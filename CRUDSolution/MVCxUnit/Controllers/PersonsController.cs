using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceContracts;
using ServiceContracts.DTO;
using ServiceContracts.Enums;
using Services;

namespace MVCxUnit.Controllers
{
    public class PersonsController : Controller
    {
        // Make Privae Fields
        private readonly IPersonService _personService;
        private readonly IcountriesService _countriesService;

        public PersonsController(IPersonService personService, IcountriesService countriesService)
        {
            _personService = personService;
            _countriesService = countriesService;
        }

        [Route("persons/index")]
        [Route("/")]
        public IActionResult Index(string searchBy, string? searchString, 
            string sortBy = nameof(PersonResponse.PersonName), 
            SortOrderOptions sortOrder = SortOrderOptions.ASC)
        {
            // Search Part
            ViewBag.SearchFields = new Dictionary<string, string>()
            {
                { nameof(PersonResponse.PersonName), "Name" },
                { nameof(PersonResponse.Email), "Email" },
                { nameof(PersonResponse.Age), "Age" },
                { nameof(PersonResponse.Gender), "Gender" },
                { nameof(PersonResponse.Address), "Address" },
                { nameof(PersonResponse.CountryName), "Country" },
                { nameof(PersonResponse.DateOfBirth), "Date Of Birth" },
                { nameof(PersonResponse.ReceiveNewsLetters), "Receive News" }
            };

            List<PersonResponse> persons = _personService.GetFilteredPersons(searchBy, searchString);

            ViewBag.CurrentSearchBy = searchBy;
            ViewBag.CurrentSearchString = searchString;


            // Sort Part
            List<PersonResponse> sortedPersons = _personService.GetSortedPersons(persons, sortBy, sortOrder);

            ViewBag.CurrentSortby = sortBy;
            ViewBag.CurrentSortOrder = sortOrder.ToString();

            return View(sortedPersons);
        }

        [HttpGet]
        [Route("persons/create")]
        public IActionResult Create()
        {
            List<CountryResponse> countries = _countriesService.GetAllCountries();

            ViewBag.Countries = countries.Select(temp => new SelectListItem()
            {
                Text = temp.CountryName,
                Value = temp.CountryId.ToString()
            });

            return View();
        }

        [HttpPost]
        [Route("persons/create")]
        public IActionResult Create(PersonAddRequest personAddRequest)
        {
            if (!ModelState.IsValid)
            {
                List<CountryResponse> countries = _countriesService.GetAllCountries();

                ViewBag.Countries = countries;

                ViewBag.Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

                return View();
            }
            PersonResponse personResponse = _personService.AddPerson(personAddRequest);

            return RedirectToAction("Index", "Persons");
        }

        [HttpGet]
        [Route("persons/{personID}")]
        public IActionResult Edit(Guid personID)
        {
            PersonResponse? personResponse = _personService.GetPersonByPersonID(personID);

            if (personResponse == null) { return RedirectToAction("Index"); }

            PersonUpdateRequest personUpdateRequest = personResponse.ToPersonUpdateRequest();

            List<CountryResponse> countries = _countriesService.GetAllCountries();

            ViewBag.Countries = countries.Select(temp => new SelectListItem()
            {
                Text = temp.CountryName,
                Value = temp.CountryId.ToString()
            });

            return View(personUpdateRequest);
        }

        [HttpPost]
        [Route("persons/{personID}")]
        public IActionResult Edit(PersonUpdateRequest personUpdateRequest)
        {
            PersonResponse? personResponse = _personService.GetPersonByPersonID(personUpdateRequest.PersonID);

            if (personResponse == null) { return RedirectToAction("Index"); }

            if (ModelState.IsValid) 
            { 
                PersonResponse updatedPerson = _personService.UpdatePerson(personUpdateRequest);

                return RedirectToAction("Index");
            }

            else
            {
                List<CountryResponse> countries = _countriesService.GetAllCountries();

                ViewBag.Countries = countries.Select(temp => new SelectListItem()
                {
                    Text = temp.CountryName,
                    Value = temp.CountryId.ToString()
                });

                ViewBag.Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

                return View();
            }
        }

        [HttpGet]
        [Route("[action]/{personID}")]
        public IActionResult Delete(Guid? personID)
        {
            PersonResponse? personResponse = _personService.GetPersonByPersonID(personID);
            if (personResponse == null)
                return RedirectToAction("Index");

            return View(personResponse);
        }


        [HttpPost]
        [Route("[action]/{personID}")]
        public IActionResult Delete(PersonUpdateRequest personUpdateResult)
        {
            PersonResponse? personResponse = _personService.GetPersonByPersonID(personUpdateResult.PersonID);
            if (personResponse == null)
                return RedirectToAction("Index");

            _personService.DeletePerson(personUpdateResult.PersonID);
            return RedirectToAction("Index");
        }
    }
}
