using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

public class mcreditcardpos_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objCreditCardID = string.Empty;
    private string objCreditCardCode = string.Empty;
    private string objCreditCardName = string.Empty;
    private string objCurrencyID = string.Empty;
    private string objMainLedger = string.Empty;
    private string objDescription = string.Empty;
   
    public string CreditCardID
    {
        get { return objCreditCardID; }
        set { objCreditCardID = value; }
    }
    public string CreditCardCode
    {
        get { return objCreditCardCode; }
        set { objCreditCardCode = value; }
    }
    public string CreditCardName
    {
        get { return objCreditCardName; }
        set { objCreditCardName = value; }
    }
    public string CurrencyID
    {
        get { return objCurrencyID; }
        set { objCurrencyID = value; }
    }
    public string MainLedger
    {
        get { return objMainLedger; }
        set { objMainLedger = value; }
    }
    public string Description
    {
        get { return objDescription; }
        set { objDescription = value; }
    }
    public string User_Operation(mcreditcardpos_Class mcreditcardpos_Class, string type)
    {
        SqlCommand cmd = addParameter(mcreditcardpos_Class, type, "");
        try
        {
            //cmd.ExecuteNonQuery();
            returnValue = cmd.ExecuteScalar().ToString();
        }
        catch (Exception ex)
        {
            //throw;
            returnValue = ex.Message.ToString();
        }
        finally
        {
            cmd.Dispose();
            conn = connobj.closeConnection();
        }
        return returnValue;
    }
    public SqlCommand addParameter(mcreditcardpos_Class mcreditcardpos_Class, string type, string cond)
    {
        string uid, nConfigID;
        if (Session["uid"] == null)
            uid = "0";
        else
            uid = Session["uid"].ToString();

        if (Session["ConfigID"] == null)
            nConfigID = "0";
        else
            nConfigID = Session["ConfigID"].ToString();
        conn = connobj.makeConnection();
        SqlCommand cmd = new SqlCommand("SP_mcurrency", conn); cmd.Parameters.AddWithValue("@nCurrencyID", mcreditcardpos_Class.CreditCardID);
        cmd.Parameters.AddWithValue("@sCurrencyName", mcreditcardpos_Class.CreditCardCode);
        cmd.Parameters.AddWithValue("@sCurrencyCode", mcreditcardpos_Class.objCreditCardName);
        cmd.Parameters.AddWithValue("@nSellingPrice", mcreditcardpos_Class.objCurrencyID);
        cmd.Parameters.AddWithValue("@nBuyingPrice", mcreditcardpos_Class.objMainLedger);
        //cmd.Parameters.AddWithValue("@nCountryID", mcreditcardpos_Class);
        cmd.Parameters.AddWithValue("@nConfigID", nConfigID);

        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(mcreditcardpos_Class mcreditcardpos_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(mcreditcardpos_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(mcreditcardpos_Class mcreditcardpos_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(mcreditcardpos_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(mcreditcardpos_Class mcreditcardpos_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(mcreditcardpos_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewmcurrency");
            return ds.Tables["viewmcurrency"];
        }
        catch
        {
            throw;
        }
        finally
        {
            cmd.Dispose();
            conn = connobj.closeConnection();
        }
    }
    public DropDownList ddlOperation(mcreditcardpos_Class mcreditcardpos_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(mcreditcardpos_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewmcurrency");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a currency", "0"));
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ddl.Items.Add(new ListItem(ds.Tables[0].Rows[i][1].ToString(), ds.Tables[0].Rows[i][0].ToString()));
            }
        }
        else
        {
            ddl.Items.Add(new ListItem("Not Found", "0"));
        }
        cmd.Dispose();
        conn = connobj.closeConnection();
        return ddl;
    }

}