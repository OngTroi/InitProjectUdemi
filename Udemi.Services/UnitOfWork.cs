using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemi.DBConnection.Interfaces;
using Udemi.DBConnection.Repository;
using Udemi.Services;
using Udemi.Services.Interfaces;
using Udemi.Services.Repository;

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

        public ICourses Courses
        {
            get { return new CoursesRepository(new DatabaseService(_connectionString)); }
        }

        #region Account
        public IUser User
        {
            get { return new UserRepository(new DatabaseService(_connectionString)); }
        }

        public IToken Token
        {
            get { return new TokenRepository(new DatabaseService(_connectionString)); }
        }
        #endregion
    }
}
