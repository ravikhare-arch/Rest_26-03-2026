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
public class mbranches_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnBranchID = string.Empty;
    private string objsBranchCode = string.Empty;
    private string objdtJoiningDate = string.Empty;
    private string objsBranchName = string.Empty;
    private string objsIATANo = string.Empty;
    private string objsLicenseNo = string.Empty;
    private string objsGSTNo = string.Empty;
    private string objsPanCardNo = string.Empty;
    private string objnCompanyID = string.Empty;
    private string objnOffTele = string.Empty;
    private string objsAuthorizedPerson = string.Empty;
    private string objsContactNo = string.Empty;
    private string objsAddress = string.Empty;
    private string objnCountryID = string.Empty;
    private string objnCityID = string.Empty;
    private string objnPincode = string.Empty;
    private string objsEmail = string.Empty;
    private string objsWebsite = string.Empty;
    private string objnStateID = string.Empty;
    private string objnConfigID = string.Empty;
    public string nBranchID
    {
        get { return objnBranchID; }
        set { objnBranchID = value; }
    }
    public string sBranchCode
    {
        get { return objsBranchCode; }
        set { objsBranchCode = value; }
    }
    public string dtJoiningDate
    {
        get { return objdtJoiningDate; }
        set { objdtJoiningDate = value; }
    }
    public string sBranchName
    {
        get { return objsBranchName; }
        set { objsBranchName = value; }
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
    public string nCompanyID
    {
        get { return objnCompanyID; }
        set { objnCompanyID = value; }
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
    public string User_Operation(mbranches_Class mbranches_Class, string type)
    {
        SqlCommand cmd = addParameter(mbranches_Class, type, "");
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
    public SqlCommand addParameter(mbranches_Class mbranches_Class, string type, string cond)
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
        SqlCommand cmd = new SqlCommand("SP_mbranches", conn); cmd.Parameters.AddWithValue("@nBranchID", mbranches_Class.nBranchID);
        cmd.Parameters.AddWithValue("@sBranchCode", mbranches_Class.sBranchCode);
        cmd.Parameters.AddWithValue("@dtJoiningDate", mbranches_Class.dtJoiningDate);
        cmd.Parameters.AddWithValue("@sBranchName", mbranches_Class.sBranchName);
        cmd.Parameters.AddWithValue("@sIATANo", mbranches_Class.sIATANo);
        cmd.Parameters.AddWithValue("@sLicenseNo", mbranches_Class.sLicenseNo);
        cmd.Parameters.AddWithValue("@sGSTNo", mbranches_Class.sGSTNo);
        cmd.Parameters.AddWithValue("@sPanCardNo", mbranches_Class.sPanCardNo);
        cmd.Parameters.AddWithValue("@nCompanyID", mbranches_Class.nCompanyID);
        cmd.Parameters.AddWithValue("@nOffTele", mbranches_Class.nOffTele);
        cmd.Parameters.AddWithValue("@sAuthorizedPerson", mbranches_Class.sAuthorizedPerson);
        cmd.Parameters.AddWithValue("@sContactNo", mbranches_Class.sContactNo);
        cmd.Parameters.AddWithValue("@sAddress", mbranches_Class.sAddress);
        cmd.Parameters.AddWithValue("@nCountryID", mbranches_Class.nCountryID);
        cmd.Parameters.AddWithValue("@nCityID", mbranches_Class.nCityID);
        cmd.Parameters.AddWithValue("@nPincode", mbranches_Class.nPincode);
        cmd.Parameters.AddWithValue("@sEmail", mbranches_Class.sEmail);
        cmd.Parameters.AddWithValue("@sWebsite", mbranches_Class.sWebsite);
        cmd.Parameters.AddWithValue("@nStateID", mbranches_Class.nStateID);
        cmd.Parameters.AddWithValue("@nConfigID", ConfigID);

        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(mbranches_Class mbranches_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(mbranches_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(mbranches_Class mbranches_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(mbranches_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(mbranches_Class mbranches_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(mbranches_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewmbranches");
            return ds.Tables["viewmbranches"];
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
    public DropDownList ddlOperation(mbranches_Class mbranches_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(mbranches_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewmbranches");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a branches", "0"));
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
