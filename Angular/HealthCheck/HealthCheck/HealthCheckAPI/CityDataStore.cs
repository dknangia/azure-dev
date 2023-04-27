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
                    Description = "The one with big park",
                    PointOfInterests = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 101,
                            Name = "Empire Building",
                            Description = "Empire building of the tallest"
                        },
                        new PointOfInterestDto()
                        {

                            Id = 102,
                            Name = "Empire Building II",
                            Description = "Empire building of the tallest"
                        }
                    }

                },
                new CityDto()
                {
                    Id = 2,
                    Name = "New Delhi",
                    Description = "The one with tallest building"
                    ,
                    PointOfInterests = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 201,
                            Name = "Kutub Minaar",
                            Description = "Empire building of the tallest"
                        },
                        new PointOfInterestDto()
                        {

                            Id = 202,
                            Name = "Zoo house",
                            Description = "Empire building of the tallest"
                        }
                    }
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
