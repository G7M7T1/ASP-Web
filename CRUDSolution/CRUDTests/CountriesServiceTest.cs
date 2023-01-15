using ServiceContracts;
using ServiceContracts.DTO;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDTests
{
    public class CountriesServiceTest
    {
        private readonly IcountriesService _countriesService;

        public CountriesServiceTest()
        {
            _countriesService = new CountriesService();
        }

        #region Add Country

        [Fact]
        public void AddCountry_nullCountry()
        {
            CountryAddRequest? request = null;

            Assert.Throws<ArgumentNullException>(() => _countriesService.AddCountry(request));

            // _countriesService.AddCountry(request);
        }


        [Fact]
        public void AddCountry_CountryNameIsNull()
        {
            CountryAddRequest? request = new CountryAddRequest() { CountryName = null };

            Assert.Throws<ArgumentException>(() => _countriesService.AddCountry(request));

            // _countriesService.AddCountry(request);
        }


        [Fact]
        public void AddCountry_DuplicateCountryName()
        {
            CountryAddRequest? request1 = new CountryAddRequest() { CountryName = "CA" };

            CountryAddRequest? request2 = new CountryAddRequest() { CountryName = "CA" };

            Assert.Throws<ArgumentException>(() =>
            {
                _countriesService.AddCountry(request1);
                _countriesService.AddCountry(request2);
            });

            // _countriesService.AddCountry(request);
        }


        [Fact]
        public void AddCountry_ProperCountryDetails()
        {
            CountryAddRequest? request = new CountryAddRequest() { CountryName = "USA" };

            CountryResponse response= _countriesService.AddCountry(request);

            List<CountryResponse> coutries_from_GetAllCountries = _countriesService.GetAllCountries();

            Assert.True(response.CountryId != Guid.Empty);
            Assert.Contains(response, coutries_from_GetAllCountries);
        }

        #endregion


        #region Get All Countries

        [Fact]
        public void GetAllCountries_EmptyList()
        {
            List<CountryResponse> actual_country_response_list = _countriesService.GetAllCountries();

            Assert.Empty(actual_country_response_list);
        }

        [Fact]
        public void GetAllCountries_AddFewCountries()
        {
            List<CountryAddRequest> country_request_list = new List<CountryAddRequest>()
            {
                new CountryAddRequest() { CountryName = "UK"},
                new CountryAddRequest() { CountryName = "CA"},
                new CountryAddRequest() { CountryName = "USA"},
                new CountryAddRequest() { CountryName = "MEX"},
                new CountryAddRequest() { CountryName = "GER"},
                new CountryAddRequest() { CountryName = "LUX"}
            };


            List<CountryResponse> countries_list_from_add_country = new List<CountryResponse>();

            // foreach to each element with
            foreach (CountryAddRequest country_request in country_request_list)
            {
                countries_list_from_add_country.Add(_countriesService.AddCountry(country_request));
            }

            
            List<CountryResponse> actualCountryResponseList = _countriesService.GetAllCountries();

            // foreach the expected country in the countries list from add country
            foreach (CountryResponse expected_country in countries_list_from_add_country)
            {
                Assert.Contains(expected_country, actualCountryResponseList);
            }
        }

        #endregion


        #region Get Country By CountryID
        [Fact]
        public void GetCountryByCountryID_NullCountryID()
        {
            Guid? countryID = null;

            CountryResponse? country_response_from_method = _countriesService.GetCountryByCountryID(countryID);

            Assert.Null(country_response_from_method);
        }

        [Fact]
        public void GetCountryByCountryID_ValidCountryID()
        {
            CountryAddRequest? country_add_request = new CountryAddRequest() { CountryName = "USA" };

            // Adding Country To List
            CountryResponse country_response_from_add = _countriesService.AddCountry(country_add_request);

            CountryResponse? country_response_from_get = _countriesService.GetCountryByCountryID(country_response_from_add.CountryId);

            Assert.Equal(country_response_from_add, country_response_from_get);
        }
        #endregion
    }
}
