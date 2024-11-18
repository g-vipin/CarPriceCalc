    
    namespace CarPriceApi.Controllers
    {
    public class CarPriceResponse
    {
        private decimal _baseCarPrice;
        public decimal BaseCarPrice { 
            get => _baseCarPrice;
            set
            {
                _baseCarPrice = Math.Round(value, 2);
            } 
            }
    }
    }
