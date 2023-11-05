using LoanManagement.DB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoanManagement.Interfaces
{
    public interface ILoanManagementController
    {
        IEnumerable<Customer> Get();
    }
}