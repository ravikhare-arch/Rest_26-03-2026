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

public class tbspreco_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    public string BSPReconID { get; set; }
    public string IATANo { get; set; }
    public string InvPeriodFrom { get; set; }
    public string InvPeriodTo { get; set; }

    [System.ComponentModel.DefaultValue(true)]
    public bool IsViewedOnImported { get; set; }  //set false on import page to show on imported page
   // public string IsSettled {get;set;}
    //public string IssueDate { get; set; }
    //public string PayableBalance { get; set; }
    //public string Remarks { get; set; }
    //public string BSPType { get; set; }
    //public string STCommRate { get; set; }
    //public string STCommAmt { get; set; }
    //public string AirLineCode { get; set; }
    //public string CouponNumber { get; set; }
    //public string TaxCash { get; set; }
    //public string SuppCommAmount { get; set; }
    //public string GrossFareCredit { get; set; }
    //public string TaxCredit { get; set; }
    //public string TaxBreakUp { get; set; }
    //public string TotalTax { get; set; }
    //public string CancellationPenalty { get; set; }

    public string User_Operation(tbspreco_Class tbspreco_Class, string type)
    {
        SqlCommand cmd = addParameter(tbspreco_Class, type, "");
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
    public SqlCommand addParameter(tbspreco_Class tbspreco_Class, string type, string cond)
    {
        string uid;
        if (Session["uid"] == null)
            uid = "0";
        else
            uid = Session["uid"].ToString();

        conn = connobj.makeConnection();
        SqlCommand cmd = new SqlCommand("SP_tbspreco", conn); 
        cmd.Parameters.AddWithValue("@BSPReconID", tbspreco_Class.BSPReconID);
        cmd.Parameters.AddWithValue("@IATANo", tbspreco_Class.IATANo);
        cmd.Parameters.AddWithValue("@InvPeriodFrom", tbspreco_Class.InvPeriodFrom);
        cmd.Parameters.AddWithValue("@InvPeriodTo", tbspreco_Class.InvPeriodTo);
        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.Parameters.AddWithValue("@IsViewedOnImported", tbspreco_Class.IsViewedOnImported);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(tbspreco_Class tbspreco_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(tbspreco_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(tbspreco_Class tbspreco_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(tbspreco_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(tbspreco_Class tbspreco_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(tbspreco_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewbspreco");
            return ds.Tables["viewbspreco"];
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
    public DropDownList ddlOperation(tbspreco_Class tbspreco_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(tbspreco_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewbspreco");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a IATA No", "0"));
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ddl.Items.Add(new ListItem(ds.Tables[0].Rows[i][0].ToString() + " - " + ds.Tables[0].Rows[i][1].ToString(), ds.Tables[0].Rows[i][0].ToString() + "|" + ds.Tables[0].Rows[i][1].ToString()));
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