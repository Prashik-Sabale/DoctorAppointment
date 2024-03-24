using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Doctor_Default : System.Web.UI.Page
{
    iClass c = new iClass();
    public string docName;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["docSession"] != null)
        {
            string[] arrDoctor = (string[])Session["docSession"];

            if (arrDoctor[0] == "1")
            {
                int docId = Convert.ToInt32(arrDoctor[1]);

                docName = c.GetReqData("DoctorsData", "docFName", "docId=" + docId).ToString();

            }
            else
            {
                //Session["docSession"] = null;
                //Response.Redirect()
            }
        }
    }
}