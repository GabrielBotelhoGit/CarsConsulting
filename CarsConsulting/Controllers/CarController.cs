using CarsConsulting.DTOs;
using CarsConsulting.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CarsConsulting.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        [Produces(typeof(List<CarDto>))]
        [SwaggerOperation("Get a list of saved cars")]
        public async Task<ActionResult> GetAllAsync()
        {
            List<CarDto> cars = await _carService.GetAllCarDtos().ConfigureAwait(false);
            return Ok(cars);
        }
    }
}