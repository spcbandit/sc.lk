using System.ComponentModel.DataAnnotations.Schema;

namespace SC.LK.Application.Domains.Entities
{
    public class TerminalEntity : BaseEntity
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string? Name { get; set; }
        
        /// <summary>
        /// Deviceid
        /// </summary>
        public string? Deviceid { get; set; }

        /// <summary>
        /// AddedScanner
        /// </summary>
        public DateTime? AddedScanner { get; set; }

        /// <summary>
        /// Подразделение
        /// </summary>
        public DivisionEntity? Division { get; set; }

        public Guid? SubscriptionId { get; set; }

        /// <summary>
        /// Подписка
        /// </summary>
        [ForeignKey(nameof(SubscriptionId))]
        public SubscriptionEntity? Subscription { get; set; }
        
    }
}