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
public class tmofarecruitement_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnBookingID = string.Empty;
    private string objsBookingNo = string.Empty;
    private string objdtBookingDate = string.Empty;
    private string objnClientID = string.Empty;
    private string objnLocationID = string.Empty;
    private string objnSupplierID = string.Empty;
    private string objnMofaRecruitementExpID = string.Empty;
    private string objnMofaRecruitementSalesID = string.Empty;
    private string objnBookTypeID = string.Empty;
    private string objbPaid = string.Empty;
    private string objnConfigID = string.Empty;
  
    public string nBookingID
    {
        get { return objnBookingID; }
        set { objnBookingID = value; }
    }
    public string sBookingNo
    {
        get { return objsBookingNo; }
        set { objsBookingNo = value; }
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
    public string nMofaRecruitementExpID
    {
        get { return objnMofaRecruitementExpID; }
        set { objnMofaRecruitementExpID = value; }
    }
    public string nMofaRecruitementSalesID
    {
        get { return objnMofaRecruitementSalesID; }
        set { objnMofaRecruitementSalesID = value; }
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
    public string User_Operation(tmofarecruitement_Class tmofarecruitement_Class, string type)
    {
        SqlCommand cmd = addParameter(tmofarecruitement_Class, type, "");
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
    public SqlCommand addParameter(tmofarecruitement_Class tmofarecruitement_Class, string type, string cond)
    {
        string uid, ConfigID;
        if (Session["uid"] == null)
            uid = "0";
        else
            uid = Session["uid"].ToString();

        ConfigID = "1";
        conn = connobj.makeConnection();
        SqlCommand cmd = new SqlCommand("SP_tmofarecruitement", conn);
        cmd.Parameters.AddWithValue("@nBookingID", tmofarecruitement_Class.nBookingID);
        cmd.Parameters.AddWithValue("@sBookingNo", tmofarecruitement_Class.sBookingNo);
        cmd.Parameters.AddWithValue("@dtBookingDate", tmofarecruitement_Class.dtBookingDate);
        cmd.Parameters.AddWithValue("@nClientID", tmofarecruitement_Class.nClientID);
        cmd.Parameters.AddWithValue("@nLocationID", tmofarecruitement_Class.nLocationID);
        cmd.Parameters.AddWithValue("@nSupplierID", tmofarecruitement_Class.nSupplierID);
        cmd.Parameters.AddWithValue("@nMofaRecruitementExpID", tmofarecruitement_Class.nMofaRecruitementExpID);
        cmd.Parameters.AddWithValue("@nMofaRecruitementSalesID", tmofarecruitement_Class.nMofaRecruitementSalesID);
        cmd.Parameters.AddWithValue("@nBookTypeID", tmofarecruitement_Class.nBookTypeID);
        cmd.Parameters.AddWithValue("@bPaid", tmofarecruitement_Class.bPaid);
        cmd.Parameters.AddWithValue("@nConfigID", ConfigID);
        cmd.Parameters.AddWithValue("@StartDate", tmofarecruitement_Class.StartDate);
        cmd.Parameters.AddWithValue("@EndDate", tmofarecruitement_Class.EndDate);     
        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(tmofarecruitement_Class tmofarecruitement_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(tmofarecruitement_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(tmofarecruitement_Class tmofarecruitement_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(tmofarecruitement_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(tmofarecruitement_Class tmofarecruitement_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(tmofarecruitement_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewtmofarecruitement");
            return ds.Tables["viewtmofarecruitement"];
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
    public DropDownList ddlOperation(tmofarecruitement_Class tmofarecruitement_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(tmofarecruitement_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewtmofarecruitement");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a mofarecruitement", "0"));
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
    public DataTable Tabledata(tmofarecruitement_Class tmofarecruitement_Class, string type, string cond)
    {
        DataTable da = new DataTable();
        try
        {
            da = viewData(tmofarecruitement_Class, type, cond);
        }
        catch
        {

        }
        return da;
    }
}
