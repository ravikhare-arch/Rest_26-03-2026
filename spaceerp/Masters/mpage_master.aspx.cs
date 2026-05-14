using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Master_page_master : System.Web.UI.Page
{
    mpage_master_Class objClass = new mpage_master_Class();
    mmodule_Class objModule = new mmodule_Class();
    cls_mmodulegroup objModuleGroup = new cls_mmodulegroup();
    validation valobj = new validation();
    muser_Class objUser = new muser_Class();
    muser_role_Class objUser_Role = new muser_role_Class();
    string cond;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                // Fillddl.FillPageddl(ddlPageSize);
                string aa = Server.UrlEncode(System.DateTime.Now.ToString());
                Session["mpage_master"] = aa;
                tblmain.Visible = true;
                tblGrd.Visible = false;
                displayGrid();
                objModule.ddlOperation(objModule, "Show", "", ddlModule);
                objModuleGroup.ddlOperation(objModuleGroup, "Show", "", ddlgrouphead);
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
        ViewState["mpage_master"] = Session["mpage_master"];
    }

    public void para()
    {
        objClass.sPageMasterName = validation.stringToDBString(txtPageMasterName.Text.Trim());
        objClass.nModuleID = ddlModule.SelectedValue;
        objClass.sPageMasterDescription = validation.stringToDBString(txtPageMasterDescription.Text.Trim());
        objClass.sPageUrl = validation.stringToDBString(txtPageUrl.Text.Trim());
        objClass.ModuleGroupID = ddlgrouphead.SelectedValue;

    }

    public void clrfield()
    {
        txtPageMasterName.Text = "";
        ddlModule.SelectedValue="0";
        txtPageMasterDescription.Text = "";
        txtPageUrl.Text = "";
        ddlgrouphead.SelectedValue = "0";
        Session["eid"] = "";
    }

    public void GetFormData()
    {
        DataTable dt = objClass.viewData(objClass, "show", Session["eid"].ToString());
        if (dt.Rows.Count > 0)
        {
            txtPageMasterName.Text = dt.Rows[0][1].ToString();        
            ddlModule.SelectedValue = dt.Rows[0][2].ToString();
            txtPageMasterDescription.Text = dt.Rows[0][3].ToString();
            txtPageUrl.Text = dt.Rows[0][4].ToString();
            ddlgrouphead.SelectedValue = dt.Rows[0][5].ToString();
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
        objClass.nPageMasterID = Session["eid"].ToString();
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
            if (Session["mpage_master"].ToString() == ViewState["mpage_master"].ToString())
            {
                para();
                var abc = objClass.User_Operation(objClass, "add");
                var strArr = abc.Split(',');
                if (strArr[0] == "1")
                {
                    string nPageID = strArr[2].ToString();
                    objUser_Role.nPageID = nPageID;
                    
                    //Checking User
                    DataTable dtUser = objUser.viewData(objUser, "show", "");
                    if (dtUser.Rows.Count > 0)
                     {
                        for(int i=0;i< dtUser.Rows.Count;i++)
                        {
                           objUser_Role.nUserID= dtUser.Rows[i]["nLoginId"].ToString();
                           if (objUser_Role.nUserID == "1")
                           {
                               objUser_Role.bPageActive = "1";
                               objUser_Role.bAdd = "1";
                               objUser_Role.bEdit = "1";
                               objUser_Role.bDelete = "1";
                               objUser_Role.bPrint = "1";
                               objUser_Role.bList = "1";
                           }
                           else
                           {
                               objUser_Role.bPageActive = "0";
                               objUser_Role.bAdd = "0";
                               objUser_Role.bEdit = "0";
                               objUser_Role.bDelete = "0";
                               objUser_Role.bPrint = "0";
                               objUser_Role.bList = "0";
                           }

                           var xyz = objUser_Role.User_Operation(objUser_Role, "add");
                           
                        }
                     }
                }
                valobj.showMsg(abc, lblmsg);
                

                //displayGrid();
                string aa = Server.UrlEncode(System.DateTime.Now.ToString());
                Session["mpage_master"] = aa;
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
            objClass.nPageMasterID = Session["eid"].ToString();
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
