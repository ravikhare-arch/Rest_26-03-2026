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
public class tgroupmofa_repeater_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnGroupMofaRPTID = string.Empty;
    private string objnGroupMofaID = string.Empty;
    private string objnRepeaterQty = string.Empty;
    private string objnSupRepeaterRate = string.Empty;
    private string objnSupRPTTotal = string.Empty;
    private string objnClntRepeaterRate = string.Empty;
    private string objnClntRPTTotal = string.Empty;
    private string objsVoucherNo = string.Empty;
    private string objdtRptDate = string.Empty;
    private string objnConfigID = string.Empty;
    public string nGroupMofaRPTID
    {
        get { return objnGroupMofaRPTID; }
        set { objnGroupMofaRPTID = value; }
    }
    public string nGroupMofaID
    {
        get { return objnGroupMofaID; }
        set { objnGroupMofaID = value; }
    }
    public string nRepeaterQty
    {
        get { return objnRepeaterQty; }
        set { objnRepeaterQty = value; }
    }
    public string nSupRepeaterRate
    {
        get { return objnSupRepeaterRate; }
        set { objnSupRepeaterRate = value; }
    }
    public string nSupRPTTotal
    {
        get { return objnSupRPTTotal; }
        set { objnSupRPTTotal = value; }
    }
    public string nClntRepeaterRate
    {
        get { return objnClntRepeaterRate; }
        set { objnClntRepeaterRate = value; }
    }
    public string nClntRPTTotal
    {
        get { return objnClntRPTTotal; }
        set { objnClntRPTTotal = value; }
    }
    public string sVoucherNo
    {
        get { return objsVoucherNo; }
        set { objsVoucherNo = value; }
    }
    public string dtRptDate
    {
        get { return objdtRptDate; }
        set { objdtRptDate = value; }
    }
    public string nConfigID
    {
        get { return objnConfigID; }
        set { objnConfigID = value; }
    }
    public string User_Operation(tgroupmofa_repeater_Class tgroupmofa_repeater_Class, string type)
    {
        SqlCommand cmd = addParameter(tgroupmofa_repeater_Class, type, "");
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
    public SqlCommand addParameter(tgroupmofa_repeater_Class tgroupmofa_repeater_Class, string type, string cond)
    {
        string uid,ConfigID;
        if (Session["uid"] == null)
            uid = "0";
        else
            uid = Session["uid"].ToString();

        if (Session["ConfigID"] == null)
            ConfigID = "0";
        else
            ConfigID = Session["ConfigID"].ToString();


        conn = connobj.makeConnection();
        SqlCommand cmd = new SqlCommand("SP_tgroupmofa_repeater", conn); cmd.Parameters.AddWithValue("@nGroupMofaRPTID", tgroupmofa_repeater_Class.nGroupMofaRPTID);
        cmd.Parameters.AddWithValue("@nGroupMofaID", tgroupmofa_repeater_Class.nGroupMofaID);
        cmd.Parameters.AddWithValue("@nRepeaterQty", tgroupmofa_repeater_Class.nRepeaterQty);
        cmd.Parameters.AddWithValue("@nSupRepeaterRate", tgroupmofa_repeater_Class.nSupRepeaterRate);
        cmd.Parameters.AddWithValue("@nSupRPTTotal", tgroupmofa_repeater_Class.nSupRPTTotal);
        cmd.Parameters.AddWithValue("@nClntRepeaterRate", tgroupmofa_repeater_Class.nClntRepeaterRate);
        cmd.Parameters.AddWithValue("@nClntRPTTotal", tgroupmofa_repeater_Class.nClntRPTTotal);
        cmd.Parameters.AddWithValue("@sVoucherNo", tgroupmofa_repeater_Class.sVoucherNo);
        cmd.Parameters.AddWithValue("@dtRptDate", tgroupmofa_repeater_Class.dtRptDate);
        cmd.Parameters.AddWithValue("@nConfigID", ConfigID);

        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(tgroupmofa_repeater_Class tgroupmofa_repeater_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(tgroupmofa_repeater_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(tgroupmofa_repeater_Class tgroupmofa_repeater_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(tgroupmofa_repeater_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(tgroupmofa_repeater_Class tgroupmofa_repeater_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(tgroupmofa_repeater_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewtgroupmofa_repeater");
            return ds.Tables["viewtgroupmofa_repeater"];
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
    public DropDownList ddlOperation(tgroupmofa_repeater_Class tgroupmofa_repeater_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(tgroupmofa_repeater_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewtgroupmofa_repeater");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a groupmofa_repeater", "0"));
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
