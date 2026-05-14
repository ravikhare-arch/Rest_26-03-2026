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
public class memployee_Class : System.Web.UI.Page
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection();
    private string objEmpID = string.Empty;
    private string objEmpCode = string.Empty;
    private string objEmpName = string.Empty;
    private string objFatherName = string.Empty;
    private string objMotherName = string.Empty;
    private string objMaritalStatus = string.Empty;
    private string objReligion = string.Empty;
    private string objDOB = string.Empty;
    private string objGender = string.Empty;
    private string objBloodGroup = string.Empty;
    private string objNationality = string.Empty;
    private string objCardno = string.Empty;
    private string objAddress1 = string.Empty;
    private string objAddress2 = string.Empty;
    private string objAddress3 = string.Empty;
    private string objPhone =  string.Empty;
    private string objEmail =  string.Empty;
    private string objCountryID = string.Empty;
    private string objStateID = string.Empty;
    private string objCityID = string.Empty;
    private string objPermanentAddOpt = string.Empty;
    private string objPermanentAddress1 = string.Empty;
    private string objPermanentAddress2 = string.Empty;
    private string objPermanentAddress3 = string.Empty;
    private string objJoiningDate = string.Empty;
    private string objConfirmationDate = string.Empty;
    private double objProbation;
    private double objNoticeDays;
    private string objPAN = string.Empty;
    private string objUAN = string.Empty;
    private string objVoterNo = string.Empty;
    private string objAadharNo = string.Empty;
    private string objCivilIDNo = string.Empty;
    private string objPassportNo = string.Empty;
    private string objDINo = string.Empty;
    private string objVisaValidDate = string.Empty;
    private string objPassportValidDate = string.Empty;
    private string objDLValidDate = string.Empty;
    private string objBankName = string.Empty;
    private string objBranch = string.Empty;
    private string objBankAccountNo = string.Empty;
    private string objBankAccountHolderName = string.Empty;
    private string objIFSCcode = string.Empty;
    private string objSwiftcode = string.Empty;
    private string objDesignation = string.Empty;
    private string objQualification = string.Empty;
    private string objExperience = string.Empty;
    public string EmpID
    {
        get { return objEmpID; }
        set { objEmpID = value; }
    }
    public string EmpCode
    {
        get { return objEmpCode; }
        set { objEmpCode = value; }
    }
    public string EmpName
    {
        get { return objEmpName; }
        set { objEmpName = value; }
    }
    public string FatherName
    {
        get { return objFatherName; }
        set { objFatherName = value; }
    }
    public string MotherName
    {
        get { return objMotherName; }
        set { objMotherName = value; }
    }
    public string Religion  
    {
        get { return objReligion; }
        set { objReligion = value; }
    }
    public string DateofBirth
    {
        get { return objDOB ; }
        set { objDOB = value; }
    }
    public string Gender
    {
        get { return objGender; }
        set { objGender = value; }
    }
    public string BloodGroup
    {
        get { return objBloodGroup; }
        set { objBloodGroup = value; }
    }
    public string Nationality   
    {
        get { return objNationality; }
        set { objNationality = value; }
    }
    public string Cardno
    {
        get { return objCardno; }
        set { objCardno = value; }
    }
    public string Address1
    {
        get { return objAddress1; }
        set { objAddress1 = value; }
    }
    public string Address2
    {
        get { return objAddress2; }
        set { objAddress2 = value; }
    }
    public string Address3
    {
        get { return objAddress3; }
        set { objAddress3 = value; }
    }
    public string CountryID
    {
        get { return objCountryID; }
        set { objCountryID = value; }
    }
    public string CityID
    {
        get { return objCityID; }
        set { objCityID = value; }
    }
    public string StateID
    {
        get { return objStateID; }
        set { objStateID = value; }
    }
    public string PermanentAddressOpt
    {
        get { return objPermanentAddOpt; }
        set { objPermanentAddOpt = value; }
    }
    public string PermanentAddress1
    {
        get { return objPermanentAddress1; }
        set { objPermanentAddress1 = value; }
    }
    public string PermanentAddress2
    {
        get { return objPermanentAddress2; }
        set { objPermanentAddress2 = value; }
    }
    public string PermanentAddress3
    {
        get { return objPermanentAddress3; }
        set { objPermanentAddress3 = value; }
    }
    public string JoiningDate
    {
        get { return objJoiningDate; }
        set { objJoiningDate = value; }
    }
    public string ConfirmationDate
    {
        get { return objConfirmationDate; }
        set { objConfirmationDate = value; }
    }
    public double Probation
    {
        get { return objProbation; }
        set { objProbation = value; }
    }
    public double NoticeDays
    {
        get { return objNoticeDays; }
        set { objNoticeDays = value; }
    }
    public string PAN
    {
        get { return objPAN; }
        set { objPAN = value; }
    }
    public string UAN
    {
        get { return objUAN; }
        set { objUAN = value; }
    }
    public string VoterNo
    {
        get { return objVoterNo; }
        set { objVoterNo = value; }
    }
    public string AadharNo
    {
        get { return objAadharNo; }
        set { objAadharNo = value; }
    }
    public string CivilIDNo
    {
        get { return objCivilIDNo; }
        set { objCivilIDNo = value; }
    }
    public string PassportNo
    {
        get { return objPassportNo; }
        set { objPassportNo = value; }
    }
    public string DINO  
    {
        get { return objDINo; }
        set { objDINo = value; }
    }
    public string VisaValidDate
    {
        get { return objVisaValidDate; }
        set { objVisaValidDate = value; }
    }
    public string PassportValidDate
    {
        get { return objPassportValidDate; }
        set { objPassportValidDate = value; }
    }
    public string DLValidDate
    {
        get { return objDLValidDate; }
        set { objDLValidDate = value; }
    }
    public string BankName
    {
        get { return objBankName; }
        set { objBankName = value; }
    }
    public string Branch
    {
        get { return objBranch; }
        set { objBranch = value; }
    }
    public string BankAccountNo
    {
        get { return objBankAccountNo; }
        set { objBankAccountNo = value; }
    }
    public string BankAccountHolderName
    {
        get { return objBankAccountHolderName; }
        set { objBankAccountHolderName = value; }
    }
    public string IFSCCode
    {
        get { return objIFSCcode ; }
        set { objIFSCcode = value; }
    }
    public string SwiftCode
    {
        get { return objSwiftcode; }
        set { objSwiftcode = value; }
    }
    public string Designation
    {
        get { return objDesignation; }
        set { objDesignation = value; }
    }
    public string Qualification
    {
        get { return objQualification; }
        set { objQualification = value; }
    }
    public string Experience
    {
        get { return objExperience; }
        set { objExperience = value; }
    }
    public string User_Operation(memployee_Class memployee_Class, string type)
    {
        SqlCommand cmd = addParameter(memployee_Class, type, "");
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
    public SqlCommand addParameter(memployee_Class memployee_Class, string type, string cond)
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
        SqlCommand cmd = new SqlCommand("SP_memployee", conn); cmd.Parameters.AddWithValue("@EmpID", memployee_Class.EmpID);
        cmd.Parameters.AddWithValue("@EmpCode", memployee_Class.EmpCode);
        cmd.Parameters.AddWithValue("@EmpName", memployee_Class.EmpName);
        cmd.Parameters.AddWithValue("@FatherName", memployee_Class.FatherName);
        cmd.Parameters.AddWithValue("@MotherName", memployee_Class.MotherName);
               
        cmd.Parameters.AddWithValue("@nConfigID", ConfigID);
        cmd.Parameters.AddWithValue("@nCreatedID", uid);
        cmd.Parameters.AddWithValue("@nModifiedID", uid);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void FillGrid(memployee_Class memployee_Class, GridView grd, string type, string cond)
    {
        try
        {
            DataTable da = viewData(memployee_Class, type, cond);
            grd.DataSource = da;
            grd.DataBind();
            if (grd.HeaderRow != null)
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch
        {
        }
    }
    public void FillReapter(memployee_Class memployee_Class, Repeater repeat, string type, string cond)
    {
        try
        {
            DataTable da = new DataTable();
            da = viewData(memployee_Class, type, cond);
            repeat.DataSource = da;
            repeat.DataBind();
        }
        catch
        {
        }
    }
    public DataTable viewData(memployee_Class memployee_Class, string type, string cond)
    {
        SqlCommand cmd = addParameter(memployee_Class, type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "viewemployee");
            return ds.Tables["viewemployee"];
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
    public DropDownList ddlOperation(memployee_Class memployee_Class, string Type, string cond, DropDownList ddl)
    {
        SqlCommand cmd = addParameter(memployee_Class, Type, cond);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewmsupplier");
        ddl.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Add(new ListItem("Choose a supplier", "0"));
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
