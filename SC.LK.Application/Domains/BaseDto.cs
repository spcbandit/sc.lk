namespace SC.LK.Application.Domains;
/// <summary>
/// Базовая сущность
/// </summary>
public class BaseDto
{
    /// <summary>
    /// Идентификатор записи
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Время последного обновления 
    /// </summary>
    public DateTime Updated { get; set; } = DateTime.Now;
}