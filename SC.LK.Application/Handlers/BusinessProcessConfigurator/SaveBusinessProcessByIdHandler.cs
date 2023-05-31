using System.Text.Json.Nodes;
using MediatR;
using Microsoft.AspNetCore.Http.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NLog.Targets;
using RestSharp.Serialization.Json;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Abstractions.ConfiguratorDispatcher;
using SC.LK.Application.Domains.ConfiguratorDispatcher.Data;
using SC.LK.Application.Domains.ExternalConnectors.DaDataService;
using SC.LK.Application.Domains.IdentityService.Requests;
using SC.LK.Application.Domains.RepositoryConfigurationService;
using SC.LK.Application.Domains.Requests.BusinessProcessConfigurator;
using SC.LK.Application.Domains.Responses.BusinessProcessConfigurator;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace SC.LK.Application.Handlers.BusinessProcessConfigurator;

public class SaveBusinessProcessByIdHandler: IRequestHandler<SaveBusinessProcessByIdRequest, SaveBusinessProcessByIdResponse>
{
    private readonly IRepositoryConfigurationServiceAdaptor _repositoryConfigurationServiceAdaptor;
    private readonly IISClient _iisClient;
    string name;
    /// <summary>
    /// Получение бизнес процесса
    /// </summary>
    /// <param name="repositoryContractor"></param>
    public SaveBusinessProcessByIdHandler(IRepositoryConfigurationServiceAdaptor repositoryConfigurationServiceAdaptor, IISClient iisClient)
    {
        _repositoryConfigurationServiceAdaptor = repositoryConfigurationServiceAdaptor ?? throw new ArgumentException(nameof(repositoryConfigurationServiceAdaptor));
        _iisClient = iisClient ?? throw new ArgumentException(nameof(iisClient));
    }

    /// <summary>
    /// Получение бизнес процесса
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<SaveBusinessProcessByIdResponse> Handle(SaveBusinessProcessByIdRequest request, CancellationToken cancellationToken)
    {
        //get token
        var serviceToken = await _iisClient.TokenAsync(null);
        _repositoryConfigurationServiceAdaptor.AuthHeader = serviceToken.JSON;
        
        var businessProcess = await _repositoryConfigurationServiceAdaptor.GetBusinessProcessByBusinessProcessIdAsync(request.BusinessProcessId);

        if (businessProcess != null)
        {
            businessProcess.JsonBody = request.JsonConfiguration;
            businessProcess.BusinessProcessName = GetName(request.JsonConfiguration);
            businessProcess.BusinessProcessDescription = businessProcess.BusinessProcessDescription ?? string.Empty;
                
            var res = await _repositoryConfigurationServiceAdaptor.UpdateBusinessProcessAsync(request.BusinessProcessId, businessProcess);
            
            if (res != null)
                return new SaveBusinessProcessByIdResponse() {Success = true};
            else
                return new SaveBusinessProcessByIdResponse() {Success = false, ErrorMessage = MessageResource.FailedUpdateBusinessProcess}; 
        }
        else
            return new SaveBusinessProcessByIdResponse() {Success = false, ErrorMessage = MessageResource.FailedGetBusinessProcess};
        
    }

    public string GetName(string configuration)
    {
        int firstIndex = configuration.IndexOf("{\"active\"");
        int lastIndex = configuration.IndexOf("},");
        string inf = configuration.Substring(firstIndex, lastIndex - firstIndex) + "}";
        JObject rss = JObject.Parse(inf);
        string rssTitle = (string)rss["name"];
        return rssTitle;
        
    }
}