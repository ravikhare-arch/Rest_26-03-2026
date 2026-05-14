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
public class msupgst_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnSupGstID = string.Empty;
    private string objnSupplierID = string.Empty;
    private string objnSupIGST = string.Empty;
    private string objnSupCGST = string.Empty;
    private string objnSupSGST = string.Empty;
    private string objnConfigID = string.Empty;
    public string nSupGstID
    {
        get { return objnSupGstID; }
        set { objnSupGstID = value; }
    }
    public string nSupplierID
    {
        get { return objnSupplierID; }
        set { objnSupplierID = value; }
    }
    public string nSupIGST
    {
        get { return objnSupIGST; }
        set { objnSupIGST = value; }
    }
    public string nSupCGST
    {
        get { return objnSupCGST; }
        set { objnSupCGST = value; }
    }
    public string nSupSGST
    {
        get { return objnSupSGST; }
        set { objnSupSGST = value; }
    }
    public string nConfigID
    {
        get { return objnConfigID; }
        set { objnConfigID = value; }
    }
    public string User_Operation(msupgst_Class msupgst_Class, string type)
    {
        SqlCommand cmd = addParameter(msupgst_Class, type, "");
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
    public SqlCommand addParameter(msupgst_Class msupgst_Class, string type, string cond)
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
        SqlCommand cmd = new SqlCommand("SP_msupgst", conn); cmd.Parameters.AddWithValue("@nSupGstID", msupgst_Class.nSupGstID);
        cmd.Parameters.AddWithValue("@nSupplierID", msupgst_Class.nSupplierID);
        cmd.Parameters.AddWithValue("@nSupIGST", msupgst_Class.nSupIGST);
        cmd.Parameters.AddWithValue("@nSupCGST", msupgst_Class.nSupCGST);
        cmd.Parameters.AddWithValue("@nSupSGST", msupgst_Class.nSupSGST);
        cmd.Parameters.AddWithValue("@nConfigID", ConfigID);

        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(msupgst_Class msupgst_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(msupgst_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(msupgst_Class msupgst_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(msupgst_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(msupgst_Class msupgst_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(msupgst_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewmsupgst");
            return ds.Tables["viewmsupgst"];
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
    public DropDownList ddlOperation(msupgst_Class msupgst_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(msupgst_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewmsupgst");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a supgst", "0"));
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
