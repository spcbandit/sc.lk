using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace SC.LK.Application.Domains.IdentityService.Requests;

public class Service
{
    /// <summary>
    /// ServiceId
    /// </summary>
    [Key]
    [JsonProperty("serviceId")]
    public Guid ServiceId { get; set; }
}