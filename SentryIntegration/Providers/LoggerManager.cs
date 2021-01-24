using System.IO;
using System.Reflection;
using System.Xml;
using log4net;
using log4net.Config;
using SentryIntegration.Interfaces;

namespace SentryIntegration.Providers 
{
    public class LoggerManager : ILoggerManager
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(LoggerManager));
        public LoggerManager()
        {
            try
            {
                XmlDocument log4netConfig = new XmlDocument();
                using (var fs = File.OpenRead("log4net.config"))
                {
                    log4netConfig.Load(fs);

                    var repo = LogManager.CreateRepository(
                        Assembly.GetEntryAssembly(), 
                        typeof(log4net.Repository.Hierarchy.Hierarchy));

                    XmlConfigurator.Configure(repo, log4netConfig["log4net"]);
                    _logger.Info("Log System Initialized");
                }
            }
            catch (System.Exception ex)
            {
                
                _logger.Error("Error", ex);
            }
            
        }
        public void LogInformation(string message)
        {
            _logger.Info(message);
        }

        public void LogDebug(string message)
        {
            _logger.Debug(message);
                        
        }

        public void LogWarn(string message)
        {
            _logger.Warn(message);
            
        }

        public void LogError(string message)
        {
            _logger.Error(message);
            
        }

        public void LogFatal(string message)
        {
            _logger.Fatal(message);
        }
    }
}