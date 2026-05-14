using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Master_driver_assign : System.Web.UI.Page
{
    mdriver_assign_Class objClass = new mdriver_assign_Class();
    mdriver_Class objDriver = new mdriver_Class();
    mvehicle_Class objVehicle = new mvehicle_Class();
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
                Session["mdriver_assign"] = aa;
                tblmain.Visible = true;
                tblGrd.Visible = false;
                objDriver.ddlOperation(objDriver,"Show","",ddlDriver);
                objVehicle.ddlOperation(objVehicle, "Show", "", ddlVehicle);
                displayGrid();
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
        ViewState["mdriver_assign"] = Session["mdriver_assign"];
    }

    public void para()
    {
        objClass.nDriverID = ddlDriver.SelectedValue;
        objClass.sTask = validation.stringToDBString(txtTask.Text.Trim());
        objClass.dtVehicleOut = validation.dateToText(dtVehicleOut.Text.Trim());
        objClass.tmVehicleOut = txtOutTime.Text.Trim();
        objClass.nTimeFormatO = ddlTimeFormatOut.SelectedValue;
        objClass.dtVehicleIN = validation.dateToText(dtVehicleIN.Text.Trim());
        objClass.tmVehicleIN = txtTimeIN.Text.Trim();
        objClass.nTimeFormatI = ddlTimeFormatIN.SelectedValue;
        objClass.nVehicleID = ddlVehicle.SelectedValue;

    }

    public void clrfield()
    {

        ddlDriver.SelectedValue = "0";
        ddlDriver.Focus();
        txtTask.Text = "";
        dtVehicleOut.Text = "";
        txtOutTime.Text = "";
        ddlTimeFormatOut.SelectedValue = "1";
        dtVehicleIN.Text = "";
        txtTimeIN.Text = "";
        ddlTimeFormatIN.SelectedValue = "2";
        ddlVehicle.SelectedValue = "0";

    }

    public void GetFormData()
    {
        DataTable dt = objClass.viewData(objClass, "show", Session["eid"].ToString());
        if (dt.Rows.Count > 0)
        {
            ddlDriver.SelectedValue = dt.Rows[0][1].ToString();
            txtTask.Text = (dt.Rows[0][2].ToString());
            dtVehicleOut.Text = validation.TextToDate(dt.Rows[0][3].ToString());
            txtOutTime.Text = dt.Rows[0][4].ToString();

            ddlTimeFormatOut.SelectedValue = dt.Rows[0][5].ToString();
            dtVehicleIN.Text = validation.TextToDate(dt.Rows[0][6].ToString());
            txtTimeIN.Text = dt.Rows[0][7].ToString();
            ddlTimeFormatIN.SelectedValue = dt.Rows[0][8].ToString();
            ddlVehicle.SelectedValue = dt.Rows[0][9].ToString();

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
        objClass.nDriverAssignID = Session["eid"].ToString();
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
            if (Session["mdriver_assign"].ToString() == ViewState["mdriver_assign"].ToString())
            {
                para();
                var abc = objClass.User_Operation(objClass, "add");
                valobj.showMsg(abc, lblmsg);
                //displayGrid();
                //clrfield();
                string aa = Server.UrlEncode(System.DateTime.Now.ToString());
                Session["mdriver_assign"] = aa;
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
            objClass.nDriverAssignID = Session["eid"].ToString();
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
