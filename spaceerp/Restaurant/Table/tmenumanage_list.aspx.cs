using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Services;
//using MailSMS;


using System.Net.Mail;

public partial class tmenumanage_list : System.Web.UI.Page
{
    static tmenumanage_Class objClass = new tmenumanage_Class();
    cls_ordertype objordertype = new cls_ordertype();
    validation valobj = new validation();
    string cond;
    public static string viewstate;
    SmtpClient sc = new SmtpClient();
    SendMail objsendmail = new SendMail();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            objordertype.ddlOperation(objordertype, "Show", "", ddlDeliveryType);
        }
    }
    //public void Page_PreRender(object sender, EventArgs e)
    //{
    //    ViewState["tsalesdebitnote"] = Session["tsalesdebitnote"];
    //    viewstate = Session["tsalesdebitnote"].ToString();
    //}


    [WebMethod]
    public static mpagemasterlist loaddata(int deliveryType,string acnonac)
    {
        list magentobj = new list();
        list magentobjnew = new list();
        mpagemasterlist mainlist = new mpagemasterlist();
        mainlist.mpagemasterobjlist = new List<list>();
        mainlist.mpagemasterobjlistnew = new List<list>();
        DataTable dt = new DataTable();
        try
        {
            if (acnonac != "0" && acnonac != "" && acnonac != null)
            {
                objClass.ACNONAC = acnonac;
            }
            else
            {
                objClass.ACNONAC = "0";
            }
            //objClass.StartDate = validation.dateToText(fromdate);
            //objClass.EndDate = validation.dateToText(todate);
            objClass.DeliveryType = deliveryType;
            objClass.ACNONAC = acnonac;
            dt = objClass.Tabledata(objClass, "Show", "");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                magentobj = new list();
                magentobj.ProductCode = dt.Rows[i]["sProductCode"].ToString();
                magentobj.Product = dt.Rows[i]["sProduct"].ToString();
                magentobj.CategoryID = dt.Rows[i]["nCategoryID"].ToString();
                magentobj.FoodTypeID = dt.Rows[i]["nFoodTypeID"].ToString();
                magentobj.Price = dt.Rows[i]["nPrice"].ToString();
                magentobj.ActualCost = dt.Rows[i]["nActualCost"].ToString();
                magentobj.MenuID = dt.Rows[i]["ItemMasterID"].ToString();
                magentobj.NetPayable = dt.Rows[i]["GSTCost"].ToString();
                magentobj.SGST = dt.Rows[i]["SGST"].ToString();
                magentobj.CGST = dt.Rows[i]["CGST"].ToString();
                magentobj.GroupName = dt.Rows[i]["GroupName"].ToString();
                magentobj.DeliveryType = dt.Rows[i]["DeliveryType"].ToString();
                mainlist.mpagemasterobjlist.Add(magentobj);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return mainlist;
    }
    //[WebMethod]
    //public static string DeleteVoucher(string AccountLedgerID)
    //{
    //    string msg = "";
    //    try
    //    {
    //        objClass.MenuID = AccountLedgerID;
    //        var vres = objClass.User_Operation(objClass, "Delete");
    //        string[] values = vres.Split(',');
    //        string val1 = values[0];
    //        if (val1 == "1")
    //        {
    //            msg = val1;
    //        }
    //        else
    //        {
    //            msg = vres;
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        msg = ex.Message.ToString();
    //    }



    //    return msg;
    //}
    [WebMethod]
    public static string DeleteVoucher(string AccountLedgerID)
    {
        string msg = "";
        try
        {
            // Yahan MenuID hi wo primary key hai jispe delete chalega
            objClass.MenuID = AccountLedgerID;
            var vres = objClass.User_Operation(objClass, "Delete");
            msg = vres.Split(',')[0]; // Agar success hai to "1" return karega
        }
        catch (Exception ex) { msg = ex.Message; }
        return msg;
    }
    [WebMethod]
    public static string MarkInactive(string agencyid)
    {
        string msg = "";
        try
        {
            objClass.MenuID = agencyid;
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
    public static string MarkActive(string agencyid)
    {
        string msg = "";
        try
        {
            objClass.MenuID = agencyid;
            var vres = objClass.User_Operation(objClass, "Active");
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
    public string date(string getdt)
    {
        string month, date, year;
        string returnval = string.Empty;
        if (getdt != "")
        {
            string dt = getdt;
            year = dt.Substring(0, 4);
            month = dt.Substring(4, 2);
            date = dt.Substring(6, 2);
            returnval = date + '-' + month + '-' + year;
            return returnval;
        }
        return returnval;
    }

    public class list
    {
        public string MenuID { get; set; }
        public string Product { get; set; }
        public string ProductCode { get; set; }
        public string CategoryID { get; set; }
        public string FoodTypeID { get; set; }
        public string Price { get; set; }
        public string ActualCost { get; set; }
        public string ApplyOffer { get; set; }
        public string NetPayable { get; set; }
        public string CGST { get; set; }
        public string SGST { get; set; }
        public string GroupName { get; set; }
        public string DeliveryType { get; set; }
    }

    public class mpagemasterlist
    {
        public List<list> mpagemasterobjlist { get; set; }
        public List<list> mpagemasterobjlistnew { get; set; }
    }


    protected void lnkAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("tmenumanage.aspx");
    }
    protected void ddlDeliveryType_selected(object sender, EventArgs e)
    {
        if (ddlDeliveryType.SelectedValue == "3" )
        {
            trac.Visible = true;
        }
        else
        {
            trac.Visible = false;
        }
    }
}
