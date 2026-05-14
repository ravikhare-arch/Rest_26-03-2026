using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;


/// <summary>
/// Summary description for cls_tticketcapture
/// </summary>
public class cls_tticketcapture : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objCaptureID = string.Empty;
    private string objTicketNo = string.Empty;
    private string objPNRNo = string.Empty;
    private string objCRSType = string.Empty;
    private string objPCC = string.Empty;
    private string objIATANo = string.Empty;
    private string objInvoiceNo = string.Empty;
    private string objPassengerName = string.Empty;
    private string objPassengerType = string.Empty;
    private string objSectorfrom = string.Empty;
    private string objSectorTo = string.Empty;
    private string objFileName = string.Empty;
    private string objdtProcess = string.Empty;
    private string objProcessTime = string.Empty;
    private string objStaffSign = string.Empty;
    private string objdtissue = string.Empty;
    private string objCurrency = string.Empty;
    private string objBasicFare = string.Empty;
    private string objTotalTax = string.Empty;
    private string objGrandTotal = string.Empty;

    public string CaptureID
    {
        get { return objCaptureID; }
        set { objCaptureID = value; }
    }
    public string TicketNo
    {
        get { return objTicketNo; }
        set { objTicketNo = value; }
    }
    public string PNRNo
    {
        get { return objPNRNo; }
        set { objPNRNo = value; }
    }
    public string CRSType
    {
        get { return objCRSType; }
        set { objCRSType = value; }
    }
    public string PCC
    {
        get { return objPCC; }
        set { objPCC = value; }
    }
    public string IATANo
    {
        get { return objIATANo; }
        set { objIATANo = value; }
    }
    public string InvoiceNo
    {
        get { return objInvoiceNo; }
        set { objInvoiceNo = value; }
    }
    public string PassengerName
    {
        get { return objPassengerName; }
        set { objPassengerName = value; }
    }
    public string PassengerType
    {
        get { return objPassengerType; }
        set { objPassengerType = value; }
    }
    public string Sectorfrom
    {
        get { return objSectorfrom; }
        set { objSectorfrom = value; }
    }
    public string SectorTo
    {
        get { return objSectorTo; }
        set { objSectorTo = value; }
    }
    public string FileName
    {
        get { return objFileName; }
        set { objFileName = value; }
    }
    public string dtProcess
    {
        get { return objdtProcess; }
        set { objdtProcess = value; }
    }
    public string ProcessTime
    {
        get { return objProcessTime; }
        set { objProcessTime = value; }
    }
    public string StaffSign
    {
        get { return objStaffSign; }
        set { objStaffSign = value; }
    }
    public string dtissue
    {
        get { return objdtissue; }
        set { objdtissue = value; }
    }
    public string Currency
    {
        get { return objCurrency; }
        set { objCurrency = value; }
    }
    public string BasicFare
    {
        get { return objBasicFare; }
        set { objBasicFare = value; }
    }
    public string TotalTax
    {
        get { return objTotalTax; }
        set { objTotalTax = value; }
    }
    public string GrandTotal
    {
        get { return objGrandTotal; }
        set { objGrandTotal = value; }
    }

    public int CreatedBy { get; set; }
    public DateTime CretedOn { get; set; }

    public string TicketSatus { get; set; }
    public string ClientName { get; set; }
    public string InvoiceType { get; set; }
    public string LPONo { get; set; }
    public string CostCenter { get; set; }
    public string AirlineLetter { get; set; }
    public string AirlineName { get; set; }
    public string FlightNo { get; set; }
    public string AirNumeric { get; set; }
    public string AirPNRNo { get; set; }
    public string PAXMobile { get; set; }
    public string PAXEmail { get; set; }
    public string FlightClass { get; set; }
    public string dtTravel { get; set; }
    public string dtReturn { get; set; }
    public string BookingSign { get; set; }
    public string IATACom { get; set; }
    public string AIRPLB { get; set; }
    public string TourCode { get; set; }
    public string FareBasis { get; set; }
    public string TaxDetails { get; set; }
    public string Cancellation { get; set; }
    public string MF { get; set; }
    public string Billing { get; set; }
    public string JourneyType { get; set; }
    public string StartDate { get; set; }
    public string EndDate { get; set; }
    public string User_Operation(cls_tticketcapture cls_tticketcapture, string type)
    {
        SqlCommand cmd = addParameter(cls_tticketcapture, type, "");
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
    public SqlCommand addParameter(cls_tticketcapture cls_tticketcapture, string type, string cond)
    {



        conn = connobj.makeConnection();
        SqlCommand cmd = new SqlCommand("SP_tticketcapture", conn); cmd.Parameters.AddWithValue("@nCaptureId", cls_tticketcapture.CaptureID);
        cmd.Parameters.AddWithValue("@sTicketNo", cls_tticketcapture.TicketNo);
        cmd.Parameters.AddWithValue("@sPNRNo", cls_tticketcapture.PNRNo);
        cmd.Parameters.AddWithValue("@sCRSType", cls_tticketcapture.CRSType);
        cmd.Parameters.AddWithValue("@sPCC", cls_tticketcapture.PCC);
        cmd.Parameters.AddWithValue("@sIATANo", cls_tticketcapture.IATANo);
        cmd.Parameters.AddWithValue("@sInvoiceNo", cls_tticketcapture.InvoiceNo);

        cmd.Parameters.AddWithValue("@sPassengerName", cls_tticketcapture.PassengerName);
        cmd.Parameters.AddWithValue("@sPassengerType", cls_tticketcapture.PassengerType);
        cmd.Parameters.AddWithValue("@sSectorfrom", cls_tticketcapture.Sectorfrom);
        cmd.Parameters.AddWithValue("@sSectorTo", cls_tticketcapture.SectorTo);
        cmd.Parameters.AddWithValue("@sFileName", cls_tticketcapture.FileName);
        cmd.Parameters.AddWithValue("@dtProcess", cls_tticketcapture.dtProcess);
        cmd.Parameters.AddWithValue("@sProcessTime", cls_tticketcapture.ProcessTime);
        cmd.Parameters.AddWithValue("@sStaffSign", cls_tticketcapture.StaffSign);

        cmd.Parameters.AddWithValue("@dtissue", cls_tticketcapture.dtissue);
        cmd.Parameters.AddWithValue("@Currency", cls_tticketcapture.Currency);
        cmd.Parameters.AddWithValue("@nBasicFare", cls_tticketcapture.BasicFare);
        cmd.Parameters.AddWithValue("@nTotalTax", cls_tticketcapture.TotalTax);
        cmd.Parameters.AddWithValue("@nGrandTotal", cls_tticketcapture.GrandTotal);
        cmd.Parameters.AddWithValue("@AirNumeric", cls_tticketcapture.AirNumeric);
        cmd.Parameters.AddWithValue("@JourneyType", cls_tticketcapture.JourneyType);
        cmd.Parameters.AddWithValue("@StartDate", cls_tticketcapture.StartDate);
        cmd.Parameters.AddWithValue("@EndDate", cls_tticketcapture.EndDate);
        cmd.Parameters.AddWithValue("@nCreatedID", CreatedBy);
        cmd.Parameters.AddWithValue("@nModifiedID", CreatedBy);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }


    public void FillGrid(cls_tticketcapture cls_tticketcapture, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(cls_tticketcapture, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch (Exception ex)
        {
        }
    }
    public void FillReapter(cls_tticketcapture cls_tticketcapture, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(cls_tticketcapture, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(cls_tticketcapture cls_tticketcapture, string type, string cond)
    {
        SqlCommand cmd = addParameter(cls_tticketcapture, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewmagent");
            return ds.Tables["viewmagent"];
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
    public DataTable Tabledata(cls_tticketcapture cls_tticketcapture, string type, string cond)
    {
        DataTable da = new DataTable();
        try
        {
            da = viewData(cls_tticketcapture, type, cond);
        }
        catch
        {

        }
        return da;
    }
}
