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
public class titem_property_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnItemPropertyID = string.Empty;
    private string objnItemDetailsID = string.Empty;
    private string objnItemUnitID = string.Empty;
    private string objsBarcode = string.Empty;
    private string objnMinOrderlevel = string.Empty;
    private string objnDeliveryQty = string.Empty;
    private string objnRedeemPoint = string.Empty;
    private string objsVendorName = string.Empty;
    private string objnItemSizeID = string.Empty;
    private string objsColor = string.Empty;
    private string objbTax = string.Empty;
    private string objnTax = string.Empty;
    private string objnTaxMasterID = string.Empty;
    private string objnCessTax = string.Empty;
    private string objnOtherTax = string.Empty;
    private string objnConfigID = string.Empty;
    public string nItemPropertyID
    {
        get { return objnItemPropertyID; }
        set { objnItemPropertyID = value; }
    }
    public string nItemDetailsID
    {
        get { return objnItemDetailsID; }
        set { objnItemDetailsID = value; }
    }
    public string nItemUnitID
    {
        get { return objnItemUnitID; }
        set { objnItemUnitID = value; }
    }
    public string sBarcode
    {
        get { return objsBarcode; }
        set { objsBarcode = value; }
    }
    public string nMinOrderlevel
    {
        get { return objnMinOrderlevel; }
        set { objnMinOrderlevel = value; }
    }
    public string nDeliveryQty
    {
        get { return objnDeliveryQty; }
        set { objnDeliveryQty = value; }
    }
    public string nRedeemPoint
    {
        get { return objnRedeemPoint; }
        set { objnRedeemPoint = value; }
    }
    public string sVendorName
    {
        get { return objsVendorName; }
        set { objsVendorName = value; }
    }
    public string nItemSizeID
    {
        get { return objnItemSizeID; }
        set { objnItemSizeID = value; }
    }
    public string sColor
    {
        get { return objsColor; }
        set { objsColor = value; }
    }
    public string bTax
    {
        get { return objbTax; }
        set { objbTax = value; }
    }
    public string nTax
    {
        get { return objnTax; }
        set { objnTax = value; }
    }
    public string nTaxMasterID
    {
        get { return objnTaxMasterID; }
        set { objnTaxMasterID = value; }
    }
    public string nCessTax
    {
        get { return objnCessTax; }
        set { objnCessTax = value; }
    }
    public string nOtherTax
    {
        get { return objnOtherTax; }
        set { objnOtherTax = value; }
    }
    public string nConfigID
    {
        get { return objnConfigID; }
        set { objnConfigID = value; }
    }
    public string User_Operation(titem_property_Class titem_property_Class, string type)
    {
        SqlCommand cmd = addParameter(titem_property_Class, type, "");
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
    public SqlCommand addParameter(titem_property_Class titem_property_Class, string type, string cond)
    {
        string uid,ConfigID;
        if (Session["uid"] == null)
            uid = "0";
        else
            uid = Session["ConfigID"].ToString();

        if (Session["ConfigID"] == null)
            ConfigID = "0";
        else
            ConfigID = Session["uid"].ToString();

        conn = connobj.makeConnection();
        SqlCommand cmd = new SqlCommand("SP_titem_property", conn); cmd.Parameters.AddWithValue("@nItemPropertyID", titem_property_Class.nItemPropertyID);
        cmd.Parameters.AddWithValue("@nItemDetailsID", titem_property_Class.nItemDetailsID);
        cmd.Parameters.AddWithValue("@nItemUnitID", titem_property_Class.nItemUnitID);
        cmd.Parameters.AddWithValue("@sBarcode", titem_property_Class.sBarcode);
        cmd.Parameters.AddWithValue("@nMinOrderlevel", titem_property_Class.nMinOrderlevel);
        cmd.Parameters.AddWithValue("@nDeliveryQty", titem_property_Class.nDeliveryQty);
        cmd.Parameters.AddWithValue("@nRedeemPoint", titem_property_Class.nRedeemPoint);
        cmd.Parameters.AddWithValue("@sVendorName", titem_property_Class.sVendorName);
        cmd.Parameters.AddWithValue("@nItemSizeID", titem_property_Class.nItemSizeID);
        cmd.Parameters.AddWithValue("@sColor", titem_property_Class.sColor);
        cmd.Parameters.AddWithValue("@bTax", titem_property_Class.bTax);
        cmd.Parameters.AddWithValue("@nTax", titem_property_Class.nTax);
        cmd.Parameters.AddWithValue("@nTaxMasterID", titem_property_Class.nTaxMasterID);
        cmd.Parameters.AddWithValue("@nCessTax", titem_property_Class.nCessTax);
        cmd.Parameters.AddWithValue("@nOtherTax", titem_property_Class.nOtherTax);
        cmd.Parameters.AddWithValue("@nConfigID", ConfigID);

        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(titem_property_Class titem_property_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(titem_property_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(titem_property_Class titem_property_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(titem_property_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(titem_property_Class titem_property_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(titem_property_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewtitem_property");
            return ds.Tables["viewtitem_property"];
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
    public DropDownList ddlOperation(titem_property_Class titem_property_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(titem_property_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewtitem_property");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a item_property", "0"));
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
