using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Http;
using Udemi.Api.Attributes;
using Udemi.Entities;
using Udemi.Entities.Common;
using Udemi.Entities.Common.Courses;

namespace Udemi.Api.Controllers.Courses
{
    [ValidateToken]
    public class CoursesController : BaseApiController
    {
        #region Category
        [HttpGet]
        public DataTable GetCategory()
        {
            return UnitOfWork.Courses.GetCategory();
        }

        [HttpPost]
        public HttpResult CreateCategory([FromBody] Category ctg )
        {
            try
            {
                return new HttpResult { };
            }
            catch (Exception ex)
            {
                return new HttpResult { };
            }
        }

        [HttpPost]
        public HttpResult UpdateCategory([FromBody] Category ctg)
        {
            try
            {
                return new HttpResult { };
            }
            catch (Exception ex)
            {
                return new HttpResult { };
            }
        }

        [HttpPost]
        public HttpResult DeleteCategory([FromBody] Category ctg)
        {
            try
            {
                return new HttpResult { };
            }
            catch (Exception ex)
            {
                return new HttpResult { };
            }
        }
        #endregion

        #region Courses
        [HttpGet]
        public DataTable GetCourses()
        {
            return UnitOfWork.Courses.GetCourses();
        }

        [HttpGet]
        public DataTable GetCoursesTopWatch()
        {
            return UnitOfWork.Courses.GetCoursesTopWatch();
        }

        [HttpGet]
        public DataTable GetCoursesByCategory(int id)
        {
            return UnitOfWork.Courses.GetCoursesByCategory(id);
        }

        [HttpGet]
        public DataTable GetCoursesDetails(int id)
        {
            return UnitOfWork.Courses.GetCoursesDetails(id);
        }

        [HttpGet]
        public DataTable GetCoursesByTitle(string title)
        {
            return UnitOfWork.Courses.GetCoursesByTitle(title);
        }

        [HttpPost]
        public HttpResult CreateCourses([FromBody] Courses_Info courses)
        {
            try
            {
                return new HttpResult { };
            }
            catch (Exception ex)
            {
                return new HttpResult { };
            }
        }

        [HttpPost]
        public HttpResult UpdateCourses([FromBody] Courses_Info courses)
        {
            try
            {
                return new HttpResult { };
            }
            catch (Exception ex)
            {
                return new HttpResult { };
            }
        }

        [HttpPost]
        public HttpResult DeleteCourses([FromBody] Courses_Info courses)
        {
            try
            {
                return new HttpResult { };
            }
            catch (Exception ex)
            {
                return new HttpResult { };
            }
        }

        [HttpPost]
        public HttpResult AddCoursesToWatchList([FromBody] Courses_Info courses)
        {
            try
            {
                return new HttpResult { };
            }
            catch (Exception ex)
            {
                return new HttpResult { };
            }
        }

        [HttpPost]
        public HttpResult RemoveCoursesToWatchList([FromBody] Courses_Info courses)
        {
            try
            {
                return new HttpResult { };
            }
            catch (Exception ex)
            {
                return new HttpResult { };
            }
        }

        [HttpPost]
        public HttpResult AddCoursesStudent([FromBody] Courses_Info courses)
        {
            try
            {
                return new HttpResult { };
            }
            catch (Exception ex)
            {
                return new HttpResult { };
            }
        }

        [HttpPost]
        public HttpResult RemoveCoursesStudent([FromBody] Courses_Info courses)
        {
            try
            {
                return new HttpResult { };
            }
            catch (Exception ex)
            {
                return new HttpResult { };
            }
        }
        #endregion
    }
}