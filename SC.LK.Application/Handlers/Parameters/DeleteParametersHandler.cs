using AutoMapper;
using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Dto;
using SC.LK.Application.Domains.RepositoryConfigurationService;
using SC.LK.Application.Domains.Requests.InstructionsParameters;
using SC.LK.Application.Domains.Responses.Instructions;
using SC.LK.Application.Domains.Responses.InstructionsParameters;

namespace SC.LK.Application.Handlers.Parameters;

public class DeleteParametersHandler : IRequestHandler<DeleteParametersRequest, DeleteParametersResponse>
{
    private readonly IRepositoryConfigurationServiceAdaptor _adaptor;
    private readonly IISClient _iisClient;

    public DeleteParametersHandler(IRepositoryConfigurationServiceAdaptor adaptor, IISClient iisClient, IMapper mapper)
    {
        _adaptor = adaptor;
        _iisClient = iisClient;
    }

    public async Task<DeleteParametersResponse> Handle(DeleteParametersRequest request,
        CancellationToken cancellationToken)
    {
        var serviceToken = await _iisClient.TokenAsync(null);
        _adaptor.AuthHeader = serviceToken.JSON;
        var res = await _adaptor.DeleteParameters(request.ParametersId);
        if (res != Guid.Empty)
        {
            return new DeleteParametersResponse() { Success = true, ParametersId = res };
        }

        return new DeleteParametersResponse() { Success = false };
    }
}