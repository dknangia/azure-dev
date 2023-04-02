using HealthCheckAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace HealthCheckAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitiesController : ControllerBase
    {


        [HttpGet]
        public ActionResult<IEnumerable<CityDto>> GetCities()
        {
            return Ok((CitiesDataStores.Current.Cities));
        }


        [HttpGet("{id:int}")]
        public ActionResult<CityDto> GetCity(int id)
        {
            var result = CitiesDataStores.Current.Cities.FirstOrDefault(x => x.Id == id);

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }


    }
}
