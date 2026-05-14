<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="Administration.aspx.cs" Inherits="Administration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="vmsg" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="vtitle" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <!-- begin page-header -->
    <h1 class="page-header">Dashboard</h1>
    <!-- end page-header -->
    <!-- begin row -->
    <div class="row">
        <!-- begin col-6 -->
        <!-- begin col-6 -->
        <div class="col-lg-12">
            <!-- begin nav-tabs -->
            <ul class="nav nav-tabs">

                <li class="nav-items">
                    <a href="#default-tab-1" data-toggle="tab" class="nav-link active">
                        <span class="d-sm-none">
                            <asp:Image ID="imgAccounts" ImageUrl="~/assets/img/accounting.png" Width="250" Height="100" runat="server" /></span>
                        <span class="d-sm-block d-none">
                            <asp:Image ID="Image1" ImageUrl="~/assets/img/accounting.png" Width="250" Height="100" runat="server" /></span>
                    </a>
                </li>
                <li class="nav-items">
                    <a href="#default-tab-2" data-toggle="tab" class="nav-link">
                        <span class="d-sm-none">
                            <asp:Image ID="Image2" ImageUrl="~/assets/img/tradding.png" Width="250" Height="100" runat="server" /></span>
                        <span class="d-sm-block d-none">
                            <asp:Image ID="Image3" ImageUrl="~/assets/img/tradding.png" Width="250" Height="100" runat="server" /></span>
                    </a>
                </li>
                <li class="">
                    <a href="#default-tab-3" data-toggle="tab" class="nav-link">
                        <span class="d-sm-none">
                            <asp:Image ID="Image4" ImageUrl="~/assets/img/travel.png" Width="250" Height="100" runat="server" /></span>
                        <span class="d-sm-block d-none">
                            <asp:Image ID="Image5" ImageUrl="~/assets/img/travel.png" Width="250" Height="100" runat="server" /></span>
                    </a>
                </li>
            </ul>
            <!-- end nav-tabs -->
            <!-- begin tab-content -->
            <div class="tab-content">
                <!-- begin tab-pane -->
                <div class="tab-pane fade active show" id="default-tab-1">
                    <div class="row">
                        <!-- begin col-3 -->
                        <div class="col-lg-3 col-md-6">

                            <div class="widget widget-stats bg-red-darker ">
                                <a href="Accounting/tchartof_account.aspx">
                                    <div class="stats-icon text-white"><i class="fa fa-desktop"></i></div>
                                    <div class="stats-info">
                                        <h4>Main Accounts</h4>
                                        <p>Main
                                            <br />
                                            Accounts</p>
                                    </div>
                                    <div class="stats-link">
                                        <a href="Masters/maccount_main.aspx">View Detail <i class="fa fa-arrow-alt-circle-right"></i></a>
                                    </div>
                                </a>
                            </div>

                        </div>
                        <!-- end col-3 -->
                        <!-- begin col-3 -->
                        <div class="col-lg-3 col-md-6">
                            <div class="widget widget-stats bg-blue-darker">
                                <a href="Accounting/tchartof_account.aspx">
                                    <div class="stats-icon text-white"><i class="fa fa-user"></i></div>
                                    <div class="stats-info">
                                        <h4>Chart of Accounts</h4>
                                        <p>Create<br />
                                            New Mask</p>
                                    </div>
                                    <div class="stats-link">
                                        <a href="Accounting/tchartof_account.aspx">View Detail <i class="fa fa-arrow-alt-circle-right"></i></a>
                                    </div>
                                </a>
                            </div>
                        </div>
                        <!-- end col-3 -->
                        <!-- begin col-3 -->
                        <div class="col-lg-3 col-md-6">
                            <div class="widget widget-stats bg-green-darker">
                                <a href="Accounting/tpayment_voucher.aspx">
                                    <div class="stats-icon text-white"><i class="fa fa-money-bill-alt"></i></div>
                                    <div class="stats-info">
                                        <h4>Cash/Bank Vouchers</h4>
                                        <p>Payment<br />
                                            Voucher</p>
                                    </div>
                                    <div class="stats-link">
                                        <a href="Accounting/tpayment_voucher.aspx">View Detail <i class="fa fa-arrow-alt-circle-right"></i></a>
                                    </div>
                                </a>
                            </div>
                        </div>
                        <!-- end col-3 -->
                        <!-- begin col-3 -->
                        <div class="col-lg-3 col-md-6">

                            <div class="widget widget-stats bg-warning">
                                <a href="Accounting/treceipt_voucher.aspx">
                                    <div class="stats-icon text-white"><i class="fa fa-users"></i></div>
                                    <div class="stats-info">
                                        <h4>Cash/Bank Vouchers</h4>
                                        <p>Reciept
                                            <br />
                                            Vouchers</p>
                                    </div>
                                    <div class="stats-link">
                                        <a href="Accounting/treceipt_voucher.aspx">View Detail <i class="fa fa-arrow-alt-circle-right"></i></a>
                                    </div>
                                </a>
                            </div>
                        </div>
                        <!-- end col-3 -->
                        <!-- begin col-3 -->
                        <div class="col-lg-3 col-md-6">
                            <div class="widget widget-stats bg-blue-darker">
                                <a href="Accounting/tacc_journal_voucher.aspx">
                                    <div class="stats-icon text-white"><i class="fa fa-table"></i></div>
                                    <div class="stats-info">
                                        <h4>Journal Vouchers</h4>
                                        <p>Journal
                                            <br />
                                            Vouchers</p>
                                    </div>
                                    <div class="stats-link">
                                        <a href="Accounting/tacc_journal_voucher.aspx">View Detail <i class="fa fa-arrow-alt-circle-right"></i></a>
                                    </div>
                                </a>
                            </div>
                        </div>
                        <!-- end col-3 -->
                        <!-- begin col-3 -->
                        <div class="col-lg-3 col-md-6">
                            <div class="widget widget-stats bg-purple-darker">
                                <a href="Accounting/tpdc_voucher.aspx">
                                    <div class="stats-icon text-white"><i class="fa fa-credit-card"></i></div>
                                    <div class="stats-info">
                                        <h4>PDC/PDCR VOUCHER</h4>
                                        <p>PDC/PDCR
                                            <br />
                                            VOUCHER</p>
                                    </div>
                                    <div class="stats-link">
                                        <a href="Accounting/tpdc_voucher.aspx">View Detail <i class="fa fa-arrow-alt-circle-right"></i></a>
                                    </div>
                                </a>
                            </div>
                        </div>
                        <!-- end col-3 -->
                        <!-- begin col-3 -->
                        <div class="col-lg-3 col-md-6">
                            <div class="widget widget-stats bg-purple-darker">
                                <a href="Accounting/tpostedvoucher.aspx">
                                    <div class="stats-icon text-white"><i class="fa fa-life-ring"></i></div>
                                    <div class="stats-info">
                                        <h4>List of Posted Vouchers</h4>
                                        <p>Posted
                                            <br />
                                            Vouchers</p>
                                    </div>
                                    <div class="stats-link">
                                        <a href="Accounting/tpostedvoucher.aspx">View Detail <i class="fa fa-arrow-alt-circle-right"></i></a>
                                    </div>
                                </a>
                            </div>
                        </div>
                        <!-- end col-3 -->
                        <!-- begin col-3 -->
                        <div class="col-lg-3 col-md-6">
                            <div class="widget widget-stats bg-green-darker">
                                <a href="Accounting/tgeneral_ledger.aspx">
                                    <div class="stats-icon text-white"><i class="fa fa-calculator"></i></div>
                                    <div class="stats-info">
                                        <h4>Statement of Account</h4>
                                        <p>General
                                            <br />
                                            Ledger </p>
                                    </div>
                                    <div class="stats-link">
                                        <a href="Accounting/tgeneral_ledger.aspx">View Detail <i class="fa fa-arrow-alt-circle-right"></i></a>
                                    </div>
                                </a>
                            </div>
                        </div>
                        <!-- end col-3 -->
                        <!-- begin col-3 -->
                        <div class="col-lg-3 col-md-6">
                            <div class="widget widget-stats bg-red-darker">
                                <a href="Accounting/tprofit_loss.aspx">
                                    <div class="stats-icon text-white"><i class="fa fa-chart-bar"></i></div>
                                    <div class="stats-info">
                                        <h4>Profit And Loss Reports</h4>
                                        <p>Profit & Loss
                                            <br />
                                            Reports</p>
                                    </div>
                                    <div class="stats-link">
                                        <a href="Accounting/tprofit_loss.aspx">View Detail <i class="fa fa-arrow-alt-circle-right"></i></a>
                                    </div>
                                </a>
                            </div>
                        </div>


                        <!-- begin col-3 -->
                        <div class="col-lg-3 col-md-6">
                            <div class="widget widget-stats bg-blue-darker">
                                <a href="Accounting/tpay_receivables.aspx">
                                    <div class="stats-icon text-white"><i class="fa fa-handshake"></i></div>
                                    <div class="stats-info">
                                        <h4>Payables Reports</h4>
                                        <p>Payables<br />
                                            Receivables</p>
                                    </div>
                                    <div class="stats-link">
                                        <a href="Accounting/tpay_receivables.aspx">View Detail <i class="fa fa-arrow-alt-circle-right"></i></a>
                                    </div>
                                </a>
                            </div>
                        </div>
                        <!-- end col-3 -->

                        <!-- begin col-3 -->
                        <div class="col-lg-3 col-md-6">
                            <div class="widget widget-stats bg-green-darker">
                                <a href="Accounting/ttrailbalance.aspx">
                                    <div class="stats-icon text-white"><i class="fa fa-chart-pie"></i></div>

                                    <div class="stats-info">
                                        <h4>Trial Balance</h4>
                                        <p>Trial Balance<br />
                                            Reports</p>
                                    </div>
                                    <div class="stats-link">
                                        <a href="Accounting/ttrailbalance.aspx">View Detail <i class="fa fa-arrow-alt-circle-right"></i></a>
                                    </div>
                                </a>
                            </div>
                        </div>
                        <!-- end col-3 -->
                        <!-- begin col-3 -->
                        <div class="col-lg-3 col-md-6">
                            <div class="widget widget-stats bg-warning">
                                <a href="Accounting/tbalancesheet.aspx">
                                    <div class="stats-icon text-white"><i class="fa fa-briefcase"></i></div>
                                    <div class="stats-info">
                                        <h4>Balance Sheet</h4>
                                        <p>Balance Sheet Reports</p>
                                    </div>
                                    <div class="stats-link">
                                        <a href="Accounting/tbalancesheet.aspx">View Detail <i class="fa fa-arrow-alt-circle-right"></i></a>
                                    </div>
                                </a>
                            </div>
                        </div>
                        <!-- end col-3 -->

                    </div>
                </div>
                <!-- end tab-pane -->
                <!-- begin tab-pane -->
                <div class="tab-pane fade" id="default-tab-2">
                    <!-- begin row -->
                    <div class="row">
                        <!-- begin col-3 -->
                        <div class="col-lg-3 col-md-6">
                            <div class="widget widget-stats bg-red-darker">
                                <div class="stats-icon text-white">
                                    <i class="fa fa-plus-square"></i>
                                </div>
                                <div class="stats-info">
                                    <h4>Create New Item</h4>
                                    <p>
                                        Create<br />
                                        New Item
                                    </p>
                                </div>
                                <div class="stats-link">
                                    <a href="TradeInventory/titem_details.aspx">View Detail <i class="fa fa-arrow-alt-circle-right"></i></a>
                                </div>
                            </div>
                        </div>
                        <!-- end col-3 -->

                        <!-- begin col-3 -->
                        <div class="col-lg-3 col-md-6">
                            <div class="widget widget-stats bg-blue-darker">
                                <div class="stats-icon text-white">
                                    <i class="fa fa-cart-plus"></i>
                                </div>
                                <div class="stats-info">
                                    <h4>PO</h4>
                                    <p>
                                        Purchase<br />
                                        Orders
                                    </p>
                                </div>
                                <div class="stats-link">
                                    <a href="TradeInventory/tpo.aspx">View Detail <i class="fa fa-arrow-alt-circle-right"></i></a>
                                </div>
                            </div>
                        </div>
                        <!-- end col-3 -->
                        <!-- begin col-3 -->
                        <div class="col-lg-3 col-md-6">
                            <div class="widget widget-stats bg-green-darker">
                                <div class="stats-icon text-white">
                                    <i class="fa fa-cart-arrow-down"></i>
                                </div>
                                <div class="stats-info">
                                    <h4>PO Invoices</h4>
                                    <p>
                                        Purchase<br />
                                        Invoices
                                    </p>
                                </div>
                                <div class="stats-link">
                                    <a href="TradeInventory/tpoinvoice.aspx">View Detail <i class="fa fa-arrow-alt-circle-right"></i></a>
                                </div>
                            </div>
                        </div>
                        <!-- end col-3 -->
                        <!-- begin col-3 -->
                        <div class="col-lg-3 col-md-6">
                            <div class="widget widget-stats bg-warning">
                                <div class="stats-icon text-white">
                                    <i class="fa fa-calendar"></i>
                                </div>
                                <div class="stats-info">
                                    <h4>Quotations</h4>
                                    <p>
                                        Sales<br />
                                        Quotations
                                    </p>
                                </div>
                                <div class="stats-link">
                                    <a href="TradeInventory/tquotation.aspx">View Detail <i class="fa fa-arrow-alt-circle-right"></i></a>
                                </div>
                            </div>
                        </div>
                        <!-- end col-3 -->
                        <!-- begin col-3 -->
                        <div class="col-lg-3 col-md-6">
                            <div class="widget widget-stats bg-blue-darker">
                                <div class="stats-icon text-white">
                                    <i class="fa fa-align-justify"></i>
                                </div>
                                <div class="stats-info">
                                    <h4>Sales Order</h4>
                                    <p>
                                        Sales<br />
                                        Order
                                    </p>
                                </div>
                                <div class="stats-link">
                                    <a href="TradeInventory/tsalesorder.aspx">View Detail <i class="fa fa-arrow-alt-circle-right"></i></a>
                                </div>
                            </div>
                        </div>
                        <!-- end col-3 -->
                        <!-- begin col-3 -->
                        <div class="col-lg-3 col-md-6">
                            <div class="widget widget-stats bg-purple-darker">
                                <div class="stats-icon text-white">
                                    <i class="fa fa-book"></i>
                                </div>
                                <div class="stats-info">
                                    <h4>Sales Invoices</h4>
                                    <p>
                                        Sales
                                        <br />
                                        Invoices
                                    </p>
                                </div>
                                <div class="stats-link">
                                    <a href="TradeInventory/tsoinvoice.aspx">View Detail <i class="fa fa-arrow-alt-circle-right"></i></a>
                                </div>
                            </div>
                        </div>
                        <!-- end col-3 -->
                        <!-- begin col-3 -->
                        <div class="col-lg-3 col-md-6">
                            <div class="widget widget-stats bg-purple-darker">
                                <div class="stats-icon">
                                    <i class="fa fa-braille"></i>
                                </div>
                                <div class="stats-info text-white">
                                    <h4>Item Ledger</h4>
                                    <p>
                                        Item
                                        <br />
                                        Ledger
                                    </p>
                                </div>
                                <div class="stats-link">
                                    <a href="TradeInventory/titem_ledger.aspx">View Detail <i class="fa fa-arrow-alt-circle-right"></i></a>
                                </div>
                            </div>
                        </div>
                        <!-- end col-3 -->
                        <!-- begin col-3 -->
                        <div class="col-lg-3 col-md-6">
                            <div class="widget widget-stats bg-green-darker">
                                <div class="stats-icon text-white">
                                    <i class="fa fa-list-alt"></i>
                                </div>
                                <div class="stats-info">
                                    <h4>Sales Reports</h4>
                                    <p>
                                        Sales
                                        <br />
                                        Reports
                                    </p>
                                </div>
                                <div class="stats-link">
                                    <a href="TradeInventory/tsales_report.aspx">View Detail <i class="fa fa-arrow-alt-circle-right"></i></a>
                                </div>
                            </div>
                        </div>
                        <!-- end col-3 -->
                        <!-- begin col-3 -->
                        <div class="col-lg-3 col-md-6">
                            <div class="widget widget-stats bg-red-darker">
                                <div class="stats-icon text-white">
                                    <i class="fa fa-id-card"></i>
                                </div>
                                <div class="stats-info">
                                    <h4>Purchase Reports</h4>
                                    <p>
                                        Purchase<br />
                                        Reports
                                    </p>
                                </div>
                                <div class="stats-link">
                                    <a href="TradeInventory/tpurchase_report.aspx">View Detail <i class="fa fa-arrow-alt-circle-right"></i></a>
                                </div>
                            </div>
                        </div>
                        <!-- end col-3 -->
                        <!-- begin col-3 -->
                        <div class="col-lg-3 col-md-6">
                            <div class="widget widget-stats bg-blue-darker">
                                <div class="stats-icon text-white">
                                    <i class="fa fa-cubes"></i>
                                </div>
                                <div class="stats-info">
                                    <h4>Stock Reports</h4>
                                    <p>
                                        Stock
                                        <br />
                                        Reports
                                    </p>
                                </div>
                                <div class="stats-link">
                                    <a href="TradeInventory/rptstock_report.aspx">View Detail <i class="fa fa-arrow-alt-circle-right"></i></a>
                                </div>
                            </div>
                        </div>
                        <!-- end col-3 -->
                        <!-- begin col-3 -->
                        <%--<div class="col-lg-3 col-md-6">
                            <div class="widget widget-stats bg-green-darker">
                                <div class="stats-icon">
                                    <i class="fa fa-clock"></i>
                                </div>
                                <div class="stats-info">
                                    <h4>Point of Sales Reports</h4>
                                    <p>
                                        Point of Sales
                                    </p>
                                </div>
                                <div class="stats-link">
                                    <a href="javascript:;">View Detail <i class="fa fa-arrow-alt-circle-right"></i></a>
                                </div>
                            </div>
                        </div>--%>
                        <!-- end col-3 -->
                        <!-- begin col-3 -->
                        <%-- <div class="col-lg-3 col-md-6">
                            <div class="widget widget-stats bg-warning">
                                <div class="stats-icon">
                                    <i class="fa fa-clock"></i>
                                </div>
                                <div class="stats-info">
                                    <h4>Item Ledger Reports</h4>
                                    <p>
                                        Item <br />Ledger
                                    </p>
                                </div>
                                <div class="stats-link">
                                    <a href="javascript:;">View Detail <i class="fa fa-arrow-alt-circle-right"></i></a>
                                </div>
                            </div>
                        </div>--%>
                        <!-- end col-3 -->
                    </div>
                    <!-- end row -->
                </div>
                <!-- end tab-pane -->
                <!-- begin tab-pane -->
                <div class="tab-pane fade" id="default-tab-3">
                    <!-- begin row -->
                    <div class="row">

                        <!-- begin col-3 -->
                        <div class="col-lg-3 col-md-6">
                            <div class="widget widget-stats bg-red-darker">
                                <div class="stats-icon text-white">
                                    <i class="fa fa-paper-plane"></i>
                                </div>
                                <div class="stats-info">
                                    <h4>Visa Booking Details</h4>
                                    <p>
                                        Visa
                                        <br />
                                        Entries 
                                    </p>
                                </div>
                                <div class="stats-link">
                                    <a href="Travel/tvisa.aspx">View Detail <i class="fa fa-arrow-alt-circle-right"></i></a>
                                </div>
                            </div>
                        </div>
                        <!-- end col-3 -->
                        <!-- begin col-3 -->
                        <div class="col-lg-3 col-md-6">
                            <div class="widget widget-stats bg-blue-darker">
                                <div class="stats-icon text-white">
                                    <i class="fa fa-plane"></i>
                                </div>
                                <div class="stats-info">
                                    <h4>Ticket Booking</h4>
                                    <p>
                                        Ticket
                                        <br />
                                        Entries
                                    </p>
                                </div>
                                <div class="stats-link">
                                    <a href="Travel/tticketing.aspx">View Detail <i class="fa fa-arrow-alt-circle-right"></i></a>
                                </div>
                            </div>
                        </div>
                        <!-- end col-3 -->
                        <!-- begin col-3 -->
                        <div class="col-lg-3 col-md-6">
                            <div class="widget widget-stats bg-green-darker">
                                <div class="stats-icon text-white">
                                    <i class="fa fa-bed"></i>
                                </div>
                                <div class="stats-info">
                                    <h4>Hotel Booking</h4>
                                    <p>
                                        Hotel
                                        <br />
                                        Entries
                                    </p>
                                </div>
                                <div class="stats-link">
                                    <a href="Travel/thotel.aspx">View Detail <i class="fa fa-arrow-alt-circle-right"></i></a>
                                </div>
                            </div>
                        </div>
                        <!-- end col-3 -->
                        <!-- begin col-3 -->
                        <div class="col-lg-3 col-md-6">
                            <div class="widget widget-stats bg-warning">
                                <div class="stats-icon text-white">
                                    <i class="fa fa-ship"></i>
                                </div>
                                <div class="stats-info">
                                    <h4>Execursion Booking</h4>
                                    <p>
                                        Execursion
                                        <br />
                                        Entries
                                    </p>
                                </div>
                                <div class="stats-link">
                                    <a href="Travel/texcursion_booking.aspx">View Detail <i class="fa fa-arrow-alt-circle-right"></i></a>
                                </div>
                            </div>
                        </div>
                        <!-- end col-3 -->
                        <!-- begin col-3 -->
                        <div class="col-lg-3 col-md-6">
                            <div class="widget widget-stats bg-red-darker">
                                <div class="stats-icon text-white">
                                    <i class="fa fa-tasks"></i>
                                </div>
                                <div class="stats-info">
                                    <h4>Travel Expense Voucher</h4>
                                    <p>
                                        Expense<br />
                                        Entry
                                    </p>
                                </div>
                                <div class="stats-link">
                                    <a href="Travel/ttravel_expense_voucher.aspx">View Detail <i class="fa fa-arrow-alt-circle-right"></i></a>
                                </div>
                            </div>
                        </div>
                        <!-- end col-3 -->
                        <!-- begin col-3 -->
                        <div class="col-lg-3 col-md-6">
                            <div class="widget widget-stats bg-blue-darker">
                                <div class="stats-icon text-white">
                                    <i class="fa fa-sliders-h"></i>
                                </div>
                                <div class="stats-info">
                                    <h4>Reports</h4>
                                    <p>
                                        Visa<br />
                                        Reports
                                    </p>
                                </div>
                                <div class="stats-link">
                                    <a href="Travel/tvisa_report.aspx">View Detail <i class="fa fa-arrow-alt-circle-right"></i></a>
                                </div>
                            </div>
                        </div>
                        <!-- end col-3 -->
                        <!-- begin col-3 -->
                        <div class="col-lg-3 col-md-6">
                            <div class="widget widget-stats bg-green-darker">
                                <div class="stats-icon text-white">
                                    <i class="fa fa-ticket-alt"></i>
                                </div>
                                <div class="stats-info">
                                    <h4>Reports</h4>
                                    <p>
                                        Ticketing 
                                        <br />
                                        Reports
                                    </p>
                                </div>
                                <div class="stats-link">
                                    <a href="Travel/tticketing_report.aspx">View Detail <i class="fa fa-arrow-alt-circle-right"></i></a>
                                </div>
                            </div>
                        </div>
                        <!-- end col-3 -->
                        <!-- begin col-3 -->
                        <div class="col-lg-3 col-md-6">
                            <div class="widget widget-stats bg-warning">
                                <div class="stats-icon text-white">
                                    <i class="fa fa-building"></i>
                                </div>
                                <div class="stats-info">
                                    <h4>Reports</h4>
                                    <p>
                                        Hotel
                                        <br />
                                        Reports
                                    </p>
                                </div>
                                <div class="stats-link">
                                    <a href="javascript:;">View Detail <i class="fa fa-arrow-alt-circle-right"></i></a>
                                </div>
                            </div>
                        </div>
                        <!-- end col-3 -->
                    </div>
                    <!-- end row -->
                </div>
                <!-- end tab-pane -->
            </div>
            <!-- end tab-content -->
        </div>
    </div>

    <!-- end row -->
</asp:Content>

