using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemi.DBConnection.Interfaces;

namespace Udemi.DBConnection
{
    public class BaseServiceClient
    {
        protected IDatabaseClient DatabaseServiceClient { get; set; }

        public BaseServiceClient(IDatabaseClient databaseServiceClient)
        {
            if (databaseServiceClient == null)
                throw new ArgumentNullException("databaseServiceClient");
            DatabaseServiceClient = databaseServiceClient;
        }

        public int ExecuteNonQuery(string query, CommandType commandType = CommandType.Text, params SqlParameter[] parameters)
        {
            return DatabaseServiceClient.ExecuteNonQuery(query, commandType, parameters);
        }

        public object ExecuteScalar(string query, CommandType commandType = CommandType.Text, params SqlParameter[] parameters)
        {
            return DatabaseServiceClient.ExecuteScalar(query, commandType, parameters);
        }

        public DataSet ExecuteData(string query, CommandType commandType = CommandType.Text, params SqlParameter[] parameters)
        {
            return DatabaseServiceClient.ExecuteData(query, commandType, parameters);
        }

        public DataTable ExecuteDataTable(string query, CommandType commandType = CommandType.Text, params SqlParameter[] parameters)
        {
            return DatabaseServiceClient.ExecuteDataTable(query, commandType, parameters);
        }
    }
}
