using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Entities;
using SC.LK.Infrastructure.Database.Contexts;

namespace SC.LK.Infrastructure.Database.Repositories;

public class BillingFaceRepository: IRepository<BillingFaceEntity>
{
    private readonly DbSet<BillingFaceEntity> _dbSet;
    private readonly ScanCityLKContext _context;

    public BillingFaceRepository(ScanCityLKContext context)
    {
        _context = context;
        _dbSet = context.Set<BillingFaceEntity>();
    }

    public IEnumerable<BillingFaceEntity> Get()
    {
        return _dbSet.AsNoTracking().ToList();
    }

    public IEnumerable<BillingFaceEntity> Get(Func<BillingFaceEntity, bool> predicate)
    {
        return _dbSet.AsNoTracking().Where(predicate).ToList();
    }

    public bool Any(Func<BillingFaceEntity, bool> predicate)
    {
        return _dbSet.AsNoTracking().Any(predicate);
    }

    public BillingFaceEntity FindById(Guid? id)
    {
        return _dbSet.Find(id);
    }

    public int Create(BillingFaceEntity item)
    {
        _dbSet.Add(item);
        return _context.SaveChanges();
    }

    public int Update(BillingFaceEntity item)
    {
        _context.Entry(item).State = EntityState.Modified;
        return _context.SaveChanges();
    }

    public int Remove(BillingFaceEntity item)
    {
        _dbSet.Remove(item);
        return _context.SaveChanges();
    }

    public IEnumerable<BillingFaceEntity> GetWithInclude(params Expression<Func<BillingFaceEntity, object>>[] includeProperties)
    {
        return Include(includeProperties).ToList();
    }

    public IEnumerable<BillingFaceEntity> GetWithInclude(Func<BillingFaceEntity, bool> predicate,
        params Expression<Func<BillingFaceEntity, object>>[] includeProperties)
    {
        var query = Include(includeProperties);
        return query.Where(predicate).ToList();
    }

    public BillingFaceEntity GetWithIncludeWithoutRelatedEntities(Guid Id)
    {
        throw new NotImplementedException();
    }

    private IQueryable<BillingFaceEntity> Include(params Expression<Func<BillingFaceEntity, object>>[] includeProperties)
    {
        IQueryable<BillingFaceEntity> query = _dbSet.AsNoTracking();
        return includeProperties
            .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
    }
}