using Microsoft.EntityFrameworkCore;

using SC.LK.Application.Domains.Entities;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SC.LK.Application.Abstractions;

namespace SC.LK.Infrastructure.Database.Contexts
{
    public class ScanCityLKContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<BalanceEntity> Balances { get; set; }
        public DbSet<BillingFaceEntity> BillingFaces { get; set; }
        public DbSet<DivisionEntity> Divisions { get; set; }
        public DbSet<KeysEntity> Keys { get; set; }
        public DbSet<SubscriptionEntity> Subscriptions { get; set; }
        public DbSet<TerminalEntity> Terminals { get; set; }
        public DbSet<ContractorEntity> Contractors { get; set; }
        public DbSet<PaymentSystemEntity> PaymentSystem { get; set; }
        public DbSet<TicketEntity> Tickets { get; set; }
        public DbSet<AvailableRolesEntity> AvailableRoles { get; set; }
        public DbSet<NotificationEntity> Notification{ get; set; }
        public DbSet<MethodAccessTypeEntity> MethodAccessType { get; set; }
        public DbSet<MethodWithRoles> MethodWithRoles { get; set; }
        public DbSet<QuarantineEntity> Quarantines { get; set; }
        /// <summary>
        /// ScanCityLKContext
        /// </summary>
        /// <param name="options"></param>
        public ScanCityLKContext(DbContextOptions<ScanCityLKContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        
    }
}
