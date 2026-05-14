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
using System.Web.Script.Serialization;

public partial class Transcation_chartof_account_Test : System.Web.UI.Page
{
    static maccountledger_Class objClass = new maccountledger_Class();



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
                Session["tchartof_account_Test"] = aa;
                
             
                
                
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
        ViewState["tchartof_account_Test"] = Session["tchartof_account_Test"];
        viewstate = Session["tchartof_account_Test"].ToString();
    }

    [WebMethod]
    public static List<ChartOfGroup> GetGroup()
    {
        List<ChartOfGroup> cog = new List<ChartOfGroup>();
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        ChartOfGroup cg;
        DataTable dtcgroup = new DataTable();
        
        dtcgroup = objClass.DropDown("ChartofAccGroup", "");
        foreach(DataRow row in dtcgroup.Rows)
        {
            cg = new ChartOfGroup {
                GroupId=Convert.ToString(row["nSubAccountID"]),
                GroupName= Convert.ToString(row["sSubAccount"])
            };
            cog.Add(cg);
        }
        return cog;
       // return serializer.Serialize(cog);
    }

    [WebMethod]
    public static AccountFamily GetAccountFamily(string subAccountID)
    {
        List<AccountFamily> accountFamilies = new List<AccountFamily>();
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        AccountFamily accountFaimly=null;
        DataTable dtcgroup = new DataTable();
        objClass.SubAccountID = subAccountID;
        dtcgroup = objClass.DropDown("FAMILYBASEDONGROUP", "");
        //foreach (DataRow row in dtcgroup.Rows)
        //{
        if (dtcgroup.Rows.Count > 0)
        {
            accountFaimly = new AccountFamily
            {
                FamilyId = Convert.ToString(dtcgroup.Rows[0]["nfamilyid"]),
                FamilyName = Convert.ToString(dtcgroup.Rows[0]["sfamily"])
            };
        }
        // accountFamilies.Add(accountFaimly);
        //}
        return accountFaimly;
            //serializer.Serialize(accountFaimly);
            // return accountFailies;
    }

    [WebMethod]
    public static List<AccountCategory> GetAccountCategory()
    {
        List<AccountCategory> accountCategories = new List<AccountCategory>();
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        AccountCategory accountCategory;
        DataTable dtcgroup = new DataTable();
        dtcgroup = objClass.DropDown("ACCOUNTCATEGORY", "");
        foreach (DataRow row in dtcgroup.Rows)
        {
            accountCategory = new AccountCategory
            {
                CategoryId = Convert.ToString(row["nAccountCategoryid"]),
                CategoryName = Convert.ToString(row["sAccountCategory"])
            };
            accountCategories.Add(accountCategory);
        }
        return accountCategories;
        //return serializer.Serialize(accountCategories);
    }
    [WebMethod]
    public static string addledger(list list)
    {
        string msg = "";
        try
        {
            if (HttpContext.Current.Session["tchartof_account_Test"].ToString() == viewstate)
            {
                // //  assign objects start
                objClass.Name = validation.stringToDBString(list.Name);
                objClass.Code = validation.stringToDBString(list.Code);
                objClass.AccountGroupID = validation.stringToDBString(list.AccountGroupID);
                objClass.Type = validation.stringToDBString(list.Type);
                objClass.Nature = validation.stringToDBString(list.Nature);
                var abc = objClass.User_Operation(objClass, "add");
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
        finally
        {
        }
        return msg;
    }

    [WebMethod]
    public static string updateagent(list list)
    {
        string msg = "";
        try
        {
            if (HttpContext.Current.Session["tchartof_account_Test"].ToString() == viewstate)
            {
                // //  assign objects start
                objClass.Name = validation.stringToDBString(list.Name);
                objClass.Code = validation.stringToDBString(list.Code);
                objClass.AccountGroupID = validation.stringToDBString(list.AccountGroupID);
                objClass.Type = validation.stringToDBString(list.Type);
                objClass.Nature = validation.stringToDBString(list.Nature);
                objClass.AccountLedgerID = Convert.ToInt32(list.AccountLedgerID).ToString();
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


    // // delete function
    [WebMethod]
    public static string DeleteLedger(string AccountLedgerID)
    {
        string msg = "";
        try
        {
            objClass.AccountLedgerID = AccountLedgerID;
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
    public static maccountledgerlist loaddata()
    {
        list magentobj = new list();
        maccountledgerlist mainlist = new maccountledgerlist();
        mainlist.maccountledgerobjlist = new List<list>();
        DataTable dt = new DataTable();
        try
        {
            dt = objClass.Tabledata(objClass, "Showgrid", "");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                magentobj = new list();
                magentobj.AccountLedgerID = Convert.ToInt32(dt.Rows[i]["nAccountLedgerID"].ToString());
                magentobj.Name = dt.Rows[i]["sName"].ToString();
                magentobj.Code = dt.Rows[i]["sCode"].ToString();
                magentobj.AccountGroupID =dt.Rows[i]["sAccountGroup"].ToString();
                magentobj.Type = dt.Rows[i]["sType"].ToString();
                magentobj.Nature = dt.Rows[i]["sNature"].ToString();
                mainlist.maccountledgerobjlist.Add(magentobj);
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
        public int AccountLedgerID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string AccountGroupID { get; set; }
        public string Type { get; set; }
        public string Nature { get; set; }       
    }

     public class maccountledgerlist
    {
        public List<list> maccountledgerobjlist { get; set; }
    }

    public class ChartOfGroup
    {
        public string GroupId { get; set; }
        public string GroupName { get; set; }

    }

    public class AccountCategory
    {
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
    public class AccountFamily
    {
        public string FamilyId { get; set; }
        public string FamilyName { get; set; }
    }
}
