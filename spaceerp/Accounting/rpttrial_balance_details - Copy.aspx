<%@ Page Title="" Language="C#" MasterPageFile="~/PrintMaster.master" AutoEventWireup="true" CodeFile="rpttrial_balance_details - Copy.aspx.cs" Inherits="Accounting_rpttrial_balance_details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <title>jQuery TreeTable Demo Page</title>
    <link href="http://www.jqueryscript.net/css/jquerysctipttop1.css" rel="stylesheet" type="text/css">
    <!-- Bootstrap -->
    <link rel="stylesheet" href="http://netdna.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <style>
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- begin breadcrumb -->
    <ol class="breadcrumb hidden-print pull-right">
        <li class="breadcrumb-item"><a href="../Administration.aspx">Home</a></li>
        <li class="breadcrumb-item active">Posted Voucher</li>
    </ol>
    <!-- end breadcrumb -->
    <!-- begin page-header -->
    <h1 class="page-header hidden-print">Posted Vouchers </h1>
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
                <h4>List Posted Vouchers
                </h4>
            </span>

        </div>
        <!-- end invoice-company -->
        <!-- begin invoice-header -->
        <div class="invoice-header">
            <div class="invoice-from">

                <address class="m-t-5 m-b-5">
                    <strong class="text-inverse">From : 23/06/2018 TO 23/06/2018
                    </strong>
                    <br />

                </address>
            </div>
            <div class="invoice-to">
                <address class="m-t-5 m-b-5">
                    <strong class="text-inverse">Voucher Type: All</strong><br />

                </address>
            </div>
            <div class="invoice-date">
                <div class="date text-inverse m-t-5">
                    User :All
                   
                </div>


            </div>
        </div>
    </div>
    <!-- end invoice-header -->
    <div class="invoice-content">
        <table id="tree-table" class="table table-hover table-bordered text-black">
            <tbody>
                <th>Account Title</th>
                <th>Current Debit</th>
                <th>Current Credit</th>
                <th>Debit Balance</th>
                <th>Credit Balance</th>
                <asp:Repeater ID="treetable" OnItemDataBound="treetable_ItemDataBound" runat="server">
                    <ItemTemplate>
                        <tr class="bg-dark text-grey font-weight-bold">
                            <td data-column="name">
                                <asp:HiddenField ID="hdn" runat="server" Value='<%#Eval("sSubAccount") %>' />
                                <%#Eval("[sSubAccount]") %></td>
                            <td><%#Eval("[DebitAmount]") %></td>
                            <td><%#Eval("[CreditAmount]") %></td>
                            <td><%#Eval("BalAmount") %></td>
                            <td><%#Eval("[BalAmount]") %></td>
                        </tr>
                        <tr>
                            <td colspan="5">
                                <asp:Repeater ID="rpttreeAcc" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td data-column="name">
                                                
                                                <%#Eval("[Account Title]") %></td>
                                            <td><%#Eval("[DebitAmount]") %></td>
                                            <td><%#Eval("[CreditAmount]") %></td>
                                            <td><%#Eval("BalAmount") %></td>
                                            <td><%#Eval("[BalAmount]") %></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>


            </tbody>
        </table>
    </div>
    <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
    <script src="http://code.jquery.com/jquery-1.12.4.min.js"></script>
    <script src="http://netdna.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <script src="../assets/js/tabletree.js"></script>
</asp:Content>

