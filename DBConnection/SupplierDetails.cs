using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
//using DBConnection;

namespace DBConnection
{
   
 public  class SupplierDetails
    {
       
        public DataTable GetSupplierCredentials(string supplierCode)
        {
              SqlConnection conn;
        connection objCon = new connection();

            conn = objCon.makeConnection();
            DataTable dt = new DataTable();
            SqlDataAdapter daAdapter = new SqlDataAdapter();
            try
            {
              
                SqlCommand cmd = new SqlCommand(supplierCode, conn);
              
                cmd.CommandType = CommandType.StoredProcedure;
                daAdapter = new SqlDataAdapter(cmd);
                daAdapter.Fill(dt);
                daAdapter.Dispose();

                dt.Dispose();
                objCon.closeConnection();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;


        }
    }
}
