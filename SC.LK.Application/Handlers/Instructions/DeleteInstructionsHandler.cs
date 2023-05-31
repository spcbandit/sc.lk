using AutoMapper;
using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Dto;
using SC.LK.Application.Domains.Requests.Instructions;
using SC.LK.Application.Domains.Responses.Instructions;

namespace SC.LK.Application.Handlers.Instructions;

public class DeleteInstructionsHandler:IRequestHandler<DeleteInstructionsRequest, DeleteInstructionsResponse>
{
    private readonly IRepositoryConfigurationServiceAdaptor _adaptor;
    private readonly IISClient _iisClient;
    
    public DeleteInstructionsHandler(IRepositoryConfigurationServiceAdaptor adaptor,IISClient iisClient)
    {
        _adaptor = adaptor;
        _iisClient = iisClient;
    }
    public async Task<DeleteInstructionsResponse> Handle(DeleteInstructionsRequest request, CancellationToken cancellationToken)
    {
        var serviceToken = await _iisClient.TokenAsync(null);
        _adaptor.AuthHeader = serviceToken.JSON;
        var res = await _adaptor.DeleteInstruction(request.InstructionsId);
       
        if (res != null)
        {
            return new DeleteInstructionsResponse() { Success = true, Response = res};
        }

        return new DeleteInstructionsResponse() { Success = false };
    }
}