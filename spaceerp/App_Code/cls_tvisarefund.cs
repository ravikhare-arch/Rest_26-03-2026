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
public class tvisarefund_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnVisaRefundID = string.Empty;
    private string objnVisaDetID = string.Empty;
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
    public string nVisaRefundID
    {
        get { return objnVisaRefundID; }
        set { objnVisaRefundID = value; }
    }
    public string nVisaDetID
    {
        get { return objnVisaDetID; }
        set { objnVisaDetID = value; }
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
    public string User_Operation(tvisarefund_Class tvisarefund_Class, string type)
    {
        SqlCommand cmd = addParameter(tvisarefund_Class, type, "");
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
    public SqlCommand addParameter(tvisarefund_Class tvisarefund_Class, string type, string cond)
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
        SqlCommand cmd = new SqlCommand("SP_tvisarefund", conn); cmd.Parameters.AddWithValue("@nVisaRefundID", tvisarefund_Class.nVisaRefundID);
        cmd.Parameters.AddWithValue("@nVisaDetID", tvisarefund_Class.nVisaDetID);
        cmd.Parameters.AddWithValue("@sRefundNo", tvisarefund_Class.sRefundNo);
        cmd.Parameters.AddWithValue("@dtRefundDate", tvisarefund_Class.dtRefundDate);
        cmd.Parameters.AddWithValue("@nRefundAmount", tvisarefund_Class.nRefundAmount);
        cmd.Parameters.AddWithValue("@nRfnSupScAmount", tvisarefund_Class.nRfnSupScAmount);
        cmd.Parameters.AddWithValue("@bRfnTax", tvisarefund_Class.bRfnTax);
        cmd.Parameters.AddWithValue("@nRfnCGst", tvisarefund_Class.nRfnCGst);
        cmd.Parameters.AddWithValue("@nRfnSGst", tvisarefund_Class.nRfnSGst);
        cmd.Parameters.AddWithValue("@nRfnIGst", tvisarefund_Class.nRfnIGst);
        cmd.Parameters.AddWithValue("@nSupplierRefund", tvisarefund_Class.nSupplierRefund);
        cmd.Parameters.AddWithValue("@nClientRefund", tvisarefund_Class.nClientRefund);
        cmd.Parameters.AddWithValue("@sRfnRemaks", tvisarefund_Class.sRfnRemaks);
        cmd.Parameters.AddWithValue("@nRefundAccountID", tvisarefund_Class.nRefundAccountID);
        cmd.Parameters.AddWithValue("@nConfigID", ConfigID);

        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(tvisarefund_Class tvisarefund_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(tvisarefund_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(tvisarefund_Class tvisarefund_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(tvisarefund_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(tvisarefund_Class tvisarefund_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(tvisarefund_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewtvisarefund");
            return ds.Tables["viewtvisarefund"];
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
    public DropDownList ddlOperation(tvisarefund_Class tvisarefund_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(tvisarefund_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewtvisarefund");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a visarefund", "0"));
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
