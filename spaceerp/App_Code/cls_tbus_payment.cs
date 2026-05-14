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
public class tbus_payment_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnBusPaymentID = string.Empty;
    private string objnBusBookingID = string.Empty;
    private string objnPaymentModeID = string.Empty;
    private string objdtPayment = string.Empty;
    private string objnAmount = string.Empty;
    private string objnAgentID = string.Empty;
    private string objnCashAccountID = string.Empty;
    private string objsRemarks = string.Empty;
    private string objsVoucherNo = string.Empty;
    private string objnConfigID = string.Empty;
    public string nBusPaymentID
    {
        get { return objnBusPaymentID; }
        set { objnBusPaymentID = value; }
    }
    public string nBusBookingID
    {
        get { return objnBusBookingID; }
        set { objnBusBookingID = value; }
    }
    public string nPaymentModeID
    {
        get { return objnPaymentModeID; }
        set { objnPaymentModeID = value; }
    }
    public string dtPayment
    {
        get { return objdtPayment; }
        set { objdtPayment = value; }
    }
    public string nAmount
    {
        get { return objnAmount; }
        set { objnAmount = value; }
    }
    public string nAgentID
    {
        get { return objnAgentID; }
        set { objnAgentID = value; }
    }
    public string nCashAccountID
    {
        get { return objnCashAccountID; }
        set { objnCashAccountID = value; }
    }
    public string sRemarks
    {
        get { return objsRemarks; }
        set { objsRemarks = value; }
    }
    public string sVoucherNo
    {
        get { return objsVoucherNo; }
        set { objsVoucherNo = value; }
    }
    public string nConfigID
    {
        get { return objnConfigID; }
        set { objnConfigID = value; }
    }
    public string User_Operation(tbus_payment_Class tbus_payment_Class, string type)
    {
        SqlCommand cmd = addParameter(tbus_payment_Class, type, "");
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
    public SqlCommand addParameter(tbus_payment_Class tbus_payment_Class, string type, string cond)
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
        SqlCommand cmd = new SqlCommand("SP_tbus_payment", conn); cmd.Parameters.AddWithValue("@nBusPaymentID", tbus_payment_Class.nBusPaymentID);
        cmd.Parameters.AddWithValue("@nBusBookingID", tbus_payment_Class.nBusBookingID);
        cmd.Parameters.AddWithValue("@nPaymentModeID", tbus_payment_Class.nPaymentModeID);
        cmd.Parameters.AddWithValue("@dtPayment", tbus_payment_Class.dtPayment);
        cmd.Parameters.AddWithValue("@nAmount", tbus_payment_Class.nAmount);
        cmd.Parameters.AddWithValue("@nAgentID", tbus_payment_Class.nAgentID);
        cmd.Parameters.AddWithValue("@nCashAccountID", tbus_payment_Class.nCashAccountID);
        cmd.Parameters.AddWithValue("@sRemarks", tbus_payment_Class.sRemarks);
        cmd.Parameters.AddWithValue("@sVoucherNo", tbus_payment_Class.sVoucherNo);
        cmd.Parameters.AddWithValue("@nConfigID", nConfigID);

        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(tbus_payment_Class tbus_payment_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(tbus_payment_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(tbus_payment_Class tbus_payment_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(tbus_payment_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(tbus_payment_Class tbus_payment_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(tbus_payment_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewtbus_payment");
            return ds.Tables["viewtbus_payment"];
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
    public DropDownList ddlOperation(tbus_payment_Class tbus_payment_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(tbus_payment_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewtbus_payment");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a bus_payment", "0"));
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
