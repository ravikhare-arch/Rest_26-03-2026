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
public class mtest_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objntestid = string.Empty;
    private string objstestname = string.Empty;
    private string objsaddress = string.Empty;
    private string objbNiote = string.Empty;
    public string ntestid
    {
        get { return objntestid; }
        set { objntestid = value; }
    }
    public string stestname
    {
        get { return objstestname; }
        set { objstestname = value; }
    }
    public string saddress
    {
        get { return objsaddress; }
        set { objsaddress = value; }
    }
    public string bNiote
    {
        get { return objbNiote; }
        set { objbNiote = value; }
    }
    public string User_Operation(mtest_Class mtest_Class, string type)
    {
        SqlCommand cmd = addParameter(mtest_Class, type, "");
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
    public SqlCommand addParameter(mtest_Class mtest_Class, string type, string cond)
    {
        string uid;
        if (Session["uid"] == null)
            uid = "0";
        else
            uid = Session["uid"].ToString();
        conn = connobj.makeConnection();
        SqlCommand cmd = new SqlCommand("SP_mtest", conn); cmd.Parameters.AddWithValue("@ntestid", mtest_Class.ntestid);
        cmd.Parameters.AddWithValue("@stestname", mtest_Class.stestname);
        cmd.Parameters.AddWithValue("@saddress", mtest_Class.saddress);
        cmd.Parameters.AddWithValue("@bNiote", mtest_Class.bNiote);

        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(mtest_Class mtest_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(mtest_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(mtest_Class mtest_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(mtest_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(mtest_Class mtest_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(mtest_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewmtest");
            return ds.Tables["viewmtest"];
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
    public DropDownList ddlOperation(mtest_Class mtest_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(mtest_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewmtest");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a test", "0"));
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
