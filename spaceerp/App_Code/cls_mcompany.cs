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
public class mcompany_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnCompanyID = string.Empty;
    private string objsCode = string.Empty;
    private string objdtJoiningDate = string.Empty;
    private string objsCompanyName = string.Empty;
    private string objsIATANo = string.Empty;
    private string objsLicenseNo = string.Empty;
    private string objsGSTNo = string.Empty;
    private string objsPanCardNo = string.Empty;
    private string objnOffTele = string.Empty;
    private string objsAuthorizedPerson = string.Empty;
    private string objsContactNo = string.Empty;
    private string objsAddress = string.Empty;
    private string objnCountryID = string.Empty;
    private string objnCityID = string.Empty;
    private string objnPincode = string.Empty;
    private string objsEmail = string.Empty;
    private string objsWebsite = string.Empty;
    private string objnCAccountID = string.Empty;
    private string objnStateID = string.Empty;
    private string objsLogoImage = string.Empty;
    private string objnCurrencyID = string.Empty;
    private string objnConfigID = string.Empty;
    public string nCompanyID
    {
        get { return objnCompanyID; }
        set { objnCompanyID = value; }
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
    public string sCompanyName
    {
        get { return objsCompanyName; }
        set { objsCompanyName = value; }
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
    public string sLogoImage
    {
        get { return objsLogoImage; }
        set { objsLogoImage = value; }
    }
    public string nCurrencyID
    {
        get { return objnCurrencyID; }
        set { objnCurrencyID = value; }
    }
    public string nConfigID
    {
        get { return objnConfigID; }
        set { objnConfigID = value; }
    }
    public string User_Operation(mcompany_Class mcompany_Class, string type)
    {
        SqlCommand cmd = addParameter(mcompany_Class, type, "");
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
    public SqlCommand addParameter(mcompany_Class mcompany_Class, string type, string cond)
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
        SqlCommand cmd = new SqlCommand("SP_mcompany", conn); cmd.Parameters.AddWithValue("@nCompanyID", mcompany_Class.nCompanyID);
        cmd.Parameters.AddWithValue("@sCode", mcompany_Class.sCode);
        cmd.Parameters.AddWithValue("@dtJoiningDate", mcompany_Class.dtJoiningDate);
        cmd.Parameters.AddWithValue("@sCompanyName", mcompany_Class.sCompanyName);
        cmd.Parameters.AddWithValue("@sIATANo", mcompany_Class.sIATANo);
        cmd.Parameters.AddWithValue("@sLicenseNo", mcompany_Class.sLicenseNo);
        cmd.Parameters.AddWithValue("@sGSTNo", mcompany_Class.sGSTNo);
        cmd.Parameters.AddWithValue("@sPanCardNo", mcompany_Class.sPanCardNo);
        cmd.Parameters.AddWithValue("@nOffTele", mcompany_Class.nOffTele);
        cmd.Parameters.AddWithValue("@sAuthorizedPerson", mcompany_Class.sAuthorizedPerson);
        cmd.Parameters.AddWithValue("@sContactNo", mcompany_Class.sContactNo);
        cmd.Parameters.AddWithValue("@sAddress", mcompany_Class.sAddress);
        cmd.Parameters.AddWithValue("@nCountryID", mcompany_Class.nCountryID);
        cmd.Parameters.AddWithValue("@nCityID", mcompany_Class.nCityID);
        cmd.Parameters.AddWithValue("@nPincode", mcompany_Class.nPincode);
        cmd.Parameters.AddWithValue("@sEmail", mcompany_Class.sEmail);
        cmd.Parameters.AddWithValue("@sWebsite", mcompany_Class.sWebsite);
        cmd.Parameters.AddWithValue("@nCAccountID", mcompany_Class.nCAccountID);
        cmd.Parameters.AddWithValue("@nStateID", mcompany_Class.nStateID);
        cmd.Parameters.AddWithValue("@sLogoImage", mcompany_Class.sLogoImage);
        cmd.Parameters.AddWithValue("@nCurrencyID", mcompany_Class.nCurrencyID);
        cmd.Parameters.AddWithValue("@nConfigID", ConfigID);

        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(mcompany_Class mcompany_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(mcompany_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(mcompany_Class mcompany_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(mcompany_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(mcompany_Class mcompany_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(mcompany_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewmcompany");
            return ds.Tables["viewmcompany"];
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
    public DropDownList ddlOperation(mcompany_Class mcompany_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(mcompany_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewmcompany");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a company", "0"));
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
