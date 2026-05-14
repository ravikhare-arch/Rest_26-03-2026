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
public class ttrainrefund_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnTrainRefundID = string.Empty;
    private string objnTrainBookingID = string.Empty;
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
    public string nTrainRefundID
    {
        get { return objnTrainRefundID; }
        set { objnTrainRefundID = value; }
    }
    public string nTrainBookingID
    {
        get { return objnTrainBookingID; }
        set { objnTrainBookingID = value; }
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
    public string User_Operation(ttrainrefund_Class ttrainrefund_Class, string type)
    {
        SqlCommand cmd = addParameter(ttrainrefund_Class, type, "");
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
    public SqlCommand addParameter(ttrainrefund_Class ttrainrefund_Class, string type, string cond)
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
        SqlCommand cmd = new SqlCommand("SP_ttrainrefund", conn); cmd.Parameters.AddWithValue("@nTrainRefundID", ttrainrefund_Class.nTrainRefundID);
        cmd.Parameters.AddWithValue("@nTrainBookingID", ttrainrefund_Class.nTrainBookingID);
        cmd.Parameters.AddWithValue("@sRefundNo", ttrainrefund_Class.sRefundNo);
        cmd.Parameters.AddWithValue("@dtRefundDate", ttrainrefund_Class.dtRefundDate);
        cmd.Parameters.AddWithValue("@nRefundAmount", ttrainrefund_Class.nRefundAmount);
        cmd.Parameters.AddWithValue("@nRfnSupScAmount", ttrainrefund_Class.nRfnSupScAmount);
        cmd.Parameters.AddWithValue("@bRfnTax", ttrainrefund_Class.bRfnTax);
        cmd.Parameters.AddWithValue("@nRfnCGst", ttrainrefund_Class.nRfnCGst);
        cmd.Parameters.AddWithValue("@nRfnSGst", ttrainrefund_Class.nRfnSGst);
        cmd.Parameters.AddWithValue("@nRfnIGst", ttrainrefund_Class.nRfnIGst);
        cmd.Parameters.AddWithValue("@nSupplierRefund", ttrainrefund_Class.nSupplierRefund);
        cmd.Parameters.AddWithValue("@nClientRefund", ttrainrefund_Class.nClientRefund);
        cmd.Parameters.AddWithValue("@sRfnRemaks", ttrainrefund_Class.sRfnRemaks);
        cmd.Parameters.AddWithValue("@nRefundAccountID", ttrainrefund_Class.nRefundAccountID);
        cmd.Parameters.AddWithValue("@nConfigID", ConfigID);

        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(ttrainrefund_Class ttrainrefund_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(ttrainrefund_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(ttrainrefund_Class ttrainrefund_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(ttrainrefund_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(ttrainrefund_Class ttrainrefund_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(ttrainrefund_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewttrainrefund");
            return ds.Tables["viewttrainrefund"];
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
    public DropDownList ddlOperation(ttrainrefund_Class ttrainrefund_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(ttrainrefund_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewttrainrefund");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a trainrefund", "0"));
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
