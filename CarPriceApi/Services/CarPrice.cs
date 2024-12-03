namespace CarPriceApi.Services
{
public abstract class CarPrice : ICarPrice
{

    private readonly ILogger _logger;
    private const int GST = 28;

    public CarPrice(ILogger logger)
    {
        _logger = logger;
    }

    public decimal CalculateBasePrice(decimal exShowroomPrice)
    {
        var basePrice = exShowroomPrice / (1 + (( GST + GetCess()) / 100m));
        _logger.Log($"Base Price Caluclated : {basePrice}");
        return basePrice;
    }

    protected abstract int GetCess();

}

public class CompactSuv : CarPrice
{

    private const int CESS = 1;

    public CompactSuv(ILogger logger) : base(logger)
    {
    }

    protected override int GetCess() => CESS;

}

public class Suv : CarPrice
{
    private const int GST = 28;
    private const int CESS = 22;

    public Suv(ILogger logger) : base(logger)
    {
    }
    
    protected override int GetCess() => 22;
}
}
