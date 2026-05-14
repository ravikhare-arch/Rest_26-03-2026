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

public partial class Travel_MofaStmt : System.Web.UI.Page
{
    tgroupmofa_Class objClass = new tgroupmofa_Class();
    tgroupmofadet_Class objClassdet = new tgroupmofadet_Class();
    SendMail objsendmail = new SendMail();
    protected void Page_Load(object sender, EventArgs e)
    {
        invoice.Visible = true;
        PNL0.Visible = false;
        if (Request.QueryString["Agentid"] != null)
        {
            //objClass.sGroupName = "0";
            //objClass.sGroupCode = Request.QueryString["Agentid"].ToString();
            //objClass.sVisaValidity = "0";
            objClass.sGMofaBookingNo = Request.QueryString["Loc"].ToString();
            objClass.dtBookingDate = validation.dateToText(Request.QueryString["DtStFrom"].ToString());
            //objClass.sDuration = validation.dateToText(Request.QueryString["DtStTo"].ToString());
            GetAgentFormData();
        }
        else if (Request.QueryString["SupID"] != null)
        {
            //objClass.sGroupName = "0";
            //objClass.sGroupCode = "0";
            //objClass.sVisaValidity = Request.QueryString["SupID"].ToString();
            objClass.sGMofaBookingNo = Request.QueryString["Loc"].ToString();
            objClass.dtBookingDate = validation.dateToText(Request.QueryString["DtStFrom"].ToString());
            //objClass.sDuration = validation.dateToText(Request.QueryString["DtStTo"].ToString());
            GetSupFormData();
        }
    }
    public void GetAgentFormData()
    {
        DataTable dt = objClass.viewData(objClass, "ShowSearch", "");
        if (dt.Rows.Count > 0)
        {
            //Main Company details
          //  lblVType.Text = "AGENT";
            imgComp.ImageUrl = "../../Uploads/" + dt.Rows[0]["sCompanyImage"].ToString();
            lblCompanyName.Text = dt.Rows[0]["sCompanyName"].ToString();
            lblAddress.Text = dt.Rows[0]["scompAdd"].ToString();
            lblPhoneNo.Text = dt.Rows[0]["sCompPhone"].ToString();
            lblFax.Text = dt.Rows[0]["sCompFax"].ToString();
            lblEmail.Text = dt.Rows[0]["sCompEmail"].ToString();
            lblWebsite.Text = dt.Rows[0]["sCompWebsite"].ToString();


            //Agent Details
            lblAgentName.Text = dt.Rows[0]["sAgent"].ToString();
            lblAgentAdd.Text = dt.Rows[0]["sAgentAdd"].ToString();
            lblAgntCity.Text = dt.Rows[0]["sAgentCity"].ToString();
            lblAgentCountry.Text = dt.Rows[0]["sAgentCountry"].ToString();
            lblAgentPhoneNo.Text = dt.Rows[0]["sPhoneNo1"].ToString();
            lblAgentFax.Text = dt.Rows[0]["sFaxNo"].ToString();
            lblAgentEmail.Text = dt.Rows[0]["sAgentEmail"].ToString();
            lblAgentWebsite.Text = dt.Rows[0]["sAgentWebsite"].ToString();
            lblAgentGstNo.Text = dt.Rows[0]["sGSTNo"].ToString();

            //Booking Details
            //lblBookingNo.Text = dt.Rows[0]["sHotelBookingNo"].ToString();
            //lblBookingDate.Text = validation.TextToDate(dt.Rows[0]["dtBooking"].ToString());



            //lblTotFare.Text = dt.Rows[0]["nClntBasicFare"].ToString();
            //lblTotTax.Text = dt.Rows[0]["nTotTaxes"].ToString();
            //lblSubTot.Text = (double.Parse(lblTotFare.Text) + double.Parse(lblTotTax.Text)).ToString();
            //lblTotSC.Text = dt.Rows[0]["nProfitAmount"].ToString();


            //lblTotSGST.Text = dt.Rows[0]["nClntSGst"].ToString();
            //lblTotCGST.Text = dt.Rows[0]["nClntCGst"].ToString();
            //lblTotIGST.Text = dt.Rows[0]["nClntIGst"].ToString();
            //lblTotDiscount.Text = dt.Rows[0]["nDisCount"].ToString();
            //lblTotTds.Text = dt.Rows[0]["nClntTdsAmount"].ToString();
            //lblTotAmt.Text = dt.Rows[0]["nSellingCost"].ToString();

            //lblbCom.Text = lblCompanyName.Text;
            //lblbComEmail.Text = lblEmail.Text;
            //lblbComTele.Text = lblPhoneNo.Text;


            //Bind Data Grid
            //  objClassdet.FillReapter(objClassdet, rptInvoice, "ShowSearch", "");


            rptInvoice.DataSource = dt;
            rptInvoice.DataBind();

            double totalBase = dt.Select().Sum(p => Convert.ToDouble(p["nMofaCost"]));
            lblTotMofaCost.Text = totalBase.ToString();

            double totTotQty = dt.Select().Sum(p => Convert.ToDouble(p["nQuantity"]));
            lblTotQty.Text = totTotQty.ToString();


            double SCTot = dt.Select().Sum(p => Convert.ToDouble(p["nSupSCAmountTotal"]));
            lblTotSC.Text = SCTot.ToString();

            double RepeatRate = dt.Select().Sum(p => Convert.ToDouble(p["nSupRepeaterRate"]));
            lblRepeaterRate.Text = RepeatRate.ToString();

            double TotRptQty = dt.Select().Sum(p => Convert.ToDouble(p["nRepeaterQty"]));
            lblRepeaterQty.Text = TotRptQty.ToString();

            //double TotRptFee = dt.Select().Sum(p => Convert.ToDouble(p["nClntRPTTotal"]));
            //lblTotRepeater.Text = TotRptFee.ToString();

            double totCGST = dt.Select().Sum(p => Convert.ToDouble(p["nSupCGSTTotal"]));
            lblCGST.Text = totCGST.ToString();

            double TotSGST = dt.Select().Sum(p => Convert.ToDouble(p["nSupSGSTTotal"]));
            lblSGST.Text = TotSGST.ToString();

            double TotIGST = dt.Select().Sum(p => Convert.ToDouble(p["nSupIGSTTotal"]));
            lblIGST.Text = TotIGST.ToString();

            double TotRec = dt.Select().Sum(p => Convert.ToDouble(p["nSupplierCost"]));
            lblTotRec.Text = TotRec.ToString();

            
        }

    }

