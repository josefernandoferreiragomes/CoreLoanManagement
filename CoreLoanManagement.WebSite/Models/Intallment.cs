namespace CoreLoanManagement.WebSite.Models
{
    public class Installment
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string LoanDescription { get; set; }
        public decimal InstallmentValue { get; set; }
        public int InstallmentId { get; set; }
    }
}