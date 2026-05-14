using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Collections.Generic;
public partial class Transcation_item_details : System.Web.UI.Page
{
    titem_details_Class objClass = new titem_details_Class();
    mmain_account_Class objChartofAcc = new mmain_account_Class();
    mitem_category_Class objItemCat = new mitem_category_Class();
    mitem_sub_category_Class objItemSubCat = new mitem_sub_category_Class();
    mitemunit_Class objItemUnit = new mitemunit_Class();
    mitemsize_Class objItemSize = new mitemsize_Class();
    titem_picture_Class objPicture = new titem_picture_Class();
    titem_property_Class objItemProperty = new titem_property_Class();
    titem_account_Class objItemAccount = new titem_account_Class();
    mtax_master_Class objTaxmaster = new mtax_master_Class();

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
                Session["titem_details"] = aa;
               // tblmain.Visible = true;
                //tblGrd.Visible = false;
                //displayGrid();
                btnVisible();
               

                objItemCat.ddlOperation(objItemCat, "Show", "", ddlItemCategory);
                objItemUnit.ddlOperation(objItemUnit, "Show", "", ddlItemUnit);
                objItemSize.ddlOperation(objItemSize, "Show", "", ddlItemSize);
                objTaxmaster.ddlOperation(objTaxmaster, "Show", "", ddlGSTTax);

                //Chart of Accounts
                objChartofAcc.ddlOperation(objChartofAcc, "ShowddlAccount", "", ddlAssetsAccount);
                objChartofAcc.ddlOperation(objChartofAcc, "ShowddlAccount", "", ddlExpenseAccount);
                objChartofAcc.ddlOperation(objChartofAcc, "ShowddlAccount", "", ddlRevenueAccount);
                

                chkTaxItem_CheckedChanged(this, e);

                ItemTabe1.Attributes.Remove("class");
                ItemTab_1.Attributes.Remove("class");
                ItemTabe1.Attributes.Add("class", "nav-link active");
                ItemTab_1.Attributes.Add("class", "tab-pane fade active show");

                //ItemTabe2.Attributes.Remove("class");
                //ItemTab_2.Attributes.Remove("class");
                //ItemTabe2.Attributes.Add("class", "nav-link");
                //ItemTab_2.Attributes.Add("class", "tab-pane fade hide");



                ItemTabe3.Attributes.Remove("class");
                ItemTab_3.Attributes.Remove("class");
                ItemTabe3.Attributes.Add("class", "nav-link");
                ItemTab_3.Attributes.Add("class", "tab-pane fade  hide");

                ItemTabe4.Attributes.Remove("class");
                ItemTab_4.Attributes.Remove("class");
                ItemTabe4.Attributes.Add("class", "nav-link ");
                ItemTab_4.Attributes.Add("class", "tab-pane fade  hide");

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
                VisibleTab();
                var ID = Request.QueryString["ID"];
                if (!string.IsNullOrEmpty(ID))
                {
                    Session["eid"] = ID;

                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    btnDelete.Visible = true;
                    GetFormData();
                    GetFormPropertyData();
                    GetFormAccountData();
                    GetFormPictureData();
                    chkTaxItem_CheckedChanged(this, e);
                    lblmsg.Text = "";
                    //tblmain.Visible = true;
                    tblGrd.Visible = false;
                    VisibleTab();
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
        ViewState["titem_details"] = Session["titem_details"];
    }

    public void VisibleTab()
    {
        if (Session["eid"].ToString() == "")
        {
            ItemTab1.Visible = true;
            //ItemTab2.Visible = false;
            ItemTab3.Visible = false;
            ItemTab4.Visible = false;
        }
        else
        {
            ItemTab1.Visible = true;
            //ItemTab2.Visible = true;
            ItemTab3.Visible = true;
            ItemTab4.Visible = true;
        }



    }

