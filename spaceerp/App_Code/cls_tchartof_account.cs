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
public class tchartof_account_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnChartOfAccountID = string.Empty;
    private string objsCode = string.Empty;
    private string objnAccountTypeID = string.Empty;
    private string objsFirstName = string.Empty;
    private string objsMidName = string.Empty;
    private string objsLastName = string.Empty;
    private string objsFamilyName = string.Empty;
    private string objsAddress = string.Empty;
    private string objsPhoneNo1 = string.Empty;
    private string objsPhoneNo2 = string.Empty;
    private string objsMobileNo = string.Empty;
    private string objsFaxNo = string.Empty;
    private string objsEmailID = string.Empty;
    private string objsWebsite = string.Empty;
    private string objnSalesPersonID = string.Empty;
    private string objnCountryID = string.Empty;
    private string objnCityID = string.Empty;
    private string objnAccountCategoryID = string.Empty;
    private string objnCreditLimit = string.Empty;
    private string objsRemarks = string.Empty;
    private string objbNotChange = string.Empty;
    private string objsGSTNo = string.Empty;
    private string objnConfigID = string.Empty;
    public string nChartOfAccountID
    {
        get { return objnChartOfAccountID; }
        set { objnChartOfAccountID = value; }
    }
    public string sCode
    {
        get { return objsCode; }
        set { objsCode = value; }
    }
    public string nAccountTypeID
    {
        get { return objnAccountTypeID; }
        set { objnAccountTypeID = value; }
    }
    public string sFirstName
    {
        get { return objsFirstName; }
        set { objsFirstName = value; }
    }
    public string sMidName
    {
        get { return objsMidName; }
        set { objsMidName = value; }
    }
    public string sLastName
    {
        get { return objsLastName; }
        set { objsLastName = value; }
    }
    public string sFamilyName
    {
        get { return objsFamilyName; }
        set { objsFamilyName = value; }
    }
    public string sAddress
    {
        get { return objsAddress; }
        set { objsAddress = value; }
    }
    public string sPhoneNo1
    {
        get { return objsPhoneNo1; }
        set { objsPhoneNo1 = value; }
    }
    public string sPhoneNo2
    {
        get { return objsPhoneNo2; }
        set { objsPhoneNo2 = value; }
    }
    public string sMobileNo
    {
        get { return objsMobileNo; }
        set { objsMobileNo = value; }
    }
    public string sFaxNo
    {
        get { return objsFaxNo; }
        set { objsFaxNo = value; }
    }
    public string sEmailID
    {
        get { return objsEmailID; }
        set { objsEmailID = value; }
    }
    public string sWebsite
    {
        get { return objsWebsite; }
        set { objsWebsite = value; }
    }
    public string nSalesPersonID
    {
        get { return objnSalesPersonID; }
        set { objnSalesPersonID = value; }
    }
    public string nCountryID
    {
        get { return objnCountryID; }
        set { objnCountryID = value; }
    }
    public string nCityID
    {
        get { return objnCityID; }
        set { objnCityID = value; }
    }
    public string nAccountCategoryID
    {
        get { return objnAccountCategoryID; }
        set { objnAccountCategoryID = value; }
    }
    public string nCreditLimit
    {
        get { return objnCreditLimit; }
        set { objnCreditLimit = value; }
    }
    public string sRemarks
    {
        get { return objsRemarks; }
        set { objsRemarks = value; }
    }
    public string bNotChange
    {
        get { return objbNotChange; }
        set { objbNotChange = value; }
    }
    public string sGSTNo
    {
        get { return objsGSTNo; }
        set { objsGSTNo = value; }
    }
    public string nConfigID
    {
        get { return objnConfigID; }
        set { objnConfigID = value; }
    }
    public string User_Operation(tchartof_account_Class tchartof_account_Class, string type)
    {
        SqlCommand cmd = addParameter(tchartof_account_Class, type, "");
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
    public SqlCommand addParameter(tchartof_account_Class tchartof_account_Class, string type, string cond)
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
        SqlCommand cmd = new SqlCommand("SP_tchartof_account", conn); cmd.Parameters.AddWithValue("@nChartOfAccountID", tchartof_account_Class.nChartOfAccountID);
        cmd.Parameters.AddWithValue("@sCode", tchartof_account_Class.sCode);
        cmd.Parameters.AddWithValue("@nAccountTypeID", tchartof_account_Class.nAccountTypeID);
        cmd.Parameters.AddWithValue("@sFirstName", tchartof_account_Class.sFirstName);
        cmd.Parameters.AddWithValue("@sMidName", tchartof_account_Class.sMidName);
        cmd.Parameters.AddWithValue("@sLastName", tchartof_account_Class.sLastName);
        cmd.Parameters.AddWithValue("@sFamilyName", tchartof_account_Class.sFamilyName);
        cmd.Parameters.AddWithValue("@sAddress", tchartof_account_Class.sAddress);
        cmd.Parameters.AddWithValue("@sPhoneNo1", tchartof_account_Class.sPhoneNo1);
        cmd.Parameters.AddWithValue("@sPhoneNo2", tchartof_account_Class.sPhoneNo2);
        cmd.Parameters.AddWithValue("@sMobileNo", tchartof_account_Class.sMobileNo);
        cmd.Parameters.AddWithValue("@sFaxNo", tchartof_account_Class.sFaxNo);
        cmd.Parameters.AddWithValue("@sEmailID", tchartof_account_Class.sEmailID);
        cmd.Parameters.AddWithValue("@sWebsite", tchartof_account_Class.sWebsite);
        cmd.Parameters.AddWithValue("@nSalesPersonID", tchartof_account_Class.nSalesPersonID);
        cmd.Parameters.AddWithValue("@nCountryID", tchartof_account_Class.nCountryID);
        cmd.Parameters.AddWithValue("@nCityID", tchartof_account_Class.nCityID);
        cmd.Parameters.AddWithValue("@nAccountCategoryID", tchartof_account_Class.nAccountCategoryID);
        cmd.Parameters.AddWithValue("@nCreditLimit", tchartof_account_Class.nCreditLimit);
        cmd.Parameters.AddWithValue("@sRemarks", tchartof_account_Class.sRemarks);
        cmd.Parameters.AddWithValue("@bNotChange", tchartof_account_Class.bNotChange);
        cmd.Parameters.AddWithValue("@sGSTNo", tchartof_account_Class.sGSTNo);
        cmd.Parameters.AddWithValue("@nConfigID", ConfigID);

        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(tchartof_account_Class tchartof_account_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(tchartof_account_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(tchartof_account_Class tchartof_account_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(tchartof_account_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(tchartof_account_Class tchartof_account_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(tchartof_account_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewtchartof_account");
            return ds.Tables["viewtchartof_account"];
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
    public DropDownList ddlOperation(tchartof_account_Class tchartof_account_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(tchartof_account_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewtchartof_account");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a chartof_account", "0"));
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
