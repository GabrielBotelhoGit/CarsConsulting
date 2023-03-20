using AutoMapper;
using CarsConsulting.DAL.Models;
using CarsConsulting.DTOs;
using CarsConsulting.Enums;
using CarsConsulting.Repositories;
using CarsConsulting.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CarsConsulting.Tests.Services
{
    [TestClass]
    public class CarServiceTest : BaseTest
    {
        private readonly Mock<ICarRepository> _carRepositoryMock;
        private readonly Mock<IMakerService> _makerServiceMock;
        private readonly IMapper _mapper;

        private readonly CarService _service;

        public CarServiceTest()
        {
            _carRepositoryMock = new();
            _makerServiceMock = new();
            _mapper = GetMapper();

            _service = new(_carRepositoryMock.Object, _makerServiceMock.Object, _mapper);
        }

        [TestMethod]
        public async Task GetAllCarDtosAsyncTest()
        {
            //Arranje
            Guid carId = Guid.NewGuid();
            List<Car> cars = new()
            {
                new Car()
                {
                    Id = carId,
                    Model = "Ioniq",
                    CylinderNumber = CylinderNumber.Four,
                    DriveType = FuelType.gas,
                    Maker = new()
                    {
                        Name = "Hyundai"
                    },
                    TransmissionType = TransmissionType.Automatic,
                    Year = "2019",
                    Image = Array.Empty<byte>()
                }
            };

            _carRepositoryMock.Setup(x => x.GetAllWithMakerAsync()).ReturnsAsync(cars);

            //Act
            List<CarDto> result = await _service.GetAllCarDtosAsync();

            //Assert
            Assert.IsNotNull(result);
            
            Assert.AreEqual(cars.Count, result.Count);
            Assert.AreEqual(true, result.Any());
            Assert.AreEqual(cars.FirstOrDefault()!.Id, result.FirstOrDefault()!.Id);
        }

        [TestMethod]
        public async Task GetCarDtoAsyncTest()
        {
            //Arranje
            Guid carId = Guid.NewGuid();
            Car car = new()
            {
                Id = carId,
                Model = "Ioniq",
                CylinderNumber = CylinderNumber.Four,
                DriveType = FuelType.gas,
                Maker = new()
                {
                    Name = "Hyundai"
                },
                TransmissionType = TransmissionType.Automatic,
                Year = "2019",
                Image = Array.Empty<byte>()
            };

            _carRepositoryMock.Setup(x => x.GetByIdAsync(carId)).ReturnsAsync(car);

            //Act
            CarDto result = await _service.GetCarDtoAsync(carId);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(car.Id, result.Id);
        }

        [TestMethod]
        public async Task CreateCarAsyncTest()
        {
            //Arranje
            Guid carId = Guid.NewGuid();
            string makerName = "Hyundai";
            Maker maker = new(makerName);
            CarDto carDto = new()
            {
                Id = carId,
                Model = "Ioniq",
                CylinderNumber = CylinderNumber.Four,
                DriveType = FuelType.gas,
                Maker = makerName,
                TransmissionType = TransmissionType.Automatic,
                Year = "2019",
                Image = Array.Empty<byte>()
            };

            _makerServiceMock.Setup(x => x.GetMakerByNameAsync(makerName)).ReturnsAsync(maker);

            //Act
            await _service.CreateCarAsync(carDto);

            //Assert
            _carRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Car>()), Times.Once);
        }

        [TestMethod]
        public async Task UpdateCarAsyncTest()
        {
            //Arranje
            Guid carId = Guid.NewGuid();
            string makerName = "Hyundai";
            Maker maker = new(makerName);
            CarDto carDto = new()
            {
                Id = carId,
                Model = "Ioniq",
                CylinderNumber = CylinderNumber.Four,
                DriveType = FuelType.gas,
                Maker = makerName,
                TransmissionType = TransmissionType.Automatic,
                Year = "2019",
                Image = Array.Empty<byte>()
            };

            _makerServiceMock.Setup(x => x.GetMakerByNameAsync(carDto.Maker)).ReturnsAsync(maker);
            _carRepositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(new Car());

            //Act
            await _service.UpdateCarAsync(carDto, carId);

            //Assert
            _carRepositoryMock.Verify(x => x.UpdateAsync(It.IsAny<Car>()), Times.Once);
            _makerServiceMock.Verify(x => x.GetMakerByNameAsync(makerName), Times.Once);
        }

        [TestMethod]
        public async Task DeleteCarAsyncTest()
        {
            //Arranje
            Guid carId = Guid.NewGuid();
            
            //Act
            await _service.DeleteCarAsync(carId);

            //Assert
            _carRepositoryMock.Verify(x => x.DeleteAsync(It.IsAny<Guid>()), Times.Once);
        }
    }
}
