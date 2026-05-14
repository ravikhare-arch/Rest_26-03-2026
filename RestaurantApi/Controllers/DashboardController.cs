using DBConnection;
using RestaurantApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;

namespace RestaurantApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DashboardController : ApiController
    {
        [HttpGet]
       public IList<SalesData> DashboardSales()
        {
            SqlConnection conn;
            connection objCon = new connection();
            SalesData data;
            SqlCommand sql_cmnd;

            List<SalesData> ItemDataList = new List<SalesData>();

            //
            //TotalAmount TableType
            try
            {
                using (conn = objCon.makeConnection())
                {
                    using (sql_cmnd = new SqlCommand("USP_GETSalesDashboardData", conn))
                    {
                        sql_cmnd.CommandType = CommandType.StoredProcedure;
                       
                        sql_cmnd.ExecuteNonQuery();
                        SqlDataReader reader;
                        using (reader = sql_cmnd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                data = new SalesData();
                                data.TotalAmount= double.Parse(reader["TotalAmount"].ToString());
                                data.TableType = int.Parse(reader["TableType"].ToString());

                                ItemDataList.Add(data);
                            }
                        }

                    }
                    //  SqlCommand sql_cmnd = new SqlCommand("GetItembyKey", conn);
                }
                //objCon.closeConnection();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ItemDataList;
        }
    }
}
