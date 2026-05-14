using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class mbranch_Master : System.Web.UI.Page
{
    mbranches_Class objBranch = new mbranches_Class();
    maccount_category_Class objAccCat = new maccount_category_Class();
    mmain_account_Class objMainAcc = new mmain_account_Class();
    maccount_sub_Class objAccountType = new maccount_sub_Class();
    msales_person_Class objSalesPer = new msales_person_Class();
    mcity_Class objCity = new mcity_Class();
    mCountry_Class objCountry = new mCountry_Class();
    mstate_Class objState = new mstate_Class();
    mclientgst_Class objclntGst = new mclientgst_Class();
    mcompany_Class objCompany = new mcompany_Class();
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
                Session["mbranches"] = aa;
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
                objCompany.ddlOperation(objCompany, "Showddl", "", ddlCompany);
                BranchCode_Generate();
                //if (GridView1.Rows.Count < 25)
                //{
                //    ddlPageSize.Visible = false;
                //    // lblpgs.Visible = false;
                //}
                //else
                //{
                //    ddlPageSize.Visible = true;
                //    //  lblpgs.Visible = true;
                //}
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
    public void BranchCode_Generate()
    {

        DataTable dt = objBranch.viewData(objBranch, "MaxCode", "");
            if (dt.Rows.Count > 0)
            {
                txtCode.Text = dt.Rows[0][0].ToString();
            }
        

    }

    public void Page_PreRender(object sender, EventArgs e)
    {
        ViewState["mbranches"] = Session["mbranches"];
    }

   

    public void para()
    {
        objBranch.sBranchCode = validation.stringToDBString(txtCode.Text.Trim());
        objBranch.dtJoiningDate = validation.dateToText(txtdtJoiningDate.Text.Trim());
        objBranch.sBranchName = validation.stringToDBString(txtAgencyName.Text.Trim());
        objBranch.sIATANo = validation.stringToDBString(txtIataNo.Text.Trim());
        objBranch.sLicenseNo = validation.stringToDBString(txtLicenseNo.Text.Trim());
        objBranch.sGSTNo = validation.stringToDBString(txtGstNo.Text.Trim());
        objBranch.sPanCardNo = validation.stringToDBString(txtPanNo.Text.Trim());
       // objBranch.nLocationID = ddlLocation.SelectedValue;
        objBranch.nOffTele = txtTelephone.Text.Trim();
        objBranch.sAuthorizedPerson = validation.stringToDBString(txtAuthorizedPerson.Text.Trim());
        objBranch.sContactNo = validation.stringToDBString(txtContactNo.Text.Trim());
        objBranch.sAddress = validation.stringToDBString(txtAddress.Text.Trim());
        objBranch.nCountryID = ddlCountryID.SelectedValue;
        objBranch.nCityID = ddlCityID.SelectedValue;
        objBranch.nPincode = txtPincode.Text.Trim();
        objBranch.sEmail = validation.stringToDBString(txtEmailID.Text.Trim());
        objBranch.sWebsite = validation.stringToDBString(txtWebsite.Text.Trim());
       
        objBranch.nStateID = ddlState.SelectedValue;
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
     
        ddlState.SelectedValue = "0";

      


        Session["eid"] = "";
        Session["CAID"] = "";
    }

    public void GetFormData()
    {
        DataTable dt = objBranch.viewData(objBranch, "show", Session["eid"].ToString());
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
            ddlState.SelectedValue = dt.Rows[0][18].ToString();

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
            //objBranch.s = "0";
            //objBranch.sFirstName = "";
            //objBranch.sPhoneNo2 = "0";

            objBranch.FillGrid(objBranch, GridView1, "ShowGrid", "");
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
        objBranch.nBranchID = Session["eid"].ToString();
        var vres = objBranch.User_Operation(objBranch, "DeActive");
        valobj.showMsg(vres, lblmsg);
        displayGrid();
        btnVisible();
        BranchCode_Generate();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            lblmsg.Text = "";
            if (Session["mbranches"].ToString() == ViewState["mbranches"].ToString())
            {
               
                    

                    para();
                    var xyz = objBranch.User_Operation(objBranch, "add");

                   
             
                BranchCode_Generate();
                valobj.showMsg(xyz, lblmsg);
                //displayGrid();
                string aa = Server.UrlEncode(System.DateTime.Now.ToString());
                Session["mbranches"] = aa;
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
            objBranch.nBranchID = Session["eid"].ToString();
            var abc = objBranch.User_Operation(objBranch, "edit");

            //Gst
           


            BranchCode_Generate();
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
        BranchCode_Generate();
    }
    protected void lnkList_Click(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        tblmain.Visible = false;
        tblGrd.Visible = true;
      //  objBranch.ddlOperation(objBranch, "Showddl", "", ddlSClient);
        displayGrid();

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //objClass.sCode = ddlSClient.SelectedValue;
        //objClass.sFirstName = "";
        //objClass.sPhoneNo2 = "0";

        objBranch.FillGrid(objBranch, GridView1, "ShowGrid", ddlSClient.SelectedValue);
    }

}
