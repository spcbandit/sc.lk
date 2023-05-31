using MediatR;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.Responses.Profile;

namespace SC.LK.Application.Domains.Requests.Profile;

public class GetUserInfoRequest : IRequest<GetUserInfoResponse>
{
    /// <summary>
    /// UserId
    /// </summary>
    public Guid UserId { get; set;}
}