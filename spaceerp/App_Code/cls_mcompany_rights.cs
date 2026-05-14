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
public class mcompany_rights_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnCompanyRightsID = string.Empty;
    private string objnCompanyID = string.Empty;
    private string objnUserID = string.Empty;
    private string objnConfigID = string.Empty;
    public string nCompanyRightsID
    {
        get { return objnCompanyRightsID; }
        set { objnCompanyRightsID = value; }
    }
    public string nCompanyID
    {
        get { return objnCompanyID; }
        set { objnCompanyID = value; }
    }
    public string nUserID
    {
        get { return objnUserID; }
        set { objnUserID = value; }
    }
    public string nConfigID
    {
        get { return objnConfigID; }
        set { objnConfigID = value; }
    }
    public string User_Operation(mcompany_rights_Class mcompany_rights_Class, string type)
    {
        SqlCommand cmd = addParameter(mcompany_rights_Class, type, "");
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
    public SqlCommand addParameter(mcompany_rights_Class mcompany_rights_Class, string type, string cond)
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
        SqlCommand cmd = new SqlCommand("SP_mcompany_rights", conn); cmd.Parameters.AddWithValue("@nCompanyRightsID", mcompany_rights_Class.nCompanyRightsID);
        cmd.Parameters.AddWithValue("@nCompanyID", mcompany_rights_Class.nCompanyID);
        cmd.Parameters.AddWithValue("@nUserID", mcompany_rights_Class.nUserID);
        cmd.Parameters.AddWithValue("@nConfigID", nConfigID);
        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(mcompany_rights_Class mcompany_rights_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(mcompany_rights_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(mcompany_rights_Class mcompany_rights_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(mcompany_rights_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(mcompany_rights_Class mcompany_rights_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(mcompany_rights_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewmcompany_rights");
            return ds.Tables["viewmcompany_rights"];
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
    public DropDownList ddlOperation(mcompany_rights_Class mcompany_rights_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(mcompany_rights_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewmcompany_rights");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a company_rights", "0"));
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
