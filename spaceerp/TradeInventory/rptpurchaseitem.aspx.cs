using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Trading_rptpurchase : System.Web.UI.Page
{
    tpoinvoice_Class objClass = new tpoinvoice_Class();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            
            FillDataList();
        }
    }
    public void FillDataList()
    {

        DataTable dtPO = objClass.viewData(objClass, "rptPurchaseItem", "POI");
        if (dtPO.Rows.Count > 0)
        {

            treetableSub.DataSource = dtPO;
            treetableSub.DataBind();

           GetGrandTotal();

        }
    }
    public void GetGrandTotal()
    {
        DataTable dtPOB = objClass.viewData(objClass, "rptPurchaseItemGrandTot", "POI");
        if (dtPOB.Rows.Count > 0)
        {
            lbltotalSaleValue.Text = dtPOB.Rows[0]["nGTotal"].ToString();

        }
    }
    protected void treetable_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
    {
        HiddenField hiddenItemID = new HiddenField();
        hiddenItemID = (HiddenField)e.Item.FindControl("hdnItemID");

        DataTable dtSubAccount = objClass.viewData(objClass, "rptPurchaseItemDet", hiddenItemID.Value.ToString());
        Repeater rpttreeAcc = new Repeater();
        rpttreeAcc = (Repeater)e.Item.FindControl("treetableAcc");
        rpttreeAcc.DataSource = dtSubAccount;
        rpttreeAcc.DataBind();


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