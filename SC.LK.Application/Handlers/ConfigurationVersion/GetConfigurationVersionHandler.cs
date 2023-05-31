using AutoMapper;
using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Dto;
using SC.LK.Application.Domains.RepositoryConfigurationService;
using SC.LK.Application.Domains.Requests.ConfigurationVersion;
using SC.LK.Application.Domains.Responses.ConfigurationVersion;

namespace SC.LK.Application.Handlers.ConfigurationVersion;

public class GetConfigurationVersionHandler : IRequestHandler<GetConfigurationVersionRequest, GetConfigurationVersionResponse>
{
    private readonly IRepositoryConfigurationServiceAdaptor _repositoryConfigurationServiceAdaptor;
    private readonly IISClient _iisClient;
    private readonly IMapper _mapper;
    
    /// <summary>
    /// Создание Конфигурации
    /// </summary>
    /// <param name="repositoryContractor"></param>
    public GetConfigurationVersionHandler(IRepositoryConfigurationServiceAdaptor repositoryConfigurationServiceAdaptor, IISClient iisClient, IMapper mapper)
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
    public async Task<GetConfigurationVersionResponse> Handle(GetConfigurationVersionRequest request, CancellationToken cancellationToken)
    {
        var serviceToken = await _iisClient.TokenAsync(null);
        _repositoryConfigurationServiceAdaptor.AuthHeader = serviceToken.JSON;
        
        var res = await  _repositoryConfigurationServiceAdaptor.GetConfigurationVersionByConfigurationVersionIdAsync(request.ConfigurationVersionId);

        
        if (res != null)
        {
            var configuration = _mapper.Map<ConfigurationVersionViewDto>(res);
            return new GetConfigurationVersionResponse() {Success = true, ConfigurationVersionViewDto = configuration};
        }
        else
            return new GetConfigurationVersionResponse() {Success = false, ErrorMessage = MessageResource.FailedCreateConfigurations};
    }
}