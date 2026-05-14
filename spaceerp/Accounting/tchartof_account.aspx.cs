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
    maccount_category_Class objAccCat = new maccount_category_Class();
    mmain_account_Class objMainAcc = new mmain_account_Class();
    maccount_sub_Class objAccountType = new maccount_sub_Class();
    msales_person_Class objSalesPer = new msales_person_Class();
    mcity_Class objCity = new mcity_Class();
    mCountry_Class objCountry = new mCountry_Class();

    validation valobj = new validation();
    string cond;
    private readonly object ddlAccountCategoryID;

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
                displayGrid();
                btnVisible();
                objAccCat.ddlOperation(objAccCat, "Show", "", ddlAccountCategoryID);
                objAccountType.ddlOperation(objAccountType, "ShowDdl", "", ddlAccountTypeID);
                objSalesPer.ddlOperation(objSalesPer, "Show", "", ddlSalesPersonID);
                objCountry.ddlOperation(objCountry, "Show", "", ddlCountryID);
                objCity.ddlOperation(objCity, "Showddl", "", ddlCityID);
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

    public void Page_PreRender(object sender, EventArgs e)
    {
        ViewState["tchartof_account"] = Session["tchartof_account"];
    }

    public void para()
    {
        objClassM.sCode = validation.stringToDBString(txtCode.Text.Trim());
        objClassM.nAccountTypeID = ddlAccountTypeID.SelectedValue;
        objClassM.sFirstName = validation.stringToDBString(txtFirstName.Text.Trim());
        objClassM.sMidName = validation.stringToDBString(txtMidName.Text.Trim());
        objClassM.sLastName = validation.stringToDBString(txtLastName.Text.Trim());
      //  objClassM.sFamilyName = validation.stringToDBString(txtFamilyName.Text.Trim());
        objClassM.sAddress = validation.stringToDBString(txtAddress.Text.Trim());
        objClassM.sPhoneNo1 = validation.stringToDBString(txtPhoneNo1.Text.Trim());
        objClassM.sPhoneNo2 = validation.stringToDBString(txtPhoneNo2.Text.Trim());
        objClassM.sMobileNo = validation.stringToDBString(txtMobileNo.Text.Trim());
        objClassM.sFaxNo = validation.stringToDBString(txtFaxNo.Text.Trim());
        objClassM.sEmailID = validation.stringToDBString(txtEmailID.Text.Trim());
        objClassM.sWebsite = validation.stringToDBString(txtWebsite.Text.Trim());
        objClassM.nSalesPersonID = ddlSalesPersonID.SelectedValue;
        objClassM.nCountryID = ddlCountryID.SelectedValue;
        objClassM.nCityID = ddlCityID.SelectedValue;
     //   objClassM.nAccountCategoryID = ddlAccountCategoryID.SelectedValue;
        objClassM.nCreditLimit = txtCreditLimit.Text.Trim();
        objClassM.sRemarks = validation.stringToDBString(txtRemarks.Text.Trim());
        objClassM.bNotChange = validation.stringToDBString(ddlChangeAllow.SelectedValue);
        objClassM.sGSTNo = validation.stringToDBString(txtGstNo.Text.Trim());
    }

    public void clrfield()
    {
        txtCode.Text = "";
        ddlAccountTypeID.SelectedValue = "0";
        txtFirstName.Text = "";
        txtMidName.Text = "";
        txtLastName.Text = "";
      //  txtFamilyName.Text = "";
        txtAddress.Text = "";
        txtPhoneNo1.Text = "";
        txtPhoneNo2.Text = "";
        txtMobileNo.Text = "";
        txtFaxNo.Text = "";
        txtEmailID.Text = "";
        txtWebsite.Text = "";
        ddlSalesPersonID.SelectedValue = "0";
        ddlCountryID.SelectedValue = "0";
        ddlCityID.SelectedValue = "0";
    //    ddlAccountCategoryID.SelectedValue = "0";
        txtCreditLimit.Text = "";
        txtRemarks.Text = "";
        txtGstNo.Text = "";
        Session["eid"] = "";
    }

    public void GetFormData()
    {
        DataTable dt = objMainAcc.viewData(objMainAcc, "ShowChartOfAcc", Session["eid"].ToString());
        if (dt.Rows.Count > 0)
        {
            txtCode.Text = dt.Rows[0][1].ToString();
            ddlAccountTypeID.SelectedValue = dt.Rows[0][2].ToString();
            txtFirstName.Text = dt.Rows[0][3].ToString();
            txtMidName.Text = dt.Rows[0][4].ToString();
            txtLastName.Text = dt.Rows[0][5].ToString();
          //  txtFamilyName.Text = dt.Rows[0][6].ToString();
            txtAddress.Text = dt.Rows[0][7].ToString();
            txtPhoneNo1.Text = dt.Rows[0][8].ToString();
            txtPhoneNo2.Text = dt.Rows[0][9].ToString();
            txtMobileNo.Text = dt.Rows[0][10].ToString();
            txtFaxNo.Text = dt.Rows[0][11].ToString();
            txtEmailID.Text = dt.Rows[0][12].ToString();
            txtWebsite.Text = dt.Rows[0][13].ToString();
            ddlSalesPersonID.SelectedValue = dt.Rows[0][14].ToString();
            ddlCountryID.SelectedValue = dt.Rows[0][15].ToString();
            ddlCityID.SelectedValue = dt.Rows[0][16].ToString();
         //   ddlAccountCategoryID.SelectedValue = dt.Rows[0][17].ToString();
            txtCreditLimit.Text = dt.Rows[0][18].ToString();
            txtRemarks.Text = dt.Rows[0][19].ToString();
            ddlChangeAllow.SelectedValue = dt.Rows[0][20].ToString();
            txtGstNo.Text = dt.Rows[0][21].ToString();
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
            objClassM.sCode = "0";
            objClassM.sFirstName = "";
            objClassM.sPhoneNo2 = "0";

            objClassM.FillGrid(objClassM, GridView1, "ShowGrid", "");
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
        objClassM.nChartOfAccountID = Session["eid"].ToString();
        var vres = objClassM.User_Operation(objClassM, "DeActive");
        valobj.showMsg(vres, lblmsg);
        displayGrid();
        btnVisible();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            lblmsg.Text = "";
            if (Session["tchartof_account"].ToString() == ViewState["tchartof_account"].ToString())
            {
                para();
                var abc = objClassM.User_Operation(objClassM, "add");
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
            para();
            objClassM.nChartOfAccountID = Session["eid"].ToString();
            var abc = objClassM.User_Operation(objClassM, "edit");
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
            GetFormData();
            if (Session["typ"].ToString() != "1")
            {
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                //if (ddlChangeAllow.SelectedValue == "1")
                //{

                   // btnUpdate.Visible = false;
                   // btnDelete.Visible = false;
                //}
                //else
                //{
                //    btnUpdate.Visible = true;
                //    btnDelete.Visible = true;
                //}
            }
            else
            {
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
            }

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
    }
    protected void lnkList_Click(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        tblmain.Visible = false;
        tblGrd.Visible = true;
        objMainAcc.ddlOperation(objMainAcc, "ShowddlAccount", "", ddlSChartAcc);
        displayGrid();

    }
   
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        objClassM.sCode = ddlSChartAcc.SelectedValue;
        objClassM.sFirstName = "";
        objClassM.sPhoneNo2 = "0";

        objClassM.FillGrid(objClassM, GridView1, "ShowGrid", "");
    }
    
}
