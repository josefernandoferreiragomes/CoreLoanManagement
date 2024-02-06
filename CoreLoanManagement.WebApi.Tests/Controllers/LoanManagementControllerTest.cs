using LoanManagement;
using LoanManagement.Controllers;
using LoanManagement.DB.Repositories;
using LoanManagement.Repositories;


namespace LoanManagement.Tests.Controllers
{
    
    public class LoanManagementControllerTest : BaseTest
    {
        [Test]
        public void Get()
        {
            // Arrange
            LoanManagerController controller = new LoanManagerController(loanManagerRepository);

            // Act
            var result = controller.Get();

            // Assert
            Assert.That(result != null);
            
        }

        [Test]
        public void TestCustomers()
        {
            var _dbLoanManagerRepository = new DBLoanManagerRepository();
            var _LoanManagementRepository = new LoanManagerRepository(_dbLoanManagerRepository);
            var result = _LoanManagementRepository.GetPageOfClassGeneric(1, 1, "jack");
            Assert.That(result != null);
        }
    }
}
