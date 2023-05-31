using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Entities;
using SC.LK.Infrastructure.Database.Contexts;

namespace SC.LK.Infrastructure.Database.Repositories;

public class AvailableRolesRepository:IRepository<AvailableRolesEntity>
{
    private readonly DbSet<AvailableRolesEntity> _dbSet;
    private readonly ScanCityLKContext _context;
    public AvailableRolesRepository(ScanCityLKContext context)
    {
        _context = context;
        _dbSet = context.Set<AvailableRolesEntity>();
    }
    public int Create(AvailableRolesEntity item)
    {
        _dbSet.Add(item);
        return _context.SaveChanges();
    }
    public bool Any(Func<AvailableRolesEntity, bool> predicate)
    {
        return _dbSet.AsNoTracking().Any(predicate);
    }

    public AvailableRolesEntity FindById(Guid? id)
    {
        return _dbSet.Find(id);
    }

    public IEnumerable<AvailableRolesEntity> Get()
    {
        return _dbSet.AsNoTracking().ToList();
    }

    public IEnumerable<AvailableRolesEntity> Get(Func<AvailableRolesEntity, bool> predicate)
    {
        return _dbSet.AsNoTracking().Where(predicate).ToList();
    }

    public int Remove(AvailableRolesEntity item)
    {
        _dbSet.Remove(item);
        return _context.SaveChanges();
    }

    public int Update(AvailableRolesEntity item)
    {
        _dbSet.Update(item);
        return _context.SaveChanges();
    }

    public IEnumerable<AvailableRolesEntity> GetWithInclude(params Expression<Func<AvailableRolesEntity, object>>[] includeProperties)
    {
        return Include(includeProperties).ToList();
    }

    public IEnumerable<AvailableRolesEntity> GetWithInclude(Func<AvailableRolesEntity, bool> predicate, params Expression<Func<AvailableRolesEntity, object>>[] includeProperties)
    {
        var query = Include(includeProperties);
        return query.Where(predicate).ToList();
    }
    private IQueryable<AvailableRolesEntity> Include(params Expression<Func<AvailableRolesEntity, object>>[] includeProperties)
    {
        IQueryable<AvailableRolesEntity> query = _dbSet.AsNoTracking();
        return includeProperties
            .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
    }
}