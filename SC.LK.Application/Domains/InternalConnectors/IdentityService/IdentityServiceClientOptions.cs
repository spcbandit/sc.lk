using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.LK.Application.Domains.IdentityService
{
    public class IdentityServiceClientOptions
    {
        /// <summary>
        /// Базовый путь
        /// </summary>
        public string BasePath { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
