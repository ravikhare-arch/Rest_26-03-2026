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
public class tposted_voucher_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnPostedVoucherID = string.Empty;
    private string objsPostedVoucherNo = string.Empty;
    private string objnVoucherTypeID = string.Empty;
    private string objdtPostedVoucher = string.Empty;
    private string objnStatusID = string.Empty;
    private string objsPostedby = string.Empty;
    private string objsAmendedby = string.Empty;
    private string objnLocationID = string.Empty;
    private string objnConfigID = string.Empty;
    public string nPostedVoucherID
    {
        get { return objnPostedVoucherID; }
        set { objnPostedVoucherID = value; }
    }
    public string sPostedVoucherNo
    {
        get { return objsPostedVoucherNo; }
        set { objsPostedVoucherNo = value; }
    }
    public string nVoucherTypeID
    {
        get { return objnVoucherTypeID; }
        set { objnVoucherTypeID = value; }
    }
    public string dtPostedVoucher
    {
        get { return objdtPostedVoucher; }
        set { objdtPostedVoucher = value; }
    }
    public string nStatusID
    {
        get { return objnStatusID; }
        set { objnStatusID = value; }
    }
    public string sPostedby
    {
        get { return objsPostedby; }
        set { objsPostedby = value; }
    }
    public string sAmendedby
    {
        get { return objsAmendedby; }
        set { objsAmendedby = value; }
    }
    public string nLocationID
    {
        get { return objnLocationID; }
        set { objnLocationID = value; }
    }
    public string nConfigID
    {
        get { return objnConfigID; }
        set { objnConfigID = value; }
    }
    public string User_Operation(tposted_voucher_Class tposted_voucher_Class, string type)
    {
        SqlCommand cmd = addParameter(tposted_voucher_Class, type, "");
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
    public SqlCommand addParameter(tposted_voucher_Class tposted_voucher_Class, string type, string cond)
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
        SqlCommand cmd = new SqlCommand("SP_tposted_voucher", conn); cmd.Parameters.AddWithValue("@nPostedVoucherID", tposted_voucher_Class.nPostedVoucherID);
        cmd.Parameters.AddWithValue("@sPostedVoucherNo", tposted_voucher_Class.sPostedVoucherNo);
        cmd.Parameters.AddWithValue("@nVoucherTypeID", tposted_voucher_Class.nVoucherTypeID);
        cmd.Parameters.AddWithValue("@dtPostedVoucher", tposted_voucher_Class.dtPostedVoucher);
        cmd.Parameters.AddWithValue("@nStatusID", tposted_voucher_Class.nStatusID);
        cmd.Parameters.AddWithValue("@sPostedby", tposted_voucher_Class.sPostedby);
        cmd.Parameters.AddWithValue("@sAmendedby", tposted_voucher_Class.sAmendedby);
        cmd.Parameters.AddWithValue("@nLocationID", tposted_voucher_Class.nLocationID);
        cmd.Parameters.AddWithValue("@nConfigID", ConfigID);

        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(tposted_voucher_Class tposted_voucher_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(tposted_voucher_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(tposted_voucher_Class tposted_voucher_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(tposted_voucher_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(tposted_voucher_Class tposted_voucher_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(tposted_voucher_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewtposted_voucher");
            return ds.Tables["viewtposted_voucher"];
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
    public DropDownList ddlOperation(tposted_voucher_Class tposted_voucher_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(tposted_voucher_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewtposted_voucher");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a posted_voucher", "0"));
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
