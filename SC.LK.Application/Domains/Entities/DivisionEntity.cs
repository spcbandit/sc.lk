using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SC.LK.Application.Domains.Entities
{
    public class DivisionEntity : BaseEntity
    {
        /// <summary>
        /// Адресс подразделения
        /// </summary>
        public string? Address { get; set; }
        
        /// <summary>
        /// Name
        /// </summary>
        public string? Name { get; set; }
        
        /// <summary>
        /// PIN
        /// </summary>
        public string PIN { get; set; }

        /// <summary>
        /// Активный
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Хост
        /// </summary>
        public string? Host { get; set; }

        /// <summary>
        /// Контрагент
        /// </summary>
        public Guid? СontractorId { get; set; }
        
        [ForeignKey(nameof(СontractorId))]
        public ContractorEntity Сontractor { get; set; }
        
        /// <summary>
        /// Терминалы
        /// </summary>
        public List<TerminalEntity> Terminals { get; set; } = new List<TerminalEntity>();
    }
}