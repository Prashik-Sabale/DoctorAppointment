using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_Default : System.Web.UI.Page
{
    iClass c = new iClass();
    public string userName;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userSession"] != null)
        {
            string[] arrUser = (string[])Session["userSession"];

            if (arrUser[0] == "1")
            {
                int userId = Convert.ToInt32(arrUser[1]);

                userName = c.GetReqData("UsersData", "userFullName", "userId=" + userId).ToString();

            }
            else
            {
                //Session["docSession"] = null;
                //Response.Redirect()
            }
        }
    }

}