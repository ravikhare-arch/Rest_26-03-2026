using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using ClosedXML.Excel;
using System.Text;
using System.Threading;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;

public partial class Accounting_rptGeneralLedger : System.Web.UI.Page
{
    tvisadet_Class objClass = new tvisadet_Class();
    tacc_journal_voucherdet_Class objClassDet = new tacc_journal_voucherdet_Class();
    mmain_account_Class objMainAcc = new mmain_account_Class();
    validation valobj = new validation();
    SendMail objsendmail = new SendMail();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            invoice.Visible = true;
            PNL0.Visible = false;
            displayGrid();
        }


    }

    public void displayGrid()
    {
        try
        {
            objClass.dtApply = validation.dateToText(Request.QueryString["dtFrom"].ToString());
            objClass.dtDOB = validation.dateToText(Request.QueryString["dtTo"].ToString());
            DataTable dt = objMainAcc.viewData(objMainAcc, "ShowVoucher", Request.QueryString["vType"].ToString());
            if (dt.Rows.Count > 0)
            {
                objClass.sReference1 = dt.Rows[0]["sVoucherCode"].ToString();
            }
            else
            {
                objClass.sReference1 = "";
            }

            getGeneralLedger();
            //  objClass.FillGrid(objClass, GridView1, "ShowGeneralLedgerDet", Request.QueryString["AccCode"].ToString()); 
        }
        catch (Exception ex)
        {
            //  valobj.showMsg(ex.Message, lblmsg);
        }
    }
    public void getGeneralLedger()
    {
        DataTable dt = objClass.viewData(objClass, "ShowGeneralLedgerDet", Request.QueryString["AccCode"].ToString());
        DataTable dtmain = new DataTable();
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

            DataTable dt1 = objClass.viewData(objClass, "GeneralLedgerOpeningBal", Request.QueryString["AccCode"].ToString());
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

            DataTable dtBal = objClass.viewData(objClass, "ShowGeneralLedgerBal", Request.QueryString["AccountID"].ToString());
            if (dtBal.Rows.Count > 0)
            {
                dtmain.Rows.Add(
                             "",
                             "",
                             "",
                              "",
                             "TOTAL RECIEPT",

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

            GetFormData();

        }


        GridView1.DataSource = dtmain;
        GridView1.DataBind();
    }
    public void GetFormData()
    {
        objClass.dtApply = validation.dateToText(Request.QueryString["dtFrom"].ToString());
        objClass.dtDOB = validation.dateToText(Request.QueryString["dtTo"].ToString());

        DataTable dt = objClass.viewData(objClass, "ShowGeneralLedgerBal", Request.QueryString["AccountID"].ToString()); // Session["eid"].ToString());
        if (dt.Rows.Count > 0)
        {

            lblDate.Text = Request.QueryString["dtFrom"].ToString() + " To " + Request.QueryString["dtTo"].ToString();

            lblAccountTitle.Text = dt.Rows[0][1].ToString() + " - " + dt.Rows[0][3].ToString();
            lblAdd.Text = dt.Rows[0][5].ToString();
            //lblCity.Text = dt.Rows[0][14].ToString();
            // lblCountry.Text = dt.Rows[0][14].ToString();
            lblPhone.Text = dt.Rows[0][6].ToString();
            lblFax.Text = dt.Rows[0][9].ToString();
            lblEmail.Text = dt.Rows[0][10].ToString();
            lblWebsite.Text = dt.Rows[0][11].ToString();
            lblCreatedDate.Text = dt.Rows[0][12].ToString();
            lblTotDebit.Text = dt.Rows[0][15].ToString();
            lblTotCredit.Text = dt.Rows[0][16].ToString();
            if (double.Parse(dt.Rows[0][17].ToString()) < 0)
            {
                string val = dt.Rows[0][17].ToString();
                var TotBal = val.Split('-');
                lblTotBalance.Text = TotBal[1].ToString() + " " + "DR";
            }
            else
            {
                lblTotBalance.Text = dt.Rows[0][17].ToString() + " " + "CR";
            }
        }
    }




    //protected void btnpdfN_Click(object sender, EventArgs e)
    //{
    //    Response.ContentType = "application/pdf";
    //    Response.AddHeader("content-disposition", "attachment;filename=TestPage.pdf");
    //    Response.Cache.SetCacheability(HttpCacheability.NoCache);
    //    StringWriter sw = new StringWriter();
    //    HtmlTextWriter hw = new HtmlTextWriter(sw);
    //    this.Page.RenderControl(hw);
    //    StringReader sr = new StringReader(sw.ToString());
    //    Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
    //    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
    //    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
    //    pdfDoc.Open();
    //    htmlparser.Parse(sr);
    //    pdfDoc.Close();
    //    Response.Write(pdfDoc);
    //    Response.End();
    //}



    //Excel & Email

    public override void
   VerifyRenderingInServerForm(Control control)
    {
        return;
    }
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        if (this.DesignMode == true)
        {
            this.EnsureChildControls();
        }
        this.Page.RegisterRequiresControlState(this);
    }

   
    protected override void OnPreRender(EventArgs e)
    {


        base.OnPreRender(e);





    }
    protected void btnExcel_Click(object sender, EventArgs e)
    {
        Response.Clear();
        hidePrint.Visible = false;
        string sDate = validation.fillTextDate();
        string sTime = validation.fillTime();
        string FileName = "GL" + "_" + sDate + "_" + sTime;
        Response.AddHeader("content-disposition", "attachment;filename=" + FileName + ".xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.xls";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        invoice.RenderControl(htmlWrite);
        Response.Write(stringWrite.ToString());
        Response.End();
        hidePrint.Visible = true;
    }

    protected void btnSendMail_Click(object sender, EventArgs e)
    {

        invoice.Visible = false;
        PNL0.Visible = true;
        lnkAttachment.Text = "AccountLedger.xlx";
    }

    public void Send()
    {
        invoice.Visible = true;
        hidePrint.Visible = false;
        PNL0.Visible = false;
        displayGrid();

        System.IO.StringWriter sw = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htw = new System.Web.UI.HtmlTextWriter(sw);
        // GridView1.DataSource = dt;
        //  GridView1.DataBind();
        // Render grid view control.
      
        invoice.RenderControl(htw);
        // Write the rendered content to a file.
        string renderedGridView = sw.ToString();
        string sFileFullName;
        string sFilePath;
        string sFileName;
        sFilePath = Server.MapPath("../Temp");
        Random rdm = new Random();

        string sDate = validation.fillTextDate();
        string sTime = validation.fillTime();
        var stimeo = sTime.Split(':');
        string Stime3 = stimeo[0].ToString() +  stimeo[1].ToString();

        sFileName = "GL" + "_" + sDate + "_" + Stime3 + ".xls";
        
        sFileFullName = sFilePath + "\\" + sFileName;
        if (File.Exists(sFileFullName))
            File.Delete(sFileFullName);
        System.IO.File.WriteAllText(sFileFullName, renderedGridView);
        lnkAttachment.Text = sFileName;

        string vto = txtTo.Text;
        string vcc = txtCC.Text;
        string vbcc = txtBCC.Text;
        string vSubject = txtSub.Text;
        string vBody = txtBody.Text;
        string AttachFileName = lnkAttachment.Text;

        hidePrint.Visible = false;

        objsendmail.Send(txtTo.Text, txtCC.Text, txtBCC.Text, txtSub.Text, txtBody.Text, lnkAttachment.Text);
        Response.Write("<script LANGUAGE='JavaScript' >alert('Email has been sent successfully')</script>");

    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        Send();
        invoice.Visible = true;
        PNL0.Visible = false;
        displayGrid();
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        invoice.Visible = true;
        PNL0.Visible = false;
        displayGrid();
    }
}