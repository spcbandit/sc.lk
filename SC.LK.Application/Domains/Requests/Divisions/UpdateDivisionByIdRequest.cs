using MediatR;
using SC.LK.Application.Domains.Responses.Divisions;

namespace SC.LK.Application.Domains.Requests.Divisions;

public class UpdateDivisionByIdRequest : IRequest<UpdateDivisionByIdResponse>
{
    /// <summary>
    /// DivisionId
    /// </summary>
    public Guid DivisionId { get; set; }
    
    /// <summary>
    /// Name
    /// </summary>
    public string? Name { get; set; }
        
    /// <summary>
    /// Adress
    /// </summary>
    public string? Address { get; set; }

    /// <summary>
    /// Активный
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// Хост
    /// </summary>
    public string? Host { get; set; }
}