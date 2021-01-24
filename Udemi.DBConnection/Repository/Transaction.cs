using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Udemi.DBConnection.Interfaces;

namespace Udemi.DBConnection.Repository
{
    public class Transaction : ITransaction
    {
        private TransactionScope _transactionScope;

        public Transaction(IsolationLevel level = IsolationLevel.ReadCommitted, double timeout = 15)
        {
            try
            {
                var options = new TransactionOptions { IsolationLevel = level, Timeout = TimeSpan.FromMinutes(timeout) };
                _transactionScope = new TransactionScope(TransactionScopeOption.Required, options);
            }
            catch (Exception)
            {
                if (_transactionScope != null)
                {
                    _transactionScope.Complete();
                    _transactionScope.Dispose();
                    _transactionScope = null;
                }
            }
        }
        public void Commit()
        {
            _transactionScope.Complete();
            _transactionScope.Dispose();
        }

        public void Commplete()
        {
            _transactionScope.Complete();
        }

        public void CompleteDispose()
        {
            if (_transactionScope != null)
            {
                _transactionScope.Complete();
                _transactionScope.Dispose();
                _transactionScope = null;
            }
        }
        public void Rollback()
        {
            _transactionScope.Dispose();
        }

        public void Dispose()
        {
            if (_transactionScope != null)
            {
                _transactionScope.Dispose();
                _transactionScope = null;
            }
        }
    }
}
