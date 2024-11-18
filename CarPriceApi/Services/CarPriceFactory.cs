namespace CarPriceApi.Services
{
public class CarPriceFactory
{
    private readonly ILogger _logger;

    private  readonly Dictionary<CarType, Func<ILogger,ICarPrice>> _carPriceMap;

    public CarPriceFactory(ILogger logger)
    {
        _logger = logger;
        _carPriceMap = new Dictionary<CarType, Func<ILogger, ICarPrice>> {
            { CarType.CompactSuv , (logger) => new CompactSuv(logger)},
            {CarType.Suv , (logger) => new Suv(logger) },      
        };

    }
    public ICarPrice GetBasePrice(CarType carType)
    {
        if(_carPriceMap.ContainsKey(carType))
        {
            return _carPriceMap[carType](_logger);
        }
        else
        {
            throw new ArgumentException("Invalid Car type");
        }
    }

}
}
