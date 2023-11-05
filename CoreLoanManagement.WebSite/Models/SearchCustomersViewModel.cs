using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CoreLoanManagement.WebSite.Models
{
    public class SearchCustomersViewModel
    {
        public List<CustomerItem> Customers { get; set; }
        public string SearchKeword { get; set; }

        public int PageSize { get; set; }
        public int PreviousPage { get; set; }
        public int NextPage { get; set; }
        public int TotalPages { get; set; } 

    }
}