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
public class mitem_sub_category_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnItemSubCategoryID = string.Empty;
    private string objnItemCategoryID = string.Empty;
    private string objsSerialNo = string.Empty;
    private string objsItemSubCategory = string.Empty;
    private string objnConfigID = string.Empty;
    public string nItemSubCategoryID
    {
        get { return objnItemSubCategoryID; }
        set { objnItemSubCategoryID = value; }
    }
    public string nItemCategoryID
    {
        get { return objnItemCategoryID; }
        set { objnItemCategoryID = value; }
    }
    public string sSerialNo
    {
        get { return objsSerialNo; }
        set { objsSerialNo = value; }
    }
    public string sItemSubCategory
    {
        get { return objsItemSubCategory; }
        set { objsItemSubCategory = value; }
    }
    public string nConfigID
    {
        get { return objnConfigID; }
        set { objnConfigID = value; }
    }
    public string User_Operation(mitem_sub_category_Class mitem_sub_category_Class, string type)
    {
        SqlCommand cmd = addParameter(mitem_sub_category_Class, type, "");
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
    public SqlCommand addParameter(mitem_sub_category_Class mitem_sub_category_Class, string type, string cond)
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
        SqlCommand cmd = new SqlCommand("SP_mitem_sub_category", conn); cmd.Parameters.AddWithValue("@nItemSubCategoryID", mitem_sub_category_Class.nItemSubCategoryID);
        cmd.Parameters.AddWithValue("@nItemCategoryID", mitem_sub_category_Class.nItemCategoryID);
        cmd.Parameters.AddWithValue("@sSerialNo", mitem_sub_category_Class.sSerialNo);
        cmd.Parameters.AddWithValue("@sItemSubCategory", mitem_sub_category_Class.sItemSubCategory);
        cmd.Parameters.AddWithValue("@nConfigID", nConfigID);
        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(mitem_sub_category_Class mitem_sub_category_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(mitem_sub_category_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(mitem_sub_category_Class mitem_sub_category_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(mitem_sub_category_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(mitem_sub_category_Class mitem_sub_category_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(mitem_sub_category_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewmitem_sub_category");
            return ds.Tables["viewmitem_sub_category"];
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
    public DropDownList ddlOperation(mitem_sub_category_Class mitem_sub_category_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(mitem_sub_category_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewmitem_sub_category");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a item_sub_category", "0"));
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
