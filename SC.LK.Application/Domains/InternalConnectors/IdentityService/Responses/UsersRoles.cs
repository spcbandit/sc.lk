using System.ComponentModel.DataAnnotations;

namespace SC.LK.Application.Domains.IdentityService.Responses;

public class UsersRoles
{
    /// <summary>
    /// RoleId
    /// </summary>
    [Key]
    public Guid RoleId { get; set; }

    /// <summary>
    /// ServicesIds
    /// </summary>
    public ICollection<Service> ServicesIds { get; set; } = null!;

    /// <summary>
    /// Description
    /// </summary>
    public string? Description { get; set; }        

    /// <summary>
    /// RoleType
    /// </summary>
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