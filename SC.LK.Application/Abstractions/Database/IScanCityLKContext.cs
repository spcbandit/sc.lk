using Microsoft.EntityFrameworkCore;
using SC.LK.Application.Domains.Entities;

namespace SC.LK.Application.Abstractions;

public interface IScanCityLKContext
{
    /// <summary>
    /// Контекст Users
    /// </summary>
    public DbSet<UserEntity> Users { get; set; }
    
    /// <summary>
    /// Контекст Balances
    /// </summary>
    public DbSet<BalanceEntity> Balances { get; set; }
    
    /// <summary>
    /// Контекст BillingFaces
    /// </summary>
    public DbSet<BillingFaceEntity> BillingFaces { get; set; }

    /// <summary>
    /// Контекст Divisions
    /// </summary>
    public DbSet<DivisionEntity> Divisions { get; set; }
    
    /// <summary>
    /// Контекст Keys
    /// </summary>
    public DbSet<KeysEntity> Keys { get; set; }
    
    /// <summary>
    /// Контекст Subscriptions
    /// </summary>
    public DbSet<SubscriptionEntity> Subscriptions { get; set; }

    /// <summary>
    /// Контекст Terminals
    /// </summary>
    public DbSet<TerminalEntity> Terminals { get; set; }
    
    /// <summary>
    /// Контекст Contractors
    /// </summary>
    public DbSet<ContractorEntity> Contractors { get; set; }

    /// <summary>
    /// Контекст PaymentSystem
    /// </summary>
    public DbSet<PaymentSystemEntity> PaymentSystem { get; set; }
}