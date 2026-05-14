using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Transcation_tsalesdebitnote : System.Web.UI.Page
{
    tsalesdebitnote_Class objClass = new tsalesdebitnote_Class();

    validation valobj = new validation();
    mmain_account_Class objAccount = new mmain_account_Class();
    mbranches_Class objBranch = new mbranches_Class();
    string cond;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {

                string aa = Server.UrlEncode(System.DateTime.Now.ToString());
                Session["tsalesdebitnote"] = aa;
                tblmain.Visible = true;
                tblGrd.Visible = false;
                tblDet.Visible = true;
                //tblGridDet.Visible = false;
                //tblbootomPage.Visible = false;
                objAccount.ddlOperation(objAccount, "ddlCustomer", "", ddlClient);
                objBranch.ddlOperation(objBranch, "Showddl", "", ddlLocationID);
                objAccount.ddlOperation(objAccount, "ddlVendor", "", ddlAgentID);
                // objLocation.ddlOperation(objLocation, "Show", "", ddlLocation);
                // objUnit.ddlOperation(objUnit, "Show", "", ddlUnit);
                // objItem.ddlOperation(objItem, "Show", "", ddlItem);
                // objChartofAcc.ddlOperation(objChartofAcc, "ShowddlAccount", "", ddlCustomerName);
                //objChartofAcc.ddlOperation(objChartofAcc, "ShowddlAccount", "", ddlCustSearch);
                //objClass.ddlOperation(objClass, "Show", "", ddlSoSearch);
                // objTaxMaster.ddlOperation(objTaxMaster, "Show", "", ddlTaxName);

                //txttsalesdebitnote.Text = validation.fillDate();



                var ID = Request.QueryString["ID"];
                if (!string.IsNullOrEmpty(ID))
                {
                    Session["eid"] = ID;
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    GetFormData();




                    //btnPrint.Visible = true;
                    //btnPaymentHistory.Visible = true;
                    //DetButtonVisible();
                    //displayGridDet();
                    //txtPaxNos_TextChanged(this, e);
                }
            }
        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, "FAIL", lblmsg);
        }
        finally
        {
        }
    }
    public void GetFormData()
    {
        DataTable dt = objClass.viewData(objClass, "show", Session["eid"].ToString());
        if (dt.Rows.Count > 0)
        {
            txtgsttype.Text = dt.Rows[0]["sGSTType"].ToString();
            tsalesdebitnotedate.Text = validation.TextToDate(dt.Rows[0]["dtDebitNote"].ToString());
            ddlClient.SelectedValue = dt.Rows[0]["nClientID"].ToString();
            ddlLocationID.SelectedValue = dt.Rows[0]["nLocationID"].ToString();
            ddlAgentID.SelectedValue = dt.Rows[0]["nAgentID"].ToString();
            txtReferenceNo.Text = dt.Rows[0]["sReferenceno"].ToString();
            treferencedate.Text = validation.TextToDate(dt.Rows[0]["dtReference"].ToString());
            txtemail.Text = dt.Rows[0]["sEmail"].ToString();
            txtagainstbill.Text = dt.Rows[0]["sAgainstBill"].ToString();
            txtagainstbilldate.Text = validation.TextToDate(dt.Rows[0]["dtAgainstBill"].ToString());
            txtcurrency.Text = dt.Rows[0]["nCurrencyID"].ToString();
            txtconversionrate.Text = dt.Rows[0]["nConversionRate"].ToString();
            txtpaymentterms.Text = dt.Rows[0]["sPaymentTerms"].ToString();
            txtduedate.Text = validation.TextToDate(dt.Rows[0]["dtDue"].ToString());
            txtreturnreason.Text = dt.Rows[0]["sDebitNoteReason"].ToString();
            txtshippingaddress.Text = dt.Rows[0]["sShippingAddress"].ToString();
            txtbillingaddress.Text = dt.Rows[0]["sBillingAddress"].ToString();
        }
    }
    public void Page_PreRender(object sender, EventArgs e)
    {
        ViewState["tsalesdebitnote"] = Session["tsalesdebitnote"];
    }


    public void para()
    {

        // objClass.sMofaBookingNo = validation.stringToDBString(txtMofaBookingNo.Text.Trim());
        objClass.GSTType = txtgsttype.Text;
        objClass.DebitNotedate = validation.dateToText(tsalesdebitnotedate.Text.Trim());
        objClass.ClientNameID = ddlClient.SelectedValue;
        objClass.LocationID = ddlLocationID.SelectedValue;
        objClass.AgentID = ddlAgentID.SelectedValue;
        objClass.Referenceno = txtReferenceNo.Text;
        objClass.Referencedate = validation.dateToText(treferencedate.Text.Trim());
        objClass.Email = txtemail.Text;
        objClass.AgainstBill = txtagainstbill.Text;
        objClass.AgainstBilldate = validation.dateToText(txtagainstbilldate.Text.Trim());
        objClass.ShippingAddress = txtshippingaddress.Text;
        objClass.BillingAddress = txtbillingaddress.Text;
        objClass.CurrencyID = "1";
        objClass.ConversionRate = txtconversionrate.Text;
        objClass.PaymentTerms = txtpaymentterms.Text;
        objClass.Duedate = validation.dateToText(txtduedate.Text.Trim());
        objClass.DebitNoteReason = txtreturnreason.Text;

    }



    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            lblmsg.Text = "";
            if (Session["tsalesdebitnote"].ToString() == ViewState["tsalesdebitnote"].ToString())
            {
                para();
                var abc = objClass.User_Operation(objClass, "add");

                //var strArr = abc.Split(',');
                //if (strArr[0] == "1")
                //{
                //    string BusID = strArr[2].ToString();


                //    Session["eid"] = BusID;

                //    paraDet();
                //    var xyz = objClassDet.User_Operation(objClassDet, "add");

                //    tblmain.Visible = true;
                //    tblDet.Visible = true;
                //    tblGridDet.Visible = true;
                //    tblGrd.Visible = false;
                //    btnPaymentHistory.Visible = true;
                //    displayGridDet();
                //    btnAdd.Visible = false;
                //    btnAddDet.Visible = true;
                //    btnUpdateDet.Visible = false;
                //    btnPrint.Visible = true;
                //    //clrfieldDet();
                //    DisableData();
                //}
                //displayGrid();

                valobj.showMsg(abc, lblmsg);
                string aa = Server.UrlEncode(System.DateTime.Now.ToString());
                Session["tsalesdebitnote"] = aa;
            }
        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, "FAIL", lblmsg);
        }
        finally
        {
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            para();
            objClass.SalesDebitNoteID = Session["eid"].ToString();
            var abc = objClass.User_Operation(objClass, "edit");
            valobj.showMsg(abc, lblmsg);
        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, "FAIL", lblmsg);
        }
        finally
        {
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {

        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, "FAIL", lblmsg);
        }
        finally
        {
        }
    }



    protected void lnkAdd_Click(object sender, EventArgs e)
    {



    }
    protected void lnkList_Click(object sender, EventArgs e)
    {
        Response.Redirect("tsalesdebitnote_list.aspx");
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            //objClass.nSalesOrderID = ddlSoSearch.SelectedValue;
            //objClass.nCustomerNameID = ddlCustSearch.SelectedValue;
            //objClass.dtsalesdebitnote = validation.dateToText(txtdtFroms.Text.Trim());
            //objClass.dtDelivery = validation.dateToText(txtdtTo.Text.Trim());
            if (ddlSoSearch.SelectedValue != "0" || ddlCustSearch.SelectedValue != "0" || (txtdtFroms.Text != "" && txtdtTo.Text != ""))
            {

                // objClass.FillGrid(objClass, GridView1, "ShowGridSearch", "");
            }
            else
            {
                //objClass.FillGrid(objClass, GridView1, "ShowGrid", "");
            }
            txtdtFroms.Text = "";
            txtdtTo.Text = "";
        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, lblmsg);
        }
    }

}
