﻿namespace Csharp.NewFeatures.Implementation.Models;

public class Company
{
    public int DealerGroupId { get; set; }
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public int Distance { get; set; }

}