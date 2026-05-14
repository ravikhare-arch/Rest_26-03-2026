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
public class tticketing_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnTicketingID = string.Empty;
    private string objnTicketTypeID = string.Empty;
    private string objsTicketBookingNo = string.Empty;
    private string objdtBooking = string.Empty;
    private string objnAgentID = string.Empty;
    private string objnLocationID = string.Empty;
    private string objnTicketingCompanyID = string.Empty;
    private string objnTicketExpenseID = string.Empty;
    private string objnTicketSalesID = string.Empty;
    private string objnSupplierID = string.Empty;
    private string objbPaid = string.Empty;
    private string objnConfigID = string.Empty;
    public string nTicketingID
    {
        get { return objnTicketingID; }
        set { objnTicketingID = value; }
    }
    public string nTicketTypeID
    {
        get { return objnTicketTypeID; }
        set { objnTicketTypeID = value; }
    }
    public string sTicketBookingNo
    {
        get { return objsTicketBookingNo; }
        set { objsTicketBookingNo = value; }
    }
    public string dtBooking
    {
        get { return objdtBooking; }
        set { objdtBooking = value; }
    }
    public string nAgentID
    {
        get { return objnAgentID; }
        set { objnAgentID = value; }
    }
    public string nLocationID
    {
        get { return objnLocationID; }
        set { objnLocationID = value; }
    }
    public string nTicketingCompanyID
    {
        get { return objnTicketingCompanyID; }
        set { objnTicketingCompanyID = value; }
    }
    public string nTicketExpenseID
    {
        get { return objnTicketExpenseID; }
        set { objnTicketExpenseID = value; }
    }
    public string nTicketSalesID
    {
        get { return objnTicketSalesID; }
        set { objnTicketSalesID = value; }
    }
    public string nSupplierID
    {
        get { return objnSupplierID; }
        set { objnSupplierID = value; }
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
    public string bAutoInvoice { get; set; }
    public string StartDate { get; set; }
    public string EndDate { get; set; }
    public string User_Operation(tticketing_Class tticketing_Class, string type)
    {
        SqlCommand cmd = addParameter(tticketing_Class, type, "");
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
    public SqlCommand addParameter(tticketing_Class tticketing_Class, string type, string cond)
    {
        string uid, nConfig;
        if (Session["uid"] == null)
            uid = "0";
        else
            uid = Session["uid"].ToString();

        if (Session["ConfigID"] == null)
            nConfig = "0";
        else
            nConfig = Session["ConfigID"].ToString();

        conn = connobj.makeConnection();
        SqlCommand cmd = new SqlCommand("SP_tticketing", conn); cmd.Parameters.AddWithValue("@nTicketingID", tticketing_Class.nTicketingID);
        cmd.Parameters.AddWithValue("@nTicketTypeID", tticketing_Class.nTicketTypeID);
        cmd.Parameters.AddWithValue("@sTicketBookingNo", tticketing_Class.sTicketBookingNo);
        cmd.Parameters.AddWithValue("@dtBooking", tticketing_Class.dtBooking);
        cmd.Parameters.AddWithValue("@nAgentID", tticketing_Class.nAgentID);
        cmd.Parameters.AddWithValue("@nLocationID", tticketing_Class.nLocationID);
        cmd.Parameters.AddWithValue("@nTicketingCompanyID", tticketing_Class.nTicketingCompanyID);
        cmd.Parameters.AddWithValue("@nTicketExpenseID", tticketing_Class.nTicketExpenseID);
        cmd.Parameters.AddWithValue("@nTicketSalesID", tticketing_Class.nTicketSalesID);
        cmd.Parameters.AddWithValue("@nSupplierID", tticketing_Class.nSupplierID);
        cmd.Parameters.AddWithValue("@bPaid", tticketing_Class.bPaid);
        cmd.Parameters.AddWithValue("@bAutoInvoice", tticketing_Class.bAutoInvoice);
        cmd.Parameters.AddWithValue("@StartDate", tticketing_Class.StartDate);
        cmd.Parameters.AddWithValue("@EndDate", tticketing_Class.EndDate);
        cmd.Parameters.AddWithValue("@nConfigID", nConfig);

        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(tticketing_Class tticketing_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(tticketing_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(tticketing_Class tticketing_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(tticketing_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(tticketing_Class tticketing_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(tticketing_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewtticketing");
            return ds.Tables["viewtticketing"];
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
    public DropDownList ddlOperation(tticketing_Class tticketing_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(tticketing_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewtticketing");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a ticketing", "0"));
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
    public DataTable Tabledata(tticketing_Class tticketing_Class, string type, string cond)
    {
        DataTable da = new DataTable();
        try
        {
            da = viewData(tticketing_Class, type, cond);
        }
        catch
        {

        }
        return da;
    }

}
