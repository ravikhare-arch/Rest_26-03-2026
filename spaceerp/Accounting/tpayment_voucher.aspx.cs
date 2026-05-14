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
    tpayment_voucher_Class objClass = new tpayment_voucher_Class();
    tpayment_voucherdet_Class objClassDet = new tpayment_voucherdet_Class();
    mlocation_Class objLocation = new mlocation_Class();
    tchartof_account_Class objAccountCode = new tchartof_account_Class();
    mmain_account_Class objAccount = new mmain_account_Class();
    tvisadet_Class objClassGen = new tvisadet_Class();
    mcurrency_Class objCurrency = new mcurrency_Class();
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
                displayGrid();
                objLocation.ddlOperation(objLocation, "Show", "", ddlLocation);

                objAccount.ddlOperation(objAccount, "ShowddlAccount", "", ddlAccountCodeID);
                objClass.ddlOperation(objClass, "Show", "", ddlVoucherNoS);
                objCurrency.ddlOperation(objCurrency, "Show", "", ddlCurrencyID);
                btnVisible();
                txtdtPaymentVoucher.Text = validation.fillDate();
                Voucher_Generate();
                fillUser();
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

                if (GridView2.Rows.Count < 25)
                {
                    ddlPageSizeDet.Visible = false;
                    lblpgsDet.Visible = false;
                }
                else
                {
                    ddlPageSizeDet.Visible = true;
                    lblpgsDet.Visible = true;
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
    public void fillUser()
    {
        DataTable dt = objUser.viewData(objUser, "show", Session["uid"].ToString());
        if (dt.Rows.Count > 0)
        {
            //txtAmendedby.Text = dt.Rows[0][3].ToString();
            txtPostedby.Text = dt.Rows[0][3].ToString();
        }
    }
    public void Page_PreRender(object sender, EventArgs e)
    {
        ViewState["tpayment_voucher"] = Session["tpayment_voucher"];
    }

    public void Voucher_Generate()
    {
        DataTable dt = objClass.viewData(objClass, "PVN", validation.dateToText(txtdtPaymentVoucher.Text));
        if (dt.Rows.Count > 0)
        {
            txtPaymentVoucherNo.Text = dt.Rows[0][0].ToString();
        }
    }
    public void para()
    {
        objClass.sPaymentVoucherNo = validation.stringToDBString(txtPaymentVoucherNo.Text.Trim());
        objClass.nVoucherTypeID = ddlVoucherTypeID.SelectedValue;
        objClass.dtPaymentVoucher = validation.dateToText(txtdtPaymentVoucher.Text.Trim());
        objClass.nStatusID = "1";
        objClass.nCashAccountID = ddlAccountType.SelectedValue;
        objClass.sPostedby = validation.stringToDBString(txtPostedby.Text.Trim());
        objClass.sAmendedby = validation.stringToDBString(txtPostedby.Text.Trim());
        objClass.nLocationID = ddlLocation.SelectedValue;
    }

    public void clrfield()
    {
        txtPaymentVoucherNo.Text = "";
        ddlVoucherTypeID.SelectedValue = "0";
        txtdtPaymentVoucher.Text = "";
      //  ddlStatusID.SelectedValue = "0";
        ddlAccountType.SelectedValue = "0";
        txtPostedby.Text = "";
      //  txtAmendedby.Text = "";
        ddlLocation.SelectedValue = "0";
        //txtConfigID.Text = "";
        Session["eid"] = "";
    }

    public void GetFormData()
    {
        DataTable dt = objClass.viewData(objClass, "show", Session["eid"].ToString());
        if (dt.Rows.Count > 0)
        {
            txtPaymentVoucherNo.Text = dt.Rows[0][1].ToString();
            ddlVoucherTypeID.SelectedValue = dt.Rows[0][2].ToString();
            txtdtPaymentVoucher.Text = validation.TextToDate(dt.Rows[0][3].ToString());
         //   ddlStatusID.SelectedValue = dt.Rows[0][4].ToString();
            txtPostedby.Text = dt.Rows[0][5].ToString();
         //   txtAmendedby.Text = dt.Rows[0][6].ToString();
            EventArgs e = new EventArgs();
            ddlVoucherTypeID_SelectedIndexChanged(this, e);
            ddlAccountType.SelectedValue = dt.Rows[0][7].ToString();
            ddlLocation.SelectedValue = dt.Rows[0][8].ToString();
            
            //txtConfigID.Text = dt.Rows[0][7].ToString();
        }
    }

    public void btnVisible()
    {
        btnAdd.Visible = true;
        btnAddDet.Visible = false;
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
        objClass.nPaymentVoucerID = Session["eid"].ToString();
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
                if (strArr[0] == "1")
                {
                    string VoucherID = strArr[2].ToString();
                    Session["eid"] = VoucherID;

                    paraDet();
                    objClassDet.nPaymentVoucherID = Session["eid"].ToString();
                    var xyz = objClassDet.User_Operation(objClassDet, "add");

                    tblGridDet.Visible = true;

                    displayGridDet();

                    btnAdd.Visible = false;
                    
                    //btnUpdate.Visible = true;
                    btnAddDet.Visible = true;
                    btnPrint.Visible = true;
                    btnUpdateDet.Visible = false;
                    clrfieldDet();
                    //DisableData();

                }

                valobj.showMsg(abc, lblmsg);
                //displayGrid();
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
            objClass.nPaymentVoucerID = Session["eid"].ToString();
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
            btnAddDet.Visible = true;
            btnPrint.Visible = true;
            btnUpdateDet.Visible = false;
            //btnUpdate.Visible = true;
            //btnDelete.Visible = true;
            GetFormData();
            clrfieldDet();
            lblmsg.Text = "";
            tblmain.Visible = true;
            tblGrd.Visible = false;
            tblGridDet.Visible = true;
            displayGridDet();
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
            Response.Redirect("rptPaymentVoucher.aspx");

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
            objClass.nPaymentVoucerID = Session["eid"].ToString();
            Response.Redirect("rptPaymentVoucher.aspx");
        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, "FAIL", lblmsg);
        }
        finally
        {
        }
    }


    //Detail Table 

    public void paraDet()
    {
        objClassDet.nPaymentVoucherID = Session["eid"].ToString();
        objClassDet.nAccountCodeID = ddlAccountCodeID.SelectedValue;
        //objClassDet.sAccountTitle = validation.stringToDBString(txtAccountTitle.Text.Trim());
       // objClassDet.nBalance = txtBalance.Text.Trim();
        objClassDet.sDescription = validation.stringToDBString(txtDescription.Text.Trim());
        objClassDet.nCurrencyID = ddlCurrencyID.SelectedValue;
        objClassDet.nRate = txtRate.Text.Trim();
        objClassDet.nAmount = txtAmount.Text.Trim();
        objClassDet.nLocalAmount = txtLocalAmount.Text.Trim();
        objClassDet.nJobID = ddlJobID.SelectedValue;
        objClassDet.sChequeNo = validation.stringToDBString(txtcheque.Text.Trim());
        objClassDet.dtCheque = validation.dateToText(txtdtCheque.Text.Trim());
        objClassDet.sRemarks = validation.stringToDBString(txtRemarks.Text.Trim());
    }

    public void clrfieldDet()
    {
        ddlAccountCodeID.SelectedValue = "0";
        //txtAccountTitle.Text = "";
        txtBalance.Text = "";
        txtDescription.Text = "";
        ddlCurrencyID.SelectedValue = "0";
        txtRate.Text = "";
        txtAmount.Text = "";
        txtLocalAmount.Text = "";
        ddlJobID.SelectedValue = "0";
        txtcheque.Text = "";
        txtdtCheque.Text = "";
        txtRemarks.Text = "";
        Session["Detid"] = "";
    }

    public void GetFormDataDet()
    {
        DataTable dt = objClassDet.viewData(objClassDet, "show", Session["Detid"].ToString());
        if (dt.Rows.Count > 0)
        {
            ddlAccountCodeID.SelectedValue = dt.Rows[0][2].ToString();
           // txtAccountTitle.Text = dt.Rows[0][3].ToString();

            EventArgs e = new EventArgs();
            ddlAccountCodeID_SelectedIndexChanged(this, e);
            //txtBalance.Text = dt.Rows[0][4].ToString();
            txtDescription.Text = dt.Rows[0][5].ToString();
            ddlCurrencyID.SelectedValue = dt.Rows[0][6].ToString();
            txtRate.Text = dt.Rows[0][7].ToString();
            txtAmount.Text = dt.Rows[0][8].ToString();
            txtLocalAmount.Text = dt.Rows[0][9].ToString();
            ddlJobID.SelectedValue = dt.Rows[0][10].ToString();
            txtcheque.Text = dt.Rows[0][11].ToString();
            txtdtCheque.Text = validation.TextToDate(dt.Rows[0][12].ToString());
            txtRemarks.Text = dt.Rows[0][13].ToString();
        }
    }
    public void displayGridDet()
    {
        try
        {
            objClassDet.FillGrid(objClassDet, GridView2, "ShowGrid", Session["eid"].ToString());
        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, lblmsg);
        }
    }

    //public void DisableData()
    //{
    //    ddlVoucherTypeID.Enabled = false;
    //    ddlAccountTypeountID.Enabled = false;
    //    ddlStatusID.Enabled = false;
    //    txtdtVoucher.Enabled = false;
    //    ddlLocationID.Enabled = false;
    //    txtPostedby.Enabled = false;
    //    txtAmbedby.Enabled = false;
    //    Img5.Enabled = false;
    //}
    //public void VisibleData()
    //{
    //    ddlVoucherTypeID.Enabled = true;
    //    ddlAccountTypeountID.Enabled = true;
    //    ddlStatusID.Enabled = true;
    //    txtdtVoucher.Enabled = true;
    //    ddlLocationID.Enabled = true;
    //    txtPostedby.Enabled = true;
    //    txtAmbedby.Enabled = true;
    //    Img5.Enabled = true;
    //}

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GridView2.PageIndex = e.NewPageIndex;
            displayGridDet();
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message.ToString();
        }
        finally
        {
        }
    }
    protected void ddlPageSizeDet_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView2.PageSize = int.Parse(ddlPageSizeDet.SelectedValue);
        displayGridDet();
    }

    protected void btnAddDet_Click(object sender, EventArgs e)
    {
        try
        {
            lblmsg.Text = "";
            if (Session["tpayment_voucher"].ToString() == ViewState["tpayment_voucher"].ToString())
            {
                paraDet();
                var abc = objClassDet.User_Operation(objClassDet, "add");

                //DetButtonVisible();
                tblGridDet.Visible = true;

                displayGridDet();
                clrfieldDet();
                btnAddDet.Visible = true;
                btnAdd.Visible = false;
                btnUpdateDet.Visible = false;
                //Total_Amount();
                valobj.showMsg(abc, lblmsg);
                string aa = Server.UrlEncode(System.DateTime.Now.ToString());
                Session["tpayment_voucher"] = aa;
                //DisableData();
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
    protected void btngdEditDet_Click(object sender, EventArgs e)
    {
        try
        {
            Session["Detid"] = "";
            LinkButton thisbtn = (LinkButton)sender;
            GridViewRow thisgrdR = (GridViewRow)thisbtn.Parent.Parent;
            int row = thisgrdR.RowIndex;
            Label IDDet = (Label)GridView2.Rows[row].Cells[0].FindControl("lblDetID");
            Session["Detid"] = IDDet.Text;
            btnAdd.Visible = false;
            btnAddDet.Visible = false;
            btnUpdateDet.Visible = true;
            //Total_Amount();
            //btnDeleteDet.Visible = true;
            // DetButtonVisible();

            GetFormDataDet();
            lblmsg.Text = "";
            tblGridDet.Visible = true;
            displayGridDet();



        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, "FAIL", lblmsg);
        }
    }

    protected void btnUpdateDet_Click(object sender, EventArgs e)
    {
        try
        {
            paraDet();
            objClassDet.nPaymentVoucherDetID = Session["Detid"].ToString();
            var abc = objClassDet.User_Operation(objClassDet, "edit");
            valobj.showMsg(abc, lblmsg);
            //DetButtonVisible();
            btnAdd.Visible = false;
            btnAddDet.Visible = true;
            btnUpdateDet.Visible = false;
            tblGridDet.Visible = true;
            clrfieldDet();
            displayGridDet();
            //Total_Amount();
            //DisableData();

        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, "FAIL", lblmsg);
        }
        finally
        {
        }
    }


    protected void btngdDeleteDet_Click(object sender, EventArgs e)
    {
        try
        {
            Session["Detid"] = "";
            LinkButton thisbtn = (LinkButton)sender;
            GridViewRow thisgrdR = (GridViewRow)thisbtn.Parent.Parent;
            int row = thisgrdR.RowIndex;
            Label IDDet = (Label)GridView2.Rows[row].Cells[0].FindControl("lblDetID");
            Session["Detid"] = IDDet.Text;

            DeleteDetRecord();
        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, "FAIL", lblmsg);
        }
    }
    public void DeleteDetRecord()
    {
        objClassDet.nPaymentVoucherDetID = Session["Detid"].ToString();
        var vres = objClassDet.User_Operation(objClassDet, "DeActive");
        valobj.showMsg(vres, lblmsg);
        tblGridDet.Visible = true;
        displayGridDet();
        clrfieldDet();
        //DetButtonVisible();
    }

    protected void lnkAdd_Click(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        tblmain.Visible = true;
        tblGrd.Visible = false;
        tblGridDet.Visible = false;
        clrfield();
        btnVisible();
        fillUser();
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
    protected void ddlCurrencyID_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dt = objCurrency.viewData(objCurrency, "show", ddlCurrencyID.SelectedValue);
        if (dt.Rows.Count > 0)
        {
            txtRate.Text = dt.Rows[0][4].ToString();
        }
    }
    protected void txtdtPaymentVoucher_TextChanged(object sender, EventArgs e)
    {
        Voucher_Generate();
    }
    protected void ddlVoucherTypeID_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(ddlVoucherTypeID.SelectedValue=="1")
        {
            objAccount.ddlOperation(objAccount, "ddlAccType", ddlVoucherTypeID.SelectedValue, ddlAccountType);
            txtcheque.Enabled = false;
            txtdtCheque.Enabled = false;
        }
        else
        {
            objAccount.ddlOperation(objAccount, "ddlAccType", ddlVoucherTypeID.SelectedValue, ddlAccountType);
            txtcheque.Enabled = true;
            txtdtCheque.Enabled = true;
        }
    }
    protected void txtAmount_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (txtAmount.Text == "")
            {
                txtAmount.Text = "0";
            }
            if (txtRate.Text == "")
            {
                txtRate.Text = "0";
            }
            txtLocalAmount.Text = (double.Parse(txtAmount.Text) * double.Parse(txtRate.Text)).ToString();
        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, lblmsg);
        }
        finally
        {

        }
    }
    protected void ddlAccountCodeID_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dt = objClassGen.viewData(objClassGen, "ShowGeneralLedgerBal", ddlAccountCodeID.SelectedValue);
         if (dt.Rows.Count > 0)
         {
             if (double.Parse(dt.Rows[0][17].ToString()) < 0)
             {
                 txtBalance.Text="";
                 string val = dt.Rows[0][17].ToString();
                 var TotBal = val.Split('-');
                 txtBalance.Text = TotBal[1].ToString() + " " + "Dr";
             }
             else if(double.Parse(dt.Rows[0][17].ToString()) > 0)
             {
                 txtBalance.Text = "";
                 txtBalance.Text = dt.Rows[0][17].ToString() + " " + "Cr";
             }
             else
             {
                 txtBalance.Text = "0";
             }
         }
         else
         {
             txtBalance.Text = "0";
         }
    }
    protected void txtRate_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (txtAmount.Text == "")
            {
                txtAmount.Text = "0";
            }
            if (txtRate.Text == "")
            {
                txtRate.Text = "0";
            }
            txtLocalAmount.Text = (double.Parse(txtAmount.Text) * double.Parse(txtRate.Text)).ToString();
        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, lblmsg);
        }
        finally
        {

        }
       
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            objClass.nPaymentVoucerID = ddlVoucherNoS.SelectedValue;
            objClass.nVoucherTypeID = ddlVTypeS.SelectedValue;
            objClass.dtPaymentVoucher = validation.dateToText(txtdtFrom.Text.Trim());
            objClass.sAmendedby= validation.dateToText(txtdtTo.Text.Trim());
         //   objClass.nStatusID = ddlStatusID.SelectedValue;
            if (ddlVoucherNoS.SelectedValue != "0" || ddlVTypeS.SelectedValue!="0"||(txtdtFrom.Text!="" && txtdtTo.Text!= "" ))
            {

            objClass.FillGrid(objClass, GridView1, "ShowGridSearch", "");
            }
            else
            {
                objClass.FillGrid(objClass, GridView1, "ShowGrid", "");
            }
            txtdtFrom.Text = "";
            txtdtTo.Text = "";
        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, lblmsg);
        }
    }
}
