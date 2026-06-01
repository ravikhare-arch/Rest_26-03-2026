using PrintModule.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Management;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
//using System.Drawing.Common;

namespace PrintModule
{
    public class Printing
    {
        StringBuilder sbLog = new StringBuilder();
        static string prnData = string.Empty;
        List<SalesOrder> orders = new List<SalesOrder>();
        private float pageWidth;

        public bool IsPrintWithGST { get; set; }
        public void PrintOnLan(int orderNumber, int orderType)
        {
            string ipAddress = "10.0.0.91";
            int port = int.Parse("9100"); //ie: 9100

            string url = GetURI(orderNumber);
            System.Net.Sockets.TcpClient client = new System.Net.Sockets.TcpClient();
            client.Connect(ipAddress, port);
            // StreamReader reader = GetPageContent(url); ;
            StreamWriter writer = new StreamWriter(client.GetStream());
            //string testFile = reader.ReadToEnd();
            //reader.Close();
            //writer.Write(testFile);

            writer.Flush();
            writer.Close();
            client.Close();
        }

        private string GetURI(int orderNumber)
        {
            // orderNumber = 168;

            string domainName = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["APIUrl"]); ;
            string url = domainName + "/api/Item/OrderDetailbyOrderID/" + orderNumber;
            return url;
        }
        public bool PrintOnDefaultPrinter(int orderNumber, int orderType)
        {
            try
            {
                PrintDocument prnDocument;
                string printername;
                //Get the default printer name.
                // WebBrowser wb = new WebBrowser();


                string url = GetURI(orderNumber);

                prnDocument = new PrintDocument();
                printername = Convert.ToString(prnDocument.PrinterSettings.PrinterName);
                if (string.IsNullOrEmpty(printername))
                    throw new Exception("No default printer is set.Printing failed!");
                // StreamReader reader = GetPageContent(url);

                string html = string.Empty;
                //string url = pageUri;
                Stream stream;
                StreamReader reader;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);


                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (stream = response.GetResponseStream())
                    {
                        using (reader = new StreamReader(stream))
                        {
                            prnData = reader.ReadToEnd();
                        }
                        //reader = new StreamReader(stream);


                    }
                }
                // using (stream = response.GetResponseStream())


