using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLogger
{
    public interface ILogger
    {
        ILogger nextLogger { get; set; }
        string sqlConnectionString { get; set; }

        void Log(LogMessage messmessageToLog);
        void LogTheMessage(LogMessage messageToLog);
        void PassToNextLogger(LogMessage messageToLog);
        void SetNextLogger(ILogger _nextLogger);
    }
}
