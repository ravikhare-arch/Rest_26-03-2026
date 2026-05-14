using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Accounting_tgeneralledger : System.Web.UI.Page
{
    tvisadet_Class ObjAccTitle = new tvisadet_Class();
    mmain_account_Class ObjAcc = new mmain_account_Class();
    mbranches_Class objLoc = new mbranches_Class();
    mairline_Class objAirline = new mairline_Class();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ReportPanel();
            //pnlAirlineSales.Visible = true;
            //pnlAirlineRefund.Visible = false;
            //pnlAirlineTaxes.Visible = false;
            //pnlAirlineSummary.Visible = false;

           // txtdtFrom.Text = validation.fillDate();
         //   txtdtToDate.Text = validation.fillDate();
            objAirline.ddlOperation(objAirline, "Showddl", "", ddlAirline);
            objAirline.ddlOperation(objAirline, "Showddl", "", ddlSummaryAirline);
            objAirline.ddlOperation(objAirline, "Showddl", "", ddlTaxesAirline);
            objAirline.ddlOperation(objAirline, "Showddl", "", ddlRefundAirline);
            objLoc.ddlOperation(objLoc, "Showddl", "", ddlBranches);
            objLoc.ddlOperation(objLoc, "Showddl", "", ddlSummaryBranch);
            objLoc.ddlOperation(objLoc, "Showddl", "", ddlTaxesBranch);
            objLoc.ddlOperation(objLoc, "Showddl", "", ddlRefundBranch);

           
        }

    }
    public void ReportPanel()
    {
        if (Request.QueryString["ReportFor"] != null)
        {
            if (Request.QueryString["ReportFor"].ToString() != "")
            {
                if (Request.QueryString["ReportFor"].ToString() == "AirlineSales")
                {
                    optReport.SelectedValue = "1";

                }
                else if (Request.QueryString["ReportFor"].ToString() == "AirlineRefund")
                {
                    optReport.SelectedValue = "2";
                }
                else if (Request.QueryString["ReportFor"].ToString() == "AirlineTaxes")
                {
                    optReport.SelectedValue = "3";
                }
                else
                {
                    optReport.SelectedValue = "4";
                }

            }
            else
            {
                optReport.SelectedValue = "1";
            }
        }
        else
        {
            optReport.SelectedValue = "1";
        }
        EventArgs e = new EventArgs();
        optReport_SelectedIndexChanged(this, e);
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {

        try
        {
            string url = "Type=" + ddlReportFor.SelectedValue + "&AirlineID=" + ddlAirline.SelectedValue + "&AccountType=" + ddlAccountType.SelectedValue +
            "&AccountTitle=" + ddlAccountTitle.SelectedValue + "&Branches=" + ddlBranches.SelectedValue +
            "&dtFrom=" + txtdtFrom.Text + "&dtTo=" + txtdtToDate.Text;
            if (ddlAccountType.SelectedValue == "7")
            {
                Response.Redirect("rptairline_sales_sup.aspx?" + url);
            }
            else
            {
                Response.Redirect("rptairline_sales_client.aspx?" + url);
            }

        }
        catch (Exception ex)
        {

        }




    }
    protected void ddlReportFor_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlReportFor.SelectedValue == "1")
        {
            ddlAirline.Enabled = false;
            ddlAirline.SelectedValue = "0";
        }
        else
        {
            ddlAirline.Enabled = true;
        }
    }
    protected void optReport_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (optReport.SelectedValue == "1")
        {
            pnlAirlineSales.Visible = true;
            pnlAirlineRefund.Visible = false;
            pnlAirlineTaxes.Visible = false;
            pnlAirlineSummary.Visible = false;
        }
        else if (optReport.SelectedValue == "2")
        {
            pnlAirlineSales.Visible = false;
            pnlAirlineRefund.Visible = true;
            pnlAirlineTaxes.Visible = false;
            pnlAirlineSummary.Visible = false;
        }
        else if (optReport.SelectedValue == "3")
        {
            pnlAirlineSales.Visible = false;
            pnlAirlineRefund.Visible = false;
            pnlAirlineTaxes.Visible = true;
            pnlAirlineSummary.Visible = false;
        }
        else if (optReport.SelectedValue == "4")
        {
            pnlAirlineSales.Visible = false;
            pnlAirlineRefund.Visible = false;
            pnlAirlineTaxes.Visible = false;
            pnlAirlineSummary.Visible = true;
        }
    }
   
    
    
    

  
    protected void ddlAccountType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlAccountType.SelectedValue != "0")
        {
            ObjAcc.ddlOperation(ObjAcc, "ddlAccType", ddlAccountType.SelectedValue, ddlAccountTitle);
        }
        else
        {
            ObjAcc.ddlOperation(ObjAcc, "ShowddlAccount", "", ddlAccountTitle);
        }
    }
    protected void ddlSummaryAccountType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSummaryAccountType.SelectedValue != "0")
        {
            ObjAcc.ddlOperation(ObjAcc, "ddlAccType", ddlSummaryAccountType.SelectedValue, ddlSummaryAcountTitle);
        }
        else
        {
            ObjAcc.ddlOperation(ObjAcc, "ShowddlAccount", "", ddlSummaryAcountTitle);
        }
    }

    protected void ddlSummaryReportFor_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSummaryReportFor.SelectedValue == "1")
        {
            ddlSummaryAirline.Enabled = false;
            ddlSummaryAirline.SelectedValue = "0";
        }
        else
        {
            ddlSummaryAirline.Enabled = true;
        }
    }
    protected void btnSummarySearch_Click(object sender, EventArgs e)
    {
        try
        {
            string url = "Type=" + ddlSummaryReportFor.SelectedValue + "&AirlineID=" + ddlSummaryAirline.SelectedValue + "&AccountType=" + ddlSummaryAccountType.SelectedValue +
            "&AccountTitle=" + ddlSummaryAcountTitle.SelectedValue + "&Branches=" + ddlSummaryBranch.SelectedValue +
            "&dtFrom=" + txtDtSummaryFrom.Text + "&dtTo=" + txtDtSummaryTO.Text;
            if (ddlSummaryAccountType.SelectedValue == "7")
            {
                Response.Redirect("rptairline_sales_summary_sup.aspx?" + url);
            }
            else
            {
                Response.Redirect("rptairline_sales_summary_client.aspx?" + url);
            }

        }
        catch (Exception ex)
        {

        }
        finally
        {

        }
    }
    protected void btnSearchRefund_Click(object sender, EventArgs e)
    {
        try
        {
            string url = "Type=" + ddlRefundReportFor.SelectedValue + "&AirlineID=" + ddlRefundAirline.SelectedValue + "&AccountType=" + ddlAccountTypeRefund.SelectedValue +
            "&AccountTitle=" + ddlRefundAccountTitle.SelectedValue + "&Branches=" + ddlRefundBranch.SelectedValue +
            "&dtFrom=" + txtdtFrom.Text + "&dtTo=" + txtdtToDate.Text;
            if (ddlAccountTypeRefund.SelectedValue == "7")
            {
                Response.Redirect("rptairline_refund_sup.aspx?" + url);
            }
            else
            {
                Response.Redirect("rptairline_refund_client.aspx?" + url);
            }

        }
        catch (Exception ex)
        {

        }
    }
    protected void ddlRefundReportFor_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlRefundReportFor.SelectedValue == "1")
        {
            ddlRefundAirline.Enabled = false;
            ddlRefundAirline.SelectedValue = "0";
        }
        else
        {
            ddlRefundAirline.Enabled = true;
        }
    }
   
    protected void ddlAccountTypeRefund_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlAccountTypeRefund.SelectedValue != "0")
        {
            ObjAcc.ddlOperation(ObjAcc, "ddlAccType", ddlAccountTypeRefund.SelectedValue, ddlRefundAccountTitle);
        }
        else
        {
            ObjAcc.ddlOperation(ObjAcc, "ShowddlAccount", "", ddlRefundAccountTitle);
        }
    }
    protected void ddlTaxReportFor_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTaxReportFor.SelectedValue == "1")
        {
            ddlTaxesAirline.Enabled = false;
            ddlTaxesAirline.SelectedValue = "0";
        }
        else
        {
            ddlTaxesAirline.Enabled = true;
        }
    }
    protected void btnSearchTaxes_Click(object sender, EventArgs e)
    {
        try
        {
            string url = "Type=" + ddlTaxReportFor.SelectedValue + "&AirlineID=" + ddlTaxesAirline.SelectedValue + "&AccountType=" + ddlTaxesAccountType.SelectedValue +
            "&AccountTitle=" + ddlTaxesAccountTitle.SelectedValue + "&Branches=" + ddlTaxesBranch.SelectedValue +
            "&dtFrom=" + txtDtTaxesFrom.Text + "&dtTo=" + txtDtTaxesTO.Text;
            if (ddlTaxesAccountType.SelectedValue == "7")
            {
                Response.Redirect("rptairline_sales_sup.aspx?" + url);
            }
            else
            {
                Response.Redirect("rptairline_sales_client.aspx?" + url);
            }

        }
        catch (Exception ex)
        {

        }
    }
    protected void ddlTaxesAccountType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTaxesAccountType.SelectedValue != "0")
        {
            ObjAcc.ddlOperation(ObjAcc, "ddlAccType", ddlTaxesAccountType.SelectedValue, ddlTaxesAccountTitle);
        }
        else
        {
            ObjAcc.ddlOperation(ObjAcc, "ShowddlAccount", "", ddlTaxesAccountTitle);
        }
    }
}