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

public partial class tgeneral_ledger_list : System.Web.UI.Page
{
    static tvisadet_Class objClass = new tvisadet_Class();
    mmain_account_Class ObjAcc = new mmain_account_Class();
    mbranches_Class objLoc = new mbranches_Class();
    static tvisadet_Class ObjAccTitle = new tvisadet_Class();
    static mmain_account_Class objMainAcc = new mmain_account_Class();
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
                txtdtFrom.Text = validation.fillDate();
                txtdtToDate.Text = validation.fillDate();
                ObjAcc.ddlOperation(ObjAcc, "ShowddlAccount", "", ddlAccountCashBook);




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
    public static mpagemasterlist loaddata(string fromdate, string todate, string AccountTitle,string AccountType)
    {

        DataTable dtmain = displaySearchGrid(fromdate, todate, AccountTitle, AccountType);

        list magentobj = new list();
        mpagemasterlist mainlist = new mpagemasterlist();
        mainlist.mpagemasterobjlist = new List<list>();


        try
        {

            for (int i = 0; i < dtmain.Rows.Count; i++)
            {
                magentobj = new list();
                magentobj.VoucherDate = validation.TextToDate(dtmain.Rows[i]["Voucher Date"].ToString());
                magentobj.VoucherNo = dtmain.Rows[i]["Voucher No"].ToString();
                magentobj.VoucherType = dtmain.Rows[i]["sVoucherType"].ToString();
                magentobj.Description = dtmain.Rows[i]["Description"].ToString();
                magentobj.DebitAmount = dtmain.Rows[i]["Debit Amount"].ToString();
                magentobj.CreditAmount = dtmain.Rows[i]["Credit Amount"].ToString();
                magentobj.Balance = dtmain.Rows[i]["Balance"].ToString();
                mainlist.mpagemasterobjlist.Add(magentobj);
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return mainlist;
    }
    public static DataTable displaySearchGrid(string fromdate, string todate, string AccountTitle, string AccountType)
    {
        DataTable dtmain = new DataTable();
        try
        {
            objClass.dtApply = validation.dateToText(fromdate);
            objClass.dtDOB = validation.dateToText(todate);
            DataTable dtnew = objMainAcc.viewData(objMainAcc, "ShowVoucher", AccountType);
            if (dtnew.Rows.Count > 0)
            {
                objClass.sReference1 = dtnew.Rows[0]["sVoucherCode"].ToString();
            }
            else
            {
                objClass.sReference1 = "";
            }
            string AccCode = "";
            if (AccountTitle != "0")
            {
                DataTable dtac = ObjAccTitle.viewData(ObjAccTitle, "ShowAccCode", AccountTitle);
                if (dtac.Rows.Count > 0)
                {
                    AccCode = dtac.Rows[0]["sCode"].ToString();
                    //Response.Redirect("rptGeneralLedger.aspx?AccountID=" + ddlAccountTitle.SelectedValue + "&AccCode=" + AccCode + "&dtFrom=" + txtdtFrom.Text + "&dtTo=" + txtdtToDate.Text + "&vType=" + ddlAccType.SelectedValue);
                }
                else
                {
                     AccCode = "";
                   // Response.Redirect("rptGeneralLedger.aspx?AccountID=" + ddlAccountTitle.SelectedValue + "&AccCode=" + AccCode + "&dtFrom=" + txtdtFrom.Text + "&dtTo=" + txtdtToDate.Text + "&vType=" + ddlAccType.SelectedValue);
                }
            }
            DataTable dt = objClass.viewData(objClass, "ShowGeneralLedgerDet", AccCode);
            dtmain.Columns.Add("Account Code");
            dtmain.Columns.Add("Voucher Date");
            dtmain.Columns.Add("Voucher No");
            dtmain.Columns.Add("sVoucherType");
            dtmain.Columns.Add("Description");
            dtmain.Columns.Add("Debit Amount");
            dtmain.Columns.Add("Credit Amount");
            dtmain.Columns.Add("Balance");
            if (dt.Rows.Count > 0)
            {

                DataTable dt1 = objClass.viewData(objClass, "GeneralLedgerOpeningBal", AccCode);
                if (dt1.Rows.Count > 0)
                {
                    dtmain.Rows.Add(
                                 "",
                                 "",
                                 "",
                                  "",
                                 "Opening Balance",

                                 dt1.Rows[0]["DebitAmount"].ToString(),
                                 dt1.Rows[0]["CreditAmount"].ToString(),
                                 dt1.Rows[0]["nOpeningBal"].ToString()
                                 );


                }
                else
                {
                    dtmain.Rows.Add(
                                    "",
                                    "",
                                    "",
                                     "",
                                    "Opening Balance",
                                    0,
                                    0,
                                    0
                                    );
                }


                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    dtmain.Rows.Add(
                                  dt.Rows[i]["Account Code"].ToString(),
                                  dt.Rows[i]["Voucher Date"].ToString(),
                                  dt.Rows[i]["Voucher No"].ToString(),
                                  dt.Rows[i]["sVoucherType"].ToString(),
                                  dt.Rows[i]["Description"].ToString(),
                                  dt.Rows[i]["nDebitAmt"].ToString(),
                                  dt.Rows[i]["nCreditAmt"].ToString(),
                                  (double.Parse(dtmain.Rows[i]["Balance"].ToString()) + double.Parse(dt.Rows[i]["nCreditAmt"].ToString()) - double.Parse(dt.Rows[i]["nDebitAmt"].ToString())).ToString()
                               );

                }

                DataTable dtBal = objClass.viewData(objClass, "ShowGeneralLedgerBal", AccountTitle);
                if (dtBal.Rows.Count > 0)
                {
                    dtmain.Rows.Add(
                                 "",
                                 "",
                                 "",
                                  "",
                                 "TOTAL RECEIPT",

                                 dtBal.Rows[0]["TotDebit"].ToString(),
                                 dtBal.Rows[0]["TotCredit"].ToString(),
                                 dtBal.Rows[0]["TotBalance"].ToString()
                                 );


                }
                else
                {
                    dtmain.Rows.Add(
                                    "",
                                    "",
                                    "",
                                     "",
                                    "Opening Balance",
                                    0,
                                    0,
                                    0
                                    );
                }

                //GetFormData();

            }


            //GridView1.DataSource = dtmain;
           // GridView1.DataBind();
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
        string AgentName = ddlAccountCashBook.SelectedItem.Text;
        #region get data

        DataTable getdtdata = new DataTable();
        getdtdata = displaySearchGrid(txtdtFrom.Text, txtdtToDate.Text, ddlAccountCashBook.SelectedValue,"0");

        // // // below table for excel table

        getdtdata.Columns.Remove("Account Code");
        //getdtdata.Columns.Remove("nItemID");
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
            var fileName = "CashBook-list-" + DateTime.Now.ToString("yyyy-MM-dd--hh-mm-ss") + ".xlsx";
            var outputDir = Server.MapPath("../Temp/CashBook-list.xlsx");

            ///// // Create the file using the FileInfo object
            var file = new FileInfo(outputDir + fileName);

            ///// // Create the package and make sure you wrap it in a using statement
            using (var package = new ExcelPackage(file))
            {
                /////  // add a new worksheet to the empty workbook
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Cash Book - " + DateTime.Now.ToShortDateString());

                // // clumn width adjustments code
                worksheet.View.FreezePanes(7, 1); //leave header and scrool all rows up and down
                worksheet.Column(1).Width = 5;
                #region

                #region
                worksheet.Column(2).Width = 15;
                worksheet.Column(3).Width = 15;
                worksheet.Column(4).Width = 15;
                worksheet.Column(5).Width = 90;
                worksheet.Column(6).Width = 15;
                worksheet.Column(7).Width = 15;
                worksheet.Column(8).Width = 20;
                

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
               
                #endregion
                ///// //Merging cells and create a center heading for out table
                worksheet.Cells[1, 1].Value = "ALNASA"; // Heading Name
                worksheet.Cells[1, 1].Style.Font.Size = 20;
                worksheet.Cells[3, 1].Style.Font.Size = 15;
                worksheet.Cells[5, 1, 5, 3].Style.Font.Size = 13;

                ///// // MergeCell for gap rows and 15 is number of colums
                //  worksheet.Cells[2, 1, 2, getdtdata.Columns.Count].Merge = true; //Merge columns start and end range
                worksheet.Cells[2, 1, 2, 8].Merge = true;
                worksheet.Cells[4, 1, 4, 8].Merge = true; //Merge columns start and end range

                //////// // ExcelWorksheet.cells[from row, from column, to row, to column].
                // worksheet.Cells[1, 1, 1, getdtdata.Columns.Count].Merge = true; //Merge columns start and end range
                worksheet.Cells[1, 1, 1, 8].Merge = true; //Merge columns start and end range
                worksheet.Cells[1, 1, 1, 8].Style.Font.Bold = true; //Font should be bold
                worksheet.Cells[1, 1, 1, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center; // Aligmnet is center
                worksheet.Cells[1, 1].Style.Font.Color.SetColor(System.Drawing.Color.WhiteSmoke);
                // // //im giving 15 for range the columns for header
                ///////  //Merging cells and create a center heading for out table
                worksheet.Cells[3, 1].Value = "	Statement  Details From : '" + txtdtFrom.Text + "' To: '" + txtdtToDate.Text + "' "; // Heading Name               
                worksheet.Cells[3, 1, 3, 8].Merge = true; //Merge columns start and end range
                worksheet.Cells[3, 1, 3, 8].Style.Font.Bold = true; //Font should be bold
                worksheet.Cells[3, 1, 3, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center; // Aligmnet is center
                worksheet.Cells[3, 1].Style.Font.Color.SetColor(System.Drawing.Color.WhiteSmoke);


                // // // // merging cells and hading 


                ///////  //Merging cells and create a center heading for out table
                worksheet.Cells[4, 1].Value = "	Statement Name : Cash Book "; // Heading Name               
                worksheet.Cells[4, 1, 4, 8].Merge = true; //Merge columns start and end range
                worksheet.Cells[4, 1, 4, 8].Style.Font.Bold = true; //Font should be bold
                worksheet.Cells[4, 1, 4, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center; // Aligmnet is center
                worksheet.Cells[4, 1].Style.Font.Color.SetColor(System.Drawing.Color.WhiteSmoke);

                // // // agent name header
                ///////  //Merging cells and create a center heading for out table
                worksheet.Cells[5, 1].Value = "	Accout Title : '" + AgentName + "' "; // Heading Name               
                worksheet.Cells[5, 1, 5, 8].Merge = true; //Merge columns start and end range
                worksheet.Cells[5, 1, 5, 8].Style.Font.Bold = true; //Font should be bold
                worksheet.Cells[5, 1, 5, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center; // Aligmnet is center
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
                using (var range = worksheet.Cells[6, 1, 6, 8])
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
                    worksheet.Cells[6, 2].Value = "Voucher Date";
                    worksheet.Cells[6, 3].Value = "Voucher No";
                    worksheet.Cells[6, 4].Value = "Voucher Type";
                    worksheet.Cells[6, 5].Value = "Description";
                    worksheet.Cells[6, 6].Value = "Debit Amount";
                    worksheet.Cells[6, 7].Value = "Credit Amount";
                    worksheet.Cells[6, 8].Value = "Balance";
                   
                }
                #endregion
                #region
                int count = 1;
                for (int i = 0; i < getdtdata.Rows.Count; i++)
                {
                    worksheet.Cells["A" + (i + 7)].Value = count;
                    worksheet.Cells["B" + (i + 7)].Value = date(getdtdata.Rows[i][0].ToString());
                    worksheet.Cells["C" + (i + 7)].Value = getdtdata.Rows[i][1].ToString();
                    worksheet.Cells["D" + (i + 7)].Value = getdtdata.Rows[i][2].ToString();
                    worksheet.Cells["E" + (i + 7)].Value = getdtdata.Rows[i][3].ToString();
                    if (worksheet.Cells["E" + (i + 7)].Value == "TOTAL RECEIPT")
                    {
                        worksheet.Cells["A" + (i + 7)].Style.Font.Bold = true;
                        worksheet.Cells["A" + (i + 7)].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        worksheet.Cells["A" + (i + 7)].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Blue);
                        worksheet.Cells["A" + (i + 7)].Style.Font.Color.SetColor(System.Drawing.Color.WhiteSmoke);

                        worksheet.Cells["B" + (i + 7)].Style.Font.Bold = true;
                        worksheet.Cells["B" + (i + 7)].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        worksheet.Cells["B" + (i + 7)].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Blue);
                        worksheet.Cells["B" + (i + 7)].Style.Font.Color.SetColor(System.Drawing.Color.WhiteSmoke);

                        worksheet.Cells["C" + (i + 7)].Style.Font.Bold = true;
                        worksheet.Cells["C" + (i + 7)].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        worksheet.Cells["C" + (i + 7)].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Blue);
                        worksheet.Cells["C" + (i + 7)].Style.Font.Color.SetColor(System.Drawing.Color.WhiteSmoke);

                        worksheet.Cells["D" + (i + 7)].Style.Font.Bold = true;
                        worksheet.Cells["D" + (i + 7)].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        worksheet.Cells["D" + (i + 7)].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Blue);
                        worksheet.Cells["D" + (i + 7)].Style.Font.Color.SetColor(System.Drawing.Color.WhiteSmoke);


                        worksheet.Cells["E" + (i + 7)].Style.Font.Bold = true;
                        worksheet.Cells["E" + (i + 7)].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        worksheet.Cells["E" + (i + 7)].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Blue);
                        worksheet.Cells["E" + (i + 7)].Style.Font.Color.SetColor(System.Drawing.Color.WhiteSmoke);

                        worksheet.Cells["F" + (i + 7)].Style.Font.Bold = true;
                        worksheet.Cells["F" + (i + 7)].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        worksheet.Cells["F" + (i + 7)].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Blue);
                        worksheet.Cells["F" + (i + 7)].Style.Font.Color.SetColor(System.Drawing.Color.WhiteSmoke);

                        worksheet.Cells["G" + (i + 7)].Style.Font.Bold = true;
                        worksheet.Cells["G" + (i + 7)].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        worksheet.Cells["G" + (i + 7)].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Blue);
                        worksheet.Cells["G" + (i + 7)].Style.Font.Color.SetColor(System.Drawing.Color.WhiteSmoke);

                        worksheet.Cells["H" + (i + 7)].Style.Font.Bold = true;
                        worksheet.Cells["H" + (i + 7)].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        worksheet.Cells["H" + (i + 7)].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Blue);
                        worksheet.Cells["H" + (i + 7)].Style.Font.Color.SetColor(System.Drawing.Color.WhiteSmoke);

                    }
                    worksheet.Cells["F" + (i + 7)].Value = getdtdata.Rows[i][4].ToString();
                    worksheet.Cells["G" + (i + 7)].Value = Convert.ToDouble(getdtdata.Rows[i][5].ToString());
                    worksheet.Cells["H" + (i + 7)].Value = Convert.ToDouble(getdtdata.Rows[i][6].ToString());
                    count++;
                }
                #endregion


                package.Save();
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename=Cash Book.xlsx");
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
  
    //protected void btnpdf_Click(object sender, EventArgs e)
    //{
    //    string va = txtFromDate.Text;

    //    string strcreditbalance = string.Empty;
    //    string strdebitbalance = string.Empty;
    //    string strbalance = string.Empty;
    //    Accountledgerb2bdepositrequest actntldgeobjclas = new Accountledgerb2bdepositrequest();
    //    magent_Class objagent2 = new magent_Class();

    //    b2bdepositrequest_Class objClass = new b2bdepositrequest_Class();
    //    DataTable dt2 = objClass.pdftable(objClass, "getagentname", ddlAgent.SelectedValue);
    //    string AgentName = dt2.Rows[0]["sAgencyName"].ToString();

    //    #region get data
    //    actntldgeobjclas.dtDateOfDeposit = validation.dateToText(txtFromDate.Text);
    //    actntldgeobjclas.sAccountNo = validation.dateToText(txtToDate.Text);

    //    DataTable creditdt = actntldgeobjclas.viewData(actntldgeobjclas, "getcreditbalAdminAccountLedgerDrCrBalance", ddlAgent.SelectedValue); // Session["eid"].ToString());
    //                                                                                                                                           //  DataTable totalbaldt = objClass.viewData(objClass, "AgentBalance", HttpContext.Current.Session["uid"].ToString());

    //    if (creditdt.Rows.Count > 0)
    //    {
    //        for (int i = 0; i < creditdt.Rows.Count; i++)
    //        {
    //            //  lblTotCredit.Text = creditdt.Rows[0]["credit"].ToString();
    //            strcreditbalance = creditdt.Rows[0]["credit"].ToString();
    //            strdebitbalance = creditdt.Rows[0]["debit"].ToString();
    //            strbalance = creditdt.Rows[0]["nBalance"].ToString();
    //        }
    //    }
    //    DataTable getdtdata = new DataTable();
    //    getdtdata = displaySearchGrid(txtFromDate.Text, txtToDate.Text, ddlAgent.SelectedValue);

    //    // // // below table for excel table

    //    getdtdata.Columns.Remove("nUserID");
    //    getdtdata.Columns.Remove("nUserTypeID");
    //    DataRow dr = getdtdata.NewRow();
    //    dr["description"] = "Total";
    //    dr["nCreditAmount"] = Convert.ToDouble(strcreditbalance.ToString());
    //    dr["nDebitAmount"] = Convert.ToDouble(strdebitbalance.ToString());
    //    dr["nBalance"] = Convert.ToDouble(strbalance.ToString());
    //    getdtdata.Rows.Add(dr);


    //    #endregion

    //    for (int x = 0; x < getdtdata.Rows.Count; x++)
    //    {
    //        getdtdata.Rows[x]["dtDate"] = date(getdtdata.Rows[x]["dtDate"].ToString());

    //    }

    //    string htmlbody = ExportDatatableToHtml(getdtdata);



    //    StringReader sr = new StringReader(htmlbody.ToString());


    //    //  //pdfGridView2.DataSource = dt;
    //    //  //pdfGridView2.DataBind();
    //    //      Response.ContentType = "application/pdf";
    //    //      Response.AddHeader("content-disposition", "attachment;filename=onlinepayment_list.pdf");
    //    //      Response.Cache.SetCacheability(HttpCacheability.NoCache);
    //    //      StringWriter sw = new StringWriter();
    //    //      HtmlTextWriter hw = new HtmlTextWriter(sw);
    //    //      StringBuilder sb = new StringBuilder();

    //    ////  pdfGridView2.RenderControl(hw);
    //    //      StringReader sr = new StringReader(sw.ToString());
    //    //      Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
    //    //      HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
    //    //      PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
    //    //      pdfDoc.Open();
    //    //      htmlparser.Parse(sr);
    //    //      pdfDoc.Close();
    //    //      Response.Write(pdfDoc);
    //    //      Response.End();

    //    Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
    //    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
    //    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
    //    pdfDoc.Open();
    //    htmlparser.Parse(sr);
    //    pdfDoc.Close();
    //    Response.ContentType = "application/pdf";
    //    Response.AddHeader("content-disposition", "attachment;filename=Cash_A/C Ledger.pdf");
    //    Response.Cache.SetCacheability(HttpCacheability.NoCache);
    //    Response.Write(pdfDoc);
    //    Response.End();
    //}
    //protected string ExportDatatableToHtml(DataTable dt)
    //{
    //    string AgentName = ddlItemName.SelectedItem.Text;
    //    string dtrequestfrom = string.Empty;
    //    string dtrquestto = string.Empty;
    //    if (txtdtFrom.Text != "")
    //    {
    //        dtrequestfrom = txtdtFrom.Text.Trim();
    //        dtrequestfrom = dtrequestfrom.Replace("/", "-");
    //        dtrquestto = txtdtToDate.Text.Trim();
    //        dtrquestto = dtrquestto.Replace("/", "-");
    //    }
    //    StringBuilder strHTMLBuilder = new StringBuilder();
    //    strHTMLBuilder.Append("<!DOCTYPE html><html>");
    //    if (txtdtFrom.Text != "")
    //    {
    //        strHTMLBuilder.Append("<head style='background: #1abc9c;border-style: groove;' ><h1 style=' text-align: center;font-style: Latin;'>Supplier Name: FlyZone Travels</h1><br><p style='color: gray;text-align: center'> Ledger Details from :-" + dtrequestfrom + " To :" + dtrquestto + "</p><br><p style='color: gray;text-align: center'> Ledger Details :Agent Cash Account Ledger Statement</p><br><p style='color: gray;text-align: center'> Agency Name :- " + AgentName + "</p><br>");

    //    }
    //    else
    //    {
    //        strHTMLBuilder.Append("<head style='background: #1abc9c;border-style: groove;' ><h1 style=' text-align: center;font-style: Latin;'>Supplier Name: FlyZone Travels</h1><p style='color: gray;text-align: center'> Ledger Name :-Agent Cash Account Ledger Statement</p><br><p style='color: gray;text-align: center'> Agency Name :- " + AgentName + "</p><br>");

    //    }
    //    strHTMLBuilder.Append("</head>");
    //    strHTMLBuilder.Append("<body style='background: green;'>");
    //    //  strHTMLBuilder.Append(@"<table border=\'1px\' cellpadding=\'1\' cel99265lspacing=\'1\' bgcolor=\'lightyellow\' style=\'font-family:Garamond; font-size:smaller\'>");
    //    // strHTMLBuilder.Append(@"<table border=1px cellpadding=1px celspacing=1px bgcolor=lightyellow style=font-family:Garamond; font-size:smaller'>");

    //    strHTMLBuilder.Append(@"<table border='1' cellpadding='1' >");

    //    strHTMLBuilder.Append("<tr>");
    //    int count = 0;
    //    // // below code for change the table header
    //    dt.Columns["dtDate"].ColumnName = "Invoice Date";
    //    dt.Columns["refNo"].ColumnName = "Invoice No";
    //    dt.Columns["sAgencyName"].ColumnName = "Vendor / Customer";
    //    dt.Columns["description"].ColumnName = "Item Name";
    //    dt.Columns["nCreditAmount"].ColumnName = "P. Qty";
    //    dt.Columns["nDebitAmount"].ColumnName = "P. Rate";
    //    dt.Columns["nBalance"].ColumnName = "S. Qty";
    //    dt.Columns["nBalance"].ColumnName = "S. Rate";
    //    dt.Columns["nBalance"].ColumnName = "Balance Qty";
    //    dt.Columns["nBalance"].ColumnName = "G Total";

    //    foreach (DataColumn myColumn in dt.Columns)
    //    {
    //        if (count == 3)
    //        {
    //            strHTMLBuilder.Append("<td style='font-size: 10px; width:150px; text-align:center;'>");
    //            strHTMLBuilder.Append(myColumn.ColumnName);
    //            strHTMLBuilder.Append("</td>");
    //        }
    //        else
    //        {
    //            strHTMLBuilder.Append("<td style='font-size: 10px; text-align:center;'>");
    //            strHTMLBuilder.Append(myColumn.ColumnName);
    //            strHTMLBuilder.Append("</td>");
    //        }
    //        count++;

    //    }
    //    strHTMLBuilder.Append("</tr>");


    //    foreach (DataRow myRow in dt.Rows)
    //    {

    //        strHTMLBuilder.Append("<tr >");
    //        foreach (DataColumn myColumn in dt.Columns)
    //        {
    //            strHTMLBuilder.Append("<td style='font-size: 10px; text-align:center;' >");
    //            strHTMLBuilder.Append(myRow[myColumn.ColumnName].ToString());
    //            strHTMLBuilder.Append("</td>");

    //        }
    //        strHTMLBuilder.Append("</tr>");
    //    }

    //    //Close tags.  
    //    strHTMLBuilder.Append("</table>");
    //    strHTMLBuilder.Append("</body>");
    //    strHTMLBuilder.Append("</html>");

    //    string Htmltext = strHTMLBuilder.ToString();

    //    return Htmltext;

    //}
    //protected void btnsendmail_Click(object sender, EventArgs e)
    //{
    //    string vto = txtTo.Text;
    //    string vcc = txtCC.Text;
    //    string vbcc = txtBCC.Text;
    //    string vSubject = txtSub.Text;
    //    string vBody = txtBody.Text;
    //    lblerrormsg.Text = "";
    //    lblerrormsg.Visible = false;
    //    try
    //    {
    //        if (rbexcel.Checked)
    //        {
    //            #region
    //            string va = txtFromDate.Text;
    //            b2bdepositrequest_Class objClass = new b2bdepositrequest_Class();
    //            magent_Class objagent2 = new magent_Class();


    //            b2bdepositrequest_Class b2bobjClass = new b2bdepositrequest_Class();
    //            DataTable dt2 = b2bobjClass.pdftable(b2bobjClass, "getagentname", ddlAgent.SelectedValue);
    //            string AgentName = dt2.Rows[0]["sAgencyName"].ToString();

    //            DataTable getdtdata = new DataTable();
    //            #region getting data
    //            string strcreditbalance = string.Empty;
    //            string strdebitbalance = string.Empty;
    //            string strbalance = string.Empty;
    //            Accountledgerb2bdepositrequest actntldgeobjclas = new Accountledgerb2bdepositrequest();


    //            #region get data
    //            actntldgeobjclas.dtDateOfDeposit = validation.dateToText(txtFromDate.Text);
    //            actntldgeobjclas.sAccountNo = validation.dateToText(txtToDate.Text);

    //            DataTable creditdt = actntldgeobjclas.viewData(actntldgeobjclas, "getcreditbalAdminAccountLedgerDrCrBalance", ddlAgent.SelectedValue); // Session["eid"].ToString());
    //                                                                                                                                                   //  DataTable totalbaldt = objClass.viewData(objClass, "AgentBalance", HttpContext.Current.Session["uid"].ToString());

    //            if (creditdt.Rows.Count > 0)
    //            {
    //                for (int i = 0; i < creditdt.Rows.Count; i++)
    //                {
    //                    //  lblTotCredit.Text = creditdt.Rows[0]["credit"].ToString();
    //                    strcreditbalance = creditdt.Rows[0]["credit"].ToString();
    //                    strdebitbalance = creditdt.Rows[0]["debit"].ToString();
    //                    strbalance = creditdt.Rows[0]["nBalance"].ToString();
    //                }
    //            }

    //            getdtdata = displaySearchGrid(txtFromDate.Text, txtToDate.Text, ddlAgent.SelectedValue);

    //            // // // below table for excel table

    //            getdtdata.Columns.Remove("nUserID");
    //            getdtdata.Columns.Remove("nUserTypeID");
    //            DataRow dr = getdtdata.NewRow();
    //            dr["description"] = "Total";
    //            dr["nCreditAmount"] = Convert.ToDouble(strcreditbalance.ToString());
    //            dr["nDebitAmount"] = Convert.ToDouble(strdebitbalance.ToString());
    //            dr["nBalance"] = Convert.ToDouble(strbalance.ToString());
    //            getdtdata.Rows.Add(dr);


    //            #endregion
    //            #endregion

    //            var fileName = "Hotel-statement-" + DateTime.Now.ToString("yyyy-MM-dd--hh-mm-ss") + ".xlsx";
    //            // var fileName= "list" + DateTime.Today.ToFileTime() + ".xlsx";
    //            var outputDir = Server.MapPath("../Temp/123.xlsx");
    //            ///// // Create the file using the FileInfo object
    //            var file = new FileInfo(outputDir + fileName);
    //            string filepath = outputDir + fileName;
    //            lnkAttachment.Text = filepath;
    //            #region start code


    //            ///// // Create the package and make sure you wrap it in a using statement
    //            using (var package = new ExcelPackage(file))
    //            {
    //                /////  // add a new worksheet to the empty workbook
    //                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Accountledger_statement - " + DateTime.Now.ToShortDateString());

    //                // // clumn width adjustments code
    //                worksheet.View.FreezePanes(7, 1); //leave header and scrool all rows up and down

    //                #region

    //                #region
    //                worksheet.Column(2).Width = 15;
    //                worksheet.Column(3).Width = 20;
    //                worksheet.Column(4).Width = 25;
    //                worksheet.Column(5).Width = 45;
    //                worksheet.Column(6).Width = 10;
    //                worksheet.Column(7).Width = 15;
    //                worksheet.Column(8).Width = 15;
    //                #endregion
    //                #endregion
    //                #region set center the row data start
    //                worksheet.Column(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
    //                worksheet.Column(2).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
    //                worksheet.Column(3).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
    //                worksheet.Column(4).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
    //                worksheet.Column(5).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
    //                worksheet.Column(6).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
    //                worksheet.Column(7).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
    //                worksheet.Column(7).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
    //                #endregion
    //                ///// //Merging cells and create a center heading for out table
    //                worksheet.Cells[1, 1].Value = "Flyzone Travel"; // Heading Name
    //                worksheet.Cells[1, 1].Style.Font.Size = 20;
    //                worksheet.Cells[3, 1].Style.Font.Size = 15;
    //                worksheet.Cells[5, 1, 5, 3].Style.Font.Size = 13;

    //                ///// // MergeCell for gap rows and 15 is number of colums
    //                //  worksheet.Cells[2, 1, 2, getdtdata.Columns.Count].Merge = true; //Merge columns start and end range
    //                worksheet.Cells[2, 1, 2, 8].Merge = true;
    //                worksheet.Cells[4, 1, 4, 8].Merge = true; //Merge columns start and end range

    //                //////// // ExcelWorksheet.cells[from row, from column, to row, to column].
    //                // worksheet.Cells[1, 1, 1, getdtdata.Columns.Count].Merge = true; //Merge columns start and end range
    //                worksheet.Cells[1, 1, 1, 8].Merge = true; //Merge columns start and end range
    //                worksheet.Cells[1, 1, 1, 8].Style.Font.Bold = true; //Font should be bold
    //                worksheet.Cells[1, 1, 1, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center; // Aligmnet is center
    //                worksheet.Cells[1, 1].Style.Font.Color.SetColor(System.Drawing.Color.WhiteSmoke);
    //                // // //im giving 15 for range the columns for header
    //                ///////  //Merging cells and create a center heading for out table
    //                worksheet.Cells[3, 1].Value = "	Statement  Deatails From : '" + txtFromDate.Text + "' To: '" + txtToDate.Text + "' "; // Heading Name               
    //                worksheet.Cells[3, 1, 3, 8].Merge = true; //Merge columns start and end range
    //                worksheet.Cells[3, 1, 3, 8].Style.Font.Bold = true; //Font should be bold
    //                worksheet.Cells[3, 1, 3, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center; // Aligmnet is center
    //                worksheet.Cells[3, 1].Style.Font.Color.SetColor(System.Drawing.Color.WhiteSmoke);


    //                // // // // merging cells and hading 


    //                ///////  //Merging cells and create a center heading for out table
    //                worksheet.Cells[4, 1].Value = "	Statement Name :Agent Cash  Account Ledger Statament "; // Heading Name               
    //                worksheet.Cells[4, 1, 4, 8].Merge = true; //Merge columns start and end range
    //                worksheet.Cells[4, 1, 4, 8].Style.Font.Bold = true; //Font should be bold
    //                worksheet.Cells[4, 1, 4, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center; // Aligmnet is center
    //                worksheet.Cells[4, 1].Style.Font.Color.SetColor(System.Drawing.Color.WhiteSmoke);

    //                // // // agent name header
    //                ///////  //Merging cells and create a center heading for out table
    //                worksheet.Cells[5, 1].Value = "	Agency Name : '" + AgentName + "' "; // Heading Name               
    //                worksheet.Cells[5, 1, 5, 8].Merge = true; //Merge columns start and end range
    //                worksheet.Cells[5, 1, 5, 8].Style.Font.Bold = true; //Font should be bold
    //                worksheet.Cells[5, 1, 5, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center; // Aligmnet is center
    //                worksheet.Cells[5, 1].Style.Font.Color.SetColor(System.Drawing.Color.WhiteSmoke);


    //                //////  //Setting the background color of header cells to Gray
    //                var fill = worksheet.Cells[1, 1].Style.Fill;
    //                fill.PatternType = ExcelFillStyle.Solid;
    //                fill.BackgroundColor.SetColor(System.Drawing.Color.Silver);

    //                var fill1 = worksheet.Cells[3, 1].Style.Fill;
    //                fill1.PatternType = ExcelFillStyle.Solid;
    //                fill1.BackgroundColor.SetColor(System.Drawing.Color.LightSeaGreen);


    //                var fill2 = worksheet.Cells[4, 1].Style.Fill;
    //                fill2.PatternType = ExcelFillStyle.Solid;
    //                fill2.BackgroundColor.SetColor(System.Drawing.Color.LightSeaGreen);


    //                var fill3 = worksheet.Cells[5, 1].Style.Fill;
    //                fill3.PatternType = ExcelFillStyle.Solid;
    //                fill3.BackgroundColor.SetColor(System.Drawing.Color.LightSeaGreen);

    //                ////////////// //Ok now format the first row of the heade, but only the first two columns;
    //                using (var range = worksheet.Cells[6, 1, 6, 8])
    //                {
    //                    range.Style.Font.Bold = true;
    //                    range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
    //                    range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Blue);
    //                    range.Style.Font.Color.SetColor(System.Drawing.Color.WhiteSmoke);

    //                    range.Style.ShrinkToFit = false;
    //                }
    //                #region
    //                for (int i = 0; i < getdtdata.Columns.Count; i++)
    //                {
    //                    worksheet.Cells[6, 1].Value = "Sr No";
    //                    worksheet.Cells[6, 2].Value = "Date";
    //                    worksheet.Cells[6, 3].Value = "Ref No";
    //                    worksheet.Cells[6, 4].Value = "Agency Name";
    //                    worksheet.Cells[6, 5].Value = "Description";
    //                    worksheet.Cells[6, 6].Value = "Credit Amount";
    //                    worksheet.Cells[6, 7].Value = "Debit Amount";
    //                    worksheet.Cells[6, 8].Value = "Balance";

    //                }
    //                #endregion
    //                #region
    //                int count = 1;
    //                for (int i = 0; i < getdtdata.Rows.Count; i++)
    //                {
    //                    worksheet.Cells["A" + (i + 7)].Value = count;
    //                    worksheet.Cells["B" + (i + 7)].Value = date(getdtdata.Rows[i][0].ToString());
    //                    worksheet.Cells["C" + (i + 7)].Value = getdtdata.Rows[i][1].ToString();
    //                    worksheet.Cells["D" + (i + 7)].Value = getdtdata.Rows[i][2].ToString();
    //                    worksheet.Cells["E" + (i + 7)].Value = getdtdata.Rows[i][3].ToString();

    //                    worksheet.Cells["F" + (i + 7)].Value = Convert.ToDouble(getdtdata.Rows[i][4].ToString());
    //                    worksheet.Cells["G" + (i + 7)].Value = Convert.ToDouble(getdtdata.Rows[i][5].ToString());
    //                    worksheet.Cells["H" + (i + 7)].Value = Convert.ToDouble(getdtdata.Rows[i][6].ToString());
    //                    //worksheet.Cells["I" + (i + 7)].Value = Convert.ToDouble( getdtdata.Rows[i][7].ToString());

    //                    count++;
    //                }
    //                #endregion


    //                #endregion
    //                package.Save();
    //                Response.Clear();
    //                //  Response.Buffer = true;
    //                //   Response.Charset = "";
    //                //  Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
    //                //  Response.AddHeader("content-disposition", "attachment;filename=Flightlist.xlsx");
    //                objsendmail.Send(txtTo.Text, txtCC.Text, txtBCC.Text, txtSub.Text, txtBody.Text, lnkAttachment.Text);
    //                //   Response.Write("<script LANGUAGE='JavaScript' >alert('Email has been sent successfully')</script>");
    //                ScriptManager.RegisterStartupScript(this, this.GetType(), "HidePopup", "$('#exampleModalLong').modal('show')", true);

    //                #region
    //                //MailMessage mm = new MailMessage("webflyzonet@gmail.com", vto);

    //                //mm = new MailMessage("webflyzonet@gmail.com", vto);
    //                //mm.Subject = "AccountLedger PDF";
    //                //mm.Body = "AccountLedger PDF Attachment";
    //                //mm.Attachments.Add(new Attachment(filepath, "application/vnd.ms-excel"));
    //                //mm.IsBodyHtml = true;

    //                //sc.Host = "smtp.gmail.com";
    //                //sc.EnableSsl = true;
    //                //System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
    //                //NetworkCred.UserName = "webflyzonet@gmail.com";
    //                //NetworkCred.Password = "Khan#1w2123";
    //                //sc.UseDefaultCredentials = true;
    //                //sc.Credentials = NetworkCred;
    //                //sc.Port = 587;
    //                //sc.Send(mm);
    //                #endregion
    //                //using (MemoryStream MyMemoryStream = new MemoryStream())
    //                //{
    //                //    package.SaveAs(MyMemoryStream);
    //                //    MyMemoryStream.WriteTo(Response.OutputStream);
    //                //    Response.Flush();
    //                //    Response.End();
    //                //}
    //                #endregion
    //            }

    //        }
    //        if (rbpdf.Checked)
    //        {
    //            #region
    //            string va = txtFromDate.Text;
    //            string strcreditbalance = string.Empty;
    //            string strdebitbalance = string.Empty;
    //            string strbalance = string.Empty;
    //            Accountledgerb2bdepositrequest actntldgeobjclas = new Accountledgerb2bdepositrequest();

    //            magent_Class objagent2 = new magent_Class();


    //            b2bdepositrequest_Class objClass = new b2bdepositrequest_Class();
    //            DataTable dt2 = objClass.pdftable(objClass, "getagentname", ddlAgent.SelectedValue);
    //            string AgentName = dt2.Rows[0]["sAgencyName"].ToString();

    //            #region get data
    //            actntldgeobjclas.dtDateOfDeposit = validation.dateToText(txtFromDate.Text);
    //            actntldgeobjclas.sAccountNo = validation.dateToText(txtToDate.Text);

    //            DataTable creditdt = actntldgeobjclas.viewData(actntldgeobjclas, "getcreditbalAdminAccountLedgerDrCrBalance", ddlAgent.SelectedValue); // Session["eid"].ToString());
    //                                                                                                                                                   //  DataTable totalbaldt = objClass.viewData(objClass, "AgentBalance", HttpContext.Current.Session["uid"].ToString());

    //            if (creditdt.Rows.Count > 0)
    //            {
    //                for (int i = 0; i < creditdt.Rows.Count; i++)
    //                {
    //                    //  lblTotCredit.Text = creditdt.Rows[0]["credit"].ToString();
    //                    strcreditbalance = creditdt.Rows[0]["credit"].ToString();
    //                    strdebitbalance = creditdt.Rows[0]["debit"].ToString();
    //                    strbalance = creditdt.Rows[0]["nBalance"].ToString();
    //                }
    //            }
    //            DataTable getdtdata = new DataTable();
    //            getdtdata = displaySearchGrid(txtFromDate.Text, txtToDate.Text, ddlAgent.SelectedValue);

    //            // // // below table for excel table

    //            getdtdata.Columns.Remove("nUserID");
    //            getdtdata.Columns.Remove("nUserTypeID");
    //            DataRow dr = getdtdata.NewRow();
    //            dr["description"] = "Total";
    //            dr["nCreditAmount"] = Convert.ToDouble(strcreditbalance.ToString());
    //            dr["nDebitAmount"] = Convert.ToDouble(strdebitbalance.ToString());
    //            dr["nBalance"] = Convert.ToDouble(strbalance.ToString());
    //            getdtdata.Rows.Add(dr);


    //            #endregion

    //            for (int x = 0; x < getdtdata.Rows.Count; x++)
    //            {
    //                getdtdata.Rows[x]["dtDate"] = date(getdtdata.Rows[x]["dtDate"].ToString());

    //            }


    //            string htmlbody = ExportDatatableToHtml(getdtdata);
    //            //  StringReader sr = new StringReader(htmlbody.ToString());

    //            using (StringWriter sw = new StringWriter())
    //            {
    //                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
    //                {
    //                    // GridView1.RenderControl(hw);
    //                    StringReader sr = new StringReader(htmlbody.ToString());
    //                    Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
    //                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
    //                    using (MemoryStream memoryStream = new MemoryStream())
    //                    {
    //                        PdfWriter.GetInstance(pdfDoc, memoryStream);
    //                        pdfDoc.Open();
    //                        htmlparser.Parse(sr);
    //                        pdfDoc.Close();
    //                        byte[] bytes = memoryStream.ToArray();
    //                        memoryStream.Close();

    //                        MailMessage mm = new MailMessage("webflyzonet@gmail.com", vto);
    //                        mm.Subject = "Flight ticket PDF";
    //                        mm.Body = "Flight ticket PDF Attachment";
    //                        mm.Attachments.Add(new Attachment(new MemoryStream(bytes), "Cash Account Ledger.pdf"));
    //                        mm.IsBodyHtml = true;

    //                        sc.Host = "smtp.gmail.com";
    //                        sc.EnableSsl = true;
    //                        System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
    //                        NetworkCred.UserName = "webflyzonet@gmail.com";
    //                        NetworkCred.Password = "Khan#1w2123";
    //                        sc.UseDefaultCredentials = true;
    //                        sc.Credentials = NetworkCred;
    //                        sc.Port = 587;
    //                        sc.Send(mm);
    //                        //   Response.Write("<script LANGUAGE='JavaScript' >alert('Email has been sent successfully')</script>");
    //                        ScriptManager.RegisterStartupScript(this, this.GetType(), "HidePopup", "$('#exampleModalLong').modal('show')", true);

    //                    }
    //                }
    //            }
    //            #endregion
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        //throw ex;
    //        lblerrormsg.Visible = true;
    //        lblerrormsg.Text = ex.Message.ToString();
    //        ScriptManager.RegisterStartupScript(this, this.GetType(), "HidePopup", "$('#exampleModalLong').modal('show')", true);

    //    }
    //    txtTo.Text = "";
    //    txtCC.Text = "";
    //    txtBCC.Text = "";
    //    txtSub.Text = "";
    //    txtBody.Text = "";
    //    rbexcel.Checked = false;
    //    rbpdf.Checked = false;

    //}

    public class list
    {

        public string VoucherDate { get; set; }
        public string VoucherNo { get; set; }
        public string VoucherType { get; set; }
        public string Description { get; set; }
        public string DebitAmount { get; set; }
        public string CreditAmount { get; set; }
        public string Balance { get; set; }
       
    }

    public class mpagemasterlist
    {
        public List<list> mpagemasterobjlist { get; set; }
    }
}
