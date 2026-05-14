<%@ Page Language="C#" AutoEventWireup="true" CodeFile="rpthotel_pay_receipt.aspx.cs" Inherits="Travel_rptInsuranceInvoice" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Hotel Payment Receipt </title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <style>
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
                                    <h3 style="margin-left: 322px;">PAYMENT RECEIPT</h3>
                                </td>
                                <td colspan="8">

                                    <span style="float: right; margin-left: 45px" id="hidePrint" runat="server"><a href="../thotel.aspx" class="btn btn-sm btn-default m-b-10 p-l-5" id="btnhome"><i class="fa fa-file-pdf t-plus-1 text-danger fa-fw fa-lg"></i>Home</a>
                                        <a href="javascript:;" onclick="printpage()" class="btn btn-sm btn-danger m-b-10 p-l-5" id="btnpdf"><i class="fa fa-file-pdf t-plus-1 text-danger fa-fw fa-lg"></i>Export as PDF</a>
                                        <a href="javascript:;" onclick="printpage()" class="btn btn-sm btn-warning m-b-10 p-l-5" id="btnprint"><i class="fa fa-print t-plus-1 fa-fw fa-lg"></i>Print</a>
                                        <asp:Button ID="btnExcel" runat="server" Text="Excel" CssClass="btn btn-sm btn-success m-b-10 p-l-5 " OnClick="btnExcel_Click" />
                                        <asp:Button ID="btnSendMail" runat="server" Text="Email" CssClass="btn btn-sm btn-primary m-b-10 p-l-5" OnClick="btnSendMail_Click" />
                                    </span>
                                </td>
                            </tr>

                        </table>
                    </div>
                    <div class="invoice-title" style="border: 2px solid black; padding: 10px;">
                        <table style="width: 100%">
                            <tr>
                                <td colspan="8">
                                    <h4 class="pull-left">DOC NO. :
                            <asp:Label ID="lblBookingNo" runat="server"></asp:Label>
                                    </h4>
                                </td>
                                <td colspan="8" class="pull-right">
                                    <h4>DOC Date:
                            <asp:Label ID="lblBookingDate" runat="server"></asp:Label></h4>
                                </td>
                            </tr>
                        </table>


                    </div>
                    <table style="border: 2px solid black; margin-left: 0; margin-right: 0; border-top: none; width: 100%">
                        <tr>
                            <td style="width: 50%; border-right: 2px solid black;" colspan="8" class="col-xs-6">
                                <%--<div  style="border-right: 1px solid black;">--%>
                                <address>
                                    <strong>
                                        <asp:Label ID="lblCompanyName" runat="server"></asp:Label><%--SPACE KNIGHT FOR TOUR AND TRAVELS--%></strong><br />
                                    Address: 
                                    <asp:Label ID="lblAddress" runat="server"></asp:Label><br />
                                    City:
                                    <asp:Label ID="lblCity" runat="server"></asp:Label>,
                                  Country: 
                                    <asp:Label ID="lblCountry" runat="server"></asp:Label><br />
                                    Phone No.:
                                    <asp:Label ID="lblPhoneNo" runat="server"></asp:Label><br />
                                    Fax No.:
                                    <asp:Label ID="lblFax" runat="server"></asp:Label><br />
                                    Email: 
                                    <asp:Label ID="lblEmail" runat="server"></asp:Label><br />
                                    Website:   
                                    <asp:Label ID="lblWebsite" runat="server"></asp:Label>
                                </address>

                                <%--</div>--%>
                            </td>
                            <td style="width: 50%" colspan="8" class="col-xs-6">
                                <%-- <div class="col-xs-6">--%>
                                <address>
                                    <strong>
                                        <asp:Label ID="lblAgentName" runat="server"></asp:Label><%--SPACE KNIGHT FOR TOUR AND TRAVELS--%></strong><br />
                                    Address:
                                    <asp:Label ID="lblAgentAdd" runat="server"></asp:Label><br />
                                    City:
                                    <asp:Label ID="lblAgntCity" runat="server"></asp:Label>,
                                  Country: 
                                    <asp:Label ID="lblAgentCountry" runat="server"></asp:Label><br />
                                    Phone No.:  
                                    <asp:Label ID="lblAgentPhoneNo" runat="server"></asp:Label><br />
                                    Fax No.:
                                    <asp:Label ID="lblAgentFax" runat="server"></asp:Label><br />
                                    Email:  
                                    <asp:Label ID="lblAgentEmail" runat="server"></asp:Label><br />
                                    Website:    
                                    <asp:Label ID="lblAgentWebsite" runat="server"></asp:Label>
                                </address>

                                <%-- </div>--%>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50%; border-right: 2px solid black; text-align: left; padding-bottom: 10px" colspan="8" class="col-xs-6">
                                <strong>GST NO.:
                                    <asp:Label ID="lblCompGstNo" runat="server"></asp:Label></strong>
                            </td>
                            <td style="width: 50%; text-align: left; padding-left: 10px; padding-bottom: 10px" colspan="8">

                                <strong>GST NO.:
                                    <asp:Label ID="lblAgentGstNo" runat="server"></asp:Label></strong>

                            </td>
                        </tr>
                    </table>
                    <%--<div class="row" style="border-left: 2px solid black; border-right: 2px solid black; margin-left: 0; margin-right: 0; border-top: none; border-bottom: none; height: 200px">
                    </div>--%>
                    <%--<div class="row" style="border: 2px solid black; margin-left: 0; margin-right: 0; border-top: none;">
                        <div class="col-xs-6" style="border-right: 2px solid black;">
                            <div class="pull-right">
                                <strong>GST:27BMXPA6006N1ZL</strong><br />
                            </div>
                        </div>
                        <div class="col-xs-6">
                            <div class="pull-right">
                                <strong>GST:27BMXPA6006N1ZL</strong><br />
                            </div>
                        </div>
                    </div>--%>
                </div>
            </div>

            <div class="row" style="background: blue; margin-left: 0; margin-right: 0; padding: 10px;">
                <div class="col-xs-12"></div>
            </div>

            <div class="row">
                <div class="col-md-12">



                    <table class="table table-condensed">
                        <thead>
                            <tr style="border-bottom: 2px solid black;">

                                <td class="text-left"><strong>PAYMENT TYPE</strong></td>
                                <td class="text-center"><strong>VOUCHER NO.</strong></td>
                                <td class="text-center"><strong>VOUCHER DATE</strong></td>
                                <td class="text-center"><strong>AGENT NAME</strong></td>
                                <td class="text-center"><strong>DESCRIPTION</strong></td>
                                <td class="text-center"><strong>AMOUNT</strong></td>


                            </tr>
                        </thead>
                        <tbody>
                            <!-- foreach ($order->lineItems as $line) or some such thing here -->
                            <asp:Repeater ID="rptInvoice" runat="server">
                                <ItemTemplate>
                                    <tr>

                                        <td class="text-left">
                                            <%# Eval("sPayMode") %>
                                           
                                        </td>
                                        <td class="text-center">
                                            <%# Eval("sVoucherNo") %>
                                        </td>
                                        <td class="text-center">
                                            <%# validation.TextToDate( Eval("dtPayment").ToString()) %>
                                        </td>
                                        <td class="text-center">
                                            <%# Eval("sAgentName") %>
                                        </td>
                                        <td class="text-center">
                                            <%# Eval("sRemarks") %>
                                        </td>
                                        <td class="text-center">
                                            <%# Eval("nAmount") %>
                                        </td>


                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>

                            <tr style="border: 2px solid black; font-weight: bold">
                                <td class="thick-line" colspan="5">GRAND TOTAL(INR)</td>
                                <td class="thick-line text-center">
                                    <asp:Label ID="lblTotAmt" runat="server"></asp:Label></td>

                            </tr>


                        </tbody>
                    </table>



                    <div class="row">
                        <%--<div class="col-xs-12">
                            <div style="padding: 15px; margin-top: 46px;">
                                <strong>Note:</strong><br />
                                * Make all cheques payable to [
                                <asp:Label ID="lblbCom" runat="server"></asp:Label>
                                ]<br />
                                * Payment is due within 30 days<br />
                            </div>
                        </div>--%>
                        <%-- <div class="col-xs-6">
                            <div class="pull-right" style="padding: 10px;">
                                <p style="margin: 0; border: 1px solid black; padding: 5px;"><strong>BANK DETAILS</strong></p>
                                <p style="margin: 0; border: 1px solid black; padding: 5px;">SPACE KNIGHT TOURS AND TRAVELS</p>
                                <p style="margin: 0; border: 1px solid black; padding: 5px;">BANK NAME: HDFC BANK</p>
                                <p style="margin: 0; border: 1px solid black; padding: 5px;">BRANCH NAME:HYDERABAD-HIMAYAT NAGAR</p>
                                <p style="margin: 0; border: 1px solid black; padding: 5px;">ACCOUNT NO:50200021671551</p>
                                <p style="margin: 0; border: 1px solid black; padding: 5px;">IFSC CODE:HDFC000081</p>
                            </div>
                        </div>--%>
                    </div>
                    <p style="text-align: center; background: blue; color: white; padding: 10px;"><strong>THANK YOU</strong></p>

                    <div class="row" style="background: skyblue; margin-left: 0; margin-right: 0; margin-top: -10px;">
                        <div class="col-xs-6">
                            <p style="padding: 10px;">
                                <strong>T:</strong>
                                <asp:Label ID="lblbComTele" runat="server"></asp:Label>
                            </p>
                        </div>
                        <div class="col-xs-6 text-right">
                            <p style="padding: 10px;">
                                <strong>E-mail:</strong>
                                <asp:Label ID="lblbComEmail" runat="server"></asp:Label>
                            </p>
                        </div>
                    </div>
                    <p style="text-align: center; padding: 10px; border-bottom: 2px solid black;"><strong>This is computer Generated Invoice.No Signature required.</strong></p>
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
