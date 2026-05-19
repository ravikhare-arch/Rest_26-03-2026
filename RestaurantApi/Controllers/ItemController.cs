using DBConnection;
using DocumentFormat.OpenXml.EMMA;
using Newtonsoft.Json;
using RestaurantApi.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace RestaurantApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ItemController : ApiController
    {
        public List<GetItembyGroupId_Result> GetItembyGroupId_Result(long id)
        {
            List<GetItembyGroupId_Result> ItemList = new List<GetItembyGroupId_Result>();
            GetItembyGroupId_Result Item1 = new GetItembyGroupId_Result();
            SqlConnection conn;
            connection objCon = new connection();
            conn = objCon.makeConnection();
            try
            {
                SqlCommand sql_cmnd = new SqlCommand("GetItembyGroupId", conn);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@GroupID", SqlDbType.Int).Value = id;
                sql_cmnd.ExecuteNonQuery();
                SqlDataReader reader = sql_cmnd.ExecuteReader();
                while (reader.Read())
                {
                    Item1 = new GetItembyGroupId_Result();
                    Item1.GroupID = int.Parse(reader["GroupID"].ToString());
                    Item1.ItemMasterID = int.Parse(reader["ItemMasterID"].ToString());
                    Item1.sProduct = reader["sProduct"].ToString();
                    Item1.nActualCost = double.Parse(reader["nPrice"].ToString());
                    Item1.CGST = double.Parse(Convert.ToString(reader["CGST"]));
                    Item1.SGST = double.Parse(Convert.ToString(reader["SGST"]));
                    Item1.IGST = double.Parse(Convert.ToString(reader["IGST"]));
                    Item1.GSTpercent = double.Parse(Convert.ToString(reader["GSTpercent"]));
                    Item1.GSTCost = double.Parse(Convert.ToString(reader["nActualCost"]));
                    Item1.TotalCost = double.Parse(Convert.ToString(reader["GSTCost"]));
                    ItemList.Add(Item1);
                }
                objCon.closeConnection();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ItemList;
            // GetItembyGroupId_Result getItembyGroupId_Result = await db.GetItembyGroupId_Result.FindAsync(id);

            //Create normal logic here as it is not working and to resolve it it will take time
            //take db connection library from hotel api and create connetion. from there just use datareader and in foreach loop set the properi
            //of class

            // ObjectResult<RestaurantApi.GetItembyGroupId_Result> getItembyGroupId_Result = db.GetItembyGroupId(id);
            //if (getItembyGroupId_Result == null)
            //{
            //    return NotFound();
            //}

            // return Ok(getItembyGroupId_Result);
        }
        [HttpGet]
        [Route("api/item/GetNCNameBasedOnOrderType")]
        public List<string> GetNCNameBasedOnOrderType()
        {
            List<string> ncNamesList = new List<string>();
            SqlConnection conn;
            connection objCon = new connection();

            try
            {
                conn = objCon.makeConnection();
                using (SqlCommand sql_cmnd = new SqlCommand("USP_GetNCNameFromOrderType", conn))
                {
                    sql_cmnd.CommandType = CommandType.StoredProcedure;

                    // 🔥 FIXED: Direct DataReader se data read karenge, extra ExecuteNonQuery block hata diya hai
                    using (SqlDataReader reader = sql_cmnd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader["NC_Name"] != DBNull.Value)
                            {
                                ncNamesList.Add(reader["NC_Name"].ToString());
                            }
                        }
                    }
                }
                objCon.closeConnection();
            }
            catch (Exception ex)
            {
                // Fail-safe system check: logs inside runtime if needed
                ncNamesList.Add("Backend Error: " + ex.Message);
            }
            return ncNamesList;
        }
        public List<GetItembyGroupId_Result> GetItembyGroupId_Result(long id, int deliveryType,int acnonac)
        {
            List<GetItembyGroupId_Result> ItemList = new List<GetItembyGroupId_Result>();
            GetItembyGroupId_Result Item1 = new GetItembyGroupId_Result();
            SqlConnection conn;
            connection objCon = new connection();
            conn = objCon.makeConnection();
            try
            {
                SqlCommand sql_cmnd = new SqlCommand("GetItembyGroupId", conn);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@GroupID", SqlDbType.Int).Value = id;
                sql_cmnd.Parameters.AddWithValue("@deliveryType", SqlDbType.Int).Value = deliveryType;
                sql_cmnd.Parameters.AddWithValue("@ACNONAC", SqlDbType.Int).Value = acnonac;
                sql_cmnd.ExecuteNonQuery();
                SqlDataReader reader = sql_cmnd.ExecuteReader();
                while (reader.Read())
                {
                    Item1 = new GetItembyGroupId_Result();
                    Item1.GroupID = int.Parse(reader["GroupID"].ToString());
                    Item1.ItemMasterID = int.Parse(reader["ItemMasterID"].ToString());
                    Item1.sProduct = reader["sProduct"].ToString();
                    Item1.nActualCost = double.Parse(reader["nPrice"].ToString());
                    Item1.CGST = double.Parse(Convert.ToString(reader["CGST"]));
                    Item1.SGST = double.Parse(Convert.ToString(reader["SGST"]));
                    Item1.IGST = double.Parse(Convert.ToString(reader["IGST"]));
                    Item1.GSTpercent = double.Parse(Convert.ToString(reader["GSTpercent"]));
                    Item1.GSTCost = double.Parse(Convert.ToString(reader["nActualCost"]));
                    Item1.TotalCost = double.Parse(Convert.ToString(reader["GSTCost"]));
                    ItemList.Add(Item1);
                }
                objCon.closeConnection();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ItemList;

        }
        /// <summary>
        /// Below method is obsolete and will never be used. 
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpGet]
        public List<GetItembyGroupId_Result> ItemListByKey(string keyValue)
        {
            List<GetItembyGroupId_Result> ItemList = new List<GetItembyGroupId_Result>();
            GetItembyGroupId_Result Item1 = new GetItembyGroupId_Result();
            SqlConnection conn;
            connection objCon = new connection();

            SqlCommand sql_cmnd;
            try
            {
                using (conn = objCon.makeConnection())
                {
                    using (sql_cmnd = new SqlCommand("GetItembyKey", conn))
                    {
                        sql_cmnd.CommandType = CommandType.StoredProcedure;
                        sql_cmnd.Parameters.AddWithValue("@Key", keyValue);
                        sql_cmnd.ExecuteNonQuery();
                        SqlDataReader reader;
                        using (reader = sql_cmnd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Item1 = new GetItembyGroupId_Result();
                                Item1.GroupID = int.Parse(reader["GroupID"].ToString());
                                Item1.ItemMasterID = int.Parse(reader["ItemMasterID"].ToString());
                                Item1.sProduct = reader["sProduct"].ToString();
                                Item1.nActualCost = double.Parse(reader["nPrice"].ToString());
                                Item1.CGST = double.Parse(Convert.ToString(reader["CGST"]));
                                Item1.SGST = double.Parse(Convert.ToString(reader["SGST"]));
                                Item1.IGST = double.Parse(Convert.ToString(reader["IGST"]));
                                Item1.GSTpercent = double.Parse(Convert.ToString(reader["GSTpercent"]));
                                Item1.GSTCost = double.Parse(Convert.ToString(reader["nActualCost"]));
                                Item1.TotalCost = double.Parse(Convert.ToString(reader["GSTCost"]));
                                ItemList.Add(Item1);
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
            return ItemList;
            // GetItembyGroupId_Result getItembyGroupId_Result = await db.GetItembyGroupId_Result.FindAsync(id);

            //Create normal logic here as it is not working and to resolve it it will take time
            //take db connection library from hotel api and create connetion. from there just use datareader and in foreach loop set the properi
            //of class

            // ObjectResult<RestaurantApi.GetItembyGroupId_Result> getItembyGroupId_Result = db.GetItembyGroupId(id);
            //if (getItembyGroupId_Result == null)
            //{
            //    return NotFound();
            //}

            // return Ok(getItembyGroupId_Result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="deliveryType"></param>
        /// <returns></returns>
        [HttpGet]
        public List<GetItembyGroupId_Result> ItemListByKey(string keyValue, int deliveryType)
        {
            List<GetItembyGroupId_Result> ItemList = new List<GetItembyGroupId_Result>();
            GetItembyGroupId_Result Item1 = new GetItembyGroupId_Result();
            SqlConnection conn;
            connection objCon = new connection();

            SqlCommand sql_cmnd;
            try
            {
                using (conn = objCon.makeConnection())
                {
                    using (sql_cmnd = new SqlCommand("GetItembyKey", conn))
                    {
                        sql_cmnd.CommandType = CommandType.StoredProcedure;
                        sql_cmnd.Parameters.AddWithValue("@Key", keyValue);
                        sql_cmnd.Parameters.AddWithValue("@deliveryType", deliveryType);
                        sql_cmnd.ExecuteNonQuery();
                        SqlDataReader reader;
                        using (reader = sql_cmnd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Item1 = new GetItembyGroupId_Result();
                                Item1.GroupID = int.Parse(reader["GroupID"].ToString());
                                Item1.ItemMasterID = int.Parse(reader["ItemMasterID"].ToString());
                                Item1.sProduct = reader["sProduct"].ToString();
                                Item1.nActualCost = double.Parse(reader["nPrice"].ToString());
                                Item1.CGST = double.Parse(Convert.ToString(reader["CGST"]));
                                Item1.SGST = double.Parse(Convert.ToString(reader["SGST"]));
                                Item1.IGST = double.Parse(Convert.ToString(reader["IGST"]));
                                Item1.GSTpercent = double.Parse(Convert.ToString(reader["GSTpercent"]));
                                Item1.GSTCost = double.Parse(Convert.ToString(reader["nActualCost"]));
                                Item1.TotalCost = double.Parse(Convert.ToString(reader["GSTCost"]));
                                ItemList.Add(Item1);
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
            return ItemList;
            // GetItembyGroupId_Result getItembyGroupId_Result = await db.GetItembyGroupId_Result.FindAsync(id);

            //Create normal logic here as it is not working and to resolve it it will take time
            //take db connection library from hotel api and create connetion. from there just use datareader and in foreach loop set the properi
            //of class

            // ObjectResult<RestaurantApi.GetItembyGroupId_Result> getItembyGroupId_Result = db.GetItembyGroupId(id);
            //if (getItembyGroupId_Result == null)
            //{
            //    return NotFound();
            //}

            // return Ok(getItembyGroupId_Result);
        }

        public int SaveItemOrderDetail(List<SalesOrder> salesOrders)
        {



            /****** if you see that salesOrder parameter is having list of added record  ************************************
             *  so if you have 10 count you will have to do foreach and will have to call 10 times database hit to save record
             *  solution to pass table varialble as a parameter in sql and write like below
             *  
             *  insert into  [maintabl name]
             *  select * from @tableTypeParameter 
             *  
             *  above query will be written in sql procedure
             *  
             *  same type of work has been done on generate debit and generate credit note so you can take reference from their.
             *  *******************************************************************************************************/

            DataTable dt = GetSalesOrderTable(salesOrders);

            int noOfRos = SaveSalesOrderDetail(dt, salesOrders[0].OrderType, salesOrders[0].OrderID, salesOrders[0].TableID, salesOrders[0].RoomNo, salesOrders[0].NCRadio);
            if (noOfRos > 0)
                return noOfRos;
            else
                return -1;
            // return msg;
        }

        private int SaveSalesOrderDetail(DataTable dtSalesOrder, int orderType, int OrderID, int TableID,string RoomNo,string NCRadio)
        {
            int noOfRowsAffeted = 0;
            try
            {
                SqlConnection conn;
                connection objCon = new connection();
                using (conn = objCon.makeConnection())
                {

                    using (SqlCommand sql_cmnd = new SqlCommand("SP_SalesOrderDetail", conn))
                    {
                        sql_cmnd.CommandType = CommandType.StoredProcedure;
                        sql_cmnd.Parameters.AddWithValue("@dtSalesOrder", dtSalesOrder);
                        sql_cmnd.Parameters.AddWithValue("@OrderType", orderType);
                        sql_cmnd.Parameters.AddWithValue("@OrderID", OrderID);
                        sql_cmnd.Parameters.AddWithValue("@CreatedBy", 1);
                        sql_cmnd.Parameters.AddWithValue("@Type", "add");
                        sql_cmnd.Parameters.AddWithValue("@TableID", TableID);
                        sql_cmnd.Parameters.AddWithValue("@RoomNumber", RoomNo);
                        sql_cmnd.Parameters.AddWithValue("@NCRadio", NCRadio);
                        noOfRowsAffeted = Convert.ToInt32(sql_cmnd.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {

                return 0;
            }
            return noOfRowsAffeted;
        }

        private DataTable GetSalesOrderTable(List<SalesOrder> salesOrders)
        {
            DataTable dt = new DataTable();

            // 1. SQL UDTT ke exact sequence mein columns add karein
            dt.Columns.Add("ItemMasterID", typeof(long));
            dt.Columns.Add("OrderID", typeof(long));
            dt.Columns.Add("OrderType", typeof(int));
            dt.Columns.Add("ProductName", typeof(string));
            dt.Columns.Add("ActualCost", typeof(double));
            dt.Columns.Add("TotalAmount", typeof(double)); // Base Total After Discount
            dt.Columns.Add("ProductQty", typeof(int));
            dt.Columns.Add("CGST", typeof(double));
            dt.Columns.Add("SGST", typeof(double));
            dt.Columns.Add("IGST", typeof(double));
            dt.Columns.Add("GSTCost", typeof(double));    // Total Tax (CGST + SGST)
            dt.Columns.Add("GSTPercent", typeof(double));
            dt.Columns.Add("ItemRemark", typeof(string));
            dt.Columns.Add("TableName", typeof(string));
            dt.Columns.Add("RoomNo", typeof(string));
            dt.Columns.Add("RTID", typeof(int));
            dt.Columns.Add("GCID", typeof(int));
            dt.Columns.Add("NCName", typeof(string));
            dt.Columns.Add("GrandTotal", typeof(double)); // Final Paid Amount
            dt.Columns.Add("NCRadio", typeof(string));

            try
            {
                foreach (var item in salesOrders)
                {
                    DataRow dr = dt.NewRow();

                    // Basic Info
                    dr["ItemMasterID"] = item.ItemMasterID;
                    dr["OrderID"] = item.OrderID;
                    dr["OrderType"] = item.OrderType;
                    dr["ProductName"] = item.ProductName;
                    dr["ActualCost"] = item.ActualCost;
                    dr["ProductQty"] = item.ProductQty;

                    // --- Calculation Logic (Recalculated for Accuracy) ---

                    // 1. Total Amount (Quantity * Rate)
                    double baseTotal = item.ActualCost * item.ProductQty;
                    dr["TotalAmount"] = baseTotal;

                    // 2. Tax Calculation (Strictly 2.5% each if GST is applied)
                    double cgst = 0, sgst = 0, totalTax = 0;

                    // Note: Frontend se item.GSTPercent ya item.isApplyGST check karein
                    if (item.GSTPercent > 0 || item.CGST > 0)
                    {
                        cgst = (baseTotal * 2.5) / 100;
                        sgst = (baseTotal * 2.5) / 100;
                        totalTax = cgst + sgst;
                    }

                    dr["CGST"] = Math.Round(cgst, 2);
                    dr["SGST"] = Math.Round(sgst, 2);
                    dr["IGST"] = 0;
                    dr["GSTCost"] = Math.Round(totalTax, 2);
                    dr["GSTPercent"] = 5.0; // Total 5% (2.5+2.5)

                    // 3. Rounding & Final Paid Amount
                    double rawGrandTotal = baseTotal + totalTax;
                    // Standard Rounding: .50 up, .49 down
                    double roundedPaidAmount = Math.Round(rawGrandTotal);

                    dr["GrandTotal"] = roundedPaidAmount; // Ye total paid hai

                    // Metadata
                    dr["ItemRemark"] = item.ItemRemarks ?? "";
                    dr["TableName"] = item.TableName ?? "";
                    dr["RoomNo"] = item.RoomNo ?? "";
                    dr["RTID"] = item.RTID;
                    dr["GCID"] = item.GCID;
                    dr["NCName"] = item.NCName ?? "";
                    dr["NCRadio"] = item.NCRadio ?? "";

                    dt.Rows.Add(dr);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Mapping Error: " + ex.Message);
            }
            return dt;
        }

        [HttpGet]
        public List<SalesOrder> PendingSalesOrder(string tableStatus)
        {
            List<SalesOrder> pendingSalesOrderlist = new List<SalesOrder>();
            SalesOrder pendingorderlist = new SalesOrder();
            SqlConnection conn;
            connection objCon = new connection();
            conn = objCon.makeConnection();
            try
            {
                SqlCommand sql_cmnd = new SqlCommand("USP_OrderStatus", conn);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@Status", tableStatus);
                sql_cmnd.ExecuteNonQuery();
                SqlDataReader reader = sql_cmnd.ExecuteReader();
                while (reader.Read())
                {
                    pendingorderlist = new SalesOrder();
                    pendingorderlist.OrderID = int.Parse(reader["OrderID"].ToString());
                    pendingorderlist.OrderType = int.Parse(reader["ordertypeval"].ToString());
                    pendingorderlist.DeliveredBy = reader["DeliveredBy"].ToString();
                    pendingorderlist.CustomerName = reader["CustomerName"].ToString();
                    pendingorderlist.TableStatus = reader["TableStatus"].ToString();
                    pendingorderlist.TotalOrderAmount = double.Parse(reader["TotalOrderAmount"].ToString());
                    pendingorderlist.Charge = double.Parse(reader["Charge"].ToString());
                    pendingorderlist.TotalPaid = double.Parse(reader["TotalPaid"].ToString());
                    pendingorderlist.PaymentStatus = reader["PaymentStatus"].ToString();
                    pendingorderlist.PayMode = reader["PayMode"].ToString();
                    pendingorderlist.OrderTypeName = reader["OrderType"].ToString();
                    pendingorderlist.OrderDate = reader["orderdate"].ToString();
                    pendingorderlist.OrderTime = reader["ordertime"].ToString();
                    pendingorderlist.OrderNo = reader["OrderNo"].ToString();
                    pendingorderlist.TableID = int.Parse(reader["TableID"].ToString());
                    pendingorderlist.TableName = reader["TableName"].ToString();
                    pendingorderlist.NCName = reader["NCName"].ToString();
                    pendingorderlist.RoomNumber = reader["RoomNumber"].ToString();
                    pendingorderlist.NCRadio = reader["NCRadio"].ToString();
                    pendingSalesOrderlist.Add(pendingorderlist);
                }
                objCon.closeConnection();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return pendingSalesOrderlist;
        }

        //[HttpGet]
        //public List<SalesOrder> OrderDetailbyOrderID(long id)
        //{
        //    CompanyDetails companydetails = new CompanyDetails();
        //    List<SalesOrder> OrderDetlist = new List<SalesOrder>();
        //    SalesOrder orderDet = new SalesOrder();
        //    SqlConnection conn;
        //    connection objCon = new connection();
        //    conn = objCon.makeConnection();
        //    try
        //    {
        //        SqlCommand sql_cmnd = new SqlCommand("USP_OrderDetailbyOrderID", conn);
        //        sql_cmnd.CommandType = CommandType.StoredProcedure;
        //        sql_cmnd.Parameters.AddWithValue("@OrderID", SqlDbType.Int).Value = id;
        //        sql_cmnd.ExecuteNonQuery();
        //        SqlDataReader reader = sql_cmnd.ExecuteReader();
        //        int count = 0;
        //        while (reader.Read())
        //        {
        //            count = count + 1;

        //            orderDet = new SalesOrder();
        //            orderDet.OrderID = Convert.ToInt32(reader["OrderID"]);
        //            orderDet.SalesOrderDetailID = int.Parse(reader["SalesOrderDetailID"].ToString());
        //            orderDet.ItemMasterID = int.Parse(reader["ItemMasterID"].ToString());
        //            orderDet.ProductName = reader["ProductName"].ToString();
        //            orderDet.ProductQty = int.Parse(reader["ProductQty"].ToString());
        //            orderDet.ActualCost = double.Parse(reader["ActualCost"].ToString());
        //            orderDet.TotalAmount = double.Parse(reader["TotalAmount"].ToString());
        //            orderDet.CGST = double.Parse(reader["CGST"].ToString());
        //            orderDet.SGST = double.Parse(reader["SGST"].ToString());
        //            orderDet.IGST = double.Parse(reader["IGST"].ToString());
        //            orderDet.GSTPercent = double.Parse(reader["GSTPercentage"].ToString());
        //            orderDet.GSTCost = double.Parse(reader["TotalGST"].ToString());
        //            orderDet.RoomNo = reader["RoomNo"].ToString();
        //            orderDet.CustomerName = reader["CustomerName"].ToString();
        //            orderDet.NCName = reader["NCName"].ToString();
        //            orderDet.sUserFullName = reader["sUserFullName"].ToString();
        //            orderDet.TotalDiscount = double.Parse(reader["TotalDiscount"].ToString()); 
        //            orderDet.GrandTotal = double.Parse(reader["GrandTotal"].ToString());
        //            //orderDet.RoomNumber = reader["RoomNumber"].ToString();

        //            if (count == 1)
        //            {
        //                DataTable dtcomp = GetCompanyDetails();
        //                if (dtcomp.Rows.Count > 0)
        //                {
        //                    for (int i = 0; i < dtcomp.Rows.Count; i++)
        //                    {

        //                        companydetails.Name = dtcomp.Rows[i]["CompanyName"].ToString();
        //                        companydetails.Address = dtcomp.Rows[i]["Addrees"].ToString();
        //                        companydetails.City = dtcomp.Rows[i]["City"].ToString();
        //                        companydetails.PinCode = dtcomp.Rows[i]["PinCode"].ToString();
        //                        companydetails.Contactno = dtcomp.Rows[i]["ContactNumber"].ToString();
        //                        companydetails.GSTNo = dtcomp.Rows[i]["GSTNumber"].ToString();
        //                        companydetails.CaptainName = dtcomp.Rows[i]["CaptainName"].ToString();

        //                    }
        //                }
        //            }
        //            orderDet.companydetails = companydetails;
        //            OrderDetlist.Add(orderDet);
        //        }
        //        objCon.closeConnection();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return OrderDetlist;
        //}

        [HttpGet]
        public List<SalesOrder> OrderDetailbyOrderID(long id)
        {
            CompanyDetails companydetails = new CompanyDetails();
            List<SalesOrder> OrderDetlist = new List<SalesOrder>();

            // Sabse pehle company details fetch kar lo (Loop ke bahar taaki baar-baar na chale)
            DataTable dtcomp = GetCompanyDetails();
            if (dtcomp != null && dtcomp.Rows.Count > 0)
            {
                companydetails.Name = dtcomp.Rows[0]["CompanyName"].ToString();
                companydetails.Address = dtcomp.Rows[0]["Addrees"].ToString();
                companydetails.City = dtcomp.Rows[0]["City"].ToString();
                companydetails.PinCode = dtcomp.Rows[0]["PinCode"].ToString();
                companydetails.Contactno = dtcomp.Rows[0]["ContactNumber"].ToString();
                companydetails.GSTNo = dtcomp.Rows[0]["GSTNumber"].ToString();
                companydetails.CaptainName = dtcomp.Rows[0]["CaptainName"].ToString();
            }

            SqlConnection conn;
            connection objCon = new connection();
            conn = objCon.makeConnection();

            try
            {
                SqlCommand sql_cmnd = new SqlCommand("USP_OrderDetailbyOrderID", conn);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@OrderID", id);

                SqlDataReader reader = sql_cmnd.ExecuteReader();

                while (reader.Read())
                {
                    SalesOrder orderDet = new SalesOrder();
                    // Basic Strings & IDs
                    orderDet.OrderID = Convert.ToInt32(reader["OrderID"]);
                    orderDet.SalesOrderDetailID = Convert.ToInt32(reader["SalesOrderDetailID"]);
                    orderDet.ItemMasterID = Convert.ToInt32(reader["ItemMasterID"]);
                    orderDet.ProductName = reader["ProductName"].ToString();
                    orderDet.ProductQty = Convert.ToInt32(reader["ProductQty"]);
                    orderDet.RoomNo = reader["RoomNo"].ToString();
                    orderDet.CustomerName = reader["CustomerName"].ToString();
                    orderDet.NCName = reader["NCName"].ToString();
                    orderDet.sUserFullName = reader["sUserFullName"].ToString();
                    orderDet.TableName = reader["TableName"].ToString();
                    orderDet.NCRadio = reader["NCRadio"].ToString();
                    // Safe Numeric Conversions (NULL handle karne ke liye)
                    orderDet.ActualCost = Convert.ToDouble(reader["ActualCost"] == DBNull.Value ? 0 : reader["ActualCost"]);
                    orderDet.TotalAmount = Convert.ToDouble(reader["TotalAmount"] == DBNull.Value ? 0 : reader["TotalAmount"]);
                    orderDet.CGST = Convert.ToDouble(reader["CGST"] == DBNull.Value ? 0 : reader["CGST"]);
                    orderDet.SGST = Convert.ToDouble(reader["SGST"] == DBNull.Value ? 0 : reader["SGST"]);
                    orderDet.IGST = Convert.ToDouble(reader["IGST"] == DBNull.Value ? 0 : reader["IGST"]);
                    orderDet.GSTPercent = Convert.ToDouble(reader["GSTPercentage"] == DBNull.Value ? 0 : reader["GSTPercentage"]);
                    orderDet.GSTCost = Convert.ToDouble(reader["TotalGST"] == DBNull.Value ? 0 : reader["TotalGST"]);
                    orderDet.TotalDiscount = Convert.ToDouble(reader["TotalDiscount"] == DBNull.Value ? 0 : reader["TotalDiscount"]);
                    orderDet.GrandTotal = Convert.ToDouble(reader["GrandTotal"] == DBNull.Value ? 0 : reader["GrandTotal"]);
                    orderDet.ServiceChargeValue = Convert.ToDouble(reader["ServiceChargeValue"] == DBNull.Value ? 0 : reader["ServiceChargeValue"]);

                    if (reader["CreatedDate"] != DBNull.Value)
                    {
                        orderDet.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                    }
                    else
                    {
                        orderDet.CreatedDate = DateTime.Now;
                    }
                    // Link company details
                    orderDet.companydetails = companydetails;

                    OrderDetlist.Add(orderDet);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                // Log error here
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    objCon.closeConnection();
                }
            }
            return OrderDetlist;
        }
        public string UpdateOrderStatus(List<SalesOrder> salesOrders)
        {
            int noOfRowsAffeted = 0;
            string successmsg = string.Empty;
            try
            {
                SqlConnection conn;
                connection objCon = new connection();
                using (conn = objCon.makeConnection())
                {
                    using (SqlCommand sql_cmnd = new SqlCommand("USP_UpdateOrderStatus", conn))
                    {
                        sql_cmnd.CommandType = CommandType.StoredProcedure;
                        sql_cmnd.Parameters.AddWithValue("@OrderID", salesOrders[0].OrderID);
                        sql_cmnd.Parameters.AddWithValue("@PayMode", salesOrders[0].PayMode);
                        sql_cmnd.Parameters.AddWithValue("@CustomerName", salesOrders[0].CustomerName);
                        sql_cmnd.Parameters.AddWithValue("@CGST", salesOrders[0].CGST);
                        sql_cmnd.Parameters.AddWithValue("@SGST", salesOrders[0].SGST);
                        sql_cmnd.Parameters.AddWithValue("@TotalOrderedAmount", salesOrders[0].TotalOrderAmount);
                        sql_cmnd.Parameters.AddWithValue("@CustomerGST", salesOrders[0].CustomerGST);
                        sql_cmnd.Parameters.AddWithValue("@CustomerEmail", salesOrders[0].CustomerEmail);
                        sql_cmnd.Parameters.AddWithValue("@CustomerNumber", salesOrders[0].CustomerNumber);
                        sql_cmnd.Parameters.AddWithValue("@CustomerAddress", salesOrders[0].CustomerAddress);
                        sql_cmnd.Parameters.AddWithValue("@GrandTotal", salesOrders[0].GrandTotal);
                        sql_cmnd.Parameters.AddWithValue("@SubTotal", salesOrders[0].SubTotal);
                        sql_cmnd.Parameters.AddWithValue("@GSTPercentage", salesOrders[0].GSTPercent);
                        sql_cmnd.Parameters.AddWithValue("@TotalDiscount", salesOrders[0].TotalDiscount);
                        sql_cmnd.Parameters.AddWithValue("@TotalCharges", salesOrders[0].Charge);
                        sql_cmnd.Parameters.AddWithValue("@DiscountValue", salesOrders[0].DiscountValue);
                        sql_cmnd.Parameters.AddWithValue("@IsApplyGST", salesOrders[0].IsApplyGST);
                        sql_cmnd.Parameters.AddWithValue("@RoomNumber", salesOrders[0].RoomNumber);
                        sql_cmnd.Parameters.AddWithValue("@NCName", salesOrders[0].NCName);
                        sql_cmnd.Parameters.AddWithValue("@nLoginID", salesOrders[0].nLoginID);
                        sql_cmnd.Parameters.AddWithValue("@sLogin", salesOrders[0].sLogin);
                        sql_cmnd.Parameters.AddWithValue("@sUserFullName", salesOrders[0].sUserFullName);
                        sql_cmnd.Parameters.AddWithValue("@TableName", salesOrders[0].TableName);
                        noOfRowsAffeted = Convert.ToInt32(sql_cmnd.ExecuteScalar());
                        if (noOfRowsAffeted > 0)
                            successmsg = "success";
                        else
                            successmsg = "failed";
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
            return successmsg;

        }

        [HttpGet]
        public List<SalesOrder> PendingOrCompletedSalesOrder(long id)
        {
            List<SalesOrder> SalesOrderlist = new List<SalesOrder>();
            SalesOrder orderlist = new SalesOrder();
            SqlConnection conn;
            connection objCon = new connection();
            conn = objCon.makeConnection();
            try
            {
                SqlCommand sql_cmnd = new SqlCommand("USP_OrderBasedOnOrderID", conn);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@OrderID", id);
                sql_cmnd.ExecuteNonQuery();
                SqlDataReader reader = sql_cmnd.ExecuteReader();
                while (reader.Read())
                {
                    orderlist = new SalesOrder();
                    orderlist.OrderID = int.Parse(reader["OrderID"].ToString());
                    orderlist.RoomNo = reader["RoomNo"].ToString();
                    orderlist.DeliveredBy = reader["DeliveredBy"].ToString();
                    orderlist.CustomerName = reader["CustomerName"].ToString();
                    orderlist.CustomerNumber = reader["CustomerNumber"].ToString();
                    orderlist.CustomerEmail = reader["CustomerEmail"].ToString();
                    orderlist.CustomerAddress = reader["CustomerAddress"].ToString();
                    orderlist.CustomerGST = reader["CustomerGST"].ToString();
                    orderlist.TableStatus = reader["TableStatus"].ToString();
                    orderlist.TotalOrderAmount = double.Parse(reader["TotalOrderAmount"].ToString());
                    orderlist.TotalDiscount = double.Parse(reader["TotalDiscount"].ToString());
                    orderlist.CGST = double.Parse(reader["CGST"].ToString());
                    orderlist.SGST = double.Parse(reader["SGST"].ToString());
                    orderlist.IGST = double.Parse(reader["IGST"].ToString());
                    orderlist.GSTCost = double.Parse(reader["Totaltax"].ToString());
                    orderlist.Charge = double.Parse(reader["Charge"].ToString());
                    orderlist.TotalPaid = double.Parse(reader["TotalPaid"].ToString());
                    orderlist.GSTPercent = double.Parse(reader["GSTPercentage"].ToString());
                    orderlist.GivenAmount = double.Parse(reader["GivenAmount"].ToString());
                    orderlist.ReturnAmount = double.Parse(reader["ReturnAmount"].ToString());
                    orderlist.SubTotal = double.Parse(reader["SubTotal"].ToString());
                    orderlist.GrandTotal = double.Parse(reader["GrandTotal"].ToString());
                    orderlist.PaymentStatus = reader["PaymentStatus"].ToString();
                    orderlist.PayMode = reader["PayMode"].ToString();
                    orderlist.NCName = reader["NCName"].ToString();
                    orderlist.CreatedDate = (DateTime)(reader["CreatedDate"] != DBNull.Value
                       ? Convert.ToDateTime(reader["CreatedDate"])
                       : (DateTime?)null);

                    SalesOrderlist.Add(orderlist);

                }
                objCon.closeConnection();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return SalesOrderlist;
        }

        [HttpGet]
        public List<SalesOrder> SummationofOrders(long id)
        {
            List<SalesOrder> OrderDetlist = new List<SalesOrder>();
            SalesOrder orderDet = new SalesOrder();
            SqlConnection conn;
            connection objCon = new connection();
            conn = objCon.makeConnection();
            try
            {
                SqlCommand sql_cmnd = new SqlCommand("USP_SummationofOrders", conn);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@OrderID", SqlDbType.Int).Value = id;
                sql_cmnd.ExecuteNonQuery();
                SqlDataReader reader = sql_cmnd.ExecuteReader();
                while (reader.Read())
                {
                    orderDet = new SalesOrder();
                    orderDet.ActualCost = double.Parse(reader["TotalAmount"].ToString());
                    orderDet.TotalDiscount = double.Parse(reader["TotalDiscount"].ToString());
                    orderDet.sUserFullName = (reader["sUserFullName"].ToString());
                    orderDet.TableName = reader["TableName"].ToString();
                    orderDet.Total_aft_Dis = reader["Total_aft_Dis"].ToString();
                    orderDet.SavedGrandTotal = reader["SavedGrandTotal"].ToString();
                    orderDet.CreatedDate = (DateTime)(reader["CreatedDate"] != DBNull.Value
                        ? Convert.ToDateTime(reader["CreatedDate"])
                        : (DateTime?)null);

                    orderDet.TotalPaid= double.Parse(reader["TotalPaid"].ToString());
                    orderDet.TotalAmount = double.Parse(reader["TotalAmount"].ToString());
                    orderDet.CGST = double.Parse(reader["CGST"].ToString());
                    orderDet.SGST = double.Parse(reader["SGST"].ToString());
                    orderDet.IGST = double.Parse(reader["IGST"].ToString());
                    orderDet.GSTPercent = double.Parse(reader["GSTPercentage"].ToString());
                    orderDet.GSTGrandTotal = double.Parse(reader["GSTGrandTotal"].ToString());
                    //orderDet.GrandTotal = double.Parse(reader["GrandTotal"].ToString());
                    orderDet.IsApplyGST = bool.Parse(reader["IsApplyGST"].ToString());
                    orderDet.OrderNo = reader["OrderNo"].ToString();
                    orderDet.RoomNumber = reader["RoomNumber"].ToString();
                    orderDet.CustomerName = reader["CustomerName"].ToString();
                    orderDet.NCName = reader["NCName"].ToString();
                    orderDet.RoundOffValue = reader["RoundOffValue"].ToString();
                    orderDet.ServiceChargeValue = double.Parse(reader["ServiceChargeValue"].ToString());
                    


                    OrderDetlist.Add(orderDet);
                }

                objCon.closeConnection();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return OrderDetlist;
        }

        [HttpGet]
        public int GetOrderIDbasedonTableID(long id)
        {
            int orderID = 0;
            try
            {
                SqlConnection conn;
                connection objCon = new connection();
                using (conn = objCon.makeConnection())
                {

                    using (SqlCommand sql_cmnd = new SqlCommand("USP_GetOrderIDfromTableID", conn))
                    {
                        sql_cmnd.CommandType = CommandType.StoredProcedure;
                        sql_cmnd.Parameters.AddWithValue("@TableID", id);
                        orderID = Convert.ToInt32(sql_cmnd.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {

                return 0;
            }
            return orderID;
        }


        //public List<SalesOrder> CompletedOrders(string orderType, string startDate, string endDate, string payMode)
        //{
        //    string cnvrtstartdate=string.Empty, convrtenddate = string.Empty;
        //    if (!string.IsNullOrEmpty(startDate) && !string.IsNullOrEmpty(endDate))
        //    {
        //        cnvrtstartdate = dateToText(startDate);
        //        convrtenddate = dateToText(endDate);
        //    }

        //    List<SalesOrder> pendingSalesOrderlist = new List<SalesOrder>();
        //    SalesOrder pendingorderlist = new SalesOrder();
        //    SqlConnection conn;
        //    connection objCon = new connection();
        //    conn = objCon.makeConnection();
        //    try
        //    {
        //        SqlCommand sql_cmnd = new SqlCommand("USP_OrderType", conn);
        //        sql_cmnd.CommandType = CommandType.StoredProcedure;
        //        sql_cmnd.Parameters.AddWithValue("@orderType", orderType);
        //        sql_cmnd.Parameters.AddWithValue("@StartDate", cnvrtstartdate);
        //        sql_cmnd.Parameters.AddWithValue("@EndDate", convrtenddate);
        //        sql_cmnd.Parameters.AddWithValue("@PayMode", payMode);
        //        sql_cmnd.ExecuteNonQuery();
        //        SqlDataReader reader = sql_cmnd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            pendingorderlist = new SalesOrder();
        //            pendingorderlist.OrderID = int.Parse(reader["OrderID"].ToString());
        //            pendingorderlist.RoomNo = reader["RoomNo"].ToString();

        //            pendingorderlist.OrderType = int.Parse(reader["ordertypeval"].ToString());
        //            pendingorderlist.DeliveredBy = reader["DeliveredBy"].ToString();
        //            pendingorderlist.CustomerName = reader["CustomerName"].ToString();
        //            pendingorderlist.TableStatus = reader["TableStatus"].ToString();
        //            pendingorderlist.TotalOrderAmount = double.Parse(reader["TotalOrderAmount"].ToString());
        //            pendingorderlist.Charge = double.Parse(reader["Charge"].ToString());
        //            pendingorderlist.TotalPaid = double.Parse(reader["TotalPaid"].ToString());
        //            pendingorderlist.PaymentStatus = reader["PaymentStatus"].ToString();
        //            pendingorderlist.PayMode = reader["PayMode"].ToString();
        //            pendingorderlist.OrderTypeName = reader["OrderType"].ToString();
        //            pendingorderlist.OrderDate = reader["orderdate"].ToString();
        //            pendingorderlist.OrderTime = reader["ordertime"].ToString();
        //            pendingorderlist.OrderNo = reader["OrderNo"].ToString();
        //            pendingorderlist.TotalDiscount = double.Parse(reader["TotalDiscount"].ToString());
        //            pendingorderlist.GSTCost = double.Parse(reader["TotalTax"].ToString());
        //            pendingorderlist.TableID = int.Parse(reader["TableID"].ToString());
        //            //pendingorderlist.RoomNumber = (reader["RoomNumber"].ToString());
        //            pendingSalesOrderlist.Add(pendingorderlist);

        //        }
        //        objCon.closeConnection();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return pendingSalesOrderlist;
        //}

        [HttpGet]
        public List<SalesOrder> CompletedOrders(string orderType, string startDate, string endDate, string payMode)
        {
            List<SalesOrder> list = new List<SalesOrder>();
            connection objCon = new connection();
            SqlConnection conn = objCon.makeConnection();

            string[] formats = { "yyyy-MM-dd", "yyyy-M-d", "dd/MM/yyyy", "d/M/yyyy" };

            try
            {
                SqlCommand cmd = new SqlCommand("USP_OrderType", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                string formattedStart = "0";
                string formattedEnd = "0";

                if (!string.IsNullOrEmpty(startDate) && startDate != "0")
                {
                    DateTime sDate;
                    if (DateTime.TryParseExact(startDate, formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out sDate) ||
                        DateTime.TryParse(startDate, out sDate))
                    {
                        formattedStart = sDate.ToString("yyyy-MM-dd");
                    }
                    else { formattedStart = "0"; }
                }

                if (!string.IsNullOrEmpty(endDate) && endDate != "0")
                {
                    DateTime eDate;
                    if (DateTime.TryParseExact(endDate, formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out eDate) ||
                        DateTime.TryParse(endDate, out eDate))
                    {
                        formattedEnd = eDate.ToString("yyyy-MM-dd");
                    }
                    else { formattedEnd = "0"; }
                }

                cmd.Parameters.AddWithValue("@orderType", orderType ?? "0");
                cmd.Parameters.AddWithValue("@StartDate", formattedStart);
                cmd.Parameters.AddWithValue("@EndDate", formattedEnd);
                cmd.Parameters.AddWithValue("@PayMode", payMode ?? "0");

                if (conn.State == ConnectionState.Closed) conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    SalesOrder item = new SalesOrder();
                    item.OrderID = Convert.ToInt32(reader["OrderID"]);
                    item.OrderNo = reader["OrderNo"].ToString();
                    item.OrderDate = reader["OrderDate"].ToString();
                    item.OrderTime = reader["OrderTime"].ToString();
                    item.OrderTypeName = reader["OrderTypeName"].ToString();
                    item.DeliveredBy = reader["Rider"].ToString();
                    item.CustomerName = reader["Guest"].ToString();
                    item.TableStatus = reader["TableStatus"].ToString();
                    item.RoomNo = reader["RoomNo"].ToString();

                    item.Charge = reader["ServiceCharge"] == DBNull.Value ? 0 : Convert.ToDouble(reader["ServiceCharge"]);
                    item.SubTotal = reader["SubTotal"] == DBNull.Value ? 0 : Convert.ToDouble(reader["SubTotal"]);
                    item.TotalOrderAmount = reader["TotalAmount"] == DBNull.Value ? 0 : Convert.ToDouble(reader["TotalAmount"]);
                    item.DiscPercent = reader["DiscPercent"] == DBNull.Value ? 0 : Convert.ToDouble(reader["DiscPercent"]);
                    item.TotalDiscount = reader["DiscAmount"] == DBNull.Value ? 0 : Convert.ToDouble(reader["DiscAmount"]);
                    item.AfterDisc = reader["AfterDisc"] == DBNull.Value ? 0 : Convert.ToDouble(reader["AfterDisc"]);
                    item.SGST = reader["SGST"] == DBNull.Value ? 0 : Convert.ToDouble(reader["SGST"]);
                    item.CGST = reader["CGST"] == DBNull.Value ? 0 : Convert.ToDouble(reader["CGST"]);
                    item.GSTCost = reader["TotalGST"] == DBNull.Value ? 0 : Convert.ToDouble(reader["TotalGST"]);
                    item.RoundOff = reader["RoundOff"] == DBNull.Value ? 0 : Convert.ToDouble(reader["RoundOff"]);

                    // 🔥 FIXED HERE: reader["NetTotal"] ko badal kar reader["TotalPaid"] kiya
                    item.TotalPaid = reader["TotalPaid"] == DBNull.Value ? 0 : Convert.ToDouble(reader["TotalPaid"]);
                    item.PayMode = reader["PayMode"].ToString();

                    list.Add(item);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error parsing: " + startDate + " or " + endDate + ". Msg: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
            }
            return list;
        }
        [HttpGet]
        public List<SalesOrder> SalesOrderDetailReport(string orderType, string startDate, string endDate)
        {
            string cnvrtstartdate = "0", convrtenddate = "0";
            if (!string.IsNullOrEmpty(startDate) && !string.IsNullOrEmpty(endDate))
            {
                cnvrtstartdate = dateToText(startDate);
                convrtenddate = dateToText(endDate);
            }

            List<SalesOrder> reportList = new List<SalesOrder>();
            connection objCon = new connection();
            SqlConnection conn = objCon.makeConnection();

            try
            {
                SqlCommand cmd = new SqlCommand("[USP_GetSalesOrderDetails_Report]", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@orderType", string.IsNullOrEmpty(orderType) ? "0" : orderType);
                cmd.Parameters.AddWithValue("@StartDate", cnvrtstartdate);
                cmd.Parameters.AddWithValue("@EndDate", convrtenddate);

                if (conn.State == ConnectionState.Closed) conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        SalesOrder item = new SalesOrder();

                        // --- DETAIL COLUMNS (Null-Safe Mapping) ---
                        item.SalesOrderDetailID = reader["SalesOrderDetailID"] != DBNull.Value ? Convert.ToInt32(reader["SalesOrderDetailID"]) : 0;
                        item.OrderID = reader["Orderid"] != DBNull.Value ? Convert.ToInt32(reader["Orderid"]) : 0;
                        item.ProductName = reader["ProductName"] != DBNull.Value ? reader["ProductName"].ToString() : "";
                        item.ItemMasterID = reader["ItemMasterID"] != DBNull.Value ? Convert.ToInt32(reader["ItemMasterID"]) : 0;
                        item.ProductQty = reader["ProductQty"] != DBNull.Value ? Convert.ToInt32(reader["ProductQty"]) : 0;
                        item.ActualCost = reader["ActualCost"] != DBNull.Value ? Convert.ToDouble(reader["ActualCost"]) : 0.0;
                        item.GSTPercentage = reader["GSTPercentage"] != DBNull.Value ? Convert.ToDouble(reader["GSTPercentage"]) : 0.0;
                        item.CGST = reader["CGST"] != DBNull.Value ? Convert.ToDouble(reader["CGST"]) : 0.0;
                        item.SGST = reader["SGST"] != DBNull.Value ? Convert.ToDouble(reader["SGST"]) : 0.0;
                        item.GSTCost = reader["TotalTax"] != DBNull.Value ? Convert.ToDouble(reader["TotalTax"]) : 0.0;
                        item.TotalOrderAmount = reader["TotalOrderAmount"] != DBNull.Value ? Convert.ToDouble(reader["TotalOrderAmount"]) : 0.0;
                        item.RoomNo = reader["RoomNo"] != DBNull.Value ? reader["RoomNo"].ToString() : "";

                        // --- MASTER INFO & OTHERS ---
                        item.OrderNo = reader["OrderNo"] != DBNull.Value ? reader["OrderNo"].ToString() : "";
                        item.OrderTypeName = reader["OrderType"] != DBNull.Value ? reader["OrderType"].ToString() : "";
                        item.ordertypeval = reader["ordertypeval"] != DBNull.Value ? Convert.ToInt32(reader["ordertypeval"]) : 0;
                        item.CustomerName = reader["CustomerName"] != DBNull.Value ? reader["CustomerName"].ToString() : "Guest";
                        item.DeliveredBy = reader["DeliveredBy"] != DBNull.Value ? reader["DeliveredBy"].ToString() : "-";
                        item.TableStatus = reader["TableStatus"] != DBNull.Value ? reader["TableStatus"].ToString() : "";
                        item.TotalDiscount = reader["TotalDiscount"] != DBNull.Value ? Convert.ToDouble(reader["TotalDiscount"]) : 0.0;
                        item.Charge = reader["Charge"] != DBNull.Value ? Convert.ToDouble(reader["Charge"]) : 0.0;
                        item.TotalPaid = reader["TotalPaid"] != DBNull.Value ? Convert.ToDouble(reader["TotalPaid"]) : 0.0;
                        item.PaymentStatus = reader["PaymentStatus"] != DBNull.Value ? reader["PaymentStatus"].ToString() : "";
                        item.PayMode = reader["PayMode"] != DBNull.Value ? reader["PayMode"].ToString() : "Cash";
                        item.OrderDate = reader["orderdate"] != DBNull.Value ? reader["orderdate"].ToString() : "";
                        item.OrderTime = reader["ordertime"] != DBNull.Value ? reader["ordertime"].ToString() : "";
                        item.TableID = reader["TableID"] != DBNull.Value ? Convert.ToInt32(reader["TableID"]) : 0;

                        reportList.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                // Yahan Error Log kar sakte hain
                throw ex;
            }
            finally
            {
                objCon.closeConnection();
            }
            return reportList;
        }
        public class DeleteOrderModel
        {
            public int OrderId { get; set; }
            public int ItemMasterID { get; set; }
        }


        [HttpPost]
        [Route("api/Item/DeleteSalesOrder")]
        public IHttpActionResult DeleteSalesOrder(DeleteOrderModel model)
        {
            // 1. Validation check
            if (model == null || model.OrderId <= 0 || model.ItemMasterID <= 0)
            {
                return Ok(new { success = false, message = "Invalid Order ID or Item ID." });
            }

            try
            {
                connection objCon = new connection();

                using (SqlConnection conn = objCon.makeConnection())
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();

                    using (SqlCommand cmd = new SqlCommand("USP_DeleteSalesOrder_Soft", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@OrderID", SqlDbType.Int).Value = model.OrderId;
                        cmd.Parameters.Add("@ItemMasterID", SqlDbType.Int).Value = model.ItemMasterID;

                        int rowsAffected = cmd.ExecuteNonQuery();

                        
                        if (rowsAffected > 0 || rowsAffected == -1)
                        {
                            return Ok(new
                            {
                                success = true,
                                message = "Order item voided successfully."
                            });
                        }
                        else
                        {
                            
                            return Ok(new
                            {
                                success = false,
                                message = "No record found to update. Please check IDs."
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
               
                return Ok(new
                {
                    success = false,
                    message = "Database Error: " + ex.Message
                });
            }
        }
        // end ravi code 


        public List<DineInDetails> GetTableNameAndOrderStatus(long id,int ordertype)
        {
            List<DineInDetails> pendingSalesOrderlist = new List<DineInDetails>();
            DineInDetails pendingorderlist = new DineInDetails();
            SqlConnection conn;
            connection objCon = new connection();
            conn = objCon.makeConnection();
            try
            {
                SqlCommand sql_cmnd = new SqlCommand("USP_GetTableNameAndOrderStatus", conn);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@AreaID", id);
                sql_cmnd.Parameters.AddWithValue("@OrderTypeID", ordertype);
                sql_cmnd.ExecuteNonQuery();
                SqlDataReader reader = sql_cmnd.ExecuteReader();
                while (reader.Read())
                {
                    pendingorderlist = new DineInDetails();
                    pendingorderlist.DineInTablemasterID = int.Parse(reader["DineInTablemasterID"].ToString());
                    pendingorderlist.OrderID = int.Parse(reader["OrderID"].ToString());
                    pendingorderlist.TableStatus = reader["TableStatus"].ToString();
                    pendingorderlist.TableName = reader["TableName"].ToString();
                   
                    pendingSalesOrderlist.Add(pendingorderlist);
                }
                objCon.closeConnection();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return pendingSalesOrderlist;
        }

        public string dateToText(string tDate)
        {
            string day, month, year, dateReturn;
            string dt = tDate;
            if (dt != "")
            {
                day = dt.Substring(0, 2);
                month = dt.Substring(3, 2);
                year = dt.Substring(6, 4);
                dateReturn = year + month + day;
            }
            else
                dateReturn = tDate;

            return dateReturn;
        }

        public int CancelOrder(long id)
        {
            int noOfRowsAffeted = 0;
            string successmsg = string.Empty;
            try
            {
                SqlConnection conn;
                connection objCon = new connection();
                using (conn = objCon.makeConnection())
                {
                    using (SqlCommand sql_cmnd = new SqlCommand("USP_CancelOrder", conn))
                    {
                        sql_cmnd.CommandType = CommandType.StoredProcedure;
                        sql_cmnd.Parameters.AddWithValue("@OrderID", id);
                        noOfRowsAffeted = Convert.ToInt32(sql_cmnd.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
            return noOfRowsAffeted;
        }

        [HttpGet]
        public List<SalesOrder> CancelledPendingOrder(string orderType, string startDate, string endDate)
        {
            string cnvrtstartdate = string.Empty, convrtenddate = string.Empty;
            if (!string.IsNullOrEmpty(startDate) && !string.IsNullOrEmpty(endDate))
            {
                cnvrtstartdate = dateToText(startDate);
                convrtenddate = dateToText(endDate);
            }
            List<SalesOrder> pendingSalesOrderlist = new List<SalesOrder>();
            SalesOrder pendingorderlist = new SalesOrder();
            SqlConnection conn;
            connection objCon = new connection();
            conn = objCon.makeConnection();
            try
            {
                SqlCommand sql_cmnd = new SqlCommand("USP_CancelledPendingOrderStatus", conn);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@orderType", orderType);
                sql_cmnd.Parameters.AddWithValue("@StartDate", cnvrtstartdate);
                sql_cmnd.Parameters.AddWithValue("@EndDate", convrtenddate);
                sql_cmnd.ExecuteNonQuery();
                SqlDataReader reader = sql_cmnd.ExecuteReader();
                while (reader.Read())
                {
                    pendingorderlist = new SalesOrder();
                    pendingorderlist.OrderID = int.Parse(reader["OrderID"].ToString());
                    pendingorderlist.OrderType = int.Parse(reader["ordertypeval"].ToString());
                    pendingorderlist.DeliveredBy = reader["DeliveredBy"].ToString();
                    pendingorderlist.CustomerName = reader["CustomerName"].ToString();
                    pendingorderlist.TableStatus = reader["TableStatus"].ToString();
                    pendingorderlist.TotalOrderAmount = double.Parse(reader["TotalOrderAmount"].ToString());
                    pendingorderlist.Charge = double.Parse(reader["Charge"].ToString());
                    pendingorderlist.TotalPaid = double.Parse(reader["TotalPaid"].ToString());
                    pendingorderlist.PaymentStatus = reader["PaymentStatus"].ToString();
                    pendingorderlist.PayMode = reader["PayMode"].ToString();
                    pendingorderlist.OrderTypeName = reader["OrderType"].ToString();
                    pendingorderlist.OrderDate = reader["orderdate"].ToString();
                    pendingorderlist.OrderTime = reader["ordertime"].ToString();
                    pendingorderlist.OrderNo = reader["OrderNo"].ToString();
                    pendingorderlist.RoomNumber = reader["RoomNumber"].ToString();
                    pendingorderlist.TableID = int.Parse(reader["TableID"].ToString());
                    pendingSalesOrderlist.Add(pendingorderlist);
                }
                objCon.closeConnection();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return pendingSalesOrderlist;
        }
        [HttpGet]
        public List<SalesOrder> CompletedInActiveOrders(string orderType, string startDate, string endDate, string payMode)
        {
            string cnvrtstartdate = string.Empty, convrtenddate = string.Empty;
            if (!string.IsNullOrEmpty(startDate) && !string.IsNullOrEmpty(endDate))
            {
                cnvrtstartdate = dateToText(startDate);
                convrtenddate = dateToText(endDate);

            }


            List<SalesOrder> pendingSalesOrderlist = new List<SalesOrder>();
            SalesOrder pendingorderlist = new SalesOrder();
            SqlConnection conn;
            connection objCon = new connection();
            conn = objCon.makeConnection();
            try
            {
                SqlCommand sql_cmnd = new SqlCommand("USP_CompletedInactiveOrder", conn);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@orderType", orderType);
                sql_cmnd.Parameters.AddWithValue("@StartDate", cnvrtstartdate);
                sql_cmnd.Parameters.AddWithValue("@EndDate", convrtenddate);
                sql_cmnd.Parameters.AddWithValue("@PayMode", payMode);
                sql_cmnd.ExecuteNonQuery();
                SqlDataReader reader = sql_cmnd.ExecuteReader();
                while (reader.Read())
                {
                    pendingorderlist = new SalesOrder();
                    pendingorderlist.OrderID = int.Parse(reader["OrderID"].ToString());
                    pendingorderlist.OrderType = int.Parse(reader["ordertypeval"].ToString());
                    pendingorderlist.DeliveredBy = reader["DeliveredBy"].ToString();
                    pendingorderlist.CustomerName = reader["CustomerName"].ToString();
                    pendingorderlist.TableStatus = reader["TableStatus"].ToString();
                    pendingorderlist.TotalOrderAmount = double.Parse(reader["TotalOrderAmount"].ToString());
                    pendingorderlist.Charge = double.Parse(reader["Charge"].ToString());
                    pendingorderlist.TotalPaid = double.Parse(reader["TotalPaid"].ToString());
                    pendingorderlist.PaymentStatus = reader["PaymentStatus"].ToString();
                    pendingorderlist.PayMode = reader["PayMode"].ToString();
                    pendingorderlist.OrderTypeName = reader["OrderType"].ToString();
                    pendingorderlist.OrderDate = reader["orderdate"].ToString();
                    pendingorderlist.OrderTime = reader["ordertime"].ToString();
                    pendingorderlist.OrderNo = reader["OrderNo"].ToString();
                    pendingSalesOrderlist.Add(pendingorderlist);
                }
                objCon.closeConnection();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return pendingSalesOrderlist;
        }

        public List<SalesOrder> GetRecentOrders()
        {
            List<SalesOrder> pendingSalesOrderlist = new List<SalesOrder>();
            SalesOrder pendingorderlist = new SalesOrder();
            SqlConnection conn;
            connection objCon = new connection();
            conn = objCon.makeConnection();
            try
            {
                SqlCommand sql_cmnd = new SqlCommand("USP_RecentOrders", conn);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.ExecuteNonQuery();
                SqlDataReader reader = sql_cmnd.ExecuteReader();
                while (reader.Read())
                {
                    pendingorderlist = new SalesOrder();
                    pendingorderlist.OrderID = int.Parse(reader["OrderID"].ToString());
                    pendingorderlist.OrderType = int.Parse(reader["ordertypeval"].ToString());
                    pendingorderlist.DeliveredBy = reader["DeliveredBy"].ToString();
                    pendingorderlist.CustomerName = reader["CustomerName"].ToString();
                    pendingorderlist.TableStatus = reader["TableStatus"].ToString();
                    pendingorderlist.TotalOrderAmount = double.Parse(reader["TotalOrderAmount"].ToString());
                    pendingorderlist.Charge = double.Parse(reader["Charge"].ToString());
                    pendingorderlist.TotalPaid = double.Parse(reader["TotalPaid"].ToString());
                    pendingorderlist.PaymentStatus = reader["PaymentStatus"].ToString();
                    pendingorderlist.PayMode = reader["PayMode"].ToString();
                    pendingorderlist.OrderTypeName = reader["OrderType"].ToString();
                    pendingorderlist.OrderDate = reader["orderdate"].ToString();
                    pendingorderlist.OrderTime = reader["ordertime"].ToString();
                    pendingorderlist.OrderNo = reader["OrderNo"].ToString();
                    pendingorderlist.TableID = int.Parse(reader["TableID"].ToString());
                    pendingorderlist.TableName = reader["TableName"].ToString();
                    pendingorderlist.RoomNo = reader["RoomNo"].ToString();
                    pendingorderlist.NCRadio = reader["NCRadio"].ToString();
                    pendingSalesOrderlist.Add(pendingorderlist);
                }
                objCon.closeConnection();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return pendingSalesOrderlist;
        }

        [HttpGet]
        public int IsAlreadyPLacedOrder(long id,string orderType)
        {
            int count = 0;
            try
            {
                SqlConnection conn;
                connection objCon = new connection();
                using (conn = objCon.makeConnection())
                {
                    using (SqlCommand sql_cmnd = new SqlCommand("USP_IsAlreadyPLacedOrder", conn))
                    {
                        sql_cmnd.CommandType = CommandType.StoredProcedure;
                        sql_cmnd.Parameters.AddWithValue("@orderID", id);
                        sql_cmnd.Parameters.AddWithValue("@orderType", orderType);
                        count = Convert.ToInt32(sql_cmnd.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
            return count;
        }

        [HttpGet]
        public List<SalesOrder> ClosingSalesOrder(string orderType, string startDate, string endDate, string payMode)
        {
            DateTime dtstartdate = new DateTime();
            DateTime dtenddate = new DateTime();
           
            string convertenddt = string.Empty;
            if (!string.IsNullOrEmpty(startDate) && !string.IsNullOrEmpty(endDate))
            {
                dtstartdate = DateTime.ParseExact(startDate,
                                  "yyyy-MM-dd HH:mm:ss",
                                  CultureInfo.InvariantCulture);
                dtenddate = DateTime.ParseExact(endDate,
                                  "yyyy-MM-dd HH:mm:ss",
                                  CultureInfo.InvariantCulture);
            }
            List<SalesOrder> pendingSalesOrderlist = new List<SalesOrder>();
            SalesOrder pendingorderlist = new SalesOrder();
            SqlConnection conn;
            connection objCon = new connection();
            conn = objCon.makeConnection();
            try
            {
                SqlCommand sql_cmnd = new SqlCommand("ClosingSalesReport", conn);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@orderType", orderType);
                sql_cmnd.Parameters.AddWithValue("@FromDate", dtstartdate);
                sql_cmnd.Parameters.AddWithValue("@ToDate", dtenddate);
                sql_cmnd.Parameters.AddWithValue("@PayMode", payMode);
                sql_cmnd.ExecuteNonQuery();
                SqlDataReader reader = sql_cmnd.ExecuteReader();
                while (reader.Read())
                {
                    //select som.createdDate, sod.orderid, paymode,paymentstatus,productQty,sod.SGST,Sod.CGST, GrandTotal as GrossAmount,DiscountValue as discount,SubTotal as netAmount from salesordermaster(nolock)som
                    pendingorderlist = new SalesOrder();
                    //pendingorderlist.OrderID = int.Parse(reader["orderid"].ToString());
                    pendingorderlist.OrderTypeName = reader["ordertypename"].ToString();
                    pendingorderlist.ProductName = reader["ProductName"].ToString();
                    pendingorderlist.SGST = double.Parse(reader["SGST"].ToString());
                    pendingorderlist.CGST = double.Parse(reader["CGST"].ToString());
                    pendingorderlist.GrandTotal = double.Parse(reader["GrossAmount"].ToString());
                    pendingorderlist.ProductQty = Int32.Parse(reader["productQty"].ToString());
                    //pendingorderlist.TotalDiscount = double.Parse(reader["discount"].ToString());
                    //pendingorderlist.SubTotal = double.Parse(reader["netAmount"].ToString());
                    //pendingorderlist.PaymentStatus = reader["paymentstatus"].ToString();
                    pendingorderlist.PayMode = reader["paymode"].ToString();
                    //pendingorderlist.createdDate = reader["createdDate"].ToString();
                    //pendingorderlist.OrderTypeName = reader["OrderType"].ToString();
                    pendingorderlist.OrderDateTime = reader["OrdDateTime"].ToString();
                    //pendingorderlist.OrderTime = reader["ordertime"].ToString();
                    pendingorderlist.ActualCost = double.Parse(reader["ActualCost"].ToString());
                    pendingSalesOrderlist.Add(pendingorderlist);
                }
                objCon.closeConnection();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return pendingSalesOrderlist;
        }
        [HttpGet]
        public List<SalesOrder> ItemWiseClosingSalesOrder(string startDate, string endDate)
        {
            DateTime dtstartdate = new DateTime();
            DateTime dtenddate = new DateTime();

            string convertenddt = string.Empty;
            if (!string.IsNullOrEmpty(startDate) && !string.IsNullOrEmpty(endDate))
            {
                dtstartdate = DateTime.ParseExact(startDate,
                                  "yyyy-MM-dd HH:mm:ss",
                                  CultureInfo.InvariantCulture);
                dtenddate = DateTime.ParseExact(endDate,
                                  "yyyy-MM-dd HH:mm:ss",
                                  CultureInfo.InvariantCulture);
            }


            List<SalesOrder> pendingSalesOrderlist = new List<SalesOrder>();
            SalesOrder pendingorderlist = new SalesOrder();
            SqlConnection conn;
            connection objCon = new connection();
            conn = objCon.makeConnection();
            try
            {
                SqlCommand sql_cmnd = new SqlCommand("ItemWiseClosingSalesReport", conn);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@FromDate", dtstartdate);
                sql_cmnd.Parameters.AddWithValue("@ToDate", dtenddate);
                sql_cmnd.ExecuteNonQuery();
                SqlDataReader reader = sql_cmnd.ExecuteReader();
                while (reader.Read())
                {
                    //select som.createdDate, sod.orderid, paymode,paymentstatus,productQty,sod.SGST,Sod.CGST, GrandTotal as GrossAmount,DiscountValue as discount,SubTotal as netAmount from salesordermaster(nolock)som
                    pendingorderlist = new SalesOrder();
                    //pendingorderlist.OrderID = int.Parse(reader["orderid"].ToString());
                   
                    pendingorderlist.ProductName = reader["ProductName"].ToString();
                    pendingorderlist.SGST = double.Parse(reader["SGST"].ToString());
                    pendingorderlist.CGST = double.Parse(reader["CGST"].ToString());
                    pendingorderlist.GrandTotal = double.Parse(reader["GrossAmount"].ToString());
                    pendingorderlist.ProductQty = Int32.Parse(reader["productQty"].ToString());
                    //pendingorderlist.TotalDiscount = double.Parse(reader["discount"].ToString());
                    //pendingorderlist.SubTotal = double.Parse(reader["netAmount"].ToString());
                    //pendingorderlist.PaymentStatus = reader["paymentstatus"].ToString();
                   
                    //pendingorderlist.createdDate = reader["createdDate"].ToString();
                    //pendingorderlist.OrderTypeName = reader["OrderType"].ToString();
                    //pendingorderlist.OrderDate = reader["orderdate"].ToString();
                    //pendingorderlist.OrderTime = reader["ordertime"].ToString();
                    //pendingorderlist.ActualCost = double.Parse(reader["ActualCost"].ToString());
                    pendingSalesOrderlist.Add(pendingorderlist);
                }
                objCon.closeConnection();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return pendingSalesOrderlist;
        }

        private DataTable GetCompanyDetails()
        {
           DataTable dt = new DataTable();
           SqlConnection conn;
           connection objCon = new connection();
            try
            {
               
                using (conn = objCon.makeConnection())
                {
                    using (SqlCommand sql_cmnd = new SqlCommand("USP_CompanyDetails", conn))
                    {
                        sql_cmnd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader datareader = sql_cmnd.ExecuteReader();
                        dt.Load(datareader);
                    }
                }
                 objCon.closeConnection();
            }
            catch (Exception ex)
            {
            }
            return dt;
        }
    }
}
