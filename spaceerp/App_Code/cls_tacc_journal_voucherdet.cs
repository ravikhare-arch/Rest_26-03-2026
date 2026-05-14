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
public class tacc_journal_voucherdet_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnJournalVoucherDetID = string.Empty;
    private string objnJournalVoucherID = string.Empty;
    private string objnAccountCodeID = string.Empty;
    private string objsAccountTitle = string.Empty;
    private string objnBalance = string.Empty;
    private string objsDescription = string.Empty;
    private string objnCurrencyID = string.Empty;
    private string objnRate = string.Empty;
    private string objnAmount = string.Empty;
    private string objnLocalAmount = string.Empty;
    private string objnJobID = string.Empty;
    private string objsRemarks = string.Empty;
    private string objnConfigID = string.Empty;
    public string nJournalVoucherDetID
    {
        get { return objnJournalVoucherDetID; }
        set { objnJournalVoucherDetID = value; }
    }
    public string nJournalVoucherID
    {
        get { return objnJournalVoucherID; }
        set { objnJournalVoucherID = value; }
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
    public string User_Operation(tacc_journal_voucherdet_Class tacc_journal_voucherdet_Class, string type)
    {
        SqlCommand cmd = addParameter(tacc_journal_voucherdet_Class, type, "");
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
    public SqlCommand addParameter(tacc_journal_voucherdet_Class tacc_journal_voucherdet_Class, string type, string cond)
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
        SqlCommand cmd = new SqlCommand("SP_tacc_journal_voucherdet", conn); cmd.Parameters.AddWithValue("@nJournalVoucherDetID", tacc_journal_voucherdet_Class.nJournalVoucherDetID);
        cmd.Parameters.AddWithValue("@nJournalVoucherID", tacc_journal_voucherdet_Class.nJournalVoucherID);
        cmd.Parameters.AddWithValue("@nAccountCodeID", tacc_journal_voucherdet_Class.nAccountCodeID);
        cmd.Parameters.AddWithValue("@sAccountTitle", tacc_journal_voucherdet_Class.sAccountTitle);
        cmd.Parameters.AddWithValue("@nBalance", tacc_journal_voucherdet_Class.nBalance);
        cmd.Parameters.AddWithValue("@sDescription", tacc_journal_voucherdet_Class.sDescription);
        cmd.Parameters.AddWithValue("@nCurrencyID", tacc_journal_voucherdet_Class.nCurrencyID);
        cmd.Parameters.AddWithValue("@nRate", tacc_journal_voucherdet_Class.nRate);
        cmd.Parameters.AddWithValue("@nAmount", tacc_journal_voucherdet_Class.nAmount);
        cmd.Parameters.AddWithValue("@nLocalAmount", tacc_journal_voucherdet_Class.nLocalAmount);
        cmd.Parameters.AddWithValue("@nJobID", tacc_journal_voucherdet_Class.nJobID);
        cmd.Parameters.AddWithValue("@sRemarks", tacc_journal_voucherdet_Class.sRemarks);
        cmd.Parameters.AddWithValue("@nConfigID", ConfigID);

        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(tacc_journal_voucherdet_Class tacc_journal_voucherdet_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(tacc_journal_voucherdet_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(tacc_journal_voucherdet_Class tacc_journal_voucherdet_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(tacc_journal_voucherdet_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(tacc_journal_voucherdet_Class tacc_journal_voucherdet_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(tacc_journal_voucherdet_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewtacc_journal_voucherdet");
            return ds.Tables["viewtacc_journal_voucherdet"];
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
    public DropDownList ddlOperation(tacc_journal_voucherdet_Class tacc_journal_voucherdet_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(tacc_journal_voucherdet_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewtacc_journal_voucherdet");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a acc_journal_voucherdet", "0"));
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
    public DataTable Tabledata(tacc_journal_voucherdet_Class tacc_journal_voucherdet_Class, string type, string cond)
    {
        DataTable da = new DataTable();
        try
        {
            da = viewData(tacc_journal_voucherdet_Class, type, cond);
        }
        catch
        {

        }
        return da;
    }

}
