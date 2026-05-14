using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System;



namespace DBConnection
{
    public class connection
    {
        public SqlConnection conn;

        public SqlConnection makeConnection()
        {
            try
            {
                //   conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                //  conn.Open();
                string stringconn1 = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                conn = new SqlConnection(stringconn1);//ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                conn.Open();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return conn;

        }
        public SqlConnection closeConnection()
        {
            conn.Close();
            return conn;
        }

        public DataSet GetDataSet(string sql)
        {
            conn = makeConnection();
            DataSet ds = new DataSet();
            SqlDataAdapter daAdapter = new SqlDataAdapter();
            try
            {

                // daAdapter.SelectCommand = new SqlCommand(sql, conn);
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nCountriesID", "98");
                cmd.Parameters.AddWithValue("@nCityID", "145710");
                cmd.Parameters.AddWithValue("@CheckIn", "20180918");
                cmd.Parameters.AddWithValue("@checkout", "20211231");

                cmd.CommandType = CommandType.StoredProcedure;
                daAdapter = new SqlDataAdapter(cmd);
                daAdapter.Fill(ds);
                daAdapter.Dispose();

                ds.Dispose();
                closeConnection();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }


    }
}