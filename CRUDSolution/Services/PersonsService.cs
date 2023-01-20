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


/*                  new Country() { CountryId = Guid.Parse("4C94A3EF-B58D-4336-B46E-43E4B74C02B4"), CountryName = "Chile" },
                    new Country() { CountryId = Guid.Parse("97816663-083A-49C1-A972-3E63FE045F17"), CountryName = "France" },
                    new Country() { CountryId = Guid.Parse("23CE6734-8EB6-4E07-A28D-106814591C0D"), CountryName = "Canada" },
                    new Country() { CountryId = Guid.Parse("B0011D9D-9661-42EF-B342-945ECEB7D4D1"), CountryName = "United States" },
                    new Country() { CountryId = Guid.Parse("40F9C480-CCC9-4727-AEF7-C3FBC951DBC3"), CountryName = "Spain" },
                    new Country() { CountryId = Guid.Parse("75D3AD24-1271-4D12-B00B-5CF06778F2E8"), CountryName = "China" },
                    new Country() { CountryId = Guid.Parse("240BD070-853A-40E7-AF94-1014BDEA011C"), CountryName = "Japan" },
                    new Country() { CountryId = Guid.Parse("0A0B5BBF-C4F3-4387-8FC4-7FB43E6A867B"), CountryName = "Germany" },
                    new Country() { CountryId = Guid.Parse("04E78F38-299A-4527-A04C-F11E3759BFC6"), CountryName = "India" },
                    new Country() { CountryId = Guid.Parse("F169B8A7-D259-442E-A9DE-EC2E7F06BD76"), CountryName = "United Kingdom" },
                    new Country() { CountryId = Guid.Parse("0DEC49DB-3A4E-47FD-93F5-963C53A0EDEC"), CountryName = "France" },
                    new Country() { CountryId = Guid.Parse("7BDBF161-0BCF-46C8-9584-5146B7931840"), CountryName = "Russia" },
                    new Country() { CountryId = Guid.Parse("21CBDECF-7EFF-452F-A49E-40E60637ED5B"), CountryName = "Italy" },
                    new Country() { CountryId = Guid.Parse("0204CB55-655F-466E-B719-4AA4CCEF02AE"), CountryName = "Iran" },
                    new Country() { CountryId = Guid.Parse("885A8DF7-4B96-4C4D-8A8F-6E8C09803F40"), CountryName = "Brazil" },
                    new Country() { CountryId = Guid.Parse("00CED539-CB78-4AD5-AB65-3FF52DB81521"), CountryName = "South Korea" },
                    new Country() { CountryId = Guid.Parse("D3CF764E-F14E-434A-9304-5DF462BF2F48"), CountryName = "Australia" },
                    new Country() { CountryId = Guid.Parse("5EC2CDA7-57F4-4D3B-9F6D-7535D59C4052"), CountryName = "Mexico" },
                    new Country() { CountryId = Guid.Parse("5D7B69BB-BD9A-4EE9-8FA2-8052B0EE179A"), CountryName = "Indonesia" },
                    new Country() { CountryId = Guid.Parse("53973B9C-C9B9-415C-A6B5-8F8FFF85B5DD"), CountryName = "Saudi Arabia" },
                    new Country() { CountryId = Guid.Parse("C2749EB9-83EC-4DC7-873F-3115E128393C"), CountryName = "Netherlands" },
                    new Country() { CountryId = Guid.Parse("3F3F915D-BBF4-4624-92F0-D8CF1BE2F57D"), CountryName = "Turkey" },
                    new Country() { CountryId = Guid.Parse("DF6A60F5-6B3D-4F59-9C34-7A84FB63C839"), CountryName = "Switzerland" },
                    new Country() { CountryId = Guid.Parse("BA52453B-ED7B-4AF2-96F1-FC81949B22B2"), CountryName = "Poland" },
                    new Country() { CountryId = Guid.Parse("AF477ECD-A270-4594-899C-E9BDC16D3285"), CountryName = "Argentina" },
                    new Country() { CountryId = Guid.Parse("B8D7DD62-04FC-4F42-A338-C767ADFCAD06"), CountryName = "Sweden" },
                    new Country() { CountryId = Guid.Parse("F4D81476-0872-43E4-B382-DB098F00608F"), CountryName = "Belgium" },
                    new Country() { CountryId = Guid.Parse("BC404F0F-E645-4D63-957B-5BD41075FFF4"), CountryName = "Thailand" },*/

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
                    PersonName = "Sion",
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


                case nameof(PersonResponse.Age):
                    matchingPersons = allPersons.Where(temp => (temp.Age != null) ?
                    temp.Age.Value.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase) : true).ToList();
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
