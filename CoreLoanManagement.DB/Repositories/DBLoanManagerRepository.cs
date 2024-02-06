using Azure;
using LoanManagement.DB.Dao;
using LoanManagement.DB.DaoSqlExecuters;
using LoanManagement.DB.Data;
using LoanManagement.DB.Interfaces;
using LoanManagement.Platform.Logger;
using LoanManagement.Platform.Serializer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LoanManagement.DB.Repositories
{
    public class DBLoanManagerRepository : IDBLoanManagerRepository
    {
        private IConfigurationRoot _configuration;
        LoanManagementDBContext _dbContext { get; set; }
        LoanManagementDBExecuter _dbExecuter { get; set; }

        public DBLoanManagerRepository() 
        {
            var contextOptions = new DbContextOptionsBuilder<LoanManagementDBContext>()
            .UseSqlServer(@"Data Source=.\\SQLEXPRESS;Initial Catalog=LoanManagement.DB.Dao.LoanManagementDBContext;Encrypt=False;Integrated Security=true")
            .Options;

            _dbContext = new LoanManagementDBContext(contextOptions);
            
            _dbExecuter= new LoanManagementDBExecuter();
            SetupLog();


        }
        public DBLoanManagerRepository(DbContextOptions<LoanManagementDBContext> contextOptions)
        {            

            _dbContext = new LoanManagementDBContext(contextOptions);

            _dbExecuter = new LoanManagementDBExecuter(contextOptions);
            SetupLog();


        }
        public DBLoanManagerRepository(DbContextOptions<LoanManagementDBContext> contextOptions, string connectionString)
        {

            _dbContext = new LoanManagementDBContext(contextOptions);

            _dbExecuter = new LoanManagementDBExecuter(contextOptions,connectionString);
            SetupLog();


        }
        private void SetupLog()
        {
            ////TO BE MOVED TO A CUSTOM LOGGER CLASS
            ////LOG
            //var config = new NLog.Config.LoggingConfiguration();

            //// Targets where to log to: File and Console
            //var logfile = new NLog.Targets.FileTarget("logfile") { FileName = @"C:\Users\josef\source\repos\josefernandoferreiragomes\LoanManagement\LogFiles\logfile2.txt" };
            //var logconsole = new NLog.Targets.ConsoleTarget("logconsole");

            //// Rules for mapping loggers to targets            
            //config.AddRule(LogLevel.Info, LogLevel.Fatal, logconsole);
            //config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);

            //// Apply config           
            //NLog.LogManager.Configuration = config;
        }

        public List<Customer> GetCustomers()
        {
            LoggerHelper.GetLogger().Info(string.Format("{0}{1}", this.GetType(), System.Reflection.MethodInfo.GetCurrentMethod()));
            var query = from b in _dbContext.Customers.ToList<Customer>()
                        select b;
            return query.ToList();
        }

        public List<Customer> GetPageOfClassGeneric(int page, int pageSize, string nameFilter)
        {
            List<Customer> customersOut = new List<Customer>();
            
            LoggerHelper.GetLogger().Info(string.Format("Before DB Call {0}{1}", this.GetType(), System.Reflection.MethodInfo.GetCurrentMethod()));
        
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json");

            var _configuration = builder.Build();


            DbContextOptions<LoanManagementDBContext> _options;
            _options = new DbContextOptionsBuilder<LoanManagementDBContext>()
                .UseSqlServer(_configuration.GetConnectionString("DefaultConnection"))
                .Options;
            using (var context = new LoanManagementDBContext(_options))
            {

                var query = context.Customers
                        .OrderBy(on => on.CustomerName)
                        .Where(c => c.CustomerName.Contains(nameFilter))
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize);
                try
                {
                    List<Customer> customers = query.ToList();
                    LoggerHelper.GetLogger().Info(string.Format("After DB Call {0}{1}{2}", customers.GetType(), System.Reflection.MethodInfo.GetCurrentMethod(), JsonSerializerHelper.SerializeToJson<List<Customer>>(customers)));

                    //for temporary purposes, simplifying
                    foreach (Customer custItem in customers)
                    {
                        Customer tempCustomer = custItem;
                        tempCustomer.LoanList = new List<Loan>();
                        customersOut.Add(tempCustomer);
                    }
                }
                catch (Exception exp)
                {
                    throw exp;
                }
                finally
                {

                }
            }
            return customersOut;
        }

        public Customer CreateCustomer(Customer customer)
        {
            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();
            return customer;
        }

        public Customer UpdateCustomer(Customer customer)
        {
            _dbContext.Customers.Update(customer);
            _dbContext.SaveChanges();
            return customer;
        }

        public CustomerLoanInstallmentDBOut GetPageOfCustomerLoanInstallment(CustomerLoaInstallmentDBIn objIn)
        {
            CustomerLoanInstallmentDBOut objOut = new CustomerLoanInstallmentDBOut();


            objOut = _dbExecuter.CustomerInstallmentGetPage(objIn);

            return objOut;
        }

      
    }
}
