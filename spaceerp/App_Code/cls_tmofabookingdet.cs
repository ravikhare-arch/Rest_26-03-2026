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
public class tmofabookingdet_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnMofaBookingDetID = string.Empty;
    private string objnMofaBookingID = string.Empty;
    private string objsEngName = string.Empty;
    private string objsArabicName = string.Empty;
    private string objnNationalityID = string.Empty;
    private string objdtDOBDate = string.Empty;
    private string objsAge = string.Empty;
    private string objsGender = string.Empty;
    private string objsPassportNo = string.Empty;
    private string objdtExpityDate = string.Empty;
    private string objsPackage = string.Empty;
    private string objdtIssueDate = string.Empty;
    private string objsMuhram = string.Empty;
    private string objsRelation = string.Empty;
    private string objsPrevNationality = string.Empty;
    private string objsAuthority = string.Empty;
    private string objsNationalIDNo = string.Empty;
    private string objsJob = string.Empty;
    private string objsAddress = string.Empty;
    private string objsBirthPlace = string.Empty;
    private string objnBasicFare = string.Empty;
    private string objnOtherTax = string.Empty;
    private string objnCommRcvd = string.Empty;
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
    private string objsReemarks = string.Empty;
    private string objbClntTax = string.Empty;
    private string objnClntCGst = string.Empty;
    private string objnClntSGst = string.Empty;
    private string objnClntIGst = string.Empty;
    private string objnClientCost = string.Empty;
    private string objnClntSc2Percent = string.Empty;
    private string objnClntSc2Amount = string.Empty;
    private string objnClntOtherChrgs = string.Empty;
    private string objnCourierChrgs = string.Empty;
    private string objsMutamarNo = string.Empty;
    private string objsMofaNo = string.Empty;
    private string objnCountryID = string.Empty;
    private string objsDependant = string.Empty;
    private string objsSponsorNo = string.Empty;
    private string objsDuration = string.Empty;
    private string objsVisaValiditry = string.Empty;
    private string objnBookTypeID = string.Empty;
    private string objnRepeaterFee = string.Empty;
    private string objnSupDiscount = string.Empty;
    private string objnConfigID = string.Empty;
    public string nMofaBookingDetID
    {
        get { return objnMofaBookingDetID; }
        set { objnMofaBookingDetID = value; }
    }
    public string nMofaBookingID
    {
        get { return objnMofaBookingID; }
        set { objnMofaBookingID = value; }
    }
    public string sEngName
    {
        get { return objsEngName; }
        set { objsEngName = value; }
    }
    public string sArabicName
    {
        get { return objsArabicName; }
        set { objsArabicName = value; }
    }
    public string nNationalityID
    {
        get { return objnNationalityID; }
        set { objnNationalityID = value; }
    }
    public string dtDOBDate
    {
        get { return objdtDOBDate; }
        set { objdtDOBDate = value; }
    }
    public string sAge
    {
        get { return objsAge; }
        set { objsAge = value; }
    }
    public string sGender
    {
        get { return objsGender; }
        set { objsGender = value; }
    }
    public string sPassportNo
    {
        get { return objsPassportNo; }
        set { objsPassportNo = value; }
    }
    public string dtExpityDate
    {
        get { return objdtExpityDate; }
        set { objdtExpityDate = value; }
    }
    public string sPackage
    {
        get { return objsPackage; }
        set { objsPackage = value; }
    }
    public string dtIssueDate
    {
        get { return objdtIssueDate; }
        set { objdtIssueDate = value; }
    }
    public string sMuhram
    {
        get { return objsMuhram; }
        set { objsMuhram = value; }
    }
    public string sRelation
    {
        get { return objsRelation; }
        set { objsRelation = value; }
    }
    public string sPrevNationality
    {
        get { return objsPrevNationality; }
        set { objsPrevNationality = value; }
    }
    public string sAuthority
    {
        get { return objsAuthority; }
        set { objsAuthority = value; }
    }
    public string sNationalIDNo
    {
        get { return objsNationalIDNo; }
        set { objsNationalIDNo = value; }
    }
    public string sJob
    {
        get { return objsJob; }
        set { objsJob = value; }
    }
    public string sAddress
    {
        get { return objsAddress; }
        set { objsAddress = value; }
    }
    public string sBirthPlace
    {
        get { return objsBirthPlace; }
        set { objsBirthPlace = value; }
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
    public string nCommRcvd
    {
        get { return objnCommRcvd; }
        set { objnCommRcvd = value; }
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
    public string sReemarks
    {
        get { return objsReemarks; }
        set { objsReemarks = value; }
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
    public string nCourierChrgs
    {
        get { return objnCourierChrgs; }
        set { objnCourierChrgs = value; }
    }
    public string sMutamarNo
    {
        get { return objsMutamarNo; }
        set { objsMutamarNo = value; }
    }
    public string sMofaNo
    {
        get { return objsMofaNo; }
        set { objsMofaNo = value; }
    }
    public string nCountryID
    {
        get { return objnCountryID; }
        set { objnCountryID = value; }
    }
    public string sDependant
    {
        get { return objsDependant; }
        set { objsDependant = value; }
    }
    public string sSponsorNo
    {
        get { return objsSponsorNo; }
        set { objsSponsorNo = value; }
    }
    public string sDuration
    {
        get { return objsDuration; }
        set { objsDuration = value; }
    }
    public string sVisaValiditry
    {
        get { return objsVisaValiditry; }
        set { objsVisaValiditry = value; }
    }
    public string nBookTypeID
    {
        get { return objnBookTypeID; }
        set { objnBookTypeID = value; }
    }
    public string nRepeaterFee
    {
        get { return objnRepeaterFee; }
        set { objnRepeaterFee = value; }
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
    public string User_Operation(tmofabookingdet_Class tmofabookingdet_Class, string type)
    {
        SqlCommand cmd = addParameter(tmofabookingdet_Class, type, "");
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
    public SqlCommand addParameter(tmofabookingdet_Class tmofabookingdet_Class, string type, string cond)
    {
        string uid,nConfigID;
        if (Session["uid"] == null)
            uid = "0";
        else
            uid = Session["uid"].ToString();

        nConfigID = "1";

        conn = connobj.makeConnection();
        SqlCommand cmd = new SqlCommand("SP_tmofabookingdet", conn); cmd.Parameters.AddWithValue("@nMofaBookingDetID", tmofabookingdet_Class.nMofaBookingDetID);
        cmd.Parameters.AddWithValue("@nMofaBookingID", tmofabookingdet_Class.nMofaBookingID);
        cmd.Parameters.AddWithValue("@sEngName", tmofabookingdet_Class.sEngName);
        cmd.Parameters.AddWithValue("@sArabicName", tmofabookingdet_Class.sArabicName);
        cmd.Parameters.AddWithValue("@nNationalityID", tmofabookingdet_Class.nNationalityID);
        cmd.Parameters.AddWithValue("@dtDOBDate", tmofabookingdet_Class.dtDOBDate);
        cmd.Parameters.AddWithValue("@sAge", tmofabookingdet_Class.sAge);
        cmd.Parameters.AddWithValue("@sGender", tmofabookingdet_Class.sGender);
        cmd.Parameters.AddWithValue("@sPassportNo", tmofabookingdet_Class.sPassportNo);
        cmd.Parameters.AddWithValue("@dtExpityDate", tmofabookingdet_Class.dtExpityDate);
        cmd.Parameters.AddWithValue("@sPackage", tmofabookingdet_Class.sPackage);
        cmd.Parameters.AddWithValue("@dtIssueDate", tmofabookingdet_Class.dtIssueDate);
        cmd.Parameters.AddWithValue("@sMuhram", tmofabookingdet_Class.sMuhram);
        cmd.Parameters.AddWithValue("@sRelation", tmofabookingdet_Class.sRelation);
        cmd.Parameters.AddWithValue("@sPrevNationality", tmofabookingdet_Class.sPrevNationality);
        cmd.Parameters.AddWithValue("@sAuthority", tmofabookingdet_Class.sAuthority);
        cmd.Parameters.AddWithValue("@sNationalIDNo", tmofabookingdet_Class.sNationalIDNo);
        cmd.Parameters.AddWithValue("@sJob", tmofabookingdet_Class.sJob);
        cmd.Parameters.AddWithValue("@sAddress", tmofabookingdet_Class.sAddress);
        cmd.Parameters.AddWithValue("@sBirthPlace", tmofabookingdet_Class.sBirthPlace);
        cmd.Parameters.AddWithValue("@nBasicFare", tmofabookingdet_Class.nBasicFare);
        cmd.Parameters.AddWithValue("@nOtherTax", tmofabookingdet_Class.nOtherTax);
        cmd.Parameters.AddWithValue("@nCommRcvd", tmofabookingdet_Class.nCommRcvd);
        cmd.Parameters.AddWithValue("@nSupScType", tmofabookingdet_Class.nSupScType);
        cmd.Parameters.AddWithValue("@nSupScpercent", tmofabookingdet_Class.nSupScpercent);
        cmd.Parameters.AddWithValue("@nSupSCAmount", tmofabookingdet_Class.nSupSCAmount);
        cmd.Parameters.AddWithValue("@bSupTax", tmofabookingdet_Class.bSupTax);
        cmd.Parameters.AddWithValue("@nSupCGst", tmofabookingdet_Class.nSupCGst);
        cmd.Parameters.AddWithValue("@nSupSGst", tmofabookingdet_Class.nSupSGst);
        cmd.Parameters.AddWithValue("@nSupIGst", tmofabookingdet_Class.nSupIGst);
        cmd.Parameters.AddWithValue("@nSupTdsType", tmofabookingdet_Class.nSupTdsType);
        cmd.Parameters.AddWithValue("@nSupTdsPercent", tmofabookingdet_Class.nSupTdsPercent);
        cmd.Parameters.AddWithValue("@nSupTdsAmount", tmofabookingdet_Class.nSupTdsAmount);
        cmd.Parameters.AddWithValue("@nSupplierCost", tmofabookingdet_Class.nSupplierCost);
        cmd.Parameters.AddWithValue("@nClntScType", tmofabookingdet_Class.nClntScType);
        cmd.Parameters.AddWithValue("@nClntScPercent", tmofabookingdet_Class.nClntScPercent);
        cmd.Parameters.AddWithValue("@nClntScAmount", tmofabookingdet_Class.nClntScAmount);
        cmd.Parameters.AddWithValue("@nClntTdsType", tmofabookingdet_Class.nClntTdsType);
        cmd.Parameters.AddWithValue("@nClntTdsPercent", tmofabookingdet_Class.nClntTdsPercent);
        cmd.Parameters.AddWithValue("@nClntTdsAmount", tmofabookingdet_Class.nClntTdsAmount);
        cmd.Parameters.AddWithValue("@nDiscount", tmofabookingdet_Class.nDiscount);
        cmd.Parameters.AddWithValue("@sReemarks", tmofabookingdet_Class.sReemarks);
        cmd.Parameters.AddWithValue("@bClntTax", tmofabookingdet_Class.bClntTax);
        cmd.Parameters.AddWithValue("@nClntCGst", tmofabookingdet_Class.nClntCGst);
        cmd.Parameters.AddWithValue("@nClntSGst", tmofabookingdet_Class.nClntSGst);
        cmd.Parameters.AddWithValue("@nClntIGst", tmofabookingdet_Class.nClntIGst);
        cmd.Parameters.AddWithValue("@nClientCost", tmofabookingdet_Class.nClientCost);
        cmd.Parameters.AddWithValue("@nClntSc2Percent", tmofabookingdet_Class.nClntSc2Percent);
        cmd.Parameters.AddWithValue("@nClntSc2Amount", tmofabookingdet_Class.nClntSc2Amount);
        cmd.Parameters.AddWithValue("@nClntOtherChrgs", tmofabookingdet_Class.nClntOtherChrgs);
        cmd.Parameters.AddWithValue("@nCourierChrgs", tmofabookingdet_Class.nCourierChrgs);
        cmd.Parameters.AddWithValue("@sMutamarNo", tmofabookingdet_Class.sMutamarNo);
        cmd.Parameters.AddWithValue("@sMofaNo", tmofabookingdet_Class.sMofaNo);
        cmd.Parameters.AddWithValue("@nCountryID", tmofabookingdet_Class.nCountryID);
        cmd.Parameters.AddWithValue("@sDependant", tmofabookingdet_Class.sDependant);
        cmd.Parameters.AddWithValue("@sSponsorNo", tmofabookingdet_Class.sSponsorNo);
        cmd.Parameters.AddWithValue("@sDuration", tmofabookingdet_Class.sDuration);
        cmd.Parameters.AddWithValue("@sVisaValiditry", tmofabookingdet_Class.sVisaValiditry);
        cmd.Parameters.AddWithValue("@nBookTypeID", tmofabookingdet_Class.nBookTypeID);
        cmd.Parameters.AddWithValue("@nRepeaterFee", tmofabookingdet_Class.nRepeaterFee);
        cmd.Parameters.AddWithValue("@nSupDiscount", tmofabookingdet_Class.nSupDiscount);
        cmd.Parameters.AddWithValue("@nConfigID", nConfigID);

        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(tmofabookingdet_Class tmofabookingdet_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(tmofabookingdet_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(tmofabookingdet_Class tmofabookingdet_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(tmofabookingdet_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(tmofabookingdet_Class tmofabookingdet_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(tmofabookingdet_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewtmofabookingdet");
            return ds.Tables["viewtmofabookingdet"];
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
    public DropDownList ddlOperation(tmofabookingdet_Class tmofabookingdet_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(tmofabookingdet_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewtmofabookingdet");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a mofabookingdet", "0"));
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
