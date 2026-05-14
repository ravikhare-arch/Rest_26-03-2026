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
public class mairgst_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnAirGstID = string.Empty;
    private string objnAirlineID = string.Empty;
    private string objnAirIGST = string.Empty;
    private string objnAirCGST = string.Empty;
    private string objnAirSGST = string.Empty;
    private string objnConfigID = string.Empty;
    public string nAirGstID
    {
        get { return objnAirGstID; }
        set { objnAirGstID = value; }
    }
    public string nAirlineID
    {
        get { return objnAirlineID; }
        set { objnAirlineID = value; }
    }
    public string nAirIGST
    {
        get { return objnAirIGST; }
        set { objnAirIGST = value; }
    }
    public string nAirCGST
    {
        get { return objnAirCGST; }
        set { objnAirCGST = value; }
    }
    public string nAirSGST
    {
        get { return objnAirSGST; }
        set { objnAirSGST = value; }
    }
    public string nConfigID
    {
        get { return objnConfigID; }
        set { objnConfigID = value; }
    }
    public string User_Operation(mairgst_Class mairgst_Class, string type)
    {
        SqlCommand cmd = addParameter(mairgst_Class, type, "");
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
    public SqlCommand addParameter(mairgst_Class mairgst_Class, string type, string cond)
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
        SqlCommand cmd = new SqlCommand("SP_mairgst", conn); cmd.Parameters.AddWithValue("@nAirGstID", mairgst_Class.nAirGstID);
        cmd.Parameters.AddWithValue("@nAirlineID", mairgst_Class.nAirlineID);
        cmd.Parameters.AddWithValue("@nAirIGST", mairgst_Class.nAirIGST);
        cmd.Parameters.AddWithValue("@nAirCGST", mairgst_Class.nAirCGST);
        cmd.Parameters.AddWithValue("@nAirSGST", mairgst_Class.nAirSGST);
        cmd.Parameters.AddWithValue("@nConfigID", ConfigID);

        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(mairgst_Class mairgst_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(mairgst_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(mairgst_Class mairgst_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(mairgst_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(mairgst_Class mairgst_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(mairgst_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewmairgst");
            return ds.Tables["viewmairgst"];
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
    public DropDownList ddlOperation(mairgst_Class mairgst_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(mairgst_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewmairgst");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a airgst", "0"));
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
