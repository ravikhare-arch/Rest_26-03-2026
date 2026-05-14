using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Trading_rptStock : System.Web.UI.Page
{
    titem_details_Class objClass = new titem_details_Class();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            //   objClass.dtSoInvoice = validation.dateToText(Request.QueryString["dtFrom"]).ToString();
            //  objClass.sRefNo = validation.dateToText(Request.QueryString["dtTo"].ToString());

            FillDataList();
        }
    }
    public void FillDataList()
    {

        DataTable dtStock = objClass.viewData(objClass, "rptItemStock", "");
        if (dtStock.Rows.Count > 0)
        {

            rptStock.DataSource = dtStock;
            rptStock.DataBind();

            GetGrandTotal();

        }

    }
    public void GetGrandTotal()
    {

        DataTable dtProfitLoss = objClass.viewData(objClass, "rptItemStockValue", "");
        if (dtProfitLoss.Rows.Count > 0)
        {
            LblTotSales.Text = dtProfitLoss.Rows[0]["nStockValue"].ToString();

        }

    }
    protected void rptStock_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
    {
        HiddenField hiddenCategoryID = new HiddenField();
        hiddenCategoryID = (HiddenField)e.Item.FindControl("hdnSubCategotyID");

     //   objClass.nCustomerNameID = hiddenCategoryID.Value.ToString();

        DataTable dtStockDet = objClass.viewData(objClass, "rptItemStockDet", hiddenCategoryID.Value.ToString());
        Repeater rptStockDet = new Repeater();
        rptStockDet = (Repeater)e.Item.FindControl("rptStockDet");
        rptStockDet.DataSource = dtStockDet;
        rptStockDet.DataBind();


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