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

public partial class tvisa_list : System.Web.UI.Page
{
    static tvisa_Class objClass = new tvisa_Class();
    mmain_account_Class ObjAcc = new mmain_account_Class();
    validation valobj = new validation();
    string cond;
    public static string viewstate;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                objClass.ddlOperation(objClass, "ddlCustomer", "", ddlAgentID);


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
    
   
    [WebMethod]
    public static mpagemasterlist loaddata(string fromdate, string todate,string Reportfor, string AgentID)
    {
        list magentobj = new list();
        list magentobjnew = new list();
        mpagemasterlist mainlist = new mpagemasterlist();
        mainlist.mpagemasterobjlist = new List<list>();
        mainlist.mpagemasterobjlistnew  = new List<list>();
        DataTable dt = new DataTable();
        DataTable dtnew = new DataTable();
        try
        {
            if (Reportfor!="0" && Reportfor != "")
            {
                if (Reportfor == "7")
                {
                    objClass.nVisaCompanyID = AgentID;
                    objClass.nAgentID = "0";
                }
                else if (Reportfor == "3")
                {
                    objClass.nAgentID = AgentID;
                    objClass.nVisaCompanyID = "0";
                }
            }
            else
            {
                objClass.nVisaCompanyID = "0";
                objClass.nAgentID = "0";
            }
            objClass.StartDate = validation.dateToText(fromdate);
            objClass.EndDate = validation.dateToText(todate);
            dt = objClass.Tabledata(objClass, "ShowGrid", "");
            
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                magentobj = new list();
                magentobj.InvoiceNo = dt.Rows[i]["sVisaBookingNo"].ToString();
                magentobj.InvoiceDate = validation.TextToDate(dt.Rows[i]["dtBooking"].ToString());
                magentobj.AgentName = dt.Rows[i]["sVisaSellCompany"].ToString();
                magentobj.Supplier = dt.Rows[i]["sVisaBuyCompany"].ToString();
                magentobj.BranchName = dt.Rows[i]["sBranchName"].ToString();
                magentobj.BuyingCost = dt.Rows[i]["nBuyingRate"].ToString();
                magentobj.SellingCost = dt.Rows[i]["nSellingRate"].ToString();
                magentobj.PaidAmount = dt.Rows[i]["nPaidAmount"].ToString();
                magentobj.Balance = dt.Rows[i]["nBalance"].ToString();
                magentobj.PaidStatus = dt.Rows[i]["sPaid"].ToString();
                magentobj.TicketID = dt.Rows[i]["nVisaId"].ToString();
                mainlist.mpagemasterobjlist.Add(magentobj);
            }            
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return mainlist;
    }
    protected void ddlStReportFor_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlStReportFor.SelectedValue != "0")
        {
            ObjAcc.ddlOperation(ObjAcc, "ddlAccType", ddlStReportFor.SelectedValue, ddlAgentID);
        }
        else
        {
            ObjAcc.ddlOperation(ObjAcc, "ShowddlAccount", "", ddlAgentID);
        }
    }
    protected void btnexcel_Click(object sender, EventArgs e)
    {

        /// DataTable dt2 = objClass.pdftable(objClass, "getagentname", ddlAgent.SelectedValue);
        string AgentName = "";
        #region get data

        DataTable getdtdata = new DataTable();
        objClass.StartDate = validation.dateToText(txttLastPurchase.Text);
        objClass.EndDate = validation.dateToText(txttLastOrder.Text);
        getdtdata = objClass.Tabledata(objClass, "ShowGrid", "");

        // // // below table for excel table

        getdtdata.Columns.Remove("nVisaID");
        getdtdata.Columns.Remove("nAgentID");
        getdtdata.Columns.Remove("nVisaCompanyID");
        //DataRow dr = getdtdata.NewRow();
        //dr["description"] = "Total";
        //dr["nCreditAmount"] = Convert.ToDouble(strcreditbalance.ToString());
        //dr["nDebitAmount"] = Convert.ToDouble(strdebitbalance.ToString());
        //dr["nBalance"] = Convert.ToDouble(strbalance.ToString());
        //getdtdata.Rows.Add(dr);


        #endregion


        try
        {


            #region start code
            var fileName = "Visa-" + DateTime.Now.ToString("yyyy-MM-dd--hh-mm-ss") + ".xlsx";
            var outputDir = Server.MapPath("../Temp/Visa.xlsx");

            ///// // Create the file using the FileInfo object
            var file = new FileInfo(outputDir + fileName);

            ///// // Create the package and make sure you wrap it in a using statement
            using (var package = new ExcelPackage(file))
            {
                /////  // add a new worksheet to the empty workbook
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Visa - " + DateTime.Now.ToShortDateString());

                // // clumn width adjustments code
                worksheet.View.FreezePanes(7, 1); //leave header and scrool all rows up and down
                worksheet.Column(1).Width = 5;
                #region

                #region
                worksheet.Column(2).Width = 15;
                worksheet.Column(3).Width = 15;
                worksheet.Column(4).Width = 40;
                worksheet.Column(5).Width = 40;
                worksheet.Column(6).Width = 40;
                worksheet.Column(7).Width = 15;
                worksheet.Column(8).Width = 20;
                worksheet.Column(9).Width = 15;
                worksheet.Column(10).Width = 15;
                worksheet.Column(11).Width = 15;

                #endregion
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
                #endregion
                ///// //Merging cells and create a center heading for out table
                worksheet.Cells[1, 1].Value = "ALNASA"; // Heading Name
                worksheet.Cells[1, 1].Style.Font.Size = 20;
                worksheet.Cells[3, 1].Style.Font.Size = 15;
                worksheet.Cells[5, 1, 5, 3].Style.Font.Size = 13;

                ///// // MergeCell for gap rows and 15 is number of colums
                //  worksheet.Cells[2, 1, 2, getdtdata.Columns.Count].Merge = true; //Merge columns start and end range
                worksheet.Cells[2, 1, 2, 11].Merge = true;
                worksheet.Cells[4, 1, 4, 11].Merge = true; //Merge columns start and end range

                //////// // ExcelWorksheet.cells[from row, from column, to row, to column].
                // worksheet.Cells[1, 1, 1, getdtdata.Columns.Count].Merge = true; //Merge columns start and end range
                worksheet.Cells[1, 1, 1, 11].Merge = true; //Merge columns start and end range
                worksheet.Cells[1, 1, 1, 11].Style.Font.Bold = true; //Font should be bold
                worksheet.Cells[1, 1, 1, 11].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center; // Aligmnet is center
                worksheet.Cells[1, 1].Style.Font.Color.SetColor(System.Drawing.Color.WhiteSmoke);
                // // //im giving 15 for range the columns for header
                ///////  //Merging cells and create a center heading for out table
                worksheet.Cells[3, 1].Value = "	Statement  Details From : '" + txttLastPurchase.Text + "' To: '" + txttLastOrder.Text + "' "; // Heading Name               
                worksheet.Cells[3, 1, 3, 11].Merge = true; //Merge columns start and end range
                worksheet.Cells[3, 1, 3, 11].Style.Font.Bold = true; //Font should be bold
                worksheet.Cells[3, 1, 3, 11].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center; // Aligmnet is center
                worksheet.Cells[3, 1].Style.Font.Color.SetColor(System.Drawing.Color.WhiteSmoke);


                // // // // merging cells and hading 


                ///////  //Merging cells and create a center heading for out table
                worksheet.Cells[4, 1].Value = "	Statement Name : Visa "; // Heading Name               
                worksheet.Cells[4, 1, 4, 11].Merge = true; //Merge columns start and end range
                worksheet.Cells[4, 1, 4, 11].Style.Font.Bold = true; //Font should be bold
                worksheet.Cells[4, 1, 4, 11].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center; // Aligmnet is center
                worksheet.Cells[4, 1].Style.Font.Color.SetColor(System.Drawing.Color.WhiteSmoke);

                // // // agent name header
                ///////  //Merging cells and create a center heading for out table
                worksheet.Cells[5, 1].Value = "	Agency Name : '" + AgentName + "' "; // Heading Name               
                worksheet.Cells[5, 1, 5, 11].Merge = true; //Merge columns start and end range
                worksheet.Cells[5, 1, 5, 11].Style.Font.Bold = true; //Font should be bold
                worksheet.Cells[5, 1, 5, 11].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center; // Aligmnet is center
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
                using (var range = worksheet.Cells[6, 1, 6, 11])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Blue);
                    range.Style.Font.Color.SetColor(System.Drawing.Color.WhiteSmoke);

                    range.Style.ShrinkToFit = false;
                }
                #region
                for (int i = 0; i < getdtdata.Columns.Count; i++)
                {
                    worksheet.Cells[6, 1].Value = "Sr No";
                    worksheet.Cells[6, 2].Value = "Invoice No";
                    worksheet.Cells[6, 3].Value = "Invoice Date";
                    worksheet.Cells[6, 4].Value = "Agent Name";
                    worksheet.Cells[6, 5].Value = "Supplier Name";
                    worksheet.Cells[6, 6].Value = "Branch Name";
                    worksheet.Cells[6, 7].Value = "Buying Cost";
                    worksheet.Cells[6, 8].Value = "Selling Cost";
                    worksheet.Cells[6, 9].Value = "Paid Amount";
                    worksheet.Cells[6, 10].Value = "Balance";
                    worksheet.Cells[6, 11].Value = "Paid Status";

                }
                #endregion
                #region
                int count = 1;
                for (int i = 0; i < getdtdata.Rows.Count; i++)
                {
                    worksheet.Cells["A" + (i + 7)].Value = count;
                    worksheet.Cells["B" + (i + 7)].Value = getdtdata.Rows[i]["sVisaBookingNo"].ToString();
                    worksheet.Cells["C" + (i + 7)].Value = date(getdtdata.Rows[i]["dtBooking"].ToString());
                    worksheet.Cells["D" + (i + 7)].Value = getdtdata.Rows[i]["sVisaSellCompany"].ToString();
                    worksheet.Cells["E" + (i + 7)].Value = getdtdata.Rows[i]["sVisaBuyCompany"].ToString();
                    worksheet.Cells["F" + (i + 7)].Value = getdtdata.Rows[i]["sBranchName"].ToString();
                    worksheet.Cells["G" + (i + 7)].Value = Convert.ToDouble(getdtdata.Rows[i]["nBuyingRate"].ToString());
                    worksheet.Cells["H" + (i + 7)].Value = Convert.ToDouble(getdtdata.Rows[i]["nSellingRate"].ToString());
                    worksheet.Cells["I" + (i + 7)].Value = Convert.ToDouble(getdtdata.Rows[i]["nPaidAmount"].ToString());
                    worksheet.Cells["J" + (i + 7)].Value = Convert.ToDouble(getdtdata.Rows[i]["nBalance"].ToString());
                    worksheet.Cells["K" + (i + 7)].Value = getdtdata.Rows[i]["sPaid"].ToString();
                    count++;
                }
                #endregion


                package.Save();
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename=Visa.xlsx");
                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    package.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }

            }
            #endregion


        }
        catch (Exception ex)
        {
            string msg = ex.Message.ToString();
        }
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
        public string TicketID { get; set; }
        public string TicketDetID { get; set; }
        public string InvoiceNo { get; set; }
        public string InvoiceDate { get; set; }
        public string AgentName { get; set; }
        public string Supplier { get; set; }
        public string BranchName { get; set; }
        public string BuyingCost { get; set; }
        public string SellingCost { get; set; }
        public string Amendedby { get; set; }
        public string PaidAmount { get; set; }
        public string PaidStatus { get; set; }
        public string Balance { get; set; }

        

        public string TicketTypeID { get; set; }
        public string AgentID { get; set; }
        public string LocationID { get; set; }
        public string TicketingCompanyID { get; set; }
        public string SupplierID { get; set; }
        public string bPaid { get; set; }
        public string AutoInvoice  { get; set; }

        public string CustomerName { get; set; }
        public string Sector { get; set; }
        public string TicketPNR { get; set; }
        public string CarrierID { get; set; }
       
        public string BookingTypeID { get; set; }
        public string BasicFare  { get; set; }

        public string ProfitType { get; set; }
        public string ProfitPercent { get; set; }
        public string ProfitAmount { get; set; }
        public string Discount { get; set; }
        public string Remarks { get; set; }
        public string SupScType { get; set; }
        public string SupScpercent  { get; set; }
        public string SupSCAmount { get; set; }
      
       
        public string bSupTax { get; set; }
        public string SupCGst { get; set; }
        public string SupSGst { get; set; }
        public string SupIGst { get; set; }
        public string bClntTax { get; set; }
        public string ClntCGst { get; set; }
        public string ClntSGst  { get; set; }
        public string ClntIGst { get; set; }

        public string bAirTax { get; set; }
        public string AirComm { get; set; }
        public string Airplb { get; set; }
        public string YqTax { get; set; }
        public string YrTax  { get; set; }
        public string OtherTax  { get; set; }

        public string SupTdsType { get; set; }
        public string SupTdsPercent { get; set; }
        public string SupTdsAmount { get; set; }
        public string ClntTdsType  { get; set; }

        public string ClntTdsPercent { get; set; }
        public string ClntTdsAmount { get; set; }
        public string K3Tax { get; set; }
        public string AirlinePnr  { get; set; }
        public string ClientSc2Percent  { get; set; }
       
        public string ClientSC2Amount { get; set; }
        public string nClientSC2Amount { get; set; }

        public string ClntOtherChrgs { get; set; }
        public string ClntBasicFare { get; set; }
        public string ClntYQTax  { get; set; }
        public string ClntYRTax  { get; set; }
        public string ClntK3Tax  { get; set; }

        public string ClntAirCom { get; set; }
        public string ClntAirPlb { get; set; }
        public string ClntOtherTax  { get; set; }
        public string FlightNo  { get; set; }
        public string TktBookFrom  { get; set; }

        public string clntTktFare { get; set; }
        public string SupTktFare { get; set; }
        public string SupDiscount  { get; set; }
        public string PaxType  { get; set; }
        public string LPONo  { get; set; }
        public string PCC { get; set; }
        public string AirlineCodeID { get; set; }
        public string GalPNRNo  { get; set; }
        public string IATANo  { get; set; }
        public string PAXMob   { get; set; }
       
        public string PAXEmail { get; set; }
        public string TripLength { get; set; }
        public string NoofSegment  { get; set; }
        public string TravelDate  { get; set; }
        public string ReturnDate  { get; set; }
        public string BookSign { get; set; }
        public string StaffSign { get; set; }
        public string TourCode  { get; set; }
        public string FareBasis  { get; set; }
        public string TaxDetails   { get; set; }

        public string Cancellation { get; set; }
        public string Resissue { get; set; }
        public string Amex  { get; set; }
        public string Empno  { get; set; }
        public string FileName  { get; set; }
        public string ProcessTime { get; set; }
        public string dtProcess { get; set; }
        public string Designator  { get; set; }

        public string Cost { get; set; }
        public string Total { get; set; }
        public string BookType { get; set; }
               
    }

    public class mpagemasterlist
    {
        public List<list> mpagemasterobjlist { get; set; }
        public List<list> mpagemasterobjlistnew { get; set; }
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
                
            //getdtdata = objClass.Tabledata(objClass, "ShowGrid", "");
            //}

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
                worksheet.Cells[2, 1, 2, 24].Merge = true;
                worksheet.Cells[4, 1, 4, 24].Merge = true; //Merge columns start and end range

                //////// // ExcelWorksheet.cells[from row, from column, to row, to column].
                // worksheet.Cells[1, 1, 1, getdtdata.Columns.Count].Merge = true; //Merge columns start and end range
                worksheet.Cells[1, 1, 1, 24].Merge = true; //Merge columns start and end range
                worksheet.Cells[1, 1, 1, 24].Style.Font.Bold = true; //Font should be bold
                worksheet.Cells[1, 1, 1, 24].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center; // Aligmnet is center
                worksheet.Cells[1, 1].Style.Font.Color.SetColor(System.Drawing.Color.WhiteSmoke);
                // // //im giving 15 for range the columns for header
                ///////  //Merging cells and create a center heading for out table
              //  worksheet.Cells[3, 1].Value = "	Statement  Deatails From : '" + txtBookingDate.Text + "' To: '" + txttobookingdate.Text + "' "; // Heading Name               
                worksheet.Cells[3, 1].Value = "	Statement  Deatails From : From Date   To: To Date "; // Heading Name               
             
                worksheet.Cells[3, 1, 3, 24].Merge = true; //Merge columns start and end range
                worksheet.Cells[3, 1, 3, 24].Style.Font.Bold = true; //Font should be bold
                worksheet.Cells[3, 1, 3, 24].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center; // Aligmnet is center
                worksheet.Cells[3, 1].Style.Font.Color.SetColor(System.Drawing.Color.WhiteSmoke);


                // // // // merging cells and hading 


                ///////  //Merging cells and create a center heading for out table
                worksheet.Cells[4, 1].Value = "	Statement Name : Auto Capture Statament "; // Heading Name               
                worksheet.Cells[4, 1, 4, 24].Merge = true; //Merge columns start and end range
                worksheet.Cells[4, 1, 4, 24].Style.Font.Bold = true; //Font should be bold
                worksheet.Cells[4, 1, 4, 24].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center; // Aligmnet is center
                worksheet.Cells[4, 1].Style.Font.Color.SetColor(System.Drawing.Color.WhiteSmoke);

                // // // agent name header
                ///////  //Merging cells and create a center heading for out table
                worksheet.Cells[5, 1].Value = "	Agency Name : Space Erp "; // Heading Name               
                worksheet.Cells[5, 1, 5, 24].Merge = true; //Merge columns start and end range
                worksheet.Cells[5, 1, 5, 24].Style.Font.Bold = true; //Font should be bold
                worksheet.Cells[5, 1, 5, 24].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center; // Aligmnet is center
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
                using (var range = worksheet.Cells[6, 1, 6, 24])
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
                    worksheet.Cells["L" + (i + 7)].Value = getdtdata.Rows[i]["sFareBasis"].ToString();
                    worksheet.Cells["M" + (i + 7)].Value = getdtdata.Rows[i]["sCancellation"].ToString();
                    worksheet.Cells["N" + (i + 7)].Value = getdtdata.Rows[i]["sTourCode"].ToString();
                    worksheet.Cells["O" + (i + 7)].Value = getdtdata.Rows[i]["sTicketNo"].ToString();
                    worksheet.Cells["P" + (i + 7)].Value = getdtdata.Rows[i]["sPNRNo"].ToString();
                    worksheet.Cells["Q" + (i + 7)].Value = getdtdata.Rows[i]["sIATANo"].ToString();
                    worksheet.Cells["R" + (i + 7)].Value = getdtdata.Rows[i]["sCRSType"].ToString();
                    worksheet.Cells["S" + (i + 7)].Value = getdtdata.Rows[i]["sPCC"].ToString();
                    worksheet.Cells["T" + (i + 7)].Value = getdtdata.Rows[i]["sPassengerType"].ToString();
                    worksheet.Cells["U" + (i + 7)].Value = getdtdata.Rows[i]["sSectorfrom"].ToString();
                    worksheet.Cells["V" + (i + 7)].Value = getdtdata.Rows[i]["sSectorTo"].ToString();
                    worksheet.Cells["W" + (i + 7)].Value = getdtdata.Rows[i]["sFileName"].ToString();
                    worksheet.Cells["X" + (i + 7)].Value = getdtdata.Rows[i]["dtProcess"].ToString();

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
     protected void lnkAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("tvisa.aspx");
    }

}