    public void CalculateAgentAmount()
    {

    }
    public void GetSupFormData()
    {
        DataTable dt = objClass.viewData(objClass, "ShowSearch", "");
        if (dt.Rows.Count > 0)
        {
          //  lblVType.Text = "SUUPLIER";
            //Main Company details
            imgComp.ImageUrl = "../../Uploads/" + dt.Rows[0]["sCompanyImage"].ToString();
            lblCompanyName.Text = dt.Rows[0]["sCompanyName"].ToString();
            lblAddress.Text = dt.Rows[0]["scompAdd"].ToString();
            lblPhoneNo.Text = dt.Rows[0]["sCompPhone"].ToString();
            lblFax.Text = dt.Rows[0]["sCompFax"].ToString();
            lblEmail.Text = dt.Rows[0]["sCompEmail"].ToString();
            lblWebsite.Text = dt.Rows[0]["sCompWebsite"].ToString();


            //Agent Details
            lblAgentName.Text = dt.Rows[0]["sSupplier"].ToString();
            lblAgentAdd.Text = dt.Rows[0]["sSupAdd"].ToString();
            lblAgntCity.Text = dt.Rows[0]["sSupCity"].ToString();
            lblAgentCountry.Text = dt.Rows[0]["sSupCountry"].ToString();
            lblAgentPhoneNo.Text = dt.Rows[0]["sSupPhone"].ToString();
            lblAgentFax.Text = dt.Rows[0]["sSupFax"].ToString();
            lblAgentEmail.Text = dt.Rows[0]["sSupEmail"].ToString();
            lblAgentWebsite.Text = dt.Rows[0]["sSupWebsite"].ToString();
            lblAgentGstNo.Text = dt.Rows[0]["sSupGst"].ToString();
            

            rptInvoice.DataSource = dt;
            rptInvoice.DataBind();

            double totalBase = dt.Select().Sum(p => Convert.ToDouble(p["nMofaCost"]));
            lblTotMofaCost.Text = totalBase.ToString();

            double totTotQty = dt.Select().Sum(p => Convert.ToDouble(p["nQuantity"]));
            lblTotQty.Text = totTotQty.ToString();


            double SCTot = dt.Select().Sum(p => Convert.ToDouble(p["nSupSCAmountTotal"]));
            lblTotSC.Text = SCTot.ToString();

            double RepeatRate = dt.Select().Sum(p => Convert.ToDouble(p["nSupRepeaterRate"]));
            lblRepeaterRate.Text = RepeatRate.ToString();

            double TotRptQty = dt.Select().Sum(p => Convert.ToDouble(p["nRepeaterQty"]));
            lblRepeaterQty.Text = TotRptQty.ToString();

            //double TotRptFee = dt.Select().Sum(p => Convert.ToDouble(p["nClntRPTTotal"]));
            //lblTotRepeater.Text = TotRptFee.ToString();

            double totCGST = dt.Select().Sum(p => Convert.ToDouble(p["nSupCGSTTotal"]));
            lblCGST.Text = totCGST.ToString();

            double TotSGST = dt.Select().Sum(p => Convert.ToDouble(p["nSupSGSTTotal"]));
            lblSGST.Text = TotSGST.ToString();

            double TotIGST = dt.Select().Sum(p => Convert.ToDouble(p["nSupIGSTTotal"]));
            lblIGST.Text = TotIGST.ToString();

            double TotRec = dt.Select().Sum(p => Convert.ToDouble(p["nSupplierCost"]));
            lblTotRec.Text = TotRec.ToString();

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
        GetAgentFormData();

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
        GetAgentFormData();
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        invoice.Visible = true;
        PNL0.Visible = false;
        GetAgentFormData();
    }

    protected void SendPdf()
    {
        invoice.Visible = true;
        hidePrint.Visible = false;
        PNL0.Visible = false;
        GetAgentFormData();

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