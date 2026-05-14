<%@ Page Language="C#" AutoEventWireup="true" CodeFile="rptairline_sales_client.aspx.cs" Inherits="Travel_TicketInvoice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Airline Wise Sales Statement</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <style>
        table {
            font-family: Arial;
            font-size: x-small;
        }

        .invoice-title h2, .invoice-title h3 {
            display: inline-block;
        }

        .table > tbody > tr > .no-line {
            border-top: none;
        }

        .table > thead > tr > .no-line {
            border-bottom: none;
        }

        .table > tbody > tr > .thick-line {
            border-top: 2px solid;
        }
    </style>

    <script type="text/javascript">
        function printpage() {
            //Get the print button and put it into a variable
            var HomeButton = document.getElementById("btnhome");
            var printButton = document.getElementById("btnprint");

            var pdfButton = document.getElementById("btnpdf");
            var ExcelButton = document.getElementById("<%=btnExcel.ClientID %>");
            var EmailButton = document.getElementById("<%=btnSendMail.ClientID %>");
            //Set the print button visibility to 'hidden' 
            HomeButton.style.visibility = 'hidden';
            printButton.style.visibility = 'hidden';

            pdfButton.style.visibility = 'hidden';
            ExcelButton.style.visibility = 'hidden';
            EmailButton.style.visibility = 'hidden';
            //Print the page content
            window.print()
            //Set the print button to 'visible' again 
            //[Delete this line if you want it to stay hidden after printing]
            printButton.style.visibility = 'visible';

            pdfButton.style.visibility = 'visible';
            ExcelButton.style.visibility = 'visible';
            EmailButton.style.visibility = 'visible';
            HomeButton.style.visibility = 'visible';
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container" id="invoice" runat="server">
            <div class="row">

                <div class="col-xs-12">
                    <div class="invoice-title" style="border: 2px solid black; border-bottom: none;">
                        <table>
                            <tr>
                                <td colspan="8">
                                    <%--<img src="logo.png" />--%>
                                    <asp:Image ID="imgComp" runat="server" AlternateText="" />
                                    <h3 style="margin-left: 322px;">
                                        
AIRLINE WISE SALES OF <asp:Label ID="lblVType" runat="server"></asp:Label></h3>
                                </td>
                                <td colspan="8">

                                    <span style="float: right; margin-left: 45px" id="hidePrint" runat="server"><a href="tairline_reports.aspx?ReportFor=AirlineSales" class="btn btn-sm btn-default m-b-10 p-l-5" id="btnhome"><i class="fa fa-file-pdf t-plus-1 text-danger fa-fw fa-lg"></i>Home</a>
                                        <a href="javascript:;" onclick="printpage()" class="btn btn-sm btn-danger m-b-10 p-l-5" id="btnpdf"><i class="fa fa-file-pdf t-plus-1 text-danger fa-fw fa-lg"></i>Export as PDF</a>
                                        <a href="javascript:;" onclick="printpage()" class="btn btn-sm btn-warning m-b-10 p-l-5" id="btnprint"><i class="fa fa-print t-plus-1 fa-fw fa-lg"></i>Print</a>
                                        <asp:Button ID="btnExcel" runat="server" Text="Excel" CssClass="btn btn-sm btn-success m-b-10 p-l-5 " OnClick="btnExcel_Click" />
                                        <asp:Button ID="btnSendMail" runat="server" Text="Email" CssClass="btn btn-sm btn-primary m-b-10 p-l-5" OnClick="btnSendMail_Click" />
                                    </span>
                                </td>
                            </tr>

                        </table>
                    </div>
                </div>
            </div>

            <div class="row" style="background: blue; margin-left: 0; margin-right: 0; padding: 10px;">
                <div class="col-xs-12"></div>
            </div>

            <%--<div class="row" id="rptAgent" runat="server">
                <div class="col-md-12">
                    <table class="table table-condensed">
                        <thead>
                            <tr style="border-bottom: 2px solid black;">
                                <td class="text-left"><strong>INV DT</strong></td>
                                <td class="text-center"><strong>INV NO</strong></td>
                                
                                <td class="text-center"><strong>TVL DT</strong></td>
                                <td class="text-center"><strong>PAX NAME </strong></td>
                                <td class="text-center"><strong>CARRIER</strong></td>
                                <td class="text-center"><strong>SECTOR</strong></td>
                                <td class="text-center"><strong>CLASS</strong></td>
                                <td class="text-center"><strong>BASE F</strong></td>
                                <td class="text-center"><strong>TAXES</strong></td>
                                <td class="text-center"><strong>M FEE</strong></td>
                                <td class="text-center"><strong>OTR. CHRGE</strong></td>
                                <td class="text-center"><strong>SGST</strong></td>
                                <td class="text-center"><strong>CGST</strong></td>
                                <td class="text-center"><strong>IGST</strong></td>
                                <td class="text-center"><strong>DISC  %</strong></td>
                                <td class="text-center"><strong>IATA</strong></td>
                                <td class="text-center"><strong>TDS</strong></td>
                                <td class="text-center"><strong>REFUND</strong></td>
                                <td class="text-center"><strong>DT CNG PEN</strong></td>
                                <td class="text-center"><strong>VOID CHRG</strong></td>
                                 <td class="text-center"><strong>DEBIT</strong></td>
                                <td class="text-center"><strong>CREDIT</strong></td>
                                <td class="text-center"><strong>BALANCE</strong></td>
                            </tr>
                        </thead>
                        <tbody>
                            <!-- foreach ($order->lineItems as $line) or some such thing here -->
                            <asp:Repeater ID="rptInvoice" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td class="text-left">
                                            <%# validation.TextToDate( Eval("dtBooking").ToString()) %>
                                        </td>
                                        <td class="text-center">
                                            <%# Eval("sTicketBookingNo") %>
                                        </td>
                                      
                                        <td class="text-center">
                                            <%# validation.TextToDate( Eval("dtTravelDate").ToString()) %>
                                        </td>
                                        <td class="text-center">
                                            <%# Eval("sCustomerName") %>
                                        </td>
                                        <td class="text-center">
                                            <%# Eval("sFCarrier") %>
                                        </td>
                                        <td class="text-center">
                                            <%# Eval("sTicketPNR") %>
                                        </td>
                                        <td class="text-center">
                                            <%# Eval("sSector") %>
                                        </td>
                                        <td class="text-center">
                                            <%# Eval("sFlightClass") %>
                                        </td>


                                        <td class="text-center">
                                            <%# Eval("nBasicFare") %>
                                        </td>
                                        <td class="text-center">
                                            <%# Eval("nTotTaxes") %> 
                                           
                                        </td>
                                        <td class="text-center">
                                            <%# Eval("nProfitAmount") %>
                                        </td>
                                         <td class="text-center">
                                            <%# Eval("nClntOtherChrgs") %>
                                        </td>
                                        <td class="text-center">
                                            <%# Eval("nClntSGst") %>
                                        </td>
                                        <td class="text-center">
                                            <%# Eval("nClntCGst") %>
                                        </td>
                                        <td class="text-center">
                                            <%# Eval("nClntIGst") %>
                                        </td>
                                        <td class="text-center">
                                            <%# Eval("nDiscount") %>
                                        </td>
                                        <td class="text-center">
                                            <%# Eval("nClntAirCom") %>
                                        </td>
                                        <td class="text-center">
                                            <%# Eval("nClntTdsAmount") %>
                                        </td>
                                        <td class="text-center">
                                            <%# Eval("nClientRefund") %>
                                        </td>
                                        <td class="text-center">0
                                        </td>
                                        <td class="text-center">0
                                        </td>
                                        <td class="text-center">
                                            <%# Eval("nSellingCost") %>
                                        </td>
                                        <td class="text-center">
                                            <%# Eval("nPaidAmount") %>
                                        </td>
                                        <td class="text-center">
                                            <%# Eval("nBalance") %>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>

                            <tr style="border: 2px solid black; font-weight: bold">
                                <td class="thick-line" colspan="8">GRAND TOTAL(INR)</td>
                                <td class="thick-line text-center">
                                    <asp:Label ID="lblTotFare" runat="server"></asp:Label></td>
                                <td class="thick-line text-center">
                                    <asp:Label ID="lblTotTax" runat="server"></asp:Label></td>

                                <td class="thick-line text-center">
                                    <asp:Label ID="lblTotSC" runat="server"></asp:Label></td>
                                 <td class="thick-line text-center">
                                    <asp:Label ID="lblotrCharge" runat="server"></asp:Label></td>
                                <td class="thick-line text-center">
                                    <asp:Label ID="lblTotSGST" runat="server"></asp:Label></td>
                                <td class="thick-line text-center">
                                    <asp:Label ID="lblTotCGST" runat="server"></asp:Label></td>
                                <td class="thick-line text-center">
                                    <asp:Label ID="lblTotIGST" runat="server"></asp:Label></td>

                                <td class="thick-line text-center">
                                    <asp:Label ID="lblTotDiscount" runat="server"></asp:Label>
                                </td>
                                <td class="thick-line text-center">
                                    <asp:Label ID="lblTotIata" runat="server"></asp:Label>
                                </td>
                                <td class="thick-line text-center">
                                    <asp:Label ID="lblTotTds" runat="server"></asp:Label>
                                </td>
                                <td class="thick-line text-center">
                                    <asp:Label ID="lblTotRefund" runat="server"></asp:Label>
                                </td>
                                <td class="thick-line text-center">
                                    <asp:Label ID="lblTotDT" runat="server"></asp:Label>
                                </td>
                                <td class="thick-line text-center">
                                    <asp:Label ID="lblTotVoid" runat="server"></asp:Label>
                                </td>
                                <td class="thick-line text-center">
                                    <asp:Label ID="lblTotRecAmt" runat="server"></asp:Label>
                                </td>
                                <td class="thick-line text-center">
                                    <asp:Label ID="lblTotPayAmt" runat="server"></asp:Label>
                                </td>
                                <td class="thick-line text-center">
                                    <asp:Label ID="lblTotBalance" runat="server"></asp:Label>
                                </td>

                            </tr>


                        </tbody>
                    </table>
                </div>
            </div>--%>
            <div class="row" id="rptSupplier" runat="server">
                <div class="col-md-12">



                    <table class="table table-condensed">
                        <thead>
                            <tr style="border-bottom: 2px solid black;">
                                <td class="text-left"><strong>INV DT</strong></td>
                                <td class="text-center"><strong>INV NO</strong></td>
                              
                             <%--   <td class="text-center"><strong>TVL DT</strong></td>
                                <td class="text-center"><strong>PAX NAME </strong></td>--%>
                                <td class="text-center"><strong>CARRIER</strong></td>
                                 <td class="text-center"><strong>SECTOR</strong></td>
                                <td class="text-center"><strong>Client</strong></td>
                                <td class="text-center"><strong>BASE F</strong></td>
                                <td class="text-center"><strong>YQ</strong></td>
                                <td class="text-center"><strong>YR</strong></td>
                                <td class="text-center"><strong>K3</strong></td>
                                 <td class="text-center"><strong>OTR TAX</strong></td>
                                 <td class="text-center"><strong>IATA COM</strong></td>
                                 <td class="text-center"><strong>PLB COM</strong></td>
                                <td class="text-center"><strong>M FEE</strong></td>
                                <td class="text-center"><strong>SGST</strong></td>
                                <td class="text-center"><strong>CGST</strong></td>
                                <td class="text-center"><strong>IGST</strong></td>
                                <td class="text-center"><strong>DISC  %</strong></td>
                                <td class="text-center"><strong>TDS</strong></td>
                                <td class="text-center"><strong>REFUND</strong></td>
                                <td class="text-center"><strong>DEBIT</strong></td>
                                <td class="text-center"><strong>CREDIT</strong></td>
                                <td class="text-center"><strong>BALANCE</strong></td>
                            </tr>
                        </thead>
                        <tbody>
                            <!-- foreach ($order->lineItems as $line) or some such thing here -->
                            <asp:Repeater ID="rptInvSup" runat="server">
                                <ItemTemplate>
                                    <tr>
                                       <td class="text-left">
                                            <%# validation.TextToDate( Eval("dtBooking").ToString()) %>
                                        </td>
                                        <td class="text-center">
                                            <%# Eval("sBookingNo") %>
                                        </td>
                                        
                                      
                                        <td class="text-center">
                                            <%# Eval("sAirline") %>
                                        </td>
                                      
                                        <td class="text-center">
                                            <%# Eval("sSector") %>
                                        </td>
                                          <td class="text-center">
                                            <%# Eval("sAgentName") %>
                                        </td>

                                        <td class="text-center">
                                            <%# Eval("nBasicFare") %>
                                        </td>
                                        <td class="text-center">
                                            <%# Eval("nYqTax") %> 
                                            
                                        </td>
                                        <td class="text-center">
                                            <%# Eval("nYrTax") %> 
                                            
                                        </td>
                                        <td class="text-center">
                                            <%# Eval("nK3Tax") %> 
                                            
                                        </td>
                                        <td class="text-center">
                                            <%# Eval("nOtherTax") %> 
                                            
                                        </td>
                                        <td class="text-center">
                                            <%# Eval("nClntAirCom") %> 
                                            
                                        </td>
                                        <td class="text-center">
                                            <%# Eval("nClntAirPlb") %> 
                                            
                                        </td>
                                        <td class="text-center">
                                            <%# Eval("nProfitAmount") %>
                                        </td>
                                        <td class="text-center">
                                            <%# Eval("nClntCGst") %>
                                        </td>
                                        <td class="text-center">
                                            <%# Eval("nClntSGst") %>
                                        </td>
                                        <td class="text-center">
                                            <%# Eval("nClntIGst") %>
                                        </td>
                                        <td class="text-center">
                                            <%# Eval("nDiscount") %>
                                        </td>
                                       
                                        <td class="text-center">
                                            <%# Eval("nClntTdsAmount") %>
                                        </td>
                                        <td class="text-center">
                                            <%# Eval("nClientRefund") %>
                                        </td>
                                   
                                        <td class="text-center">
                                            <%# Eval("nSellingCost") %>
                                        </td>
                                        <td class="text-center">
                                            <%# Eval("nPaidAmount") %>
                                        </td>
                                        <td class="text-center">
                                            <%# Eval("nBalance") %>
                                        </td>
                                      
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>

                            <tr style="border: 2px solid black; font-weight: bold">
                                <td class="thick-line" colspan="5">GRAND TOTAL(INR)</td>
                                <td class="thick-line text-center">
                                    <asp:Label ID="lblSupTotFare" runat="server"></asp:Label></td>
                                

                                <td class="thick-line text-center">
                                    <asp:Label ID="lblSupYQ" runat="server"></asp:Label></td>
                                
                              
                                
                                <td class="thick-line text-center">
                                    <asp:Label ID="lblSupYR" runat="server"></asp:Label></td>
                                <td class="thick-line text-center">
                                    <asp:Label ID="lblSupK3" runat="server"></asp:Label></td>

                                <td class="thick-line text-center">
                                    <asp:Label ID="lblSupOTRTAX" runat="server"></asp:Label></td>
                                 <td class="thick-line text-center">
                                    <asp:Label ID="lblSupIATA" runat="server"></asp:Label></td>
                                <td class="thick-line text-center">
                                    <asp:Label ID="lblSupPLB" runat="server"></asp:Label></td>
                                <td class="thick-line">
                                    <asp:Label ID="lblSupTotSC" runat="server"></asp:Label></td>
                                <td class="thick-line text-center">
                                    <asp:Label ID="lblSupTotCGST" runat="server"></asp:Label></td>
                                <td class="thick-line text-center">
                                    <asp:Label ID="lblSupTotSGST" runat="server"></asp:Label></td>
                                <td class="thick-line text-center">
                                    <asp:Label ID="lblSupTotIGST" runat="server"></asp:Label></td>

                                <td class="thick-line text-center">
                                    <asp:Label ID="lblSupTotDiscount" runat="server"></asp:Label>
                                </td>
                                
                                <td class="thick-line text-center">
                                    <asp:Label ID="lblSupTotTds" runat="server"></asp:Label>
                                </td>
                                <td class="thick-line text-center">
                                    <asp:Label ID="TotSupRefund" runat="server"></asp:Label>
                                </td>
                              <%--  <td class="thick-line text-center">
                                    <asp:Label ID="lblSupTotDT" runat="server"></asp:Label>
                                </td>
                                <td class="thick-line text-center">
                                    <asp:Label ID="lblSupTotVoid" runat="server"></asp:Label>
                                </td>--%>
                                <td class="thick-line text-center">
                                    <asp:Label ID="lblSupTotRecAmt" runat="server"></asp:Label>
                                </td>
                                
                                <td class="thick-line text-center">
                                    <asp:Label ID="lblSupTotPayAmt" runat="server"></asp:Label>
                                </td>
                                <td class="thick-line text-center">
                                    <asp:Label ID="lblSupBalance" runat="server"></asp:Label>
                                </td>

                            </tr>


                        </tbody>
                    </table>


                </div>
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
    </form>
</body>
</html>
