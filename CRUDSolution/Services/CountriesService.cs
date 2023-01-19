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

                    new Country() { CountryId = Guid.Parse("4C94A3EF-B58D-4336-B46E-43E4B74C02B4"), CountryName = "Chile" },
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
                    new Country() { CountryId = Guid.Parse("BC404F0F-E645-4D63-957B-5BD41075FFF4"), CountryName = "Thailand" }
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