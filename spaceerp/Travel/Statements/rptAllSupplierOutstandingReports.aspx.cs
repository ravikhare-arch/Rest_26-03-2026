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
    msupplier_Class objClass = new msupplier_Class();
    mcompany_Class objComp = new mcompany_Class();
    //   tgroupmofadet_Class objClassdet = new tgroupmofadet_Class();
    SendMail objsendmail = new SendMail();
    protected void Page_Load(object sender, EventArgs e)
    {
        invoice.Visible = true;
        
        PNL0.Visible = false;
       
            objClass.dtJoiningDate = validation.dateToText(Request.QueryString["DtOSFrom"].ToString());
            objClass.sAgencyName = validation.dateToText(Request.QueryString["DtOSTo"].ToString());
            GetAgentFormData();

        

    }
    public void GetAgentFormData()
    {
        DataTable dtC = objComp.viewData(objComp, "ShowComp", Session["ConfigID"].ToString());
        if (dtC.Rows.Count > 0)
        {
            //Main Company details
            //  lblVType.Text = "AGENT";
            imgComp.ImageUrl = "../../Uploads/" + dtC.Rows[0]["sLogoImage"].ToString();
            lblCompanyName.Text = dtC.Rows[0]["sCompanyName"].ToString();
            lblAddress.Text = dtC.Rows[0]["sAddress"].ToString();
            lblCountry.Text = dtC.Rows[0]["sCountryName"].ToString();

            lblCity.Text = dtC.Rows[0]["sCityName"].ToString();
            lblPhoneNo.Text = dtC.Rows[0]["nOffTele"].ToString();
            // lblFax.Text = dt.Rows[0]["sCompFax"].ToString();
            lblEmail.Text = dtC.Rows[0]["sEmail"].ToString();
            lblWebsite.Text = dtC.Rows[0]["sWebsite"].ToString();
            lblCompGstNo.Text = dtC.Rows[0]["sGSTNo"].ToString();
        }
        DataTable dt = objClass.viewData(objClass, "ShowSupOutstanding", "");
        if (dt.Rows.Count > 0)
        {

           




            rptInvoice.DataSource = dt;
            rptInvoice.DataBind();

            double Debit = dt.Select().Sum(p => Convert.ToDouble(p["nDebit"]));
            lblDebit.Text = Debit.ToString();

            double Credit = dt.Select().Sum(p => Convert.ToDouble(p["nCredit"]));
            lblCredit.Text = Credit.ToString();


            double totalBalance = dt.Select().Sum(p => Convert.ToDouble(p["nBalance"]));
            lblBalance.Text = totalBalance.ToString();


        }

    }

    public void CalculateAgentAmount()
    {

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