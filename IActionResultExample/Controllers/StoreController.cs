using Microsoft.AspNetCore.Mvc;

namespace IActionResultExample.Controllers
{
    public class StoreController : Controller
    {
        [Route("store/books/{id}")]
        public IActionResult Books()
        {
            // Get Id
            int id = Convert.ToInt32(Request.RouteValues["id"]);

            return Content($"Hello Books {id}", "text/html");
        }
    }
}
