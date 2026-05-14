<%@ Page Title="" Language="C#" MasterPageFile="~/PrintMaster.master" AutoEventWireup="true" CodeFile="rptjournal_voucher.aspx.cs" Inherits="Accounting_rptjournal_voucher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../assets/css/default/invoice-print.min.css" rel="stylesheet" />
    <link href="../assets/css/default/mystyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- begin breadcrumb -->
    <ol class="breadcrumb hidden-print pull-right">
        <li class="breadcrumb-item"><a href="tJournal_voucher.aspx">Home</a></li>
        <li class="breadcrumb-item active">Journal Voucher</li>
    </ol>
    <!-- end breadcrumb -->
    <!-- begin page-header -->
    <h1 class="page-header hidden-print">Journal Voucher </h1>
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

        </div>
        <!-- end invoice-company -->
        <!-- begin invoice-header -->
        <div class="invoice-header">
            <div class="invoice-from">
                <small>from</small>
                <address class="m-t-5 m-b-5">
                    <strong class="text-inverse">
                        <asp:Label ID="lblCompanyName1" runat="server"></asp:Label></strong><br />
                    <asp:Label ID="lblcompanyAdd" runat="server"></asp:Label><br />
                    <asp:Label ID="lblCity" runat="server"></asp:Label>,
                    <asp:Label ID="lblCountry" runat="server"></asp:Label><br />
                    Phone:
                    <asp:Label ID="lblPhone" runat="server"></asp:Label><br />
                    Fax:
                    <asp:Label ID="lblFax" runat="server"></asp:Label><br />
                    Email:
                    <asp:Label ID="lblEmail" runat="server"></asp:Label>
                </address>
            </div>

            <div class="invoice-date">
                <small>Journal Voucher Details</small>
                <div class="date text-inverse m-t-5">
                    Date
                    <br />
                    <small>
                        <asp:Label ID="lblDate" runat="server"></asp:Label></small>
                </div>
                <div class="invoice-detail">
                    <div class="date text-inverse m-t-5">
                        Journal Voucher No.
                        <br />
                        <small>
                            <asp:Label ID="lblVoucherNo" runat="server"></asp:Label>

                        </small>
                    </div>

                    <%--<div class="date text-inverse m-t-5">
                        Reference No.:<br />
                        <small>
                            <asp:Label ID="lblrefNo" runat="server"></asp:Label></small>
                    </div>--%>
                </div>
            </div>
        </div>
        <!-- end invoice-header -->
        <!-- begin invoice-content -->
        <div class="invoice-content">
            <!-- begin table-responsive -->
            <div class="table-responsive">
                <asp:GridView ID="GridView1" CssClass="table table-invoice" runat="server"
                    AutoGenerateColumns="False" EmptyDataText="No Records to display" DataKeyNames="nJournalVoucherDetID"
                    Width="100%" AllowPaging="true" AllowSorting="True" PageSize="25">
                    <Columns>
                        <asp:TemplateField HeaderText="nJournalVoucherDetID" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblID" runat="server" Text='<%# Eval("nJournalVoucherDetID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="sCode" HeaderText="Mark" />
                        <asp:BoundField DataField="sAccountTitle" HeaderText="Account Title" />
                        <asp:BoundField DataField="sDescription" HeaderText="Description" />
                        <asp:BoundField DataField="sChequeNo" HeaderText="Cheque No." />
                        <asp:TemplateField HeaderText="Cheque Date">
                            <ItemTemplate>
                                <%#validation.TextToDate(Eval("dtCheque").ToString())%>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="sCurrenccy" HeaderText="Currency" />
                        <asp:BoundField DataField="nAmount" HeaderText="    Amount" />
                    </Columns>
                </asp:GridView>

            </div>
            <!-- end table-responsive -->
            <!-- begin invoice-price -->
            <div class="invoice-price">
                <div class="invoice-price-left">
                    <div class="invoice-price-row">
                        <div class="sub-price">
                            <small>SUBTOTAL</small>
                            <span class="text-inverse">
                                <asp:Label ID="lblSubTot" runat="server"></asp:Label></span>
                        </div>
                        <div class="sub-price">
                            <%--<i class="fa fa-plus text-muted"></i>--%>
                        </div>
                        <div class="sub-price">
                            <%-- <small>Tax</small>
                            <span class="text-inverse">
                                <asp:Label ID="lblTaxTot" runat="server"></asp:Label></span>--%>
                        </div>
                        <div class="sub-price">
                            <%--<i class="fa fa-minus text-muted"></i>--%>
                        </div>
                        <div class="sub-price">
                            <%-- <small>Discount</small>
                            <span class="text-inverse">
                                <asp:Label ID="lblDiscTot" runat="server"></asp:Label></span>--%>
                        </div>
                    </div>

                </div>
                <div class="invoice-price-right">
                    <small>GRAND TOTAL</small> <span class="f-w-600">
                        <asp:Label ID="lblGrandtotal" runat="server"></asp:Label></span>
                </div>
            </div>
            <!-- end invoice-price -->
        </div>
        <!-- end invoice-content -->
        <!-- begin invoice-note -->
        <div class="invoice-note">
            * Make all cheques payable to [<asp:Label ID="lblCompanyName2" runat="server"></asp:Label>]<br />
            * Journal is due within 30 days<br />
            * If you have any questions concerning this invoice, contact  [<asp:Label ID="lblcperson" runat="server"></asp:Label>,
            <asp:Label ID="lblphone2" runat="server"></asp:Label>,
            <asp:Label ID="lblemail2" runat="server"></asp:Label>]
               
        </div>
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

