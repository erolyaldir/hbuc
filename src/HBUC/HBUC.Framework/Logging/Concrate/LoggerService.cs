using Microsoft.Extensions.Logging; 

namespace HBUC.Logging
{
    
    public class LoggerService<T> : IAppLogger<T> 
    {
        private readonly ILogger<T> _logger;
        public LoggerService(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<T>();
        }

        public void LogWarning(string message, params object[] args)
        {
            _logger.LogWarning(message, args);
        }

        public void LogInformation(string message, params object[] args)
        {
            _logger.LogInformation(message, args);
        }
    }
}
