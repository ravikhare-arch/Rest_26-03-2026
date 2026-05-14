using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Travel_TicketInvoice : System.Web.UI.Page
{
    tticketing_Class objClass = new tticketing_Class();


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
                
                Session["tticket_invoice"] = aa;
                Session["ConfigID"] = "1";
                GetFormData();
                
            }
        }
        catch (Exception ex)
        {
           
        }
        finally
        {
        }
    }
    public void GetFormData()
    {
        DataTable dt = objClass.viewData(objClass, "TicInvoice", Session["eid"].ToString());
        if (dt.Rows.Count > 0)
        {
            lblBookingNo.Text = dt.Rows[0][1].ToString();
            lblBookDate.Text =validation.TextToDate(dt.Rows[0][2].ToString());
            lblCompanyName.Text = dt.Rows[0][5].ToString();
            lblCompanyName1.Text = dt.Rows[0][5].ToString();

            lblCompanyName2.Text = dt.Rows[0][5].ToString();
            lblcperson.Text = dt.Rows[0][6].ToString();
            lblrefNo.Text = dt.Rows[0][8].ToString();
            lblCustName.Text = dt.Rows[0][9].ToString();

            lblFlightDest.Text = dt.Rows[0][12].ToString() + " / " + dt.Rows[0][13].ToString();
            lblFlightDetails.Text = dt.Rows[0][17].ToString() + " / " + dt.Rows[0][11].ToString(); ;
           
            lblPNR.Text = dt.Rows[0][16].ToString();
            lblRate.Text = dt.Rows[0][22].ToString();
           
            lblTax.Text = dt.Rows[0][23].ToString();
            lblDiscount.Text = dt.Rows[0][24].ToString();
            lblTotal.Text = dt.Rows[0][27].ToString();
            lblSubTot.Text = dt.Rows[0][29].ToString();
            lblTaxTot.Text = dt.Rows[0][30].ToString();
            lblDiscTot.Text = dt.Rows[0][31].ToString();
            lblcompanyAdd.Text = dt.Rows[0][32].ToString();
            lblCity.Text = dt.Rows[0][31].ToString();
            lblCountry.Text = dt.Rows[0][31].ToString();
            lblPhone.Text = dt.Rows[0][35].ToString();
            lblphone2.Text = dt.Rows[0][35].ToString();
            lblFax.Text = dt.Rows[0][34].ToString();
            lblEmail.Text = dt.Rows[0][33].ToString();
            lblemail2.Text = dt.Rows[0][33].ToString();
            lblGrandtotal.Text = (Convert.ToInt32(lblSubTot.Text) + Convert.ToInt32(lblTaxTot.Text) - (Convert.ToInt32(lblDiscTot.Text))).ToString();
        }
    }
}