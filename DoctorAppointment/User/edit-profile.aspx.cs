using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_edit_profile : System.Web.UI.Page
{
    iClass c = new iClass();
    string[] arrSession = new string[2];
    int userId;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["userSession"] != null)
            {

                GetUsersDetails();
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            ddrGender.SelectedValue = ddrGender.SelectedValue.Trim().Replace("'", "`");
            ddrCity.SelectedValue = ddrCity.SelectedValue.Trim().Replace("'", "`");
            txtEmailId.Text = txtEmailId.Text.Trim().Replace("'", "`");
            txtAge.Text = txtAge.Text.Trim().Replace("'", "`");


            arrSession = (string[])Session["userSession"];
            userId = Convert.ToInt32(arrSession[1]);

            if (c.IsRecordExist("select userDetId from UserDetails where userId=" + userId))
            {
                int detMaxId = Convert.ToInt32(c.GetReqData("UserDetails", "userDetId", "userId=" + userId));
                c.ExecuteQuery("Update UserDetails Set cityId='" + ddrCity.SelectedValue + "', userGender=" + ddrGender.SelectedValue + ", userEmail='" + txtEmailId.Text + "', userAge='" + txtAge.Text + "' Where userDetId=" + detMaxId);

                if (ddrGender.SelectedValue != "")
                    c.ExecuteQuery("Update UserDetails Set userGender=" + ddrGender.SelectedValue + " Where userDetId=" + detMaxId);

                if (txtEmailId.Text != "")
                    c.ExecuteQuery("Update UserDetails Set userEmail='" + txtEmailId.Text + "' Where userId=" + userId);

                if (ddrCity.SelectedValue != "")
                    c.ExecuteQuery("Update UserDetails Set cityId=" + ddrCity.SelectedValue + " Where userId=" + userId);

                if (txtAge.Text != "")
                    c.ExecuteQuery("Update UserDetails Set userAge=" + txtAge.Text + " Where userDetId=" + detMaxId);

            }
            else
            {
                int detMaxId = c.NextId("UserDetails", "userDetId");
                c.ExecuteQuery("Insert into UserDetails (userDetId, userId, userGender, userEmail, cityId, userAge) values (" + detMaxId + ", " + userId + ", '" + ddrGender.SelectedValue + "', '" + txtEmailId.Text + "', '" + ddrCity.SelectedValue + "', '" + txtAge.Text + "')");

            }
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myScriptASDSasjkdhnAD", "toastr.success('Profile Updated','Success');", true);

        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myScriptAisahkdhnAD", "toastr.error('Error Occured','Error');", true);
            return;
        }
    }

    private void GetUsersDetails()
    {
        try
        {
            arrSession = (string[])Session["userSession"];
            userId = Convert.ToInt32(arrSession[1]);

            DataTable dtUser = c.GetDataTable("select * from UsersData where userId=" + userId);
            DataRow row = dtUser.Rows[0];

            txtFN.Text = row["userFullName"].ToString();
            txtMNO.Text = row["userMOB"].ToString();

            if (c.IsRecordExist("select * from UserDetails where userId=" + userId))
            {
                DataTable dtUserdtl = c.GetDataTable("select * from UserDetails where userId=" + userId);
                DataRow row1 = dtUserdtl.Rows[0];

                txtAge.Text = row1["userAge"].ToString();
                ddrCity.SelectedValue = row1["cityId"].ToString();
                ddrGender.SelectedValue = row1["userGender"].ToString();
                txtEmailId.Text = row1["userEmail"].ToString();
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
}