using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Transcation_soinvoice : System.Web.UI.Page
{
    tsoinvoice_Class objClass = new tsoinvoice_Class();
    tsoinvoice_det_Class objClassDet = new tsoinvoice_det_Class();
    validation valobj = new validation();
    mlocation_Class objLocation = new mlocation_Class();
    mitemunit_Class objUnit = new mitemunit_Class();
    titem_details_Class objItem = new titem_details_Class();
    mtax_tamplate_Class objTaxTamplate = new mtax_tamplate_Class();
    mtax_master_Class objTaxMaster = new mtax_master_Class();
    mmain_account_Class objChartOfAcc = new mmain_account_Class();
    tsalesorder_Class objSOClass = new tsalesorder_Class();
    tsalesorder_det_Class objSODetClass = new tsalesorder_det_Class();
    tvisadet_Class objClassGen = new tvisadet_Class();
    tsales_payment_Class objSalesPay = new tsales_payment_Class();
    string cond;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                string aa = Server.UrlEncode(System.DateTime.Now.ToString());
                Session["tsoinvoice"] = aa;
                tblmain.Visible = true;
                tblGrd.Visible = false;
                tblDet.Visible = true;
                tblGridDet.Visible = false;
                tblbootomPage.Visible = false;

                objLocation.ddlOperation(objLocation, "Show", "", ddlLocationID);
                objUnit.ddlOperation(objUnit, "Show", "", ddlUnit);
                objItem.ddlOperation(objItem, "Show", "", ddlItem);
                objChartOfAcc.ddlOperation(objChartOfAcc, "ShowddlAccount", "", ddlCustomerName);
                objChartOfAcc.ddlOperation(objChartOfAcc, "ShowddlAccount", "", ddlCustSearch);
                objClass.ddlOperation(objClass, "Show", "", ddlSoSearch);
                objTaxMaster.ddlOperation(objTaxMaster, "Show", "", ddlTaxName);
                displayGrid();
                btnVisible();

                txtdtSoInvoice.Text = validation.fillDate();
                txtdtSoInvoice_TextChanged(this, e);
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
                     btnUpdate.Visible = false;
                     btnDelete.Visible = false;

                     GetFormData();
                     // GetGrandTotal();
                     lblmsg.Text = "";
                     tblmain.Visible = true;
                     tblGrd.Visible = false;
                     tblGridDet.Visible = true;
                     DetButtonVisible();
                     displayGridDet();

                     GetGrandTotal();
                     tblbootomPage.Visible = true;
                     btnUpdate.Visible = true;
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
        ViewState["tsoinvoice"] = Session["tsoinvoice"];
    }

    public void para()
    {
        objClass.sSoInvoiceNo = validation.stringToDBString(txtSoInvoiceNo.Text.Trim());
        objClass.dtSoInvoice = validation.dateToText(txtdtSoInvoice.Text.Trim());
        objClass.nLocationID = ddlLocationID.SelectedValue;
        objClass.nInvoiceFromID = ddlInvoiceFromID.SelectedValue;
        objClass.nSoID = ddlSoID.SelectedValue;
        objClass.sRefNo = validation.stringToDBString(txtRefNo.Text.Trim());
        objClass.nCustomerNameID = ddlCustomerName.SelectedValue;
        objClass.sRemarks = validation.stringToDBString(txtRemarks.Text.Trim());
        objClass.nShipingCost = txtShippimngCost.Text.Trim();
        objClass.nOtherCharges = txtOtherCharges.Text.Trim();
        objClass.nDiscount = txtDiscount.Text.Trim();
        objClass.bPaid = "0";  //Un paid 
    }
    public void paradet()
    {
        objClassDet.nSoInvoiceID = Session["eid"].ToString();
        objClassDet.nItemID = ddlItem.SelectedValue;
        objClassDet.nItemUnitID = ddlUnit.SelectedValue;
        objClassDet.nCurrentStock = txtStock.Text.Trim();
        objClassDet.nQuantity = txtQty.Text.Trim();
        objClassDet.nUnitPrice = txtUnitPrice.Text.Trim();
        objClassDet.nTotPrice = txtItemPrice.Text.Trim();

        objClassDet.nTaxMasterID = ddlTaxName.SelectedValue;
        objClassDet.nTaxTypeID = ddlTaxType.SelectedValue;
        objClassDet.nTaxValue = txtTaxValue.Text;
        objClassDet.nTaxableAmount = txtTaxableAmount.Text;

        objClassDet.CGST = txtCGST.Text.Trim();
        objClassDet.SGST = txtSGST.Text.Trim();
        objClassDet.IGST = txtIGST.Text.Trim();
        objClassDet.CGSTAmount = (double.Parse(txtItemPrice.Text) * double.Parse(txtCGST.Text) / 100).ToString();
        objClassDet.SGSTAmount = (double.Parse(txtItemPrice.Text) * double.Parse(txtSGST.Text) / 100).ToString();
        objClassDet.IGSTAmount = (double.Parse(txtItemPrice.Text) * double.Parse(txtIGST.Text) / 100).ToString();
    }
    public void clrfield()
    {
        txtSoInvoiceNo.Text = "";
        txtdtSoInvoice.Text = "";
        ddlLocationID.SelectedValue = "0";
        ddlInvoiceFromID.SelectedValue = "1";
        ddlSoID.SelectedValue = "0";
        txtRefNo.Text = "";
        ddlCustomerName.SelectedValue = "0";
        txtRemarks.Text = "";
        Session["eid"] = "";

        txtSubTot.Text = "0";
        txtShippimngCost.Text = "0";
        txtOtherCharges.Text = "0";
        txtDiscount.Text = "0";
        txtTaxTotal.Text = "0";
        txtGrandTot.Text = "0";
    }
    public void clrfieldDet()
    {

        ddlItem.SelectedValue = "0";
        ddlUnit.SelectedValue = "0";
        txtStock.Text = "";
        txtQty.Text = "0";
        txtUnitPrice.Text = "0";
        txtTotalPrice.Text = "0";
        Session["Detid"] = "";

        ddlTaxName.SelectedValue = "0";
        ddlTaxType.SelectedValue = "0";
        txtTaxValue.Text = "0";
        txtTaxableAmount.Text = "0";
    }

    public void GetFormData()
    {
        DataTable dt = objClass.viewData(objClass, "show", Session["eid"].ToString());
        if (dt.Rows.Count > 0)
        {
            txtSoInvoiceNo.Text = dt.Rows[0][1].ToString();
            txtdtSoInvoice.Text = validation.TextToDate(dt.Rows[0][2].ToString());
            ddlLocationID.SelectedValue = dt.Rows[0][3].ToString();
            ddlInvoiceFromID.SelectedValue = dt.Rows[0][4].ToString();
            objSOClass.ddlOperation(objSOClass, "Show", "", ddlSoID);
            ddlSoID.SelectedValue = dt.Rows[0][5].ToString();
            txtRefNo.Text = dt.Rows[0][6].ToString();
            ddlCustomerName.SelectedValue = dt.Rows[0][7].ToString();
            EventArgs e = new EventArgs();
            ddlCustomerName_SelectedIndexChanged(this, e);
            txtRemarks.Text = dt.Rows[0][8].ToString();


            txtShippimngCost.Text = dt.Rows[0][9].ToString();
            txtOtherCharges.Text = dt.Rows[0][10].ToString();
            txtDiscount.Text = dt.Rows[0][11].ToString();
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
            // txtStock.Text = dt.Rows[0][4].ToString();
            txtQty.Text = dt.Rows[0][5].ToString();
            txtUnitPrice.Text = dt.Rows[0][6].ToString();
            txtTotalPrice.Text = dt.Rows[0][7].ToString();

            ddlTaxName.SelectedValue = dt.Rows[0][8].ToString();
            ddlTaxType.SelectedValue = dt.Rows[0][9].ToString();
            txtTaxValue.Text = dt.Rows[0][10].ToString();
            txtTaxableAmount.Text = dt.Rows[0][11].ToString();
            txtcgstamt.Text = dt.Rows[0]["CGSTAmount"].ToString();
            txtsgstamt.Text = dt.Rows[0]["SGSTAmount"].ToString();
            txtigstamt.Text = dt.Rows[0]["IGSTAmount"].ToString();
        }
    }
    public void btnVisible()
    {
        btnAdd.Visible = true;
        btnUpdate.Visible = false;
        btnDelete.Visible = false;
        btnAddDet.Visible = false;
        btnUpdateDet.Visible = false;
        btnDeleteDet.Visible = false;
        clrfield();
    }

    public void DetButtonVisible()
    {
        tblDet.Visible = true;
        tblGridDet.Visible = true;
        btnAddDet.Visible = false;
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
        objClass.nSoInvoiceID = Session["eid"].ToString();
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
            if (Session["tsoinvoice"].ToString() == ViewState["tsoinvoice"].ToString())
            {
                para();
                var abc = objClass.User_Operation(objClass, "add");
                var strArr = abc.Split(',');
                if (strArr[0] == "1")
                {
                    string nSoInvoiceID = strArr[2].ToString();
                    Session["eid"] = nSoInvoiceID;

                    paradet();
                    var xyz = objClassDet.User_Operation(objClassDet, "add");

                    btnAdd.Visible = false;
                    btnAddDet.Visible = false;
                    btnUpdateDet.Visible = false;
                    tblGridDet.Visible = true;
                    displayGridDet();
                    clrfieldDet();

                    tblbootomPage.Visible = true;
                    btnUpdate.Visible = true;
                    GetGrandTotal();
                }
                valobj.showMsg(abc, lblmsg);
                //displayGrid();
                string aa = Server.UrlEncode(System.DateTime.Now.ToString());
                Session["tsoinvoice"] = aa;
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
            objClass.nSoInvoiceID = Session["eid"].ToString();
            var abc = objClass.User_Operation(objClass, "edit");
            valobj.showMsg(abc, lblmsg);

            tblbootomPage.Visible = true;
            btnUpdate.Visible = true;
            //displayGrid();
            string aa = Server.UrlEncode(System.DateTime.Now.ToString());
            Session["tsoinvoice"] = aa;
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
            btnUpdate.Visible = false;
            btnDelete.Visible = false;

            GetFormData();
            // GetGrandTotal();
            lblmsg.Text = "";
            tblmain.Visible = true;
            tblGrd.Visible = false;
            tblGridDet.Visible = true;
            DetButtonVisible();
            displayGridDet();

            GetGrandTotal();
            tblbootomPage.Visible = true;
            btnUpdate.Visible = true;
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

            objSalesPay.nSoInvoiceID = ID.Text;
            DropDownList ddlPMode = (DropDownList)GridView1.Rows[row].Cells[0].FindControl("ddlPayMode");
            objSalesPay.nPaymentModeID = ddlPMode.SelectedValue;

            TextBox txtamt = (TextBox)GridView1.Rows[row].Cells[0].FindControl("txtPayAmount");
            objSalesPay.nAmount = txtamt.Text;

            objSalesPay.dtPayment = validation.fillTextDate();

           TextBox txtremk = (TextBox)GridView1.Rows[row].Cells[0].FindControl("txtPayRemarks");
           objSalesPay.sRemarks =validation.stringToDBString(txtremk.Text);


           var abc = objSalesPay.User_Operation(objSalesPay, "add");
          

           GetPaidDetails();
           objClass.nSoInvoiceID = ID.Text;
           var xyz = objClass.User_Operation(objClass, "bPaidEdit");
           displayGrid();
           valobj.showMsg(abc, lblmsg);
            //btnAdd.Visible = false;
            //btnUpdate.Visible = false;
            //btnDelete.Visible = false;

            //GetFormData();
            //// GetGrandTotal();
            //lblmsg.Text = "";
            //tblmain.Visible = true;
            //tblGrd.Visible = false;
            //tblGridDet.Visible = true;
            //DetButtonVisible();
            //displayGridDet();

            //GetGrandTotal();
            //tblbootomPage.Visible = true;
            //btnUpdate.Visible = true;
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
            btnDeleteDet.Visible = true;
            GetFormDataDet();
            displayGridDet();
            lblmsg.Text = "";

            GetGrandTotal();
            tblbootomPage.Visible = true;
            btnUpdate.Visible = true;



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
                tblbootomPage.Visible = true;
                btnUpdate.Visible = true;
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
            objClassDet.nSoinvoiceDetID = Session["Detid"].ToString();
            var abc = objClassDet.User_Operation(objClassDet, "edit");
            valobj.showMsg(abc, lblmsg);
            displayGridDet();
            btnAddDet.Visible = true;
            btnUpdateDet.Visible = false;
            btnDeleteDet.Visible = false;
            clrfieldDet();
            GetGrandTotal();
            tblbootomPage.Visible = true;
            btnUpdate.Visible = true;
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
        objClassDet.nSoinvoiceDetID = Session["Detid"].ToString();
        var vres = objClassDet.User_Operation(objClassDet, "DeActive");
        valobj.showMsg(vres, lblmsg);
        displayGridDet();
        DetButtonVisible();
        GetGrandTotal();
        tblbootomPage.Visible = true;
        btnUpdate.Visible = true;
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

            Response.Redirect("rptsalesinvoice.aspx");
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
            Response.Redirect("rptsalesinvoice.aspx");

        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, "FAIL", lblmsg);
        }
    }

    protected void lnkAdd_Click(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        tblmain.Visible = true;
        tblGrd.Visible = false;
        tblGridDet.Visible = false;
        ddlSoID.Enabled = false;
        clrfield();
        btnVisible();
        txtdtSoInvoice.Text = validation.fillDate();
        txtdtSoInvoice_TextChanged(this, e);
        
        tblbootomPage.Visible = false;
        btnUpdate.Visible = false;
    }
    protected void lnkList_Click(object sender, EventArgs e)
    {
        Response.Redirect("tsoinvoice_list.aspx");
    }
    protected void txtQty_TextChanged(object sender, EventArgs e)
    {

        try
        {
            if (txtQty.Text != "" & txtUnitPrice.Text != "")
            {
                txtItemPrice.Text = (Convert.ToInt32(txtQty.Text) * Convert.ToInt32(txtUnitPrice.Text)).ToString();
                txtUnitPrice.Focus();
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
                txtItemPrice.Text = (Convert.ToInt32(txtQty.Text) * Convert.ToInt32(txtUnitPrice.Text)).ToString();
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
    protected void txtdtSoInvoice_TextChanged(object sender, EventArgs e)
    {
        SOI_Generate();
    }
    public void SOI_Generate()
    {
        DataTable dt = objClass.viewData(objClass, "MaxSOInvoiceNo", validation.dateToText(txtdtSoInvoice.Text));
        if (dt.Rows.Count > 0)
        {
            txtSoInvoiceNo.Text = dt.Rows[0][0].ToString();
        }
    }
    protected void ddlInvoiceFromID_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlInvoiceFromID.SelectedValue == "2")
        {
            ddlSoID.Enabled = true;
            objClass.ddlOperation(objClass, "ShowSO", "", ddlSoID);
        }
        else
        {
            ddlSoID.SelectedValue = "0";
            ddlSoID.Enabled = false;
        }
    }
    protected void ddlSoID_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            if (ddlSoID.SelectedValue != "0")
            {

                DataTable dt = objSOClass.viewData(objSOClass, "show", ddlSoID.SelectedValue);
                if (dt.Rows.Count > 0)
                {
                    ddlLocationID.SelectedValue = dt.Rows[0][5].ToString();
                    ddlCustomerName.SelectedValue = dt.Rows[0][7].ToString();
                    ddlCustomerName_SelectedIndexChanged(this, e);
                    // txtBalance.Text = dt.Rows[0][11].ToString();
                    txtRefNo.Text = dt.Rows[0][1].ToString();
                }
                para();
                var abc = objClass.User_Operation(objClass, "add");
                var strArr = abc.Split(',');
                if (strArr[0] == "1")
                {
                    string nSoInvoiceID = strArr[2].ToString();
                    Session["eid"] = nSoInvoiceID;
                    DataTable dtDet = objSODetClass.viewData(objSODetClass, "show", ddlSoID.SelectedValue);
                    if (dtDet.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtDet.Rows.Count; i++)
                        {
                            objClassDet.nSoInvoiceID = nSoInvoiceID.ToString();
                            objClassDet.nItemID = dtDet.Rows[i][2].ToString();
                            objClassDet.nItemUnitID = dtDet.Rows[i][3].ToString();
                            objClassDet.nCurrentStock = dtDet.Rows[i][4].ToString();
                            objClassDet.nQuantity = dtDet.Rows[i][5].ToString();
                            objClassDet.nUnitPrice = dtDet.Rows[i][6].ToString();
                            objClassDet.nTotPrice = dtDet.Rows[i][7].ToString();

                            var xyz = objClassDet.User_Operation(objClassDet, "add");
                        }
                    }

                    btnAdd.Visible = false;
                    btnAddDet.Visible = true;
                    btnUpdateDet.Visible = false;
                    btnDeleteDet.Visible = false;

                    tblDet.Visible = true;
                    tblGridDet.Visible = true;
                    GetFormData();

                    tblGridDet.Visible = true;
                    displayGridDet();
                   
                    GetGrandTotal();
                    tblbootomPage.Visible = true;
                    btnUpdate.Visible = true;
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
    protected void ddlCustomerName_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dt = objClassGen.viewData(objClassGen, "ShowGeneralLedgerBal", ddlCustomerName.SelectedValue);
        if (dt.Rows.Count > 0)
        {
            if (int.Parse(dt.Rows[0][17].ToString()) < 0)
            {
                txtBalance.Text = "";
                string val = dt.Rows[0][17].ToString();
                var TotBal = val.Split('-');
                txtBalance.Text = TotBal[1].ToString() + " " + "Dr";
            }
            else if (int.Parse(dt.Rows[0][17].ToString()) > 0)
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
                txtUnitPrice.Text = dtItem.Rows[0][14].ToString();
                ddlUnit.SelectedValue = dtItem.Rows[0][17].ToString();
            }
            else
            {
                ddlUnit.SelectedValue = "0";
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
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            objClass.nSoInvoiceID = ddlSoSearch.SelectedValue;
            objClass.nCustomerNameID = ddlCustSearch.SelectedValue;
            objClass.dtSoInvoice = validation.dateToText(txtdtFroms.Text.Trim());
            objClass.sRefNo = validation.dateToText(txtdtTo.Text.Trim());
            if (ddlSoSearch.SelectedValue != "0" || ddlCustSearch.SelectedValue != "0" || (txtdtFroms.Text != "" && txtdtTo.Text != ""))
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

    protected void ddlTaxName_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTaxName.SelectedValue != "0")
        {
            // Fill Tax Data
            DataTable dt = objTaxMaster.viewData(objTaxMaster, "Show", ddlTaxName.SelectedValue);
            //Commented on 02122021 start
            //if (dt.Rows.Count > 0)
            //{
            //    ddlTaxType.SelectedValue = dt.Rows[0]["nTaxTypeID"].ToString();
            //    txtTaxValue.Text = dt.Rows[0]["nTaxValue"].ToString();

            //}
            //else
            //{
            //    ddlTaxType.SelectedValue = "0";
            //    txtTaxValue.Text = "";
            //}
            //Commented on 02122021 start
            //Added on 02122021 start
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
            //Added on 02122021 end
            //Calculate Tax Amount
            //Commented on 02122021 start
            //if (ddlTaxType.SelectedValue == "1")
            //{
            //    txtTaxableAmount.Text = txtTaxValue.Text;
            //    ddlTaxType.Enabled = true;
            //    txtTaxValue.Enabled = true;
            //    txtTaxableAmount.Enabled = true;
            //}
            //else if (ddlTaxType.SelectedValue == "2")
            //{
            //    ddlTaxType.Enabled = false;
            //    txtTaxValue.Enabled = false;
            //    txtTaxableAmount.Enabled = false;
            //    txtTaxableAmount.Text = ((double.Parse(txtItemPrice.Text) * double.Parse(txtTaxValue.Text)) / 100).ToString();
            //}
            //else
            //{
            //    txtTaxableAmount.Text = "0";
            //}
            //Commented on 02122021 end
            CalTotPrice();
        }
        else
        {
            ddlTaxType.SelectedValue = "0";
            txtTaxValue.Text = "";
            txtTaxableAmount.Text = "0";
        }
    }
    //Added on 02122021 start
    public void CalTotPrice()
    {
        //if (txtOtherTax.Text == "")
        //{
        //    txtOtherTax.Text = "0";
        //}
        //Calculate Tax Amount
        double cgst = 0; double sgst = 0; double Igst = 0; double ItemDiscount = 0;
        cgst = ((double.Parse(txtItemPrice.Text) * double.Parse(txtCGST.Text)) / 100);
        txtcgstamt.Text = Convert.ToString(cgst);
        sgst = ((double.Parse(txtItemPrice.Text) * double.Parse(txtSGST.Text)) / 100);
        txtsgstamt.Text = Convert.ToString(sgst);
        Igst = ((double.Parse(txtItemPrice.Text) * double.Parse(txtIGST.Text)) / 100);
        txtigstamt.Text = Convert.ToString(Igst);
        //ItemDiscount = (double.Parse(txtItemPrice.Text) * double.Parse(txtItemDiscount.Text) / 100);
        txtTotalPrice.Text = (cgst + sgst + Igst - ItemDiscount  + double.Parse(txtItemPrice.Text)).ToString();
    }
    public void GetGrandTotal()
    {
        if (Session["eid"].ToString() != null)
        {

            DataTable dt = objClass.viewData(objClass, "ShowGrid", Session["eid"].ToString());
            if (dt.Rows.Count > 0)
            {
                txtSubTot.Text = dt.Rows[0]["SubTotal"].ToString();
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
        DataTable dtMain =new DataTable();
        dtMain=objClass.viewData(objClass,"ShowGrid",Session["eid"].ToString());
        if(dtMain.Rows.Count>0)
        {
             GrandTotal = dtMain.Rows[0]["GTotal"].ToString();
        }

        DataTable dtPaid = objSalesPay.viewData(objSalesPay, "ShowPaid", Session["eid"].ToString());
        if (dtPaid.Rows.Count > 0)
        {
            TotalPaid = dtPaid.Rows[0]["sTotPaid"].ToString();
        }
        
        //Adding value for bPaid
        if (TotalPaid.ToString() == "" || TotalPaid.ToString() =="0")
        {
            objClass.bPaid = "0";   //UnPaid
        }
        if(GrandTotal.ToString() == TotalPaid.ToString())
        {
            objClass.bPaid = "1";   //Paid
        }
        else if (int.Parse(TotalPaid) > 0 &&   int.Parse(TotalPaid)< int.Parse(GrandTotal))
        {
            objClass.bPaid = "2";   //Paid
        }
        else
        {
            objClass.bPaid = "2";   //Exta Paid
        }
    }
}
