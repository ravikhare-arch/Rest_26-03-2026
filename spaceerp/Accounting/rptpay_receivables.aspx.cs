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
    SendMail objsendmail = new SendMail();
    mAccountFamily_Class objClass = new mAccountFamily_Class();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            invoice.Visible = true;
            PNL0.Visible = false;
            if (Request.QueryString["ReportType"].ToString() == "1")
            {
                lblrpttype.Text = "PAYABLES";
            }
            else
                lblrpttype.Text = "RECEIVABLES";

            FillDataList();
        }
    }
    public void FillDataList()
    {
        if (Request.QueryString["ReportType"].ToString() == "1")
        {

            DataTable dtTrialB = objClass.viewData(objClass, "Payables", "");
            if (dtTrialB.Rows.Count > 0)
            {

                treetableSub.DataSource = dtTrialB;
                treetableSub.DataBind();

                GetGrandTotal();

            }
        }
        else
        {
            DataTable dtTrialB = objClass.viewData(objClass, "Receivables", "");
            if (dtTrialB.Rows.Count > 0)
            {

                treetableSub.DataSource = dtTrialB;
                treetableSub.DataBind();

                GetGrandTotal();

            }
        }
    }
    public void GetGrandTotal()
    {
        if (Request.QueryString["ReportType"].ToString() == "1")
        {


            DataTable dtTrialB = objClass.viewData(objClass, "PayablesBal", "");
            if (dtTrialB.Rows.Count > 0)
            {

                lbltotBalance.Text = dtTrialB.Rows[0]["BalTotal"].ToString();

            }
        }
        else
        {
            DataTable dtTrialB = objClass.viewData(objClass, "ReceivableBal", "");
            if (dtTrialB.Rows.Count > 0)
            {

                lbltotBalance.Text = dtTrialB.Rows[0]["BalTotal"].ToString();

            }
        }
    }
    protected void treetable_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
    {
        HiddenField hiddenMain = new HiddenField();
        hiddenMain = (HiddenField)e.Item.FindControl("hdnMain");
        if (Request.QueryString["ReportType"].ToString() == "1")
        {


            DataTable dtSubAccount = objClass.viewData(objClass, "PayablesDet", hiddenMain.Value.ToString());

            Repeater rpttreeAcc = new Repeater();
            rpttreeAcc = (Repeater)e.Item.FindControl("treetableAcc");
            rpttreeAcc.DataSource = dtSubAccount;
            rpttreeAcc.DataBind();
        }
        else
        {
            DataTable dtSubAccount = objClass.viewData(objClass, "ReceivablesDet", hiddenMain.Value.ToString());

            Repeater rpttreeAcc = new Repeater();
            rpttreeAcc = (Repeater)e.Item.FindControl("treetableAcc");
            rpttreeAcc.DataSource = dtSubAccount;
            rpttreeAcc.DataBind();
        }



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
        string FileName = "PRR" + "_" + sDate + "_" + sTime;
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

        sFileName = "PRR" + "_" + sDate + "_" + Stime3 + ".xls";

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