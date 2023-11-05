using CoreLoanManagement.WebSite.Interfaces;
using CoreLoanManagement.WebSite.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CoreLoanManagement.WebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private Interfaces.IApiLoanRepository _loanRepository;

        public HomeController(ILogger<HomeController> logger, IApiLoanRepository loanRepository)
        {
            _logger = logger;
            _loanRepository = loanRepository;
    }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}