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
public class tvisa_purchase_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnVisaPurchaseId = string.Empty;
    private string objsVisaPurchaseInvoiceNo = string.Empty;
    private string objdtPurchaseBooking = string.Empty;
    private string objnCompanyID = string.Empty;
    private string objnLocationID = string.Empty;
    private string objnVendorID = string.Empty;
    private string objnVisaExpenseID = string.Empty;
    private string objnVisaSalesID = string.Empty;
    private string objbPaid = string.Empty;
    private string objnConfigID = string.Empty;
    public string nVisaPurchaseId
    {
        get { return objnVisaPurchaseId; }
        set { objnVisaPurchaseId = value; }
    }
    public string sVisaPurchaseInvoiceNo
    {
        get { return objsVisaPurchaseInvoiceNo; }
        set { objsVisaPurchaseInvoiceNo = value; }
    }
    public string dtPurchaseBooking
    {
        get { return objdtPurchaseBooking; }
        set { objdtPurchaseBooking = value; }
    }
    public string nCompanyID
    {
        get { return objnCompanyID; }
        set { objnCompanyID = value; }
    }
    public string nLocationID
    {
        get { return objnLocationID; }
        set { objnLocationID = value; }
    }
    public string nVendorID
    {
        get { return objnVendorID; }
        set { objnVendorID = value; }
    }
    public string nVisaExpenseID
    {
        get { return objnVisaExpenseID; }
        set { objnVisaExpenseID = value; }
    }
    public string nVisaSalesID
    {
        get { return objnVisaSalesID; }
        set { objnVisaSalesID = value; }
    }
    public string bPaid
    {
        get { return objbPaid; }
        set { objbPaid = value; }
    }
    public string nConfigID
    {
        get { return objnConfigID; }
        set { objnConfigID = value; }
    }
    public string User_Operation(tvisa_purchase_Class tvisa_purchase_Class, string type)
    {
        SqlCommand cmd = addParameter(tvisa_purchase_Class, type, "");
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
    public SqlCommand addParameter(tvisa_purchase_Class tvisa_purchase_Class, string type, string cond)
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
        SqlCommand cmd = new SqlCommand("SP_tvisa_purchase", conn); cmd.Parameters.AddWithValue("@nVisaPurchaseId", tvisa_purchase_Class.nVisaPurchaseId);
        cmd.Parameters.AddWithValue("@sVisaPurchaseInvoiceNo", tvisa_purchase_Class.sVisaPurchaseInvoiceNo);
        cmd.Parameters.AddWithValue("@dtPurchaseBooking", tvisa_purchase_Class.dtPurchaseBooking);
        cmd.Parameters.AddWithValue("@nCompanyID", tvisa_purchase_Class.nCompanyID);
        cmd.Parameters.AddWithValue("@nLocationID", tvisa_purchase_Class.nLocationID);
        cmd.Parameters.AddWithValue("@nVendorID", tvisa_purchase_Class.nVendorID);
        cmd.Parameters.AddWithValue("@nVisaExpenseID", tvisa_purchase_Class.nVisaExpenseID);
        cmd.Parameters.AddWithValue("@nVisaSalesID", tvisa_purchase_Class.nVisaSalesID);
        cmd.Parameters.AddWithValue("@bPaid", tvisa_purchase_Class.bPaid);
        cmd.Parameters.AddWithValue("@nConfigID", ConfigID);

        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(tvisa_purchase_Class tvisa_purchase_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(tvisa_purchase_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(tvisa_purchase_Class tvisa_purchase_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(tvisa_purchase_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(tvisa_purchase_Class tvisa_purchase_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(tvisa_purchase_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewtvisa_purchase");
            return ds.Tables["viewtvisa_purchase"];
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
    public DropDownList ddlOperation(tvisa_purchase_Class tvisa_purchase_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(tvisa_purchase_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewtvisa_purchase");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a visa_purchase", "0"));
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
