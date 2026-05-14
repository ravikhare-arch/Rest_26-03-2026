<%@ Page Title="" Language="C#" MasterPageFile="~/PrintMaster.master" AutoEventWireup="true" CodeFile="rptsalesitem.aspx.cs" Inherits="Trading_rptsales_item" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <link rel="stylesheet" href="http://netdna.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ol class="breadcrumb hidden-print pull-right">
        <li class="breadcrumb-item"><a href="tSales_report.aspx">Home</a></li>
        <li class="breadcrumb-item active">Sales Reports Item Wise</li>
    </ol>
    <!-- end breadcrumb -->
    <!-- begin page-header -->
    <h1 class="page-header hidden-print">Sales Report </h1>
    <!-- end page-header -->

    <!-- begin invoice -->
    <div class="invoice">
        <!-- begin invoice-company -->
        <div class="invoice-company text-inverse f-w-600">
            <span class="pull-right hidden-print">
                <%-- <a href="javascript:;" class="btn btn-sm btn-white m-b-10 p-l-5"><i class="fa fa-file-pdf t-plus-1 text-danger fa-fw fa-lg"></i>Export as PDF</a>--%>
                <a href="javascript:;" onclick="window.print()" class="btn btn-sm btn-white m-b-10 p-l-5"><i class="fa fa-print t-plus-1 fa-fw fa-lg"></i>Print</a>
            </span>
            <span class="text-center">
                <h4>Sales Report Detail Item Wise
                </h4>
            </span>

        </div>
        <!-- end invoice-company -->
        <!-- begin invoice-header -->

        <!-- end invoice-header -->
        <table id="treetable" class="table table-hover table-bordered text-black">
            <tbody>
                <tr class="bg-danger font-weight-bold text-white">
                    <th>Date</th>
                    <th>Invoice No</th>
                    <th>Customer Name</th>
                    <th>Item Name</th>
                    <th>Quantity</th>
                    <th>Unit Price</th>
                    <th>Sales Amount</th>
                    <th>Purchase Amount</th>
                    <th>Profit Amount</th>
                    <th>Profit (%)</th>
                </tr>
                <asp:Repeater ID="rptsales" runat="server">
                    <ItemTemplate>
                        <tr class="text-black">
                            <td data-column="name" class="p-l-10">

                                <asp:HiddenField ID="hdnItemID" runat="server" Value='<%#Eval("nItemID") %>' />
                                <%# validation.TextToDate(Eval("dtSoInvoice").ToString()) %>

                            </td>
                            <td data-column="name"><%#Eval("sSoInvoiceNo") %></td>
                            <td><%#Eval("sAccountTitle") %></td>
                            <td><%#Eval("sitemName") %></td>
                            <td><%#Eval("nQuantity") %></td>
                            <td><%#Eval("nUnitPrice") %></td>
                            <td><%#Eval("nTotPrice") %> </td>
                            <td><%#Eval("nPurchaseCost") %> </td>
                            <td><%#Eval("nProfit") %> </td>
                            <td><%#Eval("nProfitPercent") %> </td>
                        </tr>

                    </ItemTemplate>
                </asp:Repeater>

            </tbody>
        </table>

        <!-- begin invoice-price -->

        <div class="row">
            <div class="col-6">
            </div>
            <div class="col-6">
                <table class="table table-hover m-t-20 text-inverse">
                    <thead>
                        <tr>

                            <th>Details</th>
                            <th>Amount</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>TOTAL SALES AMOUNT</td>
                            <td>
                                <asp:Label ID="LblTotSales" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>TOTAL PURCHASE AMOUNT (-)</td>
                            <td>
                                <asp:Label ID="LblTotPurchase" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>TOTAL PROFIT AMOUNT</td>
                            <td>
                                <asp:Label ID="lblProfit" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>TOTAL PROFIT (%)</td>
                            <td>
                                <asp:Label ID="lblProfitPercent" runat="server"></asp:Label></td>
                        </tr>
                        
                    </tbody>
                </table>


            </div>

        </div>
        <!-- end invoice-price -->
    </div>
    <!-- end invoice-content -->
    <!-- begin Cashier -->
    
  
    
    <!-- begin invoice-footer -->
    <div class="invoice-footer">
        <p class="text-center m-b-5 f-w-600">
            THANK YOU FOR YOUR BUSINESS
                   
        </p>

    </div>
    <!-- end invoice-footer -->



</asp:Content>

