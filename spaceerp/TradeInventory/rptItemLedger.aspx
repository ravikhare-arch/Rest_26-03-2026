<%@ Page Title="" Language="C#" MasterPageFile="~/PrintMaster.master" AutoEventWireup="true" CodeFile="rptItemLedger.aspx.cs" Inherits="Trading_rptItemLedger" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../assets/css/default/invoice-print.min.css" rel="stylesheet" />
    <link href="../assets/css/default/mystyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- begin breadcrumb -->
    <ol class="breadcrumb hidden-print pull-right">
        <li class="breadcrumb-item"><a href="tItem_ledger.aspx">Home</a></li>
        <li class="breadcrumb-item active">Item Ledger</li>
    </ol>
    <!-- end breadcrumb -->
    <!-- begin page-header -->
    <h1 class="page-header hidden-print">Item Ledger </h1>
    <!-- end page-header -->

    <!-- begin invoice -->
    <div class="invoice">
        <!-- begin invoice-company -->
        <div class="invoice-company text-inverse f-w-600">
            <span class="pull-right hidden-print">
                <%-- <a href="javascript:;" class="btn btn-sm btn-white m-b-10 p-l-5"><i class="fa fa-file-pdf t-plus-1 text-danger fa-fw fa-lg"></i>Export as PDF</a>--%>
                <a href="javascript:;" onclick="window.print()" class="btn btn-sm btn-white m-b-10 p-l-5"><i class="fa fa-print t-plus-1 fa-fw fa-lg"></i>Print</a>
            </span>
            <asp:Label ID="lblCompanyName" runat="server"></asp:Label>
            <span class="text-center">
                <h4>Item of Ledger </h4>
            </span>
        </div>
        <!-- end invoice-company -->
        <!-- begin invoice-header -->
        <div class="invoice-header">
            <div class="invoice-from">
               <h4> Item Name : <asp:Label ID="ItemName" runat="server"></asp:Label></h4>
            </div>

            <div class="invoice-date">

                <div class="date text-inverse m-t-5">
                    Statement Period : 
                   
                    <small>
                        <asp:Label ID="lblDate" runat="server"></asp:Label></small>
                </div>
                <div class="invoice-detail">
                    <div class="date text-inverse m-t-5">
                        
                    </div>

                    <%--<div class="date text-inverse m-t-5">
                        Currency:<br />
                        <small>
                            <asp:Label ID="lblCurrency" runat="server"></asp:Label></small>
                    </div>--%>
                </div>
            </div>
        </div>
        <!-- end invoice-header -->
        <!-- begin invoice-content -->
        <div class="invoice-content">
            <!-- begin table-responsive -->
            <%--<div class="table-responsive">
                <table class="table table-hover table-bordered text-black">

                    <tbody>
                        <tr>
                            <th>Invoice Date</th>
                            <th>Invoice No	</th>
                            <th>Item Name	</th>
                            <th>P.Rate</th>
                            <th>S. Qty	</th>
                            <th>S. Rate	</th>
                            <th>Balance	</th>
                            <th>G.Total	</th>
                        </tr>
                        <asp:Repeater ID="GridView1" OnItemDataBound="rptBalance_ItemDataBound" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td data-column="name" class="p-l-10">

                                        <asp:HiddenField ID="hdInvNo" runat="server" Value='<%#Eval("InvoiceNo") %>' />
                                        <%#Eval("[InvoiceNo]") %></td>
                                     <td><%#Eval ("[InvoiceDate]") %></td>
                                    <td><%#Eval ("[sitemName]") %></td>
                                    <td><%#Eval("[CreditQuantity]") %></td>
                                    <td><%#Eval("pUnit") %></td>
                                    <td><%#Eval("[DebitQuantity]") %></td>
                                    <td><%#Eval("[sUnit]") %></td>
                                    <asp:Repeater ID="rptBalance" runat="server">
                                        <ItemTemplate>
                                            <td>
                                                <asp:Label ID="lblBalance" runat="server"></asp:Label></td>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    <td><%#Eval("[GTotal]") %></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>

                </table>--%>

                 <asp:GridView ID="GridView1" CssClass="table table-striped table-bordered" runat="server"
                    AutoGenerateColumns="False" EmptyDataText="No Records to display" DataKeyNames="InvoiceID"
                    Width="100%" AllowPaging="true" AllowSorting="True" PageSize="25" HeaderStyle-BackColor="Gray">
                    <Columns>
                        <asp:TemplateField HeaderText="InvoiceID" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblID" runat="server" Text='<%# Eval("InvoiceID") %>'></asp:Label>
                                <asp:HiddenField ID="hdnInvNo" runat="server" Value='<%#Eval("nItemID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Invoice Date">
                            <ItemTemplate>
                                <%#validation.TextToDate(Eval("[InvoiceDate]").ToString())%>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="InvoiceNo" HeaderText="Invoice No" />
                        <asp:BoundField DataField="AccountTitle" HeaderText="Vendor/ Customers" />
                        <asp:BoundField DataField="sitemName" HeaderText="Item Name" />
                        <asp:BoundField DataField="CreditQuantity" HeaderText="P. Qty" />
                        <asp:BoundField DataField="pUnit" HeaderText="P.Rate" />
                        <asp:BoundField DataField="DebitQuantity" HeaderText="S. Qty" />
                        <asp:BoundField DataField="sUnit" HeaderText="S. Rate" />
                       <asp:BoundField DataField="nBalance" HeaderText="Balance Quantity" />
                        <asp:BoundField DataField="GTotal" HeaderText="G.Total" />
                    </Columns>
                </asp:GridView>
            </div>
            <!-- end table-responsive -->
            <!-- begin invoice-price -->
            <div class="invoice-price">
                <div class="invoice-price-left">
                    <div class="invoice-price-row">
                        <div class="sub-price">
                            <small>Total Credit Quantity</small>
                            <span class="text-inverse">
                                <asp:Label ID="lblTotCreditQty" runat="server"></asp:Label>
                            </span>
                        </div>
                        <div class="sub-price">
                            <i class="fa fa-minus text-muted"></i>
                        </div>
                        <div class="sub-price">
                            <small>Total Debit Quantity</small>
                            <span class="text-inverse">
                                <asp:Label ID="lblTotDebitQty" runat="server"></asp:Label></span>
                        </div>


                        <div class="sub-price">
                            <%--<i class="fa fa-minus text-muted"></i>--%>
                        </div>
                        <%--<div class="sub-price">
                             <small>Discount</small>
                            <span class="text-inverse">
                                </span>
                        </div>--%>
                    </div>

                </div>
                <div class="invoice-price-right">
                    <small>TOTAL BALANCE QUANTTIY</small> <span class="f-w-600">
                        <asp:Label ID="lblTotBalanceQty" runat="server"></asp:Label></span>
                </div>
            </div>
            <!-- end invoice-price -->
        </div>
        <!-- end invoice-content -->
        <!-- begin invoice-note -->
        <%-- <div class="invoice-note">
            * Make all cheques payable to [<asp:Label ID="lblCompanyName2" runat="server"></asp:Label>]<br />
            * Journal is due within 30 days<br />
            * If you have any questions concerning this invoice, contact  [<asp:Label ID="lblcperson" runat="server"></asp:Label>,
            <asp:Label ID="lblphone2" runat="server"></asp:Label>,
            <asp:Label ID="lblemail2" runat="server"></asp:Label>]
               
        </div>--%>
        <!-- end invoice-note -->
        <!-- begin invoice-footer -->
        <div class="invoice-footer">
            <p class="text-center m-b-5 f-w-600">
                THANK YOU FOR YOUR BUSINESS
                   
            </p>

        </div>
        <!-- end invoice-footer -->
    </div>
    <!-- end invoice -->
</asp:Content>

