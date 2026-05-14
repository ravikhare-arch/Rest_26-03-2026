using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Masters_Change_Password : System.Web.UI.Page
{
    muser_Class objClass = new muser_Class();
    validation valobj = new validation();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                string aa = Server.UrlEncode(System.DateTime.Now.ToString());
                Session["muser"] = aa;
                tblmain.Visible = true;
                txtPassword.TextMode = TextBoxMode.Password;
                //tblGrd.Visible = false;
                //ItemTab1.Visible = true;
                //ItemTab2.Visible = false;
                //displayGrid();
                
                if (Session["uid"].ToString() != null)
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
    public void GetFormData()
    {
        DataTable dt = objClass.viewData(objClass, "show", Session["uid"].ToString());
        if (dt.Rows.Count > 0)
        {
            lblPass.Text = dt.Rows[0]["sPassword"].ToString();
            // txtPassword.Text = dt.Rows[0][2].ToString();
          
        }
    }
    public void para()
    {
       objClass.spassword = validation.stringToDBString(txtPassword.Text.Trim());
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            para();

            objClass.nuserid = Session["uid"].ToString();
             DataTable dt = objClass.viewData(objClass, "show", Session["uid"].ToString());
             if (dt.Rows.Count > 0)
             {
                 if (dt.Rows[0]["sPassword"].ToString()==txtCurrentPassword.Text)
                 {
                     var abc = objClass.User_Operation(objClass, "ChangePassword");
                     valobj.showMsg(abc, lblmsg);
                 }
                 else
                 {
                     valobj.showMsg("Current Password not match", "FAIL", lblmsg);
                 }
             }
           
            //displayGrid();
        }
        catch (Exception ex)
        {
            
        }
        finally
        {
        }
    }
    protected void btnShowPass_Click(object sender, EventArgs e)
    {
        txtPassword.TextMode = TextBoxMode.SingleLine;
        this.txtPassword.Text = txtPassword.Text;
    }
}