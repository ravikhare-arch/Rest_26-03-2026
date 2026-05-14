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
public class mairline_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnAirlineID = string.Empty;
    private string objsCode = string.Empty;
    private string objdtJoiningDate = string.Empty;
    private string objsAirlineName = string.Empty;
    private string objsIATANo = string.Empty;
    private string objsLicenseNo = string.Empty;
    private string objsGSTNo = string.Empty;
    private string objsPanCardNo = string.Empty;
    private string objnLocationID = string.Empty;
    private string objnOffTele = string.Empty;
    private string objsAuthorizedPerson = string.Empty;
    private string objsContactNo = string.Empty;
    private string objsAddress = string.Empty;
    private string objnCountryID = string.Empty;
    private string objnCityID = string.Empty;
    private string objnPincode = string.Empty;
    private string objsEmail = string.Empty;
    private string objsWebsite = string.Empty;
    private string objnCreditLimit = string.Empty;
    private string objnCAccountID = string.Empty;
    private string objnStateID = string.Empty;
    private string objsDesignator = string.Empty;
    private string objsAllience = string.Empty;
    private string objnConfigID = string.Empty;
    public string nAirlineID
    {
        get { return objnAirlineID; }
        set { objnAirlineID = value; }
    }
    public string sCode
    {
        get { return objsCode; }
        set { objsCode = value; }
    }
    public string dtJoiningDate
    {
        get { return objdtJoiningDate; }
        set { objdtJoiningDate = value; }
    }
    public string sAirlineName
    {
        get { return objsAirlineName; }
        set { objsAirlineName = value; }
    }
    public string sIATANo
    {
        get { return objsIATANo; }
        set { objsIATANo = value; }
    }
    public string sLicenseNo
    {
        get { return objsLicenseNo; }
        set { objsLicenseNo = value; }
    }
    public string sGSTNo
    {
        get { return objsGSTNo; }
        set { objsGSTNo = value; }
    }
    public string sPanCardNo
    {
        get { return objsPanCardNo; }
        set { objsPanCardNo = value; }
    }
    public string nLocationID
    {
        get { return objnLocationID; }
        set { objnLocationID = value; }
    }
    public string nOffTele
    {
        get { return objnOffTele; }
        set { objnOffTele = value; }
    }
    public string sAuthorizedPerson
    {
        get { return objsAuthorizedPerson; }
        set { objsAuthorizedPerson = value; }
    }
    public string sContactNo
    {
        get { return objsContactNo; }
        set { objsContactNo = value; }
    }
    public string sAddress
    {
        get { return objsAddress; }
        set { objsAddress = value; }
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
    public string nPincode
    {
        get { return objnPincode; }
        set { objnPincode = value; }
    }
    public string sEmail
    {
        get { return objsEmail; }
        set { objsEmail = value; }
    }
    public string sWebsite
    {
        get { return objsWebsite; }
        set { objsWebsite = value; }
    }
    public string nCreditLimit
    {
        get { return objnCreditLimit; }
        set { objnCreditLimit = value; }
    }
    public string nCAccountID
    {
        get { return objnCAccountID; }
        set { objnCAccountID = value; }
    }
    public string nStateID
    {
        get { return objnStateID; }
        set { objnStateID = value; }
    }
    public string sDesignator
    {
        get { return objsDesignator; }
        set { objsDesignator = value; }
    }
    public string sAllience
    {
        get { return objsAllience; }
        set { objsAllience = value; }
    }
    public string nConfigID
    {
        get { return objnConfigID; }
        set { objnConfigID = value; }
    }
    public string User_Operation(mairline_Class mairline_Class, string type)
    {
        SqlCommand cmd = addParameter(mairline_Class, type, "");
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
    public SqlCommand addParameter(mairline_Class mairline_Class, string type, string cond)
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
        SqlCommand cmd = new SqlCommand("SP_mairline", conn); cmd.Parameters.AddWithValue("@nAirlineID", mairline_Class.nAirlineID);
        cmd.Parameters.AddWithValue("@sCode", mairline_Class.sCode);
        cmd.Parameters.AddWithValue("@dtJoiningDate", mairline_Class.dtJoiningDate);
        cmd.Parameters.AddWithValue("@sAirlineName", mairline_Class.sAirlineName);
        cmd.Parameters.AddWithValue("@sIATANo", mairline_Class.sIATANo);
        cmd.Parameters.AddWithValue("@sLicenseNo", mairline_Class.sLicenseNo);
        cmd.Parameters.AddWithValue("@sGSTNo", mairline_Class.sGSTNo);
        cmd.Parameters.AddWithValue("@sPanCardNo", mairline_Class.sPanCardNo);
        cmd.Parameters.AddWithValue("@nLocationID", mairline_Class.nLocationID);
        cmd.Parameters.AddWithValue("@nOffTele", mairline_Class.nOffTele);
        cmd.Parameters.AddWithValue("@sAuthorizedPerson", mairline_Class.sAuthorizedPerson);
        cmd.Parameters.AddWithValue("@sContactNo", mairline_Class.sContactNo);
        cmd.Parameters.AddWithValue("@sAddress", mairline_Class.sAddress);
        cmd.Parameters.AddWithValue("@nCountryID", mairline_Class.nCountryID);
        cmd.Parameters.AddWithValue("@nCityID", mairline_Class.nCityID);
        cmd.Parameters.AddWithValue("@nPincode", mairline_Class.nPincode);
        cmd.Parameters.AddWithValue("@sEmail", mairline_Class.sEmail);
        cmd.Parameters.AddWithValue("@sWebsite", mairline_Class.sWebsite);
        cmd.Parameters.AddWithValue("@nCreditLimit", mairline_Class.nCreditLimit);
        cmd.Parameters.AddWithValue("@nCAccountID", mairline_Class.nCAccountID);
        cmd.Parameters.AddWithValue("@nStateID", mairline_Class.nStateID);
        cmd.Parameters.AddWithValue("@sDesignator", mairline_Class.sDesignator);
        cmd.Parameters.AddWithValue("@sAllience", mairline_Class.sAllience);
        cmd.Parameters.AddWithValue("@nConfigID", ConfigID);

        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(mairline_Class mairline_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(mairline_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(mairline_Class mairline_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(mairline_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
     public DataTable viewData(mairline_Class mairline_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(mairline_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewairline");
            return ds.Tables["viewairline"];
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
   
    public DropDownList ddlOperation(mairline_Class mairline_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(mairline_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewmairline");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a airline", "0"));
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
    public DataTable Tabledata(mairline_Class mairline_Class, string type, string cond)
    {
        DataTable da = new DataTable();
        try
        {
            da = viewData(mairline_Class, type, cond);
        }
        catch
        {

        }
        return da;
    }

}
