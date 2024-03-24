using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Doctor_edit_profile : System.Web.UI.Page
{
    iClass c = new iClass();
    string[] arrSession = new string[2];
    int docId;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            c.FillComboBox("speName", "speID", "SpecialitiesData", "delMark=1", "speID", 0, ddrSpecialty);
            if (Session["docSession"] != null)
            {

                GetDoctorsDetails();
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            txtMNO.Text = txtMNO.Text.Trim().Replace("'", "`");
            txtQual.Text = txtQual.Text.Trim().Replace("'", "`");
            txtHosp.Text = txtHosp.Text.Trim().Replace("'", "`");
            txtAddr.Text = txtAddr.Text.Trim().Replace("'", "`");
            txtExp.Text = txtExp.Text.Trim().Replace("'", "`");


            if (txtExp.Text != "")
            {
                if (!c.IsNumeric(txtExp.Text))
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "sdfgjkhsjkdf", "toastr.warning('Enter Experience in Number','Warning');", true);
                    txtExp.Focus();
                    return;
                }
            }

            arrSession = (string[])Session["docSession"];
            docId = Convert.ToInt32(arrSession[1]);


            if (c.IsRecordExist("select docDetId from DocDetails where docId=" + docId))
            {
                int detMaxId = Convert.ToInt32(c.GetReqData("DocDetails", "docDetId", "docId=" + docId));
                c.ExecuteQuery("Update DocDetails Set Qualification='" + txtQual.Text + "', YOE=" + txtExp.Text + ", HospName='" + txtHosp.Text + "', HospAddr='" + txtAddr.Text + "', Specialty='" + ddrSpecialty.SelectedValue + "' Where docDetId=" + detMaxId);

                if (txtExp.Text != "")
                    c.ExecuteQuery("Update DocDetails Set YOE=" + txtExp.Text + " Where docDetId=" + detMaxId);

                if (txtMNO.Text != "")
                    c.ExecuteQuery("Update DoctorsData Set docMOB='" + txtMNO.Text + "' Where docId=" + docId);

                if (ddrCity.SelectedValue != "")
                    c.ExecuteQuery("Update DoctorsData Set cityId=" + ddrCity.SelectedValue + " Where docId=" + docId);

            }
            else
            {
                int detMaxId = c.NextId("DocDetails", "docDetId");
                c.ExecuteQuery("Insert into DocDetails (docDetId, docId, Qualification, HospName, HospAddr, Specialty) values (" + detMaxId + ", " + docId + ", '" + txtQual.Text + "', '" + txtHosp.Text + "', '" + txtAddr.Text + "', '" + ddrSpecialty.SelectedValue + "')");
            }
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myScriptASDSasjkdhnAD", "toastr.success('Profile Updated','Success');", true);

        
        }
        catch (Exception)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myScriptASURLH", "toastr.error('Error Occured','Error');", true);
            return;
        }
    }
    private void GetDoctorsDetails()
    {
        try
        {
            arrSession = (string[])Session["docSession"];
            docId = Convert.ToInt32(arrSession[1]);

            DataTable dtDoc = c.GetDataTable("select * from DoctorsData where docId=" + docId);
            DataRow row = dtDoc.Rows[0];

            txtFN.Text = row["docFName"].ToString();
            txtLN.Text = row["docLName"].ToString();
            ddrCity.Text = row["cityId"].ToString();
            ddrGender.Text = row["docGender"].ToString();
            txtEmailId.Text = row["docEmail"].ToString();
            txtMNO.Text = row["docMOB"].ToString();

            if (c.IsRecordExist("select * from DocDetails where docId=" + docId))
            {
                DataTable dtDocdtl = c.GetDataTable("select * from DocDetails where docId=" + docId);
                DataRow row1 = dtDocdtl.Rows[0];

                txtQual.Text = row1["Qualification"].ToString();
                txtExp.Text = row1["YOE"].ToString();
                txtHosp.Text = row1["HospName"].ToString();
                txtAddr.Text = row1["HospAddr"].ToString();
                ddrSpecialty.SelectedValue = row1["Specialty"].ToString();
            }

        }
        catch (Exception)
        {

            throw;
        }
    }

}