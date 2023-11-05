using System.ComponentModel.DataAnnotations;

namespace LoanManagement.DB.Data
{
    public class Loan
    {
        [Key]
        public int LoanId { get; set; } 
        public string LoanDescription { get; set;}

        public decimal LoanValue { get; set; }

        public Customer Customer { get; set; }
    }
}
