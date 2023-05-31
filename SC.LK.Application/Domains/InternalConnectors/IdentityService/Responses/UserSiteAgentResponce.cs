namespace SC.LK.Application.Domains.IdentityService.Responses;

public class UserSiteAgentResponce
{
    /// <summary>
    /// Логин
    /// </summary>
    public string Login { get; set; } = null!;

    /// <summary>
    /// Пароль
    /// </summary>
    public string Password { get; set; } = null!;
}