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
public class mgst_setting_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnGstSettingID = string.Empty;
    private string objnLocationID = string.Empty;
    private string objnIGST = string.Empty;
    private string objnCGST = string.Empty;
    private string objnSGST = string.Empty;
    private string objnConfigID = string.Empty;
    public string nGstSettingID
    {
        get { return objnGstSettingID; }
        set { objnGstSettingID = value; }
    }
    public string nLocationID
    {
        get { return objnLocationID; }
        set { objnLocationID = value; }
    }
    public string nIGST
    {
        get { return objnIGST; }
        set { objnIGST = value; }
    }
    public string nCGST
    {
        get { return objnCGST; }
        set { objnCGST = value; }
    }
    public string nSGST
    {
        get { return objnSGST; }
        set { objnSGST = value; }
    }
    public string nConfigID
    {
        get { return objnConfigID; }
        set { objnConfigID = value; }
    }
    public string User_Operation(mgst_setting_Class mgst_setting_Class, string type)
    {
        SqlCommand cmd = addParameter(mgst_setting_Class, type, "");
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
    public SqlCommand addParameter(mgst_setting_Class mgst_setting_Class, string type, string cond)
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
        SqlCommand cmd = new SqlCommand("SP_mgst_setting", conn); cmd.Parameters.AddWithValue("@nGstSettingID", mgst_setting_Class.nGstSettingID);
        cmd.Parameters.AddWithValue("@nLocationID", mgst_setting_Class.nLocationID);
        cmd.Parameters.AddWithValue("@nIGST", mgst_setting_Class.nIGST);
        cmd.Parameters.AddWithValue("@nCGST", mgst_setting_Class.nCGST);
        cmd.Parameters.AddWithValue("@nSGST", mgst_setting_Class.nSGST);
        cmd.Parameters.AddWithValue("@nConfigID", nConfigID);

        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(mgst_setting_Class mgst_setting_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(mgst_setting_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(mgst_setting_Class mgst_setting_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(mgst_setting_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(mgst_setting_Class mgst_setting_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(mgst_setting_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewmgst_setting");
            return ds.Tables["viewmgst_setting"];
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
    public DropDownList ddlOperation(mgst_setting_Class mgst_setting_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(mgst_setting_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewmgst_setting");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a gst_setting", "0"));
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
