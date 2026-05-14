<%@ Page Title="" Language="C#" MasterPageFile="~/PrintMaster.master" AutoEventWireup="true" CodeFile="rptpurchaseitem.aspx.cs" Inherits="Trading_rptpurchase" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <link rel="stylesheet" href="http://netdna.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <link href="../css/Common.css" rel="stylesheet" />
    <style>
        .table th{
            background-color: #5191FA;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <!-- begin row -->
    <div class="row">
        <!-- begin col-6 -->
        <div class="col-lg-12">
            <!-- begin panel -->
            <div class="panel panel-inverse">
                <!-- begin panel-heading -->
                <div class="panel-heading">
                    <div class="panel-heading-btn pull-left">
                         <a href="javascript:;" onclick="window.print()" class="btn btn-info btn-xs"><i class="fa fa-print t-plus-1 fa-fw fa-lg"></i>Print</a>
                    </div>
                    <div class="panel-heading-btn">
                        <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                        <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                    </div>

                    <h4 class="panel-title text-center">Purchase Report Detail Item Wise</h4>
                </div>
                <!-- end panel-heading -->
                <!-- begin panel-body -->
                <div class="panel-body">

    <!-- begin invoice -->
    <div class="invoice">
        <!-- end invoice-header -->
        <table id="treetable" class="table table-hover table-bordered text-black">
            <tbody>
                <tr class="bg-danger font-weight-bold text-white">
                    <th>Date</th>
                    <th>Invoice No</th>
                    <th>Vendor Name</th>
                    <th>Quantity</th>
                    <th>Unit Price</th>
                    <th>Grand Total</th>
                </tr>
                <asp:Repeater ID="treetableSub" OnItemDataBound="treetable_ItemDataBound" runat="server">
                    <ItemTemplate>
                        <tr class="bg-grey-lighter text-black font-weight-bold">
                            <td>Item Name:</td>
                            <td data-column="name" class="p-l-10">

                                <asp:HiddenField ID="hdnItemID" runat="server" Value='<%#Eval("nItemID") %>' />
                                <%#Eval("[sitemName]") %></td>
                            <td>Balance Quantity: </td>
                            <td><%#Eval("[Credit Quantity]") %></td>
                            <td>Grand Total:</td>
                            <td><%#Eval("nGtotal") %></td>
                        </tr>
                        <asp:Repeater ID="treetableAcc" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td data-column="name"><%#validation.TextToDate(Eval("dtPoInvoice").ToString()) %></td>
                                    <td data-column="name"><%#Eval("sPoInvoiceNo") %></td>

                                    <td><%#Eval("sAccountTitle") %></td>
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
                <tr class="bgTotal">
                    <td colspan="4"></td>
                    <td data-column="name" class="p-l-10">Total</td>

                    <td>
                        <asp:Label ID="lbltotalSaleValue" runat="server"> </asp:Label></td>
                </tr>
            </tbody>
        </table>
        </div>

                </div>
                </div>
            </div>
        </div>
        <asp:Label ID="lblrecord" runat="server" Visible="false" ForeColor="Red"> </asp:Label>
        <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
        <script src="http://code.jquery.com/jquery-1.12.4.min.js"></script>
        <%--  <script src="http://netdna.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>--%>
        <%--<script src="../assets/js/tabletree.js"></script>--%>
</asp:Content>

