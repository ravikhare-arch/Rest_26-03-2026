using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Trading_rptItemLedger : System.Web.UI.Page
{
    titem_details_Class objClass = new titem_details_Class();
    //  tacc_journal_voucherdet_Class objClassDet = new tacc_journal_voucherdet_Class();
    protected void Page_Load(object sender, EventArgs e)
    {
        GetFormData();
        if (Request.QueryString["ItemName"] != "" && Request.QueryString["dtFrom"] != "" && Request.QueryString["dtTo"] != "")
        {

            lblDate.Text = Request.QueryString["dtFrom"].ToString() + " To " + Request.QueryString["dtTo"].ToString();
            ItemName.Text = Request.QueryString["ItemName"].ToString();
        }
        displayGrid();
    }
    public void displayGrid()
    {
        try
        {
            objClass.dtExpiry = validation.dateToText(Request.QueryString["dtFrom"].ToString());
            objClass.dtLastOrder = validation.dateToText(Request.QueryString["dtTo"].ToString());
            DataTable dt = objClass.viewData(objClass, "ItemLedgerDet", Request.QueryString["ItemId"].ToString());
            DataTable dtmain = dt.Clone();
            dtmain.Columns.Add("nBalance");

            if (dt.Rows.Count > 0)
            {

                DataTable dt1 = objClass.viewData(objClass, "StockOpeningBalance", Request.QueryString["ItemId"].ToString());
                if (dt1.Rows.Count > 0)
                {
                    dtmain.Rows.Add(
                                    0,
                                    0,
                                    "",
                                    "",
                                    "Opening Balance",
                                    0,
                                    0,
                                    0,
                                    0,
                                    0,
                                    "",
                                    dt1.Rows[0]["nBalance"].ToString()
                                    );
                }
                else
                {
                    dtmain.Rows.Add(
                                    0,
                                    0,
                                    "",
                                    "",
                                    "Opening Balance",
                                    0,
                                    0,
                                    0,
                                    0,
                                    0,
                                    "",
                                    0
                                    );
                }


                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    dtmain.Rows.Add(
                                  dt.Rows[i]["InvoiceID"].ToString(),
                                  dt.Rows[i]["nItemID"].ToString(),
                                  dt.Rows[i]["InvoiceDate"].ToString(),
                                  dt.Rows[i]["InvoiceNo"].ToString(),
                                  dt.Rows[i]["sitemName"].ToString(),
                                  dt.Rows[i]["pUnit"].ToString(),
                                  dt.Rows[i]["CreditQuantity"].ToString(),
                                  dt.Rows[i]["sUnit"].ToString(),
                                  dt.Rows[i]["DebitQuantity"].ToString(),
                                  dt.Rows[i]["GTotal"].ToString(),
                                  dt.Rows[i]["AccountTitle"].ToString(),
                                  (int.Parse(dtmain.Rows[i]["nBalance"].ToString()) + int.Parse(dt.Rows[i]["CreditQuantity"].ToString()) - int.Parse(dt.Rows[i]["DebitQuantity"].ToString())).ToString()
                               );

                }



            }


            GridView1.DataSource = dtmain;
            GridView1.DataBind();


            // objClass.FillGrid(objClass, GridView1, "ItemLedgerDet", Request.QueryString["ItemId"].ToString()); 
        }
        catch (Exception ex)
        {
            //  valobj.showMsg(ex.Message, lblmsg);
        }
    }
    public void GetFormData()
    {
        objClass.dtExpiry = validation.dateToText(Request.QueryString["dtFrom"].ToString());
        objClass.dtLastOrder = validation.dateToText(Request.QueryString["dtTo"].ToString());

        DataTable dt = objClass.viewData(objClass, "StockBalance", Request.QueryString["ItemId"].ToString()); // Session["eid"].ToString());
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lblTotCreditQty.Text = dt.Rows[0]["Credit Quantity"].ToString();
                lblTotDebitQty.Text = dt.Rows[0]["Debit Quantity"].ToString();
                lblTotBalanceQty.Text = dt.Rows[0]["nBalance"].ToString();
            }

        }
    }
    protected void rptBalance_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
    {
        HiddenField hiddeninv = new HiddenField();
        hiddeninv = (HiddenField)e.Item.FindControl("hdInvNo");
        string s = hiddeninv.Value.ToString();
        //objClass.dtJournalVoucher = validation.dateToText(Request.QueryString["dtFrom"].ToString());
        //objClass.sPostedby = validation.dateToText(Request.QueryString["dtTo"].ToString());

        //Repeater rpttreeAcc = new Repeater();
        //rpttreeAcc = (Repeater)e.Item.FindControl("treeAcc");
        //DataTable dtAccount = objClass.viewData(objClass, "TrialBalanceAcc", hiddenSub.Value.ToString());

        //rpttreeAcc.DataSource = dtAccount;
        //rpttreeAcc.DataBind();



    }

}