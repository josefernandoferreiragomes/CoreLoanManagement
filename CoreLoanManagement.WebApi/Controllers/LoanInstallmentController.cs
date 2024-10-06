using LoanManagement.DB.Dao;
using LoanManagement.DB.Data;
using LoanManagement.DB.Interfaces;
using LoanManagement.DB.Repositories;
using LoanManagement.Interfaces;
using LoanManagement.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LoanManagement.Controllers
{
    
    [ApiController]    
    [Route("[controller]")]
    public class LoanInstallmentController : ControllerBase
    {
        LoanManagement.Interfaces.ILoanManagerRepository _LoanManagementRepository { get; set; }

        private IConfigurationRoot _configuration;

        // represents database's configuration
        private DbContextOptions<LoanManagementDBContext> _options;
        public IDBLoanManagerRepository db;

        public LoanInstallmentController(ILoanManagerRepository loanManagementRepository)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            _configuration = builder.Build();
            _options = new DbContextOptionsBuilder<LoanManagementDBContext>()
                .UseSqlServer(_configuration.GetConnectionString("DefaultConnection"))
                .Options;            
           
            db = new DBLoanManagerRepository(_options, _configuration.GetConnectionString("DefaultConnection"));

            _LoanManagementRepository = new LoanManagerRepository(db);

        }
        
        // GET api/values
        [HttpGet(Name = "PostLoanInstallment")]
        public IEnumerable<LoanManagement.DB.Data.CustomerLoanInstallmentDBOutItem> Get(int customerId, int pageSize, int lastId)
        {
            CustomerLoaInstallmentDBIn objIn = new CustomerLoaInstallmentDBIn();
            objIn.CustomerId = customerId;
            objIn.PageSize = pageSize;
            objIn.LastPageLastInstallmentId = lastId;
            return _LoanManagementRepository.GetPageOfCustomerLoanInstallment(objIn).ListOfItems;
        }
    }
}
