using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PersonalFinanceManagementAPI.Models
{
    public partial class DailyBalance
    {
        public int DailyId { get; set; }
        public DateTime? TransactionDate { get; set; }
        public decimal? TotalIncome { get; set; }
        public decimal? TotalExpense { get; set; }
        public decimal? Balance { get; set; }
    }
}
