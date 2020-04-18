<%@ WebHandler Language="C#" Class="CalculatorHandler" %>

using System;
using System.Web;

public class CalculatorHandler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context)
    {
        HttpResponse response = context.Response;
        response.ContentType = "text/plain";

        float value1, value2;
        if(Single.TryParse(context.Request.QueryString["value1"], out value1) &
            Single.TryParse(context.Request.QueryString["value2"], out value2))
        {
            response.Write(value1 + value2);
        }
        else
        {
                response.Write("-");
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}