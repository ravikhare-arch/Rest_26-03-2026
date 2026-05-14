using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.Services;


using System.Xml;
using ClosedXML.Excel;
using OfficeOpenXml;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Drawing;
using OfficeOpenXml.Style;
using System.Text;


using System.Threading;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
//using MailSMS;

using System.Configuration;

using System.Net.Mail;
using System.Net;

public partial class Auto_Capture_list : System.Web.UI.Page
{
    static cls_tticketcapture objClass = new cls_tticketcapture();
    public static string viewstate;
    validation valobj = new validation();
    string cond;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                // Fillddl.FillPageddl(ddlPageSize
                string aa = Server.UrlEncode(System.DateTime.Now.ToString());
                Session["Auto_Capture_list"] = aa;              
            }
        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, "FAIL", lblmsg);
        }
        finally
        {
        }
    }

    public void Page_PreRender(object sender, EventArgs e)
    {
        ViewState["Auto_Capture_list"] = Session["Auto_Capture_list"];
        viewstate = Session["Auto_Capture_list"].ToString();
    }

    [WebMethod]
    public static mpagemasterlist loaddata(string fromdate, string todate)
    {
        list magentobj = new list();
        mpagemasterlist mainlist = new mpagemasterlist();
        mainlist.mpagemasterobjlist = new List<list>();
        DataTable dt = new DataTable();
        try
        {
            objClass.StartDate = validation.dateToText(fromdate);
            objClass.EndDate = validation.dateToText(todate);
            dt = objClass.Tabledata(objClass, "ShowGrid", "");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                magentobj = new list();
                magentobj.JourneyType = dt.Rows[i]["sJourneyType"].ToString();
                magentobj.AirNumeric = dt.Rows[i]["sAirlineLetter"].ToString();
                magentobj.AirPNRNo = dt.Rows[i]["sAirPNRNo"].ToString();
                magentobj.PAXName = dt.Rows[i]["sPassengerName"].ToString();
                magentobj.PAXMobile = dt.Rows[i]["sPAXMob"].ToString();
                magentobj.PAXEmail = dt.Rows[i]["sPAXEmail"].ToString();
                magentobj.TravelDate = dt.Rows[i]["dttravel"].ToString();
                magentobj.ReturnDate = dt.Rows[i]["dtReturn"].ToString();
                magentobj.BookSign = dt.Rows[i]["sBookingSign"].ToString();
                
                magentobj.FareBasis = dt.Rows[i]["sFareBasis"].ToString();
                magentobj.Taxdetails = dt.Rows[i]["sTaxDetails"].ToString();
                magentobj.Cancellation = dt.Rows[i]["sCancellation"].ToString();
                magentobj.MF = dt.Rows[i]["sMF"].ToString();
                magentobj.Billing = dt.Rows[i]["sBilling"].ToString();
                magentobj.FileName = dt.Rows[i]["sFileName"].ToString();
                magentobj.ProcessDate = validation.TextToDate(dt.Rows[i]["dtProcess"].ToString());
                magentobj.ProcessTime = dt.Rows[i]["sProcessTime"].ToString();
                magentobj.StaffSign = dt.Rows[i]["sStaffSign"].ToString();
                magentobj.IssueDate = validation.TextToDate( dt.Rows[i]["dtIssue"].ToString());
                magentobj.Currency = dt.Rows[i]["sCurrency"].ToString();
                magentobj.BasicFare = dt.Rows[i]["nBasicFare"].ToString();
                magentobj.TotalTax = dt.Rows[i]["nTotalTax"].ToString();
                magentobj.GrandTotal = dt.Rows[i]["nGrandTotal"].ToString();

                magentobj.IATAComm = dt.Rows[i]["sIATACom"].ToString();
                magentobj.TicketNo = dt.Rows[i]["sTicketNo"].ToString();
                magentobj.IATANo = dt.Rows[i]["sIATANo"].ToString();
                
                magentobj.CRS = dt.Rows[i]["sCRSType"].ToString();
                magentobj.PCC = dt.Rows[i]["sPCC"].ToString();
                magentobj.PAXType = dt.Rows[i]["sPassengerType"].ToString();
                magentobj.SectorFrom = dt.Rows[i]["sSectorfrom"].ToString();
                magentobj.SectorTO = dt.Rows[i]["sSectorTo"].ToString();
                magentobj.PNRNo = dt.Rows[i]["sPNRNo"].ToString();
                mainlist.mpagemasterobjlist.Add(magentobj);
//                sTicketNo,sPNRNo,sCRSType,sPCC,sIATANo,sInvoiceNo,sPassengerName,sPassengerType,sSectorfrom,sSectorTo,sFileName,dtProcess,sProcessTime,sStaffSign,dtIssue,sCurrency,
                //nBasicFare,nTotalTax,nGrandTotal,sTicketStatus,sClientName,sInvoiceType,

//sLPONo,sCostCenter,sAirlineLetter,sAirlineName,sFlightNo,sAirNumeric,sAirPNRNo,sPAXMob,sPAXEmail,
                
                //sFlightClass,dttravel,dtReturn,sBookingSign,sIATACom,sAIRPLB,sTourCode,sFareBasis,sTaxDetails,sCancellation,sMF,sBilling,sJourneyType
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return mainlist;
    }
     protected void btnexcel_Click(object sender, EventArgs e)
    {
    
    }
    public string date(string getdt)
    {
        string month, date, year;
        string returnval = string.Empty;
        if (getdt != "")
        {
            string dt = getdt;
            year = dt.Substring(0, 4);
            month = dt.Substring(4, 2);
            date = dt.Substring(6, 2);
            returnval = date + '-' + month + '-' + year;
            return returnval;
        }
        return returnval;
    }

    protected void btnpdf_Click(object sender, EventArgs e)
    {
            }
    protected void btnsendmail_Click(object sender, EventArgs e)
    {
       
    }
    
    public class list
    {
        public string JourneyType { get; set; }
        public string AirNumeric { get; set; }
        public string AirPNRNo { get; set; }
        public string PAXMobile { get; set; }
        public string PAXEmail { get; set; }
        public string TravelDate { get; set; }
        public string ReturnDate { get; set; }
        public string BookSign { get; set; }
        public string IATAComm { get; set; }
        public string FareBasis { get; set; }
        public string Taxdetails { get; set; }
        public string Cancellation { get; set; }
        public string MF { get; set; }
        public string Billing { get; set; }
        public string TourCode { get; set; }
        public string PNRNo { get; set; }
        public string TicketNo { get; set; }
        public string IATANo { get; set; }
        public string PAXName { get; set; }
        public string CRS { get; set; }
        public string PCC { get; set; }
        public string PAXType { get; set; }
        public string SectorFrom { get; set; }
        public string SectorTO { get; set; }
        public string FileName { get; set; }
        public string ProcessDate { get; set; }
        public string ProcessTime { get; set; }
        public string StaffSign { get; set; }
        public string IssueDate { get; set; }
        public string Currency { get; set; }
        public string BasicFare { get; set; }
        public string TotalTax { get; set; }
        public string GrandTotal { get; set; }
    }

    public class mpagemasterlist
    {
        public List<list> mpagemasterobjlist { get; set; }
    }
    protected void btnexcel_Click1(object sender, EventArgs e)
    {
        cls_tticketcapture objClass = new cls_tticketcapture();
        try
        {
          
            list magentobj = new list();
            mpagemasterlist mainlist = new mpagemasterlist();
            mainlist.mpagemasterobjlist = new List<list>();
            DataTable getdtdata = new DataTable();
            //if (txtfromdate.Text != "" && txttodate.Text!="")
            //{
            //    objClass.dtProcess = validation.dateToText(txtfromdate.Text.Trim()).ToString();
            //    objClass.dtissue = validation.dateToText(txttodate.Text.Trim()).ToString();
            //    getdtdata = objClass.Tabledata(objClass, "ShowGridwithdate", "");
            //}
            //else{


            //}
            //objClass.StartDate = validation.dateToText(txtfromdate.Text);
            //objClass.EndDate = validation.dateToText(txttodate.Text);
            getdtdata = objClass.Tabledata(objClass, "ShowGrid", "");
            var fileName = "Auto Capture-List-" + DateTime.Now.ToString("yyyy-MM-dd--hh-mm-ss") + ".xlsx";
            var outputDir = Server.MapPath("/Temp/123.xlsx");

            ///// // Create the file using the FileInfo object
            var file = new FileInfo(outputDir + fileName);

            ///// // Create the package and make sure you wrap it in a using statement
            using (var package = new ExcelPackage(file))
            {
                /////  // add a new worksheet to the empty workbook
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Auto Capture statement - " + DateTime.Now.ToShortDateString());

                // // clumn width adjustments code
                worksheet.View.FreezePanes(7, 1); //leave header and scrool all rows up and down
                worksheet.Column(1).Width = 10;
                #region
                worksheet.Column(2).Width = 15;
                worksheet.Column(3).Width = 15;
                worksheet.Column(4).Width = 30;
                worksheet.Column(5).Width = 10;
                worksheet.Column(6).Width = 19;
                worksheet.Column(7).Width = 25;
                worksheet.Column(8).Width = 15;
                worksheet.Column(9).Width = 15;
                worksheet.Column(11).Width = 15;
                worksheet.Column(12).Width = 15;
                worksheet.Column(24).Width = 25;
                #endregion
                #region set center the row data start
                worksheet.Column(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Column(2).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Column(3).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Column(4).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Column(5).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Column(6).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Column(7).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Column(8).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Column(9).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Column(10).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Column(11).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Column(12).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Column(13).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Column(14).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Column(15).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Column(16).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Column(17).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Column(18).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Column(19).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Column(20).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Column(21).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Column(22).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Column(23).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Column(24).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                #endregion
                ///// //Merging cells and create a center heading for out table
                worksheet.Cells[1, 1].Value = "Space Erp"; // Heading Name
                worksheet.Cells[1, 1].Style.Font.Size = 20;
                worksheet.Cells[3, 1].Style.Font.Size = 15;
                worksheet.Cells[5, 1, 5, 3].Style.Font.Size = 13;

                ///// // MergeCell for gap rows and 15 is number of colums
                //  worksheet.Cells[2, 1, 2, getdtdata.Columns.Count].Merge = true; //Merge columns start and end range
                worksheet.Cells[2, 1, 2, 35].Merge = true;
                worksheet.Cells[4, 1, 4, 35].Merge = true; //Merge columns start and end range

                //////// // ExcelWorksheet.cells[from row, from column, to row, to column].
                // worksheet.Cells[1, 1, 1, getdtdata.Columns.Count].Merge = true; //Merge columns start and end range
                worksheet.Cells[1, 1, 1, 35].Merge = true; //Merge columns start and end range
                worksheet.Cells[1, 1, 1, 35].Style.Font.Bold = true; //Font should be bold
                worksheet.Cells[1, 1, 1, 35].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center; // Aligmnet is center
                worksheet.Cells[1, 1].Style.Font.Color.SetColor(System.Drawing.Color.WhiteSmoke);
                // // //im giving 15 for range the columns for header
                ///////  //Merging cells and create a center heading for out table
              //  worksheet.Cells[3, 1].Value = "	Statement  Deatails From : '" + txtBookingDate.Text + "' To: '" + txttobookingdate.Text + "' "; // Heading Name               
                worksheet.Cells[3, 1].Value = "	Statement  Deatails From : From Date   To: To Date "; // Heading Name               
             
                worksheet.Cells[3, 1, 3, 35].Merge = true; //Merge columns start and end range
                worksheet.Cells[3, 1, 3, 35].Style.Font.Bold = true; //Font should be bold
                worksheet.Cells[3, 1, 3, 35].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center; // Aligmnet is center
                worksheet.Cells[3, 1].Style.Font.Color.SetColor(System.Drawing.Color.WhiteSmoke);


                // // // // merging cells and hading 


                ///////  //Merging cells and create a center heading for out table
                worksheet.Cells[4, 1].Value = "	Statement Name : Auto Capture Statament "; // Heading Name               
                worksheet.Cells[4, 1, 4, 35].Merge = true; //Merge columns start and end range
                worksheet.Cells[4, 1, 4, 35].Style.Font.Bold = true; //Font should be bold
                worksheet.Cells[4, 1, 4, 35].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center; // Aligmnet is center
                worksheet.Cells[4, 1].Style.Font.Color.SetColor(System.Drawing.Color.WhiteSmoke);

                // // // agent name header
                ///////  //Merging cells and create a center heading for out table
                worksheet.Cells[5, 1].Value = "	Agency Name : Space Erp "; // Heading Name               
                worksheet.Cells[5, 1, 5, 35].Merge = true; //Merge columns start and end range
                worksheet.Cells[5, 1, 5, 35].Style.Font.Bold = true; //Font should be bold
                worksheet.Cells[5, 1, 5, 35].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center; // Aligmnet is center
                worksheet.Cells[5, 1].Style.Font.Color.SetColor(System.Drawing.Color.WhiteSmoke);


                //////  //Setting the background color of header cells to Gray
                var fill = worksheet.Cells[1, 1].Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(System.Drawing.Color.Silver);

                var fill1 = worksheet.Cells[3, 1].Style.Fill;
                fill1.PatternType = ExcelFillStyle.Solid;
                fill1.BackgroundColor.SetColor(System.Drawing.Color.LightSeaGreen);


                var fill2 = worksheet.Cells[4, 1].Style.Fill;
                fill2.PatternType = ExcelFillStyle.Solid;
                fill2.BackgroundColor.SetColor(System.Drawing.Color.LightSeaGreen);


                var fill3 = worksheet.Cells[5, 1].Style.Fill;
                fill3.PatternType = ExcelFillStyle.Solid;
                fill3.BackgroundColor.SetColor(System.Drawing.Color.LightSeaGreen);

                ////////////// //Ok now format the first row of the heade, but only the first two columns;
                using (var range = worksheet.Cells[6, 1, 6, 35])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Blue);
                    range.Style.Font.Color.SetColor(System.Drawing.Color.WhiteSmoke);

                    range.Style.ShrinkToFit = false;
                }

                for (int i = 0; i < getdtdata.Columns.Count; i++)
                {
                    worksheet.Cells[6, 1].Value = "Sr No";
                    worksheet.Cells[6, 2].Value = "Journey Type";
                    worksheet.Cells[6, 3].Value = "Air Numeric";
                    worksheet.Cells[6, 4].Value = " Air PNR";
                    worksheet.Cells[6, 5].Value = "Passenger Name";
                    worksheet.Cells[6, 6].Value = "Pax mob";
                    worksheet.Cells[6, 7].Value = "Pax Email";
                    worksheet.Cells[6, 8].Value = "Travel Date";
                    worksheet.Cells[6, 9].Value = "Return Date";
                    worksheet.Cells[6, 10].Value = "Booking Sign";
                    worksheet.Cells[6, 11].Value = "IATA Comm";
                    worksheet.Cells[6, 12].Value = "Air PLB";
                    worksheet.Cells[6, 13].Value = "Fair Basics";
                    worksheet.Cells[6, 14].Value = "Tax Details";
                    worksheet.Cells[6, 15].Value = "Cancellation";
                    worksheet.Cells[6, 16].Value = "Tour Code";
                    worksheet.Cells[6, 17].Value = "Ticket Number";
                    worksheet.Cells[6, 18].Value = "PNR NO";
                    worksheet.Cells[6, 19].Value = "CRS";
                    worksheet.Cells[6, 20].Value = "PCC";
                    worksheet.Cells[6, 21].Value = "IATA NO";
                    worksheet.Cells[6, 22].Value = "PAX Type";
                    worksheet.Cells[6, 23].Value = "Sector From";
                    worksheet.Cells[6, 24].Value = "Sector To";
                    worksheet.Cells[6, 25].Value = "File Name";
                    worksheet.Cells[6, 26].Value = "Process Date";
                    worksheet.Cells[6, 27].Value = "Process Time";
                    worksheet.Cells[6, 28].Value = "Staff Sign";
                    worksheet.Cells[6, 29].Value = "Issue Date";
                    worksheet.Cells[6, 30].Value = "Currency";
                    worksheet.Cells[6, 31].Value = "Basic Fare";
                    worksheet.Cells[6, 32].Value = "Total Tax";
                    worksheet.Cells[6, 33].Value = "Grand Total";
                    worksheet.Cells[6, 34].Value = "MF";
                    worksheet.Cells[6, 35].Value = "Billing";
                    

                }


                int count = 1;
                for (int i = 0; i < getdtdata.Rows.Count; i++)
                {
                    worksheet.Cells["A" + (i + 7)].Value = count;
                    worksheet.Cells["B" + (i + 7)].Value = getdtdata.Rows[i]["sJourneyType"].ToString();
                    worksheet.Cells["C" + (i + 7)].Value = getdtdata.Rows[i]["sAirlineLetter"].ToString();
                    worksheet.Cells["D" + (i + 7)].Value = getdtdata.Rows[i]["sAirPNRNo"].ToString();
                    worksheet.Cells["E" + (i + 7)].Value = getdtdata.Rows[i]["sPassengerName"].ToString();
                    worksheet.Cells["F" + (i + 7)].Value = getdtdata.Rows[i]["sPAXMob"].ToString();
                    worksheet.Cells["G" + (i + 7)].Value = getdtdata.Rows[i]["sPAXEmail"].ToString();
                    worksheet.Cells["H" + (i + 7)].Value = getdtdata.Rows[i]["dttravel"].ToString();
                    worksheet.Cells["I" + (i + 7)].Value = getdtdata.Rows[i]["dtReturn"].ToString();
                    worksheet.Cells["J" + (i + 7)].Value = getdtdata.Rows[i]["sBookingSign"].ToString();
                    worksheet.Cells["K" + (i + 7)].Value = getdtdata.Rows[i]["sIATACom"].ToString();
                    worksheet.Cells["L" + (i + 7)].Value = "";
                    worksheet.Cells["M" + (i + 7)].Value = getdtdata.Rows[i]["sFareBasis"].ToString();
                    worksheet.Cells["N" + (i + 7)].Value = "";
                    worksheet.Cells["O" + (i + 7)].Value = getdtdata.Rows[i]["sCancellation"].ToString();
                    worksheet.Cells["P" + (i + 7)].Value = getdtdata.Rows[i]["sTourCode"].ToString();
                    worksheet.Cells["Q" + (i + 7)].Value = getdtdata.Rows[i]["sTicketNo"].ToString();
                    worksheet.Cells["R" + (i + 7)].Value = getdtdata.Rows[i]["sPNRNo"].ToString();
                    worksheet.Cells["S" + (i + 7)].Value = getdtdata.Rows[i]["sCRSType"].ToString();
                    worksheet.Cells["T" + (i + 7)].Value = getdtdata.Rows[i]["sPCC"].ToString();
                    worksheet.Cells["U" + (i + 7)].Value = getdtdata.Rows[i]["sIATANo"].ToString();
                    worksheet.Cells["V" + (i + 7)].Value = getdtdata.Rows[i]["sPassengerType"].ToString();
                    worksheet.Cells["W" + (i + 7)].Value = getdtdata.Rows[i]["sSectorfrom"].ToString();
                    worksheet.Cells["X" + (i + 7)].Value = getdtdata.Rows[i]["sSectorTo"].ToString();
                    worksheet.Cells["Y" + (i + 7)].Value = getdtdata.Rows[i]["sFileName"].ToString();
                    worksheet.Cells["Z" + (i + 7)].Value = validation.TextToDate(getdtdata.Rows[i]["dtProcess"].ToString());
                    worksheet.Cells["AA" + (i + 7)].Value = getdtdata.Rows[i]["sProcessTime"].ToString();
                    worksheet.Cells["AB" + (i + 7)].Value = getdtdata.Rows[i]["sStaffSign"].ToString();
                    worksheet.Cells["AC" + (i + 7)].Value = validation.TextToDate(getdtdata.Rows[i]["dtProcess"].ToString());
                    worksheet.Cells["AD" + (i + 7)].Value = getdtdata.Rows[i]["sCurrency"].ToString();
                    worksheet.Cells["AE" + (i + 7)].Value = getdtdata.Rows[i]["nBasicFare"].ToString();
                    worksheet.Cells["AF" + (i + 7)].Value = getdtdata.Rows[i]["nTotalTax"].ToString();
                    worksheet.Cells["AG" + (i + 7)].Value = getdtdata.Rows[i]["nGrandTotal"].ToString();
                    worksheet.Cells["AH" + (i + 7)].Value = getdtdata.Rows[i]["sMF"].ToString();
                    worksheet.Cells["AI" + (i + 7)].Value = getdtdata.Rows[i]["sBilling"].ToString();
                    count++;
                }

                package.Save();
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename=Flightlist.xlsx");
                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    package.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }

            }
        }
        catch (Exception ex)
        {
            string msg = ex.Message.ToString();
        }
        finally
        {

        }

    }

    public string converttext(string getdate)
    {
        string month, date, year;
        string returnval = string.Empty;
        if (getdate != "")
        {
            var dt = getdate.Split('/');
            year = dt[2];
            month = dt[0];
            date = dt[1];
            returnval = date + '-' + month + '-' + year;
            return returnval;
        }
        return returnval;
    }
}
