using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Filters
{
    public class MyExceptionFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled && filterContext.Exception is InvalidOperationException)
            {
                filterContext.HttpContext.Response.Write("<div class=\"container\"><h3>(InvalidOperationException)</h3></div>");
                filterContext.ExceptionHandled = true;
            }
        }
    }
}