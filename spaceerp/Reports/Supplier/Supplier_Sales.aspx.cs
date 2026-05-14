using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Reports_Customers_Customer_Sales : System.Web.UI.Page
{
    tvisadet_Class ObjAccTitle = new tvisadet_Class();
    mmain_account_Class ObjAcc = new mmain_account_Class();
    mbranches_Class objLoc = new mbranches_Class();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            pnlGenLedger.Visible = true;
           

            //txtdtFrom.Text = validation.fillDate();
            //txtdtToDate.Text = validation.fillDate();
            ObjAcc.ddlOperation(ObjAcc, "ddlAccType", "7", ddlAccountTitle);

            objLoc.ddlOperation(objLoc, "Showddl", "", ddlBranches);
            
        }

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("rptsupplier_sales.aspx?AccountID=" + ddlAccountTitle.SelectedValue + "&SalesType=" + ddlAccType.SelectedValue + "&Branches=" + ddlBranches.SelectedValue + "&dtFrom=" + txtdtFrom.Text + "&dtTo=" + txtdtToDate.Text);
      
        //if (ddlAccountTitle.SelectedValue != "0")
        //{
        //    DataTable dt = ObjAccTitle.viewData(ObjAccTitle, "ShowAccCode", ddlAccountTitle.SelectedValue);
        //    if (dt.Rows.Count > 0)
        //    {
        //        string AccCode = dt.Rows[0]["sCode"].ToString();
        //        Response.Redirect("rptclient_sales.aspx?AccountID=" + ddlAccountTitle.SelectedValue + "&AccCode=" + AccCode + "&dtFrom=" + txtdtFrom.Text + "&dtTo=" + txtdtToDate.Text + "&vType=" + ddlAccType.SelectedValue);
        //    }
        //    else
        //    {
        //        string AccCode = "";
        //        Response.Redirect("rptGeneralLedger.aspx?AccountID=" + ddlAccountTitle.SelectedValue + "&AccCode=" + AccCode + "&dtFrom=" + txtdtFrom.Text + "&dtTo=" + txtdtToDate.Text + "&vType=" + ddlAccType.SelectedValue);
        //    }
        //}


    }
    protected void ddlReportFor_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlReportFor.SelectedValue == "2")
        {
            ObjAcc.ddlOperation(ObjAcc, "ddlAccType", "7", ddlAccountTitle);
            ddlAccountTitle.Enabled = true;
            RFV5.ValidationGroup = "A";
        }
        else
        {
            ddlAccountTitle.SelectedValue = "0";
            ddlAccountTitle.Enabled = false;
            RFV5.ValidationGroup = "B";
          //  ObjAcc.ddlOperation(ObjAcc, "ShowddlAccount", "3", ddlAccountTitle);
        }
    }
    protected void optReport_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (optReport.SelectedValue == "1")
        {
            pnlGenLedger.Visible = true;
           
        }
        else if (optReport.SelectedValue == "2")
        {
         
        }
        else if (optReport.SelectedValue == "3")
        {
           
        }
        else if (optReport.SelectedValue == "4")
        {
            
        }
    }
}