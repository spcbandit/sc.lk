using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Entities;
using SC.LK.Infrastructure.Database.Contexts;

namespace SC.LK.Infrastructure.Database.Repositories;

public class DivisionRepository: IRepository<DivisionEntity>
{
    private readonly DbSet<DivisionEntity> _dbSet;
    private readonly ScanCityLKContext _context;

    public DivisionRepository(ScanCityLKContext context)
    {
        _context = context;
        _context.Database.EnsureCreated();
        _dbSet = context.Set<DivisionEntity>();
    }

    public IEnumerable<DivisionEntity> Get()
    {
        return _dbSet.AsNoTracking().ToList();
    }

    public IEnumerable<DivisionEntity> Get(Func<DivisionEntity, bool> predicate)
    {
        return _dbSet.AsNoTracking().Where(predicate).ToList();
    }

    public bool Any(Func<DivisionEntity, bool> predicate)
    {
        return _dbSet.AsNoTracking().Any(predicate);
    }

    public DivisionEntity FindById(Guid? id)
    {
        return _dbSet.Find(id);
    }

    public int Create(DivisionEntity item)
    {
        _dbSet.Add(item);
        return _context.SaveChanges();
    }

    public int Update(DivisionEntity item)
    {
        _context.Entry(item).State = EntityState.Modified;
        return _context.SaveChanges();
    }

    public int Remove(DivisionEntity item)
    {
        _dbSet.Remove(item);
        return _context.SaveChanges();
    }

    public IEnumerable<DivisionEntity> GetWithInclude(params Expression<Func<DivisionEntity, object>>[] includeProperties)
    {
        return Include(includeProperties).ToList();
    }

    public IEnumerable<DivisionEntity> GetWithInclude(Func<DivisionEntity, bool> predicate,
        params Expression<Func<DivisionEntity, object>>[] includeProperties)
    {
        var query = Include(includeProperties);
        return query.Where(predicate).ToList();
    }

    private IQueryable<DivisionEntity> Include(params Expression<Func<DivisionEntity, object>>[] includeProperties)
    {
        IQueryable<DivisionEntity> query = _dbSet.AsNoTracking();
        return includeProperties
            .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
    }
}