using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace MealManagement.Common
{
    public static class MyLogger
    {
        private static readonly NLog.Logger _logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
        public static void LogInfo(string message)
        {
            _logger.Info(message);
        }

        public static void LogError(string message)
        {
            _logger.Error(message);
        }

        public static void LogException(Exception ex, string message = "")
        {
            if (message == string.Empty)
            {
                _logger.Error(ex);
            }
            else
            {
                _logger.Error(ex, message);
            }
        }
    }
}
