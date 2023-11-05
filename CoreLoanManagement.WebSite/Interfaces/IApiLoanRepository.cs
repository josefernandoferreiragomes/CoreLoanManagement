using CoreLoanManagement.WebSite.Models;

namespace CoreLoanManagement.WebSite.Interfaces
{
    public interface IApiLoanRepository
    {

        Task<List<ClientApi.Customer>> ObtainCustomers();

        Task<List<CustomerItem>> SearchCustomers(string searchKeyword, int currentPage, int pageSize);

        Task<List<ClientApi.CustomerLoanInstallmentDBOutItem>> ObtainLoanInstallmentPage(int CustomerId, int pageSize, int LastPageLastItemId);

    }

    

   
}