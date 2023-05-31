using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using SC.LK.Application.Domains.Enums;

namespace SC.LK.Application.Domains.Entities
{
    public class ContractorEntity : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public Guid? ParentContractorId { get; set; }

        /// <summary>
        /// Тип
        /// </summary>
        public ContractorType Type { get; set; }
        
        /// <summary>
        /// Статус
        /// </summary>
        public ContractorStatusType Status { get; set; }

        /// <summary>
        /// Родительский контрагент
        /// </summary>
        public ContractorEntity? ParentContractor { get; set; }

        /// <summary>
        /// Дочерние клиенты
        /// </summary>
        public List<ContractorEntity> ChildContractors { get; set; } 
            = new List<ContractorEntity>();

        /// <summary>
        /// Name
        /// </summary>
        public string? Name { get; set; }
        
        /// <summary>
        /// Пользователи
        /// </summary>
        public List<UserEntity> Users { get; set; }

        /// <summary>
        /// Биллинг лица
        /// </summary>
        public List<BillingFaceEntity> BillingFaces { get; set; }
        
        /// <summary>
        /// Брелок
        /// </summary>
        public KeysEntity Keys { get; set; }

        /// <summary>
        /// Партнер 
        /// </summary>
        public bool Partner { get; set; }
        
        /// <summary>
        /// Подразделения
        /// </summary>
        public List<DivisionEntity> Division { get; set; } = new List<DivisionEntity>();
        
        /// <summary>
        /// Система оплаты
        /// </summary>
        public PaymentSystemType PaymentSystem { get; set; }
    }
}