using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemi.DBConnection.Interfaces
{
    public interface IDatabaseClient
    {
        string ConnectionString { get; set; }

        int ExecuteNonQuery(string query, CommandType commandType = CommandType.Text, params SqlParameter[] parameters);

        object ExecuteScalar(string query, CommandType commandType = CommandType.Text, params SqlParameter[] parameters);

        DataSet ExecuteData(string query, CommandType commandType = CommandType.Text, params SqlParameter[] parameters);

        DataTable ExecuteDataTable(string query, CommandType commandType = CommandType.Text, params SqlParameter[] parameters);

        DbConnection OpenConnection();
        DbTransaction BeginTransaction(IsolationLevel level = IsolationLevel.ReadCommitted);
    }
}
