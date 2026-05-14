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

public partial class titem_ledger_list : System.Web.UI.Page
{
    static titem_details_Class objClass = new titem_details_Class();
    public static string viewstate;
    validation valobj = new validation();
    string cond;
    SmtpClient sc = new SmtpClient();
    SendMail objsendmail = new SendMail();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                // Fillddl.FillPageddl(ddlPageSize
                txtdtFrom.Text = validation.fillDate();
                txtdtToDate.Text = validation.fillDate();
                objClass.ddlOperation(objClass, "Show", "", ddlItemName);

            }
        }
        catch (Exception ex)
        {
            //valobj.showMsg(ex.Message, "FAIL", lblmsg);
        }
        finally
        {
        }
    }

    [WebMethod]
    public static mpagemasterlist loaddata(string fromdate, string todate, string itemid)
    {

        DataTable dtmain = displaySearchGrid(fromdate, todate, itemid);

        list magentobj = new list();
        mpagemasterlist mainlist = new mpagemasterlist();
        mainlist.mpagemasterobjlist = new List<list>();


        try
        {

            for (int i = 0; i < dtmain.Rows.Count; i++)
            {
                magentobj = new list();
                magentobj.InvoiceDate = validation.TextToDate(dtmain.Rows[i]["InvoiceDate"].ToString());
                magentobj.InvoiceNo = dtmain.Rows[i]["InvoiceNo"].ToString();
                magentobj.Customer = dtmain.Rows[i]["AccountTitle"].ToString();
                magentobj.ItemName = dtmain.Rows[i]["sitemName"].ToString();
                magentobj.PQty = dtmain.Rows[i]["CreditQuantity"].ToString();
                magentobj.PRate = dtmain.Rows[i]["pUnit"].ToString();
                magentobj.SQty = dtmain.Rows[i]["DebitQuantity"].ToString();
                magentobj.SRate = dtmain.Rows[i]["sUnit"].ToString();
                magentobj.BalQty = dtmain.Rows[i]["nBalance"].ToString();
                magentobj.GTotal = dtmain.Rows[i]["GTotal"].ToString();
                mainlist.mpagemasterobjlist.Add(magentobj);
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return mainlist;
    }
    public static DataTable displaySearchGrid(string fromdate, string todate, string itemid)
    {
        DataTable dtmain = null;
        try
        {
            objClass.dtExpiry = validation.dateToText(fromdate);
            objClass.dtLastOrder = validation.dateToText(todate);
            DataTable dt = objClass.viewData(objClass, "ItemLedgerDet", itemid);
            dtmain = dt.Clone();
            dtmain.Columns.Add("nBalance");

            if (dt.Rows.Count > 0)
            {

                DataTable dt1 = objClass.viewData(objClass, "StockOpeningBalance", itemid);
                if (dt1.Rows.Count > 0)
                {
                    dtmain.Rows.Add(
                                    0,
                                    0,
                                    "",
                                    "",
                                    "Opening Balance",
                                    0,
                                    0,
                                    0,
                                    0,
                                    0,
                                    "",
                                    dt1.Rows[0]["nBalance"].ToString()
                                    );
                }
                else
                {
                    dtmain.Rows.Add(
                                    0,
                                    0,
                                    "",
                                    "",
                                    "Opening Balance",
                                    0,
                                    0,
                                    0,
                                    0,
                                    0,
                                    "",
                                    0
                                    );
                }


                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    dtmain.Rows.Add(
                                  dt.Rows[i]["InvoiceID"].ToString(),
                                  dt.Rows[i]["nItemID"].ToString(),
                                  dt.Rows[i]["InvoiceDate"].ToString(),
                                  dt.Rows[i]["InvoiceNo"].ToString(),
                                  dt.Rows[i]["sitemName"].ToString(),
                                  dt.Rows[i]["pUnit"].ToString(),
                                  dt.Rows[i]["CreditQuantity"].ToString(),
                                  dt.Rows[i]["sUnit"].ToString(),
                                  dt.Rows[i]["DebitQuantity"].ToString(),
                                  dt.Rows[i]["GTotal"].ToString(),
                                  dt.Rows[i]["AccountTitle"].ToString(),
                                  (int.Parse(dtmain.Rows[i]["nBalance"].ToString()) + int.Parse(dt.Rows[i]["CreditQuantity"].ToString()) - int.Parse(dt.Rows[i]["DebitQuantity"].ToString())).ToString()
                               );

                }
            }
        }
        catch (Exception ex)
        {
            //  valobj.showMsg(ex.Message, lblmsg);
        }
        return dtmain;
    }
    protected void btnexcel_Click(object sender, EventArgs e)
    {

        /// DataTable dt2 = objClass.pdftable(objClass, "getagentname", ddlAgent.SelectedValue);
        string AgentName = ddlItemName.SelectedItem.Text;
        #region get data

        DataTable getdtdata = new DataTable();
        getdtdata = displaySearchGrid(txtdtFrom.Text, txtdtToDate.Text, ddlItemName.SelectedValue);

        // // // below table for excel table

        getdtdata.Columns.Remove("InvoiceID");
        getdtdata.Columns.Remove("nItemID");
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
            var fileName = "ItemLedger-list-" + DateTime.Now.ToString("yyyy-MM-dd--hh-mm-ss") + ".xlsx";
            var outputDir = Server.MapPath("../Temp/Itemledger-list.xlsx");

            ///// // Create the file using the FileInfo object
            var file = new FileInfo(outputDir + fileName);

            ///// // Create the package and make sure you wrap it in a using statement
            using (var package = new ExcelPackage(file))
            {
                /////  // add a new worksheet to the empty workbook
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Item Ledger - " + DateTime.Now.ToShortDateString());

                // // clumn width adjustments code
                worksheet.View.FreezePanes(7, 1); //leave header and scrool all rows up and down
                worksheet.Column(1).Width = 10;
                #region

                #region
                worksheet.Column(2).Width = 15;
                worksheet.Column(3).Width = 20;
                worksheet.Column(4).Width = 25;
                worksheet.Column(5).Width = 45;
                worksheet.Column(6).Width = 10;
                worksheet.Column(7).Width = 15;
                worksheet.Column(8).Width = 25;
                worksheet.Column(9).Width = 45;
                worksheet.Column(10).Width = 10;
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
                worksheet.Cells[3, 1].Value = "	Statement  Details From : '" + txtdtFrom.Text + "' To: '" + txtdtToDate.Text + "' "; // Heading Name               
                worksheet.Cells[3, 1, 3, 11].Merge = true; //Merge columns start and end range
                worksheet.Cells[3, 1, 3, 11].Style.Font.Bold = true; //Font should be bold
                worksheet.Cells[3, 1, 3, 11].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center; // Aligmnet is center
                worksheet.Cells[3, 1].Style.Font.Color.SetColor(System.Drawing.Color.WhiteSmoke);


                // // // // merging cells and hading 


                ///////  //Merging cells and create a center heading for out table
                worksheet.Cells[4, 1].Value = "	Statement Name :Item Ledger "; // Heading Name               
                worksheet.Cells[4, 1, 4, 11].Merge = true; //Merge columns start and end range
                worksheet.Cells[4, 1, 4, 11].Style.Font.Bold = true; //Font should be bold
                worksheet.Cells[4, 1, 4, 11].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center; // Aligmnet is center
                worksheet.Cells[4, 1].Style.Font.Color.SetColor(System.Drawing.Color.WhiteSmoke);

                // // // agent name header
                ///////  //Merging cells and create a center heading for out table
                worksheet.Cells[5, 1].Value = "	Item Name : '" + AgentName + "' "; // Heading Name               
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
                    worksheet.Cells[6, 2].Value = "Invoice Date";
                    worksheet.Cells[6, 3].Value = "Invoice No";
                    worksheet.Cells[6, 4].Value = "Vendor / Customer";
                    worksheet.Cells[6, 5].Value = "Item Name";
                    worksheet.Cells[6, 6].Value = "P. Qty";
                    worksheet.Cells[6, 7].Value = "P. Rate";
                    worksheet.Cells[6, 8].Value = "S. Qty";
                    worksheet.Cells[6, 9].Value = "S. Rate";
                    worksheet.Cells[6, 10].Value = "Balance Qty";
                    worksheet.Cells[6, 11].Value = "G Total";
                }
                #endregion
                #region
                int count = 1;
                for (int i = 0; i < getdtdata.Rows.Count; i++)
                {
                    worksheet.Cells["A" + (i + 7)].Value = count;
                    worksheet.Cells["B" + (i + 7)].Value = date(getdtdata.Rows[i][0].ToString());
                    worksheet.Cells["C" + (i + 7)].Value = getdtdata.Rows[i][1].ToString();
                    worksheet.Cells["D" + (i + 7)].Value = getdtdata.Rows[i][8].ToString();
                    worksheet.Cells["E" + (i + 7)].Value = getdtdata.Rows[i][2].ToString();
                    worksheet.Cells["F" + (i + 7)].Value = getdtdata.Rows[i][3].ToString();
                    worksheet.Cells["G" + (i + 7)].Value = Convert.ToDouble(getdtdata.Rows[i][4].ToString());
                    worksheet.Cells["H" + (i + 7)].Value = Convert.ToDouble(getdtdata.Rows[i][5].ToString());
                    worksheet.Cells["I" + (i + 7)].Value = Convert.ToDouble(getdtdata.Rows[i][6].ToString());
                    worksheet.Cells["J" + (i + 7)].Value = Convert.ToDouble(getdtdata.Rows[i][7].ToString());
                    worksheet.Cells["K" + (i + 7)].Value = Convert.ToDouble(getdtdata.Rows[i][9].ToString());
                    count++;
                }
                #endregion


                package.Save();
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename=Cash Account ledger.xlsx");
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

        string AgentName = ddlItemName.SelectedItem.Text;
        DataTable getdtdata = new DataTable();
        getdtdata = displaySearchGrid(txtdtFrom.Text, txtdtToDate.Text, ddlItemName.SelectedValue);

        // // // below table for excel table

        getdtdata.Columns.Remove("InvoiceID");
        getdtdata.Columns.Remove("nItemID");

        string htmlbody = ExportDatatableToHtml(getdtdata);



        StringReader sr = new StringReader(htmlbody.ToString());
        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        pdfDoc.Open();
        htmlparser.Parse(sr);
        pdfDoc.Close();
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=ItemLedger.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Write(pdfDoc);
        Response.End();
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
                getdtdata = displaySearchGrid(txtdtFrom.Text, txtdtToDate.Text, ddlItemName.SelectedValue);

                // // // below table for excel table

                getdtdata.Columns.Remove("InvoiceID");
                getdtdata.Columns.Remove("nItemID");



                #endregion


                var fileName = "ItemLedger-" + DateTime.Now.ToString("yyyy-MM-dd--hh-mm-ss") + ".xlsx";
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
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Item Ledger - " + DateTime.Now.ToShortDateString());

                    // // clumn width adjustments code
                    worksheet.View.FreezePanes(7, 1); //leave header and scrool all rows up and down
                    worksheet.Column(1).Width = 10;
                    #region

                    #region
                    worksheet.Column(2).Width = 15;
                    worksheet.Column(3).Width = 20;
                    worksheet.Column(4).Width = 25;
                    worksheet.Column(5).Width = 45;
                    worksheet.Column(6).Width = 10;
                    worksheet.Column(7).Width = 15;
                    worksheet.Column(8).Width = 25;
                    worksheet.Column(9).Width = 45;
                    worksheet.Column(10).Width = 10;
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
                    worksheet.Cells[3, 1].Value = "	Statement  Details From : '" + txtdtFrom.Text + "' To: '" + txtdtToDate.Text + "' "; // Heading Name               
                    worksheet.Cells[3, 1, 3, 11].Merge = true; //Merge columns start and end range
                    worksheet.Cells[3, 1, 3, 11].Style.Font.Bold = true; //Font should be bold
                    worksheet.Cells[3, 1, 3, 11].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center; // Aligmnet is center
                    worksheet.Cells[3, 1].Style.Font.Color.SetColor(System.Drawing.Color.WhiteSmoke);


                    // // // // merging cells and hading 


                    ///////  //Merging cells and create a center heading for out table
                    worksheet.Cells[4, 1].Value = "	Statement Name :Item Ledger "; // Heading Name               
                    worksheet.Cells[4, 1, 4, 11].Merge = true; //Merge columns start and end range
                    worksheet.Cells[4, 1, 4, 11].Style.Font.Bold = true; //Font should be bold
                    worksheet.Cells[4, 1, 4, 11].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center; // Aligmnet is center
                    worksheet.Cells[4, 1].Style.Font.Color.SetColor(System.Drawing.Color.WhiteSmoke);

                    // // // agent name header
                    ///////  //Merging cells and create a center heading for out table
                    worksheet.Cells[5, 1].Value = "	Item Name : '" + ddlItemName.SelectedItem.Text + "' "; // Heading Name               
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
                        worksheet.Cells[6, 2].Value = "Invoice Date";
                        worksheet.Cells[6, 3].Value = "Invoice No";
                        worksheet.Cells[6, 4].Value = "Vendor / Customer";
                        worksheet.Cells[6, 5].Value = "Item Name";
                        worksheet.Cells[6, 6].Value = "P. Qty";
                        worksheet.Cells[6, 7].Value = "P. Rate";
                        worksheet.Cells[6, 8].Value = "S. Qty";
                        worksheet.Cells[6, 9].Value = "S. Rate";
                        worksheet.Cells[6, 10].Value = "Balance Qty";
                        worksheet.Cells[6, 11].Value = "G Total";
                    }
                    #endregion
                    #region
                    int count = 1;
                    for (int i = 0; i < getdtdata.Rows.Count; i++)
                    {
                        worksheet.Cells["A" + (i + 7)].Value = count;
                        worksheet.Cells["B" + (i + 7)].Value = date(getdtdata.Rows[i][0].ToString());
                        worksheet.Cells["C" + (i + 7)].Value = getdtdata.Rows[i][1].ToString();
                        worksheet.Cells["D" + (i + 7)].Value = getdtdata.Rows[i][8].ToString();
                        worksheet.Cells["E" + (i + 7)].Value = getdtdata.Rows[i][2].ToString();
                        worksheet.Cells["F" + (i + 7)].Value = getdtdata.Rows[i][3].ToString();
                        worksheet.Cells["G" + (i + 7)].Value = Convert.ToDouble(getdtdata.Rows[i][4].ToString());
                        worksheet.Cells["H" + (i + 7)].Value = Convert.ToDouble(getdtdata.Rows[i][5].ToString());
                        worksheet.Cells["I" + (i + 7)].Value = Convert.ToDouble(getdtdata.Rows[i][6].ToString());
                        worksheet.Cells["J" + (i + 7)].Value = Convert.ToDouble(getdtdata.Rows[i][7].ToString());
                        worksheet.Cells["K" + (i + 7)].Value = Convert.ToDouble(getdtdata.Rows[i][9].ToString());
                        count++;
                    }



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
                string AgentName = ddlItemName.SelectedItem.Text;
                DataTable getdtdata = new DataTable();
                getdtdata = displaySearchGrid(txtdtFrom.Text, txtdtToDate.Text, ddlItemName.SelectedValue);

                getdtdata.Columns.Remove("InvoiceID");
                getdtdata.Columns.Remove("nItemID");

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
                            mm.Subject = "Item Ledger PDF";
                            mm.Body = "Item Ledger PDF Attachment";
                            mm.Attachments.Add(new Attachment(new MemoryStream(bytes), "ItemLedger.pdf"));
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
    protected string ExportDatatableToHtml(DataTable dt)
    {
        string AgentName = ddlItemName.SelectedItem.Text;
        string dtrequestfrom = string.Empty;
        string dtrquestto = string.Empty;
        if (txtdtFrom.Text != "")
        {
            dtrequestfrom = txtdtFrom.Text.Trim();
            dtrequestfrom = dtrequestfrom.Replace("/", "-");
            dtrquestto = txtdtToDate.Text.Trim();
            dtrquestto = dtrquestto.Replace("/", "-");
        }
        StringBuilder strHTMLBuilder = new StringBuilder();
        strHTMLBuilder.Append("<!DOCTYPE html><html>");
        if (txtdtFrom.Text != "")
        {
            strHTMLBuilder.Append("<head style='background: #1abc9c;border-style: groove;' ><h1 style=' text-align: center;font-style: Latin;'>Supplier Name: Alnasa Technology</h1><br><p style='color: gray;text-align: center'> Ledger Details from :-" + dtrequestfrom + " To :" + dtrquestto + "</p><br><p style='color: gray;text-align: center'> Ledger Details : Item Ledger</p><br><p style='color: gray;text-align: center'> Agency Name :- " + AgentName + "</p><br>");

        }
        else
        {
            strHTMLBuilder.Append("<head style='background: #1abc9c;border-style: groove;' ><h1 style=' text-align: center;font-style: Latin;'>Supplier Name: Alnasa Technology</h1><p style='color: gray;text-align: center'> Ledger Name :-Agent Cash Account Ledger Statement</p><br><p style='color: gray;text-align: center'> Item Name :- " + AgentName + "</p><br>");

        }
        strHTMLBuilder.Append("</head>");
        strHTMLBuilder.Append("<body style='background: green;'>");
        //  strHTMLBuilder.Append(@"<table border=\'1px\' cellpadding=\'1\' cel99265lspacing=\'1\' bgcolor=\'lightyellow\' style=\'font-family:Garamond; font-size:smaller\'>");
        // strHTMLBuilder.Append(@"<table border=1px cellpadding=1px celspacing=1px bgcolor=lightyellow style=font-family:Garamond; font-size:smaller'>");

        strHTMLBuilder.Append(@"<table border='1' cellpadding='1' >");

        strHTMLBuilder.Append("<tr>");
        int count = 0;
        // // below code for change the table header
        dt.Columns["InvoiceDate"].ColumnName = "Invoice Date";
        dt.Columns["InvoiceNo"].ColumnName = "Invoice No";
        dt.Columns["AccountTitle"].ColumnName = "Vendor / Customer";
        dt.Columns["sitemName"].ColumnName = "Item Name";
        dt.Columns["CreditQuantity"].ColumnName = "P. Qty";
        dt.Columns["pUnit"].ColumnName = "P. Rate";
        dt.Columns["DebitQuantity"].ColumnName = "S. Qty";
        dt.Columns["sUnit"].ColumnName = "S. Rate";
        dt.Columns["nBalance"].ColumnName = "Balance Qty";
        dt.Columns["GTotal"].ColumnName = "G Total";
       

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
    //protected void btnPrint_Click(object sender, EventArgs e)
    //{
    //    DataTable dtmain = displaySearchGrid(fromdate, todate, itemid);
    //    string dtrequestfrom = string.Empty;
    //    string dtrquestto = string.Empty;


    //    if (txttLastPurchase.Text != "")
    //    {
    //        if (ddlCustomerName.SelectedValue != "0" && ddlCustomerName.SelectedValue != "")
    //        {
    //            objClass.ClientNameID = ddlCustomerName.SelectedValue;
    //        }
    //        else
    //        {
    //            objClass.ClientNameID = "0";
    //        }
    //        dtrequestfrom = txttLastPurchase.Text.Trim();
    //        // dtrequestfrom = dtrequestfrom.Replace("/", "-");
    //        dtrquestto = txttLastOrder.Text.Trim();
    //        //dtrquestto = dtrquestto.Replace("/", "-");

    //        lbldates.Text = "Ledger Details from:" + dtrequestfrom + " To: " + dtrquestto + "";
    //        objClass.StartDate = validation.dateToText(dtrequestfrom);
    //        objClass.EndDate = validation.dateToText(dtrquestto);
    //        objClass.FillGrid(objClass, GridViewexcel, "Show", "");
    //    }
    //    Session["ctrl"] = scndgrddiv;

    //    ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('../Print.aspx','PrintMe','height=300px,width=300px,scrollbars=1');</script>");

    //}

    public class list
    {

        public string InvoiceDate { get; set; }
        public string InvoiceNo { get; set; }
        public string Customer { get; set; }
        public string ItemName { get; set; }
        public string PQty { get; set; }
        public string PRate { get; set; }
        public string SQty { get; set; }
        public string SRate { get; set; }
        public string BalQty { get; set; }
        public string GTotal { get; set; }
    }

    public class mpagemasterlist
    {
        public List<list> mpagemasterobjlist { get; set; }
    }
}
#endregion