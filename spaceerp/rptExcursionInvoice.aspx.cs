using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Travel_rptExcursionInvoice : System.Web.UI.Page
{
    texcursion_booking_Class objClass = new texcursion_booking_Class();
    protected void Page_Load(object sender, EventArgs e)
    {
        GetFormData();
    }
    public void GetFormData()
    {
        DataTable dt = objClass.viewData(objClass, "PrintInv", Session["eid"].ToString());
        if (dt.Rows.Count > 0)
        {
            //Main Company details
            lblCompanyName.Text = dt.Rows[0]["sCompanyName"].ToString();
           // lblCompanyName1.Text = dt.Rows[0]["sCompanyName"].ToString();
            lblAddress.Text = dt.Rows[0]["scompAdd"].ToString();
            lblPhone.Text = dt.Rows[0]["sCompPhone"].ToString();
            lblFax.Text = dt.Rows[0]["sCompFax"].ToString();
            lblEmail.Text = dt.Rows[0]["sCompEmail"].ToString();
            lblWebsite.Text = dt.Rows[0]["sCompWebsite"].ToString();


            //Agent Details
            lblAgent.Text = dt.Rows[0]["sAgentName"].ToString();
            lblAgentAdd.Text = dt.Rows[0]["sAgentAdd"].ToString();
            lblCity.Text = dt.Rows[0]["sAgentCity"].ToString();
            lblCountry.Text = dt.Rows[0]["sAgentCountry"].ToString();
            lblAgentPhone.Text = dt.Rows[0]["sPhoneNo1"].ToString();
            lblAgentFax.Text = dt.Rows[0]["sFaxNo"].ToString();
            lblAgentEmail.Text = dt.Rows[0]["sAgentEmail"].ToString();
            lblAgentWebsite.Text = dt.Rows[0]["sAgentWebsite"].ToString();

            //Booking Details
            lblBookingNo.Text = dt.Rows[0]["sExcursionBookingNo"].ToString();
            lblBookingDate.Text = validation.TextToDate(dt.Rows[0]["dtExcursionBooking"].ToString());

            //Calculation
            lblSc.Text = dt.Rows[0]["nProfitAmount"].ToString();
            lblSubTot1.Text = (double.Parse(dt.Rows[0]["nBuyCost"].ToString()) + double.Parse(lblSc.Text)).ToString();
            lblSubTot2.Text = lblSubTot1.Text;
            lblTds.Text = dt.Rows[0]["nClntTdsAmount"].ToString();
            lblCgst.Text = dt.Rows[0]["nClntCGst"].ToString();
            lblSgst.Text = dt.Rows[0]["nClntSGst"].ToString();
            lblIgst.Text = dt.Rows[0]["nClntIGst"].ToString();
            lblDiscount.Text = dt.Rows[0]["nDiscount"].ToString();
            lblGrandTot.Text = dt.Rows[0]["nSellingCost"].ToString();


            //Bottom Details
            lblCompany3.Text = dt.Rows[0]["sCompanyName"].ToString();
            lblComEmail2.Text = dt.Rows[0]["sCompEmail"].ToString();
            lblComWebsite2.Text = dt.Rows[0]["sCompWebsite"].ToString();
            lblComPhone2.Text = dt.Rows[0]["sCompPhone"].ToString();

            //Bind Data Grid
            rptDetails.DataSource = dt;
            rptDetails.DataBind();
        }
     
    }
}