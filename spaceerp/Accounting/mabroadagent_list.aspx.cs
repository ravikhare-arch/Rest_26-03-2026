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

public partial class mabroadagent_list : System.Web.UI.Page
{

    static mabroadagent_Class objClient = new mabroadagent_Class();
    static msupgst_Class objclntGst = new msupgst_Class();
    static mcity_Class objCity = new mcity_Class();
    static mCountry_Class objCountry = new mCountry_Class();
    static mstate_Class objState = new mstate_Class();

    static mcity_Class objvendorCity = new mcity_Class();
    static mCountry_Class objvendorCountry = new mCountry_Class();
    static mstate_Class objvendorState = new mstate_Class();
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
                objCountry.ddlOperation(objCountry, "Show", "", ddlCountryID);
                objState.ddlOperation(objState, "Showddl", "", ddlState);
                objCity.ddlOperation(objCity, "Showddl", "", ddlCityID);
                objvendorCountry.ddlOperation(objvendorCountry, "Show", "", ddlvendorcountryid);
                objvendorState.ddlOperation(objvendorState, "Showddl", "", ddlvendorstate);
                objvendorCity.ddlOperation(objvendorCity, "Showddl", "", ddlvendorcity);
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
    public static string AddClient(list list)
    {
        string msg = "";
        try
        {
            if (HttpContext.Current.Session["tchartof_account"].ToString() == viewstate)
            {

                string CAID = "0";
                HttpContext.Current.Session["CAID"] = CAID;
                objClient.nCAccountID = CAID;
                para(list);
                var xyz = objClient.User_Operation(objClient, "add");
                var strArr = xyz.Split(',');
              
                string val1 = strArr[0];
                if (val1 == "1")
                {
                    msg = "1";
                }
                else
                {
                    msg = xyz.ToString();
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


    public static string para(list list)
    {
        objClient.sSupplierCode = validation.stringToDBString(list.Code);
        objClient.sAgencyName = validation.stringToDBString(list.AgencyName);
        objClient.sIATANo = validation.stringToDBString(list.IATANo);
        objClient.sLicenseNo = validation.stringToDBString(list.LicenseNo);
        objClient.sGSTNo = validation.stringToDBString(list.GSTNo);
        objClient.sPanCardNo = validation.stringToDBString(list.PANno);
        //  objClient.nLocationID = ddlLocation.SelectedValue;
    
        objClient.sAuthorizedPerson = validation.stringToDBString(list.AuthorisedPerson);
        objClient.sAddress = "";
        objClient.nCountryID = "0";
        objClient.nCityID = "0";
        objClient.nStateID = "0";
        

        objClient.VendorAddress = list.VendorAddress;
        objClient.VendorCountryID = list.VendorCountryID;
        objClient.VendorStateID = list.VendorStateID;
        objClient.VendorCityID = list.VendorCityID;
       

        return list.ToString();
    }


    [WebMethod]
    public static string UpdateClient(list list)
    {
        string msg = "";
        try
        {
            if (HttpContext.Current.Session["tchartof_account"].ToString() == viewstate)
            {

                para(list);
                objClient.nSupplierID = list.ClientID;
                objClient.nCAccountID = list.CAccountID;
                var abc1 = objClient.User_Operation(objClient, "edit");


                //  valobj.showMsg(abc, lblmsg);
                string[] values = abc1.Split(',');
                string val1 = values[0];
                if (val1 == "1")
                {
                    msg = "1";
                }
                else
                {
                    msg = abc1.ToString();
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
    public static string DeleteClient(string AccountLedgerID)
    {
        string msg = "";
        try
        {
            objClient.nSupplierID = AccountLedgerID;
            var vres = objClient.User_Operation(objClient, "DeActive");
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
            dt = objClient.Tabledata(objClient, "show", "");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                magentobj = new list();
                magentobj.ClientID = dt.Rows[i]["nAbroadAgentID"].ToString();
                magentobj.Code = dt.Rows[i]["sSupplierCode"].ToString();
                magentobj.AgencyName = dt.Rows[i]["sAgencyName"].ToString();
                magentobj.IATANo = dt.Rows[i]["sIATANo"].ToString();
                magentobj.LicenseNo = dt.Rows[i]["sLicenseNo"].ToString();
                magentobj.GSTNo = dt.Rows[i]["sGSTNo"].ToString();
                magentobj.PANno = dt.Rows[i]["sPanCardNo"].ToString();
                magentobj.CAccountID = dt.Rows[i]["nCAccountID"].ToString();

                magentobj.Address = dt.Rows[i]["sAddress"].ToString();
                magentobj.CountryID = dt.Rows[i]["nCountryID"].ToString();
                magentobj.StateID = dt.Rows[i]["nStateID"].ToString();
                magentobj.CityID = dt.Rows[i]["nCityID"].ToString();
                magentobj.Pincode = dt.Rows[i]["nPincode"].ToString();
                magentobj.AuthorisedPerson = dt.Rows[i]["sAuthorizedPerson"].ToString();
                magentobj.ContactNo = dt.Rows[i]["sContactNo"].ToString();
                magentobj.Email = dt.Rows[i]["sEmail"].ToString();
                magentobj.Website = dt.Rows[i]["sWebsite"].ToString();
                magentobj.Creditlimit = dt.Rows[i]["nCreditLimit"].ToString();

                magentobj.VendorContactNo = dt.Rows[i]["sVendorContactno"].ToString();
                magentobj.VendorAddress = dt.Rows[i]["sVendorAddress"].ToString();
                magentobj.VendorCountryID = dt.Rows[i]["nVendorCountryID"].ToString();
                magentobj.VendorStateID = dt.Rows[i]["nVendorStateID"].ToString();
                magentobj.VendorCityID = dt.Rows[i]["nVendorCityID"].ToString();
                magentobj.VendorEmail = dt.Rows[i]["sVendorEmail"].ToString();
                magentobj.VendorPincode = dt.Rows[i]["nVendorPincode"].ToString();
                magentobj.VendorLongitude = dt.Rows[i]["sVendorLongtit"].ToString();
                magentobj.VendorLatitude = dt.Rows[i]["sVendorLatit"].ToString();
                magentobj.Longitude = dt.Rows[i]["sLongitude"].ToString();
                magentobj.Latitude = dt.Rows[i]["sLatitude"].ToString();
                DataTable dtclntGst = objclntGst.viewData(objclntGst, "show", magentobj.CAccountID);
                if (dtclntGst.Rows.Count > 0)
                {
                    magentobj.SGST = dtclntGst.Rows[0][4].ToString();
                    magentobj.CGST = dtclntGst.Rows[0][3].ToString();
                    magentobj.IGST = dtclntGst.Rows[0][2].ToString();

                }
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
        public string ClientID { get; set; }
        public string Code { get; set; }
        public string AgencyName { get; set; }
        public string IATANo { get; set; }
        public string LicenseNo { get; set; }
        public string GSTNo { get; set; }
        public string PANno { get; set; }
        public string Address { get; set; }
        public string CountryID { get; set; }
        public string StateID { get; set; }
        public string CityID { get; set; }
        public string Pincode { get; set; }
        public string AuthorisedPerson { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Creditlimit { get; set; }
        public string SGST { get; set; }
        public string CGST { get; set; }
        public string IGST { get; set; }
        public string ClntGstID { get; set; }
        public string CAccountID { get; set; }

        public string VendorContactNo { get; set; }
        public string VendorAddress { get; set; }
        public string VendorCountryID { get; set; }
        public string VendorStateID { get; set; }
        public string VendorCityID { get; set; }
        public string VendorPincode { get; set; }
        public string VendorEmail { get; set; }
        public string VendorLatitude { get; set; }
        public string VendorLongitude { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }

    public class muserlist
    {
        public List<list> muserobjlist { get; set; }
    }
}
