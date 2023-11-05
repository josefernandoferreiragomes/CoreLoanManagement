using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoreLoanManagement.WebSite.Models
{
    public class InstallmentViewModel
    {
        public int LastPageLastItemId { get; set; }
        public int CustomerId { get; set; }
        
        public List<Installment> InstallmentList { get; set; }
    }
}