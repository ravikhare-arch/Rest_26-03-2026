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

public partial class Travel_TicketInvoice : System.Web.UI.Page
{
    tticketing_Class objClass = new tticketing_Class();
    tticketingdet_Class objClassdet = new tticketingdet_Class();
    SendMail objsendmail = new SendMail();
    protected void Page_Load(object sender, EventArgs e)
    {
        invoice.Visible = true;
        PNL0.Visible = false;
        if (Request.QueryString["id"] != null)
        {
            objClassdet.sReferenceNo = Request.QueryString["id"].ToString();
            objClassdet.sCustomerName = "0";
            objClassdet.sPassportNo = "0";
            objClassdet.sAirlinePnr = "0";
            objClassdet.sDeparture = "0";
            objClassdet.dtTravelDate = "";
            objClassdet.dtReturnDate = "";
            GetFormData();
        }
        else if (Request.QueryString["Detid"] != null)
        {
            GetFormDataDet();
        }
    }
    public void GetFormData()
    {
        DataTable dt = objClass.viewData(objClass, "TicInvoice", Request.QueryString["id"].ToString());
        if (dt.Rows.Count > 0)
        {
            //Main Company details
            imgComp.ImageUrl = "../../Uploads/" + dt.Rows[0]["sCompanyImage"].ToString();
            lblCompanyName.Text = dt.Rows[0]["scompanyname"].ToString();
            lblAddress.Text = dt.Rows[0]["comaddress"].ToString();
            lblPhoneNo.Text = dt.Rows[0]["comphone"].ToString();
            lblFax.Text = dt.Rows[0]["comfax"].ToString();
            lblEmail.Text = dt.Rows[0]["comemail"].ToString();
            lblWebsite.Text = dt.Rows[0]["comwebsite"].ToString();


            //Agent Details
            lblAgentName.Text = dt.Rows[0]["sAgentName"].ToString();
            lblAgentAdd.Text = dt.Rows[0]["sAgentAdd"].ToString();
            //lblAgntCity.Text = dt.Rows[0]["sAgentCity"].ToString();
            //lblAgentCountry.Text = dt.Rows[0]["sAgentCountry"].ToString();
            lblAgentPhoneNo.Text = dt.Rows[0]["sPhoneNo1"].ToString();
            lblAgentFax.Text = dt.Rows[0]["sFaxNo"].ToString();
            lblAgentEmail.Text = dt.Rows[0]["sEmailID"].ToString();
            lblAgentWebsite.Text = dt.Rows[0]["sWebsite"].ToString();
            lblAgentGstNo.Text = dt.Rows[0]["sGSTNo"].ToString();

            //Booking Details
            lblBookingNo.Text = dt.Rows[0]["sTicketBookingNo"].ToString();
            lblBookingDate.Text = validation.TextToDate(dt.Rows[0]["dtBooking"].ToString());



            lblTotFare.Text = dt.Rows[0]["nClntBasicFare"].ToString();
            lblTotTax.Text = dt.Rows[0]["nTotTaxes"].ToString();
            lblSubTot.Text = (double.Parse(lblTotFare.Text) + double.Parse(lblTotTax.Text)).ToString();
            lblTotSC.Text = dt.Rows[0]["nProfitAmount"].ToString();
            lblOtrChrg.Text = dt.Rows[0]["nClntOtherChrgs"].ToString();

            lblTotSGST.Text = dt.Rows[0]["nClntSGst"].ToString();
            lblTotCGST.Text = dt.Rows[0]["nClntCGst"].ToString();
            lblTotIGST.Text = dt.Rows[0]["nClntIGst"].ToString();
            lblTotDiscount.Text = dt.Rows[0]["nDisCount"].ToString();
            lblTotTds.Text = dt.Rows[0]["nClntTdsAmount"].ToString();
            lblTotAmt.Text = dt.Rows[0]["nSellingCost"].ToString();

            lblbCom.Text = lblCompanyName.Text;
            lblbComEmail.Text = lblEmail.Text;
            lblbComTele.Text = lblPhoneNo.Text;


            //Bind Data Grid
            objClassdet.FillReapter(objClassdet, rptInvoice, "ShowSearch", "");

            //   rptInvoice.DataSource = dt;
            // rptInvoice.DataBind();

        }

    }

    public void GetFormDataDet()
    {
        DataTable dt = objClassdet.viewData(objClassdet, "TicInvoiceDet", Request.QueryString["Detid"].ToString());
        if (dt.Rows.Count > 0)
        {
            //Main Company details
            imgComp.ImageUrl = "../../Uploads/" + dt.Rows[0]["sCompanyImage"].ToString();
            lblCompanyName.Text = dt.Rows[0]["scompanyname"].ToString();
            lblAddress.Text = dt.Rows[0]["comaddress"].ToString();
            lblPhoneNo.Text = dt.Rows[0]["comphone"].ToString();
            lblFax.Text = dt.Rows[0]["comfax"].ToString();
            lblEmail.Text = dt.Rows[0]["comemail"].ToString();
            lblWebsite.Text = dt.Rows[0]["comwebsite"].ToString();


            //Agent Details
            lblAgentName.Text = dt.Rows[0]["sAgentName"].ToString();
            lblAgentAdd.Text = dt.Rows[0]["sAgentAdd"].ToString();
            //lblAgntCity.Text = dt.Rows[0]["sAgentCity"].ToString();
            //lblAgentCountry.Text = dt.Rows[0]["sAgentCountry"].ToString();
            lblAgentPhoneNo.Text = dt.Rows[0]["sPhoneNo1"].ToString();
            lblAgentFax.Text = dt.Rows[0]["sFaxNo"].ToString();
            lblAgentEmail.Text = dt.Rows[0]["sEmailID"].ToString();
            lblAgentWebsite.Text = dt.Rows[0]["sWebsite"].ToString();
            lblAgentGstNo.Text = dt.Rows[0]["sGSTNo"].ToString();
            //Booking Details
            lblBookingNo.Text = dt.Rows[0]["sTicketBookingNo"].ToString();
            lblBookingDate.Text = validation.TextToDate(dt.Rows[0]["dtBooking"].ToString());



            lblTotFare.Text = dt.Rows[0]["nClntBasicFare"].ToString();
            lblTotTax.Text = dt.Rows[0]["nTotTaxes"].ToString();
            lblSubTot.Text = (double.Parse(lblTotFare.Text) + double.Parse(lblTotTax.Text)).ToString();
            lblTotSC.Text = dt.Rows[0]["nProfitAmount"].ToString();
            lblOtrChrg.Text = dt.Rows[0]["nClntOtherChrgs"].ToString();

            lblTotSGST.Text = dt.Rows[0]["nClntSGst"].ToString();
            lblTotCGST.Text = dt.Rows[0]["nClntCGst"].ToString();
            lblTotIGST.Text = dt.Rows[0]["nClntIGst"].ToString();
            lblTotDiscount.Text = dt.Rows[0]["nDisCount"].ToString();
            lblTotTds.Text = dt.Rows[0]["nClntTdsAmount"].ToString();
            lblTotAmt.Text = dt.Rows[0]["nSellingCost"].ToString();

            lblbCom.Text = lblCompanyName.Text;
            lblbComEmail.Text = lblEmail.Text;
            lblbComTele.Text = lblPhoneNo.Text;


            //Bind Data Grid
            // objClassdet.FillReapter(objClassdet, rptInvoice, "ShowSearch", "");


            rptInvoice.DataSource = dt;
            rptInvoice.DataBind();

        }

    }
    //Print -Excel - Pdf


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