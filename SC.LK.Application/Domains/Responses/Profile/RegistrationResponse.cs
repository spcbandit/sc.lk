using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SC.LK.Application.Domains.Dto;
using SC.LK.Application.Domains.Entities;

namespace SC.LK.Application.Domains.Responses.Profile
{
    public class RegistrationResponse : BaseResponse
    {
        /// <summary>
        /// User
        /// </summary>
        public UserDto User { get; set; }
    }
}
