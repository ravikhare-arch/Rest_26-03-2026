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

public partial class mairline_list : System.Web.UI.Page
{
    static tchartof_account_Class objClassM = new tchartof_account_Class();
    static mairline_Class objAirline = new mairline_Class();
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
                Session["tchartof_account"] = aa;              
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
        ViewState["tchartof_account"] = Session["tchartof_account"];
        viewstate = Session["tchartof_account"].ToString();
    }

    [WebMethod]
    public static string AddAirline(list list)
    {
        string msg = "";
        try
        {
            if (HttpContext.Current.Session["tchartof_account"].ToString() == viewstate)
            {
                paraAccount(list);
                // //  assign objects start
                var abc = objClassM.User_Operation(objClassM, "add");
                var strArr = abc.Split(',');
                if (strArr[0] == "1")
                {
                    string CAID = strArr[2].ToString();
                    objAirline.nCAccountID = CAID;

                    para(list);
                    var xyz = objAirline.User_Operation(objAirline, "add");

                }
                
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

    public static string paraAccount(list list)
    {
        objClassM.sCode = validation.stringToDBString(list.Code);
        objClassM.nAccountTypeID = "12";
        objClassM.sFirstName = validation.stringToDBString(list.AirlineName);
        //  objClassM.sMidName = validation.stringToDBString(txtMidName.Text.Trim());
        // objClassM.sLastName = validation.stringToDBString(txtLastName.Text.Trim());
        //  objClassM.sFamilyName = validation.stringToDBString(txtFamilyName.Text.Trim());
        objClassM.sAddress = "";
        objClassM.sPhoneNo1 = "";
        //   objClassM.sPhoneNo2 = validation.stringToDBString(txtPhoneNo2.Text.Trim());
        objClassM.sMobileNo = "";
        //   objClassM.sFaxNo = validation.stringToDBString(txtFaxNo.Text.Trim());
        objClassM.sEmailID = "";
        objClassM.sWebsite = "";
        // objClassM.nSalesPersonID = ddlSalesPersonID.SelectedValue;
        objClassM.nCountryID = "0";
        objClassM.nCityID = "0";
        //   objClassM.nAccountCategoryID = ddlAccountCategoryID.SelectedValue;
        objClassM.nCreditLimit = "0";
        //  objClassM.sRemarks = validation.stringToDBString(txtRemarks.Text.Trim());
        //   objClassM.bNotChange = validation.stringToDBString(ddlChangeAllow.SelectedValue);
        objClassM.sGSTNo = "";
        objClassM.nChartOfAccountID = "";
        return list.ToString();
    }

    public static string para(list list) 
    {
        objAirline.sCode = validation.stringToDBString(list.Code);
        objAirline.dtJoiningDate = "";
        objAirline.sAirlineName = validation.stringToDBString(list.AirlineName);
        objAirline.sIATANo = "";
        objAirline.sLicenseNo = "";
        objAirline.sGSTNo = "";
        objAirline.sPanCardNo = "";
        //  objAirline.nLocationID = ddlLocation.SelectedValue;
        objAirline.nOffTele = "";
        objAirline.sAuthorizedPerson = "";
        objAirline.sContactNo = "";
        objAirline.sAddress = "";
        objAirline.nCountryID = "0";
        objAirline.nCityID = "0";
        objAirline.nPincode = "0";
        objAirline.sEmail = "";
        objAirline.sWebsite = "";
        objAirline.nCreditLimit = "0";
        
        objAirline.nStateID = "";
        objAirline.sDesignator = validation.stringToDBString(list.Designator);
        objAirline.sAllience = "";
        return list.ToString();
    }

    [WebMethod]
    public static string UpdateAirline(list list)
    {
        string msg = "";
        try
        {
            if (HttpContext.Current.Session["tchartof_account"].ToString() == viewstate)
            {
                paraAccount(list);
                objClassM.nChartOfAccountID =  list.CAccountID;
                var abc = objClassM.User_Operation(objClassM, "edit");

                para(list);
                objAirline.nAirlineID = list.AirlineID;
                var abc1 = objAirline.User_Operation(objAirline, "edit");


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
    public static string DeleteAirline(string AccountLedgerID)
    {
        string msg = "";
        try
        {
            objAirline.nAirlineID = AccountLedgerID;
            var vres = objAirline.User_Operation(objAirline, "DeActive");
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
            dt = objAirline.Tabledata(objAirline, "ShowGrid", "");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                magentobj = new list();
                magentobj.AirlineID =dt.Rows[i]["nAirlineID"].ToString();
                magentobj.Code = dt.Rows[i]["sCode"].ToString();
                magentobj.AirlineName = dt.Rows[i]["sAirlineName"].ToString();
                magentobj.IATANo = dt.Rows[i]["sIATANo"].ToString();
                magentobj.CAccountID = dt.Rows[i]["nCAccountID"].ToString();
                magentobj.Designator = dt.Rows[i]["sDesignator"].ToString();
                mainlist.muserobjlist.Add(magentobj);
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
        public string AirlineID { get; set; }
        public string Code { get; set; }
        public string AirlineName { get; set; }
        public string IATANo { get; set; }
        public string Designator { get; set; }
        public string CAccountID { get; set; }
       
    }

    public class muserlist
    {
        public List<list> muserobjlist { get; set; }
    }
}