    public void para()
    {
       

        objClass.sitemName = validation.stringToDBString(txtitemName.Text.Trim());
        objClass.nItemCategoryID = ddlItemCategory.SelectedValue;
        objClass.nItemSubCategoryID = ddlItemSubCategory.SelectedValue;
        objClass.nItemTypeID = ddlItemType.SelectedValue;
        objClass.sItemMark = validation.stringToDBString(txtItemMark.Text.Trim());
        objClass.sWarrentyRemarks = validation.stringToDBString(txtWarrentyRemarks.Text.Trim());
        if (chkWarrentyRemarks.Checked == true)
        {
            objClass.bWarrentyRemarks = "1";
        }
        else
        {
            objClass.bWarrentyRemarks = "0";
        }

        objClass.sPromotionRemarks = validation.stringToDBString(txtPromotionRemarks.Text.Trim());
        if (chkPromotionRemarks.Checked == true)
        {
            objClass.bPromotionRemarks = "1";
        }
        else
        {
            objClass.bPromotionRemarks = "0";
        }

        objClass.sItemRemarks = validation.stringToDBString(txtItemRemarks.Text.Trim());

        if (chkItemRemarks.Checked == true)
        {
            objClass.bItemRemarks = "1";
        }
        else
        {
            objClass.bItemRemarks = "0";
        }
        objClass.sSpecificationRemarks = validation.stringToDBString(txtSpecificationRemarks.Text.Trim());
        if (chkSpecificationRemarks.Checked == true)
        {
            objClass.bSpecificationRemarks = "1";
        }
        else
        {
            objClass.bSpecificationRemarks = "0";
        }
        objClass.nSalePrice = txtSalePrice.Text.Trim();
        objClass.nAvgSalePrice = txtAvgSalePrice.Text.Trim();
        objClass.nLastPurchasePrice = txtLastPurchasePrice.Text.Trim();
        objClass.nAvgPurchasePrice = txtAvgPurchasePrice.Text.Trim();
        objClass.dtLastPurchase = validation.dateToText(txttLastPurchase.Text.Trim());
        objClass.dtLastOrder = validation.dateToText(txttLastOrder.Text.Trim());
        objClass.dtLastSold = validation.dateToText(txttLastSold.Text.Trim());
        objClass.dtExpiry = validation.dateToText(txttExpiry.Text.Trim());

    }

    public void clrfield()
    {
        txtitemName.Text = "";
        // txtItemCategoryID.Text = "";
        // txtItemSubCategoryID.Text = "";
        //txtItemTypeID.Text = "";
        txtItemMark.Text = "";
        txtWarrentyRemarks.Text = "";
        txtWarrentyRemarks.Text = "";
        txtPromotionRemarks.Text = "";
        txtPromotionRemarks.Text = "";
        txtItemRemarks.Text = "";
        txtItemRemarks.Text = "";
        txtSpecificationRemarks.Text = "";
        txtSpecificationRemarks.Text = "";
        txtSalePrice.Text = "";
        txtAvgSalePrice.Text = "";
        txtLastPurchasePrice.Text = "";
        txtAvgPurchasePrice.Text = "";
        txttLastPurchase.Text = "";
        txttLastOrder.Text = "";
        txttLastSold.Text = "";
        txttExpiry.Text = "";
        Session["eid"] = "";
    }

