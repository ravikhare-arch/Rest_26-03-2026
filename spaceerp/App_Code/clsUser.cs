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
public class muser_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnuserid = string.Empty;
    private string objsusername = string.Empty;
    private string objspassword = string.Empty;
    private string objnusertype = string.Empty;
    private string objsUserFullName = string.Empty;
    private string objnUserTypeID = string.Empty;
    private string objnDepartmentID = string.Empty;
    private string objnLocationID = string.Empty;
    private string objnConfigID = string.Empty;
     private string objnPageMasterID = string.Empty;

    public string nuserid
    {
        get { return objnuserid; }
        set { objnuserid = value; }
    }
    public string susername
    {
        get { return objsusername; }
        set { objsusername = value; }
    }
    public string spassword
    {
        get { return objspassword; }
        set { objspassword = value; }
    }
    public string nusertype
    {
        get { return objnusertype; }
        set { objnusertype = value; }
    }
    public string sUserFullName
    {
        get { return objsUserFullName; }
        set { objsUserFullName = value; }
    }
    public string nUserTypeID
    {
        get { return objnUserTypeID; }
        set { objnUserTypeID = value; }
    }
    public string nDepartmentID
    {
        get { return objnDepartmentID; }
        set { objnDepartmentID = value; }
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
    public string nPageMasterID
    {
        get { return objnPageMasterID; }
        set { objnPageMasterID = value; }
    }
    public string User_Operation(muser_Class muser_Class, string type)
    {
        SqlCommand cmd = addParameter(muser_Class, type, "");
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
    public SqlCommand addParameter(muser_Class muser_Class, string type, string cond)
    {
        string uid;
        if (Session["uid"] == null)
            uid = "0";
        else
            uid = Session["uid"].ToString();
        if (Session["ConfigID"] == null)
            nConfigID = "0";
        else
            nConfigID = Session["ConfigID"].ToString();
        conn = connobj.makeConnection();
        SqlCommand cmd = new SqlCommand("SP_muser", conn); cmd.Parameters.AddWithValue("@nLoginId", muser_Class.nuserid);
        cmd.Parameters.AddWithValue("@sLogin", muser_Class.susername);
        cmd.Parameters.AddWithValue("@sPassword", muser_Class.spassword);
        cmd.Parameters.AddWithValue("@sUserFullName", muser_Class.sUserFullName);
        cmd.Parameters.AddWithValue("@nUserTypeID", muser_Class.nUserTypeID);
        cmd.Parameters.AddWithValue("@nDepartmentID", muser_Class.nDepartmentID);
        cmd.Parameters.AddWithValue("@nLocationID", muser_Class.nLocationID);
        cmd.Parameters.AddWithValue("@nConfigID", nConfigID);
        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        if (string.IsNullOrEmpty(muser_Class.nPageMasterID))
        {
            muser_Class.nPageMasterID = "0";
        }
        cmd.Parameters.AddWithValue("@nPageMasterID", muser_Class.nPageMasterID);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(muser_Class muser_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(muser_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(muser_Class muser_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(muser_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(muser_Class muser_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(muser_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewmuser");
            return ds.Tables["viewmuser"];
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
    public DropDownList ddlOperation(muser_Class muser_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(muser_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewmuser");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a user", "0"));
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
    public DataTable Tabledata(muser_Class muser_Class, string type, string cond)
    {
        DataTable da = new DataTable();
        try
        {
            da = viewData(muser_Class, type, cond);
            
        }
        catch
        {

        }
        return da;
    }
}