using LoanManagement.DB.Data;
using LoanManagement.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LoanManagement.Controllers
{
    //[ApiController]
    //[Route("[loanInstallment]")]
    //[Route("api/[controller]")]
    [ApiController]
    //[Route("api/LoanInstallment")]
    [Route("[controller]")]
    public class LoanInstallmentController : ControllerBase
    {
        LoanManagement.Interfaces.ILoanManagerRepository _LoanManagementRepository { get; set; }
      
        public LoanInstallmentController(ILoanManagerRepository loanManagementRepository)
        {
            _LoanManagementRepository = loanManagementRepository;
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
