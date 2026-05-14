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

public class tbankreco_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    public string BankRecoID { get; set; }
    public string TransDate { get; set; }
    public string Narration { get; set; }
    public double DrAmount { get; set; }
    public double CrAmount { get; set; }
    public double BalanceAmount { get; set; }
    public string StartDate { get; set; }
    public string EndDate { get; set; }

    public string BankName { get; set; }

    public string User_Operation(tbankreco_Class tbankreco_Class, string type)
    {
        SqlCommand cmd = addParameter(tbankreco_Class, type, "");
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
    public SqlCommand addParameter(tbankreco_Class tbankreco_Class, string type, string cond)
    {
        string uid;
        if (Session["uid"] == null)
            uid = "0";
        else
            uid = Session["uid"].ToString();
        conn = connobj.makeConnection();
        SqlCommand cmd = new SqlCommand("SP_tbankreco", conn); cmd.Parameters.AddWithValue("@BankRecoID", tbankreco_Class.BankRecoID);
        cmd.Parameters.AddWithValue("@TransDate", tbankreco_Class.TransDate);
        cmd.Parameters.AddWithValue("@Narration", tbankreco_Class.Narration);
        cmd.Parameters.AddWithValue("@DrAmount", tbankreco_Class.DrAmount);
        cmd.Parameters.AddWithValue("@CrAmount", tbankreco_Class.CrAmount);
        cmd.Parameters.AddWithValue("@BalanceAmount", tbankreco_Class.BalanceAmount);
        cmd.Parameters.AddWithValue("@StartDate", tbankreco_Class.StartDate);
        cmd.Parameters.AddWithValue("@EndDate", tbankreco_Class.EndDate);
        cmd.Parameters.AddWithValue("@BankName", tbankreco_Class.BankName);
        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(tbankreco_Class tbankreco_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(tbankreco_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(tbankreco_Class tbankreco_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(tbankreco_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(tbankreco_Class tbankreco_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(tbankreco_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewbankreco");
            return ds.Tables["viewbankreco"];
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
    public DropDownList ddlOperation(tbankreco_Class tbankreco_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(tbankreco_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewbankreco");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a Bank", "0"));
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ddl.Items.Add(new ListItem(ds.Tables[0].Rows[i][0].ToString() + " - " + ds.Tables[0].Rows[i][1].ToString() + " - " + ds.Tables[0].Rows[i][2].ToString(), ds.Tables[0].Rows[i][0].ToString() + "|" + ds.Tables[0].Rows[i][1].ToString() + "|" + ds.Tables[0].Rows[i][3].ToString()));
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
    public DataTable Tabledata(tbankreco_Class tbankreco_Class, string type, string cond)
    {
        DataTable da = new DataTable();
        try
        {
            da = viewData(tbankreco_Class, type, cond);
        }
        catch
        {

        }
        return da;
    }
}