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
public class tacc_journal_voucher_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnJournalVoucerID = string.Empty;
    private string objsJournalVoucherNo = string.Empty;
    private string objnVoucherTypeID = string.Empty;
    private string objnAccountTypeID = string.Empty;
    private string objdtJournalVoucher = string.Empty;
    private string objnStatusID = string.Empty;
    private string objsPostedby = string.Empty;
    private string objsAmendedby = string.Empty;
    private string objLocationID = string.Empty;
    private string objnConfigID = string.Empty;
    public string nJournalVoucerID
    {
        get { return objnJournalVoucerID; }
        set { objnJournalVoucerID = value; }
    }
    public string sJournalVoucherNo
    {
        get { return objsJournalVoucherNo; }
        set { objsJournalVoucherNo = value; }
    }
    public string nVoucherTypeID
    {
        get { return objnVoucherTypeID; }
        set { objnVoucherTypeID = value; }
    }
    public string dtJournalVoucher
    {
        get { return objdtJournalVoucher; }
        set { objdtJournalVoucher = value; }
    }
    public string nAccountTypeID
    {
        get { return objnAccountTypeID; }
        set { objnAccountTypeID = value; }
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
    public string nLocationID
    {
        get { return objLocationID; }
        set { objLocationID = value; }
    }
    public string nConfigID
    {
        get { return objnConfigID; }
        set { objnConfigID = value; }
    }
    public string StartDate { get; set; }
    public string EndDate { get; set; }
    public string User_Operation(tacc_journal_voucher_Class tacc_journal_voucher_Class, string type)
    {
        SqlCommand cmd = addParameter(tacc_journal_voucher_Class, type, "");
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
    public SqlCommand addParameter(tacc_journal_voucher_Class tacc_journal_voucher_Class, string type, string cond)
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
        SqlCommand cmd = new SqlCommand("SP_tacc_journal_voucher", conn); cmd.Parameters.AddWithValue("@nJournalVoucerID", tacc_journal_voucher_Class.nJournalVoucerID);
        cmd.Parameters.AddWithValue("@sJournalVoucherNo", tacc_journal_voucher_Class.sJournalVoucherNo);
        cmd.Parameters.AddWithValue("@nVoucherTypeID", tacc_journal_voucher_Class.nVoucherTypeID);
        cmd.Parameters.AddWithValue("@dtJournalVoucher", tacc_journal_voucher_Class.dtJournalVoucher);
        cmd.Parameters.AddWithValue("@nAccountTypeID", tacc_journal_voucher_Class.nAccountTypeID);
        cmd.Parameters.AddWithValue("@nStatusID", tacc_journal_voucher_Class.nStatusID);
        cmd.Parameters.AddWithValue("@sPostedby", tacc_journal_voucher_Class.sPostedby);
        cmd.Parameters.AddWithValue("@sAmendedby", tacc_journal_voucher_Class.sAmendedby);
        cmd.Parameters.AddWithValue("@nLocationID", tacc_journal_voucher_Class.nLocationID);
        cmd.Parameters.AddWithValue("@nConfigID", ConfigID);
        cmd.Parameters.AddWithValue("@StartDate", tacc_journal_voucher_Class.StartDate);
        cmd.Parameters.AddWithValue("@EndDate", tacc_journal_voucher_Class.EndDate);

        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(tacc_journal_voucher_Class tacc_journal_voucher_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(tacc_journal_voucher_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(tacc_journal_voucher_Class tacc_journal_voucher_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(tacc_journal_voucher_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(tacc_journal_voucher_Class tacc_journal_voucher_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(tacc_journal_voucher_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewtacc_journal_voucher");
            return ds.Tables["viewtacc_journal_voucher"];
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
    public DropDownList ddlOperation(tacc_journal_voucher_Class tacc_journal_voucher_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(tacc_journal_voucher_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewtacc_journal_voucher");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a acc_journal_voucher", "0"));
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
    public DataTable Tabledata(tacc_journal_voucher_Class tacc_journal_voucher_Class, string type, string cond)
    {
        DataTable da = new DataTable();
        try
        {
            da = viewData(tacc_journal_voucher_Class, type, cond);
        }
        catch
        {

        }
        return da;
    }

}
