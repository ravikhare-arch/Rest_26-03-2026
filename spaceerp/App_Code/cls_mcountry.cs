using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
public class mCountry_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnCountryID = string.Empty;
    private string objsCountryName = string.Empty;
    private string objsLanguage = string.Empty;
    private string objsCapital = string.Empty;
    private string objsContinent = string.Empty;
    public string nCountryID
    {
        get { return objnCountryID; }
        set { objnCountryID = value; }
    }
    public string sCountryName
    {
        get { return objsCountryName; }
        set { objsCountryName = value; }
    }
    public string sLanguage
    {
        get { return objsLanguage; }
        set { objsLanguage = value; }
    }
    public string sCapital
    {
        get { return objsCapital; }
        set { objsCapital = value; }
    }
    public string sContinent
    {
        get { return objsContinent; }
        set { objsContinent = value; }
    }
    public string User_Operation(mCountry_Class mCountry_Class, string type)
    {
        SqlCommand cmd = addParameter(mCountry_Class, type, "");
        try
        {
            //cmd.ExecuteNonQuery();
            returnValue = cmd.ExecuteScalar().ToString();
        }
        catch (Exception ex)
        {
            //throw;
            returnValue = ex.Message.ToString();
        }
        finally
        {
            cmd.Dispose();
            conn = connobj.closeConnection();
        }
        return returnValue;
    }
    public SqlCommand addParameter(mCountry_Class mCountry_Class, string type, string cond)
    {
        string uid, ConfigID;
        if (Session["uid"] == null)
            uid = "0";
        else
            uid = Session["uid"].ToString();


        if (Session["ConfigID"] == null)
            ConfigID = "0";
        else
            ConfigID = Session["ConfigID"].ToString();

        conn = connobj.makeConnection();
        SqlCommand cmd = new SqlCommand("SP_mcountry", conn); cmd.Parameters.AddWithValue("@nCountryID", mCountry_Class.nCountryID);
        cmd.Parameters.AddWithValue("@sCountryName", mCountry_Class.sCountryName);
        cmd.Parameters.AddWithValue("@sLanguage", mCountry_Class.sLanguage);
        cmd.Parameters.AddWithValue("@sCapital", mCountry_Class.sCapital);
        cmd.Parameters.AddWithValue("@sContinent", mCountry_Class.sContinent);
        cmd.Parameters.AddWithValue("@nConfigID", ConfigID);
        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(mCountry_Class mCountry_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(mCountry_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(mCountry_Class mCountry_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(mCountry_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(mCountry_Class mCountry_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(mCountry_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewmCountry");
            return ds.Tables["viewmCountry"];
        }
        catch
        {
            throw;
        }
        finally
        {
            cmd.Dispose();
            conn = connobj.closeConnection();
        }
    }
    public DropDownList ddlOperation(mCountry_Class mCountry_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(mCountry_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewmCountry");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a Country", "0"));
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ddl.Items.Add(new ListItem(ds.Tables[0].Rows[i][1].ToString(), ds.Tables[0].Rows[i][0].ToString()));
            }
        }
        else
        {
            ddl.Items.Add(new ListItem("Not Found", "0"));
        }
        cmd.Dispose();
        conn = connobj.closeConnection();
        return ddl;
    }

}
