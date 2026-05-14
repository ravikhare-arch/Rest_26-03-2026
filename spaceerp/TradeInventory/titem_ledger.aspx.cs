using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Trading_titemledger : System.Web.UI.Page
{
    titem_details_Class ObjItem = new titem_details_Class();

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
           
            txtdtFrom.Text = validation.fillDate();
            txtdtToDate.Text = validation.fillDate();
            ObjItem.ddlOperation(ObjItem, "Show", "", ddlItemName);
           
        }

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //string fromDate = validation.dateToText(txtdtFrom.Text);
        //string ToDate = validation.dateToText(txtdtToDate.Text);
        if(ddlItemName.SelectedValue!="0")
        {
            DataTable dt = ObjItem.viewData(ObjItem, "Show", ddlItemName.SelectedValue);
            if(dt.Rows.Count>0)
            {
               string ItemName = dt.Rows[0]["sitemName"].ToString();
               Response.Redirect("rptItemLedger.aspx?ItemId=" + ddlItemName.SelectedValue + "&ItemName=" + ItemName + "&dtFrom=" + txtdtFrom.Text + "&dtTo=" + txtdtToDate.Text);
            }
           
        }
       
        
    }
}