using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Text.RegularExpressions;


public partial class Site : System.Web.UI.MasterPage
{
    validation valobj = new validation();
    public string GetCurrentPageName()
    {
        string sPath = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
        var str = sPath.Split('/');
        string sRet = str[str.Length-1].ToString();
        return sRet.ToString().ToLower();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["uid"] == null)
        {
            Response.Redirect(Page.ResolveUrl("~/default.aspx"));

        }
        else if (Session["ConfigID"] == null)
        {
            Response.Redirect(Page.ResolveUrl("~/default.aspx"));

        }
        ShowMessage();
        //else
        //{
        //    if (Request.QueryString["vMenuType"] == "")
        //    {
        //        String pageUrl = "";
        //        pageUrl = GetCurrentPageName();
        //        if (pageUrl != "error.aspx")
        //        {
        //            if (Session["uRole"].ToString() != "" || Session["uRole"].ToString() != null)
        //            {

        //                if (Session["uRole"].ToString().ToLower().Contains(pageUrl))
        //                {

        //                }
        //                else
        //                {
        //                    if (Session["typ"].ToString() != "1")
        //                        Response.Redirect(Page.ResolveUrl("~/error.aspx"));
        //                }

        //            }
        //            else
        //            {
        //                Response.Redirect("../default.aspx");
        //            }
        //        }
        //    }
            
        //}

    }
    public void ShowMessage()
    {
         if (!string.IsNullOrEmpty(Request.QueryString["vmsg"]))
         {
             valobj.showMsg(Request.QueryString["vmsg"].ToString(), lblmsg);
         }

    }

}
