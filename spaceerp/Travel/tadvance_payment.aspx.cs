using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Transcation_payment_voucher : System.Web.UI.Page
{
    muser_Class objUser = new muser_Class();
    tadvance_payment_Class objClass = new tadvance_payment_Class();
    
  //  mlocation_Class objLocation = new mlocation_Class();
  //  tchartof_account_Class objAccount = new tchartof_account_Class();
    mmain_account_Class objAccount = new mmain_account_Class();
    mclient_Class objClient = new mclient_Class();
   
    validation valobj = new validation();
    string cond;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                string aa = Server.UrlEncode(System.DateTime.Now.ToString());
                Session["tpayment_voucher"] = aa;
                tblmain.Visible = true;
                tblGrd.Visible = false;

                objClass.ddlOperation(objClass, "Show", "", ddlVoucherNoS);
                btnVisible();
                txtdtPaymentVoucher.Text = validation.fillDate();
                Voucher_Generate();

                if (GridView1.Rows.Count < 25)
                {
                    ddlPageSize.Visible = false;
                    lblpgs.Visible = false;
                }
                else
                {
                    ddlPageSize.Visible = true;
                    lblpgs.Visible = true;
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

    public void Page_PreRender(object sender, EventArgs e)
    {
        ViewState["tpayment_voucher"] = Session["tpayment_voucher"];
    }

    public void Voucher_Generate()
    {
        DataTable dt = objClass.viewData(objClass, "MaxVoucher", validation.dateToText(txtdtPaymentVoucher.Text));
        if (dt.Rows.Count > 0)
        {
            txtPaymentVoucherNo.Text = dt.Rows[0][0].ToString();
        }
    }
    public void para()
    {

        //  objClass.nInvoiceID = Session["eid"].ToString();
        objClass.sVoucherNo = txtPaymentVoucherNo.Text;
        objClass.dtVoucher = validation.dateToText(txtdtPaymentVoucher.Text);
        objClass.nPaymentTypeID = ddlPaymentType.SelectedValue;
        objClass.nAccountTypeID = ddlPayfor.SelectedValue;
        objClass.nAccountID = ddlAccount.SelectedValue;
        objClass.nPaymentModeID = ddlPaymentMode.SelectedValue;
        objClass.sChequeNo = validation.stringToDBString(txtChecqueNo.Text);
        objClass.dtCheque = validation.dateToText(txtdtCheque.Text);
        objClass.nAmount = txtAmount.Text;
        objClass.sRemarks = validation.stringToDBString(txtRemarks.Text);
        objClass.nCashAccountID = ddlPayAccount.SelectedValue;
       
    }

    public void clrfield()
    {
        txtPaymentVoucherNo.Text = "";
        txtdtPaymentVoucher.Text = "";
        ddlPaymentType.SelectedValue = "0";
        ddlPayfor.SelectedValue = "0";
        ddlAccount.SelectedValue = "0";
        ddlPaymentMode.SelectedValue = "0";
        txtChecqueNo.Text = "";
        txtdtCheque.Text = "";
       
        txtAmount.Text = "";
        txtRemarks.Text = "";
        ddlPayAccount.SelectedValue = "0";
        Session["eid"] = "";
    }

    public void GetFormData()
    {
        DataTable dt = objClass.viewData(objClass, "show", Session["eid"].ToString());
        if (dt.Rows.Count > 0)
        {
            EventArgs e = new EventArgs();
            
           

            txtPaymentVoucherNo.Text = dt.Rows[0][1].ToString();
            txtdtPaymentVoucher.Text = validation.TextToDate(dt.Rows[0][2].ToString());
            ddlPaymentType.SelectedValue = dt.Rows[0][3].ToString();
             
            ddlPayfor.SelectedValue = dt.Rows[0][4].ToString();
            ddlPayfor_SelectedIndexChanged(this, e);
            ddlAccount.SelectedValue = dt.Rows[0][5].ToString();
            ddlPaymentMode.SelectedValue = dt.Rows[0][6].ToString();
            ddlPaymentMode_SelectedIndexChanged(this, e);
            txtChecqueNo.Text = dt.Rows[0][7].ToString();
            txtdtCheque.Text = validation.TextToDate(dt.Rows[0][8].ToString());
            txtAmount.Text = dt.Rows[0][9].ToString();
            txtRemarks.Text = dt.Rows[0][10].ToString();
            ddlPayAccount.SelectedValue = dt.Rows[0][12].ToString();
           // txtStatusID.Text = dt.Rows[0][11].ToString();


        }
    }

    public void btnVisible()
    {
        btnAdd.Visible = true;
        //btnAddDet.Visible = false;
        btnUpdateDet.Visible = false;
        btnPrint.Visible = false;
        //btnUpdate.Visible = false;
        //btnDelete.Visible = false;
        clrfield();
    }

    public void displayGrid()
    {
        try
        {
            objClass.FillGrid(objClass, GridView1, "ShowGrid", "");
        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, lblmsg);
        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GridView1.PageIndex = e.NewPageIndex;
            displayGrid();
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message.ToString();
        }
        finally
        {
        }
    }

    protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView1.PageSize = int.Parse(ddlPageSize.SelectedValue);
        displayGrid();
    }

    public void DeleteRecord()
    {
        objClass.nAdvancePaymentID = Session["eid"].ToString();
        var vres = objClass.User_Operation(objClass, "DeActive");
        valobj.showMsg(vres, lblmsg);
        displayGrid();
        btnVisible();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            lblmsg.Text = "";
            if (Session["tpayment_voucher"].ToString() == ViewState["tpayment_voucher"].ToString())
            {

                para();
                var abc = objClass.User_Operation(objClass, "add");
                var strArr = abc.Split(',');




                valobj.showMsg(abc, lblmsg);
                tblGrd.Visible = true;
                tblmain.Visible = false;

                displayGrid();
                string aa = Server.UrlEncode(System.DateTime.Now.ToString());
                Session["tpayment_voucher"] = aa;
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
            // objClass.nPaymentVoucerID = Session["eid"].ToString();
            var abc = objClass.User_Operation(objClass, "edit");
            valobj.showMsg(abc, lblmsg);
            //displayGrid();
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
            DeleteRecord();
        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, "FAIL", lblmsg);
        }
        finally
        {
        }
    }

    protected void btngdEdit_Click(object sender, EventArgs e)
    {
        try
        {
            Session["eid"] = "";
            LinkButton thisbtn = (LinkButton)sender;
            GridViewRow thisgrdR = (GridViewRow)thisbtn.Parent.Parent;
            int row = thisgrdR.RowIndex;
            Label ID = (Label)GridView1.Rows[row].Cells[0].FindControl("lblID");
            Session["eid"] = ID.Text;

            btnAdd.Visible = false;
            //btnAddDet.Visible = true;
            btnPrint.Visible = true;
            btnUpdateDet.Visible = true;

            //btnUpdate.Visible = true;
            //btnDelete.Visible = true;
            GetFormData();

            lblmsg.Text = "";
            tblmain.Visible = true;
            tblGrd.Visible = false;

          //  txtAmount.Enabled = false;
        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, "FAIL", lblmsg);
        }
    }

    protected void btngdDelete_Click(object sender, EventArgs e)
    {
        try
        {
            Session["eid"] = "";
            LinkButton thisbtn = (LinkButton)sender;
            GridViewRow thisgrdR = (GridViewRow)thisbtn.Parent.Parent;
            int row = thisgrdR.RowIndex;
            Label ID = (Label)GridView1.Rows[row].Cells[0].FindControl("lblID");
            Session["eid"] = ID.Text;

            DeleteRecord();
        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, "FAIL", lblmsg);
        }
    }

    protected void btngdPrint_Click(object sender, EventArgs e)
    {
        try
        {
            Session["eid"] = "";
            LinkButton thisbtn = (LinkButton)sender;
            GridViewRow thisgrdR = (GridViewRow)thisbtn.Parent.Parent;
            int row = thisgrdR.RowIndex;
            Label ID = (Label)GridView1.Rows[row].Cells[0].FindControl("lblID");
            Session["eid"] = ID.Text;
            Response.Redirect("PaymentReceipt/rpt_payment_receipt.aspx?id=" + Session["eid"].ToString());

        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, "FAIL", lblmsg);
        }
    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        try
        {
            objClass.nAdvancePaymentID = Session["eid"].ToString();
            Response.Redirect("PaymentReceipt/rpt_payment_receipt.aspx?id=" + Session["eid"].ToString());
        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, "FAIL", lblmsg);
        }
        finally
        {
        }
    }

    protected void btnUpdateDet_Click(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        if (Session["tpayment_voucher"].ToString() == ViewState["tpayment_voucher"].ToString())
        {

            para();
            objClass.nAdvancePaymentID = Session["eid"].ToString();
            var abc = objClass.User_Operation(objClass, "edit");




            valobj.showMsg(abc, lblmsg);
            //displayGrid();
            string aa = Server.UrlEncode(System.DateTime.Now.ToString());
            Session["tpayment_voucher"] = aa;
        }
    }

    
    //public void DisableControl()
    //{
    //    //ddlPayFor.Enabled = false;
    //    //ddlClient.Enabled = false;
    //    ddlPaymentMode.Enabled = false;
    //    ddlPayAccount.Enabled = false;
    //    txtdtPaymentVoucher.Enabled = false;

    //}
    //public void EnableControl()
    //{
    //    //ddlPayFor.Enabled = true;
    //    //ddlClient.Enabled = true;
    //    ddlPaymentMode.Enabled = true;
    //    ddlPayAccount.Enabled = true;
    //    txtdtPaymentVoucher.Enabled = true;

    //}





    protected void lnkAdd_Click(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        tblmain.Visible = true;
        tblGrd.Visible = false;

        txtAmount.Enabled = true;
        clrfield();
        btnVisible();
        txtdtPaymentVoucher.Text = validation.fillDate();
        Voucher_Generate();
    }
    protected void lnkList_Click(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        tblmain.Visible = false;
        tblGrd.Visible = true;

        displayGrid();

    }

    protected void txtdtPaymentVoucher_TextChanged(object sender, EventArgs e)
    {
        Voucher_Generate();
    }
    protected void ddlVoucherTypeID_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (ddlVoucherTypeID.SelectedValue == "1")
        //{
        //    objAccount.ddlOperation(objAccount, "ddlAccType", ddlVoucherTypeID.SelectedValue, ddlClient);
        //    txtcheque.Enabled = false;
        //    txtdtCheque.Enabled = false;
        //}
        //else
        //{
        //    objAccount.ddlOperation(objAccount, "ddlAccType", ddlVoucherTypeID.SelectedValue, ddlClient);
        //    txtcheque.Enabled = true;
        //    txtdtCheque.Enabled = true;
        //}
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //try
        //{
        //    objClass.nPaymentVoucerID = ddlVoucherNoS.SelectedValue;
        //    objClass.nVoucherTypeID = ddlVTypeS.SelectedValue;
        //    objClass.dtPaymentVoucher = validation.dateToText(txtdtFrom.Text.Trim());
        //    objClass.sAmendedby = validation.dateToText(txtdtTo.Text.Trim());
        //    //   objClass.nStatusID = ddlStatusID.SelectedValue;
        //    if (ddlVoucherNoS.SelectedValue != "0" || ddlVTypeS.SelectedValue != "0" || (txtdtFrom.Text != "" && txtdtTo.Text != ""))
        //    {

        //        objClass.FillGrid(objClass, GridView1, "ShowGridSearch", "");
        //    }
        //    else
        //    {
        //        objClass.FillGrid(objClass, GridView1, "ShowGrid", "");
        //    }
        //    txtdtFrom.Text = "";
        //    txtdtTo.Text = "";
        //}
        //catch (Exception ex)
        //{
        //    valobj.showMsg(ex.Message, lblmsg);
        //}
    }
   
    protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (lblAmount.Text == "")
        {
            lblAmount.Text = "0";
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            TextBox txtbal = (TextBox)e.Row.FindControl("txtBalance");

            TextBox txtPayVal = (TextBox)e.Row.FindControl("txtPaymentValue");
            CheckBox chkSelect = (CheckBox)e.Row.FindControl("chkInv");


            if (double.Parse(txtbal.Text) >= double.Parse(lblAmount.Text))
            {
                txtPayVal.Text = lblAmount.Text;

                lblAmount.Text = "0";

            }
            else if (double.Parse(txtbal.Text) <= double.Parse(lblAmount.Text))
            {

                txtPayVal.Text = txtbal.Text;
                lblAmount.Text = (double.Parse(lblAmount.Text) - double.Parse(txtPayVal.Text)).ToString();

            }
            //else
            //{
            //    txtPayVal.Text = lblAmount.Text;
            //    lblAmount.Text = (double.Parse(lblAmount.Text) - double.Parse(txtPayVal.Text)).ToString();
            //}

            if (txtPayVal.Text == "" || txtPayVal.Text == "0")
            {
                chkSelect.Checked = false;
            }
            else
            {
                chkSelect.Checked = true;
            }


        }
    }
    protected void txtPaymentValue_TextChanged(object sender, EventArgs e)
    {
        if (Session["eid"] == "")
        {
            GridViewRow row = ((GridViewRow)((TextBox)sender).NamingContainer);
            //NamingContainer return the container that the control sits in
            TextBox other = (TextBox)row.FindControl("txtPaymentValue");
            CheckBox chkSelect = (CheckBox)row.FindControl("chkInv");
            chkSelect.Checked = true;
        //    GrandTotal();
        }
        else
        {
            GridViewRow row = ((GridViewRow)((TextBox)sender).NamingContainer);
            //NamingContainer return the container that the control sits in
            TextBox other = (TextBox)row.FindControl("txtPaymentValue");
        //    GrandTotalDet();

        }


    }


    protected void ddlPaymentMode_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPaymentMode.SelectedValue == "1")
        {
            objAccount.ddlOperation(objAccount, "ddlAccType", ddlPaymentMode.SelectedValue, ddlPayAccount);
        }
        else if (ddlPaymentMode.SelectedValue == "2")
        {
            objAccount.ddlOperation(objAccount, "ddlAccType", ddlPaymentMode.SelectedValue, ddlPayAccount);

        }
        else
        {
            objAccount.ddlOperation(objAccount, "ddlAccType", "2", ddlPayAccount);

        }
    }
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void txtAmount_TextChanged(object sender, EventArgs e)
    {
        

    }
    protected void ddlPayfor_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPayfor.SelectedValue != "0")
        {
            objAccount.ddlOperation(objAccount, "ddlAccType", ddlPayfor.SelectedValue, ddlAccount);
           
        }
        else
        {
            ddlAccount.SelectedValue = "0";

        }
        if(ddlPayfor.SelectedValue=="3")
        {
            ddlPaymentType.SelectedValue = "1";
        }
        else
        {
            ddlPaymentType.SelectedValue = "2";
        }
    }
    
}
