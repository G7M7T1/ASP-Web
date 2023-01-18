using Entities;
using ServiceContracts;
using ServiceContracts.DTO;
using ServiceContracts.Enums;
using Services.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PersonsService : IPersonService
    {
        private readonly List<Person> _person;

        private readonly IcountriesService _countriesService;

        public PersonsService(bool initialize = true)
        {
            _person = new List<Person>();
            _countriesService = new CountriesService();

            if (initialize)
            {
                // PersonID: 52BDB454-D4AE-4D44-956B-0601287F1770
                // PersonID: CDAB7440-EF83-44C2-A6FA-69B1E169816B
                // PersonID: 36B97CF5-47B5-4F24-B3D4-A01BECBA382F
                // PersonID: 3F02F114-64CB-44EC-842C-85F590D8E8ED
                // PersonID: 0992F323-F9DE-4A07-91AA-0D3E9FC63CDF

                // 4C94A3EF-B58D-4336-B46E-43E4B74C02B4, CountryName = "Chile" },
                // 97816663-083A-49C1-A972-3E63FE045F17, CountryName = "France" },
                // 23CE6734-8EB6-4E07-A28D-106814591C0D, CountryName = "Canada" },
                // B0011D9D-9661-42EF-B342-945ECEB7D4D1, CountryName = "America" },
                // 40F9C480-CCC9-4727-AEF7-C3FBC951DBC3, CountryName = "Spain" }

                _person.Add(new Person() 
                {
                    PersonName = "Anastasia",
                    Email = "achalkly0@squidoo.com",
                    DateOfBirth = DateTime.Parse("1979-06-14"),
                    Gender = GenderOptions.Female.ToString(),
                    Address = "29956 Lighthouse Bay Trail",
                    ReceiveNewsLetters = false,
                    PersonID = Guid.Parse("52BDB454-D4AE-4D44-956B-0601287F1770"),
                    CountryID = Guid.Parse("4C94A3EF-B58D-4336-B46E-43E4B74C02B4")
                });

                _person.Add(new Person()
                {
                    PersonName = "Pippo",
                    Email = "ptoderbrugge1@ftc.gov",
                    DateOfBirth = DateTime.Parse("1976-11-21"),
                    Gender = GenderOptions.Male.ToString(),
                    Address = "6764 Magdeline Terrace",
                    ReceiveNewsLetters = false,
                    PersonID = Guid.Parse("CDAB7440-EF83-44C2-A6FA-69B1E169816B"),
                    CountryID = Guid.Parse("97816663-083A-49C1-A972-3E63FE045F17")
                });

                _person.Add(new Person()
                {
                    PersonName = "Corrie",
                    Email = "ccampe2@newyorker.com",
                    DateOfBirth = DateTime.Parse("2014-10-29"),
                    Gender = GenderOptions.Female.ToString(),
                    Address = "9 Morning Place",
                    ReceiveNewsLetters = true,
                    PersonID = Guid.Parse("36B97CF5-47B5-4F24-B3D4-A01BECBA382F"),
                    CountryID = Guid.Parse("23CE6734-8EB6-4E07-A28D-106814591C0D")
                });

                _person.Add(new Person()
                {
                    PersonName = "Jonas",
                    Email = "jumney3@de.vu",
                    DateOfBirth = DateTime.Parse("1972-06-22"),
                    Gender = GenderOptions.Male.ToString(),
                    Address = "46 Pleasure Terrace",
                    ReceiveNewsLetters = true,
                    PersonID = Guid.Parse("3F02F114-64CB-44EC-842C-85F590D8E8ED"),
                    CountryID = Guid.Parse("B0011D9D-9661-42EF-B342-945ECEB7D4D1")
                });

                _person.Add(new Person()
                {
                    PersonName = "Si",
                    Email = "sdrynan4@timesonline.co.uk",
                    DateOfBirth = DateTime.Parse("2013-02-23"),
                    Gender = GenderOptions.Male.ToString(),
                    Address = "1658 Bayside Crossing",
                    ReceiveNewsLetters = false,
                    PersonID = Guid.Parse("0992F323-F9DE-4A07-91AA-0D3E9FC63CDF"),
                    CountryID = Guid.Parse("40F9C480-CCC9-4727-AEF7-C3FBC951DBC3")
                });
            }
        }

        private PersonResponse ConvertPersonToPersonResponse(Person person)
        {
            PersonResponse personResponse = person.ToPersonResponse();

            personResponse.CountryName = _countriesService.GetCountryByCountryID(person.CountryID)?.CountryName;

            return personResponse;
        }

        PersonResponse IPersonService.AddPerson(PersonAddRequest? personAddRequest)
        {
            if (personAddRequest == null)
            {
                throw new ArgumentNullException(nameof(personAddRequest));
            }

            /*            ValidationContext validationContext = new ValidationContext(personAddRequest);

                        // Make Validation Results List
                        List<ValidationResult> validationResults = new List<ValidationResult>();

                        bool isValid =  Validator.TryValidateObject(personAddRequest, validationContext, validationResults, true);

                        if (!isValid) { throw new ArgumentException(validationResults.FirstOrDefault()?.ErrorMessage); }*/

            ValidationHelper.ModelValidation(personAddRequest);


            // Convert PersonAddRequest to Person Type
            Person person = personAddRequest.ToPerson();

            // Give Guid
            person.PersonID = Guid.NewGuid();

            _person.Add(person);

            PersonResponse personResponse = person.ToPersonResponse();

            personResponse.CountryName = _countriesService.GetCountryByCountryID(person.CountryID)?.CountryName;

            return ConvertPersonToPersonResponse(person);
        }

        public PersonResponse? GetPersonByPersonID(Guid? personId)
        {
            if (personId == null)
            {
                return null;
            }

            Person? person = _person.FirstOrDefault(temp=> temp.PersonID == personId);

            if (person == null)
            {
                return null;
            }

            return ConvertPersonToPersonResponse(person);
        }

        public List<PersonResponse> GetAllPersons()
        {
            return _person.Select(temp => ConvertPersonToPersonResponse(temp)).ToList();
        }

        public List<PersonResponse> GetFilteredPersons(string searchBy, string? searchString)
        {
            List<PersonResponse> allPersons = GetAllPersons();

            List<PersonResponse> matchingPersons = allPersons;

            if (string.IsNullOrEmpty(searchBy) || string.IsNullOrEmpty(searchString))
            {
                return matchingPersons;
            }

            switch (searchBy)
            {
                case nameof(PersonResponse.PersonName):
                    matchingPersons = allPersons.Where(temp => (!string.IsNullOrEmpty(temp.PersonName) ? 
                    temp.PersonName.Contains(searchString, StringComparison.OrdinalIgnoreCase) : true)).ToList();
                    break;


                case nameof(PersonResponse.Email):
                    matchingPersons = allPersons.Where(temp => (!string.IsNullOrEmpty(temp.Email) ?
                    temp.Email.Contains(searchString, StringComparison.OrdinalIgnoreCase) : true)).ToList();
                    break;


                case nameof(PersonResponse.DateOfBirth):
                    matchingPersons = allPersons.Where(temp => (temp.DateOfBirth != null) ?
                    temp.DateOfBirth.Value.ToString("dd MMMM yyyy").Contains(searchString, StringComparison.OrdinalIgnoreCase) : true).ToList();
                    break;


                case nameof(PersonResponse.Gender):
                    matchingPersons = allPersons.Where(temp => (!string.IsNullOrEmpty(temp.Gender)) ?
                    temp.Gender.Contains(searchString, StringComparison.OrdinalIgnoreCase) : true).ToList();
                    break;


                case nameof(PersonResponse.Address):
                    matchingPersons = allPersons.Where(temp => (!string.IsNullOrEmpty(temp.Address)) ?
                    temp.Address.Contains(searchString, StringComparison.OrdinalIgnoreCase) : true).ToList();
                    break;


                default:
                    matchingPersons= allPersons;
                    break;
            }

            return matchingPersons;
        }

        public List<PersonResponse> GetSortedPersons(List<PersonResponse> allPersons, string sortBy, SortOrderOptions sortOrder)
        {
            if (string.IsNullOrEmpty(sortBy))
            {
                return allPersons;
            }

            List<PersonResponse> sortedPersons = (sortBy, sortOrder) switch
            {
                (nameof(PersonResponse.PersonName), SortOrderOptions.ASC) =>
                allPersons.OrderBy(temp => temp.PersonName, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PersonResponse.PersonName), SortOrderOptions.DESC) =>
                allPersons.OrderByDescending(temp => temp.PersonName, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PersonResponse.Email), SortOrderOptions.ASC) =>
                allPersons.OrderBy(temp => temp.Email, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PersonResponse.Email), SortOrderOptions.DESC) =>
                allPersons.OrderByDescending(temp => temp.Email, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PersonResponse.DateOfBirth), SortOrderOptions.ASC) =>
                allPersons.OrderBy(temp => temp.DateOfBirth).ToList(),

                (nameof(PersonResponse.DateOfBirth), SortOrderOptions.DESC) =>
                allPersons.OrderByDescending(temp => temp.DateOfBirth).ToList(),

                (nameof(PersonResponse.Age), SortOrderOptions.ASC) =>
                allPersons.OrderBy(temp => temp.Age).ToList(),

                (nameof(PersonResponse.Age), SortOrderOptions.DESC) =>
                allPersons.OrderByDescending(temp => temp.Age).ToList(),

                (nameof(PersonResponse.Gender), SortOrderOptions.ASC) =>
                allPersons.OrderBy(temp => temp.Gender, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PersonResponse.Gender), SortOrderOptions.DESC) =>
                allPersons.OrderByDescending(temp => temp.Gender, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PersonResponse.CountryName), SortOrderOptions.ASC) =>
                allPersons.OrderBy(temp => temp.CountryName, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PersonResponse.CountryName), SortOrderOptions.DESC) =>
                allPersons.OrderByDescending(temp => temp.CountryName, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PersonResponse.Address), SortOrderOptions.ASC) =>
                allPersons.OrderBy(temp => temp.Address, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PersonResponse.Address), SortOrderOptions.DESC) =>
                allPersons.OrderByDescending(temp => temp.Address, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PersonResponse.ReceiveNewsLetters), SortOrderOptions.ASC) =>
                allPersons.OrderBy(temp => temp.ReceiveNewsLetters).ToList(),

                (nameof(PersonResponse.ReceiveNewsLetters), SortOrderOptions.DESC) =>
                allPersons.OrderByDescending(temp => temp.ReceiveNewsLetters).ToList(),

                _ => allPersons
            };

            return sortedPersons;
        }

        public PersonResponse UpdatePerson(PersonUpdateRequest? personUpdateRequest)
        {
            if (personUpdateRequest == null)
            {
                throw new ArgumentNullException(nameof(personUpdateRequest));
            }

            // Run ValidationHelper
            ValidationHelper.ModelValidation(personUpdateRequest);

            // Get Matching Person Object To Update 
            Person? matchingPerson = _person.FirstOrDefault(temp => temp.PersonID == personUpdateRequest.PersonID);

            if (matchingPerson == null)
            {
                throw new ArgumentException("Given Person Id Does Not Exist");
            }

            matchingPerson.Email = personUpdateRequest.Email;
            matchingPerson.Address = personUpdateRequest.Address;
            matchingPerson.CountryID = personUpdateRequest.CountryID;
            matchingPerson.PersonName = personUpdateRequest.PersonName;
            matchingPerson.DateOfBirth = personUpdateRequest.DateOfBirth;
            matchingPerson.Gender = personUpdateRequest.Gender.ToString();
            matchingPerson.ReceiveNewsLetters = personUpdateRequest.ReceiveNewsLetters;

            return ConvertPersonToPersonResponse(matchingPerson);
        }

        public bool DeletePerson(Guid? personId)
        {
            if (personId == null) { throw new ArgumentNullException(nameof(personId)); }

            Person? person = _person.FirstOrDefault(temp => temp.PersonID == personId);

            if (person == null) { return false; }

            _person.RemoveAll(temp => temp.PersonID == personId);

            return true;
        }
    }
}
