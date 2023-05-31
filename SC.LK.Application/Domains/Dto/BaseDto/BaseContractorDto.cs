using SC.LK.Application.Domains.Enums;

namespace SC.LK.Application.Domains.Dto.BaseDto;

public class BaseContractorDto
{
    /// <summary>
    /// Идентификатор записи
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Время последного обновления 
    /// </summary>
    public DateTime Updated { get; set; } = DateTime.Now;
    
    /// <summary>
    /// 
    /// </summary>
    public bool IsMain { get; set; }
    /// <summary>
    /// Name
    /// </summary>
    public string? Name { get; set; }
    
    /// <summary>
    /// Брелок
    /// </summary>
    public KeysDto Keys { get; set; }

    /// <summary>
    /// Партнер 
    /// </summary>
    public bool Partner { get; set; }
    /// <summary>
    /// Система оплаты
    /// </summary>
    public PaymentSystemType PaymentSystem { get; set; }
}