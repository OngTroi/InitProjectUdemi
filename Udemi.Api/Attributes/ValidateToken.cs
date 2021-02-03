using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Udemi.Api.Attributes
{
    public class ValidateToken : ActionFilterAttribute
    {
        readonly List<string> lstcontrollteacher = new List<string>();
        readonly List<string> lstcontrolladministrator = new List<string>();

        public override void OnActionExecuting(HttpActionContext actionContext)
        {

        }
    }
}