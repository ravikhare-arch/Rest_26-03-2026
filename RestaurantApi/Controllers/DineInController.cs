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

namespace RestaurantApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DineInController : ApiController
    {
        public List<DineArea> GetAreaName(long id)
        {
            List<DineArea> dineareaList = new List<DineArea>();
            DineArea objDineArea = new DineArea();
            SqlConnection conn;
            connection objCon = new connection();
            conn = objCon.makeConnection();
            try
            {
                SqlCommand sql_cmnd = new SqlCommand("USP_GetAreaName", conn);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@OrderTypeID", id);
                sql_cmnd.ExecuteNonQuery();
                SqlDataReader reader = sql_cmnd.ExecuteReader();
                while (reader.Read())
                {
                    objDineArea = new DineArea();
                    objDineArea.DineAreaMasterID = int.Parse(reader["DineAreaMasterID"].ToString());
                    objDineArea.AreaName = reader["AreaName"].ToString();
                    objDineArea.OrderTypeID = int.Parse(reader["OrderType"].ToString());
                    dineareaList.Add(objDineArea);
                }
                objCon.closeConnection();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dineareaList;
        }
        public string GetTableName(long id)
        {
            string tableName =  string.Empty;
            try
            {
                SqlConnection conn;
                connection objCon = new connection();
                using (conn = objCon.makeConnection())
                {

                    using (SqlCommand sql_cmnd = new SqlCommand("USP_GetTableName", conn))
                    {
                        sql_cmnd.CommandType = CommandType.StoredProcedure;
                        sql_cmnd.Parameters.AddWithValue("@TableID", id);
                        tableName = Convert.ToString(sql_cmnd.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                return "";
            }
            return tableName;
        }
    }
}
