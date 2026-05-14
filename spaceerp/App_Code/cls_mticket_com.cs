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
public class mticket_com_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnticketcomId = string.Empty;
    private string objnReceivedFromID = string.Empty;
    private string objnAirlineID = string.Empty;
    private string objnSupplierID = string.Empty;
    private string objnTicketTypeID = string.Empty;
    private string objdtStartDate = string.Empty;
    private string objdtEndDate = string.Empty;
    private string objnCalMethodID = string.Empty;
    private string objnInctValue = string.Empty;
    private string objbStatus = string.Empty;
    private string objnConfigID = string.Empty;
    public string nticketcomId
    {
        get { return objnticketcomId; }
        set { objnticketcomId = value; }
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
    public string nInctValue
    {
        get { return objnInctValue; }
        set { objnInctValue = value; }
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
    public string User_Operation(mticket_com_Class mticket_com_Class, string type)
    {
        SqlCommand cmd = addParameter(mticket_com_Class, type, "");
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
    public SqlCommand addParameter(mticket_com_Class mticket_com_Class, string type, string cond)
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
        SqlCommand cmd = new SqlCommand("SP_mticket_com", conn); cmd.Parameters.AddWithValue("@nticketcomId", mticket_com_Class.nticketcomId);
        cmd.Parameters.AddWithValue("@nReceivedFromID", mticket_com_Class.nReceivedFromID);
        cmd.Parameters.AddWithValue("@nAirlineID", mticket_com_Class.nAirlineID);
        cmd.Parameters.AddWithValue("@nSupplierID", mticket_com_Class.nSupplierID);
        cmd.Parameters.AddWithValue("@nTicketTypeID", mticket_com_Class.nTicketTypeID);
        cmd.Parameters.AddWithValue("@dtStartDate", mticket_com_Class.dtStartDate);
        cmd.Parameters.AddWithValue("@dtEndDate", mticket_com_Class.dtEndDate);
        cmd.Parameters.AddWithValue("@nCalMethodID", mticket_com_Class.nCalMethodID);
        cmd.Parameters.AddWithValue("@nInctValue", mticket_com_Class.nInctValue);
        cmd.Parameters.AddWithValue("@bStatus", mticket_com_Class.bStatus);
        cmd.Parameters.AddWithValue("@nConfigID", ConfigID);

        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(mticket_com_Class mticket_com_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(mticket_com_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(mticket_com_Class mticket_com_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(mticket_com_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(mticket_com_Class mticket_com_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(mticket_com_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewmticket_com");
            return ds.Tables["viewmticket_com"];
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
    public DropDownList ddlOperation(mticket_com_Class mticket_com_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(mticket_com_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewmticket_com");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a ticket_com", "0"));
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
