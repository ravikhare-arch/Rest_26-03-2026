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
public class tcar_bookingdet_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnCarBookingDetID = string.Empty;
    private string objnCarBookingID = string.Empty;
    private string objsReferenceNo = string.Empty;
    private string objsPaxtName = string.Empty;
    private string objsAdult = string.Empty;
    private string objsChild = string.Empty;
    private string objsInfant = string.Empty;
    private string objsTelephone = string.Empty;
    private string objnDriverID = string.Empty;
    private string objnVehiclerID = string.Empty;
    private string objdtTripDate = string.Empty;
    private string objsPickupPlace = string.Empty;
    private string objsCRNo = string.Empty;
    private string objsPayType = string.Empty;
    private string objnBasicFare = string.Empty;
    private string objnExtraKM = string.Empty;
    private string objnExtraHrs = string.Empty;
    private string objnDriverCharges = string.Empty;
    private string objnTollPark = string.Empty;
    private string objnFuel = string.Empty;
    private string objnSupScType = string.Empty;
    private string objnSupScpercent = string.Empty;
    private string objnSupSCAmount = string.Empty;
    private string objbSupTax = string.Empty;
    private string objnSupCGst = string.Empty;
    private string objnSupSGst = string.Empty;
    private string objnSupIGst = string.Empty;
    private string objnSupTdsType = string.Empty;
    private string objnSupTdsPercent = string.Empty;
    private string objnSupTdsAmount = string.Empty;
    private string objnSupplierCost = string.Empty;
    private string objnClntScType = string.Empty;
    private string objnClntScPercent = string.Empty;
    private string objnClntScAmount = string.Empty;
    private string objnClntTdsType = string.Empty;
    private string objnClntTdsPercent = string.Empty;
    private string objnClntTdsAmount = string.Empty;
    private string objnDiscount = string.Empty;
    private string objbClntTax = string.Empty;
    private string objnClntCGst = string.Empty;
    private string objnClntSGst = string.Empty;
    private string objnClntIGst = string.Empty;
    private string objnClientCost = string.Empty;
    private string objnClntSc2Percent = string.Empty;
    private string objnClntSc2Amount = string.Empty;
    private string objnClntOtherChrgs = string.Empty;
    private string objnSupDiscount = string.Empty;
    private string objnConfigID = string.Empty;
    public string nCarBookingDetID
    {
        get { return objnCarBookingDetID; }
        set { objnCarBookingDetID = value; }
    }
    public string nCarBookingID
    {
        get { return objnCarBookingID; }
        set { objnCarBookingID = value; }
    }
    public string sReferenceNo
    {
        get { return objsReferenceNo; }
        set { objsReferenceNo = value; }
    }
    public string sPaxtName
    {
        get { return objsPaxtName; }
        set { objsPaxtName = value; }
    }
    public string sAdult
    {
        get { return objsAdult; }
        set { objsAdult = value; }
    }
    public string sChild
    {
        get { return objsChild; }
        set { objsChild = value; }
    }
    public string sInfant
    {
        get { return objsInfant; }
        set { objsInfant = value; }
    }
    public string sTelephone
    {
        get { return objsTelephone; }
        set { objsTelephone = value; }
    }
    public string nDriverID
    {
        get { return objnDriverID; }
        set { objnDriverID = value; }
    }
    public string nVehiclerID
    {
        get { return objnVehiclerID; }
        set { objnVehiclerID = value; }
    }
    public string dtTripDate
    {
        get { return objdtTripDate; }
        set { objdtTripDate = value; }
    }
    public string sPickupPlace
    {
        get { return objsPickupPlace; }
        set { objsPickupPlace = value; }
    }
    public string sCRNo
    {
        get { return objsCRNo; }
        set { objsCRNo = value; }
    }
    public string sPayType
    {
        get { return objsPayType; }
        set { objsPayType = value; }
    }
    public string nBasicFare
    {
        get { return objnBasicFare; }
        set { objnBasicFare = value; }
    }
    public string nExtraKM
    {
        get { return objnExtraKM; }
        set { objnExtraKM = value; }
    }
    public string nExtraHrs
    {
        get { return objnExtraHrs; }
        set { objnExtraHrs = value; }
    }
    public string nDriverCharges
    {
        get { return objnDriverCharges; }
        set { objnDriverCharges = value; }
    }
    public string nTollPark
    {
        get { return objnTollPark; }
        set { objnTollPark = value; }
    }
    public string nFuel
    {
        get { return objnFuel; }
        set { objnFuel = value; }
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
    public string User_Operation(tcar_bookingdet_Class tcar_bookingdet_Class, string type)
    {
        SqlCommand cmd = addParameter(tcar_bookingdet_Class, type, "");
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
    public SqlCommand addParameter(tcar_bookingdet_Class tcar_bookingdet_Class, string type, string cond)
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
        SqlCommand cmd = new SqlCommand("SP_tcar_bookingdet", conn); cmd.Parameters.AddWithValue("@nCarBookingDetID", tcar_bookingdet_Class.nCarBookingDetID);
        cmd.Parameters.AddWithValue("@nCarBookingID", tcar_bookingdet_Class.nCarBookingID);
        cmd.Parameters.AddWithValue("@sReferenceNo", tcar_bookingdet_Class.sReferenceNo);
        cmd.Parameters.AddWithValue("@sPaxtName", tcar_bookingdet_Class.sPaxtName);
        cmd.Parameters.AddWithValue("@sAdult", tcar_bookingdet_Class.sAdult);
        cmd.Parameters.AddWithValue("@sChild", tcar_bookingdet_Class.sChild);
        cmd.Parameters.AddWithValue("@sInfant", tcar_bookingdet_Class.sInfant);
        cmd.Parameters.AddWithValue("@sTelephone", tcar_bookingdet_Class.sTelephone);
        cmd.Parameters.AddWithValue("@nDriverID", tcar_bookingdet_Class.nDriverID);
        cmd.Parameters.AddWithValue("@nVehiclerID", tcar_bookingdet_Class.nVehiclerID);
        cmd.Parameters.AddWithValue("@dtTripDate", tcar_bookingdet_Class.dtTripDate);
        cmd.Parameters.AddWithValue("@sPickupPlace", tcar_bookingdet_Class.sPickupPlace);
        cmd.Parameters.AddWithValue("@sCRNo", tcar_bookingdet_Class.sCRNo);
        cmd.Parameters.AddWithValue("@sPayType", tcar_bookingdet_Class.sPayType);
        cmd.Parameters.AddWithValue("@nBasicFare", tcar_bookingdet_Class.nBasicFare);
        cmd.Parameters.AddWithValue("@nExtraKM", tcar_bookingdet_Class.nExtraKM);
        cmd.Parameters.AddWithValue("@nExtraHrs", tcar_bookingdet_Class.nExtraHrs);
        cmd.Parameters.AddWithValue("@nDriverCharges", tcar_bookingdet_Class.nDriverCharges);
        cmd.Parameters.AddWithValue("@nTollPark", tcar_bookingdet_Class.nTollPark);
        cmd.Parameters.AddWithValue("@nFuel", tcar_bookingdet_Class.nFuel);
        cmd.Parameters.AddWithValue("@nSupScType", tcar_bookingdet_Class.nSupScType);
        cmd.Parameters.AddWithValue("@nSupScpercent", tcar_bookingdet_Class.nSupScpercent);
        cmd.Parameters.AddWithValue("@nSupSCAmount", tcar_bookingdet_Class.nSupSCAmount);
        cmd.Parameters.AddWithValue("@bSupTax", tcar_bookingdet_Class.bSupTax);
        cmd.Parameters.AddWithValue("@nSupCGst", tcar_bookingdet_Class.nSupCGst);
        cmd.Parameters.AddWithValue("@nSupSGst", tcar_bookingdet_Class.nSupSGst);
        cmd.Parameters.AddWithValue("@nSupIGst", tcar_bookingdet_Class.nSupIGst);
        cmd.Parameters.AddWithValue("@nSupTdsType", tcar_bookingdet_Class.nSupTdsType);
        cmd.Parameters.AddWithValue("@nSupTdsPercent", tcar_bookingdet_Class.nSupTdsPercent);
        cmd.Parameters.AddWithValue("@nSupTdsAmount", tcar_bookingdet_Class.nSupTdsAmount);
        cmd.Parameters.AddWithValue("@nSupplierCost", tcar_bookingdet_Class.nSupplierCost);
        cmd.Parameters.AddWithValue("@nClntScType", tcar_bookingdet_Class.nClntScType);
        cmd.Parameters.AddWithValue("@nClntScPercent", tcar_bookingdet_Class.nClntScPercent);
        cmd.Parameters.AddWithValue("@nClntScAmount", tcar_bookingdet_Class.nClntScAmount);
        cmd.Parameters.AddWithValue("@nClntTdsType", tcar_bookingdet_Class.nClntTdsType);
        cmd.Parameters.AddWithValue("@nClntTdsPercent", tcar_bookingdet_Class.nClntTdsPercent);
        cmd.Parameters.AddWithValue("@nClntTdsAmount", tcar_bookingdet_Class.nClntTdsAmount);
        cmd.Parameters.AddWithValue("@nDiscount", tcar_bookingdet_Class.nDiscount);
        cmd.Parameters.AddWithValue("@bClntTax", tcar_bookingdet_Class.bClntTax);
        cmd.Parameters.AddWithValue("@nClntCGst", tcar_bookingdet_Class.nClntCGst);
        cmd.Parameters.AddWithValue("@nClntSGst", tcar_bookingdet_Class.nClntSGst);
        cmd.Parameters.AddWithValue("@nClntIGst", tcar_bookingdet_Class.nClntIGst);
        cmd.Parameters.AddWithValue("@nClientCost", tcar_bookingdet_Class.nClientCost);
        cmd.Parameters.AddWithValue("@nClntSc2Percent", tcar_bookingdet_Class.nClntSc2Percent);
        cmd.Parameters.AddWithValue("@nClntSc2Amount", tcar_bookingdet_Class.nClntSc2Amount);
        cmd.Parameters.AddWithValue("@nClntOtherChrgs", tcar_bookingdet_Class.nClntOtherChrgs);
        cmd.Parameters.AddWithValue("@nSupDiscount", tcar_bookingdet_Class.nSupDiscount);
        cmd.Parameters.AddWithValue("@nConfigID", ConfigID);

        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(tcar_bookingdet_Class tcar_bookingdet_Class, GridView grd, string type, string cond)
    {
       
            DataTable da = viewData(tcar_bookingdet_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        
    }
    public void FillReapter(tcar_bookingdet_Class tcar_bookingdet_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(tcar_bookingdet_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(tcar_bookingdet_Class tcar_bookingdet_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(tcar_bookingdet_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewtcar_bookingdet");
            return ds.Tables["viewtcar_bookingdet"];
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
    public DropDownList ddlOperation(tcar_bookingdet_Class tcar_bookingdet_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(tcar_bookingdet_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewtcar_bookingdet");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a car_bookingdet", "0"));
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
