using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ttravel_expense_invoice : System.Web.UI.Page
{
    ttravel_expense_voucher_Class objClass = new ttravel_expense_voucher_Class();
    ttravel_expense_voucherdet_Class objClassDet = new ttravel_expense_voucherdet_Class();


    validation valobj = new validation();
    string cond;
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            if (!IsPostBack)
            {
                string aa = Server.UrlEncode(System.DateTime.Now.ToString());
                //Fillddl.FillPageddl(ddlPageSize);
                Session["Expense_invoice"] = aa;
                Session["ConfigID"] = "1";
                GetFormData();
                displayGrid();
            }
        }
        catch (Exception ex)
        {

        }
        finally
        {
        }
    }
    public void displayGrid()
    {
        try
        {
            objClassDet.FillGrid(objClassDet, GridView1, "InvPrintDet", Session["eid"].ToString());
        }
        catch (Exception ex)
        {
            //  valobj.showMsg(ex.Message, lblmsg);
        }
    }
    public void GetFormData()
    {
        DataTable dt = objClass.viewData(objClass, "PrintInv", Session["eid"].ToString());
        if (dt.Rows.Count > 0)
        {
            lblBookingNo.Text = dt.Rows[0][3].ToString();
            lblBookDate.Text = validation.TextToDate(dt.Rows[0][5].ToString());
            lblCompanyName.Text = dt.Rows[0][8].ToString();
            lblCompanyName1.Text = dt.Rows[0][8].ToString();
            lblCompanyName2.Text = dt.Rows[0][8].ToString();
           

            lblcompanyAdd.Text = dt.Rows[0][9].ToString();
            //lblCity.Text = dt.Rows[0][14].ToString();
            //lblGrandtotal.Text = dt.Rows[0][17].ToString();
            lblSubTot.Text = dt.Rows[0][14].ToString();
            lblGrandtotal.Text = dt.Rows[0][14].ToString();
            lblPhone.Text = dt.Rows[0][10].ToString();
            lblphone2.Text = dt.Rows[0][10].ToString();
            lblEmail.Text = dt.Rows[0][11].ToString();
            lblFax.Text = dt.Rows[0][12].ToString();
            
            lblemail2.Text = dt.Rows[0][12].ToString();
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