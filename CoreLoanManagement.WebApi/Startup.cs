using LoanManagement.DB.Dao;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace CoreLoanManagement.WebApi
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
          //  services.AddDbContext<LoanManagementDBContext>(o =>
          //o.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
          //  services.AddMvc();

          //  _configuration = builder.Build();
          //  _options = new DbContextOptionsBuilder<LoanManagementDBContext>()
          //      .UseSqlServer(_configuration.GetConnectionString("DefaultConnection"))
          //      .Options;
        }
    }
}
