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
    tchartof_account_Class objClass = new tchartof_account_Class();
    SendMail objsendmail = new SendMail();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString != null)
        {
            invoice.Visible = true;
            PNL0.Visible = false;
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
            PLMonthlyTotal();
            PLMonthlyIncomeCategory();
            //   PLMonthlyIncomeCategoryTotal();
            PLMonthlyExpenseCategory();
            //  PLMonthlyExpenseCategoryTotal();

            //  PLMonthlyTotal();
        }
        catch (Exception ex)
        {
            //  valobj.showMsg(ex.Message, lblmsg);
        }
    }
    public void PLMonthlyTotal()
    {
        try
        {
            // objClass.FillReapter(objClass, rptPl, "ProfitLossMonhy", "");
            //  DataTable PLMonth = objClass.viewData(objClass, "ProfitLossMonhy", "");

         //   objClass.FillReapter(objClass, rptPl, "ProfitLossMonhy", "");
            //objClass.FillReapter(objClass, rptExpense, "ProfitLossExpense", "");

            

            DataTable dtPl = objClass.viewData(objClass, "ProfitLossMonhy", "");
            DataTable TaxMonth = objClass.viewData(objClass, "GSTMonthDet", "");

            DataTable dtFinalPl = new DataTable();

            dtFinalPl = dtPl.Copy();
            
            dtFinalPl.Columns.Add("nTax");
            dtFinalPl.Columns.Add("nPl");

            for (int j = 0; j < dtFinalPl.Rows.Count; j++)
            {

                dtFinalPl.Rows[j]["nTax"] = TaxMonth.Rows[j]["totTax"].ToString();

                dtFinalPl.Rows[j]["nPl"] = (double.Parse(dtFinalPl.Rows[j]["nTotal"].ToString()) - double.Parse(dtFinalPl.Rows[j]["nTax"].ToString()));
            }


            rptPl.DataSource = dtFinalPl;

            rptPl.DataBind();

            DataTable dt = objClass.viewData(objClass, "ProfitLossMonthlyTot", "");
            if (dt.Rows.Count > 0)
            {
                lblIncome.Text = dt.Rows[0]["CreditAmount"].ToString();
                lblExp.Text = dt.Rows[0]["DebitAmount"].ToString();
                lblProfitLoss.Text = dt.Rows[0]["nProfitLoss"].ToString();

            }
            DataTable dtGstTot = objClass.viewData(objClass, "GST", "");
            if (dtGstTot.Rows.Count > 0)
            {
                lblTax.Text = dtGstTot.Rows[0]["totTax"].ToString();
                

            }
            lblFinalPL.Text = (double.Parse(lblProfitLoss.Text) - double.Parse(lblTax.Text)).ToString();

           
        }
        catch (Exception ex)
        {
            //  valobj.showMsg(ex.Message, lblmsg);
        }
    }

    public void PLMonthlyIncomeCategory()
    {
        try
        {
            DataTable dtBind = new DataTable();
            DataTable dt = objClass.viewData(objClass, "ProfitLossMonthyIncomeCategory", "");
            if (dt.Rows.Count > 0)
            {
                DataTable dtDistinct = dt.DefaultView.ToTable(true, "sVoucherType");
                DataTable dtDistinctMonths = dt.DefaultView.ToTable(true, "sMonth", "sYear");

                dtBind.Columns.Add("Category");
                for (int i = 0; i < dtDistinctMonths.Rows.Count; i++)
                {
                    dtBind.Columns.Add(dtDistinctMonths.Rows[i]["sMonth"].ToString() + " - " + dtDistinctMonths.Rows[i]["sYear"].ToString());
                }

                for (int i = 0; i < dtDistinct.Rows.Count; i++)
                {
                    DataRow dr = dtBind.NewRow();
                    dr[0] = dtDistinct.Rows[i]["sVoucherType"].ToString();
                    dtBind.Rows.Add(dr);
                }




                for (int j = 0; j < dtDistinct.Rows.Count; j++)
                {

                    for (int i = 0; i < dtBind.Columns.Count; i++)
                    {
                        int colname = i + 1;
                        if (i == dtBind.Columns.Count - 1)
                            colname = i;

                        var MY = dtBind.Columns[colname].ColumnName.Split('-');
                        string condition = "sMonth = '" + MY[0].Trim() + "' AND sVoucherType='" + dtDistinct.Rows[j]["sVoucherType"] + "' AND sYear = '" + MY[1].Trim() + "'";
                        DataRow[] results = dt.Select(condition);
                        foreach (DataRow row in results)
                        {
                            DataRow dr = dtBind.NewRow();

                            //    dr[0] = dtDistinctMonths.Rows[j]["sMonth"].ToString() + " " + dtDistinctMonths.Rows[j]["sYear"].ToString();
                            for (int z = 1; z < dtBind.Columns.Count; z++)
                            {
                                if (z == colname)
                                {
                                    if (row["sIncome"] != "")
                                    {
                                        dtBind.Rows[j][z] = row["sIncome"].ToString();
                                    }

                                }

                            }
                        }
                    }
                }
            }


            DataRow dr1 = dtBind.NewRow();
            dtBind.Rows.Add(dr1);

            DataTable dtTotIncome = objClass.viewData(objClass, "ProfitLossMonthyIncomeCategoryTot", "");

            for (int x = 0; x < dtBind.Columns.Count; x++)
            {
                // double Tot = 5000;

                if (x == 0)
                {
                    // double Tot = dtBind.Select().Sum(p => Convert.ToDouble(dtBind.Columns[z].ColumnName));
                    dtBind.Rows[dtBind.Rows.Count - 1][x] = "TOTAL";
                }
                else
                {
                    var MY = dtBind.Columns[x].ColumnName.Split('-');
                    string condition = "sMonth = '" + MY[0].Trim() + "' AND sYear = '" + MY[1].Trim() + "'";
                    DataRow[] results = dtTotIncome.Select(condition);

                    foreach (DataRow row in results)
                    {
                        DataRow dr = dtBind.NewRow();

                        //    dr[0] = dtDistinctMonths.Rows[j]["sMonth"].ToString() + " " + dtDistinctMonths.Rows[j]["sYear"].ToString();
                        for (int z = 1; z < dtBind.Columns.Count; z++)
                        {
                            if (z == x)
                            {
                                if (row["sIncome"] != "")
                                {
                                    dtBind.Rows[dtBind.Rows.Count - 1][z] = row["sIncome"].ToString();
                                }
                                else
                                {
                                    dtBind.Rows[dtBind.Rows.Count - 1][z] = "0";
                                }
                            }

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
    public void PLMonthlyIncomeCategory1()
    {
        try
        {
            DataTable dtBind = new DataTable();
            DataTable dt = objClass.viewData(objClass, "ProfitLossMonthyIncomeCategory", "");
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
                                    dtBind.Rows[j][z] = row["sIncome"].ToString();
                                }
                            }
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

    public void PLMonthlyIncomeCategoryTest()
    {
        try
        {
            DataTable dtBind = new DataTable();
            DataTable dt = objClass.viewData(objClass, "ProfitLossMonthyIncomeCategory", "");
            if (dt.Rows.Count > 0)
            {
                DataTable dtDistinct = dt.DefaultView.ToTable(true, "sVoucherType");
                DataTable dtDistinctMonths = dt.DefaultView.ToTable(true, "sMonth", "sYear");

                dtBind.Columns.Add("CATEGORY");
                for (int i = 0; i < dtDistinctMonths.Rows.Count; i++)
                {
                    dtBind.Columns.Add(dtDistinctMonths.Rows[i]["sMonth"].ToString() + " - " + dtDistinctMonths.Rows[i]["sYear"].ToString());

                }

                for (int i = 0; i < dtDistinct.Rows.Count; i++)
                {
                    DataRow dr = dtBind.NewRow();
                    dr[0] = dtDistinct.Rows[i]["sVoucherType"].ToString();
                    dtBind.Rows.Add(dr);
                }


                for (int j = 0; j < dtDistinct.Rows.Count; j++)
                {

                    for (int i = 0; i < dtDistinctMonths.Rows.Count; i++)
                    {

                        string condition = "sMonth = '" + dtDistinctMonths.Rows[i]["sMonth"].ToString() + "' AND sVoucherType='" + dtDistinct.Rows[j][0].ToString() + "' AND sYear = '" + dtDistinctMonths.Rows[i]["sYear"].ToString() + "'";
                        DataRow[] results = dt.Select(condition);

                        foreach (DataRow row in results)
                        {
                            DataRow dr = dtBind.NewRow();





                            //   dr[0] = dtDistinctMonths.Rows[j]["sMonth"].ToString() + " - " + dtDistinctMonths.Rows[j]["sYear"].ToString();
                            for (int y = 0; y < dtBind.Rows.Count; y++)
                            {

                                for (int z = 1; z < dtBind.Columns.Count; z++)
                                {
                                    //int colname = z + 1;
                                    //if (z == dtBind.Columns.Count - 1)
                                    //    colname = z;
                                    string colName = dtBind.Columns[z].ColumnName;
                                    string DtBindColumn = dtDistinctMonths.Rows[i]["sMonth"].ToString() + " - " + dtDistinctMonths.Rows[i]["sYear"].ToString();
                                    if (dtDistinct.Rows[i][0] == dtBind.Rows[y][0] && DtBindColumn == colName)
                                    {
                                        dtBind.Rows[y][z] = row["sIncome"].ToString();
                                    }
                                }
                            }

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
            DataTable dt = objClass.viewData(objClass, "ProfitLossMonthyExpCategory", "");
            if (dt.Rows.Count > 0)
            {
                DataTable dtDistinct = dt.DefaultView.ToTable(true, "sVoucherType");
                DataTable dtDistinctMonths = dt.DefaultView.ToTable(true, "sMonth", "sYear");

                dtBind.Columns.Add("Category");
                for (int i = 0; i < dtDistinctMonths.Rows.Count; i++)
                {
                    dtBind.Columns.Add(dtDistinctMonths.Rows[i]["sMonth"].ToString() + " - " + dtDistinctMonths.Rows[i]["sYear"].ToString());
                }

                for (int i = 0; i < dtDistinct.Rows.Count; i++)
                {
                    DataRow dr = dtBind.NewRow();
                    dr[0] = dtDistinct.Rows[i]["sVoucherType"].ToString();
                    dtBind.Rows.Add(dr);
                }


                for (int j = 0; j < dtDistinct.Rows.Count; j++)
                {

                    for (int i = 0; i < dtBind.Columns.Count; i++)
                    {
                        int colname = i + 1;
                        if (i == dtBind.Columns.Count - 1)
                            colname = i;

                        var MY = dtBind.Columns[colname].ColumnName.Split('-');
                        string condition = "sMonth = '" + MY[0].Trim() + "' AND sVoucherType='" + dtDistinct.Rows[j]["sVoucherType"] + "' AND sYear = '" + MY[1].Trim() + "'";
                        // string condition = "sMonth = '" + dtDistinctMonths.Rows[j]["sMonth"].ToString() + "' AND sVoucherType='" + dtBind.Columns[colname].ColumnName + "' AND sYear = '" + dtDistinctMonths.Rows[j]["sYear"].ToString() + "'";
                        DataRow[] results = dt.Select(condition);
                        foreach (DataRow row in results)
                        {
                            DataRow dr = dtBind.NewRow();

                            //  dr[0] = dtDistinctMonths.Rows[j]["sMonth"].ToString() + " " + dtDistinctMonths.Rows[j]["sYear"].ToString();
                            for (int z = 1; z < dtBind.Columns.Count; z++)
                            {
                                if (z == colname)
                                {
                                    if (row["sExpense"] != "")
                                    {
                                        dtBind.Rows[j][z] = row["sExpense"].ToString();
                                    }

                                }


                            }
                        }
                    }
                }
            }


            DataRow dr1 = dtBind.NewRow();
            dtBind.Rows.Add(dr1);

            DataTable dtTotExp = objClass.viewData(objClass, "ProfitLossMonthyExpCategoryTot", "");

            for (int x = 0; x < dtBind.Columns.Count; x++)
            {
                // double Tot = 5000;

                if (x == 0)
                {
                    // double Tot = dtBind.Select().Sum(p => Convert.ToDouble(dtBind.Columns[z].ColumnName));
                    dtBind.Rows[dtBind.Rows.Count - 1][x] = "TOTAL";
                }
                else
                {
                    var MY = dtBind.Columns[x].ColumnName.Split('-');
                    string condition = "sMonth = '" + MY[0].Trim() + "' AND sYear = '" + MY[1].Trim() + "'";
                    DataRow[] results = dtTotExp.Select(condition);

                    foreach (DataRow row in results)
                    {
                        DataRow dr = dtBind.NewRow();

                        //    dr[0] = dtDistinctMonths.Rows[j]["sMonth"].ToString() + " " + dtDistinctMonths.Rows[j]["sYear"].ToString();
                        for (int z = 1; z < dtBind.Columns.Count; z++)
                        {
                            if (z == x)
                            {
                                if (row["sExpense"] != "")
                                {
                                    dtBind.Rows[dtBind.Rows.Count - 1][z] = row["sExpense"].ToString();
                                }
                                else
                                {
                                    dtBind.Rows[dtBind.Rows.Count - 1][z] = "0";
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
        string FileName = "PL" + "_" + sDate + "_" + sTime;
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

        sFileName = "PL" + "_" + sDate + "_" + Stime3 + ".xls";

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
        //  displayData();
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        invoice.Visible = true;
        PNL0.Visible = false;
        displayData();
    }
}