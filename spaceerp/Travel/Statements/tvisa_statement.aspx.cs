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

public partial class Travel_HotelStmt : System.Web.UI.Page
{
    tvisa_Class objClass = new tvisa_Class();
    tvisadet_Class objClassdet = new tvisadet_Class();
    SendMail objsendmail = new SendMail();
    protected void Page_Load(object sender, EventArgs e)
    {
        invoice.Visible = true;
        PNL0.Visible = false;
        if (Request.QueryString["Agentid"] != null)
        {
            rptAgent.Visible = true;
            rptSup.Visible = false;
            objClassdet.sReference1 = "0";
            objClassdet.sCustomerName = Request.QueryString["Agentid"].ToString();
            objClassdet.sPassportNo = "0";
            objClassdet.sNationality = Request.QueryString["Loc"].ToString();
            objClassdet.dtVisaExpiryDate = "0";
            objClassdet.dtIssue = validation.dateToText(Request.QueryString["DtStFrom"].ToString());
            objClassdet.dtApply = validation.dateToText(Request.QueryString["DtStTo"].ToString());
            GetAgentFormData();
        }
        else if (Request.QueryString["SupID"] != null)
        {
            rptAgent.Visible = false;
            rptSup.Visible = true;
            objClassdet.sReference1 = "0";
            objClassdet.sCustomerName = "0";
            objClassdet.sPassportNo = Request.QueryString["SupID"].ToString();
            objClassdet.sNationality = Request.QueryString["Loc"].ToString();
            objClassdet.dtVisaExpiryDate = "0";
            objClassdet.dtIssue = validation.dateToText(Request.QueryString["DtStFrom"].ToString());
            objClassdet.dtApply = validation.dateToText(Request.QueryString["DtStTo"].ToString());
            GetSupFormData();
        }
    }
    public void GetAgentFormData()
    {
        DataTable dt = objClassdet.viewData(objClassdet, "ShowSearch", "");
        if (dt.Rows.Count > 0)
        {
            //Main Company details
            lblVType.Text = "AGENT";
            imgComp.ImageUrl = "../../Uploads/" + dt.Rows[0]["sCompanyImage"].ToString();
            lblCompanyName.Text = dt.Rows[0]["sCompanyName"].ToString();
            lblAddress.Text = dt.Rows[0]["scompAdd"].ToString();
            lblPhoneNo.Text = dt.Rows[0]["sCompPhone"].ToString();
            lblFax.Text = dt.Rows[0]["sCompFax"].ToString();
            lblEmail.Text = dt.Rows[0]["sCompEmail"].ToString();
            lblWebsite.Text = dt.Rows[0]["sCompWebsite"].ToString();


            //Agent Details
            lblAgentName.Text = dt.Rows[0]["sVisaSellCompany"].ToString();
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

            double totalBase = dt.Select().Sum(p => Convert.ToDouble(p["nBuyingRate"]));
         //   (rptInvoice.Controls[rptInvoice.Controls.Count - 1].Controls[0].FindControl("lblBase") as Label).Text = totalBase.ToString();
            lblTotFare.Text = totalBase.ToString();

            
            double SCTot = dt.Select().Sum(p => Convert.ToDouble(p["nProfitAmount"]));
         //   (rptInvoice.Controls[rptInvoice.Controls.Count - 1].Controls[0].FindControl("lblSC") as Label).Text = SCTot.ToString();
            lblTotSC.Text = SCTot.ToString();

            double SC2 = dt.Select().Sum(p => Convert.ToDouble(p["nClntSC2Amount"]));
            //  (rptInvoice.Controls[rptInvoice.Controls.Count - 1].Controls[0].FindControl("lblTotTaxes") as Label).Text = OtrChargesTot.ToString();
            lblSC2.Text = SC2.ToString();

            double Courier = dt.Select().Sum(p => Convert.ToDouble(p["nCourierCharges"]));
            //  (rptInvoice.Controls[rptInvoice.Controls.Count - 1].Controls[0].FindControl("lblTotTaxes") as Label).Text = OtrChargesTot.ToString();
            lblCourier.Text = Courier.ToString();

            double OtrChargesTot = dt.Select().Sum(p => Convert.ToDouble(p["nOtherCharges"]));
          //  (rptInvoice.Controls[rptInvoice.Controls.Count - 1].Controls[0].FindControl("lblTotTaxes") as Label).Text = OtrChargesTot.ToString();
         lblOthercharge.Text = OtrChargesTot.ToString();

            double TotSGST = dt.Select().Sum(p => Convert.ToDouble(p["nClntCGst"]));
         //   (rptInvoice.Controls[rptInvoice.Controls.Count - 1].Controls[0].FindControl("lblClntSGst") as Label).Text = TotSGST.ToString();
            lblTotSGST.Text = TotSGST.ToString();

            double TotCGST = dt.Select().Sum(p => Convert.ToDouble(p["nClntSGst"]));
          //  (rptInvoice.Controls[rptInvoice.Controls.Count - 1].Controls[0].FindControl("lblClntCGst") as Label).Text = TotCGST.ToString();
            lblTotCGST.Text = TotCGST.ToString();

            double TotIGST = dt.Select().Sum(p => Convert.ToDouble(p["nClntIGst"]));
           // (rptInvoice.Controls[rptInvoice.Controls.Count - 1].Controls[0].FindControl("lblClntIGst") as Label).Text = TotIGST.ToString();
            lblTotIGST.Text = TotIGST.ToString();

            double TotDiscount = dt.Select().Sum(p => Convert.ToDouble(p["nDiscount"]));
          //  (rptInvoice.Controls[rptInvoice.Controls.Count - 1].Controls[0].FindControl("lblDiscount") as Label).Text = TotDiscount.ToString();
          //  lblTotDiscount.Text = TotDiscount.ToString();

            double TotTds = dt.Select().Sum(p => Convert.ToDouble(p["nClntTdsAmount"]));
          //  (rptInvoice.Controls[rptInvoice.Controls.Count - 1].Controls[0].FindControl("lblClntTdsAmount") as Label).Text = totalBase.ToString();
         //   lblTotTds.Text = TotTds.ToString();

            double TotAmt = dt.Select().Sum(p => Convert.ToDouble(p["nSellingRate"]));
            //   (rptInvoice.Controls[rptInvoice.Controls.Count - 1].Controls[0].FindControl("lblSellingCost") as Label).Text = totalBase.ToString();
            lblTotAmt.Text = TotAmt.ToString();

            double TotPaid = dt.Select().Sum(p => Convert.ToDouble(p["nPaidAmount"]));
            lblTotPaid.Text = TotPaid.ToString();
            double TotBal = dt.Select().Sum(p => Convert.ToDouble(p["nBalance"]));
            lblTotBalance.Text = TotBal.ToString();
        }

    }

