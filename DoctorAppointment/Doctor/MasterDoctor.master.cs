using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Doctor_MasterDoctor : System.Web.UI.MasterPage
{
    iClass c = new iClass();
    public string userName;
    public string rootPath;
    protected void Page_Load(object sender, EventArgs e)
    {
        //docProfileMarkup = "Welcome";

    }
    protected void Page_Init(object sender, EventArgs e)
    {
        rootPath = c.ReturnHttp();
        if (Session["docSession"] != null)
        {
            userName = Session["docSession"].ToString();

        }
        else
        {
            Response.Redirect(rootPath + "loginDoctor.aspx");
        }
    }
}
