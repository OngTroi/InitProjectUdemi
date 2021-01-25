using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemi.DBConnection.Interfaces;
using Udemi.DBConnection.Repository;

namespace Udemi.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Initalize
        private string _connectionString;

        private bool _disposed;

        public UnitOfWork(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ITransaction BeginTransaction()
        {
            return new Transaction();
        }

        public void EndTransaction(ITransaction transaction)
        {
            if (transaction != null)
            {
                transaction.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // new DatabaseServiceSql(_connectionString).TryDispose();
                }
            }
            _disposed = true;
        }
        #endregion

    }
}
