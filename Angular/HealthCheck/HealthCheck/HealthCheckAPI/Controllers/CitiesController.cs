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
            return new JsonResult(new List<object>
            {
                new {id =1 , Name = "New York"},
                new {id =2, Name = "Canada"}
            });
        }


        [HttpGet("getCity")]
        public JsonResult GetCity()
        {
            return new JsonResult(new List<object>
            {
                new {id =1 , Name = "New York"},
               
            });
        }
    }
}
