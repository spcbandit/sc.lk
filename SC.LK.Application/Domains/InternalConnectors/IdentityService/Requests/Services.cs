using Newtonsoft.Json;

namespace SC.LK.Application.Domains.IdentityService.Requests;

/// <summary>
/// Id сервисов к которым принаждлежит роль или пользователь
/// </summary>
public record Services
{
    /// <summary>
    /// ServiceId
    /// </summary>
    [JsonProperty("serviceId")]
    public Guid ServiceId { get; set; }
}