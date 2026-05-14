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

public partial class tpurchasereturninvoice_list : System.Web.UI.Page
{
    static tpurhcasereturninvoice_Class objClass = new tpurhcasereturninvoice_Class();
    validation valobj = new validation();
    string cond;
    public static string viewstate;
    SmtpClient sc = new SmtpClient();
    SendMail objsendmail = new SendMail();
    mmain_account_Class objChartOfAcc = new mmain_account_Class();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                // Fillddl.FillPageddl(ddlPageSize
                string aa = Server.UrlEncode(System.DateTime.Now.ToString());
                mmain_account_Class objChartOfAcc = new mmain_account_Class();
                objChartOfAcc.ddlOperation(objChartOfAcc, "ShowddlAccount", "", ddlCustomerName);
            }
        }
        catch (Exception ex)
        {
           // valobj.showMsg(ex.Message, "FAIL", lblmsg);
        }
        finally
        {
        }
    }
    //public void Page_PreRender(object sender, EventArgs e)
    //{
    //    ViewState["tsalesdebitnote"] = Session["tsalesdebitnote"];
    //    viewstate = Session["tsalesdebitnote"].ToString();
    //}


    [WebMethod]
    public static mpagemasterlist loaddata(string fromdate, string todate, string Reportfor)
    {
        list magentobj = new list();
        list magentobjnew = new list();
        mpagemasterlist mainlist = new mpagemasterlist();
        mainlist.mpagemasterobjlist = new List<list>();
        mainlist.mpagemasterobjlistnew  = new List<list>();
        DataTable dt = new DataTable();
        try
        {
            if (Reportfor != "0" && Reportfor != "")
            {
                objClass.ClientNameID = Reportfor;
            }
            else
            {
                objClass.ClientNameID = "0";
            }
            objClass.StartDate = validation.dateToText(fromdate);
            objClass.EndDate = validation.dateToText(todate);
            dt = objClass.Tabledata(objClass, "Show", "");
            
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                magentobj = new list();
                magentobj.SalesDebitNoteNo = dt.Rows[i]["sPurchaseReturnNo"].ToString();
                magentobj.DebitNotedate = validation.TextToDate(dt.Rows[i]["dtDebitNote"].ToString());
                magentobj.GSTType = dt.Rows[i]["sGSTType"].ToString();
                magentobj.Referenceno = dt.Rows[i]["sReferenceno"].ToString();
                magentobj.Referencedate = validation.TextToDate(dt.Rows[i]["dtReference"].ToString()); 
                magentobj.SalesDebitNoteID =dt.Rows[i]["nPurchaseReturnInvoiceID"].ToString();
                //magentobj.AgentID =dt.Rows[i]["nAgentID"].ToString();
                //magentobj.LocationID = dt.Rows[i]["nLocationID"].ToString();
                //magentobj.TicketingCompanyID = dt.Rows[i]["nTicketingCompanyID"].ToString();
                //magentobj.SupplierID = dt.Rows[i]["nSupplierID"].ToString();
                //magentobj.AutoInvoice = dt.Rows[i]["bAutoInvoice"].ToString();
                //magentobj.TicketTypeID = dt.Rows[i]["nTicketTypeID"].ToString();
                mainlist.mpagemasterobjlist.Add(magentobj);
            }            
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return mainlist;
    }
    [WebMethod]
    public static string DeleteVoucher(string AccountLedgerID)
    {
        string msg = "";
        try
        {
            objClass.PurchaseDebitNoteID = AccountLedgerID;
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
    protected void btnexcel_Click(object sender, EventArgs e)
    {

        /// DataTable dt2 = objClass.pdftable(objClass, "getagentname", ddlAgent.SelectedValue);
        string AgentName = "";
        #region get data

        DataTable getdtdata = new DataTable();
       // objClass.nVendorID = ddlCustomerName.SelectedValue;
        objClass.StartDate = validation.dateToText(txttLastPurchase.Text);
        objClass.EndDate = validation.dateToText(txttLastOrder.Text);
        getdtdata = objClass.Tabledata(objClass, "Show", "");

        // // // below table for excel table

        //getdtdata.Columns.Remove("nBookingID");
        //getdtdata.Columns.Remove("nAgentID");
        //getdtdata.Columns.Remove("nVisaCompanyID");
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
            var fileName = "Purchase Return Invoice -" + DateTime.Now.ToString("yyyy-MM-dd--hh-mm-ss") + ".xlsx";
            var outputDir = Server.MapPath("../Temp/PurchaseReturnInvoice.xlsx");

            ///// // Create the file using the FileInfo object
            var file = new FileInfo(outputDir + fileName);

            ///// // Create the package and make sure you wrap it in a using statement
            using (var package = new ExcelPackage(file))
            {
                /////  // add a new worksheet to the empty workbook
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Purchase Return Invoice - " + DateTime.Now.ToShortDateString());

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
               

                #endregion
                #endregion
                #region set center the row data start
                worksheet.Column(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Column(2).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Column(3).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Column(4).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Column(5).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Column(6).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                
                #endregion
                ///// //Merging cells and create a center heading for out table
                worksheet.Cells[1, 1].Value = "ALNASA"; // Heading Name
                worksheet.Cells[1, 1].Style.Font.Size = 20;
                worksheet.Cells[3, 1].Style.Font.Size = 15;
                worksheet.Cells[5, 1, 5, 3].Style.Font.Size = 13;

                ///// // MergeCell for gap rows and 15 is number of colums
                //  worksheet.Cells[2, 1, 2, getdtdata.Columns.Count].Merge = true; //Merge columns start and end range
                worksheet.Cells[2, 1, 2, 6].Merge = true;
                worksheet.Cells[4, 1, 4, 6].Merge = true; //Merge columns start and end range

                //////// // ExcelWorksheet.cells[from row, from column, to row, to column].
                // worksheet.Cells[1, 1, 1, getdtdata.Columns.Count].Merge = true; //Merge columns start and end range
                worksheet.Cells[1, 1, 1, 6].Merge = true; //Merge columns start and end range
                worksheet.Cells[1, 1, 1, 6].Style.Font.Bold = true; //Font should be bold
                worksheet.Cells[1, 1, 1, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center; // Aligmnet is center
                worksheet.Cells[1, 1].Style.Font.Color.SetColor(System.Drawing.Color.WhiteSmoke);
                // // //im giving 15 for range the columns for header
                ///////  //Merging cells and create a center heading for out table
                worksheet.Cells[3, 1].Value = "	Statement  Details From : '" + txttLastPurchase.Text + "' To: '" + txttLastOrder.Text + "' "; // Heading Name               
                worksheet.Cells[3, 1, 3, 6].Merge = true; //Merge columns start and end range
                worksheet.Cells[3, 1, 3, 6].Style.Font.Bold = true; //Font should be bold
                worksheet.Cells[3, 1, 3, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center; // Aligmnet is center
                worksheet.Cells[3, 1].Style.Font.Color.SetColor(System.Drawing.Color.WhiteSmoke);


                // // // // merging cells and hading 


                ///////  //Merging cells and create a center heading for out table
                worksheet.Cells[4, 1].Value = "	Statement Name : Purchase Return Invoice "; // Heading Name               
                worksheet.Cells[4, 1, 4, 6].Merge = true; //Merge columns start and end range
                worksheet.Cells[4, 1, 4, 6].Style.Font.Bold = true; //Font should be bold
                worksheet.Cells[4, 1, 4, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center; // Aligmnet is center
                worksheet.Cells[4, 1].Style.Font.Color.SetColor(System.Drawing.Color.WhiteSmoke);

                // // // agent name header
                ///////  //Merging cells and create a center heading for out table
                worksheet.Cells[5, 1].Value = "	Agency Name : '" + AgentName + "' "; // Heading Name               
                worksheet.Cells[5, 1, 5, 6].Merge = true; //Merge columns start and end range
                worksheet.Cells[5, 1, 5, 6].Style.Font.Bold = true; //Font should be bold
                worksheet.Cells[5, 1, 5, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center; // Aligmnet is center
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
                using (var range = worksheet.Cells[6, 1, 6, 6])
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
                    worksheet.Cells[6, 2].Value = "Debit Note No";
                    worksheet.Cells[6, 3].Value = "Debit Note Date";
                    worksheet.Cells[6, 4].Value = "GST Type";
                    worksheet.Cells[6, 5].Value = "Reference No";
                    worksheet.Cells[6, 6].Value = "Reference Date";
                   

                }
                #endregion
                #region
                int count = 1;
                for (int i = 0; i < getdtdata.Rows.Count; i++)
                {
                    worksheet.Cells["A" + (i + 7)].Value = count;
                    worksheet.Cells["B" + (i + 7)].Value = getdtdata.Rows[i]["sPurchaseReturnNo"].ToString();
                    worksheet.Cells["C" + (i + 7)].Value = date(getdtdata.Rows[i]["dtDebitNote"].ToString());
                    worksheet.Cells["D" + (i + 7)].Value = getdtdata.Rows[i]["sGSTType"].ToString();
                    worksheet.Cells["E" + (i + 7)].Value = getdtdata.Rows[i]["sReferenceno"].ToString();
                    worksheet.Cells["F" + (i + 7)].Value = date(getdtdata.Rows[i]["dtReference"].ToString());
                   
                    count++;
                }
                #endregion


                package.Save();
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename=PurchaseReturnInvoice.xlsx");
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

        DataTable getdtdata = new DataTable();
        objClass.StartDate = validation.dateToText(txttLastPurchase.Text);
        objClass.EndDate = validation.dateToText(txttLastOrder.Text);
        getdtdata = objClass.Tabledata(objClass, "Show", "");


        // // // below table for excel table



        //for (int x = 0; x < getdtdata.Rows.Count; x++)
        //{
        //    getdtdata.Rows[x]["dtDate"] = date(getdtdata.Rows[x]["dtDate"].ToString());

        //}

        string htmlbody = ExportDatatableToHtml(getdtdata);



        StringReader sr = new StringReader(htmlbody.ToString());
        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        pdfDoc.Open();
        htmlparser.Parse(sr);
        pdfDoc.Close();
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=PurchaseReturnInvoice.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Write(pdfDoc);
        Response.End();
    }
    protected string ExportDatatableToHtml(DataTable dt)
    {



        string AgentName = string.Empty;
        string dtrequestfrom = string.Empty;
        string dtrquestto = string.Empty;
        //if (txtFromDate.Text != "")
        //{
        //    dtrequestfrom = txtFromDate.Text.Trim();
        //    dtrequestfrom = dtrequestfrom.Replace("/", "-");
        //    dtrquestto = txtToDate.Text.Trim();
        //    dtrquestto = dtrquestto.Replace("/", "-");
        //}
        StringBuilder strHTMLBuilder = new StringBuilder();
        strHTMLBuilder.Append("<!DOCTYPE html><html>");
        //if ( != "")
        //{
        //    strHTMLBuilder.Append("<head style='background: #1abc9c;border-style: groove;' ><h1 style=' text-align: center;font-style: Latin;'>Supplier Name: FlyZone Travels</h1><br><p style='color: gray;text-align: center'> Ledger Details from :-" + dtrequestfrom + " To :" + dtrquestto + "</p><br><p style='color: gray;text-align: center'> Ledger Details :- Cash Account Ledger Statement</p><br><p style='color: gray;text-align: center'> Agency Name :- " + AgentName + "</p><br>");

        //}
        //else
        //{
        //    strHTMLBuilder.Append("<head style='background: #1abc9c;border-style: groove;' ><h1 style=' text-align: center;font-style: Latin;'>Supplier Name: FlyZone Travels</h1><p style='color: gray;text-align: center'> Ledger Name :- Cash Account Ledger Statement</p><br><p style='color: gray;text-align: center'> Agency Name :- " + AgentName + "</p><br>");

        //}
        strHTMLBuilder.Append("<head style='background: #1abc9c;border-style: groove;' ><h1 style=' text-align: center;font-style: Latin;'>Supplier Name: Alnasa Technology</h1><p style='color: gray;text-align: center'> Report :- Purchase Return Invoice</p><br><p style='color: gray;text-align: center'> Agency Name :- " + AgentName + "</p><br>");
        strHTMLBuilder.Append("</head>");
        strHTMLBuilder.Append("<body style='background: green;'>");
        //  strHTMLBuilder.Append(@"<table border=\'1px\' cellpadding=\'1\' cel99265lspacing=\'1\' bgcolor=\'lightyellow\' style=\'font-family:Garamond; font-size:smaller\'>");
        // strHTMLBuilder.Append(@"<table border=1px cellpadding=1px celspacing=1px bgcolor=lightyellow style=font-family:Garamond; font-size:smaller'>");

        strHTMLBuilder.Append(@"<table border='1' cellpadding='1' >");

        strHTMLBuilder.Append("<tr>");
        int count = 0;
        // // below code for change the table header
        dt.Columns.Remove("nPurchaseReturnInvoiceID");
        dt.Columns["sPurchaseReturnNo"].ColumnName = "Debit Note No";
        // date(getdtdata.Rows[x]["dtDate"].ToString());
        dt.Columns["dtDebitNote"].ColumnName = "Debit Note Date";
        dt.Columns["sGSTType"].ColumnName = "GST Type";
        dt.Columns["sReferenceno"].ColumnName = "Reference No";
        dt.Columns["dtReference"].ColumnName = "Reference Date";

        foreach (DataColumn myColumn in dt.Columns)
        {
            if (count == 3)
            {
                strHTMLBuilder.Append("<td style='font-size: 10px; width:150px; text-align:center;'>");
                strHTMLBuilder.Append(myColumn.ColumnName);
                strHTMLBuilder.Append("</td>");
            }
            else
            {
                strHTMLBuilder.Append("<td style='font-size: 10px; text-align:center;'>");
                strHTMLBuilder.Append(myColumn.ColumnName);
                strHTMLBuilder.Append("</td>");
            }
            count++;

        }
        strHTMLBuilder.Append("</tr>");


        foreach (DataRow myRow in dt.Rows)
        {

            strHTMLBuilder.Append("<tr >");
            foreach (DataColumn myColumn in dt.Columns)
            {
                strHTMLBuilder.Append("<td style='font-size: 10px; text-align:center;' >");
                strHTMLBuilder.Append(myRow[myColumn.ColumnName].ToString());
                strHTMLBuilder.Append("</td>");

            }
            strHTMLBuilder.Append("</tr>");
        }

        //Close tags.  
        strHTMLBuilder.Append("</table>");
        strHTMLBuilder.Append("</body>");
        strHTMLBuilder.Append("</html>");

        string Htmltext = strHTMLBuilder.ToString();

        return Htmltext;

    }
    protected void btnsendmail_Click(object sender, EventArgs e)
    {
        string vto = txtTo.Text;
        string vcc = txtCC.Text;
        string vbcc = txtBCC.Text;
        string vSubject = txtSub.Text;
        string vBody = txtBody.Text;
        lblerrormsg.Text = "";
        lblerrormsg.Visible = false;
        try
        {
            if (rbexcel.Checked)
            {
                #region



                DataTable getdtdata = new DataTable();
                objClass.StartDate = validation.dateToText(txttLastPurchase.Text);
                objClass.EndDate = validation.dateToText(txttLastOrder.Text);
                getdtdata = objClass.Tabledata(objClass, "ShowGrid", "");



                #endregion


                var fileName = "PurchaseReturnInvoice-" + DateTime.Now.ToString("yyyy-MM-dd--hh-mm-ss") + ".xlsx";
                // var fileName= "list" + DateTime.Today.ToFileTime() + ".xlsx";
                var outputDir = Server.MapPath("../Temp/123.xlsx");
                ///// // Create the file using the FileInfo object
                var file = new FileInfo(outputDir + fileName);
                string filepath = outputDir + fileName;
                lnkAttachment.Text = filepath;
                #region start code


                ///// // Create the package and make sure you wrap it in a using statement
                using (var package = new ExcelPackage(file))
                {
                    /////  // add a new worksheet to the empty workbook
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("PurchaseReturnInvoice - " + DateTime.Now.ToShortDateString());

                    // // clumn width adjustments code
                    worksheet.View.FreezePanes(7, 1); //leave header and scrool all rows up and down

                    #region

                    #region
                    worksheet.Column(2).Width = 15;
                    worksheet.Column(3).Width = 20;
                    worksheet.Column(4).Width = 25;
                    worksheet.Column(5).Width = 45;
                    worksheet.Column(6).Width = 10;

                    #endregion
                    #endregion
                    #region set center the row data start
                    worksheet.Column(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    worksheet.Column(2).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    worksheet.Column(3).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    worksheet.Column(4).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    worksheet.Column(5).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    worksheet.Column(6).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    #endregion
                    ///// //Merging cells and create a center heading for out table
                    worksheet.Cells[1, 1].Value = "Alnasa Technology"; // Heading Name
                    worksheet.Cells[1, 1].Style.Font.Size = 20;
                    worksheet.Cells[3, 1].Style.Font.Size = 15;
                    worksheet.Cells[5, 1, 5, 3].Style.Font.Size = 13;

                    ///// // MergeCell for gap rows and 15 is number of colums
                    //  worksheet.Cells[2, 1, 2, getdtdata.Columns.Count].Merge = true; //Merge columns start and end range
                    worksheet.Cells[2, 1, 2, 6].Merge = true;
                    worksheet.Cells[4, 1, 4, 6].Merge = true; //Merge columns start and end range

                    //////// // ExcelWorksheet.cells[from row, from column, to row, to column].
                    // worksheet.Cells[1, 1, 1, getdtdata.Columns.Count].Merge = true; //Merge columns start and end range
                    worksheet.Cells[1, 1, 1, 6].Merge = true; //Merge columns start and end range
                    worksheet.Cells[1, 1, 1, 6].Style.Font.Bold = true; //Font should be bold
                    worksheet.Cells[1, 1, 1, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center; // Aligmnet is center
                    worksheet.Cells[1, 1].Style.Font.Color.SetColor(System.Drawing.Color.WhiteSmoke);
                    // // //im giving 15 for range the columns for header
                    ///////  //Merging cells and create a center heading for out table
                    worksheet.Cells[3, 1].Value = "	Statement  Deatails From : '" + txttLastPurchase.Text + "' To: '" + txttLastOrder.Text + "' "; // Heading Name               
                    worksheet.Cells[3, 1, 3, 6].Merge = true; //Merge columns start and end range
                    worksheet.Cells[3, 1, 3, 6].Style.Font.Bold = true; //Font should be bold
                    worksheet.Cells[3, 1, 3, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center; // Aligmnet is center
                    worksheet.Cells[3, 1].Style.Font.Color.SetColor(System.Drawing.Color.WhiteSmoke);


                    // // // // merging cells and hading 


                    ///////  //Merging cells and create a center heading for out table
                    worksheet.Cells[4, 1].Value = "	Statement Name : Purchase Return Invoice "; // Heading Name               
                    worksheet.Cells[4, 1, 4, 6].Merge = true; //Merge columns start and end range
                    worksheet.Cells[4, 1, 4, 6].Style.Font.Bold = true; //Font should be bold
                    worksheet.Cells[4, 1, 4, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center; // Aligmnet is center
                    worksheet.Cells[4, 1].Style.Font.Color.SetColor(System.Drawing.Color.WhiteSmoke);

                    // // // agent name header
                    ///////  //Merging cells and create a center heading for out table
                    worksheet.Cells[5, 1].Value = "	Agency Name : Test "; // Heading Name               
                    worksheet.Cells[5, 1, 5, 6].Merge = true; //Merge columns start and end range
                    worksheet.Cells[5, 1, 5, 6].Style.Font.Bold = true; //Font should be bold
                    worksheet.Cells[5, 1, 5, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center; // Aligmnet is center
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
                    using (var range = worksheet.Cells[6, 1, 6, 6])
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
                        worksheet.Cells[6, 2].Value = "Debit Note No";
                        worksheet.Cells[6, 3].Value = "Debit Note Date";
                        worksheet.Cells[6, 4].Value = "GST Type";
                        worksheet.Cells[6, 5].Value = "Reference No";
                        worksheet.Cells[6, 6].Value = "Reference Date";


                    }
                    #endregion
                    #region
                    int count = 1;
                    for (int i = 0; i < getdtdata.Rows.Count; i++)
                    {
                        worksheet.Cells["A" + (i + 7)].Value = count;
                        worksheet.Cells["B" + (i + 7)].Value = getdtdata.Rows[i]["sPurchaseReturnNo"].ToString();
                        worksheet.Cells["C" + (i + 7)].Value = date(getdtdata.Rows[i]["dtDebitNote"].ToString());
                        worksheet.Cells["D" + (i + 7)].Value = getdtdata.Rows[i]["sGSTType"].ToString();
                        worksheet.Cells["E" + (i + 7)].Value = getdtdata.Rows[i]["sReferenceno"].ToString();
                        worksheet.Cells["F" + (i + 7)].Value = date(getdtdata.Rows[i]["dtReference"].ToString());

                        count++;
                    }
                    #endregion


                    #endregion
                    package.Save();
                    Response.Clear();
                    //  Response.Buffer = true;
                    //   Response.Charset = "";
                    //  Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    //  Response.AddHeader("content-disposition", "attachment;filename=Flightlist.xlsx");
                    objsendmail.Send(txtTo.Text, txtCC.Text, txtBCC.Text, txtSub.Text, txtBody.Text, lnkAttachment.Text);
                    //   Response.Write("<script LANGUAGE='JavaScript' >alert('Email has been sent successfully')</script>");
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "HidePopup", "$('#exampleModalLong').modal('show')", true);

                    #region
                    //MailMessage mm = new MailMessage("webflyzonet@gmail.com", vto);

                    //mm = new MailMessage("webflyzonet@gmail.com", vto);
                    //mm.Subject = "AccountLedger PDF";
                    //mm.Body = "AccountLedger PDF Attachment";
                    //mm.Attachments.Add(new Attachment(filepath, "application/vnd.ms-excel"));
                    //mm.IsBodyHtml = true;

                    //sc.Host = "smtp.gmail.com";
                    //sc.EnableSsl = true;
                    //System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                    //NetworkCred.UserName = "webflyzonet@gmail.com";
                    //NetworkCred.Password = "Khan#1w2123";
                    //sc.UseDefaultCredentials = true;
                    //sc.Credentials = NetworkCred;
                    //sc.Port = 587;
                    //sc.Send(mm);
                    #endregion
                    //using (MemoryStream MyMemoryStream = new MemoryStream())
                    //{
                    //    package.SaveAs(MyMemoryStream);
                    //    MyMemoryStream.WriteTo(Response.OutputStream);
                    //    Response.Flush();
                    //    Response.End();
                    //}

                }

            }
            if (rbpdf.Checked)
            {
                #region
                DataTable getdtdata = new DataTable();
                objClass.StartDate = validation.dateToText(txttLastPurchase.Text);
                objClass.EndDate = validation.dateToText(txttLastOrder.Text);
                getdtdata = objClass.Tabledata(objClass, "Show", "");

                string htmlbody = ExportDatatableToHtml(getdtdata);
                //  StringReader sr = new StringReader(htmlbody.ToString());

                using (StringWriter sw = new StringWriter())
                {
                    using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                    {
                        // GridView1.RenderControl(hw);
                        StringReader sr = new StringReader(htmlbody.ToString());
                        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            PdfWriter.GetInstance(pdfDoc, memoryStream);
                            pdfDoc.Open();
                            htmlparser.Parse(sr);
                            pdfDoc.Close();
                            byte[] bytes = memoryStream.ToArray();
                            memoryStream.Close();

                            MailMessage mm = new MailMessage("webflyzonet@gmail.com", vto);
                            mm.Subject = "Purchase Return Invoice PDF";
                            mm.Body = "PurchaseReturn Invoice PDF Attachment";
                            mm.Attachments.Add(new Attachment(new MemoryStream(bytes), "PurchaseReturnInvoice.pdf"));
                            mm.IsBodyHtml = true;

                            sc.Host = "smtp.gmail.com";
                            sc.EnableSsl = true;
                            System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                            NetworkCred.UserName = "webflyzonet@gmail.com";
                            NetworkCred.Password = "Khan#1w2123";
                            sc.UseDefaultCredentials = true;
                            sc.Credentials = NetworkCred;
                            sc.Port = 587;
                            sc.Send(mm);
                            //   Response.Write("<script LANGUAGE='JavaScript' >alert('Email has been sent successfully')</script>");
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "HidePopup", "$('#exampleModalLong').modal('show')", true);

                        }
                    }
                }
                #endregion
            }
        }
        catch (Exception ex)
        {
            //throw ex;
            lblerrormsg.Visible = true;
            lblerrormsg.Text = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "HidePopup", "$('#exampleModalLong').modal('show')", true);

        }
        txtTo.Text = "";
        txtCC.Text = "";
        txtBCC.Text = "";
        txtSub.Text = "";
        txtBody.Text = "";
        rbexcel.Checked = false;
        rbpdf.Checked = false;

    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {

        string dtrequestfrom = string.Empty;
        string dtrquestto = string.Empty;


        if (txttLastPurchase.Text != "")
        {
            if (ddlCustomerName.SelectedValue != "0" && ddlCustomerName.SelectedValue != "")
            {
                objClass.ClientNameID = ddlCustomerName.SelectedValue;
            }
            else
            {
                objClass.ClientNameID = "0";
            }
            dtrequestfrom = txttLastPurchase.Text.Trim();
            // dtrequestfrom = dtrequestfrom.Replace("/", "-");
            dtrquestto = txttLastOrder.Text.Trim();
            //dtrquestto = dtrquestto.Replace("/", "-");

            lbldates.Text = "Ledger Details from:" + dtrequestfrom + " To: " + dtrquestto + "";
            objClass.StartDate = validation.dateToText(dtrequestfrom);
            objClass.EndDate = validation.dateToText(dtrquestto);
            objClass.FillGrid(objClass, GridViewexcel, "Show", "");
        }
        Session["ctrl"] = scndgrddiv;

        ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('../Print.aspx','PrintMe','height=300px,width=300px,scrollbars=1');</script>");

    }
    public class list
    {
        public string SalesDebitNoteID { get; set; }
        public string SalesDebitNoteNo { get; set; }
        public string GSTType { get; set; }
        public string ClientNameID { get; set; }
        public string LocationID { get; set; }
        public string DebitNotedate { get; set; }
        public string Referenceno { get; set; }
        public string Referencedate { get; set; }


    }

    public class mpagemasterlist
    {
        public List<list> mpagemasterobjlist { get; set; }
        public List<list> mpagemasterobjlistnew { get; set; }
    }
    
    
     protected void lnkAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("tpurchasereturninvoice.aspx");
    }

}
