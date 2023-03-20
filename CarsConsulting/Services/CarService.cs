using AutoMapper;
using CarsConsulting.Common.DTOs;
using CarsConsulting.Common.Exceptions;
using CarsConsulting.DAL.Models;
using CarsConsulting.DTOs;
using CarsConsulting.Enums;
using CarsConsulting.Repositories;

namespace CarsConsulting.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly IMakerService _makerService;
        private readonly IMapper _mapper;

        public CarService(ICarRepository carRepository,
            IMakerService makerService, 
            IMapper mapper)
        {
            _carRepository = carRepository;
            _makerService = makerService;
            _mapper = mapper;
        }             

        public async Task<List<CarDto>> GetAllCarDtosAsync()
        {
            List<Car> cars = await _carRepository.GetAllWithMakerAsync().ConfigureAwait(false);
            return _mapper.Map<List<CarDto>>(cars);
        }

        public async Task<CarDto> GetCarDtoAsync(Guid id)
        {
            Car? car = await _carRepository.GetByIdAsync(id).ConfigureAwait(false);

            if (car == null)
            {
                throw new EntityNotFoundException($"Entity with id:{id} was not found");
            }

            return _mapper.Map<CarDto>(car);
        }

        public async Task CreateCarAsync(CarDto carDto)
        {
            var car = _mapper.Map<Car>(carDto);
            Maker? maker = await _makerService.GetMakerByNameAsync(carDto.Maker).ConfigureAwait(false);

            if (maker != null) { 
                car.Maker = maker;
            }
            else
            {
                car.Maker = await _makerService.CreateMakerAsync(carDto.Maker).ConfigureAwait(false);
            }

            await _carRepository.AddAsync(car).ConfigureAwait(false);
        }

        public async Task UpdateCarAsync(CarDto carDto, Guid id)
        {
            Car? car = await _carRepository.GetByIdAsync(id).ConfigureAwait(false);

            if (car == null)
            {
                throw new EntityNotFoundException($"Entity with id:{id} was not found");
            }
            await UpdateCarAsync(carDto, car).ConfigureAwait(false);

            await _carRepository.UpdateAsync(car).ConfigureAwait(false);
        }

        public async Task DeleteCarAsync(Guid id)
        {
            await _carRepository.DeleteAsync(id).ConfigureAwait(false);
        }

        public CarEnumsDto GetEnumValues()
        {
            CarEnumsDto carEnumsDto = new();
            carEnumsDto.CylinderNumbers = Enum.GetValues(typeof(CylinderNumber))
               .Cast<CylinderNumber>()
               .ToDictionary(t => (int)t, t => t.ToString());

            carEnumsDto.FuelTypes = Enum.GetValues(typeof(FuelType))
               .Cast<FuelType>()
               .ToDictionary(t => (int)t, t => t.ToString());

            carEnumsDto.TransmissionTypes = Enum.GetValues(typeof(TransmissionType))
               .Cast<TransmissionType>()
               .ToDictionary(t => (int)t, t => t.ToString());

            return carEnumsDto;
        }

        private async Task UpdateCarAsync(CarDto carDto, Car car)
        {
            Maker? maker = await _makerService.GetMakerByNameAsync(carDto.Maker).ConfigureAwait(false);

            if (maker != null)
            {
                car.Maker = maker;
            }
            else
            {
                car.Maker = await _makerService.CreateMakerAsync(carDto.Maker).ConfigureAwait(false);
            }

            car.Model = carDto.Model;
            car.CylinderNumber = carDto.CylinderNumber;
            car.TransmissionType = carDto.TransmissionType;
            car.Year = carDto.Year;
            car.Image = carDto.Image;
            car.UpdatedAt = DateTime.UtcNow;
        }
    }
}
