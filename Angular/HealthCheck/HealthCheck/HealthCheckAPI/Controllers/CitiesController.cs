using Microsoft.AspNetCore.Mvc;

namespace HealthCheckAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitiesController : ControllerBase
    {

        
        [HttpGet]
        public JsonResult GetCities()
        {
            return new JsonResult((CitiesDataStores.Current.Cities));
        }


        [HttpGet("{id:int}")]
        public JsonResult GetCity(int id)
        {
            return new JsonResult(CitiesDataStores.Current.Cities.Where(x => x.Id == id));
        }

        
    }
}
