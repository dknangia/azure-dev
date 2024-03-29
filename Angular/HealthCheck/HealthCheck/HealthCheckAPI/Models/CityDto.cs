﻿namespace HealthCheckAPI.Models
{
    public class CityDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public IList<PointOfInterestDto> PointOfInterests { get; set; } = new List<PointOfInterestDto>();

    }
}
