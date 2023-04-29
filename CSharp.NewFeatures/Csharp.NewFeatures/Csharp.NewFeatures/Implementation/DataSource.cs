using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.NewFeatures.Implementation
{
    public static class DataSource
    {
        public static IEnumerable<Company> GetData()
        {
            return new List<Company>
            {
                new Company()
                {
                    Id = 101, City = "Brampton", DealerGroupId = 1001, Latitude = 51.213890, Longitude = -102.462776, Name = "Brampton dealers-1001"
                },
                new Company()
                {
                    Id = 102, City = "Brampton", DealerGroupId = 1001, Latitude = 52.321945, Longitude = -106.584167, Name = "Brampton dealers-1001"
                },
                new Company()
                {
                    Id = 103, City = "Brampton", DealerGroupId = 1002, Latitude = 0, Longitude = 101, Name = "Brampton dealers-1002"
                },
                new Company()
                {
                    Id = 104, City = "Brampton", DealerGroupId = 1002, Latitude = 0, Longitude = 101, Name = "Brampton dealers-1002"
                },
                new Company()
                {
                    Id = 105, City = "Brampton", DealerGroupId = 1003, Latitude = 0, Longitude = 101, Name = "Brampton dealers-1003"
                },
                new Company()
                {
                    Id = 106, City = "Brampton", DealerGroupId = 1003, Latitude = 0, Longitude = 101, Name = "Brampton dealers-1003"
                },
                new Company()
                {
                    Id = 107, City = "Brampton", DealerGroupId = 1003, Latitude = 0, Longitude = 101, Name = "Brampton dealers-1003"
                },
                new Company()
                {
                    Id = 108, City = "Brampton", DealerGroupId = 1004, Latitude = 0, Longitude = 101, Name = "Brampton dealers-1004"
                },
                new Company()
                {
                    Id = 109, City = "Brampton", DealerGroupId = 1004, Latitude = 0, Longitude = 101, Name = "Brampton dealers-1004"
                },
                new Company()
                {
                    Id = 110, City = "Brampton", DealerGroupId = 1004, Latitude = 0, Longitude = 101, Name = "Brampton dealers-1004"
                }

            }; 
        }
    }

    public class Company
    {
        public int DealerGroupId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public double Latitude { get; set; }
        public double Longitude { get; set; }

    }
}
