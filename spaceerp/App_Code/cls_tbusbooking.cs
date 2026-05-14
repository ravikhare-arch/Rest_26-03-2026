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
public class tbusbooking_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnBusBookingID = string.Empty;
    private string objsBusBookingNo = string.Empty;
    private string objdtBookingDate = string.Empty;
    private string objnClientID = string.Empty;
    private string objnLocationID = string.Empty;
    private string objnSupplierID = string.Empty;
    private string objnBusExpenseID = string.Empty;
    private string objnBusSalesID = string.Empty;
    private string objnTypeID = string.Empty;
    private string objbPaid = string.Empty;
    private string objnConfigID = string.Empty;
    public string nBusBookingID
    {
        get { return objnBusBookingID; }
        set { objnBusBookingID = value; }
    }
    public string sBusBookingNo
    {
        get { return objsBusBookingNo; }
        set { objsBusBookingNo = value; }
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
    public string nBusExpenseID
    {
        get { return objnBusExpenseID; }
        set { objnBusExpenseID = value; }
    }
    public string nBusSalesID
    {
        get { return objnBusSalesID; }
        set { objnBusSalesID = value; }
    }
    public string nTypeID
    {
        get { return objnTypeID; }
        set { objnTypeID = value; }
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
    public string User_Operation(tbusbooking_Class tbusbooking_Class, string type)
    {
        SqlCommand cmd = addParameter(tbusbooking_Class, type, "");
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
    public SqlCommand addParameter(tbusbooking_Class tbusbooking_Class, string type, string cond)
    {
        string uid;
        if (Session["uid"] == null)
            uid = "0";
        else
            uid = Session["uid"].ToString();

        string nConfigID;
        nConfigID = "1";

        conn = connobj.makeConnection();
        SqlCommand cmd = new SqlCommand("SP_tbusbooking", conn); cmd.Parameters.AddWithValue("@nBusBookingID", tbusbooking_Class.nBusBookingID);
        cmd.Parameters.AddWithValue("@sBusBookingNo", tbusbooking_Class.sBusBookingNo);
        cmd.Parameters.AddWithValue("@dtBookingDate", tbusbooking_Class.dtBookingDate);
        cmd.Parameters.AddWithValue("@nClientID", tbusbooking_Class.nClientID);
        cmd.Parameters.AddWithValue("@nLocationID", tbusbooking_Class.nLocationID);
        cmd.Parameters.AddWithValue("@nSupplierID", tbusbooking_Class.nSupplierID);
        cmd.Parameters.AddWithValue("@nBusExpenseID", tbusbooking_Class.nBusExpenseID);
        cmd.Parameters.AddWithValue("@nBusSalesID", tbusbooking_Class.nBusSalesID);
        cmd.Parameters.AddWithValue("@nTypeID", tbusbooking_Class.nTypeID);
        cmd.Parameters.AddWithValue("@bPaid", tbusbooking_Class.bPaid);
        cmd.Parameters.AddWithValue("@nConfigID", nConfigID);
        cmd.Parameters.AddWithValue("@StartDate", tbusbooking_Class.StartDate);
        cmd.Parameters.AddWithValue("@EndDate", tbusbooking_Class.EndDate);

        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(tbusbooking_Class tbusbooking_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(tbusbooking_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(tbusbooking_Class tbusbooking_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(tbusbooking_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(tbusbooking_Class tbusbooking_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(tbusbooking_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewtbusbooking");
            return ds.Tables["viewtbusbooking"];
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
    public DropDownList ddlOperation(tbusbooking_Class tbusbooking_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(tbusbooking_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewtbusbooking");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a busbooking", "0"));
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
    public DataTable Tabledata(tbusbooking_Class tbusbooking_Class, string type, string cond)
    {
        DataTable da = new DataTable();
        try
        {
            da = viewData(tbusbooking_Class, type, cond);
        }
        catch
        {

        }
        return da;
    }
}
