namespace SC.LK.Application.Domains.Dto;

public class PaymentSystemDto : Domains.BaseDto
{
    /// <summary>
    /// Имя
    /// </summary>
    public string? Name { get; set; }
        
    /// <summary>
    /// Token
    /// </summary>
    public string? Token { get; set; }

    /// <summary>
    /// MainUrl
    /// </summary>
    public string? MainUrl { get; set; }
        
}