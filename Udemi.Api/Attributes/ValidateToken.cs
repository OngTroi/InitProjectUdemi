using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Udemi.Entities.Common.Account;
using Udemi.Services;
using static Udemi.Api.WebApiApplication;

namespace Udemi.Api.Attributes
{
    public class ValidateToken : ActionFilterAttribute
    {
        protected IUnitOfWork UnitOfWork;
        //Danh sách action cần validate Administrator
        readonly List<string> lstactionTeacher = new List<string>(new string[] { "CreateCourses", "UpdateCourses", "DeleteCourses"});
        //Danh sách action cần validate Teacher
        readonly List<string> lstactionAdministrtor = new List<string>(new string[] { "CreateCourses", "UpdateCourses", "DeleteCourses", "CreateCategory", "UpdateCategory", "DeleteCategory", "CreateUser", "UpdateUser", "DeleteUser" });

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            //Lấy thông tin action

            var action = HttpContext.Current.Request.RequestContext.RouteData.Values["action"].ToString();

            string TokenId = actionContext.Request.Headers.GetValues("Udemi-Token").FirstOrDefault().ToString();
            if (TokenId.IsNullOrWhiteSpace())
            {
                var response = new HttpResponseMessage(HttpStatusCode.PreconditionFailed)
                {
                    Content = new StringContent("Token is empty.")
                };
                actionContext.Response = response;
                return;
            }

            UnitOfWork = UnitOfWorkFactory.GetUnitOfWork(Global.ConnectionString.ToString(), "SQL");
            Token getTk = UnitOfWork.Token.GetToken(TokenId);
            if (getTk.TokenId == null)
            {
                var response = new HttpResponseMessage(HttpStatusCode.PreconditionFailed)
                {
                    Content = new StringContent("Invalid Token.")
                };
                actionContext.Response = response;
                return;
            }
            //Kiểm tra action
            bool checkteacher = false;
            bool checkadministrator = false;

            foreach (var item in lstactionTeacher)
            {
                if (item.Equals(action))
                {
                    checkteacher = true;
                }
            }
            foreach (var item in lstactionAdministrtor)
            {
                if (item.Equals(action))
                {
                    checkadministrator = true;
                }
            }

            if (checkteacher)
            {
                //Kiểm tra usertype
                if (!getTk.User_Type.Equals("T"))
                {
                    var response = new HttpResponseMessage(HttpStatusCode.PreconditionFailed)
                    {
                        Content = new StringContent("Wrong Type token.")
                    };
                    actionContext.Response = response;
                    return;
                }
            }

            if (checkadministrator)
            {
                //Kiểm tra usertype
                if (!getTk.User_Type.Equals("A"))
                {
                    var response = new HttpResponseMessage(HttpStatusCode.PreconditionFailed)
                    {
                        Content = new StringContent("Wrong Type token.")
                    };
                    actionContext.Response = response;
                    return;
                }
            }
        }
    }
}