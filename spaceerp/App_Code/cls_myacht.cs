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
public class myacht_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnYachtID = string.Empty;
    private string objsYachtName = string.Empty;
    private string objsDimension = string.Empty;
    private string objsMaxLoad = string.Empty;
    private string objsMaxPeople = string.Empty;
    private string objnConfigID = string.Empty;
    public string nYachtID
    {
        get { return objnYachtID; }
        set { objnYachtID = value; }
    }
    public string sYachtName
    {
        get { return objsYachtName; }
        set { objsYachtName = value; }
    }
    public string sDimension
    {
        get { return objsDimension; }
        set { objsDimension = value; }
    }
    public string sMaxLoad
    {
        get { return objsMaxLoad; }
        set { objsMaxLoad = value; }
    }
    public string sMaxPeople
    {
        get { return objsMaxPeople; }
        set { objsMaxPeople = value; }
    }
    public string nConfigID
    {
        get { return objnConfigID; }
        set { objnConfigID = value; }
    }
    public string User_Operation(myacht_Class myacht_Class, string type)
    {
        SqlCommand cmd = addParameter(myacht_Class, type, "");
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
    public SqlCommand addParameter(myacht_Class myacht_Class, string type, string cond)
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
        SqlCommand cmd = new SqlCommand("SP_myacht", conn); cmd.Parameters.AddWithValue("@nYachtID", myacht_Class.nYachtID);
        cmd.Parameters.AddWithValue("@sYachtName", myacht_Class.sYachtName);
        cmd.Parameters.AddWithValue("@sDimension", myacht_Class.sDimension);
        cmd.Parameters.AddWithValue("@sMaxLoad", myacht_Class.sMaxLoad);
        cmd.Parameters.AddWithValue("@sMaxPeople", myacht_Class.sMaxPeople);
        cmd.Parameters.AddWithValue("@nConfigID", ConfigID);
        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(myacht_Class myacht_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(myacht_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(myacht_Class myacht_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(myacht_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(myacht_Class myacht_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(myacht_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewmyacht");
            return ds.Tables["viewmyacht"];
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
    public DropDownList ddlOperation(myacht_Class myacht_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(myacht_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewmyacht");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a yacht", "0"));
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
