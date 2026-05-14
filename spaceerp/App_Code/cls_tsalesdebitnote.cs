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
public class tsalesdebitnote_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    public string SalesDebitNoteID { get; set; }
    public string GSTType { get; set; }
    public string ClientNameID { get; set; }
    public string LocationID { get; set; }
    public string DebitNotedate { get; set; }
    public string Referenceno { get; set; }
    public string Referencedate { get; set; }
    public string AgentID { get; set; }
    public string Email { get; set; }
    public string AgainstBill { get; set; }
    public string AgainstBilldate { get; set; }
    public string CurrencyID { get; set; }
    public string ConversionRate { get; set; }
    public string ShippingAddress { get; set; }
    public string BillingAddress { get; set; }
    public string PaymentTerms { get; set; }
    public string Duedate { get; set; }
    public string DebitNoteReason { get; set; }
    public string StartDate { get; set; }
    public string EndDate { get; set; }
    public string User_Operation(tsalesdebitnote_Class tsalesdebitnote_Class, string type)
    {
        SqlCommand cmd = addParameter(tsalesdebitnote_Class, type, "");
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
    public SqlCommand addParameter(tsalesdebitnote_Class tsalesdebitnote_Class, string type, string cond)
    {
        string uid, ConfigID;
        if (Session["uid"] == null)
            uid = "0";
        else
            uid = Session["uid"].ToString();

       
        conn = connobj.makeConnection();
        SqlCommand cmd = new SqlCommand("SP_tsalesdebitnote", conn); cmd.Parameters.AddWithValue("@SalesDebitNoteID", tsalesdebitnote_Class.SalesDebitNoteID);
        cmd.Parameters.AddWithValue("@GSTType", tsalesdebitnote_Class.GSTType);
        cmd.Parameters.AddWithValue("@ClientNameID", tsalesdebitnote_Class.ClientNameID);
        cmd.Parameters.AddWithValue("@LocationID", tsalesdebitnote_Class.LocationID);
        cmd.Parameters.AddWithValue("@DebitNotedate", tsalesdebitnote_Class.DebitNotedate);
        cmd.Parameters.AddWithValue("@Referenceno", tsalesdebitnote_Class.Referenceno);
        cmd.Parameters.AddWithValue("@Referencedate", tsalesdebitnote_Class.Referencedate);
        cmd.Parameters.AddWithValue("@AgentID", tsalesdebitnote_Class.AgentID);
        cmd.Parameters.AddWithValue("@Email", tsalesdebitnote_Class.Email);
        cmd.Parameters.AddWithValue("@AgainstBill", tsalesdebitnote_Class.AgainstBill);
        cmd.Parameters.AddWithValue("@AgainstBilldate", tsalesdebitnote_Class.AgainstBilldate);
        cmd.Parameters.AddWithValue("@CurrencyID", tsalesdebitnote_Class.CurrencyID);
        cmd.Parameters.AddWithValue("@ConversionRate", tsalesdebitnote_Class.ConversionRate);
        cmd.Parameters.AddWithValue("@ShippingAddress", tsalesdebitnote_Class.ShippingAddress);
        cmd.Parameters.AddWithValue("@BillingAddress", tsalesdebitnote_Class.BillingAddress);
        cmd.Parameters.AddWithValue("@PaymentTerms", tsalesdebitnote_Class.PaymentTerms);
        cmd.Parameters.AddWithValue("@Duedate", tsalesdebitnote_Class.Duedate);
        cmd.Parameters.AddWithValue("@DebitNoteReason", tsalesdebitnote_Class.DebitNoteReason);
        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.Parameters.AddWithValue("@StartDate", tsalesdebitnote_Class.StartDate);
        cmd.Parameters.AddWithValue("@EndDate", tsalesdebitnote_Class.EndDate);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(tsalesdebitnote_Class tsalesdebitnote_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(tsalesdebitnote_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(tsalesdebitnote_Class tsalesdebitnote_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(tsalesdebitnote_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(tsalesdebitnote_Class tsalesdebitnote_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(tsalesdebitnote_Class, type, cond);
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
    public DropDownList ddlOperation(tsalesdebitnote_Class tsalesdebitnote_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(tsalesdebitnote_Class, Type, cond);
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
    public DataTable Tabledata(tsalesdebitnote_Class tsalesdebitnote_Class, string type, string cond)
    {
        DataTable da = new DataTable();
        try
        {
            da = viewData(tsalesdebitnote_Class, type, cond);
        }
        catch
        {

        }
        return da;
    }

}
