using CarsConsulting.DAL.Models;
using CarsConsulting.Repositories;
using CarsConsulting.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq.Expressions;

namespace CarsConsulting.Tests.Services
{
    [TestClass]
    public class MakerServiceTest
    {
        private readonly Mock<IMakerRepository> _makerRepository;

        private readonly MakerService _makerService;

        public MakerServiceTest()
        {
            _makerRepository = new();
            _makerService = new(_makerRepository.Object);
        }

        [TestMethod]
        public async Task GetMakerByNameAsyncTest()
        {
            //Arranje
            string makerName = "Hyundai";
            Maker maker = new(makerName);

            _makerRepository.Setup(x => x.GetAsync(It.IsAny<Expression<Func<Maker, bool>>>())).ReturnsAsync(new List<Maker> { maker });

            //Act
            Maker? result = await _makerService.GetMakerByNameAsync(makerName);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(maker.Name, result.Name);
        }

        [TestMethod]
        public async Task CreateMakerAsyncTest()
        {
            //Arranje
            string makerName = "Hyundai";

            //Act
            Maker? result = await _makerService.CreateMakerAsync(makerName);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(makerName, result.Name);
        }
    }
}
