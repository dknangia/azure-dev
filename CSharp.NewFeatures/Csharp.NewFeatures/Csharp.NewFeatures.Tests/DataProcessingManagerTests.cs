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
            var expectedDistance = 598; // expected distance in km

            

            // Act
            var distance = DataProcessingManager.CalculateDistance(dealerLatitude, dealerLongitude);

            // Assert
            Assert.That(distance, Is.EqualTo(expectedDistance));
        }
    }


}