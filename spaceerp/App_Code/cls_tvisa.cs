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
public class tvisa_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnVisaId = string.Empty;
    private string objsVisaBookingNo = string.Empty;
    private string objdtBooking = string.Empty;
    private string objnAgentID = string.Empty;
    private string objnLocationID = string.Empty;
    private string objnVisaCompanyID = string.Empty;
    private string objnVisaExpenseID = string.Empty;
    private string objnVisaSalesID = string.Empty;
    private string objnBookTypeID = string.Empty;
    private string objbPaid = string.Empty;
    private string objnConfigID = string.Empty;
    public string nVisaId
    {
        get { return objnVisaId; }
        set { objnVisaId = value; }
    }
    public string sVisaBookingNo
    {
        get { return objsVisaBookingNo; }
        set { objsVisaBookingNo = value; }
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
    public string nVisaCompanyID
    {
        get { return objnVisaCompanyID; }
        set { objnVisaCompanyID = value; }
    }
    public string nVisaExpenseID
    {
        get { return objnVisaExpenseID; }
        set { objnVisaExpenseID = value; }
    }
    public string nVisaSalesID
    {
        get { return objnVisaSalesID; }
        set { objnVisaSalesID = value; }
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
    public string User_Operation(tvisa_Class tvisa_Class, string type)
    {
        SqlCommand cmd = addParameter(tvisa_Class, type, "");
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
    public SqlCommand addParameter(tvisa_Class tvisa_Class, string type, string cond)
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
        SqlCommand cmd = new SqlCommand("SP_tvisa", conn); cmd.Parameters.AddWithValue("@nVisaId", tvisa_Class.nVisaId);
        cmd.Parameters.AddWithValue("@sVisaBookingNo", tvisa_Class.sVisaBookingNo);
        cmd.Parameters.AddWithValue("@dtBooking", tvisa_Class.dtBooking);
        cmd.Parameters.AddWithValue("@nAgentID", tvisa_Class.nAgentID);
        cmd.Parameters.AddWithValue("@nLocationID", tvisa_Class.nLocationID);
        cmd.Parameters.AddWithValue("@nVisaCompanyID", tvisa_Class.nVisaCompanyID);
        cmd.Parameters.AddWithValue("@nVisaExpenseID", tvisa_Class.nVisaExpenseID);
        cmd.Parameters.AddWithValue("@nVisaSalesID", tvisa_Class.nVisaSalesID);
        cmd.Parameters.AddWithValue("@nBookTypeID", tvisa_Class.nBookTypeID);
        cmd.Parameters.AddWithValue("@bPaid", tvisa_Class.bPaid);
        cmd.Parameters.AddWithValue("@nConfigID", ConfigID);
        cmd.Parameters.AddWithValue("@StartDate", tvisa_Class.StartDate);
        cmd.Parameters.AddWithValue("@EndDate", tvisa_Class.EndDate);

        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(tvisa_Class tvisa_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(tvisa_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(tvisa_Class tvisa_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(tvisa_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(tvisa_Class tvisa_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(tvisa_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewtvisa");
            return ds.Tables["viewtvisa"];
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
    public DropDownList ddlOperation(tvisa_Class tvisa_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(tvisa_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewtvisa");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a visa", "0"));
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
    public DataTable Tabledata(tvisa_Class tvisa_Class, string type, string cond)
    {
        DataTable da = new DataTable();
        try
        {
            da = viewData(tvisa_Class, type, cond);
        }
        catch
        {

        }
        return da;
    }
}
