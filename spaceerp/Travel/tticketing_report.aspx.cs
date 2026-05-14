using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Travel_tticketing_report : System.Web.UI.Page
{
    tticketing_Class objClass = new tticketing_Class();
    //tchartof_account_Class objAgent = new tchartof_account_Class  ();
    tvisa_Class objAccount = new tvisa_Class();
    mcompany_Class objCompany = new mcompany_Class();
    mlocation_Class objLocation = new mlocation_Class();
    validation valobj = new validation();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                displayGrid();
                objAccount.ddlOperation(objAccount, "ddlCustomer", "", ddlAgentID);
                objLocation.ddlOperation(objLocation, "Show", "", ddlLocationID);
                objClass.ddlOperation(objClass, "Show", "", ddlTicketBookingNo);
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
    public void displaySearchGrid()
    {
        try
        {
            objClass.FillGrid(objClass, GridView1, "grdSearch", "");
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
    protected void btngdEdit_Click(object sender, EventArgs e)
    {
        try
        {
            Session["TTid"] = "";
            LinkButton thisbtn = (LinkButton)sender;
            GridViewRow thisgrdR = (GridViewRow)thisbtn.Parent.Parent;
            int row = thisgrdR.RowIndex;
            Label ID = (Label)GridView1.Rows[row].Cells[0].FindControl("lblID");
            Session["TTid"] = ID.Text;
            Response.Redirect("tticketing.aspx");
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
            Response.Redirect("rptTicketInvoice.aspx");

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
    public void DeleteRecord()
    {
        objClass.nTicketingID = Session["eid"].ToString();
        var vres = objClass.User_Operation(objClass, "DeActive");
        displayGrid();
        valobj.showMsg(vres, lblmsg);
    }
    public void getPara()
    {
        objClass.nTicketingID = ddlTicketBookingNo.SelectedValue;
       objClass.dtBooking= ddlTicketBookingNo.SelectedValue;
        objClass.dtBooking = validation.dateToText(txtdtBooking.Text.Trim());
        objClass.nAgentID = ddlAgentID.SelectedValue;
        objClass.nLocationID = ddlLocationID.SelectedValue;

    }
    public void clrfield()
    {
        txtdtBooking.Text = "";
        ddlTicketBookingNo.SelectedValue = "0";
        ddlAgentID.SelectedValue = "0";
        ddlLocationID.SelectedValue = "0";
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtdtBooking.Text != "" || ddlTicketBookingNo.SelectedValue != "" || ddlAgentID.SelectedValue != "0" || ddlLocationID.SelectedValue != "0" )
            {
                getPara();
                //string cond = objClass.dtBooking;
                displaySearchGrid();
                clrfield();
            }
            else
            {
                displayGrid();
            }
        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, lblmsg);
        }
    }
}