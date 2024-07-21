using CoreLoanManagement.WebApi.Models;

namespace LoanManagement.Interfaces
{
    public interface ICustomerItemController
    {
        IEnumerable<CustomerItem> Get(GenericPageParameters parameters);
    }
}