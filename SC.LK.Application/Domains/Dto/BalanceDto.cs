namespace SC.LK.Application.Domains.Dto;

public class BalanceDto: Domains.BaseDto
{
    /// <summary>
    /// Контрагент
    /// </summary>
    public Guid? ContractorId { get; set; }
        
    public ContractorDto Contractor { get; set; }

    /// <summary>
    /// Сумма
    /// </summary>
    public decimal Amout { get; set; }
        
    /// <summary>
    /// Бонусы
    /// </summary>
    public BonusesDto Bonuses{ get; set; } //класс
}