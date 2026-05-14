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

public partial class ItemGroupMaster : System.Web.UI.Page
{
    static Itemgroupmanage  objClass = new Itemgroupmanage();
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
               
                string aa = Server.UrlEncode(System.DateTime.Now.ToString());
                Session["ItemGroupMaster"] = aa;
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
        ViewState["ItemGroupMaster"] = Session["ItemGroupMaster"];
        viewstate = Session["ItemGroupMaster"].ToString();
    }

    [WebMethod]
    public static string addPagePamster(list list)
    {
        string msg = "";
        try
        {
            if (HttpContext.Current.Session["ItemGroupMaster"].ToString() == viewstate)
            {
                // //  assign objects start
                objClass.MenuGroup = validation.stringToDBString(list.MenuGroup);
                var abc = objClass.User_Operation(objClass, "add");
                //  valobj.showMsg(abc, lblmsg);
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
    public static string UpdatePageMaster(list list)
    {
        string msg = "";
        try
        {
            if (HttpContext.Current.Session["ItemGroupMaster"].ToString() == viewstate)
            {
                // //  assign objects start
                objClass.MenuGroup = validation.stringToDBString(list.MenuGroup);
                objClass.MenuGroupID = Convert.ToInt32(list.MenuGroupID).ToString();
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
            objClass.MenuGroupID = AccountLedgerID;
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
    public static mpagemasterlist loaddata()
    {
        list magentobj = new list();
        mpagemasterlist mainlist = new mpagemasterlist();
        mainlist.mpagemasterobjlist = new List<list>();
        DataTable dt = new DataTable();
        try
        {
            dt = objClass.Tabledata(objClass, "Show", "");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                magentobj = new list();
                magentobj.MenuGroupID = Convert.ToInt32(dt.Rows[i]["GroupID"].ToString());
                magentobj.MenuGroup = dt.Rows[i]["GroupName"].ToString();
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
        public int MenuGroupID { get; set; }
        public string MenuGroup { get; set; }
       
    }

    public class mpagemasterlist
    {
        public List<list> mpagemasterobjlist { get; set; }
    }
}
