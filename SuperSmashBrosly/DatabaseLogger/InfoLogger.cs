using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DatabaseLogger
{
    public class InfoLogger : ILogger
    {
        public ILogger nextLogger { get; set; }
        public string sqlConnectionString { get; set; }

        public void LogTheMessage(LogMessage messageToLog)
        {
            if (messageToLog.LogType == "Info")
            {
                Log(messageToLog);
            }
            else
            {
                PassToNextLogger(messageToLog);
            }
        }

        public void Log(LogMessage messageToLog)
        {
            string query = $"Insert into dbo.SmashBrosLog (LogLevel,LogMessage)" +
                $"VALUES( '{messageToLog.LogType}','{messageToLog.Message}')";

            using (SqlConnection conn = new SqlConnection(sqlConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                conn.Open();

                sqlCommand.ExecuteNonQuery();

                conn.Close();
            }
        }

        public void PassToNextLogger(LogMessage messageToLog)
        {
            nextLogger.LogTheMessage(messageToLog);
        }

        public void SetNextLogger(ILogger _nextLogger)
        {
            nextLogger = _nextLogger;
        }
    }
}
