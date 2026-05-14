using System;
using System.Collections.Generic;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
//using MailSMS;


using System.Net;
using System.IO.Compression;

public partial class VoidOrderlist : System.Web.UI.Page
{
    cls_ordertype objordertype = new cls_ordertype();
    protected void Page_Load(object sender, EventArgs e)
    {
        hdnApiurl.Value = clsConfiguration.ApiUrl;
        if (!IsPostBack)
        {
            objordertype.ddlOperation(objordertype, "Show", "", ddlordertype);
        }
    }
    protected void btnexcel_Click(object sender, EventArgs e)
    {
        string orderTypeName = "Void Order";
       // string apiURL = "http://localhost:5000/api/Item/CompletedInActiveOrders";
        string apiURL = clsConfiguration.ApiUrl +"/api/Item/CompletedInActiveOrders";

        string startDate = txttLastPurchase.Text;
        string endDate = txttLastOrder.Text;
        string payMode = ddlpaymode.SelectedValue;
        string orderType = ddlordertype.SelectedValue;
        string urlParameters = "?orderType=" + orderType + "&startDate=" + startDate + "&endDate=" + endDate + "&payMode=" + payMode;
       
        string retAPIValue = HitToApi(apiURL + urlParameters, "GET");
        List<SalesOrder> orders = new List<SalesOrder>();
        orders = Newtonsoft.Json.JsonConvert.DeserializeObject<List<SalesOrder>>(retAPIValue);

        try
        {


            #region start code
            var fileName = "" + orderTypeName + " Report - " + DateTime.Now.ToString("yyyy-MM-dd--hh-mm-ss") + ".xlsx";
            var outputDir = Server.MapPath("../Temp/" + orderTypeName + ".xlsx");

            ///// // Create the file using the FileInfo object
            var file = new FileInfo(outputDir + fileName);

            ///// // Create the package and make sure you wrap it in a using statement
            using (var package = new ExcelPackage(file))
            {
                /////  // add a new worksheet to the empty workbook
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("" + orderTypeName + " - " + DateTime.Now.ToShortDateString());

                // // clumn width adjustments code
                worksheet.View.FreezePanes(7, 1); //leave header and scrool all rows up and down
                worksheet.Column(1).Width = 5;
                #region

                #region
                worksheet.Column(2).Width = 15;
                worksheet.Column(3).Width = 15;
                worksheet.Column(4).Width = 15;
                worksheet.Column(5).Width = 15;
                worksheet.Column(6).Width = 15;
                worksheet.Column(7).Width = 40;
                worksheet.Column(8).Width = 20;
                worksheet.Column(9).Width = 15;
                worksheet.Column(10).Width = 15;
                worksheet.Column(11).Width = 15;
                worksheet.Column(12).Width = 15;
                worksheet.Column(13).Width = 15;
                worksheet.Column(14).Width = 15;
                worksheet.Column(15).Width = 15;
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
                worksheet.Column(8).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Column(9).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Column(10).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Column(11).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Column(12).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Column(13).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Column(14).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Column(15).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                #endregion
                ///// //Merging cells and create a center heading for out table
                //worksheet.Cells[1, 1].Value = "ALNASA"; // Heading Name
                //worksheet.Cells[1, 1].Style.Font.Size = 20;
                //worksheet.Cells[3, 1].Style.Font.Size = 15;
                //worksheet.Cells[5, 1, 5, 3].Style.Font.Size = 13;

                //worksheet.Cells[2, 1, 2, 15].Merge = true;
                //worksheet.Cells[4, 1, 4, 15].Merge = true; //Merge columns start and end range

                //worksheet.Cells[1, 1, 1, 15].Merge = true; //Merge columns start and end range
                //worksheet.Cells[1, 1, 1, 15].Style.Font.Bold = true; //Font should be bold
                //worksheet.Cells[1, 1, 1, 15].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center; // Aligmnet is center
                //worksheet.Cells[1, 1].Style.Font.Color.SetColor(System.Drawing.Color.WhiteSmoke);
                string compName = string.IsNullOrEmpty(hdnCompName.Value) ? "ALNASA" : hdnCompName.Value;
                worksheet.Cells[1, 1, 1, 15].Merge = true;
                worksheet.Cells[1, 1].Value = compName;
                worksheet.Cells[1, 1].Style.Font.Size = 20;
                worksheet.Cells[1, 1].Style.Font.Bold = true;
                worksheet.Cells[1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[1, 1].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                worksheet.Cells[1, 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Silver);
                worksheet.Cells[1, 1].Style.Font.Color.SetColor(System.Drawing.Color.Black);

                // 2. Address & Contact (Sub-Heading)
                string compDetails = hdnCompAddress.Value + " | Mobile: " + hdnCompContact.Value;
                worksheet.Cells[2, 1, 2, 15].Merge = true;
                worksheet.Cells[2, 1].Value = compDetails;
                worksheet.Cells[2, 1].Style.Font.Size = 12;
                worksheet.Cells[2, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[2, 1].Style.Font.Bold = true;

                // // //im giving 15 for range the columns for header
                ///////  //Merging cells and create a center heading for out table
                worksheet.Cells[3, 1].Value = "	Statement  Details From : '" + txttLastPurchase.Text + "' To: '" + txttLastOrder.Text + "' "; // Heading Name               
                worksheet.Cells[3, 1, 3, 15].Merge = true; //Merge columns start and end range
                worksheet.Cells[3, 1, 3, 15].Style.Font.Bold = true; //Font should be bold
                worksheet.Cells[3, 1, 3, 15].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center; // Aligmnet is center
                worksheet.Cells[3, 1].Style.Font.Color.SetColor(System.Drawing.Color.WhiteSmoke);


                // // // // merging cells and hading 


                ///////  //Merging cells and create a center heading for out table
                worksheet.Cells[4, 1].Value = "	Statement Name : " + orderTypeName + ""; // Heading Name               
                worksheet.Cells[4, 1, 4, 15].Merge = true; //Merge columns start and end range
                worksheet.Cells[4, 1, 4, 15].Style.Font.Bold = true; //Font should be bold
                worksheet.Cells[4, 1, 4, 15].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center; // Aligmnet is center
                worksheet.Cells[4, 1].Style.Font.Color.SetColor(System.Drawing.Color.WhiteSmoke);


                //worksheet.Cells[5, 1].Value = "	Agency Name : '" + AgentName + "' "; // Heading Name               
                //worksheet.Cells[5, 1, 5, 15].Merge = true; //Merge columns start and end range
                //worksheet.Cells[5, 1, 5, 15].Style.Font.Bold = true; //Font should be bold
                //worksheet.Cells[5, 1, 5, 15].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center; // Aligmnet is center
                //worksheet.Cells[5, 1].Style.Font.Color.SetColor(System.Drawing.Color.WhiteSmoke);


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


                //var fill3 = worksheet.Cells[5, 1].Style.Fill;
                //fill3.PatternType = ExcelFillStyle.Solid;
                //fill3.BackgroundColor.SetColor(System.Drawing.Color.LightSeaGreen);

                ////////////// //Ok now format the first row of the heade, but only the first two columns;
                using (var range = worksheet.Cells[6, 1, 6, 15])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Blue);
                    range.Style.Font.Color.SetColor(System.Drawing.Color.WhiteSmoke);

                    range.Style.ShrinkToFit = false;
                }
                #region
                for (int j = 0; j < orders.Count; j++)
                {
                    worksheet.Cells[6, 1].Value = "Sr No";
                    worksheet.Cells[6, 2].Value = "Order ID";
                    worksheet.Cells[6, 3].Value = "Order Date";
                    worksheet.Cells[6, 4].Value = "Order Time";
                    worksheet.Cells[6, 5].Value = "Order Type";
                    worksheet.Cells[6, 6].Value = "Rider";
                    worksheet.Cells[6, 7].Value = "Customer";
                    worksheet.Cells[6, 8].Value = "Table Status";
                    worksheet.Cells[6, 9].Value = "Total Amount";
                    worksheet.Cells[6, 10].Value = "Total Discount";
                    worksheet.Cells[6, 11].Value = "Charge";
                    worksheet.Cells[6, 12].Value = "Total GST";
                    worksheet.Cells[6, 13].Value = "Total Paid";
                    worksheet.Cells[6, 14].Value = "Payment Mode";
                    worksheet.Cells[6, 15].Value = "Payment Status";
                }


                #endregion
                #region
                int count = 1;
                int i = 0;
                foreach (var item in orders)
                {
                    i = i + 1;
                    worksheet.Cells["A" + (i + 7)].Value = count;
                    worksheet.Cells["B" + (i + 7)].Value = item.OrderID;
                    worksheet.Cells["C" + (i + 7)].Value = item.OrderDate;
                    worksheet.Cells["D" + (i + 7)].Value = item.OrderTime;
                    worksheet.Cells["E" + (i + 7)].Value = item.OrderTypeName;
                    worksheet.Cells["F" + (i + 7)].Value = "";
                    worksheet.Cells["G" + (i + 7)].Value = item.CustomerName;
                    worksheet.Cells["H" + (i + 7)].Value = item.TableStatus;
                    worksheet.Cells["I" + (i + 7)].Value = item.TotalOrderAmount;
                    worksheet.Cells["J" + (i + 7)].Value = item.TotalDiscount;
                    worksheet.Cells["K" + (i + 7)].Value = item.Charge;
                    worksheet.Cells["L" + (i + 7)].Value = item.GSTCost;
                    worksheet.Cells["M" + (i + 7)].Value = item.TotalPaid;
                    worksheet.Cells["N" + (i + 7)].Value = item.PayMode;
                    worksheet.Cells["O" + (i + 7)].Value = item.PaymentStatus;
                    count++;
                }

                #endregion


                package.Save();
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename=" + orderTypeName + ".xlsx");
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
    public static string HitToApi(string apiPath, string acceptVerb)
    {
        HttpWebRequest httpWebRequest;
        HttpWebResponse httpWebResponse;
        StreamReader streamReader = null;

        httpWebRequest = (HttpWebRequest)WebRequest.Create(apiPath);
        httpWebRequest.Accept = "application/json";
        httpWebRequest.ContentType = "application/json";
        httpWebRequest.Method = acceptVerb;

        httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

        if (httpWebResponse.Headers.Get("Content-Encoding") == "gzip" || httpWebResponse.Headers.Get("Content-Encoding") == "deflate")
        {
            Stream IStream = default(Stream);
            IStream = new GZipStream(httpWebResponse.GetResponseStream(), CompressionMode.Decompress);
            streamReader = new System.IO.StreamReader(IStream);
        }
        else
            streamReader = new System.IO.StreamReader(httpWebResponse.GetResponseStream());

        return streamReader.ReadToEnd();
    }

}
