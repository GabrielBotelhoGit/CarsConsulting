using CarsConsulting.Common.DTOs;
using CarsConsulting.DTOs;

namespace CarsConsulting.Services
{
    public interface ICarService
    {
        public Task<List<CarDto>> GetAllCarDtosAsync();
        public Task<CarDto> GetCarDtoAsync(Guid id);
        public Task CreateCarAsync(CarDto carDto);
        public Task UpdateCarAsync(CarDto carDto, Guid id);
        public Task DeleteCarAsync(Guid id);
        public CarEnumsDto GetEnumValues();
    }
}
