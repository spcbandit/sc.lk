using SC.LK.Application.Domains.Dto.BaseDto;

namespace SC.LK.Application.Domains.Dto;

public class UserInfoDto
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
    /// Активен ли аккаунт
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    ///  главный контрагент для пользовател
    /// </summary>
    public Guid MainContractor { get; set; }

    /// <summary>
    /// Имя
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Отчество
    /// </summary>
    public string? Parent { get; set; }

    /// <summary>
    /// Фамилия
    /// </summary>
    public string? Family { get; set; }

    /// <summary>
    /// Login
    /// </summary>
    public string? Login { get; set; }

    /// <summary>
    /// Token
    /// </summary>
    public string? Token { get; set; }

    /// <summary>
    /// Password
    /// </summary>
    public string? Password { get; set; }

    /// <summary>
    /// Удален ли аккаунт
    /// </summary>
    public bool? IsDelete { get; set; }

    /// <summary>
    /// Контрагент
    /// </summary>
    public List<BaseContractorDto> Сontractor { get; set; }
    /// <summary>
    /// Super
    /// </summary>
    public bool IsSuper { get; set; }

}