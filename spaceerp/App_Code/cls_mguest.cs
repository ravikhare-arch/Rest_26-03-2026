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
public class mguest_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnGuestID = string.Empty;
    private string objnCompanyID = string.Empty;
    private string objsSerialNo = string.Empty;
    private string objsGuestName = string.Empty;
    private string objsAddress = string.Empty;
    private string objnCountryID = string.Empty;
    private string objnCityID = string.Empty;
    private string objsTelephone = string.Empty;
    private string objsFax = string.Empty;
    private string objsMobile = string.Empty;
    private string objsEmail = string.Empty;
    private string objsRemarks = string.Empty;
    private string objnConfigID = string.Empty;
    public string nGuestID
    {
        get { return objnGuestID; }
        set { objnGuestID = value; }
    }
    public string nCompanyID
    {
        get { return objnCompanyID; }
        set { objnCompanyID = value; }
    }
    public string sSerialNo
    {
        get { return objsSerialNo; }
        set { objsSerialNo = value; }
    }
    public string sGuestName
    {
        get { return objsGuestName; }
        set { objsGuestName = value; }
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
    public string sFax
    {
        get { return objsFax; }
        set { objsFax = value; }
    }
    public string sMobile
    {
        get { return objsMobile; }
        set { objsMobile = value; }
    }
    public string sEmail
    {
        get { return objsEmail; }
        set { objsEmail = value; }
    }
    public string sRemarks
    {
        get { return objsRemarks; }
        set { objsRemarks = value; }
    }
    public string nConfigID
    {
        get { return objnConfigID; }
        set { objnConfigID = value; }
    }
    public string User_Operation(mguest_Class mguest_Class, string type)
    {
        SqlCommand cmd = addParameter(mguest_Class, type, "");
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
    public SqlCommand addParameter(mguest_Class mguest_Class, string type, string cond)
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
        SqlCommand cmd = new SqlCommand("SP_mguest", conn); cmd.Parameters.AddWithValue("@nGuestID", mguest_Class.nGuestID);
        cmd.Parameters.AddWithValue("@nCompanyID", mguest_Class.nCompanyID);
        cmd.Parameters.AddWithValue("@sSerialNo", mguest_Class.sSerialNo);
        cmd.Parameters.AddWithValue("@sGuestName", mguest_Class.sGuestName);
        cmd.Parameters.AddWithValue("@sAddress", mguest_Class.sAddress);
        cmd.Parameters.AddWithValue("@nCountryID", mguest_Class.nCountryID);
        cmd.Parameters.AddWithValue("@nCityID", mguest_Class.nCityID);
        cmd.Parameters.AddWithValue("@sTelephone", mguest_Class.sTelephone);
        cmd.Parameters.AddWithValue("@sFax", mguest_Class.sFax);
        cmd.Parameters.AddWithValue("@sMobile", mguest_Class.sMobile);
        cmd.Parameters.AddWithValue("@sEmail", mguest_Class.sEmail);
        cmd.Parameters.AddWithValue("@sRemarks", mguest_Class.sRemarks);
        cmd.Parameters.AddWithValue("@nConfigID", nConfigID);

        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(mguest_Class mguest_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(mguest_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(mguest_Class mguest_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(mguest_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(mguest_Class mguest_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(mguest_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewmguest");
            return ds.Tables["viewmguest"];
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
    public DropDownList ddlOperation(mguest_Class mguest_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(mguest_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewmguest");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a guest", "0"));
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
