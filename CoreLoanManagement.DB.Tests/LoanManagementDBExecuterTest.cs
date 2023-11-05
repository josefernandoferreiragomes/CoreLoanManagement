using LoanManagement.DB.Dao;
using LoanManagement.DB.Data;
using LoanManagement.DB.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace LoanManagement.DB.Tests
{

    public class LoanManagementDBExecuterTest
    {
        //[TestClass]
        //public class CarServiceContextInitTests
        //{
        //    // to have the same Configuration object as in Startup
        //    private IConfigurationRoot _configuration;

        //    // represents database's configuration
        //    private DbContextOptions<CarServiceContext> _options;

        //    public CarServiceContextInitTests()
        //    {
        //        var builder = new ConfigurationBuilder()
        //            .SetBasePath(Directory.GetCurrentDirectory())
        //            .AddJsonFile("appsettings.json");

        //        _configuration = builder.Build();
        //        _options = new DbContextOptionsBuilder<CarServiceContext>()
        //            .UseSqlServer(_configuration.GetConnectionString("DefaultConnection"))
        //            .Options;
        //    }
        //    [TestMethod]
        //    public void InitializeDatabaseWithDataTest()
        //    {
        //        using (var context = new CarServiceContext(_options))
        //        {
        //            context.Database.EnsureDeleted();
        //            context.Database.EnsureCreated();

        //            var car1 = new Car()
        //            {
        //                Producer = "Volkswagen",
        //                Model = "Golf IV",
        //                ProductionDate = new DateTime(2009, 01, 01),
        //                IsOnWarranty = false
        //            };

        //            var car2 = new Car()
        //            {
        //                Producer = "Peugeot",
        //                Model = "206",
        //                ProductionDate = new DateTime(2000, 01, 01),
        //                IsOnWarranty = false
        //            };

        //            context.Cars.AddRange(car1, car2);
        //            context.SaveChanges();
        //        }
        //    }
        //}

        // to have the same Configuration object as in Startup
        private IConfigurationRoot _configuration;

        // represents database's configuration
        private DbContextOptions<LoanManagementDBContext> _options;

        public LoanManagementDBExecuterTest()
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
        public void Given_CustomerId_When_ThereIsLoanInstallmentDataOrNot_Then_LoanInstallmentIsReturned()
        {
            var contextOptions = new DbContextOptionsBuilder<LoanManagementDBContext>()
            .UseSqlServer(_configuration.GetConnectionString("DefaultConnection"))
            .Options;
            //Arrange
            DBLoanManagerRepository repository = new DBLoanManagerRepository(contextOptions, _configuration.GetConnectionString("DefaultConnection"));
            CustomerLoaInstallmentDBIn objIn = new CustomerLoaInstallmentDBIn();

            objIn.CustomerId = 8;
            objIn.PageSize = 2;
            objIn.LastPageLastInstallmentId = 0;

            //Act
            CustomerLoanInstallmentDBOut objOut = repository.GetPageOfCustomerLoanInstallment(objIn);
            
            //Assert

            Assert.IsTrue(objOut != null);
            Assert.IsTrue(objOut.ListOfItems!=null);
            Assert.IsTrue(objOut.ListOfItems.Count > 0);
            Console.WriteLine(String.Format("RowCount:{0}",objOut.ListOfItems.Count));
        }
    }
}
