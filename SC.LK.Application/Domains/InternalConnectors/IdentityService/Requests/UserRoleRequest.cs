namespace SC.LK.Application.Domains.IdentityService.Requests;

public class UserRoleRequest
{
    /// <summary>
    /// RoleId
    /// </summary>
    public Guid RoleId { get; set; }

    /// <summary>
    /// ServiceId
    /// </summary>
    public ICollection<Services> ServiceId { get; set; } = null!;

    /// <summary>
    /// Description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// RoleType
    /// </summary>
    public byte RoleType { get; set; }
}