using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class search_doctor : System.Web.UI.Page
{
    iClass c = new iClass();
    public string resultMarkup;
    protected void Page_Load(object sender, EventArgs e)
    {

    }




    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtSearch.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "sdfgjkjkkjkdf", "toastr.warning('Enter Doctor name or specialty','warning');", true);
                return;
            }
            string searchCriteria = txtSearch.Text;

            string strQuery = "select * from DoctorsData where (docFName='" + searchCriteria + "' Or docLName='" + searchCriteria + "' OR docFName + ' ' + docLName='" + searchCriteria + "' )" +
                " Or (docFName Like '%" + searchCriteria + "&' Or docLName Like '%" + searchCriteria + "%' OR docFName + ' ' + docLName Like '%" + searchCriteria + "%')";

            StringBuilder strMarkup = new StringBuilder();
            using (DataTable dtResults = c.GetDataTable(strQuery))
            {
                foreach (DataRow row in dtResults.Rows)
                {
                    strMarkup.Append("<div class=\"col_1_6\">"+ row["docFName"].ToString()  +"</div>");
                }
            }

            resultMarkup = strMarkup.ToString();
            //if (c.IsRecordExist("select * from DoctorsData where docFName='" + searchCriteria + "' Or docLName='" + searchCriteria + "' OR docFName + ' ' + docLName='" + searchCriteria + "' "))
            //{

            //}
        }
        catch (Exception)
        {

            throw;
        }
    }
}