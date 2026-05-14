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
public class tpdc_voucher_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnPdcVoucerID = string.Empty;
    private string objsPdcVoucherNo = string.Empty;
    private string objnVoucherTypeID = string.Empty;
    private string objdtPdcVoucher = string.Empty;
    private string objnStatusID = string.Empty;
    private string objsPostedby = string.Empty;
    private string objsAmendedby = string.Empty;
    private string objnDepositedBankID = string.Empty;
    private string objnLocationID = string.Empty;
    private string objnConfigID = string.Empty;
    public string nPdcVoucerID
    {
        get { return objnPdcVoucerID; }
        set { objnPdcVoucerID = value; }
    }
    public string sPdcVoucherNo
    {
        get { return objsPdcVoucherNo; }
        set { objsPdcVoucherNo = value; }
    }
    public string nVoucherTypeID
    {
        get { return objnVoucherTypeID; }
        set { objnVoucherTypeID = value; }
    }
    public string dtPdcVoucher
    {
        get { return objdtPdcVoucher; }
        set { objdtPdcVoucher = value; }
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
    public string nDepositedBankID
    {
        get { return objnDepositedBankID; }
        set { objnDepositedBankID = value; }
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
    public string User_Operation(tpdc_voucher_Class tpdc_voucher_Class, string type)
    {
        SqlCommand cmd = addParameter(tpdc_voucher_Class, type, "");
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
    public SqlCommand addParameter(tpdc_voucher_Class tpdc_voucher_Class, string type, string cond)
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
        SqlCommand cmd = new SqlCommand("SP_tpdc_voucher", conn); cmd.Parameters.AddWithValue("@nPdcVoucerID", tpdc_voucher_Class.nPdcVoucerID);
        cmd.Parameters.AddWithValue("@sPdcVoucherNo", tpdc_voucher_Class.sPdcVoucherNo);
        cmd.Parameters.AddWithValue("@nVoucherTypeID", tpdc_voucher_Class.nVoucherTypeID);
        cmd.Parameters.AddWithValue("@dtPdcVoucher", tpdc_voucher_Class.dtPdcVoucher);
        cmd.Parameters.AddWithValue("@nStatusID", tpdc_voucher_Class.nStatusID);
        cmd.Parameters.AddWithValue("@sPostedby", tpdc_voucher_Class.sPostedby);
        cmd.Parameters.AddWithValue("@sAmendedby", tpdc_voucher_Class.sAmendedby);
        cmd.Parameters.AddWithValue("@nDepositedBankID", tpdc_voucher_Class.nDepositedBankID);
        cmd.Parameters.AddWithValue("@nLocationID", tpdc_voucher_Class.nLocationID);
        cmd.Parameters.AddWithValue("@nConfigID", ConfigID);

        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(tpdc_voucher_Class tpdc_voucher_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(tpdc_voucher_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(tpdc_voucher_Class tpdc_voucher_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(tpdc_voucher_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(tpdc_voucher_Class tpdc_voucher_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(tpdc_voucher_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewtpdc_voucher");
            return ds.Tables["viewtpdc_voucher"];
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
    public DropDownList ddlOperation(tpdc_voucher_Class tpdc_voucher_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(tpdc_voucher_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewtpdc_voucher");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a pdc_voucher", "0"));
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
