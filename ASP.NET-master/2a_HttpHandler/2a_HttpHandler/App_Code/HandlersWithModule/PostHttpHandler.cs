using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Сводное описание для PostHttpHandler
/// </summary>
public class PostHttpHandler : IHttpHandler
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
            context.Response.Write("POST-HTTP-PYB:Name=" +
                HttpContext.Current.Items["PYBN"]);
        }
        if (HttpContext.Current.Items["PYBS"] != null)
        {
            context.Response.Write("; POST-HTTP-PYB:SurName=" +
                HttpContext.Current.Items["PYBS"]);
        }
    }
}