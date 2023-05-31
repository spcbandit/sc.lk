using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Entities;
using SC.LK.Infrastructure.Database.Contexts;

namespace SC.LK.Infrastructure.Database.Repositories;

public class MethodRolesRepository:IRepository<MethodWithRoles>
{
    private readonly DbSet<MethodWithRoles> _dbSet;
    private readonly ScanCityLKContext _context;
    public MethodRolesRepository(ScanCityLKContext context)
    {
        _context = context;
        _dbSet = context.Set<MethodWithRoles>();
    }
    public int Create(MethodWithRoles item)
    {
        _dbSet.Add(item);
        return _context.SaveChanges();
    }

    public MethodWithRoles FindById(Guid? id)
    {
        return _dbSet.Find(id);
    }

    public IEnumerable<MethodWithRoles> Get()
    {
        return _dbSet.AsNoTracking().ToList();
    }

    public IEnumerable<MethodWithRoles> Get(Func<MethodWithRoles, bool> predicate)
    {
        return _dbSet.AsNoTracking().Where(predicate).ToList();
    }

    public bool Any(Func<MethodWithRoles, bool> predicate)
    {
        return _dbSet.AsNoTracking().Any(predicate);
    }

    public int Remove(MethodWithRoles item)
    {
        _dbSet.Remove(item);
        return _context.SaveChanges();
    }

    public int Update(MethodWithRoles item)
    {
        _context.Entry(item).State = EntityState.Modified;
        return _context.SaveChanges();
    }

    public IEnumerable<MethodWithRoles> GetWithInclude(params Expression<Func<MethodWithRoles, object>>[] includeProperties)
    {
        return Include(includeProperties).ToList();
    }

    public IEnumerable<MethodWithRoles> GetWithInclude(Func<MethodWithRoles, bool> predicate, params Expression<Func<MethodWithRoles, object>>[] includeProperties)
    {
        var query = Include(includeProperties);
        return query.Where(predicate).ToList();
    }
    private IQueryable<MethodWithRoles> Include(params Expression<Func<MethodWithRoles, object>>[] includeProperties)
    {
        IQueryable<MethodWithRoles> query = _dbSet.AsNoTracking();
        return includeProperties
            .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
    }
}