using LoanManagement.DB.Dao;
using LoanManagement.DB.DaoSqlExecuters;
using LoanManagement.DB.Data;
using LoanManagement.DB.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LoanManagement.DB.Tests
{
    
    public class LoanManagementTest
    {

        // to have the same Configuration object as in Startup
        private IConfigurationRoot _configuration;

        // represents database's configuration
        private DbContextOptions<LoanManagementDBContext> _options;

        public LoanManagementTest()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            _configuration = builder.Build();
            _options = new DbContextOptionsBuilder<LoanManagementDBContext>()
                .UseSqlServer(_configuration.GetConnectionString("DefaultConnection"))
                .Options;
        }

        [Test]
        public void TestDbContextDbSeed()
        {

            using (var context = new LoanManagementDBContext(_options))
            {
                List<Customer> customers = new List<Customer>();
                Customer customerA = new Customer() { CustomerName = "Jack Ma" };
                Customer customerB = new Customer() { CustomerName = "Jack Dorsey" };

                customers.Add(customerA);
                customers.Add(customerB);
                customers.Add(new Customer() { CustomerName = "John Doe" });
                customers.Add(new Customer() { CustomerName = "Satya Nadella" });
                customers.Add(new Customer() { CustomerName = "Elon Musk" });
                customers.Add(new Customer() { CustomerName = "Elizabeth Holmes" });
                customers.Add(new Customer() { CustomerName = "Sundar Pichai" });

                context.Customers.AddRange(customers);

                List<Loan> loans = new List<Loan>();
                Loan loanA = new Loan() { Customer = customerA, LoanDescription = "Mortgage loan", LoanValue = 100000 };
                Loan loanB = new Loan() { Customer = customerB, LoanDescription = "Leasing loan", LoanValue = 50000 };
                loans.Add(loanA);
                loans.Add(loanB);

                context.Loans.AddRange(loans);

                List<Installment> installments = new List<Installment>();
                installments.Add(new Installment() { Loan = loanA, InstallmentValue = loanA.LoanValue / 36 });
                installments.Add(new Installment() { Loan = loanB, InstallmentValue = loanB.LoanValue / 36 });

                context.Installments.AddRange(installments);

                context.SaveChanges();
            }
        }
        [Test]
        public void TestDbContext()
        {
            using (var context = new LoanManagementDBContext(_options))
            {
                // Create and save a new Customer
                var name = "Paul";

                var customer = new Customer { CustomerName = name };
                context.Customers.Add(customer);
                context.SaveChanges();

                //// Display all customers from the database
                var query = from b in context.Customers.ToList<Customer>()
                            select b;

                Console.WriteLine("All customers in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.CustomerName);
                }
            }
        }

        [Test]
        public void TestPagination()
        {

            //arrange
            var db = new DBLoanManagerRepository(_options);


            //act
            IEnumerable<Customer> filteredCustomers = db.GetPageOfClassGeneric(5, 3, "1");

            //assert
            Assert.IsNotNull(filteredCustomers);

        }
    }
}
