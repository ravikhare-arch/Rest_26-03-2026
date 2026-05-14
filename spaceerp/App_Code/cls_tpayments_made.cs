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
public class tpayments_made_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnPaymentMadeID = string.Empty;
    private string objnPaymentModeID = string.Empty;
    private string objnCashAccountID = string.Empty;
    private string objdtPayment = string.Empty;
    private string objsVoucherNo = string.Empty;
    private string objnTotAmount = string.Empty;
    private string objnSupplierID = string.Empty;
    private string objsRemarks = string.Empty;
    private string objsPayfor = string.Empty;
    private string objnConfigID = string.Empty;
    public string nPaymentMadeID
    {
        get { return objnPaymentMadeID; }
        set { objnPaymentMadeID = value; }
    }
    public string nPaymentModeID
    {
        get { return objnPaymentModeID; }
        set { objnPaymentModeID = value; }
    }
    public string nCashAccountID
    {
        get { return objnCashAccountID; }
        set { objnCashAccountID = value; }
    }
    public string dtPayment
    {
        get { return objdtPayment; }
        set { objdtPayment = value; }
    }
    public string sVoucherNo
    {
        get { return objsVoucherNo; }
        set { objsVoucherNo = value; }
    }
    public string nTotAmount
    {
        get { return objnTotAmount; }
        set { objnTotAmount = value; }
    }
    public string nSupplierID
    {
        get { return objnSupplierID; }
        set { objnSupplierID = value; }
    }
    public string sRemarks
    {
        get { return objsRemarks; }
        set { objsRemarks = value; }
    }
    public string sPayfor
    {
        get { return objsPayfor; }
        set { objsPayfor = value; }
    }
    public string nConfigID
    {
        get { return objnConfigID; }
        set { objnConfigID = value; }
    }
    public string StartDate { get; set; }
    public string EndDate { get; set; }
    public string User_Operation(tpayments_made_Class tpayments_made_Class, string type)
    {
        SqlCommand cmd = addParameter(tpayments_made_Class, type, "");
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
    public SqlCommand addParameter(tpayments_made_Class tpayments_made_Class, string type, string cond)
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
        SqlCommand cmd = new SqlCommand("SP_tpayments_made", conn); cmd.Parameters.AddWithValue("@nPaymentMadeID", tpayments_made_Class.nPaymentMadeID);
        cmd.Parameters.AddWithValue("@nPaymentModeID", tpayments_made_Class.nPaymentModeID);
        cmd.Parameters.AddWithValue("@nCashAccountID", tpayments_made_Class.nCashAccountID);
        cmd.Parameters.AddWithValue("@dtPayment", tpayments_made_Class.dtPayment);
        cmd.Parameters.AddWithValue("@sVoucherNo", tpayments_made_Class.sVoucherNo);
        cmd.Parameters.AddWithValue("@nTotAmount", tpayments_made_Class.nTotAmount);
        cmd.Parameters.AddWithValue("@nSupplierID", tpayments_made_Class.nSupplierID);
        cmd.Parameters.AddWithValue("@sRemarks", tpayments_made_Class.sRemarks);
        cmd.Parameters.AddWithValue("@sPayfor", tpayments_made_Class.sPayfor);
        cmd.Parameters.AddWithValue("@nConfigID", ConfigID);
        cmd.Parameters.AddWithValue("@StartDate", tpayments_made_Class.StartDate);
        cmd.Parameters.AddWithValue("@EndDate", tpayments_made_Class.EndDate);
        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(tpayments_made_Class tpayments_made_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(tpayments_made_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(tpayments_made_Class tpayments_made_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(tpayments_made_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(tpayments_made_Class tpayments_made_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(tpayments_made_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewtpayments_made");
            return ds.Tables["viewtpayments_made"];
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
    public DropDownList ddlOperation(tpayments_made_Class tpayments_made_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(tpayments_made_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewtpayments_made");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a payments_made", "0"));
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
    public DataTable Tabledata(tpayments_made_Class tpayments_made_Class, string type, string cond)
    {
        DataTable da = new DataTable();
        try
        {
            da = viewData(tpayments_made_Class, type, cond);
        }
        catch
        {

        }
        return da;
    }
}
