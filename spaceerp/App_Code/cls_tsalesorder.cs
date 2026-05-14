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
public class tsalesorder_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnSalesOrderID = string.Empty;
    private string objsSalesOrderNo = string.Empty;
    private string objnStatusID = string.Empty;
    private string objdtSalesOrder = string.Empty;
    private string objdtDelivery = string.Empty;
    private string objnLocationID = string.Empty;
    private string objsReferenceNo = string.Empty;
    private string objnCustomerNameID = string.Empty;
    private string objbAttention = string.Empty;
    private string objbNote = string.Empty;
    private string objsAttention = string.Empty;
    private string objsNote = string.Empty;
    private string objnShipingCost = string.Empty;
    private string objnOtherCharges = string.Empty;
    private string objnDiscount = string.Empty;
    private string objbPaid = string.Empty;
    private string objnConfigID = string.Empty;
    public string nSalesOrderID
    {
        get { return objnSalesOrderID; }
        set { objnSalesOrderID = value; }
    }
    public string sSalesOrderNo
    {
        get { return objsSalesOrderNo; }
        set { objsSalesOrderNo = value; }
    }
    public string nStatusID
    {
        get { return objnStatusID; }
        set { objnStatusID = value; }
    }
    public string dtSalesOrder
    {
        get { return objdtSalesOrder; }
        set { objdtSalesOrder = value; }
    }
    public string dtDelivery
    {
        get { return objdtDelivery; }
        set { objdtDelivery = value; }
    }
    public string nLocationID
    {
        get { return objnLocationID; }
        set { objnLocationID = value; }
    }
    public string sReferenceNo
    {
        get { return objsReferenceNo; }
        set { objsReferenceNo = value; }
    }
    public string nCustomerNameID
    {
        get { return objnCustomerNameID; }
        set { objnCustomerNameID = value; }
    }
    public string bAttention
    {
        get { return objbAttention; }
        set { objbAttention = value; }
    }
    public string bNote
    {
        get { return objbNote; }
        set { objbNote = value; }
    }
    public string sAttention
    {
        get { return objsAttention; }
        set { objsAttention = value; }
    }
    public string sNote
    {
        get { return objsNote; }
        set { objsNote = value; }
    }
    public string nShipingCost
    {
        get { return objnShipingCost; }
        set { objnShipingCost = value; }
    }
    public string nOtherCharges
    {
        get { return objnOtherCharges; }
        set { objnOtherCharges = value; }
    }
    public string nDiscount
    {
        get { return objnDiscount; }
        set { objnDiscount = value; }
    }
    public string bPaid
    {
        get { return objbPaid; }
        set { objbPaid = value; }
    }
    public string nConfigID
    {
        get { return objnConfigID; }
        set { objnConfigID = value; }
    }
    public string StartDate { get; set; }
    public string EndDate { get; set; }
    public string User_Operation(tsalesorder_Class tsalesorder_Class, string type)
    {
        SqlCommand cmd = addParameter(tsalesorder_Class, type, "");
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
    public SqlCommand addParameter(tsalesorder_Class tsalesorder_Class, string type, string cond)
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
        SqlCommand cmd = new SqlCommand("SP_tsalesorder", conn); cmd.Parameters.AddWithValue("@nSalesOrderID", tsalesorder_Class.nSalesOrderID);
        cmd.Parameters.AddWithValue("@sSalesOrderNo", tsalesorder_Class.sSalesOrderNo);
        cmd.Parameters.AddWithValue("@nStatusID", tsalesorder_Class.nStatusID);
        cmd.Parameters.AddWithValue("@dtSalesOrder", tsalesorder_Class.dtSalesOrder);
        cmd.Parameters.AddWithValue("@dtDelivery", tsalesorder_Class.dtDelivery);
        cmd.Parameters.AddWithValue("@nLocationID", tsalesorder_Class.nLocationID);
        cmd.Parameters.AddWithValue("@sReferenceNo", tsalesorder_Class.sReferenceNo);
        cmd.Parameters.AddWithValue("@nCustomerNameID", tsalesorder_Class.nCustomerNameID);
        cmd.Parameters.AddWithValue("@bAttention", tsalesorder_Class.bAttention);
        cmd.Parameters.AddWithValue("@bNote", tsalesorder_Class.bNote);
        cmd.Parameters.AddWithValue("@sAttention", tsalesorder_Class.sAttention);
        cmd.Parameters.AddWithValue("@sNote", tsalesorder_Class.sNote);
        cmd.Parameters.AddWithValue("@nShipingCost", tsalesorder_Class.nShipingCost);
        cmd.Parameters.AddWithValue("@nOtherCharges", tsalesorder_Class.nOtherCharges);
        cmd.Parameters.AddWithValue("@nDiscount", tsalesorder_Class.nDiscount);
        cmd.Parameters.AddWithValue("@bPaid", tsalesorder_Class.bPaid);
        cmd.Parameters.AddWithValue("@nConfigID", ConfigID);
        cmd.Parameters.AddWithValue("@StartDate", tsalesorder_Class.StartDate);
        cmd.Parameters.AddWithValue("@EndDate", tsalesorder_Class.EndDate);
        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(tsalesorder_Class tsalesorder_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(tsalesorder_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(tsalesorder_Class tsalesorder_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(tsalesorder_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(tsalesorder_Class tsalesorder_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(tsalesorder_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewtsalesorder");
            return ds.Tables["viewtsalesorder"];
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
    public DropDownList ddlOperation(tsalesorder_Class tsalesorder_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(tsalesorder_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewtsalesorder");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a salesorder", "0"));
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
    public DataTable Tabledata(tsalesorder_Class tsalesorder_Class, string type, string cond)
    {
        DataTable da = new DataTable();
        try
        {
            da = viewData(tsalesorder_Class, type, cond);
        }
        catch
        {

        }
        return da;
    }

}
