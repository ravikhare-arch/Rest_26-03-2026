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
public class tgroup_ticketsector_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnTickerSectorID = string.Empty;
    private string objnTicketingDetID = string.Empty;
    private string objsSector = string.Empty;
    private string objsAirline = string.Empty;
    private string objdtTDate = string.Empty;
    private string objnConfigID = string.Empty;
    public string nTickerSectorID
    {
        get { return objnTickerSectorID; }
        set { objnTickerSectorID = value; }
    }
    public string nTicketingDetID
    {
        get { return objnTicketingDetID; }
        set { objnTicketingDetID = value; }
    }
    public string sSector
    {
        get { return objsSector; }
        set { objsSector = value; }
    }
    public string sAirline
    {
        get { return objsAirline; }
        set { objsAirline = value; }
    }
    public string dtTDate
    {
        get { return objdtTDate; }
        set { objdtTDate = value; }
    }
    public string nConfigID
    {
        get { return objnConfigID; }
        set { objnConfigID = value; }
    }
    public string User_Operation(tgroup_ticketsector_Class tgroup_ticketsector_Class, string type)
    {
        SqlCommand cmd = addParameter(tgroup_ticketsector_Class, type, "");
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
    public SqlCommand addParameter(tgroup_ticketsector_Class tgroup_ticketsector_Class, string type, string cond)
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
        SqlCommand cmd = new SqlCommand("SP_tgroup_ticketsector", conn); cmd.Parameters.AddWithValue("@nTickerSectorID", tgroup_ticketsector_Class.nTickerSectorID);
        cmd.Parameters.AddWithValue("@nTicketingDetID", tgroup_ticketsector_Class.nTicketingDetID);
        cmd.Parameters.AddWithValue("@sSector", tgroup_ticketsector_Class.sSector);
        cmd.Parameters.AddWithValue("@sAirline", tgroup_ticketsector_Class.sAirline);
        cmd.Parameters.AddWithValue("@dtTDate", tgroup_ticketsector_Class.dtTDate);
        cmd.Parameters.AddWithValue("@nConfigID", ConfigID);

        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(tgroup_ticketsector_Class tgroup_ticketsector_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(tgroup_ticketsector_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(tgroup_ticketsector_Class tgroup_ticketsector_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(tgroup_ticketsector_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(tgroup_ticketsector_Class tgroup_ticketsector_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(tgroup_ticketsector_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewtgroup_ticketsector");
            return ds.Tables["viewtgroup_ticketsector"];
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
    public DropDownList ddlOperation(tgroup_ticketsector_Class tgroup_ticketsector_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(tgroup_ticketsector_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewtgroup_ticketsector");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a group_ticketsector", "0"));
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
