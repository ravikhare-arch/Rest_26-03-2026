using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Accounting_rptjournal_voucher : System.Web.UI.Page
{
    tacc_journal_voucher_Class objClass = new tacc_journal_voucher_Class();
    tacc_journal_voucherdet_Class objClassDet = new tacc_journal_voucherdet_Class();
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["ConfigID"] = "1";
        GetFormData();
        displayGrid();
    }
    public void displayGrid()
    {
        try
        {
            objClassDet.FillGrid(objClassDet, GridView1, "ShowVoucher", "2");
        }
        catch (Exception ex)
        {
            //  valobj.showMsg(ex.Message, lblmsg);
        }
    }
    public void GetFormData()
    {
        DataTable dt = objClass.viewData(objClass, "ShowVoucher", "2");
        if (dt.Rows.Count > 0)
        {



            lblVoucherNo.Text = dt.Rows[0][1].ToString();
            lblDate.Text = validation.TextToDate(dt.Rows[0][3].ToString());
            lblCompanyName.Text = dt.Rows[0][11].ToString();
            lblCompanyName1.Text = dt.Rows[0][11].ToString();
            //lblcompanyname2.text = dt.rows[0][4].tostring();
            lblcperson.Text = dt.Rows[0][6].ToString();


            lblcompanyAdd.Text = dt.Rows[0][12].ToString();
            //lblCity.Text = dt.Rows[0][14].ToString();
            lblGrandtotal.Text = dt.Rows[0][18].ToString();
            lblSubTot.Text = dt.Rows[0][18].ToString();
            // lblPhone.Text = dt.Rows[0][35].ToString();
            // lblphone2.Text = dt.Rows[0][35].ToString();
            // lblFax.Text = dt.Rows[0][34].ToString();
            //  lblEmail.Text = dt.Rows[0][33].ToString();
            //  lblemail2.Text = dt.Rows[0][33].ToString();
            //lblCustName.Text = dt.Rows[0][9].ToString();

            //lblFlightDest.Text = dt.Rows[0][12].ToString() + " / " + dt.Rows[0][13].ToString();
            // lblFlightDetails.Text = dt.Rows[0][17].ToString() + " / " + dt.Rows[0][11].ToString(); ;

            //lblPNR.Text = dt.Rows[0][16].ToString();
            //   lblRate.Text = dt.Rows[0][22].ToString();
            // lblTax.Text = dt.Rows[0][23].ToString();
            //  lblDiscount.Text = dt.Rows[0][24].ToString();
            // lblTotal.Text = dt.Rows[0][27].ToString();
            //  lblSubTot.Text = dt.Rows[0][29].ToString();
            // lblTaxTot.Text = dt.Rows[0][30].ToString();
            // lblDiscTot.Text = dt.Rows[0][31].ToString();
            //   lblGrandtotal.Text = (Convert.ToInt32(lblSubTot.Text) + Convert.ToInt32(lblTaxTot.Text) - (Convert.ToInt32(lblDiscTot.Text))).ToString();
        }
    }
}