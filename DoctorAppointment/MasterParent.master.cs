using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterParent : System.Web.UI.MasterPage
{
    iClass c = new iClass();
    public string rootPath;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Page_Init(object sender, EventArgs e)
    {
        rootPath = c.ReturnHttp();
    }

    protected void btnSignup_Click(object sender, EventArgs e)
    {
        Response.Redirect("registerDoctor.aspx");
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        Response.Redirect("loginDoctor.aspx");
    }
}
