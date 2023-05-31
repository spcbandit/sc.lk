using MediatR;
using SC.LK.Application.Domains.Responses.Templates;

namespace SC.LK.Application.Domains.Requests.Templates;

public class CreateTemplatesRequest : IRequest<CreateTemplatesResponse>
{
    /// <summary>
    /// ContractorId
    /// </summary>
    public Guid ContractorId { get; set; }
    /// <summary>
    /// Наименование
    /// </summary>
    public string? Name { get; set; }
        
    /// <summary>
    /// Предопределенный
    /// </summary>
    public bool IsDefault { get; set; }

    /// <summary>
    /// JSON Body
    /// </summary>
    public string? JsonBody { get; set; }

    /// <summary>
    /// Позиция прайса
    /// </summary>
    public Guid PricePositionId { get; set; }
}