using LoanManagement.DB.Data;
using LoanManagement.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoanManagement.Interfaces
{
    public interface ILoanManagerRepository
    {
        //List<Customer> GetCustomer();
        IEnumerable<Customer> GetCustomer(string name);
        List<CustomerItem> GetPageOfClassGeneric(int page, int pageSize, string nameFilter);
        CustomerItem CreateCustomer(CustomerItem customer);
        CustomerItem UpdateCustomer(CustomerItem customer);
        CustomerLoanInstallmentDBOut GetPageOfCustomerLoanInstallment(CustomerLoaInstallmentDBIn objIn);
    }
}