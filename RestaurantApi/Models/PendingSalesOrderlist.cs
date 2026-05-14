using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantApi.Models
{
    public class PendingSalesOrderlist
    {
        public int OrderID { get; set; }
        public string OrderType { get; set; }
        public string DeliveredBy { get; set; }
        public string CustomerName { get; set; }
        public string TableStatus { get; set; }
        public double TotalOrderAmount { get; set; }
        public double Charge { get; set; }
        public double TotalPaid { get; set; }
        public string PaymentStatus { get; set; }
        public string PayMode { get; set; }
    }
}