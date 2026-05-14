using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Transcation_travel_expense_voucher : System.Web.UI.Page
{
    ttravel_expense_voucher_Class objClass = new ttravel_expense_voucher_Class();
    ttravel_expense_voucherdet_Class objClassDet = new ttravel_expense_voucherdet_Class();
    mdriver_Class objDriver = new mdriver_Class();
    mvehicle_Class objVehicle = new mvehicle_Class();
    mexpense_category_Class objExpCat = new mexpense_category_Class();
    maccount_cash_Class objCashAcc = new maccount_cash_Class();
    maccount_expense_Class objExpAcc = new maccount_expense_Class();
    mlocation_Class objLoc = new mlocation_Class();
    muser_Class objUser = new muser_Class();
    validation valobj = new validation();
    string cond;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                //Fillddl.FillPageddl(ddlPageSize);
                string aa = Server.UrlEncode(System.DateTime.Now.ToString());
                Session["ttravel_expense_voucher"] = aa;
                tblmain.Visible = true;
                tblGrd.Visible = false;

                objLoc.ddlOperation(objLoc, "Show", "", ddlLocationID);
                objDriver.ddlOperation(objDriver, "Show", "", ddlDriverID);
                objVehicle.ddlOperation(objVehicle, "Show", "", ddlVehicleID);
                objExpCat.ddlOperation(objExpCat, "Show", "", ddlExpenseCatID);
                objCashAcc.ddlOperation(objCashAcc, "Show", "", ddlCashAccountID);
                objExpAcc.ddlOperation(objExpAcc, "Show", "", ddlExpenseAccountID);
                displayGrid();
                btnVisible();
                fillUser();
                txtdtVoucher.Text = validation.fillDate();
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

                if (Session["TEid"] != "" && Session["TEid"] != null)
                {

                    string eid = Session["TEid"].ToString();
                    Session["eid"] = eid;
                    Session["TEid"] = "";
                    GetFormData();
                    // GetFormDataDet();
                    btnAdd.Visible = false;
                    btnAddDet.Visible = true;
                    btnUpdateDet.Visible = false;
                    // btnPrint.Visible = true;
                    tblGridDet.Visible = true;
                    DisableData();
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
        ViewState["ttravel_expense_voucher"] = Session["ttravel_expense_voucher"];
    }
    public void fillUser()
    {
        DataTable dt = objUser.viewData(objUser, "show", Session["uid"].ToString());
        if (dt.Rows.Count > 0)
        {
            txtAmbedby.Text = dt.Rows[0][3].ToString();
            txtPostedby.Text = dt.Rows[0][3].ToString();
        }
    }

    public void para()
    {
        objClass.nVoucherTypeID = ddlVoucherTypeID.SelectedValue;
        objClass.nCashAccountID = ddlCashAccountID.SelectedValue;
        objClass.sVoucherNo = validation.stringToDBString(txtVoucherNo.Text.Trim());
        objClass.nStatusID = ddlStatusID.SelectedValue;
        objClass.dtVoucher = validation.dateToText(txtdtVoucher.Text.Trim());
        objClass.nLocationID = ddlLocationID.SelectedValue;
        objClass.sPostedby = validation.stringToDBString(txtPostedby.Text.Trim());
        objClass.sAmbedby = validation.stringToDBString(txtAmbedby.Text.Trim());
    }

    public void clrfield()
    {
        ddlVoucherTypeID.SelectedValue = "0";
        ddlCashAccountID.SelectedValue = "0";
        txtVoucherNo.Text = "";
        ddlStatusID.SelectedValue = "0";
        txtdtVoucher.Text = "";
        ddlLocationID.SelectedValue = "0";
        txtPostedby.Text = "";
        txtAmbedby.Text = "";
        Session["eid"] = "";
        lblTotAmount.Text = "";
    }
    protected void txtdtVoucher_TextChanged(object sender, EventArgs e)
    {
        Voucher_Generate();
    }
    public void Voucher_Generate()
    {
        DataTable dt = objClass.viewData(objClass, "VNO", validation.dateToText(txtdtVoucher.Text));
        if (dt.Rows.Count > 0)
        {
            txtVoucherNo.Text = dt.Rows[0][0].ToString();
        }
    }
    public void Total_Amount()
    {
        lblTotAmount.Visible = true;
        DataTable dt = objClassDet.viewData(objClassDet, "TotAmt", Session["eid"].ToString());
        if (dt.Rows.Count > 0)
        {
            lblTotAmount.Text = " Total amount is :" + ' ' + dt.Rows[0][0].ToString();
        }



    }
    public void GetFormData()
    {
        DataTable dt = objClass.viewData(objClass, "show", Session["eid"].ToString());
        if (dt.Rows.Count > 0)
        {
            ddlVoucherTypeID.SelectedValue = dt.Rows[0][1].ToString();
            ddlCashAccountID.SelectedValue = dt.Rows[0][2].ToString();
            txtVoucherNo.Text = dt.Rows[0][3].ToString();
            ddlStatusID.SelectedValue = dt.Rows[0][4].ToString();
            txtdtVoucher.Text = validation.TextToDate(dt.Rows[0][5].ToString());
            ddlLocationID.SelectedValue = dt.Rows[0][6].ToString();
            txtPostedby.Text = dt.Rows[0][7].ToString();
            txtAmbedby.Text = dt.Rows[0][8].ToString();
        }
    }

    public void btnVisible()
    {
        btnAdd.Visible = true;
        //btnUpdate.Visible = false;
        btnUpdateDet.Visible = false;
        btnAddDet.Visible = false;
        //btnDelete.Visible = false;
        clrfield();
    }

    public void displayGrid()
    {
        try
        {
            objClass.FillGrid(objClass, GridView1, "Show", "");
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
        objClass.nTravelExpenseVoucherID = Session["eid"].ToString();
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
            if (Session["ttravel_expense_voucher"].ToString() == ViewState["ttravel_expense_voucher"].ToString())
            {
                para();
                var abc = objClass.User_Operation(objClass, "add");

                var strArr = abc.Split(',');
                if (strArr[0] == "1")
                {
                    string VoucherID = strArr[2].ToString();
                    Session["eid"] = VoucherID;

                    paraDet();
                    objClassDet.nTravelExpenseVoucherID = Session["eid"].ToString();
                    var xyz = objClassDet.User_Operation(objClassDet, "add");

                    tblGridDet.Visible = true;

                    displayGridDet();

                    btnAdd.Visible = false;
                    //btnUpdate.Visible = true;
                    btnAddDet.Visible = true;
                    btnUpdateDet.Visible = false;
                    clrfieldDet();
                    Total_Amount();
                    DisableData();

                }
                valobj.showMsg(abc, lblmsg);
                //displayGrid();
                string aa = Server.UrlEncode(System.DateTime.Now.ToString());
                Session["ttravel_expense_voucher"] = aa;
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
    //        objClass.nTravelExpenseVoucherID = Session["eid"].ToString();
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

            btnAdd.Visible = false;
            //btnUpdate.Visible = true;
            btnAddDet.Visible = true;
            btnUpdateDet.Visible = false;
            //btnDelete.Visible = true;
            GetFormData();
            lblmsg.Text = "";
            tblmain.Visible = true;
            tblGrd.Visible = false;
            tblGridDet.Visible = true;
            displayGridDet();
            clrfieldDet();
            Total_Amount();
            DisableData();
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
            Response.Redirect("ttravelexpense_invoice.aspx");

        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, "FAIL", lblmsg);
        }
    }

    // For Details Table 


    public void paraDet()
    {
        objClassDet.nTravelExpenseVoucherID = Session["eid"].ToString();
        objClassDet.nDriverID = ddlDriverID.SelectedValue;
        objClassDet.nVehicleID = ddlVehicleID.SelectedValue;
        objClassDet.nExpenseAccountID = ddlExpenseAccountID.SelectedValue;
        objClassDet.nExpenseCatID = ddlExpenseCatID.SelectedValue;
        objClassDet.nAmount = txtAmount.Text.Trim();
        objClassDet.sDescription = validation.stringToDBString(txtDescription.Text.Trim());
        objClassDet.sRemarks = validation.stringToDBString(txtRemarks.Text.Trim());
    }

    public void clrfieldDet()
    {
        ddlDriverID.SelectedValue = "0";
        ddlVehicleID.SelectedValue = "0";
        ddlExpenseAccountID.SelectedValue = "0";
        ddlExpenseCatID.SelectedValue = "0";
        txtAmount.Text = "";
        txtDescription.Text = "";
        txtRemarks.Text = "";
        Session["Detid"] = "";
    }

    public void GetFormDataDet()
    {
        DataTable dt = objClassDet.viewData(objClassDet, "show", Session["Detid"].ToString());
        if (dt.Rows.Count > 0)
        {
            ddlDriverID.SelectedValue = dt.Rows[0][2].ToString();
            ddlVehicleID.SelectedValue = dt.Rows[0][3].ToString();
            ddlExpenseAccountID.SelectedValue = dt.Rows[0][4].ToString();
            ddlExpenseCatID.SelectedValue = dt.Rows[0][5].ToString();
            txtAmount.Text = dt.Rows[0][6].ToString();
            txtDescription.Text = dt.Rows[0][7].ToString();
            txtRemarks.Text = dt.Rows[0][8].ToString();
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

    public void DisableData()
    {
        ddlVoucherTypeID.Enabled = false;
        ddlCashAccountID.Enabled = false;
        ddlStatusID.Enabled = false;
        txtdtVoucher.Enabled = false;
        ddlLocationID.Enabled = false;
        txtPostedby.Enabled = false;
        txtAmbedby.Enabled = false;
     //   Img5.Enabled = false;
    }
    public void VisibleData()
    {
        ddlVoucherTypeID.Enabled = true;
        ddlCashAccountID.Enabled = true;
        ddlStatusID.Enabled = true;
        txtdtVoucher.Enabled = true;
        ddlLocationID.Enabled = true;
        txtPostedby.Enabled = true;
        txtAmbedby.Enabled = true;
   //     Img5.Enabled = true;
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
            if (Session["ttravel_expense_voucher"].ToString() == ViewState["ttravel_expense_voucher"].ToString())
            {
                paraDet();
                var abc = objClassDet.User_Operation(objClassDet, "add");

                //DetButtonVisible();
                tblGridDet.Visible = true;

                displayGridDet();
                clrfieldDet();
                btnAddDet.Visible = true;
                btnAdd.Visible = false;
                btnUpdateDet.Visible = false;
                Total_Amount();
                valobj.showMsg(abc, lblmsg);
                string aa = Server.UrlEncode(System.DateTime.Now.ToString());
                Session["ttravel_expense_voucher"] = aa;
                DisableData();
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
            btnAdd.Visible = false;
            btnAddDet.Visible = false;
            btnUpdateDet.Visible = true;
            Total_Amount();
            //btnDeleteDet.Visible = true;
            // DetButtonVisible();

            GetFormDataDet();
            lblmsg.Text = "";
            tblGridDet.Visible = true;
            displayGridDet();



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
            paraDet();
            objClassDet.nTravelExpenseVoucherDetID = Session["Detid"].ToString();
            var abc = objClassDet.User_Operation(objClassDet, "edit");
            valobj.showMsg(abc, lblmsg);
            //DetButtonVisible();
            btnAdd.Visible = false;
            btnAddDet.Visible = true;
            btnUpdateDet.Visible = false;
            tblGridDet.Visible = true;
            clrfieldDet();
            displayGridDet();
            Total_Amount();
            DisableData();

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
        objClassDet.nTravelExpenseVoucherDetID = Session["Detid"].ToString();
        var vres = objClassDet.User_Operation(objClassDet, "DeActive");
        valobj.showMsg(vres, lblmsg);
        tblGridDet.Visible = true;
        displayGridDet();
        clrfieldDet();
        //DetButtonVisible();
    }

    protected void lnkAdd_Click(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        tblmain.Visible = true;
        tblGrd.Visible = false;
        tblGridDet.Visible = false;
        clrfield();
        btnVisible();
        VisibleData();
        txtdtVoucher.Text = validation.fillDate();
        Voucher_Generate();
        Session["eid"] = "";
        Session["TEid"] = "";
    }
    protected void lnkList_Click(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        tblmain.Visible = false;
        tblGrd.Visible = true;
        displayGrid();

        Session["eid"] = "";
        Session["TEid"] = "";
    }

}
