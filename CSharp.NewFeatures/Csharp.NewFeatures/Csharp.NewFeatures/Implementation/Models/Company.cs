namespace Csharp.NewFeatures.Implementation.Models;

public record Company
{
    public int DealerGroupId { get; init; }
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string City { get; init; } = string.Empty;
    public double Latitude { get; init; }
    public double Longitude { get; init; }
    public int Distance { get; init; }

}