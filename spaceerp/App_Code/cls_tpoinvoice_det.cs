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
public class tpoinvoice_det_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnPoinvoiceDetID = string.Empty;
    private string objnPoInvoiceID = string.Empty;
    private string objnItemID = string.Empty;
    private string objnItemUnitID = string.Empty;
    private string objnQuantity = string.Empty;
    private string objnUnitPrice = string.Empty;
    private string objnTaxMasterID = string.Empty;
    private string objnCGST = string.Empty;
    private string objnSGST = string.Empty;
    private string objnIGST = string.Empty;
    private string objnCGSTValue = string.Empty;
    private string objnSGSTValue = string.Empty;
    private string objnIGSTValue = string.Empty;
    private string objnOhterTax = string.Empty;
    private string objnDicountPercent = string.Empty;
    private string objnDiscountValue = string.Empty;
    private string objnTotalPrice = string.Empty;
    private string objnConfigID = string.Empty;
    public string nPoinvoiceDetID
    {
        get { return objnPoinvoiceDetID; }
        set { objnPoinvoiceDetID = value; }
    }
    public string nPoInvoiceID
    {
        get { return objnPoInvoiceID; }
        set { objnPoInvoiceID = value; }
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
    public string nTaxMasterID
    {
        get { return objnTaxMasterID; }
        set { objnTaxMasterID = value; }
    }
    public string nCGST
    {
        get { return objnCGST; }
        set { objnCGST = value; }
    }
    public string nSGST
    {
        get { return objnSGST; }
        set { objnSGST = value; }
    }
    public string nIGST
    {
        get { return objnIGST; }
        set { objnIGST = value; }
    }
    public string nCGSTValue
    {
        get { return objnCGSTValue; }
        set { objnCGSTValue = value; }
    }
    public string nSGSTValue
    {
        get { return objnSGSTValue; }
        set { objnSGSTValue = value; }
    }
    public string nIGSTValue
    {
        get { return objnIGSTValue; }
        set { objnIGSTValue = value; }
    }
    public string nOhterTax
    {
        get { return objnOhterTax; }
        set { objnOhterTax = value; }
    }
    public string nDicountPercent
    {
        get { return objnDicountPercent; }
        set { objnDicountPercent = value; }
    }
    public string nDiscountValue
    {
        get { return objnDiscountValue; }
        set { objnDiscountValue = value; }
    }
    public string nTotalPrice
    {
        get { return objnTotalPrice; }
        set { objnTotalPrice = value; }
    }
    public string nConfigID
    {
        get { return objnConfigID; }
        set { objnConfigID = value; }
    }
    public string User_Operation(tpoinvoice_det_Class tpoinvoice_det_Class, string type)
    {
        SqlCommand cmd = addParameter(tpoinvoice_det_Class, type, "");
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
    public SqlCommand addParameter(tpoinvoice_det_Class tpoinvoice_det_Class, string type, string cond)
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
        SqlCommand cmd = new SqlCommand("SP_tpoinvoice_det", conn); cmd.Parameters.AddWithValue("@nPoinvoiceDetID", tpoinvoice_det_Class.nPoinvoiceDetID);
        cmd.Parameters.AddWithValue("@nPoInvoiceID", tpoinvoice_det_Class.nPoInvoiceID);
        cmd.Parameters.AddWithValue("@nItemID", tpoinvoice_det_Class.nItemID);
        cmd.Parameters.AddWithValue("@nItemUnitID", tpoinvoice_det_Class.nItemUnitID);
        cmd.Parameters.AddWithValue("@nQuantity", tpoinvoice_det_Class.nQuantity);
        cmd.Parameters.AddWithValue("@nUnitPrice", tpoinvoice_det_Class.nUnitPrice);
        cmd.Parameters.AddWithValue("@nTaxMasterID", tpoinvoice_det_Class.nTaxMasterID);
        cmd.Parameters.AddWithValue("@nCGST", tpoinvoice_det_Class.nCGST);
        cmd.Parameters.AddWithValue("@nSGST", tpoinvoice_det_Class.nSGST);
        cmd.Parameters.AddWithValue("@nIGST", tpoinvoice_det_Class.nIGST);
        cmd.Parameters.AddWithValue("@nCGSTValue", tpoinvoice_det_Class.nCGSTValue);
        cmd.Parameters.AddWithValue("@nSGSTValue", tpoinvoice_det_Class.nSGSTValue);
        cmd.Parameters.AddWithValue("@nIGSTValue", tpoinvoice_det_Class.nIGSTValue);
        cmd.Parameters.AddWithValue("@nOhterTax", tpoinvoice_det_Class.nOhterTax);
        cmd.Parameters.AddWithValue("@nDicountPercent", tpoinvoice_det_Class.nDicountPercent);
        cmd.Parameters.AddWithValue("@nDiscountValue", tpoinvoice_det_Class.nDiscountValue);
        cmd.Parameters.AddWithValue("@nTotalPrice", tpoinvoice_det_Class.nTotalPrice);
        cmd.Parameters.AddWithValue("@nConfigID", tpoinvoice_det_Class.nConfigID);

        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(tpoinvoice_det_Class tpoinvoice_det_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(tpoinvoice_det_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(tpoinvoice_det_Class tpoinvoice_det_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(tpoinvoice_det_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(tpoinvoice_det_Class tpoinvoice_det_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(tpoinvoice_det_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewtpoinvoice_det");
            return ds.Tables["viewtpoinvoice_det"];
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
    public DropDownList ddlOperation(tpoinvoice_det_Class tpoinvoice_det_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(tpoinvoice_det_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewtpoinvoice_det");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a poinvoice_det", "0"));
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
