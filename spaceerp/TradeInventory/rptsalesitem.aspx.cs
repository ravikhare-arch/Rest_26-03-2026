using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Trading_rptsales_item : System.Web.UI.Page
{
    tsoinvoice_Class objClass = new tsoinvoice_Class();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            objClass.dtSoInvoice =validation.dateToText(Request.QueryString["dtFrom"]).ToString();
            objClass.sRefNo = validation.dateToText(Request.QueryString["dtTo"].ToString());
            FillDataList();
        }
    }
    public void FillDataList()
    {

        DataTable dtSalesItem = objClass.viewData(objClass, "rptSalesItem", "");
        if (dtSalesItem.Rows.Count > 0)
        {

            rptsales.DataSource = dtSalesItem;
            rptsales.DataBind();

          GetGrandTotal();

        }
    }
    public void GetGrandTotal()
    {
        DataTable dtProfitLoss = objClass.viewData(objClass, "rptSalesItemDet", "");
        if (dtProfitLoss.Rows.Count > 0)
        {
            LblTotSales.Text = dtProfitLoss.Rows[0]["nTotSalesAmount"].ToString();
            LblTotPurchase.Text = dtProfitLoss.Rows[0]["nTotPurchaseCost"].ToString();
            lblProfit.Text = dtProfitLoss.Rows[0]["nTotalProfitAmount"].ToString();
            lblProfitPercent.Text = dtProfitLoss.Rows[0]["nTotalProfitPercent"].ToString();

        }
    }
   
}