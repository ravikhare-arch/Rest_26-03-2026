using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Tradding_rptpo : System.Web.UI.Page
{
    tsalesorder_Class objClass = new tsalesorder_Class();
    tsalesorder_det_Class objClassDet = new tsalesorder_det_Class();
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
            objClassDet.FillGrid(objClassDet, GridView1, "rptsalesorderdet", Session["eid"].ToString());
        }
        catch (Exception ex)
        {
            //  valobj.showMsg(ex.Message, lblmsg);
        }
    }
    public void GetFormData()
    {
        DataTable dt = objClass.viewData(objClass, "rptsalesorder", Session["eid"].ToString());
        if (dt.Rows.Count > 0)
        {


           
            lblSONo.Text = dt.Rows[0]["sSalesOrderNo"].ToString();
           // lblVoucherType.Text = dt.Rows[0][2].ToString();
            lblDate.Text =validation.TextToDate(dt.Rows[0]["dtSalesOrder"].ToString());
            lblDelivertDate.Text = validation.TextToDate(dt.Rows[0]["dtDelivery"].ToString());
            lblCompanyName.Text = dt.Rows[0]["sAccountTitle"].ToString();
            lblCompanyName1.Text = dt.Rows[0]["sAccountTitle"].ToString();
            //lblcompanyname2.text = dt.rows[0][4].tostring();
           // lblcperson.Text = dt.Rows[0][6].ToString();


            lblcompanyAdd.Text = dt.Rows[0]["sAddress"].ToString();
            lblPhone.Text = dt.Rows[0]["sPhoneNo1"].ToString();
            lblFax.Text = dt.Rows[0]["sFaxNo"].ToString();
            lblEmail.Text = dt.Rows[0]["sEmailID"].ToString();
            lblWebsite.Text = dt.Rows[0]["sWebsite"].ToString();
            lblSubTot.Text = dt.Rows[0]["SubTotal"].ToString();
            lblDiscount.Text = dt.Rows[0]["nDiscount"].ToString();
            lblShippingCost.Text = dt.Rows[0]["nShipingCost"].ToString();
            lblOtherCost.Text = dt.Rows[0]["nOtherCharges"].ToString();
            lblTotalTax.Text = dt.Rows[0]["TotTax"].ToString();
            lblGrandtotal.Text = dt.Rows[0]["GTotal"].ToString();
        }
    }
}