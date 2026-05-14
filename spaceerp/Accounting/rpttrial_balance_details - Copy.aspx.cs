using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;



public partial class Accounting_rpttrial_balance_details : System.Web.UI.Page
{
    tacc_journal_voucher_Class objClass = new tacc_journal_voucher_Class();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            Session["ConfigID"] = "1";
            FillDataList();
        }
    }
    public void FillDataList()
    {
        DataTable dtTrialB = objClass.viewData(objClass, "TrialBalanceSub", "");
        if (dtTrialB.Rows.Count > 0)
        {
            //DataTable tblPosted = new DataTable();
            //tblPosted.Columns.Add("Row");
            //tblPosted.Columns.Add("VoucherNo");
            //tblPosted.Columns.Add("VoucherDate");
            //tblPosted.Columns.Add("sPostedby");
            //tblPosted.Columns.Add("sVoucherType");
            //tblPosted.Columns.Add("TotDebit");
            //tblPosted.Columns.Add("TotCredit");
            //for (int i = 0; i < dtPosted.Rows.Count; i++)
            //{
            //    tblPosted.Rows.Add(new object[] {
            //        i,
            //        dtPosted.Rows[i]["Voucher No"].ToString(),
            //        dtPosted.Rows[i]["Voucher Date"].ToString(),
            //        dtPosted.Rows[i]["sPostedby"].ToString(),
            //        dtPosted.Rows[i]["sVoucherType"].ToString(),
            //        dtPosted.Rows[i]["TotDebit"].ToString(),
            //        dtPosted.Rows[i]["TotCredit"].ToString(),
            //    });
            //}

            treetable.DataSource = dtTrialB;
            treetable.DataBind();
        }
    }
    protected void treetable_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        HiddenField hiddenID = new HiddenField();
        hiddenID = (HiddenField)e.Item.FindControl("hdn");
        string SubAccount = hiddenID.Value.ToString();

        DataTable dtAccount = objClass.viewData(objClass, "TrialBalanceAcc", SubAccount);
        if (dtAccount.Rows.Count > 0)
        {


            Repeater rpttreeAcc = new Repeater();
            rpttreeAcc = (Repeater)e.Item.FindControl("rpttreeAcc");

            rpttreeAcc.DataSource = dtAccount;
            rpttreeAcc.DataBind();

        }

    }

}
