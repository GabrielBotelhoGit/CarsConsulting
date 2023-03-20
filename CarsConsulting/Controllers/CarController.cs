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
            List<CarDto> cars = await _carService.GetAllCarDtosAsync().ConfigureAwait(false);
            return Ok(cars);
        }

        [HttpGet("{id}")]
        [Produces(typeof(CarDto))]
        [SwaggerOperation("Get a specific car")]
        public async Task<ActionResult> GetByIdAsync(Guid id)
        {
            CarDto car = await _carService.GetCarDtoAsync(id).ConfigureAwait(false);
            return Ok(car);
        }

        [HttpPost]
        [Produces(typeof(bool))]
        [SwaggerOperation("Create a new car")]
        public async Task<ActionResult> CreateAsync([FromBody] CarDto carDto)
        {
            await _carService.CreateCarAsync(carDto).ConfigureAwait(false);
            return Ok(true);
        }

        [HttpPut("{id}")]
        [Produces(typeof(bool))]
        [SwaggerOperation("Update a car")]
        public async Task<ActionResult> UpdateAsync([FromBody] CarDto carDto, [FromRoute] Guid id)
        {
            await _carService.UpdateCarAsync(carDto, id).ConfigureAwait(false);
            return Ok(true);
        }

        [HttpDelete("{id}")]
        [Produces(typeof(bool))]
        [SwaggerOperation("Delete a car")]
        public async Task<ActionResult> DeleteAsync([FromRoute] Guid id)
        {
            await _carService.DeleteCarAsync(id).ConfigureAwait(false);
            return Ok(true);
        }

        [HttpGet("Enums")]
        [Produces(typeof(bool))]
        [SwaggerOperation("Get the car enums")]
        public ActionResult GetCarEnums()
        {            
            return Ok(_carService.GetEnumValues());
        }
    }
}