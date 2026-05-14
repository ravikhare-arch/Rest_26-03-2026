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

public partial class Travel_rptTicketInvoice : System.Web.UI.Page
{
    tticketing_Class objClass = new tticketing_Class();
    SendMail objsendmail = new SendMail();
    protected void Page_Load(object sender, EventArgs e)
    {
        invoice.Visible = true;
        PNL0.Visible = false;
        if (Request.QueryString["id"] != null)
        {

            GetFormData();
        }
    }
    public void GetFormData()
    {
        DataTable dt = objClass.viewData(objClass, "TicInvoice", Request.QueryString["id"].ToString());
        if (dt.Rows.Count > 0)
        {
            //Main Company details
            //lblCompanyName.Text = dt.Rows[0]["sCompanyName"].ToString();
            //lblAddress.Text = dt.Rows[0]["ComAddress"].ToString();
            //lblPhone.Text = dt.Rows[0]["ComPhone"].ToString();
            //lblFax.Text = dt.Rows[0]["ComFax"].ToString();
            //lblEmail.Text = dt.Rows[0]["ComEmail"].ToString();
            //lblWebsite.Text = dt.Rows[0]["ComWebsite"].ToString();


            //Agent Details
            lblAgent.Text = dt.Rows[0]["sAgentName"].ToString();
            lblAgentAdd.Text = dt.Rows[0]["sAgentAdd"].ToString();
            lblCity.Text = dt.Rows[0]["sAgentCity"].ToString();
            lblCountry.Text = dt.Rows[0]["sAgentCountry"].ToString();
            lblAgentPhone.Text = dt.Rows[0]["sPhoneNo1"].ToString();
            lblAgentFax.Text = dt.Rows[0]["sFaxNo"].ToString();
            lblAgentEmail.Text = dt.Rows[0]["sEmailID"].ToString();
            lblAgentWebsite.Text = dt.Rows[0]["sWebsite"].ToString();

            //Booking Details
            lblBookingNo.Text = dt.Rows[0]["sTicketBookingNo"].ToString();
            lblBookingDate.Text =validation.TextToDate(dt.Rows[0]["dtBooking"].ToString());

            //Calculation
            lblSc.Text = dt.Rows[0]["nProfitAmount"].ToString();
            lblSubTot1.Text = (double.Parse(dt.Rows[0]["nBuyingCost"].ToString()) + double.Parse(lblSc.Text)).ToString();
            lblSubTot2.Text = lblSubTot1.Text;

            lblTds.Text = dt.Rows[0]["nClntTdsAmount"].ToString();
            lblCgst.Text = dt.Rows[0]["nClntCGst"].ToString();
            lblSgst.Text = dt.Rows[0]["nClntSGst"].ToString();
            lblIgst.Text = dt.Rows[0]["nClntIGst"].ToString();
            lblDiscount.Text = dt.Rows[0]["nDiscount"].ToString();
            lblGrandTot.Text = dt.Rows[0]["nSellingCost"].ToString();

            //Bottom Details
            lblCompany3.Text = dt.Rows[0]["sCompanyName"].ToString();
            lblComEmail2.Text = dt.Rows[0]["ComEmail"].ToString();
            lblComWebsite2.Text = dt.Rows[0]["ComWebsite"].ToString();
            lblComPhone2.Text = dt.Rows[0]["ComPhone"].ToString();

            //Bind Data Grid
            rptDetails.DataSource = dt;
            rptDetails.DataBind();
           
        }
        
    }

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
        string FileName = "TI" + "_" + sDate + "_" + sTime;
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
        GetFormData();

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

        sFileName = "TI" + "_" + sDate + "_" + Stime3 + ".xls";

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
        GetFormData();
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        invoice.Visible = true;
        PNL0.Visible = false;
        GetFormData();
    }

    protected void SendPdf()
    {
        invoice.Visible = true;
        hidePrint.Visible = false;
        PNL0.Visible = false;
        GetFormData();

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