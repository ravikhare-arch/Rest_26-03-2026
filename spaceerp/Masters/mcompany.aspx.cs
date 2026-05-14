using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Transcation_chartof_account : System.Web.UI.Page
{
    tchartof_acc_io_Class objClass = new tchartof_acc_io_Class();
    mcompany_Class objCompany = new mcompany_Class();
    maccount_category_Class objAccCat = new maccount_category_Class();
    mmain_account_Class objMainAcc = new mmain_account_Class();
    maccount_sub_Class objAccountType = new maccount_sub_Class();
    msales_person_Class objSalesPer = new msales_person_Class();
    mcity_Class objCity = new mcity_Class();
    mCountry_Class objCountry = new mCountry_Class();
    mstate_Class objState = new mstate_Class();
    mclientgst_Class objclntGst = new mclientgst_Class();
    mcurrency_Class objCurrency = new mcurrency_Class();
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
                Session["tchartof_account"] = aa;
                tblmain.Visible = true;
                tblGrd.Visible = false;
                txtdtJoiningDate.Text = validation.fillDate();
                displayGrid();
                btnVisible();
                //  objAccCat.ddlOperation(objAccCat, "Show", "", ddlAccountCategoryID);
                //  objAccountType.ddlOperation(objAccountType, "ShowDdl", "", ddlAccountTypeID);
                objState.ddlOperation(objState, "Showddl", "", ddlState);
                objCountry.ddlOperation(objCountry, "Show", "", ddlCountryID);
                objCity.ddlOperation(objCity, "Showddl", "", ddlCityID);
                objCurrency.ddlOperation(objCurrency, "Show", "", ddlCurrency);
                CompanyCode_Generate();
                if (GridView1.Rows.Count < 25)
                {
                    ddlPageSize.Visible = false;
                    // lblpgs.Visible = false;
                }
                else
                {
                    ddlPageSize.Visible = true;
                    //  lblpgs.Visible = true;
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
    public void CompanyCode_Generate()
    {

        DataTable dt = objCompany.viewData(objCompany, "MaxCode", "");
        if (dt.Rows.Count > 0)
        {
            txtCode.Text = dt.Rows[0][0].ToString();
        }


    }

    public void Page_PreRender(object sender, EventArgs e)
    {
        ViewState["tchartof_account"] = Session["tchartof_account"];
    }

    public void paraAccount()
    {
        objClass.sCode = validation.stringToDBString(txtCode.Text.Trim());
        objClass.nAccountTypeID = "13";
        objClass.sFirstName = validation.stringToDBString(txtAgencyName.Text.Trim());
        //  objClass.sMidName = validation.stringToDBString(txtMidName.Text.Trim());
        // objClass.sLastName = validation.stringToDBString(txtLastName.Text.Trim());
        //  objClass.sFamilyName = validation.stringToDBString(txtFamilyName.Text.Trim());
        objClass.sAddress = validation.stringToDBString(txtAddress.Text.Trim());
        objClass.sPhoneNo1 = validation.stringToDBString(txtTelephone.Text.Trim());
        //   objClass.sPhoneNo2 = validation.stringToDBString(txtPhoneNo2.Text.Trim());
        objClass.sMobileNo = validation.stringToDBString(txtContactNo.Text.Trim());
        //   objClass.sFaxNo = validation.stringToDBString(txtFaxNo.Text.Trim());
        objClass.sEmailID = validation.stringToDBString(txtEmailID.Text.Trim());
        objClass.sWebsite = validation.stringToDBString(txtWebsite.Text.Trim());
        // objClass.nSalesPersonID = ddlSalesPersonID.SelectedValue;
        objClass.nCountryID = ddlCountryID.SelectedValue;
        objClass.nCityID = ddlCityID.SelectedValue;
        //   objClass.nAccountCategoryID = ddlAccountCategoryID.SelectedValue;
        // objClass.nCreditLimit = txtCreditLimit.Text.Trim();
        //  objClass.sRemarks = validation.stringToDBString(txtRemarks.Text.Trim());
        //   objClass.bNotChange = validation.stringToDBString(ddlChangeAllow.SelectedValue);
        objClass.sGSTNo = validation.stringToDBString(txtGstNo.Text.Trim());
    }

    public void para()
    {
        objCompany.sCode = validation.stringToDBString(txtCode.Text.Trim());
        objCompany.dtJoiningDate = validation.dateToText(txtdtJoiningDate.Text.Trim());
        objCompany.sCompanyName = validation.stringToDBString(txtAgencyName.Text.Trim());
        objCompany.sIATANo = validation.stringToDBString(txtIataNo.Text.Trim());
        objCompany.sLicenseNo = validation.stringToDBString(txtLicenseNo.Text.Trim());
        objCompany.sGSTNo = validation.stringToDBString(txtGstNo.Text.Trim());
        objCompany.sPanCardNo = validation.stringToDBString(txtPanNo.Text.Trim());
        // objCompany.nLocationID = ddlLocation.SelectedValue;
        objCompany.nOffTele = txtTelephone.Text.Trim();
        objCompany.sAuthorizedPerson = validation.stringToDBString(txtAuthorizedPerson.Text.Trim());
        objCompany.sContactNo = validation.stringToDBString(txtContactNo.Text.Trim());
        objCompany.sAddress = validation.stringToDBString(txtAddress.Text.Trim());
        objCompany.nCountryID = ddlCountryID.SelectedValue;
        objCompany.nCityID = ddlCityID.SelectedValue;
        objCompany.nPincode = txtPincode.Text.Trim();
        objCompany.sEmail = validation.stringToDBString(txtEmailID.Text.Trim());
        objCompany.sWebsite = validation.stringToDBString(txtWebsite.Text.Trim());
        // objCompany.nCreditLimit = txtCreditLimit.Text.Trim();
        objCompany.nCAccountID = Session["CAID"].ToString();
        objCompany.nStateID = ddlState.SelectedValue;
        objCompany.nCurrencyID = ddlCurrency.SelectedValue;

    }


    public void clrfield()
    {
        // txtCode.Text = "";
        txtdtJoiningDate.Text = "";
        txtAgencyName.Text = "";
        txtIataNo.Text = "";
        txtLicenseNo.Text = "";
        txtGstNo.Text = "";
        txtPanNo.Text = "";
        //  ddlLocation.SelectedValue = "0";
        txtTelephone.Text = "";
        txtAuthorizedPerson.Text = "";
        txtContactNo.Text = "";
        txtAddress.Text = "";
        ddlCountryID.SelectedValue = "0";
        ddlCityID.SelectedValue = "0";
        txtPincode.Text = "";
        txtEmailID.Text = "";
        txtWebsite.Text = "";
        //   txtCreditLimit.Text = "";
        ddlState.SelectedValue = "0";

        //GST


        Session["eid"] = "";
        Session["CAID"] = "";
    }

    public void GetFormData()
    {
        DataTable dt = objCompany.viewData(objCompany, "show", Session["eid"].ToString());
        if (dt.Rows.Count > 0)
        {
            txtCode.Text = dt.Rows[0][1].ToString();
            txtdtJoiningDate.Text = validation.TextToDate(dt.Rows[0][2].ToString());
            txtAgencyName.Text = dt.Rows[0][3].ToString();
            txtIataNo.Text = dt.Rows[0][4].ToString();
            txtLicenseNo.Text = dt.Rows[0][5].ToString();
            txtGstNo.Text = dt.Rows[0][6].ToString();
            txtPanNo.Text = dt.Rows[0][7].ToString();
            // ddlLocation.SelectedValue = dt.Rows[0][8].ToString();
            txtTelephone.Text = dt.Rows[0][8].ToString();
            txtAuthorizedPerson.Text = dt.Rows[0][9].ToString();
            txtContactNo.Text = dt.Rows[0][10].ToString();
            txtAddress.Text = dt.Rows[0][11].ToString();
            ddlCountryID.SelectedValue = dt.Rows[0][12].ToString();
            ddlCityID.SelectedValue = dt.Rows[0][13].ToString();
            txtPincode.Text = dt.Rows[0][14].ToString();
            txtEmailID.Text = dt.Rows[0][15].ToString();
            txtWebsite.Text = dt.Rows[0][16].ToString();
            // txtCreditLimit.Text = dt.Rows[0][18].ToString();
            ddlState.SelectedValue = dt.Rows[0][18].ToString();
            logoImg.ImageUrl = "../Uploads/" + dt.Rows[0][19].ToString();
            lblimagename.Text = dt.Rows[0][19].ToString();
            ddlCurrency.SelectedValue = dt.Rows[0][20].ToString();
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
            //objClass.sCode = "0";
            //objClass.sFirstName = "";
            //objClass.sPhoneNo2 = "0";

            objCompany.FillGrid(objCompany, GridView1, "ShowGrid", "");
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
        objClass.nChartOfAccountID = Session["eid"].ToString();
        var vres = objClass.User_Operation(objClass, "DeActive");
        valobj.showMsg(vres, lblmsg);
        displayGrid();
        btnVisible();
        CompanyCode_Generate();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            lblmsg.Text = "";
            if (Session["tchartof_account"].ToString() == ViewState["tchartof_account"].ToString())
            {
                paraAccount();
                var abc = objClass.User_Operation(objClass, "add");
                var strArr = abc.Split(',');
                if (strArr[0] == "1")
                {
                    string CAID = strArr[2].ToString();
                    Session["CAID"] = CAID;

                    para();
                    objCompany.sLogoImage = valobj.AddImage(FUCompanyImage);
                    var xyz = objCompany.User_Operation(objCompany, "add");




                }
                CompanyCode_Generate();
                valobj.showMsg(abc, lblmsg);
                //displayGrid();
                string aa = Server.UrlEncode(System.DateTime.Now.ToString());
                Session["tchartof_account"] = aa;
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
            paraAccount();
            objClass.nChartOfAccountID = Session["CAID"].ToString();
            var abc = objClass.User_Operation(objClass, "edit");

            para();
            objCompany.sLogoImage = valobj.UpdateImage(FUCompanyImage, lblimagename);
            objCompany.nCompanyID = Session["eid"].ToString();
            var abc1 = objCompany.User_Operation(objCompany, "edit");

            //Gst




            CompanyCode_Generate();
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

            Label CAID = (Label)GridView1.Rows[row].Cells[0].FindControl("lblCAID");
            Session["CAID"] = CAID.Text;

            btnAdd.Visible = false;
            //  btnUpdate.Visible = true;
            if (Session["typ"].ToString() != "1")
            {
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
            }
            else
            {
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
            }
            GetFormData();

            lblmsg.Text = "";
            tblmain.Visible = true;
            tblGrd.Visible = false;
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

    protected void lnkAdd_Click(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        tblmain.Visible = true;
        tblGrd.Visible = false;
        clrfield();
        btnVisible();
        CompanyCode_Generate();
    }
    protected void lnkList_Click(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        tblmain.Visible = false;
        tblGrd.Visible = true;
        //objCompany.ddlOperation(objCompany, "Showddl", "", ddlSClient);
        displayGrid();

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        objClass.sCode = ddlSClient.SelectedValue;
        objClass.sFirstName = "";
        objClass.sPhoneNo2 = "0";

        objCompany.FillGrid(objCompany, GridView1, "ShowGrid", ddlSClient.SelectedValue);
    }

}
