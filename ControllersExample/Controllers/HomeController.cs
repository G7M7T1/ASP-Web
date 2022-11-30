using ControllersExample.Models;
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


        [Route("other")]
        public ContentResult Other()
        {
            return Content("<h1>Hello World</h1> <h2>Hello From Other Page</h2>", "text/html");
        }


        [Route("Person")]
        public JsonResult Person()
        {
            Person person = new Person()
            {
                Id = Guid.NewGuid(), FirstName = "Test",
                LastName = "Test", Age = 30
            };
            // return "{\"key\": \"value\"}"; // JSON

            // return new JsonResult(person);

            return Json(person);
        }


        [Route("file-download1")]
        public VirtualFileResult FileDownload1() // wwwroot
        {
            return new VirtualFileResult("/text.pdf", "application/pdf");
        }


        // any file outside of wwwroot folder
        [Route("file-download2")]
        public PhysicalFileResult FileDownload2() // enter all path
        {
            return new PhysicalFileResult(@"C:\Users\g7m7t\Downloads\text.pdf", "application/pdf");
        }


        // Usually use when need Image from Database   Need byte
        [Route("file-download3")]
        public FileContentResult FileDownload3() // enter all path
        {
            byte[] bytes = System.IO.File.ReadAllBytes(@"C:\Users\g7m7t\Downloads\text.pdf");

            return new FileContentResult(bytes, "application/pdf");
        }
    }
}
