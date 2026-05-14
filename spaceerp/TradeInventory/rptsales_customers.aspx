<%@ Page Title="" Language="C#" MasterPageFile="~/PrintMaster.master" AutoEventWireup="true" CodeFile="rptsales_customers.aspx.cs" Inherits="Trading_rptSales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <link rel="stylesheet" href="http://netdna.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <link href="../../css/StatementSheet.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
            <div class="row">                
                <div class="widget-box">
                    <div class="widget-header widget-header-large">
                        <%--<img src="logo.png" />--%>
                        <asp:Image ID="imgComp" runat="server" AlternateText="" Height="100px" Style="display: none" />
                        <div class="widget-toolbar no-border invoice-info h3 center-block">
                            <span class="invoice-info-label">
                                </span>
                            <span class="red">Sales Report</span> 
                            <span class="invoice-info-label">Detail Vendor Wise</span>
                             <span class="text-right pull-right" id="hidePrint" runat="server">
                             <a href="tSales_report.aspx" class="btn btn-sm btn btn-info m-b-10 p-l-5" id="btnhome"><i class="fa fa-home t-plus-1 text-white fa-fw fa-lg"></i>Home</a>                        
                <a href="javascript:;" onclick="window.print()" class="btn btn-sm btn-white m-b-10 p-l-5"><i class="fa fa-print t-plus-1 fa-fw fa-lg"></i>Print</a>
                    </span>
                        </div>

                    </div>
                    <div class="widget-body">
    
    
    <!-- begin invoice -->
    <div class="invoice">
        <table id="treetable" class="table table-striped table-bordered">
            <thead>
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
                <asp:Repeater ID="rptSales" OnItemDataBound="rptSales_ItemDataBound" runat="server">
                    <ItemTemplate>
                        <tr class="bg-grey-lighter text-black font-weight-bold">
                            <td>Customer Name:
                                 <asp:HiddenField ID="hdnCustomerID" runat="server" Value='<%#Eval("nCustomerNameID") %>' />
                            </td>
                            
                            <td colspan="5"><%#Eval ("[sAccountTitle]") %></td>
                           
                            <td><%#Eval("nTotSalesAmount") %></td>
                            <td><%#Eval("nTotPurchaseCost") %></td>
                            <td><%#Eval("nTotalProfitAmount") %></td>
                            <td><%#Eval("nTotalProfitPercent") %></td>
                        </tr>
                        <asp:Repeater ID="rptSalesDet" runat="server">
                            <ItemTemplate>
                                <tr class="text-black">
                                    <td data-column="name" class="p-l-10">
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
                    </ItemTemplate>
                </asp:Repeater>
            </thead>
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
                            <td>TOTAL PROFIT AMOUTN</td>
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
        <div class="invoice-footer">
            <p class="text-center m-b-5 f-w-600">
                THANK YOU FOR YOUR BUSINESS
            </p>
        </div>
    </div>
</div>
                    </div>
                </div>
        </div>

</asp:Content>

