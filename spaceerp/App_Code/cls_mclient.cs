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
public class mclient_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnClientID = string.Empty;
    private string objsClientCode = string.Empty;
    private string objdtJoiningDate = string.Empty;
    private string objsAgencyName = string.Empty;
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
    private string objnConfigID = string.Empty;
    public string nClientID
    {
        get { return objnClientID; }
        set { objnClientID = value; }
    }
    public string sClientCode
    {
        get { return objsClientCode; }
        set { objsClientCode = value; }
    }
    public string dtJoiningDate
    {
        get { return objdtJoiningDate; }
        set { objdtJoiningDate = value; }
    }
    public string sAgencyName
    {
        get { return objsAgencyName; }
        set { objsAgencyName = value; }
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
    public string nConfigID
    {
        get { return objnConfigID; }
        set { objnConfigID = value; }
    }
    public string StartDate { get; set; }
    public string EndDate { get; set; }
    public string VendorContactNo { get; set; }
    public string VendorAddress { get; set; }
    public string VendorCountryID { get; set; }
    public string VendorStateID { get; set; }
    public string VendorCityID { get; set; }
    public string VendorPincode { get; set; }
    public string VendorEmail { get; set; }
    public string VendorLatitude { get; set; }
    public string VendorLongitude { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }
    public string User_Operation(mclient_Class mclient_Class, string type)
    {
        SqlCommand cmd = addParameter(mclient_Class, type, "");
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
    public SqlCommand addParameter(mclient_Class mclient_Class, string type, string cond)
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
        SqlCommand cmd = new SqlCommand("SP_mclient", conn); cmd.Parameters.AddWithValue("@nClientID", mclient_Class.nClientID);
        cmd.Parameters.AddWithValue("@sClientCode", mclient_Class.sClientCode);
        cmd.Parameters.AddWithValue("@dtJoiningDate", mclient_Class.dtJoiningDate);
        cmd.Parameters.AddWithValue("@sAgencyName", mclient_Class.sAgencyName);
        cmd.Parameters.AddWithValue("@sIATANo", mclient_Class.sIATANo);
        cmd.Parameters.AddWithValue("@sLicenseNo", mclient_Class.sLicenseNo);
        cmd.Parameters.AddWithValue("@sGSTNo", mclient_Class.sGSTNo);
        cmd.Parameters.AddWithValue("@sPanCardNo", mclient_Class.sPanCardNo);
        cmd.Parameters.AddWithValue("@nLocationID", mclient_Class.nLocationID);
        cmd.Parameters.AddWithValue("@nOffTele", mclient_Class.nOffTele);
        cmd.Parameters.AddWithValue("@sAuthorizedPerson", mclient_Class.sAuthorizedPerson);
        cmd.Parameters.AddWithValue("@sContactNo", mclient_Class.sContactNo);
        cmd.Parameters.AddWithValue("@sAddress", mclient_Class.sAddress);
        cmd.Parameters.AddWithValue("@nCountryID", mclient_Class.nCountryID);
        cmd.Parameters.AddWithValue("@nCityID", mclient_Class.nCityID);
        cmd.Parameters.AddWithValue("@nPincode", mclient_Class.nPincode);
        cmd.Parameters.AddWithValue("@sEmail", mclient_Class.sEmail);
        cmd.Parameters.AddWithValue("@sWebsite", mclient_Class.sWebsite);
        cmd.Parameters.AddWithValue("@nCreditLimit", mclient_Class.nCreditLimit);
        cmd.Parameters.AddWithValue("@nCAccountID", mclient_Class.nCAccountID);
        cmd.Parameters.AddWithValue("@nStateID", mclient_Class.nStateID);
        cmd.Parameters.AddWithValue("@sVendorContactNo", mclient_Class.VendorContactNo);
        cmd.Parameters.AddWithValue("@sVendorAddress", mclient_Class.VendorAddress);
        cmd.Parameters.AddWithValue("@nVendorCountryID", mclient_Class.VendorCountryID);
        cmd.Parameters.AddWithValue("@nVendorStateID", mclient_Class.VendorStateID);
        cmd.Parameters.AddWithValue("@nVendorCityID", mclient_Class.VendorCityID);
        cmd.Parameters.AddWithValue("@nVendorPincode", mclient_Class.VendorPincode);
        cmd.Parameters.AddWithValue("@sVendorEmail", mclient_Class.VendorEmail);
        cmd.Parameters.AddWithValue("@sVendorLatitude", mclient_Class.VendorLatitude);
        cmd.Parameters.AddWithValue("@sVendorLongitude", mclient_Class.VendorLongitude);
        cmd.Parameters.AddWithValue("@sLatitude", mclient_Class.Latitude);
        cmd.Parameters.AddWithValue("@sLongitude", mclient_Class.Longitude);

        cmd.Parameters.AddWithValue("@nConfigID", nConfigID);
        cmd.Parameters.AddWithValue("@StartDate", mclient_Class.StartDate);
        cmd.Parameters.AddWithValue("@EndDate", mclient_Class.EndDate);
        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(mclient_Class mclient_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(mclient_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(mclient_Class mclient_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(mclient_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(mclient_Class mclient_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(mclient_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewmclient");
            return ds.Tables["viewmclient"];
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
    public DropDownList ddlOperation(mclient_Class mclient_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(mclient_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewmclient");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a client", "0"));
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
    public DataTable Tabledata(mclient_Class mclient_Class, string type, string cond)
    {
        DataTable da = new DataTable();
        try
        {
            da = viewData(mclient_Class, type, cond);
            
        }
        catch
        {

        }
        return da;
    }

}
