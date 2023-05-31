using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.LK.Application.Domains
{
    /// <summary>
    /// Базовая сущность
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// Идентификатор записи
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Время последного обновления 
        /// </summary>
        public DateTime Updated { get; set; } = DateTime.Now;
    }
}
