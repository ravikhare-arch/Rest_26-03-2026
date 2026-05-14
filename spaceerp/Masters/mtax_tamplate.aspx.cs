using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Master_tax_tamplate : System.Web.UI.Page
{
    mtax_tamplate_Class objClass = new mtax_tamplate_Class();
    mtax_master_Class objTaxMaster = new mtax_master_Class();
    mtax_templatedet_Class objClassDet = new mtax_templatedet_Class();

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
                Session["mtax_tamplate"] = aa;
                tblmain.Visible = true;
                tblGrd.Visible = false;
                tblDet.Visible = false;
                objTaxMaster.ddlOperation(objTaxMaster, "Show", "", ddlTaxName);
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

                if (GridView2.Rows.Count < 25)
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
        ViewState["mtax_tamplate"] = Session["mtax_tamplate"];
    }

    public void para()
    {
        objClass.sTamplateName = validation.stringToDBString(txtTamplateName.Text.Trim());
        objClass.nTamplateForID = ddlTemplateFor.SelectedValue;


    }

    public void clrfield()
    {
        txtTamplateName.Text = "";
        ddlTemplateFor.SelectedValue = "0";

        Session["eid"] = "";
    }

    public void GetFormData()
    {
        DataTable dt = objClass.viewData(objClass, "show", Session["eid"].ToString());
        if (dt.Rows.Count > 0)
        {
            txtTamplateName.Text = dt.Rows[0][1].ToString();
            ddlTemplateFor.SelectedValue = dt.Rows[0][2].ToString();

        }
    }
    protected void ddlTaxName_TextChanged(object sender, EventArgs e)
    {

        try
        {
            DataTable dt = objTaxMaster.viewData(objTaxMaster, "show", ddlTaxName.SelectedValue);
            if (dt.Rows.Count > 0)
            {


                ddlTaxType.SelectedValue = dt.Rows[0][2].ToString();
                txtValue.Text = dt.Rows[0][3].ToString();
            }
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
        objClass.nTaxTamplateId = Session["eid"].ToString();
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
            if (Session["mtax_tamplate"].ToString() == ViewState["mtax_tamplate"].ToString())
            {
                para();
                var abc = objClass.User_Operation(objClass, "add");
                               
                var strArr = abc.Split(',');
                if(strArr[1]=="1")
                {
                    string ItemID = strArr[2].ToString();
                     Session["eid"] = ItemID;

                     btnAdd.Visible = false;
                     btnUpdate.Visible = true;
                     btnDelete.Visible = true;
                     displayGridDet();
                     GetFormData();
                     clrfieldDet();

                     tblmain.Visible = true;
                     tblDet.Visible = true;
                     tblGrd.Visible = false;
                     btnUpdateDet.Visible = false;
                }
               
                valobj.showMsg(abc, lblmsg);
                

                //displayGrid();
                
                string aa = Server.UrlEncode(System.DateTime.Now.ToString());
                Session["mtax_tamplate"] = aa;
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
            objClass.nTaxTamplateId = Session["eid"].ToString();
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
            displayGridDet();
            clrfieldDet();
            lblmsg.Text = "";
            tblmain.Visible = true;
            tblDetGrid.Visible = true;
            tblDet.Visible = true;
            tblGrd.Visible = false;
            btnUpdateDet.Visible = false;
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

    //Detail Table 

    public void clrfieldDet()
    {
        ddlTaxName.SelectedValue = "0";
        ddlTaxType.SelectedValue = "0";
        txtValue.Text = "";
        Session["detid"] = "";

    }
    public void DetButtonVisible()
    {
        tblDet.Visible = true;
        btnAddDet.Visible = true;
        btnUpdateDet.Visible = false;
        clrfieldDet();
    }

    public void paradet()
    {
        objClassDet.nTaxTemplateID = Session["eid"].ToString();
        objClassDet.nTaxMasterID = ddlTaxName.SelectedValue;
        objClassDet.nTaxTypeID = ddlTaxType.SelectedValue;
        objClassDet.nTaxValue = txtValue.Text.Trim();


    }

    public void GetFormDataDet()
    {
        DataTable dt = objClassDet.viewData(objClassDet, "show", Session["detid"].ToString());
        if (dt.Rows.Count > 0)
        {
            ddlTaxName.SelectedValue = dt.Rows[0][2].ToString();
            ddlTaxType.SelectedValue = dt.Rows[0][3].ToString();
            txtValue.Text = dt.Rows[0][4].ToString();
        }
    }
    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GridView2.PageIndex = e.NewPageIndex;
            displayGridDet();
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message.ToString();
        }
        finally
        {
        }
    }
    protected void ddlPageSizeDet_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView2.PageSize = int.Parse(ddlPageSizeDet.SelectedValue);
        displayGridDet();
    }
    public void displayGridDet()
    {
        try
        {


            objClassDet.FillGrid(objClassDet, GridView2, "ShowGrid", Session["eid"].ToString());
        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, lblmsg);
        }
    }
    protected void btnAddDet_Click(object sender, EventArgs e)
    {
        try
        {
            lblmsg.Text = "";
            if (Session["mtax_tamplate"].ToString() == ViewState["mtax_tamplate"].ToString())
            {
                paradet();
                var abc = objClassDet.User_Operation(objClassDet, "add");

                valobj.showMsg(abc, lblmsg);
                displayGridDet();
                clrfieldDet();
                string aa = Server.UrlEncode(System.DateTime.Now.ToString());
                Session["tquotation"] = aa;
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

    protected void btnUpdateDet_Click(object sender, EventArgs e)
    {
        try
        {
            paradet();
            objClassDet.nTaxTemplateDetID = Session["detid"].ToString();
            var abc = objClassDet.User_Operation(objClassDet, "edit");
            valobj.showMsg(abc, lblmsg);
            btnUpdateDet.Visible = false;
            btnAddDet.Visible = true;
            displayGridDet();
            clrfieldDet();
        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, "FAIL", lblmsg);
        }
        finally
        {
        }
    }


    protected void btngdEditDet_Click(object sender, EventArgs e)
    {
        try
        {
            Session["Detid"] = "";
            LinkButton thisbtn = (LinkButton)sender;
            GridViewRow thisgrdR = (GridViewRow)thisbtn.Parent.Parent;
            int row = thisgrdR.RowIndex;
            Label IDDet = (Label)GridView2.Rows[row].Cells[0].FindControl("lblIDDet");
            Session["Detid"] = IDDet.Text;

            btnAddDet.Visible = false;
            btnUpdateDet.Visible = true;
            // DetButtonVisible();
            GetFormDataDet();

            displayGridDet();
            lblmsg.Text = "";
            tblDetGrid.Visible = true;
                


        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, "FAIL", lblmsg);
        }
    }

    protected void btngdDeleteDet_Click(object sender, EventArgs e)
    {
        try
        {
            Session["Detid"] = "";
            LinkButton thisbtn = (LinkButton)sender;
            GridViewRow thisgrdR = (GridViewRow)thisbtn.Parent.Parent;
            int row = thisgrdR.RowIndex;
            Label IDDet = (Label)GridView2.Rows[row].Cells[0].FindControl("lblIDDet");
            Session["Detid"] = IDDet.Text;

            DeleteDetRecord();
        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, "FAIL", lblmsg);
        }
    }
    public void DeleteDetRecord()
    {
        objClassDet.nTaxTemplateDetID = Session["Detid"].ToString();
        var vres = objClassDet.User_Operation(objClassDet, "DeActive");
        valobj.showMsg(vres, lblmsg);
        displayGridDet();
        DetButtonVisible();
    }
    protected void lnkAdd_Click(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        tblmain.Visible = true;
        tblGrd.Visible = false;
        tblDet.Visible = false;
        tblDetGrid.Visible = false;
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
