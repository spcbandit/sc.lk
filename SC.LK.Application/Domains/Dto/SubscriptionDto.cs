namespace SC.LK.Application.Domains.Dto;

public class SubscriptionDto : Domains.BaseDto
{
    public Guid? TerminalId { get; set; }

    /// <summary>
    /// Терминал
    /// </summary>
    public TerminalDto Terminal { get; set; }
        
    /// <summary>
    /// Позиция прайса
    /// </summary>
    public PricesDto PricePosition { get; set; }

    /// <summary>
    /// Срок валидности
    /// </summary>
    public DateTime ValidityPeriod { get; set; }
}