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
public class maccount_sub_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnSubAccountID = string.Empty;
    private string objnFamilyID = string.Empty;
    private string objnMainAccountID = string.Empty;
    private string objsSubAccount = string.Empty;
    private string objsCode = string.Empty;
    private string objnConfigID = string.Empty;
    public string nSubAccountID
    {
        get { return objnSubAccountID; }
        set { objnSubAccountID = value; }
    }
    public string nFamilyID
    {
        get { return objnFamilyID; }
        set { objnFamilyID = value; }
    }
    public string nMainAccountID
    {
        get { return objnMainAccountID; }
        set { objnMainAccountID = value; }
    }
    public string sSubAccount
    {
        get { return objsSubAccount; }
        set { objsSubAccount = value; }
    }
    public string sCode
    {
        get { return objsCode; }
        set { objsCode = value; }
    }
    public string nConfigID
    {
        get { return objnConfigID; }
        set { objnConfigID = value; }
    }
    public string User_Operation(maccount_sub_Class maccount_sub_Class, string type)
    {
        SqlCommand cmd = addParameter(maccount_sub_Class, type, "");
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
    public SqlCommand addParameter(maccount_sub_Class maccount_sub_Class, string type, string cond)
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
        SqlCommand cmd = new SqlCommand("SP_maccount_sub", conn); cmd.Parameters.AddWithValue("@nSubAccountID", maccount_sub_Class.nSubAccountID);
        cmd.Parameters.AddWithValue("@nFamilyID", maccount_sub_Class.nFamilyID);
        cmd.Parameters.AddWithValue("@nMainAccountID", maccount_sub_Class.nMainAccountID);
        cmd.Parameters.AddWithValue("@sSubAccount", maccount_sub_Class.sSubAccount);
        cmd.Parameters.AddWithValue("@sCode", maccount_sub_Class.sCode);
        cmd.Parameters.AddWithValue("@nConfigID", ConfigID);

        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(maccount_sub_Class maccount_sub_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(maccount_sub_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
            
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
            

        }
        catch
        {
        }
    }
    public void FillReapter(maccount_sub_Class maccount_sub_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(maccount_sub_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(maccount_sub_Class maccount_sub_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(maccount_sub_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewmsub_account");
            return ds.Tables["viewmsub_account"];
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
    public DropDownList ddlOperation(maccount_sub_Class maccount_sub_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(maccount_sub_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewmsub_account");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a sub_account", "0"));
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
