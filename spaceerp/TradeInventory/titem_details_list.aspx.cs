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

public partial class titem_details_list : System.Web.UI.Page
{
    static titem_details_Class objClass = new titem_details_Class();
    validation valobj = new validation();
    string cond;
    public static string viewstate;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {

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
    public static string DeleteVoucher(string AccountLedgerID)
    {
        string msg = "";
        try
        {
            objClass.nItemDetailsID = AccountLedgerID;
            var vres = objClass.User_Operation(objClass, "Delete");
            string[] values = vres.Split(',');
            string val1 = values[0];
            if (val1 == "1")
            {
                msg = val1;
            }
            else
            {
                msg = vres;
            }
        }
        catch (Exception ex)
        {
            msg = ex.Message.ToString();
        }



        return msg;
    }

    [WebMethod]
    public static mpagemasterlist loaddata()
    {
        list magentobj = new list();
        list magentobjnew = new list();
        mpagemasterlist mainlist = new mpagemasterlist();
        mainlist.mpagemasterobjlist = new List<list>();
        DataTable dt = new DataTable();
        try
        {
            dt = objClass.Tabledata(objClass, "ShowGrid", "");
            
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                magentobj = new list();
                magentobj.ItemName = dt.Rows[i]["sitemName"].ToString();
                magentobj.ItemCategory = dt.Rows[i]["sItemCategory"].ToString();
                magentobj.ItemSubCategory = dt.Rows[i]["sItemSubCategory"].ToString();
                magentobj.ItemType = dt.Rows[i]["sItemType"].ToString();
                magentobj.ItemMark = dt.Rows[i]["sItemMark"].ToString();
                magentobj.SalePrice = dt.Rows[i]["nSalePrice"].ToString();
                magentobj.ExpiryDate = validation.TextToDate(dt.Rows[i]["dtExpiry"].ToString());
                magentobj.ItemID = dt.Rows[i]["nItemDetailsID"].ToString();
                mainlist.mpagemasterobjlist.Add(magentobj);
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
        public string ItemID { get; set; }
        public string ItemName{ get; set; }
        public string ItemCategory { get; set; }
        public string ItemSubCategory { get; set; }
        public string ItemType { get; set; }
        public string ItemMark { get; set; }
        public string SalePrice { get; set; }
        public string ExpiryDate { get; set; }
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
        Response.Redirect("titem_details.aspx");
    }

}
