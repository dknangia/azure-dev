namespace HealthCheckAPI.Models
{
    public class CityDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public IEnumerable<PointOfInterest> PointOfInterests { get; set; } = new List<PointOfInterest>();

    }
}
