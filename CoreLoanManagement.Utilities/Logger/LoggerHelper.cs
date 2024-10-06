using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LoanManagement.Platform.Logger
{
    public static class LoggerHelper
    {
        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        public static NLog.Logger GetLogger()
        {
            return _logger;
        }
    }
}
