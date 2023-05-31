using AutoMapper;
using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Dto;
using SC.LK.Application.Domains.Requests.ConfigurationVersion;
using SC.LK.Application.Domains.Responses.ConfigurationVersion;

namespace SC.LK.Application.Handlers.ConfigurationVersion;

public class GetAllConfigurationVersionHandler : IRequestHandler<GetAllConfigurationVersionRequest, GetAllConfigurationsVersionResponse>
{
    private readonly IRepositoryConfigurationServiceAdaptor _repositoryConfigurationServiceAdaptor;
    private readonly IISClient _iisClient;
    private readonly IMapper _mapper;
    
    /// <summary>
    /// Создание Конфигурации
    /// </summary>
    /// <param name="repositoryContractor"></param>
    public GetAllConfigurationVersionHandler(IRepositoryConfigurationServiceAdaptor repositoryConfigurationServiceAdaptor, IISClient iisClient, IMapper mapper)
    {
        _repositoryConfigurationServiceAdaptor = repositoryConfigurationServiceAdaptor ?? throw new ArgumentException(nameof(repositoryConfigurationServiceAdaptor));
        _iisClient = iisClient ?? throw new ArgumentException(nameof(iisClient));
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
    }

    /// <summary>
    /// Создание Конфигурации
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<GetAllConfigurationsVersionResponse> Handle(GetAllConfigurationVersionRequest request, CancellationToken cancellationToken)
    {
        var serviceToken = await _iisClient.TokenAsync(null);
        _repositoryConfigurationServiceAdaptor.AuthHeader = serviceToken.JSON;
        
        var res = await  _repositoryConfigurationServiceAdaptor.GetConfigurationVersionsByConfigurationIdAsync(request.ConfigurationId);

        if (res != null)
        {
            var ConfigurationVersions = _mapper.Map<List<ConfigurationVersionViewDto>>(res);
            return new GetAllConfigurationsVersionResponse()
                {Success = true, ConfigurationVersions = ConfigurationVersions};
        }
        else
            return new GetAllConfigurationsVersionResponse() {Success = false, ErrorMessage = MessageResource.FailedCreateConfigurations};
    }
}