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
public class tsoinvoice_det_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnSoinvoiceDetID = string.Empty;
    private string objnSoInvoiceID = string.Empty;
    private string objnItemID = string.Empty;
    private string objnItemUnitID = string.Empty;
    private string objnCurrentStock = string.Empty;
    private string objnQuantity = string.Empty;
    private string objnUnitPrice = string.Empty;
    private string objnTotPrice = string.Empty;
    private string objnTaxMasterID = string.Empty;
    private string objnTaxTypeID = string.Empty;
    private string objnTaxValue = string.Empty;
    private string objnTaxableAmount = string.Empty;
    private string objnConfigID = string.Empty;
    public string nSoinvoiceDetID
    {
        get { return objnSoinvoiceDetID; }
        set { objnSoinvoiceDetID = value; }
    }
    public string nSoInvoiceID
    {
        get { return objnSoInvoiceID; }
        set { objnSoInvoiceID = value; }
    }
    public string nItemID
    {
        get { return objnItemID; }
        set { objnItemID = value; }
    }
    public string nItemUnitID
    {
        get { return objnItemUnitID; }
        set { objnItemUnitID = value; }
    }
    public string nCurrentStock
    {
        get { return objnCurrentStock; }
        set { objnCurrentStock = value; }
    }
    public string nQuantity
    {
        get { return objnQuantity; }
        set { objnQuantity = value; }
    }
    public string nUnitPrice
    {
        get { return objnUnitPrice; }
        set { objnUnitPrice = value; }
    }
    public string nTotPrice
    {
        get { return objnTotPrice; }
        set { objnTotPrice = value; }
    }
    public string nTaxMasterID
    {
        get { return objnTaxMasterID; }
        set { objnTaxMasterID = value; }
    }
    public string nTaxTypeID
    {
        get { return objnTaxTypeID; }
        set { objnTaxTypeID = value; }
    }
    public string nTaxValue
    {
        get { return objnTaxValue; }
        set { objnTaxValue = value; }
    }
    public string nTaxableAmount
    {
        get { return objnTaxableAmount; }
        set { objnTaxableAmount = value; }
    }
    public string nConfigID
    {
        get { return objnConfigID; }
        set { objnConfigID = value; }
    }

    public string CGST { get; set; }
    public string SGST { get; set; }
    public string IGST { get; set; }
    public string CGSTAmount { get; set; }
    public string SGSTAmount { get; set; }
    public string IGSTAmount { get; set; }

    public string User_Operation(tsoinvoice_det_Class tsoinvoice_det_Class, string type)
    {
        SqlCommand cmd = addParameter(tsoinvoice_det_Class, type, "");
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
    public SqlCommand addParameter(tsoinvoice_det_Class tsoinvoice_det_Class, string type, string cond)
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
        SqlCommand cmd = new SqlCommand("SP_tsoinvoice_det", conn); cmd.Parameters.AddWithValue("@nSoinvoiceDetID", tsoinvoice_det_Class.nSoinvoiceDetID);
        cmd.Parameters.AddWithValue("@nSoInvoiceID", tsoinvoice_det_Class.nSoInvoiceID);
        cmd.Parameters.AddWithValue("@nItemID", tsoinvoice_det_Class.nItemID);
        cmd.Parameters.AddWithValue("@nItemUnitID", tsoinvoice_det_Class.nItemUnitID);
        cmd.Parameters.AddWithValue("@nCurrentStock", tsoinvoice_det_Class.nCurrentStock);
        cmd.Parameters.AddWithValue("@nQuantity", tsoinvoice_det_Class.nQuantity);
        cmd.Parameters.AddWithValue("@nUnitPrice", tsoinvoice_det_Class.nUnitPrice);
        cmd.Parameters.AddWithValue("@nTotPrice", tsoinvoice_det_Class.nTotPrice);
        cmd.Parameters.AddWithValue("@nTaxMasterID", tsoinvoice_det_Class.nTaxMasterID);
        cmd.Parameters.AddWithValue("@nTaxTypeID", tsoinvoice_det_Class.nTaxTypeID);
        cmd.Parameters.AddWithValue("@nTaxValue", tsoinvoice_det_Class.nTaxValue);
        cmd.Parameters.AddWithValue("@nTaxableAmount", tsoinvoice_det_Class.nTaxableAmount);
        cmd.Parameters.AddWithValue("@nConfigID", ConfigID);

        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.Parameters.AddWithValue("@nCGST", tsoinvoice_det_Class.CGST);
        cmd.Parameters.AddWithValue("@nSGST", tsoinvoice_det_Class.SGST);
        cmd.Parameters.AddWithValue("@nIGST", tsoinvoice_det_Class.IGST);
        cmd.Parameters.AddWithValue("@nCGSTValue", tsoinvoice_det_Class.CGSTAmount);
        cmd.Parameters.AddWithValue("@nSGSTValue", tsoinvoice_det_Class.SGSTAmount);
        cmd.Parameters.AddWithValue("@nIGSTValue", tsoinvoice_det_Class.IGSTAmount);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(tsoinvoice_det_Class tsoinvoice_det_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(tsoinvoice_det_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(tsoinvoice_det_Class tsoinvoice_det_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(tsoinvoice_det_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(tsoinvoice_det_Class tsoinvoice_det_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(tsoinvoice_det_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewtsoinvoice_det");
            return ds.Tables["viewtsoinvoice_det"];
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
    public DropDownList ddlOperation(tsoinvoice_det_Class tsoinvoice_det_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(tsoinvoice_det_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewtsoinvoice_det");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a soinvoice_det", "0"));
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
