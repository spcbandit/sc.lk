using AutoMapper;
using MediatR;
using Newtonsoft.Json;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Abstractions.ConfiguratorDispatcher;
using SC.LK.Application.Domains.ConfiguratorDispatcher.Data;
using SC.LK.Application.Domains.Dto;
using SC.LK.Application.Domains.Requests.BusinessProcessConfigurator;
using SC.LK.Application.Domains.Responses.BusinessProcessConfigurator;

namespace SC.LK.Application.Handlers.BusinessProcessConfigurator;

public class GetBusinessProcessByIdHandler: IRequestHandler<GetBusinessProcessByIdRequest, GetBusinessProcessByIdResponse>
{
    private readonly IRepositoryConfigurationServiceAdaptor _repositoryConfigurationServiceAdaptor;
    private readonly IISClient _iisClient;
    private readonly IHtmlGenerator _htmlGenerator;
    private readonly IMapper _mapper;
    
    /// <summary>
    /// Получение бизнес процесса
    /// </summary>
    /// <param name="repositoryContractor"></param>
    public GetBusinessProcessByIdHandler(IRepositoryConfigurationServiceAdaptor repositoryConfigurationServiceAdaptor,
        IISClient iisClient, IHtmlGenerator htmlGenerator, IMapper mapper)
    {
        _htmlGenerator = htmlGenerator ?? throw new ArgumentException(nameof(htmlGenerator));
        _repositoryConfigurationServiceAdaptor = repositoryConfigurationServiceAdaptor ?? throw new ArgumentException(nameof(repositoryConfigurationServiceAdaptor));
        _iisClient = iisClient ?? throw new ArgumentException(nameof(iisClient));
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
    }

    /// <summary>
    /// Получение бизнес процесса
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<GetBusinessProcessByIdResponse> Handle(GetBusinessProcessByIdRequest request, CancellationToken cancellationToken)
    {
        //get token
        var serviceToken = await _iisClient.TokenAsync(null);
        _repositoryConfigurationServiceAdaptor.AuthHeader = serviceToken.JSON;

        var businessProcess = await _repositoryConfigurationServiceAdaptor
            .GetBusinessProcessByBusinessProcessIdAsync(request.BusinessProcessId);
        
        var mapBusinessProcess = _mapper.Map<BusinessProcessViewDto>(businessProcess);


        if (businessProcess != null)
            return new GetBusinessProcessByIdResponse()
            {
                Success = true, 
                BusinessProcess = mapBusinessProcess, 
            };
        else
            return new GetBusinessProcessByIdResponse() {Success = false, ErrorMessage = MessageResource.FailedGetConfigurations}; 
    }
}