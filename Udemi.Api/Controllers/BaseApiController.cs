using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using Udemi.Services;
using static Udemi.Api.WebApiApplication;

namespace Udemi.Api.Controllers
{
    public class BaseApiController : ApiController
    {
        protected IUnitOfWork UnitOfWork;

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            try
            {
                UnitOfWork = UnitOfWorkFactory.GetUnitOfWork(@"DESKTOP-2EQ0RU5\SQLEXPRESS", "SQL");
            }
            catch (Exception ex)
            {
            }
            base.Initialize(controllerContext);
        }
    }
}
