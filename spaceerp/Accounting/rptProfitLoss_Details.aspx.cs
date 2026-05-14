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
    tchartof_account_Class objClass = new tchartof_account_Class();
    SendMail objsendmail = new SendMail();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString != null)
        {
            invoice.Visible = true;
            PNL0.Visible = false;
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
            objClass.FillReapter(objClass, rptSales, "ProfitLossIncome", "");
            objClass.FillReapter(objClass, rptExpense, "ProfitLossExpense", "");



            DataTable dt = objClass.viewData(objClass, "ProfitLossTotal", "");
            if (dt.Rows.Count > 0)
            {
                lblTotIncome.Text = dt.Rows[0]["nCreditAmount"].ToString();
                lblTotExp.Text = dt.Rows[0]["nDebitAmount"].ToString();

               

                if (double.Parse(dt.Rows[0]["nProfitLoss"].ToString()) > 0)
                {
                    lblPlTitle.Text = "PROFIT BEFORE TAX";
                    lblprofitLoss.Text = dt.Rows[0]["nProfitLoss"].ToString();
                    trProfitloss.Attributes.Add("Class", "bg-green-transparent-4 font-weight-bold");

                }
                else
                {
                    lblPlTitle.Text = "LOSS BEFORE TAX";
                    lblprofitLoss.Text = dt.Rows[0]["nProfitLoss"].ToString();
                    trProfitloss.Attributes.Add("Class", "bg-red-transparent-4 font-weight-bold");
                }

            }
            DataTable dtGst = objClass.viewData(objClass, "GST", "");
            if (dtGst.Rows.Count > 0)
            {
                lblTax.Text = dtGst.Rows[0]["totTax"].ToString();

            }
            else
            {
                lblTax.Text = "0";
            }
            lblPlwithTAX.Text = (double.Parse(lblprofitLoss.Text) - double.Parse(lblTax.Text)).ToString();
            if (double.Parse(lblPlwithTAX.Text) > 0)
            {
                lblPlwithTAXTtile.Text = "PROFIT AFTER TAX";
                trWithTax.Attributes.Add("Class", "bg-green-transparent-4 font-weight-bold");
            }
            else
            {
                lblPlwithTAXTtile.Text = "LOSS AFTER TAX";
                trWithTax.Attributes.Add("Class", "bg-red-transparent-4 font-weight-bold");
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
        string FileName = "PL" + "_" + sDate + "_" + sTime;
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

        sFileName = "PL" + "_" + sDate + "_" + Stime3 + ".xls";

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
        // displayData();
        hidePrint.Visible = true;
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        invoice.Visible = true;
        PNL0.Visible = false;
        displayData();
        hidePrint.Visible = true;
    }
}