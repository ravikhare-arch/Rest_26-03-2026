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
public class tcar_booking_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnCarBookingID = string.Empty;
    private string objsCarBookingNo = string.Empty;
    private string objdtCarBooking = string.Empty;
    private string objnClientID = string.Empty;
    private string objnLocationID = string.Empty;
    private string objnSupplierID = string.Empty;
    private string objnCarExpenseID = string.Empty;
    private string objnCarSalesID = string.Empty;
    private string objnBookTypeID = string.Empty;
    private string objbPaid = string.Empty;
    private string objnConfigID = string.Empty;
    public string nCarBookingID
    {
        get { return objnCarBookingID; }
        set { objnCarBookingID = value; }
    }
    public string sCarBookingNo
    {
        get { return objsCarBookingNo; }
        set { objsCarBookingNo = value; }
    }
    public string dtCarBooking
    {
        get { return objdtCarBooking; }
        set { objdtCarBooking = value; }
    }
    public string nClientID
    {
        get { return objnClientID; }
        set { objnClientID = value; }
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
    public string nCarExpenseID
    {
        get { return objnCarExpenseID; }
        set { objnCarExpenseID = value; }
    }
    public string nCarSalesID
    {
        get { return objnCarSalesID; }
        set { objnCarSalesID = value; }
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
    public string User_Operation(tcar_booking_Class tcar_booking_Class, string type)
    {
        SqlCommand cmd = addParameter(tcar_booking_Class, type, "");
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
    public SqlCommand addParameter(tcar_booking_Class tcar_booking_Class, string type, string cond)
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
        SqlCommand cmd = new SqlCommand("SP_tcar_booking", conn); cmd.Parameters.AddWithValue("@nCarBookingID", tcar_booking_Class.nCarBookingID);
        cmd.Parameters.AddWithValue("@sCarBookingNo", tcar_booking_Class.sCarBookingNo);
        cmd.Parameters.AddWithValue("@dtCarBooking", tcar_booking_Class.dtCarBooking);
        cmd.Parameters.AddWithValue("@nClientID", tcar_booking_Class.nClientID);
        cmd.Parameters.AddWithValue("@nLocationID", tcar_booking_Class.nLocationID);
        cmd.Parameters.AddWithValue("@nSupplierID", tcar_booking_Class.nSupplierID);
        cmd.Parameters.AddWithValue("@nCarExpenseID", tcar_booking_Class.nCarExpenseID);
        cmd.Parameters.AddWithValue("@nCarSalesID", tcar_booking_Class.nCarSalesID);
        cmd.Parameters.AddWithValue("@nBookTypeID", tcar_booking_Class.nBookTypeID);
        cmd.Parameters.AddWithValue("@bPaid", tcar_booking_Class.bPaid);
        cmd.Parameters.AddWithValue("@nConfigID", ConfigID);
        cmd.Parameters.AddWithValue("@StartDate", tcar_booking_Class.StartDate);
        cmd.Parameters.AddWithValue("@EndDate", tcar_booking_Class.EndDate);
        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(tcar_booking_Class tcar_booking_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(tcar_booking_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(tcar_booking_Class tcar_booking_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(tcar_booking_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(tcar_booking_Class tcar_booking_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(tcar_booking_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewtcar_booking");
            return ds.Tables["viewtcar_booking"];
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
    public DropDownList ddlOperation(tcar_booking_Class tcar_booking_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(tcar_booking_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewtcar_booking");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a car_booking", "0"));
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
    public DataTable Tabledata(tcar_booking_Class tcar_booking_Class, string type, string cond)
    {
        DataTable da = new DataTable();
        try
        {
            da = viewData(tcar_booking_Class, type, cond);
        }
        catch
        {

        }
        return da;
    }
}
