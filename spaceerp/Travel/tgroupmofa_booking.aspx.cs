using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Transcation_mofa_booking : System.Web.UI.Page
{
    tgroupmofa_Class objClass = new tgroupmofa_Class();
    tgroupmofadet_Class objClassDet = new tgroupmofadet_Class();
    tpayments_receive_Class objMofaPay = new tpayments_receive_Class();
    tpayments_receivedet_Class objMofaPayDet = new tpayments_receivedet_Class();
    tgroupmofa_repeater_Class objMofaRepeater = new tgroupmofa_repeater_Class();
    //  magent_Class objAgent = new magent_Class();
    mCountry_Class objCountry = new mCountry_Class();
    //  mcompany_Class objcompany = new mcompany_Class();

    // mlocation_Class objBranch = new mlocation_Class();

    // tchartof_account_Class objAccount = new tchartof_account_Class();
    mmain_account_Class objAccount = new mmain_account_Class();
    msupgst_Class objSupGst = new msupgst_Class();
    mclientgst_Class objClntGst = new mclientgst_Class();
    //  tmofarefund_Class objRefund = new tmofarefund_Class();
    msupplier_Class objSupplier = new msupplier_Class();
    mclient_Class objClient = new mclient_Class();
    mbranches_Class objBranch = new mbranches_Class();
    validation valobj = new validation();
    string cond, max_id, Booking_No;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                //Fillddl.FillPageddl(ddlPageSize);
                string aa = Server.UrlEncode(System.DateTime.Now.ToString());
                Session["tMofa_booking"] = aa;
                objAccount.ddlOperation(objAccount, "ddlCustomer", "", ddlAgentID);
                objBranch.ddlOperation(objBranch, "Showddl", "", ddlLocationID);
                objAccount.ddlOperation(objAccount, "ddlVendor", "", ddlSupplier);
                //  objCountry.ddlOperation(objCountry, "show", "", ddlNationalityID);
                //     objCountry.ddlOperation(objCountry, "show", "", ddlCountry);
                tblmain.Visible = true;
                tblDet.Visible = true;
                tblGridDet.Visible = false;
                tblGrd.Visible = false;
                PnlPayment.Visible = false;
               // displayGrid();
                btnVisible();
                txtdtMofaBooking.Text = validation.fillDate();
                Booking_Generate();

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
                    lblpgs.Visible = false;
                }
                else
                {
                    ddlPageSizeDet.Visible = true;
                    lblpgs.Visible = true;
                }
                //Repeater Fee True False
                chkRepeaterclnt_CheckedChanged(this, e);
                chkRepeatersup_CheckedChanged(this, e);
                var ID = Request.QueryString["ID"];
                if (!string.IsNullOrEmpty(ID))
                {
                    Session["eid"] = ID;

                    btnAdd.Visible = false;
                    btnPrint.Visible = true;
                    btnPaymentHistory.Visible = true;
                    //btnUpdate.Visible = true;
                    //btnDelete.Visible = true;
                    GetFormData();
                    GetFormDataDet();

                    GetFormDataRepeater();


                    lblmsg.Text = "";
                    tblmain.Visible = true;
                    tblGrd.Visible = false;
                    //  clrfieldDet();
                    DetButtonVisible();
                    DisableData();
                    tblGridDet.Visible = true;
                    displayGridDet();
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
        ViewState["tMofa_booking"] = Session["tMofa_booking"];
    }

    public void Booking_Generate()
    {
        DataTable dt = objClass.viewData(objClass, "MaxBookNo", validation.dateToText(txtdtMofaBooking.Text));
        if (dt.Rows.Count > 0)
        {
            txtMofaBookingNo.Text = dt.Rows[0][0].ToString();
        }
    }
    public void para()
    {

        objClass.sGMofaBookingNo = validation.stringToDBString(txtMofaBookingNo.Text.Trim());
        objClass.nSupplierID = ddlSupplier.SelectedValue;
        objClass.dtBookingDate = validation.dateToText(txtdtMofaBooking.Text.Trim());
        objClass.nClientID = ddlAgentID.SelectedValue;


        objClass.nLocationID = ddlLocationID.SelectedValue;
        objClass.nBookTypeID = ddlbookType.SelectedValue;
        
        objClass.nBuyingCost = validation.stringToDBString(txtSupplierCost.Text.Trim());
        objClass.nSellingCost = validation.stringToDBString(txtClientCost.Text.Trim());

        objClass.bPaid = "0";  //Un paid 
        //  objClass.nBookTypeID = ddlbookType.SelectedValue;

        objClass.sRemarks = validation.stringToDBString(txtRemarks.Text.Trim());
       
    }

    public void clrfield()
    {
        txtMofaBookingNo.Text = "";
        txtdtMofaBooking.Text = "";
        ddlAgentID.SelectedValue = "0";
        ddlLocationID.SelectedValue = "0";
        ddlSupplier.SelectedValue = "0";

        ddlbookType.SelectedValue = "0";
        txtGroupName.Text = "";
        txtGroupCode.Text = "";
        txtDuration.Text = "";
        txtVisaValidity.Text = "";

        txtSupplierCost.Text = "";
        txtClientCost.Text = "";
        txtRemarks.Text = "";
        Session["eid"] = "";
    }

    public void GetFormData()
    {
        DataTable dt = objClass.viewData(objClass, "show", Session["eid"].ToString());
        if (dt.Rows.Count > 0)
        {
            txtMofaBookingNo.Text = dt.Rows[0]["sGMofaBookingNo"].ToString();
            txtdtMofaBooking.Text = validation.TextToDate(dt.Rows[0]["dtBookingDate"].ToString());
            ddlSupplier.SelectedValue = dt.Rows[0]["nSupplierID"].ToString();
            ddlAgentID.SelectedValue = dt.Rows[0]["nClientID"].ToString();
            ddlLocationID.SelectedValue = dt.Rows[0]["nLocationID"].ToString();
            ddlbookType.SelectedValue = dt.Rows[0]["nBookTypeID"].ToString();
          
         
          //  txtRemarks.Text = dt.Rows[0][16].ToString();
            


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

    public void DisableData()
    {
        //txtdtMofaBooking.Enabled = false;

        //ddlAgentID.Enabled = false;
        //ddlLocationID.Enabled = false;
        //ddlAgentID.Enabled = false;
    }
    public void VisibleData()
    {
        txtdtMofaBooking.Enabled = true;


        ddlAgentID.Enabled = true;
        ddlLocationID.Enabled = true;
        ddlAgentID.Enabled = true;
    }

    public void displayGrid()
    {
        try
        {
            //DataTable dtMain = objClass.viewData(objClass, "ShowGrid", "");
            //if (dtMain.Rows.Count > 0)
            //{
            //    DataTable dtSum = objClass.viewData(objClass, "ShowGridCalulation", "");

            //    DataTable dtresult = new DataTable();
            //    dtresult = dtMain.Clone();
            //    dtresult.Columns.Add("nSupplierCost1");
            //    dtresult.Columns.Add("nClientCost1");
            //    string nSupplierCost1, nClientCost;
            //    for (int i = 0; i < dtMain.Rows.Count; i++)
            //    {
            //        DataRow[] result = dtSum.Select("nGroupMofaID =" + dtMain.Rows[i][0].ToString());
            //        foreach (DataRow row in result)
            //        {
            //             nSupplierCost1 = row.Field<string>("nSupplierCost");

            //             nClientCost = row["nClientCost"].ToString();
            //        }
            //        dtresult.Rows.Add(
            //            dtMain.Rows[i][0],
            //            nSupplierCost1.ToString(),
            //            nClientCost.ToString()

            //            );
            //    }


            //}
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
        objClass.nGroupMofaID = Session["eid"].ToString();
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
            if (Session["tMofa_booking"].ToString() == ViewState["tMofa_booking"].ToString())
            {
                para();
                var abc = objClass.User_Operation(objClass, "add");

                var strArr = abc.Split(',');
                if (strArr[0] == "1")
                {
                    string MofaID = strArr[2].ToString();
                    Session["eid"] = MofaID;

                    paraDet();
                    var xyz = objClassDet.User_Operation(objClassDet, "add");

                    if (chkRepeaterclnt.Checked)
                    {
                        RepeaterSave();
                    }
                    tblmain.Visible = true;
                    tblDet.Visible = true;
                    tblGridDet.Visible = true;
                    tblGrd.Visible = false;
                    btnPaymentHistory.Visible = true;
                    displayGridDet();
                    btnAdd.Visible = false;
                    btnAddDet.Visible = true;
                    btnUpdateDet.Visible = false;
                    btnPrint.Visible = true;
                    //clrfieldDet();
                    DisableData();
                }
                //displayGrid();

                valobj.showMsg(abc, lblmsg);
                string aa = Server.UrlEncode(System.DateTime.Now.ToString());
                Session["tMofa_booking"] = aa;
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

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        try
        {
            objClass.nGroupMofaID = Session["eid"].ToString();
            //if (ddlbookType.SelectedValue == "1")
            //{
            //    Response.Redirect("rptmofa_invoice.aspx?id=" + Session["eid"].ToString());
            //}
            //else
            //{

            //    Response.Redirect("rptmofarefund_invoice.aspx?id=" + Session["eid"].ToString());
            //}
            Response.Redirect("Invoices/rptgroupmofa_invoice.aspx?id=" + Session["eid"].ToString());
        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, "FAIL", lblmsg);
        }
        finally
        {
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

            Label lblType = (Label)GridView1.Rows[row].Cells[0].FindControl("lblBookType");
            //if (lblType.Text == "Booking")
            //{
            //    Response.Redirect("rptmofa_invoice.aspx?id=" + Session["eid"].ToString());
            //}
            //else
            //{

            //    Response.Redirect("rptmofarefund_invoice.aspx?id=" + Session["eid"].ToString());
            //}
            Response.Redirect("Invoices/rptgroupmofa_invoice.aspx?id=" + Session["eid"].ToString());

        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, "FAIL", lblmsg);
        }
    }

    protected void btngdPrintdet_Click(object sender, EventArgs e)
    {
        Session["Detid"] = "";
        LinkButton thisbtn = (LinkButton)sender;
        GridViewRow thisgrdR = (GridViewRow)thisbtn.Parent.Parent;
        int row = thisgrdR.RowIndex;
        Label ID = (Label)GridView2.Rows[row].Cells[0].FindControl("lblDetID");
        Session["Detid"] = ID.Text;

        Label lblType = (Label)GridView2.Rows[row].Cells[0].FindControl("lblBookType");
        if (lblType.Text == "Booking")
        {
            Response.Redirect("Invoices/rptgroupmofa_invoice.aspx?Detid=" + ID.Text);
        }
        else
        {

          //  Response.Redirect("Invoices/rptmofa_refund_invoice.aspx?Detid=" + ID.Text);
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
            btnPrint.Visible = true;
            btnPaymentHistory.Visible = true;
            //btnUpdate.Visible = true;
            //btnDelete.Visible = true;
            GetFormData();
            GetFormDataDet();

            GetFormDataRepeater();


            lblmsg.Text = "";
            tblmain.Visible = true;
            tblGrd.Visible = false;
            //  clrfieldDet();
            DetButtonVisible();
            DisableData();
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

    // Ticketing Detail Table 
    public void paraDet()
    {
        double SupSC = 0; double ClntSC = 0; double ClntSC2 = 0;
        objClassDet.nGroupMofaID = Session["eid"].ToString();
        objClassDet.sGroupName = validation.stringToDBString(txtGroupName.Text.Trim());
        objClassDet.sGroupCode = validation.stringToDBString(txtGroupCode.Text.Trim());
        objClassDet.sDuration = validation.stringToDBString(txtDuration.Text.Trim());
        objClassDet.sVisaValidity = validation.stringToDBString(txtVisaValidity.Text.Trim());
        objClassDet.sVisaValidity = validation.stringToDBString(txtRemarks.Text.Trim());
        if (chkRepeaterclnt.Checked)
        {
            objClassDet.bRepeater = "1";

        }
        else
        {
            objClassDet.bRepeater = "0";
        }
        objClassDet.nQuantity = validation.stringToDBString(txtClntQty.Text.Trim());
        objClassDet.nMofaCost = validation.stringToDBString(txtclntCost.Text.Trim());
        objClassDet.nMofaCostTotal = validation.stringToDBString(lblMofaCostTotal.Text.Trim());
        //objClassDet.nNationalityID = ddlNationalityID.SelectedValue;
        //objClassDet.dtDOBDate = validation.dateToText(txtdtDOBDate.Text.Trim());
        //objClassDet.sAge = validation.stringToDBString(txtAge.Text.Trim());
        //objClassDet.sGender = validation.stringToDBString(ddlGender.SelectedValue);
        //objClassDet.sPassportNo = validation.stringToDBString(txtPassportNo.Text.Trim());
        //objClassDet.dtExpityDate = validation.dateToText(txtdtExpityDate.Text.Trim());
        //objClassDet.sPackage = validation.stringToDBString(txtPackage.Text.Trim());
        //       objClassDet.dtIssueDate = validation.dateToText(txtdtIssueDate.Text.Trim());
        //  objClassDet.sMuhram = validation.stringToDBString(txtMuhram.Text.Trim());
        // objClassDet.sRelation = validation.stringToDBString(txtRelation.Text.Trim());
        //   objClassDet.sPrevNationality = validation.stringToDBString(txtPrevNationality.Text.Trim());
        //   objClassDet.sAuthority = validation.stringToDBString(txtAuthority.Text.Trim());
        //objClassDet.sNationalIDNo = validation.stringToDBString(txtNationalIDNo.Text.Trim());
        //objClassDet.sJob = validation.stringToDBString(txtJob.Text.Trim());
        //objClassDet.sAddress = validation.stringToDBString(txtAddress.Text.Trim());
        //objClassDet.sBirthPlace = validation.stringToDBString(txtBirthPlace.Text.Trim());

        objClassDet.nSupSCType = ddlSupScType.SelectedValue;
        if (ddlSupScType.SelectedValue == "0")
        {
            objClassDet.nSupSCPercent = "0";
            objClassDet.nSupSCAmount = txtSupSc.Text.Trim();
            SupSC = double.Parse(txtSupSc.Text.Trim());
        }
        else
        {
            objClassDet.nSupSCPercent = txtSupSc.Text.Trim();
            SupSC = double.Parse(txtBasicFare.Text) * double.Parse(txtSupSc.Text) / 100;
            objClassDet.nSupSCAmount = (SupSC).ToString();
        }
        objClassDet.nSupSCAmountTotal = validation.stringToDBString(txtSupScTot.Text.Trim());

        if (ddlSupTds.SelectedValue == "0")
        {
            objClassDet.nSupTDSPercent = "0";
            objClassDet.nSupTDSAmount = txtSupTds.Text.Trim();
        }
        else
        {
            objClassDet.nSupTDSPercent = txtSupSc.Text.Trim();
            double SupTDS = (SupSC) * double.Parse(txtSupTds.Text) / 100;
            objClassDet.nSupTDSAmount = (SupTDS).ToString();
        }
        objClassDet.nSupOtrTax = txtOtherTax.Text.Trim();
        objClassDet.nSupDiscount = txtSupDiscount.Text.Trim();
        if (chkSupTax.Checked)
        {
            objClassDet.bSupTax = "1";
        }
        else
        {
            objClassDet.bSupTax = "0";
        }
        objClassDet.nSupCGST = lblsupcgst.Text.Trim();
        objClassDet.nSupSGST = lblsupsgst.Text.Trim();
        objClassDet.nSupIGST = lblsupigst.Text.Trim();
        objClassDet.nSupCGSTTotal = txtsupcgst.Text.Trim();
        objClassDet.nSupSGSTTotal = txtsupsgst.Text.Trim();
        objClassDet.nSupIGSTTotal = txtsupigst.Text.Trim();
        objClassDet.nSupTDSType = ddlSupTds.SelectedValue;

        objClassDet.nSupplierCost = lblBuyCost.Text.Trim();

        objClassDet.nClntSCType = ddlProfitType.SelectedValue;
        if (ddlProfitType.SelectedValue == "0")
        {
            objClassDet.nClntSCPercent = "0";
            objClassDet.nClntSCAmount = txtProfitAmt.Text.Trim();
            ClntSC = double.Parse(txtProfitAmt.Text.Trim());
        }
        else
        {
            objClassDet.nClntSCPercent = txtProfitAmt.Text.Trim();
            ClntSC = double.Parse(lblBuyCost.Text) * double.Parse(txtProfitAmt.Text) / 100;
            objClassDet.nClntSCAmount = (ClntSC).ToString();
        }
        objClassDet.nClntSCAmountTotal = txtClntScTot.Text.Trim();
        objClassDet.nClntTDSType = ddlClntTds.SelectedValue;
        if (ddlClntTds.SelectedValue == "0")
        {
            objClassDet.nClntTDSPercent = "0";
            objClassDet.nClntTDSAmount = txtClntTds.Text.Trim();
        }
        else
        {
            objClassDet.nClntTDSPercent = txtClntTds.Text.Trim();
            double ClntTDS = (ClntSC) * double.Parse(txtClntTds.Text) / 100;
            objClassDet.nClntTDSAmount = (ClntTDS).ToString();
        }
        objClassDet.nClntOtrTax = txtOtherchrg.Text.Trim();
        objClassDet.nClntDiscount = txtDiscount.Text.Trim();
        objClassDet.nCourierfee = txtCourierCharge.Text.Trim();
        if (chkClntTax.Checked)
        {
            objClassDet.bClntTax = "1";
        }
        else
        {
            objClassDet.bClntTax = "0";
        }
        objClassDet.nClntCGST = lblClntCgst.Text.Trim();
        objClassDet.nClntSGST = lblClntSgst.Text.Trim();
        objClassDet.nClntIGST = lblClntIgst.Text.Trim();
        objClassDet.nClntCGSTTotal = txtClntCgst.Text.Trim();
        objClassDet.nClntSGSTTotal = txtClntSgst.Text.Trim();
        objClassDet.nClntIGSTTotal = txtClntIgst.Text.Trim();
        objClassDet.nClientCost = lblSelleing.Text.Trim();



        //if (ddlProfitType.SelectedValue == "0")
        //{
        //    objClassDet.nClntSc2Percent = "0";
        //    objClassDet.nClntSc2Amount = txtProfitAmt2.Text.Trim();
        //}
        //else
        //{
        //    objClassDet.nClntSc2Percent = txtProfitAmt2.Text.Trim();
        //    ClntSC2 = double.Parse(lblBuyCost.Text) * double.Parse(txtProfitAmt2.Text) / 100;
        //    objClassDet.nClntSc2Amount = (ClntSC2).ToString();
        //}


        //   objClassDet.sMutamarNo = validation.stringToDBString(txtMutamarNo.Text.Trim());
        //  objClassDet.sMofaNo = validation.stringToDBString(txtMofaNo.Text.Trim());
        //     objClassDet.nCountryID = validation.stringToDBString(ddlCountry.SelectedValue.Trim());
        //  objClassDet.sDependant = validation.stringToDBString(txtDependant.Text.Trim());
        //    objClassDet.sSponsorNo = validation.stringToDBString(txtSpnsrNo.Text.Trim());
        //   objClassDet.sDuration = validation.stringToDBString(txtDuration.Text.Trim());
        //   objClassDet.sVisaValiditry = validation.stringToDBString(txtValidity.Text.Trim());
    }

    public void clrfieldDet()
    {

        txtBasicFare.Text = "";
        txtOtherTax.Text = "";
        //  txtSupComm.Text = "";
        ddlSupScType.SelectedValue = "0";
        txtSupSc.Text = "";
        ddlSupTds.SelectedValue = "0";
        txtSupTds.Text = "";

        txtsupcgst.Text = "";
        txtsupsgst.Text = "";
        txtsupigst.Text = "";
        txtSupplierCost.Text = "";
        lblBuyCost.Text = "";
        ddlProfitType.SelectedValue = "0";
        txtProfitAmt.Text = "";
        //ddlClntTds.SelectedValue = "0";
        //txtClntTds.Text = "";
        //txtDiscount.Text = "";
        txtClntCgst.Text = "";
        txtClntSgst.Text = "";
        txtClntIgst.Text = "";
        txtClientCost.Text = "";
        lblSelleing.Text = "";
        txtRemarks.Text = "";

        //  txtProfitAmt2.Text = "";
        txtOtherchrg.Text = "";
        txtCourierCharge.Text = "";
        //  txtMutamarNo.Text = "";
        //txtMofaNo.Text = "";
        //ddlCountry.SelectedValue = "0";
        ////    txtDependant.Text = "";
        ////      txtSpnsrNo.Text = "";
        //txtDuration.Text = "";
        //txtValidity.Text = "";
        ddlbookType.SelectedValue = "0";
        txtSupRepeaterFee.Text = "";
        //     txtclntRepeaterFee.Text = "";
        txtSupDiscount.Text = "";
        Session["Detid"] = "";
    }
    public void DetButtonVisible()
    {
        tblDet.Visible = true;
        tblGridDet.Visible = false;
        btnAdd.Visible = false;
        btnAddDet.Visible = true;
        btnUpdateDet.Visible = false;
        //btnDeleteDet.Visible = false;
        //clrfieldDet();
    }

    public void GetFormDataDet()
    {
        DataTable dt = objClassDet.viewData(objClassDet, "show", Session["Detid"].ToString());
        if (dt.Rows.Count > 0)
        {
            Session["Detid"] = dt.Rows[0]["nGroupMofaDetID"].ToString();
            txtGroupName.Text = dt.Rows[0]["sGroupName"].ToString();
            txtGroupCode.Text = dt.Rows[0]["sGroupCode"].ToString();
            txtDuration.Text = dt.Rows[0]["sDuration"].ToString();
            txtVisaValidity.Text = dt.Rows[0]["sVisaValidity"].ToString();
            txtRemarks.Text = dt.Rows[0]["sRemarks"].ToString();
            if (dt.Rows[0]["bRepeater"].ToString() == "1")
            {
                chkRepeaterclnt.Checked = true;
                chkRepeatersup.Checked = true;

            }
            else
            {
                chkRepeaterclnt.Checked = false;
                chkRepeatersup.Checked = false;
            }
            txtClntQty.Text = dt.Rows[0]["nQuantity"].ToString();
            txtSupQty.Text = dt.Rows[0]["nQuantity"].ToString();
            txtclntCost.Text = dt.Rows[0]["nMofaCost"].ToString();
            txtBasicFare.Text = dt.Rows[0]["nMofaCost"].ToString();
            lblMofaCostTotal.Text = dt.Rows[0]["nMofaCostTotal"].ToString();



            ddlSupScType.SelectedValue = dt.Rows[0]["nSupSCType"].ToString();

            if (ddlSupScType.SelectedValue == "1")
            {
                txtSupSc.Text = dt.Rows[0]["nSupSCPercent"].ToString();
            }
            else
            {
                txtSupSc.Text = dt.Rows[0]["nSupSCAmount"].ToString();
            }
            txtSupScTot.Text = dt.Rows[0]["nSupSCAmountTotal"].ToString();

            ddlSupTds.SelectedValue = dt.Rows[0]["nSupTDSType"].ToString();
            if (ddlSupTds.SelectedValue == "1")
            {
                txtSupTds.Text = dt.Rows[0]["nSupTDSPercent"].ToString();
            }
            else
            {
                txtSupTds.Text = dt.Rows[0]["nSupTDSAmount"].ToString();
            }
            txtOtherTax.Text = dt.Rows[0]["nSupOtrTax"].ToString();
            txtSupDiscount.Text = dt.Rows[0]["nSupDiscount"].ToString();
            if (dt.Rows[0]["bSupTax"].ToString() == "1")
            {
                chkSupTax.Checked = true;
            }
            else
            {
                chkSupTax.Checked = false;
            }
            txtsupcgst.Text = dt.Rows[0]["nSupCGST"].ToString();
            txtsupsgst.Text = dt.Rows[0]["nSupCGST"].ToString();
            txtsupigst.Text = dt.Rows[0]["nSupCGST"].ToString();

            lblsupcgst.Text = dt.Rows[0]["nSupCGSTTotal"].ToString();
            lblsupsgst.Text = dt.Rows[0]["nSupSGSTTotal"].ToString();
            lblsupigst.Text = dt.Rows[0]["nSupIGSTTotal"].ToString();




            txtSupplierCost.Text = dt.Rows[0]["nSupplierCost"].ToString();
            lblBuyCost.Text = dt.Rows[0]["nSupplierCost"].ToString();

            ddlProfitType.SelectedValue = dt.Rows[0]["nClntSCType"].ToString();
            if (ddlProfitType.SelectedValue == "1")
            {
                txtProfitAmt.Text = dt.Rows[0]["nClntSCPercent"].ToString();
            }
            else
            {
                txtProfitAmt.Text = dt.Rows[0]["nClntSCAmount"].ToString();
            }
            txtClntScTot.Text = dt.Rows[0]["nClntSCAmountTotal"].ToString();
            ddlClntTds.SelectedValue = dt.Rows[0]["nClntTDSType"].ToString();
            if (ddlClntTds.SelectedValue == "1")
            {
                txtClntTds.Text = dt.Rows[0]["nClntTDSPercent"].ToString();
            }
            else
            {
                txtClntTds.Text = dt.Rows[0]["nClntTDSAmount"].ToString();
            }
            txtOtherchrg.Text = dt.Rows[0]["nClntOtrTax"].ToString();
            txtDiscount.Text = dt.Rows[0]["nClntDiscount"].ToString();
            txtCourierCharge.Text = dt.Rows[0]["nCourierfee"].ToString();

            if (dt.Rows[0]["bClntTax"].ToString() == "1")
            {
                chkClntTax.Checked = true;
            }
            else
            {
                chkClntTax.Checked = false;
            }
            lblClntCgst.Text = dt.Rows[0]["nClntCGST"].ToString();
            lblClntSgst.Text = dt.Rows[0]["nClntSGST"].ToString();
            lblClntIgst.Text = dt.Rows[0]["nClntIGST"].ToString();
            txtClntCgst.Text = dt.Rows[0]["nClntCGSTTotal"].ToString();
            txtClntSgst.Text = dt.Rows[0]["nClntSGSTTotal"].ToString();
            txtClntIgst.Text = dt.Rows[0]["nClntIGSTTotal"].ToString();

            txtClientCost.Text = dt.Rows[0]["nClientCost"].ToString();
            lblSelleing.Text = dt.Rows[0]["nClientCost"].ToString();


        }
    }

    public void btnVisibleDet()
    {
        btnAdd.Visible = true;
        //btnUpdate.Visible = false;
        //btnDelete.Visible = false;
        clrfieldDet();
    }

    public void displayGridDet()
    {
        try
        {
            objClassDet.sGroupName = Session["eid"].ToString();
            objClassDet.sGroupCode = "0";
            objClassDet.sVisaValidity = "0";
            objClassDet.sDuration = "0";
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
            if (Session["tMofa_booking"].ToString() == ViewState["tMofa_booking"].ToString())
            {
                paraDet();
                var abc = objClassDet.User_Operation(objClassDet, "add");

                tblmain.Visible = true;
                tblDet.Visible = true;
                tblGridDet.Visible = true;
                tblGrd.Visible = false;

                displayGridDet();
                btnAdd.Visible = false;
                btnAddDet.Visible = true;
                btnUpdateDet.Visible = false;

                //   clrfieldDet();
                DisableData();


                valobj.showMsg(abc, lblmsg);
                string aa = Server.UrlEncode(System.DateTime.Now.ToString());
                Session["tMofa_booking"] = aa;
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

            Label MofaID = (Label)GridView2.Rows[row].Cells[0].FindControl("lblGroupMofaBookingID");
            Session["eid"] = MofaID.Text;
            btnAdd.Visible = false;
            btnAddDet.Visible = false;
            btnUpdateDet.Visible = true;
            btnPrint.Visible = true;
            tblmain.Visible = true;
            tblDet.Visible = true;
            tblGridDet.Visible = true;
            tblGrd.Visible = false;
            btnPaymentHistory.Visible = true;
            displayGridDet();

            GetFormDataDet();
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
            //objClassDet.nGroupMofaID = Session["eid"].ToString();
            //var abc = objClass.User_Operation(objClass, "edit");

            paraDet();
            objClassDet.nGroupMofaDetID = Session["Detid"].ToString();
            var abc1 = objClassDet.User_Operation(objClassDet, "edit");

            if (chkRepeaterclnt.Checked)
            {
                RepeaterSave();
            }
            valobj.showMsg(abc1, lblmsg);
            //clrfieldDet();
            
            tblDet.Visible = true;
            tblGridDet.Visible = true;
            btnAdd.Visible = false;
            btnAddDet.Visible = true;
            btnUpdateDet.Visible = false;

            displayGridDet();

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
        objClassDet.nGroupMofaDetID = Session["Detid"].ToString();
        var vres = objClassDet.User_Operation(objClassDet, "DeActive");
        valobj.showMsg(vres, lblmsg);
        DetButtonVisible();
        clrfieldDet();
        displayGridDet();

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
        txtdtMofaBooking.Text = validation.fillDate();
        Booking_Generate();
        Session["eid"] = "";
        Session["Detid"] = "";
    }
    protected void lnkList_Click(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        tblmain.Visible = false;
        tblGrd.Visible = true;
        PnlPayment.Visible = false;
        Session["eid"] = "";
        Session["Detid"] = "";
        displayGrid();

        objAccount.ddlOperation(objAccount, "ddlCustomer", "", ddlSClient);
        objBranch.ddlOperation(objBranch, "Show", "", ddlSLoc);
        objAccount.ddlOperation(objAccount, "ddlVendor", "", ddlSSup);
        objClass.ddlOperation(objClass, "Show", "", ddlInvoiceNo);
        Response.Redirect("tgroupmofa_booking_list.aspx");

    }
    protected void txtdtMofaBooking_TextChanged(object sender, EventArgs e)
    {
        Booking_Generate();
    }
    protected void txtBasicFare_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (txtBasicFare.Text == "")
            {
                txtBasicFare.Text = "0";
            }
            if (txtOtherTax.Text == "")
            {
                txtOtherTax.Text = "0";
            }
            //if (txtSupComm.Text == "")
            //{
            //    txtSupComm.Text = "0";
            //}
            if (txtSupSc.Text == "")
            {
                txtSupSc.Text = "0";
            }
            if (txtSupTds.Text == "")
            {
                txtSupTds.Text = "0";
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
            if (txtSupplierCost.Text == "")
            {
                txtSupplierCost.Text = "0";
            }

            if (txtProfitAmt.Text == "")
            {
                txtProfitAmt.Text = "0";
            }

            //if (txtClntTds.Text == "")
            //{
            //    txtClntTds.Text = "0";
            //}
            //if (txtDiscount.Text == "")
            //{
            //    txtDiscount.Text = "0";
            //}

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
            //if (txtClntTds.Text == "")
            //{
            //    txtClntTds.Text = "0";
            //}
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
            //if (txtProfitAmt2.Text == "")
            //{
            //    txtProfitAmt2.Text = "0";
            //}
            if (txtOtherchrg.Text == "")
            {
                txtOtherchrg.Text = "0";
            }
            if (txtCourierCharge.Text == "")
            {
                txtCourierCharge.Text = "0";
            }
            if (txtSupRepeaterFee.Text == "")
            {
                txtSupRepeaterFee.Text = "0";
            }
            if (txtSupDiscount.Text == "")
            {
                txtSupDiscount.Text = "0";
            }
            if (txtSupQty.Text == "")
            {
                txtSupQty.Text = "1";
            }
            if (txtClntQty.Text == "")
            {
                txtClntQty.Text = "1";
            }

            txtclntCost.Text = txtBasicFare.Text;

            //GST Calculation

            //GST Calculation
            GstCal();



            double SupSC = 0; double SupTDS = 0; double ClntSC = 0; double ClntSC2 = 0; double ClntTDS = 0; double subTot = 0;
            //Supplier SC and TDS Calculation

            txtclntCost.Text = txtBasicFare.Text;
            subTot = double.Parse(txtBasicFare.Text) * double.Parse(txtSupQty.Text);
            lblMofaCostTotal.Text = subTot.ToString();
            if (ddlSupScType.SelectedValue == "0")
            {
                SupSC = double.Parse(txtSupScTot.Text);
            }
            else
            {
                SupSC = subTot * double.Parse(txtSupScTot.Text) / 100;

            }
            if (ddlSupTds.SelectedValue == "0")
            {
                SupTDS = double.Parse(txtSupTds.Text);
            }
            else
            {
                SupTDS = SupSC * double.Parse(txtSupTds.Text) / 100;

            }

            if (ddlbookType.SelectedValue == "2")
            {
                string SupCost = (((subTot) + double.Parse(txtOtherTax.Text) + double.Parse(txtSupRepeaterFee.Text) + SupSC - SupTDS - (double.Parse(txtSupDiscount.Text)) + (double.Parse(txtsupcgst.Text)) + (double.Parse(txtsupsgst.Text)) + (double.Parse(txtsupigst.Text)))).ToString();
                // string SupCost1 = (double.Parse(SupCost) * (double.Parse(txtSupQty.Text))).ToString();
                txtSupplierCost.Text = (double.Parse(SupCost) - double.Parse(txtRefundAmt.Text) - double.Parse(txtRfnCGst.Text) - double.Parse(txtRfnSGst.Text) - double.Parse(txtRfnIGst.Text) + (double.Parse(txtSupRptTotal.Text))).ToString();
            }
            else
            {
                string SupCost = (((subTot) + double.Parse(txtOtherTax.Text) + SupSC - SupTDS - (double.Parse(txtSupDiscount.Text)) + (double.Parse(txtsupcgst.Text)) + (double.Parse(txtsupsgst.Text)) + (double.Parse(txtsupigst.Text)) + (double.Parse(txtSupRptTotal.Text)))).ToString();
                //  string SupCost1 = (double.Parse(SupCost) * (double.Parse(txtSupQty.Text))).ToString();
                txtSupplierCost.Text = SupCost;
            }
            lblBuyCost.Text = ((subTot + double.Parse(txtOtherTax.Text) + SupSC - SupTDS - (double.Parse(txtSupDiscount.Text))  +(double.Parse(txtsupcgst.Text)) + (double.Parse(txtsupsgst.Text)) + (double.Parse(txtsupigst.Text)) + (double.Parse(txtSupRptTotal.Text)))).ToString();




            if (ddlProfitType.SelectedValue == "0")
            {
                ClntSC = double.Parse(txtClntScTot.Text);
                //    ClntSC2 = double.Parse(txtProfitAmt2.Text);
            }
            else
            {
                ClntSC = double.Parse(txtclntCost.Text) * double.Parse(txtClntScTot.Text) / 100;
                // ClntSC2 = double.Parse(lblBuyCost.Text) * double.Parse(txtProfitAmt2.Text) / 100;

            }
            //if (ddlClntTds.SelectedValue == "0")
            //{
            //    ClntTDS = double.Parse(txtClntTds.Text);
            //}
            //else
            //{
            //    ClntTDS = ClntSC * double.Parse(txtClntTds.Text) / 100;

            //}

            if (ddlbookType.SelectedValue == "2")
            {
                //String ClientCost = ((double.Parse(lblSupCost.Text)) + double.Parse(ClntSC) + double.Parse(ClntSC2) - double.Parse(ClntTDS) - double.Parse(txtDiscount.Text) + (double.Parse(txtClntCgst.Text)) + (double.Parse(txtClntSgst.Text)) + (double.Parse(txtClntIgst.Text))).ToString();
                //txtTotal.Text = (double.Parse(ClientCost) - double.Parse(txtRefundAmt.Text) - double.Parse(txtRfnCGst.Text) - double.Parse(txtRfnSGst.Text) - double.Parse(txtRfnIGst.Text) - double.Parse(txtrfnSC.Text)).ToString();
                txtClientCost.Text = "-" + (double.Parse(txtSupplierCost.Text) - double.Parse(txtrfnSC.Text)).ToString();

            }
            else
            {
                txtClientCost.Text = ((double.Parse(lblBuyCost.Text) + ClntSC + ClntSC2 - ClntTDS - (double.Parse(txtDiscount.Text)) + (double.Parse(txtCourierCharge.Text)) + (double.Parse(txtOtherchrg.Text)) + (double.Parse(txtClntCgst.Text)) + (double.Parse(txtClntSgst.Text)) + (double.Parse(txtClntIgst.Text)) + (double.Parse(txtClntRptTotal.Text)))).ToString();

            }
            lblSelleing.Text = ((double.Parse(lblBuyCost.Text) + ClntSC + ClntSC2 - ClntTDS - (double.Parse(txtDiscount.Text)) + (double.Parse(txtOtherchrg.Text)) + (double.Parse(txtCourierCharge.Text)) + (double.Parse(txtClntCgst.Text)) + (double.Parse(txtClntSgst.Text)) + (double.Parse(txtClntIgst.Text)) + (double.Parse(txtClntRptTotal.Text)))).ToString();

            //  ddlTax.Focus();




        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, lblmsg);
        }
        finally
        {
            txtSupQty.Focus();
        }
    }
    protected void txtclntCost_TextChanged(object sender, EventArgs e)
    {
        txtBasicFare.Text = txtclntCost.Text;
        txtBasicFare_TextChanged(this, e);
        txtClntQty.Focus();

    }
    protected void txtOtherTax_TextChanged(object sender, EventArgs e)
    {
        try
        {
            txtBasicFare_TextChanged(this, e);
            txtSupDiscount.Focus();
        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, lblmsg);
        }
        finally
        {

        }
    }
    //protected void txtSupComm_TextChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        txtBasicFare_TextChanged(this, e);
    //        txtSupSc.Focus();
    //    }
    //    catch (Exception ex)
    //    {
    //        valobj.showMsg(ex.Message, lblmsg);
    //    }
    //    finally
    //    {

    //    }
    //}
    protected void txtSupSc_TextChanged(object sender, EventArgs e)
    {
        try
        {
            double SupSC = 0;
            if (ddlSupScType.SelectedValue == "0")
            {
                SupSC = double.Parse(txtSupSc.Text);
            }
            else
            {
                SupSC = double.Parse(txtBasicFare.Text) * double.Parse(txtSupSc.Text) / 100;

            }

            txtSupScTot.Text = (SupSC * double.Parse(txtSupQty.Text)).ToString();
            txtBasicFare_TextChanged(this, e);
            txtSupRepeaterFee.Focus();


        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, lblmsg);
        }
        finally
        {

        }
    }

    protected void txtSupTds_TextChanged(object sender, EventArgs e)
    {
        txtBasicFare_TextChanged(this, e);
        txtOtherTax.Focus();
    }
    
    protected void txtProfitAmt_TextChanged(object sender, EventArgs e)
    {
        try
        {
            double ClntSC = 0;
            if (ddlProfitType.SelectedValue == "0")
            {
                ClntSC = double.Parse(txtProfitAmt.Text);
            }
            else
            {
                ClntSC = double.Parse(txtBasicFare.Text) * double.Parse(txtProfitAmt.Text) / 100;

            }

            txtClntScTot.Text = (ClntSC * double.Parse(txtClntQty.Text)).ToString();

            txtBasicFare_TextChanged(this, e);
            //   txtclntRepeaterFee.Focus();

        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, lblmsg);
        }
        finally
        {

        }
    }


    protected void txtClntTds_TextChanged(object sender, EventArgs e)
    {
        try
        {
            txtBasicFare_TextChanged(this, e);
            //  txtDiscount.Focus();

        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, lblmsg);
        }
        finally
        {

        }
    }
    protected void txtDiscount_TextChanged(object sender, EventArgs e)
    {
        try
        {
            txtBasicFare_TextChanged(this, e);
            txtCourierCharge.Focus();

        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, lblmsg);
        }
        finally
        {

        }
    }
    protected void chkSupTax_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            txtBasicFare_TextChanged(this, e);

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
            txtBasicFare_TextChanged(this, e);

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

        //Sup GST
        DataTable dtSupgst = objSupGst.viewData(objSupGst, "show", ddlSupplier.SelectedValue);
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

                lblsupigst.Text = "0";
                lblsupcgst.Text = "0";
                lblsupsgst.Text = "0";
            }
            else
            {

                if (ddlSupScType.SelectedValue == "0")
                {
                    if (SupState == CompState)
                    {
                        lblsupigst.Text = "0";
                        lblsupcgst.Text = ((double.Parse(txtSupSc.Text)) * (double.Parse(Supsgst)) / 100).ToString();
                        lblsupsgst.Text = ((double.Parse(txtSupSc.Text)) * (double.Parse(Supcgst)) / 100).ToString();

                        txtsupigst.Text = "0";
                        txtsupcgst.Text = ((double.Parse(lblsupcgst.Text)) * (double.Parse(txtSupQty.Text))).ToString();
                        txtsupsgst.Text = ((double.Parse(lblsupsgst.Text)) * (double.Parse(txtSupQty.Text))).ToString();
                    }
                    else
                    {
                        lblsupigst.Text = ((double.Parse(txtSupSc.Text)) * (double.Parse(Supigst)) / 100).ToString();
                        lblsupcgst.Text = "0";
                        lblsupsgst.Text = "0";

                        txtsupigst.Text = ((double.Parse(lblsupigst.Text)) * (double.Parse(txtSupQty.Text))).ToString();
                        txtsupcgst.Text = "0";
                        txtsupsgst.Text = "0";
                    }
                }
                else
                {
                    double Profit = double.Parse(lblBuyCost.Text) * double.Parse(txtSupSc.Text) / 100;
                    if (SupState == CompState)
                    {
                        lblsupigst.Text = "0";
                        lblsupcgst.Text = (((Profit)) * (double.Parse(Supsgst)) / 100).ToString();
                        lblsupsgst.Text = (((Profit)) * (double.Parse(Supcgst)) / 100).ToString();


                        txtsupigst.Text = "0";
                        txtsupcgst.Text = ((double.Parse(lblsupcgst.Text)) * (double.Parse(txtSupQty.Text))).ToString();
                        txtsupsgst.Text = ((double.Parse(lblsupsgst.Text)) * (double.Parse(txtSupQty.Text))).ToString();
                    }
                    else
                    {
                        lblsupigst.Text = ((Profit) * (double.Parse(Supigst)) / 100).ToString();
                        lblsupcgst.Text = "0";
                        lblsupsgst.Text = "0";

                        txtsupigst.Text = ((double.Parse(lblsupigst.Text)) * (double.Parse(txtSupQty.Text))).ToString();
                        txtsupcgst.Text = "0";
                        txtsupsgst.Text = "0";
                    }
                }

            }
        }
        else
        {
            txtsupigst.Text = "0";
            txtsupcgst.Text = "0";
            txtsupsgst.Text = "0";

            lblsupigst.Text = "0";
            lblsupcgst.Text = "0";
            lblsupsgst.Text = "0";
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
                lblClntCgst.Text = "0";
                lblClntSgst.Text = "0";
                lblClntIgst.Text = "0";

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
                        lblClntIgst.Text = "0";
                        lblClntCgst.Text = ((double.Parse(txtProfitAmt.Text)) * (double.Parse(Clntsgst)) / 100).ToString();
                        lblClntSgst.Text = ((double.Parse(txtProfitAmt.Text)) * (double.Parse(Clntcgst)) / 100).ToString();

                        txtClntIgst.Text = "0";
                        txtClntCgst.Text = ((double.Parse(lblClntCgst.Text)) * (double.Parse(txtClntQty.Text))).ToString();
                        txtClntSgst.Text = ((double.Parse(lblClntSgst.Text)) * (double.Parse(txtClntQty.Text))).ToString();
                    }
                    else
                    {
                        lblClntIgst.Text = ((double.Parse(txtProfitAmt.Text)) * (double.Parse(Clntigst)) / 100).ToString();
                        lblClntCgst.Text = "0";
                        lblClntSgst.Text = "0";

                        txtClntIgst.Text = ((double.Parse(lblClntIgst.Text)) * (double.Parse(txtClntQty.Text))).ToString();
                        txtClntCgst.Text = "0";
                        txtClntSgst.Text = "0";
                    }
                }
                else
                {
                    double Profit = double.Parse(lblBuyCost.Text) * double.Parse(txtProfitAmt.Text) / 100;
                    if (ClntState == CompState)
                    {

                        lblClntIgst.Text = "0";
                        lblClntCgst.Text = (((Profit)) * (double.Parse(Clntsgst)) / 100).ToString();
                        lblClntSgst.Text = (((Profit)) * (double.Parse(Clntcgst)) / 100).ToString();

                        txtClntIgst.Text = "0";
                        txtClntCgst.Text = ((double.Parse(lblClntCgst.Text)) * (double.Parse(txtClntQty.Text))).ToString();
                        txtClntSgst.Text = ((double.Parse(lblClntSgst.Text)) * (double.Parse(txtClntQty.Text))).ToString();
                    }
                    else
                    {

                        lblClntIgst.Text = ((Profit) * (double.Parse(Clntigst)) / 100).ToString();
                        lblClntCgst.Text = "0";
                        lblClntSgst.Text = "0";

                        txtClntIgst.Text = ((double.Parse(lblClntIgst.Text)) * (double.Parse(txtClntQty.Text))).ToString();
                        txtClntCgst.Text = "0";
                        txtClntSgst.Text = "0";
                    }
                }
            }

        }
        else
        {

            lblClntCgst.Text = "0";
            lblClntSgst.Text = "0";
            lblClntIgst.Text = "0";

            txtClntCgst.Text = "0";
            txtClntSgst.Text = "0";
            txtClntIgst.Text = "0";
        }


        //Refund GST


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
    protected void txtMofaBookingNo_TextChanged(object sender, EventArgs e)
    {
        DataTable dt = objClass.viewData(objClass, "FillDataMofa", txtMofaBookingNo.Text);
        if (dt.Rows.Count > 0)
        {
            Session["eid"] = dt.Rows[0][0].ToString();
            GetFormData();
            GetFormDataDet();
            if (ddlbookType.SelectedValue == "2")
            {
                tblrefund.Visible = true;

                GetFormDataRepeater();

                txtBasicFare_TextChanged(this, e);
            }
            else
            {
                tblrefund.Visible = false;
            }

            btnUpdateDet.Visible = true;
            btnPrint.Visible = true;
            btnAdd.Visible = false;

        }
        else
        {
            btnUpdateDet.Visible = false;
            btnPrint.Visible = false;
            btnAdd.Visible = true;
            //   clrfield();
            // clrfieldDet();
        }

    }
    protected void txtProfitAmt2_TextChanged(object sender, EventArgs e)
    {
        try
        {
            txtBasicFare_TextChanged(this, e);
            // txtClntTds.Focus();

        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, lblmsg);
        }
        finally
        {

        }
    }
    protected void txtOtherchrg_TextChanged(object sender, EventArgs e)
    {
        try
        {
            txtBasicFare_TextChanged(this, e);
            txtRemarks.Focus();

        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, lblmsg);
        }
        finally
        {

        }
    }

    protected void txtCourierCharge_TextChanged(object sender, EventArgs e)
    {
        try
        {
            txtBasicFare_TextChanged(this, e);
            txtOtherchrg.Focus();

        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, lblmsg);
        }
        finally
        {

        }
    }



    protected void txtSupDiscount_TextChanged(object sender, EventArgs e)
    {
        try
        {
            txtBasicFare_TextChanged(this, e);
            txtProfitAmt.Focus();

        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, lblmsg);
        }
        finally
        {

        }
    }

    //Repeater Fee
    public string RepeaterVoucher_Generate(string sdtRpt)
    {
        string repeaterVoucher;
        DataTable dt = objMofaRepeater.viewData(objMofaRepeater, "MaxVoucherNo", sdtRpt);
        if (dt.Rows.Count > 0)
        {
            repeaterVoucher = dt.Rows[0][0].ToString();
        }
        else
        {
            repeaterVoucher = "";
        }
        return repeaterVoucher;
    }

    public void paraRepeater()
    {
        objMofaRepeater.nGroupMofaID = Session["eid"].ToString();
        objMofaRepeater.nRepeaterQty = txtSupRptQty.Text;
        objMofaRepeater.nSupRepeaterRate = txtSupRepeaterFee.Text;
        objMofaRepeater.nSupRPTTotal = txtSupRptTotal.Text;
        objMofaRepeater.nClntRepeaterRate = txtClntRptFee.Text;
        objMofaRepeater.nClntRPTTotal = txtClntRptTotal.Text;
        objMofaRepeater.dtRptDate = validation.fillTextDate();
        objMofaRepeater.sVoucherNo = RepeaterVoucher_Generate(objMofaRepeater.dtRptDate);


    }

    public void clrfieldRepeater()
    {
        txtSupRepeaterFee.Text = "0";
        txtRefundAmt.Text = "0";
        txtrfnSC.Text = "0";
        txtRfnRemarks.Text = "";
        Session["Detid"] = "";
    }

    public void GetFormDataRepeater()
    {
        DataTable dt = objMofaRepeater.viewData(objMofaRepeater, "show", Session["eid"].ToString());
        if (dt.Rows.Count > 0)
        {

            txtSupRptQty.Text = dt.Rows[0][2].ToString();
            txtClntRptQty.Text = dt.Rows[0][2].ToString();
            txtSupRepeaterFee.Text = dt.Rows[0][3].ToString();
            txtSupRptTotal.Text = dt.Rows[0][4].ToString();
            txtClntRptFee.Text = dt.Rows[0][5].ToString();
            txtClntRptTotal.Text = dt.Rows[0][6].ToString();
            //   lblRepeaterVoucher.Text = dt.Rows[0][8].ToString();
            // txtSupRptQty.Text = validation.TextToDate(dt.Rows[0][9].ToString());

        }
    }

    public void RepeaterSave()
    {
        try
        {
            paraRepeater();
            DataTable dt = objMofaRepeater.viewData(objMofaRepeater, "show", Session["eid"].ToString());

            if (dt.Rows.Count > 0)
            {


                //objMofaRepeater.nGroupMofaID = dt.Rows[0][1].ToString();
                var abc = objMofaRepeater.User_Operation(objMofaRepeater, "edit");
            }
            else
            {
                var abc = objMofaRepeater.User_Operation(objMofaRepeater, "add");
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
            txtBasicFare_TextChanged(this, e);
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
            txtBasicFare_TextChanged(this, e);
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
            txtBasicFare_TextChanged(this, e);
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

    public void RepeaterGst()
    {

    }

    public string RepeaterNo_Generate()
    {
        string RefundNo = "";
        //DataTable dtRefund = objRefund.viewData(objRefund, "show", Session["Detid"].ToString());
        //if (dtRefund.Rows.Count > 0)
        //{
        //    RefundNo = dtRefund.Rows[0]["sRefundNo"].ToString();
        //}
        //else
        //{
        //    DataTable dt = objRefund.viewData(objRefund, "MaxRefundNo", validation.dateToText(txtdtRfnDate.Text));
        //    if (dt.Rows.Count > 0)
        //    {
        //        RefundNo = dt.Rows[0][0].ToString();
        //    }
        //    else
        //    {
        //        RefundNo = "";
        //    }
        //}


        return RefundNo;
    }


    //Search

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            //    if (ddlVisaBookingNo.SelectedValue != "0" || txtdtBooking.Text != "" || ddlVisaBookingNo.SelectedValue != "0" || ddlAgentID.SelectedValue != "0" || ddlLocationID.SelectedValue != "0")
            //    {
            SearchPara();
            displaySearchGrid();
            SearcClr();


            //  clrfield();
            //}
            //else
            //{
            //    displayGrid();
            //}
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
            objClassDet.FillGrid(objClassDet, GridView1, "ShowSearch", "");

        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, lblmsg);
        }
    }

    public void SearchPara()
    {
        //objClassDet.sEngName = ddlInvoiceNo.SelectedValue;
        //objClassDet.sArabicName = ddlSClient.SelectedValue;
        //objClassDet.sAge = ddlSSup.SelectedValue;
        //objClassDet.sPassportNo = ddlSLoc.SelectedValue;
        //objClassDet.sPackage = ddlSBookType.SelectedValue;
        //objClassDet.dtExpityDate = validation.dateToText(txtSdtBooking.Text);
    }

    public void SearcClr()
    {
        ddlInvoiceNo.SelectedValue = "0";
        ddlSClient.SelectedValue = "0";
        ddlSSup.SelectedValue = "0";
        ddlSLoc.SelectedValue = "0";
        ddlSBookType.SelectedValue = "0";
        txtSdtBooking.Text = "";
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
        Session["Payid"] = "";

        LinkButton thisbtn = (LinkButton)sender;
        GridViewRow thisgrdR = (GridViewRow)thisbtn.Parent.Parent;
        int row = thisgrdR.RowIndex;
        Label MofaID = (Label)GridView1.Rows[row].Cells[0].FindControl("lblID");
        Session["eid"] = MofaID.Text;
        Label AgentID = (Label)GridView1.Rows[row].Cells[0].FindControl("lblAgentID");
        lblAgent.Text = AgentID.Text;
        Label nBalance = (Label)GridView1.Rows[row].Cells[0].FindControl("lblBalance");
        txtPayBalance.Text = nBalance.Text;
        txtdtpayment.Text = validation.fillDate();

        Label InvNo = (Label)GridView1.Rows[row].Cells[0].FindControl("lblInvoiceNo");
        txtPayInv.Text = InvNo.Text;

        Label InvDate = (Label)GridView1.Rows[row].Cells[0].FindControl("lblInvoiceDate");
        lblInvoiceDate.Text = InvDate.Text;

        txtPayRemarks.Text = "Group Umrah Mofa  payment for invoice no.: " + InvNo.Text;
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
        txtPayRemarks.Text = "Group Mofa payment for invoice no.: " + txtMofaBookingNo.Text;
        txtPayInv.Text = txtMofaBookingNo.Text;
        lblInvoiceDate.Text = validation.dateToText(txtdtMofaBooking.Text).ToString();
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
        objMofaPay.sPayfor = "GroupMofa";
        objMofaPay.FillGrid(objMofaPay, GridPay, "ShowPaymentsModule", Session["eid"].ToString());
    }
    public void paymentPara()
    {
        objMofaPay.nPaymentModeID = ddlPayVoucherType.SelectedValue;
        objMofaPay.nCashAccountID = ddlPaymentAccount.SelectedValue;
        objMofaPay.dtPayment = validation.dateToText(txtdtpayment.Text);
        objMofaPay.sVoucherNo = txtPayVoucherNo.Text;
        objMofaPay.nTotAmount = txtPayAmount.Text;
        objMofaPay.nAgentID = lblAgent.Text;
        objMofaPay.sRemarks = txtPayRemarks.Text;
        objMofaPay.sPayfor = "GroupMofa";

        //Detail Table
        objMofaPayDet.nInvoiceID = Session["eid"].ToString();
        objMofaPayDet.sInvoiceNo = txtPayInv.Text;
        objMofaPayDet.dtInvoiceDate = lblInvoiceDate.Text;
        objMofaPayDet.nAmount = txtPayAmount.Text; ;

        objMofaPayDet.sRemarks = txtPayRemarks.Text;
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
        DataTable dt = objMofaPayDet.viewData(objMofaPayDet, "GetDataTravel", Session["PayDetid"].ToString());
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
        if (Session["tMofa_booking"].ToString() == ViewState["tMofa_booking"].ToString())
        {
            paymentPara();

            if (Session["Payid"] == null || Session["Payid"] == "")
            {
                var abc = objMofaPay.User_Operation(objMofaPay, "add");
                var strArr = abc.Split(',');
                if (strArr[0] == "1")
                {
                    string PayID = strArr[2].ToString();
                    Session["Payid"] = PayID;
                    objMofaPayDet.nPaymentReceiveID = PayID;
                    var abc1 = objMofaPayDet.User_Operation(objMofaPayDet, "add");
                }
                valobj.showMsg(abc, lblmsg);

                Session["Payid"] = "";
                Session["PayDetid"] = "";
            }
            else
            {
                //Upodate Main Table
                objMofaPay.nPaymentReceiveID = Session["Payid"].ToString();
                var abc = objMofaPay.User_Operation(objMofaPay, "edit");

                //Upodate Detail Table
                objMofaPayDet.nPaymentReceiveDetID = Session["PayDetid"].ToString();
                objMofaPayDet.nPaymentReceiveID = Session["Payid"].ToString();
                var abc1 = objMofaPayDet.User_Operation(objMofaPayDet, "edit");

                valobj.showMsg(abc, lblmsg);
                Session["Payid"] = "";
                Session["PayDetid"] = "";

            }
            GetPaidDetails();
            objClass.nGroupMofaID = Session["eid"].ToString();
            var xyz = objClass.User_Operation(objClass, "bPaidEdit");

            GetBalance();
            Payclrfield();
            DisplayPaymentGrid();
            PayVoucher_Generate();

        }



        string aa = Server.UrlEncode(System.DateTime.Now.ToString());
        Session["tMofa_booking"] = aa;

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
        objMofaPay.nPaymentReceiveID = Session["Payid"].ToString();
        var vres = objMofaPay.User_Operation(objMofaPay, "DeActive");
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
        DataTable dt = objMofaPay.viewData(objMofaPay, "PVN", validation.dateToText(txtdtpayment.Text));
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

            Response.Redirect("PaymentReceipt/rptpay_receipt_inv.aspx?Detid=" + IDDet.Text + "&sPayfor=GroupMofa");
        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, "FAIL", lblmsg);
        }
    }
    protected void btnPaymentReceipt_Click(object sender, EventArgs e)
    {
        Response.Redirect("PaymentReceipt/rptpay_receipt_inv.aspx?id=" + Session["eid"].ToString() + "&sPayfor=Mofa");
    }

    protected void ddlSupplier_SelectedIndexChanged(object sender, EventArgs e)
    {
        objAccount.ddlOperation(objAccount, "ddlCustomer", ddlSupplier.SelectedValue, ddlAgentID);
    }


    protected void txtClntQty_TextChanged(object sender, EventArgs e)
    {
        txtSupQty.Text = txtClntQty.Text;
        txtBasicFare_TextChanged(this, e);
        txtProfitAmt.Focus();
    }
    protected void txtSupQty_TextChanged(object sender, EventArgs e)
    {
        txtClntQty.Text = txtSupQty.Text;
        txtBasicFare_TextChanged(this, e);
        txtSupSc.Focus();

    }

    protected void txtSupRptQty_TextChanged(object sender, EventArgs e)
    {
        txtClntRptQty.Text = txtSupRptQty.Text;


        if (txtSupRepeaterFee.Text == "")
        {
            txtSupRepeaterFee.Text = "0";
        }
        if (txtSupRptQty.Text == "")
        {
            txtSupRptQty.Text = "1";
        }
        txtSupRptTotal.Text = (double.Parse(txtSupRepeaterFee.Text) * double.Parse(txtSupRptQty.Text)).ToString();
        txtBasicFare_TextChanged(this, e);

        txtProfitAmt.Focus();
    }
    protected void txtClntRptQty_TextChanged(object sender, EventArgs e)
    {
        txtSupRptQty.Text = txtClntRptQty.Text;

        if (txtClntRptFee.Text == "")
        {
            txtClntRptFee.Text = "0";
        }
        if (txtClntRptQty.Text == "")
        {
            txtClntRptQty.Text = "1";
        }
        txtClntRptTotal.Text = (double.Parse(txtClntRptFee.Text) * double.Parse(txtClntRptQty.Text)).ToString();
        txtBasicFare_TextChanged(this, e);

        //txtProfitAmt.Focus();
    }


    protected void txtSupRepeaterFee_TextChanged(object sender, EventArgs e)
    {
        if (txtSupRepeaterFee.Text == "")
        {
            txtSupRepeaterFee.Text = "0";
        }
        if (txtSupRptQty.Text == "")
        {
            txtSupRptQty.Text = "1";
        }
        txtSupRptTotal.Text = (double.Parse(txtSupRepeaterFee.Text) * double.Parse(txtSupRptQty.Text)).ToString();
        txtBasicFare_TextChanged(this, e);

        txtSupRptQty.Focus();
    }
    protected void txtClntRptFee_TextChanged(object sender, EventArgs e)
    {
        if (txtClntRptFee.Text == "")
        {
            txtClntRptFee.Text = "0";
        }
        if (txtClntRptQty.Text == "")
        {
            txtClntRptQty.Text = "1";
        }
        txtClntRptTotal.Text = (double.Parse(txtClntRptFee.Text) * double.Parse(txtClntRptQty.Text)).ToString();
        txtBasicFare_TextChanged(this, e);

        txtClntRptQty.Focus();
    }

    protected void txtSupRptTotal_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtClntRptTotal_TextChanged(object sender, EventArgs e)
    {

    }



    protected void chkRepeatersup_CheckedChanged(object sender, EventArgs e)
    {
        if (chkRepeatersup.Checked)
        {
            txtSupRepeaterFee.Enabled = true;
            txtSupRptQty.Enabled = true;
            txtSupRptTotal.Enabled = false;

            txtClntRptFee.Enabled = true;
            txtClntRptQty.Enabled = true;
            txtClntRptTotal.Enabled = false;

            chkRepeaterclnt.Checked = true;
            //   chkRepeaterclnt_CheckedChanged(this, e);
        }
        else
        {
            txtSupRepeaterFee.Enabled = false;
            txtSupRptQty.Enabled = false;
            txtSupRptTotal.Enabled = false;

            txtClntRptFee.Enabled = false;
            txtClntRptQty.Enabled = false;
            txtClntRptTotal.Enabled = false;

            txtSupRepeaterFee.Text = "0";
            txtSupRptQty.Text = "1";
            txtSupRptTotal.Text = "0";

            txtClntRptFee.Text = "0";
            txtClntRptQty.Text = "1";
            txtClntRptTotal.Text = "0";

            chkRepeaterclnt.Checked = false;
        }
    }

    protected void chkRepeaterclnt_CheckedChanged(object sender, EventArgs e)
    {
        if (chkRepeaterclnt.Checked)
        {
            txtSupRepeaterFee.Enabled = true;
            txtSupRptQty.Enabled = true;
            txtSupRptTotal.Enabled = false;

            txtClntRptFee.Enabled = true;
            txtClntRptQty.Enabled = true;
            txtClntRptTotal.Enabled = false;

            chkRepeatersup.Checked = true;
            //   chkRepeaterclnt_CheckedChanged(this, e);
        }
        else
        {
            txtSupRepeaterFee.Enabled = false;
            txtSupRptQty.Enabled = false;
            txtSupRptTotal.Enabled = false;

            txtClntRptFee.Enabled = false;
            txtClntRptQty.Enabled = false;
            txtClntRptTotal.Enabled = false;

            txtSupRepeaterFee.Text = "0";
            txtSupRptQty.Text = "1";
            txtSupRptTotal.Text = "0";

            txtClntRptFee.Text = "0";
            txtClntRptQty.Text = "1";
            txtClntRptTotal.Text = "0";

            chkRepeatersup.Checked = false;
        }
    }
}
