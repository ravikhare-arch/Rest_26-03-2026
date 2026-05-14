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
public class mabroadagent_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnSupplierID = string.Empty;
    private string objsSupplierCode = string.Empty;
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
    public string nSupplierID
    {
        get { return objnSupplierID; }
        set { objnSupplierID = value; }
    }
    public string sSupplierCode
    {
        get { return objsSupplierCode; }
        set { objsSupplierCode = value; }
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
    public string User_Operation(mabroadagent_Class mabroadagent_Class, string type)
    {
        SqlCommand cmd = addParameter(mabroadagent_Class, type, "");
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
    public SqlCommand addParameter(mabroadagent_Class mabroadagent_Class, string type, string cond)
    {
        string uid, ConfigID;
        if (Session["uid"] == null)
            uid = "0";
        else
            uid = Session["uid"].ToString();
        ConfigID = "1";


        conn = connobj.makeConnection();
        SqlCommand cmd = new SqlCommand("SP_mabroadagent", conn); cmd.Parameters.AddWithValue("@nAbroadAgentID", mabroadagent_Class.nSupplierID);
        cmd.Parameters.AddWithValue("@sSupplierCode", mabroadagent_Class.sSupplierCode);
        cmd.Parameters.AddWithValue("@dtJoiningDate", mabroadagent_Class.dtJoiningDate);
        cmd.Parameters.AddWithValue("@sAgencyName", mabroadagent_Class.sAgencyName);
        cmd.Parameters.AddWithValue("@sIATANo", mabroadagent_Class.sIATANo);
        cmd.Parameters.AddWithValue("@sLicenseNo", mabroadagent_Class.sLicenseNo);
        cmd.Parameters.AddWithValue("@sGSTNo", mabroadagent_Class.sGSTNo);
        cmd.Parameters.AddWithValue("@sPanCardNo", mabroadagent_Class.sPanCardNo);
        cmd.Parameters.AddWithValue("@nLocationID", mabroadagent_Class.nLocationID);
        cmd.Parameters.AddWithValue("@nOffTele", mabroadagent_Class.nOffTele);
        cmd.Parameters.AddWithValue("@sAuthorizedPerson", mabroadagent_Class.sAuthorizedPerson);
        cmd.Parameters.AddWithValue("@sContactNo", mabroadagent_Class.sContactNo);
        cmd.Parameters.AddWithValue("@sAddress", mabroadagent_Class.sAddress);
        cmd.Parameters.AddWithValue("@nCountryID", mabroadagent_Class.nCountryID);
        cmd.Parameters.AddWithValue("@nCityID", mabroadagent_Class.nCityID);
        cmd.Parameters.AddWithValue("@nPincode", mabroadagent_Class.nPincode);
        cmd.Parameters.AddWithValue("@sEmail", mabroadagent_Class.sEmail);
        cmd.Parameters.AddWithValue("@sWebsite", mabroadagent_Class.sWebsite);
        cmd.Parameters.AddWithValue("@nCreditLimit", mabroadagent_Class.nCreditLimit);
        cmd.Parameters.AddWithValue("@nCAccountID", mabroadagent_Class.nCAccountID);
        cmd.Parameters.AddWithValue("@nStateID", mabroadagent_Class.nStateID);

        cmd.Parameters.AddWithValue("@sVendorContactNo", mabroadagent_Class.VendorContactNo);
        cmd.Parameters.AddWithValue("@sVendorAddress", mabroadagent_Class.VendorAddress);
        cmd.Parameters.AddWithValue("@nVendorCountryID", mabroadagent_Class.VendorCountryID);
        cmd.Parameters.AddWithValue("@nVendorStateID", mabroadagent_Class.VendorStateID);
        cmd.Parameters.AddWithValue("@nVendorCityID", mabroadagent_Class.VendorCityID);
        cmd.Parameters.AddWithValue("@nVendorPincode", mabroadagent_Class.VendorPincode);
        cmd.Parameters.AddWithValue("@sVendorEmail", mabroadagent_Class.VendorEmail);
        cmd.Parameters.AddWithValue("@sVendorLatitude", mabroadagent_Class.VendorLatitude);
        cmd.Parameters.AddWithValue("@sVendorLongitude", mabroadagent_Class.VendorLongitude);
        cmd.Parameters.AddWithValue("@sLatitude", mabroadagent_Class.Latitude);
        cmd.Parameters.AddWithValue("@sLongitude", mabroadagent_Class.Longitude);
        cmd.Parameters.AddWithValue("@nConfigID", ConfigID);

        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(mabroadagent_Class mabroadagent_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(mabroadagent_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(mabroadagent_Class mabroadagent_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(mabroadagent_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(mabroadagent_Class mabroadagent_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(mabroadagent_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewmsupplier");
            return ds.Tables["viewmsupplier"];
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
    public DropDownList ddlOperation(mabroadagent_Class mabroadagent_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(mabroadagent_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewmsupplier");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a supplier", "0"));
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
    public DataTable Tabledata(mabroadagent_Class mabroadagent_Class, string type, string cond)
    {
        DataTable da = new DataTable();
        try
        {
            da = viewData(mabroadagent_Class, type, cond);

        }
        catch
        {

        }
        return da;
    }

}
