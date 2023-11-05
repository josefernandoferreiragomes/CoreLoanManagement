using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CoreLoanManagement.WebSite.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Customer name is mandatory")]
        [DisplayName("Customer Name")]
        public string CustomerName { get; set; }              

        [Required(ErrorMessage = "Customer type is mandatory")]
        [DisplayName("Customer Type")]
        public int CustomerTypeId { get; set; }

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is mandatory")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Display(Name = "Date of birth")]
        public DateTime DateOfBirth { get; set; }   

        public bool Gender { get; set; }
    }
}