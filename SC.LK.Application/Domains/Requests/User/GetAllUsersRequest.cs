using MediatR;
using SC.LK.Application.Domains.Responses.User;

namespace SC.LK.Application.Domains.Requests.User;

public class GetAllUsersRequest : IRequest<GetAllUsersResponse>
{
    /// <summary>
    /// ContractorId
    /// </summary>
    public Guid ContractorId { get; set; }
    
    /// <summary>
    /// UserId
    /// </summary>
    public Guid UserId { get; set; }
}