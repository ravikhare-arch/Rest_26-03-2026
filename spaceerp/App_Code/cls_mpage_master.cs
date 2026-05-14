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
public class mpage_master_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnPageMasterID = string.Empty;
    private string objsPageMasterName = string.Empty;
    private string objnModuleID = string.Empty;
    private string objsPageMasterDescription = string.Empty;
    private string objsPageUrl = string.Empty;
    private string objnConfigID = string.Empty;
    private string objModuleGroupID = string.Empty;

    public string nPageMasterID
    {
        get { return objnPageMasterID; }
        set { objnPageMasterID = value; }
    }
    public string sPageMasterName
    {
        get { return objsPageMasterName; }
        set { objsPageMasterName = value; }
    }
    public string nModuleID
    {
        get { return objnModuleID; }
        set { objnModuleID = value; }
    }
    public string sPageMasterDescription
    {
        get { return objsPageMasterDescription; }
        set { objsPageMasterDescription = value; }
    }
    public string sPageUrl
    {
        get { return objsPageUrl; }
        set { objsPageUrl = value; }
    }
    public string nConfigID
    {
        get { return objnConfigID; }
        set { objnConfigID = value; }
    }
    public string ModuleGroupID
    {
        get { return objModuleGroupID;}
        set { objModuleGroupID = value; }
    }
    public string User_Operation(mpage_master_Class mpage_master_Class, string type)
    {
        SqlCommand cmd = addParameter(mpage_master_Class, type, "");
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
    public SqlCommand addParameter(mpage_master_Class mpage_master_Class, string type, string cond)
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
        SqlCommand cmd = new SqlCommand("SP_mpage_master", conn); cmd.Parameters.AddWithValue("@nPageMasterID", mpage_master_Class.nPageMasterID);
        cmd.Parameters.AddWithValue("@sPageMasterName", mpage_master_Class.sPageMasterName);
        cmd.Parameters.AddWithValue("@nModuleID", mpage_master_Class.nModuleID);
        cmd.Parameters.AddWithValue("@sPageMasterDescription", mpage_master_Class.sPageMasterDescription);
        cmd.Parameters.AddWithValue("@sPageUrl", mpage_master_Class.sPageUrl);
        cmd.Parameters.AddWithValue("@ModuleGroupID", mpage_master_Class.ModuleGroupID);
        cmd.Parameters.AddWithValue("@nConfigID", nConfigID);

        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(mpage_master_Class mpage_master_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(mpage_master_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(mpage_master_Class mpage_master_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(mpage_master_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(mpage_master_Class mpage_master_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(mpage_master_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewmpage_master");
            return ds.Tables["viewmpage_master"];
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
    public DropDownList ddlOperation(mpage_master_Class mpage_master_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(mpage_master_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewmpage_master");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a page_master", "0"));
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
    public DataTable Tabledata(mpage_master_Class mpage_master_Class, string type, string cond)
    {
        DataTable da = new DataTable();
        try
        {
            da = viewData(mpage_master_Class, type, cond);
            //grd.DataSource = da;
            //grd.DataBind();
            //if (grd.HeaderRow != null)
            //    grd.HeaderRow.TableSection = TableRowSection.TableHeader;

        }
        catch
        {

        }
        return da;
    }
}
