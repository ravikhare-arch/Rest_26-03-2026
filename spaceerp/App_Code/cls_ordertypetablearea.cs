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
public class OrderTypeTableAreaMapping : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    public string OrderTypeTableAreaID { get; set; }
    public string OrderTypeID { get; set; }
    public string TableID { get; set; }
    public string AreaID { get; set; }
    
    public string User_Operation(OrderTypeTableAreaMapping OrderTypeTableAreaMapping, string type)
    {
        SqlCommand cmd = addParameter(OrderTypeTableAreaMapping, type, "");
        try
        {
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
    public SqlCommand addParameter(OrderTypeTableAreaMapping OrderTypeTableAreaMapping, string type, string cond)
    {
         string uid;
        if (Session["uid"] == null)
            uid = "0";
        else
            uid = Session["uid"].ToString();
        conn = connobj.makeConnection();
        SqlCommand cmd = new SqlCommand("USP_OrderTypeTableAreaMapping", conn);
        cmd.Parameters.AddWithValue("@OrdertypeTableAreaID", OrderTypeTableAreaMapping.OrderTypeTableAreaID);
        cmd.Parameters.AddWithValue("@TableID", OrderTypeTableAreaMapping.TableID);
        cmd.Parameters.AddWithValue("@AreaID", OrderTypeTableAreaMapping.AreaID);
        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.Parameters.AddWithValue("@OrderTypeID", OrderTypeTableAreaMapping.OrderTypeID);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(OrderTypeTableAreaMapping OrderTypeTableAreaMapping, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(OrderTypeTableAreaMapping, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(OrderTypeTableAreaMapping OrderTypeTableAreaMapping, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(OrderTypeTableAreaMapping, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(OrderTypeTableAreaMapping OrderTypeTableAreaMapping, string type, string cond)
    {
        SqlCommand cmd = addParameter(OrderTypeTableAreaMapping, type, cond);
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
    public DropDownList ddlOperation(OrderTypeTableAreaMapping OrderTypeTableAreaMapping, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(OrderTypeTableAreaMapping, Type, cond);
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
    public DataTable Tabledata(OrderTypeTableAreaMapping OrderTypeTableAreaMapping, string type, string cond)
    {
        DataTable da = new DataTable();
        try
        {
            da = viewData(OrderTypeTableAreaMapping, type, cond);
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
