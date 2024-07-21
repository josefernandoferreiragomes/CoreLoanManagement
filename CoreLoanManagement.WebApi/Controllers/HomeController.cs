using Microsoft.AspNetCore.Mvc;

namespace LoanManagement.Controllers
{
    public class HomeController : ControllerBase
    {
        public ActionResult Index()
        {        

            return new ViewResult();
        }
    }
}
