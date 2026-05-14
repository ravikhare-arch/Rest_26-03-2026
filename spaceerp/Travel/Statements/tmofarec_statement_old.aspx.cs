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
public partial class Travel_tmofa_statement : System.Web.UI.Page
{
    tmofarecruitement_Class objClass = new tmofarecruitement_Class();
    tmofarecruitementdet_Class objClassDet = new tmofarecruitementdet_Class();
    mmain_account_Class objAccount = new mmain_account_Class();
    mlocation_Class objLoc = new mlocation_Class();
    validation valobj = new validation();
    SendMail objsendmail = new SendMail();
    string cond;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            if (!IsPostBack)
            {
                pnlMain.Visible = true;
                PNL0.Visible = false;
                objAccount.ddlOperation(objAccount, "ddlCustomer", "", ddlSClient);
                objLoc.ddlOperation(objLoc, "Show", "", ddlSLoc);
                objAccount.ddlOperation(objAccount, "ShowddlAccount", "", ddlSSup);
                objClass.ddlOperation(objClass, "Show", "", ddlInvoiceNo);

                displayGrid();

            }
        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, "FAIL", lblmsg);
        }
        finally
        {
        }
    }
    public void displayGrid()
    {
        try
        {
            if (Request.QueryString != null)
            {
                objClassDet.sFullName = "0";
                if (Request.QueryString["AccType"].ToString() == "0")
                {
                    objClassDet.sPassportNo = "0";
                    objClassDet.sPassportType = "0";
                }
                else if (Request.QueryString["AccType"].ToString() == "7")
                {
                    objClassDet.sPassportNo = "0";
                    objClassDet.sPassportType = Request.QueryString["AccTitle"].ToString();
                }
                else if (Request.QueryString["AccType"].ToString() == "3")
                {
                    objClassDet.sPassportNo = Request.QueryString["AccTitle"].ToString();
                    objClassDet.sPassportType = "0";
                }
                else
                {
                    objClassDet.sPassportNo = "0";
                    objClassDet.sPassportType = Request.QueryString["AccTitle"].ToString();
                }

                objClassDet.sPlaceIssue = Request.QueryString["Loc"].ToString();
               // objClassDet.sDeparture = "0";
                objClassDet.dtDOB = validation.dateToText(Request.QueryString["DtStFrom"].ToString());
                string sDate = validation.dateToText(Request.QueryString["DtStTo"].ToString());
                objClassDet.sBirthPlace = "0";
            }
            else
            {
                objClassDet.sFullName = "0";
                objClassDet.sPassportNo = "0";
                objClassDet.sPassportType = "0";
                objClassDet.sPlaceIssue = "0";
                objClassDet.dtDOB = "";
                objClassDet.sBirthPlace = "0";
             //   objClassDet.dtApply = "";
            }



            objClassDet.FillGrid(objClassDet, GridView1, "ShowSearch", "");
        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, lblmsg);
        }
    }

   
    //Search

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            //    if (ddlVisaBookingNo.SelectedValue != "0" || txtdtBooking.Text != "" || ddlVisaBookingNo.SelectedValue != "0" || ddlAgentID.SelectedValue != "0" || ddlLocationID.SelectedValue != "0")
            //    {
            SearchPara();
            displaySearchGrid();


            //  clrfield();
            //}
            //else
            //{
            //    displayGrid();
            //}
        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, lblmsg);
        }
    }
    public void displaySearchGrid()
    {
        try
        {
            objClassDet.FillGrid(objClassDet, GridView1, "ShowSearch", "");

        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, lblmsg);
        }
    }

    public void SearchPara()
    {
       

        objClassDet.sFullName = ddlInvoiceNo.SelectedValue;
        objClassDet.sPassportNo = ddlSClient.SelectedValue;
        objClassDet.sPassportType = ddlSSup.SelectedValue;
        objClassDet.sPlaceIssue = ddlSLoc.SelectedValue;
        objClassDet.dtDOB = "";
        objClassDet.sBirthPlace = ddlSBookType.SelectedValue;
       
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
        tpContent.Visible = false;
        string sDate = validation.fillTextDate();
        string sTime = validation.fillTime();
        string FileName = "MFSTM" + "_" + sDate + "_" + sTime;
        Response.AddHeader("content-disposition", "attachment;filename=" + FileName + ".xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.xls";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        GridView1.RenderControl(htmlWrite);
        Response.Write(stringWrite.ToString());
        Response.End();
        tpContent.Visible = true;
    }
    protected void btnSendMail_Click(object sender, EventArgs e)
    {

        tpContent.Visible = false;
        pnlMain.Visible = false;
        PNL0.Visible = true;
        lnkAttachment.Text = "Invoice.xlx";
    }

    public void Send()
    {
        pnlMain.Visible = true;
        tpContent.Visible = false;
        PNL0.Visible = false;
       

        System.IO.StringWriter sw = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htw = new System.Web.UI.HtmlTextWriter(sw);
        // GridView1.DataSource = dt;
        //  GridView1.DataBind();
        // Render grid view control.

        GridView1.RenderControl(htw);
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

        sFileName = "MFSTM" + "_" + sDate + "_" + Stime3 + ".xls";

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

        pnlMain.Visible = true;
        tpContent.Visible = true;
        objsendmail.Send(txtTo.Text, txtCC.Text, txtBCC.Text, txtSub.Text, txtBody.Text, lnkAttachment.Text);
        Response.Write("<script LANGUAGE='JavaScript' >alert('Email has been sent successfully')</script>");

    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        Send();
        displayGrid();
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        tpContent.Visible = true;
        pnlMain.Visible = true;
        PNL0.Visible = false;
      //  GetFormData();
    }

    protected void SendPdf()
    {
        pnlMain.Visible = true;
        tpContent.Visible = false;
        PNL0.Visible = false;
        //  GetFormData();

        string sDate = validation.fillTextDate();
        string sTime = validation.fillTime();
        string FileName = "MFSTM" + "_" + sDate + "_" + sTime;
        Response.ContentType = "application/pdf";

        Response.AddHeader("content-disposition", "attachment;filename="+FileName+".pdf");

        Response.Cache.SetCacheability(HttpCacheability.NoCache);

        StringWriter sw = new StringWriter();

        HtmlTextWriter hw = new HtmlTextWriter(sw);


        GridView1.RenderControl(hw);

        StringReader sr = new StringReader(sw.ToString());

        Document pdfDoc = new Document(PageSize.A1.Rotate(), 0, 0, 5, 0);

        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);

        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);

        pdfDoc.Open();

        htmlparser.Parse(sr);

        pdfDoc.Close();

        Response.Write(pdfDoc);

        Response.End();
        pnlMain.Visible = true;
        tpContent.Visible = false;
        PNL0.Visible = false;
    }

    protected void btnPdf_Click(object sender, EventArgs e)
    {
        SendPdf();
    }
}