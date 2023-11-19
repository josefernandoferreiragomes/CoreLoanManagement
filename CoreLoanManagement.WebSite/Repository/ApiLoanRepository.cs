using CoreLoanManagement.WebSite.Factories;
using CoreLoanManagement.WebSite.Interfaces;
using CoreLoanManagement.WebSite.Models;

namespace CoreLoanManagement.WebSite.Repository
{
    public class ApiLoanRepository : IApiLoanRepository
    {

        public async Task<List<ClientApi.CustomerItem>> ObtainCustomers()
        {

            List<ClientApi.CustomerItem> response = new List<ClientApi.CustomerItem>();

            ConcreteAPIClientFactoryGeneric<ClientApi.Management> clientFactory = new ConcreteAPIClientFactoryGeneric<ClientApi.Management>();
            ClientApi.Management client = clientFactory.GetClient();

            try
            {
                response = (List<ClientApi.CustomerItem>)await client.GetCustomerItemAsync(null, null, null, null, null, null, "j");
            }
            catch (ClientApi.ApiException ex)
            {
                //TODO Handle exception
                throw ex;
            }
            catch (Exception ex)
            {
                //TODO Handle exception
                throw ex;
            }
            finally
            {
                //any final procedures like dispose object
            }
            return response;
        }
        public async Task<List<CustomerItem>> SearchCustomers(string searchKeyword, int currentPage, int pageSize)
        {
            List<CustomerItem> output = new List<CustomerItem>();
            List<ClientApi.CustomerItem> response = new List<ClientApi.CustomerItem>();

            ConcreteAPIClientFactoryGeneric<ClientApi.Management> clientFactory = new ConcreteAPIClientFactoryGeneric<ClientApi.Management>();
            ClientApi.Management client = clientFactory.GetClient();

            try
            {
                int totalCount = 0;
                int totalPages = 4;
                response = (List<ClientApi.CustomerItem>)await client.GetCustomerItemAsync(totalCount, pageSize, currentPage, totalPages, false, false, searchKeyword);

                foreach (ClientApi.CustomerItem customerItem in response)
                {
                    CustomerItem tempItem = new CustomerItem();
                    tempItem.CustomerName = customerItem.CustomerName;
                    tempItem.CustomerId = customerItem.CustomerId == null ? 0 : (int)customerItem.CustomerId;
                    output.Add(tempItem);
                }

            }
            catch (ClientApi.ApiException ex)
            {
                //TODO Handle exception
                throw ex;
            }
            catch (Exception ex)
            {
                //TODO Handle exception
                throw ex;
            }
            finally
            {
                //any final procedures like dispose object
            }
            return output;
        }

        public async Task<List<CoreLoanManagement.WebSite.ClientApi.CustomerLoanInstallmentDBOutItem>> ObtainLoanInstallmentPage(int CustomerId, int pageSize, int LastPageLastItemId)
        {

            List<CoreLoanManagement.WebSite.ClientApi.CustomerLoanInstallmentDBOutItem> response = new List<CoreLoanManagement.WebSite.ClientApi.CustomerLoanInstallmentDBOutItem>();

            ConcreteAPIClientFactoryGeneric<CoreLoanManagement.WebSite.ClientApi.Management> clientFactory = new ConcreteAPIClientFactoryGeneric<CoreLoanManagement.WebSite.ClientApi.Management>();
            CoreLoanManagement.WebSite.ClientApi.Management client = clientFactory.GetClient();

            try
            {
                response = (List<ClientApi.CustomerLoanInstallmentDBOutItem>)await client.PostLoanInstallmentAsync(CustomerId, pageSize, LastPageLastItemId);
            }
            catch (ClientApi.ApiException ex)
            {
                //TODO Handle exception
                throw ex;
            }
            catch (Exception ex)
            {
                //TODO Handle exception
                throw ex;
            }
            finally
            {
                //any final procedures like dispose object
            }
            return response;
        }

        //Task<List<ClientApi.Customer>> IApiLoanRepository.ObtainCustomers()
        //{
        //    throw new NotImplementedException();
        //}

        //Task<List<ClientApi.CustomerItem>> IApiLoanRepository.SearchCustomers(string searchKeyword, int currentPage, int pageSize)
        //{
        //    throw new NotImplementedException();
        //}
    }




}