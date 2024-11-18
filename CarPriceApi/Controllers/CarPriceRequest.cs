using CarPriceApi.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CarPriceApi.Controllers
{
public class CarPriceRequest
    {
        [JsonProperty("car_type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CarType CarType { get; set; }
        
        [JsonProperty("exshowroom_price")]
        public decimal ExShowroomPrice { get; set; }
    }
}