using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Transcation_poinvoice : System.Web.UI.Page
{
    tpoinvoice_Class objClass = new tpoinvoice_Class();
    tpoinvoice_det_Class objClassDet = new tpoinvoice_det_Class();
    validation valobj = new validation();
    mlocation_Class objLocation = new mlocation_Class();
    mitemunit_Class objUnit = new mitemunit_Class();
    titem_details_Class objItem = new titem_details_Class();
    titem_property_Class objItemProp = new titem_property_Class();
    mtax_tamplate_Class objTaxTamplate = new mtax_tamplate_Class();
    mtax_master_Class objTaxMaster = new mtax_master_Class();
    mmain_account_Class objChartOfAcc = new mmain_account_Class();
    tpo_Class objPOClass = new tpo_Class();
    tpo_det_Class objPODetClass = new tpo_det_Class();
    tpurchase_payment_Class objPurchasePay = new tpurchase_payment_Class();
    tvisadet_Class objClassGen = new tvisadet_Class();
    string cond;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                string aa = Server.UrlEncode(System.DateTime.Now.ToString());
                Session["tpoinvoice"] = aa;
                tblmain.Visible = true;
                tblGrd.Visible = false;
                tblDet.Visible = true;
                tblGridDet.Visible = false;
                tblbootomPage.Visible = false;
                objLocation.ddlOperation(objLocation, "Show", "", ddlLocationID);
                objUnit.ddlOperation(objUnit, "Show", "", ddlUnit);
                objItem.ddlOperation(objItem, "Show", "", ddlItem);
                objChartOfAcc.ddlOperation(objChartOfAcc, "ShowddlAccount", "", ddlVendorName);
                objChartOfAcc.ddlOperation(objChartOfAcc, "ShowddlAccount", "", ddlVendSearch);
                objClass.ddlOperation(objClass, "Show", "", ddlPoSearch);
                objTaxMaster.ddlOperation(objTaxMaster, "Show", "", ddlTaxName);
                displayGrid();
                btnVisible();

                txtdtPoInvoice.Text = validation.fillDate();
                txtdtPoInvoice_TextChanged(this, e);
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
                var ID = Request.QueryString["ID"];
                if (!string.IsNullOrEmpty(ID))
                {
                    Session["eid"] = ID;
                    btnPrint.Visible = true;
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    //  btnDelete.Visible = false;

                    GetFormData();
                    // GetGrandTotal();
                    lblmsg.Text = "";
                    tblmain.Visible = true;
                    tblGrd.Visible = false;
                    tblGridDet.Visible = true;
                    tblbootomPage.Visible = true;
                    DetButtonVisible();
                    displayGridDet();
                    GetGrandTotal();
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
        ViewState["tpoinvoice"] = Session["tpoinvoice"];
    }

    public void para()
    {
        objClass.sPoInvoiceNo = validation.stringToDBString(txtPoInvoiceNo.Text.Trim());
        objClass.dtPoInvoice = validation.dateToText(txtdtPoInvoice.Text.Trim());
        objClass.nLocationID = ddlLocationID.SelectedValue;
        objClass.nInvoiceFromID = ddlInvoiceFromID.SelectedValue;
        objClass.nPoID = ddlPoID.SelectedValue;
        objClass.sRefNo = validation.stringToDBString(txtRefNo.Text.Trim());
        objClass.nVendorID = validation.stringToDBString(ddlVendorName.SelectedValue.Trim());
        //  objClass.nBalance = txtBalance.Text.Trim();
        objClass.nShipingCost = txtShippimngCost.Text.Trim();
        objClass.nOtherCharges = txtOtherCharges.Text.Trim();
        objClass.nDiscount = txtDiscount.Text.Trim();
        objClass.bPaid = "0";  //Un paid 
        objClass.sRemarks = validation.stringToDBString(txtRemarks.Text.Trim());
        objClass.nCompanyID = Session["ConfigID"].ToString();
        objClass.nFromStateID = Session["ConfigID"].ToString();
        objClass.nToStateID = Session["ConfigID"].ToString();
    }
    public void paradet()
    {
        objClassDet.nPoInvoiceID = Session["eid"].ToString();
        objClassDet.nItemID = ddlItem.SelectedValue;
        objClassDet.nItemUnitID = ddlUnit.SelectedValue;
       // objClassDet.nCurrentStock = txtStock.Text.Trim();
        objClassDet.nQuantity = txtQty.Text.Trim();
        objClassDet.nUnitPrice = txtUnitPrice.Text.Trim();
        objClassDet.nTaxMasterID = ddlTaxName.SelectedValue;
      //  objClassDet.nTotalPrice = txtItemPrice.Text.Trim();
        
        //   objClassDet.nTaxTypeID = ddlTaxType.SelectedValue;
        //   objClassDet.nTaxValue = txtTaxValue.Text;

        objClassDet.nCGST = txtCGST.Text.Trim();
        objClassDet.nSGST = txtSGST.Text.Trim();
        objClassDet.nIGST = txtIGST.Text.Trim();
        objClassDet.nCGSTValue =(double.Parse(txtItemPrice.Text)* double.Parse(txtCGST.Text)/100).ToString();
        objClassDet.nSGSTValue = (double.Parse(txtItemPrice.Text) * double.Parse(txtSGST.Text) / 100).ToString();
        objClassDet.nIGSTValue = (double.Parse(txtItemPrice.Text) * double.Parse(txtIGST.Text) / 100).ToString();
        objClassDet.nOhterTax = txtOtherTax.Text.Trim();
        objClassDet.nDicountPercent = txtItemDiscount.Text.Trim();
        objClassDet.nDiscountValue = (double.Parse(txtItemPrice.Text) * double.Parse(txtItemDiscount.Text) / 100).ToString(); 
        objClassDet.nTotalPrice = txtItemPrice.Text.Trim(); 
    }

    public void clrfield()
    {
        txtPoInvoiceNo.Text = "";
        txtdtPoInvoice.Text = "";
        ddlLocationID.SelectedValue = "0";
        ddlInvoiceFromID.SelectedValue = "1";
        ddlPoID.SelectedValue = "0";
        txtRefNo.Text = "";
        ddlVendorName.SelectedValue = "0";
        txtSubTot.Text = "0";
        txtShippimngCost.Text = "0";
        txtOtherCharges.Text = "0";
        txtDiscount.Text = "0";
        txtTaxTotal.Text = "0";
        txtGrandTot.Text = "0";
       
        // txtBalance.Text = "";
        txtRemarks.Text = "";
        //txtConfigID.Text = "";
        Session["eid"] = "";
    }
    public void clrfieldDet()
    {

        ddlItem.SelectedValue = "0";
        ddlUnit.SelectedValue = "0";
        txtStock.Text = "";
        txtQty.Text = "1";
        txtUnitPrice.Text = "0";
        txtItemPrice.Text = "0";
        ddlTaxName.SelectedValue = "0";
        //    ddlTaxType.SelectedValue = "0";
        //   txtTaxValue.Text = "0";
        txtItemPrice.Text = "0";
        txtTotalPrice.Text = "0";
        txtCGST.Text = "0";
        txtSGST.Text = "0";

        txtIGST.Text = "0";
        txtOtherTax.Text = "0";
        Session["Detid"] = "";

    }
    public void GetFormData()
    {
        DataTable dt = objClass.viewData(objClass, "show", Session["eid"].ToString());
        if (dt.Rows.Count > 0)
        {
            txtPoInvoiceNo.Text = dt.Rows[0][1].ToString();
            txtdtPoInvoice.Text = validation.TextToDate(dt.Rows[0][2].ToString());
            ddlLocationID.SelectedValue = dt.Rows[0][3].ToString();
            ddlInvoiceFromID.SelectedValue = dt.Rows[0][4].ToString();
            objPOClass.ddlOperation(objPOClass, "Show", "", ddlPoID);
            ddlPoID.SelectedValue = dt.Rows[0][5].ToString();
            txtRefNo.Text = dt.Rows[0][6].ToString();
            ddlVendorName.SelectedValue = dt.Rows[0][7].ToString();
            EventArgs e = new EventArgs();
            ddlVendorName_SelectedIndexChanged(this, e);
            // txtBalance.Text = dt.Rows[0][8].ToString();


            txtShippimngCost.Text = dt.Rows[0][8].ToString();
            txtOtherCharges.Text = dt.Rows[0][9].ToString();
            txtDiscount.Text = dt.Rows[0][10].ToString();
            txtRemarks.Text = dt.Rows[0][11].ToString();
        }
    }
    public void GetFormDataDet()
    {
        DataTable dt = objClassDet.viewData(objClassDet, "show", Session["detid"].ToString());
        if (dt.Rows.Count > 0)
        {
            ddlItem.SelectedValue = dt.Rows[0][2].ToString();
            ddlUnit.SelectedValue = dt.Rows[0][3].ToString();
            EventArgs e = new EventArgs();
            ddlItem_SelectedIndexChanged(this, e);
            string stock = txtStock.Text;

            txtQty.Text = dt.Rows[0][4].ToString();
            txtStock.Text = (double.Parse(stock) + double.Parse(txtQty.Text)).ToString();
            txtUnitPrice.Text = dt.Rows[0][6].ToString();
            txtItemPrice.Text = dt.Rows[0][7].ToString();

            ddlTaxName.SelectedValue = dt.Rows[0][8].ToString();
            //  ddlTaxType.SelectedValue = dt.Rows[0][9].ToString();
            //   txtTaxValue.Text = dt.Rows[0][10].ToString();
            
            txtCGST.Text = dt.Rows[0][9].ToString();
            txtSGST.Text = dt.Rows[0][10].ToString();
            txtIGST.Text = dt.Rows[0][11].ToString();
            txtOtherTax.Text = dt.Rows[0][12].ToString();
            txtItemPrice.Text = dt.Rows[0][13].ToString();
            txtcgstamt.Text = dt.Rows[0]["nCGSTValue"].ToString();
            txtsgstamt.Text = dt.Rows[0]["nSGSTValue"].ToString();
            txtigstamt.Text = dt.Rows[0]["nIGSTValue"].ToString();
        }
    }
    public void btnVisible()
    {
        btnAdd.Visible = true;
        btnUpdate.Visible = false;
       // btnDelete.Visible = false;
        btnAddDet.Visible = false;
        btnUpdateDet.Visible = false;
        btnDeleteDet.Visible = false;
        clrfield();
    }

    public void DetButtonVisible()
    {
        tblDet.Visible = true;
        tblGridDet.Visible = true;
        btnAddDet.Visible = true;
        btnUpdateDet.Visible = false;
        btnDeleteDet.Visible = false;
        clrfieldDet();
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

    public void DeleteRecord()
    {
        objClass.nPoInvoiceID = Session["eid"].ToString();
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
            if (Session["tpoinvoice"].ToString() == ViewState["tpoinvoice"].ToString())
            {
                para();
                var abc = objClass.User_Operation(objClass, "add");
                var strArr = abc.Split(',');
                if (strArr[0] == "1")
                {
                    string nPoinvoiceID = strArr[2].ToString();
                    Session["eid"] = nPoinvoiceID;

                    paradet();
                    var xyz = objClassDet.User_Operation(objClassDet, "add");

                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    btnAddDet.Visible = true;
                    btnUpdateDet.Visible = false;
                    clrfieldDet();
                    tblGridDet.Visible = true;
                    displayGridDet();
                   
                    tblbootomPage.Visible = true;
                    GetGrandTotal();
                }
                valobj.showMsg(abc, lblmsg);
                //displayGrid();
                string aa = Server.UrlEncode(System.DateTime.Now.ToString());
                Session["tpoinvoice"] = aa;
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
            objClass.nPoInvoiceID = Session["eid"].ToString();
            var abc = objClass.User_Operation(objClass, "edit");
            valobj.showMsg(abc, lblmsg);
            displayGridDet();
            GetGrandTotal();

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
            btnUpdate.Visible = true;
          //  btnDelete.Visible = false;

            GetFormData();
            // GetGrandTotal();
            lblmsg.Text = "";
            tblmain.Visible = true;
            tblGrd.Visible = false;
            tblGridDet.Visible = true;
            tblbootomPage.Visible = true;
            DetButtonVisible();
            displayGridDet();
            GetGrandTotal();
        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, "FAIL", lblmsg);
        }
    }
    protected void btngdPayment_Click(object sender, EventArgs e)
    {
        try
        {
            Session["eid"] = "";
            LinkButton thisbtn = (LinkButton)sender;
            GridViewRow thisgrdR = (GridViewRow)thisbtn.Parent.Parent;
            int row = thisgrdR.RowIndex;
            Label ID = (Label)GridView1.Rows[row].Cells[0].FindControl("lblID");
            Session["eid"] = ID.Text;

            objPurchasePay.nPoInvoiceID = ID.Text;
            DropDownList ddlPMode = (DropDownList)GridView1.Rows[row].Cells[0].FindControl("ddlPayMode");
            objPurchasePay.nPaymentModeID = ddlPMode.SelectedValue;

            TextBox txtamt = (TextBox)GridView1.Rows[row].Cells[0].FindControl("txtPayAmount");
            objPurchasePay.nAmount = txtamt.Text;

            objPurchasePay.dtPayment = validation.fillTextDate();

            TextBox txtremk = (TextBox)GridView1.Rows[row].Cells[0].FindControl("txtPayRemarks");
            objPurchasePay.sRemarks = validation.stringToDBString(txtremk.Text);


            var abc = objPurchasePay.User_Operation(objPurchasePay, "add");


            GetPaidDetails();
            objClass.nPoInvoiceID = ID.Text;
            var xyz = objClass.User_Operation(objClass, "bPaidEdit");
            displayGrid();
            valobj.showMsg(abc, lblmsg);

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

            btnAddDet.Visible = false;
            btnUpdateDet.Visible = true;
            btnDeleteDet.Visible = false;
            GetFormDataDet();
            displayGridDet();
            GetGrandTotal();
            lblmsg.Text = "";



        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, "FAIL", lblmsg);
        }
    }

    protected void btnAddDet_Click(object sender, EventArgs e)
    {
        try
        {
            lblmsg.Text = "";
            if (Session["tpoinvoice"].ToString() == ViewState["tpoinvoice"].ToString())
            {
                paradet();
                var abc = objClassDet.User_Operation(objClassDet, "add");
                valobj.showMsg(abc, lblmsg);
                displayGridDet();
                clrfieldDet();
                GetGrandTotal();
                string aa = Server.UrlEncode(System.DateTime.Now.ToString());

                Session["tpoinvoice"] = aa;
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
            paradet();
            objClassDet.nPoinvoiceDetID = Session["Detid"].ToString();
            var abc = objClassDet.User_Operation(objClassDet, "edit");
            valobj.showMsg(abc, lblmsg);
            displayGridDet();
            btnAddDet.Visible = true;
            btnUpdateDet.Visible = false;
            btnDeleteDet.Visible = false;
            clrfieldDet();
            GetGrandTotal();
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
            GetGrandTotal();
        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, "FAIL", lblmsg);
        }
    }
    public void DeleteDetRecord()
    {
        objClassDet.nPoinvoiceDetID = Session["Detid"].ToString();
        var vres = objClassDet.User_Operation(objClassDet, "DeActive");
        valobj.showMsg(vres, lblmsg);
        displayGridDet();
        DetButtonVisible();
        GetGrandTotal();
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        try
        {
            Session["eid"] = Request.QueryString["ID"];
            //LinkButton thisbtn = (LinkButton)sender;
            //GridViewRow thisgrdR = (GridViewRow)thisbtn.Parent.Parent;
            //int row = thisgrdR.RowIndex;
            //Label ID = (Label)GridView1.Rows[row].Cells[0].FindControl("lblID");
            //Session["eid"] = ID.Text;

            Response.Redirect("rptpoinvoice.aspx");
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
            Response.Redirect("rptpoinvoice.aspx");

        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, "FAIL", lblmsg);
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            objClass.nPoInvoiceID = ddlPoSearch.SelectedValue;
            objClass.nVendorID = ddlVendSearch.SelectedValue;
            objClass.dtPoInvoice = validation.dateToText(txtdtFroms.Text.Trim());
            objClass.sRefNo = validation.dateToText(txtdtTo.Text.Trim());
            if (ddlPoSearch.SelectedValue != "0" || ddlVendSearch.SelectedValue != "0" || (txtdtFroms.Text != "" && txtdtTo.Text != ""))
            {

                objClass.FillGrid(objClass, GridView1, "ShowGridSearch", "");
            }
            else
            {
                objClass.FillGrid(objClass, GridView1, "ShowGrid", "");
            }
            txtdtFroms.Text = "";
            txtdtTo.Text = "";
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
        ddlPoID.Enabled = false;
        clrfield();
        btnVisible();
        txtdtPoInvoice.Text = validation.fillDate();
        txtdtPoInvoice_TextChanged(this, e);
        tblbootomPage.Visible = false;
    }
    protected void lnkList_Click(object sender, EventArgs e)
    {
        Response.Redirect("tpoinvoice_list.aspx");
    }
    public void Price()
    {
        txtItemPrice.Text = (double.Parse(txtQty.Text) * double.Parse(txtUnitPrice.Text)).ToString();
    }
    protected void txtQty_TextChanged(object sender, EventArgs e)
    {

        try
        {
            if (txtQty.Text != "" & txtUnitPrice.Text != "")
            {
                Price();
                txtUnitPrice.Focus();
                CalTotPrice();
            }
            else
            {
                txtItemPrice.Text = "0";
            }
        }
        catch
        {

        }

    }

    protected void txtUnitPrice_TextChanged(object sender, EventArgs e)
    {

        try
        {
            if (txtQty.Text != "" & txtUnitPrice.Text != "")
            {
                Price();
                btnAddDet.Focus();
            }
            else
            {
                txtItemPrice.Text = "0";
            }
        }
        catch
        {

        }

    }
    protected void txtdtPoInvoice_TextChanged(object sender, EventArgs e)
    {
        POI_Generate();
    }
    public void POI_Generate()
    {
        DataTable dt = objClass.viewData(objClass, "MaxPOInvoiceNo", validation.dateToText(txtdtPoInvoice.Text));
        if (dt.Rows.Count > 0)
        {
            txtPoInvoiceNo.Text = dt.Rows[0][0].ToString();
        }
    }
    protected void ddlInvoiceFromID_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlInvoiceFromID.SelectedValue == "2")
        {
            ddlPoID.Enabled = true;
            objClass.ddlOperation(objClass, "ShowPO", "", ddlPoID);
        }
        else
        {
            ddlPoID.SelectedValue = "0";
            ddlPoID.Enabled = false;
        }
    }
    protected void ddlPoID_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlPoID.SelectedValue != "0")
            {
                DataTable dt = objPOClass.viewData(objPOClass, "show", ddlPoID.SelectedValue);
                if (dt.Rows.Count > 0)
                {
                    ddlLocationID.SelectedValue = dt.Rows[0][5].ToString();
                    ddlVendorName.SelectedValue = dt.Rows[0][6].ToString();
                    txtBalance.Text = dt.Rows[0][11].ToString();
                    txtRefNo.Text = dt.Rows[0][1].ToString();
                }
                para();
                var abc = objClass.User_Operation(objClass, "add");
                var strArr = abc.Split(',');
                if (strArr[0] == "1")
                {
                    string nPoinvoiceID = strArr[2].ToString();
                    Session["eid"] = nPoinvoiceID;
                    DataTable dtDet = objPODetClass.viewData(objPODetClass, "show", ddlPoID.SelectedValue);
                    if (dtDet.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtDet.Rows.Count; i++)
                        {
                            objClassDet.nPoInvoiceID = nPoinvoiceID.ToString();
                            objClassDet.nItemID = dtDet.Rows[i][2].ToString();
                            objClassDet.nItemUnitID = dtDet.Rows[i][3].ToString();
                        //    objClassDet.nCurrentStock = dtDet.Rows[i][4].ToString();
                            objClassDet.nQuantity = dtDet.Rows[i][5].ToString();
                            objClassDet.nUnitPrice = dtDet.Rows[i][6].ToString();
                            objClassDet.nTotalPrice = dtDet.Rows[i][7].ToString();

                            var xyz = objClassDet.User_Operation(objClassDet, "add");
                        }
                    }

                    btnAdd.Visible = false;
                    btnAddDet.Visible = false;
                    btnUpdateDet.Visible = false;
                    btnDeleteDet.Visible = false;
                    btnUpdate.Visible = true;
                    tblbootomPage.Visible = true;
                    tblDet.Visible = true;
                    tblGridDet.Visible = true;
                    GetFormData();
                    displayGridDet();
                    //    clrfieldDet();
                    valobj.showMsg(abc, lblmsg);
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
    protected void ddlVendorName_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dt = objClassGen.viewData(objClassGen, "ShowGeneralLedgerBal", ddlVendorName.SelectedValue);
        if (dt.Rows.Count > 0)
        {
            if (double.Parse(dt.Rows[0][17].ToString()) < 0)
            {
                txtBalance.Text = "";
                string val = dt.Rows[0][17].ToString();
                var TotBal = val.Split('-');
                txtBalance.Text = TotBal[1].ToString() + " " + "Dr";
            }
            else if (double.Parse(dt.Rows[0][17].ToString()) > 0)
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
    protected void ddlItem_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlItem.SelectedValue != "0")
        {

            DataTable dtItem = objItem.viewData(objItem, "ShowGrid", ddlItem.SelectedValue);
            if (dtItem.Rows.Count > 0)
            {
                txtUnitPrice.Text = dtItem.Rows[0]["nLastPurchasePrice"].ToString();
                ddlUnit.SelectedValue = dtItem.Rows[0][17].ToString();
                ddlTaxName.SelectedValue = dtItem.Rows[0]["nTaxMasterID"].ToString();
                ddlTaxName_SelectedIndexChanged(this, e);
                
                txtOtherTax.Text = dtItem.Rows[0]["nOtherTax"].ToString();
            }
            else
            {
                ddlUnit.SelectedValue = "0";
                ddlTaxName.SelectedValue = "0";
                txtOtherTax.Text = "0";
            }

            DataTable dtCurrentStock = objItem.viewData(objItem, "CurrentStock", ddlItem.SelectedValue);
            if (dtCurrentStock.Rows.Count > 0)
            {
                txtStock.Text = dtCurrentStock.Rows[0][3].ToString();
            }
            else
            {
                txtStock.Text = "0";
            }
            Price();
            CalTotPrice();

        }
    }
    protected void ddlTaxName_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (ddlTaxName.SelectedValue != "0")
        {
            if (txtItemPrice.Text == "")
            {
                txtItemPrice.Text = "0";
            }

            //if (txtTaxValue.Text == "")
            //{
            //    txtTaxValue.Text = "0";
            //}
            // Fill Tax Data
            DataTable dt = objTaxMaster.viewData(objTaxMaster, "Show", ddlTaxName.SelectedValue);
            if (dt.Rows.Count > 0)
            {
                txtCGST.Text = dt.Rows[0]["nCGST"].ToString();
                txtSGST.Text = dt.Rows[0]["nSGST"].ToString();
                txtIGST.Text = dt.Rows[0]["nIGST"].ToString();

            }
            else
            {
                txtCGST.Text = "0";
                txtSGST.Text = "0";
                txtIGST.Text = "0";
            }

            DataTable dt1 = objItemProp.viewData(objItemProp, "Show", ddlItem.SelectedValue);
            if (dt.Rows.Count > 0)
            {
                txtOtherTax.Text = dt1.Rows[0]["nOtherTax"].ToString();


            }
            else
            {
                txtOtherTax.Text = "0";

            }

            CalTotPrice();

        }
        else
        {
            //ddlTaxType.SelectedValue = "0";
            //txtTaxValue.Text = "0";
            //txtItemPrice.Text = "0";
        }
    }
    public void CalTotPrice()
    {
        if (txtOtherTax.Text == "")
        {
            txtOtherTax.Text = "0";
        }
        //Calculate Tax Amount
        double cgst = 0; double sgst = 0; double Igst = 0; double ItemDiscount = 0;
        cgst = ((double.Parse(txtItemPrice.Text) * double.Parse(txtCGST.Text)) / 100);
        txtcgstamt.Text = Convert.ToString(cgst);
        sgst = ((double.Parse(txtItemPrice.Text) * double.Parse(txtSGST.Text)) / 100);
        txtsgstamt.Text = Convert.ToString(sgst);
        Igst = ((double.Parse(txtItemPrice.Text) * double.Parse(txtIGST.Text)) / 100);
        txtigstamt.Text = Convert.ToString(Igst);
        ItemDiscount = (double.Parse(txtItemPrice.Text) * double.Parse(txtItemDiscount.Text) / 100);
        txtTotalPrice.Text = (cgst + sgst + Igst - ItemDiscount + double.Parse(txtOtherTax.Text) + double.Parse(txtItemPrice.Text)).ToString();
    }
    public void GetGrandTotal()
    {
        if (Session["eid"].ToString() != null)
        {

            DataTable dt = objClass.viewData(objClass, "ShowGrid", Session["eid"].ToString());
            if (dt.Rows.Count > 0)
            {
                txtSubTot.Text = dt.Rows[0]["TotPrice"].ToString();
                txtTaxTotal.Text = dt.Rows[0]["TotTax"].ToString();
            }
            else
            {
                txtSubTot.Text = "0";
                txtTaxTotal.Text = "0";
            }
            txtGrandTot.Text = (double.Parse(txtSubTot.Text) + double.Parse(txtShippimngCost.Text) + double.Parse(txtOtherCharges.Text) + double.Parse(txtTaxTotal.Text) - double.Parse(txtDiscount.Text)).ToString();
        }
        else
        {
            txtGrandTot.Text = "0";
        }
    }
    protected void txtShippimngCost_TextChanged(object sender, EventArgs e)
    {
        GetGrandTotal();
    }
    protected void txtOtherCharges_TextChanged(object sender, EventArgs e)
    {
        GetGrandTotal();
    }
    protected void txtDiscount_TextChanged(object sender, EventArgs e)
    {
        GetGrandTotal();
    }

    public void GetPaidDetails()
    {
        string GrandTotal = ""; string TotalPaid = "";
        DataTable dtMain = new DataTable();
        dtMain = objClass.viewData(objClass, "ShowGrid", Session["eid"].ToString());
        if (dtMain.Rows.Count > 0)
        {
            GrandTotal = dtMain.Rows[0]["GTotal"].ToString();
        }

        DataTable dtPaid = objPurchasePay.viewData(objPurchasePay, "ShowPaid", Session["eid"].ToString());
        if (dtPaid.Rows.Count > 0)
        {
            TotalPaid = dtPaid.Rows[0]["sTotPaid"].ToString();
        }

        //Adding value for bPaid
        if (TotalPaid.ToString() == "" || TotalPaid.ToString() == "0")
        {
            objClass.bPaid = "0";   //UnPaid
        }
        if (GrandTotal.ToString() == TotalPaid.ToString())
        {
            objClass.bPaid = "1";   //Paid
        }
        else if (int.Parse(TotalPaid) > 0 && int.Parse(TotalPaid) < int.Parse(GrandTotal))
        {
            objClass.bPaid = "2";   //Partial Paid
        }
        else
        {
            objClass.bPaid = "0";   //Exta Paid
        }
    }
    protected void txtItemDiscount_TextChanged(object sender, EventArgs e)
    {
        CalTotPrice();
    }
}
