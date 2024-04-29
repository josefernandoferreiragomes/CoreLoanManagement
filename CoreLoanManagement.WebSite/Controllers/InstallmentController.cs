using CoreLoanManagement.WebSite.ClientApi;
using CoreLoanManagement.WebSite.Interfaces;
using CoreLoanManagement.WebSite.Models;
using LoanManagement.WebSite.Data;
using Microsoft.AspNetCore.Mvc;

namespace LoanManagement.WebSite.Controllers
{
    public class InstallmentController : Controller
    {

        private CoreLoanManagement.WebSite.Interfaces.IApiLoanRepository _loanRepository;
        private readonly ILogger<InstallmentController> _logger;

        public InstallmentController(ILogger<InstallmentController> logger, IApiLoanRepository loanRepository)
        {
            _logger = logger;
            _loanRepository = loanRepository;
        }

        const int PageSize = 2;
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult StringAppendExample()
        {
            return View();
        }


        public async Task<ActionResult> LoanInstallments(InstallmentViewModel inputModel)
        {
            
            InstallmentViewModel customerViewModel= await GetInstallmentsAsync(inputModel.CustomerId, inputModel.LastPageLastItemId);
            ViewBag.Message = "All installments";
            return View(customerViewModel);
        }        

        private async Task<InstallmentViewModel> GetInstallmentsAsync(int CustomerId, int LastPageLastItemId)
        {
            InstallmentViewModel installmentViewModel = new InstallmentViewModel();
            installmentViewModel.InstallmentList = new List<Installment>();

            List<CoreLoanManagement.WebSite.ClientApi.CustomerLoanInstallmentDBOutItem> response;

            response = await ApiLoanDataWrapperClass.ObtainLoanInstallmentPage(CustomerId, PageSize, LastPageLastItemId);

            foreach (CoreLoanManagement.WebSite.ClientApi.CustomerLoanInstallmentDBOutItem installmentItem in response)
            {
                installmentViewModel.InstallmentList.Add(new Installment
                {
                    CustomerName = installmentItem.CustomerName,
                    LoanDescription = installmentItem.LoanDescription,
                    InstallmentId = (int)installmentItem.InstallmentId,
                    InstallmentValue = (decimal)installmentItem.InstallmentValue
                });
            }
            return installmentViewModel;
        }        

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}