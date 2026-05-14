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
using System.Web.Script.Serialization;

public partial class tacc_journal_voucher_list : System.Web.UI.Page
{
    static tacc_journal_voucher_Class objClass = new tacc_journal_voucher_Class();
    static tacc_journal_voucherdet_Class objClassDet = new tacc_journal_voucherdet_Class();
    muser_Class objUser = new muser_Class();
    mlocation_Class objLocation = new mlocation_Class();
    tvisadet_Class objClassGen = new tvisadet_Class();
   
    static mmain_account_Class objAccountCode = new mmain_account_Class();
    mcurrency_Class objCurrency = new mcurrency_Class();
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
                Session["tacc_journal_voucher_list"] = aa;
                objLocation.ddlOperation(objLocation, "Show", "", ddlLocation);
                objAccountCode.ddlOperation(objAccountCode, "ShowddlAccount", "", ddlAccountCodeID);
                objAccountCode.ddlOperation(objAccountCode, "ShowddlAccount", "", ddlAccountType);
                objCurrency.ddlOperation(objCurrency, "Show", "", ddlCurrencyID);

                txttJournalVoucher.Text = validation.fillDate();
                Voucher_Generate();
                fillUser();
                
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
    public void fillUser()
    {
        DataTable dt = objUser.viewData(objUser, "show", Session["uid"].ToString());
        if (dt.Rows.Count > 0)
        {
            //   txtAmendedby.Text = dt.Rows[0][3].ToString();
            txtPostedby.Text = dt.Rows[0][3].ToString();
        }
    }
    public void Page_PreRender(object sender, EventArgs e)
    {
        ViewState["tacc_journal_voucher_list"] = Session["tacc_journal_voucher_list"];
        viewstate = Session["tacc_journal_voucher_list"].ToString();
    }

