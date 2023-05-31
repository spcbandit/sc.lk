using RestSharp;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.LK.Application.Domains
{
    public class BaseRequest
    {
        /// <summary>
        /// EndPoint
        /// </summary>
        public string EndPoint { get; set; }
        
        /// <summary>
        /// Method
        /// </summary>
        public Method Method { get; set; }
        
        /// <summary>
        /// Body
        /// </summary>
        public object Body { get; set; }
        
        /// <summary>
        /// Headers
        /// </summary>
        public Dictionary<string, string> Headers { get; set; }
    }
}
