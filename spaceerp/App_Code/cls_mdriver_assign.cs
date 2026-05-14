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
public class mdriver_assign_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnDriverAssignID = string.Empty;
    private string objnDriverID = string.Empty;
    private string objsTask = string.Empty;
    private string objdtVehicleOut = string.Empty;
    private string objtmVehicleOut = string.Empty;
    private string objnTimeFormatO = string.Empty;
    private string objdtVehicleIN = string.Empty;
    private string objtmVehicleIN = string.Empty;
    private string objnTimeFormatI = string.Empty;
    private string objnVehicleID = string.Empty;
    private string objnConfigID = string.Empty;
    public string nDriverAssignID
    {
        get { return objnDriverAssignID; }
        set { objnDriverAssignID = value; }
    }
    public string nDriverID
    {
        get { return objnDriverID; }
        set { objnDriverID = value; }
    }
    public string sTask
    {
        get { return objsTask; }
        set { objsTask = value; }
    }
    public string dtVehicleOut
    {
        get { return objdtVehicleOut; }
        set { objdtVehicleOut = value; }
    }
    public string tmVehicleOut
    {
        get { return objtmVehicleOut; }
        set { objtmVehicleOut = value; }
    }
    public string nTimeFormatO
    {
        get { return objnTimeFormatO; }
        set { objnTimeFormatO = value; }
    }
    public string dtVehicleIN
    {
        get { return objdtVehicleIN; }
        set { objdtVehicleIN = value; }
    }
    public string tmVehicleIN
    {
        get { return objtmVehicleIN; }
        set { objtmVehicleIN = value; }
    }
    public string nTimeFormatI
    {
        get { return objnTimeFormatI; }
        set { objnTimeFormatI = value; }
    }
    public string nVehicleID
    {
        get { return objnVehicleID; }
        set { objnVehicleID = value; }
    }
    public string nConfigID
    {
        get { return objnConfigID; }
        set { objnConfigID = value; }
    }
    public string User_Operation(mdriver_assign_Class mdriver_assign_Class, string type)
    {
        SqlCommand cmd = addParameter(mdriver_assign_Class, type, "");
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
    public SqlCommand addParameter(mdriver_assign_Class mdriver_assign_Class, string type, string cond)
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
        SqlCommand cmd = new SqlCommand("SP_mdriver_assign", conn); cmd.Parameters.AddWithValue("@nDriverAssignID", mdriver_assign_Class.nDriverAssignID);
        cmd.Parameters.AddWithValue("@nDriverID", mdriver_assign_Class.nDriverID);
        cmd.Parameters.AddWithValue("@sTask", mdriver_assign_Class.sTask);
        cmd.Parameters.AddWithValue("@dtVehicleOut", mdriver_assign_Class.dtVehicleOut);
        cmd.Parameters.AddWithValue("@tmVehicleOut", mdriver_assign_Class.tmVehicleOut);
        cmd.Parameters.AddWithValue("@nTimeFormatO", mdriver_assign_Class.nTimeFormatO);
        cmd.Parameters.AddWithValue("@dtVehicleIN", mdriver_assign_Class.dtVehicleIN);
        cmd.Parameters.AddWithValue("@tmVehicleIN", mdriver_assign_Class.tmVehicleIN);
        cmd.Parameters.AddWithValue("@nTimeFormatI", mdriver_assign_Class.nTimeFormatI);
        cmd.Parameters.AddWithValue("@nVehicleID", mdriver_assign_Class.nVehicleID);
        cmd.Parameters.AddWithValue("@nConfigID", nConfigID);

        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(mdriver_assign_Class mdriver_assign_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(mdriver_assign_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(mdriver_assign_Class mdriver_assign_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(mdriver_assign_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(mdriver_assign_Class mdriver_assign_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(mdriver_assign_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewmdriver_assign");
            return ds.Tables["viewmdriver_assign"];
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
    public DropDownList ddlOperation(mdriver_assign_Class mdriver_assign_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(mdriver_assign_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewmdriver_assign");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a driver_assign", "0"));
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
