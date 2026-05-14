using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Transcation_hotel : System.Web.UI.Page
{
    thotel_booking_Class objClass = new thotel_booking_Class();
    thotel_bookingdet_Class objClassDet = new thotel_bookingdet_Class();
    tpayments_receive_Class objHotelPay = new tpayments_receive_Class();
    tpayments_receivedet_Class objHotelPayDet = new tpayments_receivedet_Class();
    thotelrefund_Class objRefund = new thotelrefund_Class();
    magent_Class objAgent = new magent_Class();
  //  mlocation_Class objBranch = new mlocation_Class();
    mcompany_Class objcompany = new mcompany_Class();
    mhotel_Class objHotelName = new mhotel_Class();
    mhotel_room_Class objRoomType = new mhotel_room_Class();
    validation valobj = new validation();
    // tchartof_account_Class objAccount = new tchartof_account_Class();
    mmain_account_Class objAccount = new mmain_account_Class();
    thotelbooking_guest_Class objHotelGuest = new thotelbooking_guest_Class();
    thotelguest_list_Class objHotelGuestList = new thotelguest_list_Class();
    msupgst_Class objSupGst = new msupgst_Class();
    mclientgst_Class objClntGst = new mclientgst_Class();
    
    mcity_Class objCity = new mcity_Class();

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
                Session["thotel"] = aa;
                tblmain.Visible = true;
                tblDet.Visible = true;
                tblGridDet.Visible = false;
                tblGrd.Visible = false;
                PnlPayment.Visible = false;
                //displayGrid();
                objAccount.ddlOperation(objAccount, "ddlCustomer", "", ddlAgentID);
                objAccount.ddlOperation(objAccount, "ddlVendor", "", ddlSupplier);
                objBranch.ddlOperation(objBranch, "Showddl", "", ddlLocationID);
                // objAccount.ddlOperation(objAccount, "ddlCustomer", ddlAgentID.SelectedValue, ddlCompanyID);
                objHotelName.ddlOperation(objHotelName, "Show", "", ddlHotelName);
                objRoomType.ddlOperation(objRoomType, "Show", "", ddlRoomType);
                objCity.ddlOperation(objCity, "Showddl", "", ddlCity);
                btnVisible();

                txtdtBooking.Text = validation.fillDate();
                txtdtBooking_TextChanged(this, e);

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

                if (Session["THid"] != "" && Session["THid"] != null)
                {
                    string eid = Session["THid"].ToString();
                    Session["eid"] = eid;
                    Session["THid"] = "";
                    GetFormData();
                    GetFormDataDet();
                    DetButtonVisible();
                    DisableData();

                }
                 var ID = Request.QueryString["ID"];
                 if (!string.IsNullOrEmpty(ID))
                 {
                     Session["eid"] = ID;
                     btnAdd.Visible = false;
                     GetFormData();
                     if (ddlbookType.SelectedValue == "2")
                     {
                         tblrefund.Visible = true;

                         GetFormDataRefund();

                         txtRate_TextChanged(this, e);
                     }
                     else
                     {
                         tblrefund.Visible = false;
                     }


                     lblmsg.Text = "";
                     tblmain.Visible = true;
                     tblGrd.Visible = false;
                     btnPrint.Visible = true;
                     btnPaymentHistory.Visible = true;
                     DetButtonVisible();
                     displayGridDet();
                     txtPaxNos_TextChanged(this, e);
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
        ViewState["thotel"] = Session["thotel"];
    }

    public void para()
    {
        objClass.sHotelBookingNo = validation.stringToDBString(txtHotelBookingNo.Text.Trim());
        objClass.dtBooking = validation.dateToText(txtdtBooking.Text.Trim());
        objClass.nAgentID = ddlAgentID.SelectedValue;
        objClass.nLocationID = ddlLocationID.SelectedValue;
        objClass.nSupplierID = ddlSupplier.SelectedValue;
        objClass.bPaid = "0";  //Un paid 
        //  objClass.nBookTypeID = ddlbookType.SelectedValue;
    }

    public void clrfield()
    {
        txtHotelBookingNo.Text = "";
        txtdtBooking.Text = "";
        ddlAgentID.SelectedValue = "0";
        ddlLocationID.SelectedValue = "0";
        ddlSupplier.SelectedValue = "0";
        txtReferenceNo.Text = "";
        ddlbookType.SelectedValue = "0";
        //Session["eid"] = "";
    }

    public void GetFormData()
    {
        DataTable dt = objClass.viewData(objClass, "show", Session["eid"].ToString());
        if (dt.Rows.Count > 0)
        {
            txtHotelBookingNo.Text = dt.Rows[0][1].ToString();
            txtdtBooking.Text = validation.TextToDate(dt.Rows[0][2].ToString());
            
            EventArgs e = new EventArgs();
            ddlLocationID.SelectedValue = dt.Rows[0][4].ToString();
            //  ddlbookType.SelectedValue = dt.Rows[0]["nBookTypeID"].ToString();
            ddlSupplier.SelectedValue = dt.Rows[0][5].ToString();
           
            ddlSupplier_SelectedIndexChanged(this, e);
            ddlAgentID.SelectedValue = dt.Rows[0][3].ToString();

        }
    }

    public void btnVisible()
    {
        btnAdd.Visible = true;
        btnAddDet.Visible = false;
        btnUpdateDet.Visible = false;
        btnPrint.Visible = false;
        btnPaymentHistory.Visible = false;
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

    protected void txtdtBooking_TextChanged(object sender, EventArgs e)
    {
        Booking_Generate();
    }
    public void Booking_Generate()
    {
        DataTable dt = objClass.viewData(objClass, "MaxBookNo", validation.dateToText(txtdtBooking.Text));
        if (dt.Rows.Count > 0)
        {
            txtHotelBookingNo.Text = dt.Rows[0][0].ToString();
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
        objClass.nHotelBookingID = Session["eid"].ToString();
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
            if (Session["thotel"].ToString() == ViewState["thotel"].ToString())
            {
                para();
                var abc = objClass.User_Operation(objClass, "add");

                var strArr = abc.Split(',');
                if (strArr[0] == "1")
                {
                    string HotelID = strArr[2].ToString();
                    Session["eid"] = HotelID;

                    paraDet();
                    var xyz = objClassDet.User_Operation(objClassDet, "add");
                    var strArr1 = xyz.Split(',');
                    if (strArr1[0] == "1")
                    {
                        string HotelDetID = strArr1[2].ToString();
                        Session["Detid"] = HotelDetID;
                        AddGuestList();
                        //paraGuest();
                        //var xyz1 = objHotelGuest.User_Operation(objHotelGuest, "add");
                        //  InsertGuestDetails();
                    }
                    tblmain.Visible = true;
                    tblDet.Visible = true;
                    tblGridDet.Visible = true;
                    tblGrd.Visible = false;

                    displayGridDet();
                    btnAdd.Visible = false;
                    btnAddDet.Visible = true;
                    btnUpdateDet.Visible = false;
                    txtPaxNos.Text = "0";
                    txtPaxNos_TextChanged(this,e);
                    //clrfieldDet();
                    DisableData();
                    valobj.showMsg(abc, lblmsg);

                }

                //displayGrid();
                string aa = Server.UrlEncode(System.DateTime.Now.ToString());
                Session["thotel"] = aa;
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
    //public void InsertGuestDetails()
    //{
    //    try
    //    {
    //        foreach (GridViewRow row in GridView3.Rows)
    //        {

    //            objHotelGuest.nHotelBookingID = Session["eid"].ToString();

    //            Label ID = (Label)row.Cells[0].FindControl("lblIdGuest");
    //            objHotelGuest.nHotelbookingGuestID = ID.Text;

    //            Label lblGnameID = (Label)row.Cells[0].FindControl("lblGnameID");
    //            objHotelGuest.sGuestName = lblGnameID.Text;
    //            var yz = objHotelGuest.User_Operation(objHotelGuest, "add");
    //        }
    //    }
    //    catch (Exception ex)
    //    {

    //    }
    //}
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            para();
            objClass.nHotelBookingID = Session["eid"].ToString();
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
            //    Response.Redirect("rptHotelInvoice.aspx?id=" + Session["eid"].ToString());
            //}
            //else
            //{

            //    Response.Redirect("rptHotelRefund_Invoice.aspx?id=" + Session["eid"].ToString());
            //}

            Response.Redirect("Invoices/rpthotel_invoice.aspx?id=" + ID.Text);

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
            objClass.nHotelBookingID = Session["eid"].ToString();
            //if (ddlbookType.SelectedValue == "1")
            //{
            //    Response.Redirect("rptHotelInvoice.aspx?id=" + Session["eid"].ToString());
            //}
            //else
            //{

            //    Response.Redirect("rptHotelRefund_Invoice.aspx?id=" + Session["eid"].ToString());
            //}

            Response.Redirect("Invoices/rpthotel_invoice.aspx?id=" + Session["eid"].ToString());
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
        Label ID = (Label)GridView2.Rows[row].Cells[0].FindControl("lblDetID");
        Session["Detid"] = ID.Text;

        Label lblType = (Label)GridView2.Rows[row].Cells[0].FindControl("lblBookType");
        if (lblType.Text == "Booking")
        {
            Response.Redirect("Invoices/rpthotel_invoice.aspx?Detid=" + ID.Text);
        }
        else
        {

            Response.Redirect("Invoices/rpthotel_refund_invoice.aspx?Detid=" + ID.Text);
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
            //btnUpdate.Visible = true;
            //btnDelete.Visible = true;
            GetFormData();
            // GetFormDataDet();
          //  GetFormDataGuest();
            if (ddlbookType.SelectedValue == "2")
            {
                tblrefund.Visible = true;

                GetFormDataRefund();

                txtRate_TextChanged(this, e);
            }
            else
            {
                tblrefund.Visible = false;
            }


            lblmsg.Text = "";
            tblmain.Visible = true;
            tblGrd.Visible = false;
            btnPrint.Visible = true;
            btnPaymentHistory.Visible = true;
            DetButtonVisible();
            // displayGuestGrid();
            displayGridDet();
            txtPaxNos_TextChanged(this, e);
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
        double SupSC = 0, ClntSC = 0, ClntSC2 = 0;

        objClassDet.nHotelBookingID = Session["eid"].ToString();
        objClassDet.sReferenceNo = validation.stringToDBString(txtReferenceNo.Text.Trim());
        //objClassDet.sGuestName = validation.stringToDBString(txtGuestName.Text.Trim());
        objClassDet.nHotelNameID = ddlHotelName.SelectedValue;
        objClassDet.sNationality = validation.stringToDBString(txtNationality.Text.Trim());
        objClassDet.nRoomType = ddlRoomType.SelectedValue;
        objClassDet.sMeal = validation.stringToDBString(txtMeal.Text.Trim());
        objClassDet.nNoOfRooms = txtNoRoom.Text.Trim();
        objClassDet.nExtraBed = txtExtrabed.Text.Trim();
        objClassDet.dtCheckIn = validation.dateToText(txtdtCheckIn.Text.Trim());
        objClassDet.dtCheckOut = validation.dateToText(txtdtCheckOut.Text.Trim());
        objClassDet.nTotalNights = txtTotNight.Text.Trim();
        objClassDet.nRate = txtRate.Text.Trim();
        objClassDet.nTotal = lblBuyCost.Text.Trim();
        objClassDet.nProfitTypeID = ddlProfitType.SelectedValue;
        //For Calculations

        if (txtProfitAmt.Text == "")
        {
            txtProfitAmt.Text = "0";
        }
        if (lblBuyCost.Text == "")
        {
            lblBuyCost.Text = "0";
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
        if (txtClntTds.Text == "")
        {
            txtClntTds.Text = "0";
        }

        if (ddlProfitType.SelectedValue == "0")
        {
            objClassDet.nProfitPercent = "0";
            objClassDet.nProfitAmount = txtProfitAmt.Text.Trim();
            ClntSC = double.Parse(txtProfitAmt.Text.Trim());
        }
        else
        {
            objClassDet.nProfitPercent = txtProfitAmt.Text.Trim();
            ClntSC = double.Parse(lblBuyCost.Text) * double.Parse(txtProfitAmt.Text) / 100;
            objClassDet.nProfitAmount = (ClntSC).ToString();
        }

        objClassDet.nDiscount = txtDiscount.Text.Trim();
        objClassDet.nSellingCost = lblSelleing.Text.Trim();
        objClassDet.sRemarks = validation.stringToDBString(txtRemarks.Text.Trim());
        objClassDet.nSupScType = ddlSupScType.SelectedValue;
        if (ddlSupScType.SelectedValue == "0")
        {
            objClassDet.nSupScpercent = "0";
            objClassDet.nSupSCAmount = txtSupSc.Text.Trim();
            SupSC = double.Parse(txtSupSc.Text.Trim());
        }
        else
        {
            objClassDet.nSupScpercent = txtSupSc.Text.Trim();
            SupSC = double.Parse(lblBuyCost.Text) * double.Parse(txtSupSc.Text) / 100;
            objClassDet.nSupSCAmount = (SupSC).ToString();
        }
        if (chkSupTax.Checked)
        {
            objClassDet.bSupTax = "1";
        }
        else
        {
            objClassDet.bSupTax = "0";
        }
        objClassDet.nSupCGst = txtsupcgst.Text.Trim();
        objClassDet.nSupSGst = txtsupsgst.Text.Trim();
        objClassDet.nSupIGst = txtsupigst.Text.Trim();
        if (chkClntTax.Checked)
        {
            objClassDet.bClntTax = "1";
        }
        else
        {
            objClassDet.bClntTax = "0";
        }
        objClassDet.nClntCGst = txtClntCgst.Text.Trim();
        objClassDet.nClntSGst = txtClntSgst.Text.Trim();
        objClassDet.nClntIGst = txtClntIgst.Text.Trim();

        objClassDet.nSupTdsType = ddlSupTds.SelectedValue;
        if (ddlSupTds.SelectedValue == "0")
        {
            objClassDet.nSupTdsPercent = "0";
            objClassDet.nSupTdsAmount = txtSupTds.Text.Trim();
        }
        else
        {
            objClassDet.nSupTdsPercent = txtSupSc.Text.Trim();
            double SupTDS = SupSC * double.Parse(txtSupTds.Text) / 100;
            objClassDet.nSupTdsAmount = (SupTDS).ToString();
        }

        objClassDet.nClntTdsType = ddlClntTds.SelectedValue;
        if (ddlClntTds.SelectedValue == "0")
        {
            objClassDet.nClntTdsPercent = "0";
            objClassDet.nClntTdsAmount = txtClntTds.Text.Trim();

        }
        else
        {
            objClassDet.nClntTdsPercent = txtClntTds.Text.Trim();
            double ClntTds = ClntSC * double.Parse(txtClntTds.Text) / 100;
            objClassDet.nClntTdsAmount = (ClntTds).ToString();
        }

        objClassDet.nBasicAmt = txtBasicFare.Text.Trim();
        objClassDet.nSupOtrTax = txtOtherTax.Text.Trim();
        objClassDet.nSupComm = txtSupComm.Text.Trim();
        if (ddlProfitType.SelectedValue == "0")
        {
            objClassDet.nClntSc2Percent = "0";
            objClassDet.nClntSc2Amount = txtProfitAmt2.Text.Trim();
            ClntSC2 = double.Parse(txtProfitAmt2.Text.Trim());
        }
        else
        {
            objClassDet.nClntSc2Percent = txtProfitAmt2.Text.Trim();
            ClntSC2 = double.Parse(lblBuyCost.Text) * double.Parse(txtProfitAmt2.Text) / 100;
            objClassDet.nClntSc2Amount = (ClntSC2).ToString();
        }

        objClassDet.nClntOtrChrgs = txtOtherchrg.Text.Trim();
        objClassDet.nCityID = ddlCity.SelectedValue;
        objClassDet.nBookTypeID = ddlbookType.SelectedValue;
        objClassDet.sPaxNos = txtPaxNos.Text;
        objClassDet.nStatusID = ddlStatus.SelectedValue;
        objClassDet.nSupDiscount = txtSupDiscount.Text;
    }


    public void clrfieldDet()
    {
        txtReferenceNo.Text = "";
        // txtGuestName.Text = "";
        ddlHotelName.SelectedValue = "0";
        txtNationality.Text = "";
        ddlRoomType.SelectedValue = "0";
        txtMeal.Text = "";
        txtNoRoom.Text = "0";
        txtExtrabed.Text = "0";
        txtdtCheckIn.Text = "";
        txtdtCheckOut.Text = "";
        txtTotNight.Text = "0";
        txtRate.Text = "0";
        txtTotal.Text = "0";
        txtRemarks.Text = "";

        ddlSupScType.SelectedValue = "0";
        txtSupSc.Text = "";

        txtsupcgst.Text = "";
        txtsupsgst.Text = "";
        txtsupigst.Text = "";
        txtClntCgst.Text = "";
        txtClntSgst.Text = "";
        txtClntIgst.Text = "";
        ddlSupTds.SelectedValue = "0";
        txtSupTds.Text = "";
        ddlClntTds.SelectedValue = "0";
        txtClntTds.Text = "";
        txtBasicFare.Text = "";
        txtOtherTax.Text = "";
        txtSupComm.Text = "";
        txtProfitAmt2.Text = "";
        txtOtherchrg.Text = "";
        ddlCity.SelectedValue = "0";
        txtProfitAmt.Text = "";
        txtclntCost.Text = "";
        txtDiscount.Text = "";
        txtPaxNos.Text = "";
        ddlStatus.SelectedValue = "0";
        txtSupDiscount.Text = "";
        Session["Detid"] = "";
    }
    public void DetButtonVisible()
    {
        tblDet.Visible = true;
        tblGridDet.Visible = true;
        btnAdd.Visible = false;
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
            //  txtGuestName.Text = dt.Rows[0][3].ToString();
            ddlHotelName.SelectedValue = dt.Rows[0][4].ToString();
            txtNationality.Text = dt.Rows[0][5].ToString();
            ddlRoomType.SelectedValue = dt.Rows[0][6].ToString();
            txtMeal.Text = dt.Rows[0][7].ToString();
            txtNoRoom.Text = dt.Rows[0][8].ToString();
            txtExtrabed.Text = dt.Rows[0][9].ToString();
            txtdtCheckIn.Text = validation.TextToDate(dt.Rows[0][10].ToString());
            txtdtCheckOut.Text = validation.TextToDate(dt.Rows[0][11].ToString());
            txtTotNight.Text = dt.Rows[0][12].ToString();
            txtRate.Text = dt.Rows[0][13].ToString();
            lblBuyCost.Text = dt.Rows[0][14].ToString();
            txtTotal.Text = dt.Rows[0][14].ToString();
            ddlProfitType.SelectedValue = dt.Rows[0][15].ToString();
            if (ddlProfitType.SelectedValue == "1")
            {
                txtProfitAmt.Text = dt.Rows[0][16].ToString();
            }
            else
            {
                txtProfitAmt.Text = dt.Rows[0][17].ToString();
            }



            txtDiscount.Text = dt.Rows[0][18].ToString();
            txtSelleing.Text = dt.Rows[0][19].ToString();
            lblSelleing.Text = dt.Rows[0][19].ToString();
            txtRemarks.Text = dt.Rows[0][20].ToString();

            ddlSupScType.SelectedValue = dt.Rows[0][21].ToString();
            if (ddlSupScType.SelectedValue == "1")
            {
                txtSupSc.Text = dt.Rows[0][22].ToString();
            }
            else
            {
                txtSupSc.Text = dt.Rows[0][23].ToString();
            }

            if (dt.Rows[0][24].ToString() == "1")
            {
                chkSupTax.Checked = true;
            }
            else
            {
                chkSupTax.Checked = false;
            }
            txtsupcgst.Text = dt.Rows[0][25].ToString();
            txtsupsgst.Text = dt.Rows[0][26].ToString();
            txtsupigst.Text = dt.Rows[0][27].ToString();
            if (dt.Rows[0][28].ToString() == "1")
            {
                chkClntTax.Checked = true;
            }
            else
            {
                chkClntTax.Checked = false;
            }
            txtClntCgst.Text = dt.Rows[0][29].ToString();
            txtClntSgst.Text = dt.Rows[0][30].ToString();
            txtClntIgst.Text = dt.Rows[0][31].ToString();

            ddlSupTds.SelectedValue = dt.Rows[0][32].ToString();
            if (ddlSupTds.SelectedValue == "1")
            {
                txtSupTds.Text = dt.Rows[0][33].ToString();
            }
            else
            {
                txtSupTds.Text = dt.Rows[0][34].ToString();
            }

            ddlClntTds.SelectedValue = dt.Rows[0][35].ToString();
            if (ddlClntTds.SelectedValue == "1")
            {
                txtClntTds.Text = dt.Rows[0][36].ToString();
            }
            else
            {
                txtClntTds.Text = dt.Rows[0][37].ToString();
            }
            txtBasicFare.Text = dt.Rows[0][38].ToString();
            txtclntCost.Text = dt.Rows[0][38].ToString();
            txtOtherTax.Text = dt.Rows[0][39].ToString();
            txtSupComm.Text = dt.Rows[0][40].ToString();
            if (ddlProfitType.SelectedValue == "1")
            {
                txtProfitAmt2.Text = dt.Rows[0][41].ToString();
            }
            else
            {
                txtProfitAmt2.Text = dt.Rows[0][42].ToString();
            }
            txtOtherchrg.Text = dt.Rows[0][43].ToString();
            ddlCity.SelectedValue = dt.Rows[0][44].ToString();
            ddlbookType.SelectedValue = dt.Rows[0]["nBookTypeID"].ToString();
            txtPaxNos.Text = dt.Rows[0][46].ToString();
            ddlStatus.SelectedValue = dt.Rows[0][47].ToString();
            txtSupDiscount.Text = dt.Rows[0][48].ToString();
        }
    }

    public void btnVisibleDet()
    {
        btnAdd.Visible = true;
        //btnUpdate.Visible = false;
        //btnDelete.Visible = false;
        clrfieldDet();
    }

    public void DisableData()
    {
        //txtdtBooking.Enabled = false;
        ////Img4.Enabled = false;
        //ddlAgentID.Enabled = false;
        //ddlLocationID.Enabled = false;
        // ddlCompanyID.Enabled = false;
    }
    public void VisibleData()
    {
        txtdtBooking.Enabled = true;
        //Img4.Enabled = true;
        ddlAgentID.Enabled = true;
        ddlLocationID.Enabled = true;
        //   ddlCompanyID.Enabled = true;
    }

    public void displayGridDet()
    {
        try
        {
            objClassDet.sReferenceNo = Session["eid"].ToString();
            objClassDet.sGuestName = "0";
            objClassDet.sMeal = "0";
            objClassDet.sNationality = "0";
            objClassDet.dtCheckOut = "0";
            objClassDet.dtCheckIn = "";
            objClassDet.sPaxNos = "0";
            objClassDet.FillGrid(objClassDet, GridView2, "ShowDet", Session["eid"].ToString());
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


    //Guest Details
    public void GuestList()
    {
        if (Session["Detid"] == null)
        {
            Session["Detid"] = "0";
        }
        if (txtPaxNos.Text == "")
            txtPaxNos.Text = "0";

        //  DataTable dt = objHotelGuestList.viewData(objHotelGuestList, "show", Session["Detid"].ToString());
        DataTable dt = new DataTable();
        dt.Columns.Add("nHotelGustID");
        dt.Columns.Add("nHotelBookingDetID");
        dt.Columns.Add("sPaxName");
        dt.Columns.Add("sGender");
        dt.Columns.Add("sAge");
        dt.Columns.Add("bLead");

        //Max Hotel Guest Max Id
        DataTable dtMaxID = objHotelGuestList.viewData(objHotelGuestList, "ShowMaxID", "");
        // dt.Clear();
        int maxID = 0;
        if (dtMaxID.Rows.Count > 0)
        {
            maxID = int.Parse(dtMaxID.Rows[0]["sMaxID"].ToString());
        }

        for (int j = 0; j < double.Parse(txtPaxNos.Text); j++)
        {

            if (j == 0)
            {
                dt.Rows.Add(new object[] {
                    maxID,
                    j,
                    "",
                    "",
                    "",                     
                    "1"
                    });
            }
            else
            {
                dt.Rows.Add(new object[] {
                    maxID+1,
                    j,
                    "",
                    "",
                    "",                      
                    "0"
                    });



            }


        }

        rptPaxList.DataSource = dt;
        rptPaxList.DataBind();
    }
    public void paraGuest()
    {
        //objHotelGuest.nHotelBookingDetID = Session["Detid"].ToString();
        //objHotelGuest.sPaxName1 = validation.stringToDBString(txtPaxtName1.Text.Trim());
        //objHotelGuest.sGender1 = validation.stringToDBString(ddlGender1.SelectedValue);
        //objHotelGuest.sAge1 = validation.stringToDBString(txtAge1.Text.Trim());
        //objHotelGuest.sPaxName2 = validation.stringToDBString(txtPaxtName2.Text.Trim());
        //objHotelGuest.sGender2 = validation.stringToDBString(ddlGender2.SelectedValue);
        //objHotelGuest.sAge2 = validation.stringToDBString(txtAge2.Text.Trim());
        //objHotelGuest.sPaxName3 = validation.stringToDBString(txtPaxtName3.Text.Trim());
        //objHotelGuest.sGender3 = validation.stringToDBString(ddlGender3.SelectedValue);
        //objHotelGuest.sAge3 = validation.stringToDBString(txtAge3.Text.Trim());
        //objHotelGuest.sPaxName4 = validation.stringToDBString(txtPaxtName4.Text.Trim());
        //objHotelGuest.sGender4 = validation.stringToDBString(ddlGender4.SelectedValue);
        //objHotelGuest.sAge4 = validation.stringToDBString(txtAge4.Text.Trim());
    }
    public void AddGuestList()
    {
        objHotelGuestList.nHotelBookingDetID = Session["Detid"].ToString();

        foreach (RepeaterItem item in rptPaxList.Items)
        {


            if (rptPaxList.Items.Count > 0)
            {
                HiddenField hdnID = item.FindControl("hdnGuestID") as HiddenField;
                HiddenField nHotelBookingDetID = item.FindControl("nHotelBookingDetID") as HiddenField;
                HiddenField hdnLead = item.FindControl("hdnLead") as HiddenField;
                TextBox txtPaxtName = item.FindControl("txtPaxtName1") as TextBox;
                DropDownList ddlGender = item.FindControl("ddlGender1") as DropDownList;
                TextBox txtAge = item.FindControl("txtAge1") as TextBox;



                DataTable dt = objHotelGuestList.viewData(objHotelGuestList, "show", hdnID.Value);
                if (dt.Rows.Count > 0)
                {
                    objHotelGuestList.nHotelGustID = dt.Rows[0][0].ToString();
                    objHotelGuestList.nHotelBookingDetID = dt.Rows[0][1].ToString();
                    objHotelGuestList.sPaxName = txtPaxtName.Text;
                    objHotelGuestList.sGender = ddlGender.SelectedValue;
                    objHotelGuestList.sAge = txtAge.Text;
                    objHotelGuestList.bLead = hdnLead.Value;
                    var xyz = objHotelGuestList.User_Operation(objHotelGuestList, "edit");

                    if (hdnLead.Value == "1")
                    {
                        objClassDet.nHotelBookingDetID = Session["Detid"].ToString();
                        objClassDet.sGuestName = txtPaxtName.Text;
                        var xyz1 = objClassDet.User_Operation(objClassDet, "UpdateGuestName");
                    }
                }
                else
                {

                    objHotelGuestList.nHotelBookingDetID = Session["Detid"].ToString();
                    objHotelGuestList.sPaxName = txtPaxtName.Text;
                    objHotelGuestList.sGender = ddlGender.SelectedValue;
                    objHotelGuestList.sAge = txtAge.Text;
                    objHotelGuestList.bLead = hdnLead.Value;

                    var xyz = objHotelGuestList.User_Operation(objHotelGuestList, "add");

                    if(hdnLead.Value=="1")
                    {
                        objClassDet.nHotelBookingDetID = Session["Detid"].ToString();
                        objClassDet.sGuestName = txtPaxtName.Text;
                        var xyz1 = objClassDet.User_Operation(objClassDet, "UpdateGuestName");
                    }
                }




            }



        }
    }
    public void GetFormDataGuest()
    {
        objHotelGuestList.FillReapter(objHotelGuestList, rptPaxList, "show", Session["Detid"].ToString());
        //if (dt.Rows.Count > 0)
        //{
        //    Session["Gid"] = dt.Rows[0][0].ToString();
        //txtPaxtName1.Text = dt.Rows[0][2].ToString();
        //ddlGender1.SelectedValue = dt.Rows[0][3].ToString();
        //txtAge1.Text = dt.Rows[0][4].ToString();
        //txtPaxtName2.Text = dt.Rows[0][5].ToString();
        //ddlGender2.SelectedValue = dt.Rows[0][6].ToString();
        //txtAge2.Text = dt.Rows[0][7].ToString();
        //txtPaxtName3.Text = dt.Rows[0][8].ToString();
        //ddlGender3.SelectedValue = dt.Rows[0][9].ToString();
        //txtAge3.Text = dt.Rows[0][10].ToString();
        //txtPaxtName4.Text = dt.Rows[0][11].ToString();
        //ddlGender4.SelectedValue = dt.Rows[0][12].ToString();
        //txtAge4.Text = dt.Rows[0][13].ToString();
        // }
    }

    public void clrfieldGuest()
    {
        //txtPaxtName1.Text = "";
        //txtAge1.Text = "";
        //txtPaxtName2.Text = "";
        //txtAge2.Text = "";
        //txtPaxtName3.Text = "";
        //txtAge3.Text = "";
        //txtPaxtName4.Text = "";
        //txtAge4.Text = "";
        Session["Gid"] = "";
    }

    protected void btnAddDet_Click(object sender, EventArgs e)
    {
        try
        {
            lblmsg.Text = "";
            if (Session["thotel"].ToString() == ViewState["thotel"].ToString())
            {
                paraDet();
                var xyz = objClassDet.User_Operation(objClassDet, "add");


                var strArr1 = xyz.Split(',');
                if (strArr1[0] == "1")
                {
                    string HotelDetID = strArr1[2].ToString();
                    Session["Detid"] = HotelDetID;
                    AddGuestList();
                    //paraGuest();
                    //var xyz1 = objHotelGuest.User_Operation(objHotelGuest, "add");
                    //  InsertGuestDetails();
                }
                DetButtonVisible();
                displayGridDet();
                //  clrfieldDet();
                valobj.showMsg(xyz, lblmsg);
                string aa = Server.UrlEncode(System.DateTime.Now.ToString());
                Session["thotel"] = aa;
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
            Label HotelBookId = (Label)GridView2.Rows[row].Cells[0].FindControl("lblhotelbookid");
            Session["eid"] = HotelBookId.Text;
            btnAddDet.Visible = false;
            btnUpdateDet.Visible = true;
            DisableData();

            tblmain.Visible = true;
            tblDet.Visible = true;
            tblGridDet.Visible = true;
            tblGrd.Visible = false;
            //btnDeleteDet.Visible = true;
            //DetButtonVisible();
            objHotelGuestList.FillReapter(objHotelGuestList, rptPaxList, "Show", IDDet.Text);
            GetFormDataDet();
            displayGridDet();
            if (ddlbookType.SelectedValue == "2")
            {
                tblrefund.Visible = true;

                GetFormDataRefund();

                txtRate_TextChanged(this, e);
            }
            else
            {
                tblrefund.Visible = false;
            }
            lblmsg.Text = "";

            txtPaxNos.Enabled = false;

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
            //objClass.nHotelBookingID = Session["eid"].ToString();
            //var abc = objClass.User_Operation(objClass, "edit");
            paraDet();
            objClassDet.nHotelBookingDetID = Session["Detid"].ToString();
            var abc1 = objClassDet.User_Operation(objClassDet, "edit");

            AddGuestList();
            //paraGuest();

            //DataTable dt = objHotelGuest.viewData(objHotelGuest, "show", Session["eid"].ToString());
            //if (dt.Rows.Count > 0)
            //{
            //    objHotelGuest.nHotelBookingDetID = Session["eid"].ToString();
            //    var abc2 = objHotelGuest.User_Operation(objHotelGuest, "edit");
            //}
            //else
            //{
            //    var abc2 = objHotelGuest.User_Operation(objHotelGuest, "add");
            //}
            // InsertGuestDetails();
            if (ddlbookType.SelectedValue == "2")
            {
                RefundSave();
            }
            //GetFormData();
            GetFormDataDet();
          //  GetFormDataGuest();
            DetButtonVisible();
            displayGridDet();
            txtPaxNos.Enabled = true;
            valobj.showMsg(abc1, lblmsg);
            
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
        objClassDet.nHotelBookingDetID = Session["Detid"].ToString();
        var vres = objClassDet.User_Operation(objClassDet, "DeActive");
        valobj.showMsg(vres, lblmsg);
        DetButtonVisible();
        displayGridDet();

    }

    protected void lnkAdd_Click(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        tblmain.Visible = true;

        tblDet.Visible = true;
        tblGrd.Visible = false;
        tblGridDet.Visible = false;
        PnlPayment.Visible = false;
        clrfield();
        clrfieldDet();

        btnVisible();
        VisibleData();
        txtdtBooking.Text = validation.fillDate();
        Booking_Generate();
        txtPaxNos.Enabled = true;
        txtPaxNos_TextChanged(this, e);
        Session["eid"] = "";
        Session["Detid"] = "";
        Session["dtGuest"] = null;
    }
    protected void lnkList_Click(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        tblmain.Visible = false;
        tblGrd.Visible = true;
        PnlPayment.Visible = false;
        Session["eid"] = "";
        Session["Detid"] = "";
        Session["dtGuest"] = null;
        displayGrid();
        
        txtPaxNos.Enabled = true;
        objAccount.ddlOperation(objAccount, "ddlCustomer", "", ddlSClient);
        objBranch.ddlOperation(objBranch, "Show", "", ddlSLoc);
        objAccount.ddlOperation(objAccount, "ddlVendor", "", ddlSSup);
        objClass.ddlOperation(objClass, "Show", "", ddlInvoiceNo);
        Response.Redirect("thotel_list.aspx");
    }


    protected void txtdtCheckOut_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string chkIn = validation.dateToText(txtdtCheckIn.Text.Trim());
            string chkOut = validation.dateToText(txtdtCheckOut.Text.Trim());
            if (chkIn != "" && chkOut != "")
            {

                txtTotNight.Text = noofnight(chkIn, chkOut);
            }
            txtRate_TextChanged(this, e);
            txtNoRoom.Focus();
        }
        catch
        {

        }
        finally
        {

        }
    }
    protected void txtdtCheckIn_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string chkIn = validation.dateToText(txtdtCheckIn.Text.Trim());
            string chkOut = validation.dateToText(txtdtCheckOut.Text.Trim());
            if (chkIn != "" && chkOut != "")
            {

                txtTotNight.Text = noofnight(chkIn, chkOut);
            }
            txtRate_TextChanged(this, e);
            txtdtCheckOut.Focus();
        }
        catch
        {

        }
        finally
        {

        }
    }
    public string noofnight(string Checkin, string Checkout)
    {
        System.DateTime firstDate = new System.DateTime(int.Parse(Checkin.Substring(0, 4)), int.Parse(Checkin.Substring(4, 2)), int.Parse(Checkin.Substring(6, 2)));
        System.DateTime secondDate = new System.DateTime(int.Parse(Checkout.Substring(0, 4)), int.Parse(Checkout.Substring(4, 2)), int.Parse(Checkout.Substring(6, 2)));
        //firstDate = firstDate.AddDays(2);
        System.TimeSpan diff = secondDate.Subtract(firstDate);
        System.TimeSpan diff1 = secondDate - firstDate;

        String noofnights = (secondDate - firstDate).TotalDays.ToString();

        return noofnights;
    }



    protected void txtRate_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (txtRate.Text == "")
            {
                txtRate.Text = "0";
            }
            if (txtNoRoom.Text == "")
            {
                txtNoRoom.Text = "0";
            }
            if (txtTotNight.Text == "")
            {
                txtTotNight.Text = "0";
            }
            if (txtExtrabed.Text == "")
            {
                txtExtrabed.Text = "0";
            }
            if (txtTotal.Text == "")
            {
                txtTotal.Text = "0";
            }
            if (txtProfitAmt.Text == "")
            {
                txtProfitAmt.Text = "0";
            }
            if (txtSelleing.Text == "")
            {
                txtSelleing.Text = "0";
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
            if (txtClntTds.Text == "")
            {
                txtClntTds.Text = "0";
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
            if (txtSupSc.Text == "")
            {
                txtSupSc.Text = "0";
            }
            if (txtSupTds.Text == "")
            {
                txtSupTds.Text = "0";
            }
            if (txtClntTds.Text == "")
            {
                txtClntTds.Text = "0";
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
            if (txtBasicFare.Text == "")
            {
                txtBasicFare.Text = "0";
            }
            if (txtOtherTax.Text == "")
            {
                txtOtherTax.Text = "0";
            }
            if (txtSupComm.Text == "")
            {
                txtSupComm.Text = "0";
            }
            if (txtProfitAmt2.Text == "")
            {
                txtProfitAmt2.Text = "0";
            }
            if (txtOtherchrg.Text == "")
            {
                txtOtherchrg.Text = "0";
            }
            if (txtMeal.Text == "")
            {
                txtMeal.Text = "0";
            }
            if (txtSupDiscount.Text == "")
            {
                txtSupDiscount.Text = "0";
            }

            //GST Calculation
            GstCal();

            double SupSC = 0; double SupTDS = 0; double ClntSC = 0; double ClntSC2 = 0; double ClntTDS = 0; double subTot = 0;

            if (ddlSupScType.SelectedValue == "0")
            {
                SupSC = double.Parse(txtSupSc.Text);
            }
            else
            {
                SupSC = subTot * double.Parse(txtSupSc.Text) / 100;

            }
            if (ddlSupTds.SelectedValue == "0")
            {
                SupTDS = double.Parse(txtSupTds.Text);
            }
            else
            {
                SupTDS = SupSC * double.Parse(txtSupTds.Text) / 100;

            }
            txtBasicFare.Text = ((double.Parse(txtRate.Text) * double.Parse(txtNoRoom.Text) * double.Parse(txtTotNight.Text)) + double.Parse(txtExtrabed.Text) + double.Parse(txtMeal.Text)).ToString();
            txtclntCost.Text = txtBasicFare.Text;
            if (ddlbookType.SelectedValue == "2")
            {
                string SupCost = ((double.Parse(txtBasicFare.Text)) + SupSC - SupTDS - (double.Parse(txtSupDiscount.Text)) + (double.Parse(txtOtherTax.Text)) - (double.Parse(txtSupComm.Text)) + (double.Parse(txtsupcgst.Text)) + (double.Parse(txtsupsgst.Text)) + (double.Parse(txtsupigst.Text))).ToString();

                txtTotal.Text = (double.Parse(SupCost) - double.Parse(txtRefundAmt.Text) - double.Parse(txtRfnCGst.Text) - double.Parse(txtRfnSGst.Text) - double.Parse(txtRfnIGst.Text)).ToString();
            }
            else
            {
                txtTotal.Text = ((double.Parse(txtBasicFare.Text)) + SupSC + (double.Parse(txtOtherTax.Text)) - (double.Parse(txtSupComm.Text)) -
                SupTDS - (double.Parse(txtSupDiscount.Text)) + (double.Parse(txtsupcgst.Text)) + (double.Parse(txtsupsgst.Text)) + (double.Parse(txtsupigst.Text))).ToString();
            }

            lblBuyCost.Text = ((double.Parse(txtBasicFare.Text)) + SupSC - SupTDS - (double.Parse(txtSupDiscount.Text)) + (double.Parse(txtOtherTax.Text)) - (double.Parse(txtSupComm.Text)) + (double.Parse(txtsupcgst.Text)) + (double.Parse(txtsupsgst.Text)) +
            (double.Parse(txtsupigst.Text))).ToString();


            if (ddlProfitType.SelectedValue == "0")
            {
                ClntSC = double.Parse(txtProfitAmt.Text);
                ClntSC2 = double.Parse(txtProfitAmt2.Text);
            }
            else
            {
                ClntSC = double.Parse(txtTotal.Text) * double.Parse(txtProfitAmt.Text) / 100;
                ClntSC2 = double.Parse(txtTotal.Text) * double.Parse(txtProfitAmt2.Text) / 100;

            }
            if (ddlClntTds.SelectedValue == "0")
            {
                ClntTDS = double.Parse(txtClntTds.Text);
            }
            else
            {
                ClntTDS = ClntSC * double.Parse(txtClntTds.Text) / 100;

            }

            if (ddlbookType.SelectedValue == "2")
            {
                //String ClientCost = ((double.Parse(lblSupCost.Text)) + double.Parse(ClntSC) + double.Parse(ClntSC2) - double.Parse(ClntTDS) - double.Parse(txtDiscount.Text) + (double.Parse(txtClntCgst.Text)) + (double.Parse(txtClntSgst.Text)) + (double.Parse(txtClntIgst.Text))).ToString();
                //txtTotal.Text = (double.Parse(ClientCost) - double.Parse(txtRefundAmt.Text) - double.Parse(txtRfnCGst.Text) - double.Parse(txtRfnSGst.Text) - double.Parse(txtRfnIGst.Text) - double.Parse(txtrfnSC.Text)).ToString();
                txtSelleing.Text = "-" + (double.Parse(txtTotal.Text) - double.Parse(txtrfnSC.Text)).ToString();

            }
            else
            {
                txtSelleing.Text = ((double.Parse(txtTotal.Text) + ClntSC + ClntSC2 + -ClntTDS + (double.Parse(txtOtherchrg.Text)) + (double.Parse(txtClntCgst.Text)) + (double.Parse(txtClntSgst.Text)) + (double.Parse(txtClntIgst.Text)) - double.Parse(txtDiscount.Text))).ToString();
            }

            lblSelleing.Text = ((double.Parse(lblBuyCost.Text) + ClntSC + ClntSC2 - ClntTDS + (double.Parse(txtOtherchrg.Text)) + (double.Parse(txtClntCgst.Text)) + (double.Parse(txtClntSgst.Text)) + (double.Parse(txtClntIgst.Text)) - double.Parse(txtDiscount.Text))).ToString();

            txtExtrabed.Focus();

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
        if (txtRate.Text == "0")
        {
            txtRate.Text = "";
        }
        if (txtNoRoom.Text == "0")
        {
            txtNoRoom.Text = "";
        }
        if (txtTotNight.Text == "0")
        {
            txtTotNight.Text = "";
        }
        if (txtExtrabed.Text == "0")
        {
            txtExtrabed.Text = "";
        }
        if (txtTotal.Text == "0")
        {
            txtTotal.Text = "";
        }
        if (txtProfitAmt.Text == "0")
        {
            txtProfitAmt.Text = "";
        }
        if (txtSelleing.Text == "0")
        {
            txtSelleing.Text = "";
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
        if (txtSupSc.Text == "0")
        {
            txtSupSc.Text = "";
        }
        if (txtSupTds.Text == "0")
        {
            txtSupTds.Text = "";
        }
        if (txtClntTds.Text == "0")
        {
            txtClntTds.Text = "";
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
        if (txtClntTds.Text == "0")
        {
            txtClntTds.Text = "";
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
        if (txtBasicFare.Text == "0")
        {
            txtBasicFare.Text = "";
        }
        if (txtOtherTax.Text == "0")
        {
            txtOtherTax.Text = "";
        }
        if (txtSupComm.Text == "0")
        {
            txtSupComm.Text = "";
        }
        if (txtProfitAmt2.Text == "0")
        {
            txtProfitAmt2.Text = "";
        }
        if (txtOtherchrg.Text == "0")
        {
            txtOtherchrg.Text = "";
        }
        if (txtMeal.Text == "0")
        {
            txtMeal.Text = "";
        }
    }
    protected void txtNoRoom_TextChanged(object sender, EventArgs e)
    {
        try
        {
            txtRate_TextChanged(this, e);
            txtRate.Focus();

        }
        catch
        {

        }
        finally
        {

        }
    }
    protected void txtTotNight_TextChanged(object sender, EventArgs e)
    {
        try
        {

            txtRate_TextChanged(this, e);
            txtRate.Focus();


        }
        catch
        {

        }
        finally
        {

        }
    }
    protected void txtExtrabed_TextChanged(object sender, EventArgs e)
    {
        try
        {

            txtRate_TextChanged(this, e);
            txtSupSc.Focus();

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
            txtRate_TextChanged(this, e);
            txtProfitAmt2.Focus();

        }
        catch
        {

        }
        finally
        {

        }
    }

    protected void txtDiscount_TextChanged(object sender, EventArgs e)
    {
        try
        {
            txtRate_TextChanged(this, e);
            txtOtherchrg.Focus();
        }
        catch
        {

        }
        finally
        {

        }
    }

    //protected void SaveGuest_Click(object sender, EventArgs e)
    //{
    //    if (Session["thotel"].ToString() == ViewState["thotel"].ToString())
    //    {
    //        DataTable dtGuest = new DataTable();
    //        if (Session["dtGuest"] == null)
    //        {
    //            dtGuest.Columns.Add("nHotelbookingGuestID");
    //            dtGuest.Columns.Add("sGuestName");


    //        }
    //        else
    //        {
    //            dtGuest = (DataTable)Session["dtGuest"];
    //        }

    //        DataRow dr = dtGuest.NewRow();
    //        dtGuest.Rows.Add(0, txtGestName.Text);
    //        Session["dtGuest"] = dtGuest;
    //        GridView3.DataSource = dtGuest;
    //        GridView3.DataBind();

    //        string aa = Server.UrlEncode(System.DateTime.Now.ToString());
    //        Session["thotel"] = aa;
    //    }

    //}
    //protected void btnGuestEdit_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        Session["Detid"] = "";
    //        LinkButton thisbtn = (LinkButton)sender;
    //        GridViewRow thisgrdR = (GridViewRow)thisbtn.Parent.Parent;
    //        int row = thisgrdR.RowIndex;


    //        //DataTable dtGuest = (DataTable)Session["dtGuest"];
    //        //dtGuest.Rows.RemoveAt(row);
    //        //GridView3.DataSource = dtGuest;
    //        //GridView3.DataBind();
    //        //Session["dtGuest"] = dtGuest;

    //        Label ID = (Label)GridView3.Rows[row].Cells[0].FindControl("lblIdGuest");
    //        objHotelGuest.nHotelbookingGuestID = ID.Text;

    //        var vres = objHotelGuest.User_Operation(objHotelGuest, "DeActive");

    //        displayGuestGrid();
    //        //  DeleteDetRecord();
    //    }
    //    catch (Exception ex)
    //    {
    //        valobj.showMsg(ex.Message, "FAIL", lblmsg);
    //    }
    //}
    //public void displayGuestGrid()
    //{
    //    try
    //    {
    //        Session["dtGuest"] = null;
    //        DataTable dt = objHotelGuest.viewData(objHotelGuest, "Show", Session["eid"].ToString());
    //        if (dt.Rows.Count > 0)
    //        {
    //            GridView3.DataSource = dt;
    //            GridView3.DataBind();


    //            DataTable dtGuest = new DataTable();

    //            dtGuest.Columns.Add("nHotelbookingGuestID");
    //            dtGuest.Columns.Add("sGuestName");

    //            for (int i = 0; i < dt.Rows.Count; i++)
    //            {
    //                DataRow dr = dtGuest.NewRow();
    //                dtGuest.Rows.Add(dt.Rows[i]["nHotelbookingGuestID"].ToString(), dt.Rows[i]["sGuestName"].ToString());
    //            }

    //            Session["dtGuest"] = dtGuest;



    //        }

    //    }
    //    catch (Exception ex)
    //    {
    //        valobj.showMsg(ex.Message, lblmsg);
    //    }
    //}

    protected void chkClntTax_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            txtRate_TextChanged(this, e);
            
        }
        catch
        {

        }
        finally
        {

        }
    }
    protected void txtSupSc_TextChanged(object sender, EventArgs e)
    {
        try
        {
            txtRate_TextChanged(this, e);
            txtOtherTax.Focus();

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
            txtRate_TextChanged(this, e);
            
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
            }
            else
            {

                if (ddlSupScType.SelectedValue == "0")
                {
                    if (SupState == CompState)
                    {
                        txtsupigst.Text = "0";
                        txtsupcgst.Text = ((double.Parse(txtSupSc.Text)) * (double.Parse(Supsgst)) / 100).ToString();
                        txtsupsgst.Text = ((double.Parse(txtSupSc.Text)) * (double.Parse(Supcgst)) / 100).ToString();
                    }
                    else
                    {
                        txtsupigst.Text = ((double.Parse(txtSupSc.Text)) * (double.Parse(Supigst)) / 100).ToString();
                        txtsupcgst.Text = "0";
                        txtsupsgst.Text = "0";
                    }
                }
                else
                {

                    double Profit = double.Parse(txtTotal.Text) * double.Parse(txtSupSc.Text) / 100;
                    if (SupState == CompState)
                    {
                        txtsupigst.Text = "0";
                        txtsupcgst.Text = (((Profit)) * (double.Parse(Supsgst)) / 100).ToString();
                        txtsupsgst.Text = (((Profit)) * (double.Parse(Supcgst)) / 100).ToString();
                    }
                    else
                    {
                        txtsupigst.Text = ((Profit) * (double.Parse(Supigst)) / 100).ToString();
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
    protected void txtHotelBookingNo_TextChanged(object sender, EventArgs e)
    {
        DataTable dt = objClass.viewData(objClass, "FillDataHotel", txtHotelBookingNo.Text);
        if (dt.Rows.Count > 0)
        {
            Session["eid"] = dt.Rows[0]["nHotelBookingID"].ToString();
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

    protected void txtOtherTax_TextChanged(object sender, EventArgs e)
    {
        try
        {
            txtRate_TextChanged(this, e);
            txtSupTds.Focus();

        }
        catch
        {

        }
        finally
        {

        }
    }
    protected void txtSupComm_TextChanged(object sender, EventArgs e)
    {
        try
        {
            txtRate_TextChanged(this, e);
            txtSupDiscount.Focus();

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
            txtRate_TextChanged(this, e);
            txtClntTds.Focus();

        }
        catch
        {

        }
        finally
        {

        }
    }
    protected void txtOtherchrg_TextChanged(object sender, EventArgs e)
    {
        try
        {
            txtRate_TextChanged(this, e);
            txtRemarks.Focus();

        }
        catch
        {

        }
        finally
        {

        }
    }
    protected void txtMeal_TextChanged(object sender, EventArgs e)
    {
        try
        {
            txtRate_TextChanged(this, e);
            txtdtCheckIn.Focus();

        }
        catch
        {

        }
        finally
        {

        }
    }
    protected void txtSupDiscount_TextChanged(object sender, EventArgs e)
    {
        txtRate_TextChanged(this, e);
        txtProfitAmt.Focus();
    }
    protected void txtSupTds_TextChanged(object sender, EventArgs e)
    {
        txtRate_TextChanged(this, e);
        txtSupComm.Focus();
    }
    //Refund


    public void paraRefund()
    {
        objRefund.nHotelBookingDetID = Session["Detid"].ToString();
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

        objRefund.nSupplierRefund = txtTotal.Text;
        objRefund.nClientRefund = Math.Abs(double.Parse(txtSelleing.Text)).ToString();
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
            txtTotal.Text = dt.Rows[0]["nSupplierRefund"].ToString();
            txtSelleing.Text = dt.Rows[0]["nClientRefund"].ToString();
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


                objRefund.nHotelRefundID = dt.Rows[0][0].ToString();
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
            txtRate_TextChanged(this, e);
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
            txtRate_TextChanged(this, e);
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
            txtRate_TextChanged(this, e);
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
        DataTable dtRefund = objRefund.viewData(objRefund, "show", Session["eid"].ToString());
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
        objClassDet.sReferenceNo = ddlInvoiceNo.SelectedValue;
        objClassDet.sGuestName = ddlSClient.SelectedValue;
        objClassDet.sMeal = ddlSSup.SelectedValue;
        objClassDet.sNationality = ddlSLoc.SelectedValue;
        objClassDet.dtCheckOut = ddlSBookType.SelectedValue;
        objClassDet.dtCheckIn = validation.dateToText(txtSdtBooking.Text);
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

    protected void txtPaxNos_TextChanged(object sender, EventArgs e)
    {
        GuestList();
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

        txtPayRemarks.Text = "Hotel  payment for invoice no.: " + InvNo.Text;
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
        txtPayRemarks.Text = "Hotel payment for invoice no.: " + txtHotelBookingNo.Text;
        txtPayInv.Text = txtHotelBookingNo.Text;
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
        objHotelPay.sPayfor = "Hotels";
        objHotelPay.FillGrid(objHotelPay, GridPay, "ShowPaymentsModule", Session["eid"].ToString());
    }
    public void paymentPara()
    {
        objHotelPay.nPaymentModeID = ddlPayVoucherType.SelectedValue;
        objHotelPay.nCashAccountID = ddlPaymentAccount.SelectedValue;
        objHotelPay.dtPayment = validation.dateToText(txtdtpayment.Text);
        objHotelPay.sVoucherNo = txtPayVoucherNo.Text;
        objHotelPay.nTotAmount = txtPayAmount.Text;
        objHotelPay.nAgentID = lblAgent.Text;
        objHotelPay.sRemarks = txtPayRemarks.Text;
        objHotelPay.sPayfor = "Hotels";

        //Detail Table
        objHotelPayDet.nInvoiceID = Session["eid"].ToString();
        objHotelPayDet.sInvoiceNo = txtPayInv.Text;
        objHotelPayDet.dtInvoiceDate = lblInvoiceDate.Text;
        objHotelPayDet.nAmount = txtPayAmount.Text; ;

        objHotelPayDet.sRemarks = txtPayRemarks.Text;
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
        DataTable dt = objHotelPayDet.viewData(objHotelPayDet, "GetDataTravel", Session["PayDetid"].ToString());
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
        if (Session["thotel"].ToString() == ViewState["thotel"].ToString())
        {
            paymentPara();

            if (Session["Payid"] == null || Session["Payid"] == "")
            {
                var abc = objHotelPay.User_Operation(objHotelPay, "add");
                var strArr = abc.Split(',');
                if (strArr[0] == "1")
                {
                    string PayID = strArr[2].ToString();
                    Session["Payid"] = PayID;
                    objHotelPayDet.nPaymentReceiveID = PayID;
                    var abc1 = objHotelPayDet.User_Operation(objHotelPayDet, "add");
                }
                valobj.showMsg(abc, lblmsg);


            }
            else
            {
                //Upodate Main Table
                objHotelPay.nPaymentReceiveID = Session["Payid"].ToString();
                var abc = objHotelPay.User_Operation(objHotelPay, "edit");

                //Upodate Detail Table
                objHotelPayDet.nPaymentReceiveDetID = Session["PayDetid"].ToString();
                objHotelPayDet.nPaymentReceiveID = Session["Payid"].ToString();
                var abc1 = objHotelPayDet.User_Operation(objHotelPayDet, "edit");

                valobj.showMsg(abc, lblmsg);
                Session["Payid"] = "";
                Session["PayDetid"] = "";

            }
            GetPaidDetails();
            objClass.nHotelBookingID = Session["eid"].ToString();
            var xyz = objClass.User_Operation(objClass, "bPaidEdit");

            GetBalance();
            Payclrfield();
            DisplayPaymentGrid();
            PayVoucher_Generate();

        }



        string aa = Server.UrlEncode(System.DateTime.Now.ToString());
        Session["thotel"] = aa;

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
        objHotelPay.nPaymentReceiveID = Session["Payid"].ToString();
        var vres = objHotelPay.User_Operation(objHotelPay, "DeActive");
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
        DataTable dt = objHotelPay.viewData(objHotelPay, "PVN", validation.dateToText(txtdtpayment.Text));
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
            Response.Redirect("PaymentReceipt/rptpay_receipt_inv.aspx?Detid=" + IDDet.Text + "&sPayfor=Hotels");
        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, "FAIL", lblmsg);
        }
    }
    protected void btnPaymentReceipt_Click(object sender, EventArgs e)
    {
        Response.Redirect("PaymentReceipt/rptpay_receipt_inv.aspx?id=" + Session["eid"].ToString() + "&sPayfor=Hotels");
    }
    protected void ddlSupplier_SelectedIndexChanged(object sender, EventArgs e)
    {
        objAccount.ddlOperation(objAccount, "ddlCustomer", ddlSupplier.SelectedValue, ddlAgentID);
    }
    
}
