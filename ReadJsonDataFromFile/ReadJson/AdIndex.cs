


using Microsoft.Spatial;

namespace ReadJson
{
    public class AdIndex
    {

        public string? Id { get; set; }
        public string? ForeignId { get; set; }
        public GeographyPoint? Location { get; set; }
        public GeographyPoint?[] SearchLocations { get; set; }


    }

    //public class GeoLocation
    //{
    //    GeographyPoint coordinates { get; set; }

    //}
}
