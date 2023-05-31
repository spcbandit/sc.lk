using AutoMapper;
using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Dto;
using SC.LK.Application.Domains.Requests.ParametersValues;
using SC.LK.Application.Domains.Responses.ParametersValues;

namespace SC.LK.Application.Handlers.ParametersValues;

public class GetParametersValuesByParametersValuesIdHandler:IRequestHandler<GetParametersValuesByParametersValuesIdRequest, GetParametersValuesByParametersValuesIdResponse>
{
    private readonly IRepositoryConfigurationServiceAdaptor _adaptor;
    private readonly IISClient _iisClient;
    private readonly IMapper _mapper;
    public GetParametersValuesByParametersValuesIdHandler(IRepositoryConfigurationServiceAdaptor adaptor,IISClient iisClient, IMapper mapper)
    {
        _adaptor = adaptor;
        _iisClient = iisClient;
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
    }
    public async Task<GetParametersValuesByParametersValuesIdResponse> Handle(GetParametersValuesByParametersValuesIdRequest request, CancellationToken cancellationToken)
    {
        var serviceToken = await _iisClient.TokenAsync(null);
        _adaptor.AuthHeader = serviceToken.JSON;
        var res = await _adaptor.GetParametersValuesByParameterValuesId(request.ParametersValuesId);
        var map = _mapper.Map<InstructionsParametersValueDto>(res);
        if (res != null)
        {
            return new GetParametersValuesByParametersValuesIdResponse() { Success = true, ParametersValueDto = map};
        }

        return new GetParametersValuesByParametersValuesIdResponse() { Success = false };
    }
    
}