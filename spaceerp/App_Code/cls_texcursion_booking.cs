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
public class texcursion_booking_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnExcursionBookingID = string.Empty;
    private string objsExcursionBookingNo = string.Empty;
    private string objdtExcursionBooking = string.Empty;
    private string objnAgentID = string.Empty;
    private string objnLocationID = string.Empty;
    private string objnSupplierID = string.Empty;
    private string objnBookTypeID = string.Empty;
    private string objbPaid = string.Empty;
    private string objnConfigID = string.Empty;
    public string nExcursionBookingID
    {
        get { return objnExcursionBookingID; }
        set { objnExcursionBookingID = value; }
    }
    public string sExcursionBookingNo
    {
        get { return objsExcursionBookingNo; }
        set { objsExcursionBookingNo = value; }
    }
    public string dtExcursionBooking
    {
        get { return objdtExcursionBooking; }
        set { objdtExcursionBooking = value; }
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
    public string nSupplierID
    {
        get { return objnSupplierID; }
        set { objnSupplierID = value; }
    }
    
    public string nBookTypeID
    {
        get { return objnBookTypeID; }
        set { objnBookTypeID = value; }
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
    public string User_Operation(texcursion_booking_Class texcursion_booking_Class, string type)
    {
        SqlCommand cmd = addParameter(texcursion_booking_Class, type, "");
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
    public SqlCommand addParameter(texcursion_booking_Class texcursion_booking_Class, string type, string cond)
    {
        string uid,nConfigID;
        if (Session["uid"] == null)
            uid = "0";
        else
            uid = Session["uid"].ToString();

        if (Session["ConfigID"] == null)
            nConfigID = "0";
        else
            nConfigID = Session["ConfigID"].ToString();

        conn = connobj.makeConnection();
        SqlCommand cmd = new SqlCommand("SP_texcursion_booking", conn); cmd.Parameters.AddWithValue("@nExcursionBookingID", texcursion_booking_Class.nExcursionBookingID);
        cmd.Parameters.AddWithValue("@sExcursionBookingNo", texcursion_booking_Class.sExcursionBookingNo);
        cmd.Parameters.AddWithValue("@dtExcursionBooking", texcursion_booking_Class.dtExcursionBooking);
        cmd.Parameters.AddWithValue("@nAgentID", texcursion_booking_Class.nAgentID);
        cmd.Parameters.AddWithValue("@nLocationID", texcursion_booking_Class.nLocationID);
        cmd.Parameters.AddWithValue("@nSupplierID", texcursion_booking_Class.nSupplierID);
        cmd.Parameters.AddWithValue("@nBookTypeID", texcursion_booking_Class.nBookTypeID);
        cmd.Parameters.AddWithValue("@bPaid", texcursion_booking_Class.bPaid);
        cmd.Parameters.AddWithValue("@nConfigID", nConfigID);
        cmd.Parameters.AddWithValue("@StartDate", texcursion_booking_Class.StartDate);
        cmd.Parameters.AddWithValue("@EndDate", texcursion_booking_Class.EndDate);
        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(texcursion_booking_Class texcursion_booking_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(texcursion_booking_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(texcursion_booking_Class texcursion_booking_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(texcursion_booking_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(texcursion_booking_Class texcursion_booking_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(texcursion_booking_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewtexcursion_booking");
            return ds.Tables["viewtexcursion_booking"];
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
    public DropDownList ddlOperation(texcursion_booking_Class texcursion_booking_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(texcursion_booking_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewtexcursion_booking");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a excursion_booking", "0"));
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
    public DataTable Tabledata(texcursion_booking_Class texcursion_booking_Class, string type, string cond)
    {
        DataTable da = new DataTable();
        try
        {
            da = viewData(texcursion_booking_Class, type, cond);
        }
        catch
        {

        }
        return da;
    }

}