    [WebMethod]
    public static mpagemasterlist loaddata(string fromdate, string todate, string Reportfor, string AgentID)
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
            objClass.StartDate = validation.dateToText(fromdate);
            objClass.EndDate = validation.dateToText(todate);
            dt = objClass.Tabledata(objClass, "ShowGrid", "");
            
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                magentobj = new list();
                magentobj.JournalVoucherNo = dt.Rows[i]["sJournalVoucherNo"].ToString();
                magentobj.dtJournalVoucher =validation.TextToDate(dt.Rows[i]["dtJournalVoucher"].ToString());
                magentobj.VoucherType = dt.Rows[i]["sVoucherType"].ToString();
                magentobj.Postedby = dt.Rows[i]["sPostedby"].ToString();
                magentobj.Amendedby = dt.Rows[i]["sAmendedby"].ToString();
                magentobj.VoucherAmount = dt.Rows[i]["TotAmount"].ToString();
                magentobj.VoucherTypeID = dt.Rows[i]["nVoucherTypeID"].ToString();
                magentobj.JournalVoucherID = dt.Rows[i]["nJournalVoucerID"].ToString();
                magentobj.Location = dt.Rows[i]["nLocationID"].ToString();
                magentobj.AccountType = dt.Rows[i]["nAccountTypeID"].ToString();
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
    public static mpagemasterlist loaddetdata(string AccountLedgerID)
    {
        list magentobjnew = new list();
        mpagemasterlist mainlist = new mpagemasterlist();
        mainlist.mpagemasterobjlistnew  = new List<list>();
        DataTable dtnew = new DataTable();
        try
        {
            dtnew = objClassDet.Tabledata(objClassDet, "ShowGrid", AccountLedgerID);

            if (dtnew.Rows.Count > 0)
            {
                for (int i = 0; i < dtnew.Rows.Count; i++)
                {
                    magentobjnew = new list();
                    magentobjnew.AccountCode = dtnew.Rows[i]["sAccountTitle"].ToString();
                    magentobjnew.AccountCodeID = dtnew.Rows[i]["nAccountCodeID"].ToString();
                    magentobjnew.Description = dtnew.Rows[i]["sDescription"].ToString();
                    magentobjnew.CurrencyID = dtnew.Rows[i]["nCurrencyID"].ToString();
                    magentobjnew.Currency = dtnew.Rows[i]["sCurrency"].ToString();
                    magentobjnew.Amount = dtnew.Rows[i]["nAmount"].ToString();
                    magentobjnew.LocalAmount = dtnew.Rows[i]["nLocalAmount"].ToString();
                    magentobjnew.Rate = dtnew.Rows[i]["nRate"].ToString();
                    magentobjnew.Remarks = dtnew.Rows[i]["sRemarks"].ToString();
                    magentobjnew.JournalVoucherDetID = dtnew.Rows[i]["nJournalVoucherDetID"].ToString();
                    mainlist.mpagemasterobjlistnew.Add(magentobjnew);
                }
            }       
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return mainlist;
    }
    [WebMethod]
    public static string AddJournalVoucher(list list)
    {
        string msg = "";
        try
        {
            if (HttpContext.Current.Session["tacc_journal_voucher_list"].ToString() == viewstate)
            {
                para(list);
                // //  assign objects start
                var abc = objClass.User_Operation(objClass, "add");
                var strArr = abc.Split(',');
                if (strArr[0] == "1")
                {
                    string VoucherID = strArr[2].ToString();
                    //Journal Voucher Det
                    paraDet(list);
                    objClassDet.nJournalVoucherID = VoucherID;
                    var xyz = objClassDet.User_Operation(objClassDet, "add");
                }

                string val1 = strArr[0];
                if (val1 == "1")
                {
                    msg = "1";
                }
                else
                {
                    msg = abc.ToString();
                }
            }
        }
        catch (Exception ex)
        {
            msg = ex.Message.ToString();
        }
        finally
        {
        }
        return msg;
    }
    [WebMethod]
    public static string UpdateJournalVoucher(list list)
    {
        string msg = "";
        try
        {
            if (HttpContext.Current.Session["tacc_journal_voucher_list"].ToString() == viewstate)
            {
                para(list);
                objClass.nJournalVoucerID = list.JournalVoucherID;
                var abc = objClass.User_Operation(objClass, "edit");

                paraDet(list);
                objClassDet.nJournalVoucherID = list.JournalVoucherID;
                objClassDet.nJournalVoucherDetID = list.JournalVoucherDetID;
                var abc1 = objClassDet.User_Operation(objClassDet, "edit");
                 //  valobj.showMsg(abc, lblmsg);
                string[] values = abc.Split(',');
                string val1 = values[0];
                if (val1 == "1")
                {
                    msg = "1";
                }
                else
                {
                    msg = abc.ToString();
                }

            }

        }
        catch (Exception ex)
        {
            msg = ex.Message.ToString();
        }
        return msg;
    }
    [WebMethod]
    public static string DeleteVoucher(string AccountLedgerID)
    {
        string msg = "";
        try
        {
            objClass.nJournalVoucerID = AccountLedgerID;
            var vres = objClass.User_Operation(objClass, "DeActive");
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
    public static string para(list list)
    {
        objClass.sJournalVoucherNo = validation.stringToDBString(list.JournalVoucherNo);
        objClass.nVoucherTypeID = list.VoucherType;
        objClass.dtJournalVoucher = validation.dateToText(list.dtJournalVoucher);
        objClass.nAccountTypeID = list.AccountType;
        //  objClass.nStatusID = ddlStatusID.SelectedValue;
        objClass.sPostedby = validation.stringToDBString(list.Postedby);
        //  objClass.sAmendedby = validation.stringToDBString(txtAmendedby.Text.Trim());
        objClass.nLocationID = list.Location;
        return list.ToString();
    }
    public static string paraDet(list list)
    {
        //objClassDet.nJournalVoucherID = Session["eid"].ToString();
        objClassDet.nAccountCodeID = list.AccountCode;
        //objClassDet.sAccountTitle = validation.stringToDBString(txtAccountTitle.Text.Trim());
        //EventArgs e = new EventArgs();
        //ddlAccountCodeID_SelectedIndexChanged(this, e);
        // objClassDet.nBalance = txtBalance.Text.Trim();
        objClassDet.sDescription = validation.stringToDBString(list.Description);
        objClassDet.nCurrencyID = list.CurrencyID;
        objClassDet.nRate = list.Rate;
        objClassDet.nAmount = list.VoucherAmount;
        objClassDet.nLocalAmount = list.LocalAmount;
        objClassDet.nJobID = "0";
        objClassDet.sRemarks = validation.stringToDBString(list.Remarks);
        return list.ToString();
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
            var fileName = "JournalVoucher-" + DateTime.Now.ToString("yyyy-MM-dd--hh-mm-ss") + ".xlsx";
            var outputDir = Server.MapPath("../Temp/JournalVoucher.xlsx");

            ///// // Create the file using the FileInfo object
            var file = new FileInfo(outputDir + fileName);

            ///// // Create the package and make sure you wrap it in a using statement
            using (var package = new ExcelPackage(file))
            {
                /////  // add a new worksheet to the empty workbook
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("JournalVoucher - " + DateTime.Now.ToShortDateString());

                // // clumn width adjustments code
                worksheet.View.FreezePanes(7, 1); //leave header and scrool all rows up and down
                worksheet.Column(1).Width = 5;
                #region

                #region
                worksheet.Column(2).Width = 15;
                worksheet.Column(3).Width = 15;
                worksheet.Column(4).Width = 40;
                worksheet.Column(5).Width = 20;
                worksheet.Column(6).Width = 20;
                worksheet.Column(7).Width = 20;


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

                #endregion
                ///// //Merging cells and create a center heading for out table
                worksheet.Cells[1, 1].Value = "ALNASA"; // Heading Name
                worksheet.Cells[1, 1].Style.Font.Size = 20;
                worksheet.Cells[3, 1].Style.Font.Size = 15;
                worksheet.Cells[5, 1, 5, 3].Style.Font.Size = 13;

                ///// // MergeCell for gap rows and 15 is number of colums
                //  worksheet.Cells[2, 1, 2, getdtdata.Columns.Count].Merge = true; //Merge columns start and end range
                worksheet.Cells[2, 1, 2, 7].Merge = true;
                worksheet.Cells[4, 1, 4, 7].Merge = true; //Merge columns start and end range

                //////// // ExcelWorksheet.cells[from row, from column, to row, to column].
                // worksheet.Cells[1, 1, 1, getdtdata.Columns.Count].Merge = true; //Merge columns start and end range
                worksheet.Cells[1, 1, 1, 7].Merge = true; //Merge columns start and end range
                worksheet.Cells[1, 1, 1, 7].Style.Font.Bold = true; //Font should be bold
                worksheet.Cells[1, 1, 1, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center; // Aligmnet is center
                worksheet.Cells[1, 1].Style.Font.Color.SetColor(System.Drawing.Color.WhiteSmoke);
                // // //im giving 15 for range the columns for header
                ///////  //Merging cells and create a center heading for out table
                worksheet.Cells[3, 1].Value = "	Statement  Details From : '" + txttLastPurchase.Text + "' To: '" + txttLastOrder.Text + "' "; // Heading Name               
                worksheet.Cells[3, 1, 3, 7].Merge = true; //Merge columns start and end range
                worksheet.Cells[3, 1, 3, 7].Style.Font.Bold = true; //Font should be bold
                worksheet.Cells[3, 1, 3, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center; // Aligmnet is center
                worksheet.Cells[3, 1].Style.Font.Color.SetColor(System.Drawing.Color.WhiteSmoke);


                // // // // merging cells and hading 


                ///////  //Merging cells and create a center heading for out table
                worksheet.Cells[4, 1].Value = "	Statement Name : Journal Voucher "; // Heading Name               
                worksheet.Cells[4, 1, 4, 7].Merge = true; //Merge columns start and end range
                worksheet.Cells[4, 1, 4, 7].Style.Font.Bold = true; //Font should be bold
                worksheet.Cells[4, 1, 4, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center; // Aligmnet is center
                worksheet.Cells[4, 1].Style.Font.Color.SetColor(System.Drawing.Color.WhiteSmoke);

                // // // agent name header
                ///////  //Merging cells and create a center heading for out table
                worksheet.Cells[5, 1].Value = "	Agency Name : '" + AgentName + "' "; // Heading Name               
                worksheet.Cells[5, 1, 5, 7].Merge = true; //Merge columns start and end range
                worksheet.Cells[5, 1, 5, 7].Style.Font.Bold = true; //Font should be bold
                worksheet.Cells[5, 1, 5, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center; // Aligmnet is center
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
                using (var range = worksheet.Cells[6, 1, 6, 7])
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
                    worksheet.Cells[6, 2].Value = "Voucher No";
                    worksheet.Cells[6, 3].Value = "Voucher Date";
                    worksheet.Cells[6, 4].Value = "Voucher Type";
                    worksheet.Cells[6, 5].Value = "Posted By";
                    worksheet.Cells[6, 6].Value = "Ammended By";
                    worksheet.Cells[6, 7].Value = "Voucher Amount";


                }
                #endregion
                #region
                int count = 1;
                for (int i = 0; i < getdtdata.Rows.Count; i++)
                {
                    worksheet.Cells["A" + (i + 7)].Value = count;
                    worksheet.Cells["B" + (i + 7)].Value = getdtdata.Rows[i]["sJournalVoucherNo"].ToString();
                    worksheet.Cells["C" + (i + 7)].Value = date(getdtdata.Rows[i]["dtJournalVoucher"].ToString());
                    worksheet.Cells["D" + (i + 7)].Value = getdtdata.Rows[i]["sVoucherType"].ToString();
                    worksheet.Cells["E" + (i + 7)].Value = getdtdata.Rows[i]["sPostedby"].ToString();
                    worksheet.Cells["F" + (i + 7)].Value = getdtdata.Rows[i]["sAmendedby"].ToString();
                    worksheet.Cells["G" + (i + 7)].Value = Convert.ToDouble(getdtdata.Rows[i]["TotAmount"].ToString());
                    
                    count++;
                }
                #endregion


                package.Save();
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename=JournalVoucher.xlsx");
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
        public string JournalVoucherID { get; set; }
        public string JournalVoucherNo { get; set; }
        public string dtJournalVoucher { get; set; }
        public string VoucherType { get; set; }
        public string VoucherTypeID { get; set; }
        public string AccountType { get; set; }
        public string Location { get; set; }
        public string Postedby { get; set; }
        public string Amendedby { get; set; }
        public string VoucherAmount { get; set; }

        public string AccountCodeID { get; set; }
        public string AccountCode { get; set; }
        public string Description { get; set; }
        public string CurrencyID { get; set; }
        public string Currency { get; set; }
        public string Rate { get; set; }
        public string Amount { get; set; }
        public string LocalAmount { get; set; }
        public string JobID { get; set; }
        public string Remarks { get; set; }
        public string JournalVoucherDetID { get; set; }
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
    protected void ddlAccountCodeID_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dt = objClassGen.viewData(objClassGen, "ShowGeneralLedgerBal", ddlAccountCodeID.SelectedValue);
        if (dt.Rows.Count > 0)
        {
            if (double.Parse(dt.Rows[0][17].ToString()) < 0)
            {
                txtBalance.Text = "";
                string val = dt.Rows[0][17].ToString();
                var TotBal = val.Split('-');
                txtBalance.Text = TotBal[1].ToString() + " " + "Dr";
            }
            else if (double.Parse(dt.Rows[0][17].ToString()) > 0)
            {
                txtBalance.Text = "";
                txtBalance.Text = dt.Rows[0][17].ToString() + " " + "Cr";
            }
            else
            {
                txtBalance.Text = "0";
            }
        }
        else
        {
            txtBalance.Text = "0";
        }



    }
    protected void txttJournalVoucher_TextChanged(object sender, EventArgs e)
    {
       Voucher_Generate();
    }
    protected void ddlCurrencyID_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dt = objCurrency.viewData(objCurrency, "show", ddlCurrencyID.SelectedValue);
        if (dt.Rows.Count > 0)
        {
            txtRate.Text = dt.Rows[0][4].ToString();
        }
        if (txtAmount.Text == "")
        {
            txtAmount.Text = "0";
        }
        if (txtRate.Text == "")
        {
            txtRate.Text = "0";
        }
        txtAmount_TextChanged(this, e);
        txtAmount.Focus();
    }
    protected void txtAmount_TextChanged(object sender, EventArgs e)
    {
        if (txtAmount.Text == "")
        {
            txtAmount.Text = "0";
        }
        if (txtRate.Text == "")
        {
            txtRate.Text = "0";
        }
        txtLocalAmount.Text = (double.Parse(txtAmount.Text) * double.Parse(txtRate.Text)).ToString();
        txtDescription.Focus();
    }
    protected void txtRate_TextChanged(object sender, EventArgs e)
    {
        txtAmount_TextChanged(this, e);
        txtAmount.Focus();
    }
    public void Voucher_Generate()
    {
        DataTable dt = objClass.viewData(objClass, "JVN", validation.dateToText(txttJournalVoucher.Text));
        if (dt.Rows.Count > 0)
        {
            txtJournalVoucherNo.Text = dt.Rows[0][0].ToString();
        }
    }
    protected void ddlStReportFor_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlStReportFor.SelectedValue != "0")
        {
            if (ddlStReportFor.SelectedValue == "3")
                objAccountCode.ddlOperation(objAccountCode, "ddlAccType", ddlStReportFor.SelectedValue, ddlAgentID);
        else
                objAccountCode.ddlOperation(objAccountCode, "ShowddlAccount", "", ddlAgentID);
        }
    }

    //[WebMethod]
    //public static List<AccountType> GetAccountType()
    //{
    //    List<AccountType> accountypess = new List<AccountType>();
    //    JavaScriptSerializer serializer = new JavaScriptSerializer();
    //    AccountType accountype;
    //    DataTable dtcgroup = new DataTable();
    //    dtcgroup = objClass.DropDown("ACCOUNTCATEGORY", "");
    //    foreach (DataRow row in dtcgroup.Rows)
    //    {
    //        accountype = new AccountType
    //        {
    //            ChartofAccountID = Convert.ToString(row["nAccountCategoryid"]),
    //            AccountTitle = Convert.ToString(row["sAccountCategory"])
    //        };
    //        accountypess.Add(accountype);
    //    }
    //    return accountypess;
    //    //return serializer.Serialize(accountCategories);
    //}
    public class AccountType
    {
        public string ChartofAccountID { get; set; }
        public string AccountTitle { get; set; }
    }
}
