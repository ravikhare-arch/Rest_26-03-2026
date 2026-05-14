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
public class titem_details_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnItemDetailsID = string.Empty;
    private string objsitemName = string.Empty;
    private string objnItemCategoryID = string.Empty;
    private string objnItemSubCategoryID = string.Empty;
    private string objnItemTypeID = string.Empty;
    private string objsItemMark = string.Empty;
    private string objsWarrentyRemarks = string.Empty;
    private string objbWarrentyRemarks = string.Empty;
    private string objsPromotionRemarks = string.Empty;
    private string objbPromotionRemarks = string.Empty;
    private string objsItemRemarks = string.Empty;
    private string objbItemRemarks = string.Empty;
    private string objsSpecificationRemarks = string.Empty;
    private string objbSpecificationRemarks = string.Empty;
    private string objnSalePrice = string.Empty;
    private string objnAvgSalePrice = string.Empty;
    private string objnLastPurchasePrice = string.Empty;
    private string objnAvgPurchasePrice = string.Empty;
    private string objdtLastPurchase = string.Empty;
    private string objdtLastOrder = string.Empty;
    private string objdtLastSold = string.Empty;
    private string objdtExpiry = string.Empty;
    private string objnConfigID = string.Empty;
    public string nItemDetailsID
    {
        get { return objnItemDetailsID; }
        set { objnItemDetailsID = value; }
    }
    public string sitemName
    {
        get { return objsitemName; }
        set { objsitemName = value; }
    }
    public string nItemCategoryID
    {
        get { return objnItemCategoryID; }
        set { objnItemCategoryID = value; }
    }
    public string nItemSubCategoryID
    {
        get { return objnItemSubCategoryID; }
        set { objnItemSubCategoryID = value; }
    }
    public string nItemTypeID
    {
        get { return objnItemTypeID; }
        set { objnItemTypeID = value; }
    }
    public string sItemMark
    {
        get { return objsItemMark; }
        set { objsItemMark = value; }
    }
    public string sWarrentyRemarks
    {
        get { return objsWarrentyRemarks; }
        set { objsWarrentyRemarks = value; }
    }
    public string bWarrentyRemarks
    {
        get { return objbWarrentyRemarks; }
        set { objbWarrentyRemarks = value; }
    }
    public string sPromotionRemarks
    {
        get { return objsPromotionRemarks; }
        set { objsPromotionRemarks = value; }
    }
    public string bPromotionRemarks
    {
        get { return objbPromotionRemarks; }
        set { objbPromotionRemarks = value; }
    }
    public string sItemRemarks
    {
        get { return objsItemRemarks; }
        set { objsItemRemarks = value; }
    }
    public string bItemRemarks
    {
        get { return objbItemRemarks; }
        set { objbItemRemarks = value; }
    }
    public string sSpecificationRemarks
    {
        get { return objsSpecificationRemarks; }
        set { objsSpecificationRemarks = value; }
    }
    public string bSpecificationRemarks
    {
        get { return objbSpecificationRemarks; }
        set { objbSpecificationRemarks = value; }
    }
    public string nSalePrice
    {
        get { return objnSalePrice; }
        set { objnSalePrice = value; }
    }
    public string nAvgSalePrice
    {
        get { return objnAvgSalePrice; }
        set { objnAvgSalePrice = value; }
    }
    public string nLastPurchasePrice
    {
        get { return objnLastPurchasePrice; }
        set { objnLastPurchasePrice = value; }
    }
    public string nAvgPurchasePrice
    {
        get { return objnAvgPurchasePrice; }
        set { objnAvgPurchasePrice = value; }
    }
    public string dtLastPurchase
    {
        get { return objdtLastPurchase; }
        set { objdtLastPurchase = value; }
    }
    public string dtLastOrder
    {
        get { return objdtLastOrder; }
        set { objdtLastOrder = value; }
    }
    public string dtLastSold
    {
        get { return objdtLastSold; }
        set { objdtLastSold = value; }
    }
    public string dtExpiry
    {
        get { return objdtExpiry; }
        set { objdtExpiry = value; }
    }
    public string nConfigID
    {
        get { return objnConfigID; }
        set { objnConfigID = value; }
    }
    public string   User_Operation(titem_details_Class titem_details_Class, string type)
    {
        SqlCommand cmd = addParameter(titem_details_Class, type, "");
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
    public SqlCommand addParameter(titem_details_Class titem_details_Class, string type, string cond)
    {
        string uid, ConfigID;
        if (Session["uid"] == null)
            uid = "0";
        else
            uid = Session["uid"].ToString();

        ConfigID = "1";
         conn = connobj.makeConnection();
        SqlCommand cmd = new SqlCommand("SP_titem_details", conn); 
        cmd.Parameters.AddWithValue("@nItemDetailsID", titem_details_Class.nItemDetailsID);
        cmd.Parameters.AddWithValue("@sitemName", titem_details_Class.sitemName);
        cmd.Parameters.AddWithValue("@nItemCategoryID", titem_details_Class.nItemCategoryID);
        cmd.Parameters.AddWithValue("@nItemSubCategoryID", titem_details_Class.nItemSubCategoryID);
        cmd.Parameters.AddWithValue("@nItemTypeID", titem_details_Class.nItemTypeID);
        cmd.Parameters.AddWithValue("@sItemMark", titem_details_Class.sItemMark);
        cmd.Parameters.AddWithValue("@sWarrentyRemarks", titem_details_Class.sWarrentyRemarks);
        cmd.Parameters.AddWithValue("@bWarrentyRemarks", titem_details_Class.bWarrentyRemarks);
        cmd.Parameters.AddWithValue("@sPromotionRemarks", titem_details_Class.sPromotionRemarks);
        cmd.Parameters.AddWithValue("@bPromotionRemarks", titem_details_Class.bPromotionRemarks);
        cmd.Parameters.AddWithValue("@sItemRemarks", titem_details_Class.sItemRemarks);
        cmd.Parameters.AddWithValue("@bItemRemarks", titem_details_Class.bItemRemarks);
        cmd.Parameters.AddWithValue("@sSpecificationRemarks", titem_details_Class.sSpecificationRemarks);
        cmd.Parameters.AddWithValue("@bSpecificationRemarks", titem_details_Class.bSpecificationRemarks);
        cmd.Parameters.AddWithValue("@nSalePrice", titem_details_Class.nSalePrice);
        cmd.Parameters.AddWithValue("@nAvgSalePrice", titem_details_Class.nAvgSalePrice);
        cmd.Parameters.AddWithValue("@nLastPurchasePrice", titem_details_Class.nLastPurchasePrice);
        cmd.Parameters.AddWithValue("@nAvgPurchasePrice", titem_details_Class.nAvgPurchasePrice);
        cmd.Parameters.AddWithValue("@dtLastPurchase", titem_details_Class.dtLastPurchase);
        cmd.Parameters.AddWithValue("@dtLastOrder", titem_details_Class.dtLastOrder);
        cmd.Parameters.AddWithValue("@dtLastSold", titem_details_Class.dtLastSold);
        cmd.Parameters.AddWithValue("@dtExpiry", titem_details_Class.dtExpiry);
        cmd.Parameters.AddWithValue("@nConfigID", ConfigID);

        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(titem_details_Class titem_details_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(titem_details_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillDataList(titem_details_Class titem_details_Class, DataList grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(titem_details_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            //if (grd.HeaderRow != null)
            //    grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(titem_details_Class titem_details_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(titem_details_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(titem_details_Class titem_details_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(titem_details_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewtitem_details");
            return ds.Tables["viewtitem_details"];
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
    public DropDownList ddlOperation(titem_details_Class titem_details_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(titem_details_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewtitem_details");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a item_details", "0"));
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
    public DataTable Tabledata(titem_details_Class titem_details_Class, string type, string cond)
    {
        DataTable da = new DataTable();
        try
        {
            da = viewData(titem_details_Class, type, cond);
        }
        catch
        {

        }
        return da;
    }

}
