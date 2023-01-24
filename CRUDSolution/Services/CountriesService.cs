using Entities;
using ServiceContracts;
using ServiceContracts.DTO;

namespace Services
{
    public class CountriesService : IcountriesService
    {
        // private field
        private readonly PersonsDbContext _db;

        // constructor
        public CountriesService(PersonsDbContext personsDbContext)
        {
            _db = personsDbContext;
        }

        public List<CountryResponse> GetAllCountries()
        {
            // D
            return _db.Countries.Select(country => country.ToCountryResponse()).ToList();
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
            if (_db.Countries.Where(temp => temp.CountryName == countryAddRequest.CountryName).Count() > 0)
            {
                throw new ArgumentException("Country Name Already Exists");
            }

            Country country = countryAddRequest.ToCountry();

            country.CountryId = Guid.NewGuid();

            _db.Countries.Add(country);
            _db.SaveChanges();

            return country.ToCountryResponse();
        }

        public CountryResponse? GetCountryByCountryID(Guid? countryId)
        {
            if (countryId == null) { return null; }

            Country? country_response_from_list = _db.Countries.FirstOrDefault(temp => temp.CountryId == countryId);

            if (country_response_from_list == null) { return null; }

            return country_response_from_list.ToCountryResponse();
        }
    }
}