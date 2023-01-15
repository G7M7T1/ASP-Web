using ServiceContracts.DTO;

namespace ServiceContracts
{
    public interface IcountriesService
    {
        /// <summary>
        /// Returns The Country Object After Adding It
        /// </summary>
        /// <param name="countryAddRequest"></param>
        /// <returns></returns>
        CountryResponse AddCountry(CountryAddRequest? countryAddRequest); 

        /// <summary>
        /// Returns All Countries From List
        /// </summary>
        /// <returns></returns>
        List<CountryResponse> GetAllCountries();

        /// <summary>
        /// Return a country Object based on the given country
        /// </summary>
        /// <param name="countryId">CountryID (Guid)</param>
        /// <returns>CountryResponse Object</returns>
        CountryResponse? GetCountryByCountryID(Guid? countryId);
    }
} 