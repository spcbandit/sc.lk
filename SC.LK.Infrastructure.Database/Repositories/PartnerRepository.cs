using Microsoft.EntityFrameworkCore;

using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Entities;
using SC.LK.Infrastructure.Database.Contexts;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SC.LK.Infrastructure.Database.Repositories
{
    public class PartnerRespository : IRepository<PartnerEntity>
    {
        private readonly DbSet<PartnerEntity> _dbSet;
        private readonly ScanCityLKContext _context;
        public PartnerRespository(ScanCityLKContext context)
        {
            _context = context;
            _dbSet = context.Set<PartnerEntity>();
        }

        public IEnumerable<PartnerEntity> Get()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public IEnumerable<PartnerEntity> Get(Func<PartnerEntity, bool> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).ToList();
        }

        public bool Any(Func<PartnerEntity, bool> predicate)
        {
            return _dbSet.AsNoTracking().Any(predicate);
        }

        public PartnerEntity FindById(Guid? id)
        {
            return _dbSet.Find(id);
        }

        public int Create(PartnerEntity item)
        {
            _dbSet.Add(item);
            return _context.SaveChanges();
        }
        public int Update(PartnerEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
            return _context.SaveChanges();
        }
        public int Remove(PartnerEntity item)
        {
            _dbSet.Remove(item);
            return _context.SaveChanges();
        }

        public IEnumerable<PartnerEntity> GetWithInclude(params Expression<Func<PartnerEntity, object>>[] includeProperties)
        {
            return Include(includeProperties).ToList();
        }

        public IEnumerable<PartnerEntity> GetWithInclude(Func<PartnerEntity, bool> predicate,
            params Expression<Func<PartnerEntity, object>>[] includeProperties)
        {
            var query = Include(includeProperties);
            return query.Where(predicate).ToList();
        }

        private IQueryable<PartnerEntity> Include(params Expression<Func<PartnerEntity, object>>[] includeProperties)
        {
            IQueryable<PartnerEntity> query = _dbSet.AsNoTracking();
            return includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
    }
}
