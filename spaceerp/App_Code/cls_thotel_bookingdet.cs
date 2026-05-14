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
public class thotel_bookingdet_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnHotelBookingDetID = string.Empty;
    private string objnHotelBookingID = string.Empty;
    private string objsReferenceNo = string.Empty;
    private string objsGuestName = string.Empty;
    private string objnHotelNameID = string.Empty;
    private string objsNationality = string.Empty;
    private string objnRoomType = string.Empty;
    private string objsMeal = string.Empty;
    private string objnNoOfRooms = string.Empty;
    private string objnExtraBed = string.Empty;
    private string objdtCheckIn = string.Empty;
    private string objdtCheckOut = string.Empty;
    private string objnTotalNights = string.Empty;
    private string objnRate = string.Empty;
    private string objnTotal = string.Empty;
    private string objnProfitTypeID = string.Empty;
    private string objnProfitPercent = string.Empty;
    private string objnProfitAmount = string.Empty;
    private string objnDiscount = string.Empty;
    private string objnSellingCost = string.Empty;
    private string objsRemarks = string.Empty;
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
    private string objnBasicAmt = string.Empty;
    private string objnSupOtrTax = string.Empty;
    private string objnSupComm = string.Empty;
    private string objnClntSc2Percent = string.Empty;
    private string objnClntSc2Amount = string.Empty;
    private string objnClntOtrChrgs = string.Empty;
    private string objnCityID = string.Empty;
    private string objnBookTypeID = string.Empty;
    private string objsPaxNos = string.Empty;
    private string objnStatusID = string.Empty;
    private string objnSupDiscount = string.Empty;
    private string objnConfigID = string.Empty;
    public string nHotelBookingDetID
    {
        get { return objnHotelBookingDetID; }
        set { objnHotelBookingDetID = value; }
    }
    public string nHotelBookingID
    {
        get { return objnHotelBookingID; }
        set { objnHotelBookingID = value; }
    }
    public string sReferenceNo
    {
        get { return objsReferenceNo; }
        set { objsReferenceNo = value; }
    }
    public string sGuestName
    {
        get { return objsGuestName; }
        set { objsGuestName = value; }
    }
    public string nHotelNameID
    {
        get { return objnHotelNameID; }
        set { objnHotelNameID = value; }
    }
    public string sNationality
    {
        get { return objsNationality; }
        set { objsNationality = value; }
    }
    public string nRoomType
    {
        get { return objnRoomType; }
        set { objnRoomType = value; }
    }
    public string sMeal
    {
        get { return objsMeal; }
        set { objsMeal = value; }
    }
    public string nNoOfRooms
    {
        get { return objnNoOfRooms; }
        set { objnNoOfRooms = value; }
    }
    public string nExtraBed
    {
        get { return objnExtraBed; }
        set { objnExtraBed = value; }
    }
    public string dtCheckIn
    {
        get { return objdtCheckIn; }
        set { objdtCheckIn = value; }
    }
    public string dtCheckOut
    {
        get { return objdtCheckOut; }
        set { objdtCheckOut = value; }
    }
    public string nTotalNights
    {
        get { return objnTotalNights; }
        set { objnTotalNights = value; }
    }
    public string nRate
    {
        get { return objnRate; }
        set { objnRate = value; }
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
    public string nBasicAmt
    {
        get { return objnBasicAmt; }
        set { objnBasicAmt = value; }
    }
    public string nSupOtrTax
    {
        get { return objnSupOtrTax; }
        set { objnSupOtrTax = value; }
    }
    public string nSupComm
    {
        get { return objnSupComm; }
        set { objnSupComm = value; }
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
    public string nClntOtrChrgs
    {
        get { return objnClntOtrChrgs; }
        set { objnClntOtrChrgs = value; }
    }
    public string nCityID
    {
        get { return objnCityID; }
        set { objnCityID = value; }
    }
    public string nBookTypeID
    {
        get { return objnBookTypeID; }
        set { objnBookTypeID = value; }
    }
    public string sPaxNos
    {
        get { return objsPaxNos; }
        set { objsPaxNos = value; }
    }
    public string nStatusID
    {
        get { return objnStatusID; }
        set { objnStatusID = value; }
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
    public string User_Operation(thotel_bookingdet_Class thotel_bookingdet_Class, string type)
    {
        SqlCommand cmd = addParameter(thotel_bookingdet_Class, type, "");
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
    public SqlCommand addParameter(thotel_bookingdet_Class thotel_bookingdet_Class, string type, string cond)
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
        SqlCommand cmd = new SqlCommand("SP_thotel_bookingdet", conn); cmd.Parameters.AddWithValue("@nHotelBookingDetID", thotel_bookingdet_Class.nHotelBookingDetID);
        cmd.Parameters.AddWithValue("@nHotelBookingID", thotel_bookingdet_Class.nHotelBookingID);
        cmd.Parameters.AddWithValue("@sReferenceNo", thotel_bookingdet_Class.sReferenceNo);
        cmd.Parameters.AddWithValue("@sGuestName", thotel_bookingdet_Class.sGuestName);
        cmd.Parameters.AddWithValue("@nHotelNameID", thotel_bookingdet_Class.nHotelNameID);
        cmd.Parameters.AddWithValue("@sNationality", thotel_bookingdet_Class.sNationality);
        cmd.Parameters.AddWithValue("@nRoomType", thotel_bookingdet_Class.nRoomType);
        cmd.Parameters.AddWithValue("@sMeal", thotel_bookingdet_Class.sMeal);
        cmd.Parameters.AddWithValue("@nNoOfRooms", thotel_bookingdet_Class.nNoOfRooms);
        cmd.Parameters.AddWithValue("@nExtraBed", thotel_bookingdet_Class.nExtraBed);
        cmd.Parameters.AddWithValue("@dtCheckIn", thotel_bookingdet_Class.dtCheckIn);
        cmd.Parameters.AddWithValue("@dtCheckOut", thotel_bookingdet_Class.dtCheckOut);
        cmd.Parameters.AddWithValue("@nTotalNights", thotel_bookingdet_Class.nTotalNights);
        cmd.Parameters.AddWithValue("@nRate", thotel_bookingdet_Class.nRate);
        cmd.Parameters.AddWithValue("@nTotal", thotel_bookingdet_Class.nTotal);
        cmd.Parameters.AddWithValue("@nProfitTypeID", thotel_bookingdet_Class.nProfitTypeID);
        cmd.Parameters.AddWithValue("@nProfitPercent", thotel_bookingdet_Class.nProfitPercent);
        cmd.Parameters.AddWithValue("@nProfitAmount", thotel_bookingdet_Class.nProfitAmount);
        cmd.Parameters.AddWithValue("@nDiscount", thotel_bookingdet_Class.nDiscount);
        cmd.Parameters.AddWithValue("@nSellingCost", thotel_bookingdet_Class.nSellingCost);
        cmd.Parameters.AddWithValue("@sRemarks", thotel_bookingdet_Class.sRemarks);
        cmd.Parameters.AddWithValue("@nSupScType", thotel_bookingdet_Class.nSupScType);
        cmd.Parameters.AddWithValue("@nSupScpercent", thotel_bookingdet_Class.nSupScpercent);
        cmd.Parameters.AddWithValue("@nSupSCAmount", thotel_bookingdet_Class.nSupSCAmount);
        cmd.Parameters.AddWithValue("@bSupTax", thotel_bookingdet_Class.bSupTax);
        cmd.Parameters.AddWithValue("@nSupCGst", thotel_bookingdet_Class.nSupCGst);
        cmd.Parameters.AddWithValue("@nSupSGst", thotel_bookingdet_Class.nSupSGst);
        cmd.Parameters.AddWithValue("@nSupIGst", thotel_bookingdet_Class.nSupIGst);
        cmd.Parameters.AddWithValue("@bClntTax", thotel_bookingdet_Class.bClntTax);
        cmd.Parameters.AddWithValue("@nClntCGst", thotel_bookingdet_Class.nClntCGst);
        cmd.Parameters.AddWithValue("@nClntSGst", thotel_bookingdet_Class.nClntSGst);
        cmd.Parameters.AddWithValue("@nClntIGst", thotel_bookingdet_Class.nClntIGst);
        cmd.Parameters.AddWithValue("@nSupTdsType", thotel_bookingdet_Class.nSupTdsType);
        cmd.Parameters.AddWithValue("@nSupTdsPercent", thotel_bookingdet_Class.nSupTdsPercent);
        cmd.Parameters.AddWithValue("@nSupTdsAmount", thotel_bookingdet_Class.nSupTdsAmount);
        cmd.Parameters.AddWithValue("@nClntTdsType", thotel_bookingdet_Class.nClntTdsType);
        cmd.Parameters.AddWithValue("@nClntTdsPercent", thotel_bookingdet_Class.nClntTdsPercent);
        cmd.Parameters.AddWithValue("@nClntTdsAmount", thotel_bookingdet_Class.nClntTdsAmount);
        cmd.Parameters.AddWithValue("@nBasicAmt", thotel_bookingdet_Class.nBasicAmt);
        cmd.Parameters.AddWithValue("@nSupOtrTax", thotel_bookingdet_Class.nSupOtrTax);
        cmd.Parameters.AddWithValue("@nSupComm", thotel_bookingdet_Class.nSupComm);
        cmd.Parameters.AddWithValue("@nClntSc2Percent", thotel_bookingdet_Class.nClntSc2Percent);
        cmd.Parameters.AddWithValue("@nClntSc2Amount", thotel_bookingdet_Class.nClntSc2Amount);
        cmd.Parameters.AddWithValue("@nClntOtrChrgs", thotel_bookingdet_Class.nClntOtrChrgs);
        cmd.Parameters.AddWithValue("@nCityID", thotel_bookingdet_Class.nCityID);
        cmd.Parameters.AddWithValue("@nBookTypeID", thotel_bookingdet_Class.nBookTypeID);
        cmd.Parameters.AddWithValue("@sPaxNos", thotel_bookingdet_Class.sPaxNos);
        cmd.Parameters.AddWithValue("@nStatusID", thotel_bookingdet_Class.nStatusID);
        cmd.Parameters.AddWithValue("@nSupDiscount", thotel_bookingdet_Class.nSupDiscount);
        cmd.Parameters.AddWithValue("@nConfigID", nConfigID);

        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(thotel_bookingdet_Class thotel_bookingdet_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(thotel_bookingdet_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(thotel_bookingdet_Class thotel_bookingdet_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(thotel_bookingdet_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(thotel_bookingdet_Class thotel_bookingdet_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(thotel_bookingdet_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewthotel_bookingdet");
            return ds.Tables["viewthotel_bookingdet"];
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
    public DropDownList ddlOperation(thotel_bookingdet_Class thotel_bookingdet_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(thotel_bookingdet_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewthotel_bookingdet");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a hotel_bookingdet", "0"));
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
