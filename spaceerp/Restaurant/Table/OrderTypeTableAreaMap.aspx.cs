using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Web.Services;

public partial class OrderTypeTableAreaMap : System.Web.UI.Page
{
    static OrderTypeTableAreaMapping  objClass = new OrderTypeTableAreaMapping();
     static TablemManageMaster  objTable = new TablemManageMaster();
    static AreaManageMaster objModule = new AreaManageMaster();
    static cls_ordertype objordertype = new cls_ordertype();
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
                Session["OrderTypeTableAreaMapping"] = aa;
                objordertype.ddlOperation(objordertype, "Show", "", ddlordertype);
                objModule.ddlOperation(objModule, "dropdown", "", ddlarea);
                objTable.ddlOperation(objTable, "Show", "", ddltable);
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
        ViewState["OrderTypeTableAreaMapping"] = Session["OrderTypeTableAreaMapping"];
        viewstate = Session["OrderTypeTableAreaMapping"].ToString();
    }

    [WebMethod]
    public static string addPagePamster(list list)
    {
        string msg = "";
        try
        {
            if (HttpContext.Current.Session["OrderTypeTableAreaMapping"].ToString() == viewstate)
            {
                // //  assign objects start
                objClass.OrderTypeID = Convert.ToInt32(list.OrderTypeID).ToString();
                objClass.AreaID = Convert.ToInt32(list.AreaID).ToString();
                objClass.TableID = Convert.ToInt32(list.TableID).ToString();
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
            if (HttpContext.Current.Session["OrderTypeTableAreaMapping"].ToString() == viewstate)
            {
                // //  assign objects start
                objClass.OrderTypeTableAreaID = Convert.ToInt32(list.OrderTypeTableAreaID).ToString();
                objClass.OrderTypeID = Convert.ToInt32(list.OrderTypeID).ToString();
                objClass.TableID = Convert.ToInt32(list.TableID).ToString();
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
            objClass.OrderTypeTableAreaID = AccountLedgerID;
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
                magentobj.TableID = Convert.ToInt32(dt.Rows[i]["DineInTablemasterID"].ToString());
                magentobj.OrderTypeID = Convert.ToInt32(dt.Rows[i]["OrderTypeID"].ToString());
                magentobj.AreaID = Convert.ToInt32(dt.Rows[i]["DineAreaMasterID"].ToString());
                magentobj.OrderTypeTableAreaID = Convert.ToInt32(dt.Rows[i]["OrdertypeTableAreaID"].ToString());
                magentobj.AreaName = dt.Rows[i]["AreaName"].ToString();
                magentobj.TableName = dt.Rows[i]["TableName"].ToString();
                magentobj.OrderypeName = dt.Rows[i]["OrderTypeName"].ToString();
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
        public int OrderTypeTableAreaID { get; set; }
        public int TableID { get; set; }
        public int AreaID { get; set; }
        public int OrderTypeID { get; set; }

        public string AreaName { get; set; }
        public string TableName { get; set; }
        public string OrderypeName { get; set; }

    }

    public class mpagemasterlist
    {
        public List<list> mpagemasterobjlist { get; set; }
    }
}
