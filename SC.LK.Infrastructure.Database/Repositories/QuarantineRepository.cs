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
    internal class QuarantineRepository : IRepository<QuarantineEntity>
    {
        private readonly DbSet<QuarantineEntity> _dbSet;
        private readonly ScanCityLKContext _context;
        public QuarantineRepository(ScanCityLKContext context)
        {
            _context = context;
            _dbSet = context.Set<QuarantineEntity>();
        }

        public IEnumerable<QuarantineEntity> Get()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public IEnumerable<QuarantineEntity> Get(Func<QuarantineEntity, bool> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).ToList();
        }

        public bool Any(Func<QuarantineEntity, bool> predicate)
        {
            return _dbSet.AsNoTracking().Any(predicate);
        }

        public QuarantineEntity FindById(Guid? id)
        {
            return _dbSet.Find(id);
        }

        public int Create(QuarantineEntity item)
        {
            _dbSet.Add(item);
            return _context.SaveChanges();
        }
        public int Update(QuarantineEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
            return _context.SaveChanges();
        }
        public int Remove(QuarantineEntity item)
        {
            _dbSet.Remove(item);
            return _context.SaveChanges();
        }

        public IEnumerable<QuarantineEntity> GetWithInclude(params Expression<Func<QuarantineEntity, object>>[] includeProperties)
        {
            return Include(includeProperties).ToList();
        }

        public IEnumerable<QuarantineEntity> GetWithInclude(Func<QuarantineEntity, bool> predicate,
            params Expression<Func<QuarantineEntity, object>>[] includeProperties)
        {
            var query = Include(includeProperties);
            return query.Where(predicate).ToList();
        }

        private IQueryable<QuarantineEntity> Include(params Expression<Func<QuarantineEntity, object>>[] includeProperties)
        {
            IQueryable<QuarantineEntity> query = _dbSet.AsNoTracking();
            return includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
    }
}

