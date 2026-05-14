using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace PrintService
{
   public class PrintingController: ApiController
    {
        [HttpGet]
        public bool Print(int id)
        {
            bool isPrinted = false;
            PrintModule.Printing obj = new PrintModule.Printing();
            try
            {
                obj.PrintOnThermal(id);
                isPrinted = true;
            }
            catch (Exception)
            {

                throw;
            }

            return isPrinted;
        }
    }
}
