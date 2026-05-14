using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Accounting_tpostedvoucher : System.Web.UI.Page
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

        Response.Redirect("rptPostedVoucher.aspx?dtFrom=" + txtdtFrom.Text + "&dtTo=" + txtdtToDate.Text + "&VoucherType=" + ddlVoucherType.SelectedValue);
    }
}