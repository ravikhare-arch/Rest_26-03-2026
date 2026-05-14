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
public class tgroupmofa_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnGroupMofaID = string.Empty;
    private string objsGMofaBookingNo = string.Empty;
    private string objdtBookingDate = string.Empty;
    private string objnSupplierID = string.Empty;
    private string objnClientID = string.Empty;
    private string objnLocationID = string.Empty;
    private string objnMofaExpenseID = string.Empty;
    private string objnMofaSalesID = string.Empty;
    private string objnBookTypeID = string.Empty;
    
    private string objnBuyingCost = string.Empty;
    private string objnSellingCost = string.Empty;
    private string objbPaid = string.Empty;
    private string objsRemarks = string.Empty;
    private string objbRepeater = string.Empty;
    private string objnConfigID = string.Empty;
    public string nGroupMofaID
    {
        get { return objnGroupMofaID; }
        set { objnGroupMofaID = value; }
    }
    public string sGMofaBookingNo
    {
        get { return objsGMofaBookingNo; }
        set { objsGMofaBookingNo = value; }
    }
    public string dtBookingDate
    {
        get { return objdtBookingDate; }
        set { objdtBookingDate = value; }
    }
    public string nSupplierID
    {
        get { return objnSupplierID; }
        set { objnSupplierID = value; }
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
    
    public string nBuyingCost
    {
        get { return objnBuyingCost; }
        set { objnBuyingCost = value; }
    }
    public string nSellingCost
    {
        get { return objnSellingCost; }
        set { objnSellingCost = value; }
    }
    public string bPaid
    {
        get { return objbPaid; }
        set { objbPaid = value; }
    }
    public string sRemarks
    {
        get { return objsRemarks; }
        set { objsRemarks = value; }
    }
    public string bRepeater
    {
        get { return objbRepeater; }
        set { objbRepeater = value; }
    }
    public string nConfigID
    {
        get { return objnConfigID; }
        set { objnConfigID = value; }
    }
    public string StartDate { get; set; }
    public string EndDate { get; set; }
    public string User_Operation(tgroupmofa_Class tgroupmofa_Class, string type)
    {
        SqlCommand cmd = addParameter(tgroupmofa_Class, type, "");
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
    public SqlCommand addParameter(tgroupmofa_Class tgroupmofa_Class, string type, string cond)
    {
        string uid,ConfigID;
        if (Session["uid"] == null)
            uid = "0";
        else
            uid = Session["uid"].ToString();

        ConfigID = "1";

        conn = connobj.makeConnection();
        SqlCommand cmd = new SqlCommand("SP_tgroupmofa", conn); cmd.Parameters.AddWithValue("@nGroupMofaID", tgroupmofa_Class.nGroupMofaID);
        cmd.Parameters.AddWithValue("@sGMofaBookingNo", tgroupmofa_Class.sGMofaBookingNo);
        cmd.Parameters.AddWithValue("@dtBookingDate", tgroupmofa_Class.dtBookingDate);
        cmd.Parameters.AddWithValue("@nSupplierID", tgroupmofa_Class.nSupplierID);
        cmd.Parameters.AddWithValue("@nClientID", tgroupmofa_Class.nClientID);
        cmd.Parameters.AddWithValue("@nLocationID", tgroupmofa_Class.nLocationID);
        cmd.Parameters.AddWithValue("@nMofaExpenseID", tgroupmofa_Class.nMofaExpenseID);
        cmd.Parameters.AddWithValue("@nMofaSalesID", tgroupmofa_Class.nMofaSalesID);
        cmd.Parameters.AddWithValue("@nBookTypeID", tgroupmofa_Class.nBookTypeID);
       
        cmd.Parameters.AddWithValue("@nBuyingCost", tgroupmofa_Class.nBuyingCost);
        cmd.Parameters.AddWithValue("@nSellingCost", tgroupmofa_Class.nSellingCost);
        cmd.Parameters.AddWithValue("@bPaid", tgroupmofa_Class.bPaid);
        cmd.Parameters.AddWithValue("@sRemarks", tgroupmofa_Class.sRemarks);
        cmd.Parameters.AddWithValue("@bRepeater", tgroupmofa_Class.bRepeater);
        cmd.Parameters.AddWithValue("@nConfigID",ConfigID);
        cmd.Parameters.AddWithValue("@StartDate", tgroupmofa_Class.StartDate);
        cmd.Parameters.AddWithValue("@EndDate", tgroupmofa_Class.EndDate);
        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(tgroupmofa_Class tgroupmofa_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(tgroupmofa_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(tgroupmofa_Class tgroupmofa_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(tgroupmofa_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(tgroupmofa_Class tgroupmofa_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(tgroupmofa_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewtgroupmofa");
            return ds.Tables["viewtgroupmofa"];
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
    public DropDownList ddlOperation(tgroupmofa_Class tgroupmofa_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(tgroupmofa_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewtgroupmofa");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a groupmofa", "0"));
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
    public DataTable Tabledata(tgroupmofa_Class tgroupmofa_Class, string type, string cond)
    {
        DataTable da = new DataTable();
        try
        {
            da = viewData(tgroupmofa_Class, type, cond);
        }
        catch
        {

        }
        return da;
    }

}
