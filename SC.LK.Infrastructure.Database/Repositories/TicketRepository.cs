using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Entities;
using SC.LK.Infrastructure.Database.Contexts;

namespace SC.LK.Infrastructure.Database.Repositories;

public class TicketRepository: IRepository<TicketEntity>
{
    private readonly DbSet<TicketEntity> _dbSet;
    private readonly ScanCityLKContext _context;

    public TicketRepository(ScanCityLKContext context)
    {
        _context = context;
        _dbSet = context.Set<TicketEntity>();
    }

    public IEnumerable<TicketEntity> Get()
    {
        return _dbSet.AsNoTracking().ToList();
    }

    public IEnumerable<TicketEntity> Get(Func<TicketEntity, bool> predicate)
    {
        return _dbSet.AsNoTracking().Where(predicate).ToList();
    }

    public bool Any(Func<TicketEntity, bool> predicate)
    {
        return _dbSet.AsNoTracking().Any(predicate);
    }

    public TicketEntity FindById(Guid? id)
    {
        return _dbSet.Find(id);
    }

    public int Create(TicketEntity item)
    {
        _dbSet.Add(item);
        return _context.SaveChanges();
    }

    public int Update(TicketEntity item)
    {
        _context.Entry(item).State = EntityState.Modified;
        return _context.SaveChanges();
    }

    public int Remove(TicketEntity item)
    {
        _dbSet.Remove(item);
        return _context.SaveChanges();
    }

    public IEnumerable<TicketEntity> GetWithInclude(params Expression<Func<TicketEntity, object>>[] includeProperties)
    {
        return Include(includeProperties).ToList();
    }

    public IEnumerable<TicketEntity> GetWithInclude(Func<TicketEntity, bool> predicate,
        params Expression<Func<TicketEntity, object>>[] includeProperties)
    {
        var query = Include(includeProperties);
        return query.Where(predicate).ToList();
    }

    private IQueryable<TicketEntity> Include(params Expression<Func<TicketEntity, object>>[] includeProperties)
    {
        IQueryable<TicketEntity> query = _dbSet.AsNoTracking();
        return includeProperties
            .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
    }
}