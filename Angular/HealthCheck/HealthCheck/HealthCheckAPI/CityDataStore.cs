using HealthCheckAPI.Models;

namespace HealthCheckAPI
{
    public class CitiesDataStores
    {
        public List<CityDto> Cities { get; set; }
        public static CitiesDataStores Current { get; } = new CitiesDataStores(); 
        public CitiesDataStores()
        {
            Cities = new List<CityDto>()
            {
                new CityDto()
                {
                    Id = 1,
                    Name = "New york city",
                    Description = "The one with big park"
                },
                new CityDto()
                {
                    Id = 2,
                    Name = "New Delhi",
                    Description = "The one with tallest building"
                },

                new CityDto()
                {
                    Id = 3,
                    Name = "Waterloo",
                    Description = "The one with a big Park and colleges"
                },

                new CityDto()
                {
                    Id = 4,
                    Name = "Toronto",
                    Description = "The city with TV tower"
                },

            };
        }
    }
}
