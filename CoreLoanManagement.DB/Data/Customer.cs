using System.ComponentModel.DataAnnotations;

namespace LoanManagement.DB.Data
{

    public class Customer
    {
        public Customer() { }

        [Key]
        public int CustomerId { get; set; }
        [MaxLength(50)]
        public string CustomerName { get; set; } 
        public List<Loan> LoanList { get; set; }
    }
}
