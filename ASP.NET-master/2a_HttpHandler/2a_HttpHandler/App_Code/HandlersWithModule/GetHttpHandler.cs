using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Сводное описание для GetHttpHandler
/// </summary>
public class GetHttpHandler : IHttpHandler
{
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

    public void ProcessRequest(HttpContext context)
    {
        if (HttpContext.Current.Items["PYBN"] != null)
        {
            context.Response.Write("GET-HTTP-PYB:Name=" +
                HttpContext.Current.Items["PYBN"]);
        }
        if (HttpContext.Current.Items["PYBS"] != null)
        {
            context.Response.Write("; GET-HTTP-PYB:SurName=" +
                HttpContext.Current.Items["PYBS"]);
        }
    }
}