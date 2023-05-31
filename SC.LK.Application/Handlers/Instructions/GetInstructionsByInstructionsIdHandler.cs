using AutoMapper;
using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Dto;
using SC.LK.Application.Domains.Requests.Instructions;
using SC.LK.Application.Domains.Responses.Instructions;

namespace SC.LK.Application.Handlers.Instructions;

public class GetInstructionsByInstructionsIdHandler:IRequestHandler<GetInstructionsByInstructionsIdRequest, GetInstructionsByInstructionsIdResponse>
{
    private readonly IRepositoryConfigurationServiceAdaptor _adaptor;
    private readonly IISClient _iisClient;
    private readonly IMapper _mapper;
    public GetInstructionsByInstructionsIdHandler(IRepositoryConfigurationServiceAdaptor adaptor,IISClient iisClient,IMapper mapper)
    {
        _adaptor = adaptor;
        _iisClient = iisClient;
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
    }
    public async Task<GetInstructionsByInstructionsIdResponse> Handle(GetInstructionsByInstructionsIdRequest request, CancellationToken cancellationToken)
    {
        var serviceToken = await _iisClient.TokenAsync(null);
        _adaptor.AuthHeader = serviceToken.JSON;
        var res = await _adaptor.GetInstructionsByInstructionsId(request.InstructionsId);
        var map = _mapper.Map<InstructionsRootDto>(res);
        if (res != null)
        {
            return new GetInstructionsByInstructionsIdResponse() { Success = true, InstructionsRootDto = map};
        }

        return new GetInstructionsByInstructionsIdResponse() { Success = false };
    }
}