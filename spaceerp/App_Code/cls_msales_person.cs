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
public class msales_person_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnSalesPersonID = string.Empty;
    private string objsSalesPersonName = string.Empty;
    private string objsMobile = string.Empty;
    private string objsPhone = string.Empty;
    private string objsEmailID = string.Empty;
    private string objnConfigID = string.Empty;
    public string nSalesPersonID
    {
        get { return objnSalesPersonID; }
        set { objnSalesPersonID = value; }
    }
    public string sSalesPersonName
    {
        get { return objsSalesPersonName; }
        set { objsSalesPersonName = value; }
    }
    public string sMobile
    {
        get { return objsMobile; }
        set { objsMobile = value; }
    }
    public string sPhone
    {
        get { return objsPhone; }
        set { objsPhone = value; }
    }
    public string sEmailID
    {
        get { return objsEmailID; }
        set { objsEmailID = value; }
    }
    public string nConfigID
    {
        get { return objnConfigID; }
        set { objnConfigID = value; }
    }
    public string User_Operation(msales_person_Class msales_person_Class, string type)
    {
        SqlCommand cmd = addParameter(msales_person_Class, type, "");
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
    public SqlCommand addParameter(msales_person_Class msales_person_Class, string type, string cond)
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
        SqlCommand cmd = new SqlCommand("SP_msales_person", conn); cmd.Parameters.AddWithValue("@nSalesPersonID", msales_person_Class.nSalesPersonID);
        cmd.Parameters.AddWithValue("@sSalesPersonName", msales_person_Class.sSalesPersonName);
        cmd.Parameters.AddWithValue("@sMobile", msales_person_Class.sMobile);
        cmd.Parameters.AddWithValue("@sPhone", msales_person_Class.sPhone);
        cmd.Parameters.AddWithValue("@sEmailID", msales_person_Class.sEmailID);
        cmd.Parameters.AddWithValue("@nConfigID", nConfigID);

        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(msales_person_Class msales_person_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(msales_person_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(msales_person_Class msales_person_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(msales_person_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(msales_person_Class msales_person_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(msales_person_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewmsalesperson");
            return ds.Tables["viewmsalesperson"];
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
    public DropDownList ddlOperation(msales_person_Class msales_person_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(msales_person_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewmsalesperson");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a salesperson", "0"));
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
