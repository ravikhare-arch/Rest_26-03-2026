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

public partial class mmodulelist : System.Web.UI.Page
{
    static mmodule_Class objClass = new mmodule_Class();
    validation valobj = new validation();
    public static string viewstate;
    string cond;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                // Fillddl.FillPageddl(ddlPageSize);
                string aa = Server.UrlEncode(System.DateTime.Now.ToString());
                Session["muser"] = aa;              
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
        viewstate = Session["muser"].ToString();
    }

    [WebMethod]
    public static string AddUser(list list)
    {
        string msg = "";
        try
        {
            if (HttpContext.Current.Session["muser"].ToString() == viewstate)
            {
                //  assign objects start
                objClass.sModuleName = validation.stringToDBString(list.GroupName);
                var abc = objClass.User_Operation(objClass, "add");

                string[] strArr = abc.Split(',');
                string val1 = strArr[0];
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
    public static string UpdateUser(list list)
    {
        string msg = "";
        try
        {
            if (HttpContext.Current.Session["muser"].ToString() == viewstate)
            {
                //  assign objects start
                objClass.sModuleName = validation.stringToDBString(list.GroupName);
                objClass.nModuleID = Convert.ToInt32(list.GroupID).ToString();
                var abc = objClass.User_Operation(objClass, "edit");

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
    public static string DeleteUser(string AccountLedgerID)
    {
        string msg = "";
        try
        {
            objClass.nModuleID = AccountLedgerID;
            var vres = objClass.User_Operation(objClass, "Delete");
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
    public static muserlist loaddata()
    {
        list magentobj = new list();
        muserlist mainlist = new muserlist();
        mainlist.muserobjlist = new List<list>();
        DataTable dt = new DataTable();
        try
        {
            dt = objClass.Tabledata(objClass, "Show", "");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                magentobj = new list();
                magentobj.GroupID = Convert.ToInt32(dt.Rows[i]["nModuleID"].ToString());
                magentobj.GroupName = dt.Rows[i]["sModuleName"].ToString();
                mainlist.muserobjlist.Add(magentobj);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return mainlist;
    }

    [WebMethod]
    public static string MarkInactive(string agencyid)
    {
        string msg = "";
        try
        {
            //objClass.nuserid = agencyid;
            //var vres = objClass.User_Operation(objClass, "DeActive");
            //string[] values = vres.Split(',');
            //string val1 = values[0];
            //if (val1 == "1")
            //{
            //    msg = val1;
            //}
            //else
            //{
            //    msg = vres;
            //}
        }
        catch (Exception ex)
        {
            msg = ex.Message.ToString();
        }
        return msg;
    }
    public class list
    {
        public int GroupID { get; set; }
        public string GroupName { get; set; }
       
    }

    public class muserlist
    {
        public List<list> muserobjlist { get; set; }
    }
}
