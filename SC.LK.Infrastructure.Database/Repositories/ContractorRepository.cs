using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Entities;
using SC.LK.Infrastructure.Database.Contexts;

namespace SC.LK.Infrastructure.Database.Repositories;

public class ContractorRepository : IRepository<ContractorEntity>
{
    private readonly DbSet<ContractorEntity> _dbSet;
    private readonly ScanCityLKContext _context;

    public ContractorRepository(ScanCityLKContext context)
    {
        _context = context;
        _dbSet = context.Set<ContractorEntity>();
    }

    public IEnumerable<ContractorEntity> Get()
    {
        return _dbSet.AsNoTracking().ToList();
    }
    public bool Any(Func<ContractorEntity, bool> predicate)
    {
        return _dbSet.AsNoTracking().Any(predicate);
    }

    public IEnumerable<ContractorEntity> Get(Func<ContractorEntity, bool> predicate)
    {
        return _dbSet.AsNoTracking().Where(predicate).ToList();
    }

    public ContractorEntity FindById(Guid? id)
    {
        return _dbSet.Find(id);
    }

    public int Create(ContractorEntity item)
    {
        _dbSet.Add(item);
        return _context.SaveChanges();
    }

    public int Update(ContractorEntity item)
    {
        _context.Entry(item).State = EntityState.Modified;
        return _context.SaveChanges();
    }

    public int Remove(ContractorEntity item)
    {
        _dbSet.Remove(item);
        return _context.SaveChanges();
    }

    public IEnumerable<ContractorEntity> GetWithInclude(params Expression<Func<ContractorEntity, object>>[] includeProperties)
    {
        return Include(includeProperties).ToList();
    }

    public IEnumerable<ContractorEntity> GetWithInclude(Func<ContractorEntity, bool> predicate,
        params Expression<Func<ContractorEntity, object>>[] includeProperties)
    {
        var query = Include(includeProperties);
        return query.Where(predicate).ToList();
    }
    
    private IQueryable<ContractorEntity> Include(params Expression<Func<ContractorEntity, object>>[] includeProperties)
    {
        IQueryable<ContractorEntity> query = _dbSet.AsNoTracking();
        return includeProperties
            .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
    }
}