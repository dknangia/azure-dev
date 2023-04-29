using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.NewFeatures.Implementation
{
    public static class DataProcessingManager
    {
        static readonly double Latitude = 43.466667;
        static readonly double Longitude = -80.516670;
        public static void DataProcessing()
        {
            var companies = DataSource.GetData();

            var companyGrouped = companies.GroupBy(x => x.DealerGroupId);

            foreach (var item in companyGrouped)
            {
                Console.WriteLine(item.Key);
                foreach (var company in item)
                {
                    Console.WriteLine($"\t -{company.Name}");
                    Console.WriteLine($"\t - {CalculateDistance(company.Latitude, company.Longitude)} Km");
                }
            }

        }

        public static int CalculateDistance(double dealerLatitude, double dealerLongitude)
        {

            if (double.IsNaN(Latitude) || double.IsNaN(Longitude) || double.IsNaN(dealerLatitude) || double.IsNaN(dealerLongitude))
                throw new ArgumentException("Latitude or Longitude are not in correct format");
            double x1 = Latitude * (Math.PI / 180.0);
            double y1 = Longitude * (Math.PI / 180.0);
            double x2 = dealerLatitude * (Math.PI / 180.0);
            double y2 = dealerLongitude * (Math.PI / 180.0) - y1;
            double d3 = Math.Pow(Math.Sin((x2 - x1) / 2.0), 2.0) + Math.Cos(x1) * Math.Cos(x2) * Math.Pow(Math.Sin(y2 / 2.0), 2.0);
            return (int)(6376500.0 * (2.0 * Math.Atan2(Math.Sqrt(d3), Math.Sqrt(1.0 - d3))) / 1000);


        }
    }
}
