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
public class mvisa_type_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnVisaTypeID = string.Empty;
    private string objsVisaType = string.Empty;
    private string objsDuration = string.Empty;
    private string objnCost = string.Empty;
    private string objnConfigID = string.Empty;
    public string nVisaTypeID
    {
        get { return objnVisaTypeID; }
        set { objnVisaTypeID = value; }
    }
    public string sVisaType
    {
        get { return objsVisaType; }
        set { objsVisaType = value; }
    }
    public string sDuration
    {
        get { return objsDuration; }
        set { objsDuration = value; }
    }
    public string nCost
    {
        get { return objnCost; }
        set { objnCost = value; }
    }
    public string nConfigID
    {
        get { return objnConfigID; }
        set { objnConfigID = value; }
    }
    public string User_Operation(mvisa_type_Class mvisa_type_Class, string type)
    {
        SqlCommand cmd = addParameter(mvisa_type_Class, type, "");
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
    public SqlCommand addParameter(mvisa_type_Class mvisa_type_Class, string type, string cond)
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
        SqlCommand cmd = new SqlCommand("SP_mvisa_type", conn); cmd.Parameters.AddWithValue("@nVisaTypeID", mvisa_type_Class.nVisaTypeID);
        cmd.Parameters.AddWithValue("@sVisaType", mvisa_type_Class.sVisaType);
        cmd.Parameters.AddWithValue("@sDuration", mvisa_type_Class.sDuration);
        cmd.Parameters.AddWithValue("@nCost", mvisa_type_Class.nCost);
        cmd.Parameters.AddWithValue("@nConfigID", ConfigID);

        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(mvisa_type_Class mvisa_type_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(mvisa_type_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(mvisa_type_Class mvisa_type_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(mvisa_type_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(mvisa_type_Class mvisa_type_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(mvisa_type_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewmvisa_type");
            return ds.Tables["viewmvisa_type"];
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
    public DropDownList ddlOperation(mvisa_type_Class mvisa_type_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(mvisa_type_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewmvisa_type");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a visa_type", "0"));
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
