using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Entities;
using SC.LK.Infrastructure.Database.Contexts;

namespace SC.LK.Infrastructure.Database.Repositories;

public class MethodAccessTypeRepository:IRepository<MethodAccessTypeEntity>
{
    private readonly DbSet<MethodAccessTypeEntity> _dbSet;
    private readonly ScanCityLKContext _context;

    public MethodAccessTypeRepository(ScanCityLKContext context)
    {
        _context = context;
        //_context.Database.EnsureCreated();
        _dbSet = context.Set<MethodAccessTypeEntity>();
    }
    public int Create(MethodAccessTypeEntity item)
    {
        _dbSet.Add(item);
        return _context.SaveChanges();
    }

    public MethodAccessTypeEntity FindById(Guid? id)
    {
        return _dbSet.Find(id);
    }

    public IEnumerable<MethodAccessTypeEntity> Get()
    {
        return _dbSet.AsNoTracking().ToList();
    }

    public IEnumerable<MethodAccessTypeEntity> Get(Func<MethodAccessTypeEntity, bool> predicate)
    {
        return _dbSet.AsNoTracking().Where(predicate).ToList();
    }

    public bool Any(Func<MethodAccessTypeEntity, bool> predicate)
    {
        return _dbSet.AsNoTracking().Any(predicate);
    }

    public int Remove(MethodAccessTypeEntity item)
    {
        _dbSet.Remove(item);
        return _context.SaveChanges();
    }
    public int Truncate(MethodsConfiguratorContext context)
    {
        return context.Database.ExecuteSqlRaw("TRUNCATE TABLE [MethodAccessType]");
    }

    public int Update(MethodAccessTypeEntity item)
    {
        _dbSet.Update(item);
        return _context.SaveChanges();
    }

    public IEnumerable<MethodAccessTypeEntity> GetWithInclude(params Expression<Func<MethodAccessTypeEntity, object>>[] includeProperties)
    {
        return Include(includeProperties).ToList();
    }

    public IEnumerable<MethodAccessTypeEntity> GetWithInclude(Func<MethodAccessTypeEntity, bool> predicate, params Expression<Func<MethodAccessTypeEntity, object>>[] includeProperties)
    {
        var query = Include(includeProperties);
        return query.Where(predicate).ToList();
    }
    private IQueryable<MethodAccessTypeEntity> Include(params Expression<Func<MethodAccessTypeEntity, object>>[] includeProperties)
    {
        IQueryable<MethodAccessTypeEntity> query = _dbSet.AsNoTracking();
        return includeProperties
            .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
    }
}