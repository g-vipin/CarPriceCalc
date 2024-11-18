using CarPriceApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarPriceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarPriceController : ControllerBase
    {
        private readonly CarPriceFactory _carPriceFactory;

        public CarPriceController(CarPriceFactory carPriceFactory)
        {
            _carPriceFactory = carPriceFactory;
        }

        [HttpPost]
        public ActionResult<CarPriceResponse> CalculateBasePrice([FromBody] CarPriceRequest request)
        {
            try
            {
                if (Enum.IsDefined(typeof(CarType), request.CarType))
                {
                    var carPrice = _carPriceFactory.GetBasePrice(request.CarType);
                    var basePrice = carPrice.CalculateBasePrice(request.ExShowroomPrice);                    
                    return Ok(new CarPriceResponse{ BaseCarPrice = basePrice});
                }
                else
                {
                    return BadRequest("Invalid car type.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}