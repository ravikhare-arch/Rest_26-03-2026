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
public class mbank_master_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnBankID = string.Empty;
    private string objsBankCode = string.Empty;
    private string objdtJoiningDate = string.Empty;
    private string objsBankName = string.Empty;
    private string objsAccountNo = string.Empty;
    private string objsIFSC = string.Empty;
    private string objsBranch = string.Empty;
    private string objsGSTNo = string.Empty;
    private string objnStateID = string.Empty;
    private string objnTelephone = string.Empty;
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
    private string objnConfigID = string.Empty;
    public string nBankID
    {
        get { return objnBankID; }
        set { objnBankID = value; }
    }
    public string sBankCode
    {
        get { return objsBankCode; }
        set { objsBankCode = value; }
    }
    public string dtJoiningDate
    {
        get { return objdtJoiningDate; }
        set { objdtJoiningDate = value; }
    }
    public string sBankName
    {
        get { return objsBankName; }
        set { objsBankName = value; }
    }
    public string sAccountNo
    {
        get { return objsAccountNo; }
        set { objsAccountNo = value; }
    }
    public string sIFSC
    {
        get { return objsIFSC; }
        set { objsIFSC = value; }
    }
    public string sBranch
    {
        get { return objsBranch; }
        set { objsBranch = value; }
    }
    public string sGSTNo
    {
        get { return objsGSTNo; }
        set { objsGSTNo = value; }
    }
    public string nStateID
    {
        get { return objnStateID; }
        set { objnStateID = value; }
    }
    public string nTelephone
    {
        get { return objnTelephone; }
        set { objnTelephone = value; }
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
    public string nConfigID
    {
        get { return objnConfigID; }
        set { objnConfigID = value; }
    }
    public string User_Operation(mbank_master_Class mbank_master_Class, string type)
    {
        SqlCommand cmd = addParameter(mbank_master_Class, type, "");
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
    public SqlCommand addParameter(mbank_master_Class mbank_master_Class, string type, string cond)
    {
        string uid,ConfigID;
        if (Session["uid"] == null)
            uid = "0";
        else
            uid = Session["uid"].ToString();

        if (Session["ConfigID"] == null)
            ConfigID = "0";
        else
            ConfigID = Session["ConfigID"].ToString();

        conn = connobj.makeConnection();
        SqlCommand cmd = new SqlCommand("SP_mbank_master", conn); cmd.Parameters.AddWithValue("@nBankID", mbank_master_Class.nBankID);
        cmd.Parameters.AddWithValue("@sBankCode", mbank_master_Class.sBankCode);
        cmd.Parameters.AddWithValue("@dtJoiningDate", mbank_master_Class.dtJoiningDate);
        cmd.Parameters.AddWithValue("@sBankName", mbank_master_Class.sBankName);
        cmd.Parameters.AddWithValue("@sAccountNo", mbank_master_Class.sAccountNo);
        cmd.Parameters.AddWithValue("@sIFSC", mbank_master_Class.sIFSC);
        cmd.Parameters.AddWithValue("@sBranch", mbank_master_Class.sBranch);
        cmd.Parameters.AddWithValue("@sGSTNo", mbank_master_Class.sGSTNo);
        cmd.Parameters.AddWithValue("@nStateID", mbank_master_Class.nStateID);
        cmd.Parameters.AddWithValue("@nTelephone", mbank_master_Class.nTelephone);
        cmd.Parameters.AddWithValue("@sAuthorizedPerson", mbank_master_Class.sAuthorizedPerson);
        cmd.Parameters.AddWithValue("@sContactNo", mbank_master_Class.sContactNo);
        cmd.Parameters.AddWithValue("@sAddress", mbank_master_Class.sAddress);
        cmd.Parameters.AddWithValue("@nCountryID", mbank_master_Class.nCountryID);
        cmd.Parameters.AddWithValue("@nCityID", mbank_master_Class.nCityID);
        cmd.Parameters.AddWithValue("@nPincode", mbank_master_Class.nPincode);
        cmd.Parameters.AddWithValue("@sEmail", mbank_master_Class.sEmail);
        cmd.Parameters.AddWithValue("@sWebsite", mbank_master_Class.sWebsite);
        cmd.Parameters.AddWithValue("@nCreditLimit", mbank_master_Class.nCreditLimit);
        cmd.Parameters.AddWithValue("@nCAccountID", mbank_master_Class.nCAccountID);
        cmd.Parameters.AddWithValue("@nConfigID", ConfigID);

        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(mbank_master_Class mbank_master_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(mbank_master_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(mbank_master_Class mbank_master_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(mbank_master_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(mbank_master_Class mbank_master_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(mbank_master_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewmbank_master");
            return ds.Tables["viewmbank_master"];
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
    public DropDownList ddlOperation(mbank_master_Class mbank_master_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(mbank_master_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewmbank_master");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a bank_master", "0"));
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
