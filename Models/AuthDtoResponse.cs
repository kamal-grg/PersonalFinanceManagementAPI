using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalFinanceManagementAPI.Models
{
    public class AuthDtoResponse
    {
         public string Token { get; set; }
        public bool Success { get; set; }
        public string ReadableMessage { get; set; } 
        public IEnumerable<string> Errors { get; set; }
    }
}
