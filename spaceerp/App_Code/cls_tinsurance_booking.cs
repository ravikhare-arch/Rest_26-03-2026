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
public class tinsurance_booking_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnInsuranceBookingID = string.Empty;
    private string objsInsuranceBookingNo = string.Empty;
    private string objdtBookingDate = string.Empty;
    private string objnClientID = string.Empty;
    private string objnLocationID = string.Empty;
    private string objnSupplierID = string.Empty;
    private string objnInsuranceExpenseID = string.Empty;
    private string objnInsuranceSalesID = string.Empty;
    private string objnBookTypeID = string.Empty;
    private string objbPaid = string.Empty;
    private string objnConfigID = string.Empty;
    public string nInsuranceBookingID
    {
        get { return objnInsuranceBookingID; }
        set { objnInsuranceBookingID = value; }
    }
    public string sInsuranceBookingNo
    {
        get { return objsInsuranceBookingNo; }
        set { objsInsuranceBookingNo = value; }
    }
    public string dtBookingDate
    {
        get { return objdtBookingDate; }
        set { objdtBookingDate = value; }
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
    public string nInsuranceExpenseID
    {
        get { return objnInsuranceExpenseID; }
        set { objnInsuranceExpenseID = value; }
    }
    public string nInsuranceSalesID
    {
        get { return objnInsuranceSalesID; }
        set { objnInsuranceSalesID = value; }
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
    public string User_Operation(tinsurance_booking_Class tinsurance_booking_Class, string type)
    {
        SqlCommand cmd = addParameter(tinsurance_booking_Class, type, "");
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
    public SqlCommand addParameter(tinsurance_booking_Class tinsurance_booking_Class, string type, string cond)
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
        SqlCommand cmd = new SqlCommand("SP_tinsurance_booking", conn); cmd.Parameters.AddWithValue("@nInsuranceBookingID", tinsurance_booking_Class.nInsuranceBookingID);
        cmd.Parameters.AddWithValue("@sInsuranceBookingNo", tinsurance_booking_Class.sInsuranceBookingNo);
        cmd.Parameters.AddWithValue("@dtBookingDate", tinsurance_booking_Class.dtBookingDate);
        cmd.Parameters.AddWithValue("@nClientID", tinsurance_booking_Class.nClientID);
        cmd.Parameters.AddWithValue("@nLocationID", tinsurance_booking_Class.nLocationID);
        cmd.Parameters.AddWithValue("@nSupplierID", tinsurance_booking_Class.nSupplierID);
        cmd.Parameters.AddWithValue("@nInsuranceExpenseID", tinsurance_booking_Class.nInsuranceExpenseID);
        cmd.Parameters.AddWithValue("@nInsuranceSalesID", tinsurance_booking_Class.nInsuranceSalesID);
        cmd.Parameters.AddWithValue("@nBookTypeID", tinsurance_booking_Class.nBookTypeID);
        cmd.Parameters.AddWithValue("@bPaid", tinsurance_booking_Class.bPaid);
        cmd.Parameters.AddWithValue("@nConfigID", ConfigID);
        cmd.Parameters.AddWithValue("@StartDate", tinsurance_booking_Class.StartDate);
        cmd.Parameters.AddWithValue("@EndDate", tinsurance_booking_Class.EndDate);
        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(tinsurance_booking_Class tinsurance_booking_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(tinsurance_booking_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(tinsurance_booking_Class tinsurance_booking_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(tinsurance_booking_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(tinsurance_booking_Class tinsurance_booking_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(tinsurance_booking_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewtinsurance_booking");
            return ds.Tables["viewtinsurance_booking"];
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
    public DropDownList ddlOperation(tinsurance_booking_Class tinsurance_booking_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(tinsurance_booking_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewtinsurance_booking");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a insurance_booking", "0"));
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
    public DataTable Tabledata(tinsurance_booking_Class tinsurance_booking_Class, string type, string cond)
    {
        DataTable da = new DataTable();
        try
        {
            da = viewData(tinsurance_booking_Class, type, cond);
        }
        catch
        {

        }
        return da;
    }
}
