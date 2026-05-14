using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantApi.Models
{
    public class OrderDetailbyOrderID
    {
        public int SalesOrderDetailID { get; set; }
        public int ItemMasterID { get; set; }
        public string ProductName { get; set; }
        public double ProductQty { get; set; }
        public double ActualCost { get; set; }
        public double TotalAmount { get; set; }
        public int OrderID { get; internal set; }
    }
}