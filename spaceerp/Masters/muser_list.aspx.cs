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

public partial class muser : System.Web.UI.Page
{
    static muser_Class objClass = new muser_Class();
    muser_role_Class objrole = new muser_role_Class();
    validation valobj = new validation();
    muser_type_Class objUserType = new muser_type_Class();
    mdepartment_Class objDept = new mdepartment_Class();
    mlocation_Class objLoc = new mlocation_Class();
    public static string viewstate;
    string cond;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                // Fillddl.FillPageddl(ddlPageSize);
                objUserType.ddlOperation(objUserType, "Show", "", ddlusertype);
                objLoc.ddlOperation(objLoc, "Show", "", ddllocation);
                objDept.ddlOperation(objDept, "Show", "", ddldepartment);
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
                // //  assign objects start
                objClass.susername = validation.stringToDBString(list.UserName);
                objClass.spassword = validation.stringToDBString(list.Password);
                objClass.sUserFullName = validation.stringToDBString(list.UserFullName);
                objClass.nUserTypeID = validation.stringToDBString(list.UserTypeID);
                objClass.nDepartmentID = validation.stringToDBString(list.DepartmentID);
                objClass.nLocationID = validation.stringToDBString(list.LocationID);
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
    public static string UpdateUser(list list)
    {
        string msg = "";
        try
        {
            if (HttpContext.Current.Session["muser"].ToString() == viewstate)
            {
                // //  assign objects start
                objClass.susername = validation.stringToDBString(list.UserName);
                objClass.spassword = validation.stringToDBString(list.Password);
                objClass.sUserFullName = validation.stringToDBString(list.UserFullName);
                objClass.nUserTypeID = validation.stringToDBString(list.UserTypeID);
                objClass.nDepartmentID = validation.stringToDBString(list.DepartmentID);
                objClass.nLocationID = validation.stringToDBString(list.LocationID);
                objClass.nuserid = Convert.ToInt32(list.UserID).ToString();
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
    public static string DeleteUser(string AccountLedgerID)
    {
        string msg = "";
        try
        {
            objClass.nuserid = AccountLedgerID;
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
            dt = objClass.Tabledata(objClass, "ShowGrid", "");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                magentobj = new list();
                magentobj.UserID = Convert.ToInt32(dt.Rows[i]["nLoginId"].ToString());
                magentobj.UserFullName = dt.Rows[i]["sUserFullName"].ToString();
                magentobj.Department = dt.Rows[i]["sDepartmentName"].ToString();
                magentobj.UserType = dt.Rows[i]["sUserType"].ToString();
                magentobj.Location = dt.Rows[i]["sLocationName"].ToString();
                magentobj.Password = dt.Rows[i]["sPassword"].ToString();
                magentobj.UserName = dt.Rows[i]["sLogin"].ToString();
                magentobj.DepartmentID = dt.Rows[i]["nDepartmentID"].ToString();
                magentobj.UserTypeID = dt.Rows[i]["nUserTypeID"].ToString();
                magentobj.LocationID = dt.Rows[i]["nLocationID"].ToString();
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
            objClass.nuserid = agencyid;
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
    public class list
    {
        public int UserID { get; set; }
        public string UserFullName { get; set; }
        public string Password { get; set; }
        public string UserTypeID { get; set; }
        public string DepartmentID { get; set; }
        public string LocationID { get; set; }
        public string UserType { get; set; }
        public string Department { get; set; }
        public string Location { get; set; }
        public string UserName { get; set; } 
    }

    public class muserlist
    {
        public List<list> muserobjlist { get; set; }
    }
}
