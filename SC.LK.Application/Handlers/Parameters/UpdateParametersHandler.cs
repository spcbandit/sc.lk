using AutoMapper;
using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Dto;
using SC.LK.Application.Domains.RepositoryConfigurationService;
using SC.LK.Application.Domains.Requests.InstructionsParameters;
using SC.LK.Application.Domains.Responses.Instructions;
using SC.LK.Application.Domains.Responses.InstructionsParameters;

namespace SC.LK.Application.Handlers.Parameters;

public class UpdateParametersHandler:IRequestHandler<UpdateParametersRequest,UpdateParametersResponse>
{
    private readonly IRepositoryConfigurationServiceAdaptor _adaptor;
    private readonly IISClient _iisClient;
    private readonly IMapper _mapper;
    public UpdateParametersHandler(IRepositoryConfigurationServiceAdaptor adaptor,IISClient iisClient,IMapper mapper)
    {
        _adaptor = adaptor;
        _iisClient = iisClient;
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
    }
    public async Task<UpdateParametersResponse> Handle(UpdateParametersRequest request, CancellationToken cancellationToken)
    {
        var serviceToken = await _iisClient.TokenAsync(null);
        _adaptor.AuthHeader = serviceToken.JSON;
        var map = _mapper.Map<InstructionsParameterView>(request.ParameterDto);
        var res = await _adaptor.UpdateParameters(map);
        if (res != Guid.Empty)
        {
            return new UpdateParametersResponse() { Success = true, ParametersId = res};
        }

        return new UpdateParametersResponse() { Success = false };
    }
}