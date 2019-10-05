using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using log4net;

namespace Eisk.Core.Logger
{
    //wrapper for logger class
    public interface ILogger
    {
        void Info(string message);
        void Warn(string message);
        void Debug(string message);
        void Error(string message);
    }

    /// <summary>
    /// Responsible for global logging 
    /// </summary>
    public class Logger : ILogger
    {
        private ILog _logger;

        public Logger()
        {
            this._logger = LogManager.GetLogger(Assembly.GetCallingAssembly(), "logger");
        }
       
        public Logger(Type logClass)
        {
            this._logger = LogManager.GetLogger(logClass);
        }

        public void Debug(string message)
        {
            _logger.Debug(message);
        }

        public void Error(string message)
        {
            _logger.Error(message);
        }

        public void Info(string message)
        {
            _logger.Info(message);
        }

        public void Warn(string message)
        {
            _logger.Warn(message);
        }
    }
}

