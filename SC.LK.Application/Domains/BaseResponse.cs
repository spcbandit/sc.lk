using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.LK.Application.Domains
{
    public class BaseResponse
    {
        /// <summary>
        /// Успех
        /// </summary>
        public bool Success { get; set; }
        
        /// <summary>
        /// Сообщение об ошибке
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}
