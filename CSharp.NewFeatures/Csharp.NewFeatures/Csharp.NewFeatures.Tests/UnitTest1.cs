using Csharp.NewFeatures.Implementation;

namespace Csharp.NewFeatures.Tests
{

    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class DataProcessingManagerTests
    {
        [Test]
        public void CalculateDistance_ThrowsArgumentException_WhenLatitudeIsNaN()
        {
            // Arrange
            var dealerLatitude = 40.0;
            var dealerLongitude = -75.0;

            // Act and Assert
            Assert.Throws<ArgumentException>(() => DataProcessingManager.CalculateDistance(double.NaN, dealerLongitude));
        }

        [Test]
        public void CalculateDistance_ReturnsCorrectValue_WhenInputsAreValid()
        {
            // Arrange
            var dealerLatitude = 40.0;
            var dealerLongitude = -75.0;
            var expectedDistance = 15; // expected distance in km

            // create a substitute for the Latitude and Longitude values
            var latitude = Substitute.For<double>();
            latitude.Returns(37.7749); // set the value of latitude to a known value

            var longitude = Substitute.For<double>();
            longitude.Returns(-122.4194); // set the value of longitude to a known value

            // Act
            var distance = DataProcessingManager.CalculateDistance(dealerLatitude, dealerLongitude);

            // Assert
            Assert.AreEqual(expectedDistance, distance);
        }
    }


}