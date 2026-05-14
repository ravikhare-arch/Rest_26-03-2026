using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Accounting_tgeneral_Statement : System.Web.UI.Page
{
    tvisadet_Class ObjAccTitle = new tvisadet_Class();
    mmain_account_Class ObjAcc = new mmain_account_Class();
    mbranches_Class objLoc = new mbranches_Class();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            objLoc.ddlOperation(objLoc, "Showddl", "", ddlLocation);  
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
   
}