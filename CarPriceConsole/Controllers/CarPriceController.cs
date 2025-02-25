using CarPriceApi.Controllers;
using CarPriceApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarPriceMvc.Controllers
{
    public class CarPriceController : Controller
    {
        private readonly CarPriceFactory _carPriceFactory;

        public CarPriceController(CarPriceFactory carPriceFactory)
        {
            _carPriceFactory = carPriceFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Calculate(CarPriceRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }

            if (!Enum.IsDefined(typeof(CarType), request.CarType))
            {
                ViewBag.Error = "Invalid car type.";
                return View("Index");
            }

            try
            {
                var carPriceObj = _carPriceFactory.GetPriceObject(request.CarType);
                var basePrice = carPriceObj.CalculateBasePrice(request.ExShowroomPrice);
                ViewBag.BasePrice = basePrice;
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Error: {ex.Message}";
            }

            return View("Index");
        }
    }
}
