using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PersonalFinanceManagementAPI.Models
{
    public partial class Transaction
    {
        public int TransactionId { get; set; }
        public int? UserId { get; set; }
        public int? CategoryId { get; set; }
        public DateTime? TransactionDate { get; set; }
        public string Description { get; set; }
        public decimal? Amount { get; set; }
        public string Remark { get; set; }
        public string Image { get; set; }
        public bool? Status { get; set; }
        public string TransactionType { get; set; }

        [JsonIgnore]
        public virtual Category Category { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }
    }
}
