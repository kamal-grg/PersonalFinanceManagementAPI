using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalFinanceManagementAPI.Models
{
    public class ErrorDtoResponse
    {
       
        public bool Success { get; set; }
        public string ReadableMessage { get; set; }
        
    }
}
