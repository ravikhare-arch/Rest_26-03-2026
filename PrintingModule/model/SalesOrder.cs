using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrintModule.Models
{
    public class SalesOrder
    {
        //salesOrder.ItemMasterID = ItemMasterID;
        //            salesOrder.ProductName = productName;
        //            salesOrder.ActualCost = productUnitPrice;
        //            salesOrder.ProductQty = productQty;
        public int ItemMasterID { get; set; }
        public int OrderType { get; set; }
        public int OrderID { get; set; }
        public string ProductName { get; set; }
      
        public double ActualCost { get; set; }
        public int ProductQty { get; set; }
        public int OrderedUnit { get; set; }
        public double CGST { get; set; }
        public double SGST { get; set; }
        public double IGST { get; set; }
        public double GSTCost { get; set; }
        public double GSTPercent { get; set; }
        public int SalesOrderDetailID { get;  set; }
        public double TotalAmount { get;  set; }
        public double ServiceChargeValue { get; set; }
        public double GrandTotal { get; set; }

        public string CustomerName { get; set; }
        public string CustomerGST { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerNumber { get; set; }
        public string CustomerAddress { get; set; }
        public string PayMode { get; set; }
        public double SubTotal { get; set; }
        public double TotalDiscount { get; set; }
        public double TotalCharges { get; set; }
        public string DeliveredBy { get; set; }
        public string TableStatus { get; set; }
        public double TotalOrderAmount { get; set; }
        public double Charge { get; set; }
        public double TotalPaid { get; set; }
        public string PaymentStatus { get; set; }
        public double GivenAmount { get; set; }
        public double ReturnAmount { get; set; }
        public double DiscountValue { get; set; }

        public int TableID { get; set; }
        public string OrderTypeName { get; set; }
        public bool IsApplyGST { get; set; }

        public double GSTGrandTotal{ get; set; }
        public string OrderDate { get; set; }
        public string OrderTime { get; set; }
        public string OrderNo { get; set; }
        public string TableName { get; set; }
        public string sUserFullName { get; set; }
        public string ItemRemarks { get; set; }
        // ravi 
        public string RoomNo { get; set; }
        public int RTID { get; set; }
        public int GCID { get; set; }
        public string  NCName { get; set; }
        public DateTime CreatedDate { get; set; }
        public CompanyDetails companydetails { get; set; }
    }
}