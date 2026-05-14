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
public class mlocation_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnLocationID = string.Empty;
    private string objsLocationName = string.Empty;
    private string objsAddress = string.Empty;
    private string objsTelephone1 = string.Empty;
    private string objsTelephone2 = string.Empty;
    private string objsFax = string.Empty;
    private string objnConfigID = string.Empty;
    public string nLocationID
    {
        get { return objnLocationID; }
        set { objnLocationID = value; }
    }
    public string sLocationName
    {
        get { return objsLocationName; }
        set { objsLocationName = value; }
    }
    public string sAddress
    {
        get { return objsAddress; }
        set { objsAddress = value; }
    }
    public string sTelephone1
    {
        get { return objsTelephone1; }
        set { objsTelephone1 = value; }
    }
    public string sTelephone2
    {
        get { return objsTelephone2; }
        set { objsTelephone2 = value; }
    }
    public string sFax
    {
        get { return objsFax; }
        set { objsFax = value; }
    }
    public string nConfigID
    {
        get { return objnConfigID; }
        set { objnConfigID = value; }
    }
    public string User_Operation(mlocation_Class mlocation_Class, string type)
    {
        SqlCommand cmd = addParameter(mlocation_Class, type, "");
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
    public SqlCommand addParameter(mlocation_Class mlocation_Class, string type, string cond)
    {
        string uid, nConfigID;
        if (Session["uid"] == null)
            uid = "0";
        else
            uid = Session["uid"].ToString();

        if (Session["ConfigID"] == null)
            nConfigID = "0";
        else
            nConfigID = Session["ConfigID"].ToString();
        conn = connobj.makeConnection();
        SqlCommand cmd = new SqlCommand("SP_mlocation", conn); cmd.Parameters.AddWithValue("@nLocationID", mlocation_Class.nLocationID);
        cmd.Parameters.AddWithValue("@sLocationName", mlocation_Class.sLocationName);
        cmd.Parameters.AddWithValue("@sAddress", mlocation_Class.sAddress);
        cmd.Parameters.AddWithValue("@sTelephone1", mlocation_Class.sTelephone1);
        cmd.Parameters.AddWithValue("@sTelephone2", mlocation_Class.sTelephone2);
        cmd.Parameters.AddWithValue("@sFax", mlocation_Class.sFax);
        cmd.Parameters.AddWithValue("@nConfigID", nConfigID);

        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(mlocation_Class mlocation_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(mlocation_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(mlocation_Class mlocation_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(mlocation_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(mlocation_Class mlocation_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(mlocation_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewmlocation");
            return ds.Tables["viewmlocation"];
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
    public DropDownList ddlOperation(mlocation_Class mlocation_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(mlocation_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewmlocation");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a location", "0"));
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
