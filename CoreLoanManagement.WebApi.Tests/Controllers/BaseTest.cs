
using LoanManagement.DB.Dao;
using LoanManagement.DB.Interfaces;
using LoanManagement.DB.Repositories;
using LoanManagement.Interfaces;
using LoanManagement.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LoanManagement.Tests.Controllers
{
    public class BaseTest
    {
        // to have the same Configuration object as in Startup
        private IConfigurationRoot _configuration;

        // represents database's configuration
        private DbContextOptions<LoanManagementDBContext> _options;

        public IDBLoanManagerRepository db;

        public ILoanManagerRepository loanManagerRepository;

        public BaseTest()
        {
            //ApplicationContainer.GetContainer().RegisterSingleton<LoanManagement.Interfaces.ILoanManagerRepository, LoanManagement.Repositories.LoanManagerRepository>();
            //ApplicationContainer.GetContainer().RegisterSingleton<LoanManagement.DB.Interfaces.IDBLoanManagerRepository, LoanManagement.DB.Repositories.DBLoanManagerRepository>();

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            _configuration = builder.Build();
            _options = new DbContextOptionsBuilder<LoanManagementDBContext>()
                .UseSqlServer(_configuration.GetConnectionString("DefaultConnection"))
                .Options;


            db = new DBLoanManagerRepository(_options, _configuration.GetConnectionString("DefaultConnection"));

            loanManagerRepository = new LoanManagerRepository(db);
        }
    }
}
