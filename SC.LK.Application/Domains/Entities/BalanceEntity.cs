using System.ComponentModel.DataAnnotations.Schema;

namespace SC.LK.Application.Domains.Entities
{
    public class BalanceEntity : BaseEntity
    {
        /// <summary>
        /// Контрагент
        /// </summary>
        public Guid? ContractorId { get; set; }
        
        [ForeignKey(nameof(ContractorId))]
        public ContractorEntity Contractor { get; set; }

        /// <summary>
        /// Сумма
        /// </summary>
        public decimal Amout { get; set; }
        
        /// <summary>
        /// Бонусы
        /// </summary>
        public BonusesEntity Bonuses{ get; set; } //класс
    }
}