using LoanManagement.DB.Data;

namespace LoanManagement.DB.Interfaces
{
    public interface IDBLoanManagerRepository
    {
        List<Customer> GetCustomers();
        List<Customer> GetPageOfClassGeneric(int page, int pageSize, string nameFilter);
        Customer CreateCustomer(Customer customer);
        Customer UpdateCustomer(Customer customer);
        CustomerLoanInstallmentDBOut GetPageOfCustomerLoanInstallment(CustomerLoaInstallmentDBIn objIn);
       
    }
}
