using HealthCheckAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace HealthCheckAPI.Controllers
{
    [ApiController]
    [Route("/api/cities/{cityId:int}/poi")]
    public class PointOfInterestController : Controller
    {
        [HttpGet]
        public ActionResult GetPointOfInterests(int cityId)
        {
            var city = CitiesDataStores.Current.Cities.FirstOrDefault(x => x.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }

            var poi = city.PointOfInterests;
            return Ok(poi);
        }

        [HttpGet("{pointId:int}", Name = "GetPointOfInterest")]
        

        public ActionResult GetPointOfInterest(int cityId, int pointId)
        {
            if (pointId <= 0) throw new ArgumentOutOfRangeException(nameof(pointId));
            var poi = CitiesDataStores.
                Current.
                Cities.
                FirstOrDefault(x => x.Id == cityId)?
                .PointOfInterests
                .FirstOrDefault(x => x.Id == pointId);
            if (poi != null)
            {
                return Ok(poi);
            }

            return NotFound();

        }

        [HttpPost]
        public ActionResult<PointOfInterestCreationDto> CreatePointOfInterest(int cityId, PointOfInterestCreationDto pointOfInterest)
        {
            if (cityId <= 0) throw new ArgumentException($"{nameof(cityId)} cannot be zero");

            var city = CitiesDataStores.Current.Cities.FirstOrDefault(x => x.Id == cityId);
            if (city == null) return NotFound();
            {
                var maxPointOfInterest = city.PointOfInterests.Max(x => x.Id);

                var newPointOfInterest = new PointOfInterestDto()
                {
                    Description = pointOfInterest.Description,
                    Id = ++maxPointOfInterest,
                    Name = pointOfInterest.Name,
                };

                city.PointOfInterests.Add(newPointOfInterest);

                return CreatedAtRoute("GetPointOfInterest",
                    new
                    {
                        cityId,
                        pointId = ++maxPointOfInterest
                    }, newPointOfInterest);
            }

        }
    }
}
