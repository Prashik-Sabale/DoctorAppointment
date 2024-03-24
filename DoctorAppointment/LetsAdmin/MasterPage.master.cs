using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LetsAdmin_MasterPage : System.Web.UI.MasterPage
{
    public string userName;
    public string rootPath;
    iClass c = new iClass();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Page_Init(object sender, EventArgs e)
    {
        rootPath = c.ReturnHttp();
        if (Session["userAdmin"] != null)
        {
            userName = Session["userAdmin"].ToString();

        }
        else
        {
            Response.Redirect(rootPath + "LetsAdmin");
        }
    }
}
