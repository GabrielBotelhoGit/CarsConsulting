using CarsConsulting.DAL;
using CarsConsulting.DAL.Models;
using CarsConsulting.Enums;
using CarsConsulting.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarsConsulting.Tests.Repositories
{
    [TestClass]
    public class CarRepositoriesTest
    {
        private readonly Guid _carId = Guid.NewGuid();

        private readonly CarRepository _carRepository;

        public CarRepositoriesTest()
        {
            _carRepository = new(GetInMemoryDbContext());
        }

        [TestMethod]
        public async Task GetAllWithMakerAsyncTest()
        {
            //Arranje

            //Act
            List<Car> cars = await _carRepository.GetAllWithMakerAsync();

            //Assert
            Assert.IsNotNull(cars);
            Assert.AreEqual(1, cars.Count);
        }

        private MainDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<MainDbContext>()
                .UseInMemoryDatabase(nameof(CarRepositoriesTest) + Guid.NewGuid()).Options;

            MainDbContext mainDbContext = new(options);

            Maker maker = new("Hyundai");

            Car car = new()
            {
                Id = _carId,
                Model = "Ioniq",
                CylinderNumber = CylinderNumber.Four,
                DriveType = FuelType.gas,
                Maker = maker,
                TransmissionType = TransmissionType.Automatic,
                Year = "2019",
                Image = Array.Empty<byte>()
            };

            mainDbContext.AddAsync(car);
            mainDbContext.SaveChanges();

            return new MainDbContext(options);
        }
    }
}
