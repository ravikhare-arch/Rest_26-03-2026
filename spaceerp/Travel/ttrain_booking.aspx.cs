using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Transcation_bus_booking : System.Web.UI.Page
{
    ttrainbooking_Class objClass = new ttrainbooking_Class();
    mrail_stations_Class objRailStn = new mrail_stations_Class();
    ttrainbooking_det_Class objClassDet = new ttrainbooking_det_Class();
    ttrain_passanger_Class objPassanger = new ttrain_passanger_Class();
    ttrainrefund_Class objRefund = new ttrainrefund_Class();
    magent_Class objAgent = new magent_Class();
    mCountry_Class objCountry = new mCountry_Class();
    mcompany_Class objcompany = new mcompany_Class();

  //  mlocation_Class objBranch = new mlocation_Class();

    mmain_account_Class objAccount = new mmain_account_Class();
    msupgst_Class objSupGst = new msupgst_Class();
    mclientgst_Class objClntGst = new mclientgst_Class();
    tpayments_receive_Class objTrainPay = new tpayments_receive_Class();
    tpayments_receivedet_Class objTrainPayDet = new tpayments_receivedet_Class();

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
                Session["tTrain_booking"] = aa;
                objAccount.ddlOperation(objAccount, "ddlCustomer", "", ddlAgentID);
                objBranch.ddlOperation(objBranch, "Showddl", "", ddlLocationID);
                objAccount.ddlOperation(objAccount, "ddlVendor", "", ddlSupplier);
                objRailStn.ddlOperation(objRailStn, "Showddl", "", ddlFromID);
                objRailStn.ddlOperation(objRailStn, "Showddl", "", ddlToID);
                objAccount.ddlOperation(objAccount, "ddlVendor", "", ddlSupplier);

                tblmain.Visible = true;
                tblDet.Visible = true;
                tblGrd.Visible = false;
                PnlPayment.Visible = false;
                displayGrid();
                btnVisible();
                txtdtTrainBooking.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
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
                //if (GridView2.Rows.Count < 25)
                //{
                //    ddlPageSizeDet.Visible = false;
                //    lblpgs.Visible = false;
                //}
                //else
                //{
                //    ddlPageSizeDet.Visible = true;
                //    lblpgs.Visible = true;
                //}

                if (Session["TECid"] != null && Session["TECid"] != "")
                {
                    string eid = Session["TECid"].ToString();
                    Session["eid"] = eid;
                    Session["TECid"] = "";
                    GetFormData();
                    GetFormDataDet();
                    btnAdd.Visible = false;
                    btnAddDet.Visible = false;
                    btnUpdateDet.Visible = true;
                    btnPrint.Visible = true;
                    btnPaymentHistory.Visible = true;
                    DisableData();
                }
                 var ID = Request.QueryString["ID"];
                 if (!string.IsNullOrEmpty(ID))
                 {
                     Session["eid"] = ID;

                     btnAdd.Visible = false;
                     btnPrint.Visible = true;
                     btnPaymentHistory.Visible = true;
                     //btnDelete.Visible = true;
                     GetFormData();
                     GetFormDataDet();
                     GetFormDataPassanger();
                     if (ddlbookType.SelectedValue == "2")
                     {
                         tblrefund.Visible = true;

                         GetFormDataRefund();

                         txtBasicFare_TextChanged(this, e);
                     }
                     else
                     {
                         tblrefund.Visible = false;
                     }
                     lblmsg.Text = "";
                     tblmain.Visible = true;
                     tblGrd.Visible = false;
                     //  clrfieldDet();
                     DetButtonVisible();
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
        ViewState["tTrain_booking"] = Session["tTrain_booking"];
    }

    public void Booking_Generate()
    {
        DataTable dt = objClass.viewData(objClass, "MaxBookNo", validation.dateToText(txtdtTrainBooking.Text));
        if (dt.Rows.Count > 0)
        {
            txtTrainBookingNo.Text = dt.Rows[0][0].ToString();
        }
    }
    public void para()
    {
        objClass.sTrainBookingNo = validation.stringToDBString(txtTrainBookingNo.Text.Trim());
        objClass.dtBookingDate = validation.dateToText(txtdtTrainBooking.Text.Trim());
        objClass.nClientID = ddlAgentID.SelectedValue;
        objClass.nLocationID = ddlLocationID.SelectedValue;
        objClass.nSupplierID = ddlSupplier.SelectedValue;
        objClass.nBookTypeID = ddlbookType.SelectedValue;
        objClass.bPaid = "0";  //Un paid 
    }

    public void clrfield()
    {
        txtTrainBookingNo.Text = "";
        txtdtTrainBooking.Text = "";
        ddlAgentID.SelectedValue = "0";
        ddlLocationID.SelectedValue = "0";
        ddlSupplier.SelectedValue = "0";
        ddlbookType.SelectedValue = "0";
        //   Session["eid"] = "";
    }

    public void GetFormData()
    {
        DataTable dt = objClass.viewData(objClass, "show", Session["eid"].ToString());
        if (dt.Rows.Count > 0)
        {
            txtTrainBookingNo.Text = dt.Rows[0][1].ToString();
            txtdtTrainBooking.Text = validation.TextToDate(dt.Rows[0][2].ToString());
            ddlAgentID.SelectedValue = dt.Rows[0][3].ToString();
            ddlLocationID.SelectedValue = dt.Rows[0][4].ToString();
            ddlSupplier.SelectedValue = dt.Rows[0][5].ToString();
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
        //btnUpdate.Visible = false;
        //btnDelete.Visible = false;
        clrfield();
    }

    public void DisableData()
    {
        //txtdtTrainBooking.Enabled = false;
        //txtTrainBookingNo.Enabled = false;
        //ddlAgentID.Enabled = false;
        //ddlLocationID.Enabled = false;
        //ddlSupplier.Enabled = false;
    }
    public void VisibleData()
    {
        txtdtTrainBooking.Enabled = true;
        txtTrainBookingNo.Enabled = true;

        ddlAgentID.Enabled = true;
        ddlLocationID.Enabled = true;
        ddlSupplier.Enabled = true;
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
        objClass.nTrainBookingID = Session["eid"].ToString();
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
            if (Session["tTrain_booking"].ToString() == ViewState["tTrain_booking"].ToString())
            {
                para();
                var abc = objClass.User_Operation(objClass, "add");

                var strArr = abc.Split(',');
                if (strArr[0] == "1")
                {
                    string TicID = strArr[2].ToString();
                    Session["eid"] = TicID;

                    paraDet();
                    var xyz = objClassDet.User_Operation(objClassDet, "add");

                    paraPassanger();
                    var pas = objPassanger.User_Operation(objPassanger, "add");

                    tblmain.Visible = true;
                    tblDet.Visible = true;
                    //nTrainBookingDetID.Visible = true;
                    tblGrd.Visible = false;

                    // displayGridDet();
                    btnAdd.Visible = false;
                    btnAddDet.Visible = false;
                    btnUpdateDet.Visible = true;
                    btnPrint.Visible = true;
                    btnPaymentHistory.Visible = true;
                    //clrfieldDet();
                    DisableData();
                }
                //displayGrid();

                valobj.showMsg(abc, lblmsg);
                string aa = Server.UrlEncode(System.DateTime.Now.ToString());
                Session["tTrain_booking"] = aa;
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
            objClass.nTrainBookingID = Session["eid"].ToString();
            if (ddlbookType.SelectedValue == "1")
            {
                Response.Redirect("Invoices/rpttrain_invoice.aspx?id=" + Session["eid"].ToString());
            }
            else
            {

                Response.Redirect("Invoices/rpttrain_refund_invoice.aspx?id=" + Session["eid"].ToString());
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
            if (lblType.Text == "Booking")
            {
                Response.Redirect("Invoices/rpttrain_invoice.aspx?id=" + Session["eid"].ToString());
            }
            else
            {

                Response.Redirect("Invoices/rpttrain_refund_invoice.aspx?id=" + Session["eid"].ToString());
            }

        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, "FAIL", lblmsg);
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
            //btnDelete.Visible = true;
            GetFormData();
            GetFormDataDet();
            GetFormDataPassanger();
            if (ddlbookType.SelectedValue == "2")
            {
                tblrefund.Visible = true;

                GetFormDataRefund();

                txtBasicFare_TextChanged(this, e);
            }
            else
            {
                tblrefund.Visible = false;
            }
            lblmsg.Text = "";
            tblmain.Visible = true;
            tblGrd.Visible = false;
            //  clrfieldDet();
            DetButtonVisible();
            DisableData();
            // displayGridDet();

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
        objClassDet.nTrainBookingID = Session["eid"].ToString();

        objClassDet.sPnrNo = validation.stringToDBString(txtPnrNo.Text.Trim());
        objClassDet.sTrainNo = validation.stringToDBString(txtTrainNo.Text.Trim());
        objClassDet.sClass = validation.stringToDBString(ddlClass.SelectedValue);
        objClassDet.sBoarding = validation.stringToDBString(txtBoarding.Text.Trim());
        objClassDet.dtTravelDate = validation.dateToText(txtdtTravelDate.Text.Trim());
        objClassDet.nFromID = ddlFromID.SelectedValue;
        objClassDet.nToID = ddlToID.SelectedValue;
        objClassDet.sPaxNos = validation.stringToDBString(txtPaxNos.Text.Trim());
        objClassDet.sTicketNo = validation.stringToDBString(txtTicketNo.Text.Trim());
       
   
        objClassDet.nBasicFare = txtBasicFare.Text.Trim();
        objClassDet.nOtherTax = txtOtherTax.Text.Trim();
        objClassDet.nSupComm = txtSupComm.Text.Trim();
        objClassDet.nSupScType = ddlSupScType.SelectedValue;
        if (ddlSupScType.SelectedValue == "0")
        {
            objClassDet.nSupScPercent = "0";
            objClassDet.nSupScAmount = txtSupSc.Text.Trim();
            SupSC = double.Parse(txtSupSc.Text.Trim());
        }
        else
        {
            objClassDet.nSupScPercent = txtSupSc.Text.Trim();
            SupSC = double.Parse(lblBuyCost.Text) * double.Parse(txtSupSc.Text) / 100;
            objClassDet.nSupScAmount = (SupSC).ToString();
        }
        objClassDet.nSupTdsType = ddlSupTds.SelectedValue;
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
        if (chkSupTax.Checked)
        {
            objClassDet.bSupTax = "1";
        }
        else
        {
            objClassDet.bSupTax = "0";
        }
        objClassDet.nSupCGST = txtsupcgst.Text.Trim();
        objClassDet.nSupSGST = txtsupsgst.Text.Trim();
        objClassDet.nSupIGST = txtsupigst.Text.Trim();
        objClassDet.nSupplierCost = lblBuyCost.Text.Trim();

        objClassDet.nClntScType = ddlProfitType.SelectedValue;
        if (ddlProfitType.SelectedValue == "0")
        {
            objClassDet.nClntScPercent = "0";
            objClassDet.nClntScAmount = txtProfitAmt.Text.Trim();
            ClntSC = double.Parse(txtProfitAmt.Text.Trim());
        }
        else
        {
            objClassDet.nClntScPercent = txtProfitAmt.Text.Trim();
            ClntSC = double.Parse(lblBuyCost.Text) * double.Parse(txtProfitAmt.Text) / 100;
            objClassDet.nClntScAmount = (ClntSC).ToString();
        }
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
        objClassDet.nDiscount = txtDiscount.Text.Trim();
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

        
        objClassDet.nClientCost = lblSelleing.Text.Trim();
        objClassDet.sRemarks = validation.stringToDBString(txtRemarks.Text.Trim());
        if (ddlProfitType.SelectedValue == "0")
        {
            objClassDet.nClntSc2Percent = "0";
            objClassDet.nClntSc2Amount = txtProfitAmt2.Text.Trim();
        }
        else
        {
            objClassDet.nClntSc2Percent = txtProfitAmt2.Text.Trim();
            ClntSC2 = double.Parse(lblBuyCost.Text) * double.Parse(txtProfitAmt2.Text) / 100;
            objClassDet.nClntSc2Amount = (ClntSC2).ToString();
        }
        objClassDet.nClntOtherChrgs = txtOtherchrg.Text.Trim();
        objClassDet.nSupDiscount = txtSupDiscount.Text.Trim();
        
    }

    public void clrfieldDet()
    {

        txtPnrNo.Text = "";
        txtTrainNo.Text = "";
        txtBoarding.Text = "";
        txtdtTravelDate.Text = "";
        ddlFromID.SelectedValue = "0";
        ddlToID.SelectedValue = "0";
        txtPaxNos.Text = "";
        txtTicketNo.Text = "";
        txtBasicFare.Text = "";
        txtOtherTax.Text = "";
        txtSupComm.Text = "";
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
        ddlClntTds.SelectedValue = "0";
        txtClntTds.Text = "";
        txtDiscount.Text = "";
        txtClntCgst.Text = "";
        txtClntSgst.Text = "";
        txtClntIgst.Text = "";
        txtClientCost.Text = "";
        lblSelleing.Text = "";
        txtRemarks.Text = "";

        txtProfitAmt2.Text = "";
        txtOtherchrg.Text = "";
        txtSupDiscount.Text = "";
        Session["Detid"] = "";
    }
    public void DetButtonVisible()
    {
        tblDet.Visible = true;
        //nTrainBookingDetID.Visible = false;
        btnAdd.Visible = false;
        btnAddDet.Visible = false;
        btnUpdateDet.Visible = true;
        //btnDeleteDet.Visible = false;
        //clrfieldDet();
    }

    public void GetFormDataDet()
    {
        DataTable dt = objClassDet.viewData(objClassDet, "show", Session["eid"].ToString());
        if (dt.Rows.Count > 0)
        {
            Session["Detid"] = dt.Rows[0][0].ToString();
            txtPnrNo.Text = dt.Rows[0][2].ToString();
            txtTrainNo.Text = dt.Rows[0][3].ToString();
            ddlClass.SelectedValue = dt.Rows[0][4].ToString();
            txtBoarding.Text = dt.Rows[0][5].ToString();
            txtdtTravelDate.Text = validation.TextToDate(dt.Rows[0][6].ToString());
            ddlFromID.SelectedValue = dt.Rows[0][7].ToString();
            ddlToID.SelectedValue = dt.Rows[0][8].ToString();
            txtPaxNos.Text = dt.Rows[0][9].ToString();
            txtTicketNo.Text = dt.Rows[0][10].ToString();
            txtBasicFare.Text = dt.Rows[0][11].ToString();
            txtOtherTax.Text = dt.Rows[0][12].ToString();
            txtSupComm.Text = dt.Rows[0][13].ToString();
            ddlSupScType.SelectedValue = dt.Rows[0][14].ToString();

            if (ddlSupScType.SelectedValue == "1")
            {
                txtSupSc.Text = dt.Rows[0][15].ToString();
            }
            else
            {
                txtSupSc.Text = dt.Rows[0][16].ToString();
            }
            ddlSupTds.SelectedValue = dt.Rows[0][17].ToString();
            if (ddlSupTds.SelectedValue == "1")
            {
                txtSupTds.Text = dt.Rows[0][18].ToString();
            }
            else
            {
                txtSupTds.Text = dt.Rows[0][19].ToString();
            }

            if (dt.Rows[0][20].ToString() == "1")
            {
                chkSupTax.Checked = true;
            }
            else
            {
                chkSupTax.Checked = false;
            }
            txtsupcgst.Text = dt.Rows[0][21].ToString();
            txtsupsgst.Text = dt.Rows[0][22].ToString();
            txtsupigst.Text = dt.Rows[0][23].ToString();

            txtSupplierCost.Text = dt.Rows[0][24].ToString();
            lblBuyCost.Text = dt.Rows[0][24].ToString();
            ddlProfitType.SelectedValue = dt.Rows[0][25].ToString();
            if (ddlProfitType.SelectedValue == "1")
            {
                txtProfitAmt.Text = dt.Rows[0][26].ToString();
            }
            else
            {
                txtProfitAmt.Text = dt.Rows[0][27].ToString();
            }

            ddlClntTds.SelectedValue = dt.Rows[0][28].ToString();
            if (ddlClntTds.SelectedValue == "1")
            {
                txtClntTds.Text = dt.Rows[0][29].ToString();
            }
            else
            {
                txtClntTds.Text = dt.Rows[0][30].ToString();
            }
           
            txtDiscount.Text = dt.Rows[0][31].ToString();

            if (dt.Rows[0][32].ToString() == "1")
            {
                chkClntTax.Checked = true;
            }
            else
            {
                chkClntTax.Checked = false;
            }
            txtClntCgst.Text = dt.Rows[0][33].ToString();
            txtClntSgst.Text = dt.Rows[0][34].ToString();
            txtClntIgst.Text = dt.Rows[0][35].ToString();
            txtClientCost.Text = dt.Rows[0][36].ToString();
            lblSelleing.Text = dt.Rows[0][36].ToString();
            txtRemarks.Text = dt.Rows[0][37].ToString();
            if (ddlProfitType.SelectedValue == "1")
            {
                txtProfitAmt2.Text = dt.Rows[0][38].ToString();
            }
            else
            {
                txtProfitAmt2.Text = dt.Rows[0][39].ToString();
            }
            txtOtherchrg.Text = dt.Rows[0][40].ToString();
            txtSupDiscount.Text = dt.Rows[0][41].ToString();
            
          
        }
    }

    public void btnVisibleDet()
    {
        btnAdd.Visible = true;
        //btnUpdate.Visible = false;
        //btnDelete.Visible = false;
        clrfieldDet();
    }

   

    //Ticket Passanger

   

    public void paraPassanger()
    {
        objPassanger.nTrainBookingID = Session["eid"].ToString();
        objPassanger.sPaxName1 = validation.stringToDBString(txtPaxName1.Text.Trim());
        objPassanger.sGender1 = validation.stringToDBString(ddlGender1.SelectedValue);
        objPassanger.sAge1 = validation.stringToDBString(txtAge1.Text.Trim());
        objPassanger.sStaus1 = validation.stringToDBString(txtStaus1.Text.Trim());
        objPassanger.sBogie1 = validation.stringToDBString(txtBogie1.Text.Trim());
        objPassanger.sPaxName2 = validation.stringToDBString(txtPaxName2.Text.Trim());
        objPassanger.sGender2 = validation.stringToDBString(ddlGender2.SelectedValue);
        objPassanger.sAge2 = validation.stringToDBString(txtAge2.Text.Trim());
        objPassanger.sStaus2 = validation.stringToDBString(txtStaus2.Text.Trim());
        objPassanger.sBogie2 = validation.stringToDBString(txtBogie2.Text.Trim());
        objPassanger.sPaxName3 = validation.stringToDBString(txtPaxName3.Text.Trim());
        objPassanger.sGender3 = validation.stringToDBString(ddlGender3.SelectedValue);
        objPassanger.sAge3 = validation.stringToDBString(txtAge3.Text.Trim());
        objPassanger.sStaus3 = validation.stringToDBString(txtStaus3.Text.Trim());
        objPassanger.sBogie3 = validation.stringToDBString(txtBogie3.Text.Trim());
        objPassanger.sPaxName4 = validation.stringToDBString(txtPaxName4.Text.Trim());
        objPassanger.sGender4 = validation.stringToDBString(ddlGender4.SelectedValue);
        objPassanger.sAge4 = validation.stringToDBString(txtAge4.Text.Trim());
        objPassanger.sStaus4 = validation.stringToDBString(txtStaus4.Text.Trim());
        objPassanger.sBogie4 = validation.stringToDBString(txtBogie4.Text.Trim());
        objPassanger.sPaxName5 = validation.stringToDBString(txtPaxName5.Text.Trim());
        objPassanger.sGender5 = validation.stringToDBString(ddlGender5.SelectedValue);
        objPassanger.sAge5 = validation.stringToDBString(txtAge5.Text.Trim());
        objPassanger.sStaus5 = validation.stringToDBString(txtStaus5.Text.Trim());
        objPassanger.sBogie5 = validation.stringToDBString(txtBogie5.Text.Trim());
        objPassanger.sPaxName6 = validation.stringToDBString(txtPaxName6.Text.Trim());
        objPassanger.sGender6 = validation.stringToDBString(ddlGender6.SelectedValue);
        objPassanger.sAge6 = validation.stringToDBString(txtAge6.Text.Trim());
        objPassanger.sStaus6 = validation.stringToDBString(txtStaus6.Text.Trim());
        objPassanger.sBogie6 = validation.stringToDBString(txtBogie6.Text.Trim());
    }

    public void clrfieldPassanger()
    {

        txtPaxName1.Text = "";
        txtAge1.Text = "";
        txtStaus1.Text = "";
        txtBogie1.Text = "";
        txtPaxName2.Text = "";
        txtAge2.Text = "";
        txtStaus2.Text = "";
        txtBogie2.Text = "";
        txtPaxName3.Text = "";
        txtAge3.Text = "";
        txtStaus3.Text = "";
        txtBogie3.Text = "";
        txtPaxName4.Text = "";
        txtAge4.Text = "";
        txtStaus4.Text = "";
        txtBogie4.Text = "";
        txtPaxName5.Text = "";
        txtAge5.Text = "";
        txtStaus5.Text = "";
        txtBogie5.Text = "";
        txtPaxName6.Text = "";
        txtAge6.Text = "";
        txtStaus6.Text = "";
        txtBogie6.Text = "";
    }
   

    public void GetFormDataPassanger()
    {
        DataTable dt = objPassanger.viewData(objPassanger, "show", Session["eid"].ToString());
        if (dt.Rows.Count > 0)
        {
            txtPaxName1.Text = dt.Rows[0][2].ToString();
            ddlGender1.SelectedValue = dt.Rows[0][3].ToString();
            txtAge1.Text = dt.Rows[0][4].ToString();
            txtStaus1.Text = dt.Rows[0][5].ToString();
            txtBogie1.Text = dt.Rows[0][6].ToString();
            txtPaxName2.Text = dt.Rows[0][7].ToString();
            ddlGender2.SelectedValue = dt.Rows[0][8].ToString();
            txtAge2.Text = dt.Rows[0][9].ToString();
            txtStaus2.Text = dt.Rows[0][10].ToString();
            txtBogie2.Text = dt.Rows[0][11].ToString();
            txtPaxName3.Text = dt.Rows[0][12].ToString();
            ddlGender3.SelectedValue = dt.Rows[0][13].ToString();
            txtAge3.Text = dt.Rows[0][14].ToString();
            txtStaus3.Text = dt.Rows[0][15].ToString();
            txtBogie3.Text = dt.Rows[0][16].ToString();
            txtPaxName4.Text = dt.Rows[0][17].ToString();
            ddlGender4.SelectedValue = dt.Rows[0][18].ToString();
            txtAge4.Text = dt.Rows[0][19].ToString();
            txtStaus4.Text = dt.Rows[0][20].ToString();
            txtBogie4.Text = dt.Rows[0][21].ToString();
            txtPaxName5.Text = dt.Rows[0][22].ToString();
            ddlGender5.SelectedValue = dt.Rows[0][23].ToString();
            txtAge5.Text = dt.Rows[0][24].ToString();
            txtStaus5.Text = dt.Rows[0][25].ToString();
            txtBogie5.Text = dt.Rows[0][26].ToString();
            txtPaxName6.Text = dt.Rows[0][27].ToString();
            ddlGender6.SelectedValue = dt.Rows[0][28].ToString();
            txtAge6.Text = dt.Rows[0][29].ToString();
            txtStaus6.Text = dt.Rows[0][30].ToString();
            txtBogie6.Text = dt.Rows[0][31].ToString();
        }
    }
    
    //End of Passanger Details


    protected void btnAddDet_Click(object sender, EventArgs e)
    {
        try
        {
            lblmsg.Text = "";
            if (Session["tTrain_booking"].ToString() == ViewState["tTrain_booking"].ToString())
            {
                paraDet();
                var abc = objClassDet.User_Operation(objClassDet, "add");

                tblmain.Visible = true;
                tblDet.Visible = true;
                tblGrd.Visible = false;

                btnAdd.Visible = false;
                btnAddDet.Visible = true;
                btnUpdateDet.Visible = false;

                clrfieldDet();
                DisableData();
                clrfieldPassanger();

                valobj.showMsg(abc, lblmsg);
                string aa = Server.UrlEncode(System.DateTime.Now.ToString());
                Session["tTrain_booking"] = aa;
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
    protected void btnUpdateDet_Click(object sender, EventArgs e)
    {
        try
        {
            para();
            objClass.nTrainBookingID = Session["eid"].ToString();
            var abc = objClass.User_Operation(objClass, "edit");

            paraDet();
            objClassDet.nTrainBookingDetID = Session["Detid"].ToString();
            var abc1 = objClassDet.User_Operation(objClassDet, "edit");

            if (ddlbookType.SelectedValue == "2")
            {
                RefundSave();
            }
            valobj.showMsg(abc, lblmsg);
            //clrfieldDet();
            DetButtonVisible();


            //  displayGridDet();

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
        lblmsg.Text = "";
        tblmain.Visible = true;
        tblGrd.Visible = false;
        tblDet.Visible = true;
        PnlPayment.Visible = false;
        clrfield();
        clrfieldDet();
        clrfieldPassanger();
        btnVisible();
        VisibleData();
        txtdtTrainBooking.Text = validation.fillDate();
        Booking_Generate();
        Session["eid"] = "";
        Session["Detid"] = "";
    }
    protected void lnkList_Click(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        tblmain.Visible = false;
        tblGrd.Visible = true;
        Session["eid"] = "";
        Session["Detid"] = "";
        displayGrid();
        PnlPayment.Visible = false;
        objAccount.ddlOperation(objAccount, "ddlCustomer", "", ddlSClient);
        objBranch.ddlOperation(objBranch, "Show", "", ddlSLoc);
        objAccount.ddlOperation(objAccount, "ddlVendor", "", ddlSSup);
        objClass.ddlOperation(objClass, "Show", "", ddlInvoiceNo);
        Response.Redirect("ttrain_booking_list.aspx");
    }
    protected void txtdtTrainBooking_TextChanged(object sender, EventArgs e)
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
            if (txtSupComm.Text == "")
            {
                txtSupComm.Text = "0";
            }
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

            if (txtClntTds.Text == "")
            {
                txtClntTds.Text = "0";
            }
            if (txtDiscount.Text == "")
            {
                txtDiscount.Text = "0";
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
            if (txtProfitAmt2.Text == "")
            {
                txtProfitAmt2.Text = "0";
            }
            if (txtOtherchrg.Text == "")
            {
                txtOtherchrg.Text = "0";
            }
            if (txtSupDiscount.Text == "")
            {
                txtSupDiscount.Text = "0";
            }

            //GST Calculation

            //GST Calculation
            GstCal();



            double SupSC = 0; double SupTDS = 0; double ClntSC = 0; double ClntSC2 = 0; double ClntTDS = 0; double subTot = 0;
            //Supplier SC and TDS Calculation
            subTot = double.Parse(txtBasicFare.Text);

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

            if (ddlbookType.SelectedValue == "2")
            {
                string SupCost = ((double.Parse(txtBasicFare.Text) + double.Parse(txtOtherTax.Text) + SupSC - SupTDS - (double.Parse(txtSupDiscount.Text)) - (double.Parse(txtSupComm.Text)) + (double.Parse(txtsupcgst.Text)) + (double.Parse(txtsupsgst.Text)) + (double.Parse(txtsupigst.Text)))).ToString();

                txtSupplierCost.Text = (double.Parse(SupCost) - double.Parse(txtRefundAmt.Text) - double.Parse(txtRfnCGst.Text) - double.Parse(txtRfnSGst.Text) - double.Parse(txtRfnIGst.Text)).ToString();
            }
            else
            {
                txtSupplierCost.Text = ((double.Parse(txtBasicFare.Text) + double.Parse(txtOtherTax.Text) + SupSC - SupTDS - (double.Parse(txtSupDiscount.Text)) - (double.Parse(txtSupComm.Text)) + (double.Parse(txtsupcgst.Text)) + (double.Parse(txtsupsgst.Text)) + (double.Parse(txtsupigst.Text)))).ToString();
            }

            lblBuyCost.Text = ((double.Parse(txtBasicFare.Text) + double.Parse(txtOtherTax.Text) + SupSC - SupTDS - (double.Parse(txtSupDiscount.Text)) - (double.Parse(txtSupComm.Text)) + (double.Parse(txtsupcgst.Text)) + (double.Parse(txtsupsgst.Text)) + (double.Parse(txtsupigst.Text)))).ToString();



            if (ddlProfitType.SelectedValue == "0")
            {
                ClntSC = double.Parse(txtProfitAmt.Text);
                ClntSC2 = double.Parse(txtProfitAmt2.Text);
            }
            else
            {
                ClntSC = double.Parse(lblBuyCost.Text) * double.Parse(txtProfitAmt.Text) / 100;
                ClntSC2 = double.Parse(lblBuyCost.Text) * double.Parse(txtProfitAmt2.Text) / 100;

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
                txtClientCost.Text = "-" + (double.Parse(txtSupplierCost.Text) - double.Parse(txtrfnSC.Text)).ToString();

            }
            else
            {
                txtClientCost.Text = ((double.Parse(lblBuyCost.Text) + ClntSC + ClntSC2 - ClntTDS - double.Parse(txtDiscount.Text) + (double.Parse(txtOtherchrg.Text)) + (double.Parse(txtClntCgst.Text)) + (double.Parse(txtClntSgst.Text)) + (double.Parse(txtClntIgst.Text)))).ToString();
            }

            lblSelleing.Text = ((double.Parse(lblBuyCost.Text) + ClntSC + ClntSC2 - ClntTDS + (double.Parse(txtOtherchrg.Text)) + (double.Parse(txtClntCgst.Text)) + (double.Parse(txtClntSgst.Text)) + (double.Parse(txtClntIgst.Text)) - double.Parse(txtDiscount.Text))).ToString();

            //  ddlTax.Focus();

            txtclntBasicFare.Text = txtBasicFare.Text;


        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, lblmsg);
        }
        finally
        {

        }
    }
    protected void txtclntBasicFare_TextChanged(object sender, EventArgs e)
    {
        txtBasicFare.Text = txtclntBasicFare.Text;
        txtBasicFare_TextChanged(this, e);
        txtProfitAmt.Focus();
    }
    protected void txtOtherTax_TextChanged(object sender, EventArgs e)
    {
        try
        {
            txtBasicFare_TextChanged(this, e);
            txtSupTds.Focus();
        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, lblmsg);
        }
        finally
        {

        }
    }
    protected void txtSupComm_TextChanged(object sender, EventArgs e)
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
    protected void txtSupSc_TextChanged(object sender, EventArgs e)
    {
        try
        {
            txtBasicFare_TextChanged(this, e);
            txtOtherTax.Focus();


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
        txtSupComm.Focus();
    }

    protected void txtProfitAmt_TextChanged(object sender, EventArgs e)
    {
        try
        {
            txtBasicFare_TextChanged(this, e);
            txtProfitAmt2.Focus();

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
            txtDiscount.Focus();

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
                    double Profit = double.Parse(lblBuyCost.Text) * double.Parse(txtSupSc.Text) / 100;
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
    protected void txtTrainBookingNo_TextChanged(object sender, EventArgs e)
    {
        DataTable dt = objClass.viewData(objClass, "FillDataTic", txtTrainBookingNo.Text);
        if (dt.Rows.Count > 0)
        {
            Session["eid"] = dt.Rows[0][0].ToString();
            GetFormData();
            GetFormDataDet();
            GetFormDataPassanger();
            if (ddlbookType.SelectedValue == "2")
            {
                tblrefund.Visible = true;

                GetFormDataRefund();

                txtBasicFare_TextChanged(this, e);
            }
            else
            {
                tblrefund.Visible = false;
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
    protected void txtProfitAmt2_TextChanged(object sender, EventArgs e)
    {
        try
        {
            txtBasicFare_TextChanged(this, e);
            txtClntTds.Focus();

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

    //Refund


    public void paraRefund()
    {
        objRefund.nTrainBookingID = Session["eid"].ToString();
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

        objRefund.nSupplierRefund = txtSupplierCost.Text;
        objRefund.nClientRefund = Math.Abs(double.Parse(txtClientCost.Text)).ToString();
        objRefund.sRfnRemaks = validation.stringToDBString(txtRfnRemarks.Text.Trim());
    }

    public void clrfieldRefund()
    {
        txtdtRfnDate.Text = validation.fillDate();
        txtRefundAmt.Text = "0";
        txtrfnSC.Text = "0";
        txtRfnRemarks.Text = "";
        Session["eid"] = "";
    }

    public void GetFormDataRefund()
    {
        DataTable dt = objRefund.viewData(objRefund, "show", Session["eid"].ToString());
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
            txtSupplierCost.Text = dt.Rows[0]["nSupplierRefund"].ToString();
            txtClientCost.Text = dt.Rows[0]["nClientRefund"].ToString();
            txtRfnRemarks.Text = dt.Rows[0]["sRfnRemaks"].ToString();
        }
    }

    public void RefundSave()
    {
        try
        {
            paraRefund();
            DataTable dt = objRefund.viewData(objRefund, "show", Session["eid"].ToString());

            if (dt.Rows.Count > 0)
            {


                objRefund.nTrainRefundID = dt.Rows[0][0].ToString();
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
        objClassDet.sPnrNo = ddlInvoiceNo.SelectedValue;
        objClassDet.sTrainNo = ddlSClient.SelectedValue;
        objClassDet.sClass = ddlSSup.SelectedValue;
        objClassDet.sBoarding = ddlSLoc.SelectedValue;
        objClassDet.sPaxNos = ddlSBookType.SelectedValue;
        objClassDet.dtTravelDate = validation.dateToText(txtSdtBooking.Text);
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
        //tblGridDet.Visible = false;

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
        txtPayRemarks.Text = "Train Ticket payment for invoice no.: " + InvNo.Text;
        DisplayPaymentGrid();
        PayVoucher_Generate();

    }

    protected void btnPaymentHistory_Click(object sender, EventArgs e)
    {
        PnlPayment.Visible = true;
        tblmain.Visible = false;
        tblDet.Visible = false;
        tblGrd.Visible = false;
       // tblGridDet.Visible = false;


        lblAgent.Text = ddlAgentID.SelectedValue;
        txtPayRemarks.Text = "Excursion payment for invoice no.: " + txtTrainBookingNo.Text;
        txtPayInv.Text = txtTrainBookingNo.Text;
        lblInvoiceDate.Text = validation.dateToText(txtdtTrainBooking.Text).ToString();
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
        objTrainPay.sPayfor = "Train";
        objTrainPay.FillGrid(objTrainPay, GridPay, "ShowPaymentsModule", Session["eid"].ToString());
    }
    public void paymentPara()
    {
        //Main Table
        //  objTrainPay.nPaymentReceiveID = Session["eid"].ToString();
        objTrainPay.nPaymentModeID = ddlPayVoucherType.SelectedValue;
        objTrainPay.nCashAccountID = ddlPaymentAccount.SelectedValue;
        objTrainPay.dtPayment = validation.dateToText(txtdtpayment.Text);
        objTrainPay.sVoucherNo = txtPayVoucherNo.Text;
        objTrainPay.nTotAmount = txtPayAmount.Text;
        objTrainPay.nAgentID = lblAgent.Text;
        objTrainPay.sRemarks = txtPayRemarks.Text;
        objTrainPay.sPayfor = "Train";

        //Detail Table
        objTrainPayDet.nInvoiceID = Session["eid"].ToString();
        objTrainPayDet.sInvoiceNo = txtPayInv.Text;
        objTrainPayDet.dtInvoiceDate = lblInvoiceDate.Text;
        objTrainPayDet.nAmount = txtPayAmount.Text; ;

        objTrainPayDet.sRemarks = txtPayRemarks.Text;

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
        DataTable dt = objTrainPayDet.viewData(objTrainPayDet, "GetDataTravel", Session["PayDetid"].ToString());
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
        if (Session["tTrain_booking"].ToString() == ViewState["tTrain_booking"].ToString())
        {
            paymentPara();

            if (Session["Payid"] == null || Session["Payid"] == "")
            {
                var abc = objTrainPay.User_Operation(objTrainPay, "add");
                var strArr = abc.Split(',');
                if (strArr[0] == "1")
                {
                    string PayID = strArr[2].ToString();
                    Session["Payid"] = PayID;
                    objTrainPayDet.nPaymentReceiveID = PayID;
                    var abc1 = objTrainPayDet.User_Operation(objTrainPayDet, "add");
                }
                valobj.showMsg(abc, lblmsg);


            }
            else
            {
                //Upodate Main Table
                objTrainPay.nPaymentReceiveID = Session["Payid"].ToString();
                var abc = objTrainPay.User_Operation(objTrainPay, "edit");

                //Upodate Detail Table
                objTrainPayDet.nPaymentReceiveDetID = Session["PayDetid"].ToString();
                objTrainPayDet.nPaymentReceiveID = Session["Payid"].ToString();
                var abc1 = objTrainPayDet.User_Operation(objTrainPayDet, "edit");

                valobj.showMsg(abc, lblmsg);
                Session["Payid"] = "";
                Session["PayDetid"] = "";

            }
            GetPaidDetails();
            objClass.nTrainBookingID = Session["eid"].ToString();
            var xyz = objClass.User_Operation(objClass, "bPaidEdit");

            GetBalance();
            Payclrfield();
            DisplayPaymentGrid();
            PayVoucher_Generate();

        }



        string aa = Server.UrlEncode(System.DateTime.Now.ToString());
        Session["tTrain_booking"] = aa;

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
        objTrainPay.nPaymentReceiveID = Session["Payid"].ToString();
        var vres = objTrainPay.User_Operation(objTrainPay, "DeActive");
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
        DataTable dt = objTrainPay.viewData(objTrainPay, "PVN", validation.dateToText(txtdtpayment.Text));
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
        Response.Redirect("PaymentReceipt/rptpay_receipt_inv.aspx?id=" + Session["eid"].ToString() + "&sPayfor=Train");
    }


    protected void ddlSupplier_SelectedIndexChanged(object sender, EventArgs e)
    {
        objAccount.ddlOperation(objAccount, "ddlCustomer", ddlSupplier.SelectedValue, ddlAgentID);
    }
   
}
