using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class registerDoctor : System.Web.UI.Page
{
    iClass c = new iClass();
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void btnRegister_Click(object sender, EventArgs e)
    {
        try
        {
            txtFName.Text = txtFName.Text.Trim().Replace("'", "`");
            txtLName.Text = txtLName.Text.Trim().Replace("'", "`");
            txtEmail.Text = txtEmail.Text.Trim().Replace("'", "`");
            txtPass.Text = txtPass.Text.Trim().Replace("'", "`");
            txtCPass.Text = txtCPass.Text.Trim().Replace("'", "`");

            if (txtFName.Text == "" || txtLName.Text == "" || txtEmail.Text == "" || txtPass.Text == "" || txtCPass.Text == "" || ddrCity.SelectedValue == "0" || ddrGender.SelectedValue == "0")
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

            if (txtPass.Text != txtCPass.Text)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myScriptABDJFD", "toastr.warning('Passwords did not match','Warning');", true);
                txtPass.Focus();
                return;
                //c.ExecuteQuery("Insert Into DoctorsData (docId, docFName, docLName, cityId, docGender, docEmail, docPass, verifyFlag, delMark, encrptId ) values (" + maxId + ", '" + txtFName.Text + "', '" + txtLName.Text + "', '" + ddrCity.SelectedValue + "', '" + ddrGender.SelectedValue + "', '" + txtEmail.Text + "', '" + txtPass.Text + "', 0, 0, '" + encrptId + "')");
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "myScriptAJRYAD", "toastr.success('Registered Successfully','Success');", true);

            }

            if (c.IsRecordExist("select * from DoctorsData Where docEmail='" + txtEmail.Text + "'"))
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myScriptABDJFD", "toastr.warning('User with this email address already registered','Warning');", true);
                txtEmail.Focus();
                return;
            }



            int maxId = c.NextId("DoctorsData", "docId");

            string encrptId = c.EncryptData(txtEmail.Text + "#" + maxId.ToString());
            c.ExecuteQuery("Insert Into DoctorsData (docId, docFName, docLName, cityId, docGender, docEmail, docPass, verifyFlag, delMark, encrptId )" + "values (" + maxId + ", '" + txtFName.Text + "', '" + txtLName.Text + "', '" + ddrCity.SelectedValue + "', '" + ddrGender.SelectedValue + "', '" + txtEmail.Text + "', '" + txtPass.Text + "', 0, 0, '" + encrptId + "')");

            string[] arrSession = new string[2];
            arrSession[0] = "1";
            arrSession[1] = maxId.ToString();
            Session["docSession"] = arrSession;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myScriptABDJFD", "toastr.success('Registered Successfully','Success');", true);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myScriptABDJFDsdf", "waitAndMove('" + Master.rootPath + "Doctor',3000);", true);


            //Page.ClientScript.RegisterStartupScript(this.GetType(), "myScriptAJRYAD", "toastr.success('Registered Successfully','Success');", true);

            //if (txtPass.Text == txtCPass.Text)
            //{


            //}
            //else
            //{
            //    Page.ClientScript.RegisterStartupScript(this.GetType(), "myScriptALFWFD", "toastr.warning('Enter correct Password','Warning');", true);
            //    txtCPass.Focus();
            //    return;
            //}






        }
        catch (Exception ex)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myScriptASURLH", "toastr.error('Error Occured','Error');", true);
            return;
        }
    }
}