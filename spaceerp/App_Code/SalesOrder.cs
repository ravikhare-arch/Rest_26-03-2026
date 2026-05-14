using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SalesOrder
/// </summary>
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
    public int SalesOrderDetailID { get; internal set; }
    public double TotalAmount { get; internal set; }

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

    public double GSTGrandTotal { get; set; }
    public string OrderDate { get; set; }
    public string OrderTime { get; set; }
    public string OrderNo { get; set; }
    public string TableName { get; set; }
    public string ItemRemarks { get; set; }
    public string OrderDateTime { get; set; }
    public string RoomNo { get; set; }
    public string NCName { get; set; }
    public string nLoginID { get; set; }
    public string sLogin { get; set; }
    public string sUserFullName { get; set; }
    public decimal DiscPercent { get; set; }
    public decimal AfterDisc { get; set; }
    public decimal RoundOff { get; set; }
}