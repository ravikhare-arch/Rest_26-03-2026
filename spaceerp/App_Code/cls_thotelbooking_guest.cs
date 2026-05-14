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
public class thotelbooking_guest_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnHotelbookingGuestID = string.Empty;
    private string objnHotelBookingDetID = string.Empty;
    private string objsPaxName1 = string.Empty;
    private string objsGender1 = string.Empty;
    private string objsAge1 = string.Empty;
    private string objsPaxName2 = string.Empty;
    private string objsGender2 = string.Empty;
    private string objsAge2 = string.Empty;
    private string objsPaxName3 = string.Empty;
    private string objsGender3 = string.Empty;
    private string objsAge3 = string.Empty;
    private string objsPaxName4 = string.Empty;
    private string objsGender4 = string.Empty;
    private string objsAge4 = string.Empty;
    private string objnConfigID = string.Empty;
    public string nHotelbookingGuestID
    {
        get { return objnHotelbookingGuestID; }
        set { objnHotelbookingGuestID = value; }
    }
    public string nHotelBookingDetID
    {
        get { return objnHotelBookingDetID; }
        set { objnHotelBookingDetID = value; }
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
    public string nConfigID
    {
        get { return objnConfigID; }
        set { objnConfigID = value; }
    }
    public string User_Operation(thotelbooking_guest_Class thotelbooking_guest_Class, string type)
    {
        SqlCommand cmd = addParameter(thotelbooking_guest_Class, type, "");
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
    public SqlCommand addParameter(thotelbooking_guest_Class thotelbooking_guest_Class, string type, string cond)
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
        SqlCommand cmd = new SqlCommand("SP_thotelbooking_guest", conn); cmd.Parameters.AddWithValue("@nHotelbookingGuestID", thotelbooking_guest_Class.nHotelbookingGuestID);
        cmd.Parameters.AddWithValue("@nHotelBookingDetID", thotelbooking_guest_Class.nHotelBookingDetID);
        cmd.Parameters.AddWithValue("@sPaxName1", thotelbooking_guest_Class.sPaxName1);
        cmd.Parameters.AddWithValue("@sGender1", thotelbooking_guest_Class.sGender1);
        cmd.Parameters.AddWithValue("@sAge1", thotelbooking_guest_Class.sAge1);
        cmd.Parameters.AddWithValue("@sPaxName2", thotelbooking_guest_Class.sPaxName2);
        cmd.Parameters.AddWithValue("@sGender2", thotelbooking_guest_Class.sGender2);
        cmd.Parameters.AddWithValue("@sAge2", thotelbooking_guest_Class.sAge2);
        cmd.Parameters.AddWithValue("@sPaxName3", thotelbooking_guest_Class.sPaxName3);
        cmd.Parameters.AddWithValue("@sGender3", thotelbooking_guest_Class.sGender3);
        cmd.Parameters.AddWithValue("@sAge3", thotelbooking_guest_Class.sAge3);
        cmd.Parameters.AddWithValue("@sPaxName4", thotelbooking_guest_Class.sPaxName4);
        cmd.Parameters.AddWithValue("@sGender4", thotelbooking_guest_Class.sGender4);
        cmd.Parameters.AddWithValue("@sAge4", thotelbooking_guest_Class.sAge4);
        cmd.Parameters.AddWithValue("@nConfigID", ConfigID);
        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(thotelbooking_guest_Class thotelbooking_guest_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(thotelbooking_guest_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(thotelbooking_guest_Class thotelbooking_guest_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(thotelbooking_guest_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(thotelbooking_guest_Class thotelbooking_guest_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(thotelbooking_guest_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewthotelbooking_guest");
            return ds.Tables["viewthotelbooking_guest"];
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
    public DropDownList ddlOperation(thotelbooking_guest_Class thotelbooking_guest_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(thotelbooking_guest_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewthotelbooking_guest");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a hotelbooking_guest", "0"));
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
