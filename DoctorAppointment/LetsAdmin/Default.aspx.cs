using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LetsAdmin_Default : System.Web.UI.Page
{
    public string errMsg;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        username.Text = username.Text.Trim().Replace("'", "`");
        password.Text = password.Text.Trim().Replace("'", "`");


        if (username.Text == "")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myScriptASDSAD", "toastr.warning('Enter Username','Warning');", true);

            //errMsg = "<span class=\"warning\" >Enter Username</span>";
            username.Focus();
            return;
        }

        if (password.Text == "")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myScriptASDSAD", "toastr.error('Enter Password','Warning');", true);
            //errMsg = "<span class=\"warning\" >Enter Password</span>";
            password.Focus();
            return;
        }

        if (username.Text == "admin")
        {
            if (password.Text == "12345")
            {

                Session["userAdmin"] = "admin";

                Response.Redirect("dashboard.aspx");
                //errMsg = "<span class=\"success\" >Login Successful</span>";
            }

            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "myScriptASDSAD", "toastr.warning('Enter Username','Warning');", true);
                //errMsg = "<span class=\"warning\" >Incorrect Password</span>";
                password.Focus();
                return;
            }

        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myScriptASDSAD", "toastr.warning('Enter Username','Warning');", true);
            //errMsg = "<span class=\"warning\" >Incorrect Username</span>";
            username.Focus();
            return;
        }



        //if (username.Text == "")
        //{
        //    errMsg = "<span class=\"warning\" >Enter Username</span>";
        //    username.Focus();
        //    return;
        //}
        //if(password.Text == "")
        //{
        //    errMsg = "<span class=\"warning\" >Enter Password</span>";
        //    password.Focus();
        //    return;
        //}

        //if (username.Text == "admin")
        //{
        //    if (password.Text == "12345")
        //    {
        //        Session["userName"] = "admin";
        //        Response.Redirect("dashboard.aspx");
        //        //errMsg = "<span class=\"success\">Login Successful</span>";
        //    }
        //    else
        //    {
        //        errMsg = "<span class=\"warning\">Wrong Password</span>";

        //    }
        //}
        //else
        //{
        //    username.Focus();
        //    errMsg = "<span class=\"warning\">Incorrect Username or password</span>";
        //    password.Focus();

        //    if(password.Text != "12345")
        //    {
        //        errMsg = "<span class=\"warning\">Login failed</span>";
        //        password.Focus();
        //        return;
        //    }
        //}
    }
}