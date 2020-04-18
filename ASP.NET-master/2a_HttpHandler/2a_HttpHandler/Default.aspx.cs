using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void GetButton_Click(object sender, EventArgs e)
    {
        HttpWebRequest rq = (HttpWebRequest)HttpWebRequest.Create("http://localhost:53839/get.pyb");
        rq.Method = "GET";
        HttpWebResponse rs = (HttpWebResponse)rq.GetResponse();
        StreamReader reader = new StreamReader(rs.GetResponseStream());
        Response.Write(reader.ReadToEnd());
    }

    protected void PostButton_Click(object sender, EventArgs e)
    {
        HttpWebRequest rq = (HttpWebRequest)HttpWebRequest.Create("http://localhost:53839/post.pyb");
        rq.Method = "POST";
        rq.MaximumResponseHeadersLength = 100;
        rq.ContentLength = 0;
        HttpWebResponse rs = (HttpWebResponse)rq.GetResponse();
        StreamReader rdr = new StreamReader(rs.GetResponseStream());
        Response.Write(rdr.ReadToEnd());
    }

    protected void PutButton_Click(object sender, EventArgs e)
    {
        HttpWebRequest rq = (HttpWebRequest)HttpWebRequest.Create("http://localhost:53839/put.pyb");
        rq.Method = "PUT";
        rq.MaximumResponseHeadersLength = 100;
        rq.ContentLength = 0;
        HttpWebResponse rs = (HttpWebResponse)rq.GetResponse();
        StreamReader rdr = new StreamReader(rs.GetResponseStream());
        Response.Write(rdr.ReadToEnd());
    }

    protected void Get403_Click(object sender, EventArgs e)
    {
        try
        {
            HttpWebRequest rq = (HttpWebRequest)HttpWebRequest.Create("http://localhost:53839/forbidden.pyb");
            rq.Method = "GET";
            HttpWebResponse rs = (HttpWebResponse)rq.GetResponse();
            StreamReader reader = new StreamReader(rs.GetResponseStream());
            Response.Write(reader.ReadToEnd());
        }
        catch (WebException we)
        {
            Response.Write(we.Status);
            Response.Write("<br/>" + we.Message);
            Response.Write("<br/>" + we.TargetSite);
            Response.Write("<br/>" + we.Source);
        }
    }
}