using System.ComponentModel.DataAnnotations;

namespace LoanManagement.DB.Data
{
    public  class Installment
    {
        [Key]
        public int InstallmentId { get; set; }  
        public Loan Loan { get; set; }

        public decimal InstallmentValue { get; set; }
    }
}
