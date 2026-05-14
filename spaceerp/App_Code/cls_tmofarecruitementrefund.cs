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
public class tmofarecruitementrefund_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnMofaRecruitementRefundID = string.Empty;
    private string objnMofaRecruitementDetID = string.Empty;
    private string objsRefundNo = string.Empty;
    private string objdtRefundDate = string.Empty;
    private string objnRefundAmount = string.Empty;
    private string objnRfnSupScAmount = string.Empty;
    private string objbRfnTax = string.Empty;
    private string objnRfnCGst = string.Empty;
    private string objnRfnSGst = string.Empty;
    private string objnRfnIGst = string.Empty;
    private string objnSupplierRefund = string.Empty;
    private string objnClientRefund = string.Empty;
    private string objsRfnRemaks = string.Empty;
    private string objnRefundAccountID = string.Empty;
    private string objnConfigID = string.Empty;
    public string nMofaRecruitementRefundID
    {
        get { return objnMofaRecruitementRefundID; }
        set { objnMofaRecruitementRefundID = value; }
    }
    public string nMofaRecruitementDetID
    {
        get { return objnMofaRecruitementDetID; }
        set { objnMofaRecruitementDetID = value; }
    }
    public string sRefundNo
    {
        get { return objsRefundNo; }
        set { objsRefundNo = value; }
    }
    public string dtRefundDate
    {
        get { return objdtRefundDate; }
        set { objdtRefundDate = value; }
    }
    public string nRefundAmount
    {
        get { return objnRefundAmount; }
        set { objnRefundAmount = value; }
    }
    public string nRfnSupScAmount
    {
        get { return objnRfnSupScAmount; }
        set { objnRfnSupScAmount = value; }
    }
    public string bRfnTax
    {
        get { return objbRfnTax; }
        set { objbRfnTax = value; }
    }
    public string nRfnCGst
    {
        get { return objnRfnCGst; }
        set { objnRfnCGst = value; }
    }
    public string nRfnSGst
    {
        get { return objnRfnSGst; }
        set { objnRfnSGst = value; }
    }
    public string nRfnIGst
    {
        get { return objnRfnIGst; }
        set { objnRfnIGst = value; }
    }
    public string nSupplierRefund
    {
        get { return objnSupplierRefund; }
        set { objnSupplierRefund = value; }
    }
    public string nClientRefund
    {
        get { return objnClientRefund; }
        set { objnClientRefund = value; }
    }
    public string sRfnRemaks
    {
        get { return objsRfnRemaks; }
        set { objsRfnRemaks = value; }
    }
    public string nRefundAccountID
    {
        get { return objnRefundAccountID; }
        set { objnRefundAccountID = value; }
    }
    public string nConfigID
    {
        get { return objnConfigID; }
        set { objnConfigID = value; }
    }
    public string User_Operation(tmofarecruitementrefund_Class tmofarecruitementrefund_Class, string type)
    {
        SqlCommand cmd = addParameter(tmofarecruitementrefund_Class, type, "");
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
    public SqlCommand addParameter(tmofarecruitementrefund_Class tmofarecruitementrefund_Class, string type, string cond)
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
        SqlCommand cmd = new SqlCommand("SP_tmofarecruitementrefund", conn); cmd.Parameters.AddWithValue("@nMofaRecruitementRefundID", tmofarecruitementrefund_Class.nMofaRecruitementRefundID);
        cmd.Parameters.AddWithValue("@nMofaRecruitementDetID", tmofarecruitementrefund_Class.nMofaRecruitementDetID);
        cmd.Parameters.AddWithValue("@sRefundNo", tmofarecruitementrefund_Class.sRefundNo);
        cmd.Parameters.AddWithValue("@dtRefundDate", tmofarecruitementrefund_Class.dtRefundDate);
        cmd.Parameters.AddWithValue("@nRefundAmount", tmofarecruitementrefund_Class.nRefundAmount);
        cmd.Parameters.AddWithValue("@nRfnSupScAmount", tmofarecruitementrefund_Class.nRfnSupScAmount);
        cmd.Parameters.AddWithValue("@bRfnTax", tmofarecruitementrefund_Class.bRfnTax);
        cmd.Parameters.AddWithValue("@nRfnCGst", tmofarecruitementrefund_Class.nRfnCGst);
        cmd.Parameters.AddWithValue("@nRfnSGst", tmofarecruitementrefund_Class.nRfnSGst);
        cmd.Parameters.AddWithValue("@nRfnIGst", tmofarecruitementrefund_Class.nRfnIGst);
        cmd.Parameters.AddWithValue("@nSupplierRefund", tmofarecruitementrefund_Class.nSupplierRefund);
        cmd.Parameters.AddWithValue("@nClientRefund", tmofarecruitementrefund_Class.nClientRefund);
        cmd.Parameters.AddWithValue("@sRfnRemaks", tmofarecruitementrefund_Class.sRfnRemaks);
        cmd.Parameters.AddWithValue("@nRefundAccountID", tmofarecruitementrefund_Class.nRefundAccountID);
        cmd.Parameters.AddWithValue("@nConfigID", ConfigID);

        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(tmofarecruitementrefund_Class tmofarecruitementrefund_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(tmofarecruitementrefund_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(tmofarecruitementrefund_Class tmofarecruitementrefund_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(tmofarecruitementrefund_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(tmofarecruitementrefund_Class tmofarecruitementrefund_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(tmofarecruitementrefund_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewtmofarecruitementrefund");
            return ds.Tables["viewtmofarecruitementrefund"];
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
    public DropDownList ddlOperation(tmofarecruitementrefund_Class tmofarecruitementrefund_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(tmofarecruitementrefund_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewtmofarecruitementrefund");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a mofarecruitementrefund", "0"));
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
