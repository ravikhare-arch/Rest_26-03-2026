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
public class mtax_tamplate_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnTaxTamplateId = string.Empty;
    private string objsTamplateName = string.Empty;
    private string objnTamplateForID = string.Empty;
    
    private string objnConfigID = string.Empty;
    public string nTaxTamplateId
    {
        get { return objnTaxTamplateId; }
        set { objnTaxTamplateId = value; }
    }
    public string sTamplateName
    {
        get { return objsTamplateName; }
        set { objsTamplateName = value; }
    }
    public string nTamplateForID
    {
        get { return objnTamplateForID; }
        set { objnTamplateForID = value; }
    }
    
    public string nConfigID
    {
        get { return objnConfigID; }
        set { objnConfigID = value; }
    }
    public string User_Operation(mtax_tamplate_Class mtax_tamplate_Class, string type)
    {
        SqlCommand cmd = addParameter(mtax_tamplate_Class, type, "");
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
    public SqlCommand addParameter(mtax_tamplate_Class mtax_tamplate_Class, string type, string cond)
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
        SqlCommand cmd = new SqlCommand("SP_mtax_tamplate", conn); cmd.Parameters.AddWithValue("@nTaxTamplateId", mtax_tamplate_Class.nTaxTamplateId);
        cmd.Parameters.AddWithValue("@sTamplateName", mtax_tamplate_Class.sTamplateName);
        cmd.Parameters.AddWithValue("@nTamplateForID", mtax_tamplate_Class.nTamplateForID);
        cmd.Parameters.AddWithValue("@nConfigID", ConfigID);
        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(mtax_tamplate_Class mtax_tamplate_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(mtax_tamplate_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(mtax_tamplate_Class mtax_tamplate_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(mtax_tamplate_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(mtax_tamplate_Class mtax_tamplate_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(mtax_tamplate_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewmtax_tamplate");
            return ds.Tables["viewmtax_tamplate"];
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
    public DropDownList ddlOperation(mtax_tamplate_Class mtax_tamplate_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(mtax_tamplate_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewmtax_tamplate");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a Tax Tamplate", "0"));
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
