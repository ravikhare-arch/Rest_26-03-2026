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

public partial class Accounting_rptreceipt_voucher : System.Web.UI.Page
{
    SendMail objsendmail = new SendMail();
    treceipt_voucher_Class objClass = new treceipt_voucher_Class();
    treceipt_voucherdet_Class objClassDet = new treceipt_voucherdet_Class();
  

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                invoice.Visible = true;
                PNL0.Visible = false;
                string aa = Server.UrlEncode(System.DateTime.Now.ToString());
                //Fillddl.FillPageddl(ddlPageSize);

              //  Session["ConfigID"] = "1";
                GetFormData();
              
            }
        }
        catch (Exception ex)
        {

        }
        finally
        {
        }

    }
    public void displayGrid()
    {
        try
        {
            objClassDet.FillGrid(objClassDet, GridView1, "ShowVoucher", Session["eid"].ToString());
        }
        catch (Exception ex)
        {
            //  valobj.showMsg(ex.Message, lblmsg);
        }
    }
    public void GetFormData()
    {
        DataTable dt = objClass.viewData(objClass, "ShowVoucher", Session["eid"].ToString());
        if (dt.Rows.Count > 0)
        {



            lblVoucherNo.Text = dt.Rows[0][1].ToString();
            lblDate.Text = validation.TextToDate(dt.Rows[0][2].ToString());
            lblVoucherType.Text = dt.Rows[0][3].ToString();
         //   lblCompanyName.Text = dt.Rows[0][8].ToString();
            lblCompanyName1.Text = dt.Rows[0][8].ToString();
            //lblcompanyname2.text = dt.rows[0][4].tostring();
         //   lblcperson.Text = dt.Rows[0][6].ToString();


            lblcompanyAdd.Text = dt.Rows[0][9].ToString();
            //lblCity.Text = dt.Rows[0][14].ToString();
            lblGrandtotal.Text = dt.Rows[0][15].ToString();
            lblSubTot.Text = dt.Rows[0][15].ToString();
            // lblPhone.Text = dt.Rows[0][35].ToString();
            // lblphone2.Text = dt.Rows[0][35].ToString();
            // lblFax.Text = dt.Rows[0][34].ToString();
            //  lblEmail.Text = dt.Rows[0][33].ToString();
            //  lblemail2.Text = dt.Rows[0][33].ToString();
            //lblCustName.Text = dt.Rows[0][9].ToString();

            //lblFlightDest.Text = dt.Rows[0][12].ToString() + " / " + dt.Rows[0][13].ToString();
            // lblFlightDetails.Text = dt.Rows[0][17].ToString() + " / " + dt.Rows[0][11].ToString(); ;

            //lblPNR.Text = dt.Rows[0][16].ToString();
            //   lblRate.Text = dt.Rows[0][22].ToString();
            // lblTax.Text = dt.Rows[0][23].ToString();
            //  lblDiscount.Text = dt.Rows[0][24].ToString();
            // lblTotal.Text = dt.Rows[0][27].ToString();
            //  lblSubTot.Text = dt.Rows[0][29].ToString();
            // lblTaxTot.Text = dt.Rows[0][30].ToString();
            // lblDiscTot.Text = dt.Rows[0][31].ToString();
            //   lblGrandtotal.Text = (Convert.ToInt32(lblSubTot.Text) + Convert.ToInt32(lblTaxTot.Text) - (Convert.ToInt32(lblDiscTot.Text))).ToString();

            //DataTable dt1 = objClassDet.viewData(objClassDet, "ShowVoucher", Session["eid"].ToString());
            //if (dt1.Rows.Count > 0)
            //{
            //  //  dt1.Rows.Add(0, 0, "", "", 0, "", "Total", "", 0.0, 0, dt.Rows[0][15].ToString(), "","", "");
            //}
            //GridView1.DataSource = dt1;
            //GridView1.DataBind();
        }
        displayGrid();
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
        string FileName = "RV" + "_" + sDate + "_" + sTime;
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

        sFileName = "RV" + "_" + sDate + "_" + Stime3 + ".xls";

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
        //GetFormData();
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