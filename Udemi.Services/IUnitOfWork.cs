using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemi.DBConnection.Interfaces;
using Udemi.Services.Interfaces;

namespace Udemi.Services
{
    public interface IUnitOfWork
    {
        #region Initial
        ITransaction BeginTransaction();
        void EndTransaction(ITransaction transaction);
        #endregion

        ICourses Courses { get; }

        IUser User { get; }
        IToken Token { get; }

    }
}