    public void GetFormData()
    {
        DataTable dt = objClass.viewData(objClass, "show", Session["eid"].ToString());
        if (dt.Rows.Count > 0)
        {
            txtitemName.Text = dt.Rows[0][1].ToString();
            ddlItemCategory.SelectedValue = dt.Rows[0][2].ToString();
            EventArgs e = new EventArgs();
            ddlItemCategory_TextChanged(this, e);
            ddlItemSubCategory.SelectedValue = dt.Rows[0][3].ToString();
            ddlItemType.SelectedValue = dt.Rows[0][4].ToString();
            txtItemMark.Text = dt.Rows[0][5].ToString();
            txtWarrentyRemarks.Text = dt.Rows[0][6].ToString();
            if (dt.Rows[0][7].ToString() == "1")
            {
                chkWarrentyRemarks.Checked = true;
            }
            else
            {
                chkWarrentyRemarks.Checked = false;
            }
            txtPromotionRemarks.Text = dt.Rows[0][8].ToString();

            if (dt.Rows[0][9].ToString() == "1")
            {
                chkPromotionRemarks.Checked = true;
            }
            else
            {
                chkPromotionRemarks.Checked = false;
            }
            txtItemRemarks.Text = dt.Rows[0][10].ToString();
            if (dt.Rows[0][11].ToString() == "1")
            {
                chkItemRemarks.Checked = true;
            }
            else
            {
                chkItemRemarks.Checked = false;
            }
            txtSpecificationRemarks.Text = dt.Rows[0][12].ToString();
            if (dt.Rows[0][13].ToString() == "1")
            {
                chkSpecificationRemarks.Checked = true;
            }
            else
            {
                chkSpecificationRemarks.Checked = false;
            }
            txtSalePrice.Text = dt.Rows[0][14].ToString();
            txtAvgSalePrice.Text = dt.Rows[0][15].ToString();
            txtLastPurchasePrice.Text = dt.Rows[0][16].ToString();
            txtAvgPurchasePrice.Text = dt.Rows[0][17].ToString();
            txttLastPurchase.Text = validation.TextToDate(dt.Rows[0][18].ToString());
            txttLastOrder.Text = validation.TextToDate(dt.Rows[0][19].ToString());
            txttLastSold.Text = validation.TextToDate(dt.Rows[0][20].ToString());
            txttExpiry.Text = validation.TextToDate(dt.Rows[0][21].ToString());
            
        }
    }

