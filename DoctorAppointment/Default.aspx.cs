using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    iClass c = new iClass();
    public string rootPath;
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void btnLogin_Click(object sender, EventArgs e)
    {
        Response.Redirect("loginDoctor.aspx");
    }

    protected void btnSignup_Click(object sender, EventArgs e)
    {
        Response.Redirect("registerDoctor.aspx");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("search-doctor/" + TextBox1.Text);
    }
}