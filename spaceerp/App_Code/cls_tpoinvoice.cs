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
public class tpoinvoice_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnPoInvoiceID = string.Empty;
    private string objsPoInvoiceNo = string.Empty;
    private string objdtPoInvoice = string.Empty;
    private string objnLocationID = string.Empty;
    private string objnInvoiceFromID = string.Empty;
    private string objnPoID = string.Empty;
    private string objsRefNo = string.Empty;
    private string objnVendorID = string.Empty;
    private string objnShipingCost = string.Empty;
    private string objnOtherCharges = string.Empty;
    private string objnDiscount = string.Empty;
    private string objbPaid = string.Empty;
    private string objsRemarks = string.Empty;
    private string objnCompanyID = string.Empty;
    private string objnFromStateID = string.Empty;
    private string objnToStateID = string.Empty;
    private string objnConfigID = string.Empty;
    public string nPoInvoiceID
    {
        get { return objnPoInvoiceID; }
        set { objnPoInvoiceID = value; }
    }
    public string sPoInvoiceNo
    {
        get { return objsPoInvoiceNo; }
        set { objsPoInvoiceNo = value; }
    }
    public string dtPoInvoice
    {
        get { return objdtPoInvoice; }
        set { objdtPoInvoice = value; }
    }
    public string nLocationID
    {
        get { return objnLocationID; }
        set { objnLocationID = value; }
    }
    public string nInvoiceFromID
    {
        get { return objnInvoiceFromID; }
        set { objnInvoiceFromID = value; }
    }
    public string nPoID
    {
        get { return objnPoID; }
        set { objnPoID = value; }
    }
    public string sRefNo
    {
        get { return objsRefNo; }
        set { objsRefNo = value; }
    }
    public string nVendorID
    {
        get { return objnVendorID; }
        set { objnVendorID = value; }
    }
    public string nShipingCost
    {
        get { return objnShipingCost; }
        set { objnShipingCost = value; }
    }
    public string nOtherCharges
    {
        get { return objnOtherCharges; }
        set { objnOtherCharges = value; }
    }
    public string nDiscount
    {
        get { return objnDiscount; }
        set { objnDiscount = value; }
    }
    public string bPaid
    {
        get { return objbPaid; }
        set { objbPaid = value; }
    }
    public string sRemarks
    {
        get { return objsRemarks; }
        set { objsRemarks = value; }
    }
    public string nCompanyID
    {
        get { return objnCompanyID; }
        set { objnCompanyID = value; }
    }
    public string nFromStateID
    {
        get { return objnFromStateID; }
        set { objnFromStateID = value; }
    }
    public string nToStateID
    {
        get { return objnToStateID; }
        set { objnToStateID = value; }
    }
    public string nConfigID
    {
        get { return objnConfigID; }
        set { objnConfigID = value; }
    }
    public string StartDate { get; set; }
    public string EndDate { get; set; }
    public string User_Operation(tpoinvoice_Class tpoinvoice_Class, string type)
    {
        SqlCommand cmd = addParameter(tpoinvoice_Class, type, "");
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
    public SqlCommand addParameter(tpoinvoice_Class tpoinvoice_Class, string type, string cond)
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
        SqlCommand cmd = new SqlCommand("SP_tpoinvoice", conn); cmd.Parameters.AddWithValue("@nPoInvoiceID", tpoinvoice_Class.nPoInvoiceID);
        cmd.Parameters.AddWithValue("@sPoInvoiceNo", tpoinvoice_Class.sPoInvoiceNo);
        cmd.Parameters.AddWithValue("@dtPoInvoice", tpoinvoice_Class.dtPoInvoice);
        cmd.Parameters.AddWithValue("@nLocationID", tpoinvoice_Class.nLocationID);
        cmd.Parameters.AddWithValue("@nInvoiceFromID", tpoinvoice_Class.nInvoiceFromID);
        cmd.Parameters.AddWithValue("@nPoID", tpoinvoice_Class.nPoID);
        cmd.Parameters.AddWithValue("@sRefNo", tpoinvoice_Class.sRefNo);
        cmd.Parameters.AddWithValue("@nVendorID", tpoinvoice_Class.nVendorID);
        cmd.Parameters.AddWithValue("@nShipingCost", tpoinvoice_Class.nShipingCost);
        cmd.Parameters.AddWithValue("@nOtherCharges", tpoinvoice_Class.nOtherCharges);
        cmd.Parameters.AddWithValue("@nDiscount", tpoinvoice_Class.nDiscount);
        cmd.Parameters.AddWithValue("@bPaid", tpoinvoice_Class.bPaid);
        cmd.Parameters.AddWithValue("@sRemarks", tpoinvoice_Class.sRemarks);
        cmd.Parameters.AddWithValue("@nCompanyID", tpoinvoice_Class.nCompanyID);
        cmd.Parameters.AddWithValue("@nFromStateID", tpoinvoice_Class.nFromStateID);
        cmd.Parameters.AddWithValue("@nToStateID", tpoinvoice_Class.nToStateID);
        cmd.Parameters.AddWithValue("@nConfigID", ConfigID);
        cmd.Parameters.AddWithValue("@StartDate", tpoinvoice_Class.StartDate);
        cmd.Parameters.AddWithValue("@EndDate", tpoinvoice_Class.EndDate);
        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(tpoinvoice_Class tpoinvoice_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(tpoinvoice_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(tpoinvoice_Class tpoinvoice_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(tpoinvoice_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(tpoinvoice_Class tpoinvoice_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(tpoinvoice_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewtpoinvoice");
            return ds.Tables["viewtpoinvoice"];
        }
        catch(Exception ex)
        {
            throw;
        }
        finally
        {
            cmd.Dispose();
            conn = connobj.closeConnection();
        }
    }
    public DropDownList ddlOperation(tpoinvoice_Class tpoinvoice_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(tpoinvoice_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewtpoinvoice");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a poinvoice", "0"));
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
    public DataTable Tabledata(tpoinvoice_Class tpoinvoice_Class, string type, string cond)
    {
        DataTable da = new DataTable();
        try
        {
            da = viewData(tpoinvoice_Class, type, cond);
        }
        catch
        {

        }
        return da;
    }

}
