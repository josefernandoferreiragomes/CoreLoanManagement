using LoanManagement;
using LoanManagement.Controllers;


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
            Assert.IsNotNull(result);
            
        }
    }
}
