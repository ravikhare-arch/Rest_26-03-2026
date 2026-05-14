<%@ Page Title="" Language="C#" MasterPageFile="~/PrintMaster.master" AutoEventWireup="true" CodeFile="rptstock_report.aspx.cs" Inherits="Trading_rptStock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <link rel="stylesheet" href="http://netdna.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <%--<style>
        body {
            background-color: #fafafa;
            font-family: 'Open Sans';
        }

        .container {
            margin: 150px auto;
        }

        .treegrid-indent {
            width: 0px;
            height: 16px;
            display: inline-block;
            position: relative;
        }

        .treegrid-expander {
            width: 0px;
            height: 16px;
            display: inline-block;
            position: relative;
            left: -17px;
            cursor: pointer;
        }
    </style>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ol class="breadcrumb hidden-print pull-right">
        <li class="breadcrumb-item"><a href="../Administration.aspx">Home</a></li>
        <li class="breadcrumb-item active">Stock  Reports</li>
    </ol>
    <!-- end breadcrumb -->
    <!-- begin page-header -->
    <h1 class="page-header hidden-print">Stock  Report </h1>
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
                <h4>Stock Report With Sale Value
                </h4>
            </span>

        </div>
        <!-- end invoice-company -->
        <!-- begin invoice-header -->

        <!-- end invoice-header -->
        <table id="treetable" class="table table-hover table-bordered text-black">
            <tbody>

                <tr class="bg-danger font-weight-bold text-white">
                    <th>Item Name</th>
                    <th>Balance Quantity</th>
                    <th>Sale Rate</th>
                    <th>Sale Value</th>

                </tr>
                <asp:Repeater ID="rptStock" OnItemDataBound="rptStock_ItemDataBound" runat="server">
                    <ItemTemplate>
                        <tr class="bg-grey-lighter text-black">
                            <td colspan="2">Category Name: <%#Eval ("[sItemCategory]") %>
                                 <asp:HiddenField ID="hdnSubCategotyID" runat="server" Value='<%#Eval("nItemSubCategoryID") %>' />
                            </td>


                            <td>Sub Categorry: <%#Eval("sItemSubCategory") %></td>

                            <td><%#Eval("nStockValue") %></td>
                        </tr>



                        <asp:Repeater ID="rptStockDet" runat="server">
                            <ItemTemplate>
                                <tr class="text-black">
                                    <td data-column="name" class="p-l-10">
                                        <%# validation.TextToDate(Eval("sitemName").ToString()) %>
                                    </td>
                                    <td data-column="name"><%#Eval("[Balance Quantity]") %></td>
                                    <td><%#Eval("nSalePrice") %></td>
                                    <td><%#Eval("nStockValue") %></td>

                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
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
                            <td>TOTAL SALES VALUE</td>
                            <td>
                                <asp:Label ID="LblTotSales" runat="server"></asp:Label></td>
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

</asp:Content>

