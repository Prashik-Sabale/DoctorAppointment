using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_MasterUser : System.Web.UI.MasterPage
{
    iClass c = new iClass();
    public string userName;
    public int userId;
    public string rootPath;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Page_Init(object sender, EventArgs e)
    {
        rootPath = c.ReturnHttp();
        if (Session["userSession"] != null)
        {
            string[] arrSession =( string[]) Session["userSession"];
            //userName = Session["userSession"].ToString();
            userId = Convert.ToInt32( arrSession[1]);
        }
        else
        {
            Response.Redirect(rootPath + "login.aspx");
        }
    }
}