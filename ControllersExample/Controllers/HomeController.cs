using Microsoft.AspNetCore.Mvc;

namespace ControllersExample.Controllers
{
    /*    public class HomeController : Controller
        {
            public IActionResult Index()
            {
                return View();
            }
        }*/

    [Controller]
    class HomeController: Microsoft.AspNetCore.Mvc.Controller // Home
    {
        [Route("/")]
        [Route("home")]
        [Route("index")]
        public string Index()
        {
            return "Hello From Index Page";
        }


        [Route("about")]
        public string About()
        {
            return "Hello From About Page";
        }


        [Route("content")]
        public ContentResult Content()
        {
            return new ContentResult()
            {
                Content = "content",
                ContentType = "text/html"
            };
        }
    }
}
