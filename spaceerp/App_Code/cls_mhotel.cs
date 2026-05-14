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
public class mhotel_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnHotelID = string.Empty;
    private string objsHotelName = string.Empty;
    private string objsContactPerson = string.Empty;
    private string objsAddress = string.Empty;
    private string objnCountryID = string.Empty;
    private string objnCityID = string.Empty;
    private string objsTelephone = string.Empty;
    private string objsMobile = string.Empty;
    private string objsFax = string.Empty;
    private string objsEmail = string.Empty;
    private string objsWebsite = string.Empty;
    private string objsRating = string.Empty;
    private string objnConfigID = string.Empty;
    public string nHotelID
    {
        get { return objnHotelID; }
        set { objnHotelID = value; }
    }
    public string sHotelName
    {
        get { return objsHotelName; }
        set { objsHotelName = value; }
    }
    public string sContactPerson
    {
        get { return objsContactPerson; }
        set { objsContactPerson = value; }
    }
    public string sAddress
    {
        get { return objsAddress; }
        set { objsAddress = value; }
    }
    public string nCountryID
    {
        get { return objnCountryID; }
        set { objnCountryID = value; }
    }
    public string nCityID
    {
        get { return objnCityID; }
        set { objnCityID = value; }
    }
    public string sTelephone
    {
        get { return objsTelephone; }
        set { objsTelephone = value; }
    }
    public string sMobile
    {
        get { return objsMobile; }
        set { objsMobile = value; }
    }
    public string sFax
    {
        get { return objsFax; }
        set { objsFax = value; }
    }
    public string sEmail
    {
        get { return objsEmail; }
        set { objsEmail = value; }
    }
    public string sWebsite
    {
        get { return objsWebsite; }
        set { objsWebsite = value; }
    }
    public string sRating
    {
        get { return objsRating; }
        set { objsRating = value; }
    }
    public string nConfigID
    {
        get { return objnConfigID; }
        set { objnConfigID = value; }
    }
    public string User_Operation(mhotel_Class mhotel_Class, string type)
    {
        SqlCommand cmd = addParameter(mhotel_Class, type, "");
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
    public SqlCommand addParameter(mhotel_Class mhotel_Class, string type, string cond)
    {
        string uid, nConfigID;
        if (Session["uid"] == null)
            uid = "0";
        else
            uid = Session["uid"].ToString();

        if (Session["ConfigID"] == null)
            nConfigID = "0";
        else
            nConfigID = Session["ConfigID"].ToString();
        conn = connobj.makeConnection();
        SqlCommand cmd = new SqlCommand("SP_mhotel", conn); cmd.Parameters.AddWithValue("@nHotelID", mhotel_Class.nHotelID);
        cmd.Parameters.AddWithValue("@sHotelName", mhotel_Class.sHotelName);
        cmd.Parameters.AddWithValue("@sContactPerson", mhotel_Class.sContactPerson);
        cmd.Parameters.AddWithValue("@sAddress", mhotel_Class.sAddress);
        cmd.Parameters.AddWithValue("@nCountryID", mhotel_Class.nCountryID);
        cmd.Parameters.AddWithValue("@nCityID", mhotel_Class.nCityID);
        cmd.Parameters.AddWithValue("@sTelephone", mhotel_Class.sTelephone);
        cmd.Parameters.AddWithValue("@sMobile", mhotel_Class.sMobile);
        cmd.Parameters.AddWithValue("@sFax", mhotel_Class.sFax);
        cmd.Parameters.AddWithValue("@sEmail", mhotel_Class.sEmail);
        cmd.Parameters.AddWithValue("@sWebsite", mhotel_Class.sWebsite);
        cmd.Parameters.AddWithValue("@sRating", mhotel_Class.sRating);
        cmd.Parameters.AddWithValue("@nConfigID", nConfigID);

        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(mhotel_Class mhotel_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(mhotel_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(mhotel_Class mhotel_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(mhotel_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(mhotel_Class mhotel_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(mhotel_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewmhotel");
            return ds.Tables["viewmhotel"];
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
    public DropDownList ddlOperation(mhotel_Class mhotel_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(mhotel_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewmhotel");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a hotel", "0"));
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
