using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.Services;

public partial class mpage_master_Test : System.Web.UI.Page
{
    static mpage_master_Class objClass = new mpage_master_Class();
    static mmodule_Class objModule = new mmodule_Class();
    static cls_mmodulegroup objModuleGroup = new cls_mmodulegroup();
    static muser_Class objUser = new muser_Class();
    static muser_role_Class objUser_Role = new muser_role_Class();
    public static string viewstate;
    validation valobj = new validation();
    string cond;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                // Fillddl.FillPageddl(ddlPageSize);
                objModule.ddlOperation(objModule, "Show", "", ddlmodule);
                objModuleGroup.ddlOperation(objModuleGroup, "Show", "", ddlgrouphead);
                string aa = Server.UrlEncode(System.DateTime.Now.ToString());
                Session["mpage_master_list"] = aa;              
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
        ViewState["mpage_master_list"] = Session["mpage_master_list"];
        viewstate = Session["mpage_master_list"].ToString();
    }

    [WebMethod]
    public static string addPagePamster(list list)
    {
        string msg = "";
        try
        {
            if (HttpContext.Current.Session["mpage_master_list"].ToString() == viewstate)
            {
                // //  assign objects start
                objClass.sPageMasterName = validation.stringToDBString(list.sPageMasterName);
                objClass.nModuleID = validation.stringToDBString(list.nModuleID);
                objClass.ModuleGroupID = validation.stringToDBString(list.ModuleGroupID);
                objClass.sPageMasterDescription = validation.stringToDBString(list.sPageMasterDescription);
                objClass.sPageUrl = validation.stringToDBString(list.sPageUrl);
                var abc = objClass.User_Operation(objClass, "add");
                //  valobj.showMsg(abc, lblmsg);
                string[] strArr = abc.Split(',');
                string val1 = strArr[0];
                if (strArr[0] == "1")
                {
                    string nPageID = strArr[2].ToString();
                    objUser_Role.nPageID = nPageID;

                    //Checking User
                    DataTable dtUser = objUser.viewData(objUser, "show", "");
                    if (dtUser.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtUser.Rows.Count; i++)
                        {
                            objUser_Role.nUserID = dtUser.Rows[i]["nLoginId"].ToString();
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
                
                if (val1 == "1")
                {
                    msg = "1";
                }
                else
                {
                    msg = abc.ToString();
                }
               
            }
        }
        catch (Exception ex)
        {
            msg = ex.Message.ToString();
        }
        finally
        {
        }
        return msg;
    }

    [WebMethod]
    public static string UpdatePageMaster(list list)
    {
        string msg = "";
        try
        {
            if (HttpContext.Current.Session["mpage_master_list"].ToString() == viewstate)
            {
                // //  assign objects start
                objClass.sPageMasterName = validation.stringToDBString(list.sPageMasterName);
                objClass.nModuleID = validation.stringToDBString(list.nModuleID);
                objClass.ModuleGroupID = validation.stringToDBString(list.ModuleGroupID);
                objClass.sPageMasterDescription = validation.stringToDBString(list.sPageMasterDescription);
                objClass.sPageUrl = validation.stringToDBString(list.sPageUrl);
                objClass.nPageMasterID = Convert.ToInt32(list.nPageMasterID).ToString();
                var abc = objClass.User_Operation(objClass, "edit");
                //  valobj.showMsg(abc, lblmsg);
                string[] values = abc.Split(',');
                string val1 = values[0];
                if (val1 == "1")
                {
                    msg = "1";
                }
                else
                {
                    msg = abc.ToString();
                }

            }

        }
        catch (Exception ex)
        {
            msg = ex.Message.ToString();
        }
        return msg;
    }
    [WebMethod]
    public static string DeletePageMaster(string AccountLedgerID)
    {
        string msg = "";
        try
        {
            objClass.nPageMasterID = AccountLedgerID;
            var vres = objClass.User_Operation(objClass, "DeActive");
            string[] values = vres.Split(',');
            string val1 = values[0];
            if (val1 == "1")
            {
                msg = val1;
            }
            else
            {
                msg = vres;
            }
        }
        catch (Exception ex)
        {
            msg = ex.Message.ToString();
        }



        return msg;
    }
    [WebMethod]
    public static mpagemasterlist loaddata()
    {
        list magentobj = new list();
        mpagemasterlist mainlist = new mpagemasterlist();
        mainlist.mpagemasterobjlist = new List<list>();
        DataTable dt = new DataTable();
        try
        {
            dt = objClass.Tabledata(objClass, "ShowGrid", "");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                magentobj = new list();
                magentobj.nPageMasterID = Convert.ToInt32(dt.Rows[i]["nPageMasterID"].ToString());
                magentobj.sPageMasterName = dt.Rows[i]["sPageMasterName"].ToString();
                magentobj.sModule = dt.Rows[i]["sModuleName"].ToString();
                magentobj.ModuleGroupID = dt.Rows[i]["nModuleGroupID"].ToString();
                magentobj.sPageMasterDescription = dt.Rows[i]["sPageMasterDescription"].ToString();
                magentobj.sPageUrl = dt.Rows[i]["sPageUrl"].ToString();
                magentobj.nModuleID = dt.Rows[i]["nModuleID"].ToString();
                magentobj.GroupName = dt.Rows[i]["sGroupName"].ToString();
                mainlist.mpagemasterobjlist.Add(magentobj);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return mainlist;
    }

    
    public class list
    {
        public int nPageMasterID { get; set; }
        public string sPageMasterName { get; set; }
        public string sPageMasterDescription { get; set; }
        public string nModuleID { get; set; }
        public string sPageUrl { get; set; }
        public string ModuleGroupID { get; set; }
        public string sModule { get; set; }
        public string GroupName { get; set; }
    }

    public class mpagemasterlist
    {
        public List<list> mpagemasterobjlist { get; set; }
    }
}
