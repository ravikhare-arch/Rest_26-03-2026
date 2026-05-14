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
        if(ddlAccountTitle.SelectedValue=="1")
        {

            Response.Redirect("rptbalancesheet.aspx?dtFrom=" + txtdtFrom.Text + "&dtTo=" + txtdtToDate.Text);
           
        }
       
    }
}