                prnDocument.PrintPage += new PrintPageEventHandler(prnDoc_PrintPage);
                prnDocument.Print();
                return true;
            }
            catch (COMException comException)
            {
                //Log the exception
                return false;
            }
            catch (Exception sysException)
            {
                //Log the exception
                return false;
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


        public List<SalesOrder> GetOrderDetails(int OrderID)
        {
            List<SalesOrder> obj = new List<SalesOrder>();
            try
            {
                string url = GetURI(OrderID);
                sbLog.AppendLine("url=" + url);
                string results = HitToApi(url, "GET");
               // Console.WriteLine(results); 
                obj = Newtonsoft.Json.JsonConvert.DeserializeObject<List<SalesOrder>>(results);
            }
            catch (Exception ex)
            {
                sbLog.AppendLine("In GetOrderDetails:" + ex.StackTrace + ":" + ex.Message);
            }

            return obj;
        }


        public static bool SetDefaultPrinter(string defaultPrinter)
        {
            using (ManagementObjectSearcher objectSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_Printer"))
            {
                using (ManagementObjectCollection objectCollection = objectSearcher.Get())
                {
                    foreach (ManagementObject mo in objectCollection)
                    {
                        if (string.Compare(mo["Name"].ToString(), defaultPrinter, true) == 0)
                        {
                            mo.InvokeMethod("SetDefaultPrinter", null, null);
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        void dailyDep(object sender, PrintPageEventArgs e)
        {
            try
            {
                double CGST = 0, SGST = 0, GstTotal = 0;
                Graphics graphics = e.Graphics;
                String underLine = "------------------------------------------------------------------";

                int startX = 10;
                int startY = 20;
                int Offset = 10;
                Offset = Offset + 15;
                double subTotal = 0.0;
                double Discount = orders[0].TotalDiscount;

                // --- Fonts Define Kiye Hain ---
                Font fontRegular = new Font("Calibri", 9);
                Font fontBold = new Font("Calibri", 10, FontStyle.Bold);
                Font fontHeader = new Font("Calibri", 13, FontStyle.Bold);
                Font itemFont = new Font("Calibri", 8);

                // --- Alignments ---
                StringFormat leftFormat = new StringFormat() { Alignment = StringAlignment.Near };
                StringFormat centerFormat = new StringFormat() { Alignment = StringAlignment.Center };
                StringFormat rightFormat = new StringFormat() { Alignment = StringAlignment.Far };

                // --- Column Widths & X-Coordinates (Items ke liye fix boxes) ---
                int col1_x = startX;           // Particulars start (X=10)
                int col1_w = 130;              // Particulars width
                int col2_x = col1_x + col1_w;  // Rate start (X=140)
                int col2_w = 50;               // Rate width
                int col3_x = col2_x + col2_w;  // Qty start (X=190)
                int col3_w = 30;               // Qty width
                int col4_x = col3_x + col3_w;  // Total start (X=220)
                int col4_w = 60;               // Total width

                // --- Header Section ---
                graphics.DrawString(orders[0].companydetails.Name, fontHeader, Brushes.Black, new RectangleF(0, startY + Offset, 300, 25), centerFormat);
                Offset = Offset + 25;
                graphics.DrawString(orders[0].companydetails.Address + ",", fontRegular, Brushes.Black, new RectangleF(0, startY + Offset, 300, 20), centerFormat);
                Offset = Offset + 15;
                graphics.DrawString(orders[0].companydetails.City + " - " + orders[0].companydetails.PinCode, fontRegular, Brushes.Black, new RectangleF(0, startY + Offset, 300, 20), centerFormat);
                Offset = Offset + 15;
                graphics.DrawString("Ph. " + orders[0].companydetails.Contactno, fontBold, Brushes.Black, new RectangleF(0, startY + Offset, 300, 20), centerFormat);
                Offset = Offset + 15;
                graphics.DrawString("GSTIN. " + orders[0].companydetails.GSTNo, fontBold, Brushes.Black, new RectangleF(0, startY + Offset, 300, 20), centerFormat);
                Offset = Offset + 15;


                graphics.DrawString(underLine, fontRegular, Brushes.Black, 0, startY + Offset);
                Offset = Offset + 15;
                //graphics.DrawString("Cash Memo", fontBold, Brushes.Black, new RectangleF(0, startY + Offset, 300, 20), centerFormat);
                //Offset = Offset + 15;
                //graphics.DrawString(underLine, fontRegular, Brushes.Black, 0, startY + Offset);
                //Offset = Offset + 15;

                string invoiceTitle = IsPrintWithGST ? "Tax Invoice" : "KOT";

                graphics.DrawString(invoiceTitle, fontBold, Brushes.Black, new RectangleF(0, startY + Offset, 300, 20), centerFormat);
                Offset = Offset + 15;

                graphics.DrawString(underLine, fontRegular, Brushes.Black, 0, startY + Offset);
                Offset = Offset + 15;
                // --- Order Info Section (LABELS BOLD, VALUES REGULAR) ---

                // Token
                graphics.DrawString("Token No.#:", fontBold, Brushes.Black, startX, startY + Offset);
                graphics.DrawString("RAZ-" + orders[0].OrderID, fontRegular, Brushes.Black, startX + 75, startY + Offset); // Value regular

                // Table
                graphics.DrawString("Table No.:", fontBold, Brushes.Black, startX + 150, startY + Offset);
                graphics.DrawString(orders[0].TableName, fontRegular, Brushes.Black, startX + 215, startY + Offset); // Value regular
                Offset = Offset + 20;

                // Captain
                graphics.DrawString("Captain:", fontBold, Brushes.Black, startX, startY + Offset);
                graphics.DrawString(orders[0].sUserFullName, fontRegular, Brushes.Black, startX + 55, startY + Offset); // Value regular

                // Room
                graphics.DrawString("Room No.#:", fontBold, Brushes.Black, startX + 150, startY + Offset);
                graphics.DrawString(orders[0].RoomNo, fontRegular, Brushes.Black, startX + 225, startY + Offset); // Value regular
                Offset = Offset + 20;

                // Customer
                graphics.DrawString("Customer:", fontBold, Brushes.Black, startX, startY + Offset);
                graphics.DrawString(orders[0].NCName, fontRegular, Brushes.Black, startX + 65, startY + Offset); // Value regular
                Offset = Offset + 20;

                // Date & Time
                CultureInfo iv = CultureInfo.InvariantCulture;
                //string timeString = DateTime.Now.ToString("ddd, MMM d yyyy hh:mm tt", iv);
                //graphics.DrawString("Date & Time:", fontBold, Brushes.Black, startX, startY + Offset);
                //graphics.DrawString(timeString, fontRegular, Brushes.Black, startX + 80, startY + Offset); // Value regular
                //Offset = Offset + 20;
                string formattedDate = string.Empty;
                if (orders[0].CreatedDate != null)
                {
                    formattedDate = (orders[0].CreatedDate)
                       .ToString("dd-MM-yyyy hh:mm tt");
                }


                graphics.DrawString("Order D T:", fontBold, Brushes.Black, startX, startY + Offset);
                graphics.DrawString(formattedDate, fontRegular, Brushes.Black, startX + 80, startY + Offset);

                Offset = Offset + 20;


                // --- Items Table Header ---
                graphics.DrawString(underLine, fontRegular, Brushes.Black, 0, startY + Offset);
                Offset = Offset + 15;

                graphics.DrawString("Particulars", fontBold, Brushes.Black, new RectangleF(col1_x, startY + Offset, col1_w, 20), leftFormat);
                graphics.DrawString("Rate", fontBold, Brushes.Black, new RectangleF(col2_x, startY + Offset, col2_w, 20), rightFormat);
                graphics.DrawString("Qty", fontBold, Brushes.Black, new RectangleF(col3_x, startY + Offset, col3_w, 20), centerFormat);
                graphics.DrawString("Total", fontBold, Brushes.Black, new RectangleF(col4_x, startY + Offset, col4_w, 20), rightFormat);

                Offset = Offset + 15;
                graphics.DrawString(underLine, fontRegular, Brushes.Black, 0, startY + Offset);
                Offset = Offset + 10;

                // --- Items Loop (Fixed Word Wrap & Alignment) ---
                //foreach (var item in orders)
                //{
                //    subTotal += item.TotalAmount;

                //    // Item lamba hoga toh height automatically badh jayegi
                //    SizeF nameSize = graphics.MeasureString(item.ProductName, itemFont, col1_w);
                //    int itemHeight = (int)nameSize.Height + 5;

                //    graphics.DrawString(item.ProductName, itemFont, Brushes.Black, new RectangleF(col1_x, startY + Offset, col1_w, itemHeight), leftFormat);
                //    graphics.DrawString(underLine, fontRegular, Brushes.Black, 0, startY + Offset);
                //    Offset = Offset + 10;
                //    graphics.DrawString(Convert.ToDouble(item.ActualCost).ToString("0.00"), itemFont, Brushes.Black, new RectangleF(col2_x, startY + Offset, col2_w, itemHeight), rightFormat);
                //    graphics.DrawString(Convert.ToString(item.ProductQty), itemFont, Brushes.Black, new RectangleF(col3_x, startY + Offset, col3_w, itemHeight), centerFormat);
                //    graphics.DrawString(Convert.ToDouble(item.TotalAmount).ToString("0.00"), itemFont, Brushes.Black, new RectangleF(col4_x, startY + Offset, col4_w, itemHeight), rightFormat);

                //    Offset += itemHeight;

                //    CGST += item.CGST;
                //    SGST += item.SGST;
                //    GstTotal += item.GSTCost;
                //}
                foreach (var item in orders)
                {
                    subTotal += item.TotalAmount;

                    // Dynamic height for long text
                    SizeF nameSize = graphics.MeasureString(item.ProductName, itemFont, col1_w);
                    int itemHeight = (int)nameSize.Height + 5;

                    // 👉 Draw Item Row
                    graphics.DrawString(item.ProductName, itemFont, Brushes.Black,
                        new RectangleF(col1_x, startY + Offset, col1_w, itemHeight), leftFormat);

                    graphics.DrawString(Convert.ToDouble(item.ActualCost).ToString("0.00"), itemFont, Brushes.Black,
                        new RectangleF(col2_x, startY + Offset, col2_w, itemHeight), rightFormat);

                    graphics.DrawString(Convert.ToString(item.ProductQty), itemFont, Brushes.Black,
                        new RectangleF(col3_x, startY + Offset, col3_w, itemHeight), centerFormat);

                    graphics.DrawString(Convert.ToDouble(item.TotalAmount).ToString("0.00"), itemFont, Brushes.Black,
                        new RectangleF(col4_x, startY + Offset, col4_w, itemHeight), rightFormat);

                    // 👉 Move offset AFTER row
                    Offset += itemHeight;

                    // 👉 NOW draw underline BELOW item
                    graphics.DrawString(underLine, fontRegular, Brushes.Black, 0, startY + Offset);

                    Offset += 10;

                    CGST += item.CGST;
                    SGST += item.SGST;
                    GstTotal += item.GSTCost;
                }
                //graphics.DrawString(underLine, fontRegular, Brushes.Black, 0, startY + Offset);
                //Offset += 15;
                graphics.DrawString("Sub Total:", fontBold, Brushes.Black, new RectangleF(col2_x, startY + Offset, col2_w + col3_w, 20), rightFormat);
                graphics.DrawString((subTotal).ToString("0.00"), fontBold, Brushes.Black, new RectangleF(col4_x, startY + Offset, col4_w, 20), rightFormat);
                Offset += 15;
                // --- Totals Section ---
               
                
                double finalAmountToPrint = subTotal; // Default agar GST/Discount na ho

                if (IsPrintWithGST)
                {
                    graphics.DrawString(underLine, fontRegular, Brushes.Black, 0, startY + Offset);
                    Offset += 15;
                    // 1. Sub Total (Base Amount)
                    graphics.DrawString("Service Charge:", fontBold, Brushes.Black, new RectangleF(col2_x, startY + Offset, col2_w + col3_w, 20), rightFormat);
                    graphics.DrawString(orders[0].ServiceChargeValue.ToString("0.00"), fontBold, Brushes.Black, new RectangleF(col4_x, startY + Offset, col4_w, 20), rightFormat);
                    Offset += 15;
                    graphics.DrawString(underLine, fontRegular, Brushes.Black, 0, startY + Offset);
                    Offset += 15;
                    // 1. Sub Total (Base Amount)
                    graphics.DrawString("Total:", fontBold, Brushes.Black, new RectangleF(col2_x, startY + Offset, col2_w + col3_w, 20), rightFormat);
                    graphics.DrawString((subTotal + orders[0].ServiceChargeValue).ToString("0.00"), fontBold, Brushes.Black, new RectangleF(col4_x, startY + Offset, col4_w, 20), rightFormat);
                    Offset += 15;
                    //graphics.DrawString(underLine, fontRegular, Brushes.Black, 0, startY + Offset);
                    //Offset += 15;

                    
                    // 2. Discount Calculation (Exact same as JS)
                    double itemTotal = subTotal;
                    double serviceCharge = orders[0].ServiceChargeValue;

                    // 1. SubTotal
                    double subTotalWithSC = itemTotal + serviceCharge;

                    // 2. Discount
                    double netAfterDiscount = subTotalWithSC - Discount;
                    // GST base
                    double taxableAmount = netAfterDiscount;
                    if (Discount > 0)
                    {
                        string discPercentText = "";
                        double perc = Math.Round((Discount / subTotal) * 100.0);
                        if (perc > 0) discPercentText = " (" + perc.ToString("0") + "%)";
                        graphics.DrawString(underLine, fontRegular, Brushes.Black, 0, startY + Offset);
                        Offset += 15;
                        graphics.DrawString("Discount" + discPercentText + ":", fontBold, Brushes.Black, new RectangleF(col1_x + 50, startY + Offset, (col2_w + col3_w + 40), 20), rightFormat);
                        graphics.DrawString("-" + Discount.ToString("0.00"), fontBold, Brushes.Black, new RectangleF(col4_x, startY + Offset, col4_w, 20), rightFormat);
                        Offset += 15;

                        graphics.DrawString(underLine, fontRegular, Brushes.Black, 0, startY + Offset);
                        Offset += 15;

                        graphics.DrawString("Total After Disc:", fontBold, Brushes.Black, new RectangleF(col2_x, startY + Offset, col2_w + col3_w, 20), rightFormat);
                        graphics.DrawString(taxableAmount.ToString("0.00"), fontBold, Brushes.Black, new RectangleF(col4_x, startY + Offset, col4_w, 20), rightFormat);
                        Offset += 15;
                    }

                    // 3. GST Calculation (JS ki tarah Taxable Amount par calculate karo)
                    // Database ki value ki jagah recalculate karo taaki diff na aaye
                    double calculatedCGST = (taxableAmount * 2.5) / 100;
                    double calculatedSGST = (taxableAmount * 2.5) / 100;
                    graphics.DrawString(underLine, fontRegular, Brushes.Black, 0, startY + Offset);
                    Offset += 15;
                    graphics.DrawString("CGST (2.5%):", fontBold, Brushes.Black, new RectangleF(col2_x, startY + Offset, col2_w + col3_w, 20), rightFormat);
                    graphics.DrawString(calculatedCGST.ToString("0.00"), fontBold, Brushes.Black, new RectangleF(col4_x, startY + Offset, col4_w, 20), rightFormat);
                    Offset += 15;
                    graphics.DrawString(underLine, fontRegular, Brushes.Black, 0, startY + Offset);
                    Offset += 15;
                    graphics.DrawString("SGST (2.5%):", fontBold, Brushes.Black, new RectangleF(col2_x, startY + Offset, col2_w + col3_w, 20), rightFormat);
                    graphics.DrawString(calculatedSGST.ToString("0.00"), fontBold, Brushes.Black, new RectangleF(col4_x, startY + Offset, col4_w, 20), rightFormat);
                    Offset += 15;
                    graphics.DrawString(underLine, fontRegular, Brushes.Black, 0, startY + Offset);
                    Offset += 15;
                    // 4. Round Off Logic (JS ke Math.round se match karne ke liye)
                    double exactTotal = taxableAmount + calculatedCGST + calculatedSGST;
                    finalAmountToPrint = Math.Round(exactTotal); // Rounded Value
                    double roundOff = finalAmountToPrint - exactTotal;

                    if (Math.Abs(roundOff) > 0.01)
                    {
                        graphics.DrawString("Round off:", fontBold, Brushes.Black, new RectangleF(col2_x, startY + Offset, col2_w + col3_w, 20), rightFormat);
                        graphics.DrawString(roundOff > 0 ? "+" + roundOff.ToString("0.00") : roundOff.ToString("0.00"), fontBold, Brushes.Black, new RectangleF(col4_x, startY + Offset, col4_w, 20), rightFormat);
                        Offset += 15;
                    }

                    graphics.DrawString(underLine, fontRegular, Brushes.Black, 0, startY + Offset);
                    Offset += 15;

                    // 5. Grand Total
                    finalAmountToPrint = orders[0].GrandTotal;

                    graphics.DrawString("Grand Total:", fontHeader, Brushes.Black, new RectangleF(startX, startY + Offset, col1_w + col2_w, 25), rightFormat);
                    graphics.DrawString(finalAmountToPrint.ToString("0.00"), fontHeader, Brushes.Black, new RectangleF(col3_x, startY + Offset, col3_w + col4_w, 25), rightFormat);
                    Offset += 24;
                    graphics.DrawString("Thank you. Do visit again.", fontBold, Brushes.Black, new RectangleF(0, startY + Offset, 300, 20), centerFormat);

                }
                //else
                //{
                //    // Without GST simple calculation
                //    //finalAmountToPrint = subTotal - Discount;
                //    finalAmountToPrint = orders[0].GrandTotal;

                //    graphics.DrawString("Grand Total:", fontHeader, Brushes.Black, new RectangleF(startX, startY + Offset, col1_w + col2_w, 25), rightFormat);
                //    graphics.DrawString(finalAmountToPrint.ToString("0.00"), fontHeader, Brushes.Black, new RectangleF(col3_x, startY + Offset, col3_w + col4_w, 25), rightFormat);
                //    Offset += 20;
                //}
                // --- IF CONDITION END ---

                // Footer hamesha niche aayega


                string currentDateTime = DateTime.Now.ToString("dd-MM-yyyy hh:mm tt");

                Offset += 18;

                string text = "Print Date & Time " + currentDateTime;

                
                RectangleF rect = new RectangleF(
                    0,
                    startY + Offset,
                    300,
                    25
                );

                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;

                graphics.DrawString(
                    text,
                    fontBold,   // same font as Thank You
                    Brushes.Black,
                    rect,
                    format
                );
            }
            catch (Exception ex)
            {
                // sbLog.AppendLine("in dailyDep " + ex.StackTrace + ex.Message);
            }
        }

        public void PrintOnThermal(int orderNo, string printerName)
        {
            try
            {
                sbLog.AppendLine("in PrintOnThermal");
                orders = GetOrderDetails(orderNo);

                if (orders.Count > 0)
                {
                    PrintDocumentSettingThermal(printerName);
                }
            }
            catch (Exception ex)
            {
                sbLog.AppendLine("Exception " + ex.StackTrace + ex.Message + ex.InnerException);
            }
            finally
            {
                string fileName = "Printing" + DateTime.Now.ToString("ddMMMyyyyhhmmss");
                if (!File.Exists(fileName))
                {
                    using (StreamWriter sw = File.CreateText(fileName))
                    {
                        sw.Write(sbLog.ToString());
                    }
                }

            }

        }

        public void PrintDocumentSettingThermal(string printerName)
        {
            PrintDialog pd = new PrintDialog();
            PrintDocument pdoc = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            Font font = new Font("calibri", 15);
            PaperSize psize = new PaperSize("Custom", 100, 30000);
            try
            {
                pd.Document = pdoc;
                pd.Document.DefaultPageSettings.PaperSize = psize;
                pdoc.DefaultPageSettings.PaperSize.Height = 30000;
                pdoc.DefaultPageSettings.PaperSize.Width = 520;
                string DefprinterName = pdoc.PrinterSettings.PrinterName;
                string lanPrinterName = string.Empty;
                if (printerName.Equals("LAN"))
                {
                    lanPrinterName = GetLanPrinterName();
                    pdoc.PrinterSettings.PrinterName = lanPrinterName;
                }

                // pdoc.PrinterSettings.PrinterName = "POS";
                pdoc.PrintPage += new PrintPageEventHandler(dailyDep);

                // pd.ShowDialog(;

                pdoc.Print();
                pdoc.PrintPage -= new PrintPageEventHandler(dailyDep);
            }
            catch (Exception ex)
            {

                sbLog.AppendLine("in PrintDocumentSettingThermal" + ex.StackTrace + ex.Message);
            }


        }

        private string GetLanPrinterName()
        {
            string url = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["APIUrl"]);
            url += "/api/Printing/GetLanPrinterName";
            string results = HitToApi(url, "GET");
            return results = Newtonsoft.Json.JsonConvert.DeserializeObject(results).ToString();

        }

        static void prnDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            System.Drawing.Font fnt = new System.Drawing.Font(System.Drawing.FontFamily.GenericSerif, 10);
            e.Graphics.DrawString(prnData, fnt, System.Drawing.Brushes.Black, 0, 0);
        }
    }
}
