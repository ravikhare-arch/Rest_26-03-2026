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

public partial class Accounting_rptPostedVoucher : System.Web.UI.Page
{
    tacc_journal_voucher_Class objClass = new tacc_journal_voucher_Class();
    SendMail objsendmail = new SendMail();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                invoice.Visible = true;
                PNL0.Visible = false;
                lblDates.Text = Request.QueryString["dtFrom"].ToString() + " To " + Request.QueryString["dtTo"].ToString();
                lblVoucherType.Text = Request.QueryString["VoucherType"].ToString();
                FillDataList();
            }
        }
        catch
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
            // objClass.FillGrid(objClass, DataList1, "ShowVoucher", Session["eid"].ToString());
        }
        catch (Exception ex)
        {
            //  valobj.showMsg(ex.Message, lblmsg);
        }
    }
    public void FillDataList()
    {
        objClass.dtJournalVoucher = validation.dateToText(Request.QueryString["dtFrom"].ToString());
        objClass.sPostedby = validation.dateToText(Request.QueryString["dtTo"].ToString());
        DataTable dtPosted = new DataTable();
        if (Request.QueryString["VoucherType"].ToString()=="All")
        {
            dtPosted = objClass.viewData(objClass, "PostedVoucher", "");
        }
        else
        {
            dtPosted = objClass.viewData(objClass, "PostedVoucher", Request.QueryString["VoucherType"].ToString());
        }
        if (dtPosted.Rows.Count > 0)
        {
            DataTable tblPosted = new DataTable();
            tblPosted.Columns.Add("Row");
            tblPosted.Columns.Add("VoucherNo");
            tblPosted.Columns.Add("VoucherDate");
            tblPosted.Columns.Add("sPostedby");
            tblPosted.Columns.Add("sVoucherType");
            tblPosted.Columns.Add("TotDebit");
            tblPosted.Columns.Add("TotCredit");
            for (int i = 0; i < dtPosted.Rows.Count; i++)
            {
                tblPosted.Rows.Add(new object[] {
                    i,
                    dtPosted.Rows[i]["Voucher No"].ToString(),
                    dtPosted.Rows[i]["Voucher Date"].ToString(),
                    dtPosted.Rows[i]["sPostedby"].ToString(),
                    dtPosted.Rows[i]["sVoucherType"].ToString(),
                    dtPosted.Rows[i]["TotDebit"].ToString(),
                    dtPosted.Rows[i]["TotCredit"].ToString(),
                });
            }

            DataList1.DataSource = tblPosted;
            DataList1.DataBind();
        }
    }
    protected void DataList1_ItemDataBound(object sender, System.Web.UI.WebControls.DataListItemEventArgs e)
    {
        HiddenField hiddenID = new HiddenField();
        hiddenID = (HiddenField)e.Item.FindControl("hdn");
        objClass.sJournalVoucherNo = hiddenID.Value.ToString();
        //int id =         (hdcatid);

        objClass.dtJournalVoucher = validation.dateToText(Request.QueryString["dtFrom"].ToString());
        objClass.sPostedby = validation.dateToText(Request.QueryString["dtTo"].ToString());

        DataTable dtPosted = new DataTable();
        if (Request.QueryString["VoucherType"].ToString() == "All")
        {
            dtPosted = objClass.viewData(objClass, "PostedVoucherDet", "");
        }
        else
        {
            dtPosted = objClass.viewData(objClass, "PostedVoucherDet", Request.QueryString["VoucherType"].ToString());
        }
        if (dtPosted.Rows.Count > 0)
        {


            Repeater rptVoucherDet = new Repeater();
            rptVoucherDet = (Repeater)e.Item.FindControl("Gridview1");

            rptVoucherDet.DataSource = dtPosted;
            rptVoucherDet.DataBind();

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
        string FileName = "PV" + "_" + sDate + "_" + sTime;
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
        displayGrid();

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

        sFileName = "PV" + "_" + sDate + "_" + Stime3 + ".xls";

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
        displayGrid();
        hidePrint.Visible = true;
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        invoice.Visible = true;
        PNL0.Visible = false;
        displayGrid();
    }
}