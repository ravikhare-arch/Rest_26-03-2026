using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Transcation_chartof_account : System.Web.UI.Page
{
    tchartof_account_Class objClass = new tchartof_account_Class();
    tchartof_acc_io_Class objClassM = new tchartof_acc_io_Class();
    mairline_Class objAirline = new mairline_Class();
    maccount_category_Class objAccCat = new maccount_category_Class();
    mmain_account_Class objMainAcc = new mmain_account_Class();
    maccount_sub_Class objAccountType = new maccount_sub_Class();
    msales_person_Class objSalesPer = new msales_person_Class();
    mcity_Class objCity = new mcity_Class();
    mCountry_Class objCountry = new mCountry_Class();
    mstate_Class objState = new mstate_Class();
    mairgst_Class objAirGst = new mairgst_Class();

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
                //  ClientCode_Generate();
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
    public void ClientCode_Generate()
    {

        DataTable dt = objAirline.viewData(objAirline, "MaxCode", "");
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
        objClassM.sCode = validation.stringToDBString(txtCode.Text.Trim());
        objClassM.nAccountTypeID = "12";
        objClassM.sFirstName = validation.stringToDBString(txtAirlineName.Text.Trim());
        //  objClassM.sMidName = validation.stringToDBString(txtMidName.Text.Trim());
        // objClassM.sLastName = validation.stringToDBString(txtLastName.Text.Trim());
        //  objClassM.sFamilyName = validation.stringToDBString(txtFamilyName.Text.Trim());
        objClassM.sAddress = validation.stringToDBString(txtAddress.Text.Trim());
        objClassM.sPhoneNo1 = validation.stringToDBString(txtTelephone.Text.Trim());
        //   objClassM.sPhoneNo2 = validation.stringToDBString(txtPhoneNo2.Text.Trim());
        objClassM.sMobileNo = validation.stringToDBString(txtContactNo.Text.Trim());
        //   objClassM.sFaxNo = validation.stringToDBString(txtFaxNo.Text.Trim());
        objClassM.sEmailID = validation.stringToDBString(txtEmailID.Text.Trim());
        objClassM.sWebsite = validation.stringToDBString(txtWebsite.Text.Trim());
        // objClassM.nSalesPersonID = ddlSalesPersonID.SelectedValue;
        objClassM.nCountryID = ddlCountryID.SelectedValue;
        objClassM.nCityID = ddlCityID.SelectedValue;
        //   objClassM.nAccountCategoryID = ddlAccountCategoryID.SelectedValue;
        objClassM.nCreditLimit = txtCreditLimit.Text.Trim();
        //  objClassM.sRemarks = validation.stringToDBString(txtRemarks.Text.Trim());
        //   objClassM.bNotChange = validation.stringToDBString(ddlChangeAllow.SelectedValue);
        objClassM.sGSTNo = validation.stringToDBString(txtGstNo.Text.Trim());
    }

    public void para()
    {
        objAirline.sCode = validation.stringToDBString(txtCode.Text.Trim());
        objAirline.dtJoiningDate = validation.dateToText(txtdtJoiningDate.Text.Trim());
        objAirline.sAirlineName = validation.stringToDBString(txtAirlineName.Text.Trim());
        objAirline.sIATANo = validation.stringToDBString(txtIataNo.Text.Trim());
        objAirline.sLicenseNo = validation.stringToDBString(txtLicenseNo.Text.Trim());
        objAirline.sGSTNo = validation.stringToDBString(txtGstNo.Text.Trim());
        objAirline.sPanCardNo = validation.stringToDBString(txtPanNo.Text.Trim());
        //  objAirline.nLocationID = ddlLocation.SelectedValue;
        objAirline.nOffTele = txtTelephone.Text.Trim();
        objAirline.sAuthorizedPerson = validation.stringToDBString(txtAuthorizedPerson.Text.Trim());
        objAirline.sContactNo = validation.stringToDBString(txtContactNo.Text.Trim());
        objAirline.sAddress = validation.stringToDBString(txtAddress.Text.Trim());
        objAirline.nCountryID = ddlCountryID.SelectedValue;
        objAirline.nCityID = ddlCityID.SelectedValue;
        objAirline.nPincode = txtPincode.Text.Trim();
        objAirline.sEmail = validation.stringToDBString(txtEmailID.Text.Trim());
        objAirline.sWebsite = validation.stringToDBString(txtWebsite.Text.Trim());
        objAirline.nCreditLimit = txtCreditLimit.Text.Trim();
        objAirline.nCAccountID = Session["CAID"].ToString();
        objAirline.nStateID = ddlState.SelectedValue;
        objAirline.sDesignator = validation.stringToDBString(txtDesignator.Text.Trim());
        objAirline.sAllience = validation.stringToDBString(txtAlliance.Text.Trim());
    }
    public void paraGst()
    {

        //Clint GST
        objAirGst.nAirCGST = txtCGST.Text.Trim();
        objAirGst.nAirSGST = txtSGST.Text.Trim();
        objAirGst.nAirIGST = txtIGST.Text.Trim();



    }

    public void clrfield()
    {
        // txtCode.Text = "";
        txtdtJoiningDate.Text = "";
        txtAirlineName.Text = "";
        txtIataNo.Text = "";
        txtLicenseNo.Text = "";
        txtGstNo.Text = "";
        txtPanNo.Text = "";
        //   ddlLocation.SelectedValue = "0";
        txtTelephone.Text = "";
        txtAuthorizedPerson.Text = "";
        txtContactNo.Text = "";
        txtAddress.Text = "";
        ddlCountryID.SelectedValue = "0";
        ddlCityID.SelectedValue = "0";
        txtPincode.Text = "";
        txtEmailID.Text = "";
        txtWebsite.Text = "";
        txtCreditLimit.Text = "";
        ddlState.SelectedValue = "0";
        txtDesignator.Text = "";
        txtAlliance.Text = "";
        //GST
        txtCGST.Text = "";
        txtSGST.Text = "";
        txtIGST.Text = "";

        Session["eid"] = "";
        Session["CAID"] = "";
    }

    public void GetFormData()
    {
        DataTable dt = objAirline.viewData(objAirline, "show", Session["eid"].ToString());
        if (dt.Rows.Count > 0)
        {
            txtCode.Text = dt.Rows[0][1].ToString();
            txtdtJoiningDate.Text = validation.TextToDate(dt.Rows[0][2].ToString());
            txtAirlineName.Text = dt.Rows[0][3].ToString();
            txtIataNo.Text = dt.Rows[0][4].ToString();
            txtLicenseNo.Text = dt.Rows[0][5].ToString();
            txtGstNo.Text = dt.Rows[0][6].ToString();
            txtPanNo.Text = dt.Rows[0][7].ToString();
            //  ddlLocation.SelectedValue = dt.Rows[0][8].ToString();
            txtTelephone.Text = dt.Rows[0][9].ToString();
            txtAuthorizedPerson.Text = dt.Rows[0][10].ToString();
            txtContactNo.Text = dt.Rows[0][11].ToString();
            txtAddress.Text = dt.Rows[0][12].ToString();
            ddlCountryID.SelectedValue = dt.Rows[0][13].ToString();
            ddlCityID.SelectedValue = dt.Rows[0][14].ToString();
            txtPincode.Text = dt.Rows[0][15].ToString();
            txtEmailID.Text = dt.Rows[0][16].ToString();
            txtWebsite.Text = dt.Rows[0][17].ToString();
            txtCreditLimit.Text = dt.Rows[0][18].ToString();
            ddlState.SelectedValue = dt.Rows[0][20].ToString();
            txtDesignator.Text = dt.Rows[0][21].ToString();
            txtAlliance.Text = dt.Rows[0][22].ToString();
        }
    }
    public void GetGstData()
    {
        DataTable dtSupGst = objAirGst.viewData(objAirGst, "show", Session["eid"].ToString());
        if (dtSupGst.Rows.Count > 0)
        {
            txtIGST.Text = dtSupGst.Rows[0][2].ToString();
            txtCGST.Text = dtSupGst.Rows[0][3].ToString();
            txtSGST.Text = dtSupGst.Rows[0][4].ToString();

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
            objClass.sCode = "0";
            objClass.sFirstName = "";
            objClass.sPhoneNo2 = "0";

            objAirline.FillGrid(objAirline, GridView1, "ShowGrid", "");
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
        ClientCode_Generate();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            lblmsg.Text = "";
            if (Session["tchartof_account"].ToString() == ViewState["tchartof_account"].ToString())
            {
                paraAccount();
                var abc = objClassM.User_Operation(objClassM, "add");
                var strArr = abc.Split(',');
                if (strArr[0] == "1")
                {
                    string CAID = strArr[2].ToString();
                    Session["CAID"] = CAID;

                    para();
                    var xyz = objAirline.User_Operation(objAirline, "add");

                    paraGst();

                    objAirGst.nAirlineID = strArr[2].ToString();
                    var abc1 = objAirGst.User_Operation(objAirGst, "add");

                }
                //   ClientCode_Generate();
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
            objClassM.nChartOfAccountID = Session["CAID"].ToString();
            var abc = objClassM.User_Operation(objClassM, "edit");

            para();
            objAirline.nAirlineID = Session["eid"].ToString();
            var abc1 = objAirline.User_Operation(objAirline, "edit");

            //Gst
            paraGst();

            objAirGst.nAirlineID = Session["CAID"].ToString();


            DataTable dtsup = objAirGst.viewData(objAirGst, "show", Session["CAID"].ToString());
            if (dtsup.Rows.Count > 0)
            {
                var abc2 = objAirGst.User_Operation(objAirGst, "edit");
            }
            else
            {
                var abc2 = objAirGst.User_Operation(objAirGst, "add");
            }

            // ClientCode_Generate();
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
            // btnUpdate.Visible = true;
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
            GetGstData();
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
        ClientCode_Generate();
    }
    protected void lnkList_Click(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        tblmain.Visible = false;
        tblGrd.Visible = true;
        objAirline.ddlOperation(objAirline, "Showddl", "", ddlSSupplier);
        displayGrid();

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        objClass.sCode = ddlSSupplier.SelectedValue;
        objClass.sFirstName = "";
        objClass.sPhoneNo2 = "0";

        objAirline.FillGrid(objAirline, GridView1, "ShowGrid", ddlSSupplier.SelectedValue);
    }

}
