using Microsoft.AspNetCore.Mvc;

namespace DatingApp.Api.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            TempData["SuccessMessage"] = "";

            return View();
        }
    }
}
