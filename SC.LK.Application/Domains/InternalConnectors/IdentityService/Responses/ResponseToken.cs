using Newtonsoft.Json;

namespace SC.LK.Application.Domains.IdentityService.Responses;


public record ResponseToken
{
    /// <summary>
    /// JSON
    /// </summary>
    [JsonProperty("json")]
    public string JSON { get; init; } = null!;

    /// <summary>
    /// UserId
    /// </summary>
    [JsonProperty("username")]
    public Guid UserId { get; init; }
}
