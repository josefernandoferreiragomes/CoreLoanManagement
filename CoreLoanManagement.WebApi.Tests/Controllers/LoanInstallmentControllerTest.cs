using LoanManagement;
using LoanManagement.Controllers;
using LoanManagement.Repositories;
using System.Collections.Generic;


namespace LoanManagement.Tests.Controllers
{
    
    public class LoanInstallmentControllerTest : BaseTest
    {
        [Test]
        public void Get()
        {
            // Arrange
            LoanInstallmentController controller = new LoanInstallmentController(loanManagerRepository);
            int CustomerId, PageSize, LastPage;

            CustomerId = 4;
            PageSize = 2;
            LastPage = 0;
            // Act
            IEnumerable<LoanManagement.DB.Data.CustomerLoanInstallmentDBOutItem> ListOfItems = controller.Get(CustomerId, PageSize, LastPage);

            // Assert
            Assert.IsNotNull(ListOfItems);
            
        }
    }
}
