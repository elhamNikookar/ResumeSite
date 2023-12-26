using Microsoft.AspNetCore.Mvc;

namespace Resume.Web.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        public IActionResult Index()
        {
            //TempData[SuccessMessage] = "You Do right";
            //TempData[ErrorMessage] = "Your Action Fails";
            //TempData[WarningMessage] = "Becarful";
            //TempData[InfoMessage] = "به راهنما دقت کنید";
            return View();
        }
    }
}
