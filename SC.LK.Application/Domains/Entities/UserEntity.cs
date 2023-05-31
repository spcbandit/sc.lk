using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SC.LK.Application.Domains.Enums;

namespace SC.LK.Application.Domains.Entities
{
    public class UserEntity : BaseEntity
    {
        /// <summary>
        /// Активен ли аккаунт
        /// </summary>
        public bool IsActive { get; set; }
        
        /// <summary>
        /// Код аутентификации
        /// </summary>
        public string? AuthCode { get; set; }
        
        /// <summary>
        ///  главный контрагент для пользовател
        /// </summary>
        public Guid MainContractor { get; set; }
        
        /// <summary>
        /// Имя
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        public string? Parent { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string? Family { get; set; }

        /// <summary>
        /// Login
        /// </summary>
        public string? Login { get; set; }
        
        /// <summary>
        /// Token
        /// </summary>
        public string? Token { get; set; }
        
        /// <summary>
        /// Password
        /// </summary>
        public string? Password { get; set; }
        
        /// <summary>
        /// Удален ли аккаунт
        /// </summary>
        public bool? IsDelete { get; set; }

        /// <summary>
        /// Контрагент
        /// </summary>
        public List<ContractorEntity> Сontractor { get; set; }
        /// <summary>
        /// Доступная роль и пермишн
        /// </summary>
        public Guid AvailableRoles { get; set; }
        /// <summary>
        /// Роль супера
        /// </summary>
        public bool IsSuper { get; set; }
    }
}
