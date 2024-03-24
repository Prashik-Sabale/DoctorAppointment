using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    iClass c = new iClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            if(Request.QueryString["auth"]!=null)
            {
                if (Request.QueryString["auth"] == "out")
                {
                    Session["userSession"] = null;
                }
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            txtPhone.Text = txtPhone.Text.Trim().Replace("'", "`");
            txtPassword.Text = txtPassword.Text.Trim().Replace("'", "`");

            if (txtPhone.Text == "" || txtPassword.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "sdfgjkhsjkdf", "toastr.warning('All Fields Are Mandatory','Warning');", true);
                return;
            }

            //if (c.EmailAddressCheck(txtPhone.Text) == false)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myScriptABDJFD", "toastr.warning('Enter valid email address','Warning');", true);
            //    //Page.ClientScript.RegisterStartupScript(this.GetType(), "myScriptABDJFD", "toastr.warning('Enter valid email address','Warning');", true);
            //    txtPhone.Focus();
            //    return;
            //}

            //if (c.EmailAddressCheck(txtPassword.Text) == false)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myScriptscBDJFD", "toastr.warning('Enter valid Password','Warning');", true);
            //    //Page.ClientScript.RegisterStartupScript(this.GetType(), "myScriptABDJFD", "toastr.warning('Enter valid email address','Warning');", true);
            //    txtPassword.Focus();
            //    return;
            //}

            if (c.IsRecordExist("select * from UsersData Where userMOB='" + txtPhone.Text + "' AND userPass='" + txtPassword.Text + "'"))
            {
                int userId = Convert.ToInt32(c.GetReqData("UsersData", "userId", "userMOB='" + txtPhone.Text + "' AND userPass='" + txtPassword.Text + "'"));

                string[] arrSession = new string[2];
                arrSession[0] = "1";
                arrSession[1] = userId.ToString();
                Session["userSession"] = arrSession;
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myScriptABDJFD", "toastr.success('Logged In Successfully','Success');", true);
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myScriptABDJFDsdfsd", "waitAndMove('" + Master.rootPath + "User',3000);", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myScriptABDJFD", "toastr.warning('Enter Valid Password','Warning');", true);
                txtPassword.Focus();
                return;
            }



            //int maxId = c.NextId("DoctorsData", "docId");

            //string encrptId = c.EncryptData(txtEmail.Text + "#" + maxId.ToString());
            //c.ExecuteQuery("Insert Into DoctorsData (docId, docFName, docLName, cityId, docGender, docEmail, docPass, verifyFlag, delMark, encrptId ) values (" + maxId + ", '" + txtFName.Text + "', '" + txtLName.Text + "', '" + ddrCity.SelectedValue + "', '" + ddrGender.SelectedValue + "', '" + txtEmail.Text + "', '" + txtPass.Text + "', 0, 0, '" + encrptId + "')");

            //string[] arrSession = new string[2];
            //arrSession[0] = "1";
            //arrSession[1] = maxId.ToString();
            //Session["docSession"] = arrSession;
            //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myScriptABDJFD", "toastr.success('Registered Successfully','Success');", true);
            //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myScriptABDJFDsdfsd", "waitAndMove('" + Master.rootPath + "doctors',3000);", true);







        }
        catch (Exception)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myScriptASURLH", "toastr.error('Error Occured','Error');", true);
            return;
        }
    }
}
