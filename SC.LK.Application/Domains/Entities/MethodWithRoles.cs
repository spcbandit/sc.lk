using System.ComponentModel.DataAnnotations.Schema;

namespace SC.LK.Application.Domains.Entities;

public class MethodWithRoles:BaseEntity
{
    public Guid Id { get; set; }
    public Guid AvailableRoleId { get; set; }
    public Guid MethodAccessTypesEntitiesId { get; set; }
}