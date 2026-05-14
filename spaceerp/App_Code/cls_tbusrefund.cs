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
public class tbusrefund_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnBusRefundID = string.Empty;
    private string objnBusBookingID = string.Empty;
    private string objsRefundNo = string.Empty;
    private string objdtRefundDate = string.Empty;
    private string objnRefundAmount = string.Empty;
    private string objnRfnSupScAmount = string.Empty;
    private string objbRfnTax = string.Empty;
    private string objnRfnCGst = string.Empty;
    private string objnRfnSGst = string.Empty;
    private string objnRfnIGst = string.Empty;
    private string objnSupplierRefund = string.Empty;
    private string objnClientRefund = string.Empty;
    private string objsRfnRemaks = string.Empty;
    private string objnRefundAccountID = string.Empty;
    private string objnConfigID = string.Empty;
    public string nBusRefundID
    {
        get { return objnBusRefundID; }
        set { objnBusRefundID = value; }
    }
    public string nBusBookingID
    {
        get { return objnBusBookingID; }
        set { objnBusBookingID = value; }
    }
    public string sRefundNo
    {
        get { return objsRefundNo; }
        set { objsRefundNo = value; }
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
    public string nSupplierRefund
    {
        get { return objnSupplierRefund; }
        set { objnSupplierRefund = value; }
    }
    public string nClientRefund
    {
        get { return objnClientRefund; }
        set { objnClientRefund = value; }
    }
    public string sRfnRemaks
    {
        get { return objsRfnRemaks; }
        set { objsRfnRemaks = value; }
    }
    public string nRefundAccountID
    {
        get { return objnRefundAccountID; }
        set { objnRefundAccountID = value; }
    }
    public string nConfigID
    {
        get { return objnConfigID; }
        set { objnConfigID = value; }
    }
    public string User_Operation(tbusrefund_Class tbusrefund_Class, string type)
    {
        SqlCommand cmd = addParameter(tbusrefund_Class, type, "");
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
    public SqlCommand addParameter(tbusrefund_Class tbusrefund_Class, string type, string cond)
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
        SqlCommand cmd = new SqlCommand("SP_tbusrefund", conn); cmd.Parameters.AddWithValue("@nBusRefundID", tbusrefund_Class.nBusRefundID);
        cmd.Parameters.AddWithValue("@nBusBookingID", tbusrefund_Class.nBusBookingID);
        cmd.Parameters.AddWithValue("@sRefundNo", tbusrefund_Class.sRefundNo);
        cmd.Parameters.AddWithValue("@dtRefundDate", tbusrefund_Class.dtRefundDate);
        cmd.Parameters.AddWithValue("@nRefundAmount", tbusrefund_Class.nRefundAmount);
        cmd.Parameters.AddWithValue("@nRfnSupScAmount", tbusrefund_Class.nRfnSupScAmount);
        cmd.Parameters.AddWithValue("@bRfnTax", tbusrefund_Class.bRfnTax);
        cmd.Parameters.AddWithValue("@nRfnCGst", tbusrefund_Class.nRfnCGst);
        cmd.Parameters.AddWithValue("@nRfnSGst", tbusrefund_Class.nRfnSGst);
        cmd.Parameters.AddWithValue("@nRfnIGst", tbusrefund_Class.nRfnIGst);
        cmd.Parameters.AddWithValue("@nSupplierRefund", tbusrefund_Class.nSupplierRefund);
        cmd.Parameters.AddWithValue("@nClientRefund", tbusrefund_Class.nClientRefund);
        cmd.Parameters.AddWithValue("@sRfnRemaks", tbusrefund_Class.sRfnRemaks);
        cmd.Parameters.AddWithValue("@nRefundAccountID", tbusrefund_Class.nRefundAccountID);
        cmd.Parameters.AddWithValue("@nConfigID", ConfigID);

        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(tbusrefund_Class tbusrefund_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(tbusrefund_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(tbusrefund_Class tbusrefund_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(tbusrefund_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(tbusrefund_Class tbusrefund_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(tbusrefund_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewtbusrefund");
            return ds.Tables["viewtbusrefund"];
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
    public DropDownList ddlOperation(tbusrefund_Class tbusrefund_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(tbusrefund_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewtbusrefund");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a busrefund", "0"));
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
