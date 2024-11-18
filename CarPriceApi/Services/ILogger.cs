namespace  CarPriceApi.Services
{
public interface ILogger
{
    void Log(string logfilePath);
    string ReadLog();
}
}
