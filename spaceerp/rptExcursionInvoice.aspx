<%@ Page Language="C#" MasterPageFile="~/PrintMaster.master" AutoEventWireup="true" CodeFile="rptExcursionInvoice.aspx.cs" Inherits="Travel_rptExcursionInvoice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div id="content" class="content" style="color: black">
        <!-- begin breadcrumb -->
        <ol class="breadcrumb hidden-print pull-right">
            <li class="breadcrumb-item"><a href="texcursion_booking.aspx">Home</a></li>
            <li class="breadcrumb-item active">Invoice</li>
        </ol>
        <!-- end breadcrumb -->
        <!-- begin page-header -->
        
        <!-- end page-header -->

        <!-- begin invoice -->
        <div class="invoice">
            <!-- begin invoice-company -->
            <div class="invoice-company text-inverse f-w-600">
                <span class="pull-right hidden-print">
                    <a href="javascript:;" onclick="window.print()" class="btn btn-sm btn-white m-b-10 p-l-5"><i class="fa fa-file-pdf t-plus-1 text-danger fa-fw fa-lg"></i>Export as PDF</a>
                    <a href="javascript:;" onclick="window.print()" class="btn btn-sm btn-white m-b-10 p-l-5"><i class="fa fa-print t-plus-1 fa-fw fa-lg"></i>Print</a>
                </span>
                INVOICE

            </div>
            <!-- end invoice-company -->
            <!-- begin invoice-header -->
            <div class="invoice-header">
                <div class="invoice-from">
                    <small>FROM</small>
                    <address class="m-t-5 m-b-5">
                        <strong class="text-inverse">
                            <asp:Label ID="lblCompanyName" runat="server"></asp:Label></strong><br />
                        <asp:Label ID="lblAddress" runat="server"></asp:Label><br />

                        Phone:
                        <asp:Label ID="lblPhone" runat="server"></asp:Label><br />
                        Fax:
                        <asp:Label ID="lblFax" runat="server"></asp:Label><br />
                        Email:
                        <asp:Label ID="lblEmail" runat="server"></asp:Label><br />
                        Website:
                        <asp:Label ID="lblWebsite" runat="server"></asp:Label>

                    </address>
                </div>
                <div class="invoice-to">
                    <small>TO</small>
                    <address class="m-t-5 m-b-5">
                        <strong class="text-inverse">
                            <asp:Label ID="lblAgent" runat="server"></asp:Label></strong><br />
                        <asp:Label ID="lblAgentAdd" runat="server"></asp:Label><br />
                        <asp:Label ID="lblCity" runat="server"></asp:Label>,
                        <asp:Label ID="lblCountry" runat="server"></asp:Label><br />
                        Phone:
                        <asp:Label ID="lblAgentPhone" runat="server"></asp:Label><br />
                        Fax:
                        <asp:Label ID="lblAgentFax" runat="server"></asp:Label>
                        Email:
                        <asp:Label ID="lblAgentEmail" runat="server"></asp:Label><br />
                        Fax:
                        <asp:Label ID="lblAgentWebsite" runat="server"></asp:Label>

                    </address>
                </div>
                <div class="invoice-date">
                    <div class="date text-inverse m-t-5">Invoice No.: </div>

                    <div class="invoice-detail">
                        <asp:Label ID="lblBookingNo" runat="server"></asp:Label>
                    </div>
                    <div class="date text-inverse m-t-5">Date:</div>
                    <div class="invoice-detail">
                        <asp:Label ID="lblBookingDate" runat="server"></asp:Label>
                    </div>
                    <div class="date text-inverse m-t-5">GST No.:</div>
                    <div class="invoice-detail">
                        27BMXPA6006N1ZL
                    </div>

                </div>
            </div>
            <!-- end invoice-header -->
            <!-- begin invoice-content -->
            <div class="invoice-content">
                <!-- begin table-responsive -->
                <div class="table-responsive">
                    <table class="table table-bordered">
                        <thead>
                            <tr>
                                <th class="text-center">REFERENCE nO.</th>
                                <th class="text-center">GUEST NAME</th>
                                <th class="text-center" >EXCURSION TYPE</th>
                                <th class="text-center">ADULT PAX</th>
                                <th class="text-right">ADULT PAX RATE</th>
                                 <th class="text-center">CHILD PAX</th>
                                <th class="text-right">CHILD PAX RATE</th>
                                <th class="text-right">AMOUNT</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptDetails" runat="server">
                                <ItemTemplate>
                                    <tr>

                                        <td class="text-center"><%# Eval("sExcursionReferenceNo") %></td>
                                        <td class="text-center"><%# Eval("sGuestName") %></td>
                                        <td class="text-center"><%# Eval("sExcursionType") %></td>
                                        <td class="text-center"><%# Eval("nAdultPax") %></td>
                                        <td class="text-center"><%# Eval("nAdultPaxRate") %></td>
                                        <td class="text-center"><%# Eval("nChildPax") %></td>
                                         <td class="text-center"><%# Eval("nChildPaxRate") %></td>
                                        <td class="text-center"><%# Eval("nBuyCost") %></td>
                                    </tr>
                                    <tr>
                                        <td colspan="8"></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                            <tr>
                                <td colspan="7" class="text-right font-weight-bold">Service Charge
                                </td>
                                <td class="text-center font-weight-bold">
                                    <asp:Label ID="lblSc" runat="server"></asp:Label>
                                </td>

                            </tr>
                            <tr>
                                <td colspan="7" class="text-right font-weight-bold">SUB TOTAL
                                </td>
                                <td class="text-center font-weight-bold">
                                    <asp:Label ID="lblSubTot1" runat="server"></asp:Label>
                                </td>

                            </tr>
                        </tbody>
                    </table>
                </div>
                <!-- end table-responsive -->
                <!-- begin invoice-price -->
                <div class="invoice-price">
                    <div class="invoice-price-left">
                        <div class="invoice-price-row">
                            <div class="sub-price">
                                <small>SUB TOT.</small>
                                <span class="text-inverse">
                                    <asp:Label ID="lblSubTot2" runat="server"></asp:Label></span>
                            </div>
                           
                            <div class="sub-price">
                                <i class="fa fa-minus text-muted"></i>
                            </div>
                            <div class="sub-price">
                                <small>TDS</small>
                                <span class="text-inverse">
                                    <asp:Label ID="lblTds" runat="server"></asp:Label></span>
                            </div>
                            <div class="sub-price">
                                <i class="fa fa-plus text-muted"></i>
                            </div>
                            <div class="sub-price">
                                <small>CGST</small>
                                <span class="text-inverse">
                                    <asp:Label ID="lblCgst" runat="server"></asp:Label></span>
                            </div>
                            <div class="sub-price">
                                <i class="fa fa-plus text-muted"></i>
                            </div>
                            <div class="sub-price">
                                <small>SGST</small>
                                <span class="text-inverse">
                                    <asp:Label ID="lblSgst" runat="server"></asp:Label></span>
                            </div>
                            <div class="sub-price">
                                <i class="fa fa-plus text-muted"></i>
                            </div>
                            <div class="sub-price">
                                <small>IGST</small>
                                <span class="text-inverse">
                                    <asp:Label ID="lblIgst" runat="server"></asp:Label></span>
                            </div>

                            <div class="sub-price">
                                <i class="fa fa-minus text-muted"></i>
                            </div>
                            <div class="sub-price">
                                <small>DISCOUNT
                                </small>
                                <span class="text-inverse">
                                    <asp:Label ID="lblDiscount" runat="server"></asp:Label></span>
                            </div>
                            
                        </div>
                    </div>
                    <div class="invoice-price-right">
                        <small>GRAND TOTAL</small> <span class="f-w-600">
                            <asp:Label ID="lblGrandTot" runat="server"></asp:Label></span>
                    </div>
                </div>
                <!-- end invoice-price -->
                <!-- end Bank Details -->

            </div>

            <!-- end invoice-content -->
            <div class="invoice-note">
                <div class="row">
                    <div class="col-md-8">
                        <strong>Note:</strong>
                        <br />
                        * Make all cheques payable to [<asp:Label ID="lblCompany3" runat="server"></asp:Label>]<br />
                        * Payment is due within 30 days<br />
                        <%--  * If you have any questions concerning this invoice, contact [Name, Phone Number, Email]--%>
                    </div>

                    <div class="col-md-4">
                        <table class="table table-bordered">

                            <tr>
                                <td colspan="2" class="text-center">BANK DETAILS</td>
                            </tr>
                            <tr>
                                <td colspan="2" class="text-center">SPACE KNIGHTS TOURS AND TRAVELS</td>
                            </tr>
                            <tr>
                                <td>BANK NAME</td>
                                <td>INDUSLAND BANK</td>
                            </tr>
                            <tr>
                                <td>BRANCH NAME</td>
                                <td>GHATKOPER BRANCH</td>
                            </tr>
                            <tr>
                                <td>ACCOUNT NO.</td>
                                <td>201002266375</td>
                            </tr>
                            <tr>
                                <td>IFSC CODE</td>
                                <td>INDB0000152</td>
                            </tr>

                        </table>

                    </div>

                </div>
            </div>
            <!-- begin invoice-note -->

            <!-- end invoice-note -->
            <!-- begin invoice-footer -->
            <div class="invoice-footer">
                <p class="text-center m-b-5 f-w-600">
                    THANK YOU FOR YOUR BUSINESS
                   
                </p>
                <p class="text-center">
                    <span class="m-r-10"><i class="fa fa-fw fa-lg fa-globe"></i><asp:Label ID="lblComWebsite2" runat="server"></asp:Label></span>
                    <span class="m-r-10"><i class="fa fa-fw fa-lg fa-phone-volume"></i><asp:Label ID="lblComPhone2" runat="server"></asp:Label></span>
                    <span class="m-r-10"><i class="fa fa-fw fa-lg fa-envelope"></i><asp:Label ID="lblComEmail2" runat="server"></asp:Label></span>
                </p>
            </div>
            <!-- end invoice-footer -->
        </div>
        <!-- end invoice -->
    </div>
</asp:Content>
