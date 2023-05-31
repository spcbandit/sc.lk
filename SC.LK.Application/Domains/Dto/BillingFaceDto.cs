namespace SC.LK.Application.Domains.Dto;

public class BillingFaceDto: Domains.BaseDto
{
    /// <summary>
    /// Имя
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// ИНН
    /// </summary>
    public string? INN { get; set; }

    /// <summary>
    /// КПП
    /// </summary>
    public string? KPP { get; set; }
        
        
    /// <summary>
    /// Система оплаты
    /// </summary>
    public PaymentSystemDto PaymentSystem { get; set; }
        
    /// <summary>
    /// СontractorId
    /// </summary>
    public Guid? СontractorId { get; set; }
    
    public ContractorDto Сontractor { get; set; }
}