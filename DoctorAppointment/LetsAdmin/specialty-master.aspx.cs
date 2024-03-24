using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class LetsAdmin_specialty_master : System.Web.UI.Page
{

    iClass c = new iClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        //string conStr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["AppointmentDB"].ConnectionString;

        //txtSPName.Text = conStr;
        if (!IsPostBack)
        {
            FillGrid();
            if (Page.RouteData.Values["speId"] != null && Page.RouteData.Values["speId"].ToString() != "")
            {

                lblId.Text = Page.RouteData.Values["speId"].ToString();
                btnDelete.Visible = true;
                GetSpecialityDetails(Convert.ToInt32(lblId.Text));
            }
            else
            {
                lblId.Text = "[New]";
                btnDelete.Visible = false;
                txtSPName.Focus();
            }

        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {

        try
        {
            txtSPName.Text = txtSPName.Text.Trim().Replace("'", "`");

            if (txtSPName.Text == "") 
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "myScriptASDSAD", "toastr.warning('Enter Speciality','Warning');", true);
                txtSPName.Focus();
                return;
            }

            //iClass c = new iClass();

            int maxId = lblId.Text == "[New]" ? c.NextId("SpecialitiesData", "speId") : Convert.ToInt32(lblId.Text);

            //c.ExecuteQuery("Insert Into SpecialitiesData (speId, speName, delMark) Values (" + maxId + ", '" + txtSPName.Text + "', 0)");

            if (lblId.Text == "[New]")
            {
                c.ExecuteQuery("Insert Into SpecialitiesData (speId, speName, delmark ) Values (" + maxId + ", '" + txtSPName.Text + "', 0)");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "myScriptASDSAD", "toastr.success('Specialities Added','Success');", true);
            }
            else
            {
                c.ExecuteQuery("Update SpecialitiesData Set speName='" + txtSPName.Text + "' Where speId=" + maxId);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "myScriptASDSAD", "toastr.success('Speciality Updated','Success');", true);
            }



            Page.ClientScript.RegisterStartupScript(this.GetType(), "myScriptASDSAD", "waitAndMove('"+ Master.rootPath + "LetsAdmin/specialty-master',2000);", true);
            txtSPName.Text = "";
            lblId.Text = "[New]";
            FillGrid();
            return;
        }
        catch (Exception)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myScriptASDSAD", "toastr.error('Error Occured','Error');", true);
            return;
        }
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect(Master.rootPath + "LetsAdmin/specialty-master");
    }

    private void FillGrid()
    {
        try
        {
            string strQuery = "select * from SpecialitiesData where delmark=0";

            DataTable dtSpecs = new DataTable();
            dtSpecs = c.GetDataTable(strQuery);
            gvSpec.DataSource = dtSpecs;
            gvSpec.DataBind();

        }
        catch (Exception)
        {

            throw;
        }
    }
    protected void gvSpec_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            Literal litAnch = new Literal();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                litAnch = (Literal)e.Row.FindControl("litAnch");
                litAnch.Text = "<a href=\"" + Master.rootPath + "LetsAdmin/specialty-master/" + e.Row.Cells[0].Text + "\" class=\"gAnch\" ></a>";
            }
        }
        catch (Exception)
        {

            throw;
        }
    }

    private void GetSpecialityDetails(int speIDX)
    {
        try
        {
            DataTable dtSpeciality = c.GetDataTable("Select * From SpecialitiesData Where speId=" + speIDX);

            DataRow row = dtSpeciality.Rows[0];

            txtSPName.Text = row["speName"].ToString();
        }
        catch (Exception)
        {

            throw;
        }
    }


    protected void btnDelete_Click(object sender, EventArgs e)
    {
        int speId = Convert.ToInt32(lblId.Text);
        c.ExecuteQuery("Update SpecialitiesData Set delmark=1 where speId=" + speId);
        Page.ClientScript.RegisterStartupScript(this.GetType(), "myScriptASDSAD", "toastr.success('Speciality Deleted Successfully','Success');", true);
        Page.ClientScript.RegisterStartupScript(this.GetType(), "myScriptwdSAD", "waitAndMove('" + Master.rootPath + "LetsAdmin/specialty-master',2000);", true);


    }
}


