using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Master_ticketinc : System.Web.UI.Page
{
    mticketinc_Class objClass = new mticketinc_Class();
    mflight_carrier_Class objCarrier = new mflight_carrier_Class();
    mmain_account_Class objAccounts = new mmain_account_Class();
    validation valobj = new validation();
    string cond;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                string aa = Server.UrlEncode(System.DateTime.Now.ToString());
                Session["mticketinc"] = aa;
                tblmain.Visible = true;
                tblGrd.Visible = false;
                displayGrid();
                btnVisible();
                objAccounts.ddlOperation(objAccounts, "ShowddlAccount", "", ddlSupplierID);
                objCarrier.ddlOperation(objCarrier, "Show", "", ddlAirlineID);
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
        ViewState["mticketinc"] = Session["mticketinc"];
    }

    public void para()
    {
        objClass.nReceivedFromID = ddlReceivedFromID.SelectedValue;
        objClass.nAirlineID = ddlAirlineID.SelectedValue;
        objClass.nSupplierID = ddlSupplierID.SelectedValue;
        objClass.nTicketTypeID = ddlTicketTypeID.SelectedValue;
        objClass.dtStartDate = validation.dateToText(txttStartDate.Text.Trim());
        objClass.dtEndDate = validation.dateToText(txttEndDate.Text.Trim());
        objClass.nCalMethodID = ddlCalMethodID.SelectedValue;
        objClass.nClassID = ddlClassID.SelectedValue;
        objClass.nGrossNetID = ddlGrossNetID.SelectedValue;
        objClass.nAutoManualID = ddlAutoManualID.SelectedValue;
        objClass.nIncValue = txtIncValue.Text.Trim();
        objClass.sSector = validation.stringToDBString(txtSector.Text.Trim());
        objClass.nFareBasic = txtFareBasic.Text.Trim();
        objClass.sDealCode = validation.stringToDBString(txtDealCode.Text.Trim());
        objClass.sClassName = validation.stringToDBString(txtClassName.Text.Trim());
        objClass.bStatus = "1";
    }

    public void clrfield()
    {
        ddlReceivedFromID.SelectedValue = "0";
        ddlAirlineID.SelectedValue = "0";
        ddlSupplierID.SelectedValue = "0";
        ddlTicketTypeID.SelectedValue = "0";
        txttStartDate.Text = "";
        txttEndDate.Text = "";
        ddlCalMethodID.SelectedValue = "1";
        ddlClassID.SelectedValue = "0";
        ddlGrossNetID.SelectedValue = "1";
        ddlAutoManualID.SelectedValue = "1";
        txtIncValue.Text = "";
        txtSector.Text = "";
        txtFareBasic.Text = "";
        txtDealCode.Text = "";
        txtClassName.Text = "";
        Session["eid"] = "";
    }

    public void GetFormData()
    {
        DataTable dt = objClass.viewData(objClass, "show", Session["eid"].ToString());
        if (dt.Rows.Count > 0)
        {
            ddlReceivedFromID.SelectedValue = dt.Rows[0][1].ToString();
            ddlAirlineID.SelectedValue = dt.Rows[0][2].ToString();
            ddlSupplierID.SelectedValue = dt.Rows[0][3].ToString();
            ddlTicketTypeID.SelectedValue = dt.Rows[0][4].ToString();
            txttStartDate.Text = validation.TextToDate(dt.Rows[0][5].ToString());
            txttEndDate.Text = validation.TextToDate(dt.Rows[0][6].ToString());
            ddlCalMethodID.SelectedValue = dt.Rows[0][7].ToString();
            ddlClassID.SelectedValue = dt.Rows[0][8].ToString();
            ddlGrossNetID.SelectedValue = dt.Rows[0][9].ToString();
            ddlAutoManualID.SelectedValue = dt.Rows[0][10].ToString();
            txtIncValue.Text = dt.Rows[0][11].ToString();
            txtSector.Text = dt.Rows[0][12].ToString();
            txtFareBasic.Text = dt.Rows[0][13].ToString();
            txtDealCode.Text = dt.Rows[0][14].ToString();
            txtClassName.Text = dt.Rows[0][15].ToString();
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
        objClass.nticketincId = Session["eid"].ToString();
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
            if (Session["mticketinc"].ToString() == ViewState["mticketinc"].ToString())
            {
                para();
                var abc = objClass.User_Operation(objClass, "add");
                valobj.showMsg(abc, lblmsg);
                //displayGrid();
                string aa = Server.UrlEncode(System.DateTime.Now.ToString());
                Session["mticketinc"] = aa;
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
            objClass.nticketincId = Session["eid"].ToString();
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
    protected void ddlReceivedFromID_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlReceivedFromID.SelectedValue == "2")
        {
            ddlSupplierID.Enabled = true;
        }
        else
        {
            ddlSupplierID.Enabled = false;
        }
    }
}
