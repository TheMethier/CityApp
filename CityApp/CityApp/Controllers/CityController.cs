using CityApp.Models;
using CityApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace CityApp.Controllers
{

    [Route("/api/v1/[controller]")]
    [ApiController]
    public class CityController(ICityService cityService) : ControllerBase
    {
        private readonly ICityService _cityService = cityService;

        [HttpGet("getRandom")]
        public IActionResult GetRandomCity()
        {
            try
            {
                var random = _cityService.GetRandomCity();
                return Ok(random);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet("getCurrent")]
        public IActionResult GetCity([FromQuery] CityRequest cityRequest) 
        {
            try
            {
                var city = _cityService.GetCity(cityRequest);
                return Ok(city);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost("add")]
        public IActionResult AddNewCity([FromBody] CityRequest cityRequest) {

                var city = _cityService.AddCity(cityRequest);
                return Ok(city);
        }
        [HttpGet("getByVehicle")]
        public IActionResult GetCitiesByVehicle([FromQuery] VehicleRequest vehicleRequest)
        {
            try
            {
                var cites = _cityService.GetCitiesByVehicle(vehicleRequest);
                return Ok(cites);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
       

    }
}
