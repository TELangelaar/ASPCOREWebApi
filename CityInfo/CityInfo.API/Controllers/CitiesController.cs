using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CityInfo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitiesController : ControllerBase
    {
        [HttpGet]
        public JsonResult GetCities()
        {
            return new JsonResult(new List<object>()
                                  {
                                      new {id = 1, Name = "NYC"},
                                      new {id = 2, Name = "Amsterdam"}
                                  });
        }
    }
}
