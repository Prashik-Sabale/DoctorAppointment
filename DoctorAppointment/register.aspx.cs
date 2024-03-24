using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class register : System.Web.UI.Page
{
    iClass c = new iClass();
    protected void Page_Load(object sender, EventArgs e)
    {

    }



    protected void btnRegister_Click(object sender, EventArgs e)
    {
        try
        {
            txtFullName.Text = txtFullName.Text.Trim().Replace("'", "`");
            txtPhone.Text = txtPhone.Text.Trim().Replace("'", "`");
            txtPass.Text = txtPass.Text.Trim().Replace("'", "`");

            if (txtFullName.Text == "" || txtPhone.Text == "" || txtPass.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "sdfgjkhsjkdf", "toastr.warning('All Fields Are Mandatory','Warning');", true);
                return;
            }

            int maxId = c.NextId("UsersData", "userId");
            string encrptId = c.EncryptData(txtPhone.Text + "#" + maxId.ToString());
            //c.ExecuteQuery("Insert Into UsersData (userId, userFullName, userMOB, userPass, verifyFlag, delMark, encrptId ) values ( " + maxId + ", '" + txtFullName.Text + "', '" + txtPhone.Text + "', '" + txtPass.Text + "', 0, 0, '" + encrptId + "')");
            c.ExecuteQuery("Insert Into UsersData (userId, userFullName, userMOB, userPass, verifyFlag, delMark, encrptId ) values" +
                " (" + maxId + ", '" + txtFullName.Text + "', '" + txtPhone.Text + "', '" + txtPass.Text + "', 0, 0, '" + encrptId + "')");


            string[] arrSession = new string[2];
            arrSession[0] = "1";
            arrSession[1] = maxId.ToString();
            Session["userSession"] = arrSession;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myScriptABtddrtDJFD", "toastr.success('Registered Successfully','Success');", true);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myScriptABDJFxwDsdfsd", "waitAndMove('" + Master.rootPath + "User',3000);", true);


        }
        catch (Exception )
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "sdfgjkhsjdgkdf", "toastr.error('Error Occured','error');", true);
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "myScriptASURdtgLH", "toastr.error('Error Occured','Error');", true);
            return;
        }
    }
}