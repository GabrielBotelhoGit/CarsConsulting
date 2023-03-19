using CarsConsulting.DTOs;

namespace CarsConsulting.Services
{
    public interface ICarService
    {
        public Task<List<CarDto>> GetAllCarDtos();
    }
}
