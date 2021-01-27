using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemi.DBConnection;

namespace Udemi.Services
{
    public class BaseServices<TEntity> : BaseServiceClient where TEntity : class
    {
        public IDatabaseService DatabaseService { get; set; }

        public BaseServices(IDatabaseService databaseService) : base(databaseService)
        {
            if (databaseService == null)
                throw new ArgumentNullException("databaseService");
            DatabaseService = databaseService;
        }
    }
}
