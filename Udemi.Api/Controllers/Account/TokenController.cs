using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Udemi.Entities;

namespace Udemi.Api.Controllers.Account
{
    public class TokenController : BaseApiController
    {
        [HttpPost]
        public HttpResult ValidateToken([FromBody] object T)
        {
            return new HttpResult();
        }
    }
}