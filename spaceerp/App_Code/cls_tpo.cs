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
public class tpo_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnPoID = string.Empty;
    private string objsPoNo = string.Empty;
    private string objsStatus = string.Empty;
    private string objdtOrder = string.Empty;
    private string objdtDelivery = string.Empty;
    private string objnLocationID = string.Empty;
    private string objnVendorNameID = string.Empty;
    private string objbAttention = string.Empty;
    private string objsAttention = string.Empty;
    private string objbNote = string.Empty;
    private string objsNote = string.Empty;
    private string objnShipingCost = string.Empty;
    private string objnOtherCharges = string.Empty;
    private string objnDiscount = string.Empty;
    private string objbPaid = string.Empty;
    private string objnConfigID = string.Empty;
    public string nPoID
    {
        get { return objnPoID; }
        set { objnPoID = value; }
    }
    public string sPoNo
    {
        get { return objsPoNo; }
        set { objsPoNo = value; }
    }
    public string sStatus
    {
        get { return objsStatus; }
        set { objsStatus = value; }
    }
    public string dtOrder
    {
        get { return objdtOrder; }
        set { objdtOrder = value; }
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
    public string nVendorNameID
    {
        get { return objnVendorNameID; }
        set { objnVendorNameID = value; }
    }
    public string bAttention
    {
        get { return objbAttention; }
        set { objbAttention = value; }
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
    public string bNote
    {
        get { return objbNote; }
        set { objbNote = value; }
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
    public string User_Operation(tpo_Class tpo_Class, string type)
    {
        SqlCommand cmd = addParameter(tpo_Class, type, "");
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
    public SqlCommand addParameter(tpo_Class tpo_Class, string type, string cond)
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
        SqlCommand cmd = new SqlCommand("SP_tpo", conn); cmd.Parameters.AddWithValue("@nPoID", tpo_Class.nPoID);
        cmd.Parameters.AddWithValue("@sPoNo", tpo_Class.sPoNo);
        cmd.Parameters.AddWithValue("@sStatus", tpo_Class.sStatus);
        cmd.Parameters.AddWithValue("@dtOrder", tpo_Class.dtOrder);
        cmd.Parameters.AddWithValue("@dtDelivery", tpo_Class.dtDelivery);
        cmd.Parameters.AddWithValue("@nLocationID", tpo_Class.nLocationID);
        cmd.Parameters.AddWithValue("@nVendorNameID", tpo_Class.nVendorNameID);
        cmd.Parameters.AddWithValue("@bAttention", tpo_Class.bAttention);
        cmd.Parameters.AddWithValue("@sAttention", tpo_Class.sAttention);
        cmd.Parameters.AddWithValue("@bNote", tpo_Class.bNote);
        cmd.Parameters.AddWithValue("@sNote", tpo_Class.sNote);
        cmd.Parameters.AddWithValue("@nShipingCost", tpo_Class.nShipingCost);
        cmd.Parameters.AddWithValue("@nOtherCharges", tpo_Class.nOtherCharges);
        cmd.Parameters.AddWithValue("@nDiscount", tpo_Class.nDiscount);
        cmd.Parameters.AddWithValue("@bPaid", tpo_Class.bPaid);
        cmd.Parameters.AddWithValue("@nConfigID", ConfigID);
        cmd.Parameters.AddWithValue("@StartDate", tpo_Class.StartDate);
        cmd.Parameters.AddWithValue("@EndDate", tpo_Class.EndDate);
        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(tpo_Class tpo_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(tpo_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(tpo_Class tpo_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(tpo_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(tpo_Class tpo_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(tpo_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewtpo");
            return ds.Tables["viewtpo"];
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
    public DropDownList ddlOperation(tpo_Class tpo_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(tpo_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewtpo");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a po", "0"));
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
    public DataTable Tabledata(tpo_Class tpo_Class, string type, string cond)
    {
        DataTable da = new DataTable();
        try
        {
            da = viewData(tpo_Class, type, cond);
        }
        catch
        {

        }
        return da;
    }
}
