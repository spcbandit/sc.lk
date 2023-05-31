namespace SC.LK.Application.Domains.Dto;

public class PricesDto : Domains.BaseDto
{
    /// <summary>
    /// Название
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// Периодичность
    /// </summary>
    public string? Frequency { get; set; }

    /// <summary>
    /// CountDays
    /// </summary>
    public int CountDays { get; set; }

    /// <summary>
    /// Стоимость
    /// </summary>
    public decimal Price {get; set; }
}