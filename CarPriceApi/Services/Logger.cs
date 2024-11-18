namespace CarPriceApi.Services
{
public sealed class Logger : ILogger
{
    private readonly string _logfilePath;

    public Logger(string logfilePath)
    {
        _logfilePath = logfilePath;
    }

    public void Log(string message)
    {
        try
        {
            var logMessage = $"{DateTime.Now} : {message}\n";
            File.AppendAllText(_logfilePath, logMessage);
        }
        catch (Exception ex)
        {
            throw new Exception($"Log write failed: {ex.Message}");
        }
    }

    public string ReadLog()
    {
        try
        {
            if (File.Exists(_logfilePath))
            {
                return File.ReadAllText(_logfilePath);
            }
            else { return "Log file not found."; }
        }
        catch (Exception ex)
        {
            throw new Exception($"Log read failed: {ex.Message}");
        }
    }
}

}
