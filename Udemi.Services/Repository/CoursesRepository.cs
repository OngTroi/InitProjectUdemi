using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemi.Services.Interfaces;

namespace Udemi.Services.Repository
{
    public class CoursesRepository : BaseServices<DataSet>, ICourses
    {

        public CoursesRepository(IDatabaseService databaseService) : base(databaseService)
        {

        }

        public DataTable GetCourses()
        {
            try
            {
                string sql = @"Select *
                               From Courses";

                return ExecuteDataTable(sql,CommandType.Text);
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }
    }
}
