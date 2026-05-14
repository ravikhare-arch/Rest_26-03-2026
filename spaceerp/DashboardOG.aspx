<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="DashboardOG.aspx.cs" Inherits="Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="vmsg" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="vtitle" runat="Server">
    Dashboard
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- begin col-12 -->
    <div class="col-lg-12">
        <!-- begin #accordion -->
        <div id="accordion" class="card-accordion">
            <!-- begin card -->
            <div class="card">
                <div class="card-header bg-black text-white pointer-cursor" data-toggle="collapse" data-target="#collapseOne">
                    ACCOUNTING MODULES
               
                </div>
                <div id="collapseOne" class="collapse" data-parent="#accordion">
                    <div class="card-body">
                        <div class="row">
                            <!-- begin col-3 -->
                            <div class="col-lg-3 col-md-6">

                                <div class="widget widget-stats bg-red-darker ">
                                    <a href="Masters/maccount_sub.aspx">
                                        <div class="stats-icon text-white"><i class="fa fa-desktop"></i></div>
                                        <div class="stats-info">
                                            <h4>Sub Accounts</h4>
                                            <p>
                                                Sub
                                                <br />
                                                Accounts
                                            </p>
                                        </div>
                                    </a>
                                    <div class="stats-link">
                                        <a href="Masters/maccount_sub.aspx">View Detail <i class="fa fa-arrow-alt-circle-right"></i></a>
                                    </div>

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
                                            <p>
                                                Chart of<br />
                                                Accounts
                                            </p>
                                        </div>
                                    </a>
                                    <div class="stats-link">
                                        <a href="Accounting/tchartof_account.aspx">View Detail <i class="fa fa-arrow-alt-circle-right"></i></a>
                                    </div>

                                </div>
                            </div>
                            <!-- end col-3 -->
                            <!-- begin col-3 -->
                            <div class="col-lg-3 col-md-6">
                                <div class="widget widget-stats bg-blue-darker">
                                    <a href="Accounting/mclient_master.aspx">
                                        <div class="stats-icon text-white"><i class="fa fa-user"></i></div>
                                        <div class="stats-info">
                                            <h4>Add Client</h4>
                                            <p>
                                                Add<br />
                                                Client
                                            </p>
                                        </div>
                                    </a>
                                    <div class="stats-link">
                                        <a href="Accounting/mclient_master.aspx">View Detail <i class="fa fa-arrow-alt-circle-right"></i></a>
                                    </div>

                                </div>
                            </div>
                            <!-- end col-3 -->
                            <!-- begin col-3 -->
                            <div class="col-lg-3 col-md-6">
                                <div class="widget widget-stats bg-blue-darker">
                                    <a href="Accounting/msupplier_master.aspx">
                                        <div class="stats-icon text-white"><i class="fa fa-user"></i></div>
                                        <div class="stats-info">
                                            <h4>Add Supplier</h4>
                                            <p>
                                                Add<br />
                                                Supplier
                                            </p>
                                        </div>
                                    </a>
                                    <div class="stats-link">
                                        <a href="Accounting/msupplier_master.aspx">View Detail <i class="fa fa-arrow-alt-circle-right"></i></a>
                                    </div>

                                </div>
                            </div>
                            <!-- end col-3 -->
                            <!-- begin col-3 -->
                            <div class="col-lg-3 col-md-6">
                                <div class="widget widget-stats bg-blue-darker">
                                    <a href="Masters/magent_assign.aspx">
                                        <div class="stats-icon text-white"><i class="fa fa-user"></i></div>
                                        <div class="stats-info">
                                            <h4>Agent Assign</h4>
                                            <p>
                                                Agent<br />
                                                Assign
                                            </p>
                                        </div>
                                    </a>
                                    <div class="stats-link">
                                        <a href="Masters/magent_assign.aspx">View Detail <i class="fa fa-arrow-alt-circle-right"></i></a>
                                    </div>

                                </div>
                            </div>
                            <!-- end col-3 -->
                            <!-- begin col-3 -->
                            <div class="col-lg-3 col-md-6">
                                <div class="widget widget-stats bg-blue-darker">
                                    <a href="Accounting/mbank_master.aspx">
                                        <div class="stats-icon text-white"><i class="fa fa-user"></i></div>
                                        <div class="stats-info">
                                            <h4>ADD BANK</h4>
                                            <p>
                                                BANK<br />
                                                MASTER
                                            </p>
                                        </div>
                                    </a>
                                    <div class="stats-link">
                                        <a href="Accounting/mbank_master.aspx">View Detail <i class="fa fa-arrow-alt-circle-right"></i></a>
                                    </div>

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
                                            <p>
                                                Payment<br />
                                                Voucher
                                            </p>
                                        </div>
                                    </a>
                                    <div class="stats-link">
                                        <a href="Accounting/tpayment_voucher.aspx">View Detail <i class="fa fa-arrow-alt-circle-right"></i></a>
                                    </div>

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
                                            <p>
                                                Reciept
                                                <br />
                                                Vouchers
                                            </p>
                                        </div>
                                    </a>
                                    <div class="stats-link">
                                        <a href="Accounting/treceipt_voucher.aspx">View Detail <i class="fa fa-arrow-alt-circle-right"></i></a>
                                    </div>

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
                                            <p>
                                                Journal
                                                <br />
                                                Vouchers
                                            </p>
                                        </div>
                                    </a>
                                    <div class="stats-link">
                                        <a href="Accounting/tacc_journal_voucher.aspx">View Detail <i class="fa fa-arrow-alt-circle-right"></i></a>
                                    </div>

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
                                            <p>
                                                PDC/PDCR
                                                <br />
                                                VOUCHER
                                            </p>
                                        </div>
                                    </a>
                                    <div class="stats-link">
                                        <a href="Accounting/tpdc_voucher.aspx">View Detail <i class="fa fa-arrow-alt-circle-right"></i></a>
                                    </div>

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
                                            <p>
                                                Posted
                                                <br />
                                                Vouchers
                                            </p>
                                        </div>
                                    </a>
                                    <div class="stats-link">
                                        <a href="Accounting/tpostedvoucher.aspx">View Detail <i class="fa fa-arrow-alt-circle-right"></i></a>
                                    </div>

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
                                            <p>
                                                General
                                                <br />
                                                Ledger
                                            </p>
                                        </div>
                                    </a>
                                    <div class="stats-link">
                                        <a href="Accounting/tgeneral_ledger.aspx">View Detail <i class="fa fa-arrow-alt-circle-right"></i></a>
                                    </div>

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
                                            <p>
                                                Profit & Loss
                                                <br />
                                                Reports
                                            </p>
                                        </div>
                                    </a>
                                    <div class="stats-link">
                                        <a href="Accounting/tprofit_loss.aspx">View Detail <i class="fa fa-arrow-alt-circle-right"></i></a>
                                    </div>

                                </div>
                            </div>


                            <!-- begin col-3 -->
                            <div class="col-lg-3 col-md-6">
                                <div class="widget widget-stats bg-blue-darker">
                                    <a href="Accounting/tpay_receivables.aspx">
                                        <div class="stats-icon text-white"><i class="fa fa-handshake"></i></div>
                                        <div class="stats-info">
                                            <h4>Payables Reports</h4>
                                            <p>
                                                Payables<br />
                                                Receivables
                                            </p>
                                        </div>
                                    </a>
                                    <div class="stats-link">
                                        <a href="Accounting/tpay_receivables.aspx">View Detail <i class="fa fa-arrow-alt-circle-right"></i></a>
                                    </div>

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
                                            <p>
                                                Trial Balance<br />
                                                Reports
                                            </p>
                                        </div>
                                    </a>
                                    <div class="stats-link">
                                        <a href="Accounting/ttrailbalance.aspx">View Detail <i class="fa fa-arrow-alt-circle-right"></i></a>
                                    </div>

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
                                    </a>
                                    <div class="stats-link">
                                        <a href="Accounting/tbalancesheet.aspx">View Detail <i class="fa fa-arrow-alt-circle-right"></i></a>
                                    </div>

                                </div>
                            </div>
                            <!-- end col-3 -->

                        </div>
                    </div>
                </div>
            </div>
            <!-- end card -->
            <!-- begin card -->

            <!-- end card -->
            <!-- begin card -->
            <div class="card">
                <div class="card-header bg-black text-white pointer-cursor collapsed" data-toggle="collapse" data-target="#collapseThree">
                    TRAVEL MODULES
						
                </div>
                <div id="collapseThree" class="collapse" data-parent="#accordion">
                    <div class="card-body">
                        <!-- begin row -->
                        <div class="row">

                            <!-- begin col-3 -->
                            <div class="col-lg-3 col-md-6">
                                <div class="widget widget-stats bg-red-darker">
                                    <a href="Travel/tvisa.aspx">
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
                                    </a>
                                    <div class="stats-link">
                                        <a href="Travel/tvisa.aspx">View Detail <i class="fa fa-arrow-alt-circle-right"></i></a>
                                    </div>

                                </div>
                            </div>
                            <!-- end col-3 -->
                            <!-- begin col-3 -->
                            <div class="col-lg-3 col-md-6">
                                <div class="widget widget-stats bg-blue-darker">
                                    <a href="Travel/tticketing.aspx">
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
                                    </a>
                                    <div class="stats-link">
                                        <a href="Travel/tticketing.aspx">View Detail <i class="fa fa-arrow-alt-circle-right"></i></a>
                                    </div>

                                </div>
                            </div>
                            <!-- end col-3 -->
                            <!-- begin col-3 -->
                            <div class="col-lg-3 col-md-6">
                                <div class="widget widget-stats bg-green-darker">
                                    <a href="Travel/thotel.aspx">
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
                                    </a>
                                    <div class="stats-link">
                                        <a href="Travel/thotel.aspx">View Detail <i class="fa fa-arrow-alt-circle-right"></i></a>
                                    </div>

                                </div>
                            </div>
                            <!-- end col-3 -->
                            <!-- begin col-3 -->
                            <div class="col-lg-3 col-md-6">
                                <div class="widget widget-stats bg-warning">
                                    <a href="Travel/texcursion_booking.aspx">
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
                                    </a>
                                    <div class="stats-link">
                                        <a href="Travel/texcursion_booking.aspx">View Detail <i class="fa fa-arrow-alt-circle-right"></i></a>
                                    </div>

                                </div>
                            </div>
                            <!-- end col-3 -->
                            <!-- begin col-3 -->
                            <div class="col-lg-3 col-md-6">
                                <div class="widget widget-stats bg-red-darker">
                                    <a href="Travel/tmofa_booking.aspx">
                                        <div class="stats-icon text-white">
                                            <i class="fa fa-tasks"></i>
                                        </div>
                                        <div class="stats-info">
                                            <h4>Umrah Mofa</h4>
                                            <p>
                                                Umrah<br />
                                                Mofa
                                            </p>
                                        </div>
                                    </a>
                                    <div class="stats-link">
                                        <a href="Travel/tmofa_booking.aspx">View Detail <i class="fa fa-arrow-alt-circle-right"></i></a>
                                    </div>
                                </div>
                            </div>
                            <!-- end col-3 -->

                            <!-- begin col-3 -->
                            <div class="col-lg-3 col-md-6">
                                <div class="widget widget-stats bg-green-darker">
                                    <a href="Travel/tmofa_recruitement.aspx">
                                        <div class="stats-icon text-white">
                                            <i class="fa fa-ticket-alt"></i>
                                        </div>
                                        <div class="stats-info">
                                            <h4>Recruitement</h4>
                                            <p>
                                                Recruitement 
                                        <br />
                                                Entries
                                            </p>
                                        </div>
                                    </a>
                                    <div class="stats-link">
                                        <a href="Travel/tmofa_recruitement.aspx">View Detail <i class="fa fa-arrow-alt-circle-right"></i></a>
                                    </div>
                                </div>
                            </div>
                            <!-- end col-3 -->
                            <!-- begin col-3 -->
                            <div class="col-lg-3 col-md-6">
                                <div class="widget widget-stats bg-blue-darker">
                                    <a href="Travel/tinsurance_booking.aspx">
                                        <div class="stats-icon text-white">
                                            <i class="fa fa-sliders-h"></i>
                                        </div>
                                        <div class="stats-info">
                                            <h4>Insurance </h4>
                                            <p>
                                                Insurance
                                                <br />
                                                Entries
                                            </p>
                                        </div>
                                    </a>
                                    <div class="stats-link">
                                        <a href="Travel/tinsurance_booking.aspx">View Detail <i class="fa fa-arrow-alt-circle-right"></i></a>
                                    </div>

                                </div>
                            </div>
                            <!-- end col-3 -->
                            <!-- begin col-3 -->
                            <div class="col-lg-3 col-md-6">
                                <div class="widget widget-stats bg-warning">
                                    <a href="Travel/ttrain_booking.aspx">
                                        <div class="stats-icon text-white">
                                            <i class="fa fa-building"></i>
                                        </div>
                                        <div class="stats-info">
                                            <h4>Train Tickets</h4>
                                            <p>
                                                Train
                                        <br />
                                                Tickets
                                            </p>
                                        </div>
                                    </a>

                                    <div class="stats-link">
                                        <a href="Travel/ttrain_booking.aspx">View Detail <i class="fa fa-arrow-alt-circle-right"></i></a>
                                    </div>
                                </div>
                            </div>
                            <!-- end col-3 -->

                            <!-- begin col-3 -->
                            <div class="col-lg-3 col-md-6">
                                <div class="widget widget-stats bg-red-darker">
                                    <a href="Travel/tbus_booking.aspx">
                                        <div class="stats-icon text-white">
                                            <i class="fa fa-building"></i>
                                        </div>
                                        <div class="stats-info">
                                            <h4>Bus Tickets</h4>
                                            <p>
                                                Bus
                                        <br />
                                                Tickets
                                            </p>
                                        </div>
                                    </a>

                                    <div class="stats-link">
                                        <a href="Travel/tbus_booking.aspx">View Detail <i class="fa fa-arrow-alt-circle-right"></i></a>
                                    </div>
                                </div>
                            </div>
                            <!-- end col-3 -->

                            <!-- begin col-3 -->
                            <div class="col-lg-3 col-md-6">
                                <div class="widget widget-stats bg-blue-darker">
                                    <a href="Travel/tcar_booking.aspx">
                                        <div class="stats-icon text-white">
                                            <i class="fa fa-building"></i>
                                        </div>
                                        <div class="stats-info">
                                            <h4>Car Booking </h4>
                                            <p>
                                                Car
                                        <br />
                                                Booking
                                            </p>
                                        </div>
                                    </a>

                                    <div class="stats-link">
                                        <a href="Travel/tcar_booking.aspx">View Detail <i class="fa fa-arrow-alt-circle-right"></i></a>
                                    </div>
                                </div>
                            </div>
                            <!-- end col-3 -->

                            <!-- begin col-3 -->
                            <div class="col-lg-3 col-md-6">
                                <div class="widget widget-stats  bg-green-darker">
                                    <a href="Travel/ttravel_expense_voucher.aspx">
                                        <div class="stats-icon text-white">
                                            <i class="fa fa-building"></i>
                                        </div>
                                        <div class="stats-info">
                                            <h4>Travel Expense Voucher</h4>
                                            <p>
                                                Expense
                                        <br />
                                                Voucher
                                            </p>
                                        </div>
                                    </a>

                                    <div class="stats-link">
                                        <a href="Travel/ttravel_expense_voucher.aspx">View Detail <i class="fa fa-arrow-alt-circle-right"></i></a>
                                    </div>
                                </div>
                            </div>
                            <!-- end col-3 -->
                        </div>
                        <!-- end row -->
                    </div>
                </div>
            </div>
            <!-- end card -->

        </div>
        <!-- end #accordion -->
    </div>
    <!-- end col-6 -->
</asp:Content>

