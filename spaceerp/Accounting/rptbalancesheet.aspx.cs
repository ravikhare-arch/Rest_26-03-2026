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

public partial class Accounting_rptProfitLoss_Details : System.Web.UI.Page
{
    SendMail objsendmail = new SendMail();
    tchartof_account_Class objClass = new tchartof_account_Class();
    protected void Page_Load(object sender, EventArgs e)
    {
        invoice.Visible = true;
        PNL0.Visible = false;
        if (Request.QueryString != null)
        {
            lblDate.Text = "PERIOD : " + Request.QueryString["dtFrom"].ToString() + " TO " + Request.QueryString["dtTo"].ToString();
            displayData();
        }
    }
    public void displayData()
    {
        try
        {
            objClass.sFirstName = validation.dateToText(Request.QueryString["dtFrom"].ToString());
            objClass.sLastName = validation.dateToText(Request.QueryString["dtTo"].ToString());
            objClass.FillReapter(objClass, rptSales, "rptBalancesheetAsset", "");
            objClass.FillReapter(objClass, rptExpense, "rptBalancesheetLiability", "");

            DataTable dtAsset = objClass.viewData(objClass, "rptBalancesheetAssetTot", "");
            if (dtAsset.Rows.Count > 0)
            {
                lblCurrentAssets.Text = dtAsset.Rows[0]["TotAssets"].ToString();
                lblTotAssets.Text = dtAsset.Rows[0]["TotAssets"].ToString();
                lblTotAssets2.Text = dtAsset.Rows[0]["TotAssets"].ToString();
                //   lblTotExp.Text = dt.Rows[0]["nDebitAmount"].ToString();

                //if (double.Parse(dt.Rows[0]["nProfitLoss"].ToString()) > 0)
                //{
                //    lblPlTitle.Text = "PROFIT";
                //    lblprofitLoss.Text = dt.Rows[0]["nProfitLoss"].ToString();
                //}
                //else
                //{
                //    lblPlTitle.Text = "LOSS";
                //    lblprofitLoss.Text = dt.Rows[0]["nProfitLoss"].ToString();
                //}
            }

            DataTable dtLiability = objClass.viewData(objClass, "rptBalancesheetLiabilityTot", "");
            if (dtLiability.Rows.Count > 0)
            {
                lblCurrentLiabilities.Text = dtLiability.Rows[0]["LiabilityAmount"].ToString();
            }

            DataTable dtPl = objClass.viewData(objClass, "rptBalancesheetPL", "");
            if (dtPl.Rows.Count > 0)
            {

                if (double.Parse(dtPl.Rows[0]["nPLAmount"].ToString()) > 0)
                {
                    trProfit.Visible = true;
                    trloss.Visible = false;
                    lblProfit.Text = dtPl.Rows[0]["nPLAmount"].ToString();
                }
                else if (double.Parse(dtPl.Rows[0]["nPLAmount"].ToString()) < 0)
                {
                    trProfit.Visible = false;
                    trloss.Visible = true;
                    double amt = double.Parse(dtPl.Rows[0]["nPLAmount"].ToString());
                    lblLoss.Text = (Math.Abs(amt)).ToString();
                }
                else
                {
                    trProfit.Visible = false;
                    trloss.Visible = false;
                }
            }

        }
        catch (Exception ex)
        {
            //  valobj.showMsg(ex.Message, lblmsg);
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
        string FileName = "BLS" + "_" + sDate + "_" + sTime;
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
        displayData();

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

        sFileName = "BLS" + "_" + sDate + "_" + Stime3 + ".xls";

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
        displayData();
    }

    protected void SendPdf()
    {
        invoice.Visible = true;
        hidePrint.Visible = false;
        PNL0.Visible = false;
        displayData();

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