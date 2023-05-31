using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.LK.Application.Domains.Entities
{
    public class AdminEntity : BaseEntity
    {
        /// <summary>
        /// Email
        /// </summary>
        public string? Email { get; set; }
        
        /// <summary>
        /// Password
        /// </summary>
        public string? Password { get; set; }
        
        /// <summary>
        /// Token
        /// </summary>
        public string? Token { get; set; }

    }
}