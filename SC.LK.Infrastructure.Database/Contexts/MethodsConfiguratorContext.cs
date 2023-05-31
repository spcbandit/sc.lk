using Microsoft.EntityFrameworkCore;
using SC.LK.Application.Domains.Entities;

namespace SC.LK.Infrastructure.Database.Contexts;


public class MethodsConfiguratorContext : DbContext
{
    public DbSet<MethodAccessTypeEntity> MethodAccessType { get; set; }
    public DbSet<MethodWithRoles> MethodWithRoles{ get; set; }

    /// <summary>
    /// ScanCityLKContext
    /// </summary>
    /// <param name="options"></param>
    public MethodsConfiguratorContext(DbContextOptions<MethodsConfiguratorContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}

