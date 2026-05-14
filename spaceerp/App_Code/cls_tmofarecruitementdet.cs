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
public class tmofarecruitementdet_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnMofaRecruitementDetID = string.Empty;
    private string objnMofaBookingID = string.Empty;
    private string objsFullName = string.Empty;
    private string objsPassportNo = string.Empty;
    private string objsPassportType = string.Empty;
    private string objdtPassIssueDate = string.Empty;
    private string objdtPassExpiryDate = string.Empty;
    private string objsPlaceIssue = string.Empty;
    private string objsBirthPlace = string.Empty;
    private string objdtDOB = string.Empty;
    private string objsIDNo = string.Empty;
    private string objsCurNationality = string.Empty;
    private string objsPastNationality = string.Empty;
    private string objsRelation = string.Empty;
    private string objsMaritalStatus = string.Empty;
    private string objsGender = string.Empty;
    private string objsOccupation = string.Empty;
    private string objsQualification = string.Empty;
    private string objsDegreeSource = string.Empty;
    private string objsHomeAdd = string.Empty;
    private string objsVisaType = string.Empty;
    private string objsSaudiMissionIn = string.Empty;
    private string objsDocumentNo = string.Empty;
    private string objsSponserName = string.Empty;
    private string objsSponserIDNo = string.Empty;
    private string objsSponserAdd = string.Empty;
    private string objsSpnserPhone = string.Empty;
    private string objsPortofEntry = string.Empty;
    private string objsNoOfEntry = string.Empty;
    private string objsTransportMode = string.Empty;
    private string objsVisaValidity = string.Empty;
    private string objsPurpose = string.Empty;
    private string objsDuration = string.Empty;
    private string objnBasicFare = string.Empty;
    private string objnOtherTax = string.Empty;
    private string objnCommRcvd = string.Empty;
    private string objnSupScType = string.Empty;
    private string objnSupScpercent = string.Empty;
    private string objnSupSCAmount = string.Empty;
    private string objbSupTax = string.Empty;
    private string objnSupCGst = string.Empty;
    private string objnSupSGst = string.Empty;
    private string objnSupIGst = string.Empty;
    private string objnSupTdsType = string.Empty;
    private string objnSupTdsPercent = string.Empty;
    private string objnSupTdsAmount = string.Empty;
    private string objnSupplierCost = string.Empty;
    private string objnClntScType = string.Empty;
    private string objnClntScPercent = string.Empty;
    private string objnClntScAmount = string.Empty;
    private string objnClntTdsType = string.Empty;
    private string objnClntTdsPercent = string.Empty;
    private string objnClntTdsAmount = string.Empty;
    private string objnDiscount = string.Empty;
    private string objsReemarks = string.Empty;
    private string objbClntTax = string.Empty;
    private string objnClntCGst = string.Empty;
    private string objnClntSGst = string.Empty;
    private string objnClntIGst = string.Empty;
    private string objnClientCost = string.Empty;
    private string objnClntSc2Percent = string.Empty;
    private string objnClntSc2Amount = string.Empty;
    private string objnClntOtherChrgs = string.Empty;
    private string objnCourierChrgs = string.Empty;
    private string objnBookTypeID = string.Empty;
    private string objnCountryID = string.Empty;
    private string objnStatusID = string.Empty;
    private string objnSupDiscount = string.Empty;
    private string objnConfigID = string.Empty;
    private string objvisaimage = string.Empty;
    private string objFUInsurence = string.Empty;

    private string objFUticket = string.Empty;
    private string objFUpasrport = string.Empty;
    private string objFUpassportback = string.Empty;
    private string objFuextra = string.Empty;
    public string Fuextra
    {
        get { return objFuextra; }
        set { objFuextra = value; }
    }
    public string FUpassportback
    {
        get { return objFUpassportback; }
        set { objFUpassportback = value; }
    }
    public string FUpasrport
    {
        get { return objFUpasrport; }
        set { objFUpasrport = value; }
    }
    public string FUticket
    {
        get { return objFUticket; }
        set { objFUticket = value; }
    }
    public string FUInsurence
    {
        get { return objFUInsurence; }
        set { objFUInsurence = value; }
    }
    public string visaimage
    {
        get { return objvisaimage; }
        set { objvisaimage = value; }
    }
    public string nMofaRecruitementDetID
    {
        get { return objnMofaRecruitementDetID; }
        set { objnMofaRecruitementDetID = value; }
    }
    public string nMofaBookingID
    {
        get { return objnMofaBookingID; }
        set { objnMofaBookingID = value; }
    }
    public string sFullName
    {
        get { return objsFullName; }
        set { objsFullName = value; }
    }
    public string sPassportNo
    {
        get { return objsPassportNo; }
        set { objsPassportNo = value; }
    }
    public string sPassportType
    {
        get { return objsPassportType; }
        set { objsPassportType = value; }
    }
    public string dtPassIssueDate
    {
        get { return objdtPassIssueDate; }
        set { objdtPassIssueDate = value; }
    }
    public string dtPassExpiryDate
    {
        get { return objdtPassExpiryDate; }
        set { objdtPassExpiryDate = value; }
    }
    public string sPlaceIssue
    {
        get { return objsPlaceIssue; }
        set { objsPlaceIssue = value; }
    }
    public string sBirthPlace
    {
        get { return objsBirthPlace; }
        set { objsBirthPlace = value; }
    }
    public string dtDOB
    {
        get { return objdtDOB; }
        set { objdtDOB = value; }
    }
    public string sIDNo
    {
        get { return objsIDNo; }
        set { objsIDNo = value; }
    }
    public string sCurNationality
    {
        get { return objsCurNationality; }
        set { objsCurNationality = value; }
    }
    public string sPastNationality
    {
        get { return objsPastNationality; }
        set { objsPastNationality = value; }
    }
    public string sRelation
    {
        get { return objsRelation; }
        set { objsRelation = value; }
    }
    public string sMaritalStatus
    {
        get { return objsMaritalStatus; }
        set { objsMaritalStatus = value; }
    }
    public string sGender
    {
        get { return objsGender; }
        set { objsGender = value; }
    }
    public string sOccupation
    {
        get { return objsOccupation; }
        set { objsOccupation = value; }
    }
    public string sQualification
    {
        get { return objsQualification; }
        set { objsQualification = value; }
    }
    public string sDegreeSource
    {
        get { return objsDegreeSource; }
        set { objsDegreeSource = value; }
    }
    public string sHomeAdd
    {
        get { return objsHomeAdd; }
        set { objsHomeAdd = value; }
    }
    public string sVisaType
    {
        get { return objsVisaType; }
        set { objsVisaType = value; }
    }
    public string sSaudiMissionIn
    {
        get { return objsSaudiMissionIn; }
        set { objsSaudiMissionIn = value; }
    }
    public string sDocumentNo
    {
        get { return objsDocumentNo; }
        set { objsDocumentNo = value; }
    }
    public string sSponserName
    {
        get { return objsSponserName; }
        set { objsSponserName = value; }
    }
    public string sSponserIDNo
    {
        get { return objsSponserIDNo; }
        set { objsSponserIDNo = value; }
    }
    public string sSponserAdd
    {
        get { return objsSponserAdd; }
        set { objsSponserAdd = value; }
    }
    public string sSpnserPhone
    {
        get { return objsSpnserPhone; }
        set { objsSpnserPhone = value; }
    }
    public string sPortofEntry
    {
        get { return objsPortofEntry; }
        set { objsPortofEntry = value; }
    }
    public string sNoOfEntry
    {
        get { return objsNoOfEntry; }
        set { objsNoOfEntry = value; }
    }
    public string sTransportMode
    {
        get { return objsTransportMode; }
        set { objsTransportMode = value; }
    }
    public string sVisaValidity
    {
        get { return objsVisaValidity; }
        set { objsVisaValidity = value; }
    }
    public string sPurpose
    {
        get { return objsPurpose; }
        set { objsPurpose = value; }
    }
    public string sDuration
    {
        get { return objsDuration; }
        set { objsDuration = value; }
    }
    public string nBasicFare
    {
        get { return objnBasicFare; }
        set { objnBasicFare = value; }
    }
    public string nOtherTax
    {
        get { return objnOtherTax; }
        set { objnOtherTax = value; }
    }
    public string nCommRcvd
    {
        get { return objnCommRcvd; }
        set { objnCommRcvd = value; }
    }
    public string nSupScType
    {
        get { return objnSupScType; }
        set { objnSupScType = value; }
    }
    public string nSupScpercent
    {
        get { return objnSupScpercent; }
        set { objnSupScpercent = value; }
    }
    public string nSupSCAmount
    {
        get { return objnSupSCAmount; }
        set { objnSupSCAmount = value; }
    }
    public string bSupTax
    {
        get { return objbSupTax; }
        set { objbSupTax = value; }
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
    public string nSupTdsType
    {
        get { return objnSupTdsType; }
        set { objnSupTdsType = value; }
    }
    public string nSupTdsPercent
    {
        get { return objnSupTdsPercent; }
        set { objnSupTdsPercent = value; }
    }
    public string nSupTdsAmount
    {
        get { return objnSupTdsAmount; }
        set { objnSupTdsAmount = value; }
    }
    public string nSupplierCost
    {
        get { return objnSupplierCost; }
        set { objnSupplierCost = value; }
    }
    public string nClntScType
    {
        get { return objnClntScType; }
        set { objnClntScType = value; }
    }
    public string nClntScPercent
    {
        get { return objnClntScPercent; }
        set { objnClntScPercent = value; }
    }
    public string nClntScAmount
    {
        get { return objnClntScAmount; }
        set { objnClntScAmount = value; }
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
    public string nDiscount
    {
        get { return objnDiscount; }
        set { objnDiscount = value; }
    }
    public string sReemarks
    {
        get { return objsReemarks; }
        set { objsReemarks = value; }
    }
    public string bClntTax
    {
        get { return objbClntTax; }
        set { objbClntTax = value; }
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
    public string nClientCost
    {
        get { return objnClientCost; }
        set { objnClientCost = value; }
    }
    public string nClntSc2Percent
    {
        get { return objnClntSc2Percent; }
        set { objnClntSc2Percent = value; }
    }
    public string nClntSc2Amount
    {
        get { return objnClntSc2Amount; }
        set { objnClntSc2Amount = value; }
    }
    public string nClntOtherChrgs
    {
        get { return objnClntOtherChrgs; }
        set { objnClntOtherChrgs = value; }
    }
    public string nCourierChrgs
    {
        get { return objnCourierChrgs; }
        set { objnCourierChrgs = value; }
    }
    public string nBookTypeID
    {
        get { return objnBookTypeID; }
        set { objnBookTypeID = value; }
    }
    public string nCountryID
    {
        get { return objnCountryID; }
        set { objnCountryID = value; }
    }
    public string nStatusID
    {
        get { return objnStatusID; }
        set { objnStatusID = value; }
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
    public string User_Operation(tmofarecruitementdet_Class tmofarecruitementdet_Class, string type)
    {
        SqlCommand cmd = addParameter(tmofarecruitementdet_Class, type, "");
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
    public SqlCommand addParameter(tmofarecruitementdet_Class tmofarecruitementdet_Class, string type, string cond)
    {
        string uid;
        if (Session["uid"] == null)
            uid = "0";
        else
            uid = Session["uid"].ToString();

        if (Session["ConfigID"] == null)
            nConfigID = "0";
        else
            nConfigID = Session["ConfigID"].ToString();

        conn = connobj.makeConnection();
        SqlCommand cmd = new SqlCommand("SP_tmofarecruitementdet", conn); cmd.Parameters.AddWithValue("@nMofaRecruitementDetID", tmofarecruitementdet_Class.nMofaRecruitementDetID);
        cmd.Parameters.AddWithValue("@nMofaBookingID", tmofarecruitementdet_Class.nMofaBookingID);
        cmd.Parameters.AddWithValue("@sFullName", tmofarecruitementdet_Class.sFullName);
        cmd.Parameters.AddWithValue("@sPassportNo", tmofarecruitementdet_Class.sPassportNo);
        cmd.Parameters.AddWithValue("@sPassportType", tmofarecruitementdet_Class.sPassportType);
        cmd.Parameters.AddWithValue("@dtPassIssueDate", tmofarecruitementdet_Class.dtPassIssueDate);
        cmd.Parameters.AddWithValue("@dtPassExpiryDate", tmofarecruitementdet_Class.dtPassExpiryDate);
        cmd.Parameters.AddWithValue("@sPlaceIssue", tmofarecruitementdet_Class.sPlaceIssue);
        cmd.Parameters.AddWithValue("@sBirthPlace", tmofarecruitementdet_Class.sBirthPlace);
        cmd.Parameters.AddWithValue("@dtDOB", tmofarecruitementdet_Class.dtDOB);
        cmd.Parameters.AddWithValue("@sIDNo", tmofarecruitementdet_Class.sIDNo);
        cmd.Parameters.AddWithValue("@sCurNationality", tmofarecruitementdet_Class.sCurNationality);
        cmd.Parameters.AddWithValue("@sPastNationality", tmofarecruitementdet_Class.sPastNationality);
        cmd.Parameters.AddWithValue("@sRelation", tmofarecruitementdet_Class.sRelation);
        cmd.Parameters.AddWithValue("@sMaritalStatus", tmofarecruitementdet_Class.sMaritalStatus);
        cmd.Parameters.AddWithValue("@sGender", tmofarecruitementdet_Class.sGender);
        cmd.Parameters.AddWithValue("@sOccupation", tmofarecruitementdet_Class.sOccupation);
        cmd.Parameters.AddWithValue("@sQualification", tmofarecruitementdet_Class.sQualification);
        cmd.Parameters.AddWithValue("@sDegreeSource", tmofarecruitementdet_Class.sDegreeSource);
        cmd.Parameters.AddWithValue("@sHomeAdd", tmofarecruitementdet_Class.sHomeAdd);
        cmd.Parameters.AddWithValue("@sVisaType", tmofarecruitementdet_Class.sVisaType);
        cmd.Parameters.AddWithValue("@sSaudiMissionIn", tmofarecruitementdet_Class.sSaudiMissionIn);
        cmd.Parameters.AddWithValue("@sDocumentNo", tmofarecruitementdet_Class.sDocumentNo);
        cmd.Parameters.AddWithValue("@sSponserName", tmofarecruitementdet_Class.sSponserName);
        cmd.Parameters.AddWithValue("@sSponserIDNo", tmofarecruitementdet_Class.sSponserIDNo);
        cmd.Parameters.AddWithValue("@sSponserAdd", tmofarecruitementdet_Class.sSponserAdd);
        cmd.Parameters.AddWithValue("@sSpnserPhone", tmofarecruitementdet_Class.sSpnserPhone);
        cmd.Parameters.AddWithValue("@sPortofEntry", tmofarecruitementdet_Class.sPortofEntry);
        cmd.Parameters.AddWithValue("@sNoOfEntry", tmofarecruitementdet_Class.sNoOfEntry);
        cmd.Parameters.AddWithValue("@sTransportMode", tmofarecruitementdet_Class.sTransportMode);
        cmd.Parameters.AddWithValue("@sVisaValidity", tmofarecruitementdet_Class.sVisaValidity);
        cmd.Parameters.AddWithValue("@sPurpose", tmofarecruitementdet_Class.sPurpose);
        cmd.Parameters.AddWithValue("@sDuration", tmofarecruitementdet_Class.sDuration);
        cmd.Parameters.AddWithValue("@nBasicFare", tmofarecruitementdet_Class.nBasicFare);
        cmd.Parameters.AddWithValue("@nOtherTax", tmofarecruitementdet_Class.nOtherTax);
        cmd.Parameters.AddWithValue("@nCommRcvd", tmofarecruitementdet_Class.nCommRcvd);
        cmd.Parameters.AddWithValue("@nSupScType", tmofarecruitementdet_Class.nSupScType);
        cmd.Parameters.AddWithValue("@nSupScpercent", tmofarecruitementdet_Class.nSupScpercent);
        cmd.Parameters.AddWithValue("@nSupSCAmount", tmofarecruitementdet_Class.nSupSCAmount);
        cmd.Parameters.AddWithValue("@bSupTax", tmofarecruitementdet_Class.bSupTax);
        cmd.Parameters.AddWithValue("@nSupCGst", tmofarecruitementdet_Class.nSupCGst);
        cmd.Parameters.AddWithValue("@nSupSGst", tmofarecruitementdet_Class.nSupSGst);
        cmd.Parameters.AddWithValue("@nSupIGst", tmofarecruitementdet_Class.nSupIGst);
        cmd.Parameters.AddWithValue("@nSupTdsType", tmofarecruitementdet_Class.nSupTdsType);
        cmd.Parameters.AddWithValue("@nSupTdsPercent", tmofarecruitementdet_Class.nSupTdsPercent);
        cmd.Parameters.AddWithValue("@nSupTdsAmount", tmofarecruitementdet_Class.nSupTdsAmount);
        cmd.Parameters.AddWithValue("@nSupplierCost", tmofarecruitementdet_Class.nSupplierCost);
        cmd.Parameters.AddWithValue("@nClntScType", tmofarecruitementdet_Class.nClntScType);
        cmd.Parameters.AddWithValue("@nClntScPercent", tmofarecruitementdet_Class.nClntScPercent);
        cmd.Parameters.AddWithValue("@nClntScAmount", tmofarecruitementdet_Class.nClntScAmount);
        cmd.Parameters.AddWithValue("@nClntTdsType", tmofarecruitementdet_Class.nClntTdsType);
        cmd.Parameters.AddWithValue("@nClntTdsPercent", tmofarecruitementdet_Class.nClntTdsPercent);
        cmd.Parameters.AddWithValue("@nClntTdsAmount", tmofarecruitementdet_Class.nClntTdsAmount);
        cmd.Parameters.AddWithValue("@nDiscount", tmofarecruitementdet_Class.nDiscount);
        cmd.Parameters.AddWithValue("@sReemarks", tmofarecruitementdet_Class.sReemarks);
        cmd.Parameters.AddWithValue("@bClntTax", tmofarecruitementdet_Class.bClntTax);
        cmd.Parameters.AddWithValue("@nClntCGst", tmofarecruitementdet_Class.nClntCGst);
        cmd.Parameters.AddWithValue("@nClntSGst", tmofarecruitementdet_Class.nClntSGst);
        cmd.Parameters.AddWithValue("@nClntIGst", tmofarecruitementdet_Class.nClntIGst);
        cmd.Parameters.AddWithValue("@nClientCost", tmofarecruitementdet_Class.nClientCost);
        cmd.Parameters.AddWithValue("@nClntSc2Percent", tmofarecruitementdet_Class.nClntSc2Percent);
        cmd.Parameters.AddWithValue("@nClntSc2Amount", tmofarecruitementdet_Class.nClntSc2Amount);
        cmd.Parameters.AddWithValue("@nClntOtherChrgs", tmofarecruitementdet_Class.nClntOtherChrgs);
        cmd.Parameters.AddWithValue("@nCourierChrgs", tmofarecruitementdet_Class.nCourierChrgs);
        cmd.Parameters.AddWithValue("@nBookTypeID", tmofarecruitementdet_Class.nBookTypeID);
        cmd.Parameters.AddWithValue("@nCountryID", tmofarecruitementdet_Class.nCountryID);
        cmd.Parameters.AddWithValue("@nStatusID", tmofarecruitementdet_Class.nStatusID);
        cmd.Parameters.AddWithValue("@nSupDiscount", tmofarecruitementdet_Class.nSupDiscount);
        cmd.Parameters.AddWithValue("@nConfigID", nConfigID);
        cmd.Parameters.AddWithValue("@visaimage", tmofarecruitementdet_Class.visaimage);
        cmd.Parameters.AddWithValue("@FUInsurence", tmofarecruitementdet_Class.FUInsurence);
        cmd.Parameters.AddWithValue("@FUticket", tmofarecruitementdet_Class.FUticket);
        cmd.Parameters.AddWithValue("@FUpasrport", tmofarecruitementdet_Class.FUpasrport);
        cmd.Parameters.AddWithValue("@FUpassportback", tmofarecruitementdet_Class.FUpassportback);
        cmd.Parameters.AddWithValue("@Fuextra", tmofarecruitementdet_Class.Fuextra);
        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(tmofarecruitementdet_Class tmofarecruitementdet_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(tmofarecruitementdet_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(tmofarecruitementdet_Class tmofarecruitementdet_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(tmofarecruitementdet_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(tmofarecruitementdet_Class tmofarecruitementdet_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(tmofarecruitementdet_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewtmofarecruitementdet");
            return ds.Tables["viewtmofarecruitementdet"];
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
    public DropDownList ddlOperation(tmofarecruitementdet_Class tmofarecruitementdet_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(tmofarecruitementdet_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewtmofarecruitementdet");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a mofarecruitementdet", "0"));
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
