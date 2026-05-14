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
public class mmodule_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnModuleID = string.Empty;
    private string objsModuleName = string.Empty;
    private string objsModuleDescription = string.Empty;
    private string objnConfigID = string.Empty;
    public string nModuleID
    {
        get { return objnModuleID; }
        set { objnModuleID = value; }
    }
    public string sModuleName
    {
        get { return objsModuleName; }
        set { objsModuleName = value; }
    }
    public string sModuleDescription
    {
        get { return objsModuleDescription; }
        set { objsModuleDescription = value; }
    }
    public string nConfigID
    {
        get { return objnConfigID; }
        set { objnConfigID = value; }
    }
    public string bActive { get; set; }
    public string User_Operation(mmodule_Class mmodule_Class, string type)
    {
        SqlCommand cmd = addParameter(mmodule_Class, type, "");
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
    public SqlCommand addParameter(mmodule_Class mmodule_Class, string type, string cond)
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
        SqlCommand cmd = new SqlCommand("SP_mmodule", conn); cmd.Parameters.AddWithValue("@nModuleID", mmodule_Class.nModuleID);
        cmd.Parameters.AddWithValue("@sModuleName", mmodule_Class.sModuleName);
        cmd.Parameters.AddWithValue("@sModuleDescription", mmodule_Class.sModuleDescription);
        cmd.Parameters.AddWithValue("@bActive", mmodule_Class.bActive);
        cmd.Parameters.AddWithValue("@nConfigID", nConfigID);

        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(mmodule_Class mmodule_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(mmodule_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(mmodule_Class mmodule_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(mmodule_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(mmodule_Class mmodule_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(mmodule_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewmmodule");
            return ds.Tables["viewmmodule"];
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
    public DropDownList ddlOperation(mmodule_Class mmodule_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(mmodule_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewmmodule");
        ddl.Items.Clear();
        ddl.Items.Add(new ListItem("Choose a Module", "0"));
        if (ds.Tables[0].Rows.Count > 0)
        {
            
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
    public DataTable Tabledata(mmodule_Class mmodule_Class, string type, string cond)
    {
        DataTable da = new DataTable();
        try
        {
            da = viewData(mmodule_Class, type, cond);

        }
        catch
        {

        }
        return da;
    }
}
