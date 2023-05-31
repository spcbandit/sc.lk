using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SC.LK.Application.Domains.Entities
{
    public class SubscriptionEntity : BaseEntity
    {
        /// <summary>
        /// Терминал
        /// </summary>
        public TerminalEntity Terminal { get; set; }
        
        /// <summary>
        /// Позиция прайса
        /// </summary>
        public PricesEntity PricePosition { get; set; }

        /// <summary>
        /// Срок валидности
        /// </summary>
        public DateTime ValidityPeriod { get; set; }
    }
}