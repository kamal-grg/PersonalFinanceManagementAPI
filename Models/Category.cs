using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PersonalFinanceManagementAPI.Models
{
    public partial class Category
    {
        public Category()
        {
            Transaction = new HashSet<Transaction>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryType { get; set; }
        public bool? Status { get; set; }

        [JsonIgnore]
        public virtual ICollection<Transaction> Transaction { get; set; }
    }
}
