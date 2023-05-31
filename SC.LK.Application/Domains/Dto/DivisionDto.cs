using System.Text.Json.Serialization;

namespace SC.LK.Application.Domains.Dto;

public class DivisionDto: Domains.BaseDto
{
    /// <summary>
    /// Адресс
    /// </summary>
    public string Address { get; set; }
    /// <summary>
    /// Name
    /// </summary>
    public string? Name { get; set; }
    
    /// <summary>
    /// Активный
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// Хост
    /// </summary>
    public string? Host { get; set; }

    /// <summary>
    /// Контрагент
    /// </summary>
    public Guid? СontractorId { get; set; }
        
    [JsonIgnore]
    public ContractorDto Сontractor { get; set; }
    public List<AgentDto> Agents { get; set; }

    /// <summary>
    /// Терминалы
    /// </summary>
    public List<TerminalDto> Terminals { get; set; } = new List<TerminalDto>();
}