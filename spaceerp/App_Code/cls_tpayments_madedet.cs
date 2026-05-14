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
public class tpayments_madedet_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnPaymentMadeDetID = string.Empty;
    private string objnPaymentMadeID = string.Empty;
    private string objnInvoiceID = string.Empty;
    private string objdtInvoiceDate = string.Empty;
    private string objsInvoiceNo = string.Empty;
    private string objnAmount = string.Empty;
    private string objsRemarks = string.Empty;
    private string objnConfigID = string.Empty;
    public string nPaymentMadeDetID
    {
        get { return objnPaymentMadeDetID; }
        set { objnPaymentMadeDetID = value; }
    }
    public string nPaymentMadeID
    {
        get { return objnPaymentMadeID; }
        set { objnPaymentMadeID = value; }
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
    public string User_Operation(tpayments_madedet_Class tpayments_madedet_Class, string type)
    {
        SqlCommand cmd = addParameter(tpayments_madedet_Class, type, "");
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
    public SqlCommand addParameter(tpayments_madedet_Class tpayments_madedet_Class, string type, string cond)
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
        SqlCommand cmd = new SqlCommand("SP_tpayments_madedet", conn); cmd.Parameters.AddWithValue("@nPaymentMadeDetID", tpayments_madedet_Class.nPaymentMadeDetID);
        cmd.Parameters.AddWithValue("@nPaymentMadeID", tpayments_madedet_Class.nPaymentMadeID);
        cmd.Parameters.AddWithValue("@nInvoiceID", tpayments_madedet_Class.nInvoiceID);
        cmd.Parameters.AddWithValue("@dtInvoiceDate", tpayments_madedet_Class.dtInvoiceDate);
        cmd.Parameters.AddWithValue("@sInvoiceNo", tpayments_madedet_Class.sInvoiceNo);
        cmd.Parameters.AddWithValue("@nAmount", tpayments_madedet_Class.nAmount);
        cmd.Parameters.AddWithValue("@sRemarks", tpayments_madedet_Class.sRemarks);
        cmd.Parameters.AddWithValue("@nConfigID", ConfigID);

        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(tpayments_madedet_Class tpayments_madedet_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(tpayments_madedet_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(tpayments_madedet_Class tpayments_madedet_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(tpayments_madedet_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(tpayments_madedet_Class tpayments_madedet_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(tpayments_madedet_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewtpayments_madedet");
            return ds.Tables["viewtpayments_madedet"];
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
    public DropDownList ddlOperation(tpayments_madedet_Class tpayments_madedet_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(tpayments_madedet_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewtpayments_madedet");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a payments_madedet", "0"));
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
    public DataTable Tabledata(tpayments_madedet_Class tpayments_madedet_Class, string type, string cond)
    {
        DataTable da = new DataTable();
        try
        {
            da = viewData(tpayments_madedet_Class, type, cond);
        }
        catch
        {

        }
        return da;
    }

}
