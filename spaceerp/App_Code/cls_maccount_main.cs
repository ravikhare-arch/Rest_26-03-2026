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
public class mmain_account_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnmainaccountid = string.Empty;
    private string objnFamilyID = string.Empty;
    private string objsMainAccountTitle = string.Empty;
    private string objnConfigID = string.Empty;
    public string nmainaccountid
    {
        get { return objnmainaccountid; }
        set { objnmainaccountid = value; }
    }
    public string nFamilyID
    {
        get { return objnFamilyID; }
        set { objnFamilyID = value; }
    }
    public string sMainAccountTitle
    {
        get { return objsMainAccountTitle; }
        set { objsMainAccountTitle = value; }
    }
    public string nConfigID
    {
        get { return objnConfigID; }
        set { objnConfigID = value; }
    }
    public string User_Operation(mmain_account_Class mmain_account_Class, string type)
    {
        SqlCommand cmd = addParameter(mmain_account_Class, type, "");
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
    public SqlCommand addParameter(mmain_account_Class mmain_account_Class, string type, string cond)
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
        SqlCommand cmd = new SqlCommand("SP_maccount_main", conn); cmd.Parameters.AddWithValue("@nmainaccountid", mmain_account_Class.nmainaccountid);
        cmd.Parameters.AddWithValue("@nFamilyID", mmain_account_Class.nFamilyID);
        cmd.Parameters.AddWithValue("@sMainAccountTitle", mmain_account_Class.sMainAccountTitle);
        cmd.Parameters.AddWithValue("@nConfigID", ConfigID);
        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(mmain_account_Class mmain_account_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(mmain_account_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(mmain_account_Class mmain_account_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(mmain_account_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(mmain_account_Class mmain_account_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(mmain_account_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewmmain_account");
            return ds.Tables["viewmmain_account"];
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
    public DropDownList ddlOperation(mmain_account_Class mmain_account_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(mmain_account_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewmmain_account");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            if(Type.ToUpper().Equals("SHOWVOUCHER"))
            { 
            ddl.Items.Add(new ListItem("All", "0"));
            }
            else
            {
                ddl.Items.Add(new ListItem("Choose a Main Account", "0"));
            }
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

    public DropDownList ddlOperationWo(mmain_account_Class mmain_account_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(mmain_account_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewmmain_account");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            
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
    public DataTable DropDown(string type, string cond)
    {
        DataTable da = new DataTable();
        try
        {
            da = viewData(this, type, cond);
        }
        catch (Exception ex)
        {

            //throw;
        }
        return da;
    }
}
