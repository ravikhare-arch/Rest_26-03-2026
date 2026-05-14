using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Master_agent_assign : System.Web.UI.Page
{
    magent_assign_Class objClass = new magent_assign_Class();
    mclient_Class objAgent = new mclient_Class();
    msupplier_Class objSupplier = new msupplier_Class();
    mflight_carrier_Class objAirline = new mflight_carrier_Class();
    validation valobj = new validation();
    string cond;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ///Fillddl.FillPageddl(ddlPageSize);
                string aa = Server.UrlEncode(System.DateTime.Now.ToString());
                Session["magent_assign"] = aa;
                tblmain.Visible = true;
                tblGrd.Visible = false;
                tblSupGrid.Visible = false;
                displayGrid();
                objAgent.ddlOperation(objAgent, "Showddl", "", ddlAgent);
               
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
        ViewState["magent_assign"] = Session["magent_assign"];
    }

    public void para()
    {
        objClass.nAgentID = ddlAgent.SelectedValue;
        objClass.nSupplierID = ddlSupplier.SelectedValue;
        objClass.nTypeID = ddlType.SelectedValue;
       
    }

    public void clrfield()
    {
        ddlAgent.SelectedValue = "0";
        ddlSupplier.SelectedValue = "0";
        ddlType.SelectedValue = "0";
        Session["eid"] = "";
    }

    public void GetFormData()
    {
        DataTable dt = objClass.viewData(objClass, "show", Session["eid"].ToString());
        if (dt.Rows.Count > 0)
        {
            ddlAgent.SelectedValue = dt.Rows[0][1].ToString();
            ddlType.SelectedValue = dt.Rows[0][3].ToString();
            EventArgs e = new EventArgs();
            ddlType_SelectedIndexChanged(this, e);
            ddlSupplier.SelectedValue = dt.Rows[0][2].ToString();
            
           
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
    public void displayGridDet()
    {
        try
        {
            objClass.nAgentID = ddlAgent.SelectedValue;
            objClass.nSupplierID = ddlSupplier.SelectedValue;
            objClass.FillGrid(objClass, GridView2, "ShowGrid", ddlSupplier.SelectedValue);
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
        objClass.nAgentAssignID = Session["eid"].ToString();
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
            if (Session["magent_assign"].ToString() == ViewState["magent_assign"].ToString())
            {
                para();
                var abc = objClass.User_Operation(objClass, "add");
                valobj.showMsg(abc, lblmsg);
                //displayGrid();

                displayGridDet();
                string aa = Server.UrlEncode(System.DateTime.Now.ToString());
                Session["magent_assign"] = aa;
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
            objClass.nAgentAssignID = Session["eid"].ToString();
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
        tblSupGrid.Visible = false;
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
    protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(ddlType.SelectedValue=="1")
        {
            objSupplier.ddlOperation(objSupplier, "Showddl", "", ddlSupplier);
        }
        else
        {
            objSupplier.ddlOperation(objSupplier, "Showddl", "", ddlSupplier);
        }
    }
    protected void ddlSupplier_SelectedIndexChanged(object sender, EventArgs e)
    {
        tblSupGrid.Visible = true;
        displayGridDet();
    }
}
