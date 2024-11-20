using CarPriceApi.Controllers;
using CarPriceApi.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CarPriceApi.Tests
{
    public class CarPriceControllerTests
    {
        private readonly Mock<CarPriceFactory> _mockCarPriceFactory;
        private readonly CarPriceController _controller;

        public CarPriceControllerTests()
        {
            _mockCarPriceFactory = new Mock<CarPriceFactory>(new Mock<ILogger>().Object);
            _controller = new CarPriceController(_mockCarPriceFactory.Object);
        }

        [Fact]
        public void CalculateBasePrice_ReturnsOkResult_WithCalculatedPrice()
        {
            // Arrange
            var request = new CarPriceRequest
            {
                CarType = CarType.Suv,
                ExShowroomPrice = 1420000
            };

            var response = new CarPriceResponse
            {
                BaseCarPrice = 1200000
            };
            
            var mockCarPrice = new Mock<ICarPrice>();
            mockCarPrice.Setup(cp => cp.CalculateBasePrice(It.IsAny<decimal>())).Returns(1200000);
            _mockCarPriceFactory.Setup(x => x.GetPriceObject(It.IsAny<CarType>())).Returns(mockCarPrice.Object);
            
            // Act
            var result = _controller.CalculateBasePrice(request);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void CalculateBasePrice_InvalidCarType_ReturnsBadRequest()
        {
            // Arrange
            var request = new CarPriceRequest
            {
                CarType = (CarType)999, // Invalid CarType
                ExShowroomPrice = 1420000
            };

            // Act
            var result = _controller.CalculateBasePrice(request);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }
    }
}
