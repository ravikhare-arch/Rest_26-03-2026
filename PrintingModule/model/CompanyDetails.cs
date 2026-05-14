using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrintModule.Models
{
    public class CompanyDetails
    {
        public string CompanyID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public string City { get; set; }
        public string PinCode { get; set; }
        public string Contactno { get; set; }
        public string GSTNo { get; set; }
        public string CaptainName { get; set; }
        public string sUserFullName { get; set; }
    }
}