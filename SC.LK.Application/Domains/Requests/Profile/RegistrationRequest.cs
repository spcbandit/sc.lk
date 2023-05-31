using MediatR;
using System.ComponentModel;
using SC.LK.Application.Domains.Responses.Profile;

namespace SC.LK.Application.Domains.Requests.Profile
{
    public class RegistrationRequest : IRequest<RegistrationResponse>
    { 
        /// <summary>
        /// Имя
        /// </summary
        public string? Name { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string? ContractorName { get; set; }
        
        /// <summary>
        /// Имя
        /// </summary>
        public string? ContractorINN { get; set; }
        
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
        public string Login { get; set; }
        
        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Удален ли аккаунт
        /// </summary>
        [DefaultValue(false)]
        public bool? IsDelete { get; set; } = false;

    }
}
