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
public class tvisadet_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnVisaDetID = string.Empty;
    private string objnVisaID = string.Empty;
    private string objsReferenceNo = string.Empty;
    private string objsCustomerName = string.Empty;
    private string objbGender = string.Empty;
    private string objdtDOB = string.Empty;
    private string objsPassportNo = string.Empty;
    private string objdtPassportIssue = string.Empty;
    private string objdtPasspoprtExpiry = string.Empty;
    private string objsNationality = string.Empty;
    private string objdtExpectedArrival = string.Empty;
    private string objdtExpectedDeparture = string.Empty;
    private string objnExpectedDuration = string.Empty;
    private string objnVisaCompanyID = string.Empty;
    private string objnVisaTypeID = string.Empty;
    private string objnVisaStatusID = string.Empty;
    private string objnExtension = string.Empty;
    private string objsReference1 = string.Empty;
    private string objsContact1 = string.Empty;
    private string objsReference2 = string.Empty;
    private string objsContact2 = string.Empty;
    private string objnOtherCharges = string.Empty;
    private string objnCourierCharges = string.Empty;
    private string objdtVisaExpiryDate = string.Empty;
    private string objnCost = string.Empty;
    private string objnDuration = string.Empty;
    private string objdtApply = string.Empty;
    private string objdtIssue = string.Empty;
    private string objnVisaRate = string.Empty;
    private string objnClntSC2Percent = string.Empty;
    private string objnClntSC2Amount = string.Empty;
    private string objnProfitTypeID = string.Empty;
    private string objnProfitPercent = string.Empty;
    private string objnProfitAmount = string.Empty;
    private string objnDiscount = string.Empty;
    private string objsRemarks = string.Empty;
    private string objnBuyCost = string.Empty;
    private string objnSupSCtype = string.Empty;
    private string objnSupSCPercent = string.Empty;
    private string objnSupSCAmount = string.Empty;
    private string objnSupTDStype = string.Empty;
    private string objnSupTDSPercent = string.Empty;
    private string objnSupTDSAmount = string.Empty;
    private string objbSupGst = string.Empty;
    private string objnSupCGst = string.Empty;
    private string objnSupSGst = string.Empty;
    private string objnSupIGst = string.Empty;
    private string objnClntTdsType = string.Empty;
    private string objnClntTdsPercent = string.Empty;
    private string objnClntTdsAmount = string.Empty;
    private string objbClntGst = string.Empty;
    private string objnClntCGst = string.Empty;
    private string objnClntSGst = string.Empty;
    private string objnClntIGst = string.Empty;
    private string objnCountryID = string.Empty;
    private string objnBookTypeID = string.Empty;
    private string objnSupDiscount = string.Empty;
    private string objnConfigID = string.Empty;
    public string nVisaDetID
    {
        get { return objnVisaDetID; }
        set { objnVisaDetID = value; }
    }
    public string nVisaID
    {
        get { return objnVisaID; }
        set { objnVisaID = value; }
    }
    public string sReferenceNo
    {
        get { return objsReferenceNo; }
        set { objsReferenceNo = value; }
    }
    public string sCustomerName
    {
        get { return objsCustomerName; }
        set { objsCustomerName = value; }
    }
    public string bGender
    {
        get { return objbGender; }
        set { objbGender = value; }
    }
    public string dtDOB
    {
        get { return objdtDOB; }
        set { objdtDOB = value; }
    }
    public string sPassportNo
    {
        get { return objsPassportNo; }
        set { objsPassportNo = value; }
    }
    public string dtPassportIssue
    {
        get { return objdtPassportIssue; }
        set { objdtPassportIssue = value; }
    }
    public string dtPasspoprtExpiry
    {
        get { return objdtPasspoprtExpiry; }
        set { objdtPasspoprtExpiry = value; }
    }
    public string sNationality
    {
        get { return objsNationality; }
        set { objsNationality = value; }
    }
    public string dtExpectedArrival
    {
        get { return objdtExpectedArrival; }
        set { objdtExpectedArrival = value; }
    }
    public string dtExpectedDeparture
    {
        get { return objdtExpectedDeparture; }
        set { objdtExpectedDeparture = value; }
    }
    public string nExpectedDuration
    {
        get { return objnExpectedDuration; }
        set { objnExpectedDuration = value; }
    }
    public string nVisaCompanyID
    {
        get { return objnVisaCompanyID; }
        set { objnVisaCompanyID = value; }
    }
    public string nVisaTypeID
    {
        get { return objnVisaTypeID; }
        set { objnVisaTypeID = value; }
    }
    public string nVisaStatusID
    {
        get { return objnVisaStatusID; }
        set { objnVisaStatusID = value; }
    }
    public string nExtension
    {
        get { return objnExtension; }
        set { objnExtension = value; }
    }
    public string sReference1
    {
        get { return objsReference1; }
        set { objsReference1 = value; }
    }
    public string sContact1
    {
        get { return objsContact1; }
        set { objsContact1 = value; }
    }
    public string sReference2
    {
        get { return objsReference2; }
        set { objsReference2 = value; }
    }
    public string sContact2
    {
        get { return objsContact2; }
        set { objsContact2 = value; }
    }
    public string nOtherCharges
    {
        get { return objnOtherCharges; }
        set { objnOtherCharges = value; }
    }
    public string nCourierCharges
    {
        get { return objnCourierCharges; }
        set { objnCourierCharges = value; }
    }
    public string dtVisaExpiryDate
    {
        get { return objdtVisaExpiryDate; }
        set { objdtVisaExpiryDate = value; }
    }
    public string nCost
    {
        get { return objnCost; }
        set { objnCost = value; }
    }
    public string nDuration
    {
        get { return objnDuration; }
        set { objnDuration = value; }
    }
    public string dtApply
    {
        get { return objdtApply; }
        set { objdtApply = value; }
    }
    public string dtIssue
    {
        get { return objdtIssue; }
        set { objdtIssue = value; }
    }
    public string nVisaRate
    {
        get { return objnVisaRate; }
        set { objnVisaRate = value; }
    }
    public string nClntSC2Percent
    {
        get { return objnClntSC2Percent; }
        set { objnClntSC2Percent = value; }
    }
    public string nClntSC2Amount
    {
        get { return objnClntSC2Amount; }
        set { objnClntSC2Amount = value; }
    }
    public string nProfitTypeID
    {
        get { return objnProfitTypeID; }
        set { objnProfitTypeID = value; }
    }
    public string nProfitPercent
    {
        get { return objnProfitPercent; }
        set { objnProfitPercent = value; }
    }
    public string nProfitAmount
    {
        get { return objnProfitAmount; }
        set { objnProfitAmount = value; }
    }
    public string nDiscount
    {
        get { return objnDiscount; }
        set { objnDiscount = value; }
    }
    public string sRemarks
    {
        get { return objsRemarks; }
        set { objsRemarks = value; }
    }
    public string nBuyCost
    {
        get { return objnBuyCost; }
        set { objnBuyCost = value; }
    }
    public string nSupSCtype
    {
        get { return objnSupSCtype; }
        set { objnSupSCtype = value; }
    }
    public string nSupSCPercent
    {
        get { return objnSupSCPercent; }
        set { objnSupSCPercent = value; }
    }
    public string nSupSCAmount
    {
        get { return objnSupSCAmount; }
        set { objnSupSCAmount = value; }
    }
    public string nSupTDStype
    {
        get { return objnSupTDStype; }
        set { objnSupTDStype = value; }
    }
    public string nSupTDSPercent
    {
        get { return objnSupTDSPercent; }
        set { objnSupTDSPercent = value; }
    }
    public string nSupTDSAmount
    {
        get { return objnSupTDSAmount; }
        set { objnSupTDSAmount = value; }
    }
    public string bSupGst
    {
        get { return objbSupGst; }
        set { objbSupGst = value; }
    }
    public string nSupCGst
    {
        get { return objnSupCGst; }
        set { objnSupCGst = value; }
    }
    public string nSupSGst
    {
        get { return objnSupSGst; }
        set { objnSupSGst = value; }
    }
    public string nSupIGst
    {
        get { return objnSupIGst; }
        set { objnSupIGst = value; }
    }
    public string nClntTdsType
    {
        get { return objnClntTdsType; }
        set { objnClntTdsType = value; }
    }
    public string nClntTdsPercent
    {
        get { return objnClntTdsPercent; }
        set { objnClntTdsPercent = value; }
    }
    public string nClntTdsAmount
    {
        get { return objnClntTdsAmount; }
        set { objnClntTdsAmount = value; }
    }
    public string bClntGst
    {
        get { return objbClntGst; }
        set { objbClntGst = value; }
    }
    public string nClntCGst
    {
        get { return objnClntCGst; }
        set { objnClntCGst = value; }
    }
    public string nClntSGst
    {
        get { return objnClntSGst; }
        set { objnClntSGst = value; }
    }
    public string nClntIGst
    {
        get { return objnClntIGst; }
        set { objnClntIGst = value; }
    }
    public string nCountryID
    {
        get { return objnCountryID; }
        set { objnCountryID = value; }
    }
    public string nBookTypeID
    {
        get { return objnBookTypeID; }
        set { objnBookTypeID = value; }
    }
    public string nSupDiscount
    {
        get { return objnSupDiscount; }
        set { objnSupDiscount = value; }
    }

    public string nConfigID
    {
        get { return objnConfigID; }
        set { objnConfigID = value; }
    }
    public string User_Operation(tvisadet_Class tvisadet_Class, string type)
    {
        SqlCommand cmd = addParameter(tvisadet_Class, type, "");
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
    public SqlCommand addParameter(tvisadet_Class tvisadet_Class, string type, string cond)
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
        SqlCommand cmd = new SqlCommand("SP_tvisadet", conn); cmd.Parameters.AddWithValue("@nVisaDetID", tvisadet_Class.nVisaDetID);
        cmd.Parameters.AddWithValue("@nVisaID", tvisadet_Class.nVisaID);
        cmd.Parameters.AddWithValue("@sReferenceNo", tvisadet_Class.sReferenceNo);
        cmd.Parameters.AddWithValue("@sCustomerName", tvisadet_Class.sCustomerName);
        cmd.Parameters.AddWithValue("@bGender", tvisadet_Class.bGender);
        cmd.Parameters.AddWithValue("@dtDOB", tvisadet_Class.dtDOB);
        cmd.Parameters.AddWithValue("@sPassportNo", tvisadet_Class.sPassportNo);
        cmd.Parameters.AddWithValue("@dtPassportIssue", tvisadet_Class.dtPassportIssue);
        cmd.Parameters.AddWithValue("@dtPasspoprtExpiry", tvisadet_Class.dtPasspoprtExpiry);
        cmd.Parameters.AddWithValue("@sNationality", tvisadet_Class.sNationality);
        cmd.Parameters.AddWithValue("@dtExpectedArrival", tvisadet_Class.dtExpectedArrival);
        cmd.Parameters.AddWithValue("@dtExpectedDeparture", tvisadet_Class.dtExpectedDeparture);
        cmd.Parameters.AddWithValue("@nExpectedDuration", tvisadet_Class.nExpectedDuration);
        cmd.Parameters.AddWithValue("@nVisaCompanyID", tvisadet_Class.nVisaCompanyID);
        cmd.Parameters.AddWithValue("@nVisaTypeID", tvisadet_Class.nVisaTypeID);
        cmd.Parameters.AddWithValue("@nVisaStatusID", tvisadet_Class.nVisaStatusID);
        cmd.Parameters.AddWithValue("@nExtension", tvisadet_Class.nExtension);
        cmd.Parameters.AddWithValue("@sReference1", tvisadet_Class.sReference1);
        cmd.Parameters.AddWithValue("@sContact1", tvisadet_Class.sContact1);
        cmd.Parameters.AddWithValue("@sReference2", tvisadet_Class.sReference2);
        cmd.Parameters.AddWithValue("@sContact2", tvisadet_Class.sContact2);
        cmd.Parameters.AddWithValue("@nOtherCharges", tvisadet_Class.nOtherCharges);
        cmd.Parameters.AddWithValue("@nCourierCharges", tvisadet_Class.nCourierCharges);
        cmd.Parameters.AddWithValue("@dtVisaExpiryDate", tvisadet_Class.dtVisaExpiryDate);
        cmd.Parameters.AddWithValue("@nCost", tvisadet_Class.nCost);
        cmd.Parameters.AddWithValue("@nDuration", tvisadet_Class.nDuration);
        cmd.Parameters.AddWithValue("@dtApply", tvisadet_Class.dtApply);
        cmd.Parameters.AddWithValue("@dtIssue", tvisadet_Class.dtIssue);
        cmd.Parameters.AddWithValue("@nVisaRate", tvisadet_Class.nVisaRate);
        cmd.Parameters.AddWithValue("@nClntSC2Percent", tvisadet_Class.nClntSC2Percent);
        cmd.Parameters.AddWithValue("@nClntSC2Amount", tvisadet_Class.nClntSC2Amount);
        cmd.Parameters.AddWithValue("@nProfitTypeID", tvisadet_Class.nProfitTypeID);
        cmd.Parameters.AddWithValue("@nProfitPercent", tvisadet_Class.nProfitPercent);
        cmd.Parameters.AddWithValue("@nProfitAmount", tvisadet_Class.nProfitAmount);
        cmd.Parameters.AddWithValue("@nDiscount", tvisadet_Class.nDiscount);
        cmd.Parameters.AddWithValue("@sRemarks", tvisadet_Class.sRemarks);
        cmd.Parameters.AddWithValue("@nBuyCost", tvisadet_Class.nBuyCost);
        cmd.Parameters.AddWithValue("@nSupSCtype", tvisadet_Class.nSupSCtype);
        cmd.Parameters.AddWithValue("@nSupSCPercent", tvisadet_Class.nSupSCPercent);
        cmd.Parameters.AddWithValue("@nSupSCAmount", tvisadet_Class.nSupSCAmount);
        cmd.Parameters.AddWithValue("@nSupTDStype", tvisadet_Class.nSupTDStype);
        cmd.Parameters.AddWithValue("@nSupTDSPercent", tvisadet_Class.nSupTDSPercent);
        cmd.Parameters.AddWithValue("@nSupTDSAmount", tvisadet_Class.nSupTDSAmount);
        cmd.Parameters.AddWithValue("@bSupGst", tvisadet_Class.bSupGst);
        cmd.Parameters.AddWithValue("@nSupCGst", tvisadet_Class.nSupCGst);
        cmd.Parameters.AddWithValue("@nSupSGst", tvisadet_Class.nSupSGst);
        cmd.Parameters.AddWithValue("@nSupIGst", tvisadet_Class.nSupIGst);
        cmd.Parameters.AddWithValue("@nClntTdsType", tvisadet_Class.nClntTdsType);
        cmd.Parameters.AddWithValue("@nClntTdsPercent", tvisadet_Class.nClntTdsPercent);
        cmd.Parameters.AddWithValue("@nClntTdsAmount", tvisadet_Class.nClntTdsAmount);
        cmd.Parameters.AddWithValue("@bClntGst", tvisadet_Class.bClntGst);
        cmd.Parameters.AddWithValue("@nClntCGst", tvisadet_Class.nClntCGst);
        cmd.Parameters.AddWithValue("@nClntSGst", tvisadet_Class.nClntSGst);
        cmd.Parameters.AddWithValue("@nClntIGst", tvisadet_Class.nClntIGst);
        cmd.Parameters.AddWithValue("@nCountryID", tvisadet_Class.nCountryID);
        cmd.Parameters.AddWithValue("@nBookTypeID", tvisadet_Class.nBookTypeID);
        cmd.Parameters.AddWithValue("@nSupDiscount", tvisadet_Class.nSupDiscount);
        cmd.Parameters.AddWithValue("@nConfigID", ConfigID);

        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(tvisadet_Class tvisadet_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(tvisadet_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(tvisadet_Class tvisadet_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(tvisadet_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(tvisadet_Class tvisadet_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(tvisadet_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewtvisadet");
            return ds.Tables["viewtvisadet"];
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
    public DropDownList ddlOperation(tvisadet_Class tvisadet_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(tvisadet_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewtvisadet");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a visadet", "0"));
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
