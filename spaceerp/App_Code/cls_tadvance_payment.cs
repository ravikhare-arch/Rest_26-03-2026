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
public class tadvance_payment_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnAdvancePaymentID = string.Empty;
    private string objsVoucherNo = string.Empty;
    private string objdtVoucher = string.Empty;
    private string objnPaymentTypeID = string.Empty;
    private string objnAccountTypeID = string.Empty;
    private string objnAccountID = string.Empty;
    private string objnPaymentModeID = string.Empty;
    private string objsChequeNo = string.Empty;
    private string objdtCheque = string.Empty;
    private string objnAmount = string.Empty;
    private string objsRemarks = string.Empty;
    private string objnStatusID = string.Empty;
    private string objnCashAccountID = string.Empty;
    private string objnConfigID = string.Empty;
    public string nAdvancePaymentID
    {
        get { return objnAdvancePaymentID; }
        set { objnAdvancePaymentID = value; }
    }
    public string sVoucherNo
    {
        get { return objsVoucherNo; }
        set { objsVoucherNo = value; }
    }
    public string dtVoucher
    {
        get { return objdtVoucher; }
        set { objdtVoucher = value; }
    }
    public string nPaymentTypeID
    {
        get { return objnPaymentTypeID; }
        set { objnPaymentTypeID = value; }
    }
    public string nAccountTypeID
    {
        get { return objnAccountTypeID; }
        set { objnAccountTypeID = value; }
    }
    public string nAccountID
    {
        get { return objnAccountID; }
        set { objnAccountID = value; }
    }
    public string nPaymentModeID
    {
        get { return objnPaymentModeID; }
        set { objnPaymentModeID = value; }
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
    public string nAmount
    {
        get { return objnAmount; }
        set { objnAmount = value; }
    }
    public string sRemarks
    {
        get { return objsRemarks; }
        set { objsRemarks = value; }
    }
    public string nStatusID
    {
        get { return objnStatusID; }
        set { objnStatusID = value; }
    }
    public string nCashAccountID
    {
        get { return objnCashAccountID; }
        set { objnCashAccountID = value; }
    }
    public string nConfigID
    {
        get { return objnConfigID; }
        set { objnConfigID = value; }
    }
    public string User_Operation(tadvance_payment_Class tadvance_payment_Class, string type)
    {
        SqlCommand cmd = addParameter(tadvance_payment_Class, type, "");
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
    public SqlCommand addParameter(tadvance_payment_Class tadvance_payment_Class, string type, string cond)
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
        SqlCommand cmd = new SqlCommand("SP_tadvance_payment", conn); cmd.Parameters.AddWithValue("@nAdvancePaymentID", tadvance_payment_Class.nAdvancePaymentID);
        cmd.Parameters.AddWithValue("@sVoucherNo", tadvance_payment_Class.sVoucherNo);
        cmd.Parameters.AddWithValue("@dtVoucher", tadvance_payment_Class.dtVoucher);
        cmd.Parameters.AddWithValue("@nPaymentTypeID", tadvance_payment_Class.nPaymentTypeID);
        cmd.Parameters.AddWithValue("@nAccountTypeID", tadvance_payment_Class.nAccountTypeID);
        cmd.Parameters.AddWithValue("@nAccountID", tadvance_payment_Class.nAccountID);
        cmd.Parameters.AddWithValue("@nPaymentModeID", tadvance_payment_Class.nPaymentModeID);
        cmd.Parameters.AddWithValue("@sChequeNo", tadvance_payment_Class.sChequeNo);
        cmd.Parameters.AddWithValue("@dtCheque", tadvance_payment_Class.dtCheque);
        cmd.Parameters.AddWithValue("@nAmount", tadvance_payment_Class.nAmount);
        cmd.Parameters.AddWithValue("@sRemarks", tadvance_payment_Class.sRemarks);
        cmd.Parameters.AddWithValue("@nStatusID", tadvance_payment_Class.nStatusID);
        cmd.Parameters.AddWithValue("@nCashAccountID", tadvance_payment_Class.nCashAccountID);
        cmd.Parameters.AddWithValue("@nConfigID", ConfigID);

        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(tadvance_payment_Class tadvance_payment_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(tadvance_payment_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(tadvance_payment_Class tadvance_payment_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(tadvance_payment_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(tadvance_payment_Class tadvance_payment_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(tadvance_payment_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewtadvance_payment");
            return ds.Tables["viewtadvance_payment"];
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
    public DropDownList ddlOperation(tadvance_payment_Class tadvance_payment_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(tadvance_payment_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewtadvance_payment");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a advance_payment", "0"));
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
