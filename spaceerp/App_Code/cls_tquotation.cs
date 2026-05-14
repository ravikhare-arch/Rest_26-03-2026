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
public class tquotation_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnQuotationID = string.Empty;
    private string objsQuotationNo = string.Empty;
    private string objnQuotationTypeID = string.Empty;
    private string objsQuotationStatus = string.Empty;
    private string objdtQuotation = string.Empty;
    private string objdtQuotationExpiry = string.Empty;
    private string objnLocationID = string.Empty;
    private string objnCustomerNameID = string.Empty;
    private string objbAttenttion = string.Empty;
    private string objsAttention = string.Empty;
    private string objbNote = string.Empty;
    private string objsNote = string.Empty;
    private string objsRemarks = string.Empty;
    private string objnShipingCost = string.Empty;
    private string objnOtherCharges = string.Empty;
    private string objnDiscount = string.Empty;
    private string objbPaid = string.Empty;
    private string objnConfigID = string.Empty;
    public string nQuotationID
    {
        get { return objnQuotationID; }
        set { objnQuotationID = value; }
    }
    public string sQuotationNo
    {
        get { return objsQuotationNo; }
        set { objsQuotationNo = value; }
    }
    public string nQuotationTypeID
    {
        get { return objnQuotationTypeID; }
        set { objnQuotationTypeID = value; }
    }
    public string sQuotationStatus
    {
        get { return objsQuotationStatus; }
        set { objsQuotationStatus = value; }
    }
    public string dtQuotation
    {
        get { return objdtQuotation; }
        set { objdtQuotation = value; }
    }
    public string dtQuotationExpiry
    {
        get { return objdtQuotationExpiry; }
        set { objdtQuotationExpiry = value; }
    }
    public string nLocationID
    {
        get { return objnLocationID; }
        set { objnLocationID = value; }
    }
    public string nCustomerNameID
    {
        get { return objnCustomerNameID; }
        set { objnCustomerNameID = value; }
    }
    public string bAttenttion
    {
        get { return objbAttenttion; }
        set { objbAttenttion = value; }
    }
    public string sAttention
    {
        get { return objsAttention; }
        set { objsAttention = value; }
    }
    public string bNote
    {
        get { return objbNote; }
        set { objbNote = value; }
    }
    public string sNote
    {
        get { return objsNote; }
        set { objsNote = value; }
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
    public string User_Operation(tquotation_Class tquotation_Class, string type)
    {
        SqlCommand cmd = addParameter(tquotation_Class, type, "");
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
    public SqlCommand addParameter(tquotation_Class tquotation_Class, string type, string cond)
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
        SqlCommand cmd = new SqlCommand("SP_tquotation", conn); cmd.Parameters.AddWithValue("@nQuotationID", tquotation_Class.nQuotationID);
        cmd.Parameters.AddWithValue("@sQuotationNo", tquotation_Class.sQuotationNo);
        cmd.Parameters.AddWithValue("@nQuotationTypeID", tquotation_Class.nQuotationTypeID);
        cmd.Parameters.AddWithValue("@sQuotationStatus", tquotation_Class.sQuotationStatus);
        cmd.Parameters.AddWithValue("@dtQuotation", tquotation_Class.dtQuotation);
        cmd.Parameters.AddWithValue("@dtQuotationExpiry", tquotation_Class.dtQuotationExpiry);
        cmd.Parameters.AddWithValue("@nLocationID", tquotation_Class.nLocationID);
        cmd.Parameters.AddWithValue("@nCustomerNameID", tquotation_Class.nCustomerNameID);
        cmd.Parameters.AddWithValue("@bAttenttion", tquotation_Class.bAttenttion);
        cmd.Parameters.AddWithValue("@sAttention", tquotation_Class.sAttention);
        cmd.Parameters.AddWithValue("@bNote", tquotation_Class.bNote);
        cmd.Parameters.AddWithValue("@sNote", tquotation_Class.sNote);
        cmd.Parameters.AddWithValue("@sRemarks", tquotation_Class.sRemarks);
        cmd.Parameters.AddWithValue("@nShipingCost", tquotation_Class.nShipingCost);
        cmd.Parameters.AddWithValue("@nOtherCharges", tquotation_Class.nOtherCharges);
        cmd.Parameters.AddWithValue("@nDiscount", tquotation_Class.nDiscount);
        cmd.Parameters.AddWithValue("@bPaid", tquotation_Class.bPaid);
        cmd.Parameters.AddWithValue("@nConfigID", Session["ConfigID"].ToString());

        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(tquotation_Class tquotation_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(tquotation_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(tquotation_Class tquotation_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(tquotation_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(tquotation_Class tquotation_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(tquotation_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewtquotation");
            return ds.Tables["viewtquotation"];
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
    public DropDownList ddlOperation(tquotation_Class tquotation_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(tquotation_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewtquotation");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a quotation", "0"));
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
