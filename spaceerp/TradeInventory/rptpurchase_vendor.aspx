<%@ Page Title="" Language="C#" MasterPageFile="~/PrintMaster.master" AutoEventWireup="true" CodeFile="rptpurchase_vendor.aspx.cs" Inherits="Trading_rptpurchase" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <link rel="stylesheet" href="http://netdna.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <style>
  
.invoice {
    position: relative;
    background-color: #FFF;
    min-height: 680px;
}

.invoice header {
    padding: 10px 0;
    margin-bottom: 20px;
    border-bottom: 1px solid #3989c6
}

.invoice .company-details {
    text-align: right
}

.invoice .company-details .name {
    margin-top: 0;
    margin-bottom: 0
}

.invoice .contacts {
    margin-bottom: 20px
}

.invoice .invoice-to {
    text-align: left
}

.invoice .invoice-to .to {
    margin-top: 0;
    margin-bottom: 0
}

.invoice .invoice-details {
    text-align: right
}

.invoice .invoice-details .invoice-id {
    margin-top: 0;
    color: #3989c6
}

.invoice main {
    padding-bottom: 50px
}

.invoice main .thanks {
    margin-top: -100px;
    font-size: 2em;
    margin-bottom: 50px
}

.invoice main .notices {
    padding-left: 6px;
    border-left: 6px solid #3989c6
}

.invoice main .notices .notice {
    font-size: 1.2em
}

.invoice table {
    width: 100%;
    border-collapse: collapse;
    border-spacing: 0;
    margin-bottom: 20px
}

.invoice table td,.invoice table th {
    padding: 15px;
    background: #eee;
    border-bottom: 1px solid #fff
}

.invoice table th {
    white-space: nowrap;
    font-weight: 400;
    color: #3989c6;
    font-size: 1.4em;
    border-top: 1px solid #3989c6;
}

.invoice table td h3 {
    margin: 0;
    font-weight: 400;
    color: #3989c6;
    font-size: 1.2em
}

.invoice table .qty,.invoice table .total,.invoice table .unit {
    text-align: right;
    font-size: 1.2em
}

.invoice table .no {
    color: #fff;
    font-size: 1.6em;
    background: #3989c6
}

.invoice table .unit {
    background: #ddd
}

.invoice table .total {
    background: #3989c6;
    color: #fff
}

.invoice table tbody tr:last-child td {
    border: none
}

.invoice table tfoot td {
    background: 0 0;
    border-bottom: none;
    white-space: nowrap;
    text-align: right;
    padding: 10px 20px;
    font-size: 1.2em;
    border-top: 1px solid #aaa
}

.invoice table tfoot tr:first-child td {
    border-top: none
}

.invoice table tfoot tr:last-child td {
    color: #3989c6;
    font-size: 1.4em;
    border-top: 1px solid #3989c6
}

.invoice table tfoot tr td:first-child {
    border: none
}

.invoice footer {
    width: 100%;
    text-align: center;
    color: #777;
    border-top: 1px solid #aaa;
    padding: 8px 0
}
.invoice-id {
    margin-top: 0px !important;
}
        .btn-sm {
            padding: 5px 15px;
            font-size: 14px;
        }
@media print {
    .invoice {
        font-size: 11px!important;
        overflow: hidden!important
    }

    .invoice footer {
        position: absolute;
        bottom: 10px;
        page-break-after: always
    }

    .invoice>div:last-child {
        page-break-before: always
    }
}
    </style>    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
      <!-- begin breadcrumb -->
    <div id="invoicebg">        
        <div class="invoice overflow-auto">
            <div>
                <header>
                    <div class="row">
                        <div class="col">
                            <h1 class="invoice-id">
                                <a target="_blank" href="javascript:;">
                                    Purchase Report Vendor Wise
                                </a>
                            </h1>
                        </div>
                        <div class="col company-details">
                           <div class="text-right" id="hidePrint" runat="server">
                <a href="tpurchase_report.aspx" class="btn btn-sm btn btn-info m-b-10 p-l-5" id="btnhome"><i class="fa fa-home t-plus-1 text-white fa-fw fa-lg"></i>Home</a>
                        <a href="javascript:;" onclick="window.print()" class="btn btn-sm btn-white m-b-10 p-l-5"><i class="fa fa-print t-plus-1 fa-fw fa-lg"></i>Print</a>
                      
            </div>
                        </div>
                    </div>
                </header>
                <main>
                     
    <!-- begin invoice -->
    <div class="invoice">
        <!-- end invoice-header -->
        <table id="treetable" class="table table-hover table-bordered text-black">
            <tbody>
                <tr class="bg-danger font-weight-bold text-white">
                    <th class="no">Date</th>
                    <th class="no">Invoice No</th>
                    <th class="no">Vendor Name</th>
                    <th class="no">Quantity</th>
                    <th class="no">Unit Price</th>
                    <th class="no">Grand Total</th>
                </tr>
                <asp:Repeater ID="rptPoVendor" OnItemDataBound="treetable_ItemDataBound" runat="server">
                    <ItemTemplate>
                        <tr class="bg-grey-lighter text-black font-weight-bold">
                            <td>Vendor Name:</td>
                            <td data-column="name" class="p-l-10" >

                                <asp:HiddenField ID="hdnVendorID" runat="server" Value='<%#Eval("nVendorID") %>' />
                                 <%#Eval("[sAccountTitle]") %></td>
                            <td>Balance Quantity: </td>
                            <td><%#Eval("[Credit Quantity]") %></td>
                            <td>Grand Total:</td>
                            <td> <%#Eval("nGtotal") %></td>
                        </tr>
                        <asp:Repeater ID="rptPoVendorDet" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td data-column="name"><%#Eval("dtPoInvoice") %></td>
                                    <td data-column="name"><%#Eval("sPoInvoiceNo") %></td>

                                    <td><%#Eval("sitemName") %></td>
                                    <td><%#Eval("nQuantity") %></td>
                                    <td><%#Eval("nUnitPrice") %></td>
                                    <td><%#Eval("GTotal") %> </td>
                                </tr>

                                <%--<asp:Repeater ID="treeAcc" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td data-column="name" class="p-l-20">

                                        <%#Eval("[Account Title]") %></td>
                                    <td><%#Eval("[DebitAmount]") %></td>
                                    <td><%#Eval("[CreditAmount]") %></td>
                                    <td><%#Eval("BalAmount") %></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>--%>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ItemTemplate>
                </asp:Repeater>
                <tr class="bg-grey-lighter font-weight-bold">
                    <td colspan="4" class="no"></td>
                    <td data-column="name" class="no">Total</td>
                    
                    <td class="no">
                        <asp:Label ID="lbltotalSaleValue" runat="server"> </asp:Label></td>
                </tr>
            </tbody>
        </table>
        <asp:Label ID="lblrecord" runat="server" Visible="false" ForeColor="Red"> </asp:Label>
        </div>
                    </main>
                </div>
            </div>
        </div>
        <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
        <script src="http://code.jquery.com/jquery-1.12.4.min.js"></script>
        <%--  <script src="http://netdna.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>--%>
        <%--<script src="../assets/js/tabletree.js"></script>--%>
</asp:Content>

