using LoanManagement.DB.Data;
using LoanManagement.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LoanManagement.Controllers
{   
    [ApiController] 
    [Route("[controller]")]
    public class LoanManagerController : ControllerBase, ILoanManagementController
    {
        LoanManagement.Interfaces.ILoanManagerRepository _LoanManagementRepository { get; set; }
        
        public LoanManagerController(ILoanManagerRepository LoanManagementRepository)
        {
            _LoanManagementRepository = LoanManagementRepository;
        }        

        // GET api/values
        [HttpGet(Name = "GetLoanManager")]
        public IEnumerable<Customer> Get()
        {
            IEnumerable<Customer> customers = _LoanManagementRepository.GetCustomer("a");
            return customers;
        }
      
    }
}
