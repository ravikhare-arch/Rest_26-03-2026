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

public partial class tpayment_made_list : System.Web.UI.Page
{
    static tpayments_made_Class objClass = new tpayments_made_Class();
    static tpayments_madedet_Class objClassDet = new tpayments_madedet_Class();
    mmain_account_Class objAccount = new mmain_account_Class();
    mclient_Class objClient = new mclient_Class();
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
                Session["tpayment_made_list"] = aa;
                objClient.ddlOperation(objClient, "Showddl", "", ddlClient);

                txttJournalVoucher.Text = validation.fillDate();
                Voucher_Generate();
                // fillUser();

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
        ViewState["tpayment_made_list"] = Session["tpayment_made_list"];
        viewstate = Session["tpayment_made_list"].ToString();
    }

    [WebMethod]
    public static mpagemasterlist loaddata(string fromdate, string todate, string Reportfor, string AgentID)
    {
        list magentobj = new list();
        list magentobjnew = new list();
        mpagemasterlist mainlist = new mpagemasterlist();
        mainlist.mpagemasterobjlist = new List<list>();
        mainlist.mpagemasterobjlistnew = new List<list>();
        DataTable dt = new DataTable();
        DataTable dtnew = new DataTable();
        try
        {
            if (Reportfor != "0" && Reportfor != "")
            {
                if (Reportfor == "7")
                {
                    objClass.nSupplierID = AgentID;
                    //objClass.nAgentID = "0";
                }
                else if (Reportfor == "3")
                {
                    objClass.nSupplierID = AgentID;
                    //objClass.nSupplierID = "0";
                }
            }
            else
            {
                objClass.nSupplierID = "0";
                //objClass.nSupplierID = "0";
            }
            objClass.StartDate = validation.dateToText(fromdate);
            objClass.EndDate = validation.dateToText(todate);
            dt = objClass.Tabledata(objClass, "ShowGrid", "");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                magentobj = new list();
                magentobj.PaymentReceiveNo = dt.Rows[i]["sVoucherNo"].ToString();
                magentobj.dtVoucher = validation.TextToDate(dt.Rows[i]["dtPayment"].ToString());
                magentobj.AgetName = dt.Rows[i]["sAgencyName"].ToString();
                magentobj.PayFor = dt.Rows[i]["sPayfor"].ToString();
                magentobj.Amount = dt.Rows[i]["nTotAmount"].ToString();
                magentobj.PaymentReceiveID = dt.Rows[i]["nPaymentMadeID"].ToString();
                magentobj.AgentID = dt.Rows[i]["nSupplierID"].ToString();
                magentobj.PaymentModeID = dt.Rows[i]["nPaymentModeID"].ToString();
                magentobj.CashAccountID = dt.Rows[i]["nCashAccountID"].ToString();
                magentobj.Remarks = dt.Rows[i]["sRemarks"].ToString();
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
        mainlist.mpagemasterobjlistnew = new List<list>();
        DataTable dtnew = new DataTable();
        try
        {
            objClassDet.dtInvoiceDate = "PayReceive";
            objClassDet.sInvoiceNo = "Visa";
            dtnew = objClassDet.Tabledata(objClassDet, "ShowGridDet", AccountLedgerID);

            if (dtnew.Rows.Count > 0)
            {
                for (int i = 0; i < dtnew.Rows.Count; i++)
                {
                    magentobjnew = new list();
                    magentobjnew.InvoiceDate = dtnew.Rows[i]["dtInvoiceDate"].ToString();
                    magentobjnew.InvoiceNo = dtnew.Rows[i]["sInvoiceNo"].ToString();
                    magentobjnew.SellingRate = dtnew.Rows[i]["nSellingRate"].ToString();
                    magentobjnew.Balance = dtnew.Rows[i]["nBalance"].ToString();
                    magentobjnew.PaymentValue = dtnew.Rows[i]["nAmount"].ToString();

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
            if (HttpContext.Current.Session["tpayment_made_list"].ToString() == viewstate)
            {
                para(list);
                // //  assign objects start
                var abc = objClass.User_Operation(objClass, "add");
                var strArr = abc.Split(',');
                if (strArr[0] == "1")
                {
                    string VoucherID = strArr[2].ToString();
                    //Journal Voucher Det
                    // paraDet(list);
                    objClassDet.nPaymentMadeID = VoucherID;
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
            if (HttpContext.Current.Session["tpayment_made_list"].ToString() == viewstate)
            {
                para(list);
                //objClass.nPaymentReceiveID = list.JournalVoucherID;
                var abc = objClass.User_Operation(objClass, "edit");

                //paraDet(list);
                //objClassDet.nPaymentReceiveID = list.JournalVoucherID;
                //objClassDet.nPaymentReceiveDetID = list.JournalVoucherDetID;
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
            objClass.nPaymentMadeID = AccountLedgerID;
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
        objClass.nPaymentModeID = list.PaymentModeID;
        objClass.nCashAccountID = list.CashAccountID;
        objClass.dtPayment = validation.dateToText(list.dtVoucher);
        objClass.sVoucherNo = list.PaymentReceiveNo;
        objClass.nTotAmount = list.Amount;
        objClass.nSupplierID = list.AgentID;

        objClass.sRemarks = list.Remarks;
        objClass.sPayfor = list.PayForID;
        return list.ToString();
    }

   
     protected void lnkAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("tpayment_made.aspx");
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
        public string PaymentReceiveID { get; set; }
        public string PaymentReceiveNo { get; set; }
        public string dtVoucher { get; set; }
        public string AgentID { get; set; }
        public string AgetName { get; set; }
        public string PayForID { get; set; }
        public string PayFor { get; set; }
        public string PaymentModeID { get; set; }
        public string CashAccountID { get; set; }
        public string Description { get; set; }
        public string Amount { get; set; }
        public string Remarks { get; set; }
        public string PaymentReceiveDetID { get; set; }

        public string InvoiceNo { get; set; }
        public string InvoiceDate { get; set; }
        public string SellingRate { get; set; }
        public string Balance { get; set; }
        public string PaymentValue { get; set; }
    }


    public class mpagemasterlist
    {
        public List<list> mpagemasterobjlist { get; set; }
        public List<list> mpagemasterobjlistnew { get; set; }
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
            var fileName = "PaymentMade-" + DateTime.Now.ToString("yyyy-MM-dd--hh-mm-ss") + ".xlsx";
            var outputDir = Server.MapPath("../Temp/PaymentMade.xlsx");

            ///// // Create the file using the FileInfo object
            var file = new FileInfo(outputDir + fileName);

            ///// // Create the package and make sure you wrap it in a using statement
            using (var package = new ExcelPackage(file))
            {
                /////  // add a new worksheet to the empty workbook
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("PaymentMade - " + DateTime.Now.ToShortDateString());

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
                worksheet.Cells[4, 1].Value = "	Statement Name : Payment Made "; // Heading Name               
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
                    worksheet.Cells[6, 2].Value = "Voucher No";
                    worksheet.Cells[6, 3].Value = "Voucher Date";
                    worksheet.Cells[6, 4].Value = "Agency Name";
                    worksheet.Cells[6, 5].Value = "Pay For";
                    worksheet.Cells[6, 6].Value = "Voucher Amount";


                }
                #endregion
                #region
                int count = 1;
                for (int i = 0; i < getdtdata.Rows.Count; i++)
                {
                    worksheet.Cells["A" + (i + 7)].Value = count;
                    worksheet.Cells["B" + (i + 7)].Value = getdtdata.Rows[i]["sVoucherNo"].ToString();
                    worksheet.Cells["C" + (i + 7)].Value = date(getdtdata.Rows[i]["dtPayment"].ToString());
                    worksheet.Cells["D" + (i + 7)].Value = getdtdata.Rows[i]["sAgencyName"].ToString();
                    worksheet.Cells["E" + (i + 7)].Value = getdtdata.Rows[i]["sPayfor"].ToString();
                    worksheet.Cells["F" + (i + 7)].Value = Convert.ToDouble(getdtdata.Rows[i]["nTotAmount"].ToString());
                    count++;
                }
                #endregion


                package.Save();
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename=PaymentMade.xlsx");
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

    protected void txttJournalVoucher_TextChanged(object sender, EventArgs e)
    {
        Voucher_Generate();
    }
    public void Voucher_Generate()
    {
        DataTable dt = objClass.viewData(objClass, "PVN", validation.dateToText(txttJournalVoucher.Text));
        if (dt.Rows.Count > 0)
        {
            txtPaymentVoucherNo.Text = dt.Rows[0][0].ToString();
        }
    }
    protected void ddlClient_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlClient.SelectedValue != "0")
            {
                //tblGridM.Visible = true;
                //GridView3.Visible = true;
                objClass.sVoucherNo = "PayReceive";
                objClass.sPayfor = ddlPayFor.SelectedValue;
                //objClass.FillGrid(objClass, GridView3, "ShowOutstanding", ddlClient.SelectedValue);
            }
            else
            {
                //GridView3.Visible = false;
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
    protected void ddlPayFor_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlClient_SelectedIndexChanged(this, e);
    }
    protected void ddlPaymentMode_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPaymentMode.SelectedValue == "1")
        {
            objAccount.ddlOperation(objAccount, "ddlAccType", ddlPaymentMode.SelectedValue, ddlPayAccount);
        }
        else if (ddlPaymentMode.SelectedValue == "2")
        {
            objAccount.ddlOperation(objAccount, "ddlAccType", ddlPaymentMode.SelectedValue, ddlPayAccount);

        }
        else
        {
            objAccount.ddlOperation(objAccount, "ddlAccType", "2", ddlPayAccount);

        }
    }
    protected void txtAmount_TextChanged(object sender, EventArgs e)
    {
        //lblAmount.Text = txtAmount.Text;

        objClass.sVoucherNo = "PayReceive";
        objClass.sPayfor = ddlPayFor.SelectedValue;
        //objClass.FillGrid(objClass, GridView3, "ShowOutstanding", ddlClient.SelectedValue);

    }
   
    protected void ddlStReportFor_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlStReportFor.SelectedValue != "0")
        {
            if (ddlStReportFor.SelectedValue == "7")
            {
                objAccount.ddlOperation(objAccount, "ddlAccType", ddlStReportFor.SelectedValue, ddlAgentID);
            }
            else
            {
                objAccount.ddlOperation(objAccount, "ShowddlAccount", "", ddlAgentID);
            }
        }
    }
}
