using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_change_password : System.Web.UI.Page
{
    iClass c = new iClass();
    string[] arrSession = new string[2];
    int userId;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        try
        {
            txtCpass.Text = txtCpass.Text.Trim().Replace("'", "`");
            txtNpass.Text = txtNpass.Text.Trim().Replace("'", "`");
            txtCNpass.Text = txtCNpass.Text.Trim().Replace("'", "`");

            if (txtCpass.Text == "" && txtNpass.Text == "" && txtCNpass.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "sdfgjkjkkjkdf", "toastr.warning('All fields are mendatory','Warning');", true);
                txtCpass.Focus();


            }

            arrSession = (string[])Session["userSession"];
            userId = Convert.ToInt32(arrSession[1]);

            string oldPass = Convert.ToString(c.GetReqData("UsersData", "userPass", "userId=" + userId));
            if (txtCpass.Text == oldPass)
            {
                if (txtNpass.Text == txtCNpass.Text)
                {
                    c.ExecuteQuery("Update UsersData set userPass ='" + txtCNpass.Text + "' where userId=" + userId);
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "sdfgjkjkkjkdf", "toastr.success('Password Changed Successfuly','success');", true);
                    return;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "sdfgjkjkkjkdf", "toastr.warning('Password did not match,'Warning');", true);
                    txtNpass.Focus();

                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "sdfgjkjkkjkdf", "toastr.warning('Please Enter Correct Password','Warning');", true);
                txtNpass.Focus();

            }
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myScriptASURLH", "toastr.error('Error Occured','Error');", true);

        }


    }
}