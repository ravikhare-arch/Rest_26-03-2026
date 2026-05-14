<%@ Page Language="C#" AutoEventWireup="true" CodeFile="rptexcursion_invoice.aspx.cs" Inherits="Travel_rptInsuranceInvoice" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Excursion Invoice </title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
      <style>
         .h1, h1 {
             font-size: 30px;
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
    <link href="../../assetss/css/custom-invoice.css" rel="stylesheet" />


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
           <div class="row nopad">
                <div class="col-md-6">
                    <img src="../../assetss/images/logo.png" class="quoteimg" />
                    <asp:Image ID="imgComp" runat="server" AlternateText="" style="display: none !important" />

                    <!-- begin invoice-company -->
                    <div class="invoice-company text-inverse f-w-600">
                        <span class="pull-left hidden-print" id="hidePrint" runat="server"><a href="../tmofa_recruitement.aspx" class="btn btn-sm btn-default m-b-10 p-l-5" id="btnhome"><i class="fa fa-file-pdf t-plus-1 text-danger fa-fw fa-lg"></i>Home</a>
                                        <a href="javascript:;" onclick="printpage()" class="btn btn-sm btn-danger m-b-10 p-l-5" id="btnpdf"><i class="fa fa-file-pdf t-plus-1 text-danger fa-fw fa-lg"></i>Export as PDF</a>
                                        <a href="javascript:;" onclick="printpage()" class="btn btn-sm btn-warning m-b-10 p-l-5" id="btnprint"><i class="fa fa-print t-plus-1 fa-fw fa-lg"></i>Print</a>
                                        <asp:Button ID="btnExcel" runat="server" Text="Excel" CssClass="btn btn-sm btn-success m-b-10 p-l-5 " OnClick="btnExcel_Click" />
                                        <asp:Button ID="btnSendMail" runat="server" Text="Email" CssClass="btn btn-sm btn-primary m-b-10 p-l-5" OnClick="btnSendMail_Click" />
                                     </span>


                    </div>
                    <!-- end invoice-company -->
                </div>
                <div class="col-md-6">
                    <div class="quotebg">
                        <img src="../../assetss/images/Quotebg.png" />
                        <h1 class="centered"><span>TAX INVOICE</span>
                        </h1>
                    </div>
                    <div class="date quotbg text-inverse m-t-5">
                    DOC. No.
                        <small>
                             <asp:Label ID="lblBookingNo" runat="server"></asp:Label>/ <asp:Label ID="lblBookingDate" runat="server"></asp:Label>
                        </small>
                </div>
                </div>
            </div>
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
                               <td><strong><asp:Label ID="lblCompanyName" runat="server"></asp:Label></strong></td>
                               <td><strong><asp:Label ID="lblAgentName" runat="server"></asp:Label></strong></td>
                           </tr>
                           <tr>
                               <td><asp:Label ID="lblAddress" runat="server"></asp:Label></td>
                               <td><asp:Label ID="lblAgentAdd" runat="server"></asp:Label></td>
                           </tr>
                           <tr>
                               <td><asp:Label ID="lblCity" runat="server"></asp:Label>, <asp:Label ID="lblCountry" runat="server"></asp:Label></td>
                               <td><asp:Label ID="lblAgntCity" runat="server"></asp:Label>, <asp:Label ID="lblAgentCountry" runat="server"></asp:Label></td>
                           </tr>
                           <tr>
                               <td>Phone No.: <asp:Label ID="lblPhoneNo" runat="server"></asp:Label>, Fax No.: <asp:Label ID="lblFax" runat="server"></asp:Label></td>
                               <td>Phone No.: <asp:Label ID="lblAgentPhoneNo" runat="server"></asp:Label>, Fax No.:<asp:Label ID="lblAgentFax" runat="server"></asp:Label></td>
                           </tr>
                           <tr>
                               <td>Email: <asp:Label ID="lblEmail" runat="server"></asp:Label>, Website: <asp:Label ID="lblWebsite" runat="server"></asp:Label></td>
                               <td>Email: <asp:Label ID="lblAgentEmail" runat="server"></asp:Label> Website:  <asp:Label ID="lblAgentWebsite" runat="server"></asp:Label></td>
                           </tr>
                           <tr>
                               <td><strong>GST NO.:
                                    <asp:Label ID="lblCompGstNo" runat="server"></asp:Label></strong></td>
                               <td><strong>GST NO.:
                                    <asp:Label ID="lblAgentGstNo" runat="server"></asp:Label></strong></td>
                           </tr>
                       </tbody>
                    </table>
                </div>
            </div>        
            <div class="row">
                <div class="col-md-12">
                    <table class="table table-condensed">
                        <thead>
                            <tr style="border-bottom: 2px solid black;">

                                <th class="text-left"><strong>REF NO.</strong></th>
                                <th class="text-center"><strong>Pax Name</strong></th>
                                <th class="text-center"><strong>EXCURSION TYPE</strong></th>
                                <th class="text-center"><strong>ADULT PAX</strong></th>
                                <th class="text-center"><strong>ADULT PAX RATE</strong></th>
                                <th class="text-center"><strong>CHILD PAX</strong></th>
                                <th class="text-center"><strong>CHILD PAX RATE</strong></th>
                                <th class="text-center"><strong>BASIC COST</strong></th>
                                <th class="text-center"><strong>SC</strong></th>
                                <th class="text-center"><strong>OTHER CHARGES</strong></th>
                                <th class="text-center"><strong>SGST</strong></th>
                                <th class="text-center"><strong>CGST</strong></th>
                                <th class="text-center"><strong>IGST</strong></th>
                                <th class="text-center"><strong>Discount</strong></th>
                                <th class="text-center"><strong>TDS</strong></th>
                                <th class="text-right"><strong>NET PAYABLE</strong></th>

                            </tr>
                        </thead>
                        <tbody>
                            <!-- foreach ($order->lineItems as $line) or some such thing here -->
                            <asp:Repeater ID="rptInvoice" runat="server">
                                <ItemTemplate>
                                    <tr>


                                        <td class="text-left">
                                            <%# Eval("sExcursionReferenceNo") %>
                                        </td>
                                        <td class="text-center">
                                            <%# Eval("sGuestName") %>
                                           
                                        </td>
                                        <td class="text-center" ><%# Eval("sExcursionType") %></td>
                                        <td class="text-center"><%# Eval("nAdultPax") %></td>
                                        <td class="text-center"><%# Eval("nAdultPaxRate") %></td>
                                        <td class="text-center"><%# Eval("nChildPax") %></td>
                                        <td class="text-center"><%# Eval("nChildPaxRate") %></td>
                                        <td class="text-center">
                                            <%# Eval("nBuyCost") %>
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
                                            <%--<asp:Label ID="lblsgst" runat="server"></asp:Label>--%></td>
                                        <td class="text-center">
                                            <%# Eval("nClntIGst") %>
                                            <%--<asp:Label ID="lblcgst" runat="server"></asp:Label>--%></td>
                                        <td class="text-center">
                                            <%# Eval("nDiscount") %>
                                            <%-- <asp:Label ID="lbligst" runat="server"></asp:Label>--%></td>
                                        <td class="text-center">
                                            <%# Eval("nClntTdsAmount") %>
                                        </td>
                                        <td class="text-right">
                                            <%# Eval("nSellingCost") %>
                                            <%--<asp:Label ID="lblAmount" runat="server"></asp:Label>--%></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>

                            <tr style="border: 2px solid black; font-weight: bold">
                                <td class="thick-line" colspan="7">GRAND TOTAL(INR)</td>
                                <td class="thick-line text-center">
                                    <asp:Label ID="lblTotFare" runat="server"></asp:Label></td>
                                <td class="thick-line text-center">
                                    <asp:Label ID="lblTotSC" runat="server"></asp:Label></td>
                                <td class="thick-line text-center">
                                    <asp:Label ID="lblTotOtrCharge" runat="server"></asp:Label></td>
                                <td class="thick-line text-center">
                                    <asp:Label ID="lblTotSGST" runat="server"></asp:Label></td>
                                <td class="thick-line text-center">
                                    <asp:Label ID="lblTotCGST" runat="server"></asp:Label></td>
                                <td class="thick-line text-center">
                                    <asp:Label ID="lblTotIGST" runat="server"></asp:Label></td>

                                <td class="thick-line text-center">
                                    <asp:Label ID="lblTotDiscount" runat="server"></asp:Label>

                                </td>
                                <td>
                                    <asp:Label ID="lblTotTds" runat="server"></asp:Label></td>
                                <td class="thick-line text-right">
                                    <asp:Label ID="lblTotAmt" runat="server"></asp:Label></td>

                            </tr>


                        </tbody>
                    </table>



                    <div class="row">
                        <div class="col-xs-12">
                            <div style="padding: 15px; margin-top: 46px;">
                                <strong>Note:</strong><br />
                                * Make all cheques payable to [
                                <asp:Label ID="lblbCom" runat="server"></asp:Label>
                                ]<br />
                                * Payment is due within 30 days<br />
                            </div>
                        </div>
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
                    <p style="text-align:center;background: #21212b; color: white; padding: 10px;"><strong>THANK YOU</strong></p>

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
