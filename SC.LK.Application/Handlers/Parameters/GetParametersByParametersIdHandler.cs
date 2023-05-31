using AutoMapper;
using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Dto;
using SC.LK.Application.Domains.RepositoryConfigurationService;
using SC.LK.Application.Domains.Requests.InstructionsParameters;
using SC.LK.Application.Domains.Responses.InstructionsParameters;

namespace SC.LK.Application.Handlers.Parameters;

public class GetParametersHandlerByParametersIdHandler:IRequestHandler<GetParametersByParametersIdRequest,GetParametersByParametersIdResponse>
{
    private readonly IRepositoryConfigurationServiceAdaptor _adaptor;
    private readonly IISClient _iisClient;
    private readonly IMapper _mapper;
    public GetParametersHandlerByParametersIdHandler(IRepositoryConfigurationServiceAdaptor adaptor,IISClient iisClient,IMapper mapper)
    {
        _adaptor = adaptor;
        _iisClient = iisClient;
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
    }

    public async Task<GetParametersByParametersIdResponse> Handle(GetParametersByParametersIdRequest request, CancellationToken cancellationToken)
    {
        var serviceToken = await _iisClient.TokenAsync(null);
        _adaptor.AuthHeader = serviceToken.JSON;
        var res = await _adaptor.GetParametersByParameterId(request.parametersId);
        var map = _mapper.Map<InstructionsParameterDto>(res);
        if (res != null)
        {
            return new GetParametersByParametersIdResponse() { Success = true, ParameterDto = map};
        }

        return new GetParametersByParametersIdResponse() { Success = false };
    }
}