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
public class ttrainbooking_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnTrainBookingID = string.Empty;
    private string objsTrainBookingNo = string.Empty;
    private string objdtBookingDate = string.Empty;
    private string objnClientID = string.Empty;
    private string objnLocationID = string.Empty;
    private string objnSupplierID = string.Empty;
    private string objnTrainExpenseID = string.Empty;
    private string objnTrainSalesID = string.Empty;
    private string objnBookTypeID = string.Empty;
    private string objbPaid = string.Empty;
    private string objnConfigID = string.Empty;
    public string nTrainBookingID
    {
        get { return objnTrainBookingID; }
        set { objnTrainBookingID = value; }
    }
    public string sTrainBookingNo
    {
        get { return objsTrainBookingNo; }
        set { objsTrainBookingNo = value; }
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
    public string nTrainExpenseID
    {
        get { return objnTrainExpenseID; }
        set { objnTrainExpenseID = value; }
    }
    public string nTrainSalesID
    {
        get { return objnTrainSalesID; }
        set { objnTrainSalesID = value; }
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
    public string User_Operation(ttrainbooking_Class ttrainbooking_Class, string type)
    {
        SqlCommand cmd = addParameter(ttrainbooking_Class, type, "");
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
    public SqlCommand addParameter(ttrainbooking_Class ttrainbooking_Class, string type, string cond)
    {
        string uid, nConfigID;
        if (Session["uid"] == null)
            uid = "0";
        else
            uid = Session["uid"].ToString();

        if (Session["ConfigID"] == null)
            nConfigID = "0";
        else
            nConfigID = Session["ConfigID"].ToString();

        conn = connobj.makeConnection();
        SqlCommand cmd = new SqlCommand("SP_ttrainbooking", conn); cmd.Parameters.AddWithValue("@nTrainBookingID", ttrainbooking_Class.nTrainBookingID);
        cmd.Parameters.AddWithValue("@sTrainBookingNo", ttrainbooking_Class.sTrainBookingNo);
        cmd.Parameters.AddWithValue("@dtBookingDate", ttrainbooking_Class.dtBookingDate);
        cmd.Parameters.AddWithValue("@nClientID", ttrainbooking_Class.nClientID);
        cmd.Parameters.AddWithValue("@nLocationID", ttrainbooking_Class.nLocationID);
        cmd.Parameters.AddWithValue("@nSupplierID", ttrainbooking_Class.nSupplierID);
        cmd.Parameters.AddWithValue("@nTrainExpenseID", ttrainbooking_Class.nTrainExpenseID);
        cmd.Parameters.AddWithValue("@nTrainSalesID", ttrainbooking_Class.nTrainSalesID);
        cmd.Parameters.AddWithValue("@nBookTypeID", ttrainbooking_Class.nBookTypeID);
        cmd.Parameters.AddWithValue("@bPaid", ttrainbooking_Class.bPaid);
        cmd.Parameters.AddWithValue("@nConfigID", nConfigID);
        cmd.Parameters.AddWithValue("@StartDate", ttrainbooking_Class.StartDate);
        cmd.Parameters.AddWithValue("@EndDate", ttrainbooking_Class.EndDate);

        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(ttrainbooking_Class ttrainbooking_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(ttrainbooking_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(ttrainbooking_Class ttrainbooking_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(ttrainbooking_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(ttrainbooking_Class ttrainbooking_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(ttrainbooking_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewttrainbooking");
            return ds.Tables["viewttrainbooking"];
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
    public DropDownList ddlOperation(ttrainbooking_Class ttrainbooking_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(ttrainbooking_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewttrainbooking");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a trainbooking", "0"));
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
    public DataTable Tabledata(ttrainbooking_Class ttrainbooking_Class, string type, string cond)
    {
        DataTable da = new DataTable();
        try
        {
            da = viewData(ttrainbooking_Class, type, cond);
        }
        catch
        {

        }
        return da;
    }

}
