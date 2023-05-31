using System.ComponentModel.DataAnnotations;

namespace SC.LK.Application.Domains.IdentityService.Responses;

public class Service
{
    /// <summary>
    /// ServiceId
    /// </summary>
    [Key]
    public Guid ServiceId { get; set; }
}