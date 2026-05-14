using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Master_guest : System.Web.UI.Page
{
    mguest_Class objClass = new mguest_Class();
    validation valobj = new validation();
    mcompany_Class objCompany = new mcompany_Class();
    mCountry_Class objCountry = new mCountry_Class();
    mcity_Class objCity = new mcity_Class();
    string cond;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                //Fillddl.FillPageddl(ddlPageSize);
                string aa = Server.UrlEncode(System.DateTime.Now.ToString());
                Session["mguest"] = aa;
                tblmain.Visible = true;
                tblGrd.Visible = false;
                displayGrid();
                objCompany.ddlOperation(objCompany, "Show", "", ddlCompany);
                objCountry.ddlOperation(objCountry, "Show", "", ddlCountry);
                btnVisible();
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
        ViewState["mguest"] = Session["mguest"];
    }

    public void para()
    {
        objClass.nCompanyID = ddlCompany.SelectedValue;
        objClass.sSerialNo = validation.stringToDBString(txtSerialNo.Text.Trim());
        objClass.sGuestName = validation.stringToDBString(txtGuestName.Text.Trim());
        objClass.sAddress = validation.stringToDBString(txtAddress.Text.Trim());
        objClass.nCountryID = ddlCountry.SelectedValue;
        objClass.nCityID = ddlCity.SelectedValue;
        objClass.sTelephone = validation.stringToDBString(txtTelephone.Text.Trim());
        objClass.sFax = validation.stringToDBString(txtFax.Text.Trim());
        objClass.sMobile = txtMobile.Text.Trim();
        objClass.sEmail = validation.stringToDBString(txtEmail.Text.Trim());
        objClass.sRemarks = validation.stringToDBString(txtRemarks.Text.Trim());

    }

    public void clrfield()
    {
        ddlCompany.SelectedValue = "0";
        txtSerialNo.Text = "";
        txtGuestName.Text = "";
        txtAddress.Text = "";
        ddlCountry.SelectedValue = "0";
        ddlCity.SelectedValue = "0";
        txtTelephone.Text = "";
        txtFax.Text = "";
        txtMobile.Text = "";
        txtEmail.Text = "";
        txtEmail.Text = "";
        txtRemarks.Text = "";
        Session["eid"] = "";
    }

    public void GetFormData()
    {
        DataTable dt = objClass.viewData(objClass, "show", Session["eid"].ToString());
        if (dt.Rows.Count > 0)
        {
            ddlCompany.SelectedValue = dt.Rows[0][1].ToString();
            txtSerialNo.Text = dt.Rows[0][2].ToString();
            txtGuestName.Text = dt.Rows[0][3].ToString();
            txtAddress.Text = dt.Rows[0][4].ToString();
            ddlCountry.SelectedValue = dt.Rows[0][5].ToString();
            EventArgs e=new EventArgs();
            ddlCountry_TextChanged(this, e);
            ddlCity.SelectedValue = dt.Rows[0][6].ToString();
            txtTelephone.Text = dt.Rows[0][7].ToString();
            txtFax.Text = dt.Rows[0][8].ToString();
            txtMobile.Text = dt.Rows[0][9].ToString();
            txtEmail.Text = dt.Rows[0][10].ToString();
            txtRemarks.Text = dt.Rows[0][11].ToString();
            
        }
    }
    protected void ddlCountry_TextChanged(object sender, EventArgs e)
    {

        try
        {
            objCity.ddlOperation(objCity, "Showddl", ddlCountry.SelectedValue, ddlCity);
        }
        catch
        {

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
        objClass.nGuestID = Session["eid"].ToString();
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
            if (Session["mguest"].ToString() == ViewState["mguest"].ToString())
            {
                para();
                var abc = objClass.User_Operation(objClass, "add");
                valobj.showMsg(abc, lblmsg);
                //displayGrid();
                string aa = Server.UrlEncode(System.DateTime.Now.ToString());
                Session["mguest"] = aa;
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
            objClass.nGuestID = Session["eid"].ToString();
            var abc = objClass.User_Operation(objClass, "edit");
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
            btnUpdate.Visible = true;
            btnDelete.Visible = true;
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
    }
    protected void lnkList_Click(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        tblmain.Visible = false;
        tblGrd.Visible = true;
        displayGrid();
    }
}
