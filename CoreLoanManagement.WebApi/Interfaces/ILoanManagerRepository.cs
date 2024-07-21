using CoreLoanManagement.WebApi.Models;
using LoanManagement.DB.Data;

namespace LoanManagement.Interfaces
{
    public interface ILoanManagerRepository
    {
        //List<Customer> GetCustomer();
        IEnumerable<Customer> GetCustomer(string name);
        List<CustomerItem> GetPageOfClassGeneric(int page, int pageSize, string? nameFilter);
        CustomerItem CreateCustomer(CustomerItem customer);
        CustomerItem UpdateCustomer(CustomerItem customer);
        CustomerLoanInstallmentDBOut GetPageOfCustomerLoanInstallment(CustomerLoaInstallmentDBIn objIn);
    }
}