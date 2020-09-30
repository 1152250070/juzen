using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Mammothcode.Service
{
    public class ServiceLogger
    {
        private ILogger _logger = null;
        public ServiceLogger(string name)
        {
            _logger = LogManager.GetLogger(name);
        }
        public void Debug(string message)
        {
            _logger.Debug(message);
        }
        public void Error(Exception exception)
        {
            _logger.Error(exception);
        }
        public void Error(string message)
        {
            _logger.Error(message);
        }
        public void Info(string message)
        {
            _logger.Info(message);
        }
        public void Fatal(string message)
        {
            _logger.Fatal(message);
        }
    }
}
