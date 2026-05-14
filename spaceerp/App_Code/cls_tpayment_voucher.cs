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
public class tpayment_voucher_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnPaymentVoucerID = string.Empty;
    private string objsPaymentVoucherNo = string.Empty;
    private string objnVoucherTypeID = string.Empty;
    private string objdtPaymentVoucher = string.Empty;
    private string objnStatusID = string.Empty;
    private string objsPostedby = string.Empty;
    private string objsAmendedby = string.Empty;
    private string objnCashAccountID = string.Empty;
    private string objnLocationID = string.Empty;
    
    private string objnConfigID = string.Empty;
    public string nPaymentVoucerID
    {
        get { return objnPaymentVoucerID; }
        set { objnPaymentVoucerID = value; }
    }
    public string sPaymentVoucherNo
    {
        get { return objsPaymentVoucherNo; }
        set { objsPaymentVoucherNo = value; }
    }
    public string nVoucherTypeID
    {
        get { return objnVoucherTypeID; }
        set { objnVoucherTypeID = value; }
    }
    public string dtPaymentVoucher
    {
        get { return objdtPaymentVoucher; }
        set { objdtPaymentVoucher = value; }
    }
    public string nStatusID
    {
        get { return objnStatusID; }
        set { objnStatusID = value; }
    }
    public string sPostedby
    {
        get { return objsPostedby; }
        set { objsPostedby = value; }
    }
    public string sAmendedby
    {
        get { return objsAmendedby; }
        set { objsAmendedby = value; }
    }
    public string nCashAccountID
    {
        get { return objnCashAccountID; }
        set { objnCashAccountID = value; }
    }
    public string nLocationID
    {
        get { return objnLocationID; }
        set { objnLocationID = value; }
    }
    public string nConfigID
    {
        get { return objnConfigID; }
        set { objnConfigID = value; }
    }
    public string User_Operation(tpayment_voucher_Class tpayment_voucher_Class, string type)
    {
        SqlCommand cmd = addParameter(tpayment_voucher_Class, type, "");
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
    public SqlCommand addParameter(tpayment_voucher_Class tpayment_voucher_Class, string type, string cond)
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
        SqlCommand cmd = new SqlCommand("SP_tpayment_voucher", conn); cmd.Parameters.AddWithValue("@nPaymentVoucerID", tpayment_voucher_Class.nPaymentVoucerID);
        cmd.Parameters.AddWithValue("@sPaymentVoucherNo", tpayment_voucher_Class.sPaymentVoucherNo);
        cmd.Parameters.AddWithValue("@nVoucherTypeID", tpayment_voucher_Class.nVoucherTypeID);
        cmd.Parameters.AddWithValue("@dtPaymentVoucher", tpayment_voucher_Class.dtPaymentVoucher);
        cmd.Parameters.AddWithValue("@nStatusID", tpayment_voucher_Class.nStatusID);
        cmd.Parameters.AddWithValue("@sPostedby", tpayment_voucher_Class.sPostedby);
        cmd.Parameters.AddWithValue("@sAmendedby", tpayment_voucher_Class.sAmendedby);
        cmd.Parameters.AddWithValue("@nCashAccountID", tpayment_voucher_Class.nCashAccountID);
        cmd.Parameters.AddWithValue("@nLocationID", tpayment_voucher_Class.nLocationID);
        cmd.Parameters.AddWithValue("@nConfigID", ConfigID);

        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(tpayment_voucher_Class tpayment_voucher_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(tpayment_voucher_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(tpayment_voucher_Class tpayment_voucher_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(tpayment_voucher_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(tpayment_voucher_Class tpayment_voucher_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(tpayment_voucher_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewtpayment_voucher");
            return ds.Tables["viewtpayment_voucher"];
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
    public DropDownList ddlOperation(tpayment_voucher_Class tpayment_voucher_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(tpayment_voucher_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewtpayment_voucher");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a payment_voucher", "0"));
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
