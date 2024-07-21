using LoanManagement.DB.Data;

namespace LoanManagement.Interfaces
{
    public interface ILoanManagementController
    {
        IEnumerable<Customer> Get();
    }
}