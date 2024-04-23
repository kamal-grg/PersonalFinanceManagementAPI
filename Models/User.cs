using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PersonalFinanceManagementAPI.Models
{
    public partial class User
    {
        public User()
        {
            Transaction = new HashSet<Transaction>();
        }

        public int UserId { get; set; }
       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Dob { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? Pin { get; set; }
        public bool? Status { get; set; }
        public DateTime? LastLogin { get; set; }

        [JsonIgnore] //this line skip geneartion of Transaction:[] list in UserJson
        public virtual ICollection<Transaction> Transaction { get; set; }
    }
}
