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

public partial class AreaMaster : System.Web.UI.Page
{
    static AreaManageMaster  objClass = new AreaManageMaster();
    public static string viewstate;
    static cls_ordertype objordertype = new cls_ordertype();
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
                Session["AreaMaster"] = aa;
                objordertype.ddlOperation(objordertype, "Show", "", ddlordertype);
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
        ViewState["AreaMaster"] = Session["AreaMaster"];
        viewstate = Session["AreaMaster"].ToString();
    }

    [WebMethod]
    public static string addPagePamster(list list)
    {
        string msg = "";
        try
        {
            if (HttpContext.Current.Session["AreaMaster"].ToString() == viewstate)
            {
                // //  assign objects start
                objClass.AreaName = validation.stringToDBString(list.AreaName);
                objClass.OrderType = list.OrderType;
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
            if (HttpContext.Current.Session["AreaMaster"].ToString() == viewstate)
            {
                // //  assign objects start
                objClass.AreaName = validation.stringToDBString(list.AreaName);
                objClass.OrderType = list.OrderType;
                objClass.AreaID = Convert.ToInt32(list.AreaID).ToString();
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
            objClass.AreaID = AccountLedgerID;
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
                magentobj.AreaID = Convert.ToInt32(dt.Rows[i]["DineAreaMasterID"].ToString());
                magentobj.AreaName = dt.Rows[i]["AreaName"].ToString();
                magentobj.OrderTypeName = dt.Rows[i]["OrderTypename"].ToString();
                magentobj.OrderType = dt.Rows[i]["ordertype"].ToString();
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
        public int AreaID { get; set; }
        public string AreaName { get; set; }

        public string OrderType { get; set; }
        public string OrderTypeName { get; set; }

    }

    public class mpagemasterlist
    {
        public List<list> mpagemasterobjlist { get; set; }
    }
}
