using Newtonsoft.Json;
using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using OfficeOpenXml.Style;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//using RestaurantApi.Models;
public partial class PendingOrderlist : System.Web.UI.Page
{
    cls_ordertype objordertype = new cls_ordertype();
    protected void Page_Load(object sender, EventArgs e)
    {
        //HttpClient client = new HttpClient();

        hdnApiurl.Value = clsConfiguration.ApiUrl;
        if (!IsPostBack)
        {
            objordertype.ddlOperation(objordertype, "Show", "", ddlDeliveryType);
            ddlDeliveryType.Items.RemoveAt(0);
            ddlDeliveryType.Items.Add(new System.Web.UI.WebControls.ListItem("ALL", "0"));
            ddlDeliveryType.SelectedValue = "0";

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

    protected void btnexcel_Click(object sender, EventArgs e)
    {
        try
        {
            // ── DATE FIX: "m" ko "M" kiya taaki Month parse ho ──
            string[] formats = { "d/M/yyyy", "dd/MM/yyyy", "yyyy-MM-dd" };
            DateTime sDate, eDate;

            if (!DateTime.TryParseExact(txttLastPurchase.Text, formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out sDate))
                sDate = DateTime.Now;

            if (!DateTime.TryParseExact(txttLastOrder.Text, formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out eDate))
                eDate = DateTime.Now;

            string startDate = sDate.ToString("yyyy-MM-dd");
            string endDate = eDate.ToString("yyyy-MM-dd");

            string orderTypeName = "ALL Sales Order Report";
            string apiURL = clsConfiguration.ApiUrl + "/api/Item/CompletedOrders";
            string payMode = ddlpaymode.SelectedValue;
            string urlParameters = "?orderType=" + ddlDeliveryType.SelectedValue + "&startDate=" + startDate + "&endDate=" + endDate + "&payMode=" + payMode;

            if (ddlDeliveryType.SelectedValue == "1") orderTypeName = "Take Away";
            else if (ddlDeliveryType.SelectedValue == "2") orderTypeName = "Room Service";
            else if (ddlDeliveryType.SelectedValue == "3") orderTypeName = "Dine-In";
            else if (ddlDeliveryType.SelectedValue == "4") orderTypeName = "Dastarkhan";

            string retAPIValue = HitToApi(apiURL + urlParameters, "GET");
            List<SalesOrder> orders = Newtonsoft.Json.JsonConvert.DeserializeObject<List<SalesOrder>>(retAPIValue);

            using (var package = new OfficeOpenXml.ExcelPackage())
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(orderTypeName);
                worksheet.View.FreezePanes(7, 1);
                int lastCol = 20;
                worksheet.Column(1).Width = 5;
                for (int c = 2; c <= lastCol; c++) { worksheet.Column(c).Width = 15; }
                worksheet.Column(7).Width = 40;

                // Header ALNASA
               // worksheet.Cells[1, 1, 1, lastCol].Merge = true;
                //worksheet.Cells[1, 1].Value = "ALNASA";
                //worksheet.Cells[1, 1].Style.Font.Size = 20;
                //worksheet.Cells[1, 1].Style.Font.Bold = true;
                //worksheet.Cells[1, 1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                //worksheet.Cells[1, 1].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                //worksheet.Cells[1, 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Silver);
                // Header Company Name
                worksheet.Cells[1, 1, 1, lastCol].Merge = true;
                string compName = string.IsNullOrEmpty(hdnCompName.Value) ? "ALNASA" : hdnCompName.Value;
                worksheet.Cells[1, 1].Value = compName;
                worksheet.Cells[1, 1].Style.Font.Size = 20;
                worksheet.Cells[1, 1].Style.Font.Bold = true;
                worksheet.Cells[1, 1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                worksheet.Cells[1, 1].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                worksheet.Cells[1, 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Silver);

                // Sub-header Address & Contact
                worksheet.Cells[2, 1, 2, lastCol].Merge = true;
                string compDetails = hdnCompAddress.Value + " | Mobile: " + hdnCompContact.Value;
                worksheet.Cells[2, 1].Value = compDetails;
                worksheet.Cells[2, 1].Style.Font.Size = 12;
                worksheet.Cells[2, 1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                // Statement Details Row
                worksheet.Cells[3, 1, 3, lastCol].Merge = true;
                worksheet.Cells[3, 1].Value = "Statement Details From : '" + txttLastPurchase.Text + "' To: '" + txttLastOrder.Text + "' ";
                worksheet.Cells[3, 1].Style.Font.Size = 15;
                worksheet.Cells[3, 1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                worksheet.Cells[3, 1].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                worksheet.Cells[3, 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightSeaGreen);
                worksheet.Cells[3, 1].Style.Font.Color.SetColor(System.Drawing.Color.WhiteSmoke);

                string[] headers = { "Sr No", "Order ID", "Order Date", "Order Time", "Order Type", "Rider", "Customer", "Table Status", "Room No", "Charge", "Sub Total", "Total", "Disc %", "Disc", "After Disc", "SGST", "CGST", "Total GST", "Round", "Net Total" };
                for (int j = 0; j < headers.Length; j++)
                {
                    var cell = worksheet.Cells[6, j + 1];
                    cell.Value = headers[j];
                    cell.Style.Font.Bold = true;
                    cell.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    cell.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    cell.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightSeaGreen);
                    cell.Style.Font.Color.SetColor(System.Drawing.Color.White);
                }

                int i = 0;
                decimal totalCharge = 0, totalSub = 0, totalAmt = 0, totalDisc = 0, totalAfterDisc = 0, totalSGST = 0, totalCGST = 0, totalTax = 0, totalRound = 0, totalNet = 0;

                foreach (var item in orders)
                {
                    i++;
                    int r = i + 7;
                    worksheet.Cells[r, 1].Value = i;
                    worksheet.Cells[r, 2].Value = item.OrderID;
                    worksheet.Cells[r, 3].Value = item.OrderDate;
                    worksheet.Cells[r, 4].Value = item.OrderTime;
                    worksheet.Cells[r, 5].Value = item.OrderTypeName;
                    worksheet.Cells[r, 6].Value = item.DeliveredBy;
                    worksheet.Cells[r, 7].Value = item.CustomerName;
                    worksheet.Cells[r, 8].Value = item.TableStatus;
                    worksheet.Cells[r, 9].Value = item.RoomNo;
                    worksheet.Cells[r, 10].Value = Convert.ToDecimal(item.Charge);
                    worksheet.Cells[r, 11].Value = Convert.ToDecimal(item.SubTotal);
                    worksheet.Cells[r, 12].Value = Convert.ToDecimal(item.TotalOrderAmount);
                    worksheet.Cells[r, 13].Value = Convert.ToDecimal(item.DiscPercent);
                    worksheet.Cells[r, 14].Value = Convert.ToDecimal(item.TotalDiscount);
                    worksheet.Cells[r, 15].Value = Convert.ToDecimal(item.AfterDisc);
                    worksheet.Cells[r, 16].Value = Convert.ToDecimal(item.SGST);
                    worksheet.Cells[r, 17].Value = Convert.ToDecimal(item.CGST);
                    worksheet.Cells[r, 18].Value = Convert.ToDecimal(item.GSTCost);
                    worksheet.Cells[r, 19].Value = Convert.ToDecimal(item.RoundOff);
                    worksheet.Cells[r, 20].Value = Convert.ToDecimal(item.TotalPaid);

                    totalCharge += Convert.ToDecimal(item.Charge); totalSub += Convert.ToDecimal(item.SubTotal); totalAmt += Convert.ToDecimal(item.TotalOrderAmount);
                    totalDisc += Convert.ToDecimal(item.TotalDiscount); totalAfterDisc += Convert.ToDecimal(item.AfterDisc); totalSGST += Convert.ToDecimal(item.SGST);
                    totalCGST += Convert.ToDecimal(item.CGST); totalTax += Convert.ToDecimal(item.GSTCost); totalRound += Convert.ToDecimal(item.RoundOff); totalNet += Convert.ToDecimal(item.TotalPaid);
                }

                int totalRow = i + 8;
                worksheet.Cells[totalRow, 1, totalRow, 9].Merge = true;
                worksheet.Cells[totalRow, 1].Value = "Grand TOTAL";
                worksheet.Cells[totalRow, 1].Style.Font.Bold = true;
                worksheet.Cells[totalRow, 10].Value = totalCharge;
                worksheet.Cells[totalRow, 11].Value = totalSub;
                worksheet.Cells[totalRow, 12].Value = totalAmt;
                worksheet.Cells[totalRow, 14].Value = totalDisc;
                worksheet.Cells[totalRow, 15].Value = totalAfterDisc;
                worksheet.Cells[totalRow, 16].Value = totalSGST;
                worksheet.Cells[totalRow, 17].Value = totalCGST;
                worksheet.Cells[totalRow, 18].Value = totalTax;
                worksheet.Cells[totalRow, 19].Value = totalRound;
                worksheet.Cells[totalRow, 20].Value = totalNet;

                worksheet.Cells[7, 10, totalRow, 20].Style.Numberformat.Format = "#,##0.00";
                worksheet.Cells[7, 10, totalRow, 20].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;

                Response.Clear();
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename=" + orderTypeName.Replace(" ", "_") + ".xlsx");
                Response.BinaryWrite(package.GetAsByteArray());
                Response.Flush();
                Response.End();
            }
        }
        catch (Exception ex) { }
    }
    protected void btnpdf_Click(object sender, EventArgs e)
    {
        try
        {
            // ── DATE FIX: "m" ko "M" kiya taaki Month parse ho ──
            string[] formats = { "d/M/yyyy", "dd/MM/yyyy", "yyyy-MM-dd" };
            DateTime sDate, eDate;

            if (!DateTime.TryParseExact(txttLastPurchase.Text, formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out sDate))
                sDate = DateTime.Now;

            if (!DateTime.TryParseExact(txttLastOrder.Text, formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out eDate))
                eDate = DateTime.Now;

            string startDate = sDate.ToString("yyyy-MM-dd");
            string endDate = eDate.ToString("yyyy-MM-dd");

            string orderTypeName = "ALL Sales Order Report";
            if (ddlDeliveryType.SelectedValue == "1") orderTypeName = "Take Away";
            else if (ddlDeliveryType.SelectedValue == "2") orderTypeName = "Room Service";
            else if (ddlDeliveryType.SelectedValue == "3") orderTypeName = "Dine-In";
            else if (ddlDeliveryType.SelectedValue == "4") orderTypeName = "Dastarkhan";

            string apiURL = clsConfiguration.ApiUrl + "/api/Item/CompletedOrders";
            string urlParameters = String.Format("?orderType={0}&startDate={1}&endDate={2}&payMode={3}",
                                      ddlDeliveryType.SelectedValue, startDate, endDate, ddlpaymode.SelectedValue);

            string retAPIValue = HitToApi(apiURL + urlParameters, "GET");

            if (string.IsNullOrEmpty(retAPIValue) || retAPIValue == "[]")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('No data found for the selected dates!');", true);
                return;
            }

            List<SalesOrder> orders = Newtonsoft.Json.JsonConvert.DeserializeObject<List<SalesOrder>>(retAPIValue);

            PdfDocument document = new PdfDocument();
            document.Info.Title = orderTypeName;
            PdfPage page = document.AddPage();
            page.Orientation = PdfSharp.PageOrientation.Landscape;
            XGraphics gfx = XGraphics.FromPdfPage(page);

            XFont titleFont = new XFont("Verdana", 12, XFontStyle.Bold);
            XFont subTitleFont = new XFont("Verdana", 7, XFontStyle.Regular);
            XFont headerFont = new XFont("Verdana", 6, XFontStyle.Bold);
            XFont cellFont = new XFont("Verdana", 6, XFontStyle.Regular);
            XSolidBrush headerBgBrush = new XSolidBrush(XColor.FromArgb(64, 64, 64));
            XSolidBrush blueBgBrush = new XSolidBrush(XColor.FromArgb(0, 51, 153));

            double[] cols = { 25, 40, 50, 40, 50, 40, 70, 45, 35, 35, 35, 40, 35, 35, 40, 35, 35, 40, 30, 40 };
            string[] headers = { "Sr", "OrderNo", "Date", "Time", "Type", "Rider", "Guest", "Status", "Room", "Chrg", "Sub", "Tot", "D%", "Disc", "AftD", "SGST", "CGST", "TGST", "Rnd", "Net" };

            //Action drawPageHeader = () => {
            //    gfx.DrawString("ALNASA RESTAURANT", titleFont, XBrushes.Red, new XRect(0, 10, page.Width, 20), XStringFormats.TopCenter);
            //    string subDetails = String.Format("Statement: {0} | Period: {1} To: {2}", orderTypeName, txttLastPurchase.Text, txttLastOrder.Text);
            //    gfx.DrawString(subDetails, subTitleFont, XBrushes.Black, new XRect(0, 25, page.Width, 15), XStringFormats.TopCenter);

            //    double xH = 15;
            //    for (int h = 0; h < headers.Length; h++)
            //    {
            //        gfx.DrawRectangle(headerBgBrush, xH, 40, cols[h], 15);
            //        gfx.DrawString(headers[h], headerFont, XBrushes.White, new XRect(xH, 40, cols[h], 15), XStringFormats.Center);
            //        xH += cols[h];
            //    }
            //};

            Action drawPageHeader = () => {
                string compName = string.IsNullOrEmpty(hdnCompName.Value) ? "ALNASA RESTAURANT" : hdnCompName.Value;
                string compDetails = hdnCompAddress.Value + " | Mobile: " + hdnCompContact.Value;

                // Company Name
                gfx.DrawString(compName, titleFont, XBrushes.Red, new XRect(0, 10, page.Width, 20), XStringFormats.TopCenter);

                // Address & Contact
                gfx.DrawString(compDetails, subTitleFont, XBrushes.DarkBlue, new XRect(0, 25, page.Width, 15), XStringFormats.TopCenter);

                // Statement Details
                string subDetails = String.Format("Statement: {0} | Period: {1} To: {2}", orderTypeName, txttLastPurchase.Text, txttLastOrder.Text);
                gfx.DrawString(subDetails, subTitleFont, XBrushes.Black, new XRect(0, 35, page.Width, 15), XStringFormats.TopCenter);

                double xH = 15;
                for (int h = 0; h < headers.Length; h++)
                {
                    // PDF header headers ka Y-coordinate 50 kar diya taaki upar text overlap na ho
                    gfx.DrawRectangle(headerBgBrush, xH, 50, cols[h], 15);
                    gfx.DrawString(headers[h], headerFont, XBrushes.White, new XRect(xH, 50, cols[h], 15), XStringFormats.Center);
                    xH += cols[h];
                }
            };

           
            

            drawPageHeader();
            double yPoint = 65;
            // double yPoint = 55;
            int slNo = 1;
            decimal sChg = 0, sSub = 0, sTot = 0, sDisc = 0, sAft = 0, sSgst = 0, sCgst = 0, sGst = 0, sNet = 0;

            foreach (var item in orders)
            {
                if (yPoint > page.Height - 50)
                {
                    page = document.AddPage();
                    page.Orientation = PdfSharp.PageOrientation.Landscape;
                    gfx = XGraphics.FromPdfPage(page);
                    drawPageHeader();
                    yPoint = 55;
                }

                double xPoint = 15;
                string[] rowData = {
                slNo.ToString(), item.OrderNo, item.OrderDate, item.OrderTime, item.OrderTypeName, item.DeliveredBy, item.CustomerName, item.TableStatus, item.RoomNo,
                item.Charge.ToString("F2"), item.SubTotal.ToString("F2"), item.TotalOrderAmount.ToString("F2"), item.DiscPercent.ToString("F1"),
                item.TotalDiscount.ToString("F2"), item.AfterDisc.ToString("F2"), item.SGST.ToString("F2"), item.CGST.ToString("F2"), item.GSTCost.ToString("F2"),
                item.RoundOff.ToString("F2"), item.TotalPaid.ToString("F2")
            };

                for (int r = 0; r < rowData.Length; r++)
                {
                    gfx.DrawRectangle(XPens.Black, xPoint, yPoint, cols[r], 15);
                    XStringFormat align = (r >= 9) ? XStringFormats.CenterRight : XStringFormats.CenterLeft;
                    gfx.DrawString(rowData[r] ?? "", cellFont, XBrushes.Black, new XRect(xPoint + 2, yPoint, cols[r] - 4, 15), align);
                    xPoint += cols[r];
                }

                sChg += Convert.ToDecimal(item.Charge); sSub += Convert.ToDecimal(item.SubTotal); sTot += Convert.ToDecimal(item.TotalOrderAmount);
                sDisc += Convert.ToDecimal(item.TotalDiscount); sAft += Convert.ToDecimal(item.AfterDisc); sSgst += Convert.ToDecimal(item.SGST);
                sCgst += Convert.ToDecimal(item.CGST); sGst += Convert.ToDecimal(item.GSTCost); sNet += Convert.ToDecimal(item.TotalPaid);

                yPoint += 15; slNo++;
            }

            // Summary Row
            double xF = 15;
            double labelWidth = 0;
            for (int k = 0; k < 9; k++) labelWidth += cols[k];
            gfx.DrawRectangle(blueBgBrush, xF, yPoint, labelWidth, 15);
            gfx.DrawString("Grand TOTAL", headerFont, XBrushes.White, new XRect(xF + 5, yPoint, labelWidth - 5, 15), XStringFormats.CenterLeft);

            xF += labelWidth;
            decimal?[] footerValues = { sChg, sSub, sTot, null, sDisc, sAft, sSgst, sCgst, sGst, null, sNet };
            for (int f = 0; f < footerValues.Length; f++)
            {
                double cW = cols[9 + f];
                gfx.DrawRectangle(blueBgBrush, xF, yPoint, cW, 15);
                if (footerValues[f].HasValue)
                    gfx.DrawString(footerValues[f].Value.ToString("F2"), headerFont, XBrushes.White, new XRect(xF, yPoint, cW - 2, 15), XStringFormats.CenterRight);
                xF += cW;
            }

            using (MemoryStream stream = new MemoryStream())
            {
                document.Save(stream, false);
                Response.Clear();
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", String.Format("attachment;filename={0}.pdf", orderTypeName.Replace(" ", "_")));
                Response.BinaryWrite(stream.ToArray());
                Response.Flush();
                Response.End();
            }
        }
        catch (Exception ex) { }
    }




}