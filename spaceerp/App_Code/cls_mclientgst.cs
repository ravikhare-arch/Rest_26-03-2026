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
public class mclientgst_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnClntGstID = string.Empty;
    private string objnClientID = string.Empty;
    private string objnClntIGST = string.Empty;
    private string objnClntCGST = string.Empty;
    private string objnClntSGST = string.Empty;
    private string objnConfigID = string.Empty;
    public string nClntGstID
    {
        get { return objnClntGstID; }
        set { objnClntGstID = value; }
    }
    public string nClientID
    {
        get { return objnClientID; }
        set { objnClientID = value; }
    }
    public string nClntIGST
    {
        get { return objnClntIGST; }
        set { objnClntIGST = value; }
    }
    public string nClntCGST
    {
        get { return objnClntCGST; }
        set { objnClntCGST = value; }
    }
    public string nClntSGST
    {
        get { return objnClntSGST; }
        set { objnClntSGST = value; }
    }
    public string nConfigID
    {
        get { return objnConfigID; }
        set { objnConfigID = value; }
    }
    public string User_Operation(mclientgst_Class mclientgst_Class, string type)
    {
        SqlCommand cmd = addParameter(mclientgst_Class, type, "");
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
    public SqlCommand addParameter(mclientgst_Class mclientgst_Class, string type, string cond)
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
        SqlCommand cmd = new SqlCommand("SP_mclientgst", conn); cmd.Parameters.AddWithValue("@nClntGstID", mclientgst_Class.nClntGstID);
        cmd.Parameters.AddWithValue("@nClientID", mclientgst_Class.nClientID);
        cmd.Parameters.AddWithValue("@nClntIGST", mclientgst_Class.nClntIGST);
        cmd.Parameters.AddWithValue("@nClntCGST", mclientgst_Class.nClntCGST);
        cmd.Parameters.AddWithValue("@nClntSGST", mclientgst_Class.nClntSGST);
        cmd.Parameters.AddWithValue("@nConfigID", nConfigID);

        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(mclientgst_Class mclientgst_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(mclientgst_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(mclientgst_Class mclientgst_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(mclientgst_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(mclientgst_Class mclientgst_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(mclientgst_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewmclientgst");
            return ds.Tables["viewmclientgst"];
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
    public DropDownList ddlOperation(mclientgst_Class mclientgst_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(mclientgst_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewmclientgst");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a clientgst", "0"));
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
