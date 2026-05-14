<%@ Page Title="" Language="C#" MasterPageFile="~/PrintMaster.master" AutoEventWireup="true" CodeFile="ttravelexpense_invoice.aspx.cs" Inherits="ttravel_expense_invoice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../assets/css/default/invoice-print.min.css" rel="stylesheet" />
    <link href="../assets/css/default/mystyle.css" rel="stylesheet" />
    <style>
        .pagebg {
            max-width: 800px;
            display: block;
            margin-left: auto;
            margin-right: auto;
            border: 1px solid #21212b;
            padding: 5px;
        }

        .quotebg {
            position: relative;
            text-align: center;
            color: white;
        }

        tr.bg-grandTtl td {
            background: #21212b;
            color: white;
        }

        .quotebg img {
            height: 70px;
            width: 100%;
        }

        .quoteimg {
            height: 72px;
        }

        .quotbg {
            background: #21212b;
            color: white;
            padding: 5px;
            width: auto;
            text-align: center;
            margin: 5px 0;
        }

        .table thead th {
            vertical-align: bottom;
            border-bottom: 2px solid #dee2e6;
            background: #21212b;
            color: white;
        }

        .table th {
            vertical-align: bottom;
            border-bottom: 2px solid #dee2e6;
            background: #21212b;
            color: white;
        }

        #ctl00_ContentPlaceHolder1_GridView1 tbody tr:nth-child(even) {
            background-color: #f2f2f2;
        }

        .table > thead > tr > th {
            padding: 0px 5px !important;
        }

        .table > tbody > tr > td {
            padding: 0px 5px !important;
        }

        .table td, .table th {
            padding: 5px;
        }

        .row {
            margin: 0px 0px;
        }

        .centered {
            position: absolute;
            top: 50%;
            left: 50%;
            transform: translate(-50%, -50%);
            margin-top: 0px;
        }

        .totals {
            display: inline-block;
            width: 100%;
        }

        .col-md-6 {
            float: left;
            padding: 0px;
            width: 50%;
        }

        @media print {
            body {
                -webkit-print-color-adjust: exact;
            }

            .quotebg {
                position: relative !important;
                text-align: center !important;
                color: white !important;
            }

            .centered {
                position: absolute !important;
                top: 50% !important;
                left: 50% !important;
                transform: translate(-50%, -50%);
                margin-top: 0px !important;
            }

                .centered span {
                    color: white !important;
                }

            .table {
                border: 1px solid #21212b;
            }

                .table thead th {
                    vertical-align: bottom;
                    border-bottom: 2px solid #dee2e6;
                    background: #21212b !important;
                    color: white !important;
                }

                .table th {
                    vertical-align: bottom;
                    border-bottom: 2px solid #dee2e6;
                    background: #21212b !important;
                    color: white;
                }

            h1 span {
                font-size: 30px;
            }

            tr.bg-grandTtl td {
                background: #21212b !important;
                color: white !important;
            }
        }

        .table {
            border: 1px solid #21212b;
        }

        h1 span {
            font-size: 30px;
        }

        .h1, h1 {
            font-size: 1rem !important;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <div class="pagebg">
        <div class="row nopad">
            <div class="col-md-5">
                <img src="../assetss/images/logo.png" class="quoteimg" />

                <!-- begin invoice-company -->
                <div class="invoice-company text-inverse f-w-600">
                    <span class="pull-left hidden-print">
                        <a href="ttravel_expense_voucher.aspx" class="btn btn-sm btn-white m-b-10 p-l-5"><i class="fa fa-angle-double-left t-plus-1 fa-fw fa-lg"></i>Back</a>
                       <a href="javascript:;" onclick="window.print()" class="btn btn-sm btn-white m-b-10 p-l-5"><i class="fa fa-print t-plus-1 fa-fw fa-lg"></i>Print</a>
                    </span>


                </div>
                <!-- end invoice-company -->
            </div>
            <div class="col-md-7">
                <div class="quotebg">
                    <img src="../assetss/images/Quotebg.png" />
                    <h1 class="centered">
                        <span>Invoice</span></h1>
                </div>
                <div class="date quotbg text-inverse m-t-5">
                    Booking No.
                        <small>
                            <asp:Label ID="lblBookingNo" runat="server"></asp:Label> (
                            <asp:Label ID="lblBookDate" runat="server"></asp:Label>)
                        </small>
                </div>
            </div>
        </div>
        <!-- begin invoice-company -->
        <!-- begin invoice -->
        <!-- begin invoice-company -->
        <div class="invoice-content">
            <!-- begin table-responsive -->
            <div class="table-responsive bg-white">
                <table class="table table-invoice" cellspacing="0" rules="all" border="1" style="width: 100%; border-collapse: collapse;">
                    <thead>
                        <tr>
                            <th scope="col">Billing Address</th>
                            <th scope="col">Shipping Address</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td><strong class="text-inverse">
                                <asp:Label ID="lblCompanyName" runat="server"></asp:Label></strong></td>
                            <td><strong>
                                <asp:Label ID="lblCompanyName1" runat="server"></asp:Label></strong></td>

                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblcompanyAdd" runat="server"></asp:Label></td>
                            <td>D-1234 Okhla Industrial Area</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblCity" runat="server"></asp:Label>,
                    <asp:Label ID="lblCountry" runat="server"></asp:Label></td>
                            <td>New Delhi-1120</td>
                        </tr>
                        <tr>
                            <td>Phone:
                    <asp:Label ID="lblPhone" runat="server"></asp:Label>,                    
                    Fax:
                    <asp:Label ID="lblFax" runat="server"></asp:Label>
                                Email:
                    
                    <asp:Label ID="lblEmail" runat="server"></asp:Label></td>
                            <td>Phone:</td>
                        </tr>

                        <tr>
                            <td>GSTIN :</td>
                            <td>GSTIN :</td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    <!-- begin invoice -->
    <div class="invoice">       
        <div class="invoice-content">
            <!-- begin table-responsive -->
            <div class="table-responsive">
                <asp:GridView ID="GridView1" CssClass="table table-invoice" runat="server"
                    AutoGenerateColumns="False" EmptyDataText="No Records to display" DataKeyNames="nTravelExpenseVoucherDetID"
                    Width="100%" AllowPaging="true" AllowSorting="True" PageSize="25">
                    <Columns>
                        <asp:TemplateField HeaderText="nTravelExpenseVoucherDetID" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblID" runat="server" Text='<%# Eval("nTravelExpenseVoucherDetID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:BoundField DataField="sDriverName" HeaderText="Driver Name" />
                        <asp:BoundField DataField="sVehicleNo" HeaderText="Vehicle No" />
                         <asp:BoundField DataField="sDescription" HeaderText="Description" />
                        <asp:BoundField DataField="sExpenseCat" HeaderText="Expense Category" />
                        <asp:BoundField DataField="nAmount" HeaderText="Amount" />
                    </Columns>
                </asp:GridView>
             
            </div>
            <!-- end table-responsive -->
            <!-- begin invoice-price -->
            <div class="totals">
                    <div class="col-md-6">
                        <div class="invoice-note">
                            <strong>Note:</strong><br />
            * Make all cheques payable to [<asp:Label ID="lblCompanyName2" runat="server"></asp:Label>]<br />
            * Payment is due within 30 days<br />
            * If you have any questions concerning this invoice, contact  [<asp:Label ID="lblphone2" runat="server"></asp:Label>,
            <asp:Label ID="lblemail2" runat="server"></asp:Label>]
               
        </div>
                        THANK YOU FOR YOUR BUSINESS!!
                    </div>
                    <div class="col-md-6">
                        <table class="table table-hover m-t-20 text-inverse">
                            <thead>
                                <tr>

                                    <th>Details</th>
                                    <th>Amount</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>SUB TOTAL</td>
                                    <td>
                                        <asp:Label ID="lblSubTot" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>TAX (+)</td>
                                    <td>
                                        <asp:Label ID="lblTaxTot" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>DISCOUNT (-)</td>
                                    <td>
                                        <asp:Label ID="lblDiscTot" runat="server"></asp:Label></td>
                                </tr>
                                <tr class="bg-grandTtl">
                                    <td>GRAND TOTAL</td>
                                    <td>
                                        <asp:Label ID="lblGrandtotal" runat="server"></asp:Label></td>
                                </tr>
                            </tbody>
                        </table>


                    </div>

                </div>
            
            <!-- end invoice-price -->
        </div>
        <!-- end invoice-content -->
        <!-- begin invoice-note -->
        
        <!-- end invoice-note -->
    </div>
    <!-- end invoice -->
    </div>
</asp:Content>

