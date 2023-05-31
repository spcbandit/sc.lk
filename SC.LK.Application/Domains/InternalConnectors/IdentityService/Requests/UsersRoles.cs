using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace SC.LK.Application.Domains.IdentityService.Requests;

public class UsersRoles
{
    /// <summary>
    /// RoleId
    /// </summary>
    [Key]
    [JsonProperty("roleId")]
    public Guid RoleId { get; set; }
    
    /// <summary>
    /// ServicesIds
    /// </summary>
    [JsonProperty("servicesIds")]
    public ICollection<Service> ServicesIds { get; set; } = null!;
    
    /// <summary>
    /// Description
    /// </summary>
    [JsonProperty("description")]
    public string? Description { get; set; }   
    
    /// <summary>
    /// RoleType
    /// </summary>
    [JsonProperty("roleType")]
    public RoleType RoleType { get; set; }        
}

/// <summary>
/// RoleType
/// </summary>
public enum RoleType : byte
{
    Service = 1,
    SiteAgent = 2,
    Admin = 3,
    Manager = 4,
}