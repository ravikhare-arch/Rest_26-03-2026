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
    mclient_Class objClient = new mclient_Class();
    maccount_category_Class objAccCat = new maccount_category_Class();
    mmain_account_Class objMainAcc = new mmain_account_Class();
    maccount_sub_Class objAccountType = new maccount_sub_Class();
    msales_person_Class objSalesPer = new msales_person_Class();
    mcity_Class objCity = new mcity_Class();
    mCountry_Class objCountry = new mCountry_Class();
    mstate_Class objState = new mstate_Class();
    mclientgst_Class objclntGst = new mclientgst_Class();
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
                objCountry.ddlOperation(objCountry, "Show", "", ddlCountryID);
                objState.ddlOperation(objState, "Showddl", "", ddlState);
                objCity.ddlOperation(objCity, "Showddl", "", ddlCityID);
                ClientCode_Generate();
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

        DataTable dt = objClient.viewData(objClient, "MaxCode", "");
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
        objClass.nAccountTypeID = "3";
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
        objClass.nCreditLimit = txtCreditLimit.Text.Trim();
        //  objClass.sRemarks = validation.stringToDBString(txtRemarks.Text.Trim());
        //   objClass.bNotChange = validation.stringToDBString(ddlChangeAllow.SelectedValue);
        objClass.sGSTNo = validation.stringToDBString(txtGstNo.Text.Trim());
    }

    public void para()
    {
        objClient.sClientCode = validation.stringToDBString(txtCode.Text.Trim());
        objClient.dtJoiningDate = validation.dateToText(txtdtJoiningDate.Text.Trim());
        objClient.sAgencyName = validation.stringToDBString(txtAgencyName.Text.Trim());
        objClient.sIATANo = validation.stringToDBString(txtIataNo.Text.Trim());
        objClient.sLicenseNo = validation.stringToDBString(txtLicenseNo.Text.Trim());
        objClient.sGSTNo = validation.stringToDBString(txtGstNo.Text.Trim());
        objClient.sPanCardNo = validation.stringToDBString(txtPanNo.Text.Trim());
       // objClient.nLocationID = ddlLocation.SelectedValue;
        objClient.nOffTele = txtTelephone.Text.Trim();
        objClient.sAuthorizedPerson = validation.stringToDBString(txtAuthorizedPerson.Text.Trim());
        objClient.sContactNo = validation.stringToDBString(txtContactNo.Text.Trim());
        objClient.sAddress = validation.stringToDBString(txtAddress.Text.Trim());
        objClient.nCountryID = ddlCountryID.SelectedValue;
        objClient.nCityID = ddlCityID.SelectedValue;
        objClient.nPincode = txtPincode.Text.Trim();
        objClient.sEmail = validation.stringToDBString(txtEmailID.Text.Trim());
        objClient.sWebsite = validation.stringToDBString(txtWebsite.Text.Trim());
        objClient.nCreditLimit = txtCreditLimit.Text.Trim();
        objClient.nCAccountID = Session["CAID"].ToString();
        objClient.nStateID = ddlState.SelectedValue;
    }

    public void paraGst()
    {

        //Clint GST
        objclntGst.nClntCGST = txtCGST.Text.Trim();
        objclntGst.nClntSGST = txtSGST.Text.Trim();
        objclntGst.nClntIGST = txtIGST.Text.Trim();

      

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
        txtCreditLimit.Text = "";
        ddlState.SelectedValue = "0";

        //GST
        txtCGST.Text = "";
        txtSGST.Text = "";
        txtIGST.Text = "";


        Session["eid"] = "";
        Session["CAID"] = "";
    }

    public void GetFormData()
    {
        DataTable dt = objClient.viewData(objClient, "show", Session["eid"].ToString());
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

        }
    }
    public void GetGstData()
    {
        DataTable dtclntGst = objclntGst.viewData(objclntGst, "show", Session["eid"].ToString());
        if (dtclntGst.Rows.Count > 0)
        {
            txtIGST.Text = dtclntGst.Rows[0][2].ToString();
            txtCGST.Text = dtclntGst.Rows[0][3].ToString();
            txtSGST.Text = dtclntGst.Rows[0][4].ToString();

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

            objClient.FillGrid(objClient, GridView1, "ShowGrid", "");
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
                var abc = objClass.User_Operation(objClass, "add");
                var strArr = abc.Split(',');
                if (strArr[0] == "1")
                {
                    string CAID = strArr[2].ToString();
                    Session["CAID"] = CAID;

                    para();
                    var xyz = objClient.User_Operation(objClient, "add");

                    paraGst();

                    objclntGst.nClientID = strArr[2].ToString();
                    var abc1 = objclntGst.User_Operation(objclntGst, "add");
                }
                ClientCode_Generate();
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
            objClient.nClientID = Session["eid"].ToString();
            var abc1 = objClient.User_Operation(objClient, "edit");

            //Gst
            paraGst();

            objclntGst.nClientID = Session["CAID"].ToString();


            DataTable dtclnt = objclntGst.viewData(objclntGst, "show", Session["CAID"].ToString());
            if (dtclnt.Rows.Count > 0)
            {
                var abc2 = objclntGst.User_Operation(objclntGst, "edit");
            }
            else
            {
                var abc2 = objclntGst.User_Operation(objclntGst, "add");
            }

            ClientCode_Generate();
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
        objClient.ddlOperation(objClient, "Showddl", "", ddlSClient);
        displayGrid();

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        objClass.sCode = ddlSClient.SelectedValue;
        objClass.sFirstName = "";
        objClass.sPhoneNo2 = "0";

        objClient.FillGrid(objClient, GridView1, "ShowGrid", ddlSClient.SelectedValue);
    }

}
