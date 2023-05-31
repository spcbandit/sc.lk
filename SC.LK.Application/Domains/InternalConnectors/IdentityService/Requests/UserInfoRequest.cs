using Newtonsoft.Json;

namespace SC.LK.Application.Domains.IdentityService.Requests;

public class UserInfoRequest
{
    /// <summary>
    /// UserId
    /// </summary>
    [JsonProperty("userId")]
    public Guid UserId { get; set; }

    /// <summary>
    /// Активен ли аккаунт
    /// </summary>
    [JsonProperty("isActive")]
    public bool IsActive { get; set; }

    /// <summary>
    /// Имя
    /// </summary>
    [JsonProperty("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Отчество
    /// </summary>
    [JsonProperty("parent")]
    public string? Parent { get; set; }

    /// <summary>
    /// Фамилия
    /// </summary>
    [JsonProperty("family")]
    public string? Family { get; set; }
    
    /// <summary>
    /// Login
    /// </summary>
    [JsonProperty("login")]
    public string Login { get; set; } = null!;
    
    /// <summary>
    /// Password
    /// </summary>
    [JsonProperty("password")]
    public string Password { get; set; } = null!;
    
    /// <summary>
    /// ServiceId
    /// </summary>
    [JsonProperty("serviceId")]
    public ICollection<Services> ServiceId { get; set; } = null!;

    /// <summary>
    /// Удален ли аккаунт
    /// </summary>
    [JsonProperty("isDelete")]
    public bool? IsDelete { get; set; }
    
    /// <summary>
    /// UsersRoles
    /// </summary>
    [JsonProperty("userRoles")]
    public virtual ICollection<UsersRoles>? UsersRoles { get; set; }
}