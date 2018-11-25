using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_Core_CuoiKy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Http;

namespace ASP_Core_CuoiKy.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            
            if (HttpContext.Session.Get("userName") == null)
            {
                filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(new { controller = "Admin/Login", action = "Login" }));
            }
            base.OnActionExecuting(filterContext);
        }
    }
}