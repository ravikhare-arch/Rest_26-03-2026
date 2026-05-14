using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Masters_medit_profile : System.Web.UI.Page
{
    muser_Class objClass = new muser_Class();
    muser_role_Class objrole = new muser_role_Class();
    mpage_master_Class objPages = new mpage_master_Class();
    validation valobj = new validation();
    muser_type_Class objUserType = new muser_type_Class();
    mdepartment_Class objDept = new mdepartment_Class();
    mlocation_Class objLoc = new mlocation_Class();
    string cond;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                string aa = Server.UrlEncode(System.DateTime.Now.ToString());
                Session["muser"] = aa;
                tblmain.Visible = true;
                //tblGrd.Visible = false;
                //ItemTab1.Visible = true;
                //ItemTab2.Visible = false;
                //displayGrid();
                objUserType.ddlOperation(objUserType, "Show", "", ddlUserTypeID);
                objLoc.ddlOperation(objLoc, "Show", "", ddlLocation);
                objDept.ddlOperation(objDept, "Show", "", ddlDepartment);
                if(Session["uid"].ToString()!=null)
                {

                GetFormData();
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
        ViewState["muser"] = Session["muser"];
    }

    public void para()
    {
        objClass.susername = validation.stringToDBString(txtLogin.Text.Trim());
       // objClass.spassword = validation.stringToDBString(txtPassword.Text.Trim());
        objClass.sUserFullName = validation.stringToDBString(txtUserFullName.Text.Trim());
        objClass.nUserTypeID = ddlUserTypeID.SelectedValue;
        objClass.nDepartmentID = ddlDepartment.SelectedValue;
        objClass.nLocationID = ddlLocation.SelectedValue;
    }

    public void clrfield()
    {
        txtLogin.Text = "";
      //  txtPassword.Text = "";
        txtUserFullName.Text = "";
        ddlUserTypeID.SelectedValue = "0";
        ddlDepartment.SelectedValue = "0";
        ddlLocation.SelectedValue = "0";
        Session["eid"] = "";
    }

    public void GetFormData()
    {
        DataTable dt = objClass.viewData(objClass, "show", Session["uid"].ToString());
        if (dt.Rows.Count > 0)
        {
            txtLogin.Text = dt.Rows[0][1].ToString();
           // txtPassword.Text = dt.Rows[0][2].ToString();
            txtUserFullName.Text = dt.Rows[0][3].ToString();
            ddlUserTypeID.SelectedValue = dt.Rows[0][4].ToString();
            ddlDepartment.SelectedValue = dt.Rows[0][5].ToString();
            ddlLocation.SelectedValue = dt.Rows[0][6].ToString();
        }
    }
   
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            para();
            objClass.nuserid = Session["uid"].ToString();
            var abc = objClass.User_Operation(objClass, "editUser");
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

   
    
   
}