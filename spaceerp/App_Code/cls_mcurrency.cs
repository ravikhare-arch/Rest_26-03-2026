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
public class mcurrency_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnCurrencyID = string.Empty;
    private string objsCurrencyName = string.Empty;
    private string objsCurrencyCode = string.Empty;
    private string objnSellingPrice = string.Empty;
    private string objnBuyingPrice = string.Empty;
    private string objnCountryID = string.Empty;
    private string objnConfigID = string.Empty;
    public string nCurrencyID
    {
        get { return objnCurrencyID; }
        set { objnCurrencyID = value; }
    }
    public string sCurrencyName
    {
        get { return objsCurrencyName; }
        set { objsCurrencyName = value; }
    }
    public string sCurrencyCode
    {
        get { return objsCurrencyCode; }
        set { objsCurrencyCode = value; }
    }
    public string nSellingPrice
    {
        get { return objnSellingPrice; }
        set { objnSellingPrice = value; }
    }
    public string nBuyingPrice
    {
        get { return objnBuyingPrice; }
        set { objnBuyingPrice = value; }
    }
    public string nCountryID
    {
        get { return objnCountryID; }
        set { objnCountryID = value; }
    }
    public string User_Operation(mcurrency_Class mcurrency_Class, string type)
    {
        SqlCommand cmd = addParameter(mcurrency_Class, type, "");
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
    public SqlCommand addParameter(mcurrency_Class mcurrency_Class, string type, string cond)
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
        SqlCommand cmd = new SqlCommand("SP_mcurrency", conn); cmd.Parameters.AddWithValue("@nCurrencyID", mcurrency_Class.nCurrencyID);
        cmd.Parameters.AddWithValue("@sCurrencyName", mcurrency_Class.sCurrencyName);
        cmd.Parameters.AddWithValue("@sCurrencyCode", mcurrency_Class.sCurrencyCode);
        cmd.Parameters.AddWithValue("@nSellingPrice", mcurrency_Class.nSellingPrice);
        cmd.Parameters.AddWithValue("@nBuyingPrice", mcurrency_Class.nBuyingPrice);
        cmd.Parameters.AddWithValue("@nCountryID", mcurrency_Class.nCountryID);
        cmd.Parameters.AddWithValue("@nConfigID", nConfigID);

        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(mcurrency_Class mcurrency_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(mcurrency_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(mcurrency_Class mcurrency_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(mcurrency_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(mcurrency_Class mcurrency_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(mcurrency_Class, type, cond);
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
    public DropDownList ddlOperation(mcurrency_Class mcurrency_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(mcurrency_Class, Type, cond);
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
