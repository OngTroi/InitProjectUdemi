using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemi.Entities.Common.Courses;

namespace Udemi.Services.Interfaces
{
    public interface ICourses
    {
        #region Category
        /// <summary>
        /// Lấy danh sách lĩnh vực
        /// </summary>
        /// <returns></returns>
        DataTable GetCategory();

        /// <summary>
        /// Lấy thông tin lĩnh vực
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        DataTable GetCategory(int id);

        /// <summary>
        /// Tạo mới Category
        /// </summary>
        /// <param name="ctg"></param>
        /// <returns></returns>
        DataTable CreateCategory(Category ctg);
        /// <summary>
        /// Cập nhật Category
        /// </summary>
        /// <param name="ctg"></param>
        /// <returns></returns>
        DataTable UpdateCategory(Category ctg);
        /// <summary>
        /// Xóa Category
        /// </summary>
        /// <param name="ctg"></param>
        /// <returns></returns>
        DataTable DeleleCategory(Category ctg);
        #endregion

        #region Courses
        /// <summary>
        /// Lấy danh sách khóa học
        /// </summary>
        /// <returns></returns>
        DataTable GetCourses();

        /// <summary>
        /// Lấy danh sách khóa học được xem nhiều
        /// </summary>
        /// <returns></returns>
        DataTable GetCoursesTopWatch();

        /// <summary>
        /// Lấy danh sách khóa học theo lĩnh vực
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        DataTable GetCoursesByCategory(int id);

        /// <summary>
        /// Lấy khóa học theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        DataTable GetCoursesDetails(int id);

        /// <summary>
        /// Lấy khóa học theo title
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        DataTable GetCoursesByTitle(string title);

        /// <summary>
        /// Tạo mới khóa học
        /// </summary>
        /// <param name="courses"></param>
        /// <returns></returns>
        DataTable CreateCourses(Courses_Info courses);

        /// <summary>
        /// Cập nhật khóa học
        /// </summary>
        /// <param name="courses"></param>
        /// <returns></returns>
        DataTable UpdateCourses(Courses_Info courses);

        /// <summary>
        /// Xóa khóa học
        /// </summary>
        /// <param name="courses"></param>
        /// <returns></returns>
        DataTable DeleteCourses(Courses_Info courses);

        /// <summary>
        /// Thêm học viên vào danh sách xem
        /// </summary>
        /// <param name="coursesid"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        bool AddCoursesToWatchList(int coursesid,string email);
        
        /// <summary>
        /// Gỡ học viên vào danh sách xem
        /// </summary>
        /// <param name="coursesid"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        bool RemoveCoursesToWatchList(int coursesid, string email);

        /// <summary>
        /// Thêm học viên vào danh sách đăng ký
        /// </summary>
        /// <param name="coursesid"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        bool AddCoursesStudent(int coursesid, string email);

        /// <summary>
        /// Gỡ học viên vào danh sách đăng ký
        /// </summary>
        /// <param name="coursesid"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        bool RemoveCoursesStudent(int coursesid, string email);
        #endregion
    }
}
