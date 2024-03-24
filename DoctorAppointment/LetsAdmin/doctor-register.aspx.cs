using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LetsAdmin_doctor_register : System.Web.UI.Page
{
    iClass c = new iClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if( !IsPostBack)
        {
            FillGrid();
            if (Page.RouteData.Values["docId"] != null && Page.RouteData.Values["docId"].ToString() != "")
            {
                lblId.Text = Page.RouteData.Values["docId"].ToString();
                btnDelete.Visible = true;
                GetDoctorsDetails(Convert.ToInt32(lblId.Text));
            }
            else
            {
                lblId.Text = "[New]";
                btnDelete.Visible = false;

            }
        }
    }

    private void FillGrid()
    {
        try
        {
            string strQuery = "select docId, docFName + ' ' + docLName as docName from DoctorsData order by docId desc";
            DataTable dtDoctors = new DataTable();
            dtDoctors = c.GetDataTable(strQuery);
            gvDoc.DataSource = dtDoctors;
            gvDoc.DataBind();
        }
        catch (Exception)
        {

            throw;
        }
    }

    protected void gvDoc_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            Literal litAnch = new Literal();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                litAnch = (Literal)e.Row.FindControl("litAnch");
                litAnch.Text = "<a href=\"" + Master.rootPath + "LetsAdmin/doctor-register/" + e.Row.Cells[0].Text + "\" class=\"gAnch\" ></a>";
            }
        }
        catch (Exception)
        {

            throw;
        }
    }

    private void GetDoctorsDetails(int docIDX)
    {
        try
        {
            DataTable dtDoctors = c.GetDataTable("Select * From DoctorsData Where docId=" + docIDX);

            DataRow row = dtDoctors.Rows[0];

            txtFName.Text = row["docFName"].ToString();
            txtLName.Text = row["docLName"].ToString();
            ddrCity.Text = row["cityId"].ToString();
            ddrGender.Text = row["docGender"].ToString();
            txtEmail.Text = row["docEmail"].ToString();
            txtPass.Text = row["docPass"].ToString();
        }
        catch (Exception)
        {

            throw;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            txtFName.Text = txtFName.Text.Trim().Replace("'", "`");
            txtLName.Text = txtLName.Text.Trim().Replace("'", "`");
            txtEmail.Text = txtEmail.Text.Trim().Replace("'", "`");
            txtPass.Text = txtPass.Text.Trim().Replace("'", "`");

            if (txtFName.Text == "" || txtLName.Text == "" || txtEmail.Text == "" || txtPass.Text == "" || ddrCity.SelectedValue == "0" || ddrGender.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "sdfgjkhsjkdf", "toastr.warning('All Fields Are Mandatory','Warning');", true);
                return;
            }

            int maxId = lblId.Text == "[New]" ? c.NextId("DoctorsData", "docId") : Convert.ToInt32(lblId.Text);

            //if (lblId.Text == "[New]")
            //    c.NextId("categoryData", "catId");
            //else
            //    maxId = Convert.ToInt32(lblId.Text);

            if (lblId.Text == "[New]")
            {
                c.ExecuteQuery("Insert Into DoctorsData (docId, docFName, docLName, cityId, docGender, docEmail, docPass, verifyFlag, delMark ) values (" + maxId + ", '" + txtFName.Text + "', '" + txtLName.Text + "', '" + ddrCity.SelectedValue + "', '" + ddrGender.SelectedValue + "', '" + txtEmail.Text + "', '" + txtPass.Text + "', 0, 0)");
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myScriptASDSasjkdhnAD", "toastr.success('Doctor Added','Success');", true);

            }
            else
            {
                c.ExecuteQuery("Update DoctorsData Set docFName='" + txtFName.Text + "', docLName='" + txtLName.Text + "', cityId=" + ddrCity.SelectedValue + ", docGender=" + ddrGender.SelectedValue + ", docPass='" + txtPass.Text + "'  Where docId=" + maxId);

                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myScriptrjhsjdghAD", "toastr.success('Doctor Updated','Success');", true);
            }
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myScriptASKJYdrgC", "waitAndMove('" + Master.rootPath + "letsAdmin/doctor-register',2000);", true);
            txtFName.Text = "";
            lblId.Text = "[New]";
            FillGrid();
            return;

        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myScriptASiawydeAD", "toastr.success('Error Occured','Error');", true);
            return;
        }
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect(Master.rootPath + "/LetsAdmin/doctor-register/");
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        {
        int docId = Convert.ToInt32(lblId.Text);
        c.ExecuteQuery("Update DoctorsData Set delMark=1 where docId=" + docId);
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myScriptASDluihdehnAD", "toastr.success('Doctor Deleted Successfully','Success');", true);
        //Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "myScriptKJGFGC", "waitAndMove('" + Master.rootPath + "letsAdmin/doctor-master',3000);", true);
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myScriptASoiugbhdD", "waitAndMove('" + Master.rootPath + "LetsAdmin/doctor-register',3000);", true);
    }
    }

    
}