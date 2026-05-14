using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Web.Services;

public partial class CompanyMaster : System.Web.UI.Page
{
    static ManageCompany  objClass = new ManageCompany(); 
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
                Session["TableMaster"] = aa;
               
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
        ViewState["TableMaster"] = Session["TableMaster"];
        viewstate = Session["TableMaster"].ToString();
    }

    [WebMethod]
    public static string addPagePamster(list list)
    {
        string msg = "";
        try
        {
            if (HttpContext.Current.Session["TableMaster"].ToString() == viewstate)
            {
                // //  assign objects start
                objClass.Name = validation.stringToDBString(list.Name);
                objClass.Address = validation.stringToDBString(list.Address);
                objClass.City = validation.stringToDBString(list.City);
                objClass.PinCode = validation.stringToDBString(list.PinCode);
                objClass.Contactno = validation.stringToDBString(list.Contactno);
                objClass.GSTNo = validation.stringToDBString(list.GSTNo);
                objClass.CaptainName = validation.stringToDBString(list.CaptainName);
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
            if (HttpContext.Current.Session["TableMaster"].ToString() == viewstate)
            {
                // //  assign objects start
                objClass.Name = validation.stringToDBString(list.Name);
                objClass.Address = validation.stringToDBString(list.Address);
                objClass.City = validation.stringToDBString(list.City);
                objClass.PinCode = validation.stringToDBString(list.PinCode);
                objClass.Contactno = validation.stringToDBString(list.Contactno);
                objClass.GSTNo = validation.stringToDBString(list.GSTNo);
                objClass.CaptainName = validation.stringToDBString(list.CaptainName);
                objClass.CompanyID = validation.stringToDBString(list.CompanyID);
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
            objClass.CompanyID = AccountLedgerID;
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
                magentobj.CompanyID = dt.Rows[i]["ID"].ToString();
                magentobj.Name = dt.Rows[i]["CompanyName"].ToString();
                magentobj.Address = dt.Rows[i]["Addrees"].ToString();
                magentobj.City = dt.Rows[i]["City"].ToString();
                magentobj.PinCode = dt.Rows[i]["PinCode"].ToString();
                magentobj.Contactno = dt.Rows[i]["ContactNumber"].ToString();
                magentobj.GSTNo = dt.Rows[i]["GSTNumber"].ToString();
                magentobj.CaptainName = dt.Rows[i]["CaptainName"].ToString();
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
        public string CompanyID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PinCode { get; set; }
        public string Contactno { get; set; }
        public string GSTNo { get; set; }
        public string CaptainName { get; set; }
    }

    public class mpagemasterlist
    {
        public List<list> mpagemasterobjlist { get; set; }
    }
}
