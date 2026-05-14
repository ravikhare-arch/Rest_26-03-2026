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
public class ttrainbooking_det_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnTrainBookingDetID = string.Empty;
    private string objnTrainBookingID = string.Empty;
    private string objsPnrNo = string.Empty;
    private string objsTrainNo = string.Empty;
    private string objsClass = string.Empty;
    private string objsBoarding = string.Empty;
    private string objdtTravelDate = string.Empty;
    private string objnFromID = string.Empty;
    private string objnToID = string.Empty;
    private string objsPaxNos = string.Empty;
    private string objsTicketNo = string.Empty;
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
    public string nTrainBookingDetID
    {
        get { return objnTrainBookingDetID; }
        set { objnTrainBookingDetID = value; }
    }
    public string nTrainBookingID
    {
        get { return objnTrainBookingID; }
        set { objnTrainBookingID = value; }
    }
    public string sPnrNo
    {
        get { return objsPnrNo; }
        set { objsPnrNo = value; }
    }
    public string sTrainNo
    {
        get { return objsTrainNo; }
        set { objsTrainNo = value; }
    }
    public string sClass
    {
        get { return objsClass; }
        set { objsClass = value; }
    }
    public string sBoarding
    {
        get { return objsBoarding; }
        set { objsBoarding = value; }
    }
    public string dtTravelDate
    {
        get { return objdtTravelDate; }
        set { objdtTravelDate = value; }
    }
    public string nFromID
    {
        get { return objnFromID; }
        set { objnFromID = value; }
    }
    public string nToID
    {
        get { return objnToID; }
        set { objnToID = value; }
    }
    public string sPaxNos
    {
        get { return objsPaxNos; }
        set { objsPaxNos = value; }
    }
    public string sTicketNo
    {
        get { return objsTicketNo; }
        set { objsTicketNo = value; }
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
    public string User_Operation(ttrainbooking_det_Class ttrainbooking_det_Class, string type)
    {
        SqlCommand cmd = addParameter(ttrainbooking_det_Class, type, "");
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
    public SqlCommand addParameter(ttrainbooking_det_Class ttrainbooking_det_Class, string type, string cond)
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
        SqlCommand cmd = new SqlCommand("SP_ttrainbooking_det", conn); cmd.Parameters.AddWithValue("@nTrainBookingDetID", ttrainbooking_det_Class.nTrainBookingDetID);
        cmd.Parameters.AddWithValue("@nTrainBookingID", ttrainbooking_det_Class.nTrainBookingID);
        cmd.Parameters.AddWithValue("@sPnrNo", ttrainbooking_det_Class.sPnrNo);
        cmd.Parameters.AddWithValue("@sTrainNo", ttrainbooking_det_Class.sTrainNo);
        cmd.Parameters.AddWithValue("@sClass", ttrainbooking_det_Class.sClass);
        cmd.Parameters.AddWithValue("@sBoarding", ttrainbooking_det_Class.sBoarding);
        cmd.Parameters.AddWithValue("@dtTravelDate", ttrainbooking_det_Class.dtTravelDate);
        cmd.Parameters.AddWithValue("@nFromID", ttrainbooking_det_Class.nFromID);
        cmd.Parameters.AddWithValue("@nToID", ttrainbooking_det_Class.nToID);
        cmd.Parameters.AddWithValue("@sPaxNos", ttrainbooking_det_Class.sPaxNos);
        cmd.Parameters.AddWithValue("@sTicketNo", ttrainbooking_det_Class.sTicketNo);
        cmd.Parameters.AddWithValue("@nBasicFare", ttrainbooking_det_Class.nBasicFare);
        cmd.Parameters.AddWithValue("@nOtherTax", ttrainbooking_det_Class.nOtherTax);
        cmd.Parameters.AddWithValue("@nSupComm", ttrainbooking_det_Class.nSupComm);
        cmd.Parameters.AddWithValue("@nSupScType", ttrainbooking_det_Class.nSupScType);
        cmd.Parameters.AddWithValue("@nSupScPercent", ttrainbooking_det_Class.nSupScPercent);
        cmd.Parameters.AddWithValue("@nSupScAmount", ttrainbooking_det_Class.nSupScAmount);
        cmd.Parameters.AddWithValue("@nSupTdsType", ttrainbooking_det_Class.nSupTdsType);
        cmd.Parameters.AddWithValue("@nSupTDSPercent", ttrainbooking_det_Class.nSupTDSPercent);
        cmd.Parameters.AddWithValue("@nSupTDSAmount", ttrainbooking_det_Class.nSupTDSAmount);
        cmd.Parameters.AddWithValue("@bSupTax", ttrainbooking_det_Class.bSupTax);
        cmd.Parameters.AddWithValue("@nSupCGST", ttrainbooking_det_Class.nSupCGST);
        cmd.Parameters.AddWithValue("@nSupSGST", ttrainbooking_det_Class.nSupSGST);
        cmd.Parameters.AddWithValue("@nSupIGST", ttrainbooking_det_Class.nSupIGST);
        cmd.Parameters.AddWithValue("@nSupplierCost", ttrainbooking_det_Class.nSupplierCost);
        cmd.Parameters.AddWithValue("@nClntScType", ttrainbooking_det_Class.nClntScType);
        cmd.Parameters.AddWithValue("@nClntScPercent", ttrainbooking_det_Class.nClntScPercent);
        cmd.Parameters.AddWithValue("@nClntScAmount", ttrainbooking_det_Class.nClntScAmount);
        cmd.Parameters.AddWithValue("@nClntTDSType", ttrainbooking_det_Class.nClntTDSType);
        cmd.Parameters.AddWithValue("@nClntTDSPercent", ttrainbooking_det_Class.nClntTDSPercent);
        cmd.Parameters.AddWithValue("@nClntTDSAmount", ttrainbooking_det_Class.nClntTDSAmount);
        cmd.Parameters.AddWithValue("@nDiscount", ttrainbooking_det_Class.nDiscount);
        cmd.Parameters.AddWithValue("@bClntTax", ttrainbooking_det_Class.bClntTax);
        cmd.Parameters.AddWithValue("@nClntCGst", ttrainbooking_det_Class.nClntCGst);
        cmd.Parameters.AddWithValue("@nClntSGst", ttrainbooking_det_Class.nClntSGst);
        cmd.Parameters.AddWithValue("@nClntIGst", ttrainbooking_det_Class.nClntIGst);
        cmd.Parameters.AddWithValue("@nClientCost", ttrainbooking_det_Class.nClientCost);
        cmd.Parameters.AddWithValue("@sRemarks", ttrainbooking_det_Class.sRemarks);
        cmd.Parameters.AddWithValue("@nClntSc2Percent", ttrainbooking_det_Class.nClntSc2Percent);
        cmd.Parameters.AddWithValue("@nClntSc2Amount", ttrainbooking_det_Class.nClntSc2Amount);

        cmd.Parameters.AddWithValue("@nClntOtherChrgs", ttrainbooking_det_Class.nClntOtherChrgs);
        cmd.Parameters.AddWithValue("@nSupDiscount", ttrainbooking_det_Class.nSupDiscount);
        cmd.Parameters.AddWithValue("@nConfigID", ConfigID);

        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(ttrainbooking_det_Class ttrainbooking_det_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(ttrainbooking_det_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(ttrainbooking_det_Class ttrainbooking_det_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(ttrainbooking_det_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(ttrainbooking_det_Class ttrainbooking_det_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(ttrainbooking_det_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewttrainbooking_det");
            return ds.Tables["viewttrainbooking_det"];
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
    public DropDownList ddlOperation(ttrainbooking_det_Class ttrainbooking_det_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(ttrainbooking_det_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewttrainbooking_det");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a trainbooking_det", "0"));
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
