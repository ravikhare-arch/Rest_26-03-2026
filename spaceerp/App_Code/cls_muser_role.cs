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
public class muser_role_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnUserRollID = string.Empty;
    private string objnUserID = string.Empty;
    private string objnPageID = string.Empty;
    private string objbPageActive = string.Empty;
    private string objbAdd = string.Empty;
    private string objbEdit = string.Empty;
    private string objbDelete = string.Empty;
    private string objbPrint = string.Empty;
    private string objbList = string.Empty;
    private string objnConfigID = string.Empty;
    public string nUserRollID
    {
        get { return objnUserRollID; }
        set { objnUserRollID = value; }
    }
    public string nUserID
    {
        get { return objnUserID; }
        set { objnUserID = value; }
    }
    public string nPageID
    {
        get { return objnPageID; }
        set { objnPageID = value; }
    }
    public string bPageActive
    {
        get { return objbPageActive; }
        set { objbPageActive = value; }
    }
    public string bAdd
    {
        get { return objbAdd; }
        set { objbAdd = value; }
    }
    public string bEdit
    {
        get { return objbEdit; }
        set { objbEdit = value; }
    }
    public string bDelete
    {
        get { return objbDelete; }
        set { objbDelete = value; }
    }
    public string bPrint
    {
        get { return objbPrint; }
        set { objbPrint = value; }
    }
    public string bList
    {
        get { return objbList; }
        set { objbList = value; }
    }
    public string nConfigID
    {
        get { return objnConfigID; }
        set { objnConfigID = value; }
    }
    public string User_Operation(muser_role_Class muser_role_Class, string type)
    {
        SqlCommand cmd = addParameter(muser_role_Class, type, "");
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
    public SqlCommand addParameter(muser_role_Class muser_role_Class, string type, string cond)
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
        SqlCommand cmd = new SqlCommand("SP_muser_role", conn); cmd.Parameters.AddWithValue("@nUserRollID", muser_role_Class.nUserRollID);
        cmd.Parameters.AddWithValue("@nUserID", muser_role_Class.nUserID);
        cmd.Parameters.AddWithValue("@nPageID", muser_role_Class.nPageID);
        cmd.Parameters.AddWithValue("@bPageActive", muser_role_Class.bPageActive);
        cmd.Parameters.AddWithValue("@bAdd", muser_role_Class.bAdd);
        cmd.Parameters.AddWithValue("@bEdit", muser_role_Class.bEdit);
        cmd.Parameters.AddWithValue("@bDelete", muser_role_Class.bDelete);
        cmd.Parameters.AddWithValue("@bPrint", muser_role_Class.bPrint);
        cmd.Parameters.AddWithValue("@bList", muser_role_Class.bList);
        cmd.Parameters.AddWithValue("@nConfigID", ConfigID);

        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(muser_role_Class muser_role_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(muser_role_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(muser_role_Class muser_role_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(muser_role_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(muser_role_Class muser_role_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(muser_role_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewmuser_role");
            return ds.Tables["viewmuser_role"];
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
    public DropDownList ddlOperation(muser_role_Class muser_role_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(muser_role_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewmuser_role");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a user_role", "0"));
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
