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
public class tticketingdet_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnTicketingDetID = string.Empty;
    private string objnTicketingID = string.Empty;
    private string objsReferenceNo = string.Empty;
    private string objsCustomerName = string.Empty;
    private string objsPassportNo = string.Empty;
    private string objnTripTypeID = string.Empty;
    private string objsSector = string.Empty;
    private string objnToCountryID = string.Empty;
    private string objdtTravelDate = string.Empty;
    private string objdtReturnDate = string.Empty;
    private string objsTicketPNR = string.Empty;
    private string objnCarrierID = string.Empty;
    private string objnTicketTypeID = string.Empty;
    private string objnFlightClassID = string.Empty;
    private string objsDeparture = string.Empty;
    private string objnStatusID = string.Empty;
    private string objnBasicFare = string.Empty;
    private string objnBuyingCost = string.Empty;
    private string objnProfitType = string.Empty;
    private string objnProfitPercent = string.Empty;
    private string objnProfitAmount = string.Empty;
    private string objnDiscount = string.Empty;
    private string objnSellingCost = string.Empty;
    private string objsRemarks = string.Empty;
    private string objnSupScType = string.Empty;
    private string objnSupScpercent = string.Empty;
    private string objnSupSCAmount = string.Empty;
    private string objbSupTax = string.Empty;
    private string objnSupCGst = string.Empty;
    private string objnSupSGst = string.Empty;
    private string objnSupIGst = string.Empty;
    private string objbClntTax = string.Empty;
    private string objnClntCGst = string.Empty;
    private string objnClntSGst = string.Empty;
    private string objnClntIGst = string.Empty;
    private string objbAirTax = string.Empty;
    private string objnAirCGst = string.Empty;
    private string objnAirSGst = string.Empty;
    private string objnAirIGst = string.Empty;
    private string objnAirInc = string.Empty;
    private string objnAirComm = string.Empty;
    private string objnAirplb = string.Empty;
    private string objnYqTax = string.Empty;
    private string objnYrTax = string.Empty;
    private string objnOcTax = string.Empty;
    private string objnOtherTax = string.Empty;
    private string objnSupTdsType = string.Empty;
    private string objnSupTdsPercent = string.Empty;
    private string objnSupTdsAmount = string.Empty;
    private string objnClntTdsType = string.Empty;
    private string objnClntTdsPercent = string.Empty;
    private string objnClntTdsAmount = string.Empty;
    private string objnK3Tax = string.Empty;
    private string objsAirlinePnr = string.Empty;
    private string objnClientSc2Percent = string.Empty;
    private string objnClientSC2Amount = string.Empty;
    private string objnClntOtherChrgs = string.Empty;
    private string objnClntBasicFare = string.Empty;
    private string objnClntYQTax = string.Empty;
    private string objnClntYRTax = string.Empty;
    private string objnClntK3Tax = string.Empty;
    private string objnClntAirInc = string.Empty;
    private string objnClntAirCom = string.Empty;
    private string objnClntAirPlb = string.Empty;
    private string objnClntOCTax = string.Empty;
    private string objnClntOtherTax = string.Empty;
    private string objdtDueDate = string.Empty;
    private string objsFlightNo = string.Empty;
    private string objsTktBookFrom = string.Empty;
    private string objnclntTktFare = string.Empty;
    private string objnSupTktFare = string.Empty;
    private string objnSupDiscount = string.Empty;
    private string objsPaxType = string.Empty;
    private string objsGender = string.Empty;
    private string objsAge = string.Empty;
    private string objnConfigID = string.Empty;
    public string nTicketingDetID
    {
        get { return objnTicketingDetID; }
        set { objnTicketingDetID = value; }
    }
    public string nTicketingID
    {
        get { return objnTicketingID; }
        set { objnTicketingID = value; }
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
    public string sPassportNo
    {
        get { return objsPassportNo; }
        set { objsPassportNo = value; }
    }
    public string nTripTypeID
    {
        get { return objnTripTypeID; }
        set { objnTripTypeID = value; }
    }
    public string sSector
    {
        get { return objsSector; }
        set { objsSector = value; }
    }
    public string nToCountryID
    {
        get { return objnToCountryID; }
        set { objnToCountryID = value; }
    }
    public string dtTravelDate
    {
        get { return objdtTravelDate; }
        set { objdtTravelDate = value; }
    }
    public string dtReturnDate
    {
        get { return objdtReturnDate; }
        set { objdtReturnDate = value; }
    }
    public string sTicketPNR
    {
        get { return objsTicketPNR; }
        set { objsTicketPNR = value; }
    }
    public string nCarrierID
    {
        get { return objnCarrierID; }
        set { objnCarrierID = value; }
    }
    public string nTicketTypeID
    {
        get { return objnTicketTypeID; }
        set { objnTicketTypeID = value; }
    }
    public string nFlightClassID
    {
        get { return objnFlightClassID; }
        set { objnFlightClassID = value; }
    }
    public string sDeparture
    {
        get { return objsDeparture; }
        set { objsDeparture = value; }
    }
    public string nStatusID
    {
        get { return objnStatusID; }
        set { objnStatusID = value; }
    }
    public string nBasicFare
    {
        get { return objnBasicFare; }
        set { objnBasicFare = value; }
    }
    public string nBuyingCost
    {
        get { return objnBuyingCost; }
        set { objnBuyingCost = value; }
    }
    public string nProfitType
    {
        get { return objnProfitType; }
        set { objnProfitType = value; }
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
    public string nSellingCost
    {
        get { return objnSellingCost; }
        set { objnSellingCost = value; }
    }
    public string sRemarks
    {
        get { return objsRemarks; }
        set { objsRemarks = value; }
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
    public string bAirTax
    {
        get { return objbAirTax; }
        set { objbAirTax = value; }
    }
    public string nAirCGst
    {
        get { return objnAirCGst; }
        set { objnAirCGst = value; }
    }
    public string nAirSGst
    {
        get { return objnAirSGst; }
        set { objnAirSGst = value; }
    }
    public string nAirIGst
    {
        get { return objnAirIGst; }
        set { objnAirIGst = value; }
    }
    public string nAirInc
    {
        get { return objnAirInc; }
        set { objnAirInc = value; }
    }
    public string nAirComm
    {
        get { return objnAirComm; }
        set { objnAirComm = value; }
    }
    public string nAirplb
    {
        get { return objnAirplb; }
        set { objnAirplb = value; }
    }
    public string nYqTax
    {
        get { return objnYqTax; }
        set { objnYqTax = value; }
    }
    public string nYrTax
    {
        get { return objnYrTax; }
        set { objnYrTax = value; }
    }
    public string nOcTax
    {
        get { return objnOcTax; }
        set { objnOcTax = value; }
    }
    public string nOtherTax
    {
        get { return objnOtherTax; }
        set { objnOtherTax = value; }
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
    public string nK3Tax
    {
        get { return objnK3Tax; }
        set { objnK3Tax = value; }
    }
    public string sAirlinePnr
    {
        get { return objsAirlinePnr; }
        set { objsAirlinePnr = value; }
    }
    public string nClientSc2Percent
    {
        get { return objnClientSc2Percent; }
        set { objnClientSc2Percent = value; }
    }
    public string nClientSC2Amount
    {
        get { return objnClientSC2Amount; }
        set { objnClientSC2Amount = value; }
    }
    public string nClntOtherChrgs
    {
        get { return objnClntOtherChrgs; }
        set { objnClntOtherChrgs = value; }
    }
    public string nClntBasicFare
    {
        get { return objnClntBasicFare; }
        set { objnClntBasicFare = value; }
    }
    public string nClntYQTax
    {
        get { return objnClntYQTax; }
        set { objnClntYQTax = value; }
    }
    public string nClntYRTax
    {
        get { return objnClntYRTax; }
        set { objnClntYRTax = value; }
    }
    public string nClntK3Tax
    {
        get { return objnClntK3Tax; }
        set { objnClntK3Tax = value; }
    }
    public string nClntAirInc
    {
        get { return objnClntAirInc; }
        set { objnClntAirInc = value; }
    }
    public string nClntAirCom
    {
        get { return objnClntAirCom; }
        set { objnClntAirCom = value; }
    }
    public string nClntAirPlb
    {
        get { return objnClntAirPlb; }
        set { objnClntAirPlb = value; }
    }
    public string nClntOCTax
    {
        get { return objnClntOCTax; }
        set { objnClntOCTax = value; }
    }
    public string nClntOtherTax
    {
        get { return objnClntOtherTax; }
        set { objnClntOtherTax = value; }
    }
    public string dtDueDate
    {
        get { return objdtDueDate; }
        set { objdtDueDate = value; }
    }
    public string sFlightNo
    {
        get { return objsFlightNo; }
        set { objsFlightNo = value; }
    }
    public string sTktBookFrom
    {
        get { return objsTktBookFrom; }
        set { objsTktBookFrom = value; }
    }
    public string nclntTktFare
    {
        get { return objnclntTktFare; }
        set { objnclntTktFare = value; }
    }
    public string nSupTktFare
    {
        get { return objnSupTktFare; }
        set { objnSupTktFare = value; }
    }
    public string nSupDiscount
    {
        get { return objnSupDiscount; }
        set { objnSupDiscount = value; }
    }
    public string sPaxType
    {
        get { return objsPaxType; }
        set { objsPaxType = value; }
    }
    public string sGender
    {
        get { return objsGender; }
        set { objsGender = value; }
    }
    public string sAge
    {
        get { return objsAge; }
        set { objsAge = value; }
    }
    public string sLPONo { get; set; }
    public string sPCC { get; set; }
    public string nAirlineCodeID { get; set; }
    public string sGalPNRNo { get; set; }
    public string sIATANo { get; set; }
    public string sPAXMob { get; set; }
    public string sPAXEmail { get; set; }
    public string sTripLength { get; set; }
    public string nNoofSegment { get; set; }
    public string sFileName { get; set; }
    public string dtProcess { get; set; }
    public string sProcessTime { get; set; }
    public string sBookSign { get; set; }
    public string sStaffSign { get; set; }
    public string sTourCode { get; set; }
    public string sFareBasis { get; set; }
    public string sTaxDetails { get; set; }
    public string sCancellation { get; set; }
    public string sResissue { get; set; }
    public string sAmex { get; set; }
    public string sEmpno { get; set; }
    public string sDesignator { get; set; }
    public string nConfigID
    {
        get { return objnConfigID; }
        set { objnConfigID = value; }
    }
    public string User_Operation(tticketingdet_Class tticketingdet_Class, string type)
    {
        SqlCommand cmd = addParameter(tticketingdet_Class, type, "");
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
    public SqlCommand addParameter(tticketingdet_Class tticketingdet_Class, string type, string cond)
    {
        string uid, ConfigID;
        if (Session["uid"] == null)
            uid = "0";
        else
            uid = Session["uid"].ToString();

        if (Session["ConfigID"] == null)
            ConfigID = "1";
        else
            ConfigID = Session["ConfigID"].ToString();
        conn = connobj.makeConnection();
        SqlCommand cmd = new SqlCommand("SP_tticketingdet", conn); cmd.Parameters.AddWithValue("@nTicketingDetID", tticketingdet_Class.nTicketingDetID);
        cmd.Parameters.AddWithValue("@nTicketingID", tticketingdet_Class.nTicketingID);
        cmd.Parameters.AddWithValue("@sReferenceNo", tticketingdet_Class.sReferenceNo);
        cmd.Parameters.AddWithValue("@sCustomerName", tticketingdet_Class.sCustomerName);
        cmd.Parameters.AddWithValue("@sPassportNo", tticketingdet_Class.sPassportNo);
        cmd.Parameters.AddWithValue("@nTripTypeID", tticketingdet_Class.nTripTypeID);
        cmd.Parameters.AddWithValue("@sSector", tticketingdet_Class.sSector);
        cmd.Parameters.AddWithValue("@nToCountryID", tticketingdet_Class.nToCountryID);
        cmd.Parameters.AddWithValue("@dtTravelDate", tticketingdet_Class.dtTravelDate);
        cmd.Parameters.AddWithValue("@dtReturnDate", tticketingdet_Class.dtReturnDate);
        cmd.Parameters.AddWithValue("@sTicketPNR", tticketingdet_Class.sTicketPNR);
        cmd.Parameters.AddWithValue("@nCarrierID", tticketingdet_Class.nCarrierID);
        cmd.Parameters.AddWithValue("@nTicketTypeID", tticketingdet_Class.nTicketTypeID);
        cmd.Parameters.AddWithValue("@nFlightClassID", tticketingdet_Class.nFlightClassID);
        cmd.Parameters.AddWithValue("@sDeparture", tticketingdet_Class.sDeparture);
        cmd.Parameters.AddWithValue("@nStatusID", tticketingdet_Class.nStatusID);
        cmd.Parameters.AddWithValue("@nBasicFare", tticketingdet_Class.nBasicFare);
        cmd.Parameters.AddWithValue("@nBuyingCost", tticketingdet_Class.nBuyingCost);
        cmd.Parameters.AddWithValue("@nProfitType", tticketingdet_Class.nProfitType);
        cmd.Parameters.AddWithValue("@nProfitPercent", tticketingdet_Class.nProfitPercent);
        cmd.Parameters.AddWithValue("@nProfitAmount", tticketingdet_Class.nProfitAmount);
        cmd.Parameters.AddWithValue("@nDiscount", tticketingdet_Class.nDiscount);
        cmd.Parameters.AddWithValue("@nSellingCost", tticketingdet_Class.nSellingCost);
        cmd.Parameters.AddWithValue("@sRemarks", tticketingdet_Class.sRemarks);
        cmd.Parameters.AddWithValue("@nSupScType", tticketingdet_Class.nSupScType);
        cmd.Parameters.AddWithValue("@nSupScpercent", tticketingdet_Class.nSupScpercent);
        cmd.Parameters.AddWithValue("@nSupSCAmount", tticketingdet_Class.nSupSCAmount);
        cmd.Parameters.AddWithValue("@bSupTax", tticketingdet_Class.bSupTax);
        cmd.Parameters.AddWithValue("@nSupCGst", tticketingdet_Class.nSupCGst);
        cmd.Parameters.AddWithValue("@nSupSGst", tticketingdet_Class.nSupSGst);
        cmd.Parameters.AddWithValue("@nSupIGst", tticketingdet_Class.nSupIGst);
        cmd.Parameters.AddWithValue("@bClntTax", tticketingdet_Class.bClntTax);
        cmd.Parameters.AddWithValue("@nClntCGst", tticketingdet_Class.nClntCGst);
        cmd.Parameters.AddWithValue("@nClntSGst", tticketingdet_Class.nClntSGst);
        cmd.Parameters.AddWithValue("@nClntIGst", tticketingdet_Class.nClntIGst);
        cmd.Parameters.AddWithValue("@bAirTax", tticketingdet_Class.bAirTax);
        cmd.Parameters.AddWithValue("@nAirCGst", tticketingdet_Class.nAirCGst);
        cmd.Parameters.AddWithValue("@nAirSGst", tticketingdet_Class.nAirSGst);
        cmd.Parameters.AddWithValue("@nAirIGst", tticketingdet_Class.nAirIGst);
        cmd.Parameters.AddWithValue("@nAirInc", tticketingdet_Class.nAirInc);
        cmd.Parameters.AddWithValue("@nAirComm", tticketingdet_Class.nAirComm);
        cmd.Parameters.AddWithValue("@nAirplb", tticketingdet_Class.nAirplb);
        cmd.Parameters.AddWithValue("@nYqTax", tticketingdet_Class.nYqTax);
        cmd.Parameters.AddWithValue("@nYrTax", tticketingdet_Class.nYrTax);
        cmd.Parameters.AddWithValue("@nOcTax", tticketingdet_Class.nOcTax);
        cmd.Parameters.AddWithValue("@nOtherTax", tticketingdet_Class.nOtherTax);
        cmd.Parameters.AddWithValue("@nSupTdsType", tticketingdet_Class.nSupTdsType);
        cmd.Parameters.AddWithValue("@nSupTdsPercent", tticketingdet_Class.nSupTdsPercent);
        cmd.Parameters.AddWithValue("@nSupTdsAmount", tticketingdet_Class.nSupTdsAmount);
        cmd.Parameters.AddWithValue("@nClntTdsType", tticketingdet_Class.nClntTdsType);
        cmd.Parameters.AddWithValue("@nClntTdsPercent", tticketingdet_Class.nClntTdsPercent);
        cmd.Parameters.AddWithValue("@nClntTdsAmount", tticketingdet_Class.nClntTdsAmount);
        cmd.Parameters.AddWithValue("@nK3Tax", tticketingdet_Class.nK3Tax);
        cmd.Parameters.AddWithValue("@sAirlinePnr", tticketingdet_Class.sAirlinePnr);
        cmd.Parameters.AddWithValue("@nClientSc2Percent", tticketingdet_Class.nClientSc2Percent);
        cmd.Parameters.AddWithValue("@nClientSC2Amount", tticketingdet_Class.nClientSC2Amount);
        cmd.Parameters.AddWithValue("@nClntOtherChrgs", tticketingdet_Class.nClntOtherChrgs);
        cmd.Parameters.AddWithValue("@nClntBasicFare", tticketingdet_Class.nClntBasicFare);
        cmd.Parameters.AddWithValue("@nClntYQTax", tticketingdet_Class.nClntYQTax);
        cmd.Parameters.AddWithValue("@nClntYRTax", tticketingdet_Class.nClntYRTax);
        cmd.Parameters.AddWithValue("@nClntK3Tax", tticketingdet_Class.nClntK3Tax);
        cmd.Parameters.AddWithValue("@nClntAirInc", tticketingdet_Class.nClntAirInc);
        cmd.Parameters.AddWithValue("@nClntAirCom", tticketingdet_Class.nClntAirCom);
        cmd.Parameters.AddWithValue("@nClntAirPlb", tticketingdet_Class.nClntAirPlb);
        cmd.Parameters.AddWithValue("@nClntOCTax", tticketingdet_Class.nClntOCTax);
        cmd.Parameters.AddWithValue("@nClntOtherTax", tticketingdet_Class.nClntOtherTax);
        cmd.Parameters.AddWithValue("@dtDueDate", tticketingdet_Class.dtDueDate);
        cmd.Parameters.AddWithValue("@sFlightNo", tticketingdet_Class.sFlightNo);
        cmd.Parameters.AddWithValue("@sTktBookFrom", tticketingdet_Class.sTktBookFrom);
        cmd.Parameters.AddWithValue("@nclntTktFare", tticketingdet_Class.nclntTktFare);
        cmd.Parameters.AddWithValue("@nSupTktFare", tticketingdet_Class.nSupTktFare);
        cmd.Parameters.AddWithValue("@nSupDiscount", tticketingdet_Class.nSupDiscount);
        cmd.Parameters.AddWithValue("@sPaxType", tticketingdet_Class.sPaxType);
        cmd.Parameters.AddWithValue("@sGender", tticketingdet_Class.sGender);
        cmd.Parameters.AddWithValue("@sAge", tticketingdet_Class.sAge);
        cmd.Parameters.AddWithValue("@LPONo", tticketingdet_Class.sLPONo);
        cmd.Parameters.AddWithValue("@PCC", tticketingdet_Class.sPCC);
        cmd.Parameters.AddWithValue("@AirlineCodeid", tticketingdet_Class.nAirlineCodeID);
        cmd.Parameters.AddWithValue("@GALPNRNo", tticketingdet_Class.sGalPNRNo);
        cmd.Parameters.AddWithValue("@IATANo", tticketingdet_Class.sIATANo);
        cmd.Parameters.AddWithValue("@PAXMobile", tticketingdet_Class.sPAXMob);
        cmd.Parameters.AddWithValue("@PAXEmail", tticketingdet_Class.sPAXEmail);
        cmd.Parameters.AddWithValue("@TripLength", tticketingdet_Class.sTripLength);
        cmd.Parameters.AddWithValue("@NoofSegment", tticketingdet_Class.nNoofSegment);
        cmd.Parameters.AddWithValue("@dtProcess", tticketingdet_Class.dtProcess);
        cmd.Parameters.AddWithValue("@Processtime", tticketingdet_Class.sProcessTime);
        cmd.Parameters.AddWithValue("@BookingSign", tticketingdet_Class.sBookSign);
        cmd.Parameters.AddWithValue("@StaffSign", tticketingdet_Class.sStaffSign);
        cmd.Parameters.AddWithValue("@TourCode", tticketingdet_Class.sTourCode);
        cmd.Parameters.AddWithValue("@FareBasis", tticketingdet_Class.sFareBasis);
        cmd.Parameters.AddWithValue("@Cancellation", tticketingdet_Class.sCancellation);
        cmd.Parameters.AddWithValue("@Reissue", tticketingdet_Class.sResissue);
        cmd.Parameters.AddWithValue("@Amex", tticketingdet_Class.sAmex);
        cmd.Parameters.AddWithValue("@Empno", tticketingdet_Class.sEmpno);
        cmd.Parameters.AddWithValue("@Designator", tticketingdet_Class.sDesignator);
        
        cmd.Parameters.AddWithValue("@nConfigID", ConfigID);

        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(tticketingdet_Class tticketingdet_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(tticketingdet_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(tticketingdet_Class tticketingdet_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(tticketingdet_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(tticketingdet_Class tticketingdet_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(tticketingdet_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewtticketingdet");
            return ds.Tables["viewtticketingdet"];
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
    public DropDownList ddlOperation(tticketingdet_Class tticketingdet_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(tticketingdet_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewtticketingdet");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a ticketingdet", "0"));
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
    public DataTable Tabledata(tticketingdet_Class tticketingdet_Class, string type, string cond)
    {
        DataTable da = new DataTable();
        try
        {
            da = viewData(tticketingdet_Class, type, cond);
        }
        catch
        {

        }
        return da;
    }

}
