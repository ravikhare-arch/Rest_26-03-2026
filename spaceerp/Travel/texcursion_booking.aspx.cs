using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Transcation_excursion_booking : System.Web.UI.Page
{
    texcursion_booking_Class objClass = new texcursion_booking_Class();
    texcursion_bookingdet_Class objClassDet = new texcursion_bookingdet_Class();
    magent_Class objAgent = new magent_Class();
    mCountry_Class objCountry = new mCountry_Class();
    mcompany_Class objcompany = new mcompany_Class();
    mexcursion_Class objExcurtion = new mexcursion_Class();
    // mlocation_Class objBranch = new mlocation_Class();
    mdriver_Class objDriver = new mdriver_Class();
    //  tchartof_account_Class objAccount = new tchartof_account_Class();
    mmain_account_Class objAccount = new mmain_account_Class();
    msupgst_Class objSupGst = new msupgst_Class();
    mclientgst_Class objClntGst = new mclientgst_Class();
    texcursuinrefund_Class objRefund = new texcursuinrefund_Class();
    tpayments_receive_Class objExcPay = new tpayments_receive_Class();
    tpayments_receivedet_Class objExcPayDet = new tpayments_receivedet_Class();
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
                Session["texcursion_booking"] = aa;
                objAccount.ddlOperation(objAccount, "ddlCustomer", "", ddlAgentID);
                objBranch.ddlOperation(objBranch, "Showddl", "", ddlLocationID);
                objAccount.ddlOperation(objAccount, "ddlVendor", "", ddlSupplier);
                objExcurtion.ddlOperation(objExcurtion, "Show", "", ddlExcursionTypeID);
                objDriver.ddlOperation(objDriver, "Show", "", ddlDiverNameID);
                tblmain.Visible = true;
                tblDet.Visible = true;
                tblGridDet.Visible = false;
                tblGrd.Visible = false;
                PnlPayment.Visible = false;
                btnVisible();
                txtdtExcursionBooking.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
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
                    //btnUpdate.Visible = true;
                    //btnDelete.Visible = true;
                    GetFormData();
                   // GetFormDataDet();
                    if (ddlbookType.SelectedValue == "2")
                    {
                        tblrefund.Visible = true;

                        GetFormDataRefund();

                        txtAdultPax_TextChanged(this, e);
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
                    btnPrint.Visible = true;
                    btnPaymentHistory.Visible = true;
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
        ViewState["texcursion_booking"] = Session["texcursion_booking"];
    }

    public void Booking_Generate()
    {
        DataTable dt = objClass.viewData(objClass, "MaxBookNo", validation.dateToText(txtdtExcursionBooking.Text));
        if (dt.Rows.Count > 0)
        {
            txtExcursionBookingNo.Text = dt.Rows[0][0].ToString();
        }
    }
    public void para()
    {
        objClass.sExcursionBookingNo = validation.stringToDBString(txtExcursionBookingNo.Text.Trim());
        objClass.dtExcursionBooking = validation.dateToText(txtdtExcursionBooking.Text.Trim());
        objClass.nAgentID = ddlAgentID.SelectedValue;
        objClass.nLocationID = ddlLocationID.SelectedValue;
        objClass.nSupplierID = ddlSupplier.SelectedValue;
        objClass.nBookTypeID = ddlbookType.SelectedValue;
        objClass.bPaid = "0";  //Un paid 
    }

    public void clrfield()
    {
        txtExcursionBookingNo.Text = "";
        txtdtExcursionBooking.Text = "";
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
            txtExcursionBookingNo.Text = dt.Rows[0][1].ToString();
            txtdtExcursionBooking.Text = validation.TextToDate(dt.Rows[0][2].ToString());
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
        //txtdtExcursionBooking.Enabled = false;

        //ddlAgentID.Enabled = false;
        //ddlLocationID.Enabled = false;
        //ddlAgentID.Enabled = false;
    }
    public void VisibleData()
    {
        txtdtExcursionBooking.Enabled = true;


        ddlAgentID.Enabled = true;
        ddlLocationID.Enabled = true;
        ddlAgentID.Enabled = true;
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
        objClass.nExcursionBookingID = Session["eid"].ToString();
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
            if (Session["texcursion_booking"].ToString() == ViewState["texcursion_booking"].ToString())
            {
                para();
                var abc = objClass.User_Operation(objClass, "add");

                var strArr = abc.Split(',');
                if (strArr[0] == "1")
                {
                    string ExcursionID = strArr[2].ToString();
                    Session["eid"] = ExcursionID;

                    paraDet();
                    var xyz = objClassDet.User_Operation(objClassDet, "add");

                    tblmain.Visible = true;
                    tblDet.Visible = true;
                    tblGridDet.Visible = true;
                    tblGrd.Visible = false;

                     displayGridDet();
                    btnAdd.Visible = false;
                    btnAddDet.Visible = true;
                    btnUpdateDet.Visible = false;
                    btnPrint.Visible = true;
                    btnPaymentHistory.Visible = true;
                    //clrfieldDet();
                    DisableData();
                    valobj.showMsg(xyz, lblmsg);
                }
                else
                {
                    valobj.showMsg(abc, lblmsg);
                }
                //displayGrid();

                
                string aa = Server.UrlEncode(System.DateTime.Now.ToString());
                Session["texcursion_booking"] = aa;
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
    //        objClass.nExcursionBookingID = Session["eid"].ToString();
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


    protected void btnPrint_Click(object sender, EventArgs e)
    {
        try
        {
            objClass.nExcursionBookingID = Request.QueryString["id"];
            if (ddlbookType.SelectedValue == "1")
            {
                Response.Redirect("Invoices/rptexcursion_invoice.aspx?id=" + Request.QueryString["id"]);
            }
            else
            {

                Response.Redirect("Invoices/rptexcursion_refund_invoice.aspx?id=" + Request.QueryString["id"]);
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
                Response.Redirect("Invoices/rptexcursion_invoice.aspx?id=" + Session["eid"].ToString());
            }
            else
            {

                Response.Redirect("Invoices/rptexcursion_refund_invoice.aspx?id=" + Session["eid"].ToString());
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
            //btnUpdate.Visible = true;
            //btnDelete.Visible = true;
            GetFormData();
            GetFormDataDet();
            if (ddlbookType.SelectedValue == "2")
            {
                tblrefund.Visible = true;

                GetFormDataRefund();

                txtAdultPax_TextChanged(this, e);
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
            btnPrint.Visible = true;
            btnPaymentHistory.Visible = true;
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

    // Excursion Detail Table 
    public void paraDet()
    {
        double SupSC = 0; double ClntSC = 0; double ClntSC2 = 0;
        objClassDet.nExcursionBookingID = Session["eid"].ToString();
        objClassDet.sExcursionReferenceNo = validation.stringToDBString(txtExcursionReferenceNo.Text.Trim());
        objClassDet.sGuestName = validation.stringToDBString(txtGuestName.Text.Trim());
        objClassDet.nExcursionTypeID = ddlExcursionTypeID.SelectedValue;
        objClassDet.nDiverNameID = ddlDiverNameID.SelectedValue;
        objClassDet.sPickupPlace = validation.stringToDBString(txtPickupPlace.Text.Trim());
        objClassDet.sTelephone = validation.stringToDBString(txtTelephone.Text.Trim());
        objClassDet.sJobNo = validation.stringToDBString(txtJobNo.Text.Trim());
        objClassDet.dtPickupDate = validation.dateToText(txttPickupDate.Text.Trim());
        objClassDet.sPickupTime = validation.stringToDBString(txtPickupTime.Text.Trim());
        objClassDet.nPickTimeFormatID = ddlPickTimeFormatID.SelectedValue;
        objClassDet.sDropTime = validation.stringToDBString(txtDropTime.Text.Trim());
        objClassDet.nDropTimeFormatID = ddlDropTimeFormatID.SelectedValue;
        objClassDet.nAdultPax = txtAdultPax.Text.Trim();
        objClassDet.nAdultPax = objClassDet.nAdultPax = (objClassDet.nAdultPax == "") ? "0" : objClassDet.nAdultPax;
        objClassDet.nAdultPaxRate = txtAdultPaxRate.Text.Trim();
        objClassDet.nAdultPaxRate = objClassDet.nAdultPaxRate = (objClassDet.nAdultPaxRate == "") ? "0" : objClassDet.nAdultPaxRate;
        objClassDet.nChildPax = txtChildPax.Text.Trim();
        objClassDet.nChildPax = objClassDet.nChildPax = (objClassDet.nChildPax == "") ? "0" : objClassDet.nChildPax;
        objClassDet.nChildPaxRate = txtChildPaxRate.Text.Trim();
        objClassDet.nChildPaxRate = objClassDet.nChildPaxRate = (objClassDet.nChildPaxRate == "") ? "0" : objClassDet.nChildPaxRate;
        objClassDet.nTotal = lblBuyCost.Text.Trim();
        objClassDet.nTotal = objClassDet.nTotal = (objClassDet.nTotal == "") ? "0" : objClassDet.nTotal;
        objClassDet.nProfitTypeID = ddlProfitType.SelectedValue;
        string prftamnt = txtProfitAmt.Text.Trim();
        prftamnt = prftamnt = (prftamnt == "") ? "0" : prftamnt;
        if (ddlProfitType.SelectedValue == "0")
        {
            objClassDet.nProfitPercent = "0";
            objClassDet.nProfitAmount = prftamnt;
            ClntSC = double.Parse(prftamnt);
        }
        else
        {
            
            objClassDet.nProfitPercent = prftamnt;
            ClntSC = double.Parse(lblBuyCost.Text) * double.Parse(prftamnt) / 100;
            objClassDet.nProfitAmount = (ClntSC).ToString();
        }
        //  objClassDet.nTaxID = ddlTax.SelectedValue;
        //  objClassDet.sTaxName = validation.stringToDBString(ddlTax.SelectedItem.Text.Trim());
        // objClassDet.nTaxAmount = txtTaxAmount.Text.Trim();
        objClassDet.nDiscount = txtDiscount.Text.Trim();
        objClassDet.nDiscount = objClassDet.nDiscount = (objClassDet.nDiscount == "") ? "0" : objClassDet.nDiscount;
        objClassDet.nSellingCost = lblSelleing.Text.Trim();
        objClassDet.nSellingCost = objClassDet.nSellingCost = (objClassDet.nSellingCost == "") ? "0" : objClassDet.nSellingCost;
        objClassDet.sRemarks = validation.stringToDBString(txtRemarks.Text.Trim());
        objClassDet.nInfPax = txtInfPax.Text.Trim();
        objClassDet.nInfPax = objClassDet.nInfPax = (objClassDet.nInfPax == "") ? "0" : objClassDet.nInfPax;
        objClassDet.nInfPaxRate = txtInfRate.Text.Trim();
        objClassDet.nInfPaxRate = objClassDet.nInfPaxRate = (objClassDet.nInfPaxRate == "") ? "0" : objClassDet.nInfPaxRate;
        objClassDet.nSupScType = ddlSupScType.SelectedValue;
        string spscamt = txtSupSc.Text.Trim();
        spscamt = spscamt = (spscamt == "") ? "0" : spscamt;
        if (ddlSupScType.SelectedValue == "0")
        {
            objClassDet.nSupScpercent = "0";
            objClassDet.nSupSCAmount = spscamt;
            SupSC = double.Parse(spscamt);
        }
        else
        {
            objClassDet.nSupScpercent = spscamt;
            SupSC = double.Parse(lblBuyCost.Text) * double.Parse(spscamt) / 100;
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
        string spstds = txtSupTds.Text.Trim();
        spstds = spstds = (spstds == "") ? "0" : spstds;
        if (ddlSupTds.SelectedValue == "0")
        {
            objClassDet.nSupTdsPercent = "0";
            objClassDet.nSupTdsAmount = spstds;
        }
        else
        {
            objClassDet.nSupTdsPercent = spscamt;
            double SupTDS = (SupSC) * double.Parse(spstds) / 100;
            objClassDet.nSupTdsAmount = (SupTDS).ToString();
        }
        string clnttds = txtClntTds.Text.Trim();
        clnttds = clnttds = (clnttds == "") ? "0" : clnttds;
        if (ddlClntTds.SelectedValue == "0")
        {
            objClassDet.nClntTdsPercent = "0";
            objClassDet.nClntTdsAmount = clnttds;
        }
        else
        {
            objClassDet.nClntTdsPercent = clnttds;
            double ClntTDS = (ClntSC) * double.Parse(clnttds) / 100;
            objClassDet.nClntTdsAmount = (ClntTDS).ToString();


        }
        string prftamnt2 = txtProfitAmt2.Text.Trim();
        prftamnt2 = prftamnt2 = (prftamnt2 == "") ? "0" : prftamnt2;
        if (ddlProfitType.SelectedValue == "0")
        {
            objClassDet.nClntSc2Percent = "0";
            objClassDet.nClntSc2Amount = prftamnt2;
        }
        else
        {
            objClassDet.nClntSc2Percent = prftamnt2;
            ClntSC2 = double.Parse(lblBuyCost.Text) * double.Parse(prftamnt2) / 100;
            objClassDet.nClntSc2Amount = (ClntSC2).ToString();
        }
        objClassDet.nClntOtherChrgs = txtOtherchrg.Text.Trim();
        objClassDet.nClntOtherChrgs = objClassDet.nClntOtherChrgs = (objClassDet.nClntOtherChrgs == "") ? "0" : objClassDet.nClntOtherChrgs;
        objClassDet.nSupDiscount = txtSupDiscount.Text.Trim();
        objClassDet.nSupDiscount = objClassDet.nSupDiscount = (objClassDet.nSupDiscount == "") ? "0" : objClassDet.nSupDiscount;
    }

    public void clrfieldDet()
    {

        txtExcursionReferenceNo.Text = "";
        txtGuestName.Text = "";
        ddlExcursionTypeID.SelectedValue = "0";
        ddlDiverNameID.SelectedValue = "0";
        txtPickupPlace.Text = "";
        txtTelephone.Text = "";
        txtJobNo.Text = "";
        txttPickupDate.Text = "";
        txtPickupTime.Text = "";
        ddlPickTimeFormatID.SelectedValue = "1";
        txtDropTime.Text = "";
        ddlDropTimeFormatID.SelectedValue = "2";
        txtAdultPax.Text = "";
        txtAdultPaxRate.Text = "";
        txtChildPax.Text = "";
        txtChildPaxRate.Text = "";
        txtTotal.Text = "";
        ddlProfitType.SelectedValue = "0";
        txtProfitAmt.Text = "";

        txtDiscount.Text = "";
        txtsellingCost.Text = "";
        txtRemarks.Text = "";
        txtInfPax.Text = "";
        txtInfRate.Text = "";
        ddlSupScType.SelectedValue = "0";
        txtSupSc.Text = "";

        txtsupcgst.Text = "";
        txtsupsgst.Text = "";
        txtsupigst.Text = "";
        txtClntCgst.Text = "";
        txtClntSgst.Text = "";
        txtClntIgst.Text = "";
        txtSupTds.Text = "";
        txtClntTds.Text = "";
        txtProfitAmt2.Text = "";
        txtOtherchrg.Text = "";
        txtSupDiscount.Text = "";
        Session["Detid"] = "";
    }
    public void DetButtonVisible()
    {
        tblDet.Visible = true;
        tblGridDet.Visible = true;
        btnAdd.Visible = false;
        btnAddDet.Visible = false;
        btnUpdateDet.Visible = true;
        //btnDeleteDet.Visible = false;
        //clrfieldDet();
    }

    public void GetFormDataDet()
    {
        DataTable dt = objClassDet.viewData(objClassDet, "Show", Session["Detid"].ToString());
        if (dt.Rows.Count > 0)
        {
            Session["Detid"] = dt.Rows[0][0].ToString();
            txtExcursionReferenceNo.Text = dt.Rows[0][2].ToString();
            txtGuestName.Text = dt.Rows[0][3].ToString();
            ddlExcursionTypeID.SelectedValue = dt.Rows[0][4].ToString();
            ddlDiverNameID.SelectedValue = dt.Rows[0][5].ToString();
            txtPickupPlace.Text = dt.Rows[0][6].ToString();
            txtTelephone.Text = dt.Rows[0][7].ToString();
            txtJobNo.Text = dt.Rows[0][8].ToString();
            txttPickupDate.Text = validation.TextToDate(dt.Rows[0][9].ToString());
            txtPickupTime.Text = dt.Rows[0][10].ToString();
            ddlPickTimeFormatID.SelectedValue = dt.Rows[0][11].ToString();
            txtDropTime.Text = dt.Rows[0][12].ToString();
            ddlDropTimeFormatID.SelectedValue = dt.Rows[0][13].ToString();
            txtAdultPax.Text = dt.Rows[0][14].ToString();
            txtAdultPaxRate.Text = dt.Rows[0][15].ToString();
            txtChildPax.Text = dt.Rows[0][16].ToString();
            txtChildPaxRate.Text = dt.Rows[0][17].ToString();
            txtTotal.Text = dt.Rows[0][18].ToString();
            ddlProfitType.SelectedValue = dt.Rows[0][19].ToString();
            if (ddlProfitType.SelectedValue == "1")
            {
                txtProfitAmt.Text = dt.Rows[0][20].ToString();
            }
            else
            {
                txtProfitAmt.Text = dt.Rows[0][21].ToString();
            }

            //  ddlTax.SelectedValue = dt.Rows[0][22].ToString();
            // txtTaxAmount.Text = dt.Rows[0][24].ToString();
            txtDiscount.Text = dt.Rows[0][22].ToString();
            txtsellingCost.Text = dt.Rows[0][23].ToString();


            txtRemarks.Text = dt.Rows[0][24].ToString();

            txtInfPax.Text = dt.Rows[0][25].ToString();
            txtInfRate.Text = dt.Rows[0][26].ToString();
            ddlSupScType.SelectedValue = dt.Rows[0][27].ToString();
            if (ddlSupScType.SelectedValue == "1")
            {
                txtSupSc.Text = dt.Rows[0][28].ToString();
            }
            else
            {
                txtSupSc.Text = dt.Rows[0][29].ToString();
            }

            if (dt.Rows[0][30].ToString() == "1")
            {
                chkSupTax.Checked = true;
            }
            else
            {
                chkSupTax.Checked = false;
            }
            txtsupcgst.Text = dt.Rows[0][31].ToString();
            txtsupsgst.Text = dt.Rows[0][32].ToString();
            txtsupigst.Text = dt.Rows[0][33].ToString();
            if (dt.Rows[0][34].ToString() == "1")
            {
                chkClntTax.Checked = true;
            }
            else
            {
                chkClntTax.Checked = false;
            }
            txtClntCgst.Text = dt.Rows[0][35].ToString();
            txtClntSgst.Text = dt.Rows[0][36].ToString();
            txtClntIgst.Text = dt.Rows[0][37].ToString();
            ddlSupTds.SelectedValue = dt.Rows[0][38].ToString();
            if (ddlSupTds.SelectedValue == "1")
            {
                txtSupTds.Text = dt.Rows[0][39].ToString();
            }
            else
            {
                txtSupTds.Text = dt.Rows[0][40].ToString();
            }
            ddlClntTds.SelectedValue = dt.Rows[0][41].ToString();
            if (ddlClntTds.SelectedValue == "1")
            {
                txtClntTds.Text = dt.Rows[0][42].ToString();
            }
            else
            {
                txtClntTds.Text = dt.Rows[0][43].ToString();
            }

            if (ddlProfitType.SelectedValue == "1")
            {
                txtProfitAmt2.Text = dt.Rows[0][44].ToString();
            }
            else
            {
                txtProfitAmt2.Text = dt.Rows[0][45].ToString();
            }
            txtOtherchrg.Text = dt.Rows[0][46].ToString();
            txtSupDiscount.Text = dt.Rows[0][47].ToString();
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
            objClassDet.FillGrid(objClassDet, GridView2, "ShowGrid", Session["eid"].ToString());
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
            if (Session["texcursion_booking"].ToString() == ViewState["texcursion_booking"].ToString())
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

                clrfieldDet();
                DisableData();


                valobj.showMsg(abc, lblmsg);
                string aa = Server.UrlEncode(System.DateTime.Now.ToString());
                Session["texcursion_booking"] = aa;
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

            Label ExcurID = (Label)GridView2.Rows[row].Cells[0].FindControl("lblExcurID");
            Session["eid"] = ExcurID.Text;

            btnAdd.Visible = false;
            btnAddDet.Visible = false;
            btnUpdateDet.Visible = true;

            tblmain.Visible = true;
            tblDet.Visible = true;
            tblGridDet.Visible = true;
            tblGrd.Visible = false;

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
            para();
            objClass.nExcursionBookingID = Session["eid"].ToString();
            var abc = objClass.User_Operation(objClass, "edit");

            paraDet();
            objClassDet.nExcursionBookingDetID = Session["Detid"].ToString();
            var abc1 = objClassDet.User_Operation(objClassDet, "edit");

            if (ddlbookType.SelectedValue == "2")
            {
                RefundSave();
            }
            valobj.showMsg(abc, lblmsg);
            //clrfieldDet();
            DetButtonVisible();


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
        objClassDet.nExcursionBookingDetID = Session["Detid"].ToString();
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
        txtdtExcursionBooking.Text = validation.fillDate();
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
        Response.Redirect("texcursion_booking_list.aspx");
    }
    protected void txtdtExcursionBooking_TextChanged(object sender, EventArgs e)
    {
        Booking_Generate();
    }
    protected void txtAdultPax_TextChanged(object sender, EventArgs e)
    {
        try
        {
            //if (txtAdultPax.Text == "")
            //{
            //    txtAdultPax.Text = "0";
            //}
            //if (txtAdultPaxRate.Text == "")
            //{
            //    txtAdultPaxRate.Text = "0";
            //}
            //if (txtChildPax.Text == "")
            //{
            //    txtChildPax.Text = "0";
            //}
            //if (txtChildPaxRate.Text == "")
            //{
            //    txtChildPaxRate.Text = "0";
            //}
            //if (txtInfPax.Text == "")
            //{
            //    txtInfPax.Text = "0";
            //}
            //if (txtInfRate.Text == "")
            //{
            //    txtInfRate.Text = "0";
            //}

            //if (txtProfitAmt.Text == "")
            //{
            //    txtProfitAmt.Text = "0";
            //}
            //if (txtsellingCost.Text == "")
            //{
            //    txtsellingCost.Text = "0";
            //}

            //if (txtDiscount.Text == "")
            //{
            //    txtDiscount.Text = "0";
            //}
            //if (txtsupcgst.Text == "")
            //{
            //    txtsupcgst.Text = "0";
            //}
            //if (txtsupsgst.Text == "")
            //{
            //    txtsupsgst.Text = "0";
            //}
            //if (txtsupcgst.Text == "")
            //{
            //    txtsupcgst.Text = "0";
            //}
            //if (txtClntCgst.Text == "")
            //{
            //    txtClntCgst.Text = "0";
            //}
            //if (txtClntSgst.Text == "")
            //{
            //    txtClntSgst.Text = "0";
            //}
            //if (txtClntIgst.Text == "")
            //{
            //    txtClntIgst.Text = "0";
            //}

            //if (chkSupTax.Checked == false)
            //{
            //    txtsupcgst.Text = "0";
            //    txtsupsgst.Text = "0";
            //    txtsupigst.Text = "0";
            //}
            //if (chkClntTax.Checked == false)
            //{
            //    txtClntCgst.Text = "0";
            //    txtClntSgst.Text = "0";
            //    txtClntIgst.Text = "0";
            //}
            //if (txtSupTds.Text == "")
            //{
            //    txtSupTds.Text = "0";
            //}
            //if (txtClntTds.Text == "")
            //{
            //    txtClntTds.Text = "0";
            //}
            //if (chkRfnTax.Checked == false)
            //{
            //    txtRfnIGst.Text = "0";
            //    txtRfnCGst.Text = "0";
            //    txtRfnSGst.Text = "0";
            //}
            //if (txtRfnIGst.Text == "")
            //{
            //    txtRfnIGst.Text = "0";
            //}
            //if (txtRfnCGst.Text == "")
            //{
            //    txtRfnCGst.Text = "0";
            //}
            //if (txtRfnSGst.Text == "")
            //{
            //    txtRfnSGst.Text = "0";
            //}
            //if (txtrfnSC.Text == "")
            //{
            //    txtrfnSC.Text = "0";
            //}
            //if (txtRefundAmt.Text == "")
            //{
            //    txtRefundAmt.Text = "0";
            //}
            //if (txtProfitAmt2.Text == "")
            //{
            //    txtProfitAmt2.Text = "0";
            //}
            //if (txtOtherchrg.Text == "")
            //{
            //    txtOtherchrg.Text = "0";
            //}
            //if (txtSupDiscount.Text == "")
            //{
            //    txtSupDiscount.Text = "0";
            //}
            //GST Calculation

            //GST Calculation
           
            string adultPax = txtAdultPax.Text;
            string adultPaxRate = txtAdultPaxRate.Text;
            string childPax = txtChildPax.Text;
            string childPaxRate = txtChildPaxRate.Text;
            string SupSCCAL = txtSupSc.Text;
            string SupTDSCAL = txtSupTds.Text;
            string supDiscount = txtSupDiscount.Text;
            string supCGST = txtsupcgst.Text;
            string supSGST = txtsupsgst.Text;
            string supIGST = txtsupigst.Text;
            string profitAmount = txtProfitAmt.Text;
            string profitAmount2 = txtProfitAmt2.Text;
            string clntTDS = txtClntTds.Text;
            string otherCharge = txtOtherchrg.Text;
            string clntCGST = txtClntCgst.Text;
            string clntSGST = txtClntSgst.Text;
            string clntIGST = txtClntIgst.Text;
            string discount = txtDiscount.Text;
            string rfnSC = txtrfnSC.Text;
            string refundAmount = txtRefundAmt.Text;


            adultPax = adultPax = (adultPax == "") ? "0" : adultPax;
            adultPaxRate = adultPaxRate = (adultPaxRate == "") ? "0" : adultPaxRate;
            childPax = childPax = (childPax == "") ? "0" : childPax;
            childPaxRate = childPaxRate = (childPaxRate == "") ? "0" : childPaxRate;
            SupSCCAL = SupSCCAL = (SupSCCAL == "") ? "0" : SupSCCAL;
            SupTDSCAL = SupTDSCAL = (SupTDSCAL == "") ? "0" : SupTDSCAL;

            supDiscount = supDiscount = (supDiscount == "") ? "0" : supDiscount;
            supCGST = supCGST = (supCGST == "") ? "0" : supCGST;
            supSGST = supSGST = (supSGST == "") ? "0" : supSGST;
            supIGST = supIGST = (supIGST == "") ? "0" : supIGST;

            profitAmount = profitAmount = (profitAmount == "") ? "0" : profitAmount;
            profitAmount2 = profitAmount2 = (profitAmount2 == "") ? "0" : profitAmount2;


            clntTDS = clntTDS = (clntTDS == "") ? "0" : clntTDS;
            otherCharge = (otherCharge == "") ? "0" : otherCharge;
            clntCGST = (clntCGST == "") ? "0" : clntCGST;
            clntSGST = (clntSGST == "") ? "0" : clntSGST;
            clntIGST = (clntIGST == "") ? "0" : clntIGST;
            discount = (discount == "") ? "0" : discount;
            refundAmount = (refundAmount == "") ? "0" : refundAmount;
            GstCal(SupSCCAL,profitAmount,refundAmount);
            double SupSC = 0; double SupTDS = 0; double ClntSC = 0; double ClntSC2 = 0; double ClntTDS = 0; double subTot = 0;
            //Supplier SC and TDS Calculation
            subTot = ((double.Parse(adultPax) * double.Parse(adultPaxRate))
              + (double.Parse(childPax) * double.Parse(childPaxRate)));

            if (ddlSupScType.SelectedValue == "0")
            {
                SupSC = double.Parse(SupSCCAL);
            }
            else
            {
                SupSC = subTot * double.Parse(SupSCCAL) / 100;

            }
            if (ddlSupTds.SelectedValue == "0")
            {
                SupTDS = double.Parse(SupTDSCAL);
            }
            else
            {
                SupTDS = SupSC * double.Parse(SupTDSCAL) / 100;

            }

            if (ddlbookType.SelectedValue == "2")
            {
                string SupCost = ((double.Parse(adultPax) * double.Parse(adultPaxRate)) + (double.Parse(childPax) * double.Parse(childPaxRate)) +
                 (SupSC - SupTDS - (double.Parse(supDiscount)) + (double.Parse(supCGST)) + (double.Parse(supSGST)) + (double.Parse(supIGST)))).ToString();

                txtTotal.Text = (double.Parse(SupCost) - double.Parse(refundAmount) - double.Parse(txtRfnCGst.Text) - double.Parse(txtRfnSGst.Text) - double.Parse(txtRfnIGst.Text)).ToString();
            }
            else
            {
                txtTotal.Text = ((double.Parse(adultPax) * double.Parse(adultPaxRate))
               + (double.Parse(childPax) * double.Parse(childPaxRate)) +
               (SupSC - SupTDS - (double.Parse(supDiscount)) + (double.Parse(supCGST)) + (double.Parse(supSGST)) + (double.Parse(supIGST)))).ToString();
            }

            lblBuyCost.Text = ((double.Parse(adultPax) * double.Parse(adultPaxRate))
               + (double.Parse(childPax) * double.Parse(childPaxRate)) +
               (SupSC - SupTDS - (double.Parse(supDiscount)) + (double.Parse(supCGST)) + (double.Parse(supSGST)) + (double.Parse(supIGST)))).ToString();



            if (ddlProfitType.SelectedValue == "0")
            {
                ClntSC = double.Parse(profitAmount);
                ClntSC2 = double.Parse(profitAmount2);
            }
            else
            {
                ClntSC = double.Parse(lblBuyCost.Text) * double.Parse(profitAmount) / 100;
                ClntSC2 = double.Parse(lblBuyCost.Text) * double.Parse(profitAmount2) / 100;

            }
            if (ddlClntTds.SelectedValue == "0")
            {
                ClntTDS = double.Parse(clntTDS);
            }
            else
            {
                ClntTDS = ClntSC * double.Parse(clntTDS) / 100;

            }

            if (ddlbookType.SelectedValue == "2")
            {
                //String ClientCost = ((double.Parse(lblSupCost.Text)) + double.Parse(ClntSC) + double.Parse(ClntSC2) - double.Parse(ClntTDS) - double.Parse(txtDiscount.Text) + (double.Parse(txtClntCgst.Text)) + (double.Parse(txtClntSgst.Text)) + (double.Parse(txtClntIgst.Text))).ToString();
                //txtTotal.Text = (double.Parse(ClientCost) - double.Parse(txtRefundAmt.Text) - double.Parse(txtRfnCGst.Text) - double.Parse(txtRfnSGst.Text) - double.Parse(txtRfnIGst.Text) - double.Parse(txtrfnSC.Text)).ToString();
                txtsellingCost.Text = "-" + (double.Parse(txtTotal.Text) - double.Parse(rfnSC)).ToString();

            }
            else
            {
                txtsellingCost.Text = ((double.Parse(txtTotal.Text) + ClntSC + ClntSC2 - ClntTDS + (double.Parse(otherCharge)) + (double.Parse(clntCGST)) + (double.Parse(clntSGST)) + (double.Parse(clntIGST)) - double.Parse(discount))).ToString();
            }

            lblSelleing.Text = ((double.Parse(lblBuyCost.Text) + ClntSC + ClntSC2 - ClntTDS + (double.Parse(otherCharge)) + (double.Parse(clntCGST)) + (double.Parse(clntSGST)) + (double.Parse(clntIGST)) - double.Parse(discount))).ToString();

            //  ddlTax.Focus();




        }
        catch(Exception ex)
        {

        }
        finally
        {
            //txtAdultPaxRate.Focus();
        }
    }
    protected void txtAdultPaxRate_TextChanged(object sender, EventArgs e)
    {
        try
        {
            txtAdultPax_TextChanged(this, e);
            txtChildPax.Focus();
        }
        catch
        {

        }
        finally
        {

        }
    }
    protected void txtChildPax_TextChanged(object sender, EventArgs e)
    {
        try
        {
            txtAdultPax_TextChanged(this, e);
            txtChildPaxRate.Focus();
        }
        catch
        {

        }
        finally
        {

        }
    }
    protected void txtChildPaxRate_TextChanged(object sender, EventArgs e)
    {
        try
        {
            txtAdultPax_TextChanged(this, e);
            txtInfPax.Focus();
        }
        catch
        {

        }
        finally
        {

        }
    }


    protected void txtInfPax_TextChanged(object sender, EventArgs e)
    {
        try
        {
            txtAdultPax_TextChanged(this, e);
            txtChildPaxRate.Focus();
        }
        catch
        {

        }
        finally
        {

        }
    }
    protected void txtInfRate_TextChanged(object sender, EventArgs e)
    {
        try
        {
            txtAdultPax_TextChanged(this, e);
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
            txtAdultPax_TextChanged(this, e);
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
            txtAdultPax_TextChanged(this, e);
            txtOtherchrg.Focus();

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
            txtAdultPax_TextChanged(this, e);
            txtSupTds.Focus();

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
            txtAdultPax_TextChanged(this, e);


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
            txtAdultPax_TextChanged(this, e);


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
            txtAdultPax_TextChanged(this, e);
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
            txtAdultPax_TextChanged(this, e);
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

    protected void txtSupTds_TextChanged(object sender, EventArgs e)
    {
        txtAdultPax_TextChanged(this, e);
        txtSupDiscount.Focus();
    }
    protected void txtClntTds_TextChanged(object sender, EventArgs e)
    {
        txtAdultPax_TextChanged(this, e);
        txtDiscount.Focus();
    }
    public void GstCal(string supSC,string profitamnt,string refundamt)
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
                        txtsupcgst.Text = ((double.Parse(supSC)) * (double.Parse(Supsgst)) / 100).ToString();
                        txtsupsgst.Text = ((double.Parse(supSC)) * (double.Parse(Supcgst)) / 100).ToString();
                    }
                    else
                    {
                        txtsupigst.Text = ((double.Parse(supSC)) * (double.Parse(Supigst)) / 100).ToString();
                        txtsupcgst.Text = "0";
                        txtsupsgst.Text = "0";
                    }
                }
                else
                {
                    double Profit = double.Parse(txtTotal.Text) * double.Parse(supSC) / 100;
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
        if (dtSupgst.Rows.Count > 0)
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
                        txtClntCgst.Text = ((double.Parse(profitamnt)) * (double.Parse(Clntsgst)) / 100).ToString();
                        txtClntSgst.Text = ((double.Parse(profitamnt)) * (double.Parse(Clntcgst)) / 100).ToString();
                    }
                    else
                    {
                        txtClntIgst.Text = ((double.Parse(profitamnt)) * (double.Parse(Clntigst)) / 100).ToString();
                        txtClntCgst.Text = "0";
                        txtClntSgst.Text = "0";
                    }
                }
                else
                {
                    double Profit = double.Parse(lblBuyCost.Text) * double.Parse(profitamnt) / 100;
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

        mairgst_Class objAirGst = new mairgst_Class();
        DataTable dtrfngst = objAirGst.viewData(objAirGst, "show", ddlSupplier.SelectedValue);
        if (dtrfngst.Rows.Count > 0)
        {
            string Rfnigst = dtrfngst.Rows[0]["nAirIGST"].ToString();
            string Rfnsgst = dtrfngst.Rows[0]["nAirSGST"].ToString();
            string Rfncgst = dtrfngst.Rows[0]["nAirCGST"].ToString();
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
                    txtRfnCGst.Text = ((double.Parse(refundamt)) * (double.Parse(Rfncgst)) / 100).ToString();
                    txtRfnSGst.Text = ((double.Parse(refundamt)) * (double.Parse(Rfnsgst)) / 100).ToString();
                }
                else
                {
                    txtRfnIGst.Text = ((double.Parse(refundamt)) * (double.Parse(Rfnigst)) / 100).ToString();
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
    protected void txtExcursionBookingNo_TextChanged(object sender, EventArgs e)
    {
        DataTable dt = objClass.viewData(objClass, "FillDataExc", txtExcursionBookingNo.Text);
        if (dt.Rows.Count > 0)
        {
            Session["eid"] = dt.Rows[0]["nExcursionBookingID"].ToString();
            GetFormData();
            GetFormDataDet();
            if (ddlbookType.SelectedValue == "2")
            {
                tblrefund.Visible = true;

                GetFormDataRefund();

                txtAdultPax_TextChanged(this, e);
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
            btnPaymentHistory.Visible = false;
            btnAdd.Visible = true;
            //   clrfield();
            // clrfieldDet();
        }

    }
    protected void txtSupDiscount_TextChanged(object sender, EventArgs e)
    {
        txtAdultPax_TextChanged(this, e);
        txtProfitAmt.Focus();
    }

    //Refund


    public void paraRefund()
    {
        objRefund.nExcursionID = Session["eid"].ToString();
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
        objRefund.nClientRefund = Math.Abs(double.Parse(txtsellingCost.Text)).ToString();
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
            txtTotal.Text = dt.Rows[0]["nSupplierRefund"].ToString();
            txtsellingCost.Text = dt.Rows[0]["nClientRefund"].ToString();
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


                objRefund.nExcursionID = dt.Rows[0][0].ToString();
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
            txtAdultPax_TextChanged(this, e);
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
            txtAdultPax_TextChanged(this, e);
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
            txtAdultPax_TextChanged(this, e);
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
        objClassDet.sExcursionReferenceNo = ddlInvoiceNo.SelectedValue;
        objClassDet.sGuestName = ddlSClient.SelectedValue;
        objClassDet.sPickupPlace = ddlSSup.SelectedValue;
        objClassDet.sPickupTime = ddlSLoc.SelectedValue;
        objClassDet.sJobNo = ddlSBookType.SelectedValue;
        objClassDet.dtPickupDate = validation.dateToText(txtSdtBooking.Text);
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

        txtPayRemarks.Text = "Excursion payment for invoice no.: " + InvNo.Text;
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
        txtPayRemarks.Text = "Excursion payment for invoice no.: " + txtExcursionBookingNo.Text;
        txtPayInv.Text = txtExcursionBookingNo.Text;
        lblInvoiceDate.Text = validation.dateToText(txtdtExcursionBooking.Text).ToString();

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
        objExcPay.sPayfor = "Excursion";
        objExcPay.FillGrid(objExcPay, GridPay, "ShowPaymentsModule", Session["eid"].ToString());
    }
    public void paymentPara()
    {
        //Main Table
        //  objExcPay.nPaymentReceiveID = Session["eid"].ToString();
        objExcPay.nPaymentModeID = ddlPayVoucherType.SelectedValue;
        objExcPay.nCashAccountID = ddlPaymentAccount.SelectedValue;
        objExcPay.dtPayment = validation.dateToText(txtdtpayment.Text);
        objExcPay.sVoucherNo = txtPayVoucherNo.Text;
        objExcPay.nTotAmount = txtPayAmount.Text;
        objExcPay.nAgentID = lblAgent.Text;
        objExcPay.sRemarks = txtPayRemarks.Text;
        objExcPay.sPayfor = "Excursion";

        //Detail Table
        objExcPayDet.nInvoiceID = Session["eid"].ToString();
        objExcPayDet.sInvoiceNo = txtPayInv.Text;
        objExcPayDet.dtInvoiceDate = lblInvoiceDate.Text;
        objExcPayDet.nAmount = txtPayAmount.Text; ;

        objExcPayDet.sRemarks = txtPayRemarks.Text;
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
        DataTable dt = objExcPayDet.viewData(objExcPayDet, "GetDataTravel", Session["PayDetid"].ToString());
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
        if (Session["texcursion_booking"].ToString() == ViewState["texcursion_booking"].ToString())
        {
            paymentPara();

            if (Session["Payid"] == null || Session["Payid"] == "")
            {
                var abc = objExcPay.User_Operation(objExcPay, "add");
                var strArr = abc.Split(',');
                if (strArr[0] == "1")
                {
                    string PayID = strArr[2].ToString();
                    Session["Payid"] = PayID;
                    objExcPayDet.nPaymentReceiveID = PayID;
                    var abc1 = objExcPayDet.User_Operation(objExcPayDet, "add");
                }
                valobj.showMsg(abc, lblmsg);


            }
            else
            {
                //Upodate Main Table
                objExcPay.nPaymentReceiveID = Session["Payid"].ToString();
                var abc = objExcPay.User_Operation(objExcPay, "edit");

                //Upodate Detail Table
                objExcPayDet.nPaymentReceiveDetID = Session["PayDetid"].ToString();
                objExcPayDet.nPaymentReceiveID = Session["Payid"].ToString();
                var abc1 = objExcPayDet.User_Operation(objExcPayDet, "edit");

                valobj.showMsg(abc, lblmsg);
                Session["Payid"] = "";
                Session["PayDetid"] = "";

            }
            GetPaidDetails();
            objClass.nExcursionBookingID = Session["eid"].ToString();
            var xyz = objClass.User_Operation(objClass, "bPaidEdit");

            GetBalance();
            Payclrfield();
            DisplayPaymentGrid();
            PayVoucher_Generate();

        }



        string aa = Server.UrlEncode(System.DateTime.Now.ToString());
        Session["texcursion_booking"] = aa;

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
        objExcPay.nPaymentReceiveID  = Session["Payid"].ToString();
        var vres = objExcPay.User_Operation(objExcPay, "DeActive");
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
        DataTable dt = objExcPay.viewData(objExcPay, "PVN", validation.dateToText(txtdtpayment.Text));
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
            Response.Redirect("PaymentReceipt/rptpay_receipt_inv.aspx?Detid=" + IDDet.Text + "&sPayfor=Excursion");
        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, "FAIL", lblmsg);
        }
    }
    protected void btnPaymentReceipt_Click(object sender, EventArgs e)
    {
        Response.Redirect("PaymentReceipt/rptpay_receipt_inv.aspx?id=" + Session["eid"].ToString() + "&sPayfor=Excursion");
    }
    protected void ddlSupplier_SelectedIndexChanged(object sender, EventArgs e)
    {
        objAccount.ddlOperation(objAccount, "ddlCustomer", ddlSupplier.SelectedValue, ddlAgentID);
    }

}
