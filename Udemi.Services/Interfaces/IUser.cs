using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemi.Entities;
using Udemi.Entities.Common.Account;

namespace Udemi.Services.Interfaces
{
    public interface IUser
    {
        /// <summary>
        /// Kiểm tra thông tin user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        bool CheckInfoUser(User user);

        /// <summary>
        /// Lấy thông tin user
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        User GetUserInfo(string email);

        /// <summary>
        /// Đăng ký
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        DataTable Register(User user);

        /// <summary>
        /// Cập nhật thông tin
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        HttpResult UpdateInfo(User user);

        /// <summary>
        /// Tạo mã OTP
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        OTP CreateOTP(string email);

        /// <summary>
        /// Validate OTP
        /// </summary>
        /// <param name="otp"></param>
        /// <returns></returns>
        bool ValidateOTP(OTP otp);
    }
}
