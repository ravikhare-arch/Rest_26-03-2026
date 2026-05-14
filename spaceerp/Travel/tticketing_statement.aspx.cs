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
public partial class Travel_tticketing_statement : System.Web.UI.Page
{
    tticketing_Class objClass = new tticketing_Class();
    tticketingdet_Class objClassDet = new tticketingdet_Class();
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
                objClass.ddlOperation(objClass, "ShowInvNo", "", ddlInvoiceNo);
                
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
            if(Request.QueryString!=null)
            {
                objClassDet.sReferenceNo = "0";
                if (Request.QueryString["AccType"].ToString() == "0")
                {
                    objClassDet.sCustomerName = "0";
                    objClassDet.sPassportNo = "0";
                }
                else if (Request.QueryString["AccType"].ToString() == "7")
                {
                    objClassDet.sCustomerName = "0";
                    objClassDet.sPassportNo = Request.QueryString["AccTitle"].ToString();
                }
                else if (Request.QueryString["AccType"].ToString() == "3")
                {
                    objClassDet.sCustomerName = Request.QueryString["AccTitle"].ToString();
                    objClassDet.sPassportNo = "0";
                }
                else
                {
                    objClassDet.sCustomerName = "0";
                    objClassDet.sPassportNo = Request.QueryString["AccTitle"].ToString();
                }

                objClassDet.sAirlinePnr = Request.QueryString["Loc"].ToString();
                objClassDet.sDeparture ="0";
                objClassDet.dtTravelDate =validation.dateToText( Request.QueryString["DtStFrom"].ToString());
                objClassDet.dtReturnDate = validation.dateToText(Request.QueryString["DtStTo"].ToString());
            }
            else
            {
                objClassDet.sReferenceNo = "0";
                objClassDet.sCustomerName = "0";
                objClassDet.sPassportNo = "0";
                objClassDet.sAirlinePnr = "0";
                objClassDet.sDeparture = "0";
                objClassDet.dtTravelDate = "";
                objClassDet.dtReturnDate = "";
            }
            


            objClassDet.FillGrid(objClassDet, GridView1, "ShowSearch", "");
        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, lblmsg);
        }
    }

    //protected void btngdEdit_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        Session["eid"] = "";
    //        LinkButton thisbtn = (LinkButton)sender;
    //        GridViewRow thisgrdR = (GridViewRow)thisbtn.Parent.Parent;
    //        int row = thisgrdR.RowIndex;
    //        Label ID = (Label)GridView1.Rows[row].Cells[0].FindControl("lblID");
    //        Session["eid"] = ID.Text;


    //        // DetButtonVisible();
    //        // clrfieldDet();
    //        // displayGridDet();

    //    }
    //    catch (Exception ex)
    //    {
    //        valobj.showMsg(ex.Message, "FAIL", lblmsg);
    //    }
    //}

    //protected void btngdPrint_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        Session["eid"] = "";
    //        LinkButton thisbtn = (LinkButton)sender;
    //        GridViewRow thisgrdR = (GridViewRow)thisbtn.Parent.Parent;
    //        int row = thisgrdR.RowIndex;
    //        Label ID = (Label)GridView1.Rows[row].Cells[0].FindControl("lblID");
    //        Session["eid"] = ID.Text;

    //        Label lblType = (Label)GridView1.Rows[row].Cells[0].FindControl("lblbookType");
    //        if (lblType.Text == "REFUND")
    //        {
    //            Response.Redirect("rptTicketRefund_Invoice.aspx?id=" + ID.Text);
    //        }
    //        else
    //        {
    //            Response.Redirect("rptTicketInvoice.aspx?id=" + ID.Text);
    //        }

    //    }
    //    catch (Exception ex)
    //    {
    //        valobj.showMsg(ex.Message, "FAIL", lblmsg);
    //    }
    //}

    //Search

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            //    if (ddlVisaBookingNo.SelectedValue != "0" || txtdtBooking.Text != "" || ddlVisaBookingNo.SelectedValue != "0" || ddlAgentID.SelectedValue != "0" || ddlLocationID.SelectedValue != "0")
            //    {
            SearchPara();
            displaySearchGrid();
            SearcClr();


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
        objClassDet.sReferenceNo = ddlInvoiceNo.SelectedValue;
        objClassDet.sCustomerName = ddlSClient.SelectedValue;
        objClassDet.sPassportNo = ddlSSup.SelectedValue;
        objClassDet.sAirlinePnr = ddlSLoc.SelectedValue;
        objClassDet.sDeparture = ddlSBookType.SelectedValue;
        objClassDet.dtTravelDate = "";
    }

    public void SearcClr()
    {
        ddlInvoiceNo.SelectedValue = "0";
        ddlSClient.SelectedValue = "0";
        ddlSSup.SelectedValue = "0";
        ddlSLoc.SelectedValue = "0";
        ddlSBookType.SelectedValue = "0";
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
        string FileName = "VSTM" + "_" + sDate + "_" + sTime;
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

        sFileName = "VSTM" + "_" + sDate + "_" + Stime3 + ".xls";

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
        string FileName = "TSTM" + "_" + sDate + "_" + sTime;
        Response.ContentType = "application/pdf";

        Response.AddHeader("content-disposition", "attachment;filename=" + FileName + ".pdf");

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