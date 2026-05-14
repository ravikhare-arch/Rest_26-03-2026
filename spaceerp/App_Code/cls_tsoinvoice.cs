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
public class tsoinvoice_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnSoInvoiceID = string.Empty;
    private string objsSoInvoiceNo = string.Empty;
    private string objdtSoInvoice = string.Empty;
    private string objnLocationID = string.Empty;
    private string objnInvoiceFromID = string.Empty;
    private string objnSoID = string.Empty;
    private string objsRefNo = string.Empty;
    private string objnCustomerNameID = string.Empty;
    private string objsRemarks = string.Empty;
    private string objnShipingCost = string.Empty;
    private string objnOtherCharges = string.Empty;
    private string objnDiscount = string.Empty;
    private string objbPaid = string.Empty;
    private string objnConfigID = string.Empty;
    public string nSoInvoiceID
    {
        get { return objnSoInvoiceID; }
        set { objnSoInvoiceID = value; }
    }
    public string sSoInvoiceNo
    {
        get { return objsSoInvoiceNo; }
        set { objsSoInvoiceNo = value; }
    }
    public string dtSoInvoice
    {
        get { return objdtSoInvoice; }
        set { objdtSoInvoice = value; }
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
    public string nSoID
    {
        get { return objnSoID; }
        set { objnSoID = value; }
    }
    public string sRefNo
    {
        get { return objsRefNo; }
        set { objsRefNo = value; }
    }
    public string nCustomerNameID
    {
        get { return objnCustomerNameID; }
        set { objnCustomerNameID = value; }
    }
    public string sRemarks
    {
        get { return objsRemarks; }
        set { objsRemarks = value; }
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
    public string nConfigID
    {
        get { return objnConfigID; }
        set { objnConfigID = value; }
    }
    public string StartDate { get; set; }
    public string EndDate { get; set; }
    public string User_Operation(tsoinvoice_Class tsoinvoice_Class, string type)
    {
        SqlCommand cmd = addParameter(tsoinvoice_Class, type, "");
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
    public SqlCommand addParameter(tsoinvoice_Class tsoinvoice_Class, string type, string cond)
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
        SqlCommand cmd = new SqlCommand("SP_tsoinvoice", conn); cmd.Parameters.AddWithValue("@nSoInvoiceID", tsoinvoice_Class.nSoInvoiceID);
        cmd.Parameters.AddWithValue("@sSoInvoiceNo", tsoinvoice_Class.sSoInvoiceNo);
        cmd.Parameters.AddWithValue("@dtSoInvoice", tsoinvoice_Class.dtSoInvoice);
        cmd.Parameters.AddWithValue("@nLocationID", tsoinvoice_Class.nLocationID);
        cmd.Parameters.AddWithValue("@nInvoiceFromID", tsoinvoice_Class.nInvoiceFromID);
        cmd.Parameters.AddWithValue("@nSoID", tsoinvoice_Class.nSoID);
        cmd.Parameters.AddWithValue("@sRefNo", tsoinvoice_Class.sRefNo);
        cmd.Parameters.AddWithValue("@nCustomerNameID", tsoinvoice_Class.nCustomerNameID);
        cmd.Parameters.AddWithValue("@sRemarks", tsoinvoice_Class.sRemarks);
        cmd.Parameters.AddWithValue("@nShipingCost", tsoinvoice_Class.nShipingCost);
        cmd.Parameters.AddWithValue("@nOtherCharges", tsoinvoice_Class.nOtherCharges);
        cmd.Parameters.AddWithValue("@nDiscount", tsoinvoice_Class.nDiscount);
        cmd.Parameters.AddWithValue("@bPaid", tsoinvoice_Class.bPaid);
        cmd.Parameters.AddWithValue("@nConfigID", ConfigID);
        cmd.Parameters.AddWithValue("@StartDate", tsoinvoice_Class.StartDate);
        cmd.Parameters.AddWithValue("@EndDate", tsoinvoice_Class.EndDate);
        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(tsoinvoice_Class tsoinvoice_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(tsoinvoice_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(tsoinvoice_Class tsoinvoice_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(tsoinvoice_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(tsoinvoice_Class tsoinvoice_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(tsoinvoice_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewtsoinvoice");
            return ds.Tables["viewtsoinvoice"];
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
    public DropDownList ddlOperation(tsoinvoice_Class tsoinvoice_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(tsoinvoice_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewtsoinvoice");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a soinvoice", "0"));
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
    public DataTable Tabledata(tsoinvoice_Class tsoinvoice_Class, string type, string cond)
    {
        DataTable da = new DataTable();
        try
        {
            da = viewData(tsoinvoice_Class, type, cond);
        }
        catch
        {

        }
        return da;
    }

}
