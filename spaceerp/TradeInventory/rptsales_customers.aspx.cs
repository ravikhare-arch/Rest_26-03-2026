using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Trading_rptSales : System.Web.UI.Page
{
    tsoinvoice_Class objClass = new tsoinvoice_Class();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            objClass.dtSoInvoice = validation.dateToText(Request.QueryString["dtFrom"]).ToString();
            objClass.sRefNo = validation.dateToText(Request.QueryString["dtTo"].ToString());

            FillDataList();
        }
    }
    public void FillDataList()
    {
        if (Request.QueryString["CustomerID"].ToString() != "0")
        {
            DataTable dtPO = objClass.viewData(objClass, "rptSalesCustomer", Request.QueryString["CustomerID"].ToString());
            if (dtPO.Rows.Count > 0)
            {

                rptSales.DataSource = dtPO;
                rptSales.DataBind();

                GetGrandTotal();

            }
        }
        else
        {
            DataTable dtPO = objClass.viewData(objClass, "rptSalesCustomer", "");
            if (dtPO.Rows.Count > 0)
            {

                rptSales.DataSource = dtPO;
                rptSales.DataBind();

                GetGrandTotal();

            }
        }
    }
    public void GetGrandTotal()
    {
        if (Request.QueryString["CustomerID"].ToString() != "0")
        {
            DataTable dtProfitLoss = objClass.viewData(objClass, "rptSalesCustomerGrandTot", Request.QueryString["CustomerID"].ToString());
            if (dtProfitLoss.Rows.Count > 0)
            {
                LblTotSales.Text = dtProfitLoss.Rows[0]["nTotSalesAmount"].ToString();
                LblTotPurchase.Text = dtProfitLoss.Rows[0]["nTotPurchaseCost"].ToString();
                lblProfit.Text = dtProfitLoss.Rows[0]["nTotalProfitAmount"].ToString();
                lblProfitPercent.Text = dtProfitLoss.Rows[0]["nTotalProfitPercent"].ToString();

            }
        }
        else
        {
            DataTable dtProfitLoss = objClass.viewData(objClass, "rptSalesCustomerGrandTot", "");
            if (dtProfitLoss.Rows.Count > 0)
            {
                LblTotSales.Text = dtProfitLoss.Rows[0]["nTotSalesAmount"].ToString();
                LblTotPurchase.Text = dtProfitLoss.Rows[0]["nTotPurchaseCost"].ToString();
                lblProfit.Text = dtProfitLoss.Rows[0]["nTotalProfitAmount"].ToString();
                lblProfitPercent.Text = dtProfitLoss.Rows[0]["nTotalProfitPercent"].ToString();

            }
        }
    }
    protected void rptSales_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
    {
        HiddenField hiddenCustID = new HiddenField();
        hiddenCustID = (HiddenField)e.Item.FindControl("hdnCustomerID");

        objClass.nCustomerNameID = hiddenCustID.Value.ToString();

        DataTable dtSalesDet = objClass.viewData(objClass, "rptSalesCustomerDet", "");
        Repeater rptCustomerDet = new Repeater();
        rptCustomerDet = (Repeater)e.Item.FindControl("rptSalesDet");
        rptCustomerDet.DataSource = dtSalesDet;
        rptCustomerDet.DataBind();


        //if (dtSubAccount.Rows.Count > 0)
        //{
        //    for (int i = 0; i < dtSubAccount.Rows.Count; i++)
        //    {

        //        DataTable dtSBA = dtSubAccount.Clone();
        //        dtSBA.Rows.Add(new object[] {
        //            i,1,
        //            dtSubAccount.Rows[i]["sSubAccount"].ToString(),
        //             dtSubAccount.Rows[i]["DebitAmount"].ToString(),
        //              dtSubAccount.Rows[i]["CreditAmount"].ToString(),
        //              dtSubAccount.Rows[i]["BalAmount"].ToString()
        //        });

        //        Repeater rpttreeSub = new Repeater();
        //        rpttreeSub = (Repeater)e.Item.FindControl("treetableSub");
        //        rpttreeSub.DataSource = dtSBA;
        //        rpttreeSub.DataBind();

        //        Repeater rpttreeAcc = new Repeater();
        //        rpttreeAcc = (Repeater)e.Item.FindControl("treeAcc");
        //        DataTable dtAccount = objClass.viewData(objClass, "TrialBalanceAcc", dtSubAccount.Rows[i]["sSubAccount"].ToString());
        //        if (dtSubAccount.Rows.Count > 0)
        //        {
        //            rpttreeAcc.DataSource = dtAccount;
        //            rpttreeAcc.DataBind();
        //        }


        //    }



        //}

    }
    protected void treetableSub_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
    {
        HiddenField hiddenSubID = new HiddenField();
        hiddenSubID = (HiddenField)e.Item.FindControl("hdnSub");

        Repeater rpttreeAcc = new Repeater();
        rpttreeAcc = (Repeater)e.Item.FindControl("treeAcc");
        DataTable dtAccount = objClass.viewData(objClass, "TrialBalanceAcc", "");

        rpttreeAcc.DataSource = dtAccount;
        rpttreeAcc.DataBind();



    }
}