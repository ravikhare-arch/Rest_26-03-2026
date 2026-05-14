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
public class tvisa_purchasedet_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnVisaPurchaseDetID = string.Empty;
    private string objnVisaPurchaseID = string.Empty;
    private string objsReferenceNo = string.Empty;
    private string objsCustomerName = string.Empty;
    private string objnNationalityID = string.Empty;
    private string objnCountryID = string.Empty;
    private string objbGender = string.Empty;
    private string objdtDOB = string.Empty;
    private string objsPassportNo = string.Empty;
    private string objdtPasspotIssue = string.Empty;
    private string objdtPasspotExpiry = string.Empty;
    private string objdtInbound = string.Empty;
    private string objdtOutbound = string.Empty;
    private string objdtVisaApply = string.Empty;
    private string objdtVisaIssue = string.Empty;
    private string objdtVisaValidity = string.Empty;
    private string objsContactNo = string.Empty;
    private string objnVisaStatusID = string.Empty;
    private string objsExtenstion = string.Empty;
    private string objnVisaTypeID = string.Empty;
    private string objsVisaDuration = string.Empty;
    private string objnCost = string.Empty;
    private string objnScTypeID = string.Empty;
    private string objnSCPercent = string.Empty;
    private string objnSCAmount = string.Empty;
    private string objnTdsTypeID = string.Empty;
    private string objnTDSPercent = string.Empty;
    private string objnTDSAmount = string.Empty;
    private string objnDiscount = string.Empty;
    private string objnOtrCharges = string.Empty;
    private string objbTax = string.Empty;
    private string objnCGst = string.Empty;
    private string objnSGST = string.Empty;
    private string objnIGST = string.Empty;
    private string objnTotalVisaCost = string.Empty;
    private string objsRemarks = string.Empty;
    private string objnBookingTypeID = string.Empty;
    private string objnConfigID = string.Empty;
    public string nVisaPurchaseDetID
    {
        get { return objnVisaPurchaseDetID; }
        set { objnVisaPurchaseDetID = value; }
    }
    public string nVisaPurchaseID
    {
        get { return objnVisaPurchaseID; }
        set { objnVisaPurchaseID = value; }
    }
    public string sReferenceNo
    {
        get { return objsReferenceNo; }
        set { objsReferenceNo = value; }
    }
    public string sCustomerName
    {
        get { return objsCustomerName; }
        set { objsCustomerName = value; }
    }
    public string nNationalityID
    {
        get { return objnNationalityID; }
        set { objnNationalityID = value; }
    }
    public string nCountryID
    {
        get { return objnCountryID; }
        set { objnCountryID = value; }
    }
    public string bGender
    {
        get { return objbGender; }
        set { objbGender = value; }
    }
    public string dtDOB
    {
        get { return objdtDOB; }
        set { objdtDOB = value; }
    }
    public string sPassportNo
    {
        get { return objsPassportNo; }
        set { objsPassportNo = value; }
    }
    public string dtPasspotIssue
    {
        get { return objdtPasspotIssue; }
        set { objdtPasspotIssue = value; }
    }
    public string dtPasspotExpiry
    {
        get { return objdtPasspotExpiry; }
        set { objdtPasspotExpiry = value; }
    }
    public string dtInbound
    {
        get { return objdtInbound; }
        set { objdtInbound = value; }
    }
    public string dtOutbound
    {
        get { return objdtOutbound; }
        set { objdtOutbound = value; }
    }
    public string dtVisaApply
    {
        get { return objdtVisaApply; }
        set { objdtVisaApply = value; }
    }
    public string dtVisaIssue
    {
        get { return objdtVisaIssue; }
        set { objdtVisaIssue = value; }
    }
    public string dtVisaValidity
    {
        get { return objdtVisaValidity; }
        set { objdtVisaValidity = value; }
    }
    public string sContactNo
    {
        get { return objsContactNo; }
        set { objsContactNo = value; }
    }
    public string nVisaStatusID
    {
        get { return objnVisaStatusID; }
        set { objnVisaStatusID = value; }
    }
    public string sExtenstion
    {
        get { return objsExtenstion; }
        set { objsExtenstion = value; }
    }
    public string nVisaTypeID
    {
        get { return objnVisaTypeID; }
        set { objnVisaTypeID = value; }
    }
    public string sVisaDuration
    {
        get { return objsVisaDuration; }
        set { objsVisaDuration = value; }
    }
    public string nCost
    {
        get { return objnCost; }
        set { objnCost = value; }
    }
    public string nScTypeID
    {
        get { return objnScTypeID; }
        set { objnScTypeID = value; }
    }
    public string nSCPercent
    {
        get { return objnSCPercent; }
        set { objnSCPercent = value; }
    }
    public string nSCAmount
    {
        get { return objnSCAmount; }
        set { objnSCAmount = value; }
    }
    public string nTdsTypeID
    {
        get { return objnTdsTypeID; }
        set { objnTdsTypeID = value; }
    }
    public string nTDSPercent
    {
        get { return objnTDSPercent; }
        set { objnTDSPercent = value; }
    }
    public string nTDSAmount
    {
        get { return objnTDSAmount; }
        set { objnTDSAmount = value; }
    }
    public string nDiscount
    {
        get { return objnDiscount; }
        set { objnDiscount = value; }
    }
    public string nOtrCharges
    {
        get { return objnOtrCharges; }
        set { objnOtrCharges = value; }
    }
    public string bTax
    {
        get { return objbTax; }
        set { objbTax = value; }
    }
    public string nCGst
    {
        get { return objnCGst; }
        set { objnCGst = value; }
    }
    public string nSGST
    {
        get { return objnSGST; }
        set { objnSGST = value; }
    }
    public string nIGST
    {
        get { return objnIGST; }
        set { objnIGST = value; }
    }
    public string nTotalVisaCost
    {
        get { return objnTotalVisaCost; }
        set { objnTotalVisaCost = value; }
    }
    public string sRemarks
    {
        get { return objsRemarks; }
        set { objsRemarks = value; }
    }
    public string nBookingTypeID
    {
        get { return objnBookingTypeID; }
        set { objnBookingTypeID = value; }
    }
    public string nConfigID
    {
        get { return objnConfigID; }
        set { objnConfigID = value; }
    }
    public string User_Operation(tvisa_purchasedet_Class tvisa_purchasedet_Class, string type)
    {
        SqlCommand cmd = addParameter(tvisa_purchasedet_Class, type, "");
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
    public SqlCommand addParameter(tvisa_purchasedet_Class tvisa_purchasedet_Class, string type, string cond)
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
        SqlCommand cmd = new SqlCommand("SP_tvisa_purchasedet", conn); cmd.Parameters.AddWithValue("@nVisaPurchaseDetID", tvisa_purchasedet_Class.nVisaPurchaseDetID);
        cmd.Parameters.AddWithValue("@nVisaPurchaseID", tvisa_purchasedet_Class.nVisaPurchaseID);
        cmd.Parameters.AddWithValue("@sReferenceNo", tvisa_purchasedet_Class.sReferenceNo);
        cmd.Parameters.AddWithValue("@sCustomerName", tvisa_purchasedet_Class.sCustomerName);
        cmd.Parameters.AddWithValue("@nNationalityID", tvisa_purchasedet_Class.nNationalityID);
        cmd.Parameters.AddWithValue("@nCountryID", tvisa_purchasedet_Class.nCountryID);
        cmd.Parameters.AddWithValue("@bGender", tvisa_purchasedet_Class.bGender);
        cmd.Parameters.AddWithValue("@dtDOB", tvisa_purchasedet_Class.dtDOB);
        cmd.Parameters.AddWithValue("@sPassportNo", tvisa_purchasedet_Class.sPassportNo);
        cmd.Parameters.AddWithValue("@dtPasspotIssue", tvisa_purchasedet_Class.dtPasspotIssue);
        cmd.Parameters.AddWithValue("@dtPasspotExpiry", tvisa_purchasedet_Class.dtPasspotExpiry);
        cmd.Parameters.AddWithValue("@dtInbound", tvisa_purchasedet_Class.dtInbound);
        cmd.Parameters.AddWithValue("@dtOutbound", tvisa_purchasedet_Class.dtOutbound);
        cmd.Parameters.AddWithValue("@dtVisaApply", tvisa_purchasedet_Class.dtVisaApply);
        cmd.Parameters.AddWithValue("@dtVisaIssue", tvisa_purchasedet_Class.dtVisaIssue);
        cmd.Parameters.AddWithValue("@dtVisaValidity", tvisa_purchasedet_Class.dtVisaValidity);
        cmd.Parameters.AddWithValue("@sContactNo", tvisa_purchasedet_Class.sContactNo);
        cmd.Parameters.AddWithValue("@nVisaStatusID", tvisa_purchasedet_Class.nVisaStatusID);
        cmd.Parameters.AddWithValue("@sExtenstion", tvisa_purchasedet_Class.sExtenstion);
        cmd.Parameters.AddWithValue("@nVisaTypeID", tvisa_purchasedet_Class.nVisaTypeID);
        cmd.Parameters.AddWithValue("@sVisaDuration", tvisa_purchasedet_Class.sVisaDuration);
        cmd.Parameters.AddWithValue("@nCost", tvisa_purchasedet_Class.nCost);
        cmd.Parameters.AddWithValue("@nScTypeID", tvisa_purchasedet_Class.nScTypeID);
        cmd.Parameters.AddWithValue("@nSCPercent", tvisa_purchasedet_Class.nSCPercent);
        cmd.Parameters.AddWithValue("@nSCAmount", tvisa_purchasedet_Class.nSCAmount);
        cmd.Parameters.AddWithValue("@nTdsTypeID", tvisa_purchasedet_Class.nTdsTypeID);
        cmd.Parameters.AddWithValue("@nTDSPercent", tvisa_purchasedet_Class.nTDSPercent);
        cmd.Parameters.AddWithValue("@nTDSAmount", tvisa_purchasedet_Class.nTDSAmount);
        cmd.Parameters.AddWithValue("@nDiscount", tvisa_purchasedet_Class.nDiscount);
        cmd.Parameters.AddWithValue("@nOtrCharges", tvisa_purchasedet_Class.nOtrCharges);
        cmd.Parameters.AddWithValue("@bTax", tvisa_purchasedet_Class.bTax);
        cmd.Parameters.AddWithValue("@nCGst", tvisa_purchasedet_Class.nCGst);
        cmd.Parameters.AddWithValue("@nSGST", tvisa_purchasedet_Class.nSGST);
        cmd.Parameters.AddWithValue("@nIGST", tvisa_purchasedet_Class.nIGST);
        cmd.Parameters.AddWithValue("@nTotalVisaCost", tvisa_purchasedet_Class.nTotalVisaCost);
        cmd.Parameters.AddWithValue("@sRemarks", tvisa_purchasedet_Class.sRemarks);
        cmd.Parameters.AddWithValue("@nBookingTypeID", tvisa_purchasedet_Class.nBookingTypeID);
        cmd.Parameters.AddWithValue("@nConfigID", ConfigID);

        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(tvisa_purchasedet_Class tvisa_purchasedet_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(tvisa_purchasedet_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(tvisa_purchasedet_Class tvisa_purchasedet_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(tvisa_purchasedet_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(tvisa_purchasedet_Class tvisa_purchasedet_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(tvisa_purchasedet_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewtvisa_purchasedet");
            return ds.Tables["viewtvisa_purchasedet"];
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
    public DropDownList ddlOperation(tvisa_purchasedet_Class tvisa_purchasedet_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(tvisa_purchasedet_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewtvisa_purchasedet");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a visa_purchasedet", "0"));
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
