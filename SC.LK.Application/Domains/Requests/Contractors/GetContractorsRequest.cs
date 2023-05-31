using System.ComponentModel;
using System.Runtime.CompilerServices;
using MediatR;
using SC.LK.Application.Domains.Responses.Contractors;

namespace SC.LK.Application.Domains.Requests.Contractors;

public class GetContractorsRequest : IRequest<GetContractorsResponse>
{
    /// <summary>
    /// UserId
    /// </summary>
    public Guid UserId { get; set; }
}