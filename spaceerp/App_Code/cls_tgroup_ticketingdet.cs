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
public class tgroup_ticketingdet_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objnTicketingDetID = string.Empty;
    private string objnTicketingID = string.Empty;
    private string objsReferenceNo = string.Empty;
    private string objsGroupName = string.Empty;
    private string objsSector = string.Empty;
    private string objsAirPNR = string.Empty;
    private string objsTicketNo = string.Empty;
    private string objnAirlineID = string.Empty;
    private string objnBookTypeID = string.Empty;
    private string objsFlightClass = string.Empty;
    private string objsFlightNo = string.Empty;
    private string objsCRS = string.Empty;
    private string objsRemarks = string.Empty;
    private string objnBasicFare = string.Empty;
    private string objnQuantity = string.Empty;
    private string objnTotBasic = string.Empty;
    private string objnYQRate = string.Empty;
    private string objnYQTot = string.Empty;
    private string objnYRRate = string.Empty;
    private string objnYRTot = string.Empty;
    private string objnK3Rate = string.Empty;
    private string objnK3Tot = string.Empty;
    private string objnOtrTaxRate = string.Empty;
    private string objnOtrTaxTot = string.Empty;
    private string objniatacomRate = string.Empty;
    private string objniatacomTot = string.Empty;
    private string objnPlbRate = string.Empty;
    private string objnPlbTot = string.Empty;
    private string objnTktCost = string.Empty;
    private string objnSupScType = string.Empty;
    private string objnSupScPercent = string.Empty;
    private string objnSupScAmount = string.Empty;
    private string objnSupScAmountTot = string.Empty;
    private string objnSupTDSType = string.Empty;
    private string objnSupTDSPercent = string.Empty;
    private string objnSupTDSAmount = string.Empty;
    private string objnSupTDSAmountTot = string.Empty;
    private string objnSupDiscount = string.Empty;
    private string objnSupDiscountTot = string.Empty;
    private string objbSupTax = string.Empty;
    private string objnSupCGST = string.Empty;
    private string objnSupCGSTTot = string.Empty;
    private string objnSupSGST = string.Empty;
    private string objnSupSGSTTot = string.Empty;
    private string objnSupIGST = string.Empty;
    private string objnSupIGSTTot = string.Empty;
    private string objnCLTScType = string.Empty;
    private string objnCLTSCPecent = string.Empty;
    private string objnCLTSCAmount = string.Empty;
    private string objnCLTSCAmountTot = string.Empty;
    private string objnCLTSC2Pecent = string.Empty;
    private string objnCLTSC2Amount = string.Empty;
    private string objnCLTSC2AmountTot = string.Empty;
    private string objnCLTTDSType = string.Empty;
    private string objnCLTTDSPercent = string.Empty;
    private string objnCLTTDSAmount = string.Empty;
    private string objnCLTTDSAmountTot = string.Empty;
    private string objnCLTDiscount = string.Empty;
    private string objnCLTDiscountTot = string.Empty;
    private string objnCLTOtrCRG = string.Empty;
    private string objnCLTOtrCRGTot = string.Empty;
    private string objbCLTTax = string.Empty;
    private string objnCLTCGST = string.Empty;
    private string objnCLTCGSTTot = string.Empty;
    private string objnCLTSGST = string.Empty;
    private string objnCLTSGSTTot = string.Empty;
    private string objnCLTIGST = string.Empty;
    private string objnCLTIGSTTot = string.Empty;
    private string objnSupplierCost = string.Empty;
    private string objnClientCost = string.Empty;
    private string objnConfigID = string.Empty;
    public string nTicketingDetID
    {
        get { return objnTicketingDetID; }
        set { objnTicketingDetID = value; }
    }
    public string nTicketingID
    {
        get { return objnTicketingID; }
        set { objnTicketingID = value; }
    }
    public string sReferenceNo
    {
        get { return objsReferenceNo; }
        set { objsReferenceNo = value; }
    }
    public string sGroupName
    {
        get { return objsGroupName; }
        set { objsGroupName = value; }
    }
    public string sSector
    {
        get { return objsSector; }
        set { objsSector = value; }
    }
    public string sAirPNR
    {
        get { return objsAirPNR; }
        set { objsAirPNR = value; }
    }
    public string sTicketNo
    {
        get { return objsTicketNo; }
        set { objsTicketNo = value; }
    }
    public string nAirlineID
    {
        get { return objnAirlineID; }
        set { objnAirlineID = value; }
    }
    public string nBookTypeID
    {
        get { return objnBookTypeID; }
        set { objnBookTypeID = value; }
    }
    public string sFlightClass
    {
        get { return objsFlightClass; }
        set { objsFlightClass = value; }
    }
    public string sFlightNo
    {
        get { return objsFlightNo; }
        set { objsFlightNo = value; }
    }
    public string sCRS
    {
        get { return objsCRS; }
        set { objsCRS = value; }
    }
    public string sRemarks
    {
        get { return objsRemarks; }
        set { objsRemarks = value; }
    }
    public string nBasicFare
    {
        get { return objnBasicFare; }
        set { objnBasicFare = value; }
    }
    public string nQuantity
    {
        get { return objnQuantity; }
        set { objnQuantity = value; }
    }
    public string nTotBasic
    {
        get { return objnTotBasic; }
        set { objnTotBasic = value; }
    }
    public string nYQRate
    {
        get { return objnYQRate; }
        set { objnYQRate = value; }
    }
    public string nYQTot
    {
        get { return objnYQTot; }
        set { objnYQTot = value; }
    }
    public string nYRRate
    {
        get { return objnYRRate; }
        set { objnYRRate = value; }
    }
    public string nYRTot
    {
        get { return objnYRTot; }
        set { objnYRTot = value; }
    }
    public string nK3Rate
    {
        get { return objnK3Rate; }
        set { objnK3Rate = value; }
    }
    public string nK3Tot
    {
        get { return objnK3Tot; }
        set { objnK3Tot = value; }
    }
    public string nOtrTaxRate
    {
        get { return objnOtrTaxRate; }
        set { objnOtrTaxRate = value; }
    }
    public string nOtrTaxTot
    {
        get { return objnOtrTaxTot; }
        set { objnOtrTaxTot = value; }
    }
    public string niatacomRate
    {
        get { return objniatacomRate; }
        set { objniatacomRate = value; }
    }
    public string niatacomTot
    {
        get { return objniatacomTot; }
        set { objniatacomTot = value; }
    }
    public string nPlbRate
    {
        get { return objnPlbRate; }
        set { objnPlbRate = value; }
    }
    public string nPlbTot
    {
        get { return objnPlbTot; }
        set { objnPlbTot = value; }
    }
    public string nTktCost
    {
        get { return objnTktCost; }
        set { objnTktCost = value; }
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
    public string nSupScAmountTot
    {
        get { return objnSupScAmountTot; }
        set { objnSupScAmountTot = value; }
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
    public string nSupTDSAmountTot
    {
        get { return objnSupTDSAmountTot; }
        set { objnSupTDSAmountTot = value; }
    }
    public string nSupDiscount
    {
        get { return objnSupDiscount; }
        set { objnSupDiscount = value; }
    }
    public string nSupDiscountTot
    {
        get { return objnSupDiscountTot; }
        set { objnSupDiscountTot = value; }
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
    public string nSupCGSTTot
    {
        get { return objnSupCGSTTot; }
        set { objnSupCGSTTot = value; }
    }
    public string nSupSGST
    {
        get { return objnSupSGST; }
        set { objnSupSGST = value; }
    }
    public string nSupSGSTTot
    {
        get { return objnSupSGSTTot; }
        set { objnSupSGSTTot = value; }
    }
    public string nSupIGST
    {
        get { return objnSupIGST; }
        set { objnSupIGST = value; }
    }
    public string nSupIGSTTot
    {
        get { return objnSupIGSTTot; }
        set { objnSupIGSTTot = value; }
    }
    public string nCLTScType
    {
        get { return objnCLTScType; }
        set { objnCLTScType = value; }
    }
    public string nCLTSCPecent
    {
        get { return objnCLTSCPecent; }
        set { objnCLTSCPecent = value; }
    }
    public string nCLTSCAmount
    {
        get { return objnCLTSCAmount; }
        set { objnCLTSCAmount = value; }
    }
    public string nCLTSCAmountTot
    {
        get { return objnCLTSCAmountTot; }
        set { objnCLTSCAmountTot = value; }
    }
    public string nCLTSC2Pecent
    {
        get { return objnCLTSC2Pecent; }
        set { objnCLTSC2Pecent = value; }
    }
    public string nCLTSC2Amount
    {
        get { return objnCLTSC2Amount; }
        set { objnCLTSC2Amount = value; }
    }
    public string nCLTSC2AmountTot
    {
        get { return objnCLTSC2AmountTot; }
        set { objnCLTSC2AmountTot = value; }
    }
    public string nCLTTDSType
    {
        get { return objnCLTTDSType; }
        set { objnCLTTDSType = value; }
    }
    public string nCLTTDSPercent
    {
        get { return objnCLTTDSPercent; }
        set { objnCLTTDSPercent = value; }
    }
    public string nCLTTDSAmount
    {
        get { return objnCLTTDSAmount; }
        set { objnCLTTDSAmount = value; }
    }
    public string nCLTTDSAmountTot
    {
        get { return objnCLTTDSAmountTot; }
        set { objnCLTTDSAmountTot = value; }
    }
    public string nCLTDiscount
    {
        get { return objnCLTDiscount; }
        set { objnCLTDiscount = value; }
    }
    public string nCLTDiscountTot
    {
        get { return objnCLTDiscountTot; }
        set { objnCLTDiscountTot = value; }
    }
    public string nCLTOtrCRG
    {
        get { return objnCLTOtrCRG; }
        set { objnCLTOtrCRG = value; }
    }
    public string nCLTOtrCRGTot
    {
        get { return objnCLTOtrCRGTot; }
        set { objnCLTOtrCRGTot = value; }
    }
    public string bCLTTax
    {
        get { return objbCLTTax; }
        set { objbCLTTax = value; }
    }
    public string nCLTCGST
    {
        get { return objnCLTCGST; }
        set { objnCLTCGST = value; }
    }
    public string nCLTCGSTTot
    {
        get { return objnCLTCGSTTot; }
        set { objnCLTCGSTTot = value; }
    }
    public string nCLTSGST
    {
        get { return objnCLTSGST; }
        set { objnCLTSGST = value; }
    }
    public string nCLTSGSTTot
    {
        get { return objnCLTSGSTTot; }
        set { objnCLTSGSTTot = value; }
    }
    public string nCLTIGST
    {
        get { return objnCLTIGST; }
        set { objnCLTIGST = value; }
    }
    public string nCLTIGSTTot
    {
        get { return objnCLTIGSTTot; }
        set { objnCLTIGSTTot = value; }
    }
    public string nSupplierCost
    {
        get { return objnSupplierCost; }
        set { objnSupplierCost = value; }
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
    public string User_Operation(tgroup_ticketingdet_Class tgroup_ticketingdet_Class, string type)
    {
        SqlCommand cmd = addParameter(tgroup_ticketingdet_Class, type, "");
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
    public SqlCommand addParameter(tgroup_ticketingdet_Class tgroup_ticketingdet_Class, string type, string cond)
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
        SqlCommand cmd = new SqlCommand("SP_tgroup_ticketingdet", conn); cmd.Parameters.AddWithValue("@nTicketingDetID", tgroup_ticketingdet_Class.nTicketingDetID);
        cmd.Parameters.AddWithValue("@nTicketingID", tgroup_ticketingdet_Class.nTicketingID);
        cmd.Parameters.AddWithValue("@sReferenceNo", tgroup_ticketingdet_Class.sReferenceNo);
        cmd.Parameters.AddWithValue("@sGroupName", tgroup_ticketingdet_Class.sGroupName);
        cmd.Parameters.AddWithValue("@sSector", tgroup_ticketingdet_Class.sSector);
        cmd.Parameters.AddWithValue("@sAirPNR", tgroup_ticketingdet_Class.sAirPNR);
        cmd.Parameters.AddWithValue("@sTicketNo", tgroup_ticketingdet_Class.sTicketNo);
        cmd.Parameters.AddWithValue("@nAirlineID", tgroup_ticketingdet_Class.nAirlineID);
        cmd.Parameters.AddWithValue("@nBookTypeID", tgroup_ticketingdet_Class.nBookTypeID);
        cmd.Parameters.AddWithValue("@sFlightClass", tgroup_ticketingdet_Class.sFlightClass);
        cmd.Parameters.AddWithValue("@sFlightNo", tgroup_ticketingdet_Class.sFlightNo);
        cmd.Parameters.AddWithValue("@sCRS", tgroup_ticketingdet_Class.sCRS);
        cmd.Parameters.AddWithValue("@sRemarks", tgroup_ticketingdet_Class.sRemarks);
        cmd.Parameters.AddWithValue("@nBasicFare", tgroup_ticketingdet_Class.nBasicFare);
        cmd.Parameters.AddWithValue("@nQuantity", tgroup_ticketingdet_Class.nQuantity);
        cmd.Parameters.AddWithValue("@nTotBasic", tgroup_ticketingdet_Class.nTotBasic);
        cmd.Parameters.AddWithValue("@nYQRate", tgroup_ticketingdet_Class.nYQRate);
        cmd.Parameters.AddWithValue("@nYQTot", tgroup_ticketingdet_Class.nYQTot);
        cmd.Parameters.AddWithValue("@nYRRate", tgroup_ticketingdet_Class.nYRRate);
        cmd.Parameters.AddWithValue("@nYRTot", tgroup_ticketingdet_Class.nYRTot);
        cmd.Parameters.AddWithValue("@nK3Rate", tgroup_ticketingdet_Class.nK3Rate);
        cmd.Parameters.AddWithValue("@nK3Tot", tgroup_ticketingdet_Class.nK3Tot);
        cmd.Parameters.AddWithValue("@nOtrTaxRate", tgroup_ticketingdet_Class.nOtrTaxRate);
        cmd.Parameters.AddWithValue("@nOtrTaxTot", tgroup_ticketingdet_Class.nOtrTaxTot);
        cmd.Parameters.AddWithValue("@niatacomRate", tgroup_ticketingdet_Class.niatacomRate);
        cmd.Parameters.AddWithValue("@niatacomTot", tgroup_ticketingdet_Class.niatacomTot);
        cmd.Parameters.AddWithValue("@nPlbRate", tgroup_ticketingdet_Class.nPlbRate);
        cmd.Parameters.AddWithValue("@nPlbTot", tgroup_ticketingdet_Class.nPlbTot);
        cmd.Parameters.AddWithValue("@nTktCost", tgroup_ticketingdet_Class.nTktCost);
        cmd.Parameters.AddWithValue("@nSupScType", tgroup_ticketingdet_Class.nSupScType);
        cmd.Parameters.AddWithValue("@nSupScPercent", tgroup_ticketingdet_Class.nSupScPercent);
        cmd.Parameters.AddWithValue("@nSupScAmount", tgroup_ticketingdet_Class.nSupScAmount);
        cmd.Parameters.AddWithValue("@nSupScAmountTot", tgroup_ticketingdet_Class.nSupScAmountTot);
        cmd.Parameters.AddWithValue("@nSupTDSType", tgroup_ticketingdet_Class.nSupTDSType);
        cmd.Parameters.AddWithValue("@nSupTDSPercent", tgroup_ticketingdet_Class.nSupTDSPercent);
        cmd.Parameters.AddWithValue("@nSupTDSAmount", tgroup_ticketingdet_Class.nSupTDSAmount);
        cmd.Parameters.AddWithValue("@nSupTDSAmountTot", tgroup_ticketingdet_Class.nSupTDSAmountTot);
        cmd.Parameters.AddWithValue("@nSupDiscount", tgroup_ticketingdet_Class.nSupDiscount);
        cmd.Parameters.AddWithValue("@nSupDiscountTot", tgroup_ticketingdet_Class.nSupDiscountTot);
        cmd.Parameters.AddWithValue("@bSupTax", tgroup_ticketingdet_Class.bSupTax);
        cmd.Parameters.AddWithValue("@nSupCGST", tgroup_ticketingdet_Class.nSupCGST);
        cmd.Parameters.AddWithValue("@nSupCGSTTot", tgroup_ticketingdet_Class.nSupCGSTTot);
        cmd.Parameters.AddWithValue("@nSupSGST", tgroup_ticketingdet_Class.nSupSGST);
        cmd.Parameters.AddWithValue("@nSupSGSTTot", tgroup_ticketingdet_Class.nSupSGSTTot);
        cmd.Parameters.AddWithValue("@nSupIGST", tgroup_ticketingdet_Class.nSupIGST);
        cmd.Parameters.AddWithValue("@nSupIGSTTot", tgroup_ticketingdet_Class.nSupIGSTTot);
        cmd.Parameters.AddWithValue("@nCLTScType", tgroup_ticketingdet_Class.nCLTScType);
        cmd.Parameters.AddWithValue("@nCLTSCPecent", tgroup_ticketingdet_Class.nCLTSCPecent);
        cmd.Parameters.AddWithValue("@nCLTSCAmount", tgroup_ticketingdet_Class.nCLTSCAmount);
        cmd.Parameters.AddWithValue("@nCLTSCAmountTot", tgroup_ticketingdet_Class.nCLTSCAmountTot);
        cmd.Parameters.AddWithValue("@nCLTSC2Pecent", tgroup_ticketingdet_Class.nCLTSC2Pecent);
        cmd.Parameters.AddWithValue("@nCLTSC2Amount", tgroup_ticketingdet_Class.nCLTSC2Amount);
        cmd.Parameters.AddWithValue("@nCLTSC2AmountTot", tgroup_ticketingdet_Class.nCLTSC2AmountTot);
        cmd.Parameters.AddWithValue("@nCLTTDSType", tgroup_ticketingdet_Class.nCLTTDSType);
        cmd.Parameters.AddWithValue("@nCLTTDSPercent", tgroup_ticketingdet_Class.nCLTTDSPercent);
        cmd.Parameters.AddWithValue("@nCLTTDSAmount", tgroup_ticketingdet_Class.nCLTTDSAmount);
        cmd.Parameters.AddWithValue("@nCLTTDSAmountTot", tgroup_ticketingdet_Class.nCLTTDSAmountTot);
        cmd.Parameters.AddWithValue("@nCLTDiscount", tgroup_ticketingdet_Class.nCLTDiscount);
        cmd.Parameters.AddWithValue("@nCLTDiscountTot", tgroup_ticketingdet_Class.nCLTDiscountTot);
        cmd.Parameters.AddWithValue("@nCLTOtrCRG", tgroup_ticketingdet_Class.nCLTOtrCRG);
        cmd.Parameters.AddWithValue("@nCLTOtrCRGTot", tgroup_ticketingdet_Class.nCLTOtrCRGTot);
        cmd.Parameters.AddWithValue("@bCLTTax", tgroup_ticketingdet_Class.bCLTTax);
        cmd.Parameters.AddWithValue("@nCLTCGST", tgroup_ticketingdet_Class.nCLTCGST);
        cmd.Parameters.AddWithValue("@nCLTCGSTTot", tgroup_ticketingdet_Class.nCLTCGSTTot);
        cmd.Parameters.AddWithValue("@nCLTSGST", tgroup_ticketingdet_Class.nCLTSGST);
        cmd.Parameters.AddWithValue("@nCLTSGSTTot", tgroup_ticketingdet_Class.nCLTSGSTTot);
        cmd.Parameters.AddWithValue("@nCLTIGST", tgroup_ticketingdet_Class.nCLTIGST);
        cmd.Parameters.AddWithValue("@nCLTIGSTTot", tgroup_ticketingdet_Class.nCLTIGSTTot);
        cmd.Parameters.AddWithValue("@nSupplierCost", tgroup_ticketingdet_Class.nSupplierCost);
        cmd.Parameters.AddWithValue("@nClientCost", tgroup_ticketingdet_Class.nClientCost);
        cmd.Parameters.AddWithValue("@nConfigID", ConfigID);

        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(tgroup_ticketingdet_Class tgroup_ticketingdet_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(tgroup_ticketingdet_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(tgroup_ticketingdet_Class tgroup_ticketingdet_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(tgroup_ticketingdet_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(tgroup_ticketingdet_Class tgroup_ticketingdet_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(tgroup_ticketingdet_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewtgroup_ticketingdet");
            return ds.Tables["viewtgroup_ticketingdet"];
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
    public DropDownList ddlOperation(tgroup_ticketingdet_Class tgroup_ticketingdet_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(tgroup_ticketingdet_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewtgroup_ticketingdet");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a group_ticketingdet", "0"));
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
