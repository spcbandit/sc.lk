using AutoMapper;
using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Requests.ParametersValues;
using SC.LK.Application.Domains.Responses.ParametersValues;

namespace SC.LK.Application.Handlers.ParametersValues;

public class DeleteParametersValuesHandler:IRequestHandler<DeleteParametersValuesRequest, DeleteParametersValuesResponse>
{
    private readonly IRepositoryConfigurationServiceAdaptor _adaptor;
    private readonly IISClient _iisClient;
    private readonly IMapper _mapper;
    public DeleteParametersValuesHandler(IRepositoryConfigurationServiceAdaptor adaptor,IISClient iisClient, IMapper mapper)
    {
        _adaptor = adaptor;
        _iisClient = iisClient;
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
    }
    public async Task<DeleteParametersValuesResponse> Handle(DeleteParametersValuesRequest request, CancellationToken cancellationToken)
    {
        var serviceToken = await _iisClient.TokenAsync(null);
        _adaptor.AuthHeader = serviceToken.JSON;
        var res = await _adaptor.DeleteParametersValues(request.ParametersValuesId);
        if (res != Guid.Empty)
        {
            return new DeleteParametersValuesResponse() { Success = true, ParametersValuesId = res};
        }

        return new DeleteParametersValuesResponse() { Success = false };
    }
}