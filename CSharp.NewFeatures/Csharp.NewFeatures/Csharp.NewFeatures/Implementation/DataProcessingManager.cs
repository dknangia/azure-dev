using System.Runtime.CompilerServices;
using Csharp.NewFeatures.Implementation.Models;

namespace Csharp.NewFeatures.Implementation
{
    public static class DataProcessingManager
    {
        private const double Latitude = 43.466667;
        private const double Longitude = -80.516670;

        public static void DataProcessing()
        {
            var companies = DataSource.GetData().Map((Latitude, Longitude));

            var companyGrouped = companies.GroupBy(x => x.DealerGroupId);

            foreach (var item in companyGrouped)
            {
                Console.WriteLine(item.Key);
                foreach (var company in item)
                {
                    Console.WriteLine($"\t -{company.Name}");
                    Console.WriteLine($"\t\t -{company.Distance} Km");
                }
            }

        }

        public static int CalculateDistance(double dealerLatitude, double dealerLongitude)
        {

            if (double.IsNaN(Latitude) || double.IsNaN(Longitude) || double.IsNaN(dealerLatitude) ||
                double.IsNaN(dealerLongitude))
                throw new ArgumentException("Latitude or Longitude are not in correct format");
            double x1 = Latitude * (Math.PI / 180.0);
            double y1 = Longitude * (Math.PI / 180.0);
            double x2 = dealerLatitude * (Math.PI / 180.0);
            double y2 = dealerLongitude * (Math.PI / 180.0) - y1;
            double d3 = Math.Pow(Math.Sin((x2 - x1) / 2.0), 2.0) +
                        Math.Cos(x1) * Math.Cos(x2) * Math.Pow(Math.Sin(y2 / 2.0), 2.0);
            return (int)(6376500.0 * (2.0 * Math.Atan2(Math.Sqrt(d3), Math.Sqrt(1.0 - d3))) / 1000);


        }
    }

    public static class Mapper
    {
        public static List<Company> Map(this List<Company>? companies, (double latitdue, double longitude) location)
        {
            var data = new List<Company>();

            if (companies != null && companies.Any())
            {
               data.AddRange( companies.Select(x => new Company
               {
                   Name = x.Name,
                   DealerGroupId = x.DealerGroupId,
                   Id = x.DealerGroupId,
                   Distance = DataProcessingManager.CalculateDistance(x.Latitude, x.Longitude)

               }));
            }

            return data;
        }

    }
}

