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
public class texcursion_bookingdet_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnExcursionBookingDetID = string.Empty;
    private string objnExcursionBookingID = string.Empty;
    private string objsExcursionReferenceNo = string.Empty;
    private string objsGuestName = string.Empty;
    private string objnExcursionTypeID = string.Empty;
    private string objnDiverNameID = string.Empty;
    private string objsPickupPlace = string.Empty;
    private string objsTelephone = string.Empty;
    private string objsJobNo = string.Empty;
    private string objdtPickupDate = string.Empty;
    private string objsPickupTime = string.Empty;
    private string objnPickTimeFormatID = string.Empty;
    private string objsDropTime = string.Empty;
    private string objnDropTimeFormatID = string.Empty;
    private string objnAdultPax = string.Empty;
    private string objnAdultPaxRate = string.Empty;
    private string objnChildPax = string.Empty;
    private string objnChildPaxRate = string.Empty;
    private string objnTotal = string.Empty;
    private string objnProfitTypeID = string.Empty;
    private string objnProfitPercent = string.Empty;
    private string objnProfitAmount = string.Empty;
    private string objnDiscount = string.Empty;
    private string objnSellingCost = string.Empty;
    private string objsRemarks = string.Empty;
    private string objnInfPax = string.Empty;
    private string objnInfPaxRate = string.Empty;
    private string objnSupScType = string.Empty;
    private string objnSupScpercent = string.Empty;
    private string objnSupSCAmount = string.Empty;
    private string objbSupTax = string.Empty;
    private string objnSupCGst = string.Empty;
    private string objnSupSGst = string.Empty;
    private string objnSupIGst = string.Empty;
    private string objbClntTax = string.Empty;
    private string objnClntCGst = string.Empty;
    private string objnClntSGst = string.Empty;
    private string objnClntIGst = string.Empty;
    private string objnSupTdsType = string.Empty;
    private string objnSupTdsPercent = string.Empty;
    private string objnSupTdsAmount = string.Empty;
    private string objnClntTdsType = string.Empty;
    private string objnClntTdsPercent = string.Empty;
    private string objnClntTdsAmount = string.Empty;
    private string objnClntSc2Percent = string.Empty;
    private string objnClntSc2Amount = string.Empty;
    private string objnClntOtherChrgs = string.Empty;
    private string objnSupDiscount = string.Empty;
    private string objnConfigID = string.Empty;
    public string nExcursionBookingDetID
    {
        get { return objnExcursionBookingDetID; }
        set { objnExcursionBookingDetID = value; }
    }
    public string nExcursionBookingID
    {
        get { return objnExcursionBookingID; }
        set { objnExcursionBookingID = value; }
    }
    public string sExcursionReferenceNo
    {
        get { return objsExcursionReferenceNo; }
        set { objsExcursionReferenceNo = value; }
    }
    public string sGuestName
    {
        get { return objsGuestName; }
        set { objsGuestName = value; }
    }
    public string nExcursionTypeID
    {
        get { return objnExcursionTypeID; }
        set { objnExcursionTypeID = value; }
    }
    public string nDiverNameID
    {
        get { return objnDiverNameID; }
        set { objnDiverNameID = value; }
    }
    public string sPickupPlace
    {
        get { return objsPickupPlace; }
        set { objsPickupPlace = value; }
    }
    public string sTelephone
    {
        get { return objsTelephone; }
        set { objsTelephone = value; }
    }
    public string sJobNo
    {
        get { return objsJobNo; }
        set { objsJobNo = value; }
    }
    public string dtPickupDate
    {
        get { return objdtPickupDate; }
        set { objdtPickupDate = value; }
    }
    public string sPickupTime
    {
        get { return objsPickupTime; }
        set { objsPickupTime = value; }
    }
    public string nPickTimeFormatID
    {
        get { return objnPickTimeFormatID; }
        set { objnPickTimeFormatID = value; }
    }
    public string sDropTime
    {
        get { return objsDropTime; }
        set { objsDropTime = value; }
    }
    public string nDropTimeFormatID
    {
        get { return objnDropTimeFormatID; }
        set { objnDropTimeFormatID = value; }
    }
    public string nAdultPax
    {
        get { return objnAdultPax; }
        set { objnAdultPax = value; }
    }
    public string nAdultPaxRate
    {
        get { return objnAdultPaxRate; }
        set { objnAdultPaxRate = value; }
    }
    public string nChildPax
    {
        get { return objnChildPax; }
        set { objnChildPax = value; }
    }
    public string nChildPaxRate
    {
        get { return objnChildPaxRate; }
        set { objnChildPaxRate = value; }
    }
    public string nTotal
    {
        get { return objnTotal; }
        set { objnTotal = value; }
    }
    public string nProfitTypeID
    {
        get { return objnProfitTypeID; }
        set { objnProfitTypeID = value; }
    }
    public string nProfitPercent
    {
        get { return objnProfitPercent; }
        set { objnProfitPercent = value; }
    }
    public string nProfitAmount
    {
        get { return objnProfitAmount; }
        set { objnProfitAmount = value; }
    }
    public string nDiscount
    {
        get { return objnDiscount; }
        set { objnDiscount = value; }
    }
    public string nSellingCost
    {
        get { return objnSellingCost; }
        set { objnSellingCost = value; }
    }
    public string sRemarks
    {
        get { return objsRemarks; }
        set { objsRemarks = value; }
    }
    public string nInfPax
    {
        get { return objnInfPax; }
        set { objnInfPax = value; }
    }
    public string nInfPaxRate
    {
        get { return objnInfPaxRate; }
        set { objnInfPaxRate = value; }
    }
    public string nSupScType
    {
        get { return objnSupScType; }
        set { objnSupScType = value; }
    }
    public string nSupScpercent
    {
        get { return objnSupScpercent; }
        set { objnSupScpercent = value; }
    }
    public string nSupSCAmount
    {
        get { return objnSupSCAmount; }
        set { objnSupSCAmount = value; }
    }
    public string bSupTax
    {
        get { return objbSupTax; }
        set { objbSupTax = value; }
    }
    public string nSupCGst
    {
        get { return objnSupCGst; }
        set { objnSupCGst = value; }
    }
    public string nSupSGst
    {
        get { return objnSupSGst; }
        set { objnSupSGst = value; }
    }
    public string nSupIGst
    {
        get { return objnSupIGst; }
        set { objnSupIGst = value; }
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
    public string nSupTdsType
    {
        get { return objnSupTdsType; }
        set { objnSupTdsType = value; }
    }
    public string nSupTdsPercent
    {
        get { return objnSupTdsPercent; }
        set { objnSupTdsPercent = value; }
    }
    public string nSupTdsAmount
    {
        get { return objnSupTdsAmount; }
        set { objnSupTdsAmount = value; }
    }
    public string nClntTdsType
    {
        get { return objnClntTdsType; }
        set { objnClntTdsType = value; }
    }
    public string nClntTdsPercent
    {
        get { return objnClntTdsPercent; }
        set { objnClntTdsPercent = value; }
    }
    public string nClntTdsAmount
    {
        get { return objnClntTdsAmount; }
        set { objnClntTdsAmount = value; }
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
    public string User_Operation(texcursion_bookingdet_Class texcursion_bookingdet_Class, string type)
    {
        SqlCommand cmd = addParameter(texcursion_bookingdet_Class, type, "");
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
    public SqlCommand addParameter(texcursion_bookingdet_Class texcursion_bookingdet_Class, string type, string cond)
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
        SqlCommand cmd = new SqlCommand("SP_texcursion_bookingdet", conn); cmd.Parameters.AddWithValue("@nExcursionBookingDetID", texcursion_bookingdet_Class.nExcursionBookingDetID);
        cmd.Parameters.AddWithValue("@nExcursionBookingID", texcursion_bookingdet_Class.nExcursionBookingID);
        cmd.Parameters.AddWithValue("@sExcursionReferenceNo", texcursion_bookingdet_Class.sExcursionReferenceNo);
        cmd.Parameters.AddWithValue("@sGuestName", texcursion_bookingdet_Class.sGuestName);
        cmd.Parameters.AddWithValue("@nExcursionTypeID", texcursion_bookingdet_Class.nExcursionTypeID);
        cmd.Parameters.AddWithValue("@nDiverNameID", texcursion_bookingdet_Class.nDiverNameID);
        cmd.Parameters.AddWithValue("@sPickupPlace", texcursion_bookingdet_Class.sPickupPlace);
        cmd.Parameters.AddWithValue("@sTelephone", texcursion_bookingdet_Class.sTelephone);
        cmd.Parameters.AddWithValue("@sJobNo", texcursion_bookingdet_Class.sJobNo);
        cmd.Parameters.AddWithValue("@dtPickupDate", texcursion_bookingdet_Class.dtPickupDate);
        cmd.Parameters.AddWithValue("@sPickupTime", texcursion_bookingdet_Class.sPickupTime);
        cmd.Parameters.AddWithValue("@nPickTimeFormatID", texcursion_bookingdet_Class.nPickTimeFormatID);
        cmd.Parameters.AddWithValue("@sDropTime", texcursion_bookingdet_Class.sDropTime);
        cmd.Parameters.AddWithValue("@nDropTimeFormatID", texcursion_bookingdet_Class.nDropTimeFormatID);
        cmd.Parameters.AddWithValue("@nAdultPax", texcursion_bookingdet_Class.nAdultPax);
        cmd.Parameters.AddWithValue("@nAdultPaxRate", texcursion_bookingdet_Class.nAdultPaxRate);
        cmd.Parameters.AddWithValue("@nChildPax", texcursion_bookingdet_Class.nChildPax);
        cmd.Parameters.AddWithValue("@nChildPaxRate", texcursion_bookingdet_Class.nChildPaxRate);
        cmd.Parameters.AddWithValue("@nTotal", texcursion_bookingdet_Class.nTotal);
        cmd.Parameters.AddWithValue("@nProfitTypeID", texcursion_bookingdet_Class.nProfitTypeID);
        cmd.Parameters.AddWithValue("@nProfitPercent", texcursion_bookingdet_Class.nProfitPercent);
        cmd.Parameters.AddWithValue("@nProfitAmount", texcursion_bookingdet_Class.nProfitAmount);
        cmd.Parameters.AddWithValue("@nDiscount", texcursion_bookingdet_Class.nDiscount);
        cmd.Parameters.AddWithValue("@nSellingCost", texcursion_bookingdet_Class.nSellingCost);
        cmd.Parameters.AddWithValue("@sRemarks", texcursion_bookingdet_Class.sRemarks);
        cmd.Parameters.AddWithValue("@nInfPax", texcursion_bookingdet_Class.nInfPax);
        cmd.Parameters.AddWithValue("@nInfPaxRate", texcursion_bookingdet_Class.nInfPaxRate);
        cmd.Parameters.AddWithValue("@nSupScType", texcursion_bookingdet_Class.nSupScType);
        cmd.Parameters.AddWithValue("@nSupScpercent", texcursion_bookingdet_Class.nSupScpercent);
        cmd.Parameters.AddWithValue("@nSupSCAmount", texcursion_bookingdet_Class.nSupSCAmount);
        cmd.Parameters.AddWithValue("@bSupTax", texcursion_bookingdet_Class.bSupTax);
        cmd.Parameters.AddWithValue("@nSupCGst", texcursion_bookingdet_Class.nSupCGst);
        cmd.Parameters.AddWithValue("@nSupSGst", texcursion_bookingdet_Class.nSupSGst);
        cmd.Parameters.AddWithValue("@nSupIGst", texcursion_bookingdet_Class.nSupIGst);
        cmd.Parameters.AddWithValue("@bClntTax", texcursion_bookingdet_Class.bClntTax);
        cmd.Parameters.AddWithValue("@nClntCGst", texcursion_bookingdet_Class.nClntCGst);
        cmd.Parameters.AddWithValue("@nClntSGst", texcursion_bookingdet_Class.nClntSGst);
        cmd.Parameters.AddWithValue("@nClntIGst", texcursion_bookingdet_Class.nClntIGst);
        cmd.Parameters.AddWithValue("@nSupTdsType", texcursion_bookingdet_Class.nSupTdsType);
        cmd.Parameters.AddWithValue("@nSupTdsPercent", texcursion_bookingdet_Class.nSupTdsPercent);
        cmd.Parameters.AddWithValue("@nSupTdsAmount", texcursion_bookingdet_Class.nSupTdsAmount);
        cmd.Parameters.AddWithValue("@nClntTdsType", texcursion_bookingdet_Class.nClntTdsType);
        cmd.Parameters.AddWithValue("@nClntTdsPercent", texcursion_bookingdet_Class.nClntTdsPercent);
        cmd.Parameters.AddWithValue("@nClntTdsAmount", texcursion_bookingdet_Class.nClntTdsAmount);
        cmd.Parameters.AddWithValue("@nClntSc2Percent", texcursion_bookingdet_Class.nClntSc2Percent);
        cmd.Parameters.AddWithValue("@nClntSc2Amount", texcursion_bookingdet_Class.nClntSc2Amount);
        cmd.Parameters.AddWithValue("@nClntOtherChrgs", texcursion_bookingdet_Class.nClntOtherChrgs);
        cmd.Parameters.AddWithValue("@nSupDiscount", texcursion_bookingdet_Class.nSupDiscount);
        cmd.Parameters.AddWithValue("@nConfigID", ConfigID);

        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(texcursion_bookingdet_Class texcursion_bookingdet_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(texcursion_bookingdet_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(texcursion_bookingdet_Class texcursion_bookingdet_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(texcursion_bookingdet_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(texcursion_bookingdet_Class texcursion_bookingdet_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(texcursion_bookingdet_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewtexcursion_bookingdet");
            return ds.Tables["viewtexcursion_bookingdet"];
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
    public DropDownList ddlOperation(texcursion_bookingdet_Class texcursion_bookingdet_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(texcursion_bookingdet_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewtexcursion_bookingdet");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a excursion_bookingdet", "0"));
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
