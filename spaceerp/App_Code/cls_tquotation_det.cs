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
public class tquotation_det_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnQuotationDetID = string.Empty;
    private string objnQuotationID = string.Empty;
    private string objnItemID = string.Empty;
    private string objnCurrentStock = string.Empty;
    private string objnUnitID = string.Empty;
    private string objnQuantity = string.Empty;
    private string objnUnitPrice = string.Empty;
    private string objnTotalPrice = string.Empty;
    private string objnTaxMasterID = string.Empty;
    private string objnTaxTypeID = string.Empty;
    private string objnTaxValue = string.Empty;
    private string objnTaxableAmount = string.Empty;
    private string objnConfigID = string.Empty;
    public string nQuotationDetID
    {
        get { return objnQuotationDetID; }
        set { objnQuotationDetID = value; }
    }
    public string nQuotationID
    {
        get { return objnQuotationID; }
        set { objnQuotationID = value; }
    }
    public string nItemID
    {
        get { return objnItemID; }
        set { objnItemID = value; }
    }
    public string nCurrentStock
    {
        get { return objnCurrentStock; }
        set { objnCurrentStock = value; }
    }
    public string nUnitID
    {
        get { return objnUnitID; }
        set { objnUnitID = value; }
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
    public string nTotalPrice
    {
        get { return objnTotalPrice; }
        set { objnTotalPrice = value; }
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
    public string User_Operation(tquotation_det_Class tquotation_det_Class, string type)
    {
        SqlCommand cmd = addParameter(tquotation_det_Class, type, "");
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
    public SqlCommand addParameter(tquotation_det_Class tquotation_det_Class, string type, string cond)
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
        SqlCommand cmd = new SqlCommand("SP_tquotation_det", conn); cmd.Parameters.AddWithValue("@nQuotationDetID", tquotation_det_Class.nQuotationDetID);
        cmd.Parameters.AddWithValue("@nQuotationID", tquotation_det_Class.nQuotationID);
        cmd.Parameters.AddWithValue("@nItemID", tquotation_det_Class.nItemID);
        cmd.Parameters.AddWithValue("@nCurrentStock", tquotation_det_Class.nCurrentStock);
        cmd.Parameters.AddWithValue("@nUnitID", tquotation_det_Class.nUnitID);
        cmd.Parameters.AddWithValue("@nQuantity", tquotation_det_Class.nQuantity);
        cmd.Parameters.AddWithValue("@nUnitPrice", tquotation_det_Class.nUnitPrice);
        cmd.Parameters.AddWithValue("@nTotalPrice", tquotation_det_Class.nTotalPrice);
        cmd.Parameters.AddWithValue("@nTaxMasterID", tquotation_det_Class.nTaxMasterID);
        cmd.Parameters.AddWithValue("@nTaxTypeID", tquotation_det_Class.nTaxTypeID);
        cmd.Parameters.AddWithValue("@nTaxValue", tquotation_det_Class.nTaxValue);
        cmd.Parameters.AddWithValue("@nTaxableAmount", tquotation_det_Class.nTaxableAmount);
        cmd.Parameters.AddWithValue("@nConfigID", ConfigID);

        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(tquotation_det_Class tquotation_det_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(tquotation_det_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(tquotation_det_Class tquotation_det_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(tquotation_det_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(tquotation_det_Class tquotation_det_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(tquotation_det_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewtquotation_det");
            return ds.Tables["viewtquotation_det"];
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
    public DropDownList ddlOperation(tquotation_det_Class tquotation_det_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(tquotation_det_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewtquotation_det");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a quotation_det", "0"));
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
