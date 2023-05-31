using System.ComponentModel;
using MediatR;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.Responses.Divisions;

namespace SC.LK.Application.Domains.Requests.Divisions;

public class CreateDivisionRequest : IRequest<CreateDivisionResponse>
{
    /// <summary>
    /// ContractorId
    /// </summary>
    public Guid ContractorId { get; set; }
    
    /// <summary>
    /// Name
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Adress
    /// </summary>
    public string? Address { get; set; }
}