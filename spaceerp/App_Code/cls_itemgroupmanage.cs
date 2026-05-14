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
public class Itemgroupmanage: System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    public string MenuGroupID { get; set; }
     public string MenuGroup { get; set; }
    public string Active { get; set; }
    public string User_Operation(Itemgroupmanage Itemgroupmanage, string type)
    {
        SqlCommand cmd = addParameter(Itemgroupmanage, type, "");
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
    public SqlCommand addParameter(Itemgroupmanage Itemgroupmanage, string type, string cond)
    {
        string uid;
        if (Session["uid"] == null)
            uid = "0";
        else
            uid = Session["uid"].ToString();

        conn = connobj.makeConnection();
        SqlCommand cmd = new SqlCommand("USP_GroupMaster", conn); cmd.Parameters.AddWithValue("@GroupID", Itemgroupmanage.MenuGroupID);       
        cmd.Parameters.AddWithValue("@GroupName", Itemgroupmanage.MenuGroup);
        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(Itemgroupmanage Itemgroupmanage, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(Itemgroupmanage, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(Itemgroupmanage Itemgroupmanage, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(Itemgroupmanage, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(Itemgroupmanage Itemgroupmanage, string type, string cond)
    {
        SqlCommand cmd = addParameter(Itemgroupmanage, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewsalesdebitnote");
            return ds.Tables["viewsalesdebitnote"];
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            cmd.Dispose();
            conn = connobj.closeConnection();
        }
    }
    public DropDownList ddlOperation(Itemgroupmanage Itemgroupmanage, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(Itemgroupmanage, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewsalesdebitnote");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a salesorder", "0"));
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
    public DataTable Tabledata(Itemgroupmanage Itemgroupmanage, string type, string cond)
    {
        DataTable da = new DataTable();
        try
        {
            da = viewData(Itemgroupmanage, type, cond);
        }
        catch
        {

        }
        return da;
    }

}
