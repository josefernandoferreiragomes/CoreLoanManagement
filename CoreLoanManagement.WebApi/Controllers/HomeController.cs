using Microsoft.AspNetCore.Mvc;

namespace LoanManagement.Controllers
{
    public class HomeController : ControllerBase
    {
        public ActionResult Index()
        {
            //ViewBag.Title = "Home Page";

            return new ViewResult();
        }
    }
}
