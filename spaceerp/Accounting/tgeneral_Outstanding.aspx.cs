using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Accounting_tgeneral_Outstanding : System.Web.UI.Page
{
    tvisadet_Class ObjAccTitle = new tvisadet_Class();
    mmain_account_Class ObjAcc = new mmain_account_Class();
    mbranches_Class objLoc = new mbranches_Class();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
          
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
   
}