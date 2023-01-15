using Entities;
using ServiceContracts;
using ServiceContracts.DTO;
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

        public PersonsService()
        {
            _person = new List<Person>();
            _countriesService = new CountriesService();
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

            return person.ToPersonResponse();
        }

        public List<PersonResponse> GetAllPersons()
        {
            return _person.Select(temp => temp.ToPersonResponse()).ToList();
        }
    }
}
