using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Transcation_quotation : System.Web.UI.Page
{
    tquotation_Class objClass = new tquotation_Class();
    tquotation_det_Class objClassDet = new tquotation_det_Class();
    mlocation_Class objLocation = new mlocation_Class();
    mitemunit_Class objUnit = new mitemunit_Class();
    titem_details_Class objItem = new titem_details_Class();
    mmain_account_Class objChartofAcc = new mmain_account_Class();
    mtax_master_Class objTaxMaster = new mtax_master_Class();
    tvisadet_Class objClassGen = new tvisadet_Class();
    validation valobj = new validation();

    string cond;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                string aa = Server.UrlEncode(System.DateTime.Now.ToString());
                Session["tquotation"] = aa;
                tblmain.Visible = true;
                tblGrd.Visible = false;
                tblDet.Visible = true;
                tblGridDet.Visible = false;
                tblbootomPage.Visible = false;
                objLocation.ddlOperation(objLocation, "Show", "", ddlLocation);
                objItem.ddlOperation(objItem, "Show", "", ddlItem);
                objUnit.ddlOperation(objUnit, "Show", "", ddlUnit);
                objChartofAcc.ddlOperation(objChartofAcc, "ShowddlAccount", "", ddlCustomerName);
                objChartofAcc.ddlOperation(objChartofAcc, "ShowddlAccount", "", ddlCustSearch);
                objClass.ddlOperation(objClass, "Show", "", ddlQuotation);
                objTaxMaster.ddlOperation(objTaxMaster, "Show", "", ddlTaxName);
                displayGrid();
                btnVisible();
                dtQuotation.Text = validation.fillDate();
                dtQuotation_TextChanged(this, e);
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

    public void Page_PreRender(object sender, EventArgs e)
    {
        ViewState["tquotation"] = Session["tquotation"];
    }

    public void para()
    {
        objClass.sQuotationNo = validation.stringToDBString(txtQuotationNo.Text.Trim());
        objClass.nQuotationTypeID = ddlType.SelectedValue;
        //objClass.sQuotationStatus = validation.stringToDBString(txtStatus.Text.Trim());
        objClass.dtQuotation = validation.dateToText(dtQuotation.Text.Trim());
        objClass.dtQuotationExpiry = validation.dateToText(dtQuotationExpiry.Text.Trim());
        objClass.nLocationID = ddlLocation.SelectedValue;
        objClass.nCustomerNameID = ddlCustomerName.SelectedValue;
      //  objClass.nBalance = txtBalance.Text.Trim();
        if (chkAttantion.Checked == true)
        {
            objClass.bAttenttion = "1";

        }
        else
        {
            objClass.bAttenttion = "0";
        }
        objClass.sAttention = validation.stringToDBString(txtAttention.Text.Trim());
        if (chkNote.Checked == true)
        {
            objClass.bNote = "1";

        }
        else
        {
            objClass.bNote = "0";
        }
        objClass.sNote = validation.stringToDBString(txtNote.Text.Trim());
        objClass.sRemarks = validation.stringToDBString(txtRemarks.Text.Trim());
        objClass.nShipingCost = txtShippimngCost.Text.Trim();
        objClass.nOtherCharges = txtOtherCharges.Text.Trim();
        objClass.nDiscount = txtDiscount.Text.Trim();
        objClass.bPaid = "0";  //Un paid 

    }

    public void paradet()
    {
        objClassDet.nQuotationID = Session["eid"].ToString();
        objClassDet.nItemID = ddlItem.SelectedValue;
        objClassDet.nUnitID = ddlUnit.SelectedValue;
     //   objClassDet.nCurrentStock = txtStock.Text.Trim();
        objClassDet.nQuantity = txtQty.Text.Trim();
        objClassDet.nUnitPrice = txtUnitPrice.Text.Trim();
        objClassDet.nTotalPrice = txtTotalPrice.Text.Trim();
        objClassDet.nTaxMasterID = ddlTaxName.SelectedValue;
        objClassDet.nTaxTypeID = ddlTaxType.SelectedValue;
        objClassDet.nTaxValue = txtTaxValue.Text;
        objClassDet.nTaxableAmount = txtTaxableAmount.Text;
    }

    public void clrfield()
    {
        txtQuotationNo.Text = "";
        ddlType.SelectedValue = "0";
      //  txtStatus.Text = "";
        dtQuotation.Text = "";
        dtQuotationExpiry.Text = "";
        ddlLocation.SelectedValue = "0";
        ddlCustomerName.SelectedValue = "0";
       // txtBalance.Text = "";
        chkAttantion.Checked = false;
        txtAttention.Text = "";
        txtNote.Text = "";
        chkNote.Checked = false;
        txtRemarks.Text = "";

        txtSubTot.Text = "0";
        txtShippimngCost.Text = "0";
        txtOtherCharges.Text = "0";
        txtDiscount.Text = "0";
        txtTaxTotal.Text = "0";
        txtGrandTot.Text = "0";

        Session["eid"] = "";
    }
    public void clrfieldDet()
    {

        ddlItem.SelectedValue = "0";
        ddlUnit.SelectedValue = "0";
        txtStock.Text = "";
        txtQty.Text = "0";
        txtUnitPrice.Text = "0";
        txtTotalPrice.Text = "0";
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
            txtQuotationNo.Text = dt.Rows[0][1].ToString();
            ddlType.SelectedValue = dt.Rows[0][2].ToString();
           // txtStatus.Text = dt.Rows[0][3].ToString();
            dtQuotation.Text = validation.TextToDate(dt.Rows[0][4].ToString());
            dtQuotationExpiry.Text = validation.TextToDate(dt.Rows[0][5].ToString());
            ddlLocation.SelectedValue = dt.Rows[0][6].ToString();
            ddlCustomerName.SelectedValue = dt.Rows[0][7].ToString();
            EventArgs e = new EventArgs();
            ddlCustomerName_SelectedIndexChanged(this, e);
           // txtBalance.Text = dt.Rows[0][8].ToString();

            if (dt.Rows[0][9].ToString() == "1")
            {
                chkAttantion.Checked = true;
            }
            else
            {
                chkAttantion.Checked = false;
            }
            txtAttention.Text = dt.Rows[0][10].ToString();

            if (dt.Rows[0][11].ToString() == "1")
            {
                chkNote.Checked = true;
            }
            else
            {
                chkNote.Checked = false;
            }
            txtNote.Text = dt.Rows[0][11].ToString();
            txtRemarks.Text = dt.Rows[0][12].ToString();
            // txtGrandTotal.Text = dt.Rows[0][14].ToString();
            txtShippimngCost.Text = dt.Rows[0][13].ToString();
            txtOtherCharges.Text = dt.Rows[0][14].ToString();
            txtDiscount.Text = dt.Rows[0][15].ToString();

        }
    }
    public void GetFormDataDet()
    {
        DataTable dt = objClassDet.viewData(objClassDet, "show", Session["detid"].ToString());
        if (dt.Rows.Count > 0)
        {
            ddlItem.SelectedValue = dt.Rows[0][2].ToString();
            EventArgs e = new EventArgs();
            ddlItem_SelectedIndexChanged(this, e);
            //txtStock.Text = dt.Rows[0][3].ToString();
            ddlUnit.SelectedValue = dt.Rows[0][4].ToString();
            txtQty.Text = dt.Rows[0][5].ToString();
            txtUnitPrice.Text = dt.Rows[0][6].ToString();
            txtTotalPrice.Text = dt.Rows[0][7].ToString();

            ddlTaxName.SelectedValue = dt.Rows[0][8].ToString();
            ddlTaxType.SelectedValue = dt.Rows[0][9].ToString();
            txtTaxValue.Text = dt.Rows[0][10].ToString();
            txtTaxableAmount.Text = dt.Rows[0][11].ToString();
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
        objClass.nQuotationID = Session["eid"].ToString();
        var vres = objClass.User_Operation(objClass, "DeActive");
        valobj.showMsg(vres, lblmsg);
        displayGrid();
        btnVisible();
    }
    protected void txtQty_TextChanged(object sender, EventArgs e)
    {

        try
        {
            if (txtQty.Text != "" & txtUnitPrice.Text != "")
            {
                txtTotalPrice.Text = (Convert.ToInt32(txtQty.Text) * Convert.ToInt32(txtUnitPrice.Text)).ToString();
                txtUnitPrice.Focus();
            }
            else
            {
                txtTotalPrice.Text = "0";
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
                txtTotalPrice.Text = (Convert.ToInt32(txtQty.Text) * Convert.ToInt32(txtUnitPrice.Text)).ToString();
                btnAddDet.Focus();
            }
            else
            {
                txtTotalPrice.Text = "0";
            }
        }
        catch
        {

        }

    }


    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            lblmsg.Text = "";
            if (Session["tquotation"].ToString() == ViewState["tquotation"].ToString())
            {
                para();
                var abc = objClass.User_Operation(objClass, "add");
                var strArr = abc.Split(',');
                if (strArr[0] == "1")
                {
                    string nQuotationID = strArr[2].ToString();
                    Session["eid"] = nQuotationID;

                    paradet();
                    var xyz = objClassDet.User_Operation(objClassDet, "add");

                    btnAdd.Visible = false;
                    btnAddDet.Visible = false;
                    btnUpdateDet.Visible = false;
                    tblGridDet.Visible = true;
                    displayGridDet();
                    clrfieldDet();
                    GetGrandTotal();
                    tblbootomPage.Visible = true;
                    btnUpdate.Visible = true;

                }
                valobj.showMsg(abc, lblmsg);

                string aa = Server.UrlEncode(System.DateTime.Now.ToString());
                Session["tquotation"] = aa;
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
            objClass.nQuotationID = Session["eid"].ToString();
            var abc = objClass.User_Operation(objClass, "edit");
            valobj.showMsg(abc, lblmsg);
            //displayGrid();
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
           
            btnDelete.Visible = false;
            DetButtonVisible();

            GetFormData();
            lblmsg.Text = "";
            tblmain.Visible = true;
            tblDet.Visible = true;

            tblGrd.Visible = false;

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
            // DetButtonVisible();
            GetFormDataDet();
            lblmsg.Text = "";
            GetGrandTotal();


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
            if (Session["tquotation"].ToString() == ViewState["tquotation"].ToString())
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
                Session["tquotation"] = aa;
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
            objClassDet.nQuotationDetID = Session["Detid"].ToString();
            var abc = objClassDet.User_Operation(objClassDet, "edit");
            valobj.showMsg(abc, lblmsg);
            displayGridDet();
            DetButtonVisible();
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
        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, "FAIL", lblmsg);
        }
    }
    public void DeleteDetRecord()
    {
        objClassDet.nQuotationDetID = Session["Detid"].ToString();
        var vres = objClassDet.User_Operation(objClassDet, "DeActive");
        valobj.showMsg(vres, lblmsg);
        displayGridDet();
        DetButtonVisible();
        GetGrandTotal();
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
            Response.Redirect("rptquotation.aspx");

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
            objClass.nQuotationID = ddlQuotation.SelectedValue;
            objClass.nCustomerNameID = ddlCustSearch.SelectedValue;
            objClass.dtQuotation = validation.dateToText(txtdtFroms.Text.Trim());
            objClass.dtQuotationExpiry = validation.dateToText(txtdtTo.Text.Trim());
            if (ddlQuotation.SelectedValue != "0" || ddlCustSearch.SelectedValue != "0" || (txtdtFroms.Text != "" && txtdtTo.Text != ""))
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
        clrfield();
        btnVisible();
        dtQuotation.Text = validation.fillDate();
        dtQuotation_TextChanged(this, e);
        tblbootomPage.Visible = false;
        tblGridDet.Visible=false;
    }
    protected void lnkList_Click(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        tblmain.Visible = false;
        tblGrd.Visible = true;
        displayGrid();
    }
    protected void chkAttantion_CheckedChanged(object sender, EventArgs e)
    {
        if (chkAttantion.Checked == true)
        {
            txtAttention.Enabled = true;
        }
        else
        {
            txtAttention.Enabled = false;
        }
    }
    protected void chkNote_CheckedChanged(object sender, EventArgs e)
    {
        if (chkNote.Checked == true)
        {
            txtNote.Enabled = true;
        }
        else
        {
            txtNote.Enabled = false;
        }
    }
    public void Quotation_Generate()
    {
        DataTable dt = objClass.viewData(objClass, "MaxQuotationNo", validation.dateToText(dtQuotation.Text));
        if (dt.Rows.Count > 0)
        {
            txtQuotationNo.Text = dt.Rows[0][0].ToString();
        }
    }
    protected void dtQuotation_TextChanged(object sender, EventArgs e)
    {
        Quotation_Generate();
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

    protected void ddlTaxName_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTaxName.SelectedValue != "0")
        {
            // Fill Tax Data
            DataTable dt = objTaxMaster.viewData(objTaxMaster, "Show", ddlTaxName.SelectedValue);
            if (dt.Rows.Count > 0)
            {
                ddlTaxType.SelectedValue = dt.Rows[0]["nTaxTypeID"].ToString();
                txtTaxValue.Text = dt.Rows[0]["nTaxValue"].ToString();

            }
            else
            {
                ddlTaxType.SelectedValue = "0";
                txtTaxValue.Text = "";
            }

            //Calculate Tax Amount
            if (ddlTaxType.SelectedValue == "1")
            {
                txtTaxableAmount.Text = txtTaxValue.Text;
            }
            else if (ddlTaxType.SelectedValue == "2")
            {
                txtTaxableAmount.Text = ((double.Parse(txtTotalPrice.Text) * double.Parse(txtTaxValue.Text)) / 100).ToString();
            }
            else
            {
                txtTaxableAmount.Text = "0";
            }

        }
        else
        {
            ddlTaxType.SelectedValue = "0";
            txtTaxValue.Text = "";
            txtTaxableAmount.Text = "0";
        }
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
}
