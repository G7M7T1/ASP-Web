using Entities;
using System;
using System.Collections.Generic;

namespace ServiceContracts.DTO
{
    /// <summary>
    /// Country Response Is Contain the CountryId and CountryName
    /// </summary>
    public class CountryResponse
    {
        public Guid CountryId { get; set; }

        public string? CountryName { get; set; }

        // Check Country ID and Country Name is Match or Not
        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj.GetType() != typeof(CountryResponse))
            {
                return false;
            }

            CountryResponse country_to_compare = (CountryResponse)obj;

            // return the ID and Name, if the ID and Name is Match it will return True
            // Else It will return false
            // This is the Equal Method
            return this.CountryId == country_to_compare.CountryId 
                && this.CountryName== country_to_compare.CountryName;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    public static class CountryExtensions
    {
        // ToCountryResponse need Country Obj
        public static CountryResponse ToCountryResponse (this Country country)
        {
            return new CountryResponse()
            {
                CountryId = country.CountryId,
                CountryName = country.CountryName
            };
        }
    }
}
