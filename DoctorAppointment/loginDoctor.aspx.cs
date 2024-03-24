using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class loginDoctor : System.Web.UI.Page
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
                    Session["docSession"] = null;
                }
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            txtEmail.Text = txtEmail.Text.Trim().Replace("'", "`");
            txtPassword.Text = txtPassword.Text.Trim().Replace("'", "`");

            if (txtEmail.Text == "" || txtPassword.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "sdfgjkhsjkdf", "toastr.warning('All Fields Are Mandatory','Warning');", true);
                return;
            }

            if (c.EmailAddressCheck(txtEmail.Text) == false)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myScriptABDJFD", "toastr.warning('Enter valid email address','Warning');", true);
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "myScriptABDJFD", "toastr.warning('Enter valid email address','Warning');", true);
                txtEmail.Focus();
                return;
            }

            if (c.IsRecordExist("select * from DoctorsData Where docEmail='" + txtEmail.Text + "' AND docPass='" + txtPassword.Text + "'"))
            {
                int docId = Convert.ToInt32(c.GetReqData("DoctorsData", "docId", "docEmail='" + txtEmail.Text + "' AND docPass='" + txtPassword.Text + "'"));

                string[] arrSession = new string[2];
                arrSession[0] = "1";
                arrSession[1] = docId.ToString();
                Session["docSession"] = arrSession;
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myScriptABDJFD", "toastr.success('Logged In Successfully','Success');", true);
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myScriptABDJFDsdfsd", "waitAndMove('" + Master.rootPath + "Doctor',3000);", true);
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

  