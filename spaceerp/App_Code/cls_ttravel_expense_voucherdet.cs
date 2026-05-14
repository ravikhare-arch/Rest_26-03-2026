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
public class ttravel_expense_voucherdet_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnTravelExpenseVoucherDetID = string.Empty;
    private string objnTravelExpenseVoucherID = string.Empty;
    private string objnDriverID = string.Empty;
    private string objnVehicleID = string.Empty;
    private string objnExpenseAccountID = string.Empty;
    private string objnExpenseCatID = string.Empty;
    private string objnAmount = string.Empty;
    private string objsDescription = string.Empty;
    private string objsRemarks = string.Empty;
    private string objnConfigId = string.Empty;
    public string nTravelExpenseVoucherDetID
    {
        get { return objnTravelExpenseVoucherDetID; }
        set { objnTravelExpenseVoucherDetID = value; }
    }
    public string nTravelExpenseVoucherID
    {
        get { return objnTravelExpenseVoucherID; }
        set { objnTravelExpenseVoucherID = value; }
    }
    public string nDriverID
    {
        get { return objnDriverID; }
        set { objnDriverID = value; }
    }
    public string nVehicleID
    {
        get { return objnVehicleID; }
        set { objnVehicleID = value; }
    }
    public string nExpenseAccountID
    {
        get { return objnExpenseAccountID; }
        set { objnExpenseAccountID = value; }
    }
    public string nExpenseCatID
    {
        get { return objnExpenseCatID; }
        set { objnExpenseCatID = value; }
    }
    public string nAmount
    {
        get { return objnAmount; }
        set { objnAmount = value; }
    }
    public string sDescription
    {
        get { return objsDescription; }
        set { objsDescription = value; }
    }
    public string sRemarks
    {
        get { return objsRemarks; }
        set { objsRemarks = value; }
    }
    public string nConfigId
    {
        get { return objnConfigId; }
        set { objnConfigId = value; }
    }
    public string User_Operation(ttravel_expense_voucherdet_Class ttravel_expense_voucherdet_Class, string type)
    {
        SqlCommand cmd = addParameter(ttravel_expense_voucherdet_Class, type, "");
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
    public SqlCommand addParameter(ttravel_expense_voucherdet_Class ttravel_expense_voucherdet_Class, string type, string cond)
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
        SqlCommand cmd = new SqlCommand("SP_ttravel_expense_voucherdet", conn); cmd.Parameters.AddWithValue("@nTravelExpenseVoucherDetID", ttravel_expense_voucherdet_Class.nTravelExpenseVoucherDetID);
        cmd.Parameters.AddWithValue("@nTravelExpenseVoucherID", ttravel_expense_voucherdet_Class.nTravelExpenseVoucherID);
        cmd.Parameters.AddWithValue("@nDriverID", ttravel_expense_voucherdet_Class.nDriverID);
        cmd.Parameters.AddWithValue("@nVehicleID", ttravel_expense_voucherdet_Class.nVehicleID);
        cmd.Parameters.AddWithValue("@nExpenseAccountID", ttravel_expense_voucherdet_Class.nExpenseAccountID);
        cmd.Parameters.AddWithValue("@nExpenseCatID", ttravel_expense_voucherdet_Class.nExpenseCatID);
        cmd.Parameters.AddWithValue("@nAmount", ttravel_expense_voucherdet_Class.nAmount);
        cmd.Parameters.AddWithValue("@sDescription", ttravel_expense_voucherdet_Class.sDescription);
        cmd.Parameters.AddWithValue("@sRemarks", ttravel_expense_voucherdet_Class.sRemarks);
        cmd.Parameters.AddWithValue("@nConfigId", ConfigID);
        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(ttravel_expense_voucherdet_Class ttravel_expense_voucherdet_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(ttravel_expense_voucherdet_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(ttravel_expense_voucherdet_Class ttravel_expense_voucherdet_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(ttravel_expense_voucherdet_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(ttravel_expense_voucherdet_Class ttravel_expense_voucherdet_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(ttravel_expense_voucherdet_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewttravel_expense_voucherdet");
            return ds.Tables["viewttravel_expense_voucherdet"];
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
    public DropDownList ddlOperation(ttravel_expense_voucherdet_Class ttravel_expense_voucherdet_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(ttravel_expense_voucherdet_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewttravel_expense_voucherdet");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a travel_expense_voucherdet", "0"));
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
