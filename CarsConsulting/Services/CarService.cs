using AutoMapper;
using CarsConsulting.DAL.Models;
using CarsConsulting.DTOs;
using CarsConsulting.Repositories;

namespace CarsConsulting.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public CarService(ICarRepository carRepository,
            IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<List<CarDto>> GetAllCarDtos()
        {
            List<Car> cars = await _carRepository.GetAllAsync().ConfigureAwait(false);
            return _mapper.Map<List<CarDto>>(cars);
        }
    }
}
