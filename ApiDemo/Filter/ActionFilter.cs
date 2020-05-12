using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDemo.Filter
{
    public class ActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string key = context.HttpContext.Request.Headers["key"];
            string token = context.HttpContext.Request.Headers["token"];
            string controller = context.RouteData.Values["Controller"].ToString();
            string action = context.RouteData.Values["Action"].ToString();
            string method = context.HttpContext.Request.Method;
            var queryString = context.HttpContext.Request.QueryString;
            if (key==null||key=="1")
            {
                context.Result = new ObjectResult(new { code=1,msg="错误"});
            }
            context.HttpContext.Request.Headers.Add("uid", "luoy");
            context.HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
        }
    }
}
