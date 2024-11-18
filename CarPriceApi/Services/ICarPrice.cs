namespace CarPriceApi.Services
{
public interface ICarPrice
{
    decimal CalculateBasePrice(decimal exShowroomPrice);
}
}