using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Master_AccountFamily : System.Web.UI.Page
{
    mAccountFamily_Class objClass = new mAccountFamily_Class();
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
                Session["mAccountFamily"] = aa;

                tblmain.Visible =true;
                tblGrd.Visible = false;
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
        ViewState["mAccountFamily"] = Session["mAccountFamily"];
    }

    public void para()
    {
        objClass.sFamily = validation.stringToDBString(txtFamily.Text.Trim());


    }

    public void clrfield()
    {
        txtFamily.Text = "";
        txtFamily.Focus();
        Session["eid"] = "";
    }

    public void GetFormData()
    {
        DataTable dt = objClass.viewData(objClass, "show", Session["eid"].ToString());
        if (dt.Rows.Count > 0)
        {
            txtFamily.Text = dt.Rows[0][1].ToString();

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
        objClass.nFamilyID = Session["eid"].ToString();
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
            if (Session["mAccountFamily"].ToString() == ViewState["mAccountFamily"].ToString())
            {
                para();
                var abc = objClass.User_Operation(objClass, "add");
                valobj.showMsg(abc, lblmsg);
                //displayGrid();
                clrfield();
                string aa = Server.UrlEncode(System.DateTime.Now.ToString());
                Session["mAccountFamily"] = aa;
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
            objClass.nFamilyID = Session["eid"].ToString();
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
            tblmain.Visible =true;
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
        tblmain.Visible =true;
        tblGrd.Visible = false;
        clrfield();
        btnVisible();
    }
    protected void lnkList_Click(object sender, EventArgs e)
    {
        lblmsg.Text = "";
       tblmain.Visible =false;
        tblGrd.Visible = true;
        displayGrid();
    }
}
