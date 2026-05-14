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
public class thotelguest_list_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnHotelGustID = string.Empty;
    private string objnHotelBookingDetID = string.Empty;
    private string objsPaxName = string.Empty;
    private string objsGender = string.Empty;
    private string objsAge = string.Empty;
    private string objbLead = string.Empty;
    private string objnConfigID = string.Empty;
    public string nHotelGustID
    {
        get { return objnHotelGustID; }
        set { objnHotelGustID = value; }
    }
    public string nHotelBookingDetID
    {
        get { return objnHotelBookingDetID; }
        set { objnHotelBookingDetID = value; }
    }
    public string sPaxName
    {
        get { return objsPaxName; }
        set { objsPaxName = value; }
    }
    public string sGender
    {
        get { return objsGender; }
        set { objsGender = value; }
    }
    public string sAge
    {
        get { return objsAge; }
        set { objsAge = value; }
    }
    public string bLead
    {
        get { return objbLead; }
        set { objbLead = value; }
    }
    public string nConfigID
    {
        get { return objnConfigID; }
        set { objnConfigID = value; }
    }
    public string User_Operation(thotelguest_list_Class thotelguest_list_Class, string type)
    {
        SqlCommand cmd = addParameter(thotelguest_list_Class, type, "");
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
    public SqlCommand addParameter(thotelguest_list_Class thotelguest_list_Class, string type, string cond)
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
        SqlCommand cmd = new SqlCommand("SP_thotelguest_list", conn); cmd.Parameters.AddWithValue("@nHotelGustID", thotelguest_list_Class.nHotelGustID);
        cmd.Parameters.AddWithValue("@nHotelBookingDetID", thotelguest_list_Class.nHotelBookingDetID);
        cmd.Parameters.AddWithValue("@sPaxName", thotelguest_list_Class.sPaxName);
        cmd.Parameters.AddWithValue("@sGender", thotelguest_list_Class.sGender);
        cmd.Parameters.AddWithValue("@sAge", thotelguest_list_Class.sAge);
        cmd.Parameters.AddWithValue("@bLead", thotelguest_list_Class.bLead);
        cmd.Parameters.AddWithValue("@nConfigID", ConfigID);

        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(thotelguest_list_Class thotelguest_list_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(thotelguest_list_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(thotelguest_list_Class thotelguest_list_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(thotelguest_list_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(thotelguest_list_Class thotelguest_list_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(thotelguest_list_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewthotelguest_list");
            return ds.Tables["viewthotelguest_list"];
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
    public DropDownList ddlOperation(thotelguest_list_Class thotelguest_list_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(thotelguest_list_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewthotelguest_list");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a hotelguest_list", "0"));
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
