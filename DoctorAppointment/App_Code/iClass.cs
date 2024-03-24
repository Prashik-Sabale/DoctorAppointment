using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for iClass
/// </summary>
public class iClass
{
    public iClass()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string OpenConnection()
    {
        return System.Web.Configuration.WebConfigurationManager.ConnectionStrings["AppointmentDB"].ConnectionString;
    }

    public void ExecuteQuery(string strQuery)
    {
        try
        {
            SqlConnection con = new SqlConnection(OpenConnection());
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            con = null;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public int NextId(string tableName, string fieldName)
    {
        try
        {
            int retValue = 1;
            SqlConnection con = new SqlConnection(OpenConnection());
            con.Open();
            SqlCommand cmd = new SqlCommand();

            SqlDataReader dr = default(SqlDataReader);
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select MAX(" + fieldName + ") as maxNo From " + tableName;
            dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    if ((dr["maxNo"]) != System.DBNull.Value)
                    {
                        retValue = Convert.ToInt32(dr["maxNo"]) + 1;
                    }
                    else
                    {
                        retValue = 1;
                    }
                }
            }
            else
            {
                retValue = 1;
            }
            dr.Close();
            cmd.Dispose();
            con.Close();
            con = null;
            return retValue;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public bool IsNumeric(string num)
    {
        try
        {

            bool rValue;
            double result;
            bool isNum = double.TryParse(num, out result);
            if (isNum)
            {
                rValue = true;
            }
            else
            {
                rValue = false;
            }
            return rValue;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetDataTable(string strQuery)
    {
        try
        {
            SqlConnection con = new SqlConnection(OpenConnection());

            SqlDataAdapter da = new SqlDataAdapter(strQuery, con);
            DataTable dt = new DataTable();

            da.Fill(dt);

            con.Close();
            con = null;

            return dt;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    public string ReturnHttp()
    {
        try
        {
            string rValue = null;
            //string domain = "https://" + HttpContext.Current.Request.ServerVariables["HTTP_HOST"];
            string domain = "http://" + HttpContext.Current.Request.ServerVariables["HTTP_HOST"];
            string localFolder;
            if (domain.Contains("localhost") == true)
            {
                localFolder = "/";
                //localFolder = "/lucidEdge/";
            }
            else
            {
                localFolder = "/";
            }

            rValue = domain + localFolder;

            return rValue;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public string EncryptData(string originalStr)
    {
        try
        {
            string strmsg = string.Empty;
            byte[] encode = new byte[originalStr.Length];
            encode = Encoding.UTF8.GetBytes(originalStr);
            strmsg = Convert.ToBase64String(encode);
            strmsg = strmsg.Replace("=", "");
            return strmsg;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public bool EmailAddressCheck(string email)
    {
        Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        Match match = regex.Match(email);
        if (match.Success)
            return true;
        else
            return false;
    }

    /// <summary>
    /// Used to get single value from databse table
    /// </summary>
    /// <param name="tableName">Name of Database Table</param>
    /// <param name="fieldName">Naem of Column</param>
    /// <param name="whereCon">Where Condition</param>
    /// <returns>Value as object</returns>
    public object GetReqData(string tableName, string fieldName, string whereCon)
    {
        try
        {
            object retValue = null;
            SqlConnection con = new SqlConnection(OpenConnection());
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = default(SqlDataReader);
            cmd.CommandText = whereCon == "" ? "Select " + fieldName + " as colName From " + tableName : "Select " + fieldName + " as colName From " + tableName + " Where " + whereCon;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr["colName"] == DBNull.Value)
                {
                    retValue = null;
                }
                else
                {
                    retValue = dr["colName"];
                }

            }
            dr.Close();
            cmd.Dispose();
            con.Close();
            con = null;
            return retValue;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// Used to check if record exists or not
    /// </summary>
    /// <param name="strQuery">SQL Query as string</param>
    /// <returns>True/False</returns>
    public bool IsRecordExist(string strQuery)
    {
        try
        {

            bool rValue = false;
            SqlConnection con = new SqlConnection(OpenConnection());
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = default(SqlDataReader);

            cmd.CommandText = strQuery;
            dr = cmd.ExecuteReader();

            rValue = dr.HasRows;
            dr.Close();
            cmd.Dispose();
            con.Close();
            con = null;

            return rValue;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    /// <summary>
    /// Used to fill DropDownList
    /// </summary>
    /// <param name="speName">Display Contents(Column Name)</param>
    /// <param name="speID">Value Content(Column Name)</param>
    /// <param name="SpecialitiesData">Database Table Name</param>
    /// <param name="whereCond">Specific Condition (SQL Where Condition)</param>
    /// <param name="ddrSpecialty">Name of DropDownList</param>
    public void FillComboBox(string speName, string speID, string SpecialitiesData, string delMark, string sortColumn, int ordType, DropDownList ddrSpecialty)
    {
        try
        {
            SqlConnection con = new SqlConnection(OpenConnection());
            string strSql = "";
            if (delMark == "1")
            {
                if (sortColumn == "")
                {
                    strSql = "SELECT " + speName + ", " + speID + " From " + SpecialitiesData;
                }
                else
                {
                    if (ordType == 0)
                    {
                        strSql = "SELECT " + speName + ", " + speID + " From " + SpecialitiesData + " Order By " + sortColumn;
                    }
                    else
                    {
                        strSql = "SELECT " + speName + ", " + speID + " From " + SpecialitiesData + " Order By " + sortColumn + " Desc";
                    }
                }
            }
            else
            {
                if (sortColumn == "")
                {
                    strSql = "SELECT " + speName + ", " + speID + " From " + SpecialitiesData + " Where " + delMark;
                }
                else
                {
                    if (ordType == 0)
                    {
                        strSql = "SELECT " + speName + ", " + speID + " From " + SpecialitiesData + " Where " + delMark + " Order By " + sortColumn;
                    }
                    else
                    {
                        strSql = "SELECT " + speName + ", " + speID + " From " + SpecialitiesData + " Where " + delMark + " Order By " + sortColumn + " Desc";
                    }
                }

            }
            SqlDataAdapter da = new SqlDataAdapter(strSql, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "myCombo");
            ddrSpecialty.DataSource = ds.Tables[0];
            ddrSpecialty.DataTextField = ds.Tables[0].Columns[speName].ColumnName.ToString();
            ddrSpecialty.DataValueField = ds.Tables[0].Columns[speID].ColumnName.ToString();
            ddrSpecialty.DataBind();

            ddrSpecialty.Items.Insert(0, "<-Select->");
            ddrSpecialty.Items[0].Value = "0";

            con.Close();
            con = null;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}