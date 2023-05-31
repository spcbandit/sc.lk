
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace SC.LK.Application.Domains.Entities
{
    public class BillingFaceEntity : BaseEntity
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// ИНН
        /// </summary>
        public string? INN { get; set; }

        /// <summary>
        /// КПП
        /// </summary>
        public string? KPP { get; set; }
        
        
        /// <summary>
        /// Система оплаты
        /// </summary>
        public PaymentSystemEntity PaymentSystem { get; set; }
        
        /// <summary>
        /// СontractorId
        /// </summary>
        public Guid? СontractorId { get; set; }
        
        [ForeignKey(nameof(СontractorId))]
        public ContractorEntity Сontractor { get; set; }
    }
}