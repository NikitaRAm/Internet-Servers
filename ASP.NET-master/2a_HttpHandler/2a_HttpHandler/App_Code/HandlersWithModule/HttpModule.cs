using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Сводное описание для GetHttpModule
/// </summary>
public class HttpModule : IHttpModule
{

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public void Init(HttpApplication context)
    {
        context.AcquireRequestState += new EventHandler(AcquireRequestState);
    }

    public void AcquireRequestState(Object sender, EventArgs e)
    {
        HttpContext context = ((HttpApplication)sender).Context;
        context.Items.Add("PYBN", "Yan");
        context.Items.Add("PYBS", "Pershay");
    }
}