    public void CalculateAgentAmount()
    {

    }
    public void GetSupFormData()
    {
        DataTable dt = objClassdet.viewData(objClassdet, "ShowSearch", "");
        if (dt.Rows.Count > 0)
        {
            lblVType.Text = "SUUPLIER";
            //Main Company details
            imgComp.ImageUrl = "../../Uploads/" + dt.Rows[0]["sCompanyImage"].ToString();
            lblCompanyName.Text = dt.Rows[0]["sCompanyName"].ToString();
            lblAddress.Text = dt.Rows[0]["scompAdd"].ToString();
            lblPhoneNo.Text = dt.Rows[0]["sCompPhone"].ToString();
            lblFax.Text = dt.Rows[0]["sCompFax"].ToString();
            lblEmail.Text = dt.Rows[0]["sCompEmail"].ToString();
            lblWebsite.Text = dt.Rows[0]["sCompWebsite"].ToString();


            //Agent Details
            lblAgentName.Text = dt.Rows[0]["sVisaBuyCompany"].ToString();
            lblAgentAdd.Text = dt.Rows[0]["sSupAdd"].ToString();
            lblAgntCity.Text = dt.Rows[0]["sSupCity"].ToString();
            lblAgentCountry.Text = dt.Rows[0]["sSupCountry"].ToString();
            lblAgentPhoneNo.Text = dt.Rows[0]["sSupPhone"].ToString();
            lblAgentFax.Text = dt.Rows[0]["sSupFax"].ToString();
            lblAgentEmail.Text = dt.Rows[0]["sSupEmail"].ToString();
            lblAgentWebsite.Text = dt.Rows[0]["sSupWebsite"].ToString();
            lblAgentGstNo.Text = dt.Rows[0]["sSupGst"].ToString();
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
            // objClassdet.FillReapter(objClassdet, rptInvoice, "ShowSearch", "");


            rptSupInvoice.DataSource = dt;
            rptSupInvoice.DataBind();

            double totalBase = dt.Select().Sum(p => Convert.ToDouble(p["nCost"]));
            //   (rptInvoice.Controls[rptInvoice.Controls.Count - 1].Controls[0].FindControl("lblBase") as Label).Text = totalBase.ToString();
            lblSupTotFare.Text = totalBase.ToString();


            double SCTot = dt.Select().Sum(p => Convert.ToDouble(p["nSupSCAmount"]));
            //   (rptInvoice.Controls[rptInvoice.Controls.Count - 1].Controls[0].FindControl("lblSC") as Label).Text = SCTot.ToString();
            lblSupTotSC.Text = SCTot.ToString();



            double TotSGST = dt.Select().Sum(p => Convert.ToDouble(p["nSupCGst"]));
            //   (rptInvoice.Controls[rptInvoice.Controls.Count - 1].Controls[0].FindControl("lblClntSGst") as Label).Text = TotSGST.ToString();
            lblSupTotSGST.Text = TotSGST.ToString();

            double TotCGST = dt.Select().Sum(p => Convert.ToDouble(p["nSupSGst"]));
            //  (rptInvoice.Controls[rptInvoice.Controls.Count - 1].Controls[0].FindControl("lblClntCGst") as Label).Text = TotCGST.ToString();
            lblSupTotCGST.Text = TotCGST.ToString();

            double TotIGST = dt.Select().Sum(p => Convert.ToDouble(p["nSupIGst"]));
            // (rptInvoice.Controls[rptInvoice.Controls.Count - 1].Controls[0].FindControl("lblClntIGst") as Label).Text = TotIGST.ToString();
            lblSupTotIGST.Text = TotIGST.ToString();

            double TotDiscount = dt.Select().Sum(p => Convert.ToDouble(p["nSupDiscount"]));
            //  (rptInvoice.Controls[rptInvoice.Controls.Count - 1].Controls[0].FindControl("lblDiscount") as Label).Text = TotDiscount.ToString();
             // lblTotDiscount.Text = TotDiscount.ToString();

            double TotTds = dt.Select().Sum(p => Convert.ToDouble(p["nSupTDSAmount"]));
            //  (rptInvoice.Controls[rptInvoice.Controls.Count - 1].Controls[0].FindControl("lblClntTdsAmount") as Label).Text = totalBase.ToString();
            //   lblTotTds.Text = TotTds.ToString();

            double TotAmt = dt.Select().Sum(p => Convert.ToDouble(p["nBuyingRate"]));
            lblSupTotAmt.Text = TotAmt.ToString();

            double TotPaid = dt.Select().Sum(p => Convert.ToDouble(p["nSupPaidAmount"]));
            lblSupTotPaid.Text = TotPaid.ToString();

            double TotBal = dt.Select().Sum(p => Convert.ToDouble(p["nSupBalance"]));
            lblSupTotBalance.Text = TotBal.ToString();

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