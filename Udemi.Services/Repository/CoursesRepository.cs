using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemi.Entities.Common.Courses;
using Udemi.Services.Interfaces;

namespace Udemi.Services.Repository
{
    public class CoursesRepository : BaseServices<DataSet>, ICourses
    {

        public CoursesRepository(IDatabaseService databaseService) : base(databaseService)
        {

        }

        #region Category
        public DataTable GetCategory()
        {
            string sql = @"Select C.*
                           From Category C";
            var dt = ExecuteDataTable(sql, CommandType.Text);
            return dt;
        }

        public DataTable GetCategory(int id)
        {
            string sql = @"Select C.*
                           From Category C
                           Where C.Id = @Id";
            var dt = ExecuteDataTable(sql, CommandType.Text,
                new SqlParameter("@Id", id)
                );
            return dt;
        }

        public DataTable CreateCategory(Category ctg)
        {
            string sql = @"Udemi_Courses_CreateCategory";
            var dt = ExecuteDataTable(sql, CommandType.StoredProcedure,
                new SqlParameter("@Title", ctg.Name)
                );
            return dt;
        }

        public DataTable UpdateCategory(Category ctg)
        {
            string sql = @"Udemi_Courses_UpdateCatory";
            var dt = ExecuteDataTable(sql, CommandType.StoredProcedure,
                new SqlParameter("@Id", ctg.Id),
                new SqlParameter("@Name", ctg.Name)
                );
            return dt;
        }

        public DataTable DeleleCategory(Category ctg)
        {
            string sql = @"Udemi_Courses_DeleteCatory";
            var dt = ExecuteDataTable(sql, CommandType.StoredProcedure,
                new SqlParameter("@Id", ctg.Id),
                new SqlParameter("@Name", ctg.Name)
                );
            return dt;
        }
        #endregion

        #region Courses
        public DataTable GetCourses()
        {
            string sql = @" Select C.*
                            From Courses C And ";
            var dt = ExecuteDataTable(sql, CommandType.Text);
            return dt;
        }

        public DataTable GetCoursesByCategory(int id)
        {
            string sql = @" Select C.*
                            From Courses C
                            Where C.CategoryId = @Id";
            var dt = ExecuteDataTable(sql, CommandType.Text,
                new SqlParameter("@Id", id)
                );
            return dt;
        }

        public DataTable GetCoursesByTitle(string title)
        {
            string sql = @" Select C.*
                            From Courses C
                            Where C.Title = @Title";
            var dt = ExecuteDataTable(sql, CommandType.Text,
                new SqlParameter("@Title", title)
                );
            return dt;
        }

        public DataTable GetCoursesDetails(int id)
        {
            string sql = @" Select C.*
                            From Courses C
                            Where C.ID = @Id";
            var dt = ExecuteDataTable(sql, CommandType.Text,
                new SqlParameter("@Id", id)
                );
            return dt;
        }

        public DataTable GetCoursesTopWatch()
        {
            string sql = @" Select C.*
                            From Courses C";
            var dt = ExecuteDataTable(sql, CommandType.Text);
            return dt;
        }

        public DataTable CreateCourses(Courses_Info courses)
        {
            string sql = @"Udemi_Courses_CreateCourses";
            var dt = ExecuteDataTable(sql, CommandType.StoredProcedure,
                new SqlParameter("@Title", courses.Title),
                new SqlParameter("@DescriptionShort", courses.DescriptionShort),
                new SqlParameter("@DescriptionLong", courses.DescriptionLong),
                new SqlParameter("@Thumbnail", courses.Thumbnail),
                new SqlParameter("@Outline", courses.Outline),
                new SqlParameter("@Teacher", courses.Teacher),
                new SqlParameter("@CategoryId", courses.CategoryId)
                );
            return dt;
        }

        public DataTable UpdateCourses(Courses_Info courses)
        {
            string sql = @"Udemi_Courses_UpdateCourses";
            var dt = ExecuteDataTable(sql, CommandType.StoredProcedure,
                new SqlParameter("@Id", courses.Id),
                new SqlParameter("@Title", courses.Title),
                new SqlParameter("@DescriptionShort", courses.DescriptionShort),
                new SqlParameter("@DescriptionLong", courses.DescriptionLong),
                new SqlParameter("@Thumbnail", courses.Thumbnail),
                new SqlParameter("@Outline", courses.Outline),
                new SqlParameter("@Teacher", courses.Teacher),
                new SqlParameter("@CategoryId", courses.CategoryId)
                );
            return dt;
        }

        public DataTable DeleteCourses(Courses_Info courses)
        {
            string sql = @"Udemi_Courses_DeleteCourses";
            var dt = ExecuteDataTable(sql, CommandType.StoredProcedure,
                new SqlParameter("@Id", courses.Id)
                );
            return dt;
        }

        public bool AddCoursesToWatchList(int coursesid, string email)
        {
            string sql = @"Udemi_Courses_AddCoursesToWatchList";
            var dt = ExecuteDataTable(sql, CommandType.StoredProcedure,
                new SqlParameter("@CoursesId", coursesid),
                new SqlParameter("@Email", email)
                );
            if ((int)dt.Rows[0]["err_code"] != 0)
            {
                return false;
            }
            return true;
        }

        public bool RemoveCoursesToWatchList(int coursesid, string email)
        {
            string sql = @"Udemi_Courses_RemoveCoursesToWatchList";
            var dt = ExecuteDataTable(sql, CommandType.StoredProcedure,
                new SqlParameter("@CoursesId", coursesid),
                new SqlParameter("@Email", email)
                );
            if ((int)dt.Rows[0]["err_code"] != 0)
            {
                return false;
            }
            return true;
        }

        public bool AddCoursesStudent(int coursesid, string email)
        {
            string sql = @"Udemi_Courses_AddCoursesStudent";
            var dt = ExecuteDataTable(sql, CommandType.StoredProcedure,
                new SqlParameter("@CoursesId", coursesid),
                new SqlParameter("@Email", email)
                );
            if ((int)dt.Rows[0]["err_code"] != 0)
            {
                return false;
            }
            return true;
        }

        public bool RemoveCoursesStudent(int coursesid, string email)
        {
            string sql = @"Udemi_Courses_RemoveCoursesStudent";
            var dt = ExecuteDataTable(sql, CommandType.StoredProcedure,
                new SqlParameter("@CoursesId", coursesid),
                new SqlParameter("@Email", email)
                );
            if ((int)dt.Rows[0]["err_code"] != 0)
            {
                return false;
            }
            return true;
        }
        #endregion
    }
}
