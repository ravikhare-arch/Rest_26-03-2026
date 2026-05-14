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
    SendMail objsendmail = new SendMail();
    tchartof_account_Class objClass = new tchartof_account_Class();
    protected void Page_Load(object sender, EventArgs e)
    {
        invoice.Visible = true;
        PNL0.Visible = false;
        if (Request.QueryString != null)
        {
            // lblDate.Text = "PERIOD : " + Request.QueryString["dtFrom"].ToString() + "TO" + Request.QueryString["dtTo"].ToString();
            displayData();
        }
    }
    public void displayData()
    {
        try
        {
            objClass.sFirstName = validation.dateToText(Request.QueryString["dtFrom"].ToString());
            objClass.sLastName = validation.dateToText(Request.QueryString["dtTo"].ToString());

            PLQuaterly();
            // objClass.FillReapter(objClass, rptPl, "ProfitLossMonhy", "");
            //objClass.FillReapter(objClass, rptExpense, "ProfitLossExpense", "");

            DataTable dt = objClass.viewData(objClass, "ProfitLossMonthlyTot", "");
            if (dt.Rows.Count > 0)
            {
                lblIncome.Text = dt.Rows[0]["CreditAmount"].ToString();
                lblExp.Text = dt.Rows[0]["DebitAmount"].ToString();
                lblProfitLoss.Text = dt.Rows[0]["nProfitLoss"].ToString();

            }
            PLMonthlyIncomeCategory();
            PLMonthlyIncomeCategoryTotal();
            PLMonthlyExpenseCategory();
            PLMonthlyExpenseCategoryTotal();
        }
        catch (Exception ex)
        {
            //  valobj.showMsg(ex.Message, lblmsg);
        }
    }

    public void PLQuaterly()
    {
        try
        {
            DataTable dtBind = new DataTable();
            DataTable dt = objClass.viewData(objClass, "ProfitLossQuaterly", "");
            if (dt.Rows.Count > 0)
            {
                dtBind.Columns.Add("sDate");
                dtBind.Columns.Add("Income");
                dtBind.Columns.Add("Expenses");
                dtBind.Columns.Add("Total");



                dtBind.Rows.Add(new Object[]{
                    "Jan - March"
                    });
                dtBind.Rows.Add(new Object[]{
                    "April - June"
                    });
                dtBind.Rows.Add(new Object[]{
                    "July - Sep"
                    });
                dtBind.Rows.Add(new Object[]{
                    "Oct - Dec"
                    });

                for (int j = 0; j < 4; j++)
                {
                    if (j == 0)
                    {
                        objClass.sCode = "01";
                        objClass.sFamilyName = "03";
                    }
                    else if (j == 1)
                    {
                        objClass.sCode = "04";
                        objClass.sFamilyName = "06";
                    }
                    else if (j == 2)
                    {
                        objClass.sCode = "07";
                        objClass.sFamilyName = "09";
                    }
                    else if (j == 3)
                    {
                        objClass.sCode = "10";
                        objClass.sFamilyName = "12";
                    }


                    DataTable dtq = objClass.viewData(objClass, "ProfitLossQuaterlyDet", "");
                    //   DataTable dtqDistinct = dtq.DefaultView.ToTable(true, "sVoucherType");


                    if (dtq.Rows.Count > 0)
                    {

                        for (int z = 0; z < dtq.Rows.Count; z++)
                        {
                            for (int x = 0; x < dtq.Columns.Count; x++)
                            {
                                for (int i = 0; i < dtBind.Columns.Count; i++)
                                {
                                    int colname = i + 1;
                                    if (i == dtBind.Columns.Count - 1)
                                        colname = i;
                                    if (x == i)
                                    {
                                        dtBind.Rows[j][colname] = dtq.Rows[z][x].ToString();
                                    }

                                }

                            }
                        }
                    }

                }

                rptPl.DataSource = dtBind;

                rptPl.DataBind();

            }

        }
        catch (Exception ex)
        {

        }

    }

    public void PLMonthlyIncomeCategory()
    {
        try
        {
            DataTable dtBind = new DataTable();
            DataTable dt = objClass.viewData(objClass, "ProfitLossQuaterlyIncome", "");
            if (dt.Rows.Count > 0)
            {
                DataTable dtDistinct = dt.DefaultView.ToTable(true, "sVoucherType");
                DataTable dtDistinctMonths = dt.DefaultView.ToTable(true, "sMonth", "sYear");


                //dtBind.Columns.Add("Category");
                //dtBind.Columns.Add("EXCURSION SALES");
                //dtBind.Columns.Add("HOTEL SALES");
                //dtBind.Columns.Add("SALES INVOICE");
                //dtBind.Columns.Add("TICKET SALES (AIR TICKETS)");
                //dtBind.Columns.Add("VISA SALES");
                for (int i = 0; i < dtDistinct.Rows.Count; i++)
                {
                    dtBind.Columns.Add(dtDistinct.Rows[i]["sVoucherType"].ToString());
                }


                dtBind.Rows.Add(new Object[]{
                    "Jan - March"
                    });
                dtBind.Rows.Add(new Object[]{
                    "April - June"
                    });
                dtBind.Rows.Add(new Object[]{
                    "July - Sep"
                    });
                dtBind.Rows.Add(new Object[]{
                    "Oct - Dec"
                    });


                for (int j = 0; j < 4; j++)
                {


                    if (j == 0)
                    {
                        objClass.sCode = "01";
                        objClass.sFamilyName = "03";
                    }
                    else if (j == 1)
                    {
                        objClass.sCode = "04";
                        objClass.sFamilyName = "06";
                    }
                    else if (j == 2)
                    {
                        objClass.sCode = "07";
                        objClass.sFamilyName = "09";
                    }
                    else if (j == 3)
                    {
                        objClass.sCode = "10";
                        objClass.sFamilyName = "12";
                    }


                    DataTable dtq = objClass.viewData(objClass, "ProfitLossQuaterlyIncomeDet", "");
                    DataTable dtqDistinct = dtq.DefaultView.ToTable(true, "sVoucherType");


                    if (dtq.Rows.Count > 0)
                    {



                        for (int i = 0; i < dtBind.Columns.Count; i++)
                        {
                            int colname = i + 1;
                            if (i == dtBind.Columns.Count - 1)
                                colname = i;
                            string condition = "sVoucherType='" + dtBind.Columns[colname].ColumnName + "'";
                            DataRow[] results = dtq.Select(condition);
                            //foreach (DataRow row in results)
                            //{
                            //    DataRow dr = dtBind.NewRow();

                            //    dr[0] = dtDistinctMonths.Rows[j]["sMonth"].ToString() + " " + dtDistinctMonths.Rows[j]["sYear"].ToString();
                            for (int z = 0; z < dtq.Rows.Count; z++)
                            {
                                if (dtq.Rows[z]["sVoucherType"].ToString() == dtBind.Columns[colname].ColumnName)
                                {
                                    dtBind.Rows[j][colname] = dtq.Rows[z]["Income"].ToString();
                                }
                            }
                            // }
                        }
                    }

                }
            }





            GridView1.DataSource = dtBind;

            GridView1.DataBind();


        }
        catch (Exception ex)
        {
            //  valobj.showMsg(ex.Message, lblmsg);
        }
    }
    public void PLMonthlyIncomeCategoryTotal()
    {
        try
        {
            DataTable dt = objClass.viewData(objClass, "ProfitLossMonthyIncomeCategoryTot", "");
            DataTable dt2 = new DataTable();
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                dt2.Columns.Add(dt.Rows[i]["sVoucherType"].ToString());
                //dt2.Columns.Add();
            }

            dt2.Rows.Add();
            dt2.Rows[0][0] = "";

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                dt2.Rows[0][i] = dt.Rows[i][1];

            }

            GridView2.DataSource = dt2;

            GridView2.DataBind();

        }
        catch (Exception ex)
        {
            //  valobj.showMsg(ex.Message, lblmsg);
        }
    }

    public void PLMonthlyExpenseCategory()
    {
        try
        {
            DataTable dtBind = new DataTable();
            DataTable dt = objClass.viewData(objClass, "ProfitLossQuaterlyExp", "");
            if (dt.Rows.Count > 0)
            {
                DataTable dtDistinct = dt.DefaultView.ToTable(true, "sVoucherType");
                DataTable dtDistinctMonths = dt.DefaultView.ToTable(true, "sMonth", "sYear");


                dtBind.Columns.Add("Date");
                //dtBind.Columns.Add("EXCURSION SALES");
                //dtBind.Columns.Add("HOTEL SALES");
                //dtBind.Columns.Add("SALES INVOICE");
                //dtBind.Columns.Add("TICKET SALES (AIR TICKETS)");
                //dtBind.Columns.Add("VISA SALES");
                for (int i = 0; i < dtDistinct.Rows.Count; i++)
                {
                    dtBind.Columns.Add(dtDistinct.Rows[i]["sVoucherType"].ToString());
                }


                dtBind.Rows.Add(new Object[]{
                    "Jan - March"
                    });
                dtBind.Rows.Add(new Object[]{
                    "April - June"
                    });
                dtBind.Rows.Add(new Object[]{
                    "July - Sep"
                    });
                dtBind.Rows.Add(new Object[]{
                    "Oct - Dec"
                    });


                for (int j = 0; j < 4; j++)
                {


                    if (j == 0)
                    {
                        objClass.sCode = "01";
                        objClass.sFamilyName = "03";
                    }
                    else if (j == 1)
                    {
                        objClass.sCode = "04";
                        objClass.sFamilyName = "06";
                    }
                    else if (j == 2)
                    {
                        objClass.sCode = "07";
                        objClass.sFamilyName = "09";
                    }
                    else if (j == 3)
                    {
                        objClass.sCode = "10";
                        objClass.sFamilyName = "12";
                    }


                    DataTable dtq = objClass.viewData(objClass, "ProfitLossQuaterlyExpDet", "");
                    DataTable dtqDistinct = dtq.DefaultView.ToTable(true, "sVoucherType");


                    if (dtq.Rows.Count > 0)
                    {



                        for (int i = 0; i < dtBind.Columns.Count; i++)
                        {
                            int colname = i + 1;
                            if (i == dtBind.Columns.Count - 1)
                                colname = i;
                            string condition = "sVoucherType='" + dtBind.Columns[colname].ColumnName + "'";
                            DataRow[] results = dtq.Select(condition);
                            //foreach (DataRow row in results)
                            //{
                            //    DataRow dr = dtBind.NewRow();

                            //    dr[0] = dtDistinctMonths.Rows[j]["sMonth"].ToString() + " " + dtDistinctMonths.Rows[j]["sYear"].ToString();
                            for (int z = 0; z < dtq.Rows.Count; z++)
                            {
                                if (dtq.Rows[z]["sVoucherType"].ToString() == dtBind.Columns[colname].ColumnName)
                                {
                                    dtBind.Rows[j][colname] = dtq.Rows[z]["sExpense"].ToString();
                                }
                            }
                            // }
                        }
                    }

                }
            }





            GridView3.DataSource = dtBind;

            GridView3.DataBind();


        }
        catch (Exception ex)
        {
            //  valobj.showMsg(ex.Message, lblmsg);
        }
    }
    public void PLMonthlyExpenseCategory1()
    {
        try
        {
            DataTable dtBind = new DataTable();
            DataTable dt = objClass.viewData(objClass, "ProfitLossMonthyExpCategory", "");
            if (dt.Rows.Count > 0)
            {
                DataTable dtDistinct = dt.DefaultView.ToTable(true, "sVoucherType");
                DataTable dtDistinctMonths = dt.DefaultView.ToTable(true, "sMonth", "sYear");

                dtBind.Columns.Add("Date");
                for (int i = 0; i < dtDistinct.Rows.Count; i++)
                {
                    dtBind.Columns.Add(dtDistinct.Rows[i]["sVoucherType"].ToString());
                }

                for (int i = 0; i < dtDistinctMonths.Rows.Count; i++)
                {
                    DataRow dr = dtBind.NewRow();
                    dr[0] = dtDistinctMonths.Rows[i]["sMonth"].ToString() + " - " + dtDistinctMonths.Rows[i]["sYear"].ToString();
                    dtBind.Rows.Add(dr);
                }


                for (int j = 0; j < dtDistinctMonths.Rows.Count; j++)
                {

                    for (int i = 0; i < dtBind.Columns.Count; i++)
                    {
                        int colname = i + 1;
                        if (i == dtBind.Columns.Count - 1)
                            colname = i;
                        string condition = "sMonth = '" + dtDistinctMonths.Rows[j]["sMonth"].ToString() + "' AND sVoucherType='" + dtBind.Columns[colname].ColumnName + "' AND sYear = '" + dtDistinctMonths.Rows[j]["sYear"].ToString() + "'";
                        DataRow[] results = dt.Select(condition);
                        foreach (DataRow row in results)
                        {
                            DataRow dr = dtBind.NewRow();

                            dr[0] = dtDistinctMonths.Rows[j]["sMonth"].ToString() + " " + dtDistinctMonths.Rows[j]["sYear"].ToString();
                            for (int z = 1; z < dtBind.Columns.Count; z++)
                            {
                                if (z == colname)
                                {
                                    dtBind.Rows[j][z] = row["sExpense"].ToString();
                                }
                            }
                        }
                    }
                }
            }





            GridView3.DataSource = dtBind;

            GridView3.DataBind();


        }
        catch (Exception ex)
        {
            //  valobj.showMsg(ex.Message, lblmsg);
        }
    }
    public void PLMonthlyExpenseCategoryTotal()
    {
        try
        {
            DataTable dt = objClass.viewData(objClass, "ProfitLossMonthyExpCategoryTot", "");
            DataTable dt2 = new DataTable();
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                dt2.Columns.Add(dt.Rows[i]["sVoucherType"].ToString());
                //dt2.Columns.Add();
            }

            dt2.Rows.Add();
            dt2.Rows[0][0] = "";

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                dt2.Rows[0][i] = dt.Rows[i][1];

            }

            GridView4.DataSource = dt2;

            GridView4.DataBind();

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
        string FileName = "PLQ" + "_" + sDate + "_" + sTime;
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

        sFileName = "PLQ" + "_" + sDate + "_" + Stime3 + ".xls";

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
        //  GetFormData();

    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        invoice.Visible = true;
        PNL0.Visible = false;
        displayData();
    }

    protected void SendPdf()
    {
        invoice.Visible = true;
        hidePrint.Visible = false;
        PNL0.Visible = false;
        displayData();

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