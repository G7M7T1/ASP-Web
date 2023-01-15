using Entities;
using ServiceContracts;
using ServiceContracts.DTO;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace CRUDTests
{
    public class PersonsServiceTest
    {
        private readonly IPersonService _personService;

        private readonly IcountriesService _countriesService;

        private readonly ITestOutputHelper _outputHelper;

        public PersonsServiceTest(ITestOutputHelper testOutputHelper)
        {
            _personService = new PersonsService();
            _countriesService = new CountriesService();
            _outputHelper = testOutputHelper;
        }


        #region Add Person
        
        [Fact]
        public void AddPerson_NullPerson()
        {
            PersonAddRequest? personAddRequest = null;

            // Act
            Assert.Throws<ArgumentNullException>(() =>
            {
                _personService.AddPerson(personAddRequest);
            });
        }


        [Fact]
        public void AddPerson_PersonNameIsNull()
        {
            PersonAddRequest personAddRequest = new PersonAddRequest()
            {
                PersonName = null,
            };

            // Act
            Assert.Throws<ArgumentException>(() =>
            {
                _personService.AddPerson(personAddRequest);
            });
        }


        [Fact]
        public void AddPerson_ProperPersonDetails()
        {
            PersonAddRequest personAddRequest = new PersonAddRequest()
            {
                PersonName = "Lis",
                Email = "lis@example.com",
                Address = "Address Example",
                CountryID = Guid.NewGuid(),
                Gender = ServiceContracts.Enums.GenderOptions.Male,
                DateOfBirth = DateTime.Parse("1977-01-01"),
                ReceiveNewsLetters= true
            };

            PersonResponse person_response_from_add = _personService.AddPerson(personAddRequest);

            List<PersonResponse> persons_list = _personService.GetAllPersons();

            // Act
            Assert.True(person_response_from_add.PersonID != Guid.Empty);
            Assert.Contains(person_response_from_add, persons_list);
        }
        #endregion


        #region Get Person By Person ID
        // null as PersonId
        [Fact]
        public void GetPersonByPersonID_NullPersonID()
        {
            Guid? personID = null;

            PersonResponse? person_response_from_get = _personService.GetPersonByPersonID(personID);

            Assert.Null(person_response_from_get);
        }


        [Fact]
        public void GetPersonByPersonID_WithPersonID()
        {
            // Make Country First Because We Need Country ID In Person Object
            CountryAddRequest countryAddRequest = new CountryAddRequest() { CountryName = "Canada" };

            // Add Country
            CountryResponse countryResponse = _countriesService.AddCountry(countryAddRequest);

            // Create Person
            PersonAddRequest personAddRequest = new PersonAddRequest()
            {
                PersonName = "Lis",
                Email = "email@gmail.com",
                Address = "1 Street",
                CountryID = countryResponse.CountryId,
                DateOfBirth = DateTime.Parse("1977-07-07"),
                Gender = ServiceContracts.Enums.GenderOptions.Male,
                ReceiveNewsLetters = true
            };

            // Get Person ID (After AddPerson)
            PersonResponse person_response_from_add = _personService.AddPerson(personAddRequest);

            PersonResponse? person_response_from_get = _personService.GetPersonByPersonID(person_response_from_add.PersonID);

            Assert.Equal(person_response_from_add, person_response_from_get);
        }

        #endregion


        #region Get All Person
        [Fact]
        public void GetAllPersons_EmptyList()
        {
            // Act
            List<PersonResponse> persons_from_get = _personService.GetAllPersons();

            // Assert
            Assert.Empty(persons_from_get);
        }


        [Fact]
        public void GetAllPersons_AddFewPersons()
        {
            // Make Country
            CountryAddRequest country_request_1 = new CountryAddRequest() { CountryName = "US" };
            CountryAddRequest country_request_2 = new CountryAddRequest() { CountryName = "CA" };
            CountryAddRequest country_request_3 = new CountryAddRequest() { CountryName = "UK" };

            // Add Country || Get Country ID
            CountryResponse country_response_1 = _countriesService.AddCountry(country_request_1);
            CountryResponse country_response_2 = _countriesService.AddCountry(country_request_2);
            CountryResponse country_response_3 = _countriesService.AddCountry(country_request_3);

            // Make Person
            PersonAddRequest personAddRequest_1 = new PersonAddRequest()
            {
                PersonName = "Jake",
                Email = "Jake@gmail.com",
                Gender = ServiceContracts.Enums.GenderOptions.Male,
                Address = "Jake's Home",
                CountryID = country_response_1.CountryId,
                DateOfBirth = DateTime.Parse("1977-07-07"),
                ReceiveNewsLetters= true
            };

            PersonAddRequest personAddRequest_2 = new PersonAddRequest()
            {
                PersonName = "Mark",
                Email = "Mark@gmail.com",
                Gender = ServiceContracts.Enums.GenderOptions.Male,
                Address = "Mark's Home",
                CountryID = country_response_2.CountryId,
                DateOfBirth = DateTime.Parse("1977-07-08"),
                ReceiveNewsLetters = false
            };

            PersonAddRequest personAddRequest_3 = new PersonAddRequest()
            {
                PersonName = "Lucy",
                Email = "Lucy@gmail.com",
                Gender = ServiceContracts.Enums.GenderOptions.Female,
                Address = "Lucy's Home",
                CountryID = country_response_3.CountryId,
                DateOfBirth = DateTime.Parse("1977-07-09"),
                ReceiveNewsLetters = true
            };

            PersonAddRequest personAddRequest_4 = new PersonAddRequest()
            {
                PersonName = "Hou",
                Email = "Hou@gmail.com",
                Gender = ServiceContracts.Enums.GenderOptions.Female,
                Address = "Hou's Home",
                CountryID = country_response_2.CountryId,
                DateOfBirth = DateTime.Parse("1997-07-10"),
                ReceiveNewsLetters = true
            };

            PersonAddRequest personAddRequest_5 = new PersonAddRequest()
            {
                PersonName = "Lis",
                Email = "Lis@gmail.com",
                Gender = ServiceContracts.Enums.GenderOptions.Male,
                Address = "Lis's Home",
                CountryID = country_response_2.CountryId,
                DateOfBirth = DateTime.Parse("1997-07-11"),
                ReceiveNewsLetters = false
            };


            // Make Person Add Request List
            List<PersonAddRequest> all_person_requests = new List<PersonAddRequest>()
            {
                personAddRequest_1, personAddRequest_2, personAddRequest_3, personAddRequest_4, personAddRequest_5
            };

            // Make Person Response List
            List<PersonResponse> person_response_list_from_add = new List<PersonResponse>();

            // Add Person || Person ID
            foreach (PersonAddRequest person_request in all_person_requests)
            {
                PersonResponse person_response = _personService.AddPerson(person_request);

                // Add To List
                person_response_list_from_add.Add(person_response);
            }

            // Print person_response_list_from_add
            _outputHelper.WriteLine("Expected:");
            foreach (PersonResponse person_response_from_add in person_response_list_from_add)
            {
                _outputHelper.WriteLine(person_response_from_add.ToString());
            }


            // GetAllPerson Get List
            List<PersonResponse> person_list_from_get = _personService.GetAllPersons();

            // Print person_list_from_get
            _outputHelper.WriteLine("Actual:");
            foreach (PersonResponse person_response_from_get in person_list_from_get)
            {
                _outputHelper.WriteLine(person_response_from_get.ToString());
            }

            foreach (PersonResponse person_response_from_add in person_response_list_from_add)
            {
                Assert.Contains(person_response_from_add, person_list_from_get);
            }
        }

        #endregion


        #region Get Filtered Persons
        [Fact]
        public void GetFilteredPersons_EmptySearchText()
        {
            // Make Country
            CountryAddRequest country_request_1 = new CountryAddRequest() { CountryName = "US" };
            CountryAddRequest country_request_2 = new CountryAddRequest() { CountryName = "CA" };
            CountryAddRequest country_request_3 = new CountryAddRequest() { CountryName = "UK" };

            // Add Country || Get Country ID
            CountryResponse country_response_1 = _countriesService.AddCountry(country_request_1);
            CountryResponse country_response_2 = _countriesService.AddCountry(country_request_2);
            CountryResponse country_response_3 = _countriesService.AddCountry(country_request_3);

            // Make Person
            PersonAddRequest personAddRequest_1 = new PersonAddRequest()
            {
                PersonName = "Jake",
                Email = "Jake@gmail.com",
                Gender = ServiceContracts.Enums.GenderOptions.Male,
                Address = "Jake's Home",
                CountryID = country_response_1.CountryId,
                DateOfBirth = DateTime.Parse("1977-07-07"),
                ReceiveNewsLetters = true
            };

            PersonAddRequest personAddRequest_2 = new PersonAddRequest()
            {
                PersonName = "Mark",
                Email = "Mark@gmail.com",
                Gender = ServiceContracts.Enums.GenderOptions.Male,
                Address = "Mark's Home",
                CountryID = country_response_2.CountryId,
                DateOfBirth = DateTime.Parse("1977-07-08"),
                ReceiveNewsLetters = false
            };

            PersonAddRequest personAddRequest_3 = new PersonAddRequest()
            {
                PersonName = "Lucy",
                Email = "Lucy@gmail.com",
                Gender = ServiceContracts.Enums.GenderOptions.Female,
                Address = "Lucy's Home",
                CountryID = country_response_3.CountryId,
                DateOfBirth = DateTime.Parse("1977-07-09"),
                ReceiveNewsLetters = true
            };

            PersonAddRequest personAddRequest_4 = new PersonAddRequest()
            {
                PersonName = "Hou",
                Email = "Hou@gmail.com",
                Gender = ServiceContracts.Enums.GenderOptions.Female,
                Address = "Hou's Home",
                CountryID = country_response_2.CountryId,
                DateOfBirth = DateTime.Parse("1997-07-10"),
                ReceiveNewsLetters = true
            };

            PersonAddRequest personAddRequest_5 = new PersonAddRequest()
            {
                PersonName = "Lis",
                Email = "Lis@gmail.com",
                Gender = ServiceContracts.Enums.GenderOptions.Male,
                Address = "Lis's Home",
                CountryID = country_response_2.CountryId,
                DateOfBirth = DateTime.Parse("1997-07-11"),
                ReceiveNewsLetters = false
            };


            // Make Person Add Request List
            List<PersonAddRequest> all_person_requests = new List<PersonAddRequest>()
            {
                personAddRequest_1, personAddRequest_2, personAddRequest_3, personAddRequest_4, personAddRequest_5
            };

            // Make Person Response List
            List<PersonResponse> person_response_list_from_add = new List<PersonResponse>();

            // Add Person || Person ID
            foreach (PersonAddRequest person_request in all_person_requests)
            {
                PersonResponse person_response = _personService.AddPerson(person_request);

                // Add To List
                person_response_list_from_add.Add(person_response);
            }

            // Print person_response_list_from_add
            _outputHelper.WriteLine("Expected:");
            foreach (PersonResponse person_response_from_add in person_response_list_from_add)
            {
                _outputHelper.WriteLine(person_response_from_add.ToString());
            }


            // GetAllPerson Get List
            List<PersonResponse> person_list_from_search = _personService.GetFilteredPersons(nameof(Person.PersonName), "");

            // Print person_list_from_get
            _outputHelper.WriteLine("Actual:");
            foreach (PersonResponse person_response_from_get in person_list_from_search)
            {
                _outputHelper.WriteLine(person_response_from_get.ToString());
            }

            foreach (PersonResponse person_response_from_add in person_response_list_from_add)
            {
                Assert.Contains(person_response_from_add, person_list_from_search);
            }
        }
        #endregion
    }
}
