using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemi.Entities;
using Udemi.Entities.Common.Account;
using Udemi.Entities.Function;
using Udemi.Services;
using System.Data;
using Udemi.Services.Interfaces;
using System.Data.SqlClient;

namespace Udemi.Services.Repository
{
    public class UserRepository : BaseServices<DataSet>, IUser
    {
        public UserRepository(IDatabaseService databaseService) : base(databaseService)
        {
        }

        public bool CheckInfoUser(User user)
        {
            string sql = @"Select A.UserEmail, A.UserPassword
                           From User_Info A
                           Where A.UserEmail = @Email  And A.UserPassword = @Password And A.IsActive = '1'";
            var sss = Hashing.GenerateHash(user.Password);
            var dt = ExecuteDataTable(sql, CommandType.Text, 
                    new SqlParameter("@Email", user.Email),
                    new SqlParameter("@Password",Hashing.GenerateHash(user.Password))
                );
            if (dt.Rows.Count == 0)
                return false;
            return true;
        }

        public User GetUserInfo(string email)
        {
            string sql = @"Select A.*
                           From User_Info A
                           Where A.UserEmail = @Email";
            var dt = ExecuteDataTable(sql, CommandType.Text, new SqlParameter("@Email", email));
            return new User
            {
                Email = dt.Rows[0]["UserEmail"].ToString(),
                FullName = dt.Rows[0]["FullName"].ToString(),
                DateOfBirth = (DateTime)dt.Rows[0]["DateOfBirth"],
                Gender = (int)dt.Rows[0]["Gender"],
                Phone = dt.Rows[0]["Phone"].ToString(),
                UserType = dt.Rows[0]["UserType"].ToString()
            };
        }

        public DataTable Register(User user)
        {
            string sql = @"Udemi_User_Register";
            var dt = ExecuteDataTable(sql, CommandType.StoredProcedure,
                new SqlParameter("@Email",user.Email),
                new SqlParameter("@Password", Hashing.GenerateHash(user.Password)),
                new SqlParameter("@FullName", user.FullName),
                new SqlParameter("@Gender", user.Gender),
                new SqlParameter("@DOB", user.DateOfBirth),
                new SqlParameter("@Phone", user.Phone)
                );
            return dt;
        }

        public HttpResult UpdateInfo(User user)
        {
            string sql = @"Udemi_User_UpdateUser";
            var dt = ExecuteDataTable(sql, CommandType.StoredProcedure,
                new SqlParameter("@Email", user.Email),
                new SqlParameter("@FullName", user.FullName),
                new SqlParameter("@Gender", user.Gender),
                new SqlParameter("@DOB", user.DateOfBirth),
                new SqlParameter("@Phone", user.Phone)
                );
            if (dt != null)
            {
                if (true)
                {
                    return new HttpResult
                    {
                        MessageCode = Entities.Enum.Enums.MessageCode.Error,
                        Message = "Fail"
                    };
                }
            }
            return new HttpResult
            {
                MessageCode = Entities.Enum.Enums.MessageCode.Success,
                Content = dt
            };
        }

        public OTP CreateOTP(string email)
        {
            string value = UseStatic().ToString();
            DateTime expired = DateTime.Now.AddMinutes(10);
            string sql = @"Udemi_User_CreateOTP";
            var dt = ExecuteDataTable(sql, CommandType.StoredProcedure,
                new SqlParameter("@Email", email),
                new SqlParameter("@Value", value),
                new SqlParameter("@ExpiredTime", expired)
                );
            return new OTP
            {
                Value = dt.Rows[0]["OTP"].ToString(),
                Email = dt.Rows[0]["Email"].ToString(),
                ExpiredTime = (DateTime)dt.Rows[0]["Expiredin"]
            };
        }


        public bool ValidateOTP(OTP otp)
        {
            string sql = @"Udemi_User_ValidateOTP";
            var dt = ExecuteDataTable(sql, CommandType.StoredProcedure, new SqlParameter("@OTP",otp.Value));
            if (!dt.Rows[0]["err_code"].ToString().Equals("0"))
            {
                return false;
            }
            return true;
        }

        public int UseStatic()
        {
            Random _random = new Random();
            // Part 2: use class-level Random.
            // ... When this method is called many times, it still has good Randoms.
            int result = _random.Next(1000000);
            // If this method declared a local Random, it would repeat itself.
            return result;
        }
    }
}
