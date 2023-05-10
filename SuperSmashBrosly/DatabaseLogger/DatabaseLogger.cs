using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DatabaseLogger
{
    public class DatabaseLogger
    {
        string _sqlConnString;

        ErrorLogger errorLogger;
        InfoLogger infoLogger;

        public DatabaseLogger()
        {
            PrepareConnection();
            errorLogger = new ErrorLogger();
            infoLogger = new InfoLogger();

            errorLogger.sqlConnectionString = _sqlConnString;
            infoLogger.sqlConnectionString = _sqlConnString;

            errorLogger.SetNextLogger(infoLogger);
        }

        public void LogMessage(LogMessage message)
        {
            errorLogger.LogTheMessage(message); 
        }

        private void PrepareConnection()
        {
            SqlConnectionStringBuilder connBldr = new SqlConnectionStringBuilder();
            connBldr.DataSource = $"(localdb)\\MSSQLLocalDB";
            connBldr.IntegratedSecurity = true;
            connBldr.InitialCatalog = $"PROG455FA23";
            _sqlConnString = connBldr.ConnectionString;
        }
    }
}
