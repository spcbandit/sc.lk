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
    public class UserRespository : IRepository<UserEntity>
    {
        private readonly DbSet<UserEntity> _dbSet;
        private readonly ScanCityLKContext _context;
        public UserRespository(ScanCityLKContext context)
        {
            _context = context;
            
            _dbSet = context.Set<UserEntity>();
        }

        public IEnumerable<UserEntity> Get()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public IEnumerable<UserEntity> Get(Func<UserEntity, bool> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).ToList();
        }

        public bool Any(Func<UserEntity, bool> predicate)
        {
            return _dbSet.AsNoTracking().Any(predicate);
        }

        public UserEntity FindById(Guid? id)
        {
            return _dbSet.Find(id);
        }

        public int Create(UserEntity item)
        {
            _dbSet.Add(item);
            return _context.SaveChanges();
        }
        public int Update(UserEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
            return _context.SaveChanges();
        }
        public int Remove(UserEntity item)
        {
            _dbSet.Remove(item);
            return _context.SaveChanges();
        }

        public IEnumerable<UserEntity> GetWithInclude(params Expression<Func<UserEntity, object>>[] includeProperties)
        {
            return Include(includeProperties).ToList();
        }
        
        public UserEntity GetWithIncludeWithoutRelatedEntities(Guid Id)
        {
            var query = _context.Users.Where(x => x.Id == Id).Include(x => x.Сontractor).FirstOrDefault();
            return query;
        }

        public IEnumerable<UserEntity> GetWithInclude(Func<UserEntity, bool> predicate,
            params Expression<Func<UserEntity, object>>[] includeProperties)
        {
            var query = Include(includeProperties);
            return query.Where(predicate).ToList();
        }

        private IQueryable<UserEntity> Include(params Expression<Func<UserEntity, object>>[] includeProperties)
        {
            IQueryable<UserEntity> query = _dbSet.AsNoTracking();
            return includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
    }
}
