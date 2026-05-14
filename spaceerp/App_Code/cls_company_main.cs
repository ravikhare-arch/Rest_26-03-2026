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
public class company_main_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnCompanyID = string.Empty;
    private string objsCompanyName = string.Empty;
    private string objsAddress = string.Empty;
    private string objsPhone = string.Empty;
    private string objsEmailID = string.Empty;
    private string objsFax = string.Empty;
    private string objsWebsite = string.Empty;
    private string objsCompanyImage = string.Empty;
    private string objnConfigID = string.Empty;
    public string nCompanyID
    {
        get { return objnCompanyID; }
        set { objnCompanyID = value; }
    }
    public string sCompanyName
    {
        get { return objsCompanyName; }
        set { objsCompanyName = value; }
    }
    public string sAddress
    {
        get { return objsAddress; }
        set { objsAddress = value; }
    }
    public string sPhone
    {
        get { return objsPhone; }
        set { objsPhone = value; }
    }
    public string sEmailID
    {
        get { return objsEmailID; }
        set { objsEmailID = value; }
    }
    public string sFax
    {
        get { return objsFax; }
        set { objsFax = value; }
    }
    public string sWebsite
    {
        get { return objsWebsite; }
        set { objsWebsite = value; }
    }
    public string sCompanyImage
    {
        get { return objsCompanyImage; }
        set { objsCompanyImage = value; }
    }
    public string nConfigID
    {
        get { return objnConfigID; }
        set { objnConfigID = value; }
    }
    public string User_Operation(company_main_Class company_main_Class, string type)
    {
        SqlCommand cmd = addParameter(company_main_Class, type, "");
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
    public SqlCommand addParameter(company_main_Class company_main_Class, string type, string cond)
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
        SqlCommand cmd = new SqlCommand("SP_company_main", conn); cmd.Parameters.AddWithValue("@nCompanyID", company_main_Class.nCompanyID);
        cmd.Parameters.AddWithValue("@sCompanyName", company_main_Class.sCompanyName);
        cmd.Parameters.AddWithValue("@sAddress", company_main_Class.sAddress);
        cmd.Parameters.AddWithValue("@sPhone", company_main_Class.sPhone);
        cmd.Parameters.AddWithValue("@sEmailID", company_main_Class.sEmailID);
        cmd.Parameters.AddWithValue("@sFax", company_main_Class.sFax);
        cmd.Parameters.AddWithValue("@sWebsite", company_main_Class.sWebsite);
        cmd.Parameters.AddWithValue("@sCompanyImage", company_main_Class.sCompanyImage);
        cmd.Parameters.AddWithValue("@nConfigID", ConfigID);

        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(company_main_Class company_main_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(company_main_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(company_main_Class company_main_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(company_main_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(company_main_Class company_main_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(company_main_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewcompany_main");
            return ds.Tables["viewcompany_main"];
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
    public DropDownList ddlOperation(company_main_Class company_main_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(company_main_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewcompany_main");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a ompany_main", "0"));
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
