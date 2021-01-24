using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using Udemi.DBConnection.Interfaces;

namespace Udemi.DBConnection.Repository
{
    public class DatabaseClient : IDatabaseClient
    {
        public string ConnectionString { get; set; }

        public SqlConnection DbConnection { get; set; }

        public SqlTransaction DbTransaction { get; set; }

        public DatabaseClient(string connectionString)
        {
            if (connectionString == null)
                throw new ArgumentNullException("connectionString");
            ConnectionString = connectionString;
            DbTransaction = null;
        }

        public DatabaseClient(SqlConnection connection)
        {
            if (connection == null)
                throw new ArgumentNullException("connection");
            DbConnection = connection;
            DbTransaction = null;
        }

        public DataSet ExecuteData(string query, CommandType commandType = CommandType.Text, params SqlParameter[] parameters)
        {
            var dtSet = new DataSet();
            if (DbConnection != null && !string.IsNullOrEmpty(DbConnection.ConnectionString) && DbConnection.State != ConnectionState.Closed)
            {
                using (SqlCommand command = DbConnection.CreateCommand())
                {
                    command.CommandTimeout = 60000;
                    command.Transaction = DbTransaction;
                    command.CommandText = query;
                    command.CommandType = commandType;
                    command.TryAddParameters(parameters);
                    var adapter = new SqlDataAdapter(command);
                    adapter.Fill(dtSet);
                    command.Parameters.Clear();
                    return dtSet;
                }
            }
            using (var conn = new SqlConnection(ConnectionString))
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                using (SqlCommand command = conn.CreateCommand())
                {
                    command.CommandTimeout = 60000;
                    command.CommandText = query;
                    command.CommandType = commandType;
                    command.TryAddParameters(parameters);
                    var adapter = new SqlDataAdapter(command);
                    adapter.Fill(dtSet);
                    command.Parameters.Clear();
                }
            }
            return dtSet;
        }

        public DataTable ExecuteDataTable(string query, CommandType commandType = CommandType.Text, params SqlParameter[] parameters)
        {
            var dtSet = new DataTable();
            if (DbConnection != null && !string.IsNullOrEmpty(DbConnection.ConnectionString) && DbConnection.State != ConnectionState.Closed)
            {
                using (SqlCommand command = DbConnection.CreateCommand())
                {
                    command.CommandTimeout = 60000;
                    command.CommandText = query;
                    command.Transaction = DbTransaction;
                    command.CommandType = commandType;
                    command.TryAddParameters(parameters);
                    var adapter = new SqlDataAdapter(command);
                    adapter.Fill(dtSet);
                    command.Parameters.Clear();
                    return dtSet;
                }
            }
            using (var conn = new SqlConnection(ConnectionString))
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                using (SqlCommand command = conn.CreateCommand())
                {
                    command.CommandTimeout = 60000;
                    command.CommandText = query;
                    command.CommandType = commandType;
                    command.TryAddParameters(parameters);
                    var adapter = new SqlDataAdapter(command);
                    adapter.Fill(dtSet);
                    command.Parameters.Clear();
                }
            }
            return dtSet;
        }

        public int ExecuteNonQuery(string query, CommandType commandType = CommandType.Text, params SqlParameter[] parameters)
        {
            if (DbConnection != null && !string.IsNullOrEmpty(DbConnection.ConnectionString) && DbConnection.State != ConnectionState.Closed)
            {
                using (var command = DbConnection.CreateCommand())
                {
                    command.CommandTimeout = 60000;
                    command.CommandText = query;
                    command.Transaction = DbTransaction;
                    command.CommandType = commandType;
                    command.TryAddParameters(parameters);
                    return command.ExecuteNonQuery();
                }
            }
            using (var conn = new SqlConnection(ConnectionString))
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                var command = conn.CreateCommand();
                command.CommandTimeout = 60000;
                command.CommandText = query;
                command.CommandType = commandType;
                command.TryAddParameters(parameters);
                return command.ExecuteNonQuery();
            }
        }

        public object ExecuteScalar(string query, CommandType commandType = CommandType.Text, params SqlParameter[] parameters)
        {
            if (DbConnection != null && !string.IsNullOrEmpty(DbConnection.ConnectionString) && DbConnection.State != ConnectionState.Closed)
            {
                using (var command = DbConnection.CreateCommand())
                {
                    command.CommandTimeout = 60000;
                    command.CommandText = query;
                    command.Transaction = DbTransaction;
                    command.CommandType = commandType;
                    command.TryAddParameters(parameters);
                    return command.ExecuteScalar();
                }
            }
            using (var conn = new SqlConnection(ConnectionString))
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                var command = conn.CreateCommand();
                command.CommandTimeout = 60000;
                command.CommandText = query;
                command.CommandType = commandType;
                command.TryAddParameters(parameters);
                return command.ExecuteScalar();
            }
        }

        public DbConnection OpenConnection()
        {
            DbConnection = DbConnection == null || string.IsNullOrEmpty(DbConnection.ConnectionString) ? new SqlConnection(ConnectionString) : DbConnection;
            if (DbConnection.State == ConnectionState.Closed)
            {
                DbConnection.Open();
            }
            return DbConnection;
        }

        public DbTransaction BeginTransaction(IsolationLevel level = IsolationLevel.ReadCommitted)
        {
            throw new NotImplementedException();
        }
    }
}
