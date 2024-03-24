using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class forgot_password : System.Web.UI.Page
{
    iClass c = new iClass();
    string[] arrSession = new string[2];
    int docId;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            txtMail.Text = txtMail.Text.Trim().Replace("'", "`");

            if (txtMail.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "sdfgjkhsjkdf", "toastr.warning('Enter Email Id','Warning');", true);
                return;
            }

            arrSession = (string[])Session["loginSession"];
            docId = Convert.ToInt32(arrSession[2]);
            String docmailId = Convert.ToString(c.GetReqData("DoctorsData", "docEmail", "docId=" + docId));
            if (txtMail.Text != docmailId)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myScriptsdfgjkhdfgsjkdf", "toastr.warning('Enter Valid Email','Warning');", true);
                txtMail.Focus();
                return;
            }




        }
        catch (Exception)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myScriptAwe4rwSytfvURLH", "toastr.error('Error Occured','Error');", true);
            return;
        }
    }
}