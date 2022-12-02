using Microsoft.AspNetCore.Mvc;
using ModelValidations.Models;

namespace ModelValidations.Controllers
{
    public class HomeController : Controller
    {
        [Route("register")]
        public IActionResult Index(Person person)
        {
            if (!ModelState.IsValid)
            {
                List<string> errorsList = new List<string>();

                foreach (var value in ModelState.Values)
                {
                    foreach (var error in value.Errors)
                    {
                        errorsList.Add(error.ErrorMessage);
                    }
                }

                string errors = string.Join("\n", errorsList);

                return BadRequest(errors);
            }

            return Content($"{person}");
        }
    }
}
