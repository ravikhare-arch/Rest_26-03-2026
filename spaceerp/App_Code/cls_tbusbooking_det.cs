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
public class tbusbooking_det_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnBusBookingDetID = string.Empty;
    private string objnBusBookingID = string.Empty;
    private string objsTicketNo = string.Empty;
    private string objsPaxName = string.Empty;
    private string objnGenderID = string.Empty;
    private string objsAge = string.Empty;
    private string objsOrigin = string.Empty;
    private string objsDestination = string.Empty;
    private string objsBusNo = string.Empty;
    private string objdtTravelDate = string.Empty;
    private string objsCoachType = string.Empty;
    private string objnBasicFare = string.Empty;
    private string objnOtherTax = string.Empty;
    private string objnSupComm = string.Empty;
    private string objnSupScType = string.Empty;
    private string objnSupScPercent = string.Empty;
    private string objnSupScAmount = string.Empty;
    private string objnSupTdsType = string.Empty;
    private string objnSupTDSPercent = string.Empty;
    private string objnSupTDSAmount = string.Empty;
    private string objbSupTax = string.Empty;
    private string objnSupCGST = string.Empty;
    private string objnSupSGST = string.Empty;
    private string objnSupIGST = string.Empty;
    private string objnSupplierCost = string.Empty;
    private string objnClntScType = string.Empty;
    private string objnClntScPercent = string.Empty;
    private string objnClntScAmount = string.Empty;
    private string objnClntTDSType = string.Empty;
    private string objnClntTDSPercent = string.Empty;
    private string objnClntTDSAmount = string.Empty;
    private string objnDiscount = string.Empty;
    private string objbClntTax = string.Empty;
    private string objnClntCGst = string.Empty;
    private string objnClntSGst = string.Empty;
    private string objnClntIGst = string.Empty;
    private string objnClientCost = string.Empty;
    private string objsRemarks = string.Empty;
    private string objnClntSc2Percent = string.Empty;
    private string objnClntSc2Amount = string.Empty;
    private string objnClntOtherChrgs = string.Empty;
    private string objnSupDiscount = string.Empty;
    private string objnConfigID = string.Empty;
    public string nBusBookingDetID
    {
        get { return objnBusBookingDetID; }
        set { objnBusBookingDetID = value; }
    }
    public string nBusBookingID
    {
        get { return objnBusBookingID; }
        set { objnBusBookingID = value; }
    }
    public string sTicketNo
    {
        get { return objsTicketNo; }
        set { objsTicketNo = value; }
    }
    public string sPaxName
    {
        get { return objsPaxName; }
        set { objsPaxName = value; }
    }
    public string nGenderID
    {
        get { return objnGenderID; }
        set { objnGenderID = value; }
    }
    public string sAge
    {
        get { return objsAge; }
        set { objsAge = value; }
    }
    public string sOrigin
    {
        get { return objsOrigin; }
        set { objsOrigin = value; }
    }
    public string sDestination
    {
        get { return objsDestination; }
        set { objsDestination = value; }
    }
    public string sBusNo
    {
        get { return objsBusNo; }
        set { objsBusNo = value; }
    }
    public string dtTravelDate
    {
        get { return objdtTravelDate; }
        set { objdtTravelDate = value; }
    }
    public string sCoachType
    {
        get { return objsCoachType; }
        set { objsCoachType = value; }
    }
    public string nBasicFare
    {
        get { return objnBasicFare; }
        set { objnBasicFare = value; }
    }
    public string nOtherTax
    {
        get { return objnOtherTax; }
        set { objnOtherTax = value; }
    }
    public string nSupComm
    {
        get { return objnSupComm; }
        set { objnSupComm = value; }
    }
    public string nSupScType
    {
        get { return objnSupScType; }
        set { objnSupScType = value; }
    }
    public string nSupScPercent
    {
        get { return objnSupScPercent; }
        set { objnSupScPercent = value; }
    }
    public string nSupScAmount
    {
        get { return objnSupScAmount; }
        set { objnSupScAmount = value; }
    }
    public string nSupTdsType
    {
        get { return objnSupTdsType; }
        set { objnSupTdsType = value; }
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
    public string nSupplierCost
    {
        get { return objnSupplierCost; }
        set { objnSupplierCost = value; }
    }
    public string nClntScType
    {
        get { return objnClntScType; }
        set { objnClntScType = value; }
    }
    public string nClntScPercent
    {
        get { return objnClntScPercent; }
        set { objnClntScPercent = value; }
    }
    public string nClntScAmount
    {
        get { return objnClntScAmount; }
        set { objnClntScAmount = value; }
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
    public string nDiscount
    {
        get { return objnDiscount; }
        set { objnDiscount = value; }
    }
    public string bClntTax
    {
        get { return objbClntTax; }
        set { objbClntTax = value; }
    }
    public string nClntCGst
    {
        get { return objnClntCGst; }
        set { objnClntCGst = value; }
    }
    public string nClntSGst
    {
        get { return objnClntSGst; }
        set { objnClntSGst = value; }
    }
    public string nClntIGst
    {
        get { return objnClntIGst; }
        set { objnClntIGst = value; }
    }
    public string nClientCost
    {
        get { return objnClientCost; }
        set { objnClientCost = value; }
    }
    public string sRemarks
    {
        get { return objsRemarks; }
        set { objsRemarks = value; }
    }
    public string nClntSc2Percent
    {
        get { return objnClntSc2Percent; }
        set { objnClntSc2Percent = value; }
    }
    public string nClntSc2Amount
    {
        get { return objnClntSc2Amount; }
        set { objnClntSc2Amount = value; }
    }
    public string nClntOtherChrgs
    {
        get { return objnClntOtherChrgs; }
        set { objnClntOtherChrgs = value; }
    }
    public string nSupDiscount
    {
        get { return objnSupDiscount; }
        set { objnSupDiscount = value; }
    }
    public string nConfigID
    {
        get { return objnConfigID; }
        set { objnConfigID = value; }
    }
    public string User_Operation(tbusbooking_det_Class tbusbooking_det_Class, string type)
    {
        SqlCommand cmd = addParameter(tbusbooking_det_Class, type, "");
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
    public SqlCommand addParameter(tbusbooking_det_Class tbusbooking_det_Class, string type, string cond)
    {
        string uid, ConfigID;
        if (Session["uid"] == null)
            uid = "0";
        else
            uid = Session["uid"].ToString();

        ConfigID = "1";
        conn = connobj.makeConnection();
        SqlCommand cmd = new SqlCommand("SP_tbusbooking_det", conn); cmd.Parameters.AddWithValue("@nBusBookingDetID", tbusbooking_det_Class.nBusBookingDetID);
        cmd.Parameters.AddWithValue("@nBusBookingID", tbusbooking_det_Class.nBusBookingID);
        cmd.Parameters.AddWithValue("@sTicketNo", tbusbooking_det_Class.sTicketNo);
        cmd.Parameters.AddWithValue("@sPaxName", tbusbooking_det_Class.sPaxName);
        cmd.Parameters.AddWithValue("@nGenderID", tbusbooking_det_Class.nGenderID);
        cmd.Parameters.AddWithValue("@sAge", tbusbooking_det_Class.sAge);
        cmd.Parameters.AddWithValue("@sOrigin", tbusbooking_det_Class.sOrigin);
        cmd.Parameters.AddWithValue("@sDestination", tbusbooking_det_Class.sDestination);
        cmd.Parameters.AddWithValue("@sBusNo", tbusbooking_det_Class.sBusNo);
        cmd.Parameters.AddWithValue("@dtTravelDate", tbusbooking_det_Class.dtTravelDate);
        cmd.Parameters.AddWithValue("@sCoachType", tbusbooking_det_Class.sCoachType);
        cmd.Parameters.AddWithValue("@nBasicFare", tbusbooking_det_Class.nBasicFare);
        cmd.Parameters.AddWithValue("@nOtherTax", tbusbooking_det_Class.nOtherTax);
        cmd.Parameters.AddWithValue("@nSupComm", tbusbooking_det_Class.nSupComm);
        cmd.Parameters.AddWithValue("@nSupScType", tbusbooking_det_Class.nSupScType);
        cmd.Parameters.AddWithValue("@nSupScPercent", tbusbooking_det_Class.nSupScPercent);
        cmd.Parameters.AddWithValue("@nSupScAmount", tbusbooking_det_Class.nSupScAmount);
        cmd.Parameters.AddWithValue("@nSupTdsType", tbusbooking_det_Class.nSupTdsType);
        cmd.Parameters.AddWithValue("@nSupTDSPercent", tbusbooking_det_Class.nSupTDSPercent);
        cmd.Parameters.AddWithValue("@nSupTDSAmount", tbusbooking_det_Class.nSupTDSAmount);
        cmd.Parameters.AddWithValue("@bSupTax", tbusbooking_det_Class.bSupTax);
        cmd.Parameters.AddWithValue("@nSupCGST", tbusbooking_det_Class.nSupCGST);
        cmd.Parameters.AddWithValue("@nSupSGST", tbusbooking_det_Class.nSupSGST);
        cmd.Parameters.AddWithValue("@nSupIGST", tbusbooking_det_Class.nSupIGST);
        cmd.Parameters.AddWithValue("@nSupplierCost", tbusbooking_det_Class.nSupplierCost);
        cmd.Parameters.AddWithValue("@nClntScType", tbusbooking_det_Class.nClntScType);
        cmd.Parameters.AddWithValue("@nClntScPercent", tbusbooking_det_Class.nClntScPercent);
        cmd.Parameters.AddWithValue("@nClntScAmount", tbusbooking_det_Class.nClntScAmount);
        cmd.Parameters.AddWithValue("@nClntTDSType", tbusbooking_det_Class.nClntTDSType);
        cmd.Parameters.AddWithValue("@nClntTDSPercent", tbusbooking_det_Class.nClntTDSPercent);
        cmd.Parameters.AddWithValue("@nClntTDSAmount", tbusbooking_det_Class.nClntTDSAmount);
        cmd.Parameters.AddWithValue("@nDiscount", tbusbooking_det_Class.nDiscount);
        cmd.Parameters.AddWithValue("@bClntTax", tbusbooking_det_Class.bClntTax);
        cmd.Parameters.AddWithValue("@nClntCGst", tbusbooking_det_Class.nClntCGst);
        cmd.Parameters.AddWithValue("@nClntSGst", tbusbooking_det_Class.nClntSGst);
        cmd.Parameters.AddWithValue("@nClntIGst", tbusbooking_det_Class.nClntIGst);
        cmd.Parameters.AddWithValue("@nClientCost", tbusbooking_det_Class.nClientCost);
        cmd.Parameters.AddWithValue("@sRemarks", tbusbooking_det_Class.sRemarks);
        cmd.Parameters.AddWithValue("@nClntSc2Percent", tbusbooking_det_Class.nClntSc2Percent);
        cmd.Parameters.AddWithValue("@nClntSc2Amount", tbusbooking_det_Class.nClntSc2Amount);
        cmd.Parameters.AddWithValue("@nClntOtherChrgs", tbusbooking_det_Class.nClntOtherChrgs);
        cmd.Parameters.AddWithValue("@nSupDiscount", tbusbooking_det_Class.nSupDiscount);
        cmd.Parameters.AddWithValue("@nConfigID", ConfigID);

        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(tbusbooking_det_Class tbusbooking_det_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(tbusbooking_det_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch (Exception ex)
        {
            //throw;
            returnValue = ex.Message.ToString();
        }
    }
    public void FillReapter(tbusbooking_det_Class tbusbooking_det_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(tbusbooking_det_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(tbusbooking_det_Class tbusbooking_det_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(tbusbooking_det_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewtbusbooking_det");
            return ds.Tables["viewtbusbooking_det"];
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
    public DropDownList ddlOperation(tbusbooking_det_Class tbusbooking_det_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(tbusbooking_det_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewtbusbooking_det");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a busbooking_det", "0"));
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
