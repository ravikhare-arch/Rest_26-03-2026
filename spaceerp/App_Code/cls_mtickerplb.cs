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
public class mtickerplb_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnticketplbId = string.Empty;
    private string objnReceivedFromID = string.Empty;
    private string objnAirlineID = string.Empty;
    private string objnSupplierID = string.Empty;
    private string objnTicketTypeID = string.Empty;
    private string objdtStartDate = string.Empty;
    private string objdtEndDate = string.Empty;
    private string objnCalMethodID = string.Empty;
    private string objnClassID = string.Empty;
    private string objnGrossNetID = string.Empty;
    private string objnAutoManualID = string.Empty;
    private string objnIncValue = string.Empty;
    private string objbStatus = string.Empty;
    private string objnConfigID = string.Empty;
    public string nticketplbId
    {
        get { return objnticketplbId; }
        set { objnticketplbId = value; }
    }
    public string nReceivedFromID
    {
        get { return objnReceivedFromID; }
        set { objnReceivedFromID = value; }
    }
    public string nAirlineID
    {
        get { return objnAirlineID; }
        set { objnAirlineID = value; }
    }
    public string nSupplierID
    {
        get { return objnSupplierID; }
        set { objnSupplierID = value; }
    }
    public string nTicketTypeID
    {
        get { return objnTicketTypeID; }
        set { objnTicketTypeID = value; }
    }
    public string dtStartDate
    {
        get { return objdtStartDate; }
        set { objdtStartDate = value; }
    }
    public string dtEndDate
    {
        get { return objdtEndDate; }
        set { objdtEndDate = value; }
    }
    public string nCalMethodID
    {
        get { return objnCalMethodID; }
        set { objnCalMethodID = value; }
    }
    public string nClassID
    {
        get { return objnClassID; }
        set { objnClassID = value; }
    }
    public string nGrossNetID
    {
        get { return objnGrossNetID; }
        set { objnGrossNetID = value; }
    }
    public string nAutoManualID
    {
        get { return objnAutoManualID; }
        set { objnAutoManualID = value; }
    }
    public string nIncValue
    {
        get { return objnIncValue; }
        set { objnIncValue = value; }
    }
    public string bStatus
    {
        get { return objbStatus; }
        set { objbStatus = value; }
    }
    public string nConfigID
    {
        get { return objnConfigID; }
        set { objnConfigID = value; }
    }
    public string User_Operation(mtickerplb_Class mtickerplb_Class, string type)
    {
        SqlCommand cmd = addParameter(mtickerplb_Class, type, "");
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
    public SqlCommand addParameter(mtickerplb_Class mtickerplb_Class, string type, string cond)
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
        SqlCommand cmd = new SqlCommand("SP_mtickerplb", conn); cmd.Parameters.AddWithValue("@nticketplbId", mtickerplb_Class.nticketplbId);
        cmd.Parameters.AddWithValue("@nReceivedFromID", mtickerplb_Class.nReceivedFromID);
        cmd.Parameters.AddWithValue("@nAirlineID", mtickerplb_Class.nAirlineID);
        cmd.Parameters.AddWithValue("@nSupplierID", mtickerplb_Class.nSupplierID);
        cmd.Parameters.AddWithValue("@nTicketTypeID", mtickerplb_Class.nTicketTypeID);
        cmd.Parameters.AddWithValue("@dtStartDate", mtickerplb_Class.dtStartDate);
        cmd.Parameters.AddWithValue("@dtEndDate", mtickerplb_Class.dtEndDate);
        cmd.Parameters.AddWithValue("@nCalMethodID", mtickerplb_Class.nCalMethodID);
        cmd.Parameters.AddWithValue("@nClassID", mtickerplb_Class.nClassID);
        cmd.Parameters.AddWithValue("@nGrossNetID", mtickerplb_Class.nGrossNetID);
        cmd.Parameters.AddWithValue("@nAutoManualID", mtickerplb_Class.nAutoManualID);
        cmd.Parameters.AddWithValue("@nIncValue", mtickerplb_Class.nIncValue);
        cmd.Parameters.AddWithValue("@bStatus", mtickerplb_Class.bStatus);
        cmd.Parameters.AddWithValue("@nConfigID", ConfigID);

        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(mtickerplb_Class mtickerplb_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(mtickerplb_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(mtickerplb_Class mtickerplb_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(mtickerplb_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(mtickerplb_Class mtickerplb_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(mtickerplb_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewmtickerplb");
            return ds.Tables["viewmtickerplb"];
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
    public DropDownList ddlOperation(mtickerplb_Class mtickerplb_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(mtickerplb_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewmtickerplb");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a tickerplb", "0"));
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
