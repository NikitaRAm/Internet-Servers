using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewStatePage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Label2.Text += "~Load~";
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        String s = Request["__VIEWSTATE"];
        this.Label1.Text = "{" + s.Length + "}" + "{" + this.TextBox1.Text.Length + "}";
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        this.Label2.Text += "~Init~";
    }

    protected void Page_Prerender(object sender, EventArgs e)
    {
        this.Label2.Text += "~Prefender~";
    }
    protected void Page_Unload(object sender, EventArgs e)
    {
        this.Label2.Text += "~Unload~";

    }
    protected void Page_Disposed(object sender, EventArgs e)
    {
        this.Label2.Text += "~Disposed~";
    }

    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        this.Label2.Text += "~CheckBox1Click~";
    }

    protected void Button2_Click1(object sender, EventArgs e)
    {
        this.Label2.Text += "~Button2Click~";
    }
}