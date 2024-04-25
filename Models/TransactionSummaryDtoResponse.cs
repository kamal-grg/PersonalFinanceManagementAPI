using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalFinanceManagementAPI.Models
{
    public class TransactionSummaryDtoResponse
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public decimal TotalSum { get; set; }
    }
}
