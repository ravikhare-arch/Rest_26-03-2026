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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            pnlGenLedger.Visible = true;
            pnlStatement.Visible = false;
            pnlOutstanding.Visible = false;
            pnlCashBook.Visible = false;

            txtdtFrom.Text = validation.fillDate();
            txtdtToDate.Text = validation.fillDate();
            ObjAcc.ddlOperation(ObjAcc, "ShowddlAccount", "", ddlAccountTitle);

            ObjAcc.ddlOperation(ObjAcc, "ShowVoucher", "", ddlAccType);


            //Statement 
            //  ObjAcc.ddlOperation(ObjAcc, "ShowddlAccount", "", ddlStAccountTitle);

            ObjAcc.ddlOperation(ObjAcc, "ShowddlAccount", "", ddlOSAccount);
            objLoc.ddlOperation(objLoc, "Showddl", "", ddlLocation);
            objLoc.ddlOperation(objLoc, "Showddl", "", ddlOSLocation);

            //Cashbook Dropdown
            ObjAcc.ddlOperation(ObjAcc, "ShowddlAccount", "", ddlAccountCashBook);
        }

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //string fromDate = validation.dateToText(txtdtFrom.Text);
        //string ToDate = validation.dateToText(txtdtToDate.Text);
        if (ddlAccountTitle.SelectedValue != "0")
        {
            DataTable dt = ObjAccTitle.viewData(ObjAccTitle, "ShowAccCode", ddlAccountTitle.SelectedValue);
            if (dt.Rows.Count > 0)
            {
                string AccCode = dt.Rows[0]["sCode"].ToString();
                Response.Redirect("rptGeneralLedger.aspx?AccountID=" + ddlAccountTitle.SelectedValue + "&AccCode=" + AccCode + "&dtFrom=" + txtdtFrom.Text + "&dtTo=" + txtdtToDate.Text + "&vType=" + ddlAccType.SelectedValue);
            }
            else
            {
                string AccCode = "";
                Response.Redirect("rptGeneralLedger.aspx?AccountID=" + ddlAccountTitle.SelectedValue + "&AccCode=" + AccCode + "&dtFrom=" + txtdtFrom.Text + "&dtTo=" + txtdtToDate.Text + "&vType=" + ddlAccType.SelectedValue);
            }
        }


    }
    protected void ddlReportFor_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlReportFor.SelectedValue != "0")
        {
            ObjAcc.ddlOperation(ObjAcc, "ddlAccType", ddlReportFor.SelectedValue, ddlAccountTitle);
        }
        else
        {
            ObjAcc.ddlOperation(ObjAcc, "ShowddlAccount", "", ddlAccountTitle);
        }
    }
    protected void optReport_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (optReport.SelectedValue == "1")
        {
            pnlGenLedger.Visible = true;
            pnlStatement.Visible = false;
            pnlOutstanding.Visible = false;
            pnlCashBook.Visible = false;
        }
        else if (optReport.SelectedValue == "2")
        {
            pnlStatement.Visible = true;
            pnlGenLedger.Visible = false;
            pnlOutstanding.Visible = false;
            pnlCashBook.Visible = false;
        }
        else if (optReport.SelectedValue == "3")
        {
            pnlGenLedger.Visible = false;
            pnlStatement.Visible = false;
            pnlOutstanding.Visible = true;
            pnlCashBook.Visible = false;
        }
        else if (optReport.SelectedValue == "4")
        {
            pnlGenLedger.Visible = false;
            pnlStatement.Visible = false;
            pnlOutstanding.Visible = false;
            pnlCashBook.Visible = true;
        }
    }
    protected void ddlStReportFor_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlStReportFor.SelectedValue != "0")
        {
            ObjAcc.ddlOperation(ObjAcc, "ddlAccType", ddlStReportFor.SelectedValue, ddlStAccountTitle);
        }
        else
        {
            ObjAcc.ddlOperation(ObjAcc, "ShowddlAccount", "", ddlStAccountTitle);
        }
    }
    protected void btnSearchSt_Click(object sender, EventArgs e)
    {
        if (ddlStAccountType.SelectedValue == "1")
        {
            if (ddlStReportFor.SelectedValue == "7")
            {
                Response.Redirect("~/Travel/Statements/tvisa_statement.aspx?AccType=" + ddlStReportFor.SelectedValue + "&SupID=" + ddlStAccountTitle.SelectedValue + "&Loc=" + ddlLocation.SelectedValue + "&DtStFrom=" + txtStdtFrom.Text + "&DtStTo=" + txtStdtToDate.Text);
            }
            else if (ddlStReportFor.SelectedValue == "3")
            {
                Response.Redirect("~/Travel/Statements/tvisa_statement.aspx?AccType=" + ddlStReportFor.SelectedValue + "&Agentid=" + ddlStAccountTitle.SelectedValue + "&Loc=" + ddlLocation.SelectedValue + "&DtStFrom=" + txtStdtFrom.Text + "&DtStTo=" + txtStdtToDate.Text);
            }
            else if (ddlStReportFor.SelectedValue == "12")
            {
                Response.Redirect("~/Travel/Statements/tvisa_statement.aspx?AccType=" + ddlStReportFor.SelectedValue + "&Agentid=" + ddlStAccountTitle.SelectedValue + "&Loc=" + ddlLocation.SelectedValue + "&DtStFrom=" + txtStdtFrom.Text + "&DtStTo=" + txtStdtToDate.Text);
            }
            //Response.Redirect("~/Travel/Statements/tvisa_statement.aspx?AccType=" + ddlStReportFor.SelectedValue + "&AccTitle=" + ddlStAccountTitle.SelectedValue + "&Loc=" + ddlLocation.SelectedValue + "&DtStFrom=" + txtStdtFrom.Text + "&DtStTo=" + txtStdtToDate.Text);
        }
        else if (ddlStAccountType.SelectedValue == "2")
        {

            if (ddlStReportFor.SelectedValue == "7")
            {
                Response.Redirect("~/Travel/Statements/tticketing_statement.aspx?AccType=" + ddlStReportFor.SelectedValue + "&SupID=" + ddlStAccountTitle.SelectedValue + "&Loc=" + ddlLocation.SelectedValue + "&DtStFrom=" + txtStdtFrom.Text + "&DtStTo=" + txtStdtToDate.Text);
            }
            else if (ddlStReportFor.SelectedValue == "3")
            {
                Response.Redirect("~/Travel/Statements/tticketing_statement.aspx?AccType=" + ddlStReportFor.SelectedValue + "&Agentid=" + ddlStAccountTitle.SelectedValue + "&Loc=" + ddlLocation.SelectedValue + "&DtStFrom=" + txtStdtFrom.Text + "&DtStTo=" + txtStdtToDate.Text);
            }
            else if (ddlStReportFor.SelectedValue == "12")
            {
                Response.Redirect("~/Travel/Statements/tticketing_statement.aspx?AccType=" + ddlStReportFor.SelectedValue + "&Agentid=" + ddlStAccountTitle.SelectedValue + "&Loc=" + ddlLocation.SelectedValue + "&DtStFrom=" + txtStdtFrom.Text + "&DtStTo=" + txtStdtToDate.Text);
            }


            //  Response.Redirect("~/Travel/tticketing_statement.aspx?AccType=" + ddlStReportFor.SelectedValue + "&AccTitle=" + ddlStAccountTitle.SelectedValue + "&Loc=" + ddlLocation.SelectedValue + "&DtStFrom=" + txtStdtFrom.Text + "&DtStTo=" + txtStdtToDate.Text);
        }
        else if (ddlStAccountType.SelectedValue == "3")
        {
            if (ddlStReportFor.SelectedValue == "7")
            {
                Response.Redirect("~/Travel/Statements/thotel_statement.aspx?AccType=" + ddlStReportFor.SelectedValue + "&SupID=" + ddlStAccountTitle.SelectedValue + "&Loc=" + ddlLocation.SelectedValue + "&DtStFrom=" + txtStdtFrom.Text + "&DtStTo=" + txtStdtToDate.Text);
            }
            else if (ddlStReportFor.SelectedValue == "3")
            {
                Response.Redirect("~/Travel/Statements/thotel_statement.aspx?AccType=" + ddlStReportFor.SelectedValue + "&Agentid=" + ddlStAccountTitle.SelectedValue + "&Loc=" + ddlLocation.SelectedValue + "&DtStFrom=" + txtStdtFrom.Text + "&DtStTo=" + txtStdtToDate.Text);
            }
            else if (ddlStReportFor.SelectedValue == "12")
            {
                Response.Redirect("~/Travel/Statements/thotel_statement.aspx?AccType=" + ddlStReportFor.SelectedValue + "&Agentid=" + ddlStAccountTitle.SelectedValue + "&Loc=" + ddlLocation.SelectedValue + "&DtStFrom=" + txtStdtFrom.Text + "&DtStTo=" + txtStdtToDate.Text);
            }
            //Response.Redirect("~/Travel/Statements/thotel_statement.aspx?AccType=" + ddlStReportFor.SelectedValue + "&AccTitle=" + ddlStAccountTitle.SelectedValue + "&Loc=" + ddlLocation.SelectedValue + "&DtStFrom=" + txtStdtFrom.Text + "&DtStTo=" + txtStdtToDate.Text);
        }
        else if (ddlStAccountType.SelectedValue == "4")
        {

            if (ddlStReportFor.SelectedValue == "7")
            {
                Response.Redirect("~/Travel/Statements/texcursion_statement.aspx?AccType=" + ddlStReportFor.SelectedValue + "&SupID=" + ddlStAccountTitle.SelectedValue + "&Loc=" + ddlLocation.SelectedValue + "&DtStFrom=" + txtStdtFrom.Text + "&DtStTo=" + txtStdtToDate.Text);
            }
            else if (ddlStReportFor.SelectedValue == "3")
            {
                Response.Redirect("~/Travel/Statements/texcursion_statement.aspx?AccType=" + ddlStReportFor.SelectedValue + "&Agentid=" + ddlStAccountTitle.SelectedValue + "&Loc=" + ddlLocation.SelectedValue + "&DtStFrom=" + txtStdtFrom.Text + "&DtStTo=" + txtStdtToDate.Text);
            }
            else if (ddlStReportFor.SelectedValue == "12")
            {
                Response.Redirect("~/Travel/Statements/texcursion_statement.aspx?AccType=" + ddlStReportFor.SelectedValue + "&Agentid=" + ddlStAccountTitle.SelectedValue + "&Loc=" + ddlLocation.SelectedValue + "&DtStFrom=" + txtStdtFrom.Text + "&DtStTo=" + txtStdtToDate.Text);
            }
        }
        else if (ddlStAccountType.SelectedValue == "5")
        {
            if (ddlStReportFor.SelectedValue == "7")
            {
                Response.Redirect("~/Travel/Statements/ttrainticket_statement.aspx?AccType=" + ddlStReportFor.SelectedValue + "&SupID=" + ddlStAccountTitle.SelectedValue + "&Loc=" + ddlLocation.SelectedValue + "&DtStFrom=" + txtStdtFrom.Text + "&DtStTo=" + txtStdtToDate.Text);
            }
            else if (ddlStReportFor.SelectedValue == "3")
            {
                Response.Redirect("~/Travel/Statements/ttrainticket_statement.aspx?AccType=" + ddlStReportFor.SelectedValue + "&Agentid=" + ddlStAccountTitle.SelectedValue + "&Loc=" + ddlLocation.SelectedValue + "&DtStFrom=" + txtStdtFrom.Text + "&DtStTo=" + txtStdtToDate.Text);
            }
            else if (ddlStReportFor.SelectedValue == "12")
            {
                Response.Redirect("~/Travel/Statements/ttrainticket_statement.aspx?AccType=" + ddlStReportFor.SelectedValue + "&Agentid=" + ddlStAccountTitle.SelectedValue + "&Loc=" + ddlLocation.SelectedValue + "&DtStFrom=" + txtStdtFrom.Text + "&DtStTo=" + txtStdtToDate.Text);
            }
            //  Response.Redirect("~/Travel/Statements/ttrainticket_statement.aspx?AccType=" + ddlStReportFor.SelectedValue + "&AccTitle=" + ddlStAccountTitle.SelectedValue + "&Loc=" + ddlLocation.SelectedValue + "&DtStFrom=" + txtStdtFrom.Text + "&DtStTo=" + txtStdtToDate.Text);
        }
        else if (ddlStAccountType.SelectedValue == "6")
        {
            if (ddlStReportFor.SelectedValue == "7")
            {
                Response.Redirect("~/Travel/Statements/tbusticket_statement.aspx?AccType=" + ddlStReportFor.SelectedValue + "&SupID=" + ddlStAccountTitle.SelectedValue + "&Loc=" + ddlLocation.SelectedValue + "&DtStFrom=" + txtStdtFrom.Text + "&DtStTo=" + txtStdtToDate.Text);
            }
            else if (ddlStReportFor.SelectedValue == "3")
            {
                Response.Redirect("~/Travel/Statements/tbusticket_statement.aspx?AccType=" + ddlStReportFor.SelectedValue + "&Agentid=" + ddlStAccountTitle.SelectedValue + "&Loc=" + ddlLocation.SelectedValue + "&DtStFrom=" + txtStdtFrom.Text + "&DtStTo=" + txtStdtToDate.Text);
            }
            else if (ddlStReportFor.SelectedValue == "12")
            {
                Response.Redirect("~/Travel/Statements/tbusticket_statement.aspx?AccType=" + ddlStReportFor.SelectedValue + "&Agentid=" + ddlStAccountTitle.SelectedValue + "&Loc=" + ddlLocation.SelectedValue + "&DtStFrom=" + txtStdtFrom.Text + "&DtStTo=" + txtStdtToDate.Text);
            }
            //  Response.Redirect("~/Travel/Statements/tbusticket_statement.aspx?AccType=" + ddlStReportFor.SelectedValue + "&AccTitle=" + ddlStAccountTitle.SelectedValue + "&Loc=" + ddlLocation.SelectedValue + "&DtStFrom=" + txtStdtFrom.Text + "&DtStTo=" + txtStdtToDate.Text);
        }
        else if (ddlStAccountType.SelectedValue == "7")
        {
            if (ddlStReportFor.SelectedValue == "7")
            {
                Response.Redirect("~/Travel/Statements/tcar_statement.aspx?AccType=" + ddlStReportFor.SelectedValue + "&SupID=" + ddlStAccountTitle.SelectedValue + "&Loc=" + ddlLocation.SelectedValue + "&DtStFrom=" + txtStdtFrom.Text + "&DtStTo=" + txtStdtToDate.Text);
            }
            else if (ddlStReportFor.SelectedValue == "3")
            {
                Response.Redirect("~/Travel/Statements/tcar_statement.aspx?AccType=" + ddlStReportFor.SelectedValue + "&Agentid=" + ddlStAccountTitle.SelectedValue + "&Loc=" + ddlLocation.SelectedValue + "&DtStFrom=" + txtStdtFrom.Text + "&DtStTo=" + txtStdtToDate.Text);
            }
            else if (ddlStReportFor.SelectedValue == "12")
            {
                Response.Redirect("~/Travel/Statements/tcar_statement.aspx?AccType=" + ddlStReportFor.SelectedValue + "&Agentid=" + ddlStAccountTitle.SelectedValue + "&Loc=" + ddlLocation.SelectedValue + "&DtStFrom=" + txtStdtFrom.Text + "&DtStTo=" + txtStdtToDate.Text);
            }
            //   Response.Redirect("~/Travel/Statements/tcar_statement.aspx?AccType=" + ddlStReportFor.SelectedValue + "&AccTitle=" + ddlStAccountTitle.SelectedValue + "&Loc=" + ddlLocation.SelectedValue + "&DtStFrom=" + txtStdtFrom.Text + "&DtStTo=" + txtStdtToDate.Text);
        }
        else if (ddlStAccountType.SelectedValue == "8")
        {
            if (ddlStReportFor.SelectedValue == "7")
            {
                Response.Redirect("~/Travel/Statements/tmofa_statement.aspx?AccType=" + ddlStReportFor.SelectedValue + "&SupID=" + ddlStAccountTitle.SelectedValue + "&Loc=" + ddlLocation.SelectedValue + "&DtStFrom=" + txtStdtFrom.Text + "&DtStTo=" + txtStdtToDate.Text);
            }
            else if (ddlStReportFor.SelectedValue == "3")
            {
                Response.Redirect("~/Travel/Statements/tmofa_statement.aspx?AccType=" + ddlStReportFor.SelectedValue + "&Agentid=" + ddlStAccountTitle.SelectedValue + "&Loc=" + ddlLocation.SelectedValue + "&DtStFrom=" + txtStdtFrom.Text + "&DtStTo=" + txtStdtToDate.Text);
            }
            else if (ddlStReportFor.SelectedValue == "12")
            {
                Response.Redirect("~/Travel/Statements/tmofa_statement.aspx?AccType=" + ddlStReportFor.SelectedValue + "&Agentid=" + ddlStAccountTitle.SelectedValue + "&Loc=" + ddlLocation.SelectedValue + "&DtStFrom=" + txtStdtFrom.Text + "&DtStTo=" + txtStdtToDate.Text);
            }
            //Response.Redirect("~/Travel/Statements/tmofa_statement.aspx?AccType=" + ddlStReportFor.SelectedValue + "&AccTitle=" + ddlStAccountTitle.SelectedValue + "&Loc=" + ddlLocation.SelectedValue + "&DtStFrom=" + txtStdtFrom.Text + "&DtStTo=" + txtStdtToDate.Text);
        }
        else if (ddlStAccountType.SelectedValue == "9")
        {
            if (ddlStReportFor.SelectedValue == "7")
            {
                Response.Redirect("~/Travel/Statements/tinsurance_statement.aspx?AccType=" + ddlStReportFor.SelectedValue + "&SupID=" + ddlStAccountTitle.SelectedValue + "&Loc=" + ddlLocation.SelectedValue + "&DtStFrom=" + txtStdtFrom.Text + "&DtStTo=" + txtStdtToDate.Text);
            }
            else if (ddlStReportFor.SelectedValue == "3")
            {
                Response.Redirect("~/Travel/Statements/tinsurance_statement.aspx?AccType=" + ddlStReportFor.SelectedValue + "&Agentid=" + ddlStAccountTitle.SelectedValue + "&Loc=" + ddlLocation.SelectedValue + "&DtStFrom=" + txtStdtFrom.Text + "&DtStTo=" + txtStdtToDate.Text);
            }
            else if (ddlStReportFor.SelectedValue == "12")
            {
                Response.Redirect("~/Travel/Statements/tinsurance_statement.aspx?AccType=" + ddlStReportFor.SelectedValue + "&Agentid=" + ddlStAccountTitle.SelectedValue + "&Loc=" + ddlLocation.SelectedValue + "&DtStFrom=" + txtStdtFrom.Text + "&DtStTo=" + txtStdtToDate.Text);
            }
            //Response.Redirect("~/Travel/Statements/tinsurance_statement.aspx?AccType=" + ddlStReportFor.SelectedValue + "&AccTitle=" + ddlStAccountTitle.SelectedValue + "&Loc=" + ddlLocation.SelectedValue + "&DtStFrom=" + txtStdtFrom.Text + "&DtStTo=" + txtStdtToDate.Text);
        }
        else if (ddlStAccountType.SelectedValue == "10")
        {
            if (ddlStReportFor.SelectedValue == "7")
            {
                Response.Redirect("~/Travel/Statements/tmofarec_statement.aspx?AccType=" + ddlStReportFor.SelectedValue + "&SupID=" + ddlStAccountTitle.SelectedValue + "&Loc=" + ddlLocation.SelectedValue + "&DtStFrom=" + txtStdtFrom.Text + "&DtStTo=" + txtStdtToDate.Text);
            }
            else if (ddlStReportFor.SelectedValue == "3")
            {
                Response.Redirect("~/Travel/Statements/tmofarec_statement.aspx?AccType=" + ddlStReportFor.SelectedValue + "&Agentid=" + ddlStAccountTitle.SelectedValue + "&Loc=" + ddlLocation.SelectedValue + "&DtStFrom=" + txtStdtFrom.Text + "&DtStTo=" + txtStdtToDate.Text);
            }
            else if (ddlStReportFor.SelectedValue == "12")
            {
                Response.Redirect("~/Travel/Statements/tmofarec_statement.aspx?AccType=" + ddlStReportFor.SelectedValue + "&Agentid=" + ddlStAccountTitle.SelectedValue + "&Loc=" + ddlLocation.SelectedValue + "&DtStFrom=" + txtStdtFrom.Text + "&DtStTo=" + txtStdtToDate.Text);
            }
            //    Response.Redirect("~/Travel/Statements/tmofarec_statement.aspx?AccType=" + ddlStReportFor.SelectedValue + "&AccTitle=" + ddlStAccountTitle.SelectedValue + "&Loc=" + ddlLocation.SelectedValue + "&DtStFrom=" + txtStdtFrom.Text + "&DtStTo=" + txtStdtToDate.Text);
        }
        else if (ddlStAccountType.SelectedValue == "11")
        {
            if (ddlStReportFor.SelectedValue == "7")
            {
                Response.Redirect("~/Travel/Statements/tgroupmofa_statement.aspx?AccType=" + ddlStReportFor.SelectedValue + "&SupID=" + ddlStAccountTitle.SelectedValue + "&Loc=" + ddlLocation.SelectedValue + "&DtStFrom=" + txtStdtFrom.Text + "&DtStTo=" + txtStdtToDate.Text);
            }
            else if (ddlStReportFor.SelectedValue == "3")
            {
                Response.Redirect("~/Travel/Statements/tgroupmofa_statement.aspx?AccType=" + ddlStReportFor.SelectedValue + "&Agentid=" + ddlStAccountTitle.SelectedValue + "&Loc=" + ddlLocation.SelectedValue + "&DtStFrom=" + txtStdtFrom.Text + "&DtStTo=" + txtStdtToDate.Text);
            }
            else if (ddlStReportFor.SelectedValue == "12")
            {
                Response.Redirect("~/Travel/Statements/tgroupmofa_statement.aspx?AccType=" + ddlStReportFor.SelectedValue + "&Agentid=" + ddlStAccountTitle.SelectedValue + "&Loc=" + ddlLocation.SelectedValue + "&DtStFrom=" + txtStdtFrom.Text + "&DtStTo=" + txtStdtToDate.Text);
            }
            //    Response.Redirect("~/Travel/Statements/tmofarec_statement.aspx?AccType=" + ddlStReportFor.SelectedValue + "&AccTitle=" + ddlStAccountTitle.SelectedValue + "&Loc=" + ddlLocation.SelectedValue + "&DtStFrom=" + txtStdtFrom.Text + "&DtStTo=" + txtStdtToDate.Text);
        }
        else if (ddlStAccountType.SelectedValue == "12")
        {
            if (ddlStReportFor.SelectedValue == "7")
            {
                Response.Redirect("~/Travel/Statements/tgroup_ticketing_statement.aspx?AccType=" + ddlStReportFor.SelectedValue + "&SupID=" + ddlStAccountTitle.SelectedValue + "&Loc=" + ddlLocation.SelectedValue + "&DtStFrom=" + txtStdtFrom.Text + "&DtStTo=" + txtStdtToDate.Text);
            }
            else if (ddlStReportFor.SelectedValue == "3")
            {
                Response.Redirect("~/Travel/Statements/tgroup_ticketing_statement.aspx?AccType=" + ddlStReportFor.SelectedValue + "&Agentid=" + ddlStAccountTitle.SelectedValue + "&Loc=" + ddlLocation.SelectedValue + "&DtStFrom=" + txtStdtFrom.Text + "&DtStTo=" + txtStdtToDate.Text);
            }
            else if (ddlStReportFor.SelectedValue == "12")
            {
                Response.Redirect("~/Travel/Statements/tgroup_ticketing_statement.aspx?AccType=" + ddlStReportFor.SelectedValue + "&Agentid=" + ddlStAccountTitle.SelectedValue + "&Loc=" + ddlLocation.SelectedValue + "&DtStFrom=" + txtStdtFrom.Text + "&DtStTo=" + txtStdtToDate.Text);
            }
            //    Response.Redirect("~/Travel/Statements/tmofarec_statement.aspx?AccType=" + ddlStReportFor.SelectedValue + "&AccTitle=" + ddlStAccountTitle.SelectedValue + "&Loc=" + ddlLocation.SelectedValue + "&DtStFrom=" + txtStdtFrom.Text + "&DtStTo=" + txtStdtToDate.Text);
        }
    }
    protected void btnOSSearch_Click(object sender, EventArgs e)
    {
        if (ddlOSReportFor.SelectedValue == "7")
        {
            Response.Redirect("~/Travel/Statements/rptSupOutstandingReports.aspx?stype=" + ddlOSAccountType.SelectedValue + "&sMode=PayMade" + "&SupID=" + ddlOSAccount.SelectedValue + "&Agentid=0" + "&Loc=" + ddlOSLocation.SelectedValue + "&DtStFrom=" + txtdtOsFrom.Text + "&DtStTo=" + txtdtOsTo.Text);
        }
        else if (ddlOSReportFor.SelectedValue == "3")
        {
            Response.Redirect("~/Travel/Statements/rptAgentOutstandingReports.aspx?stype=" + ddlOSAccountType.SelectedValue + "&sMode=PayReceive" + "&SupID=0" + "&Agentid=" + ddlOSAccount.SelectedValue + "&Loc=" + ddlOSLocation.SelectedValue + "&DtStFrom=" + txtdtOsFrom.Text + "&DtStTo=" + txtdtOsTo.Text);
        }

    }
    protected void ddlOSReportFor_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlOSReportFor.SelectedValue != "0")
        {
            ObjAcc.ddlOperation(ObjAcc, "ddlAccType", ddlOSReportFor.SelectedValue, ddlOSAccount);
        }
        else
        {
            ObjAcc.ddlOperation(ObjAcc, "ShowddlAccount", "", ddlOSAccount);
        }


    }

    protected void btnOSSearchAll_Click(object sender, EventArgs e)
    {
        if (ddlOSRPTTYPE.SelectedValue == "1")
        {
            Response.Redirect("~/Travel/Statements/rptAllAgentOutstandingReports.aspx?DtOSFrom=" + txtdtOsFrom.Text + "&DtOSTo=" + txtdtOsTo.Text);
        }
        else if (ddlOSRPTTYPE.SelectedValue == "2")
        {
            Response.Redirect("~/Travel/Statements/rptAllSupplierOutstandingReports.aspx?DtOSFrom=" + txtdtOsFrom.Text + "&DtOSTo=" + txtdtOsTo.Text);
        }
    }
    protected void btnSearchCashBook_Click(object sender, EventArgs e)
    {
        if (ddlAccountCashBook.SelectedValue != "0")
        {
            DataTable dt = ObjAccTitle.viewData(ObjAccTitle, "ShowAccCode", ddlAccountCashBook.SelectedValue);
            if (dt.Rows.Count > 0)
            {
                string AccCode = dt.Rows[0]["sCode"].ToString();
                Response.Redirect("rptGeneralLedger.aspx?AccountID=" + ddlAccountCashBook.SelectedValue + "&AccCode=" + AccCode + "&dtFrom=" + txtdtCashBFrom.Text + "&dtTo=" + txtdtCashBTo.Text + "&vType=" + ddlAccType.SelectedValue);
            }
            else
            {
                string AccCode = "";
                Response.Redirect("rptGeneralLedger.aspx?AccountID=" + ddlAccountTitle.SelectedValue + "&AccCode=" + AccCode + "&dtFrom=" + txtdtFrom.Text + "&dtTo=" + txtdtToDate.Text + "&vType=''");
            }
        }
    }
}