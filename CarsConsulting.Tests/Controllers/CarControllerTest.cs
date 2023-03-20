using CarsConsulting.Controllers;
using CarsConsulting.DTOs;
using CarsConsulting.Enums;
using CarsConsulting.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CarsConsulting.Tests.Controllers
{
    [TestClass]
    public class CarControllerTest : BaseTest
    {
        private readonly Mock<ICarService> _carServiceMock;
        private readonly CarController _carController;

        public CarControllerTest()
        {
            _carServiceMock = new();
            _carController = new(_carServiceMock.Object);
        }

        [TestMethod]
        public async Task GetAllAsyncTest()
        {
            //Arranje
            Guid carId = Guid.NewGuid();
            List<CarDto> carDtos = new()
            {
                new CarDto()
                {
                    Id = carId,
                    Model = "Ioniq",
                    CylinderNumber = CylinderNumber.Four,
                    DriveType = FuelType.gas,
                    Maker = "Hyundai",
                    TransmissionType = TransmissionType.Automatic,
                    Year = "2019",
                    Image = Array.Empty<byte>()
                }
            };

            _carServiceMock.Setup(x => x.GetAllCarDtosAsync()).ReturnsAsync(carDtos);

            //Act
            var actionResult = await _carController.GetAllAsync() as OkObjectResult;

            //Assert
            Assert.IsNotNull(actionResult);
            List<CarDto>? responseCars = actionResult.Value as List<CarDto>;
            Assert.IsNotNull(responseCars);
            Assert.AreEqual(carDtos.Count, responseCars.Count);
            Assert.AreEqual(true, responseCars.Any());
            Assert.AreEqual(carDtos.FirstOrDefault()!.Id, responseCars.FirstOrDefault()!.Id);
        }

        [TestMethod]
        public async Task GetByIdAsyncTest()
        {
            //Arranje
            Guid carId = Guid.NewGuid();
            CarDto carDto = new()
            {
                Id = carId,
                Model = "Ioniq",
                CylinderNumber = CylinderNumber.Four,
                DriveType = FuelType.gas,
                Maker = "Hyundai",
                TransmissionType = TransmissionType.Automatic,
                Year = "2019",
                Image = Array.Empty<byte>()
            };

            _carServiceMock.Setup(x => x.GetCarDtoAsync(carId)).ReturnsAsync(carDto);

            //Act
            var actionResult = await _carController.GetByIdAsync(carId) as OkObjectResult;

            //Assert
            Assert.IsNotNull(actionResult);
            CarDto? responseCar = actionResult.Value as CarDto;
            Assert.IsNotNull(responseCar);
            Assert.AreEqual(carDto.Id, responseCar.Id);
        }

        [TestMethod]
        public async Task CreateAsyncTest()
        {
            //Arranje
            Guid carId = Guid.NewGuid();
            CarDto carDto = new()
            {
                Id = carId,
                Model = "Ioniq",
                CylinderNumber = CylinderNumber.Four,
                DriveType = FuelType.gas,
                Maker = "Hyundai",
                TransmissionType = TransmissionType.Automatic,
                Year = "2019",
                Image = Array.Empty<byte>()
            };

            _carServiceMock.Setup(x => x.CreateCarAsync(carDto));

            //Act
            var actionResult = await _carController.CreateAsync(carDto) as OkObjectResult;

            //Assert
            Assert.IsNotNull(actionResult);
            _carServiceMock.Verify(x => x.CreateCarAsync(carDto), Times.Once);
        }

        [TestMethod]
        public async Task UpdateAsyncTest()
        {
            //Arranje
            Guid carId = Guid.NewGuid();
            CarDto carDto = new()
            {
                Id = carId,
                Model = "Ioniq",
                CylinderNumber = CylinderNumber.Four,
                DriveType = FuelType.gas,
                Maker = "Hyundai",
                TransmissionType = TransmissionType.Automatic,
                Year = "2019",
                Image = Array.Empty<byte>()
            };

            _carServiceMock.Setup(x => x.UpdateCarAsync(carDto, carId));

            //Act
            var actionResult = await _carController.UpdateAsync(carDto, carId) as OkObjectResult;

            //Assert
            Assert.IsNotNull(actionResult);
            _carServiceMock.Verify(x => x.UpdateCarAsync(carDto, carId), Times.Once);
        }

        [TestMethod]
        public async Task DeleteAsyncTest()
        {
            //Arranje
            Guid carId = Guid.NewGuid();
            
            _carServiceMock.Setup(x => x.DeleteCarAsync(carId));

            //Act
            var actionResult = await _carController.DeleteAsync(carId) as OkObjectResult;

            //Assert
            Assert.IsNotNull(actionResult);
            _carServiceMock.Verify(x => x.DeleteCarAsync(carId), Times.Once);
        }
    }
}