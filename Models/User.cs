using Microsoft.AspNetCore.Mvc;
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
        [Required(ErrorMessage = "First Name is Require"), MaxLength(30)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is Require"), MaxLength(30)]

        public string LastName { get; set; }
        [DisplayFormat(DataFormatString ="{0:dd-MM-yyyy}")]
        public DateTime? Dob { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [StringLength(50, ErrorMessage = "Must be between 5 and 50 characters", MinimumLength = 5)]
        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "Must be a valid email")]

        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        
        [Required(ErrorMessage = "PIN is required")]
         
        
        public int? Pin { get; set; }

       
      
        [HiddenInput]
        public bool? Status { get; set; }
        [HiddenInput]
        public DateTime? LastLogin { get; set; }

        [JsonIgnore] //this line skip geneartion of Transaction:[] list in UserJson
        public virtual ICollection<Transaction> Transaction { get; set; }
    }
}
