namespace LoanManagement.DB.Data
{
    public class CustomerLoaInstallmentDBIn
    {
        public int CustomerId { get; set; } 
        public int PageSize { get; set; }
        public int LastPageLastInstallmentId { get; set; }
    }
}
