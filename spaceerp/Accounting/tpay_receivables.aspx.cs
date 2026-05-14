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
          
        }

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //string fromDate = validation.dateToText(txtdtFrom.Text);
        //string ToDate = validation.dateToText(txtdtToDate.Text);
        if (optReportType.SelectedValue == "1")
        {

            Response.Redirect("rptpay_receivables.aspx?ReportType=" + optReportType.SelectedValue);
        }
        else
        {
            Response.Redirect("rptpay_receivables.aspx?ReportType=" + optReportType.SelectedValue);
        }
       
       
    }
}