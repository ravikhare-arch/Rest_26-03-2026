using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    validation valobj = new validation();
    muser_Class objClass = new muser_Class();
    company_main_Class objCom = new company_main_Class();
    string vgoto;
    SqlConnection conn;
    connection connobj = new connection();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["msg"] != null)
            {
                valobj.showMsg(Request.QueryString["msg"].ToString(), lblmsg);
            }
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

    }

    protected void btn_Click(object sender, EventArgs e)
    {
        objClass.susername = txtUser.Text.Trim();
        objClass.spassword = txtPass.Text.Trim();
        Session["ConfigID"] = "0";
        DataTable dt = objClass.viewData(objClass, "chkUser", "");

        if (dt.Rows.Count > 0)
        {
            // Session bharna zaroori hai taaki JS use utha sake
            Session["nLoginId"] = dt.Rows[0]["nLoginId"].ToString();
            Session["sLogin"] = dt.Rows[0]["sLogin"].ToString();
            Session["sUserFullName"] = dt.Rows[0]["sUserFullName"].ToString();

            Session["uid"] = dt.Rows[0][0].ToString();
            Session["name"] = dt.Rows[0][1].ToString();
            Session["typ"] = dt.Rows[0]["nUserTypeID"].ToString();
            Session["nPOTaxTemplateID"] = "1";

            SetMenu();

            DataTable dtConfig = objCom.viewData(objCom, "ShowConfig", dt.Rows[0]["nConfigID"].ToString());
            if (dtConfig.Rows.Count > 0)
            {
                Session["ConfigID"] = dtConfig.Rows[0]["nConfigID"].ToString();
            }

            // YAHAN DHAYAN DO: Redirect wali lines delete kar do!
            // Taki page reload ho aur niche wali script chale.
        }
        else
        {
            valobj.showMsg("Username or Password is not valid!", "FAIL", lblmsg);
        }
    }
    //protected void btn_Click(object sender, EventArgs e)
    //{
    //    objClass.susername = txtUser.Text.Trim();
    //    objClass.spassword = txtPass.Text.Trim();
    //    Session["ConfigID"] = "0";
    //    DataTable dt = objClass.viewData(objClass, "chkUser", "");
    //    if (dt.Rows.Count > 0)
    //    {
    //        Session["uid"] = dt.Rows[0][0].ToString();
    //        Session["name"] = dt.Rows[0][1].ToString();
    //        Session["typ"] = dt.Rows[0]["nUserTypeID"].ToString();
    //        Session["nPOTaxTemplateID"] = "1";
    //        SetMenu();
    //        DataTable dtConfig = objCom.viewData(objCom, "ShowConfig", dt.Rows[0]["nConfigID"].ToString());
    //        if (dtConfig.Rows.Count > 0)
    //        {
    //            Session["nLoginId"] = dt.Rows[0]["nLoginId"].ToString();
    //            Session["sLogin"] = dt.Rows[0]["sLogin"].ToString();
    //            Session["sUserFullName"] = dt.Rows[0]["sUserFullName"].ToString();
    //            Session["ConfigID"] = dtConfig.Rows[0]["nConfigID"].ToString();
    //        }

    //        vgoto = "Dashboard.aspx";
    //        if (Request.QueryString["url"] != null)
    //        {
    //            if (Request.QueryString["url"].ToString() != "")
    //            {
    //                Response.Redirect(vgoto);
    //            }
    //            else
    //                Response.Redirect(vgoto);
    //        }
    //        else
    //            Response.Redirect(vgoto);

    //    }

    //    else
    //    {
    //        valobj.showMsg("Username or Password is not valid!", "FAIL", lblmsg);
    //    }
    //}
    public void SetMenu()
    {
        var MenuString = string.Empty;
        var vcond = string.Empty;
        var admincond = string.Empty;
        string vUsertype = Session["typ"].ToString();
        var ullist = string.Empty;
        if (vUsertype != "1")
        {
            vUsertype = Session["uid"].ToString();
        }
        else
        {
            vUsertype = "";
        }

        DataTable dt = objClass.viewData(objClass, "chkUserMenuConfig", vUsertype);
        try
        {
            if (dt.Rows.Count > 0)
            {
                string path = string.Empty;
                MenuString = "<ul class='metismenu' id='side-menu'>";
                foreach (DataRow row in dt.Rows)
                {
                    path = ResolveUrl("~/Menus/CommonPage.aspx?vMenuType=" + row["sModuleName"].ToString());
                    MenuString += "<li><a href='" + path + "'><i class='fa fa-pie-chart'></i><span>" + row["sModuleName"].ToString() + "</span> </a </li>";
                }
                MenuString += "</ul>";
            }
            Session["MenuString"] = MenuString;
        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message.ToString(), "FAIL", lblmsg);
        }
        finally
        {

        }

    }
}
