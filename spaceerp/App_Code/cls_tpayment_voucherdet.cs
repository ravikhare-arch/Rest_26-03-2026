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
public class tpayment_voucherdet_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnPaymentVoucherDetID = string.Empty;
    private string objnPaymentVoucherID = string.Empty;
    private string objnAccountCodeID = string.Empty;
    private string objsAccountTitle = string.Empty;
    private string objnBalance = string.Empty;
    private string objsDescription = string.Empty;
    private string objnCurrencyID = string.Empty;
    private string objnRate = string.Empty;
    private string objnAmount = string.Empty;
    private string objnLocalAmount = string.Empty;
    private string objnJobID = string.Empty;
    private string objsChequeNo = string.Empty;
    private string objdtCheque = string.Empty;
    private string objsRemarks = string.Empty;
    private string objnConfigID = string.Empty;
    public string nPaymentVoucherDetID
    {
        get { return objnPaymentVoucherDetID; }
        set { objnPaymentVoucherDetID = value; }
    }
    public string nPaymentVoucherID
    {
        get { return objnPaymentVoucherID; }
        set { objnPaymentVoucherID = value; }
    }
    public string nAccountCodeID
    {
        get { return objnAccountCodeID; }
        set { objnAccountCodeID = value; }
    }
    public string sAccountTitle
    {
        get { return objsAccountTitle; }
        set { objsAccountTitle = value; }
    }
    public string nBalance
    {
        get { return objnBalance; }
        set { objnBalance = value; }
    }
    public string sDescription
    {
        get { return objsDescription; }
        set { objsDescription = value; }
    }
    public string nCurrencyID
    {
        get { return objnCurrencyID; }
        set { objnCurrencyID = value; }
    }
    public string nRate
    {
        get { return objnRate; }
        set { objnRate = value; }
    }
    public string nAmount
    {
        get { return objnAmount; }
        set { objnAmount = value; }
    }
    public string nLocalAmount
    {
        get { return objnLocalAmount; }
        set { objnLocalAmount = value; }
    }
    public string nJobID
    {
        get { return objnJobID; }
        set { objnJobID = value; }
    }
    public string sChequeNo
    {
        get { return objsChequeNo; }
        set { objsChequeNo = value; }
    }
    public string dtCheque
    {
        get { return objdtCheque; }
        set { objdtCheque = value; }
    }
    public string sRemarks
    {
        get { return objsRemarks; }
        set { objsRemarks = value; }
    }
    public string nConfigID
    {
        get { return objnConfigID; }
        set { objnConfigID = value; }
    }
    public string User_Operation(tpayment_voucherdet_Class tpayment_voucherdet_Class, string type)
    {
        SqlCommand cmd = addParameter(tpayment_voucherdet_Class, type, "");
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
    public SqlCommand addParameter(tpayment_voucherdet_Class tpayment_voucherdet_Class, string type, string cond)
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
        SqlCommand cmd = new SqlCommand("SP_tpayment_voucherdet", conn); cmd.Parameters.AddWithValue("@nPaymentVoucherDetID", tpayment_voucherdet_Class.nPaymentVoucherDetID);
        cmd.Parameters.AddWithValue("@nPaymentVoucherID", tpayment_voucherdet_Class.nPaymentVoucherID);
        cmd.Parameters.AddWithValue("@nAccountCodeID", tpayment_voucherdet_Class.nAccountCodeID);
        cmd.Parameters.AddWithValue("@sAccountTitle", tpayment_voucherdet_Class.sAccountTitle);
        cmd.Parameters.AddWithValue("@nBalance", tpayment_voucherdet_Class.nBalance);
        cmd.Parameters.AddWithValue("@sDescription", tpayment_voucherdet_Class.sDescription);
        cmd.Parameters.AddWithValue("@nCurrencyID", tpayment_voucherdet_Class.nCurrencyID);
        cmd.Parameters.AddWithValue("@nRate", tpayment_voucherdet_Class.nRate);
        cmd.Parameters.AddWithValue("@nAmount", tpayment_voucherdet_Class.nAmount);
        cmd.Parameters.AddWithValue("@nLocalAmount", tpayment_voucherdet_Class.nLocalAmount);
        cmd.Parameters.AddWithValue("@nJobID", tpayment_voucherdet_Class.nJobID);
        cmd.Parameters.AddWithValue("@sChequeNo", tpayment_voucherdet_Class.sChequeNo);
        cmd.Parameters.AddWithValue("@dtCheque", tpayment_voucherdet_Class.dtCheque);
        cmd.Parameters.AddWithValue("@sRemarks", tpayment_voucherdet_Class.sRemarks);
        cmd.Parameters.AddWithValue("@nConfigID", ConfigID);
        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(tpayment_voucherdet_Class tpayment_voucherdet_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(tpayment_voucherdet_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(tpayment_voucherdet_Class tpayment_voucherdet_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(tpayment_voucherdet_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(tpayment_voucherdet_Class tpayment_voucherdet_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(tpayment_voucherdet_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewtpayment_voucherdet");
            return ds.Tables["viewtpayment_voucherdet"];
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
    public DropDownList ddlOperation(tpayment_voucherdet_Class tpayment_voucherdet_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(tpayment_voucherdet_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewtpayment_voucherdet");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a payment_voucherdet", "0"));
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
