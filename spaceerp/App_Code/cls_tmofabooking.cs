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
public class tmofabooking_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnMofaBookingID = string.Empty;
    private string objsMofaBookingNo = string.Empty;
    private string objdtBookingDate = string.Empty;
    private string objnClientID = string.Empty;
    private string objnLocationID = string.Empty;
    private string objnSupplierID = string.Empty;
    private string objnMofaExpenseID = string.Empty;
    private string objnMofaSalesID = string.Empty;
    private string objnBookTypeID = string.Empty;
    private string objbPaid = string.Empty;
    private string objnConfigID = string.Empty;
    public string nMofaBookingID
    {
        get { return objnMofaBookingID; }
        set { objnMofaBookingID = value; }
    }
    public string sMofaBookingNo
    {
        get { return objsMofaBookingNo; }
        set { objsMofaBookingNo = value; }
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
    public string nMofaExpenseID
    {
        get { return objnMofaExpenseID; }
        set { objnMofaExpenseID = value; }
    }
    public string nMofaSalesID
    {
        get { return objnMofaSalesID; }
        set { objnMofaSalesID = value; }
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
    public string User_Operation(tmofabooking_Class tmofabooking_Class, string type)
    {
        SqlCommand cmd = addParameter(tmofabooking_Class, type, "");
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
    public SqlCommand addParameter(tmofabooking_Class tmofabooking_Class, string type, string cond)
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
        SqlCommand cmd = new SqlCommand("SP_tmofabooking", conn); cmd.Parameters.AddWithValue("@nMofaBookingID", tmofabooking_Class.nMofaBookingID);
        cmd.Parameters.AddWithValue("@sMofaBookingNo", tmofabooking_Class.sMofaBookingNo);
        cmd.Parameters.AddWithValue("@dtBookingDate", tmofabooking_Class.dtBookingDate);
        cmd.Parameters.AddWithValue("@nClientID", tmofabooking_Class.nClientID);
        cmd.Parameters.AddWithValue("@nLocationID", tmofabooking_Class.nLocationID);
        cmd.Parameters.AddWithValue("@nSupplierID", tmofabooking_Class.nSupplierID);
        cmd.Parameters.AddWithValue("@nMofaExpenseID", tmofabooking_Class.nMofaExpenseID);
        cmd.Parameters.AddWithValue("@nMofaSalesID", tmofabooking_Class.nMofaSalesID);
        cmd.Parameters.AddWithValue("@nBookTypeID", tmofabooking_Class.nBookTypeID);
        cmd.Parameters.AddWithValue("@StartDate", tmofabooking_Class.StartDate);
        cmd.Parameters.AddWithValue("@EndDate", tmofabooking_Class.EndDate);
        cmd.Parameters.AddWithValue("@bPaid", tmofabooking_Class.bPaid);
        cmd.Parameters.AddWithValue("@nConfigID", ConfigID);

        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(tmofabooking_Class tmofabooking_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(tmofabooking_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(tmofabooking_Class tmofabooking_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(tmofabooking_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(tmofabooking_Class tmofabooking_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(tmofabooking_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewtmofabooking");
            return ds.Tables["viewtmofabooking"];
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
    public DropDownList ddlOperation(tmofabooking_Class tmofabooking_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(tmofabooking_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewtmofabooking");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a mofabooking", "0"));
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
    public DataTable Tabledata(tmofabooking_Class tmofabooking_Class, string type, string cond)
    {
        DataTable da = new DataTable();
        try
        {
            da = viewData(tmofabooking_Class, type, cond);
        }
        catch
        {

        }
        return da;
    }

}
