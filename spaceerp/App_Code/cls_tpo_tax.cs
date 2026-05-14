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
public class tpo_tax_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnPoTaxID = string.Empty;
    private string objnPoID = string.Empty;
    private string objnPoDetID = string.Empty;
    private string objnTaxMasterID = string.Empty;
    private string objnTaxTypeID = string.Empty;
    private string objnTaxValue = string.Empty;
    private string objnTaxableAmount = string.Empty;
    private string objnConfigID = string.Empty;
    public string nPoTaxID
    {
        get { return objnPoTaxID; }
        set { objnPoTaxID = value; }
    }
    public string nPoID
    {
        get { return objnPoID; }
        set { objnPoID = value; }
    }
    public string nPoDetID
    {
        get { return objnPoDetID; }
        set { objnPoDetID = value; }
    }
    public string nTaxMasterID
    {
        get { return objnTaxMasterID; }
        set { objnTaxMasterID = value; }
    }
    public string nTaxTypeID
    {
        get { return objnTaxTypeID; }
        set { objnTaxTypeID = value; }
    }
    public string nTaxValue
    {
        get { return objnTaxValue; }
        set { objnTaxValue = value; }
    }
    public string nTaxableAmount
    {
        get { return objnTaxableAmount; }
        set { objnTaxableAmount = value; }
    }
    public string nConfigID
    {
        get { return objnConfigID; }
        set { objnConfigID = value; }
    }
    public string User_Operation(tpo_tax_Class tpo_tax_Class, string type)
    {
        SqlCommand cmd = addParameter(tpo_tax_Class, type, "");
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
    public SqlCommand addParameter(tpo_tax_Class tpo_tax_Class, string type, string cond)
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
        SqlCommand cmd = new SqlCommand("SP_tpo_tax", conn); cmd.Parameters.AddWithValue("@nPoTaxID", tpo_tax_Class.nPoTaxID);
        cmd.Parameters.AddWithValue("@nPoID", tpo_tax_Class.nPoID);
        cmd.Parameters.AddWithValue("@nPoDetID", tpo_tax_Class.nPoDetID);
        cmd.Parameters.AddWithValue("@nTaxMasterID", tpo_tax_Class.nTaxMasterID);
        cmd.Parameters.AddWithValue("@nTaxTypeID", tpo_tax_Class.nTaxTypeID);
        cmd.Parameters.AddWithValue("@nTaxValue", tpo_tax_Class.nTaxValue);
        cmd.Parameters.AddWithValue("@nTaxableAmount", tpo_tax_Class.nTaxableAmount);
        cmd.Parameters.AddWithValue("@nConfigID", ConfigID);

        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(tpo_tax_Class tpo_tax_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(tpo_tax_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(tpo_tax_Class tpo_tax_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(tpo_tax_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(tpo_tax_Class tpo_tax_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(tpo_tax_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewtpo_tax");
            return ds.Tables["viewtpo_tax"];
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
    public DropDownList ddlOperation(tpo_tax_Class tpo_tax_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(tpo_tax_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewtpo_tax");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a po_tax", "0"));
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
