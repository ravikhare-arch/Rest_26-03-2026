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
    mmain_account_Class objAccountTitle = new mmain_account_Class();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            txtdtFrom.Text = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).ToString("dd/MM/yyyy");

            objAccountTitle.ddlOperation(objAccountTitle, "ShowddlAccount", "", ddlCustomer);
            //txtdtFrom.Text = validation.fillDate();
            txtdtToDate.Text = validation.fillDate();
        }

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {

        if (ddlReportType.SelectedValue == "1")
        {

            Response.Redirect("rptsalesitem.aspx?dtFrom=" + txtdtFrom.Text + "&dtTo=" + txtdtToDate.Text);
        }
        else if (ddlReportType.SelectedValue == "2")
        {

            Response.Redirect("rptsales_customers.aspx?dtFrom=" + txtdtFrom.Text + "&dtTo=" + txtdtToDate.Text + "&CustomerID=" + ddlCustomer.SelectedValue);
        }


    }
    protected void ddlReportType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlReportType.SelectedValue == "1")
        {
            ddlCustomer.Enabled = false;
        }
        else
        {
            ddlCustomer.Enabled = true;
        }
    }
}