using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Transcation_visa : System.Web.UI.Page
{
    tvisa_Class objClass = new tvisa_Class();
    tvisadet_Class objClassDet = new tvisadet_Class();
    tpayments_receive_Class objVisaPay = new tpayments_receive_Class();
    tpayments_receivedet_Class objVisaPayDet = new tpayments_receivedet_Class();
    validation valobj = new validation();
    mclient_Class objAgent = new mclient_Class();
    
    mbranches_Class objlocation = new mbranches_Class();
    //  mvisa_company_Class objVisaCompany = new mvisa_company_Class();
    mvisa_type_Class objVisaType = new mvisa_type_Class();
    mtax_master_Class objTaxMaster = new mtax_master_Class();
    msupgst_Class objSupGst = new msupgst_Class();
    mclientgst_Class objClntGst = new mclientgst_Class();
    tvisarefund_Class objRefund = new tvisarefund_Class();

    mmain_account_Class objAccTitle = new mmain_account_Class();
    tchartof_account_Class objCAcc = new tchartof_account_Class();
    mCountry_Class objCountry = new mCountry_Class();


    mmain_account_Class objAccount = new mmain_account_Class();
    msupplier_Class objSupplier = new msupplier_Class();
    mclient_Class objClient = new mclient_Class();
    mbranches_Class objBranch = new mbranches_Class();

    string cond;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                string aa = Server.UrlEncode(System.DateTime.Now.ToString());
                Session["tvisa"] = aa;
                tblmain.Visible = true;
                tblDet.Visible = true;
                tblGridDet.Visible = false;
                tblGrd.Visible = false;
                PnlPayment.Visible = false;

               
                  objClass.ddlOperation(objClass, "ddlCustomer", "", ddlAgentID);
                //  objAccTitle.ddlOperation(objAccTitle, "ShowddlAccount", "", ddlLAccountTitle);
                //   objClass.ddlOperation(objClass, "ddlCustomer", ddlAgentID.SelectedValue, ddlCompanyID);
                objlocation.ddlOperation(objlocation, "Showddl", "", ddlLocationID);
                objClass.ddlOperation(objClass, "ddlVendor", "", ddlSupplier);
                objVisaType.ddlOperation(objVisaType, "Show", "", ddlVisaTypeID);
                objCountry.ddlOperation(objCountry, "Show", "", ddlCountry);
                btnVisible();
                txttBooking.Text = validation.fillDate();
                txttBooking_TextChanged(this, e);
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

                if (Session["TVid"] != null && Session["TVid"] != "")
                {
                    string eid = Session["TVid"].ToString();
                    Session["eid"] = eid;
                    Session["TVid"] = "";
                    GetFormData();
                    GetFormDataDet();
                    btnAdd.Visible = false;
                    btnAddDet.Visible = false;
                    btnUpdateDet.Visible = true;
                    btnPrint.Visible = true;
                    btnPaymentHistory.Visible = true;

                }
               
                var ID = Request.QueryString["ID"];
                if (!string.IsNullOrEmpty(ID))
                {
                    Session["eid"] = ID;
                    GetFormData();

                    lblmsg.Text = "";
                    tblmain.Visible = true;
                    tblGridDet.Visible = true;
                    tblDet.Visible = true;
                    tblGrd.Visible = false;

                    btnAdd.Visible = false;
                    btnAddDet.Visible = true;
                    btnUpdateDet.Visible = false;
                    btnPrint.Visible = true;
                    btnPaymentHistory.Visible = true;
                    displayGridDet();
                    DisableData();
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
        ViewState["tvisa"] = Session["tvisa"];
    }

    public void para()
    {
        objClass.sVisaBookingNo = validation.stringToDBString(txtVisaBookingNo.Text.Trim());
        objClass.dtBooking = validation.dateToText(txttBooking.Text.Trim());
        objClass.nAgentID = ddlAgentID.SelectedValue;
        objClass.nLocationID = ddlLocationID.SelectedValue;
        objClass.nVisaCompanyID = ddlSupplier.SelectedValue;
        objClass.nBookTypeID = ddlbookType.SelectedValue;
        objClass.bPaid = "0";  //Un paid 
    }

    public void clrfield()
    {
        txtVisaBookingNo.Text = "";
        txttBooking.Text = "";
        ddlAgentID.SelectedValue = "0";
        ddlLocationID.SelectedValue = "0";
        ddlSupplier.SelectedValue = "0";
        ddlbookType.SelectedValue = "0";
        Session["eid"] = "";
    }

    public void GetFormData()
    {
        DataTable dt = objClass.viewData(objClass, "show", Session["eid"].ToString());
        if (dt.Rows.Count > 0)
        {
            txtVisaBookingNo.Text = dt.Rows[0][1].ToString();
            txttBooking.Text = validation.TextToDate(dt.Rows[0][2].ToString());

            ddlLocationID.SelectedValue = dt.Rows[0][4].ToString();
            ddlSupplier.SelectedValue = dt.Rows[0][5].ToString();
            EventArgs e = new EventArgs();
            ddlSupplier_SelectedIndexChanged(this, e);
            ddlAgentID.SelectedValue = dt.Rows[0][3].ToString();
            ddlbookType.SelectedValue = dt.Rows[0][8].ToString();
        }
    }

    public void btnVisible()
    {
        btnAdd.Visible = true;
        btnAddDet.Visible = false;
        btnUpdateDet.Visible = false;
        btnPrint.Visible = false;
        btnPaymentHistory.Visible = false;
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

    protected void txttBooking_TextChanged(object sender, EventArgs e)
    {
        Booking_Generate();
    }
    public void Booking_Generate()
    {
        DataTable dt = objClass.viewData(objClass, "MaxBookNo", validation.dateToText(txttBooking.Text));
        if (dt.Rows.Count > 0)
        {
            txtVisaBookingNo.Text = dt.Rows[0][0].ToString();
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



    public void DisableData()
    {
        //txttBooking.Enabled = false;
        ////  Img2.Enabled = false;
        //ddlAgentID.Enabled = false;
        //ddlLocationID.Enabled = false;
        //ddlSupplier.Enabled = false;
    }
    public void VisibleData()
    {
        txttBooking.Enabled = true;
        //   Img2.Enabled = true;
        ddlAgentID.Enabled = true;
        ddlLocationID.Enabled = true;
        ddlSupplier.Enabled = true;
    }
    public void DeleteRecord()
    {
        objClass.nVisaId = Session["eid"].ToString();
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
            if (Session["tvisa"].ToString() == ViewState["tvisa"].ToString())
            {
                para();
                var abc = objClass.User_Operation(objClass, "add");
                valobj.showMsg(abc, lblmsg);

                var strArr = abc.Split(',');
                if (strArr[0] == "1")
                {
                    string VisaID = strArr[2].ToString();
                    Session["eid"] = VisaID;

                    paraDet();
                    var xyz = objClassDet.User_Operation(objClassDet, "add");

                    tblGridDet.Visible = true;
                    displayGridDet();
                    btnAdd.Visible = false;
                    //btnUpdate.Visible = true;
                    btnAddDet.Visible = true;
                    btnUpdateDet.Visible = false;
                    btnPrint.Visible = true;
                    btnPaymentHistory.Visible = true;
                    //   GetFormDataDet();
                    // clrfieldDet();
                    //btnUpdate.Visible = true;
                    //btnDelete.Visible = true;
                }


                //displayGrid();
                string aa = Server.UrlEncode(System.DateTime.Now.ToString());
                Session["tvisa"] = aa;



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

    //protected void btnUpdate_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        para();
    //        objClass.nVisaId = Session["eid"].ToString();
    //        var abc = objClass.User_Operation(objClass, "edit");
    //        valobj.showMsg(abc, lblmsg);
    //        //displayGrid();
    //    }
    //    catch (Exception ex)
    //    {
    //        valobj.showMsg(ex.Message, "FAIL", lblmsg);
    //    }
    //    finally
    //    {
    //    }
    //}

    //protected void btnDelete_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        DeleteRecord();
    //    }
    //    catch (Exception ex)
    //    {
    //        valobj.showMsg(ex.Message, "FAIL", lblmsg);
    //    }
    //    finally
    //    {
    //    }
    //}

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


            GetFormData();
            //  GetFormDataDet();
            if (ddlbookType.SelectedValue == "2")
            {
                tblrefund.Visible = true;

                GetFormDataRefund();

                ddlVisaTypeID_TextChanged(this, e);
            }
            else
            {
                tblrefund.Visible = false;
            }
            lblmsg.Text = "";
            tblmain.Visible = true;
            tblGridDet.Visible = true;
            tblDet.Visible = true;
            tblGrd.Visible = false;

            btnAdd.Visible = false;
            btnAddDet.Visible = true;
            btnUpdateDet.Visible = false;
            btnPrint.Visible = true;
            btnPaymentHistory.Visible = true;
            //btnUpdate.Visible = true;
            //btnDelete.Visible = true;
            //  DetButtonVisible();
            displayGridDet();
            DisableData();
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

            Label lblType = (Label)GridView1.Rows[row].Cells[0].FindControl("lblbookType");
            //if (lblType.Text == "Booking")
            //{
            //    Response.Redirect("rptVisaInvoice.aspx?id=" + ID.Text);
            //}
            //else
            //{
            //    Response.Redirect("rptVisaRefund_Invoice.aspx?id=" + ID.Text);
            //}
            Response.Redirect("Invoices/rptvisa_invoice.aspx?id=" + ID.Text);
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
            objClass.nVisaId = Session["eid"].ToString();
            //if (ddlbookType.SelectedValue == "1")
            //{
            //    Response.Redirect("rptVisaInvoice.aspx?id=" + Session["eid"].ToString());
            //}
            //else
            //{
            //    Response.Redirect("rptVisaRefund_Invoice.aspx?id=" + Session["eid"].ToString());
            //}
            Response.Redirect("Invoices/rptvisa_invoice.aspx?id=" + Session["eid"].ToString());

        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, "FAIL", lblmsg);
        }
        finally
        {
        }
    }
    protected void btngdPrintdet_Click(object sender, EventArgs e)
    {
        Session["Detid"] = "";
        LinkButton thisbtn = (LinkButton)sender;
        GridViewRow thisgrdR = (GridViewRow)thisbtn.Parent.Parent;
        int row = thisgrdR.RowIndex;
        Label ID = (Label)GridView2.Rows[row].Cells[0].FindControl("lblIDDet");
        Session["Detid"] = ID.Text;

        Label lblType = (Label)GridView2.Rows[row].Cells[0].FindControl("lblBookType");
        if (lblType.Text == "Booking")
        {
            Response.Redirect("Invoices/rptvisa_invoice.aspx?Detid=" + ID.Text);
        }
        else
        {

            Response.Redirect("Invoices/rptvisa_refund_invoice.aspx?Detid=" + ID.Text);
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

    // Vesa Detail Table 
    public void paraDet()
    {
        double SupSC = 0, ClientSC = 0;

        objClassDet.nVisaID = Session["eid"].ToString();
        objClassDet.sReferenceNo = validation.stringToDBString(txtReferenceNo.Text.Trim());
        objClassDet.sCustomerName = validation.stringToDBString(txtCustomerName.Text.Trim());
        objClassDet.bGender = ddlGender.SelectedValue;
        objClassDet.dtDOB = validation.dateToText(txttDOB.Text.Trim());
        objClassDet.sPassportNo = validation.stringToDBString(txtPassportNo.Text.Trim());
      //  objClassDet.dtPassportIssue = validation.dateToText(txttPassportIssue.Text.Trim());
      //  objClassDet.dtPasspoprtExpiry = validation.dateToText(txttPasspoprtExpiry.Text.Trim());
        objClassDet.sNationality = validation.stringToDBString(txtNationality.Text.Trim());
        objClassDet.dtExpectedArrival = validation.dateToText(txttExpectedArrival.Text.Trim());
        objClassDet.dtExpectedDeparture = validation.dateToText(txttExpectedDeparture.Text.Trim());
        objClassDet.nExpectedDuration = txtExpectedDuration.Text.Trim();
        objClassDet.nVisaCompanyID = "0";
        objClassDet.nVisaTypeID = ddlVisaTypeID.SelectedValue;
        objClassDet.nVisaStatusID = ddlVisaStatusID.SelectedValue;
        objClassDet.nExtension = txtExtension.Text.Trim();
        objClassDet.sReference1 = "";
      //  objClassDet.sContact1 = validation.stringToDBString(txtContact1.Text.Trim());
        objClassDet.sReference2 = "";
        objClassDet.sContact2 = "";
        objClassDet.nOtherCharges = txtOtherCharge.Text.Trim();
        objClassDet.nCourierCharges = txtCourierCharge.Text.Trim();
        objClassDet.dtVisaExpiryDate = validation.dateToText(txtdtVisaExpiry.Text.Trim());
        objClassDet.nCost = txtCost.Text.Trim();
        objClassDet.nDuration = txtDuration.Text.Trim();
      //  objClassDet.dtApply = validation.dateToText(txttApply.Text.Trim());
     //   objClassDet.dtIssue = validation.dateToText(txttIssue.Text.Trim());
        objClassDet.nVisaRate = lblSelleing.Text.Trim();
        //objClassDet.nClntSC2 = txtProfitAmt2.Text.Trim();
        //   objClassDet.nBalance = txtBalance.Text.Trim();
        if (txtProfitAmt.Text == "")
        {
            txtProfitAmt.Text = "0";
        }
        if (txtCost.Text == "")
        {
            txtCost.Text = "0";
        }
        if (txtProfitAmt2.Text == "")
        {
            txtProfitAmt2.Text = "0";
        }
        if (txtSupSc.Text == "")
        {
            txtSupSc.Text = "0";
        }
        if (txtSupTds.Text == "")
        {
            txtSupTds.Text = "0";
        }
        if (txtClntTdsAmount.Text == "")
        {
            txtClntTdsAmount.Text = "0";
        }
        objClassDet.nProfitTypeID = ddlProfitType.SelectedValue;
        if (ddlProfitType.SelectedValue == "0")
        {
            objClassDet.nProfitPercent = "0";
            objClassDet.nProfitAmount = txtProfitAmt.Text.Trim();
            ClientSC = double.Parse(txtProfitAmt.Text.Trim());
        }
        else
        {
            objClassDet.nProfitPercent = txtProfitAmt.Text.Trim();
            ClientSC = double.Parse(txtCost.Text) * double.Parse(txtProfitAmt.Text) / 100;
            objClassDet.nProfitAmount = (ClientSC * double.Parse(txtProfitAmt.Text) / 100).ToString();
        }

        if (ddlProfitType.SelectedValue == "0")
        {
            objClassDet.nClntSC2Percent = "0";
            objClassDet.nClntSC2Amount = txtProfitAmt2.Text.Trim();
            ClientSC = double.Parse(txtProfitAmt2.Text.Trim());
        }
        else
        {
            objClassDet.nClntSC2Percent = txtProfitAmt.Text.Trim();
            ClientSC = double.Parse(txtCost.Text) * double.Parse(txtProfitAmt2.Text) / 100;
            objClassDet.nClntSC2Amount = (ClientSC * double.Parse(txtProfitAmt2.Text) / 100).ToString();
        }
        objClassDet.nDiscount = txtDiscount.Text.Trim();
        objClassDet.sRemarks = validation.stringToDBString(txtRemarks.Text.Trim());

        objClassDet.nBuyCost = lblBuyCost.Text.Trim();

        objClassDet.nSupSCtype = ddlSupScType.SelectedValue;

        if (ddlSupScType.SelectedValue == "0")
        {
            objClassDet.nSupSCPercent = "0";
            objClassDet.nSupSCAmount = txtSupSc.Text.Trim();
            SupSC = double.Parse(txtSupSc.Text.Trim());
        }
        else
        {
            objClassDet.nSupSCPercent = txtSupSc.Text.Trim();
            SupSC = double.Parse(txtCost.Text) * double.Parse(txtSupSc.Text) / 100;
            objClassDet.nSupSCAmount = SupSC.ToString();
        }
        objClassDet.nSupTDStype = ddlSupTds.SelectedValue;
        if (ddlSupTds.SelectedValue == "0")
        {
            objClassDet.nSupTDSPercent = "0";
            objClassDet.nSupTDSAmount = txtSupTds.Text.Trim();
        }
        else
        {
            objClassDet.nSupTDSPercent = txtSupTds.Text.Trim();
            double SupTDS = (SupSC * double.Parse(txtSupTds.Text)) / 100;
            objClassDet.nSupTDSAmount = SupTDS.ToString();
        }

        if (chkSupTax.Checked)
        {
            objClassDet.bSupGst = "1";
        }
        else
        {
            objClassDet.bSupGst = "0";
        }
        objClassDet.nSupCGst = txtsupcgst.Text.Trim();
        objClassDet.nSupSGst = txtsupsgst.Text.Trim();
        objClassDet.nSupIGst = txtsupigst.Text.Trim();

        objClassDet.nClntTdsType = ddlClntTds.SelectedValue;
        if (ddlClntTds.SelectedValue == "0")
        {
            objClassDet.nClntTdsPercent = "0";
            objClassDet.nClntTdsAmount = txtClntTdsAmount.Text.Trim();
        }
        else
        {
            objClassDet.nClntTdsPercent = txtClntTdsAmount.Text.Trim();
            double ClntTDS = (ClientSC * double.Parse(txtClntTdsAmount.Text)) / 100;
            objClassDet.nClntTdsAmount = ClntTDS.ToString();
        }

        if (chkClntTax.Checked)
        {
            objClassDet.bClntGst = "1";
        }
        else
        {
            objClassDet.bClntGst = "0";
        }
        objClassDet.nClntCGst = txtClntCgst.Text.Trim();
        objClassDet.nClntSGst = txtClntSgst.Text.Trim();
        objClassDet.nClntIGst = txtClntIgst.Text.Trim();
        objClassDet.nCountryID = ddlCountry.SelectedValue;
        objClassDet.nBookTypeID = ddlbookType.SelectedValue;
        objClassDet.nSupDiscount = txtSupDisc.Text.Trim();

    }

    public void clrfieldDet()
    {

        txtReferenceNo.Text = "";
        txtCustomerName.Text = "";
        ddlGender.SelectedValue = "1";
        txttDOB.Text = "";
        txtPassportNo.Text = "";
    //    txttPassportIssue.Text = "";
    //    txttPasspoprtExpiry.Text = "";
        txtNationality.Text = "";
        txttExpectedArrival.Text = "";
        txttExpectedDeparture.Text = "";
        txtExpectedDuration.Text = "";
        ddlSupplier.SelectedValue = "0";
        ddlVisaTypeID.SelectedValue = "0";
        ddlVisaStatusID.SelectedValue = "0";
        txtExtension.Text = "";
        //txtReference1.Text = "";
     //   txtContact1.Text = "";
        //txtReference2.Text = "";
        //txtContact2.Text = "";
        txtClntCost.Text = "";
        txtProfitAmt.Text = "";
        txtClntTdsAmount.Text = "";
        
        txtProfitAmt2.Text = "0";
        //   txtDeposit.Text = "";
        txtdtVisaExpiry.Text = "";
        txtCost.Text = "";

        txtDuration.Text = "";
  //      txttApply.Text = "";
       // txttIssue.Text = "";
        txtVisaRate.Text = "";
        txtCourierCharge.Text = "";
        txtOtherCharge.Text = "";
        //   txtBalance.Text = "";
        txtDiscount.Text = "";
        ddlProfitType.SelectedValue = "0";
        txtProfitAmt.Text = "";
        txtSupDisc.Text = "0";
        txtRemarks.Text = "";
        txtSupSc.Text = "";
        txtSupTds.Text = "";
        Session["Detid"] = "";
       
    }
    public void DetButtonVisible()
    {
        tblDet.Visible = true;
        tblGridDet.Visible = true;
        btnAddDet.Visible = true;
        btnUpdateDet.Visible = false;
        btnPrint.Visible = true;
        btnPaymentHistory.Visible = true;
        //btnDeleteDet.Visible = false;
        //clrfieldDet();
    }

    public void GetFormDataDet()
    {
        DataTable dt = objClassDet.viewData(objClassDet, "show", Session["Detid"].ToString());
        if (dt.Rows.Count > 0)
        {
            Session["Detid"] = dt.Rows[0][0].ToString();
            txtReferenceNo.Text = dt.Rows[0][2].ToString();
            txtCustomerName.Text = dt.Rows[0][3].ToString();
            ddlGender.SelectedValue = dt.Rows[0][4].ToString();
            txttDOB.Text = validation.TextToDate(dt.Rows[0][5].ToString());
            txtPassportNo.Text = dt.Rows[0][6].ToString();
        //    txttPassportIssue.Text = validation.TextToDate(dt.Rows[0][7].ToString());
          //  txttPasspoprtExpiry.Text = validation.TextToDate(dt.Rows[0][8].ToString());
            txtNationality.Text = dt.Rows[0][9].ToString();
            txttExpectedArrival.Text = validation.TextToDate(dt.Rows[0][10].ToString());
            txttExpectedDeparture.Text = validation.TextToDate(dt.Rows[0][11].ToString());
            txtExpectedDuration.Text = dt.Rows[0][12].ToString();
            //  ddlSupplier.SelectedValue = dt.Rows[0][13].ToString();
            ddlVisaTypeID.SelectedValue = dt.Rows[0][14].ToString();
            ddlVisaStatusID.SelectedValue = dt.Rows[0][15].ToString();
            txtExtension.Text = dt.Rows[0][16].ToString();
            // txtReference1.Text = dt.Rows[0][17].ToString();
        //    txtContact1.Text = dt.Rows[0][18].ToString();
            //txtReference2.Text = dt.Rows[0][19].ToString();
            //txtContact2.Text = dt.Rows[0][20].ToString();
            txtOtherCharge.Text = dt.Rows[0][21].ToString();
            txtCourierCharge.Text = dt.Rows[0][22].ToString();
            txtdtVisaExpiry.Text = validation.TextToDate(dt.Rows[0][23].ToString());
            txtCost.Text = dt.Rows[0][24].ToString();
            txtClntCost.Text = dt.Rows[0][24].ToString();
            txtDuration.Text = dt.Rows[0][25].ToString();
       //     txttApply.Text = validation.TextToDate(dt.Rows[0][26].ToString());
        //    txttIssue.Text = validation.TextToDate(dt.Rows[0][27].ToString());
            txtVisaRate.Text = dt.Rows[0][28].ToString();

            ddlProfitType.SelectedValue = dt.Rows[0][31].ToString();
            if (ddlProfitType.SelectedValue == "1")
            {
                txtProfitAmt2.Text = dt.Rows[0][29].ToString();
            }
            else
            {
                txtProfitAmt2.Text = dt.Rows[0][30].ToString();
            }
            //    txtBalance.Text = dt.Rows[0][30].ToString();

            if (ddlProfitType.SelectedValue == "1")
            {
                txtProfitAmt.Text = dt.Rows[0][32].ToString();
            }
            else
            {
                txtProfitAmt.Text = dt.Rows[0][33].ToString();
            }


            txtDiscount.Text = dt.Rows[0][34].ToString();
            txtRemarks.Text = dt.Rows[0][35].ToString();

            txtBuyCost.Text = dt.Rows[0][36].ToString();
            ddlSupScType.SelectedValue = dt.Rows[0][37].ToString();
            if (ddlSupScType.SelectedValue == "1")
            {
                txtSupSc.Text = dt.Rows[0][38].ToString();
            }
            else
            {
                txtSupSc.Text = dt.Rows[0][39].ToString();
            }
            ddlSupTds.SelectedValue = dt.Rows[0][40].ToString();
            if (ddlSupTds.SelectedValue == "1")
            {
                txtSupTds.Text = dt.Rows[0][41].ToString();
            }
            else
            {
                txtSupTds.Text = dt.Rows[0][42].ToString();
            }
            if (dt.Rows[0][43].ToString() == "1")
            {
                chkSupTax.Checked = true;
            }
            else
            {
                chkSupTax.Checked = false;
            }
            txtsupcgst.Text = dt.Rows[0][44].ToString();
            txtsupsgst.Text = dt.Rows[0][45].ToString();
            txtsupigst.Text = dt.Rows[0][46].ToString();

            ddlClntTds.SelectedValue = dt.Rows[0][47].ToString();
            if (ddlClntTds.SelectedValue == "1")
            {
                txtClntTdsAmount.Text = dt.Rows[0][48].ToString();
            }
            else
            {
                txtClntTdsAmount.Text = dt.Rows[0][49].ToString();
            }
            if (dt.Rows[0][50].ToString() == "1")
            {
                chkClntTax.Checked = true;
            }
            else
            {
                chkClntTax.Checked = false;
            }
            txtClntCgst.Text = dt.Rows[0][51].ToString();
            txtClntSgst.Text = dt.Rows[0][52].ToString();
            txtClntIgst.Text = dt.Rows[0][53].ToString();
            ddlCountry.SelectedValue = dt.Rows[0][54].ToString();
            ddlbookType.SelectedValue = dt.Rows[0][55].ToString();
            txtSupDisc.Text = dt.Rows[0][56].ToString();
        }
    }

    public void btnVisibleDet()
    {
        // btnAdd.Visible = true;
        //btnUpdate.Visible = false;
        //btnDelete.Visible = false;
        //  clrfieldDet();
    }

    public void displayGridDet()
    {
        try
        {
            objClassDet.sReference1 = Session["eid"].ToString();
            objClassDet.sCustomerName = "0";
            objClassDet.sPassportNo = "0";
            objClassDet.sNationality = "0";
            objClassDet.dtVisaExpiryDate = "0";
            objClassDet.dtIssue = "";
            objClassDet.dtApply = "";
            objClassDet.FillGrid(objClassDet, GridView2, "ShowSearch", "");
        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, lblmsg);
        }
    }


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
            if (Session["tvisa"].ToString() == ViewState["tvisa"].ToString())
            {
                paraDet();
                var abc = objClassDet.User_Operation(objClassDet, "add");
                valobj.showMsg(abc, lblmsg);

                string aa = Server.UrlEncode(System.DateTime.Now.ToString());
                Session["tvisa"] = aa;
                tblDet.Visible = true;
                tblGridDet.Visible = true;
                btnAddDet.Visible = true;
                btnUpdateDet.Visible = false;
                //btnDeleteDet.Visible = false;
                displayGridDet();
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
            Label IDDet = (Label)GridView2.Rows[row].Cells[0].FindControl("lblIDDet");
            Session["Detid"] = IDDet.Text;

            Label VisaID = (Label)GridView2.Rows[row].Cells[0].FindControl("lblvisaID");
            Session["eid"] = VisaID.Text;

            btnAddDet.Visible = false;
            btnUpdateDet.Visible = true;
            btnPrint.Visible = true;
            btnPaymentHistory.Visible = true;
            // btnDeleteDet.Visible = true;
            // DetButtonVisible();
            GetFormDataDet();
            displayGridDet();

            if (ddlbookType.SelectedValue == "2")
            {
                tblrefund.Visible = true;

                GetFormDataRefund();

                txtProfitAmt_TextChanged(this, e);
                lblBuyCost.Visible = true;
                lblBuyCostTitle.Visible = true;
                lblSelleing.Visible = true;
                lblSelleingTitle.Visible = true;
            }
            else
            {
                tblrefund.Visible = false;
                lblBuyCost.Visible = false;
                lblBuyCostTitle.Visible = false;
                lblSelleing.Visible = false;
                lblSelleingTitle.Visible = false;
            }

            lblmsg.Text = "";



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
            //para();
            //objClass.nVisaId = Session["eid"].ToString();
            //var abc1 = objClass.User_Operation(objClass, "edit");

            paraDet();
            objClassDet.nVisaID = Session["eid"].ToString();
            objClassDet.nVisaDetID = Session["Detid"].ToString();

            var abc = objClassDet.User_Operation(objClassDet, "edit");

            if (ddlbookType.SelectedValue == "2")
            {
                RefundSave();
            }
            valobj.showMsg(abc, lblmsg);
            DetButtonVisible();
            displayGridDet();
            //clrfieldDet();
        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, "FAIL", lblmsg);
        }
        finally
        {
        }
    }

    protected void btnDeleteDet_Click(object sender, EventArgs e)
    {
        try
        {
            DeleteDetRecord();
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
            Label IDDet = (Label)GridView2.Rows[row].Cells[0].FindControl("lblIDDet");
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
        objClassDet.nVisaDetID = Session["Detid"].ToString();
        var vres = objClassDet.User_Operation(objClassDet, "DeActive");
        valobj.showMsg(vres, lblmsg);
        displayGridDet();
        DetButtonVisible();
    }

    protected void lnkAdd_Click(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        tblmain.Visible = true;
        tblGrd.Visible = false;
        tblDet.Visible = true;
        tblGridDet.Visible = false;
        PnlPayment.Visible = false;
        clrfield();
        clrfieldDet();
        btnVisible();

        VisibleData();
        txttBooking.Text = validation.fillDate();
        Booking_Generate();
        Session["eid"] = "";
        Session["Detid"] = "";
        Session["TVid"] = "";
    }
    protected void lnkList_Click(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        tblmain.Visible = false;
        tblGrd.Visible = true;
        tblGridDet.Visible = false;
        PnlPayment.Visible = false;
        Session["eid"] = "";
        Session["Detid"] = "";
        displayGrid();
        Session["TVid"] = "";
        objClass.ddlOperation(objClass, "ddlCustomer", "", ddlSClient);
        objlocation.ddlOperation(objlocation, "Show", "", ddlSLoc);
        objClass.ddlOperation(objClass, "ddlVendor", "", ddlSSup);
        objClass.ddlOperation(objClass, "show", "", ddlInvoiceNo);
        Response.Redirect("tvisa_list.aspx");

    }
    //protected void btnLedger_Click(object sender, EventArgs e)
    //{
    //    string AccountID = ddlLAccountTitle.SelectedValue;

    //    string AccCode = "";
    //    string dtFrom = txtldtFrom.Text;
    //    string dtTo = txtldtTo.Text;

    //    if (ddlLAccountTitle.SelectedValue != "0")
    //    {
    //        DataTable dt = objClassDet.viewData(objClassDet, "ShowCode", ddlLAccountTitle.SelectedValue);
    //        if (dt.Rows.Count > 0)
    //        {
    //            AccCode = dt.Rows[0]["sCode"].ToString();
    //        }
    //    }

    //    Response.Redirect("rptGeneralLedger.aspx?AccountID=" + AccountID + "&AccCode=" + AccCode + "&dtFrom=" + dtFrom + "&dtTo=" + dtTo);
    //}


    protected void ddlVisaTypeID_TextChanged(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = objVisaType.viewData(objVisaType, "Show", ddlVisaTypeID.SelectedValue);
            if (dt.Rows.Count > 0)
            {
                txtDuration.Text = dt.Rows[0][2].ToString();
               // txtCost.Text = dt.Rows[0][3].ToString();
              //  txtProfitAmt_TextChanged(this, e);

            }
            else
            {
             //   txtCost.Text = "0";
            }
           // txtClntCost.Text = txtCost.Text;
        }
        catch
        {

        }
        finally
        {

        }
    }

    protected void txtProfitAmt2_TextChanged(object sender, EventArgs e)
    {
        try
        {
            txtProfitAmt_TextChanged(this, e);
            txtClntTdsAmount.Focus();

        }
        catch
        {

        }
        finally
        {

        }
    }
    protected void txtProfitAmt_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (txtSupSc.Text == "")
            {
                txtSupSc.Text = "0";
            }
            if (txtSupTds.Text == "")
            {
                txtSupTds.Text = "0";
            }
            //if (txtDeposit.Text == "")
            //{
            //    txtDeposit.Text = "0";
            //}
            if (txtProfitAmt2.Text == "")
            {
                txtProfitAmt2.Text = "0";
            }
            if (txtProfitAmt.Text == "")
            {
                txtProfitAmt.Text = "0";
            }
            if (txtVisaRate.Text == "")
            {
                txtVisaRate.Text = "0";
            }
            if (txtClntTdsAmount.Text == "")
            {
                txtClntTdsAmount.Text = "0";
            }

            if (txtCost.Text == "")
            {
                txtCost.Text = "0";
            }
            if (txtProfitAmt2.Text == "")
            {
                txtProfitAmt2.Text = "0";
            }
            if (txtCourierCharge.Text == "")
            {
                txtCourierCharge.Text = "0";
            }
            if (txtOtherCharge.Text == "")
            {
                txtOtherCharge.Text = "0";
            }

            if (txtDiscount.Text == "")
            {
                txtDiscount.Text = "0";
            }
            if (txtsupcgst.Text == "")
            {
                txtsupcgst.Text = "0";
            }
            if (txtsupsgst.Text == "")
            {
                txtsupsgst.Text = "0";
            }
            if (txtsupcgst.Text == "")
            {
                txtsupcgst.Text = "0";
            }
            if (txtClntCgst.Text == "")
            {
                txtClntCgst.Text = "0";
            }
            if (txtClntSgst.Text == "")
            {
                txtClntSgst.Text = "0";
            }
            if (txtClntIgst.Text == "")
            {
                txtClntIgst.Text = "0";
            }
            if (txtSupTds.Text == "")
            {
                txtSupTds.Text = "0";
            }
            if (txtSupDisc.Text == "")
            {
                txtSupDisc.Text = "0";
            }

            if (chkSupTax.Checked == false)
            {
                txtsupcgst.Text = "0";
                txtsupsgst.Text = "0";
                txtsupigst.Text = "0";
            }
            if (chkClntTax.Checked == false)
            {
                txtClntCgst.Text = "0";
                txtClntSgst.Text = "0";
                txtClntIgst.Text = "0";
            }
            if (txtSupTds.Text == "")
            {
                txtSupTds.Text = "0";
            }

            if (chkRfnTax.Checked == false)
            {
                txtRfnIGst.Text = "0";
                txtRfnCGst.Text = "0";
                txtRfnSGst.Text = "0";
            }
            if (txtRfnIGst.Text == "")
            {
                txtRfnIGst.Text = "0";
            }
            if (txtRfnCGst.Text == "")
            {
                txtRfnCGst.Text = "0";
            }
            if (txtRfnSGst.Text == "")
            {
                txtRfnSGst.Text = "0";
            }
            if (txtrfnSC.Text == "")
            {
                txtrfnSC.Text = "0";
            }
            if (txtRefundAmt.Text == "")
            {
                txtRefundAmt.Text = "0";
            }
            if (txtProfitAmt2.Text == "")
            {
                txtProfitAmt2.Text = "0";
            }
            if (txtOtherCharge.Text == "")
            {
                txtOtherCharge.Text = "0";
            }
            if (txtCourierCharge.Text == "")
            {
                txtCourierCharge.Text = "0";
            }
            if (txtClntCost.Text == "")
            {
                txtClntCost.Text = "0";
            }


            //GST Calculation
            GstCal();
            string supSc, ClntSC, ClntSC2, SupTDS, ClntTDS;

            if (ddlSupScType.SelectedValue == "0")
            {
                supSc = (double.Parse(txtSupSc.Text)).ToString();
            }
            else
            {
                supSc = (double.Parse(txtCost.Text) * double.Parse(txtSupSc.Text) / 100).ToString();

            }
            if (ddlSupTds.SelectedValue == "0")
            {
                SupTDS = (double.Parse(txtSupTds.Text)).ToString();
            }
            else
            {
                SupTDS = (double.Parse(supSc) * double.Parse(txtSupTds.Text) / 100).ToString();

            }


            if (ddlbookType.SelectedValue == "2")
            {
                string SupCost = (double.Parse(txtCost.Text) + double.Parse(supSc) - double.Parse(SupTDS) - double.Parse(txtSupDisc.Text) + double.Parse(txtsupcgst.Text) + double.Parse(txtsupsgst.Text) + double.Parse(txtsupigst.Text)).ToString();

                txtBuyCost.Text = (double.Parse(SupCost) - double.Parse(txtRefundAmt.Text) - double.Parse(txtRfnCGst.Text) - double.Parse(txtRfnSGst.Text) - double.Parse(txtRfnIGst.Text)).ToString();
            }
            else
            {
                txtBuyCost.Text = (double.Parse(txtCost.Text) + double.Parse(supSc) - double.Parse(SupTDS) - double.Parse(txtSupDisc.Text) + double.Parse(txtsupcgst.Text) + double.Parse(txtsupsgst.Text) + double.Parse(txtsupigst.Text)).ToString();
            }
            lblBuyCost.Text = (double.Parse(txtCost.Text) + double.Parse(supSc) - double.Parse(SupTDS) - double.Parse(txtSupDisc.Text) + double.Parse(txtsupcgst.Text) + double.Parse(txtsupsgst.Text) + double.Parse(txtsupigst.Text)).ToString();

            //Selling Cost

            if (ddlProfitType.SelectedValue == "0")
            {
                ClntSC = (double.Parse(txtProfitAmt.Text)).ToString();
                ClntSC2 = (double.Parse(txtProfitAmt2.Text)).ToString();
            }
            else
            {
                ClntSC = (double.Parse(txtBuyCost.Text) * double.Parse(txtProfitAmt.Text) / 100).ToString();
                ClntSC2 = (double.Parse(txtBuyCost.Text) * double.Parse(txtProfitAmt2.Text) / 100).ToString();
                //txtBuyCost.Text = (double.Parse(txtCost.Text) + Profit - (double.Parse(txtDiscount.Text))).ToString();
                //txtProfitAmt.Focus();
            }
            if (ddlClntTds.SelectedValue == "0")
            {
                ClntTDS = (double.Parse(txtClntTdsAmount.Text)).ToString();
            }
            else
            {
                ClntTDS = (double.Parse(ClntSC) * double.Parse(txtClntTdsAmount.Text) / 100).ToString();
                //txtBuyCost.Text = (double.Parse(txtCost.Text) + Profit - (double.Parse(txtDiscount.Text))).ToString();
                //txtProfitAmt.Focus();
            }

            if (ddlbookType.SelectedValue == "2")
            {
                //String ClientCost = ((double.Parse(lblSupCost.Text)) + double.Parse(ClntSC) + double.Parse(ClntSC2) - double.Parse(ClntTDS) - double.Parse(txtDiscount.Text) + (double.Parse(txtClntCgst.Text)) + (double.Parse(txtClntSgst.Text)) + (double.Parse(txtClntIgst.Text))).ToString();
                //txtTotal.Text = (double.Parse(ClientCost) - double.Parse(txtRefundAmt.Text) - double.Parse(txtRfnCGst.Text) - double.Parse(txtRfnSGst.Text) - double.Parse(txtRfnIGst.Text) - double.Parse(txtrfnSC.Text)).ToString();
                txtVisaRate.Text = "-" + (double.Parse(txtBuyCost.Text) - double.Parse(txtrfnSC.Text)).ToString();

            }
            else
            {
                txtVisaRate.Text = (double.Parse(lblBuyCost.Text) + double.Parse(ClntSC) + double.Parse(ClntSC2) + double.Parse(txtCourierCharge.Text) + double.Parse(txtOtherCharge.Text) - double.Parse(ClntTDS) + double.Parse(txtClntCgst.Text)
             + double.Parse(txtClntSgst.Text) + double.Parse(txtClntIgst.Text) - double.Parse(txtDiscount.Text)).ToString();
            }


            lblSelleing.Text = (double.Parse(lblBuyCost.Text) + double.Parse(ClntSC) + double.Parse(ClntSC2) + double.Parse(txtCourierCharge.Text) + double.Parse(txtOtherCharge.Text) - double.Parse(ClntTDS) + double.Parse(txtClntCgst.Text)
            + double.Parse(txtClntSgst.Text) + double.Parse(txtClntIgst.Text) - double.Parse(txtDiscount.Text)).ToString();


            // txtBalance.Text = (Double.Parse(lblSelleing.Text) - Double.Parse(txtProfitAmt2.Text)).ToString();
            txtProfitAmt2.Focus();
            ShowEmptyText();
        }
        catch
        {

        }
        finally
        {

        }
    }
    public void ShowEmptyText()
    {
        if (txtSupSc.Text == "0")
        {
            txtSupSc.Text = "";
        }
        if (txtSupTds.Text == "0")
        {
            txtSupTds.Text = "";
        }
        //if (txtDeposit.Text == "")
        //{
        //    txtDeposit.Text = "0";
        //}
        if (txtProfitAmt2.Text == "0")
        {
            txtProfitAmt2.Text = "";
        }
        if (txtProfitAmt.Text == "0")
        {
            txtProfitAmt.Text = "";
        }
        if (txtVisaRate.Text == "0")
        {
            txtVisaRate.Text = "";
        }
        if (txtClntTdsAmount.Text == "0")
        {
            txtClntTdsAmount.Text = "";
        }

        if (txtCost.Text == "0")
        {
            txtCost.Text = "";
        }
        if (txtProfitAmt2.Text == "0")
        {
            txtProfitAmt2.Text = "";
        }
        if (txtCourierCharge.Text == "0")
        {
            txtCourierCharge.Text = "";
        }
        if (txtOtherCharge.Text == "0")
        {
            txtOtherCharge.Text = "";
        }

        if (txtDiscount.Text == "0")
        {
            txtDiscount.Text = "";
        }
        if (txtsupcgst.Text == "0")
        {
            txtsupcgst.Text = "";
        }
        if (txtsupsgst.Text == "0")
        {
            txtsupsgst.Text = "";
        }
        if (txtsupcgst.Text == "0")
        {
            txtsupcgst.Text = "";
        }
        if (txtClntCgst.Text == "0")
        {
            txtClntCgst.Text = "";
        }
        if (txtClntSgst.Text == "0")
        {
            txtClntSgst.Text = "";
        }
        if (txtClntIgst.Text == "0")
        {
            txtClntIgst.Text = "";
        }
        if (txtSupTds.Text == "0")
        {
            txtSupTds.Text = "";
        }

        if (chkSupTax.Checked == false)
        {
            txtsupcgst.Text = "0";
            txtsupsgst.Text = "0";
            txtsupigst.Text = "0";
        }
        if (chkClntTax.Checked == false)
        {
            txtClntCgst.Text = "0";
            txtClntSgst.Text = "0";
            txtClntIgst.Text = "0";
        }
        if (txtSupTds.Text == "0")
        {
            txtSupTds.Text = "";
        }

        if (chkRfnTax.Checked == false)
        {
            txtRfnIGst.Text = "0";
            txtRfnCGst.Text = "0";
            txtRfnSGst.Text = "0";
        }
        if (txtRfnIGst.Text == "0")
        {
            txtRfnIGst.Text = "";
        }
        if (txtRfnCGst.Text == "0")
        {
            txtRfnCGst.Text = "";
        }
        if (txtRfnSGst.Text == "0")
        {
            txtRfnSGst.Text = "";
        }
        if (txtrfnSC.Text == "0")
        {
            txtrfnSC.Text = "";
        }
        if (txtRefundAmt.Text == "0")
        {
            txtRefundAmt.Text = "";
        }
        if (txtProfitAmt2.Text == "0")
        {
            txtProfitAmt2.Text = "";
        }
        if (txtOtherCharge.Text == "0")
        {
            txtOtherCharge.Text = "";
        }
        if (txtCourierCharge.Text == "0")
        {
            txtCourierCharge.Text = "";
        }
        if (txtClntCost.Text == "0")
        {
            txtClntCost.Text = "";
        }
    }
    protected void txtDiscount_TextChanged(object sender, EventArgs e)
    {
        try
        {
            txtProfitAmt_TextChanged(this, e);
            txtCourierCharge.Focus();
        }
        catch
        {

        }
        finally
        {

        }
    }



    protected void chkSupTax_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            txtProfitAmt_TextChanged(this, e);
        }
        catch
        {

        }
        finally
        {

        }
    }
    protected void chkClntTax_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            txtProfitAmt_TextChanged(this, e);

        }
        catch
        {

        }
        finally
        {

        }
    }

    public void GstCal()
    {
        //Sup GST
        DataTable dtSupgst = objSupGst.viewData(objSupGst, "show", ddlSupplier.SelectedValue);


        DataTable dtSupState = objSupplier.viewData(objSupplier, "ShowAcc", ddlSupplier.SelectedValue);
        string SupState;
        if (dtSupState.Rows.Count > 0)
        {
            SupState = dtSupState.Rows[0]["nStateID"].ToString();
        }
        else
        {
            SupState = "0";
        }
        DataTable dtClntState = objClient.viewData(objClient, "ShowAcc", ddlAgentID.SelectedValue);
        string ClntState;
        if (dtClntState.Rows.Count > 0)
        {
            ClntState = dtClntState.Rows[0]["nStateID"].ToString();
        }
        else
        {
            ClntState = "0";
        }

        DataTable dtCompanyState = objBranch.viewData(objBranch, "show", ddlLocationID.SelectedValue);
        string CompState;
        if (dtCompanyState.Rows.Count > 0)
        {
            CompState = dtCompanyState.Rows[0]["nStateID"].ToString();
        }
        else
        {
            CompState = "0";
        }
        if (dtSupgst.Rows.Count > 0)
        {



            string Supigst = dtSupgst.Rows[0]["nSupIgst"].ToString();
            string Supsgst = dtSupgst.Rows[0]["nSupSgst"].ToString();
            string Supcgst = dtSupgst.Rows[0]["nSupCgst"].ToString();


            if (chkSupTax.Checked == false)
            {
                txtsupigst.Text = "0";
                txtsupcgst.Text = "0";
                txtsupsgst.Text = "0";
            }
            else
            {

                if (ddlSupScType.SelectedValue == "0")
                {
                    if (SupState == CompState)
                    {
                        txtsupigst.Text = "0";
                        //  txtsupigst.Text = ((double.Parse(txtSupSc.Text)) * (double.Parse(Supigst)) / 100).ToString();
                        txtsupcgst.Text = ((double.Parse(txtSupSc.Text)) * (double.Parse(Supsgst)) / 100).ToString();
                        txtsupsgst.Text = ((double.Parse(txtSupSc.Text)) * (double.Parse(Supcgst)) / 100).ToString();
                    }
                    else
                    {
                        txtsupigst.Text = ((double.Parse(txtSupSc.Text)) * (double.Parse(Supigst)) / 100).ToString();
                        txtsupcgst.Text = "0";
                        txtsupsgst.Text = "0";
                        //txtsupcgst.Text = ((double.Parse(txtSupSc.Text)) * (double.Parse(Supsgst)) / 100).ToString();
                        // txtsupsgst.Text = ((double.Parse(txtSupSc.Text)) * (double.Parse(Supcgst)) / 100).ToString();
                    }

                }
                else
                {
                    if (SupState == CompState)
                    {
                        double Profit = double.Parse(lblBuyCost.Text) * double.Parse(txtSupSc.Text) / 100;
                        txtsupigst.Text = "0";
                        //  txtsupigst.Text = ((Profit) * (double.Parse(Supigst)) / 100).ToString();
                        txtsupcgst.Text = (((Profit)) * (double.Parse(Supsgst)) / 100).ToString();
                        txtsupsgst.Text = (((Profit)) * (double.Parse(Supcgst)) / 100).ToString();
                    }
                    else
                    {
                        double Profit = double.Parse(lblBuyCost.Text) * double.Parse(txtSupSc.Text) / 100;
                        txtsupigst.Text = ((Profit) * (double.Parse(Supigst)) / 100).ToString();
                        txtsupcgst.Text = "0";
                        txtsupsgst.Text = "0";
                        // txtsupcgst.Text = (((Profit)) * (double.Parse(Supsgst)) / 100).ToString();
                        // txtsupsgst.Text = (((Profit)) * (double.Parse(Supcgst)) / 100).ToString();
                    }
                }

            }
        }
        else
        {
            txtsupigst.Text = "0";
            txtsupcgst.Text = "0";
            txtsupsgst.Text = "0";
        }

        //Client GST
        DataTable dtClntgst = objClntGst.viewData(objClntGst, "show", ddlAgentID.SelectedValue);
        if (dtClntgst.Rows.Count > 0)
        {


            string Clntigst = dtClntgst.Rows[0]["nClntIgst"].ToString();
            string Clntsgst = dtClntgst.Rows[0]["nClntSgst"].ToString();
            string Clntcgst = dtClntgst.Rows[0]["nClntCgst"].ToString();


            if (chkClntTax.Checked == false)
            {
                txtClntCgst.Text = "0";
                txtClntSgst.Text = "0";
                txtClntIgst.Text = "0";
            }
            else
            {

                if (ddlProfitType.SelectedValue == "0")
                {
                    if (ClntState == CompState)
                    {
                        // txtClntIgst.Text = ((double.Parse(txtProfitAmt.Text)) * (double.Parse(Clntigst)) / 100).ToString();
                        txtClntIgst.Text = "0";
                        txtClntCgst.Text = ((double.Parse(txtProfitAmt.Text)) * (double.Parse(Clntsgst)) / 100).ToString();
                        txtClntSgst.Text = ((double.Parse(txtProfitAmt.Text)) * (double.Parse(Clntcgst)) / 100).ToString();
                    }
                    else
                    {
                        txtClntIgst.Text = ((double.Parse(txtProfitAmt.Text)) * (double.Parse(Clntigst)) / 100).ToString();
                        txtClntCgst.Text = "0";
                        txtClntSgst.Text = "0";
                    }
                }
                else
                {
                    double Profit = double.Parse(lblBuyCost.Text) * double.Parse(txtProfitAmt.Text) / 100;
                    if (ClntState == CompState)
                    {

                        // txtClntIgst.Text = ((Profit) * (double.Parse(Clntigst)) / 100).ToString();
                        txtClntCgst.Text = (((Profit)) * (double.Parse(Clntsgst)) / 100).ToString();
                        txtClntSgst.Text = (((Profit)) * (double.Parse(Clntcgst)) / 100).ToString();
                    }
                    else
                    {

                        txtClntIgst.Text = ((Profit) * (double.Parse(Clntigst)) / 100).ToString();
                        txtClntCgst.Text = "0";
                        txtClntSgst.Text = "0";
                    }

                }
            }

        }
        else
        {

            txtClntCgst.Text = "0";
            txtClntSgst.Text = "0";
            txtClntIgst.Text = "0";

        }


        //Refund GST

        //mairgst_Class objclGst = new mairgst_Class();
        DataTable dtrfngst = objClntGst.viewData(objClntGst, "show", ddlAgentID.SelectedValue);
        if (dtrfngst.Rows.Count > 0)
        {


            string Rfnigst = dtrfngst.Rows[0]["nClntIgst"].ToString();
            string Rfnsgst = dtrfngst.Rows[0]["nClntSgst"].ToString();
            string Rfncgst = dtrfngst.Rows[0]["nClntCgst"].ToString();
            if (chkRfnTax.Checked == false)
            {

                txtRfnCGst.Text = "0";
                txtRfnSGst.Text = "0";
                txtRfnIGst.Text = "0";

            }
            else
            {
                if (ClntState == CompState)
                {

                    txtRfnIGst.Text = "0";
                    txtRfnCGst.Text = ((double.Parse(txtRefundAmt.Text)) * (double.Parse(Rfncgst)) / 100).ToString();
                    txtRfnSGst.Text = ((double.Parse(txtRefundAmt.Text)) * (double.Parse(Rfnsgst)) / 100).ToString();
                }
                else
                {
                    txtRfnIGst.Text = ((double.Parse(txtRefundAmt.Text)) * (double.Parse(Rfnigst)) / 100).ToString();
                    txtRfnCGst.Text = "0";
                    txtRfnSGst.Text = "0";
                }
            }

        }
        else
        {
            txtRfnCGst.Text = "0";
            txtRfnSGst.Text = "0";
            txtRfnIGst.Text = "0";
        }
    }
    protected void txtSupSc_TextChanged(object sender, EventArgs e)
    {
        txtProfitAmt_TextChanged(this, e);
        txtSupTds.Focus();
    }
    protected void txtSupTds_TextChanged(object sender, EventArgs e)
    {
        txtProfitAmt_TextChanged(this, e);
        //txtSupTds.Focus();
    }
    protected void txtCost_TextChanged(object sender, EventArgs e)
    {
        txtClntCost.Text = txtCost.Text;
        txtProfitAmt_TextChanged(this, e);
        ddlVisaStatusID.Focus();
    }
    protected void txtClntCost_TextChanged(object sender, EventArgs e)
    {
        txtCost.Text = txtClntCost.Text;
        txtProfitAmt_TextChanged(this, e);
        txtProfitAmt.Focus();
    }
    protected void txtClntTdsAmount_TextChanged(object sender, EventArgs e)
    {
        txtProfitAmt_TextChanged(this, e);
        txtDiscount.Focus();
    }
    protected void txtCourierCharge_TextChanged(object sender, EventArgs e)
    {
        txtProfitAmt_TextChanged(this, e);
        txtOtherCharge.Focus();
    }
    protected void txtOtherCharge_TextChanged(object sender, EventArgs e)
    {
        txtProfitAmt_TextChanged(this, e);
        txtRemarks.Focus();
    }
    protected void txtSupDisc_TextChanged(object sender, EventArgs e)
    {
        txtProfitAmt_TextChanged(this, e);
        txtSupDisc.Focus();
    }
    protected void ddlbookType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlbookType.SelectedValue == "2")
        {
            tblrefund.Visible = true;
            txtdtRfnDate.Text = validation.fillDate();
        }
        else
        {
            tblrefund.Visible = false;
        }
    }
    protected void txtVisaBookingNo_TextChanged(object sender, EventArgs e)
    {
        DataTable dt = objClass.viewData(objClass, "FillDataVisa", txtVisaBookingNo.Text);
        if (dt.Rows.Count > 0)
        {
            Session["eid"] = dt.Rows[0]["nVisaId"].ToString();
            GetFormData();
            GetFormDataDet();
            if (ddlbookType.SelectedValue == "2")
            {
                GetFormDataRefund();
            }
            btnUpdateDet.Visible = true;
            btnPrint.Visible = true;
            btnPaymentHistory.Visible = true;
            btnAdd.Visible = false;

        }
        else
        {
            btnUpdateDet.Visible = false;
            btnPrint.Visible = false;
            btnPaymentHistory.Visible = false;
            btnAdd.Visible = true;
            //   clrfield();
            // clrfieldDet();
        }

    }

    //Refund

    public void paraRefund()
    {
        objRefund.nVisaDetID = Session["Detid"].ToString();
        objRefund.dtRefundDate = validation.dateToText(txtdtRfnDate.Text);
        objRefund.sRefundNo = RefundNo_Generate();
        objRefund.nRefundAmount = txtRefundAmt.Text;
        objRefund.nRfnSupScAmount = txtrfnSC.Text;
        if (chkRfnTax.Checked == true)
        {
            objRefund.bRfnTax = "1";
        }
        else
        {
            objRefund.bRfnTax = "0";
        }
        objRefund.nRfnCGst = txtRfnCGst.Text.Trim();
        objRefund.nRfnSGst = txtRfnSGst.Text.Trim();
        objRefund.nRfnIGst = txtRfnIGst.Text.Trim();

        objRefund.nSupplierRefund = txtBuyCost.Text;
        objRefund.nClientRefund = Math.Abs(double.Parse(txtVisaRate.Text)).ToString();
        objRefund.sRfnRemaks = validation.stringToDBString(txtRfnRemarks.Text.Trim());
    }

    public void clrfieldRefund()
    {
        txtdtRfnDate.Text = validation.fillDate();
        txtRefundAmt.Text = "0";
        txtrfnSC.Text = "0";
        txtRfnRemarks.Text = "";
        Session["Detid"] = "";
    }

    public void GetFormDataRefund()
    {
        DataTable dt = objRefund.viewData(objRefund, "show", Session["Detid"].ToString());
        if (dt.Rows.Count > 0)
        {

            txtdtRfnDate.Text = validation.TextToDate(dt.Rows[0]["dtRefundDate"].ToString());
            txtRefundAmt.Text = dt.Rows[0]["nRefundAmount"].ToString();
            txtrfnSC.Text = dt.Rows[0]["nRfnSupScAmount"].ToString();
            if (dt.Rows[0]["bRfnTax"].ToString() == "1")
            {
                chkRfnTax.Checked = true;
            }
            else
            {
                chkRfnTax.Checked = false;
            }
            txtRfnCGst.Text = dt.Rows[0]["nRfnCGst"].ToString();
            txtRfnSGst.Text = dt.Rows[0]["nRfnSGst"].ToString();
            txtRfnIGst.Text = dt.Rows[0]["nRfnIGst"].ToString();
            txtBuyCost.Text = dt.Rows[0]["nSupplierRefund"].ToString();
            txtVisaRate.Text = dt.Rows[0]["nClientRefund"].ToString();
            txtRfnRemarks.Text = dt.Rows[0]["sRfnRemaks"].ToString();
        }
    }

    public void RefundSave()
    {
        try
        {
            paraRefund();
            DataTable dt = objRefund.viewData(objRefund, "show", Session["Detid"].ToString());

            if (dt.Rows.Count > 0)
            {


                objRefund.nVisaRefundID = dt.Rows[0][0].ToString();
                var abc = objRefund.User_Operation(objRefund, "edit");
            }
            else
            {
                var abc = objRefund.User_Operation(objRefund, "add");
            }
        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, lblmsg);
        }

    }

    protected void txtrfnSC_TextChanged(object sender, EventArgs e)
    {
        try
        {
            txtProfitAmt_TextChanged(this, e);
            txtRfnRemarks.Focus();
        }
        catch
        {

        }
        finally
        {

        }
    }
    protected void txtRefundAmt_TextChanged(object sender, EventArgs e)
    {
        try
        {
            txtProfitAmt_TextChanged(this, e);
            txtrfnSC.Focus();

        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, lblmsg);
        }
        finally
        {

        }
    }
    protected void chkRfnTax_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            txtProfitAmt_TextChanged(this, e);
            txtRefundAmt.Focus();

        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, lblmsg);
        }
        finally
        {

        }
    }

    public void RefundGst()
    {

    }

    public string RefundNo_Generate()
    {
        string RefundNo;
        DataTable dtRefund = objRefund.viewData(objRefund, "show", Session["Detid"].ToString());
        if (dtRefund.Rows.Count > 0)
        {
            RefundNo = dtRefund.Rows[0]["sRefundNo"].ToString();
        }
        else
        {
            DataTable dt = objRefund.viewData(objRefund, "MaxRefundNo", validation.dateToText(txtdtRfnDate.Text));
            if (dt.Rows.Count > 0)
            {
                RefundNo = dt.Rows[0][0].ToString();
            }
            else
            {
                RefundNo = "";
            }
        }
        return RefundNo;
    }



    //Search

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
           
            SearchPara();
            displaySearchGrid();
            txtSdtBooking.Text = "";

        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, lblmsg);
        }
    }
    public void displaySearchGrid()
    {
        try
        {
            objClassDet.FillGrid(objClassDet, GridView1, "ShowGrid", "");
        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, lblmsg);
        }
    }

    public void SearchPara()
    {
        objClassDet.sReference1 = ddlInvoiceNo.SelectedValue;
        objClassDet.sCustomerName = ddlSClient.SelectedValue;
        objClassDet.sPassportNo = ddlSSup.SelectedValue;
        objClassDet.sNationality = ddlSLoc.SelectedValue;
        objClassDet.dtVisaExpiryDate = ddlExpiry.SelectedValue;
        objClassDet.dtIssue ="";
        objClassDet.dtDOB = validation.dateToText(txtSdtBooking.Text);
    }


    //Payment Against Invoice
    protected void btngdPay_Click(object sender, EventArgs e)
    {
        PnlPayment.Visible = true;
        tblmain.Visible = false;
        tblDet.Visible = false;
        tblGrd.Visible = false;
        tblGridDet.Visible = false;

        Session["eid"] = "";
        LinkButton thisbtn = (LinkButton)sender;
        GridViewRow thisgrdR = (GridViewRow)thisbtn.Parent.Parent;
        int row = thisgrdR.RowIndex;
        Label VisaID = (Label)GridView1.Rows[row].Cells[0].FindControl("lblID");
        Session["eid"] = VisaID.Text;
        Label AgentID = (Label)GridView1.Rows[row].Cells[0].FindControl("lblAgentID");
        lblAgent.Text = AgentID.Text;
        Label nBalance = (Label)GridView1.Rows[row].Cells[0].FindControl("lblBalance");
        txtPayBalance.Text = nBalance.Text;
        txtdtpayment.Text = validation.fillDate();

        Label InvNo = (Label)GridView1.Rows[row].Cells[0].FindControl("lblInvoiceNo");
        txtPayInv.Text = InvNo.Text;
        Label InvDate = (Label)GridView1.Rows[row].Cells[0].FindControl("lblInvoiceDate");
        lblInvoiceDate.Text = InvDate.Text;

        txtPayRemarks.Text = "Visa payment for invoice no.: " + InvNo.Text;
        DisplayPaymentGrid();
        PayVoucher_Generate();

    }

    protected void btnPaymentHistory_Click(object sender, EventArgs e)
    {
        PnlPayment.Visible = true;
        tblmain.Visible = false;
        tblDet.Visible = false;
        tblGrd.Visible = false;
        tblGridDet.Visible = false;


        lblAgent.Text = ddlAgentID.SelectedValue;
        txtPayRemarks.Text = "Visa payment for invoice no.: " + txtVisaBookingNo.Text;
        txtPayInv.Text = txtVisaBookingNo.Text;
        lblInvoiceDate.Text = validation.dateToText(txttBooking.Text).ToString();
        GetBalance();
        txtdtpayment.Text = validation.fillDate();

        DisplayPaymentGrid();
        PayVoucher_Generate();
    }

    protected void GridPay_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GridPay.PageIndex = e.NewPageIndex;
            DisplayPaymentGrid();
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message.ToString();
        }
        finally
        {
        }

    }
    public void DisplayPaymentGrid()
    {
        objVisaPay.sPayfor = "Visa";
        objVisaPay.FillGrid(objVisaPay, GridPay, "ShowPaymentsModule", Session["eid"].ToString());
    }
    public void paymentPara()
    {
        //Main Table
      //  objVisaPay.nPaymentReceiveID = Session["eid"].ToString();
        objVisaPay.nPaymentModeID = ddlPayVoucherType.SelectedValue;
        objVisaPay.nCashAccountID = ddlPaymentAccount.SelectedValue;
        objVisaPay.dtPayment = validation.dateToText(txtdtpayment.Text);
        objVisaPay.sVoucherNo = txtPayVoucherNo.Text;
        objVisaPay.nTotAmount = txtPayAmount.Text;
        objVisaPay.nAgentID = lblAgent.Text;
        objVisaPay.sRemarks = txtPayRemarks.Text;
        objVisaPay.sPayfor = "Visa";

        //Detail Table
        objVisaPayDet.nInvoiceID = Session["eid"].ToString();
        objVisaPayDet.sInvoiceNo = txtPayInv.Text;
        objVisaPayDet.dtInvoiceDate = lblInvoiceDate.Text;
        objVisaPayDet.nAmount = txtPayAmount.Text; ;

        objVisaPayDet.sRemarks = txtPayRemarks.Text;
       
    }
    public void GetPaidDetails()
    {
        string GrandTotal = ""; string TotalPaid = "";
        DataTable dtMain = new DataTable();
        dtMain = objClass.viewData(objClass, "ShowGrid", Session["eid"].ToString());
        if (dtMain.Rows.Count > 0)
        {
            GrandTotal = dtMain.Rows[0]["nSellingRate"].ToString();
            TotalPaid = dtMain.Rows[0]["nPaidAmount"].ToString();
        }

        //DataTable dtPaid = objClass.viewData(objClass, "ShowGrid", Session["eid"].ToString());
        //if (dtPaid.Rows.Count > 0)
        //{
        //    TotalPaid = dtPaid.Rows[0]["nPaidAmount"].ToString();
        //}

        //Adding value for bPaid
        if (TotalPaid.ToString() == "" || TotalPaid.ToString() == "0")
        {
            objClass.bPaid = "0";   //UnPaid
        }
        if (GrandTotal.ToString() == TotalPaid.ToString() || double.Parse(TotalPaid) > double.Parse(GrandTotal))
        {
            objClass.bPaid = "1";   //Paid
        }
        else if (int.Parse(TotalPaid) > 0 && double.Parse(TotalPaid) < double.Parse(GrandTotal))
        {
            objClass.bPaid = "2";   //Partial Paid
        }
        else
        {
            objClass.bPaid = "3";   //Exta Paid
        }
    }
    public void Payclrfield()
    {
        ddlPayVoucherType.SelectedValue = "0";

        txtPayAmount.Text = "";
        ddlAgentID.SelectedValue = "0";
        ddlPaymentAccount.SelectedValue = "0";
        // txtPayRemarks.Text = "";


    }
    public void GetPaymentData()
    {
        DataTable dt = objVisaPayDet.viewData(objVisaPayDet, "GetDataTravel", Session["PayDetid"].ToString());
        if (dt.Rows.Count > 0)
        {
            // ddlVisaID.SelectedValue = dt.Rows[0][1].ToString();
            ddlPayVoucherType.SelectedValue = dt.Rows[0]["nPaymentModeID"].ToString();
            EventArgs e = new EventArgs();
            ddlPayVoucherType_SelectedIndexChanged(this, e);
            ddlPaymentAccount.SelectedValue = dt.Rows[0]["nCashAccountID"].ToString();
            txtdtpayment.Text = validation.TextToDate(dt.Rows[0]["dtPayment"].ToString());
            txtPayVoucherNo.Text = dt.Rows[0]["sVoucherNo"].ToString();
            txtPayAmount.Text = dt.Rows[0]["nAmount"].ToString();
            lblAgent.Text = dt.Rows[0]["nAgentID"].ToString();
            
            txtPayRemarks.Text = dt.Rows[0]["sRemarks"].ToString();
           

        }
    }
    protected void ddlPayVoucherType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPayVoucherType.SelectedValue == "1")
        {
            objAccount.ddlOperation(objAccount, "ddlAccType", ddlPayVoucherType.SelectedValue, ddlPaymentAccount);
        }
        else if (ddlPayVoucherType.SelectedValue == "2")
        {
            objAccount.ddlOperation(objAccount, "ddlAccType", ddlPayVoucherType.SelectedValue, ddlPaymentAccount);

        }
        else
        {
            objAccount.ddlOperation(objAccount, "ddlAccType", "2", ddlPaymentAccount);

        }
    }
    protected void btnPayment_Click(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        if (Session["tvisa"].ToString() == ViewState["tvisa"].ToString())
        {
            paymentPara();

            if (Session["Payid"] == null || Session["Payid"] == "")
            {
                var abc = objVisaPay.User_Operation(objVisaPay, "add");
                var strArr = abc.Split(',');
                if (strArr[0] == "1")
                {
                    string PayID = strArr[2].ToString();
                    Session["Payid"] = PayID;
                    objVisaPayDet.nPaymentReceiveID = PayID;
                    var abc1 = objVisaPayDet.User_Operation(objVisaPayDet, "add");
                }
                valobj.showMsg(abc, lblmsg);


            }
            else
            {
                //Upodate Main Table
                objVisaPay.nPaymentReceiveID = Session["Payid"].ToString();
                var abc = objVisaPay.User_Operation(objVisaPay, "edit");

                //Upodate Detail Table
                objVisaPayDet.nPaymentReceiveDetID = Session["PayDetid"].ToString();
                objVisaPayDet.nPaymentReceiveID = Session["Payid"].ToString();
                var abc1 = objVisaPayDet.User_Operation(objVisaPayDet, "edit");

                valobj.showMsg(abc, lblmsg);
                Session["Payid"] = "";
                Session["PayDetid"] = "";

            }
            GetPaidDetails();
            objClass.nVisaId = Session["eid"].ToString();
            var xyz = objClass.User_Operation(objClass, "bPaidEdit");

            GetBalance();
            Payclrfield();
            DisplayPaymentGrid();
            PayVoucher_Generate();

        }



        string aa = Server.UrlEncode(System.DateTime.Now.ToString());
        Session["tvisa"] = aa;

    }

    protected void btngdPayEdit_Click1(object sender, EventArgs e)
    {
        Session["Payid"] = "";
        LinkButton thisbtn = (LinkButton)sender;
        GridViewRow thisgrdR = (GridViewRow)thisbtn.Parent.Parent;
        int row = thisgrdR.RowIndex;
        Label ID = (Label)GridPay.Rows[row].Cells[0].FindControl("lblPayID");
        Session["Payid"] = ID.Text;
        Label IDDet = (Label)GridPay.Rows[row].Cells[0].FindControl("lblPaydETID");
        Session["PayDetid"] = IDDet.Text;


        GetPaymentData();
        txtPayBalance.Text = (double.Parse(txtPayBalance.Text) + double.Parse(txtPayAmount.Text)).ToString();
        DisplayPaymentGrid();
        lblmsg.Text = "";

    }
    protected void btngdPayDelete_Click(object sender, EventArgs e)
    {
        try
        {
            Session["Payid"] = "";
            LinkButton thisbtn = (LinkButton)sender;
            GridViewRow thisgrdR = (GridViewRow)thisbtn.Parent.Parent;
            int row = thisgrdR.RowIndex;
            Label ID = (Label)GridPay.Rows[row].Cells[0].FindControl("lblPayID");
            Session["Payid"] = ID.Text;

            DeletePaymentRecord();
            GetBalance();
        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, "FAIL", lblmsg);
        }
    }
    public void DeletePaymentRecord()
    {
        objVisaPay.nPaymentReceiveID = Session["Payid"].ToString();
        var vres = objVisaPay.User_Operation(objVisaPay, "DeActive");
        valobj.showMsg(vres, lblmsg);
        DisplayPaymentGrid();
        PayVoucher_Generate();
        Session["Payid"] = "";
    }

    public void GetBalance()
    {
        if (Session["eid"] == null)
        {
            Session["eid"] = "0";
        }
        DataTable dt = objClass.viewData(objClass, "ShowGrid", Session["eid"].ToString());
        if (dt.Rows.Count > 0)
        {
            txtPayBalance.Text = dt.Rows[0]["nBalance"].ToString();
        }
        else
        {
            txtPayBalance.Text = "0";
        }
    }



    protected void txtdtpayment_TextChanged(object sender, EventArgs e)
    {
        PayVoucher_Generate();
    }
    public void PayVoucher_Generate()
    {
        DataTable dt = objVisaPay.viewData(objVisaPay, "PVN", validation.dateToText(txtdtpayment.Text));
        if (dt.Rows.Count > 0)
        {
            txtPayVoucherNo.Text = dt.Rows[0][0].ToString();
        }
    }
    protected void btngdPayPrintDet_Click(object sender, EventArgs e)
    {
        try
        {
            Session["Payid"] = "";
            LinkButton thisbtn = (LinkButton)sender;
            GridViewRow thisgrdR = (GridViewRow)thisbtn.Parent.Parent;
            int row = thisgrdR.RowIndex;
            Label ID = (Label)GridPay.Rows[row].Cells[0].FindControl("lblPayID");
            Session["Payid"] = ID.Text;
            Label IDDet = (Label)GridPay.Rows[row].Cells[0].FindControl("lblPaydETID");
            Session["PayDetid"] = IDDet.Text;

            //if (lblType.Text == "Booking")
            //{
            //    Response.Redirect("rptVisaInvoice.aspx?id=" + ID.Text);
            //}
            //else
            //{
            //    Response.Redirect("rptVisaRefund_Invoice.aspx?id=" + ID.Text);
            //}
            Response.Redirect("PaymentReceipt/rptpay_receipt_inv.aspx?Detid=" + IDDet.Text + "&sPayfor=Visa");
        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, "FAIL", lblmsg);
        }
    }
    protected void btnPaymentReceipt_Click(object sender, EventArgs e)
    {
        Response.Redirect("PaymentReceipt/rptpay_receipt_inv.aspx?id=" + Session["eid"].ToString() + "&sPayfor=Visa");
    }

    protected void ddlSupplier_SelectedIndexChanged(object sender, EventArgs e)
    {
        objClass.ddlOperation(objClass, "ddlCustomer", ddlSupplier.SelectedValue, ddlAgentID);
    }

}
