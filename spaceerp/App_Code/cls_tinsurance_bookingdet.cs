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
public class tinsurance_bookingdet_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnInsuranceBookingDetID = string.Empty;
    private string objnInsuranceBookingID = string.Empty;
    private string objsPolicyNo = string.Empty;
    private string objsPaxName = string.Empty;
    private string objsGender = string.Empty;
    private string objsAge = string.Empty;
    private string objsPlanNo = string.Empty;
    private string objsAssignee = string.Empty;
    private string objsPassport = string.Empty;
    private string objsCArea = string.Empty;
    private string objsProposal = string.Empty;
    private string objdtTravelFromDate = string.Empty;
    private string objdtTravelToDate = string.Empty;
    private string objsAddress = string.Empty;
    private string objnBasicFare = string.Empty;
    private string objnOtherTax = string.Empty;
    private string objnSupComm = string.Empty;
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
    private string objsRemarks = string.Empty;
    private string objnClntSc2Percent = string.Empty;
    private string objnClntSc2Amount = string.Empty;
    private string objnClntOtherChrgs = string.Empty;
    private string objnBookTypeID = string.Empty;
    private string objnCountryID = string.Empty;
    private string objnInsType = string.Empty;
    private string objdtInsIssueDate = string.Empty;
    private string objdtInsExpiryDate = string.Empty;
    private string objsNoofDays = string.Empty;
    private string objnStatusID = string.Empty;
    private string objnSupDiscount = string.Empty;
    private string objnConfigID = string.Empty;
    public string nInsuranceBookingDetID
    {
        get { return objnInsuranceBookingDetID; }
        set { objnInsuranceBookingDetID = value; }
    }
    public string nInsuranceBookingID
    {
        get { return objnInsuranceBookingID; }
        set { objnInsuranceBookingID = value; }
    }
    public string sPolicyNo
    {
        get { return objsPolicyNo; }
        set { objsPolicyNo = value; }
    }
    public string sPaxName
    {
        get { return objsPaxName; }
        set { objsPaxName = value; }
    }
    public string sGender
    {
        get { return objsGender; }
        set { objsGender = value; }
    }
    public string sAge
    {
        get { return objsAge; }
        set { objsAge = value; }
    }
    public string sPlanNo
    {
        get { return objsPlanNo; }
        set { objsPlanNo = value; }
    }
    public string sAssignee
    {
        get { return objsAssignee; }
        set { objsAssignee = value; }
    }
    public string sPassport
    {
        get { return objsPassport; }
        set { objsPassport = value; }
    }
    public string sCArea
    {
        get { return objsCArea; }
        set { objsCArea = value; }
    }
    public string sProposal
    {
        get { return objsProposal; }
        set { objsProposal = value; }
    }
    public string dtTravelFromDate
    {
        get { return objdtTravelFromDate; }
        set { objdtTravelFromDate = value; }
    }
    public string dtTravelToDate
    {
        get { return objdtTravelToDate; }
        set { objdtTravelToDate = value; }
    }
    public string sAddress
    {
        get { return objsAddress; }
        set { objsAddress = value; }
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
    public string nBookTypeID
    {
        get { return objnBookTypeID; }
        set { objnBookTypeID = value; }
    }
    public string nCountryID
    {
        get { return objnCountryID; }
        set { objnCountryID = value; }
    }
    public string nInsType
    {
        get { return objnInsType; }
        set { objnInsType = value; }
    }
    public string dtInsIssueDate
    {
        get { return objdtInsIssueDate; }
        set { objdtInsIssueDate = value; }
    }
    public string dtInsExpiryDate
    {
        get { return objdtInsExpiryDate; }
        set { objdtInsExpiryDate = value; }
    }
    public string sNoofDays
    {
        get { return objsNoofDays; }
        set { objsNoofDays = value; }
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
    public string User_Operation(tinsurance_bookingdet_Class tinsurance_bookingdet_Class, string type)
    {
        SqlCommand cmd = addParameter(tinsurance_bookingdet_Class, type, "");
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
    public SqlCommand addParameter(tinsurance_bookingdet_Class tinsurance_bookingdet_Class, string type, string cond)
    {
        string uid,nConfigID;
        if (Session["uid"] == null)
            uid = "0";
        else
            uid = Session["uid"].ToString();

        if (Session["ConfigID"] == null)
            nConfigID = "0";
        else
            nConfigID = Session["ConfigID"].ToString();

        conn = connobj.makeConnection();
        SqlCommand cmd = new SqlCommand("SP_tinsurance_bookingdet", conn); cmd.Parameters.AddWithValue("@nInsuranceBookingDetID", tinsurance_bookingdet_Class.nInsuranceBookingDetID);
        cmd.Parameters.AddWithValue("@nInsuranceBookingID", tinsurance_bookingdet_Class.nInsuranceBookingID);
        cmd.Parameters.AddWithValue("@sPolicyNo", tinsurance_bookingdet_Class.sPolicyNo);
        cmd.Parameters.AddWithValue("@sPaxName", tinsurance_bookingdet_Class.sPaxName);
        cmd.Parameters.AddWithValue("@sGender", tinsurance_bookingdet_Class.sGender);
        cmd.Parameters.AddWithValue("@sAge", tinsurance_bookingdet_Class.sAge);
        cmd.Parameters.AddWithValue("@sPlanNo", tinsurance_bookingdet_Class.sPlanNo);
        cmd.Parameters.AddWithValue("@sAssignee", tinsurance_bookingdet_Class.sAssignee);
        cmd.Parameters.AddWithValue("@sPassport", tinsurance_bookingdet_Class.sPassport);
        cmd.Parameters.AddWithValue("@sCArea", tinsurance_bookingdet_Class.sCArea);
        cmd.Parameters.AddWithValue("@sProposal", tinsurance_bookingdet_Class.sProposal);
        cmd.Parameters.AddWithValue("@dtTravelFromDate", tinsurance_bookingdet_Class.dtTravelFromDate);
        cmd.Parameters.AddWithValue("@dtTravelToDate", tinsurance_bookingdet_Class.dtTravelToDate);
        cmd.Parameters.AddWithValue("@sAddress", tinsurance_bookingdet_Class.sAddress);
        cmd.Parameters.AddWithValue("@nBasicFare", tinsurance_bookingdet_Class.nBasicFare);
        cmd.Parameters.AddWithValue("@nOtherTax", tinsurance_bookingdet_Class.nOtherTax);
        cmd.Parameters.AddWithValue("@nSupComm", tinsurance_bookingdet_Class.nSupComm);
        cmd.Parameters.AddWithValue("@nSupScType", tinsurance_bookingdet_Class.nSupScType);
        cmd.Parameters.AddWithValue("@nSupScpercent", tinsurance_bookingdet_Class.nSupScpercent);
        cmd.Parameters.AddWithValue("@nSupSCAmount", tinsurance_bookingdet_Class.nSupSCAmount);
        cmd.Parameters.AddWithValue("@bSupTax", tinsurance_bookingdet_Class.bSupTax);
        cmd.Parameters.AddWithValue("@nSupCGst", tinsurance_bookingdet_Class.nSupCGst);
        cmd.Parameters.AddWithValue("@nSupSGst", tinsurance_bookingdet_Class.nSupSGst);
        cmd.Parameters.AddWithValue("@nSupIGst", tinsurance_bookingdet_Class.nSupIGst);
        cmd.Parameters.AddWithValue("@nSupTdsType", tinsurance_bookingdet_Class.nSupTdsType);
        cmd.Parameters.AddWithValue("@nSupTdsPercent", tinsurance_bookingdet_Class.nSupTdsPercent);
        cmd.Parameters.AddWithValue("@nSupTdsAmount", tinsurance_bookingdet_Class.nSupTdsAmount);
        cmd.Parameters.AddWithValue("@nSupplierCost", tinsurance_bookingdet_Class.nSupplierCost);
        cmd.Parameters.AddWithValue("@nClntScType", tinsurance_bookingdet_Class.nClntScType);
        cmd.Parameters.AddWithValue("@nClntScPercent", tinsurance_bookingdet_Class.nClntScPercent);
        cmd.Parameters.AddWithValue("@nClntScAmount", tinsurance_bookingdet_Class.nClntScAmount);
        cmd.Parameters.AddWithValue("@nClntTdsType", tinsurance_bookingdet_Class.nClntTdsType);
        cmd.Parameters.AddWithValue("@nClntTdsPercent", tinsurance_bookingdet_Class.nClntTdsPercent);
        cmd.Parameters.AddWithValue("@nClntTdsAmount", tinsurance_bookingdet_Class.nClntTdsAmount);
        cmd.Parameters.AddWithValue("@nDiscount", tinsurance_bookingdet_Class.nDiscount);
        cmd.Parameters.AddWithValue("@bClntTax", tinsurance_bookingdet_Class.bClntTax);
        cmd.Parameters.AddWithValue("@nClntCGst", tinsurance_bookingdet_Class.nClntCGst);
        cmd.Parameters.AddWithValue("@nClntSGst", tinsurance_bookingdet_Class.nClntSGst);
        cmd.Parameters.AddWithValue("@nClntIGst", tinsurance_bookingdet_Class.nClntIGst);
        cmd.Parameters.AddWithValue("@nClientCost", tinsurance_bookingdet_Class.nClientCost);
        cmd.Parameters.AddWithValue("@sRemarks", tinsurance_bookingdet_Class.sRemarks);
        cmd.Parameters.AddWithValue("@nClntSc2Percent", tinsurance_bookingdet_Class.nClntSc2Percent);
        cmd.Parameters.AddWithValue("@nClntSc2Amount", tinsurance_bookingdet_Class.nClntSc2Amount);
        cmd.Parameters.AddWithValue("@nClntOtherChrgs", tinsurance_bookingdet_Class.nClntOtherChrgs);
        cmd.Parameters.AddWithValue("@nBookTypeID", tinsurance_bookingdet_Class.nBookTypeID);
        cmd.Parameters.AddWithValue("@nCountryID", tinsurance_bookingdet_Class.nCountryID);
        cmd.Parameters.AddWithValue("@nInsType", tinsurance_bookingdet_Class.nInsType);
        cmd.Parameters.AddWithValue("@dtInsIssueDate", tinsurance_bookingdet_Class.dtInsIssueDate);
        cmd.Parameters.AddWithValue("@dtInsExpiryDate", tinsurance_bookingdet_Class.dtInsExpiryDate);
        cmd.Parameters.AddWithValue("@sNoofDays", tinsurance_bookingdet_Class.sNoofDays);
        cmd.Parameters.AddWithValue("@nStatusID", tinsurance_bookingdet_Class.nStatusID);
        cmd.Parameters.AddWithValue("@nSupDiscount", tinsurance_bookingdet_Class.nSupDiscount);
        cmd.Parameters.AddWithValue("@nConfigID", nConfigID);

        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(tinsurance_bookingdet_Class tinsurance_bookingdet_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(tinsurance_bookingdet_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch (Exception ex)
        {
            //valobj.showMsg(ex.Message, lblmsg);
        }
    }
    public void FillReapter(tinsurance_bookingdet_Class tinsurance_bookingdet_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(tinsurance_bookingdet_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(tinsurance_bookingdet_Class tinsurance_bookingdet_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(tinsurance_bookingdet_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewtinsurance_bookingdet");
            return ds.Tables["viewtinsurance_bookingdet"];
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
    public DropDownList ddlOperation(tinsurance_bookingdet_Class tinsurance_bookingdet_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(tinsurance_bookingdet_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewtinsurance_bookingdet");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a insurance_bookingdet", "0"));
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
