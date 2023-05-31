using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Entities;
using SC.LK.Infrastructure.Database.Contexts;

namespace SC.LK.Infrastructure.Database.Repositories;

public class NotificationRepository:IRepository<NotificationEntity>
{
    private readonly DbSet<NotificationEntity> _dbSet;
    private readonly ScanCityLKContext _context;

    public NotificationRepository(ScanCityLKContext context)
    {
        _context = context;
        _dbSet = context.Set<NotificationEntity>();
    }

    public int Create(NotificationEntity item)
    {
        _dbSet.Add(item);
        return _context.SaveChanges();
    }

    public NotificationEntity FindById(Guid? id)
    {
        return _dbSet.Find(id);
    }

    public IEnumerable<NotificationEntity> Get()
    {
        return _dbSet.AsNoTracking().ToList();
    }

    public IEnumerable<NotificationEntity> Get(Func<NotificationEntity, bool> predicate)
    {
        return _dbSet.AsNoTracking().Where(predicate).ToList();
    }

    public bool Any(Func<NotificationEntity, bool> predicate)
    {
        return _dbSet.AsNoTracking().Any(predicate);
    }

    public int Remove(NotificationEntity item)
    {
        _dbSet.Remove(item);
        return _context.SaveChanges();
    }

    public int Update(NotificationEntity item)
    {
        _context.Entry(item).State = EntityState.Modified;
        return _context.SaveChanges();
    }

    public IEnumerable<NotificationEntity> GetWithInclude(params Expression<Func<NotificationEntity, object>>[] includeProperties)
    {
        return Include(includeProperties).ToList();
    }

    public IEnumerable<NotificationEntity> GetWithInclude(Func<NotificationEntity, bool> predicate, params Expression<Func<NotificationEntity, object>>[] includeProperties)
    {
        var query = Include(includeProperties);
        return query.Where(predicate).ToList();
    }
    private IQueryable<NotificationEntity> Include(params Expression<Func<NotificationEntity, object>>[] includeProperties)
    {
        IQueryable<NotificationEntity> query = _dbSet.AsNoTracking();
        return includeProperties
            .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
    }
}