<%@ Page Title="" Language="C#" MasterPageFile="~/PrintMaster.master" AutoEventWireup="true" CodeFile="rptsalesinvoice.aspx.cs" Inherits="Tradding_rptso" %>

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
        h1 span{
            font-size:32px;
            margin-top: 0px;
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

            .table thead th {
                vertical-align: bottom;
                border-bottom: 2px solid #dee2e6;
                background: #21212b !important;
                color: white !important;
            }

            tr.bg-grandTtl td {
                background: #21212b !important;
                color: white !important;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="pagebg">
        <div class="row nopad">
            <div class="col-md-6">
                <img src="../assetss/images/logo.png" class="quoteimg" />

                <!-- begin invoice-company -->
                <div class="invoice-company text-inverse f-w-600">
                    <span class="pull-left hidden-print">
                 <a  href="tsalesorder.aspx" class="btn btn-sm btn-white m-b-10 p-l-5"><i class="fa fa-angle-double-left t-plus-1 fa-fw fa-lg"></i>Back</a>
                <a href="javascript:;" onclick="window.print()" class="btn btn-sm btn-white m-b-10 p-l-5"><i class="fa fa-print t-plus-1 fa-fw fa-lg"></i>Print</a>
            </span>


                </div>
                <!-- end invoice-company -->
            </div>
            <div class="col-md-6">
                <div class="quotebg">
                    <img src="../assetss/images/Quotebg.png" />
                    <h1 class="centered">
                            <asp:Label ID="lblVoucherType" runat="server" Text="Sales Invoice"></asp:Label></h1>
                </div>
                <div class="date quotbg text-inverse m-t-5">
                    Sales Invoice No.
                        <small>
                            <asp:Label ID="lblSONo" runat="server"></asp:Label>/ <asp:Label ID="lblDate" runat="server"></asp:Label>
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
                                    <asp:Label ID="lblCity" runat="server"></asp:Label>, <asp:Label ID="lblCountry" runat="server"></asp:Label></td>
                                <td>New Delhi-1120</td>
                            </tr>
                            <tr>
                                <td>Phone:
                    <asp:Label ID="lblPhone" runat="server"></asp:Label>,
                    Fax:
                     <asp:Label ID="lblFax" runat="server"></asp:Label>
                                    Email:
                    <asp:Label ID="lblEmail" runat="server"></asp:Label>
                                    Website:
                    <asp:Label ID="lblWebsite" runat="server"></asp:Label></td>
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
    <div class="invoice">
        <!-- begin invoice-content -->
        <div class="invoice-content">
            <!-- begin table-responsive -->
            <div class="table-responsive bg-white">
                <asp:GridView ID="GridView1" CssClass="table table-invoice" runat="server"
                    AutoGenerateColumns="False" EmptyDataText="No Records to display" DataKeyNames="nSoinvoiceDetID"
                    Width="100%" AllowPaging="true" AllowSorting="True" PageSize="25">
                    <Columns>
                        <asp:TemplateField HeaderText="nSoinvoiceDetID" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblID" runat="server" Text='<%# Eval("nSoinvoiceDetID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="sItemName" HeaderText="Item Name" />
                        <asp:BoundField DataField="sItemUnit" HeaderText="Item Unit" />
                        <asp:BoundField DataField="nQuantity" HeaderText="Quantity" />
                        <asp:BoundField DataField="nUnitPrice" HeaderText="Unit Price" />
                        <asp:BoundField DataField="sTaxName" HeaderText="Tax Name" />
                        <asp:BoundField DataField="nTaxableAmount" HeaderText="Tax Amount" />
                        <asp:BoundField DataField="nTotPrice" HeaderText="Total Price" />
                    </Columns>
                </asp:GridView>

            </div>
            <!-- end table-responsive -->
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
                                <td>SUB TOTAL BEFORE TAX</td>
                                <td>
                                    <asp:Label ID="lblSubTot" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>DISCOUNT (-)</td>
                                <td>
                                    <asp:Label ID="lblDiscount" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>SHIPPING & PACKAGING COST</td>
                                <td>
                                    <asp:Label ID="lblShippingCost" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>OTHER COST</td>
                                <td>
                                    <asp:Label ID="lblOtherCost" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>TOTAL TAX AMOUNT</td>
                                <td>
                                    <asp:Label ID="lblTotalTax" runat="server"></asp:Label></td>
                            </tr>
                            <tr class="bg-grey-lighter font-weight-bold">
                                <td>GRAND TOTAL</td>
                                <td>
                                    <asp:Label ID="lblGrandtotal" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>TOTAL PAID(-)</td>
                                <td>
                                    <asp:Label ID="lblTotPaid" runat="server"></asp:Label></td>
                            </tr>
                            <tr class="bg-grey-lighter font-weight-bold">
                                <td>TOTAL BALANCE</td>
                                <td>
                                    <asp:Label ID="lblBalance" runat="server"></asp:Label></td>
                            </tr>
                        </tbody>
                    </table>


                </div>

            </div>
            <!-- end invoice-price -->
        </div>
        <!-- end invoice-content -->
        <!-- begin Cashier -->
        <div class="row">
            <div class="col-12 p-40">
                <div class="row">
                    <div class="col-4" style="border-top: 1px solid #18558a; padding-top: 5px; margin-top: 40px; text-align: center">
                        Company Name & Stamp
                    </div>

                </div>

            </div>

        </div>
        <!-- end Cashier -->
        <!-- begin invoice-note -->
        <%-- <div class="invoice-note">
            * Make all cheques payable to [<asp:Label ID="lblCompanyName2" runat="server"></asp:Label>]<br />
            * Payment is due within 30 days<br />
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

