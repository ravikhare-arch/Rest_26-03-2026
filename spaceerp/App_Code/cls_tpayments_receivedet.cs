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
public class tpayments_receivedet_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnPaymentReceiveDetID = string.Empty;
    private string objnPaymentReceiveID = string.Empty;
    private string objnInvoiceID = string.Empty;
    private string objdtInvoiceDate = string.Empty;
    private string objsInvoiceNo = string.Empty;
    private string objnAmount = string.Empty;
    private string objsRemarks = string.Empty;
    private string objnConfigID = string.Empty;
    public string nPaymentReceiveDetID
    {
        get { return objnPaymentReceiveDetID; }
        set { objnPaymentReceiveDetID = value; }
    }
    public string nPaymentReceiveID
    {
        get { return objnPaymentReceiveID; }
        set { objnPaymentReceiveID = value; }
    }
    public string nInvoiceID
    {
        get { return objnInvoiceID; }
        set { objnInvoiceID = value; }
    }
    public string dtInvoiceDate
    {
        get { return objdtInvoiceDate; }
        set { objdtInvoiceDate = value; }
    }
    public string sInvoiceNo
    {
        get { return objsInvoiceNo; }
        set { objsInvoiceNo = value; }
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
    public string nConfigID
    {
        get { return objnConfigID; }
        set { objnConfigID = value; }
    }
    public string User_Operation(tpayments_receivedet_Class tpayments_receivedet_Class, string type)
    {
        SqlCommand cmd = addParameter(tpayments_receivedet_Class, type, "");
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
    public SqlCommand addParameter(tpayments_receivedet_Class tpayments_receivedet_Class, string type, string cond)
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
        SqlCommand cmd = new SqlCommand("SP_tpayments_receivedet", conn); cmd.Parameters.AddWithValue("@nPaymentReceiveDetID", tpayments_receivedet_Class.nPaymentReceiveDetID);
        cmd.Parameters.AddWithValue("@nPaymentReceiveID", tpayments_receivedet_Class.nPaymentReceiveID);
        cmd.Parameters.AddWithValue("@nInvoiceID", tpayments_receivedet_Class.nInvoiceID);
        cmd.Parameters.AddWithValue("@dtInvoiceDate", tpayments_receivedet_Class.dtInvoiceDate);
        cmd.Parameters.AddWithValue("@sInvoiceNo", tpayments_receivedet_Class.sInvoiceNo);
        cmd.Parameters.AddWithValue("@nAmount", tpayments_receivedet_Class.nAmount);
        cmd.Parameters.AddWithValue("@sRemarks", tpayments_receivedet_Class.sRemarks);
        cmd.Parameters.AddWithValue("@nConfigID", ConfigID);

        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(tpayments_receivedet_Class tpayments_receivedet_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(tpayments_receivedet_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(tpayments_receivedet_Class tpayments_receivedet_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(tpayments_receivedet_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(tpayments_receivedet_Class tpayments_receivedet_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(tpayments_receivedet_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewtpayments_receivedet");
            return ds.Tables["viewtpayments_receivedet"];
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
    public DropDownList ddlOperation(tpayments_receivedet_Class tpayments_receivedet_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(tpayments_receivedet_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewtpayments_receivedet");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a payments_receivedet", "0"));
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
    public DataTable Tabledata(tpayments_receivedet_Class tpayments_receivedet_Class, string type, string cond)
    {
        DataTable da = new DataTable();
        try
        {
            da = viewData(tpayments_receivedet_Class, type, cond);
        }
        catch
        {

        }
        return da;
    }

}
