using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Udemi.Api.Controllers.Courses
{
    public class CoursesController : BaseApiController
    {
        [HttpGet]
        public DataTable GetCourses()
        {
            return UnitOfWork.Courses.GetCourses();
        }
    }
}