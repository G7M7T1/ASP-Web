using ServiceContracts;

namespace Services
{
    public class CitiesService: ICitiesService
    {
        private List<string> _cities;

        public CitiesService()
        {
            _cities = new List<string>()
            {
                "Montreal",
                "Paris",
                "New York",
                "Tokyo",
                "Rome",
                "Toronto"   
            };
        }

        public List<string> GetCities()
        {
            return _cities;
        }
    }
}