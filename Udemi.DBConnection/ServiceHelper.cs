using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemi.DBConnection
{
    public static class ServiceHelper
    {
        public static void TryAddParameters(this SqlCommand command, params SqlParameter[] parameters)
        {
            if (command == null)
                throw new ArgumentNullException("command");
            if (parameters == null || parameters.Length == 0) return;
            command.Parameters.AddRange(parameters);
        }
    }
}
