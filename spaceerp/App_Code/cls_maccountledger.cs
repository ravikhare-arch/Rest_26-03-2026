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
public class maccountledger_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objAccountLedgerID = string.Empty;
    private string objName = string.Empty;
    private string objCode = string.Empty;
    private string objAccountGroupID = string.Empty;
    private string objType = string.Empty;
    private string objNature = string.Empty;
    private string objnConfigID = string.Empty;
   
    public string AccountLedgerID
    {
        get { return objAccountLedgerID; }
        set { objAccountLedgerID = value; }
    }
    public string Name
    {
        get { return objName; }
        set { objName = value; }
    }
    public string Code
    {
        get { return objCode; }
        set { objCode = value; }
    }
    public string AccountGroupID
    {
        get { return objAccountGroupID; }
        set { objAccountGroupID = value; }
    }
    public string Type
    {
        get { return objType; }
        set { objType = value; }
    }
    public string Nature
    {
        get { return objNature; }
        set { objNature = value; }
    }
    public string ConfigID
    {
        get { return objnConfigID; }
        set { objnConfigID = value; }
    }
    public string SubAccountID { get; set; }

    public string User_Operation(maccountledger_Class maccountledger_Class, string type)
    {
        SqlCommand cmd = addParameter(maccountledger_Class, type, "");
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
    public SqlCommand addParameter(maccountledger_Class maccountledger_Class, string type, string cond)
    {
        string uid, ConfigID;
        if (Session["uid"] == null)
            uid = "0";
        else
            uid = Session["uid"].ToString();

        if (Session["ConfigID"] == null)
            ConfigID = "0";
        else
            ConfigID = Session["ConfigID"].ToString();

        conn = connobj.makeConnection();
        SqlCommand cmd = new SqlCommand("SP_maccountledger", conn);
        cmd.Parameters.AddWithValue("@AccountLedgerID", maccountledger_Class.AccountLedgerID);
        cmd.Parameters.AddWithValue("@Name", maccountledger_Class.Name);
        cmd.Parameters.AddWithValue("@Code", maccountledger_Class.Code);
        cmd.Parameters.AddWithValue("@AccountGroupID", maccountledger_Class.AccountGroupID);
        cmd.Parameters.AddWithValue("@AccountType", maccountledger_Class.Type);
        cmd.Parameters.AddWithValue("@Nature", maccountledger_Class.Nature);

        cmd.Parameters.AddWithValue("@nConfigID", ConfigID);
        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.Parameters.AddWithValue("@SubAccountID", SubAccountID);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(maccountledger_Class maccountledger_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(maccountledger_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(maccountledger_Class maccountledger_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(maccountledger_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
   
    public DataTable viewData(maccountledger_Class maccountledger_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(maccountledger_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewmsubadmin");
            return ds.Tables["viewmsubadmin"];
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
                     
    public DataTable Tabledata(maccountledger_Class maccountledger_Class, string type, string cond)
    {
        DataTable da = new DataTable();
        try
        {
            da = viewData(maccountledger_Class, type, cond);
            //grd.DataSource = da;
            //grd.DataBind();
            //if (grd.HeaderRow != null)
            //    grd.HeaderRow.TableSection = TableRowSection.TableHeader;

        }
        catch
        {

        }
        return da;
    }

    public DataTable DropDown(string type,string cond)
    {
        DataTable da = new DataTable();
        try
        {
            da = viewData(this, type, cond);
        }
        catch (Exception ex)
        {

            //throw;
        }
        return da;
    }
}
