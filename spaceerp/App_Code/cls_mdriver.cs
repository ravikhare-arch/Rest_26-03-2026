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
public class mdriver_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnDriverID = string.Empty;
    private string objsDriverName = string.Empty;
    private string objsDrivingLicence = string.Empty;
    private string objdtLicenceValid = string.Empty;
    private string objsContactNo1 = string.Empty;
    private string objsContactNo2 = string.Empty;
    private string objnVehicleID = string.Empty;
    private string objnConfigID = string.Empty;
    public string nDriverID
    {
        get { return objnDriverID; }
        set { objnDriverID = value; }
    }
    public string sDriverName
    {
        get { return objsDriverName; }
        set { objsDriverName = value; }
    }
    public string sDrivingLicence
    {
        get { return objsDrivingLicence; }
        set { objsDrivingLicence = value; }
    }
    public string dtLicenceValid
    {
        get { return objdtLicenceValid; }
        set { objdtLicenceValid = value; }
    }
    public string sContactNo1
    {
        get { return objsContactNo1; }
        set { objsContactNo1 = value; }
    }
    public string sContactNo2
    {
        get { return objsContactNo2; }
        set { objsContactNo2 = value; }
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
    public string User_Operation(mdriver_Class mdriver_Class, string type)
    {
        SqlCommand cmd = addParameter(mdriver_Class, type, "");
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
    public SqlCommand addParameter(mdriver_Class mdriver_Class, string type, string cond)
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
        SqlCommand cmd = new SqlCommand("SP_mdriver", conn); cmd.Parameters.AddWithValue("@nDriverID", mdriver_Class.nDriverID);
        cmd.Parameters.AddWithValue("@sDriverName", mdriver_Class.sDriverName);
        cmd.Parameters.AddWithValue("@sDrivingLicence", mdriver_Class.sDrivingLicence);
        cmd.Parameters.AddWithValue("@dtLicenceValid", mdriver_Class.dtLicenceValid);
        cmd.Parameters.AddWithValue("@sContactNo1", mdriver_Class.sContactNo1);
        cmd.Parameters.AddWithValue("@sContactNo2", mdriver_Class.sContactNo2);
        cmd.Parameters.AddWithValue("@nVehicleID", mdriver_Class.nVehicleID);
        cmd.Parameters.AddWithValue("@nConfigID", nConfigID);

        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(mdriver_Class mdriver_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(mdriver_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(mdriver_Class mdriver_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(mdriver_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(mdriver_Class mdriver_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(mdriver_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewmdriver");
            return ds.Tables["viewmdriver"];
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
    public DropDownList ddlOperation(mdriver_Class mdriver_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(mdriver_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewmdriver");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a driver", "0"));
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
