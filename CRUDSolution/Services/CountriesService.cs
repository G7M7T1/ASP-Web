using Entities;
using ServiceContracts;
using ServiceContracts.DTO;

namespace Services
{
    public class CountriesService : IcountriesService
    {
        // private field
        private readonly List<Country> _countries;

        // constructor
        public CountriesService(bool initialize = true)
        {
            _countries = new List<Country>();

            if (initialize)
            {
                _countries = new List<Country>()
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

                    new Country() { CountryId = Guid.Parse("4C94A3EF-B58D-4336-B46E-43E4B74C02B4"), CountryName = "Chile" },
                    new Country() { CountryId = Guid.Parse("97816663-083A-49C1-A972-3E63FE045F17"), CountryName = "France" },
                    new Country() { CountryId = Guid.Parse("23CE6734-8EB6-4E07-A28D-106814591C0D"), CountryName = "Canada" },
                    new Country() { CountryId = Guid.Parse("B0011D9D-9661-42EF-B342-945ECEB7D4D1"), CountryName = "America" },
                    new Country() { CountryId = Guid.Parse("40F9C480-CCC9-4727-AEF7-C3FBC951DBC3"), CountryName = "Spain" }
                };
            }
        }

        public CountryResponse AddCountry(CountryAddRequest? countryAddRequest)
        {
            // countryAddRequest can not be null
            if (countryAddRequest==null)
            {
                throw new ArgumentNullException(nameof(countryAddRequest));
            }

            // countryAddRequest.CountryName can not be null
            if (countryAddRequest.CountryName==null)
            {
                throw new ArgumentException(nameof(countryAddRequest.CountryName));
            }

            // Duplicate Name it is not allow
            if (_countries.Where(temp => temp.CountryName == countryAddRequest.CountryName).Count() > 0)
            {
                throw new ArgumentException("Country Name Already Exists");
            }

            Country country = countryAddRequest.ToCountry();

            country.CountryId = Guid.NewGuid();

            _countries.Add(country);

            return country.ToCountryResponse();
        }

        public List<CountryResponse> GetAllCountries()  
        {
            // D
            return _countries.Select(country => country.ToCountryResponse()).ToList();
        }

        public CountryResponse? GetCountryByCountryID(Guid? countryId)
        {
            if (countryId == null) { return null; }

            Country? country_response_from_list = _countries.FirstOrDefault(temp => temp.CountryId == countryId);

            if (country_response_from_list == null) { return null; }

            return country_response_from_list.ToCountryResponse();
        }
    }
}