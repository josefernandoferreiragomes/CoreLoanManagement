using LoanManagement.Interfaces;
using LoanManagement.Models;
using LoanManagement.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace LoanManagement.Controllers
{
    //[ApiController]
    //[Route("[customerItem]")]
    //[Route("api/[controller]")]
    [ApiController]
    [Route("[controller]")]
    public class CustomerItemController : ControllerBase, ICustomerItemController
    {
        LoanManagement.Interfaces.ILoanManagerRepository _LoanManagementRepository { get; set; }
        
       
        public CustomerItemController(LoanManagement.Interfaces.ILoanManagerRepository repository)
        {
            _LoanManagementRepository = repository;
        }

        // GET api/values
        [HttpGet(Name = "GetCustomerItem")]
        public IEnumerable<CustomerItem> Get([FromQuery] GenericPageParameters parameters)
        
        {
            return _LoanManagementRepository.GetPageOfClassGeneric(parameters.CurrentPage,parameters.PageSize, parameters.SearchKeyword);
        }

        // POST api/values
        [HttpPost(Name = "PostCustomerItem")]
        public CustomerItem Post([FromBody] CustomerItem customer)
        {
            _LoanManagementRepository.CreateCustomer(customer);
            CustomerItem customerItem = customer;
            if(customerItem == null) 
            { 
            }
            return customerItem;
        }

        // PUT api/values/5
        [HttpPut(Name = "PutCustomerItem")]
        public CustomerItem Put(int id, [FromBody] CustomerItem customer)
        {

            _LoanManagementRepository.UpdateCustomer(customer);
            CustomerItem customerItem = customer;
            if (customerItem == null)
            {
            }
            return customerItem;
        }
    }
}
