using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CoreLoanManagement.WebSite.Models
{
    public class SimulateLoanViewModel
    {
        [DisplayName("Loan Amount")]
        public decimal LoanAmount { get; set; }
        
        [DisplayName("LoanInterest Rate")]
        public decimal LoanInterestRate { get; set; }
        
        [DisplayName("Loan Installment")]
        public decimal LoanInstallment { get; set; }
        
        [DisplayName("Loan Duration")]
        public decimal LoanDuration { get; set; }
    }
}