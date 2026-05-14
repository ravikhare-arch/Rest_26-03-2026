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
public class tmenumanage_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    public string MenuID { get; set; }
    public string Product { get; set; }
    public string ProductCode { get; set; }
    public double Price { get; set; }
    public int DeliveryType { get; set; }
    public string CategoryID { get; set; }
    public string FoodTypeID { get; set; }
    public double ActualCost { get; set; }
    public string ApplyOffer { get; set; }
    public string GroupID { get; set; }
    public string isActive { get; set; }
    public string GSTID { get; set; }
    public double GSTCost { get; set; }
     public double SGST { get; set; }
     public double CGST { get; set; }
     public double IGST { get; set; }
    public double GSTpercent { get; set; }
    public string ACNONAC { get; set; }
    public string User_Operation(tmenumanage_Class tmenumanage_Class, string type)
    {
        SqlCommand cmd = addParameter(tmenumanage_Class, type, "");
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
    public SqlCommand addParameter(tmenumanage_Class tmenumanage_Class, string type, string cond)
    {
        string uid;
        if (Session["uid"] == null)
            uid = "0";
        else
            uid = Session["uid"].ToString();

        conn = connobj.makeConnection();
        SqlCommand cmd = new SqlCommand("SP_tmenumanage", conn); cmd.Parameters.AddWithValue("@MenuID", tmenumanage_Class.MenuID);       
        cmd.Parameters.AddWithValue("@ProductCode", tmenumanage_Class.ProductCode);
        cmd.Parameters.AddWithValue("@Product", tmenumanage_Class.Product);
        cmd.Parameters.AddWithValue("@CategoryID", tmenumanage_Class.CategoryID);
        cmd.Parameters.AddWithValue("@FoodTypeID", tmenumanage_Class.FoodTypeID);
        cmd.Parameters.AddWithValue("@Price", tmenumanage_Class.Price);
        cmd.Parameters.AddWithValue("@ActualCost", tmenumanage_Class.ActualCost);
        cmd.Parameters.AddWithValue("@ApplyOffer", tmenumanage_Class.ApplyOffer);
        cmd.Parameters.AddWithValue("@GroupID", tmenumanage_Class.GroupID);
        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.Parameters.AddWithValue("@isActive", tmenumanage_Class.isActive);
        cmd.Parameters.AddWithValue("@GSTID", tmenumanage_Class.GSTID);
        cmd.Parameters.AddWithValue("@GSTCost", tmenumanage_Class.GSTCost);
        cmd.Parameters.AddWithValue("@CGST", tmenumanage_Class.SGST);
        cmd.Parameters.AddWithValue("@SGST", tmenumanage_Class.CGST);
        cmd.Parameters.AddWithValue("@IGST", tmenumanage_Class.IGST);
        cmd.Parameters.AddWithValue("@DeliveryType", tmenumanage_Class.DeliveryType);
        cmd.Parameters.AddWithValue("@GSTpercent", tmenumanage_Class.GSTpercent);
        cmd.Parameters.AddWithValue("@ACNONAC", tmenumanage_Class.ACNONAC);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(tmenumanage_Class tmenumanage_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(tmenumanage_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(tmenumanage_Class tmenumanage_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(tmenumanage_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(tmenumanage_Class tmenumanage_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(tmenumanage_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewsalesdebitnote");
            return ds.Tables["viewsalesdebitnote"];
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            cmd.Dispose();
            conn = connobj.closeConnection();
        }
    }
    public DropDownList ddlOperation(tmenumanage_Class tmenumanage_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(tmenumanage_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewsalesdebitnote");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a salesorder", "0"));
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
    public DataTable Tabledata(tmenumanage_Class tmenumanage_Class, string type, string cond)
    {
        DataTable da = new DataTable();
        try
        {
            da = viewData(tmenumanage_Class, type, cond);
        }
        catch
        {

        }
        return da;
    }

}
