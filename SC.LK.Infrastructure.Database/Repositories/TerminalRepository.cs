using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Entities;
using SC.LK.Infrastructure.Database.Contexts;

namespace SC.LK.Infrastructure.Database.Repositories;

public class TerminalRepository : IRepository<TerminalEntity>
{
    private readonly DbSet<TerminalEntity> _dbSet;
    private readonly ScanCityLKContext _context;

    public TerminalRepository(ScanCityLKContext context)
    {
        _context = context;
        _dbSet = context.Set<TerminalEntity>();
    }

    public IEnumerable<TerminalEntity> Get()
    {
        return _dbSet.AsNoTracking().ToList();
    }

    public IEnumerable<TerminalEntity> Get(Func<TerminalEntity, bool> predicate)
    {
        return _dbSet.AsNoTracking().Where(predicate).ToList();
    }

    public bool Any(Func<TerminalEntity, bool> predicate)
    {
        return _dbSet.AsNoTracking().Any(predicate);
    }

    public TerminalEntity FindById(Guid? id)
    {
        return _dbSet.Find(id);
    }

    public int Create(TerminalEntity item)
    {
        _dbSet.Add(item);
        return _context.SaveChanges();
    }

    public int Update(TerminalEntity item)
    {
        _context.Entry(item).State = EntityState.Modified;
        return _context.SaveChanges();
    }

    public int Remove(TerminalEntity item)
    {
        _dbSet.Remove(item);
        return _context.SaveChanges();
    }

    public IEnumerable<TerminalEntity> GetWithInclude(params Expression<Func<TerminalEntity, object>>[] includeProperties)
    {
        return Include(includeProperties).ToList();
    }

    public IEnumerable<TerminalEntity> GetWithInclude(Func<TerminalEntity, bool> predicate,
        params Expression<Func<TerminalEntity, object>>[] includeProperties)
    {
        var query = Include(includeProperties);
        return query.Where(predicate).ToList();
    }

    private IQueryable<TerminalEntity> Include(params Expression<Func<TerminalEntity, object>>[] includeProperties)
    {
        IQueryable<TerminalEntity> query = _dbSet.AsNoTracking();
        return includeProperties
            .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
    }
}