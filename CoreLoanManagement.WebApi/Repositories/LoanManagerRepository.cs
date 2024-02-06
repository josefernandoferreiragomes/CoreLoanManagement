using LoanManagement.DB.Data;
using LoanManagement.DB.Interfaces;
using LoanManagement.Interfaces;
using LoanManagement.Platform.Mapper;
using LoanManagement.Web.Models;

namespace LoanManagement.Repositories
{
    public class LoanManagerRepository:ILoanManagerRepository
    {

        LoanManagement.DB.Interfaces.IDBLoanManagerRepository _repository { get; set; }
        public LoanManagerRepository(IDBLoanManagerRepository repository)
        {
            _repository = repository;
        }

        //public LoanManagerRepository(LoanManagement.DB.Interfaces.IDBLoanManagerRepository repository) 
        //{ 
        //    _repository= repository;
        //}

        //public List<Customer> GetCustomer()
        //{
        //    return _repository.GetCustomers();

        //}
        public IEnumerable<Customer> GetCustomer(string name)
        {
            return _repository.GetCustomers().Where(c => c.CustomerName.Contains(name)).ToList();
            
        }    

        public CustomerLoanInstallmentDBOut GetPageOfCustomerLoanInstallment(CustomerLoaInstallmentDBIn objIn)
        {
            return _repository.GetPageOfCustomerLoanInstallment(objIn);
        }
        public List<CustomerItem> GetPageOfClassGeneric(int page, int pageSize, string nameFilter)
        {
            List<CustomerItem> customersSV = new List<CustomerItem>();
            List<Customer> customersDB = _repository.GetPageOfClassGeneric(page, page, nameFilter);

            //todo use the integrated list instead of foreach
            foreach (Customer customer in customersDB) 
            {
                CustomerItem customerItem = CustomMapper.Map<Customer, CustomerItem>(customer);
                customersSV.Add(customerItem);
            }
            
            return customersSV;
        }
        public CustomerItem CreateCustomer(CustomerItem customerItem)
        {
            Customer customer = CustomMapper.Map<CustomerItem, Customer>(customerItem);
            _repository.CreateCustomer(customer);
            return customerItem;
        }
        public CustomerItem UpdateCustomer(CustomerItem customerItem)
        {
            Customer customer = CustomMapper.Map<CustomerItem, Customer>(customerItem);
            _repository.UpdateCustomer(customer);
            return customerItem;
        }
    }
}