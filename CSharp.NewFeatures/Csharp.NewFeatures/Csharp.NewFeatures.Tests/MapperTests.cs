using Csharp.NewFeatures.Implementation;
using Csharp.NewFeatures.Implementation.Models;

namespace Csharp.NewFeatures.Tests;

[TestFixture]
public class MapperTests
{
    [Test]
    public void Map_ReturnsEmptyList_WhenInputIsNull()
    {
        // Arrange
        List<Company>? companies = null;
        var location = (latitude: 10.0, longitude: 20.0);

        // Act
        var result = companies.Map(location);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Map_ReturnsEmptyList_WhenInputIsEmpty()
    {
        // Arrange
        var companies = new List<Company>();
        var location = (latitude: 10.0, longitude: 20.0);

        // Act
        var result = companies.Map(location);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Map_ReturnsMappedList_WhenInputIsValid()
    {
        // Arrange
        var companies = new List<Company>
        {
            new Company { Name = "Company A", DealerGroupId = 1, Id = 1, Latitude = 12.0, Longitude = 22.0 },
            new Company { Name = "Company B", DealerGroupId = 2, Id = 2, Latitude = 14.0, Longitude = 24.0 }
        };
        var location = (latitude: 10.0, longitude: 20.0);


        // Act
        var result = companies.Map(location);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result, Has.Count.EqualTo(2));
        Assert.That(result[0].Name, Is.EqualTo("Company A"));
        Assert.That(result[0].DealerGroupId, Is.EqualTo(1));
        Assert.That(result[0].Id, Is.EqualTo(1));
        Assert.That(result[0].Distance, Is.EqualTo(10085));
        Assert.That(result[1].Name, Is.EqualTo("Company B"));
        Assert.That(result[1].DealerGroupId, Is.EqualTo(2));
        Assert.That(result[1].Id, Is.EqualTo(2));
        Assert.That(result[1].Distance, Is.EqualTo(10080));
    }
}