using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csharp.NewFeatures.Implementation.Models;

namespace Csharp.NewFeatures.Implementation
{
    public static class DataSource
    {
        //43.466667 -80.516670
        public static List<Company> GetData()
        {
            return new List<Company>
            {
                new Company()
                {
                    Id = 101, City = "Brampton", DealerGroupId = 1001, Latitude = 43.4844178, Longitude = -80.5327317, Name = "Brampton dealers-1001"
                },
                new Company()
                {
                    Id = 102, City = "Brampton", DealerGroupId = 1001, Latitude = 52.321945, Longitude = -106.584167, Name = "Brampton dealers-1001"
                },
                new Company()
                {
                    Id = 103, City = "Brampton", DealerGroupId = 1002, Latitude = 50.288055, Longitude = -107.793892, Name = "Brampton dealers-1002"
                },
                new Company()
                {
                    Id = 104, City = "Brampton", DealerGroupId = 1002, Latitude = 52.757500, Longitude = -108.286110, Name = "Brampton dealers-1002"
                },
                new Company()
                {
                    Id = 105, City = "Brampton", DealerGroupId = 1003, Latitude = 50.393333, Longitude = -105.551941, Name = "Brampton dealers-1003"
                },
                new Company()
                {
                    Id = 106, City = "Brampton", DealerGroupId = 1003, Latitude = 50.930557, Longitude = -102.807777, Name = "Brampton dealers-1003"
                },
                new Company()
                {
                    Id = 107, City = "Brampton", DealerGroupId = 1003, Latitude = 52.856388, Longitude = -104.610001, Name = "Brampton dealers-1003"
                },
                new Company()
                {
                    Id = 108, City = "Brampton", DealerGroupId = 1004, Latitude = 52.289722, Longitude =  -106.666664, Name = "Brampton dealers-1004"
                },
                new Company()
                {
                    Id = 109, City = "Brampton", DealerGroupId = 1004, Latitude = 52.201942, Longitude = -105.123055, Name = "Brampton dealers-1004"
                },
                new Company()
                {
                    Id = 110, City = "Brampton", DealerGroupId = 1004, Latitude = 53.278046, Longitude = -110.005470, Name = "Brampton dealers-1004"
                }

            }; 
        }
    }
}
