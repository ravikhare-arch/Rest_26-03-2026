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
public class ManageCompany : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    
    public string CompanyID { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }

    public string City { get; set; }
    public string PinCode { get; set; }
    public string Contactno { get; set; }
    public string GSTNo { get; set; }
    public string CaptainName { get; set; }
    public string User_Operation(ManageCompany ManageCompany, string type)
    {
        SqlCommand cmd = addParameter(ManageCompany, type, "");
        try
        {
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
    public SqlCommand addParameter(ManageCompany ManageCompany, string type, string cond)
    {
         string uid;
        if (Session["uid"] == null)
            uid = "0";
        else
            uid = Session["uid"].ToString();
        conn = connobj.makeConnection();
        SqlCommand cmd = new SqlCommand("USP_CompanyMaster", conn); cmd.Parameters.AddWithValue("@CompanyID", ManageCompany.CompanyID);
        cmd.Parameters.AddWithValue("@CompanyName", ManageCompany.Name);
        cmd.Parameters.AddWithValue("@Address", ManageCompany.Address);
        cmd.Parameters.AddWithValue("@City", ManageCompany.City);
        cmd.Parameters.AddWithValue("@PinCode", ManageCompany.PinCode);
        cmd.Parameters.AddWithValue("@Contactno", ManageCompany.Contactno);
        cmd.Parameters.AddWithValue("@GSTNo", ManageCompany.GSTNo);
        cmd.Parameters.AddWithValue("@CaptainName", ManageCompany.CaptainName);
        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(ManageCompany ManageCompany, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(ManageCompany, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(ManageCompany ManageCompany, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(ManageCompany, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(ManageCompany ManageCompany, string type, string cond)
    {
        SqlCommand cmd = addParameter(ManageCompany, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewmpage_master");
            return ds.Tables["viewmpage_master"];
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
    public DataTable Tabledata(ManageCompany ManageCompany, string type, string cond)
    {
        DataTable da = new DataTable();
        try
        {
            da = viewData(ManageCompany, type, cond);
        }
        catch
        {

        }
        return da;
    }
}
