using CoreLoanManagement.WebSite.Models;
using CoreLoanManagement.WebSite.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace CoreLoanManagement.WebSite.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private Interfaces.IApiLoanRepository _loanRepository;

        public CustomerController(ILogger<HomeController> logger, IApiLoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
            _logger = logger;
        }

        //public CustomerController()
        //{
        //    _loanRepository = ApplicationContainer.GetContainer().Resolve<LoanManagement.WebSite.Repository.ApiLoanRepository>();
        //}


        [HttpGet]
        public ActionResult SearchCustomers()
        {
            SearchCustomersViewModel model = new SearchCustomersViewModel();
            model.Customers = new List<CustomerItem>();
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> SearchCustomers(SearchCustomersViewModel model)
        {
            model.Customers = null;
            model.Customers = await _loanRepository.SearchCustomers(model.SearchKeword, 2, 2);

            //mock
            //CustomerItem customer = new CustomerItem { Id = 1, CustomerName = "customerMock" };
            //model.Customers = new List<CustomerItem> { customer };
            return View(model);
        }       

        public async Task<ActionResult> Customers()
        {
            CustomerViewModel customerViewModel= await GetCustomerAsync();
            ViewBag.Message = "Your application description page.";
            return View(customerViewModel);
        }

        public ActionResult AddCustomer()
        {
            AddCustomerViewmodel addCustomerViewmodel = FillAddCustomerViewModel();
            return View(addCustomerViewmodel);
        }

        public ActionResult AddCustomerFormCollection()
        {
            CustomerFormCollectionViewModel addCustomerViewmodel = new CustomerFormCollectionViewModel();
            

            return View(addCustomerViewmodel);
        }
        
        [HttpPost]
        public ActionResult AddCustomerFormCollection(Microsoft.AspNetCore.Http.IFormCollection collection)
        {

            //TODO Send information to API
            CustomerFormCollectionViewModel addCustomerViewmodel = new CustomerFormCollectionViewModel();
            
            addCustomerViewmodel.FullName = collection["fullName"];
            
            addCustomerViewmodel.Message = "Customer successfully added";

            return View(addCustomerViewmodel);
        }

        [HttpPost]
        public ActionResult AddCustomer(Customer customer)
        {
            AddCustomerViewmodel addCustomerViewmodel = FillAddCustomerViewModel(customer.CustomerTypeId);

            if (ModelState.IsValid)
            {
                //TODO Send information to API
                
                addCustomerViewmodel.customer = new Customer();
                addCustomerViewmodel.customer.CustomerName = customer.CustomerName;
                addCustomerViewmodel.customer.CustomerTypeId = customer.CustomerTypeId;
                addCustomerViewmodel.Message = "Customer successfully added";
            }
            else
            {
                addCustomerViewmodel.Message = "Customer form with errors";
            }
            
            
            return View(addCustomerViewmodel);
        }
        [HttpPost]
        public ActionResult AddCustomerAjax(Customer customer)
        {

            string message = "SUCCESS adding customer from Ajax";
            //TODO Send information to API
            return Json(new
            {
                Message = message//,
                //JsonRequestBehavior.AllowGet
            });
        }

        private static AddCustomerViewmodel FillAddCustomerViewModel(int selected = 0)
        {
            AddCustomerViewmodel addCustomerViewmodel = new AddCustomerViewmodel();
            //MOCK
            List<CustomerType> customerTypes = new List<CustomerType>
            {
                new CustomerType
                {
                    CustomerTypeDescription = "Retail",
                    CustomerTypeID = 1
                },
                new CustomerType
                {
                    CustomerTypeDescription = "Corporate",
                    CustomerTypeID = 2
                }
            };
            //MOCK

            addCustomerViewmodel.selecLoanItems = new List<SelectListItem>();
            foreach (CustomerType customerType in customerTypes)
            {
                addCustomerViewmodel.selecLoanItems.Add(new SelectListItem
                {
                    Value = customerType.CustomerTypeID.ToString(),
                    Text = customerType.CustomerTypeDescription,
                    Selected = customerType.CustomerTypeID == selected
                });
            }

            return addCustomerViewmodel;
        }

        private async Task<CustomerViewModel> GetCustomerAsync()
        {
            CustomerViewModel customerViewModel = new CustomerViewModel();
            customerViewModel.CustomerList = new List<Customer>();

            List<ClientApi.CustomerItem> response;
            response = await _loanRepository.ObtainCustomers();

            foreach (ClientApi.CustomerItem customerItem in response)
            {
                customerViewModel.CustomerList.Add(new Customer { CustomerName = customerItem.CustomerName, Id = (int)customerItem.CustomerId });
            }
            return customerViewModel;
        }        
       
    }
}