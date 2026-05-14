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

public partial class Accounting_rpttrialbalance_subaccount : System.Web.UI.Page
{
    tacc_journal_voucher_Class objClass = new tacc_journal_voucher_Class();
    SendMail objsendmail = new SendMail();
    protected void Page_Load(object sender, EventArgs e)
    {
        invoice.Visible = true;
        PNL0.Visible = false;
        if (!this.IsPostBack)
        {
            lblrptDates.Text = Request.QueryString["dtFrom"].ToString() + " TO " + Request.QueryString["dtTo"].ToString();
            FillDataList();
        }
    }
    public void FillDataList()
    {
        objClass.dtJournalVoucher = validation.dateToText(Request.QueryString["dtFrom"].ToString());
        objClass.sPostedby = validation.dateToText(Request.QueryString["dtTo"].ToString());
        DataTable dtTrialB = objClass.viewData(objClass, "TrialBalanceSub", "");
        if (dtTrialB.Rows.Count > 0)
        {

            treetableSub.DataSource = dtTrialB;
            treetableSub.DataBind();

            GetGrandTotal();

        }
    }
    public void GetGrandTotal()
    {
        objClass.dtJournalVoucher = validation.dateToText(Request.QueryString["dtFrom"].ToString());
        objClass.sPostedby = validation.dateToText(Request.QueryString["dtTo"].ToString());
        DataTable dtTrialB = objClass.viewData(objClass, "TrialBalanceMain", "");
        if (dtTrialB.Rows.Count > 0)
        {
            lbltotDebit.Text = dtTrialB.Rows[0]["DebitAmount"].ToString();
            lbltotCredit.Text = dtTrialB.Rows[0]["CreditAmount"].ToString();
            lbltotBalance.Text = dtTrialB.Rows[0]["BalAmount"].ToString();

        }
    }
    protected void treetable_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
    {
        HiddenField hiddenMain = new HiddenField();
        hiddenMain = (HiddenField)e.Item.FindControl("hdnMain");

        objClass.dtJournalVoucher = validation.dateToText(Request.QueryString["dtFrom"].ToString());
        objClass.sPostedby = validation.dateToText(Request.QueryString["dtTo"].ToString());
        DataTable dtSubAccount = objClass.viewData(objClass, "TrialBalanceAcc", hiddenMain.Value.ToString());
        Repeater rpttreeAcc = new Repeater();
        rpttreeAcc = (Repeater)e.Item.FindControl("treetableAcc");
        rpttreeAcc.DataSource = dtSubAccount;
        rpttreeAcc.DataBind();


        //if (dtSubAccount.Rows.Count > 0)
        //{
        //    for (int i = 0; i < dtSubAccount.Rows.Count; i++)
        //    {

        //        DataTable dtSBA = dtSubAccount.Clone();
        //        dtSBA.Rows.Add(new object[] {
        //            i,1,
        //            dtSubAccount.Rows[i]["sSubAccount"].ToString(),
        //             dtSubAccount.Rows[i]["DebitAmount"].ToString(),
        //              dtSubAccount.Rows[i]["CreditAmount"].ToString(),
        //              dtSubAccount.Rows[i]["BalAmount"].ToString()
        //        });

        //        Repeater rpttreeSub = new Repeater();
        //        rpttreeSub = (Repeater)e.Item.FindControl("treetableSub");
        //        rpttreeSub.DataSource = dtSBA;
        //        rpttreeSub.DataBind();

        //        Repeater rpttreeAcc = new Repeater();
        //        rpttreeAcc = (Repeater)e.Item.FindControl("treeAcc");
        //        DataTable dtAccount = objClass.viewData(objClass, "TrialBalanceAcc", dtSubAccount.Rows[i]["sSubAccount"].ToString());
        //        if (dtSubAccount.Rows.Count > 0)
        //        {
        //            rpttreeAcc.DataSource = dtAccount;
        //            rpttreeAcc.DataBind();
        //        }


        //    }



        //}

    }
    protected void treetableSub_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
    {
        HiddenField hiddenSubID = new HiddenField();
        hiddenSubID = (HiddenField)e.Item.FindControl("hdnSub");
        objClass.sPostedby = hiddenSubID.Value.ToString();

        Repeater rpttreeAcc = new Repeater();
        rpttreeAcc = (Repeater)e.Item.FindControl("treeAcc");
        DataTable dtAccount = objClass.viewData(objClass, "TrialBalanceAcc", "");

        rpttreeAcc.DataSource = dtAccount;
        rpttreeAcc.DataBind();



    }

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
        string FileName = "TBR" + "_" + sDate + "_" + sTime;
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
        lnkAttachment.Text = "Invoice.xlx";
    }

    public void Send()
    {
        invoice.Visible = true;
        hidePrint.Visible = false;
        PNL0.Visible = false;
        FillDataList();

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
        string Stime3 = stimeo[0].ToString() + stimeo[1].ToString();

        sFileName = "TBR" + "_" + sDate + "_" + Stime3 + ".xls";

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
        hidePrint.Visible = true;
        //   displayData();
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        invoice.Visible = true;
        PNL0.Visible = false;
        FillDataList();
    }

    protected void SendPdf()
    {
        invoice.Visible = true;
        hidePrint.Visible = false;
        PNL0.Visible = false;
        FillDataList();

        Response.ContentType = "application/pdf";

        Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.pdf");

        Response.Cache.SetCacheability(HttpCacheability.NoCache);

        StringWriter sw = new StringWriter();

        HtmlTextWriter hw = new HtmlTextWriter(sw);


        invoice.RenderControl(hw);

        StringReader sr = new StringReader(sw.ToString());

        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);

        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);

        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);

        pdfDoc.Open();

        htmlparser.Parse(sr);

        pdfDoc.Close();

        Response.Write(pdfDoc);

        Response.End();
    }
}