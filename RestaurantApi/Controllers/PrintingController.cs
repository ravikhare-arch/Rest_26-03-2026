using DBConnection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestaurantApi.Controllers
{
    public class PrintingController : ApiController
    {
        public string GetLanPrinterName()
        {
            string printerName = string.Empty;
            SqlConnection conn;
            connection objCon = new connection();
            conn = objCon.makeConnection();
            try
            {
                SqlCommand sql_cmnd = new SqlCommand("USP_GetPrinterName", conn);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                printerName= Convert.ToString(sql_cmnd.ExecuteScalar());
               
                objCon.closeConnection();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return printerName;
        }
    }
}
