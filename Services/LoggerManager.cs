using web_api_example.Contracts;
using NLog;
namespace web_api_example.Services
{
    public class LoggerManager : ILoggerManager
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        public LoggerManager(){}
        public void LogDebug(string message)
        {
            logger.Debug(message);
        }

        public void LogError(string message)
        {
            logger.Error(message);
        }

        public void LogInfo(string message)
        {
            logger.Info(message);
        }

        public void LogWarn(string message)
        {
            logger.Warn(message);
        }
    }
}