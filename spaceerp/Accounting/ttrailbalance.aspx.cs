using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Accounting_ttrailbalance : System.Web.UI.Page
{
    mlocation_Class objLocation = new mlocation_Class();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //  objLocation.ddlOperation(objLocation, "Show", "", ddlLocation);
            txtdtFrom.Text = validation.fillDate();
            txtdtToDate.Text = validation.fillDate();
        }

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //string fromDate = validation.dateToText(txtdtFrom.Text);
        //string ToDate = validation.dateToText(txtdtToDate.Text);
        if(ddlReportType.SelectedValue=="1")
        {

            Response.Redirect("rpttrial_balance_details.aspx?dtFrom=" + txtdtFrom.Text + "&dtTo=" + txtdtToDate.Text);
        }
        else if (ddlReportType.SelectedValue == "2")
        {

            Response.Redirect("rpttrialbalance_detailaccount.aspx?dtFrom=" + txtdtFrom.Text + "&dtTo=" + txtdtToDate.Text);
        }
        else if (ddlReportType.SelectedValue == "3")
        {

            Response.Redirect("rpttrialbalance_subaccount.aspx?dtFrom=" + txtdtFrom.Text + "&dtTo=" + txtdtToDate.Text);
        }
        else if (ddlReportType.SelectedValue == "4")
        {

            Response.Redirect("rpttrialbalance_subaccountdet.aspx?dtFrom=" + txtdtFrom.Text + "&dtTo=" + txtdtToDate.Text);
        }
       
    }
}