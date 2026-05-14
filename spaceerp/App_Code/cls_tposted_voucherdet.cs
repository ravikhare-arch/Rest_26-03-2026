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
public class tposted_voucherdet_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnPostedVoucherDetID = string.Empty;
    private string objnPostedVoucherID = string.Empty;
    private string objnAccountCodeID = string.Empty;
    private string objnBalance = string.Empty;
    private string objsDescription = string.Empty;
    private string objnCurrencyID = string.Empty;
    private string objnRate = string.Empty;
    private string objnDebit = string.Empty;
    private string objnCredit = string.Empty;
    private string objnJobID = string.Empty;
    private string objnConfigID = string.Empty;
    public string nPostedVoucherDetID
    {
        get { return objnPostedVoucherDetID; }
        set { objnPostedVoucherDetID = value; }
    }
    public string nPostedVoucherID
    {
        get { return objnPostedVoucherID; }
        set { objnPostedVoucherID = value; }
    }
    public string nAccountCodeID
    {
        get { return objnAccountCodeID; }
        set { objnAccountCodeID = value; }
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
    public string nDebit
    {
        get { return objnDebit; }
        set { objnDebit = value; }
    }
    public string nCredit
    {
        get { return objnCredit; }
        set { objnCredit = value; }
    }
    public string nJobID
    {
        get { return objnJobID; }
        set { objnJobID = value; }
    }
    public string nConfigID
    {
        get { return objnConfigID; }
        set { objnConfigID = value; }
    }
    public string User_Operation(tposted_voucherdet_Class tposted_voucherdet_Class, string type)
    {
        SqlCommand cmd = addParameter(tposted_voucherdet_Class, type, "");
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
    public SqlCommand addParameter(tposted_voucherdet_Class tposted_voucherdet_Class, string type, string cond)
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
        SqlCommand cmd = new SqlCommand("SP_tposted_voucherdet", conn); cmd.Parameters.AddWithValue("@nPostedVoucherDetID", tposted_voucherdet_Class.nPostedVoucherDetID);
        cmd.Parameters.AddWithValue("@nPostedVoucherID", tposted_voucherdet_Class.nPostedVoucherID);
        cmd.Parameters.AddWithValue("@nAccountCodeID", tposted_voucherdet_Class.nAccountCodeID);
        cmd.Parameters.AddWithValue("@nBalance", tposted_voucherdet_Class.nBalance);
        cmd.Parameters.AddWithValue("@sDescription", tposted_voucherdet_Class.sDescription);
        cmd.Parameters.AddWithValue("@nCurrencyID", tposted_voucherdet_Class.nCurrencyID);
        cmd.Parameters.AddWithValue("@nRate", tposted_voucherdet_Class.nRate);
        cmd.Parameters.AddWithValue("@nDebit", tposted_voucherdet_Class.nDebit);
        cmd.Parameters.AddWithValue("@nCredit", tposted_voucherdet_Class.nCredit);
        cmd.Parameters.AddWithValue("@nJobID", tposted_voucherdet_Class.nJobID);
        cmd.Parameters.AddWithValue("@nConfigID", ConfigID);

        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(tposted_voucherdet_Class tposted_voucherdet_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(tposted_voucherdet_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(tposted_voucherdet_Class tposted_voucherdet_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(tposted_voucherdet_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(tposted_voucherdet_Class tposted_voucherdet_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(tposted_voucherdet_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewtposted_voucherdet");
            return ds.Tables["viewtposted_voucherdet"];
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
    public DropDownList ddlOperation(tposted_voucherdet_Class tposted_voucherdet_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(tposted_voucherdet_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewtposted_voucherdet");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a posted_voucherdet", "0"));
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
