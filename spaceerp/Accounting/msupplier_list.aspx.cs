using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.Services;


using System.Xml;
using ClosedXML.Excel;
using OfficeOpenXml;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Drawing;
using OfficeOpenXml.Style;
using System.Text;


using System.Threading;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
//using MailSMS;

using System.Configuration;

using System.Net.Mail;
using System.Net;

public partial class mclient_list : System.Web.UI.Page
{
    static tchartof_account_Class objClass = new tchartof_account_Class();
    static msupplier_Class objClient = new msupplier_Class();
    static msupgst_Class objclntGst = new msupgst_Class();
    static mcity_Class objCity = new mcity_Class();
    static mCountry_Class objCountry = new mCountry_Class();
    static mstate_Class objState = new mstate_Class();

    static mcity_Class objvendorCity = new mcity_Class();
    static mCountry_Class objvendorCountry = new mCountry_Class();
    static mstate_Class objvendorState = new mstate_Class();
    validation valobj = new validation();

    public static string viewstate;
    string cond;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                // Fillddl.FillPageddl(ddlPageSize);

                string aa = Server.UrlEncode(System.DateTime.Now.ToString());
                Session["tchartof_account"] = aa;
                objCountry.ddlOperation(objCountry, "Show", "", ddlCountryID);
                objState.ddlOperation(objState, "Showddl", "", ddlState);
                objCity.ddlOperation(objCity, "Showddl", "", ddlCityID);
                objvendorCountry.ddlOperation(objvendorCountry, "Show", "", ddlvendorcountryid);
                objvendorState.ddlOperation(objvendorState, "Showddl", "", ddlvendorstate);
                objvendorCity.ddlOperation(objvendorCity, "Showddl", "", ddlvendorcity);
            }
        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, "FAIL", lblmsg);
        }
        finally
        {
        }
    }

    public void Page_PreRender(object sender, EventArgs e)
    {
        ViewState["tchartof_account"] = Session["tchartof_account"];
        viewstate = Session["tchartof_account"].ToString();
    }

    [WebMethod]
    public static string AddClient(list list)
    {
        string msg = "";
        try
        {
            if (HttpContext.Current.Session["tchartof_account"].ToString() == viewstate)
            {
                paraAccount(list);
                // //  assign objects start
                var abc = objClass.User_Operation(objClass, "add");
                var strArr = abc.Split(',');
                if (strArr[0] == "1")
                {
                    string CAID = strArr[2].ToString();
                    HttpContext.Current.Session["CAID"] = CAID;
                    objClient.nCAccountID = CAID;
                    para(list);
                    var xyz = objClient.User_Operation(objClient, "add");

                    paraGst(list);

                    objclntGst.nSupplierID = strArr[2].ToString();
                    var abc1 = objclntGst.User_Operation(objclntGst, "add");

                }

                string val1 = strArr[0];
                if (val1 == "1")
                {
                    msg = "1";
                }
                else
                {
                    msg = abc.ToString();
                }
            }
        }
        catch (Exception ex)
        {
            msg = ex.Message.ToString();
        }
        finally
        {
        }
        return msg;
    }

    public static string paraAccount(list list)
    {
        objClass.sCode = validation.stringToDBString(list.Code);
        objClass.nAccountTypeID = "7";
        objClass.sFirstName = validation.stringToDBString(list.AgencyName);

        objClass.nChartOfAccountID = "";

        objClass.sAddress = validation.stringToDBString(list.Address);
        objClass.sPhoneNo1 = "";
        //   objClass.sPhoneNo2 = validation.stringToDBString(txtPhoneNo2.Text.Trim());
        objClass.sMobileNo = validation.stringToDBString(list.ContactNo);
        //   objClass.sFaxNo = validation.stringToDBString(txtFaxNo.Text.Trim());
        objClass.sEmailID = validation.stringToDBString(list.Email);
        objClass.sWebsite = validation.stringToDBString(list.Website);
        // objClass.nSalesPersonID = ddlSalesPersonID.SelectedValue;
        objClass.nCountryID = list.CountryID;
        objClass.nCityID = list.CityID;
        //   objClass.nAccountCategoryID = ddlAccountCategoryID.SelectedValue;
        objClass.nCreditLimit = list.Creditlimit;
        //  objClass.sRemarks = validation.stringToDBString(txtRemarks.Text.Trim());
        //   objClass.bNotChange = validation.stringToDBString(ddlChangeAllow.SelectedValue);
        objClass.sGSTNo = validation.stringToDBString(list.GSTNo);
        objClass.nChartOfAccountID = "";
        return list.ToString();
    }

    public static string para(list list)
    {
        objClient.sSupplierCode = validation.stringToDBString(list.Code);
        objClient.dtJoiningDate = "";
        objClient.sAgencyName = validation.stringToDBString(list.AgencyName);
        objClient.sIATANo = validation.stringToDBString(list.IATANo);
        objClient.sLicenseNo = validation.stringToDBString(list.LicenseNo);
        objClient.sGSTNo = validation.stringToDBString(list.GSTNo);
        objClient.sPanCardNo = validation.stringToDBString(list.PANno);
        //  objClient.nLocationID = ddlLocation.SelectedValue;
        objClient.nOffTele = "";
        objClient.sAuthorizedPerson = validation.stringToDBString(list.AuthorisedPerson);
        objClient.sContactNo = validation.stringToDBString(list.ContactNo);
        objClient.sAddress = validation.stringToDBString(list.Address);
        objClient.nCountryID = list.CountryID;
        objClient.nCityID = list.CityID;
        objClient.nStateID = list.StateID;
        objClient.nPincode = list.Pincode;
        objClient.sEmail = list.Email;
        objClient.sWebsite = list.Website;
        objClient.nCreditLimit = list.Creditlimit;

        objClient.VendorAddress = list.VendorAddress;
        objClient.VendorContactNo = list.VendorContactNo;
        objClient.VendorCountryID = list.VendorCountryID;
        objClient.VendorStateID = list.VendorStateID;
        objClient.VendorCityID = list.VendorCityID;
        objClient.VendorEmail = list.VendorEmail;
        objClient.VendorPincode = list.VendorPincode;
        objClient.VendorLatitude = list.VendorLatitude;
        objClient.VendorLongitude = list.VendorLongitude;
        objClient.Latitude = list.Latitude;
        objClient.Longitude = list.Longitude;

        return list.ToString();
    }

    public static string paraGst(list list)
    {
        //Clint GST
        objclntGst.nSupCGST = list.CGST;
        objclntGst.nSupSGST = list.SGST;
        objclntGst.nSupIGST = list.IGST;
        return list.ToString();
    }

    [WebMethod]
    public static string UpdateClient(list list)
    {
        string msg = "";
        try
        {
            if (HttpContext.Current.Session["tchartof_account"].ToString() == viewstate)
            {
                paraAccount(list);
                objClass.nChartOfAccountID = list.CAccountID;
                var abc = objClass.User_Operation(objClass, "edit");

                para(list);
                objClient.nSupplierID = list.ClientID;
                objClient.nCAccountID = list.CAccountID;
                var abc1 = objClient.User_Operation(objClient, "edit");


                paraGst(list);

                objclntGst.nSupplierID = list.CAccountID;


                DataTable dtclnt = objclntGst.viewData(objclntGst, "show", list.CAccountID);
                if (dtclnt.Rows.Count > 0)
                {
                    objclntGst.nSupGstID = dtclnt.Rows[0]["nSupGstID"].ToString();
                    var abc2 = objclntGst.User_Operation(objclntGst, "edit");
                }
                else
                {
                    var abc2 = objclntGst.User_Operation(objclntGst, "add");
                }
                //  valobj.showMsg(abc, lblmsg);
                string[] values = abc.Split(',');
                string val1 = values[0];
                if (val1 == "1")
                {
                    msg = "1";
                }
                else
                {
                    msg = abc.ToString();
                }

            }

        }
        catch (Exception ex)
        {
            msg = ex.Message.ToString();
        }
        return msg;
    }
    [WebMethod]
    public static string DeleteClient(string AccountLedgerID)
    {
        string msg = "";
        try
        {
            objClient.nSupplierID = AccountLedgerID;
            var vres = objClient.User_Operation(objClient, "DeActive");
            string[] values = vres.Split(',');
            string val1 = values[0];
            if (val1 == "1")
            {
                msg = val1;
            }
            else
            {
                msg = vres;
            }
        }
        catch (Exception ex)
        {
            msg = ex.Message.ToString();
        }



        return msg;
    }
    [WebMethod]
    public static muserlist loaddata(string fromdate, string todate)
    {
        list magentobj = new list();
        muserlist mainlist = new muserlist();
        mainlist.muserobjlist = new List<list>();
        DataTable dt = new DataTable();
        try
        {
            objClient.StartDate = validation.dateToText(fromdate);
            objClient.EndDate = validation.dateToText(todate);
            dt = objClient.Tabledata(objClient, "show", "");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                magentobj = new list();
                magentobj.ClientID = dt.Rows[i]["nSupplierID"].ToString();
                magentobj.Code = dt.Rows[i]["sSupplierCode"].ToString();
                magentobj.AgencyName = dt.Rows[i]["sAgencyName"].ToString();
                magentobj.IATANo = dt.Rows[i]["sIATANo"].ToString();
                magentobj.LicenseNo = dt.Rows[i]["sLicenseNo"].ToString();
                magentobj.GSTNo = dt.Rows[i]["sGSTNo"].ToString();
                magentobj.PANno = dt.Rows[i]["sPanCardNo"].ToString();
                magentobj.CAccountID = dt.Rows[i]["nCAccountID"].ToString();

                magentobj.Address = dt.Rows[i]["sAddress"].ToString();
                magentobj.CountryID = dt.Rows[i]["nCountryID"].ToString();
                magentobj.StateID = dt.Rows[i]["nStateID"].ToString();
                magentobj.CityID = dt.Rows[i]["nCityID"].ToString();
                magentobj.Pincode = dt.Rows[i]["nPincode"].ToString();
                magentobj.AuthorisedPerson = dt.Rows[i]["sAuthorizedPerson"].ToString();
                magentobj.ContactNo = dt.Rows[i]["sContactNo"].ToString();
                magentobj.Email = dt.Rows[i]["sEmail"].ToString();
                magentobj.Website = dt.Rows[i]["sWebsite"].ToString();
                magentobj.Creditlimit = dt.Rows[i]["nCreditLimit"].ToString();

                magentobj.VendorContactNo = dt.Rows[i]["sVendorContactno"].ToString();
                magentobj.VendorAddress = dt.Rows[i]["sVendorAddress"].ToString();
                magentobj.VendorCountryID = dt.Rows[i]["nVendorCountryID"].ToString();
                magentobj.VendorStateID = dt.Rows[i]["nVendorStateID"].ToString();
                magentobj.VendorCityID = dt.Rows[i]["nVendorCityID"].ToString();
                magentobj.VendorEmail = dt.Rows[i]["sVendorEmail"].ToString();
                magentobj.VendorPincode = dt.Rows[i]["nVendorPincode"].ToString();
                magentobj.VendorLongitude = dt.Rows[i]["sVendorLongtit"].ToString();
                magentobj.VendorLatitude = dt.Rows[i]["sVendorLatit"].ToString();
                magentobj.Longitude = dt.Rows[i]["sLongitude"].ToString();
                magentobj.Latitude = dt.Rows[i]["sLatitude"].ToString();
                DataTable dtclntGst = objclntGst.viewData(objclntGst, "show", magentobj.CAccountID);
                if (dtclntGst.Rows.Count > 0)
                {
                    magentobj.SGST = dtclntGst.Rows[0][4].ToString();
                    magentobj.CGST = dtclntGst.Rows[0][3].ToString();
                    magentobj.IGST = dtclntGst.Rows[0][2].ToString();

                }
                mainlist.muserobjlist.Add(magentobj);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return mainlist;
    }

    public class list
    {
        public string ClientID { get; set; }
        public string Code { get; set; }
        public string AgencyName { get; set; }
        public string IATANo { get; set; }
        public string LicenseNo { get; set; }
        public string GSTNo { get; set; }
        public string PANno { get; set; }
        public string Address { get; set; }
        public string CountryID { get; set; }
        public string StateID { get; set; }
        public string CityID { get; set; }
        public string Pincode { get; set; }
        public string AuthorisedPerson { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Creditlimit { get; set; }
        public string SGST { get; set; }
        public string CGST { get; set; }
        public string IGST { get; set; }
        public string ClntGstID { get; set; }
        public string CAccountID { get; set; }

        public string VendorContactNo { get; set; }
        public string VendorAddress { get; set; }
        public string VendorCountryID { get; set; }
        public string VendorStateID { get; set; }
        public string VendorCityID { get; set; }
        public string VendorPincode { get; set; }
        public string VendorEmail { get; set; }
        public string VendorLatitude { get; set; }
        public string VendorLongitude { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }

    public class muserlist
    {
        public List<list> muserobjlist { get; set; }
    }
    protected void btnexcel_Click(object sender, EventArgs e)
    {

        /// DataTable dt2 = objClass.pdftable(objClass, "getagentname", ddlAgent.SelectedValue);
        string AgentName = "";
        #region get data

        DataTable getdtdata = new DataTable();
        objClient.StartDate = validation.dateToText(txttLastPurchase.Text);
        objClient.EndDate = validation.dateToText(txttLastOrder.Text);
        getdtdata = objClient.Tabledata(objClient, "ShowGrid", "");



        #endregion


        try
        {


            #region start code
            var fileName = "Supplier-" + DateTime.Now.ToString("yyyy-MM-dd--hh-mm-ss") + ".xlsx";
            var outputDir = Server.MapPath("../Temp/Supplier.xlsx");

            ///// // Create the file using the FileInfo object
            var file = new FileInfo(outputDir + fileName);

            ///// // Create the package and make sure you wrap it in a using statement
            using (var package = new ExcelPackage(file))
            {
                /////  // add a new worksheet to the empty workbook
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Supplier - " + DateTime.Now.ToShortDateString());

                // // clumn width adjustments code
                worksheet.View.FreezePanes(7, 1); //leave header and scrool all rows up and down
                worksheet.Column(1).Width = 5;
                #region

                #region
                worksheet.Column(2).Width = 15;
                worksheet.Column(3).Width = 50;
                worksheet.Column(4).Width = 20;
                worksheet.Column(5).Width = 20;
                worksheet.Column(6).Width = 20;
                worksheet.Column(7).Width = 20;


                #endregion
                #endregion
                #region set center the row data start
                worksheet.Column(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Column(2).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Column(3).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Column(4).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Column(5).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Column(6).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Column(7).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                #endregion
                ///// //Merging cells and create a center heading for out table
                worksheet.Cells[1, 1].Value = "ALNASA"; // Heading Name
                worksheet.Cells[1, 1].Style.Font.Size = 20;
                worksheet.Cells[3, 1].Style.Font.Size = 15;
                worksheet.Cells[5, 1, 5, 3].Style.Font.Size = 13;

                ///// // MergeCell for gap rows and 15 is number of colums
                //  worksheet.Cells[2, 1, 2, getdtdata.Columns.Count].Merge = true; //Merge columns start and end range
                worksheet.Cells[2, 1, 2, 7].Merge = true;
                worksheet.Cells[4, 1, 4, 7].Merge = true; //Merge columns start and end range

                //////// // ExcelWorksheet.cells[from row, from column, to row, to column].
                // worksheet.Cells[1, 1, 1, getdtdata.Columns.Count].Merge = true; //Merge columns start and end range
                worksheet.Cells[1, 1, 1, 7].Merge = true; //Merge columns start and end range
                worksheet.Cells[1, 1, 1, 7].Style.Font.Bold = true; //Font should be bold
                worksheet.Cells[1, 1, 1, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center; // Aligmnet is center
                worksheet.Cells[1, 1].Style.Font.Color.SetColor(System.Drawing.Color.WhiteSmoke);
                // // //im giving 15 for range the columns for header
                ///////  //Merging cells and create a center heading for out table
                worksheet.Cells[3, 1].Value = "	Statement  Details From : '" + txttLastPurchase.Text + "' To: '" + txttLastOrder.Text + "' "; // Heading Name               
                worksheet.Cells[3, 1, 3, 7].Merge = true; //Merge columns start and end range
                worksheet.Cells[3, 1, 3, 7].Style.Font.Bold = true; //Font should be bold
                worksheet.Cells[3, 1, 3, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center; // Aligmnet is center
                worksheet.Cells[3, 1].Style.Font.Color.SetColor(System.Drawing.Color.WhiteSmoke);


                // // // // merging cells and hading 


                ///////  //Merging cells and create a center heading for out table
                worksheet.Cells[4, 1].Value = "	Statement Name : Supplier "; // Heading Name               
                worksheet.Cells[4, 1, 4, 7].Merge = true; //Merge columns start and end range
                worksheet.Cells[4, 1, 4, 7].Style.Font.Bold = true; //Font should be bold
                worksheet.Cells[4, 1, 4, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center; // Aligmnet is center
                worksheet.Cells[4, 1].Style.Font.Color.SetColor(System.Drawing.Color.WhiteSmoke);

                // // // agent name header
                ///////  //Merging cells and create a center heading for out table
                worksheet.Cells[5, 1].Value = "	Agency Name : '" + AgentName + "' "; // Heading Name               
                worksheet.Cells[5, 1, 5, 7].Merge = true; //Merge columns start and end range
                worksheet.Cells[5, 1, 5, 7].Style.Font.Bold = true; //Font should be bold
                worksheet.Cells[5, 1, 5, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center; // Aligmnet is center
                worksheet.Cells[5, 1].Style.Font.Color.SetColor(System.Drawing.Color.WhiteSmoke);


                //////  //Setting the background color of header cells to Gray
                var fill = worksheet.Cells[1, 1].Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(System.Drawing.Color.Silver);

                var fill1 = worksheet.Cells[3, 1].Style.Fill;
                fill1.PatternType = ExcelFillStyle.Solid;
                fill1.BackgroundColor.SetColor(System.Drawing.Color.LightSeaGreen);


                var fill2 = worksheet.Cells[4, 1].Style.Fill;
                fill2.PatternType = ExcelFillStyle.Solid;
                fill2.BackgroundColor.SetColor(System.Drawing.Color.LightSeaGreen);


                var fill3 = worksheet.Cells[5, 1].Style.Fill;
                fill3.PatternType = ExcelFillStyle.Solid;
                fill3.BackgroundColor.SetColor(System.Drawing.Color.LightSeaGreen);

                ////////////// //Ok now format the first row of the heade, but only the first two columns;
                using (var range = worksheet.Cells[6, 1, 6, 7])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Blue);
                    range.Style.Font.Color.SetColor(System.Drawing.Color.WhiteSmoke);

                    range.Style.ShrinkToFit = false;
                }
                #region
                for (int i = 0; i < getdtdata.Columns.Count; i++)
                {
                    worksheet.Cells[6, 1].Value = "Sr No";
                    worksheet.Cells[6, 2].Value = "AIRLINE CODE";
                    worksheet.Cells[6, 3].Value = "AGENCY NAME";
                    worksheet.Cells[6, 4].Value = "IATA NO";
                    worksheet.Cells[6, 5].Value = "LICENSE NO";
                    worksheet.Cells[6, 6].Value = "GST NO";
                    worksheet.Cells[6, 7].Value = "PAN NO";

                }
                #endregion
                #region
                int count = 1;
                for (int i = 0; i < getdtdata.Rows.Count; i++)
                {
                    worksheet.Cells["A" + (i + 7)].Value = count;
                    worksheet.Cells["B" + (i + 7)].Value = getdtdata.Rows[i]["sSupplierCode"].ToString();
                    worksheet.Cells["C" + (i + 7)].Value = getdtdata.Rows[i]["sAgencyName"].ToString();
                    worksheet.Cells["D" + (i + 7)].Value = getdtdata.Rows[i]["sIATANo"].ToString();
                    worksheet.Cells["E" + (i + 7)].Value = getdtdata.Rows[i]["sLicenseNo"].ToString();
                    worksheet.Cells["F" + (i + 7)].Value = getdtdata.Rows[i]["sGSTNo"].ToString();
                    worksheet.Cells["G" + (i + 7)].Value = getdtdata.Rows[i]["sPanCardNo"].ToString();
                    
                    count++;
                }
                #endregion


                package.Save();
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename=Supplier.xlsx");
                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    package.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }

            }
            #endregion


        }
        catch (Exception ex)
        {
            string msg = ex.Message.ToString();
        }
    }

}
