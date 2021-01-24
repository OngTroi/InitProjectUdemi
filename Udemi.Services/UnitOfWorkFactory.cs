using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemi.Services
{
    public class UnitOfWorkFactory
    {
        public static IUnitOfWork GetUnitOfWork(string strConnection, string databaseSystemType)
        {
            return new UnitOfWork(strConnection);
        }
    }
}
