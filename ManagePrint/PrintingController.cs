using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace ManagePrint
{
   public class PrintingController: ApiController
    {
        StringBuilder log = new StringBuilder(string.Empty);
        [HttpGet]
        public bool Print(int id, string printerName)
        {
            
            bool isPrinted = false;
            PrintModule.Printing obj = new PrintModule.Printing();
            
            try
            {
                Console.WriteLine("entered in Print method, Printer Name: "+printerName);

                obj.IsPrintWithGST = false;
                obj.PrintOnThermal(id, printerName);
                isPrinted = true;
            }
            catch (Exception ex)
            {

                Console.WriteLine("Exception found Message: "+ ex.Message + System.Environment.NewLine + "Stack Trace:"+ ex.StackTrace);
            }

            return isPrinted;
        }

        [HttpGet]
        public bool PrintWithGst(int id, string printerName)
        {
            bool isPrinted = false;
            PrintModule.Printing obj = new PrintModule.Printing();
            obj.IsPrintWithGST = true;
            try
            {
                obj.PrintOnThermal(id, printerName);
                isPrinted = true;
            }
            catch (Exception ex)
            {

                throw;
            }

            return isPrinted;
        }
    }

  
}
