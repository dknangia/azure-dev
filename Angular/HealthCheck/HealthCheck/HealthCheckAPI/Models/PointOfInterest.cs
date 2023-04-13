using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HealthCheckAPI.Models;

//public class PointOfInterest
//{
//    public int Id { get; set; }
//    public string? Name { get; set; }
//    public string? Description { get; set; }
//}

public class PointOfInterestCreationDto
{
    
    public string? Name { get; set; } = string.Empty;
    public string? Description { get; set; }

}

public class PointOfInterestDto
{
    public int? Id { get; set; }
    public string? Name { get; set; } = string.Empty;
    public string? Description { get; set; }

}