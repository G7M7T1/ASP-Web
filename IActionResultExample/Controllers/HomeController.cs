using IActionResultExample.Models;
using Microsoft.AspNetCore.Mvc;

namespace IActionResultExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("book")]
        public IActionResult Index([FromRoute]int? bookid, Book book)
        {
            if (bookid.HasValue == false)
            {
                // Response.StatusCode = 400;
                // return Content("Book Id is not supplied");

                // return new BadRequestResult();
                return BadRequest("Book Id is not supplied");
            }

            // Book Id can't be empty
            if (string.IsNullOrEmpty(Convert.ToString(Request.Query["bookid"])))
            {
                // Response.StatusCode = 404;
                // return Content("Book Id can't be null or empty");
                return BadRequest("Book Id can't be null or empty");
            }

            // Book Id should be between 1 to 1000
            int bookId = Convert.ToInt32(ControllerContext.HttpContext.Request.Query["bookid"]);

            if (bookId <= 0)
            {
                // return Content("Book Id Can't be less than 0");
                return NotFound("Book Id Can't be less than 0");
            }

            if (bookId > 1000)
            {
                // return Content("Book Id Can't be bigger than 1000");

                return NotFound("Book Id Can't be bigger than 1000");
            }

            // return File("text.pdf", "application/pdf");

            // return new RedirectToActionResult("Books", "Store", new {});

            // send Id
            // return RedirectToAction("Books", "Store", new { id = bookId });

            return RedirectToActionPermanent("Books", "Store", new { id = bookId });

            // moved Permanently
            // return new RedirectToActionResult("Books", "Store", new {}, permanent: true);


            // must be local url
            // return new LocalRedirectResult($"store/books/{bookId}, true");
            // return LocalRedirect($"store/books/{bookId}");
            // return LocalRedirectPermanent($"store/books/{bookId}");


            // TO Other Url
            // return Redirect($"store/books/{bookId}");
            // return RedirectPermanent($"store/books/{bookId}");
        }
    }
}
