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
public class tadvance_utilise_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnAdvanceUtiliseID = string.Empty;
    private string objnPaymentModeID = string.Empty;
    private string objnCashAccountID = string.Empty;
    private string objdtPayment = string.Empty;
    private string objsVoucherNo = string.Empty;
    private string objnTotAmount = string.Empty;
    private string objsAccountType = string.Empty;
    private string objnAccountID = string.Empty;
    private string objsPayfor = string.Empty;
    private string objsRemarks = string.Empty;
    private string objsPaymentType = string.Empty;
    private string objnConfigID = string.Empty;
    public string nAdvanceUtiliseID
    {
        get { return objnAdvanceUtiliseID; }
        set { objnAdvanceUtiliseID = value; }
    }
    public string nPaymentModeID
    {
        get { return objnPaymentModeID; }
        set { objnPaymentModeID = value; }
    }
    public string nCashAccountID
    {
        get { return objnCashAccountID; }
        set { objnCashAccountID = value; }
    }
    public string dtPayment
    {
        get { return objdtPayment; }
        set { objdtPayment = value; }
    }
    public string sVoucherNo
    {
        get { return objsVoucherNo; }
        set { objsVoucherNo = value; }
    }
    public string nTotAmount
    {
        get { return objnTotAmount; }
        set { objnTotAmount = value; }
    }
    public string sAccountType
    {
        get { return objsAccountType; }
        set { objsAccountType = value; }
    }
    public string nAccountID
    {
        get { return objnAccountID; }
        set { objnAccountID = value; }
    }
    public string sPayfor
    {
        get { return objsPayfor; }
        set { objsPayfor = value; }
    }
    public string sRemarks
    {
        get { return objsRemarks; }
        set { objsRemarks = value; }
    }
    public string sPaymentType
    {
        get { return objsPaymentType; }
        set { objsPaymentType = value; }
    }
    public string nConfigID
    {
        get { return objnConfigID; }
        set { objnConfigID = value; }
    }
    public string User_Operation(tadvance_utilise_Class tadvance_utilise_Class, string type)
    {
        SqlCommand cmd = addParameter(tadvance_utilise_Class, type, "");
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
    public SqlCommand addParameter(tadvance_utilise_Class tadvance_utilise_Class, string type, string cond)
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
        SqlCommand cmd = new SqlCommand("SP_tadvance_utilise", conn); cmd.Parameters.AddWithValue("@nAdvanceUtiliseID", tadvance_utilise_Class.nAdvanceUtiliseID);
        cmd.Parameters.AddWithValue("@nPaymentModeID", tadvance_utilise_Class.nPaymentModeID);
        cmd.Parameters.AddWithValue("@nCashAccountID", tadvance_utilise_Class.nCashAccountID);
        cmd.Parameters.AddWithValue("@dtPayment", tadvance_utilise_Class.dtPayment);
        cmd.Parameters.AddWithValue("@sVoucherNo", tadvance_utilise_Class.sVoucherNo);
        cmd.Parameters.AddWithValue("@nTotAmount", tadvance_utilise_Class.nTotAmount);
        cmd.Parameters.AddWithValue("@sAccountType", tadvance_utilise_Class.sAccountType);
        cmd.Parameters.AddWithValue("@nAccountID", tadvance_utilise_Class.nAccountID);
        cmd.Parameters.AddWithValue("@sPayfor", tadvance_utilise_Class.sPayfor);
        cmd.Parameters.AddWithValue("@sRemarks", tadvance_utilise_Class.sRemarks);
        cmd.Parameters.AddWithValue("@sPaymentType", tadvance_utilise_Class.sPaymentType);
        cmd.Parameters.AddWithValue("@nConfigID", ConfigID);

        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(tadvance_utilise_Class tadvance_utilise_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(tadvance_utilise_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(tadvance_utilise_Class tadvance_utilise_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(tadvance_utilise_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(tadvance_utilise_Class tadvance_utilise_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(tadvance_utilise_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewtadvance_utilise");
            return ds.Tables["viewtadvance_utilise"];
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
    public DropDownList ddlOperation(tadvance_utilise_Class tadvance_utilise_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(tadvance_utilise_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewtadvance_utilise");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a advance_utilise", "0"));
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
