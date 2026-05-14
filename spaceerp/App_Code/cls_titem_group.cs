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
public class titem_group_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnItemGroupID = string.Empty;
    private string objnItemDetailsID = string.Empty;
    private string objsItemName = string.Empty;
    private string objnQty = string.Empty;
    private string objnSalePrice = string.Empty;
    private string objnConfigID = string.Empty;
    public string nItemGroupID
    {
        get { return objnItemGroupID; }
        set { objnItemGroupID = value; }
    }
    public string nItemDetailsID
    {
        get { return objnItemDetailsID; }
        set { objnItemDetailsID = value; }
    }
    public string sItemName
    {
        get { return objsItemName; }
        set { objsItemName = value; }
    }
    public string nQty
    {
        get { return objnQty; }
        set { objnQty = value; }
    }
    public string nSalePrice
    {
        get { return objnSalePrice; }
        set { objnSalePrice = value; }
    }
    public string nConfigID
    {
        get { return objnConfigID; }
        set { objnConfigID = value; }
    }
    public string User_Operation(titem_group_Class titem_group_Class, string type)
    {
        SqlCommand cmd = addParameter(titem_group_Class, type, "");
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
    public SqlCommand addParameter(titem_group_Class titem_group_Class, string type, string cond)
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
        SqlCommand cmd = new SqlCommand("SP_titem_group", conn); cmd.Parameters.AddWithValue("@nItemGroupID", titem_group_Class.nItemGroupID);
        cmd.Parameters.AddWithValue("@nItemDetailsID", titem_group_Class.nItemDetailsID);
        cmd.Parameters.AddWithValue("@sItemName", titem_group_Class.sItemName);
        cmd.Parameters.AddWithValue("@nQty", titem_group_Class.nQty);
        cmd.Parameters.AddWithValue("@nSalePrice", titem_group_Class.nSalePrice);
        cmd.Parameters.AddWithValue("@nConfigID", ConfigID);

        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(titem_group_Class titem_group_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(titem_group_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(titem_group_Class titem_group_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(titem_group_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(titem_group_Class titem_group_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(titem_group_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewtitem_group");
            return ds.Tables["viewtitem_group"];
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
    public DropDownList ddlOperation(titem_group_Class titem_group_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(titem_group_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewtitem_group");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a item_group", "0"));
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
