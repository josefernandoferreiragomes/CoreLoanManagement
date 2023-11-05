using CoreLoanManagement.WebSite.ClientApi;
using CoreLoanManagement.WebSite.Factories;
using CoreLoanManagement.WebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using CoreLoanManagement.WebSite.ClientApi;

namespace LoanManagement.WebSite.Data
{
    public static class ApiLoanDataWrapperClass
    {

        public static async Task<List<CoreLoanManagement.WebSite.ClientApi.Customer>> ObtainCustomers()
        {

            List< CoreLoanManagement.WebSite.ClientApi.Customer > response = new List<CoreLoanManagement.WebSite.ClientApi.Customer>();

            ConcreteAPIClientFactoryGeneric<CoreLoanManagement.WebSite.ClientApi.Management> clientFactory = new ConcreteAPIClientFactoryGeneric<CoreLoanManagement.WebSite.ClientApi.Management>();
            CoreLoanManagement.WebSite.ClientApi.Management client = clientFactory.GetClient();

            try
            {
                response = (List<CoreLoanManagement.WebSite.ClientApi.Customer>)await client.GetCustomerItemAsync(null,null,null,null,null,null,"");
            }
            catch (CoreLoanManagement.WebSite.ClientApi.ApiException ex)
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
        public static async Task<List<CoreLoanManagement.WebSite.ClientApi.CustomerItem>> SearchCustomers(string searchKeyword, int currentPage, int pageSize)
        {
            List<CoreLoanManagement.WebSite.ClientApi.CustomerItem> output = new List<CoreLoanManagement.WebSite.ClientApi.CustomerItem>();
            List<CoreLoanManagement.WebSite.ClientApi.CustomerItem> response = new List<CoreLoanManagement.WebSite.ClientApi.CustomerItem>();

            ConcreteAPIClientFactoryGeneric<CoreLoanManagement.WebSite.ClientApi.Management> clientFactory = new ConcreteAPIClientFactoryGeneric<CoreLoanManagement.WebSite.ClientApi.Management>();
            CoreLoanManagement.WebSite.ClientApi.Management client = clientFactory.GetClient();

            try
            {
                int totalCount = 0;
                int totalPages = 4;
                response = (List<CoreLoanManagement.WebSite.ClientApi.CustomerItem>)await client.GetCustomerItemAsync(totalCount, pageSize, currentPage, totalPages, false, false, searchKeyword);

                foreach (CoreLoanManagement.WebSite.ClientApi.CustomerItem customerItem in response)
                {
                    CoreLoanManagement.WebSite.ClientApi.CustomerItem tempItem = new CoreLoanManagement.WebSite.ClientApi.CustomerItem();
                    tempItem.CustomerName = customerItem.CustomerName;
                    tempItem.CustomerId = customerItem.CustomerId == null ? 0 : (int)customerItem.CustomerId;
                    output.Add(tempItem);
                }

            }
            catch (CoreLoanManagement.WebSite.ClientApi.ApiException ex)
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

        public static async Task<List<CoreLoanManagement.WebSite.ClientApi.CustomerLoanInstallmentDBOutItem>> ObtainLoanInstallmentPage(int CustomerId, int pageSize, int LastPageLastItemId)
        {

            List<CoreLoanManagement.WebSite.ClientApi.CustomerLoanInstallmentDBOutItem> response = new List<CoreLoanManagement.WebSite.ClientApi.CustomerLoanInstallmentDBOutItem>();

            ConcreteAPIClientFactoryGeneric<CoreLoanManagement.WebSite.ClientApi.Management> clientFactory = new ConcreteAPIClientFactoryGeneric<CoreLoanManagement.WebSite.ClientApi.Management>();
            CoreLoanManagement.WebSite.ClientApi.Management client = clientFactory.GetClient();

            try
            {
                response = (List<CoreLoanManagement.WebSite.ClientApi.CustomerLoanInstallmentDBOutItem>)await client.PostLoanInstallmentAsync(CustomerId, pageSize, LastPageLastItemId);
            }
            catch (CoreLoanManagement.WebSite.ClientApi.ApiException ex)
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
    }




}