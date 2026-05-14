using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Tradding_rptpo : System.Web.UI.Page
{
    tpoinvoice_Class objClass = new tpoinvoice_Class();
    tpoinvoice_det_Class objClassDet = new tpoinvoice_det_Class();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                objClass.nConfigID = "1";
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
            objClassDet.FillGrid(objClassDet, GridView1, "rptpoinvoicedet", Session["eid"].ToString());
        }
        catch (Exception ex)
        {
            //  valobj.showMsg(ex.Message, lblmsg);
        }
    }
    public void GetFormData()
    {
        DataTable dt = objClass.viewData(objClass, "rptpoinvoice", Session["eid"].ToString());
        if (dt.Rows.Count > 0)
        {



            lblPONo.Text = dt.Rows[0]["sPoInvoiceNo"].ToString();
            // lblVoucherType.Text = dt.Rows[0][2].ToString();
            lblDate.Text = validation.TextToDate(dt.Rows[0]["dtPoInvoice"].ToString());
            lblCompanyName.Text = dt.Rows[0]["sAccountTitle"].ToString();
            lblCompanyName1.Text = dt.Rows[0]["sAccountTitle"].ToString();
            //lblcompanyname2.text = dt.rows[0][4].tostring();
            // lblcperson.Text = dt.Rows[0][6].ToString();


            lblcompanyAdd.Text = dt.Rows[0]["sAddress"].ToString();
            lblPhone.Text = dt.Rows[0]["sPhoneNo1"].ToString();
            lblFax.Text = dt.Rows[0]["sFaxNo"].ToString();
            lblEmail.Text = dt.Rows[0]["sEmailID"].ToString();
            lblWebsite.Text = dt.Rows[0]["sWebsite"].ToString();

            ////lblSubTot.Text = dt.Rows[0]["SubTotal"].ToString();
            lblSubTot.Text = dt.Rows[0]["TotPrice"].ToString();
            lblDiscount.Text = dt.Rows[0]["nDiscount"].ToString();
            lblShippingCost.Text = dt.Rows[0]["nShipingCost"].ToString();
            lblOtherCost.Text = dt.Rows[0]["nOtherCharges"].ToString();
            lblTotalTax.Text = dt.Rows[0]["TotTax"].ToString();
            lblGrandtotal.Text = dt.Rows[0]["GTotal"].ToString();
            lblTotPaid.Text = dt.Rows[0]["nPaidAmount"].ToString();
            lblBalance.Text = dt.Rows[0]["Balance"].ToString();

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