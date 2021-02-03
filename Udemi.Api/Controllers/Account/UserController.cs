using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Http;
using Udemi.Entities;
using Udemi.Entities.Common.Account;
using Udemi.Api.Attributes;
using System.Net.Mail;

namespace Udemi.Api.Controllers.Account
{
    public class UserController : BaseApiController
    {
        [HttpPost]
        public HttpResult Login([FromBody] User user)
        {
            try
            {
                //Kiểm tra thông tin đầu vào
                if (string.IsNullOrWhiteSpace(user.Email))
                    return new HttpResult { MessageCode = Entities.Enum.Enums.MessageCode.Error, Message = "Email is null" };
                if (string.IsNullOrWhiteSpace(user.Password))
                    return new HttpResult { MessageCode = Entities.Enum.Enums.MessageCode.Error, Message = "Password is null" };
                //Kiểm tra User
                var checkuser = UnitOfWork.User.CheckInfoUser(user);
                if (!checkuser)
                    return new HttpResult { MessageCode = Entities.Enum.Enums.MessageCode.Error, Message = "User does not exists." };
                //Kiểm tra token còn hạn hay không
                var getToken = UnitOfWork.Token.GetTokenByUser(user.Email);
                if (getToken.Rows.Count != 0)
                {
                    return new HttpResult
                    {
                        MessageCode = Entities.Enum.Enums.MessageCode.Success,
                        Content = new Token
                        {
                            Email = user.Email,
                            TokenId = getToken.Rows[0]["TokenId"].ToString(),
                            expiredin = (DateTime)(getToken.Rows[0]["ExpiredTime"])
                        }
                    };
                }
                //Tạo mới token
                DateTime expiredDate = DateTime.Now.AddDays(3);
                string tokenvalue = JWTManagement.GenerateToken(user.Email, expiredDate);
                Token token = new Token
                {
                    Email = user.Email,
                    TokenId = tokenvalue,
                    expiredin = expiredDate
                };
                //Lưu Token vào DB
                var SaveToken = UnitOfWork.Token.SaveToken(token);
                //Trả kết quả
                return new HttpResult
                {
                    MessageCode = Entities.Enum.Enums.MessageCode.Success,
                    Content = token
                };
            }
            catch (Exception ex)
            {
                return new HttpResult
                {
                    MessageCode = Entities.Enum.Enums.MessageCode.Exception,
                    Message = ex.Message
                };
            }
        }

        [HttpPost]
        public HttpResult Register([FromBody] User user)
        {
            try
            {
                //Kiểm tra thông tin đầu vào
                if (string.IsNullOrWhiteSpace(user.Email))
                    return new HttpResult { MessageCode = Entities.Enum.Enums.MessageCode.Error, Message = "Email is null" };
                if (string.IsNullOrWhiteSpace(user.Password))
                    return new HttpResult { MessageCode = Entities.Enum.Enums.MessageCode.Error, Message = "Password is null" };
                if (string.IsNullOrWhiteSpace(user.Phone))
                    return new HttpResult { MessageCode = Entities.Enum.Enums.MessageCode.Error, Message = "Phone is null" };
                
                //Đăng kí user
                var RegisterUser = UnitOfWork.User.Register(user);
                if ((int)RegisterUser.Rows[0]["err_code"] != 0)
                    return new HttpResult { MessageCode = Entities.Enum.Enums.MessageCode.Error, Message = RegisterUser.Rows[0]["err_msg"].ToString() };
                //Tạo mã OTP
                var otp = UnitOfWork.User.CreateOTP(user.Email);
                SendEmailOTP(user.Email, otp);
                return new HttpResult 
                {
                    MessageCode = Entities.Enum.Enums.MessageCode.Success,
                    Message = "OTP Send.",
                    Content = new 
                    {
                        Email =  user.Email,
                        FullName = user.FullName,
                        Gender = user.Gender,
                        DOB = user.DateOfBirth,
                        Phone = user.Phone
                    }
                };
            }
            catch (Exception ex)
            {
                return new HttpResult
                {
                    MessageCode = Entities.Enum.Enums.MessageCode.Exception,
                    Message = ex.Message
                };
            }
        }

        [ValidateToken]
        [HttpPost]
        public HttpResult UpdateUser([FromBody] User user)
        {
            try
            {
                return UnitOfWork.User.UpdateInfo(user);
            }
            catch (Exception ex)
            {
                return new HttpResult
                {
                    MessageCode = Entities.Enum.Enums.MessageCode.Exception,
                    Message = ex.Message
                };
            }
        }

        [HttpPost]
        public HttpResult ValidateOTP([FromBody] OTP otp)
        {
            try
            {
                //Kiểm tra thông tin đầu vào
                if (string.IsNullOrWhiteSpace(otp.Value))
                    return new HttpResult { MessageCode = Entities.Enum.Enums.MessageCode.Error, Message = "OTP is null" };
                //Xác thực OTP
                if (!UnitOfWork.User.ValidateOTP(otp))
                {
                    return new HttpResult
                    {
                        MessageCode = Entities.Enum.Enums.MessageCode.Error,
                        Message = "Active fail."
                    };
                }
                return new HttpResult
                {
                    MessageCode = Entities.Enum.Enums.MessageCode.Success,
                    Message = "Success."
                };
            }
            catch (Exception ex)
            {
                return new HttpResult
                {
                    MessageCode = Entities.Enum.Enums.MessageCode.Exception,
                    Message = ex.Message
                };
            }
        }


        public void SendEmailOTP(string email, OTP otp)
        {
            string to = "sky.endless96@gmail.com";
            string from = "thien_tran996@yahoo.com";
            MailMessage message = new MailMessage(from, to);
            message.Subject = "Confirm OTP to register User.";
            message.Body = @"Using this new feature, you can send an email message from an application very easily.";
            SmtpClient client = new SmtpClient("https://localhost:44388");
            // Credentials are necessary if the server requires the client
            // to authenticate before it will send email on the client's behalf.
            client.UseDefaultCredentials = true;

            try
            {
                client.Send(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in CreateTestMessage2(): {0}",
                    ex.ToString());
            }
        }
    }
}