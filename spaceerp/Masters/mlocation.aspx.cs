using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Master_location : System.Web.UI.Page
{
    mlocation_Class objClass = new mlocation_Class();
    validation valobj = new validation();
    msupgst_Class objSupGst = new msupgst_Class();
    mclientgst_Class objclntGst = new mclientgst_Class();
    mairgst_Class objairtGst = new mairgst_Class();
    string cond;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                string aa = Server.UrlEncode(System.DateTime.Now.ToString());
                Session["mlocation"] = aa;
                tblmain.Visible = true;
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
        ViewState["mlocation"] = Session["mlocation"];
    }

    public void para()
    {
        objClass.sLocationName = validation.stringToDBString(txtLocationName.Text.Trim());
        objClass.sAddress = validation.stringToDBString(txtAddress.Text.Trim());
        objClass.sTelephone1 = validation.stringToDBString(txtTelephone1.Text.Trim());
        objClass.sTelephone2 = validation.stringToDBString(txtTelephone2.Text.Trim());
        objClass.sFax = validation.stringToDBString(txtFax.Text.Trim());
    }
    //public void paraGst()
    //{
    //    //Sup GST
    //    objSupGst.nSupCGST = txtsupcgst.Text.Trim();
    //    objSupGst.nSupSGST = txtsupsgst.Text.Trim();
    //    objSupGst.nSupIGST = txtsupigst.Text.Trim();

    //    //Clint GST
    //    objclntGst.nClntCGST = txtClntCgst.Text.Trim();
    //    objclntGst.nClntSGST = txtClntSgst.Text.Trim();
    //    objclntGst.nClntIGST = txtClntIgst.Text.Trim();

    //    //Air GST
    //    objairtGst.nAirCGST = txtAirCGST.Text.Trim();
    //    objairtGst.nAirSGST = txtAirSGST.Text.Trim();
    //    objairtGst.nAirIGST = txtAirIGST.Text.Trim();
       
    //}


    public void clrfield()
    {
        txtLocationName.Text = "";
        txtAddress.Text = "";
        txtTelephone1.Text = "";
        txtTelephone2.Text = "";
        txtFax.Text = "";
        Session["eid"] = "";
    }

    public void GetFormData()
    {
        DataTable dt = objClass.viewData(objClass, "show", Session["eid"].ToString());
        if (dt.Rows.Count > 0)
        {
            txtLocationName.Text = dt.Rows[0][1].ToString();
            txtAddress.Text = dt.Rows[0][2].ToString();
            txtTelephone1.Text = dt.Rows[0][3].ToString();
            txtTelephone2.Text = dt.Rows[0][4].ToString();
            txtFax.Text = dt.Rows[0][5].ToString();
        }
    }

    //public void GetGstData()
    //{
    //    DataTable dtSupGst = objSupGst.viewData(objSupGst, "show", Session["eid"].ToString());
    //    if (dtSupGst.Rows.Count > 0)
    //    {
    //        txtsupigst.Text = dtSupGst.Rows[0][2].ToString();
    //        txtsupcgst.Text = dtSupGst.Rows[0][3].ToString();
    //        txtsupsgst.Text = dtSupGst.Rows[0][4].ToString();
            
    //    }

    //    DataTable dtclntGst = objclntGst.viewData(objclntGst, "show", Session["eid"].ToString());
    //    if (dtclntGst.Rows.Count > 0)
    //    {
    //        txtClntIgst.Text = dtclntGst.Rows[0][2].ToString();
    //        txtClntCgst.Text = dtclntGst.Rows[0][3].ToString();
    //        txtClntSgst.Text = dtclntGst.Rows[0][4].ToString();
            
    //    }

    //    DataTable dtAirGst = objSupGst.viewData(objSupGst, "show", Session["eid"].ToString());
    //    if (dtSupGst.Rows.Count > 0)
    //    {
    //        txtAirIGST.Text = dtAirGst.Rows[0][2].ToString();
    //        txtAirCGST.Text = dtAirGst.Rows[0][3].ToString();
    //        txtAirSGST.Text = dtAirGst.Rows[0][4].ToString();
    //    }
    //}

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
        objClass.nLocationID = Session["eid"].ToString();
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
            if (Session["mlocation"].ToString() == ViewState["mlocation"].ToString())
            {
                para();
                var abc = objClass.User_Operation(objClass, "add");
                var strArr = abc.Split(',');
                if (strArr[0] == "1")
                {

                    //paraGst();

                    //objSupGst.nLocationID = strArr[2].ToString();
                    //var abc1 = objSupGst.User_Operation(objSupGst, "add");

                    //objclntGst.nLocationID = strArr[2].ToString();
                    //var abc2 = objclntGst.User_Operation(objclntGst, "add");
                    
                    //objairtGst.nLocationID = strArr[2].ToString();
                    //var abc3 = objairtGst.User_Operation(objairtGst, "add"); 

                }


                valobj.showMsg(abc, lblmsg);

                //displayGrid();
                string aa = Server.UrlEncode(System.DateTime.Now.ToString());
                Session["mlocation"] = aa;
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
            objClass.nLocationID = Session["eid"].ToString();
            var abc = objClass.User_Operation(objClass, "edit");
            
            //Gst
            //paraGst();

          //  objSupGst.nLocationID = Session["eid"].ToString();
            //objclntGst.nLocationID = Session["eid"].ToString();
            //objairtGst.nLocationID = Session["eid"].ToString();

            //DataTable dtsup = objSupGst.viewData(objSupGst, "show", Session["eid"].ToString());
            //if(dtsup.Rows.Count>0)
            //{
            //    var abc1 = objSupGst.User_Operation(objSupGst, "edit");
            //}
            //else
            //{
            //    var abc1 = objSupGst.User_Operation(objSupGst, "add");
            //}
            //DataTable dtclnt = objclntGst.viewData(objclntGst, "show", Session["eid"].ToString());
            //if (dtclnt.Rows.Count > 0)
            //{
            //    var abc2 = objclntGst.User_Operation(objclntGst, "edit");
            //}
            //else
            //{
            //    var abc1 = objclntGst.User_Operation(objclntGst, "add");
            //}

            //DataTable dtAir = objairtGst.viewData(objairtGst, "show", Session["eid"].ToString());
            //if (dtAir.Rows.Count > 0)
            //{
            //    var abc1 = objairtGst.User_Operation(objairtGst, "edit");
            //}
            //else
            //{
            //    var abc1 = objairtGst.User_Operation(objairtGst, "add");
            //}
            
            
            
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
            //GetGstData();
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
