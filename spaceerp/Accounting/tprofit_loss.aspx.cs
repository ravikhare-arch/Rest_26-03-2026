using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Accounting_tprofit_loss : System.Web.UI.Page
{
    tchartof_account_Class ObjAccTitle = new tchartof_account_Class();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
           
            txtdtFrom.Text = validation.fillDate();
            txtdtToDate.Text = validation.fillDate();
           // ObjAccTitle.ddlOperation(ObjAccTitle, "Showddl", "", ddlAccountTitle);
           
        }

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //string fromDate = validation.dateToText(txtdtFrom.Text);
        //string ToDate = validation.dateToText(txtdtToDate.Text);
        if(ddlAccountTitle.SelectedValue=="1")
        {
           
                Response.Redirect("rptProfitLoss_Details.aspx?dtFrom=" + txtdtFrom.Text + "&dtTo=" + txtdtToDate.Text);
           
        }
        else if(ddlAccountTitle.SelectedValue=="2")
        {
           
                Response.Redirect("rptProfitLoss_Monthly.aspx?dtFrom=" + txtdtFrom.Text + "&dtTo=" + txtdtToDate.Text);
           
        }
        else if (ddlAccountTitle.SelectedValue == "3")
        {

            Response.Redirect("rptProfitLoss_Quaterly.aspx?dtFrom=" + txtdtFrom.Text + "&dtTo=" + txtdtToDate.Text);

        }
        else if (ddlAccountTitle.SelectedValue == "4")
        {

            Response.Redirect("rptProfitLoss_halfYear.aspx?dtFrom=" + txtdtFrom.Text + "&dtTo=" + txtdtToDate.Text);

        }
        else if (ddlAccountTitle.SelectedValue == "5")
        {

            Response.Redirect("rptProfitLoss_Yearly.aspx?dtFrom=" + txtdtFrom.Text + "&dtTo=" + txtdtToDate.Text);

        }
        
    }
}