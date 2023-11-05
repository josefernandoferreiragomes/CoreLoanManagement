using CoreLoanManagement.WebSite.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LoanManagement.WebSite.Controllers
{
    public class LoanController : Controller
    {
        private CoreLoanManagement.WebSite.Interfaces.IApiLoanRepository _loanRepository;
        private readonly ILogger<LoanController> _logger;

        public LoanController(ILogger<LoanController> logger, IApiLoanRepository loanRepository)
        {
            _logger = logger;
            _loanRepository = loanRepository;
        }

        // GET: Loan
        public ActionResult SimulateLoan()
        {
            return View();
        }
    }
}