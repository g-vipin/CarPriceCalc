public interface ILogger
{
    void Log(string logfilePath);
    string ReadLog();
}