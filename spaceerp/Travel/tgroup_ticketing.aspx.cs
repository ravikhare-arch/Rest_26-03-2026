using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Transcation_ticketing : System.Web.UI.Page
{
    tgroup_ticketing_Class objClass = new tgroup_ticketing_Class();
    tgroup_ticketingdet_Class objClassDet = new tgroup_ticketingdet_Class();
    tgroup_tiketrefund_Class objRefund = new tgroup_tiketrefund_Class();
    tgroup_ticketsector_Class objSector = new tgroup_ticketsector_Class();
    tpayments_receive_Class objTicPay = new tpayments_receive_Class();
    tpayments_receivedet_Class objTicPayDet = new tpayments_receivedet_Class();
    //  magent_Class objAgent = new magent_Class();
    //  mCountry_Class objCountry = new mCountry_Class();
    mairline_Class objCarrier = new mairline_Class();
    // nflight_destination_Class objFlightDest = new nflight_destination_Class();
    //   mticketing_company_Class objTicCom = new mticketing_company_Class();
    mflight_class_Class objflClass = new mflight_class_Class();
    //   mcompany_Class objcompany = new mcompany_Class();
    //mlocation_Class objBranch = new mlocation_Class();
    //tchartof_account_Class objAccounts = new tchartof_account_Class();
    mmain_account_Class objAccount = new mmain_account_Class();
    msupgst_Class objSupGst = new msupgst_Class();
    mclientgst_Class objClntGst = new mclientgst_Class();
    mairgst_Class objAirGst = new mairgst_Class();
    mticket_com_Class objTickCom = new mticket_com_Class();

    msupplier_Class objSupplier = new msupplier_Class();
    mclient_Class objClient = new mclient_Class();
    mbranches_Class objBranch = new mbranches_Class();
    validation valobj = new validation();
    string cond;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                // Fillddl.FillPageddl(ddlPageSize);
                string aa = Server.UrlEncode(System.DateTime.Now.ToString());
                Session["tticketing"] = aa;

                tblmain.Visible = true;
                tblDet.Visible = true;
                tblGridDet.Visible = true;
                tblGrd.Visible = false;
                PnlPayment.Visible = false;

                objAccount.ddlOperation(objAccount, "ddlCustomer", "", ddlAgentID);
                objBranch.ddlOperation(objBranch, "Showddl", "", ddlLocationID);
                // objAccounts.ddlOperation(objAccounts, "ddlCustomer", "", ddlCompanyID);
                //  objFlightDest.ddlOperation(objFlightDest, "Showddl", "", ddlFromCountryID);
                //  objFlightDest.ddlOperation(objFlightDest, "Showddl", "", ddlToCountryID);
                objCarrier.ddlOperation(objCarrier, "Showddl", "", ddlCarrierID);
                objAccount.ddlOperation(objAccount, "ddlVendor", "", ddlsupplier);
                objflClass.ddlOperation(objflClass, "Show", "", ddlFlightClassID);
                displayGrid();
                btnVisible();
                txtdtBooking.Text = validation.fillDate();
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

                if (Session["TTid"] != "" && Session["TTid"] != null)
                {
                    string eid = Session["TTid"].ToString();
                    Session["eid"] = eid;
                    Session["TTid"] = "";
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

                     btnAdd.Visible = false;
                     //btnUpdate.Visible = false;
                     //btnDelete.Visible = false;
                     //btnUpdate.Visible = true;
                     btnAddDet.Visible = true;
                     btnUpdateDet.Visible = false;
                     //btnDeleteDet.Visible = false;
                     DisableData();
                     GetFormData();
                     //  GetFormDataDet();

                     objSector.FillReapter(objSector, rptSector, "showRpt", ID);
                     if (ddlBookType.SelectedValue == "2")
                     {
                         tblrefund.Visible = true;

                         GetFormDataRefund();

                         txtProfitAmount_TextChanged(this, e);
                     }
                     else
                     {
                         tblrefund.Visible = false;
                     }
                     lblmsg.Text = "";

                     txtSector.Enabled = true;
                     lblmsg.Text = "";
                     tblmain.Visible = true;
                     tblGridDet.Visible = true;
                     tblDet.Visible = true;
                     tblGrd.Visible = false;
                     btnPrint.Visible = true;
                     btnPaymentHistory.Visible = true;

                     // DetButtonVisible();
                     // clrfieldDet();
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
        ViewState["tticketing"] = Session["tticketing"];
    }
    protected void ddlsupplierType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlsupplierType.SelectedValue == "1")
            {
                ddlsupplier.Enabled = true;
                objAccount.ddlOperation(objAccount, "ddlVendor", "", ddlsupplier);
            }
            else if (ddlsupplierType.SelectedValue == "2")
            {
                ddlsupplier.Enabled = true;
                objAccount.ddlOperation(objAccount, "ddlAirline", "", ddlsupplier);
                objAccount.ddlOperation(objAccount, "ddlCustomer", "", ddlAgentID);
            }
            else
            {
                ddlsupplier.Enabled = false;
                objAccount.ddlOperation(objAccount, "ShowddlAccount", "742", ddlsupplier);
                ddlsupplier.SelectedValue = "742";

                objAccount.ddlOperation(objAccount, "ddlCustomer", "", ddlAgentID);
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
    public void para()
    {
        objClass.nTicketTypeID = ddlTicketType.SelectedValue;
        objClass.sBookingNo = validation.stringToDBString(txtTicketBookingNo.Text.Trim());
        objClass.dtBooking = validation.dateToText(txtdtBooking.Text.Trim());
        objClass.nAgentID = ddlAgentID.SelectedValue;
        objClass.nSupplierID = ddlsupplier.SelectedValue;
        objClass.nLocationID = ddlLocationID.SelectedValue;
        objClass.bPaid = "0";  //Un paid 
        objClass.nSupplierType = ddlsupplierType.SelectedValue;

    }

    public void clrfield()
    {
        ddlTicketType.SelectedValue = "0";
        txtTicketBookingNo.Text = "";
        txtdtBooking.Text = "";
        ddlAgentID.SelectedValue = "0";
        ddlLocationID.SelectedValue = "0";
        ddlsupplierType.SelectedValue = "0";
        ddlsupplier.SelectedValue = "0";
        Session["eid"] = "";
    }

    public void GetFormData()
    {
        DataTable dt = objClass.viewData(objClass, "show", Session["eid"].ToString());
        if (dt.Rows.Count > 0)
        {
            ddlTicketType.SelectedValue = dt.Rows[0][1].ToString();

            txtTicketBookingNo.Text = dt.Rows[0][2].ToString();
            txtdtBooking.Text = validation.TextToDate(dt.Rows[0][3].ToString());
            ddlsupplierType.SelectedValue = dt.Rows[0][10].ToString();
            EventArgs e = new EventArgs();
            ddlsupplierType_SelectedIndexChanged(this, e);
            ddlsupplier.SelectedValue = dt.Rows[0][5].ToString();

            ddlsupplier_SelectedIndexChanged(this, e);
            ddlAgentID.SelectedValue = dt.Rows[0][4].ToString();
            ddlLocationID.SelectedValue = dt.Rows[0][6].ToString();

            //  ddlCompanyID.SelectedValue = dt.Rows[0][5].ToString();


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
        // btnUpdate.Visible = false;
        // btnDeleteDet.Visible = false;
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
        objClass.nTicketingID = Session["eid"].ToString();
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
            if (Session["tticketing"].ToString() == ViewState["tticketing"].ToString())
            {
                para();
                var abc = objClass.User_Operation(objClass, "add");

                // displayGrid();

                var strArr = abc.Split(',');
                if (strArr[0] == "1")
                {
                    string TicketID = strArr[2].ToString();
                    Session["eid"] = TicketID;

                    paraDet();
                    var xyz = objClassDet.User_Operation(objClassDet, "add");

                    var strArr1 = xyz.Split(',');
                    if (strArr1[0] == "1")
                    {
                        string TicketDetID = strArr1[2].ToString();
                        Session["Detid"] = TicketDetID;
                        AddSector();
                    }
                    DetButtonVisible();
                    tblGridDet.Visible = true;
                    tblDet.Visible = true;
                    displayGridDet();
                    btnAdd.Visible = false;

                    btnAddDet.Visible = true;
                    btnUpdateDet.Visible = false;
                    btnPrint.Visible = true;
                    btnPaymentHistory.Visible = true;
                    //clrfieldDet();
                    DisableData();
                    //  GetFormDataDet();

                }

                valobj.showMsg(abc, lblmsg);
                string aa = Server.UrlEncode(System.DateTime.Now.ToString());
                Session["tticketing"] = aa;
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
            objClass.nTicketingID = Session["eid"].ToString();
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
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        try
        {
            objClass.nTicketingID = Session["eid"].ToString();
            //if (ddlTicketType.SelectedValue == "2")
            //{
            //    Response.Redirect("rptTicketRefund_Invoice.aspx?id=" + Session["eid"].ToString());
            //}
            //else
            //{
            //    Response.Redirect("rptTicketInvoiceNew.aspx?id=" + Session["eid"].ToString());
            //}
            Response.Redirect("Invoices/rptGroupTicket_Invoice.aspx?id=" + Session["eid"].ToString());
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
            //btnUpdate.Visible = false;
            //btnDelete.Visible = false;
            //btnUpdate.Visible = true;
            btnAddDet.Visible = true;
            btnUpdateDet.Visible = false;
            //btnDeleteDet.Visible = false;
            DisableData();
            GetFormData();
            //  GetFormDataDet();

            objSector.FillReapter(objSector, rptSector, "showRpt", ID.Text);
            if (ddlBookType.SelectedValue == "2")
            {
                tblrefund.Visible = true;

                GetFormDataRefund();

                txtProfitAmount_TextChanged(this, e);
            }
            else
            {
                tblrefund.Visible = false;
            }
            lblmsg.Text = "";

            txtSector.Enabled = true;
            lblmsg.Text = "";
            tblmain.Visible = true;
            tblGridDet.Visible = true;
            tblDet.Visible = true;
            tblGrd.Visible = false;
            btnPrint.Visible = true;
            btnPaymentHistory.Visible = true;

            // DetButtonVisible();
            // clrfieldDet();
            displayGridDet();

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
            //if (lblType.Text == "REFUND")
            //{
            //    Response.Redirect("rptTicketRefund_Invoice.aspx?id=" + ID.Text);
            //}
            //else
            //{
            //    Response.Redirect("rptTicketInvoiceNew.aspx?id=" + ID.Text);
            //}
            Response.Redirect("Invoices/rptGroupTicket_Invoice.aspx?id=" + Session["eid"].ToString());
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
        Label ID = (Label)GridView2.Rows[row].Cells[0].FindControl("lblIDDet");
        Session["Detid"] = ID.Text;

        Label lblType = (Label)GridView2.Rows[row].Cells[0].FindControl("lblBookType");
        if (lblType.Text == "Booking")
        {
            Response.Redirect("Invoices/rptGroupTicket_Invoice.aspx?Detid=" + ID.Text);
        }
        else
        {

            Response.Redirect("Invoices/rptticket_refund_invoice.aspx?Detid=" + ID.Text);
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
        double SupSC = 0, ClientSC = 0, ClientSC2 = 0;
        objClassDet.nTicketingID = Session["eid"].ToString();
        objClassDet.sReferenceNo = validation.stringToDBString(txtReferenceNo.Text.Trim());
        objClassDet.sGroupName = validation.stringToDBString(txtGroupName.Text.Trim());

        objClassDet.sSector = txtSector.Text;
        TextBox txtdtTravelR = rptSector.Items[0].FindControl("txtdtTravelR") as TextBox;

        objClassDet.sAirPNR = validation.stringToDBString(txtAirPnr.Text.Trim());
        objClassDet.sTicketNo = validation.stringToDBString(txtTicketNo.Text.Trim());

        objClassDet.nAirlineID = ddlCarrierID.SelectedValue;
        objClassDet.nBookTypeID = ddlBookType.SelectedValue;
        objClassDet.sFlightClass = ddlFlightClassID.SelectedValue;
        objClassDet.sFlightNo = validation.stringToDBString(txtFlightNo.Text.Trim());
        // 
        objClassDet.sCRS = ddlTktBookFrom.SelectedValue;
        objClassDet.sRemarks = txtRemarks.Text.Trim();

        objClassDet.nBasicFare = txtFareBasis.Text.Trim();
        objClassDet.nQuantity = txtClntQty.Text.Trim();
        objClassDet.nTotBasic = txtBasicTot.Text.Trim();

        objClassDet.nYQRate = txtYQtax.Text.Trim();
        objClassDet.nYQTot = txtYQTaxTot.Text.Trim();
        objClassDet.nYRRate = txtYRtax.Text.Trim();

        objClassDet.nYRTot = txtYRTaxTot.Text.Trim();
        objClassDet.nK3Rate = txtK3Tax.Text.Trim();
        objClassDet.nK3Tot = txtK3Tot.Text.Trim();

        objClassDet.nOtrTaxRate = txtOtherTax.Text.Trim();
        objClassDet.nOtrTaxTot = txtOtherTaxtot.Text.Trim();
        objClassDet.niatacomRate = txtAirComm.Text.Trim();
        objClassDet.niatacomTot = txtAirComTot.Text.Trim();

        objClassDet.nPlbRate = txtAirplb.Text.Trim();
        objClassDet.nPlbTot = txtAirPlbTot.Text.Trim();

        objClassDet.nTktCost = txtClntTicketFare.Text.Trim();
        if (txtProfitAmount.Text == "")
        {
            txtProfitAmount.Text = "0";
        }
        if (txtClntSc2.Text == "")
        {
            txtClntSc2.Text = "0";
        }
        if (txtSupplierCost.Text == "")
        {
            txtSupplierCost.Text = "0";
        }
        if (txtSupTicketFare.Text == "")
        {
            txtSupTicketFare.Text = "0";
        }
        if (txtClientCost.Text == "")
        {
            txtClientCost.Text = "0";
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


        objClassDet.nSupScType = ddlSupScType.SelectedValue;

        if (ddlSupScType.SelectedValue == "0")
        {
            objClassDet.nSupScPercent = "0";
            objClassDet.nSupScAmount = txtSupSc.Text.Trim();
            SupSC = double.Parse(txtSupSc.Text.Trim());
            //objClassDet.nSupScAmountTot = (SupSC* double.Parse(txtClntQty.Text)).ToString();
        }
        else
        {
            if (txtSupSc.Text != "")
            {
                objClassDet.nSupScPercent = txtSupSc.Text.Trim();
                SupSC = double.Parse(txtSupTicketFare.Text) * double.Parse(txtSupSc.Text) / 100;
                objClassDet.nSupScAmount = (SupSC).ToString();
            }

            //   objClassDet.nSupScAmountTot = (SupSC * double.Parse(txtClntQty.Text)).ToString();
        }
        objClassDet.nSupScAmountTot = txtSupScTot.Text.Trim();
        objClassDet.nSupTDSType = ddlSupTds.SelectedValue;
        if (ddlSupTds.SelectedValue == "0")
        {
            objClassDet.nSupTDSPercent = "0";
            objClassDet.nSupTDSAmount = txtSupTds.Text.Trim();
        }
        else
        {
            if (txtSupTds.Text != "")
            {
                objClassDet.nSupTDSPercent = txtSupTds.Text.Trim();
                double SupTDS = double.Parse(txtSupTds.Text) * SupSC / 100;
                objClassDet.nSupScAmount = (SupTDS).ToString();

            }
        }
        objClassDet.nSupTDSAmountTot = txtSupTdsTot.Text.Trim();


        objClassDet.nSupDiscount = txtSupDiscount.Text.Trim();
        objClassDet.nSupDiscountTot = txtSupDiscountTot.Text.Trim();
        if (chkSupTax.Checked)
        {
            objClassDet.bSupTax = "1";
        }
        else
        {
            objClassDet.bSupTax = "0";
        }
        objClassDet.nSupCGST = txtsupcgst.Text.Trim();
        objClassDet.nSupCGSTTot = txtsupcgstTot.Text.Trim();
        objClassDet.nSupSGST = txtsupsgst.Text.Trim();
        objClassDet.nSupSGSTTot = txtsupsgstTot.Text.Trim();
        objClassDet.nSupIGST = txtsupigst.Text.Trim();
        objClassDet.nSupIGSTTot = txtsupigstTot.Text.Trim();


        objClassDet.nCLTScType = ddlProfit.SelectedValue;
        //for Calculation of Various Feild


        if (ddlProfit.SelectedValue == "0")
        {
            objClassDet.nCLTSCPecent = "0";

            objClassDet.nCLTSCAmount = txtProfitAmount.Text.Trim();

            ClientSC = double.Parse(txtProfitAmount.Text.Trim());
        }
        else
        {
            if (txtProfitAmount.Text != "")
            {
                objClassDet.nCLTSCPecent = txtProfitAmount.Text.Trim();
                ClientSC = double.Parse(txtSupplierCost.Text) * double.Parse(txtProfitAmount.Text) / 100;
                objClassDet.nCLTSCAmount = (ClientSC).ToString();
            }
        }
        objClassDet.nCLTSCAmountTot = txtProfitAmountTot.Text.Trim();

        if (ddlProfit.SelectedValue == "0")
        {

            objClassDet.nCLTSC2Pecent = "";
            objClassDet.nCLTSC2Amount = txtClntSc2.Text.Trim();

            ClientSC2 = double.Parse(txtClntSc2.Text.Trim());
        }
        else
        {
            if (txtClntSc2.Text != "")
            {
                objClassDet.nCLTSC2Pecent = txtClntSc2.Text.Trim();
                ClientSC2 = double.Parse(txtSupplierCost.Text) * double.Parse(txtClntSc2.Text) / 100;
                objClassDet.nCLTSC2Amount = (ClientSC2).ToString();
            }
            else
            {
                objClassDet.nCLTSC2Amount = "";
            }
        }
        objClassDet.nCLTSC2AmountTot = txtClntSc2Tot.Text.Trim();
        objClassDet.nCLTTDSType = ddlclntTds.SelectedValue;
        if (ddlclntTds.SelectedValue == "0")
        {
            objClassDet.nCLTTDSPercent = "0";
            objClassDet.nCLTTDSAmount = txtSupTds.Text.Trim();
        }
        else
        {
            if (txtClntTds.Text != "")
            {
                objClassDet.nCLTTDSPercent = txtClntTds.Text.Trim();
                double ClnrTDS = ClientSC * double.Parse(txtClntTds.Text) / 100;
                objClassDet.nCLTTDSAmount = (ClnrTDS).ToString();
            }

        }
        objClassDet.nCLTTDSAmountTot = txtClntTdsTot.Text.Trim();

        objClassDet.nCLTDiscount = txtDiscount.Text.Trim();
        objClassDet.nCLTDiscountTot = txtClntDiscountTot.Text.Trim();
        objClassDet.nCLTOtrCRG = txtOtherchrg.Text.Trim();
        objClassDet.nCLTOtrCRGTot = txtOtherchrgTot.Text.Trim();
        if (chkClntTax.Checked)
        {
            objClassDet.bCLTTax = "1";
        }
        else
        {
            objClassDet.bCLTTax = "0";
        }
        objClassDet.nCLTCGST = txtClntCgst.Text.Trim();
        objClassDet.nCLTCGSTTot = txtClntCgstTot.Text.Trim();
        objClassDet.nCLTSGST = txtClntSgst.Text.Trim();
        objClassDet.nCLTSGSTTot = txtClntSgstTot.Text.Trim();
        objClassDet.nCLTIGST = txtClntIgst.Text.Trim();
        objClassDet.nCLTIGSTTot = txtClntIgstTot.Text.Trim();
        objClassDet.nSupplierCost = lblSupCost.Text.Trim();
        objClassDet.nClientCost = lblClientCost.Text.Trim();


    }

    public void DisableData()
    {
        //txtdtBooking.Enabled = false;
        //ddlAgentID.Enabled = false;
        //ddlLocationID.Enabled = false;
        //ddlsupplier.Enabled = false;
        //ddlsupplierType.Enabled = false;
    }
    public void VisibleData()
    {
        txtdtBooking.Enabled = true;
        ddlAgentID.Enabled = true;
        ddlLocationID.Enabled = true;
        ddlsupplier.Enabled = true;
        ddlsupplierType.Enabled = true;
    }
    public void clrfieldDet()
    {

        txtReferenceNo.Text = "";
        txtGroupName.Text = "";
        //  txtPassportNo.Text = "";
        //  ddlTripTypeID.SelectedValue = "0";
        txtSector.Text = "";
        //ddlFromCountryID.SelectedValue = "0";
        //ddlToCountryID.SelectedValue = "0";
        //  txtTravelDate.Text = "";
        // txttReturnDate.Text = "";
        txtTicketNo.Text = "";
        ddlCarrierID.SelectedValue = "0";
        ddlsupplier.SelectedValue = "0";
        ddlFlightClassID.SelectedValue = "0";
        //  txtDeparture.Text = "";
        txtSupplierCost.Text = "";
        txtProfitAmount.Text = "";
        txtOtherTax.Text = "";
        txtDiscount.Text = "";
        // txtFareBasis.Text = "";
        //  ddlStatus.SelectedValue = "0";
        txtClientCost.Text = "";
        txtRemarks.Text = "";
        ddlSupScType.SelectedValue = "0";
        txtSupSc.Text = "";

        txtsupcgst.Text = "";
        txtsupsgst.Text = "";
        txtsupigst.Text = "";
        txtClntCgst.Text = "";
        txtClntSgst.Text = "";
        txtClntIgst.Text = "";

        //txtAircgst.Text = "";
        //txtAirsgst.Text = "";
        //txtAirIgst.Text = "";
        //  txtAirInc.Text = "";
        txtAirComm.Text = "";
        txtAirplb.Text = "";
        txtYQtax.Text = "";
        txtYRtax.Text = "";
        //    txtOcTax.Text = "";
        txtOtherTax.Text = "";
        ddlSupTds.SelectedValue = "0";
        txtSupTds.Text = "";
        ddlclntTds.SelectedValue = "0";
        txtClntTds.Text = "";
        txtK3Tax.Text = "";
        txtAirPnr.Text = "";

        txtFareBasis.Text = "";
        txtClntSc2.Text = "";
        txtOtherchrg.Text = "";

        txtClntBasicFare.Text = "";
        txtClntYQTax.Text = "";
        txtClntYRTax.Text = "";
        txtClntK3Tax.Text = "";
        //  txtClntAirInc.Text = "";
        txtClntAirCom.Text = "";
        txtClntAirPlb.Text = "";
        //  txtClntOCTax.Text = "";
        txtClntOtherTax.Text = "";
        //  txtdtDueDate.Text = "";
        txtFlightNo.Text = "";

        txtClntTicketFare.Text = "";
        txtSupTicketFare.Text = "";
        txtSupDiscount.Text = "";

        Session["Detid"] = "";
    }
    public void DetButtonVisible()
    {
        tblDet.Visible = true;
        tblGridDet.Visible = true;
        btnAddDet.Visible = true;
        btnUpdateDet.Visible = false;
        //  btnDeleteDet.Visible = false;
        //clrfieldDet();
    }

    public void GetFormDataDet()
    {
        DataTable dt = objClassDet.viewData(objClassDet, "show", Session["Detid"].ToString());
        if (dt.Rows.Count > 0)
        {
            Session["Detid"] = dt.Rows[0][0].ToString();
            txtReferenceNo.Text = dt.Rows[0][2].ToString();
            txtGroupName.Text = dt.Rows[0][3].ToString();
            txtSector.Text = dt.Rows[0][4].ToString();
            txtAirPnr.Text = dt.Rows[0][5].ToString();
            txtTicketNo.Text = dt.Rows[0][6].ToString();
            ddlCarrierID.SelectedValue = dt.Rows[0][7].ToString();
            ddlBookType.SelectedValue = dt.Rows[0][8].ToString();
            ddlFlightClassID.SelectedValue = dt.Rows[0][9].ToString();

            txtFlightNo.Text = dt.Rows[0][10].ToString();
            ddlTktBookFrom.Text = dt.Rows[0][11].ToString();
            txtRemarks.Text = dt.Rows[0][12].ToString();

            txtFareBasis.Text = dt.Rows[0][13].ToString();
            txtClntBasicFare.Text = dt.Rows[0][13].ToString();
            txtClntQty.Text = dt.Rows[0][14].ToString();
            txtSupQty.Text = dt.Rows[0][14].ToString();


            txtClntYQTax.Text = dt.Rows[0][16].ToString();
            txtYQtax.Text = dt.Rows[0][16].ToString();
            txtYQTaxTot.Text = dt.Rows[0][17].ToString();
            txtYRtax.Text = dt.Rows[0][18].ToString();
            txtClntYRTax.Text = dt.Rows[0][18].ToString();
            txtYRTaxTot.Text = dt.Rows[0][19].ToString();
            txtK3Tax.Text = dt.Rows[0][20].ToString();
            txtClntK3Tax.Text = dt.Rows[0][20].ToString();
            txtK3Tot.Text = dt.Rows[0][21].ToString();
            txtOtherTax.Text = dt.Rows[0][22].ToString();
            txtClntOtherTax.Text = dt.Rows[0][22].ToString();
            txtOtherTaxtot.Text = dt.Rows[0][23].ToString();
            txtAirComm.Text = dt.Rows[0][24].ToString();
            txtClntAirCom.Text = dt.Rows[0][24].ToString();
            txtAirComTot.Text = dt.Rows[0][25].ToString();
            txtAirplb.Text = dt.Rows[0][26].ToString();
            txtClntAirPlb.Text = dt.Rows[0][26].ToString();
            txtAirPlbTot.Text = dt.Rows[0][27].ToString();
            txtSupTicketFare.Text = dt.Rows[0][28].ToString();
            txtClntTicketFare.Text = dt.Rows[0][28].ToString();


            //lblSupCost.Text = dt.Rows[0][17].ToString();
            //txtSupplierCost.Text = dt.Rows[0][17].ToString();

            ddlSupScType.SelectedValue = dt.Rows[0][29].ToString();
            if (ddlSupScType.SelectedValue == "1")
            {
                txtSupSc.Text = dt.Rows[0][30].ToString();
            }
            else
            {
                txtSupSc.Text = dt.Rows[0][31].ToString();
            }
            txtSupScTot.Text = dt.Rows[0][32].ToString();
            ddlSupTds.SelectedValue = dt.Rows[0][33].ToString();
            if (ddlSupTds.SelectedValue == "1")
            {
                txtSupTds.Text = dt.Rows[0][34].ToString();
            }
            else
            {
                txtSupTds.Text = dt.Rows[0][35].ToString();
            }
            txtSupTdsTot.Text = dt.Rows[0][36].ToString();
            txtSupDiscount.Text = dt.Rows[0][37].ToString();
            txtSupDiscountTot.Text = dt.Rows[0][38].ToString();

            if (dt.Rows[0][39].ToString() == "1")
            {
                chkSupTax.Checked = true;
            }
            else
            {
                chkSupTax.Checked = false;
            }
            txtsupcgst.Text = dt.Rows[0][40].ToString();
            txtsupcgstTot.Text = dt.Rows[0][41].ToString();
            txtsupsgst.Text = dt.Rows[0][42].ToString();
            txtsupsgstTot.Text = dt.Rows[0][43].ToString();
            txtsupigst.Text = dt.Rows[0][44].ToString();
            txtsupigstTot.Text = dt.Rows[0][45].ToString();


            ddlProfit.SelectedValue = dt.Rows[0][46].ToString();
            if (ddlProfit.SelectedValue == "1")
            {
                txtProfitAmount.Text = dt.Rows[0][47].ToString();
            }
            else
            {
                txtProfitAmount.Text = dt.Rows[0][48].ToString();
            }
            txtProfitAmountTot.Text = dt.Rows[0][49].ToString();

            if (ddlProfit.SelectedValue == "1")
            {
                txtClntSc2.Text = dt.Rows[0][50].ToString();
            }
            else
            {
                txtClntSc2.Text = dt.Rows[0][51].ToString();
            }

            txtClntSc2Tot.Text = dt.Rows[0][52].ToString();


            ddlclntTds.SelectedValue = dt.Rows[0][53].ToString();
            if (ddlclntTds.SelectedValue == "1")
            {
                txtClntTds.Text = dt.Rows[0][54].ToString();
            }
            else
            {
                txtClntTds.Text = dt.Rows[0][55].ToString();
            }

            txtClntTdsTot.Text = dt.Rows[0][56].ToString();


            txtDiscount.Text = dt.Rows[0][57].ToString();
            txtClntDiscountTot.Text = dt.Rows[0][58].ToString();
            txtOtherchrg.Text = dt.Rows[0][59].ToString();
            txtOtherchrgTot.Text = dt.Rows[0][60].ToString();

            if (dt.Rows[0][61].ToString() == "1")
            {
                chkClntTax.Checked = true;
            }
            else
            {
                chkClntTax.Checked = false;
            }
            txtClntCgst.Text = dt.Rows[0][62].ToString();
            txtClntCgstTot.Text = dt.Rows[0][63].ToString();
            txtClntSgst.Text = dt.Rows[0][64].ToString();
            txtClntSgstTot.Text = dt.Rows[0][65].ToString();
            txtClntIgst.Text = dt.Rows[0][66].ToString();
            txtClntIgstTot.Text = dt.Rows[0][67].ToString();
            txtSupplierCost.Text = dt.Rows[0][68].ToString();

            lblSupCost.Text = dt.Rows[0][68].ToString();
            txtClientCost.Text = dt.Rows[0][69].ToString();
            lblClientCost.Text = dt.Rows[0][69].ToString();

            //  txtFareBasis.Text = dt.Rows[0][19].ToString();


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
            objClassDet.sReferenceNo = Session["eid"].ToString();
            objClassDet.sGroupName = "0";
            objClassDet.sAirPNR = "0";
            objClassDet.sCRS = "0";
            objClassDet.sFlightClass = "";
            objClassDet.sSector = "0";
            objClassDet.FillGrid(objClassDet, GridView2, "ShowSearch", "");
        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, lblmsg);
        }
    }

    public void AddSector()
    {
        objSector.nTicketingDetID = Session["Detid"].ToString();

        foreach (RepeaterItem item in rptSector.Items)
        {
            //objClass.nTicketingID = txtTicketingID.Text.Trim();
            // objClass.sSector = validation.stringToDBString(txtSector.Text.Trim());
            // objClass.sAirline = validation.stringToDBString(txtAirline.Text.Trim());
            //  objClass.dtTDate = validation.dateToText(txttTDate.Text.Trim());

            if (rptSector.Items.Count > 0)
            {
                HiddenField hdn = item.FindControl("hdnRow") as HiddenField;
                Label lblsector = item.FindControl("lblsector") as Label;
                TextBox txtSecAirR = item.FindControl("txtSecAirR") as TextBox;
                TextBox txtdtTravelR = item.FindControl("txtdtTravelR") as TextBox;



                DataTable dt = objSector.viewData(objSector, "show", hdn.Value);
                if (dt.Rows.Count > 0)
                {
                    objSector.nTickerSectorID = dt.Rows[0][0].ToString();
                    objSector.sSector = lblsector.Text;
                    objSector.sAirline = txtSecAirR.Text;
                    objSector.dtTDate = validation.dateToText(txtdtTravelR.Text);
                    var xyz = objSector.User_Operation(objSector, "edit");
                }
                else
                {
                    objSector.sSector = lblsector.Text;
                    objSector.sAirline = txtSecAirR.Text;
                    objSector.dtTDate = validation.dateToText(txtdtTravelR.Text);
                    var xyz = objSector.User_Operation(objSector, "add");
                }




            }



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
    //protected void ddlPageSizeDet_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    GridView2.PageSize = int.Parse(ddlPageSizeDet.SelectedValue);
    //    displayGridDet();
    //}

    public void Booking_Generate()
    {
        if (ddlTicketType.SelectedValue == "1")
        {
            DataTable dt = objClass.viewData(objClass, "MaxBookNoDom", validation.dateToText(txtdtBooking.Text));
            if (dt.Rows.Count > 0)
            {
                txtTicketBookingNo.Text = dt.Rows[0][0].ToString();
            }
        }
        else if (ddlTicketType.SelectedValue == "2")
        {
            DataTable dt = objClass.viewData(objClass, "MaxBookNoINT", validation.dateToText(txtdtBooking.Text));
            if (dt.Rows.Count > 0)
            {
                txtTicketBookingNo.Text = dt.Rows[0][0].ToString();
            }
        }
        else if (ddlTicketType.SelectedValue == "3")
        {
            DataTable dt = objClass.viewData(objClass, "MaxBookNoBSP", validation.dateToText(txtdtBooking.Text));
            if (dt.Rows.Count > 0)
            {
                txtTicketBookingNo.Text = dt.Rows[0][0].ToString();
            }
        }
        else if (ddlTicketType.SelectedValue == "4")
        {

        }
        else if (ddlTicketType.SelectedValue == "5")
        {
            DataTable dt = objClass.viewData(objClass, "MaxBookNoVOID", validation.dateToText(txtdtBooking.Text));
            if (dt.Rows.Count > 0)
            {
                txtTicketBookingNo.Text = dt.Rows[0][0].ToString();
            }
        }
        else
        {
            DataTable dt = objClass.viewData(objClass, "MaxBookNo", validation.dateToText(txtdtBooking.Text));
            if (dt.Rows.Count > 0)
            {
                txtTicketBookingNo.Text = dt.Rows[0][0].ToString();
            }
        }

    }



    protected void btnAddDet_Click(object sender, EventArgs e)
    {
        try
        {
            lblmsg.Text = "";
            if (Session["tticketing"].ToString() == ViewState["tticketing"].ToString())
            {
                paraDet();
                var xyz = objClassDet.User_Operation(objClassDet, "add");
                var strArr1 = xyz.Split(',');
                if (strArr1[0] == "1")
                {
                    string TicketDetID = strArr1[2].ToString();
                    Session["Detid"] = TicketDetID;
                    AddSector();
                }

                DetButtonVisible();
                tblGridDet.Visible = true;
                displayGridDet();
                //clrfieldDet();
                valobj.showMsg(xyz, lblmsg);
                string aa = Server.UrlEncode(System.DateTime.Now.ToString());
                Session["tticketing"] = aa;
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
            Label IDD = (Label)GridView2.Rows[row].Cells[0].FindControl("lblgroupid");
            Session["eid"] = IDD.Text;
            btnAdd.Visible = false;
            //btnUpdate.Visible = false;
            //btnDelete.Visible = false;
            //btnUpdate.Visible = true;
            btnAddDet.Visible = false;
            btnUpdateDet.Visible = true;
            // btnDeleteDet.Visible = false;
            DisableData();

            GetFormDataDet();
            objSector.FillReapter(objSector, rptSector, "showRpt", IDDet.Text);
            displayGridDet();
            if (ddlBookType.SelectedValue == "2")
            {
                tblrefund.Visible = true;

                GetFormDataRefund();

                txtProfitAmount_TextChanged(this, e);
            }
            else
            {
                tblrefund.Visible = false;
            }
            lblmsg.Text = "";

            txtSector.Enabled = false;

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
            //objClass.nTicketingID = Session["eid"].ToString();
            //var abc1 = objClass.User_Operation(objClass, "edit");


            paraDet();
            objClassDet.nTicketingDetID = Session["Detid"].ToString();
            var abc = objClassDet.User_Operation(objClassDet, "edit");

            if (ddlBookType.SelectedValue == "2")
            {
                RefundSave();
            }
            AddSector();
            tblGridDet.Visible = true;
            displayGridDet();
            btnAdd.Visible = false;

            btnAddDet.Visible = true;
            btnUpdateDet.Visible = false;
            btnPrint.Visible = true;
            btnPaymentHistory.Visible = true;
            DisableData();
            // txtSector.Enabled = true;
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

    protected void btnDeleteDet_Click(object sender, EventArgs e)
    {
        try
        {
            DeleteDetRecord();
            txtSector.Enabled = true;
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
        objClassDet.nTicketingDetID = Session["Detid"].ToString();
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
        txtSector.Enabled = true;

        clrfield();
        clrfieldDet();
        btnVisible();
        txtdtBooking.Text = validation.fillDate();
        VisibleData();
        Booking_Generate();

        Session["eid"] = "";
        Session["Detid"] = "";
        Session["TTid"] = "";
    }
    protected void lnkList_Click(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        tblmain.Visible = false;
        tblGrd.Visible = true;
        Session["eid"] = "";
        Session["Detid"] = "";
        Session["TTid"] = "";
        displayGrid();
        PnlPayment.Visible = false;
        objAccount.ddlOperation(objAccount, "ddlCustomer", "", ddlSClient);
        objBranch.ddlOperation(objBranch, "Show", "", ddlSLoc);
        objAccount.ddlOperation(objAccount, "ShowddlAccount", "", ddlSSup);
        objClass.ddlOperation(objClass, "ShowInvNo", "", ddlInvoiceNo);
        Response.Redirect("tgroup_ticketing_list.aspx");
    }
    protected void txtdtBooking_TextChanged(object sender, EventArgs e)
    {
        Booking_Generate();
    }


    protected void txtProfitAmount_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (txtFareBasis.Text == "")
            {
                txtFareBasis.Text = "0";
            }
            if (txtAirplb.Text == "")
            {
                txtAirplb.Text = "0";
            }
            //if (txtAirInc.Text == "")
            //{
            //    txtAirInc.Text = "0";
            //}
            if (txtAirComm.Text == "")
            {
                txtAirComm.Text = "0";
            }
            if (txtSupSc.Text == "")
            {
                txtSupSc.Text = "0";
            }
            if (txtProfitAmount.Text == "")
            {
                txtProfitAmount.Text = "0";
            }
            if (txtOtherTax.Text == "")
            {
                txtOtherTax.Text = "0";
            }
            if (txtProfitAmount.Text == "")
            {
                txtProfitAmount.Text = "0";
            }
            if (txtDiscount.Text == "")
            {
                txtDiscount.Text = "0";
            }
            if (txtYQtax.Text == "")
            {
                txtYQtax.Text = "0";
            }
            if (txtYRtax.Text == "")
            {
                txtYRtax.Text = "0";
            }
            //if (txtOcTax.Text == "")
            //{
            //    txtOcTax.Text = "0";
            //}
            if (txtK3Tax.Text == "")
            {
                txtK3Tax.Text = "0";
            }
            if (txtSupTds.Text == "")
            {
                txtSupTds.Text = "0";
            }
            if (txtClntTds.Text == "")
            {
                txtClntTds.Text = "0";
            }
            if (txtClntSc2.Text == "")
            {
                txtClntSc2.Text = "0";
            }
            if (txtRefundAmt.Text == "")
            {
                txtRefundAmt.Text = "0";
            }
            if (txtrfnSC.Text == "")
            {
                txtrfnSC.Text = "0";
            }
            if (txtRfnCGst.Text == "")
            {
                txtRfnCGst.Text = "0";
            }
            if (txtRfnSGst.Text == "")
            {
                txtRfnSGst.Text = "0";
            }
            if (txtRfnIGst.Text == "")
            {
                txtRfnIGst.Text = "0";
            }
            if (txtOtherchrg.Text == "")
            {
                txtOtherchrg.Text = "0";
            }
            //Clnt Side Tax
            if (txtClntBasicFare.Text == "")
            {
                txtClntBasicFare.Text = "0";
            }
            if (txtClntYQTax.Text == "")
            {
                txtClntYQTax.Text = "0";
            }
            if (txtClntYRTax.Text == "")
            {
                txtClntYRTax.Text = "0";
            }
            if (txtClntK3Tax.Text == "")
            {
                txtClntK3Tax.Text = "0";
            }
            //if (txtClntAirInc.Text == "")
            //{
            //    txtClntAirInc.Text = "0";
            //}
            if (txtClntAirCom.Text == "")
            {
                txtClntAirCom.Text = "0";
            }
            if (txtClntAirPlb.Text == "")
            {
                txtClntAirPlb.Text = "0";
            }
            //if (txtClntOCTax.Text == "")
            //{
            //    txtClntOCTax.Text = "0";

            //}
            if (txtClntOtherTax.Text == "")
            {
                txtClntOtherTax.Text = "0";

            }
            if (txtSupDiscount.Text == "")
            {
                txtSupDiscount.Text = "0";

            }


            //GST Calculation
            GstCal();


            // string igst, sgst, cgst;
            // Total Amount of Basic Fare, YQ, YR, K3, PLB, IATA COMM AN TIKET COST



            txtBasicTot.Text = (double.Parse(txtFareBasis.Text) * double.Parse(txtSupQty.Text)).ToString();
            txtYQTaxTot.Text = (double.Parse(txtYQtax.Text) * double.Parse(txtSupQty.Text)).ToString();
            txtYRTaxTot.Text = (double.Parse(txtYRtax.Text) * double.Parse(txtSupQty.Text)).ToString();
            txtK3Tot.Text = (double.Parse(txtK3Tax.Text) * double.Parse(txtSupQty.Text)).ToString();
            txtOtherTaxtot.Text = (double.Parse(txtOtherTax.Text) * double.Parse(txtSupQty.Text)).ToString();
            txtAirComTot.Text = (double.Parse(txtAirComm.Text) * double.Parse(txtSupQty.Text)).ToString();
            txtAirPlbTot.Text = (double.Parse(txtAirplb.Text) * double.Parse(txtSupQty.Text)).ToString();



            txtClntTicketFare.Text = (double.Parse(txtBasicTot.Text) + double.Parse(txtYQTaxTot.Text) + double.Parse(txtYRTaxTot.Text) + double.Parse(txtK3Tot.Text) + double.Parse(txtOtherTaxtot.Text) + double.Parse(txtAirComTot.Text) + double.Parse(txtAirPlbTot.Text)).ToString();
            txtSupTicketFare.Text = txtClntTicketFare.Text;


            string supSc, ClntSC, ClntSC2, SupTDS, ClntTDS;

            if (ddlSupScType.SelectedValue == "0")
            {
                supSc = (double.Parse(txtSupSc.Text)).ToString();
            }
            else
            {
                supSc = (double.Parse(txtSupplierCost.Text) * double.Parse(txtSupSc.Text) / 100).ToString();
                //txtBuyCost.Text = (double.Parse(txtSupplierCost.Text) + Profit - (double.Parse(txtDiscount.Text))).ToString();
                //txtProfitAmt.Focus();
            }
            txtSupScTot.Text = (double.Parse(supSc) * double.Parse(txtSupQty.Text)).ToString();

            if (ddlSupTds.SelectedValue == "0")
            {
                SupTDS = (double.Parse(txtSupTds.Text)).ToString();
            }
            else
            {
                SupTDS = (double.Parse(supSc) * double.Parse(txtSupTds.Text) / 100).ToString();
                //txtBuyCost.Text = (double.Parse(txtSupplierCost.Text) + Profit - (double.Parse(txtDiscount.Text))).ToString();
                //txtProfitAmt.Focus();
            }
            txtSupTdsTot.Text = (double.Parse(SupTDS) * double.Parse(txtSupQty.Text)).ToString();
            txtSupDiscountTot.Text = (double.Parse(txtSupDiscount.Text) * double.Parse(txtSupQty.Text)).ToString();

            //Buying Cost
            if (ddlBookType.SelectedValue == "2")
            {
                string SupCost = ((double.Parse(txtSupTicketFare.Text)) + (double.Parse(txtSupScTot.Text)) - (double.Parse(txtSupTdsTot.Text)) - (double.Parse(txtSupDiscountTot.Text))
                 + (double.Parse(txtsupcgstTot.Text)) + (double.Parse(txtsupsgstTot.Text)) + (double.Parse(txtsupigstTot.Text))).ToString();

                txtSupplierCost.Text = (double.Parse(SupCost) - double.Parse(txtRefundAmt.Text) - double.Parse(txtRfnCGst.Text) - double.Parse(txtRfnSGst.Text) - double.Parse(txtRfnIGst.Text)).ToString();
            }
            else
            {
                txtSupplierCost.Text = ((double.Parse(txtSupTicketFare.Text)) + (double.Parse(txtSupScTot.Text)) - (double.Parse(txtSupTdsTot.Text)) - (double.Parse(txtSupDiscountTot.Text))
                 + (double.Parse(txtsupcgstTot.Text)) + (double.Parse(txtsupsgstTot.Text)) + (double.Parse(txtsupigstTot.Text))).ToString();

            }

            //For Supplier Ticket Fare



            lblSupCost.Text = ((double.Parse(txtSupTicketFare.Text)) + (double.Parse(txtSupScTot.Text)) -
           (double.Parse(txtSupTdsTot.Text)) - (double.Parse(txtSupDiscountTot.Text)) + (double.Parse(txtsupcgstTot.Text)) + (double.Parse(txtsupsgstTot.Text)) + (double.Parse(txtsupigstTot.Text))).ToString();



            if (ddlProfit.SelectedValue == "0")
            {
                ClntSC = (double.Parse(txtProfitAmount.Text)).ToString();
            }
            else
            {
                ClntSC = (double.Parse(txtSupplierCost.Text) * double.Parse(txtProfitAmount.Text) / 100).ToString();

            }
            txtProfitAmountTot.Text = (double.Parse(ClntSC) * double.Parse(txtClntQty.Text)).ToString();
            if (ddlProfit.SelectedValue == "0")
            {
                ClntSC2 = (double.Parse(txtClntSc2.Text)).ToString();
            }
            else
            {
                ClntSC2 = (double.Parse(txtSupplierCost.Text) * double.Parse(txtClntSc2.Text) / 100).ToString();
                //txtBuyCost.Text = (double.Parse(txtSupplierCost.Text) + Profit - (double.Parse(txtDiscount.Text))).ToString();
                //txtProfitAmt.Focus();
            }
            txtClntSc2Tot.Text = (double.Parse(ClntSC2) * double.Parse(txtClntQty.Text)).ToString();

            if (ddlclntTds.SelectedValue == "0")
            {
                ClntTDS = (double.Parse(txtClntTds.Text)).ToString();
            }
            else
            {
                ClntTDS = (double.Parse(ClntSC) * double.Parse(txtClntTds.Text) / 100).ToString();
                //txtBuyCost.Text = (double.Parse(txtSupplierCost.Text) + Profit - (double.Parse(txtDiscount.Text))).ToString();
                //txtProfitAmt.Focus();
            }
            txtClntTdsTot.Text = (double.Parse(ClntTDS) * double.Parse(txtClntQty.Text)).ToString();
            txtClntDiscountTot.Text = (double.Parse(txtDiscount.Text) * double.Parse(txtClntQty.Text)).ToString();
            txtOtherchrgTot.Text = (double.Parse(txtOtherchrg.Text) * double.Parse(txtClntQty.Text)).ToString();
            //Client  Cost or Selling Cost
            if (ddlBookType.SelectedValue == "2")
            {
                //String ClientCost = ((double.Parse(lblSupCost.Text)) + double.Parse(ClntSC) + double.Parse(ClntSC2) - double.Parse(ClntTDS) - double.Parse(txtDiscount.Text) + (double.Parse(txtClntCgst.Text)) + (double.Parse(txtClntSgst.Text)) + (double.Parse(txtClntIgst.Text))).ToString();
                //txtClientCost.Text = (double.Parse(ClientCost) - double.Parse(txtRefundAmt.Text) - double.Parse(txtRfnCGst.Text) - double.Parse(txtRfnSGst.Text) - double.Parse(txtRfnIGst.Text) - double.Parse(txtrfnSC.Text)).ToString();
                txtClientCost.Text = "- " + (double.Parse(txtSupplierCost.Text) - double.Parse(txtrfnSC.Text)).ToString();

            }
            else
            {

                txtClientCost.Text = ((double.Parse(txtSupplierCost.Text)) + double.Parse(txtProfitAmountTot.Text) + double.Parse(txtClntSc2Tot.Text) - double.Parse(txtClntTdsTot.Text) -
               double.Parse(txtClntDiscountTot.Text) + (double.Parse(txtOtherchrgTot.Text)) + (double.Parse(txtClntCgstTot.Text)) + (double.Parse(txtClntSgstTot.Text))
               + (double.Parse(txtClntIgstTot.Text))).ToString();
            }

            //For Client Ticket Fare


            // txtClientCost.Text = ((double.Parse(lblSupCost.Text)) + double.Parse(ClntSC) + double.Parse(ClntSC2) - double.Parse(ClntTDS) - double.Parse(txtDiscount.Text) + (double.Parse(txtClntCgst.Text)) + (double.Parse(txtClntSgst.Text)) + (double.Parse(txtClntIgst.Text))).ToString();
            lblClientCost.Text = ((double.Parse(lblSupCost.Text)) + double.Parse(txtProfitAmountTot.Text) + double.Parse(txtClntSc2Tot.Text) - double.Parse(txtClntTdsTot.Text) -
               double.Parse(txtClntDiscountTot.Text) + (double.Parse(txtOtherchrgTot.Text)) + (double.Parse(txtClntCgstTot.Text)) + (double.Parse(txtClntSgstTot.Text))
               + (double.Parse(txtClntIgstTot.Text))).ToString();

            ShowEmptyText();

            txtClntSc2.Focus();
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
        if (txtFareBasis.Text == "0")
        {
            txtFareBasis.Text = "";
        }
        if (txtAirplb.Text == "0")
        {
            txtAirplb.Text = "";
        }
        //if (txtAirInc.Text == "0")
        //{
        //    txtAirInc.Text = "";
        //}
        if (txtAirComm.Text == "0")
        {
            txtAirComm.Text = "";
        }
        if (txtSupSc.Text == "0")
        {
            txtSupSc.Text = "";
        }
        if (txtProfitAmount.Text == "0")
        {
            txtProfitAmount.Text = "";
        }
        if (txtOtherTax.Text == "0")
        {
            txtOtherTax.Text = "";
        }
        if (txtProfitAmount.Text == "0")
        {
            txtProfitAmount.Text = "";
        }
        if (txtDiscount.Text == "0")
        {
            txtDiscount.Text = "";
        }
        if (txtYQtax.Text == "0")
        {
            txtYQtax.Text = "";
        }
        if (txtYRtax.Text == "0")
        {
            txtYRtax.Text = "";
        }
        //if (txtOcTax.Text == "0")
        //{
        //    txtOcTax.Text = "0";
        //}
        if (txtK3Tax.Text == "0")
        {
            txtK3Tax.Text = "";
        }
        if (txtSupTds.Text == "0")
        {
            txtSupTds.Text = "";
        }
        if (txtClntTds.Text == "0")
        {
            txtClntTds.Text = "";
        }
        if (txtClntSc2.Text == "0")
        {
            txtClntSc2.Text = "";
        }
        if (txtRefundAmt.Text == "0")
        {
            txtRefundAmt.Text = "";
        }
        if (txtrfnSC.Text == "0")
        {
            txtrfnSC.Text = "";
        }
        if (txtRfnCGst.Text == "0")
        {
            txtRfnCGst.Text = "";
        }
        if (txtRfnSGst.Text == "0")
        {
            txtRfnSGst.Text = "";
        }
        if (txtRfnIGst.Text == "0")
        {
            txtRfnIGst.Text = "";
        }
        if (txtOtherchrg.Text == "0")
        {
            txtOtherchrg.Text = "";
        }
        //Clnt Side Tax
        if (txtClntBasicFare.Text == "0")
        {
            txtClntBasicFare.Text = "";
        }
        if (txtClntYQTax.Text == "0")
        {
            txtClntYQTax.Text = "";
        }
        if (txtClntYRTax.Text == "0")
        {
            txtClntYRTax.Text = "";
        }
        if (txtClntK3Tax.Text == "0")
        {
            txtClntK3Tax.Text = "";
        }
        //if (txtClntAirInc.Text == "0")
        //{
        //    txtClntAirInc.Text = "";
        //}
        if (txtClntAirCom.Text == "0")
        {
            txtClntAirCom.Text = "";
        }
        if (txtClntAirPlb.Text == "0")
        {
            txtClntAirPlb.Text = "";
        }
        //if (txtClntOCTax.Text == "0")
        //{
        //    txtClntOCTax.Text = "0";

        //}
        if (txtClntOtherTax.Text == "0")
        {
            txtClntOtherTax.Text = "";

        }
        if (txtSupDiscount.Text == "0")
        {
            txtSupDiscount.Text = "";

        }
    }
    protected void txtOtherTax_TextChanged(object sender, EventArgs e)
    {
        try
        {
            txtClntOtherTax.Text = txtOtherTax.Text;
            txtProfitAmount_TextChanged(this, e);
            txtAirComm.Focus();

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
            txtProfitAmount_TextChanged(this, e);
            txtClntTds.Focus();
        }
        catch
        {

        }
        finally
        {

        }
    }
    protected void txtFareBasis_TextChanged(object sender, EventArgs e)
    {
        try
        {
            txtClntBasicFare.Text = txtFareBasis.Text;
            ShowEmptyText();
            AirComm();
            //  AirInc();

            AirPLB();

            txtProfitAmount_TextChanged(this, e);

            txtYQtax.Focus();


        }
        catch
        {

        }
        finally
        {

        }
    }
    public void AirComm()
    {
        DataTable dtComm = new DataTable();
        objTickCom.dtEndDate = validation.fillDate();
        dtComm = objTickCom.viewData(objTickCom, "ShowComm", ddlCarrierID.SelectedValue);
        if (dtComm.Rows.Count > 0)
        {
            if (dtComm.Rows[0]["nTicketTypeID"].ToString() == ddlTicketType.SelectedValue)
            {
                if (dtComm.Rows[0]["nCalMethodID"].ToString() == "0")
                {
                    txtAirComm.Text = (double.Parse(txtFareBasis.Text) * double.Parse(dtComm.Rows[0]["nInctValue"].ToString()) / 100).ToString();
                }
                else if (dtComm.Rows[0]["nCalMethodID"].ToString() == "1")
                {


                    txtAirComm.Text = ((double.Parse(txtFareBasis.Text) * double.Parse(dtComm.Rows[0]["nInctValue"].ToString()) / 100) +
                  (double.Parse(txtYQtax.Text) * double.Parse(dtComm.Rows[0]["nInctValue"].ToString()) / 100)).ToString();

                }
                else
                {
                    txtAirComm.Text = "0";
                }
                //else if (dtComm.Rows[0]["nCalMethodID"].ToString() == "1")
                //{
                //    txtAirComm.Text = ((double.Parse(txtFareBasis.Text) * double.Parse(dtComm.Rows[0]["nInctValue"].ToString()) / 100) +
                //   (double.Parse(txtYQtax.Text) * double.Parse(dtComm.Rows[0]["nInctValue"].ToString()) / 100) + (double.Parse(txtYRtax.Text) * double.Parse(dtComm.Rows[0]["nInctValue"].ToString()) / 100) +
                //   (double.Parse(txtSupTds.Text) * double.Parse(dtComm.Rows[0]["nInctValue"].ToString()) / 100) + (double.Parse(txtOtherTax.Text) * double.Parse(dtComm.Rows[0]["nInctValue"].ToString()) / 100)).ToString();

                //}


            }

        }
        else
        {
            txtAirComm.Text = "0";
        }
    }
    //public void AirInc()
    //{
    //    mticketinc_Class objTicinc = new mticketinc_Class();
    //    DataTable dtINC = new DataTable();
    //    objTicinc.dtEndDate = validation.fillDate();
    //    dtINC = objTicinc.viewData(objTicinc, "ShowInc", ddlCarrierID.SelectedValue);
    //    if (dtINC.Rows.Count > 0)
    //    {
    //        if (dtINC.Rows[0]["nTicketTypeID"].ToString() == ddlTicketType.SelectedValue)
    //        {
    //            if (dtINC.Rows[0]["nCalMethodID"].ToString() == "0")
    //            {
    //                txtAirInc.Text = (double.Parse(txtFareBasis.Text) * double.Parse(dtINC.Rows[0]["nIncValue"].ToString()) / 100).ToString();
    //            }
    //            else if (dtINC.Rows[0]["nCalMethodID"].ToString() == "1")
    //            {
    //                txtAirInc.Text = ((double.Parse(txtFareBasis.Text) * double.Parse(dtINC.Rows[0]["nIncValue"].ToString()) / 100) +
    //             (double.Parse(txtYQtax.Text) * double.Parse(dtINC.Rows[0]["nIncValue"].ToString()) / 100) + (double.Parse(txtYRtax.Text) * double.Parse(dtINC.Rows[0]["nIncValue"].ToString()) / 100) +
    //             (double.Parse(txtSupTds.Text) * double.Parse(dtINC.Rows[0]["nIncValue"].ToString()) / 100) + (double.Parse(txtOtherTax.Text) * double.Parse(dtINC.Rows[0]["nIncValue"].ToString()) / 100)).ToString();


    //            }
    //            else if (dtINC.Rows[0]["nCalMethodID"].ToString() == "2")
    //            {


    //                txtAirInc.Text = ((double.Parse(txtFareBasis.Text) * double.Parse(dtINC.Rows[0]["nIncValue"].ToString()) / 100) +
    //              (double.Parse(txtYQtax.Text) * double.Parse(dtINC.Rows[0]["nInctValue"].ToString()) / 100)).ToString();

    //            }
    //            else
    //            {
    //                txtAirInc.Text = "0";
    //            }

    //        }

    //    }
    //    else
    //    {
    //        txtAirInc.Text = "0";
    //    }
    //}
    public void AirPLB()
    {
        mtickerplb_Class objTicplb = new mtickerplb_Class();
        DataTable dtPlb = new DataTable();
        objTicplb.dtEndDate = validation.fillTextDate();

        dtPlb = objTicplb.viewData(objTicplb, "ShowPlb", ddlCarrierID.SelectedValue);
        if (dtPlb.Rows.Count > 0)
        {
            if (dtPlb.Rows[0]["nTicketTypeID"].ToString() == ddlTicketType.SelectedValue)
            {
                if (dtPlb.Rows[0]["nCalMethodID"].ToString() == "0")
                {
                    txtAirplb.Text = (double.Parse(txtFareBasis.Text) * double.Parse(dtPlb.Rows[0]["nIncValue"].ToString()) / 100).ToString();
                }
                else if (dtPlb.Rows[0]["nCalMethodID"].ToString() == "1")
                {


                    txtAirplb.Text = ((double.Parse(txtFareBasis.Text) * double.Parse(dtPlb.Rows[0]["nIncValue"].ToString()) / 100) +
                  (double.Parse(txtYQtax.Text) * double.Parse(dtPlb.Rows[0]["nIncValue"].ToString()) / 100)).ToString();

                }

                else
                {
                    txtAirplb.Text = "0";
                }

                //  else if (dtPlb.Rows[0]["nCalMethodID"].ToString() == "1")
                // {
                //     txtAirplb.Text = ((double.Parse(txtFareBasis.Text) * double.Parse(dtPlb.Rows[0]["nIncValue"].ToString()) / 100) +
                //(double.Parse(txtYQtax.Text) * double.Parse(dtPlb.Rows[0]["nIncValue"].ToString()) / 100) + (double.Parse(txtYRtax.Text) * double.Parse(dtPlb.Rows[0]["nIncValue"].ToString()) / 100) +
                //(double.Parse(txtSupTds.Text) * double.Parse(dtPlb.Rows[0]["nIncValue"].ToString()) / 100) + (double.Parse(txtOtherTax.Text) * double.Parse(dtPlb.Rows[0]["nIncValue"].ToString()) / 100)).ToString();


                //}

            }

        }
        else
        {
            txtAirplb.Text = "0";
        }
    }

    protected void txtAirInc_TextChanged(object sender, EventArgs e)
    {
        try
        {

            txtProfitAmount_TextChanged(this, e);
            txtSupSc.Focus();

        }
        catch
        {

        }
        finally
        {

        }
    }
    protected void txtAirComm_TextChanged(object sender, EventArgs e)
    {
        try
        {
            txtClntAirCom.Text = txtAirComm.Text;
            txtProfitAmount_TextChanged(this, e);
            txtAirplb.Focus();

        }
        catch
        {

        }
        finally
        {

        }
    }
    protected void txtAirplb_TextChanged(object sender, EventArgs e)
    {
        try
        {
            txtAirplb.Text = txtClntAirPlb.Text;
            txtProfitAmount_TextChanged(this, e);
            txtSupSc.Focus();

        }
        catch
        {

        }
        finally
        {

        }
    }
    protected void txtAirInc_TextChanged1(object sender, EventArgs e)
    {
        txtAirplb.Text = txtClntAirPlb.Text;
        txtProfitAmount_TextChanged(this, e);
        txtAirComm.Focus();
    }

    protected void txtSupSc_TextChanged(object sender, EventArgs e)
    {
        try
        {
            txtProfitAmount_TextChanged(this, e);
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
            txtProfitAmount_TextChanged(this, e);
            txtFareBasis.Focus();
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
            ddlSupScType.Focus();
            chkSupTax.Focus();
        }
        catch
        {

        }
        finally
        {

        }
    }

    protected void txtClntTds_TextChanged(object sender, EventArgs e)
    {
        try
        {
            txtProfitAmount_TextChanged(this, e);
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

    public void GstCal()
    {
        //Sup GST
        DataTable dtSupgst = objSupGst.viewData(objSupGst, "show", ddlsupplier.SelectedValue);
        DataTable dtSupState = objSupplier.viewData(objSupplier, "ShowAcc", ddlsupplier.SelectedValue);
        DataTable dtClntState = objClient.viewData(objClient, "ShowAcc", ddlAgentID.SelectedValue);

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
            if (dtSupState.Rows.Count > 0)
            {



                string SupState = dtSupState.Rows[0]["nStateID"].ToString();

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
                        if (SupState == CompState)
                        {
                            double Profit = double.Parse(txtClientCost.Text) * double.Parse(txtSupSc.Text) / 100;
                            txtsupigst.Text = "0";
                            txtsupcgst.Text = (((Profit)) * (double.Parse(Supsgst)) / 100).ToString();
                            txtsupsgst.Text = (((Profit)) * (double.Parse(Supcgst)) / 100).ToString();
                        }
                        else
                        {
                            double Profit = double.Parse(txtClientCost.Text) * double.Parse(txtSupSc.Text) / 100;
                            txtsupigst.Text = ((Profit) * (double.Parse(Supigst)) / 100).ToString();
                            txtsupcgst.Text = "0";
                            txtsupsgst.Text = "0";

                        }
                    }

                }

                txtsupcgstTot.Text = (double.Parse(txtsupcgst.Text) * double.Parse(txtSupQty.Text)).ToString();
                txtsupsgstTot.Text = (double.Parse(txtsupsgst.Text) * double.Parse(txtSupQty.Text)).ToString();
                txtsupigstTot.Text = (double.Parse(txtsupigst.Text) * double.Parse(txtSupQty.Text)).ToString();

            }
            else
            {
                txtsupigst.Text = "0";
                txtsupcgst.Text = "0";
                txtsupsgst.Text = "0";
                txtsupcgstTot.Text = "0";
                txtsupsgstTot.Text = "0";
                txtsupigstTot.Text = "0";
            }
        }
        else
        {
            txtsupigst.Text = "0";
            txtsupcgst.Text = "0";
            txtsupsgst.Text = "0";
            txtsupcgstTot.Text = "0";
            txtsupsgstTot.Text = "0";
            txtsupigstTot.Text = "0";
        }

        //Client GST
        DataTable dtClntgst = objClntGst.viewData(objClntGst, "show", ddlAgentID.SelectedValue);
        if (dtClntgst.Rows.Count > 0)
        {
            if (dtClntState.Rows.Count > 0)
            {

                string ClntState = dtClntState.Rows[0]["nStateID"].ToString();
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

                    if (ddlProfit.SelectedValue == "0")
                    {
                        if (ClntState == CompState)
                        {
                            txtClntIgst.Text = "0";
                            txtClntCgst.Text = ((double.Parse(txtProfitAmount.Text)) * (double.Parse(Clntsgst)) / 100).ToString();
                            txtClntSgst.Text = ((double.Parse(txtProfitAmount.Text)) * (double.Parse(Clntcgst)) / 100).ToString();
                        }
                        else
                        {
                            txtClntIgst.Text = ((double.Parse(txtProfitAmount.Text)) * (double.Parse(Clntigst)) / 100).ToString();
                            txtClntCgst.Text = "0";
                            txtClntSgst.Text = "0";
                        }
                    }
                    else
                    {
                        if (ClntState == CompState)
                        {
                            double Profit = double.Parse(txtClientCost.Text) * double.Parse(txtProfitAmount.Text) / 100;
                            txtClntIgst.Text = "0";
                            txtClntCgst.Text = (((Profit)) * (double.Parse(Clntsgst)) / 100).ToString();
                            txtClntSgst.Text = (((Profit)) * (double.Parse(Clntcgst)) / 100).ToString();
                        }
                        else
                        {
                            double Profit = double.Parse(txtClientCost.Text) * double.Parse(txtProfitAmount.Text) / 100;
                            txtClntIgst.Text = ((Profit) * (double.Parse(Clntigst)) / 100).ToString();
                            txtClntCgst.Text = "0";
                            txtClntSgst.Text = "0";
                        }
                    }
                }
                txtClntCgstTot.Text = (double.Parse(txtClntCgst.Text) * double.Parse(txtSupQty.Text)).ToString();
                txtClntSgstTot.Text = (double.Parse(txtClntSgst.Text) * double.Parse(txtSupQty.Text)).ToString();
                txtClntIgstTot.Text = (double.Parse(txtClntIgst.Text) * double.Parse(txtSupQty.Text)).ToString();
            }
            else
            {
                txtClntCgst.Text = "0";
                txtClntSgst.Text = "0";
                txtClntIgst.Text = "0";
                txtClntCgstTot.Text = "0";
                txtClntSgstTot.Text = "0";
                txtClntIgstTot.Text = "0";

            }


        }
        else
        {

            txtClntCgst.Text = "0";
            txtClntSgst.Text = "0";
            txtClntIgst.Text = "0";
            txtClntCgstTot.Text = "0";
            txtClntSgstTot.Text = "0";
            txtClntIgstTot.Text = "0";

        }

        //Refund GST


        DataTable dtrfngst = objClntGst.viewData(objClntGst, "show", ddlAgentID.SelectedValue);
        if (dtrfngst.Rows.Count > 0)
        {

            string ClntState = dtClntState.Rows[0]["nStateID"].ToString();
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
    protected void txtYQtax_TextChanged(object sender, EventArgs e)
    {
        txtClntYQTax.Text = txtYQtax.Text;
        txtProfitAmount_TextChanged(this, e);
        txtYRtax.Focus();
    }
    protected void txtYRtax_TextChanged(object sender, EventArgs e)
    {
        txtClntYRTax.Text = txtYRtax.Text;
        txtProfitAmount_TextChanged(this, e);
        txtK3Tax.Focus();
    }
    //protected void txtOcTax_TextChanged(object sender, EventArgs e)
    //{
    //    txtProfitAmount_TextChanged(this, e);
    //    txtOtherTax.Focus();
    //}
    protected void txtK3Tax_TextChanged(object sender, EventArgs e)
    {
        txtClntK3Tax.Text = txtK3Tax.Text;
        txtProfitAmount_TextChanged(this, e);
        txtOtherTax.Focus();
    }
    protected void txtClntSc2_TextChanged(object sender, EventArgs e)
    {
        txtProfitAmount_TextChanged(this, e);
        txtClntTds.Focus();
    }
    protected void ddlCarrierID_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dt = objCarrier.viewData(objCarrier, "Show", ddlCarrierID.SelectedValue);
        if (dt.Rows.Count > 0)
        {
            txtTicketNo.Text = dt.Rows[0]["sDesignator"].ToString() + "-";
            txtTicketNo.Focus();
        }
    }

    protected void ddlLocationID_TextChanged(object sender, EventArgs e)
    {
        txtProfitAmount_TextChanged(this, e);
        txtFareBasis.Focus();
    }
    protected void txtTicketNo_TextChanged(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = objClassDet.viewData(objClassDet, "FillDataTicket", txtTicketNo.Text);
            if (dt.Rows.Count > 0)
            {
                Session["eid"] = dt.Rows[0]["nTicketingID"].ToString();
                GetFormData();
                GetFormDataDet();
                btnUpdateDet.Visible = true;
                btnPrint.Visible = true;
                btnPaymentHistory.Visible = true;
                btnAdd.Visible = false;
                string aa = Server.UrlEncode(System.DateTime.Now.ToString());
                Session["tticketing"] = aa;
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
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, lblmsg);
        }

    }
    protected void txtOtherchrg_TextChanged(object sender, EventArgs e)
    {
        try
        {
            txtProfitAmount_TextChanged(this, e);
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

    protected void txtClntBasicFare_TextChanged(object sender, EventArgs e)
    {
        txtFareBasis.Text = txtClntBasicFare.Text;
        ShowEmptyText();
        AirComm();
        //  AirInc();

        AirPLB();


        txtProfitAmount_TextChanged(this, e);

        txtClntYQTax.Focus();
    }
    protected void txtClntYQTax_TextChanged(object sender, EventArgs e)
    {
        txtYQtax.Text = txtClntYQTax.Text;
        txtProfitAmount_TextChanged(this, e);
        txtClntYRTax.Focus();
    }
    protected void txtClntYRTax_TextChanged(object sender, EventArgs e)
    {
        txtYRtax.Text = txtClntYRTax.Text;
        txtProfitAmount_TextChanged(this, e);
        txtClntK3Tax.Focus();
    }
    protected void txtClntK3Tax_TextChanged(object sender, EventArgs e)
    {
        txtK3Tax.Text = txtClntK3Tax.Text;
        txtProfitAmount_TextChanged(this, e);
        txtClntOtherTax.Focus();
    }
    protected void txtClntAirInc_TextChanged(object sender, EventArgs e)
    {
        txtProfitAmount_TextChanged(this, e);
        txtProfitAmount.Focus();
    }
    protected void txtClntAirCom_TextChanged(object sender, EventArgs e)
    {
        txtAirComm.Text = txtClntAirCom.Text;
        txtProfitAmount_TextChanged(this, e);
        txtClntAirPlb.Focus();
    }
    protected void txtClntAirPlb_TextChanged(object sender, EventArgs e)
    {
        txtAirplb.Text = txtClntAirPlb.Text;
        txtProfitAmount_TextChanged(this, e);
        txtProfitAmount.Focus();
    }
    protected void txtClntOCTax_TextChanged(object sender, EventArgs e)
    {
        txtProfitAmount_TextChanged(this, e);
        txtClntOtherTax.Focus();
    }
    protected void txtClntOtherTax_TextChanged(object sender, EventArgs e)
    {
        txtOtherTax.Text = txtClntOtherTax.Text;
        txtProfitAmount_TextChanged(this, e);
        txtProfitAmount.Focus();
    }
    protected void txtSupDiscount_TextChanged(object sender, EventArgs e)
    {
        txtProfitAmount_TextChanged(this, e);
        btnAdd.Focus();
    }
    protected void txtClntQty_TextChanged(object sender, EventArgs e)
    {
        txtSupQty.Text = txtClntQty.Text;
        txtProfitAmount_TextChanged(this, e);
        txtClntYQTax.Focus();
    }
    protected void txtSupQty_TextChanged(object sender, EventArgs e)
    {
        txtClntQty.Text = txtSupQty.Text;
        txtProfitAmount_TextChanged(this, e);
        txtYQtax.Focus();
    }

    protected void ddlTicketType_SelectedIndexChanged(object sender, EventArgs e)
    {

        Booking_Generate();



    }
    protected void txtSector_TextChanged(object sender, EventArgs e)
    {

        var abc = txtSector.Text.Split('/');
        string AirCode, nSectorID;
        DataTable dtAirCode = objCarrier.viewData(objCarrier, "Show", ddlCarrierID.SelectedValue);
        if (dtAirCode.Rows.Count > 0)
        {
            AirCode = dtAirCode.Rows[0]["sCode"].ToString();
        }
        else
        {
            AirCode = "";
        }
        DataTable dtMaxID = objSector.viewData(objSector, "showMaxID", "");
        if (dtMaxID.Rows.Count > 0)
        {
            nSectorID = dtMaxID.Rows[0][0].ToString();
        }
        else
        {
            nSectorID = "0";
        }
        if (Session["dtSector"] != null)
        {
            DataTable dt = Session["dtSector"] as DataTable;
            dt.Clear();
            for (int j = 0; j < abc.Length; j++)
            {

                if (j == abc.Length - 1)
                {

                }
                else
                {
                    dt.Rows.Add(new object[] {
                      int.Parse(nSectorID)+j+1,
                        abc[j] + " / " + abc[j+1],
                        AirCode,
                        validation.fillTextDate()
                     });
                }

            }
            rptSector.DataSource = dt;
            rptSector.DataBind();
            Session["dtSector"] = dt;

        }
        else
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("nTickerSectorID");
            dt.Columns.Add("sSector");
            dt.Columns.Add("sAirline");
            dt.Columns.Add("dtTDate");
            for (int i = 0; i < abc.Length; i++)
            {
                if (i == abc.Length - 1)
                {
                    //dt.Rows.Add(new object[] {
                    //i,
                    //abc[i] + " - " + abc[0],
                    //"AI",
                    //""
                    //});
                }
                else
                {
                    dt.Rows.Add(new object[] {
                int.Parse(nSectorID)+i+1,
                abc[i] + " / " + abc[i+1],
                AirCode,
               validation.fillTextDate()
                });
                }

            }

            rptSector.DataSource = dt;
            rptSector.DataBind();
            Session["dtSector"] = dt;
        }


    }





    //Refund 
    public void paraRefund()
    {
        objRefund.nTiketingBookDetID = Session["Detid"].ToString();
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
            DataTable dt = objRefund.viewData(objRefund, "show", Session["Detid"].ToString());

            if (dt.Rows.Count > 0)
            {


                objRefund.nTiketRefundID = dt.Rows[0][0].ToString();
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
            txtProfitAmount_TextChanged(this, e);
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
            txtProfitAmount_TextChanged(this, e);
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
            txtProfitAmount_TextChanged(this, e);
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
        objClassDet.sGroupName = ddlSClient.SelectedValue;
        //objClassDet.sPassportNo = ddlSSup.SelectedValue;
        //objClassDet.sAirlinePnr = ddlSLoc.SelectedValue;
        //objClassDet.sDeparture = ddlSBookType.SelectedValue;
        //objClassDet.dtTravelDate = validation.dateToText(txtSdtBooking.Text);
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

    protected void ddlBookType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlBookType.SelectedValue == "2")
        {
            tblrefund.Visible = true;
            txtdtRfnDate.Text = validation.fillDate();
            displayGridDet();
        }
        else
        {
            tblrefund.Visible = false;
        }
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

        txtPayRemarks.Text = "Group Air Ticket payment for invoice no.: " + InvNo.Text;
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
        txtPayRemarks.Text = "Group Air Ticket payment for invoice no.: " + txtTicketBookingNo.Text;
        txtPayInv.Text = txtTicketBookingNo.Text;
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
        objTicPay.sPayfor = "GroupAirTicket";
        objTicPay.FillGrid(objTicPay, GridPay, "ShowPaymentsModule", Session["eid"].ToString());
    }
    public void paymentPara()
    {
        //Main Table
        //  objTicPay.nPaymentReceiveID = Session["eid"].ToString();
        objTicPay.nPaymentModeID = ddlPayVoucherType.SelectedValue;
        objTicPay.nCashAccountID = ddlPaymentAccount.SelectedValue;
        objTicPay.dtPayment = validation.dateToText(txtdtpayment.Text);
        objTicPay.sVoucherNo = txtPayVoucherNo.Text;
        objTicPay.nTotAmount = txtPayAmount.Text;
        objTicPay.nAgentID = lblAgent.Text;
        objTicPay.sRemarks = txtPayRemarks.Text;
        objTicPay.sPayfor = "GroupAirTicket";

        //Detail Table
        objTicPayDet.nInvoiceID = Session["eid"].ToString();
        objTicPayDet.sInvoiceNo = txtPayInv.Text;
        objTicPayDet.dtInvoiceDate = lblInvoiceDate.Text;
        objTicPayDet.nAmount = txtPayAmount.Text; ;

        objTicPayDet.sRemarks = txtPayRemarks.Text;
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



        //Adding value for bPaid
        if (TotalPaid.ToString() == "" || TotalPaid.ToString() == "0")
        {
            objClass.bPaid = "0";   //UnPaid
        }
        else if (GrandTotal.ToString() == TotalPaid.ToString() || double.Parse(TotalPaid) > double.Parse(GrandTotal))
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
        DataTable dt = objTicPayDet.viewData(objTicPayDet, "GetDataTravel", Session["PayDetid"].ToString());
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
        if (Session["tticketing"].ToString() == ViewState["tticketing"].ToString())
        {
            paymentPara();

            if (Session["Payid"] == null || Session["Payid"] == "")
            {
                var abc = objTicPay.User_Operation(objTicPay, "add");
                var strArr = abc.Split(',');
                if (strArr[0] == "1")
                {
                    string PayID = strArr[2].ToString();
                    Session["Payid"] = PayID;
                    objTicPayDet.nPaymentReceiveID = PayID;
                    var abc1 = objTicPayDet.User_Operation(objTicPayDet, "add");
                }
                valobj.showMsg(abc, lblmsg);


            }
            else
            {
                //Upodate Main Table
                objTicPay.nPaymentReceiveID = Session["Payid"].ToString();
                var abc = objTicPay.User_Operation(objTicPay, "edit");

                //Upodate Detail Table
                objTicPayDet.nPaymentReceiveDetID = Session["PayDetid"].ToString();
                objTicPayDet.nPaymentReceiveID = Session["Payid"].ToString();
                var abc1 = objTicPayDet.User_Operation(objTicPayDet, "edit");

                valobj.showMsg(abc, lblmsg);
                Session["Payid"] = "";
                Session["PayDetid"] = "";

            }
            GetPaidDetails();
            objClass.nTicketingID = Session["eid"].ToString();
            var xyz = objClass.User_Operation(objClass, "bPaidEdit");

            GetBalance();
            Payclrfield();
            DisplayPaymentGrid();
            PayVoucher_Generate();

        }



        string aa = Server.UrlEncode(System.DateTime.Now.ToString());
        Session["tticketing"] = aa;

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
        objTicPay.nPaymentReceiveID = Session["Payid"].ToString();
        var vres = objTicPay.User_Operation(objTicPay, "DeActive");
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
        DataTable dt = objTicPay.viewData(objTicPay, "PVN", validation.dateToText(txtdtpayment.Text));
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
            Response.Redirect("PaymentReceipt/rptpay_receipt_inv.aspx?Detid=" + IDDet.Text + "&sPayfor=AirTicket");
        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, "FAIL", lblmsg);
        }
    }
    protected void btnPaymentReceipt_Click(object sender, EventArgs e)
    {
        Response.Redirect("PaymentReceipt/rptpay_receipt_inv.aspx?id=" + Session["eid"].ToString() + "&sPayfor=AirTicket");
    }

    protected void ddlsupplier_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlsupplierType.SelectedValue == "1")
        {
            objAccount.ddlOperation(objAccount, "ddlCustomer", ddlsupplier.SelectedValue, ddlAgentID);
        }
        else
        {
            objAccount.ddlOperation(objAccount, "ddlCustomer", "", ddlAgentID);
        }

    }

}
