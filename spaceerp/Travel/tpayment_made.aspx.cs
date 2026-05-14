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
    tpayments_made_Class objClass = new tpayments_made_Class();
    tpayments_madedet_Class objClassDet = new tpayments_madedet_Class();
    mlocation_Class objLocation = new mlocation_Class();
    tchartof_account_Class objAccountCode = new tchartof_account_Class();
    mmain_account_Class objAccount = new mmain_account_Class();
    msupplier_Class objSupplier = new msupplier_Class();
    tvisadet_Class objClassGen = new tvisadet_Class();
    tvisa_Class objVisa = new tvisa_Class();
    tticketing_Class objAirTicket = new tticketing_Class();
    thotel_booking_Class objHotels = new thotel_booking_Class();
    texcursion_booking_Class objExcursion = new texcursion_booking_Class();
    tmofabooking_Class objMofa = new tmofabooking_Class();
    tgroupmofa_Class objGroupMofa = new tgroupmofa_Class();
    tmofarecruitement_Class objRecmt = new tmofarecruitement_Class();
    tinsurance_booking_Class objInsurance = new tinsurance_booking_Class();
    ttrainbooking_Class objTrain = new ttrainbooking_Class();
    tbusbooking_Class objBus = new tbusbooking_Class();
    tcar_booking_Class objCar = new tcar_booking_Class();
    tgroup_ticketing_Class objGroupTicket = new tgroup_ticketing_Class();
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
                tblGridM.Visible = true;
                tblGridDet.Visible = false;
              //  displayGrid();
                //   objLocation.ddlOperation(objLocation, "Show", "", ddlPayFor);

                objSupplier.ddlOperation(objSupplier, "showddl", "", ddlSupplier);
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
                var ID = Request.QueryString["ID"];
                if (!string.IsNullOrEmpty(ID))
                {
                    Session["eid"] = ID;

                    btnAdd.Visible = false;
                    //btnAddDet.Visible = true;
                    btnPrint.Visible = true;
                    btnUpdateDet.Visible = true;

                    //btnUpdate.Visible = true;
                    //btnDelete.Visible = true;
                    GetFormData();
                    txtAmount.Enabled = false;
                    lblmsg.Text = "";
                    tblmain.Visible = true;
                    tblGrd.Visible = false;
                    tblGridM.Visible = false;
                    tblGridDet.Visible = true;
                    displayGridDet();
                    DisableControl();
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
        DataTable dt = objClass.viewData(objClass, "PPV", validation.dateToText(txtdtPaymentVoucher.Text));
        if (dt.Rows.Count > 0)
        {
            txtPaymentVoucherNo.Text = dt.Rows[0][0].ToString();
        }
    }
    public void para()
    {

        //  objClass.nInvoiceID = Session["eid"].ToString();
        objClass.nPaymentModeID = ddlPaymentMode.SelectedValue;
        objClass.nCashAccountID = ddlPayAccount.SelectedValue;
        objClass.dtPayment = validation.dateToText(txtdtPaymentVoucher.Text);
        objClass.sVoucherNo = txtPaymentVoucherNo.Text;
        objClass.nTotAmount = txtAmount.Text;
        objClass.nSupplierID = ddlSupplier.SelectedValue;

       objClass.sRemarks = txtRemarks.Text;
        objClass.sPayfor = ddlPayFor.SelectedValue;
    }

    public void clrfield()
    {
        txtPaymentVoucherNo.Text = "";
        ddlPaymentMode.SelectedValue = "0";
        txtdtPaymentVoucher.Text = "";
        ddlSupplier.SelectedValue = "0";
        ddlPayFor.SelectedValue = "0";
        txtAmount.Text = "";
        txtRemarks.Text = "";
        //txtConfigID.Text = "";
        Session["eid"] = "";
    }

    public void GetFormData()
    {
        DataTable dt = objClass.viewData(objClass, "show", Session["eid"].ToString());
        if (dt.Rows.Count > 0)
        {
            ddlPaymentMode.SelectedValue = dt.Rows[0][1].ToString();
            EventArgs e =new EventArgs();
            ddlPaymentMode_SelectedIndexChanged(this,e);
            ddlPayAccount.SelectedValue = dt.Rows[0][2].ToString(); 
            txtdtPaymentVoucher.Text = validation.TextToDate(dt.Rows[0][3].ToString()); 
            txtPaymentVoucherNo.Text = dt.Rows[0][4].ToString(); 
            txtAmount.Text = dt.Rows[0][5].ToString(); 
            ddlSupplier.SelectedValue = dt.Rows[0][6].ToString(); 

            txtRemarks.Text = dt.Rows[0][7].ToString(); 
            ddlPayFor.SelectedValue = dt.Rows[0][8].ToString();
            

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
          objClass.nPaymentMadeID = Session["eid"].ToString();
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
                    string PayID = strArr[2].ToString();
                    Session["eid"] = PayID;
                    objClassDet.nPaymentMadeID = PayID;
                    for (int i = 0; i < GridView3.Rows.Count; i++)
                    {
                        CheckBox chkSelect = GridView3.Rows[i].FindControl("chkInv") as CheckBox;
                        string InvoiceID = (GridView3.Rows[i].FindControl("lblInvID") as Label).Text;
                        objClassDet.nInvoiceID = InvoiceID;

                        string dtInvoice = (GridView3.Rows[i].FindControl("lblInvDate") as Label).Text;
                        objClassDet.dtInvoiceDate = dtInvoice;

                        string sInvoice = (GridView3.Rows[i].FindControl("lblInvNo") as Label).Text;
                        objClassDet.sInvoiceNo = sInvoice;

                        objClassDet.sRemarks = ddlPayFor.SelectedValue + " Payments for Invoice No : " + sInvoice;

                        objClassDet.nAmount = (GridView3.Rows[i].FindControl("txtPaymentValue") as TextBox).Text;

                        if (chkSelect.Checked)
                        {
                            var abc1 = objClassDet.User_Operation(objClassDet, "add");


                            //if (ddlPayFor.SelectedValue == "Visa")
                            //{
                            //    GetVisaPaid(InvoiceID);
                            //}
                            //else if (ddlPayFor.SelectedValue == "AirTicket")
                            //{
                            //    GetAirTicketPaid(InvoiceID);
                            //}
                            //else if (ddlPayFor.SelectedValue == "Hotels")
                            //{
                            //    GetHotelsPaid(InvoiceID);
                            //}
                            //else if (ddlPayFor.SelectedValue == "Excursion")
                            //{
                            //    GetExcursionPaid(InvoiceID);
                            //}
                            //else if (ddlPayFor.SelectedValue == "Mofa")
                            //{
                            //    GetMofaPaid(InvoiceID);
                            //}
                            //else if (ddlPayFor.SelectedValue == "GroupMofa")
                            //{
                            //    GetGroupMofaPaid(InvoiceID);
                            //}
                            //else if (ddlPayFor.SelectedValue == "Recruitement")
                            //{
                            //    GetRecruitementPaid(InvoiceID);
                            //}
                            //else if (ddlPayFor.SelectedValue == "Insurance")
                            //{
                            //    GetInsurancePaid(InvoiceID);
                            //}
                            //else if (ddlPayFor.SelectedValue == "Train")
                            //{
                            //    GetTrainPaid(InvoiceID);
                            //}
                            //else if (ddlPayFor.SelectedValue == "Bus")
                            //{
                            //    GetBusPaid(InvoiceID);
                            //}
                            //else if (ddlPayFor.SelectedValue == "Car")
                            //{
                            //    GetCarPaid(InvoiceID);
                            //}
                        }

                    }
                }



                valobj.showMsg(abc, lblmsg);
                tblGrd.Visible = true;
                tblmain.Visible = false;
                tblGridM.Visible = false;
                tblGridDet.Visible = false;
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
            txtAmount.Enabled = false;
            lblmsg.Text = "";
            tblmain.Visible = true;
            tblGrd.Visible = false;
            tblGridM.Visible = false;
            tblGridDet.Visible = true;
            displayGridDet();
            DisableControl();
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
            Response.Redirect("PaymentReceipt/rpt_payment_made.aspx?id=" + Session["eid"].ToString());

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
            objClass.nPaymentMadeID = Request.QueryString["id"];
            Response.Redirect("PaymentReceipt/rpt_payment_made.aspx?id=" + Request.QueryString["id"]);
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
            objClass.nPaymentMadeID = Session["eid"].ToString();
            var abc = objClass.User_Operation(objClass, "edit");

            objClassDet.nPaymentMadeID = Session["eid"].ToString();
            for (int i = 0; i < GridView2.Rows.Count; i++)
            {
                string PaymentDetID = (GridView2.Rows[i].FindControl("lblPaymentDetID") as Label).Text;
                objClassDet.nPaymentMadeDetID = PaymentDetID;

                string InvoiceID = (GridView2.Rows[i].FindControl("lblInvID") as Label).Text;
                objClassDet.nInvoiceID = InvoiceID;

                string dtInvoice = (GridView2.Rows[i].FindControl("lblInvDate") as Label).Text;
                objClassDet.dtInvoiceDate = dtInvoice;

                string sInvoice = (GridView2.Rows[i].FindControl("lblInvNo") as Label).Text;
                objClassDet.sInvoiceNo = sInvoice;

                objClassDet.sRemarks = ddlPayFor.SelectedValue + " Payments for Invoice No : " + sInvoice;


                objClassDet.nAmount = (GridView2.Rows[i].FindControl("txtPaymentValue") as TextBox).Text;

                var abc1 = objClassDet.User_Operation(objClassDet, "edit");

                //if(ddlPayFor.SelectedValue=="Visa")
                //{
                //    GetVisaPaid(InvoiceID);
                //}
                //else if (ddlPayFor.SelectedValue == "AirTicket")
                //{
                //    GetAirTicketPaid(InvoiceID);
                //}
                //else if (ddlPayFor.SelectedValue == "Hotels")
                //{
                //    GetHotelsPaid(InvoiceID);
                //}
                //else if (ddlPayFor.SelectedValue == "Excursion")
                //{
                //    GetExcursionPaid(InvoiceID);
                //}
                //else if (ddlPayFor.SelectedValue == "Mofa")
                //{
                //    GetMofaPaid(InvoiceID);
                //}
                //else if (ddlPayFor.SelectedValue == "GroupMofa")
                //{
                //    GetGroupMofaPaid(InvoiceID);
                //}
                //else if (ddlPayFor.SelectedValue == "Recruitement")
                //{
                //    GetRecruitementPaid(InvoiceID);
                //}
                //else if (ddlPayFor.SelectedValue == "Insurance")
                //{
                //    GetRecruitementPaid(InvoiceID);
                //}
                //else if (ddlPayFor.SelectedValue == "Train")
                //{
                //    GetTrainPaid(InvoiceID);
                //}
                //else if (ddlPayFor.SelectedValue == "Bus")
                //{
                //    GetBusPaid(InvoiceID);
                //}
                //else if (ddlPayFor.SelectedValue == "Car")
                //{
                //    GetCarPaid(InvoiceID);
                //}
            }



            valobj.showMsg(abc, lblmsg);
            //displayGrid();
            string aa = Server.UrlEncode(System.DateTime.Now.ToString());
            Session["tpayment_voucher"] = aa;
        }
    }

    public void GetVisaPaid(string InvID)
    {
       
            string GrandTotal = ""; string TotalPaid = "";
            DataTable dtMain = new DataTable();
            dtMain = objVisa.viewData(objVisa, "ShowGrid", InvID);
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
                objVisa.bPaid = "0";   //UnPaid
            }
            if (GrandTotal.ToString() == TotalPaid.ToString() || double.Parse(TotalPaid) > double.Parse(GrandTotal))
            {
                objVisa.bPaid = "1";   //Paid
            }
            else if (int.Parse(TotalPaid) > 0 && double.Parse(TotalPaid) < double.Parse(GrandTotal))
            {
                objVisa.bPaid = "2";   //Partial Paid
            }
            else
            {
                objVisa.bPaid = "3";   //Exta Paid
            }
            objVisa.nVisaId = InvID;
            var xyz = objVisa.User_Operation(objVisa, "bPaidEdit");
       
    }
    public void GetAirTicketPaid(string InvID)
    {

        string GrandTotal = ""; string TotalPaid = "";
        DataTable dtMain = new DataTable();
        dtMain = objAirTicket.viewData(objAirTicket, "ShowGrid", InvID);
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
            objAirTicket.bPaid = "0";   //UnPaid
        }
        if (GrandTotal.ToString() == TotalPaid.ToString() || double.Parse(TotalPaid) > double.Parse(GrandTotal))
        {
            objAirTicket.bPaid = "1";   //Paid
        }
        else if (int.Parse(TotalPaid) > 0 && double.Parse(TotalPaid) < double.Parse(GrandTotal))
        {
            objAirTicket.bPaid = "2";   //Partial Paid
        }
        else
        {
            objAirTicket.bPaid = "3";   //Exta Paid
        }
        objAirTicket.nTicketingID = InvID;
        var xyz = objAirTicket.User_Operation(objAirTicket, "bPaidEdit");

    }
    public void GetHotelsPaid(string InvID)
    {

        string GrandTotal = ""; string TotalPaid = "";
        DataTable dtMain = new DataTable();
        dtMain = objHotels.viewData(objHotels, "ShowGrid", InvID);
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
            objHotels.bPaid = "0";   //UnPaid
        }
        if (GrandTotal.ToString() == TotalPaid.ToString() || double.Parse(TotalPaid) > double.Parse(GrandTotal))
        {
            objHotels.bPaid = "1";   //Paid
        }
        else if (int.Parse(TotalPaid) > 0 && double.Parse(TotalPaid) < double.Parse(GrandTotal))
        {
            objHotels.bPaid = "2";   //Partial Paid
        }
        else
        {
            objHotels.bPaid = "3";   //Exta Paid
        }
        objHotels.nHotelBookingID = InvID;
        var xyz = objHotels.User_Operation(objHotels, "bPaidEdit");

    }
    public void GetExcursionPaid(string InvID)
    {

        string GrandTotal = ""; string TotalPaid = "";
        DataTable dtMain = new DataTable();
        dtMain = objExcursion.viewData(objExcursion, "ShowGrid", InvID);
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
            objExcursion.bPaid = "0";   //UnPaid
        }
        if (GrandTotal.ToString() == TotalPaid.ToString() || double.Parse(TotalPaid) > double.Parse(GrandTotal))
        {
            objExcursion.bPaid = "1";   //Paid
        }
        else if (int.Parse(TotalPaid) > 0 && double.Parse(TotalPaid) < double.Parse(GrandTotal))
        {
            objExcursion.bPaid = "2";   //Partial Paid
        }
        else
        {
            objExcursion.bPaid = "3";   //Exta Paid
        }
        objExcursion.nExcursionBookingID = InvID;
        var xyz = objExcursion.User_Operation(objExcursion, "bPaidEdit");

    }
    public void GetMofaPaid(string InvID)
    {

        string GrandTotal = ""; string TotalPaid = "";
        DataTable dtMain = new DataTable();
        dtMain = objMofa.viewData(objMofa, "ShowGrid", InvID);
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
            objMofa.bPaid = "0";   //UnPaid
        }
        if (GrandTotal.ToString() == TotalPaid.ToString() || double.Parse(TotalPaid) > double.Parse(GrandTotal))
        {
            objMofa.bPaid = "1";   //Paid
        }
        else if (int.Parse(TotalPaid) > 0 && double.Parse(TotalPaid) < double.Parse(GrandTotal))
        {
            objMofa.bPaid = "2";   //Partial Paid
        }
        else
        {
            objMofa.bPaid = "3";   //Exta Paid
        }
        objMofa.nMofaBookingID = InvID;
        var xyz = objMofa.User_Operation(objMofa, "bPaidEdit");

    }
    public void GetGroupMofaPaid(string InvID)
    {

        string GrandTotal = ""; string TotalPaid = "";
        DataTable dtMain = new DataTable();
        dtMain = objGroupMofa.viewData(objGroupMofa, "ShowGrid", InvID);
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
            objGroupMofa.bPaid = "0";   //UnPaid
        }
        if (GrandTotal.ToString() == TotalPaid.ToString() || double.Parse(TotalPaid) > double.Parse(GrandTotal))
        {
            objGroupMofa.bPaid = "1";   //Paid
        }
        else if (int.Parse(TotalPaid) > 0 && double.Parse(TotalPaid) < double.Parse(GrandTotal))
        {
            objGroupMofa.bPaid = "2";   //Partial Paid
        }
        else
        {
            objGroupMofa.bPaid = "3";   //Exta Paid
        }
        objGroupMofa.nGroupMofaID = InvID;
        var xyz = objGroupMofa.User_Operation(objGroupMofa, "bPaidEdit");

    }
    public void GetRecruitementPaid(string InvID)
    {

        string GrandTotal = ""; string TotalPaid = "";
        DataTable dtMain = new DataTable();
        dtMain = objRecmt.viewData(objRecmt, "ShowGrid", InvID);
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
            objRecmt.bPaid = "0";   //UnPaid
        }
        if (GrandTotal.ToString() == TotalPaid.ToString() || double.Parse(TotalPaid) > double.Parse(GrandTotal))
        {
            objRecmt.bPaid = "1";   //Paid
        }
        else if (int.Parse(TotalPaid) > 0 && double.Parse(TotalPaid) < double.Parse(GrandTotal))
        {
            objRecmt.bPaid = "2";   //Partial Paid
        }
        else
        {
            objRecmt.bPaid = "3";   //Exta Paid
        }
        objRecmt.nBookingID = InvID;
        var xyz = objRecmt.User_Operation(objRecmt, "bPaidEdit");

    }
    public void GetInsurancePaid(string InvID)
    {

        string GrandTotal = ""; string TotalPaid = "";
        DataTable dtMain = new DataTable();
        dtMain = objInsurance.viewData(objInsurance, "ShowGrid", InvID);
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
            objInsurance.bPaid = "0";   //UnPaid
        }
        if (GrandTotal.ToString() == TotalPaid.ToString() || double.Parse(TotalPaid) > double.Parse(GrandTotal))
        {
            objInsurance.bPaid = "1";   //Paid
        }
        else if (int.Parse(TotalPaid) > 0 && double.Parse(TotalPaid) < double.Parse(GrandTotal))
        {
            objInsurance.bPaid = "2";   //Partial Paid
        }
        else
        {
            objInsurance.bPaid = "3";   //Exta Paid
        }
        objInsurance.nInsuranceBookingID = InvID;
        var xyz = objInsurance.User_Operation(objInsurance, "bPaidEdit");

    }
    public void GetTrainPaid(string InvID)
    {

        string GrandTotal = ""; string TotalPaid = "";
        DataTable dtMain = new DataTable();
        dtMain = objTrain.viewData(objTrain, "ShowGrid", InvID);
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
            objTrain.bPaid = "0";   //UnPaid
        }
        if (GrandTotal.ToString() == TotalPaid.ToString() || double.Parse(TotalPaid) > double.Parse(GrandTotal))
        {
            objTrain.bPaid = "1";   //Paid
        }
        else if (int.Parse(TotalPaid) > 0 && double.Parse(TotalPaid) < double.Parse(GrandTotal))
        {
            objTrain.bPaid = "2";   //Partial Paid
        }
        else
        {
            objTrain.bPaid = "3";   //Exta Paid
        }
        objTrain.nTrainBookingID = InvID;
        var xyz = objTrain.User_Operation(objTrain, "bPaidEdit");

    }

    public void GetBusPaid(string InvID)
    {

        string GrandTotal = ""; string TotalPaid = "";
        DataTable dtMain = new DataTable();
        dtMain = objBus.viewData(objBus, "ShowGrid", InvID);
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
            objBus.bPaid = "0";   //UnPaid
        }
        if (GrandTotal.ToString() == TotalPaid.ToString() || double.Parse(TotalPaid) > double.Parse(GrandTotal))
        {
            objBus.bPaid = "1";   //Paid
        }
        else if (int.Parse(TotalPaid) > 0 && double.Parse(TotalPaid) < double.Parse(GrandTotal))
        {
            objBus.bPaid = "2";   //Partial Paid
        }
        else
        {
            objBus.bPaid = "3";   //Exta Paid
        }
        objBus.nBusBookingID = InvID;
        var xyz = objBus.User_Operation(objBus, "bPaidEdit");

    }
    public void GetCarPaid(string InvID)
    {

        string GrandTotal = ""; string TotalPaid = "";
        DataTable dtMain = new DataTable();
        dtMain = objCar.viewData(objCar, "ShowGrid", InvID);
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
            objCar.bPaid = "0";   //UnPaid
        }
        if (GrandTotal.ToString() == TotalPaid.ToString() || double.Parse(TotalPaid) > double.Parse(GrandTotal))
        {
            objCar.bPaid = "1";   //Paid
        }
        else if (int.Parse(TotalPaid) > 0 && double.Parse(TotalPaid) < double.Parse(GrandTotal))
        {
            objCar.bPaid = "2";   //Partial Paid
        }
        else
        {
            objCar.bPaid = "3";   //Exta Paid
        }
        objCar.nCarBookingID = InvID;
        var xyz = objCar.User_Operation(objCar, "bPaidEdit");

    }
    

    public void DisableControl()
    {
        ddlPayFor.Enabled = false;
        ddlSupplier.Enabled = false;
        ddlPaymentMode.Enabled = false;
        ddlPayAccount.Enabled = false;
        txtdtPaymentVoucher.Enabled = false;

    }
    public void EnableControl()
    {
        ddlPayFor.Enabled = true;
        ddlSupplier.Enabled = true;
        ddlPaymentMode.Enabled = true;
        ddlPayAccount.Enabled = true;
        txtdtPaymentVoucher.Enabled = true;

    }


    public void displayGridDet()
    {
        try
        {
            objClassDet.dtInvoiceDate = "PayMade";
            objClassDet.sInvoiceNo = ddlPayFor.SelectedValue;
            objClassDet.FillGrid(objClassDet, GridView2, "ShowGridDet", Session["eid"].ToString());
        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, lblmsg);
        }
    }



    protected void lnkAdd_Click(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        tblmain.Visible = true;
        tblGrd.Visible = false;
        tblGridDet.Visible = false;
        tblGridM.Visible = false;
        txtAmount.Enabled = true;
        clrfield();
        EnableControl();
        btnVisible();
        txtdtPaymentVoucher.Text = validation.fillDate();
        Voucher_Generate();
    }
    protected void lnkList_Click(object sender, EventArgs e)
    {
        Response.Redirect("tpayment_made_list.aspx");

    }

    protected void txtdtPaymentVoucher_TextChanged(object sender, EventArgs e)
    {
        Voucher_Generate();
    }
    protected void ddlVoucherTypeID_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (ddlVoucherTypeID.SelectedValue == "1")
        //{
        //    objAccount.ddlOperation(objAccount, "ddlAccType", ddlVoucherTypeID.SelectedValue, ddlSupplier);
        //    txtcheque.Enabled = false;
        //    txtdtCheque.Enabled = false;
        //}
        //else
        //{
        //    objAccount.ddlOperation(objAccount, "ddlAccType", ddlVoucherTypeID.SelectedValue, ddlSupplier);
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
    protected void ddlPayFor_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlSupplier_SelectedIndexChanged(this, e);
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
        if(Session["eid"]=="")
        {
            GridViewRow row = ((GridViewRow)((TextBox)sender).NamingContainer);
            //NamingContainer return the container that the control sits in
            TextBox other = (TextBox)row.FindControl("txtPaymentValue");
            CheckBox chkSelect = (CheckBox)row.FindControl("chkInv");
            chkSelect.Checked = true;
            GrandTotal();
        }
        else
        {
            GridViewRow row = ((GridViewRow)((TextBox)sender).NamingContainer);
            //NamingContainer return the container that the control sits in
            TextBox other = (TextBox)row.FindControl("txtPaymentValue");
            GrandTotalDet();
            
        }
        

    }
    private void GrandTotal()
    {
        float GTotal = 0f;

        for (int i = 0; i < GridView3.Rows.Count; i++)
        {
            String total = (GridView3.Rows[i].FindControl("txtPaymentValue") as TextBox).Text;
            GTotal += Convert.ToSingle(total);
        }
        txtAmount.Text = GTotal.ToString();
    }
    private void GrandTotalDet()
    {
        float GTotal = 0f;

        for (int i = 0; i < GridView2.Rows.Count; i++)
        {
            String total = (GridView2.Rows[i].FindControl("txtPaymentValue") as TextBox).Text;
            GTotal += Convert.ToSingle(total);
        }
        txtAmount.Text = GTotal.ToString();
    }
    protected void ddlSupplier_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlSupplier.SelectedValue != "0")
            {
                tblGridM.Visible = true;
                GridView3.Visible = true;
                objClass.sPayfor = ddlPayFor.SelectedValue;
                objClass.sVoucherNo = "PayMade";
                objClass.FillGrid(objClass, GridView3, "ShowOutstanding", ddlSupplier.SelectedValue);
            }
            else
            {


                GridView3.Visible = false;
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
        lblAmount.Text = txtAmount.Text;

        objClass.sPayfor = ddlPayFor.SelectedValue;
        objClass.sVoucherNo = "PayMade";
        objClass.FillGrid(objClass, GridView3, "ShowOutstanding", ddlSupplier.SelectedValue);

    }
    
}
