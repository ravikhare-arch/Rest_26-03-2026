using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Data.SqlClient;

public partial class Menus_CommonPage : System.Web.UI.Page
{
    validation valobj = new validation();
    SqlConnection conn;
    connection connobj = new connection();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                string aa = Server.UrlEncode(System.DateTime.Now.ToString());
                Session["mmodule"] = aa;
                ShowMenu();
            }
        }
        catch (Exception ex)
        {
           // valobj.showMsg(ex.Message, "FAIL", lblmsg);
        }
        finally
        {
        }
    }
    public void ShowMenu()
    {
        conn = connobj.makeConnection();
        var vcond = string.Empty;
        var admincond = string.Empty;
        var vcolumn = string.Empty;
       // string vUsertype = Session["typ"].ToString;
       string vUsertype = Session["typ"].ToString();

        //if (Request.QueryString["vMenuType"] == "Reports")
        //{
        //    vcond += " and mmodulegroup.sGroupName='Reports'";
        //    vcolumn = " mmodulegroup.sGroupName as 'GroupName'";
        //}
        //else
        //{
        //    vcond += " and mmodule.sModuleName='" + Request.QueryString["vMenuType"] + "' ";
        //    vcolumn = " mmodule.sModuleName as 'GroupName'";
        //}
        if (vUsertype == "1")
        {
            admincond = vcond;
        }
        else
        {
            admincond = " and tuserconfigure.nLoginID= " + Session["uid"];
        }
        vcond += " and mmodule.sModuleName='" + Request.QueryString["vMenuType"] + "'" + admincond;
        var vsql = " SELECT mpage_master.nPageMasterID,mpage_master.sPageUrl,mmodulegroup.sGroupName ,sPageMasterName from mmodule " +
                    " INNER JOIN mpage_master  ON mpage_master.nModuleID=mmodule.nModuleID " +
                    " LEFT JOIN tuserconfigure  ON mpage_master.nPageMasterID=tuserconfigure.nPageMasterID " +
                    " INNER JOIN mmodulegroup ON (mmodulegroup.nModuleGroupID=mpage_master.nModuleGroupID)  " +
                    " WHERE  mpage_master.bActive=1 " + vcond + " GROUP BY mpage_master.nPageMasterID , mpage_master.sPageUrl,mmodulegroup.sGroupName ,sPageMasterName ORDER BY mmodulegroup.sGroupName  ";

        //If Request.QueryString("vMenuType") = "Reports" Then
        //    vsql = "select mbmd.sType,mbmd.sSequenceNo,mbmd.sLeftLinkName,mbmd.sLeftLinkPath,mbmd.sRightLinkName,mbmd.sRightLinkPath,mbmd.sRemarks,mbmd.nBankModuleDetID,mbm.sBankModule AS 'GroupHead'  from mbanksysclientconfig mbsc inner join sysclient sc on mbsc.sSysClientID=sc.nSysClientID inner join mbankmoduledet mbmd on mbsc.nBankModuledetid=mbmd.nBankModuleDetID inner join mbankmodule mbm on mbm.nBankModuleID=mbmd.nBankModuleID INNER JOIN mbankmodulegroup ON (mbankmodulegroup.nBankModuleGroupID=mbmd.nBankModuleGroupID)  where sc.bCurrent='1' AND mbmd.sType<>'GROUP_HEAD' AND mbmd.bActive=1 " & vcond & " order by mbm.nSequenceNo,abs(mbmd.sSequenceNo)"
        //End If
        var dbComm = new SqlCommand();
        dbComm = new SqlCommand(vsql, conn);

        try
        {
            var vGroupHead = string.Empty;
            var tempHead = string.Empty;
            int vsrcnter = 0;
            SqlDataReader dr;
            dr = dbComm.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    if (vGroupHead.ToUpper() != dr.GetValue(2).ToString().ToUpper())
                    {
                        vsrcnter = vsrcnter + 1;
                        vGroupHead = dr.GetValue(2).ToString();
                        tempHead = "";

                        if (lblMenu.Text != "")
                        {
                            lblMenu.Text += "</ul>";
                            lblMenu.Text += "</div>";
                            lblMenu.Text += "</div>";
                            lblMenu.Text += "</div>";
                        }
                        if (vsrcnter == 1)
                        {
                            if (lblMenu.Text != "")
                            {
                                lblMenu.Text += "</div>";
                            }
                            lblMenu.Text += "<div class='row'>";
                        }
                        lblMenu.Text += "<div class='col-md-4 col-xs-12 '><div style='width: 100%; float:left; margin-bottom:10px; box-shadow:0 0 1px grey; height: 220px; '><div class='colpsbox_one_top' style='padding-left:40px; '><div class='icon_corner'><i class='fa fa-pie-chart' style='font-size:20px;color:white;'></i></div>";
                        lblMenu.Text += "<span>" + vGroupHead + "</span>&nbsp;<i class='fa fa-square' style='color:#b71411;'></i></div>";
                        lblMenu.Text += "<div class='scroll-box' style='width:100%; float:left; height: 180px;'>";
                        //lblMenu.Text += "<ul>";
                        if (vsrcnter == 3)
                        {
                            vsrcnter = 0;
                        }
                    }
                    lblMenu.Text += "<div  class='clps_desn' style='margin-bottom:0;' ><a class='clps_desn_sml' href='.." + dr.GetValue(1).ToString() + "' >" + dr.GetValue(3).ToString() + "</a></div>";
                }
                //lblMenu.Text += "</ul>";
                lblMenu.Text += "</div>";
                lblMenu.Text += "</div>";
                lblMenu.Text += "</div>";
                if (vsrcnter == 1)
                {
                    lblMenu.Text += "<div class='col-md-4 col-xs-12 menucards' style='margin-left:0px;'></div>";
                }
                lblMenu.Text += "</div>";
            }
        }
        catch (Exception ex)
        {
            //valobj.showMsg(ex.Message, lblmsg);
        }
        finally
        {
            dbComm.Dispose();
            conn = connobj.closeConnection();
        }
    }
}