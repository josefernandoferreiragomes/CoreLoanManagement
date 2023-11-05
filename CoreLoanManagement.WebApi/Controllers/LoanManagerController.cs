using LoanManagement.DB.Data;
using LoanManagement.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LoanManagement.Controllers
{
    //[ApiController]
    //[Route("[loanManager]")]
    //[Route("api/[controller]")]
    [ApiController]
    //[Route("api/LoanManager")]
    [Route("[controller]")]
    public class LoanManagerController : ControllerBase, ILoanManagementController
    {
        LoanManagement.Interfaces.ILoanManagerRepository _LoanManagementRepository { get; set; }
        
        public LoanManagerController(ILoanManagerRepository LoanManagementRepository)
        {
            _LoanManagementRepository = LoanManagementRepository;
        }
        //public LoanManagerController(LoanManagement.Interfaces.ILoanManagerRepository repository)
        //{
        //    _LoanManagementRepository = repository;
        //}

        // GET api/values
        [HttpGet(Name = "GetLoanManager")]
        public IEnumerable<Customer> Get()
        {
            IEnumerable<Customer> customers = _LoanManagementRepository.GetCustomer("a");
            return customers;
        }
        //// GET api/values/5
        //public IEnumerable<Customer> Get(string name)
        //{
        //    return _LoanManagementRepository.GetCustomer(name);
        //}
        //// GET api/values/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/values/5
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/values/5
        //public void Delete(int id)
        //{
        //}
    }
}
