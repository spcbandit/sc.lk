using AutoMapper;
using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Dto;
using SC.LK.Application.Domains.InternalConnectors.RepositoryConfigurationService.Instructions;
using SC.LK.Application.Domains.Requests.Instructions;
using SC.LK.Application.Domains.Responses.Instructions;

namespace SC.LK.Application.Handlers.Instructions;

public class AddInstructionsHandler:IRequestHandler<AddInstructionsRequest, AddInstructionsResponse>
{
    private readonly IRepositoryConfigurationServiceAdaptor _adaptor;
    private readonly IISClient _iisClient;
    private readonly IMapper _mapper;
    public AddInstructionsHandler(IRepositoryConfigurationServiceAdaptor adaptor,IISClient iisClient,IMapper mapper)
    {
        _adaptor = adaptor;
        _iisClient = iisClient;
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
    }
    public async Task<AddInstructionsResponse> Handle(AddInstructionsRequest request, CancellationToken cancellationToken)
    {
        var serviceToken = await _iisClient.TokenAsync(null);
        _adaptor.AuthHeader = serviceToken.JSON;
        var map = _mapper.Map<InstructionsRootView>(request.InstructionsDto);
        var res = await _adaptor.AddInstruction(map);
        if (res != null)
        {
            return new AddInstructionsResponse() { Success = true, AddedInstructionId = res};
        }

        return new AddInstructionsResponse() { Success = false };
    }
}