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

        [HttpGet("{poiId:int}")]

        public ActionResult GetPointOfInterest(int cityId, int poiId)
        {
            if (poiId <= 0) throw new ArgumentOutOfRangeException(nameof(poiId));
            var poi = CitiesDataStores.
                Current.
                Cities.
                FirstOrDefault(x => x.Id == cityId)?
                .PointOfInterests
                .FirstOrDefault(x => x.Id == poiId);
            if (poi != null)
            {
                return Ok(poi);
            }

            return NotFound();

        }
    }
}
