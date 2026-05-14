<%@ Page Language="C#" MasterPageFile="~/PrintMaster.master" AutoEventWireup="true" CodeFile="rptTicketRefund_Invoice.aspx.cs" Inherits="Travel_rptTicketInvoice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function printpage() {
            //Get the print button and put it into a variable
            var printButton = document.getElementById("btnprint");
            var topLink = document.getElementById("tplink");
            var pdfButton = document.getElementById("btnpdf");
            var ExcelButton = document.getElementById("<%=btnExcel.ClientID %>");
            var EmailButton = document.getElementById("<%=btnSendMail.ClientID %>");
            //Set the print button visibility to 'hidden' 
            printButton.style.visibility = 'hidden';
            topLink.style.visibility = 'hidden';
            pdfButton.style.visibility = 'hidden';
            ExcelButton.style.visibility = 'hidden';
            EmailButton.style.visibility = 'hidden';
            //Print the page content
            window.print()
            //Set the print button to 'visible' again 
            //[Delete this line if you want it to stay hidden after printing]
            printButton.style.visibility = 'visible';
            topLink.style.visibility = 'visible';
            pdfButton.style.visibility = 'visible';
            ExcelButton.style.visibility = 'visible';
            EmailButton.style.visibility = 'visible';
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div id="content" class="content" style="color: black">
        <!-- begin breadcrumb -->
        <div class="row">
            <div class="col-md-6">
            </div>
            <div class="col-md-6">
                <ol class="breadcrumb hidden-print pull-right" id="tplink">
                    <li class="breadcrumb-item"><a href="tticketing.aspx">Home</a></li>
                    <li class="breadcrumb-item active">Refund</li>
                </ol>
            </div>
        </div>
        <!-- end breadcrumb -->
        <!-- begin page-header -->
        <%-- <h1 class="page-header hidden-print">Invoice <small>Air Tickets...</small></h1>--%>
        <!-- end page-header -->

        <!-- begin invoice -->
        <div class="invoice" id="invoice" runat="server">
            <table style="width: 100%">
                <tr>
                    <td class="text-center float-left" style="width: 50%; text-decoration: underline; margin-bottom: 25px;" colspan="6">
                        <div class="text-right">
                            <h3 style="text-decoration: underline">INVOICE </h3>
                        </div>
                    </td>
                    <td class="float-right" style="width: 50%" colspan="6">
                        <div class="pull-right hidden-print" id="hidePrint" runat="server">
                            <a href="javascript:;" onclick="printpage()" class="btn btn-sm btn-white m-b-10 p-l-5" id="btnpdf"><i class="fa fa-file-pdf t-plus-1 text-danger fa-fw fa-lg"></i>Export as PDF</a>
                            <a href="javascript:;" onclick="printpage()" class="btn btn-sm btn-warning m-b-10 p-l-5" id="btnprint"><i class="fa fa-print t-plus-1 fa-fw fa-lg"></i>Print</a>


                            <asp:Button ID="btnExcel" runat="server" Text="Excel" CssClass="btn btn-sm btn-success m-b-10 p-l-5 " OnClick="btnExcel_Click" />
                            <asp:Button ID="btnSendMail" runat="server" Text="Email" CssClass="btn btn-sm btn-primary m-b-10 p-l-5" OnClick="btnSendMail_Click" />
                        </div>
                    </td>
                </tr>
            </table>
            <!-- end invoice-company -->
            <!-- begin invoice-header -->
            <div class="invoice-header">
                <table style="margin-bottom: 30px">
                    <tr>
                        <td colspan="4" style="width: 35%">

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


                        </td>

                        <td colspan="4" style="width: 35%">

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

                        </td>

                        <td colspan="4" class="float-right" style="width: 30%">

                            <div class="text-black m-t-5">
                                <b>Invoice No.</b>: 
                                <asp:Label ID="lblBookingNo" runat="server"></asp:Label>
                            </div>

                            <div class="invoice-detail">
                            </div>
                            <div class="date text-inverse m-t-15">
                                <b>Date</b> : 
                                <asp:Label ID="lblBookingDate" runat="server"></asp:Label>
                            </div>
                            <div class="invoice-detail">
                            </div>
                            <div class="date text-inverse m-t-15"><b>GST No.</b> : 27BMXPA6006N1ZL</div>


                        </td>
                    </tr>
                </table>
                <br />
            </div>
            <!-- end invoice-header -->
            <!-- begin invoice-content -->
            <div class="invoice-content">
                <!-- begin table-responsive -->
                <div class="table-responsive">
                    <table style="border: 1px; width: 99%; margin-bottom: 30px; color: black;">

                        <tr style="background-color: #1c3967; color: white; height: 40px; text-align: center;">
                            <th class="text-center" colspan="2">TICKET NO</th>
                            <th class="text-center" colspan="2">PASSENGER NAME</th>
                            <th class="text-center" colspan="2">SECTOR</th>
                            <th class="text-center" colspan="4">FLIGHT DETAILS</th>
                            <th class="text-center" colspan="2">FARE AMOUNT</th>
                        </tr>
                        <asp:Repeater ID="rptDetails" runat="server">
                            <ItemTemplate>
                                <tr style="height: 40px; text-align: center; padding: 10px; border: 1px solid black">
                                    <td class="text-center" colspan="2"><%# Eval("sTicketPNR") %></td>
                                    <td class="text-center" colspan="2"><%# Eval("sCustomerName") %></td>
                                    <td class="text-center" colspan="2"><%# Eval("sSector") %> </td>
                                    <td class="text-center" colspan="4"><%# Eval("sFlightDetails") %></td>
                                    <td class="text-center" colspan="2"><%# Eval("nBuyingCost") %></td>
                                </tr>

                            </ItemTemplate>
                        </asp:Repeater>
                        <tr style="height: 40px; text-align: center; padding: 10px; border: 1px solid black">
                            <td colspan="10" class="text-right font-weight-bold">Service Charge
                            </td>
                            <td class="text-center font-weight-bold" colspan="2">
                                <asp:Label ID="lblSc" runat="server"></asp:Label>
                            </td>

                        </tr>
                        <tr style="height: 40px; text-align: center; padding: 10px; border: 1px solid black">
                            <td colspan="10" class="text-right font-weight-bold">SUB TOTAL
                            </td>
                            <td class="text-center font-weight-bold" colspan="2">
                                <asp:Label ID="lblSubTot1" runat="server"></asp:Label>
                            </td>

                        </tr>
                    </table>
                    

                    <!-- end invoice-price -->
                </div>
                <!-- end table-responsive -->
                <!-- begin invoice-price -->
             
                    <table style="border: 1px; width: 99%; margin-bottom: 30px; color: black;">
                        <tr style="background-color: #f2f2f2; height: 80px">
                            <td style="padding-left: 10px;">
                                <small>SUB TOT.</small><br />
                                <span class="text-inverse">
                                    <asp:Label ID="lblSubTot2" runat="server"></asp:Label></span>
                            </td>
                            <td>
                                <i class="fa fa-minus text-muted"></i>
                            </td>
                            <td>

                                <small>DISCOUNT      </small>
                                <br />
                                <span class="text-inverse">
                                    <asp:Label ID="lblDiscount" runat="server"></asp:Label></span>
                            </td>
                            <td>
                                <i class="fa fa-minus text-muted"></i>
                            </td>
                            <td>
                                <small>TDS</small><br />
                                <span class="text-inverse">

                                    <asp:Label ID="lblTds" runat="server"></asp:Label></span>
                            </td>
                            <td>
                                <i class="fa fa-plus text-muted"></i>
                            </td>
                            <td>
                                <small>CGST</small>
                                <span class="text-inverse">
                                    <br />
                                    <asp:Label ID="lblCgst" runat="server"></asp:Label></span>
                            </td>
                            <td>
                                <i class="fa fa-plus text-muted"></i>
                            </td>
                            <td>
                                <small>SGST</small><br />
                                <span class="text-inverse">
                                    <asp:Label ID="lblSgst" runat="server"></asp:Label></span>
                            </td>
                            <td>
                                <i class="fa fa-plus text-muted"></i>
                            </td>
                            <td>
                                <small>IGST</small>
                                <span class="text-inverse">
                                    <br />
                                    <asp:Label ID="lblIgst" runat="server"></asp:Label></span>
                            </td>

                            <td style="background-color: #293036; color: white; text-align: center">
                                <b>GRAND TOTAL</b>
                                <br />
                                <span class="f-w-600">
                                    <asp:Label ID="lblGrandTot" runat="server"></asp:Label></span>
                            </td>
                        </tr>
                    </table>
                    <!-- end invoice-price -->
                </div>
                <!-- end invoice-price -->
                <!-- end Bank Details -->

           

            <!-- end invoice-content -->
              <table style="border: 1px; width: 99%; margin-bottom: 30px; color: black;">
                    <tr style="height: 80px">
                        <td colspan="6" style="padding: 20px">
                            <strong>Note:</strong>
                            <br />
                            * Make all cheques payable to [<asp:Label ID="lblCompany3" runat="server"></asp:Label>]<br />
                            * Payment is due within 30 days<br />
                        </td>
                        <td colspan="6" style="padding: 20px">

                            <table border="1" style="width: 100%; float: right">

                                <tr style="background-color: #1c3967; color: white; height: 40px">
                                    <td class="text-center" colspan="2">BANK DETAILS</td>
                                </tr>
                                <tr>
                                    <td class="text-center" colspan="2">SPACE KNIGHTS TOURS AND TRAVELS</td>
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
                        </td>
                    </tr>
                </table>
            <!-- begin invoice-note -->

            <!-- end invoice-note -->
            <!-- begin invoice-footer -->
            <hr />

            <!-- end invoice-note -->
            <!-- begin invoice-footer -->
            <table style="width: 100%; color: black;">
                <tr>
                    <td colspan="12" style="text-align: center; width: 100%">

                        <p class="text-center m-b-5 f-w-600">
                            THANK YOU FOR YOUR BUSINESS
                   
                        </p>
                        <p class="text-center">
                            <span class="m-r-10"><i class="fa fa-fw fa-lg fa-globe"></i>
                                <asp:Label ID="lblComWebsite2" runat="server"></asp:Label></span> |
                                <span class="m-r-10"><i class="fa fa-fw fa-lg fa-phone-volume"></i>
                                    <asp:Label ID="lblComPhone2" runat="server"></asp:Label></span> |
                                <span class="m-r-10"><i class="fa fa-fw fa-lg fa-envelope"></i>
                                    <asp:Label ID="lblComEmail2" runat="server"></asp:Label></span>
                        </p>

                    </td>
                    <%--  <td colspan="6" style="text-align:right;width:50%"></td>--%>
                </tr>
            </table>
            <!-- end invoice-footer -->
        </div>
    </div>
    <asp:Panel ID="PNL0" runat="server" Style="background-color: white; width: 500px; border-width: 2px; border-color: Black; border-style: solid; padding: 20px; margin: 0 auto">
        <div class="form-group row m-b-15">
            <label class="control-label col-sm-3" for="email" style="color: black;">To</label>
            <div class="col-sm-8">
                <asp:TextBox ID="txtTo" runat="server" CssClass="form-control" Style="color: black;" />
            </div>
        </div>
        <div class="form-group row m-b-15">
            <label class="control-label col-sm-3" for="email" style="color: black;">CC</label>
            <div class="col-sm-8">
                <asp:TextBox ID="txtCC" runat="server" CssClass="form-control" Style="color: black;" />
            </div>
        </div>
        <div class="form-group row m-b-15">
            <label class="control-label col-sm-3" for="email" style="color: black;">BCC</label>
            <div class="col-sm-8">
                <asp:TextBox ID="txtBCC" runat="server" CssClass="form-control" Style="color: black;" />
            </div>
        </div>
        <div class="form-group row m-b-15">
            <label class="control-label col-sm-3" for="email" style="color: black;">Subject</label>
            <div class="col-sm-8">
                <asp:TextBox ID="txtSub" runat="server" CssClass="form-control" Style="color: black;" />
            </div>
        </div>
        <div class="form-group row m-b-15">
            <label class="control-label col-sm-3" for="email" style="color: black;">Body</label>
            <div class="col-sm-8">
                <asp:TextBox ID="txtBody" runat="server" TextMode="MultiLine" Rows="5" CssClass="form-control" Style="color: black;" />
                <i class="fa fa-paperclip text-black"></i>
                <asp:LinkButton ID="lnkAttachment" runat="server" Style="font-size: 11px; color: black"></asp:LinkButton>
            </div>
        </div>
        <div style="text-align: right;">
            <asp:Button ID="btnSend" runat="server" CssClass="btn btn-primary" Text="Send" Style="color: black;" OnClick="btnSend_Click" />
            <asp:Button ID="btnClose" runat="server" CssClass="btn btn-default" Text="Close" Style="color: black;" OnClick="btnClose_Click" />
        </div>
    </asp:Panel>
</asp:Content>
