using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CarPriceApi.Services;

namespace CarPriceApi.Controllers
{
public class CarPriceRequest
{
    [JsonPropertyName("car_type")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    [Required]
    [Description("The type of car (e.g., Sedan, SUV).")]
    public CarType CarType { get; set; }
    
    [JsonPropertyName("exshowroom_price")]
    [Required]
    [Range(1, double.MaxValue, ErrorMessage = "Ex-showroom price must be greater than 0.")]
    public decimal ExShowroomPrice { get; set; }
}
}