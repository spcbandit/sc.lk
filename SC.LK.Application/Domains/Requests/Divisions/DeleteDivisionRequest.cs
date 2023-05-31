using MediatR;
using SC.LK.Application.Domains.Responses.Divisions;

namespace SC.LK.Application.Domains.Requests.Divisions;

public class DeleteDivisionRequest : IRequest<DeleteDivisionResponse>
{
    /// <summary>
    /// DivisionId
    /// </summary>
    public Guid DivisionId { get; set; }
}