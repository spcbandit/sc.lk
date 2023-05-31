using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace SC.LK.Application.Domains.Entities;

public class MethodAccessTypeEntity: BaseEntity
{
    public string MethodName { get; set; }
}