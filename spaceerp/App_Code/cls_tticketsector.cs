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
public class tticketsector_Class : System.Web.UI.Page
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
    public string User_Operation(tticketsector_Class tticketsector_Class, string type)
    {
        SqlCommand cmd = addParameter(tticketsector_Class, type, "");
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
    public SqlCommand addParameter(tticketsector_Class tticketsector_Class, string type, string cond)
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
        SqlCommand cmd = new SqlCommand("SP_tticketsector", conn); cmd.Parameters.AddWithValue("@nTickerSectorID", tticketsector_Class.nTickerSectorID);
        cmd.Parameters.AddWithValue("@nTicketingDetID", tticketsector_Class.nTicketingDetID);
        cmd.Parameters.AddWithValue("@sSector", tticketsector_Class.sSector);
        cmd.Parameters.AddWithValue("@sAirline", tticketsector_Class.sAirline);
        cmd.Parameters.AddWithValue("@dtTDate", tticketsector_Class.dtTDate);
        cmd.Parameters.AddWithValue("@nConfigID", ConfigID);

        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(tticketsector_Class tticketsector_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(tticketsector_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(tticketsector_Class tticketsector_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(tticketsector_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(tticketsector_Class tticketsector_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(tticketsector_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewtticketsector");
            return ds.Tables["viewtticketsector"];
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
    public DropDownList ddlOperation(tticketsector_Class tticketsector_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(tticketsector_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewtticketsector");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a ticketsector", "0"));
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
