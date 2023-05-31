using AutoMapper;
using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Dto;
using SC.LK.Application.Domains.InternalConnectors.RepositoryConfigurationService.Instructions;
using SC.LK.Application.Domains.RepositoryConfigurationService;
using SC.LK.Application.Domains.Requests.ParametersValues;
using SC.LK.Application.Domains.Responses.ParametersValues;

namespace SC.LK.Application.Handlers.ParametersValues;

public class UpdateParametersValuesHandler:IRequestHandler<UpdateParametersValuesRequest,UpdateParametersValuesResponse >
{
    private readonly IRepositoryConfigurationServiceAdaptor _adaptor;
    private readonly IISClient _iisClient;
    private readonly IMapper _mapper;
    public UpdateParametersValuesHandler(IRepositoryConfigurationServiceAdaptor adaptor,IISClient iisClient, IMapper mapper)
    {
        _adaptor = adaptor;
        _iisClient = iisClient;
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
    }
    public async Task<UpdateParametersValuesResponse> Handle(UpdateParametersValuesRequest request, CancellationToken cancellationToken)
    {
        var serviceToken = await _iisClient.TokenAsync(null);
        _adaptor.AuthHeader = serviceToken.JSON;
        var map = _mapper.Map<InstructionsParametersValueView>(request.ParametersValueDto);
        var res = await _adaptor.UpdateParametersValues(map);
        if (res != null)
        {
            return new UpdateParametersValuesResponse() { Success = true, ParametersValuesId = res};
        }

        return new UpdateParametersValuesResponse() { Success = false };
    }
}