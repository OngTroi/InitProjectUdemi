using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemi.DBConnection.Interfaces;

namespace Udemi.Services
{
    public interface IUnitOfWork
    {
        ITransaction BeginTransaction();
        void EndTransaction(ITransaction transaction);
    }
}
