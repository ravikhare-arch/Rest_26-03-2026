using Newtonsoft.Json;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SalesOrderReport : System.Web.UI.Page
{
    cls_ordertype objordertype = new cls_ordertype();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            hdnApiurl.Value = clsConfiguration.ApiUrl;
        }
        catch { }

        if (!IsPostBack)
        {
            // Dropdown Load
            objordertype.ddlOperation(objordertype, "Show", "", ddlDeliveryType);
            if (ddlDeliveryType.Items.Count > 0) ddlDeliveryType.Items.RemoveAt(0);
            ddlDeliveryType.Items.Add(new ListItem("ALL", "0"));
            ddlDeliveryType.SelectedValue = "0";
        }
    }

    public static string HitToApi(string apiPath, string acceptVerb)
    {
        HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(apiPath);
        httpWebRequest.Accept = "application/json";
        httpWebRequest.ContentType = "application/json";
        httpWebRequest.Method = acceptVerb;

        using (HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
        {
            Stream responseStream = httpWebResponse.GetResponseStream();
            if (httpWebResponse.Headers.Get("Content-Encoding") == "gzip")
                responseStream = new GZipStream(responseStream, CompressionMode.Decompress);
            else if (httpWebResponse.Headers.Get("Content-Encoding") == "deflate")
                responseStream = new DeflateStream(responseStream, CompressionMode.Decompress);

            using (StreamReader streamReader = new StreamReader(responseStream))
            {
                return streamReader.ReadToEnd();
            }
        }
    }

    protected void btnexcel_Click(object sender, EventArgs e)
    {
        try
        {
            string orderTypeName = ddlDeliveryType.SelectedItem.Text;
            string apiURL = hdnApiurl.Value + "/api/Item/CompletedOrders";

            // Fixed parameters using string.Format
            string urlParameters = string.Format("?orderType={0}&startDate={1}&endDate={2}",
                                    ddlDeliveryType.SelectedValue,
                                    txttLastPurchase.Text,
                                    txttLastOrder.Text);

            string retAPIValue = HitToApi(apiURL + urlParameters, "GET");
            List<SalesOrder> orders = JsonConvert.DeserializeObject<List<SalesOrder>>(retAPIValue);

            if (orders == null || orders.Count == 0)
            {
                ShowMessage("No records found to export.");
                return;
            }

            using (ExcelPackage package = new ExcelPackage())
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sales Report");

                // Header Styling
                worksheet.Cells["A1:O1"].Merge = true;
                worksheet.Cells["A1"].Value = "ALNASA - " + orderTypeName + " REPORT";
                worksheet.Cells["A1"].Style.Font.Size = 18;
                worksheet.Cells["A1"].Style.Font.Bold = true;
                worksheet.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                worksheet.Cells["A3:O3"].Merge = true;
                worksheet.Cells["A3"].Value = string.Format("Period: {0} To {1}", txttLastPurchase.Text, txttLastOrder.Text);
                worksheet.Cells["A3"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                // Table Headers
                string[] colNames = { "Sr No", "Order ID", "Order Date", "Order Time", "Order Type", "Rider", "Customer", "Table Status", "Total Amount", "Total Discount", "Charge", "Total GST", "Total Paid", "Payment Mode", "Payment Status" };
                for (int j = 0; j < colNames.Length; j++)
                {
                    var cell = worksheet.Cells[6, j + 1];
                    cell.Value = colNames[j];
                    cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    cell.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Blue);
                    cell.Style.Font.Color.SetColor(System.Drawing.Color.White);
                    cell.Style.Font.Bold = true;
                }

                int rowIdx = 7;
                int srNo = 1;
                foreach (var item in orders)
                {
                    worksheet.Cells[rowIdx, 1].Value = srNo++;
                    worksheet.Cells[rowIdx, 2].Value = item.OrderNo;
                    worksheet.Cells[rowIdx, 3].Value = item.OrderDate;
                    worksheet.Cells[rowIdx, 4].Value = item.OrderTime;
                    worksheet.Cells[rowIdx, 5].Value = item.OrderTypeName;
                    worksheet.Cells[rowIdx, 7].Value = item.CustomerName;
                    worksheet.Cells[rowIdx, 8].Value = item.TableStatus;
                    worksheet.Cells[rowIdx, 9].Value = item.TotalOrderAmount;
                    worksheet.Cells[rowIdx, 10].Value = item.TotalDiscount;
                    worksheet.Cells[rowIdx, 11].Value = item.Charge;
                    worksheet.Cells[rowIdx, 12].Value = item.GSTCost;
                    worksheet.Cells[rowIdx, 13].Value = item.TotalPaid;
                    worksheet.Cells[rowIdx, 14].Value = item.PayMode;
                    worksheet.Cells[rowIdx, 15].Value = item.PaymentStatus;
                    rowIdx++;
                }

                worksheet.Cells.AutoFitColumns();

                Response.Clear();
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                string fileName = string.Format("attachment;filename={0}_Report.xlsx", orderTypeName.Replace(" ", "_"));
                Response.AddHeader("content-disposition", fileName);
                Response.BinaryWrite(package.GetAsByteArray());
                Response.Flush();
                Response.SuppressContent = true;
                HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
        }
        catch (Exception ex)
        {
            ShowMessage("Error: " + ex.Message);
        }
    }

    private void ShowMessage(string msg)
    {
        // Specifying System.Web.UI.WebControls.Label to avoid ambiguity
        System.Web.UI.WebControls.Label lbl = (System.Web.UI.WebControls.Label)Page.FindControl("ctl00$ContentPlaceHolder1$lblmsg");
        if (lbl != null) { lbl.Text = msg; }
        else { ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + msg + "');", true); }
    }
}