    public void btnVisible()
    {
        btnAdd.Visible = true;
        btnUpdate.Visible = false;
        btnDelete.Visible = false;
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
    protected void ddlItemCategory_TextChanged(object sender, EventArgs e)
    {
        try
        {
            objItemSubCat.ddlOperation(objItemSubCat, "Showddl", ddlItemCategory.SelectedValue, ddlItemSubCategory);

            ItemTabe1.Attributes.Remove("class");
            ItemTab_1.Attributes.Remove("class");
            ItemTabe1.Attributes.Add("class", "nav-link active");
            ItemTab_1.Attributes.Add("class", "tab-pane fade active show");

            //ItemTabe2.Attributes.Remove("class");
            //ItemTab_2.Attributes.Remove("class");
            //ItemTabe2.Attributes.Add("class", "nav-link");
            //ItemTab_2.Attributes.Add("class", "tab-pane fade show");



            ItemTabe3.Attributes.Remove("class");
            ItemTab_3.Attributes.Remove("class");
            ItemTabe3.Attributes.Add("class", "nav-link");
            ItemTab_3.Attributes.Add("class", "tab-pane fade  show");

            ItemTabe4.Attributes.Remove("class");
            ItemTab_4.Attributes.Remove("class");
            ItemTabe4.Attributes.Add("class", "nav-link ");
            ItemTab_4.Attributes.Add("class", "tab-pane fade  show");
        }
        catch
        {

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
        objClass.nItemDetailsID = Session["eid"].ToString();
        var vres = objClass.User_Operation(objClass, "DeActive");
        valobj.showMsg(vres, lblmsg);
        displayGrid();
        btnVisible();
    }

    public void GetItemID()
    {
        Session["eid"] = "";



        DataTable dt = objClass.viewData(objClass, "ShowMaxID", "");
        if (dt.Rows.Count > 0)
        {
            Session["eid"] = dt.Rows[0][0].ToString();

        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            lblmsg.Text = "";
            if (Session["titem_details"].ToString() == ViewState["titem_details"].ToString())
            {
                para();
                var abc = objClass.User_Operation(objClass, "add");

                var strArr = abc.Split(',');
                string ItemID = strArr[2].ToString();
                Session["eid"] = ItemID;
                //Add Record into Item Property Table
                objItemProperty.nItemDetailsID = ItemID;

                var abc2 = objItemProperty.User_Operation(objItemProperty, "add");

                //Add Record into Item Account Table
                AccountPara();
                objItemAccount.nItemDetailsID = ItemID;
                var abc3 = objItemAccount.User_Operation(objItemAccount, "add");


                //Add Record into Item Picture Table
                objPicture.nItemDetailsID = ItemID;
                var abc4 = objPicture.User_Operation(objPicture, "add");


                valobj.showMsg(abc3, lblmsg);
                //displayGrid();
                string aa = Server.UrlEncode(System.DateTime.Now.ToString());
                Session["titem_details"] = aa;

                // Tabs Visible True
                //VisibleTab();

                //Visible Buttons
                btnAdd.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;


                ItemTabe1.Attributes.Remove("class");
                ItemTab_1.Attributes.Remove("class");
                ItemTabe1.Attributes.Add("class", "nav-link active");
                ItemTab_1.Attributes.Add("class", "tab-pane fade active show");

                //ItemTabe2.Attributes.Remove("class");
                //ItemTab_2.Attributes.Remove("class");
                //ItemTabe2.Attributes.Add("class", "nav-link");
                //ItemTab_2.Attributes.Add("class", "tab-pane fade show");



                ItemTabe3.Attributes.Remove("class");
                ItemTab_3.Attributes.Remove("class");
                ItemTabe3.Attributes.Add("class", "nav-link");
                ItemTab_3.Attributes.Add("class", "tab-pane fade  show");

                ItemTabe4.Attributes.Remove("class");
                ItemTab_4.Attributes.Remove("class");
                ItemTabe4.Attributes.Add("class", "nav-link ");
                ItemTab_4.Attributes.Add("class", "tab-pane fade  show");

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
            objClass.nItemDetailsID = Session["eid"].ToString();
            var abc = objClass.User_Operation(objClass, "edit");

            AccountPara();
            objItemAccount.nItemDetailsID = Session["eid"].ToString();
            var abcacc = objItemAccount.User_Operation(objItemAccount, "edit");

            //displayGrid();

            PropertyPara();
            objItemProperty.nItemDetailsID = Session["eid"].ToString();
            var xyz = objItemProperty.User_Operation(objItemProperty, "edit");
            valobj.showMsg(abc, lblmsg);
            //ItemTabe1.Attributes.Remove("class");
            //ItemTab_1.Attributes.Remove("class");
            //ItemTabe1.Attributes.Add("class", "nav-link active");
            //ItemTab_1.Attributes.Add("class", "tab-pane fade active show");

            //ItemTabe2.Attributes.Remove("class");
            //ItemTab_2.Attributes.Remove("class");
            //ItemTabe2.Attributes.Add("class", "nav-link");
            //ItemTab_2.Attributes.Add("class", "tab-pane fade show");



            //ItemTabe3.Attributes.Remove("class");
            //ItemTab_3.Attributes.Remove("class");
            //ItemTabe3.Attributes.Add("class", "nav-link");
            //ItemTab_3.Attributes.Add("class", "tab-pane fade  show");

            //ItemTabe4.Attributes.Remove("class");
            //ItemTab_4.Attributes.Remove("class");
            //ItemTabe4.Attributes.Add("class", "nav-link ");
            //ItemTab_4.Attributes.Add("class", "tab-pane fade  show");

            valobj.showMsg(abc, lblmsg);
            //displayGrid();
            string aa = Server.UrlEncode(System.DateTime.Now.ToString());
            Session["titem_details"] = aa;
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
            btnDelete.Visible = true;
            GetFormData();
            GetFormPropertyData();
            GetFormAccountData();
            GetFormPictureData();
            chkTaxItem_CheckedChanged(this, e);
            lblmsg.Text = "";
            //tblmain.Visible = true;
            tblGrd.Visible = false;
           // VisibleTab();
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

    //Properties Fills and Update and View Clicks 

    public void btnPropertyVisible()
    {
        // btnAddProperty.Visible = true;
        //btnUpdateProperty.Visible = false;
        //btnDeleteProperty.Visible = false;
        clrPropertiesField();
    }
    public void clrPropertiesField()
    {
        //ddlItemUnit.SelectedValue = "0";
        //txtbarcode.Text = "";
        //txtMinOrder.Text = "";
        //txtDeliveryQty.Text = "";
        //txtRedeemPoint.Text = "";
        //txtVendor.Text = "";
        //ddlItemSize.SelectedValue = "0";
        //txtColor.Text = "";
        //chkTaxItem.Checked = false;
        //txtCessTax.Text = "";
        //Session["Prop_eid"] = "";
    }
    public void PropertyPara()
    {
        objItemProperty.nItemUnitID = ddlItemUnit.SelectedValue;
        objItemProperty.sBarcode = validation.stringToDBString(txtbarcode.Text.Trim());
        objItemProperty.nMinOrderlevel = txtMinOrder.Text.Trim();
        objItemProperty.nDeliveryQty = txtDeliveryQty.Text.Trim();
        objItemProperty.nRedeemPoint = txtRedeemPoint.Text.Trim();
        objItemProperty.sVendorName = validation.stringToDBString(txtVendor.Text.Trim());
        objItemProperty.nItemSizeID = ddlItemSize.SelectedValue;
        objItemProperty.sColor = validation.stringToDBString(txtColor.Text.Trim());
        if (chkTaxItem.Checked == true)
        {
            objItemProperty.bTax = "1";
        }
        else
        {
            objItemProperty.bTax = "0";
        }
        objItemProperty.nTaxMasterID = ddlGSTTax.SelectedValue;
        objItemProperty.nCessTax = txtCessTax.Text.Trim();
        objItemProperty.nOtherTax = txtOtherTax.Text.Trim();


    }

    public void GetFormPropertyData()
    {
        DataTable dt = objItemProperty.viewData(objItemProperty, "show", Session["eid"].ToString());
        if (dt.Rows.Count > 0)
        {
            ddlItemUnit.SelectedValue = dt.Rows[0][2].ToString();
            txtbarcode.Text = dt.Rows[0][3].ToString();

            txtMinOrder.Text = dt.Rows[0][4].ToString();
            txtDeliveryQty.Text = dt.Rows[0][5].ToString();
            txtRedeemPoint.Text = dt.Rows[0][6].ToString();
            txtVendor.Text = dt.Rows[0][7].ToString();
            ddlItemSize.SelectedValue = dt.Rows[0][8].ToString();
            txtColor.Text = dt.Rows[0][9].ToString();


            if (dt.Rows[0][10].ToString() == "1")
            {
                chkTaxItem.Checked = true;
            }
            else
            {
                chkTaxItem.Checked = false;
            }
            //txtTax.Text = dt.Rows[0][11].ToString();
            ddlGSTTax.SelectedValue = dt.Rows[0][12].ToString();
            txtCessTax.Text = dt.Rows[0][13].ToString();
            txtOtherTax.Text = dt.Rows[0][14].ToString();


        }
    }

    protected void btnAddProperty_Click(object sender, EventArgs e)
    {
        try
        {
            lblmsg.Text = "";
            if (Session["titem_details"].ToString() == ViewState["titem_details"].ToString())
            {
                para();
                var abc = objItemProperty.User_Operation(objItemProperty, "add");
                valobj.showMsg(abc, lblmsg);
                //displayGrid();

                ItemTabe1.Attributes.Remove("class");
                ItemTab_1.Attributes.Remove("class");
                ItemTabe1.Attributes.Add("class", "nav-link ");
                ItemTab_1.Attributes.Add("class", "tab-pane fade  show");

                //ItemTabe2.Attributes.Remove("class");
                //ItemTab_2.Attributes.Remove("class");
                //ItemTabe2.Attributes.Add("class", "nav-link active");
                //ItemTab_2.Attributes.Add("class", "tab-pane fade active show");



                ItemTabe3.Attributes.Remove("class");
                ItemTab_3.Attributes.Remove("class");
                ItemTabe3.Attributes.Add("class", "nav-link");
                ItemTab_3.Attributes.Add("class", "tab-pane fade  show");

                ItemTabe4.Attributes.Remove("class");
                ItemTab_4.Attributes.Remove("class");
                ItemTabe4.Attributes.Add("class", "nav-link ");
                ItemTab_4.Attributes.Add("class", "tab-pane fade  show");


                string aa = Server.UrlEncode(System.DateTime.Now.ToString());
                Session["titem_details"] = aa;
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
    protected void btnUpdateProperty_Click(object sender, EventArgs e)
    {
        try
        {
            PropertyPara();
            objItemProperty.nItemDetailsID = Session["eid"].ToString();
            var abc = objItemProperty.User_Operation(objItemProperty, "edit");
            valobj.showMsg(abc, lblmsg);

            ItemTabe1.Attributes.Remove("class");
            ItemTab_1.Attributes.Remove("class");
            ItemTabe1.Attributes.Add("class", "nav-link ");
            ItemTab_1.Attributes.Add("class", "tab-pane fade  show");

            //ItemTabe2.Attributes.Remove("class");
            //ItemTab_2.Attributes.Remove("class");
            //ItemTabe2.Attributes.Add("class", "nav-link active");
            //ItemTab_2.Attributes.Add("class", "tab-pane fade active show");



            ItemTabe3.Attributes.Remove("class");
            ItemTab_3.Attributes.Remove("class");
            ItemTabe3.Attributes.Add("class", "nav-link");
            ItemTab_3.Attributes.Add("class", "tab-pane fade  show");

            ItemTabe4.Attributes.Remove("class");
            ItemTab_4.Attributes.Remove("class");
            ItemTabe4.Attributes.Add("class", "nav-link ");
            ItemTab_4.Attributes.Add("class", "tab-pane fade  show");

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
    //Properties Fills and Update and View Clicks  End 




    //Item Account Fills and Update and View Clicks 


    public void AccountPara()
    {
        objItemAccount.nAssetsAccountID = ddlAssetsAccount.SelectedValue;
        objItemAccount.nRevenueAccountID = ddlRevenueAccount.SelectedValue;
        objItemAccount.nExpenseAccountID = ddlExpenseAccount.SelectedValue;


    }

    public void GetFormAccountData()
    {
        DataTable dt = objItemAccount.viewData(objItemAccount, "show", Session["eid"].ToString());
        if (dt.Rows.Count > 0)
        {
            ddlAssetsAccount.SelectedValue = dt.Rows[0][2].ToString();
            ddlRevenueAccount.SelectedValue = dt.Rows[0][3].ToString();

            ddlExpenseAccount.SelectedValue = dt.Rows[0][4].ToString();

        }
    }

    protected void btnUpdateAccount_Click(object sender, EventArgs e)
    {
        try
        {
            AccountPara();
            objItemAccount.nItemDetailsID = Session["eid"].ToString();
            var abc = objItemAccount.User_Operation(objItemAccount, "edit");
            valobj.showMsg(abc, lblmsg);

            ItemTabe1.Attributes.Remove("class");
            ItemTab_1.Attributes.Remove("class");
            ItemTabe1.Attributes.Add("class", "nav-link ");
            ItemTab_1.Attributes.Add("class", "tab-pane fade  show");

            //ItemTabe2.Attributes.Remove("class");
            //ItemTab_2.Attributes.Remove("class");
            //ItemTabe2.Attributes.Add("class", "nav-link ");
            //ItemTab_2.Attributes.Add("class", "tab-pane fade  show");

           

            ItemTabe3.Attributes.Remove("class");
            ItemTab_3.Attributes.Remove("class");
            ItemTabe3.Attributes.Add("class", "nav-link active");
            ItemTab_3.Attributes.Add("class", "tab-pane fade active show");

            ItemTabe4.Attributes.Remove("class");
            ItemTab_4.Attributes.Remove("class");
            ItemTabe4.Attributes.Add("class", "nav-link ");
            ItemTab_4.Attributes.Add("class", "tab-pane fade  show");


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


    public void PicturePara()
    {

        string fileName = Path.GetFileName(imgUpload.PostedFile.FileName);

        objPicture.sItemPic = fileName.ToString();



    }

    public void GetFormPictureData()
    {
        DataTable dt = objPicture.viewData(objPicture, "show", Session["eid"].ToString());
        if (dt.Rows.Count > 0)
        {
            string fileName;
            fileName = dt.Rows[0][2].ToString();
            imgitem.ImageUrl = "~/assets/img/item-img/" + fileName;


        }
    }
    protected void btnPicture_Click(object sender, EventArgs e)
    {
        try
        {
            if (imgUpload.HasFile)
            {
                string fileName = Path.GetFileName(imgUpload.PostedFile.FileName);
                imgUpload.PostedFile.SaveAs(Server.MapPath("~/assets/img/item-img/") + fileName);
            }

            PicturePara();
            objPicture.nItemDetailsID = Session["eid"].ToString();
            var abc = objPicture.User_Operation(objPicture, "edit");
            valobj.showMsg(abc, lblmsg);
            //displayGrid();
            GetFormPictureData();

            ItemTabe1.Attributes.Remove("class");
            ItemTab_1.Attributes.Remove("class");
            ItemTabe1.Attributes.Add("class", "nav-link ");
            ItemTab_1.Attributes.Add("class", "tab-pane fade  show");

            //ItemTabe2.Attributes.Remove("class");
            //ItemTab_2.Attributes.Remove("class");
            //ItemTabe2.Attributes.Add("class", "nav-link ");
            //ItemTab_2.Attributes.Add("class", "tab-pane fade  show");

           

            ItemTabe3.Attributes.Remove("class");
            ItemTab_3.Attributes.Remove("class");
            ItemTabe3.Attributes.Add("class", "nav-link");
            ItemTab_3.Attributes.Add("class", "tab-pane fade  show");

            ItemTabe4.Attributes.Remove("class");
            ItemTab_4.Attributes.Remove("class");
            ItemTabe4.Attributes.Add("class", "nav-link active");
            ItemTab_4.Attributes.Add("class", "tab-pane fade active show");

        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, "FAIL", lblmsg);
        }
        finally
        {
        }

    }
    protected void DeleteGroup_Click(object sender, EventArgs e)
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

    public void DeletePropertyRecord()
    {
        objItemProperty.nItemDetailsID = Session["eid"].ToString();
        var vres = objItemProperty.User_Operation(objItemProperty, "DeActive");
        valobj.showMsg(vres, lblmsg);
        displayGrid();
        btnPropertyVisible();
    }

    protected void lnkAdd_Click(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        //tblmain.Visible = true;
        tblGrd.Visible = false;
        clrfield();
        btnVisible();
       //  VisibleTab();

        ItemTabe1.Attributes.Remove("class");
        ItemTab_1.Attributes.Remove("class");
        ItemTabe1.Attributes.Add("class", "nav-link active");
        ItemTab_1.Attributes.Add("class", "tab-pane fade active show");

        //ItemTabe2.Attributes.Remove("class");
        //ItemTab_2.Attributes.Remove("class");
        //ItemTabe2.Attributes.Add("class", "nav-link");
        //ItemTab_2.Attributes.Add("class", "tab-pane fade  show");



        ItemTabe3.Attributes.Remove("class");
        ItemTab_3.Attributes.Remove("class");
        ItemTabe3.Attributes.Add("class", "nav-link ");
        ItemTab_3.Attributes.Add("class", "tab-pane fade show");

        ItemTabe4.Attributes.Remove("class");
        ItemTab_4.Attributes.Remove("class");
        ItemTabe4.Attributes.Add("class", "nav-link");
        ItemTab_4.Attributes.Add("class", "tab-pane fade  show");
    }
    protected void lnkList_Click(object sender, EventArgs e)
    {
        Response.Redirect("titem_details_list.aspx");
    }


    protected void chkTaxItem_CheckedChanged(object sender, EventArgs e)
    {
        if (chkTaxItem.Checked == true)
        {
            ddlGSTTax.Enabled = true;
            txtCessTax.Enabled = true;
            txtOtherTax.Enabled = true;
        }
        else
        {
            ddlGSTTax.Enabled = false;
            txtCessTax.Enabled = false;
            txtOtherTax.Enabled = false;
        }

        //commented on 16112021
        //ItemTabe1.Attributes.Remove("class");
        //ItemTab_1.Attributes.Remove("class");
        //ItemTabe1.Attributes.Add("class", "nav-link ");
        //ItemTab_1.Attributes.Add("class", "tab-pane fade  show");

        
        //ItemTabe3.Attributes.Remove("class");
        //ItemTab_3.Attributes.Remove("class");
        //ItemTabe3.Attributes.Add("class", "nav-link ");
        //ItemTab_3.Attributes.Add("class", "tab-pane fade show");

        //ItemTabe4.Attributes.Remove("class");
        //ItemTab_4.Attributes.Remove("class");
        //ItemTabe4.Attributes.Add("class", "nav-link");
        //ItemTab_4.Attributes.Add("class", "tab-pane fade  show");
    }
}
