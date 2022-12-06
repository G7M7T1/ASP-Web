using Microsoft.AspNetCore.Mvc;

namespace Razor_Views.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
