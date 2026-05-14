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
public class tgroupmofadet_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnGroupMofaDetID = string.Empty;
    private string objnGroupMofaID = string.Empty;
    private string objsGroupName = string.Empty;
    private string objsGroupCode = string.Empty;
    private string objsDuration = string.Empty;
    private string objsVisaValidity = string.Empty;
    private string objsRemarks = string.Empty;
    private string objbRepeater = string.Empty;
    private string objnQuantity = string.Empty;
    private string objnMofaCost = string.Empty;
    private string objnMofaCostTotal = string.Empty;
    private string objnSupSCType = string.Empty;
    private string objnSupSCPercent = string.Empty;
    private string objnSupSCAmount = string.Empty;
    private string objnSupSCAmountTotal = string.Empty;
    private string objnSupTDSType = string.Empty;
    private string objnSupTDSPercent = string.Empty;
    private string objnSupTDSAmount = string.Empty;
    private string objnSupOtrTax = string.Empty;
    private string objnSupDiscount = string.Empty;
    private string objbSupTax = string.Empty;
    private string objnSupCGST = string.Empty;
    private string objnSupSGST = string.Empty;
    private string objnSupIGST = string.Empty;
    private string objnSupCGSTTotal = string.Empty;
    private string objnSupSGSTTotal = string.Empty;
    private string objnSupIGSTTotal = string.Empty;
    private string objnSupplierCost = string.Empty;
    private string objnClntSCType = string.Empty;
    private string objnClntSCPercent = string.Empty;
    private string objnClntSCAmount = string.Empty;
    private string objnClntSCAmountTotal = string.Empty;
    private string objnClntTDSType = string.Empty;
    private string objnClntTDSPercent = string.Empty;
    private string objnClntTDSAmount = string.Empty;
    private string objnClntOtrTax = string.Empty;
    private string objnClntDiscount = string.Empty;
    private string objnCourierfee = string.Empty;
    private string objbClntTax = string.Empty;
    private string objnClntCGST = string.Empty;
    private string objnClntSGST = string.Empty;
    private string objnClntIGST = string.Empty;
    private string objnClntCGSTTotal = string.Empty;
    private string objnClntSGSTTotal = string.Empty;
    private string objnClntIGSTTotal = string.Empty;
    private string objnClientCost = string.Empty;
    private string objnConfigID = string.Empty;
    public string nGroupMofaDetID
    {
        get { return objnGroupMofaDetID; }
        set { objnGroupMofaDetID = value; }
    }
    public string nGroupMofaID
    {
        get { return objnGroupMofaID; }
        set { objnGroupMofaID = value; }
    }
    public string sGroupName
    {
        get { return objsGroupName; }
        set { objsGroupName = value; }
    }
    public string sGroupCode
    {
        get { return objsGroupCode; }
        set { objsGroupCode = value; }
    }
    public string sDuration
    {
        get { return objsDuration; }
        set { objsDuration = value; }
    }
    public string sVisaValidity
    {
        get { return objsVisaValidity; }
        set { objsVisaValidity = value; }
    }
    public string sRemarks
    {
        get { return objsRemarks; }
        set { objsRemarks = value; }
    }
    public string bRepeater
    {
        get { return objbRepeater; }
        set { objbRepeater = value; }
    }
    public string nQuantity
    {
        get { return objnQuantity; }
        set { objnQuantity = value; }
    }
    public string nMofaCost
    {
        get { return objnMofaCost; }
        set { objnMofaCost = value; }
    }
    public string nMofaCostTotal
    {
        get { return objnMofaCostTotal; }
        set { objnMofaCostTotal = value; }
    }
    public string nSupSCType
    {
        get { return objnSupSCType; }
        set { objnSupSCType = value; }
    }
    public string nSupSCPercent
    {
        get { return objnSupSCPercent; }
        set { objnSupSCPercent = value; }
    }
    public string nSupSCAmount
    {
        get { return objnSupSCAmount; }
        set { objnSupSCAmount = value; }
    }
    public string nSupSCAmountTotal
    {
        get { return objnSupSCAmountTotal; }
        set { objnSupSCAmountTotal = value; }
    }
    public string nSupTDSType
    {
        get { return objnSupTDSType; }
        set { objnSupTDSType = value; }
    }
    public string nSupTDSPercent
    {
        get { return objnSupTDSPercent; }
        set { objnSupTDSPercent = value; }
    }
    public string nSupTDSAmount
    {
        get { return objnSupTDSAmount; }
        set { objnSupTDSAmount = value; }
    }
    public string nSupOtrTax
    {
        get { return objnSupOtrTax; }
        set { objnSupOtrTax = value; }
    }
    public string nSupDiscount
    {
        get { return objnSupDiscount; }
        set { objnSupDiscount = value; }
    }
    public string bSupTax
    {
        get { return objbSupTax; }
        set { objbSupTax = value; }
    }
    public string nSupCGST
    {
        get { return objnSupCGST; }
        set { objnSupCGST = value; }
    }
    public string nSupSGST
    {
        get { return objnSupSGST; }
        set { objnSupSGST = value; }
    }
    public string nSupIGST
    {
        get { return objnSupIGST; }
        set { objnSupIGST = value; }
    }
    public string nSupCGSTTotal
    {
        get { return objnSupCGSTTotal; }
        set { objnSupCGSTTotal = value; }
    }
    public string nSupSGSTTotal
    {
        get { return objnSupSGSTTotal; }
        set { objnSupSGSTTotal = value; }
    }
    public string nSupIGSTTotal
    {
        get { return objnSupIGSTTotal; }
        set { objnSupIGSTTotal = value; }
    }
    public string nSupplierCost
    {
        get { return objnSupplierCost; }
        set { objnSupplierCost = value; }
    }
    public string nClntSCType
    {
        get { return objnClntSCType; }
        set { objnClntSCType = value; }
    }
    public string nClntSCPercent
    {
        get { return objnClntSCPercent; }
        set { objnClntSCPercent = value; }
    }
    public string nClntSCAmount
    {
        get { return objnClntSCAmount; }
        set { objnClntSCAmount = value; }
    }
    public string nClntSCAmountTotal
    {
        get { return objnClntSCAmountTotal; }
        set { objnClntSCAmountTotal = value; }
    }
    public string nClntTDSType
    {
        get { return objnClntTDSType; }
        set { objnClntTDSType = value; }
    }
    public string nClntTDSPercent
    {
        get { return objnClntTDSPercent; }
        set { objnClntTDSPercent = value; }
    }
    public string nClntTDSAmount
    {
        get { return objnClntTDSAmount; }
        set { objnClntTDSAmount = value; }
    }
    public string nClntOtrTax
    {
        get { return objnClntOtrTax; }
        set { objnClntOtrTax = value; }
    }
    public string nClntDiscount
    {
        get { return objnClntDiscount; }
        set { objnClntDiscount = value; }
    }
    public string nCourierfee
    {
        get { return objnCourierfee; }
        set { objnCourierfee = value; }
    }
    public string bClntTax
    {
        get { return objbClntTax; }
        set { objbClntTax = value; }
    }
    public string nClntCGST
    {
        get { return objnClntCGST; }
        set { objnClntCGST = value; }
    }
    public string nClntSGST
    {
        get { return objnClntSGST; }
        set { objnClntSGST = value; }
    }
    public string nClntIGST
    {
        get { return objnClntIGST; }
        set { objnClntIGST = value; }
    }
    public string nClntCGSTTotal
    {
        get { return objnClntCGSTTotal; }
        set { objnClntCGSTTotal = value; }
    }
    public string nClntSGSTTotal
    {
        get { return objnClntSGSTTotal; }
        set { objnClntSGSTTotal = value; }
    }
    public string nClntIGSTTotal
    {
        get { return objnClntIGSTTotal; }
        set { objnClntIGSTTotal = value; }
    }
    public string nClientCost
    {
        get { return objnClientCost; }
        set { objnClientCost = value; }
    }
    public string nConfigID
    {
        get { return objnConfigID; }
        set { objnConfigID = value; }
    }
    public string User_Operation(tgroupmofadet_Class tgroupmofadet_Class, string type)
    {
        SqlCommand cmd = addParameter(tgroupmofadet_Class, type, "");
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
    public SqlCommand addParameter(tgroupmofadet_Class tgroupmofadet_Class, string type, string cond)
    {
        string uid,ConfigID;
        if (Session["uid"] == null)
            uid = "0";
        else
            uid = Session["uid"].ToString();

        if (Session["ConfigID"] == null)
            ConfigID = "0";
        else
            ConfigID = Session["ConfigID"].ToString();

        conn = connobj.makeConnection();
        SqlCommand cmd = new SqlCommand("SP_tgroupmofadet", conn); cmd.Parameters.AddWithValue("@nGroupMofaDetID", tgroupmofadet_Class.nGroupMofaDetID);
        cmd.Parameters.AddWithValue("@nGroupMofaID", tgroupmofadet_Class.nGroupMofaID);
        cmd.Parameters.AddWithValue("@sGroupName", tgroupmofadet_Class.sGroupName);
        cmd.Parameters.AddWithValue("@sGroupCode", tgroupmofadet_Class.sGroupCode);
        cmd.Parameters.AddWithValue("@sDuration", tgroupmofadet_Class.sDuration);
        cmd.Parameters.AddWithValue("@sVisaValidity", tgroupmofadet_Class.sVisaValidity);
        cmd.Parameters.AddWithValue("@sRemarks", tgroupmofadet_Class.sRemarks);
        cmd.Parameters.AddWithValue("@bRepeater", tgroupmofadet_Class.bRepeater);
        cmd.Parameters.AddWithValue("@nQuantity", tgroupmofadet_Class.nQuantity);
        cmd.Parameters.AddWithValue("@nMofaCost", tgroupmofadet_Class.nMofaCost);
        cmd.Parameters.AddWithValue("@nMofaCostTotal", tgroupmofadet_Class.nMofaCostTotal);
        cmd.Parameters.AddWithValue("@nSupSCType", tgroupmofadet_Class.nSupSCType);
        cmd.Parameters.AddWithValue("@nSupSCPercent", tgroupmofadet_Class.nSupSCPercent);
        cmd.Parameters.AddWithValue("@nSupSCAmount", tgroupmofadet_Class.nSupSCAmount);
        cmd.Parameters.AddWithValue("@nSupSCAmountTotal", tgroupmofadet_Class.nSupSCAmountTotal);
        cmd.Parameters.AddWithValue("@nSupTDSType", tgroupmofadet_Class.nSupTDSType);
        cmd.Parameters.AddWithValue("@nSupTDSPercent", tgroupmofadet_Class.nSupTDSPercent);
        cmd.Parameters.AddWithValue("@nSupTDSAmount", tgroupmofadet_Class.nSupTDSAmount);
        cmd.Parameters.AddWithValue("@nSupOtrTax", tgroupmofadet_Class.nSupOtrTax);
        cmd.Parameters.AddWithValue("@nSupDiscount", tgroupmofadet_Class.nSupDiscount);
        cmd.Parameters.AddWithValue("@bSupTax", tgroupmofadet_Class.bSupTax);
        cmd.Parameters.AddWithValue("@nSupCGST", tgroupmofadet_Class.nSupCGST);
        cmd.Parameters.AddWithValue("@nSupSGST", tgroupmofadet_Class.nSupSGST);
        cmd.Parameters.AddWithValue("@nSupIGST", tgroupmofadet_Class.nSupIGST);
        cmd.Parameters.AddWithValue("@nSupCGSTTotal", tgroupmofadet_Class.nSupCGSTTotal);
        cmd.Parameters.AddWithValue("@nSupSGSTTotal", tgroupmofadet_Class.nSupSGSTTotal);
        cmd.Parameters.AddWithValue("@nSupIGSTTotal", tgroupmofadet_Class.nSupIGSTTotal);
        cmd.Parameters.AddWithValue("@nSupplierCost", tgroupmofadet_Class.nSupplierCost);
        cmd.Parameters.AddWithValue("@nClntSCType", tgroupmofadet_Class.nClntSCType);
        cmd.Parameters.AddWithValue("@nClntSCPercent", tgroupmofadet_Class.nClntSCPercent);
        cmd.Parameters.AddWithValue("@nClntSCAmount", tgroupmofadet_Class.nClntSCAmount);
        cmd.Parameters.AddWithValue("@nClntSCAmountTotal", tgroupmofadet_Class.nClntSCAmountTotal);
        cmd.Parameters.AddWithValue("@nClntTDSType", tgroupmofadet_Class.nClntTDSType);
        cmd.Parameters.AddWithValue("@nClntTDSPercent", tgroupmofadet_Class.nClntTDSPercent);
        cmd.Parameters.AddWithValue("@nClntTDSAmount", tgroupmofadet_Class.nClntTDSAmount);
        cmd.Parameters.AddWithValue("@nClntOtrTax", tgroupmofadet_Class.nClntOtrTax);
        cmd.Parameters.AddWithValue("@nClntDiscount", tgroupmofadet_Class.nClntDiscount);
        cmd.Parameters.AddWithValue("@nCourierfee", tgroupmofadet_Class.nCourierfee);
        cmd.Parameters.AddWithValue("@bClntTax", tgroupmofadet_Class.bClntTax);
        cmd.Parameters.AddWithValue("@nClntCGST", tgroupmofadet_Class.nClntCGST);
        cmd.Parameters.AddWithValue("@nClntSGST", tgroupmofadet_Class.nClntSGST);
        cmd.Parameters.AddWithValue("@nClntIGST", tgroupmofadet_Class.nClntIGST);
        cmd.Parameters.AddWithValue("@nClntCGSTTotal", tgroupmofadet_Class.nClntCGSTTotal);
        cmd.Parameters.AddWithValue("@nClntSGSTTotal", tgroupmofadet_Class.nClntSGSTTotal);
        cmd.Parameters.AddWithValue("@nClntIGSTTotal", tgroupmofadet_Class.nClntIGSTTotal);
        cmd.Parameters.AddWithValue("@nClientCost", tgroupmofadet_Class.nClientCost);
        cmd.Parameters.AddWithValue("@nConfigID", tgroupmofadet_Class.nConfigID);

        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(tgroupmofadet_Class tgroupmofadet_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(tgroupmofadet_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(tgroupmofadet_Class tgroupmofadet_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(tgroupmofadet_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(tgroupmofadet_Class tgroupmofadet_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(tgroupmofadet_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewtgroupmofadet");
            return ds.Tables["viewtgroupmofadet"];
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
    public DropDownList ddlOperation(tgroupmofadet_Class tgroupmofadet_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(tgroupmofadet_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewtgroupmofadet");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a groupmofadet", "0"));
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
