using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SC.LK.Application.Abstractions
{
    /// <summary>
    /// Интерфейс базового репозитория для работы с бд
    /// </summary>
    /// <typeparam name="BaseEntity">Базовая сущность интерфейса (БС)</typeparam>
    public interface IRepository<BaseEntity>
    {
        /// <summary>
        /// Создание БС
        /// </summary>
        /// <param name="item">Базовая сущность</param>
        int Create(BaseEntity item);

        /// <summary>
        /// Поиск по Id БС
        /// </summary>
        /// <param name="id">Идентификатор записи</param>
        /// <returns></returns>
        BaseEntity FindById(Guid? id);

        /// <summary>
        /// Получения всех БС 
        /// </summary>
        /// <returns></returns>
        IEnumerable<BaseEntity> Get();

        /// <summary>
        /// Получение БС по предикату
        /// </summary>
        /// <param name="predicate">Условие получения</param>
        /// <returns></returns>
        IEnumerable<BaseEntity> Get(Func<BaseEntity, bool> predicate);
        /// <summary>
        /// Any
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>

        public bool Any(Func<BaseEntity, bool> predicate);

        /// <summary>
        /// Удаление БС
        /// </summary>
        /// <param name="item">Базовая сущность</param>
        int Remove(BaseEntity item);

        /// <summary>
        /// Обновление БС
        /// </summary>
        /// <param name="item">Базовая сущность</param>
        int Update(BaseEntity item);
        
        /// <summary>
        /// Получение БС со связными сущностями
        /// </summary>
        /// <param name="includeProperties">Связные сущности</param>
        /// <returns></returns>
        public IEnumerable<BaseEntity> GetWithInclude(params Expression<Func<BaseEntity, object>>[] includeProperties);

        /// <summary>
        /// Получение БС со связными сущностями с предикатом
        /// </summary>
        /// <param name="predicate">Условие получение</param>
        /// <param name="includeProperties">Связные сущности</param>
        /// <returns></returns>
        public IEnumerable<BaseEntity> GetWithInclude(Func<BaseEntity, bool> predicate, params Expression<Func<BaseEntity, object>>[] includeProperties);
    }
}
