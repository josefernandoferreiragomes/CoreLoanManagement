using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Web.Models
{

    public class CustomerItem
    {
        public CustomerItem() { }
        public int CustomerId { get; set; }
        
        public string CustomerName { get; set; } 
        
    }
}
