using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Transcation_tpurchasedebitnote : System.Web.UI.Page
{
    tpurhcasedebitnote_Class objClass = new tpurhcasedebitnote_Class();
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
                Session["tpurchasedebitnote"] = aa;
                tblmain.Visible = true;
               
                tblDet.Visible = true;
                //tblGridDet.Visible = false;
                //tblbootomPage.Visible = false;

                objAccount.ddlOperation(objAccount, "ddlCustomer", "", ddlClient);
                objBranch.ddlOperation(objBranch, "Showddl", "", ddlLocationID);
                objAccount.ddlOperation(objAccount, "ddlVendor", "", ddlAgentID);

                             
                txttSalesOrder.Text = validation.fillDate();



                var ID = Request.QueryString["ID"];
                if (!string.IsNullOrEmpty(ID))
                {
                    Session["eid"] = ID;
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    GetFormData();
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
            txttSalesOrder.Text = validation.TextToDate(dt.Rows[0]["dtDebitNote"].ToString());
            ddlClient.SelectedValue = dt.Rows[0]["nClientID"].ToString();
            ddlLocationID.SelectedValue = dt.Rows[0]["nLocationID"].ToString();
            ddlAgentID.SelectedValue = dt.Rows[0]["nAgentID"].ToString();
            txtReferenceNo.Text = dt.Rows[0]["sReferenceno"].ToString();
            txttDelivery.Text = validation.TextToDate(dt.Rows[0]["dtReference"].ToString());
            txtemail.Text = dt.Rows[0]["sEmail"].ToString();
            txtagainstbill.Text = dt.Rows[0]["sAgainstBill"].ToString();
            txtagainstbilldate.Text = validation.TextToDate(dt.Rows[0]["dtAgainstBill"].ToString());
            //txtcurrency.Text = dt.Rows[0]["nCurrencyID"].ToString();
            txtconversionrate.Text = dt.Rows[0]["nConversionRate"].ToString();
            txtpaymentterms.Text = dt.Rows[0]["sPaymentTerms"].ToString();
            txtduedate.Text = validation.TextToDate(dt.Rows[0]["dtDue"].ToString());
            txtreturnreason.Text = dt.Rows[0]["sDebitNoteReason"].ToString();
            txtshippingaddress.Text = dt.Rows[0]["sShippingAddress"].ToString();
            txtbillingaddress.Text = dt.Rows[0]["sBillingAddress"].ToString();
        }
    }

   

    public void para()
    {

        // objClass.sMofaBookingNo = validation.stringToDBString(txtMofaBookingNo.Text.Trim());
        objClass.GSTType = txtgsttype.Text;
        objClass.DebitNotedate = validation.dateToText(txttSalesOrder.Text.Trim());
        objClass.ClientNameID = ddlClient.SelectedValue;
        objClass.LocationID = ddlLocationID.SelectedValue;
        objClass.AgentID = ddlAgentID.SelectedValue;
        objClass.Referenceno = txtReferenceNo.Text;
        objClass.Referencedate = validation.dateToText(txttDelivery.Text.Trim());
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
            if (Session["tpurchasedebitnote"].ToString() == ViewState["tpurchasedebitnote"].ToString())
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
                Session["tpurchasedebitnote"] = aa;
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
            objClass.PurchaseDebitNoteID = Session["eid"].ToString();
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
      Response.Redirect("tpurchasedebitnote_list.aspx");
    }

  

}
