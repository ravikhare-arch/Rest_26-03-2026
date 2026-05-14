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
public class trefund_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnRefundID = string.Empty;
    private string objnRefundTypeID = string.Empty;
    private string objnRefundForID = string.Empty;
    private string objdtRefundDate = string.Empty;
    private string objnRefundAmount = string.Empty;
    private string objnRfnSupScType = string.Empty;
    private string objnRfnSupScPercent = string.Empty;
    private string objnRfnSupScAmount = string.Empty;
    private string objbRfnTax = string.Empty;
    private string objnRfnCGst = string.Empty;
    private string objnRfnSGst = string.Empty;
    private string objnRfnIGst = string.Empty;
    private string objnRfnClntScType = string.Empty;
    private string objnRfnClntScPercent = string.Empty;
    private string objnRfnClntScAmount = string.Empty;
    private string objnTotalRefund = string.Empty;
    private string objsRfnRemaks = string.Empty;
    private string objnConfigID = string.Empty;
    public string nRefundID
    {
        get { return objnRefundID; }
        set { objnRefundID = value; }
    }
    public string nRefundTypeID
    {
        get { return objnRefundTypeID; }
        set { objnRefundTypeID = value; }
    }
    public string nRefundForID
    {
        get { return objnRefundForID; }
        set { objnRefundForID = value; }
    }
    public string dtRefundDate
    {
        get { return objdtRefundDate; }
        set { objdtRefundDate = value; }
    }
    public string nRefundAmount
    {
        get { return objnRefundAmount; }
        set { objnRefundAmount = value; }
    }
    public string nRfnSupScType
    {
        get { return objnRfnSupScType; }
        set { objnRfnSupScType = value; }
    }
    public string nRfnSupScPercent
    {
        get { return objnRfnSupScPercent; }
        set { objnRfnSupScPercent = value; }
    }
    public string nRfnSupScAmount
    {
        get { return objnRfnSupScAmount; }
        set { objnRfnSupScAmount = value; }
    }
    public string bRfnTax
    {
        get { return objbRfnTax; }
        set { objbRfnTax = value; }
    }
    public string nRfnCGst
    {
        get { return objnRfnCGst; }
        set { objnRfnCGst = value; }
    }
    public string nRfnSGst
    {
        get { return objnRfnSGst; }
        set { objnRfnSGst = value; }
    }
    public string nRfnIGst
    {
        get { return objnRfnIGst; }
        set { objnRfnIGst = value; }
    }
    public string nRfnClntScType
    {
        get { return objnRfnClntScType; }
        set { objnRfnClntScType = value; }
    }
    public string nRfnClntScPercent
    {
        get { return objnRfnClntScPercent; }
        set { objnRfnClntScPercent = value; }
    }
    public string nRfnClntScAmount
    {
        get { return objnRfnClntScAmount; }
        set { objnRfnClntScAmount = value; }
    }
    public string nTotalRefund
    {
        get { return objnTotalRefund; }
        set { objnTotalRefund = value; }
    }
    public string sRfnRemaks
    {
        get { return objsRfnRemaks; }
        set { objsRfnRemaks = value; }
    }
    public string nConfigID
    {
        get { return objnConfigID; }
        set { objnConfigID = value; }
    }
    public string User_Operation(trefund_Class trefund_Class, string type)
    {
        SqlCommand cmd = addParameter(trefund_Class, type, "");
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
    public SqlCommand addParameter(trefund_Class trefund_Class, string type, string cond)
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
        SqlCommand cmd = new SqlCommand("SP_trefund", conn); cmd.Parameters.AddWithValue("@nRefundID", trefund_Class.nRefundID);
        cmd.Parameters.AddWithValue("@nRefundTypeID", trefund_Class.nRefundTypeID);
        cmd.Parameters.AddWithValue("@nRefundForID", trefund_Class.nRefundForID);
        cmd.Parameters.AddWithValue("@dtRefundDate", trefund_Class.dtRefundDate);
        cmd.Parameters.AddWithValue("@nRefundAmount", trefund_Class.nRefundAmount);
        cmd.Parameters.AddWithValue("@nRfnSupScType", trefund_Class.nRfnSupScType);
        cmd.Parameters.AddWithValue("@nRfnSupScPercent", trefund_Class.nRfnSupScPercent);
        cmd.Parameters.AddWithValue("@nRfnSupScAmount", trefund_Class.nRfnSupScAmount);
        cmd.Parameters.AddWithValue("@bRfnTax", trefund_Class.bRfnTax);
        cmd.Parameters.AddWithValue("@nRfnCGst", trefund_Class.nRfnCGst);
        cmd.Parameters.AddWithValue("@nRfnSGst", trefund_Class.nRfnSGst);
        cmd.Parameters.AddWithValue("@nRfnIGst", trefund_Class.nRfnIGst);
        cmd.Parameters.AddWithValue("@nRfnClntScType", trefund_Class.nRfnClntScType);
        cmd.Parameters.AddWithValue("@nRfnClntScPercent", trefund_Class.nRfnClntScPercent);
        cmd.Parameters.AddWithValue("@nRfnClntScAmount", trefund_Class.nRfnClntScAmount);
        cmd.Parameters.AddWithValue("@nTotalRefund", trefund_Class.nTotalRefund);
        cmd.Parameters.AddWithValue("@sRfnRemaks", trefund_Class.sRfnRemaks);
        cmd.Parameters.AddWithValue("@nConfigID", ConfigID);

        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(trefund_Class trefund_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(trefund_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(trefund_Class trefund_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(trefund_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(trefund_Class trefund_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(trefund_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewtrefund");
            return ds.Tables["viewtrefund"];
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
    public DropDownList ddlOperation(trefund_Class trefund_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(trefund_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewtrefund");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a refund", "0"));
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
