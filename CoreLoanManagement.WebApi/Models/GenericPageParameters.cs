﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoreLoanManagement.WebApi.Models
{
    public class GenericPageParameters
    {
        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }    
        public int TotalPages { get; set; }        
        public bool HasNext { get ; set; }
        public bool HasPrevious { get ; set; }
        public string? SearchKeyword { get; set; }
    }
}