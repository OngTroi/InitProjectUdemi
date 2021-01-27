using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemi.DBConnection.Repository;

namespace Udemi.Services
{
    public class DatabaseService : DatabaseClient, IDatabaseService
    {
        public DatabaseService(string connectionString) : base(connectionString)
        {
        }
    }
}
