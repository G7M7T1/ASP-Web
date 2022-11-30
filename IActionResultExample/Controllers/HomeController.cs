using Microsoft.AspNetCore.Mvc;

namespace IActionResultExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("book")]
        public IActionResult Index()
        {
            if (!Request.Query.ContainsKey("bookid"))
            {
                Response.StatusCode = 400;
                return Content("Book Id is not supplied");
            }

            // Book Id can't be empty
            if (string.IsNullOrEmpty(Convert.ToString(Request.Query["bookid"])))
            {
                Response.StatusCode = 404;
                return Content("Book Id can't be null or empty");
            }

            // Book Id should be between 1 to 1000
            int bookId = Convert.ToInt32(ControllerContext.HttpContext.Request.Query["bookid"]);

            if (bookId <= 0)
            {
                return Content("Book Id Can't be less than 0");
            }

            if (bookId > 1000)
            {
                return Content("Book Id Can't be bigger than 1000");
            }

            return File("text.pdf", "application/pdf");
        }
    }
}
