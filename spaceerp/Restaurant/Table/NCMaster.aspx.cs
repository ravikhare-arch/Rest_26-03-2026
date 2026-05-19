using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Data;

public partial class NCMaster : System.Web.UI.Page
{
    static NCManageMaster objClass = new NCManageMaster();
    public static string viewstate = "";
    static cls_ordertype objordertype = new cls_ordertype(); // Aapka existing Dropdown fill class
    validation valobj = new validation();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                string token = DateTime.Now.Ticks.ToString();
                Session["NCMaster"] = token;
                viewstate = token;

                // Order Type Dropdown Fill kerna
                objordertype.ddlOperation(objordertype, "Show", "", ddlordertype);
            }
        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, "FAIL", lblmsg);
        }
    }

    [WebMethod]
    public static string addPagePamster(list list)
    {
        string msg = "";
        try
        {
            objClass.AreaName = list.AreaName;
            objClass.OrderType = list.OrderType;
            objClass.AreaID = "0";

            string result = objClass.User_Operation(objClass, "add");
            msg = result;
        }
        catch (Exception ex)
        {
            msg = ex.Message;
        }
        return msg;
    }

    [WebMethod]
    public static string UpdatePageMaster(list list)
    {
        string msg = "";
        try
        {
            objClass.AreaName = list.AreaName;
            objClass.OrderType = list.OrderType;
            objClass.AreaID = list.AreaID.ToString();

            string result = objClass.User_Operation(objClass, "edit");
            msg = result;
        }
        catch (Exception ex)
        {
            msg = ex.Message;
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
            string result = objClass.User_Operation(objClass, "Delete");
            msg = result;
        }
        catch (Exception ex)
        {
            msg = ex.Message;
        }
        return msg;
    }

    [WebMethod]
    public static mpagemasterlist loaddata()
    {
        mpagemasterlist mainlist = new mpagemasterlist();
        mainlist.mpagemasterobjlist = new List<list>();

        try
        {
            // 🔥 GAP FIXED: Ab table se active data load hoga!
            DataTable dt = objClass.Tabledata(objClass, "Show", "");

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    list obj = new list();
                    obj.AreaID = Convert.ToInt32(row["NC_ID"]);
                    obj.AreaName = row["NC_Name"].ToString();
                    obj.OrderType = row["OrderTypeID"].ToString();
                    obj.OrderTypeName = row["OrderTypeName"].ToString();

                    mainlist.mpagemasterobjlist.Add(obj);
                }
            }
        }
        catch (Exception ex)
        {
            // Log exception here
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