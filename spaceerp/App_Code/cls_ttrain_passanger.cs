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
public class ttrain_passanger_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnTrainPassangerID = string.Empty;
    private string objnTrainBookingID = string.Empty;
    private string objsPaxName1 = string.Empty;
    private string objsGender1 = string.Empty;
    private string objsAge1 = string.Empty;
    private string objsStaus1 = string.Empty;
    private string objsBogie1 = string.Empty;
    private string objsPaxName2 = string.Empty;
    private string objsGender2 = string.Empty;
    private string objsAge2 = string.Empty;
    private string objsStaus2 = string.Empty;
    private string objsBogie2 = string.Empty;
    private string objsPaxName3 = string.Empty;
    private string objsGender3 = string.Empty;
    private string objsAge3 = string.Empty;
    private string objsStaus3 = string.Empty;
    private string objsBogie3 = string.Empty;
    private string objsPaxName4 = string.Empty;
    private string objsGender4 = string.Empty;
    private string objsAge4 = string.Empty;
    private string objsStaus4 = string.Empty;
    private string objsBogie4 = string.Empty;
    private string objsPaxName5 = string.Empty;
    private string objsGender5 = string.Empty;
    private string objsAge5 = string.Empty;
    private string objsStaus5 = string.Empty;
    private string objsBogie5 = string.Empty;
    private string objsPaxName6 = string.Empty;
    private string objsGender6 = string.Empty;
    private string objsAge6 = string.Empty;
    private string objsStaus6 = string.Empty;
    private string objsBogie6 = string.Empty;
    private string objnConfigID = string.Empty;
    public string nTrainPassangerID
    {
        get { return objnTrainPassangerID; }
        set { objnTrainPassangerID = value; }
    }
    public string nTrainBookingID
    {
        get { return objnTrainBookingID; }
        set { objnTrainBookingID = value; }
    }
    public string sPaxName1
    {
        get { return objsPaxName1; }
        set { objsPaxName1 = value; }
    }
    public string sGender1
    {
        get { return objsGender1; }
        set { objsGender1 = value; }
    }
    public string sAge1
    {
        get { return objsAge1; }
        set { objsAge1 = value; }
    }
    public string sStaus1
    {
        get { return objsStaus1; }
        set { objsStaus1 = value; }
    }
    public string sBogie1
    {
        get { return objsBogie1; }
        set { objsBogie1 = value; }
    }
    public string sPaxName2
    {
        get { return objsPaxName2; }
        set { objsPaxName2 = value; }
    }
    public string sGender2
    {
        get { return objsGender2; }
        set { objsGender2 = value; }
    }
    public string sAge2
    {
        get { return objsAge2; }
        set { objsAge2 = value; }
    }
    public string sStaus2
    {
        get { return objsStaus2; }
        set { objsStaus2 = value; }
    }
    public string sBogie2
    {
        get { return objsBogie2; }
        set { objsBogie2 = value; }
    }
    public string sPaxName3
    {
        get { return objsPaxName3; }
        set { objsPaxName3 = value; }
    }
    public string sGender3
    {
        get { return objsGender3; }
        set { objsGender3 = value; }
    }
    public string sAge3
    {
        get { return objsAge3; }
        set { objsAge3 = value; }
    }
    public string sStaus3
    {
        get { return objsStaus3; }
        set { objsStaus3 = value; }
    }
    public string sBogie3
    {
        get { return objsBogie3; }
        set { objsBogie3 = value; }
    }
    public string sPaxName4
    {
        get { return objsPaxName4; }
        set { objsPaxName4 = value; }
    }
    public string sGender4
    {
        get { return objsGender4; }
        set { objsGender4 = value; }
    }
    public string sAge4
    {
        get { return objsAge4; }
        set { objsAge4 = value; }
    }
    public string sStaus4
    {
        get { return objsStaus4; }
        set { objsStaus4 = value; }
    }
    public string sBogie4
    {
        get { return objsBogie4; }
        set { objsBogie4 = value; }
    }
    public string sPaxName5
    {
        get { return objsPaxName5; }
        set { objsPaxName5 = value; }
    }
    public string sGender5
    {
        get { return objsGender5; }
        set { objsGender5 = value; }
    }
    public string sAge5
    {
        get { return objsAge5; }
        set { objsAge5 = value; }
    }
    public string sStaus5
    {
        get { return objsStaus5; }
        set { objsStaus5 = value; }
    }
    public string sBogie5
    {
        get { return objsBogie5; }
        set { objsBogie5 = value; }
    }
    public string sPaxName6
    {
        get { return objsPaxName6; }
        set { objsPaxName6 = value; }
    }
    public string sGender6
    {
        get { return objsGender6; }
        set { objsGender6 = value; }
    }
    public string sAge6
    {
        get { return objsAge6; }
        set { objsAge6 = value; }
    }
    public string sStaus6
    {
        get { return objsStaus6; }
        set { objsStaus6 = value; }
    }
    public string sBogie6
    {
        get { return objsBogie6; }
        set { objsBogie6 = value; }
    }
    public string nConfigID
    {
        get { return objnConfigID; }
        set { objnConfigID = value; }
    }
    public string User_Operation(ttrain_passanger_Class ttrain_passanger_Class, string type)
    {
        SqlCommand cmd = addParameter(ttrain_passanger_Class, type, "");
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
    public SqlCommand addParameter(ttrain_passanger_Class ttrain_passanger_Class, string type, string cond)
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
        SqlCommand cmd = new SqlCommand("SP_ttrain_passanger", conn); cmd.Parameters.AddWithValue("@nTrainPassangerID", ttrain_passanger_Class.nTrainPassangerID);
        cmd.Parameters.AddWithValue("@nTrainBookingID", ttrain_passanger_Class.nTrainBookingID);
        cmd.Parameters.AddWithValue("@sPaxName1", ttrain_passanger_Class.sPaxName1);
        cmd.Parameters.AddWithValue("@sGender1", ttrain_passanger_Class.sGender1);
        cmd.Parameters.AddWithValue("@sAge1", ttrain_passanger_Class.sAge1);
        cmd.Parameters.AddWithValue("@sStaus1", ttrain_passanger_Class.sStaus1);
        cmd.Parameters.AddWithValue("@sBogie1", ttrain_passanger_Class.sBogie1);
        cmd.Parameters.AddWithValue("@sPaxName2", ttrain_passanger_Class.sPaxName2);
        cmd.Parameters.AddWithValue("@sGender2", ttrain_passanger_Class.sGender2);
        cmd.Parameters.AddWithValue("@sAge2", ttrain_passanger_Class.sAge2);
        cmd.Parameters.AddWithValue("@sStaus2", ttrain_passanger_Class.sStaus2);
        cmd.Parameters.AddWithValue("@sBogie2", ttrain_passanger_Class.sBogie2);
        cmd.Parameters.AddWithValue("@sPaxName3", ttrain_passanger_Class.sPaxName3);
        cmd.Parameters.AddWithValue("@sGender3", ttrain_passanger_Class.sGender3);
        cmd.Parameters.AddWithValue("@sAge3", ttrain_passanger_Class.sAge3);
        cmd.Parameters.AddWithValue("@sStaus3", ttrain_passanger_Class.sStaus3);
        cmd.Parameters.AddWithValue("@sBogie3", ttrain_passanger_Class.sBogie3);
        cmd.Parameters.AddWithValue("@sPaxName4", ttrain_passanger_Class.sPaxName4);
        cmd.Parameters.AddWithValue("@sGender4", ttrain_passanger_Class.sGender4);
        cmd.Parameters.AddWithValue("@sAge4", ttrain_passanger_Class.sAge4);
        cmd.Parameters.AddWithValue("@sStaus4", ttrain_passanger_Class.sStaus4);
        cmd.Parameters.AddWithValue("@sBogie4", ttrain_passanger_Class.sBogie4);
        cmd.Parameters.AddWithValue("@sPaxName5", ttrain_passanger_Class.sPaxName5);
        cmd.Parameters.AddWithValue("@sGender5", ttrain_passanger_Class.sGender5);
        cmd.Parameters.AddWithValue("@sAge5", ttrain_passanger_Class.sAge5);
        cmd.Parameters.AddWithValue("@sStaus5", ttrain_passanger_Class.sStaus5);
        cmd.Parameters.AddWithValue("@sBogie5", ttrain_passanger_Class.sBogie5);
        cmd.Parameters.AddWithValue("@sPaxName6", ttrain_passanger_Class.sPaxName6);
        cmd.Parameters.AddWithValue("@sGender6", ttrain_passanger_Class.sGender6);
        cmd.Parameters.AddWithValue("@sAge6", ttrain_passanger_Class.sAge6);
        cmd.Parameters.AddWithValue("@sStaus6", ttrain_passanger_Class.sStaus6);
        cmd.Parameters.AddWithValue("@sBogie6", ttrain_passanger_Class.sBogie6);
        cmd.Parameters.AddWithValue("@nConfigID", ConfigID);

        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(ttrain_passanger_Class ttrain_passanger_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(ttrain_passanger_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(ttrain_passanger_Class ttrain_passanger_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(ttrain_passanger_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(ttrain_passanger_Class ttrain_passanger_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(ttrain_passanger_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewttrain_passanger");
            return ds.Tables["viewttrain_passanger"];
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
    public DropDownList ddlOperation(ttrain_passanger_Class ttrain_passanger_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(ttrain_passanger_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewttrain_passanger");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a train_passanger", "0"));
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
