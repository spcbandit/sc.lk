using System.ComponentModel.DataAnnotations.Schema;
using SC.LK.Application.Domains.IdentityService.Requests;
using SC.LK.Application.Domains.Responses.User;

namespace SC.LK.Application.Domains.Entities;

public class AvailableRolesEntity:BaseEntity
{ 
    public string RoleName { get; set; }
    public decimal RoleType { get; set; }
}