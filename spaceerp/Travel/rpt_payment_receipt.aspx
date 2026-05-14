<%@ Page Language="C#" AutoEventWireup="true" CodeFile="rpt_payment_receipt.aspx.cs" Inherits="Travel_rptInsuranceInvoice" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Payment Receipt </title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <link href="../../assets/css/default/invoice-print.min.css" rel="stylesheet" />
    <link href="../../assets/css/default/mystyle.css" rel="stylesheet" />
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
            font-size: 23px;
        }

        .h1, h1 {
            font-size: 0.6rem !important;
        }
    </style>
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
        <div class="pagebg">
            <div class="row nopad" id="invoice" runat="server">
                <div class="col-md-5">
                    <img src="../../assetss/images/logo.png" class="quoteimg" />
                    <asp:Image ID="imgComp" runat="server" AlternateText="" Width="200" style="display: none;" />
                    <!-- begin invoice-company -->
                    <div class="invoice-company text-inverse f-w-600">
                        <span class="pull-left hidden-print" id="hidePrint" runat="server">
                            <%--<a href="../tpayment_receive.aspx" class="btn btn-sm btn-default m-b-10 p-l-5" id="btnhome"><i class="fa fa-file-pdf t-plus-1 text-danger fa-fw fa-lg"></i>Home</a>--%>
                            <a href="javascript:;" onclick="printpage()" class="btn btn-sm btn-danger m-b-10 p-l-5" id="btnpdf"><i class="fa fa-file-pdf t-plus-1 text-danger fa-fw fa-lg"></i>Export as PDF</a>
                            <a href="javascript:;" onclick="printpage()" class="btn btn-sm btn-warning m-b-10 p-l-5" id="btnprint"><i class="fa fa-print t-plus-1 fa-fw fa-lg"></i>Print</a>
                            <asp:Button ID="btnExcel" runat="server" Text="Excel" CssClass="btn btn-sm btn-success m-b-10 p-l-5 " OnClick="btnExcel_Click" />
                            <asp:Button ID="btnSendMail" runat="server" Text="Email" CssClass="btn btn-sm btn-primary m-b-10 p-l-5" OnClick="btnSendMail_Click" />
                        </span>


                    </div>
                    <!-- end invoice-company -->
                </div>
                <div class="col-md-7">
                    <div class="quotebg">
                        <img src="../../assetss/images/Quotebg.png" />
                        <h1 class="centered">
                            <span>PAYMENT RECEIPT</span></h1>
                    </div>
                    <div class="date quotbg text-inverse m-t-5">
                        DOC No.
                        <small>
                            <asp:Label ID="lblBookingNo" runat="server"></asp:Label>/ <asp:Label ID="lblBookingDate" runat="server"></asp:Label>
                        </small>
                    </div>
                </div>
            </div>
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
                                <asp:Label ID="lblAgentName" runat="server"></asp:Label></strong></td>

                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblAddress" runat="server"></asp:Label></td>
                            <td><asp:Label ID="lblAgentAdd" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblCity" runat="server"></asp:Label>,
                    <asp:Label ID="lblCountry" runat="server"></asp:Label></td>
                            <td><asp:Label ID="lblAgntCity" runat="server"></asp:Label>, <asp:Label ID="lblAgentCountry" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>Phone:
                    <asp:Label ID="lblPhoneNo" runat="server"></asp:Label>,                    
                    Fax:
                    <asp:Label ID="lblFax" runat="server"></asp:Label>
                                Email:
                    
                    <asp:Label ID="lblEmail" runat="server"></asp:Label>, <asp:Label ID="lblWebsite" runat="server"></asp:Label></td>
                            <td>Phone:
                                <asp:Label ID="lblAgentPhoneNo" runat="server"></asp:Label>,
                                        Fax No.:
                                    <asp:Label ID="lblAgentFax" runat="server"></asp:Label>,
                                        Email:  
                                    <asp:Label ID="lblAgentEmail" runat="server"></asp:Label>,
                                        Website:    
                                    <asp:Label ID="lblAgentWebsite" runat="server"></asp:Label>
                            </td>
                        </tr>

                        <tr>
                            <td>GSTIN :<asp:Label ID="lblCompGstNo" runat="server"></asp:Label></td>
                            <td>GSTIN :<asp:Label ID="lblAgentGstNo" runat="server"></asp:Label></td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
                    
            <div class="table-responsive bg-white">
                <table class="table table-invoice" cellspacing="0" rules="all" border="1" style="width: 100%; border-collapse: collapse;">
                            <thead>
                                <tr style="border-bottom: 2px solid black;">

                                    <th class="text-left"><strong>PAYMENT TYPE</strong></th>
                                    <th class="text-center"><strong>PAYMENT FOR</strong></th>
                                    <th class="text-center"><strong>INVOICE NO.</strong></th>
                                    <th class="text-center"><strong>INVOICE DATE</strong></th>
                                    <th class="text-center"><strong>AGENT NAME</strong></th>
                                    <th class="text-center"><strong>DESCRIPTION</strong></th>
                                    <th class="text-center"><strong>AMOUNT</strong></th>


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
                                                <%# Eval("sPayFor") %>
                                            </td>
                                            <td class="text-center">
                                                <%# Eval("sInvoiceNo") %>
                                            </td>
                                            <td class="text-center">
                                                <%# validation.TextToDate( Eval("dtInvoiceDate").ToString()) %>
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
                                    <td class="thick-line" colspan="6">GRAND TOTAL(INR)</td>
                                    <td class="thick-line text-center">
                                        <asp:Label ID="lblTotAmt" runat="server"></asp:Label></td>

                                </tr>


                            </tbody>
                        </table>
                        
                        <div style="text-align: center;"><strong>THANK YOU</strong></div>

                        <div class="row">
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
                        <div style="text-align: center; border-bottom: 2px solid black;"><strong>This is computer Generated Invoice.No Signature required.</strong></div>
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
        </div>
    </form>
</body>
</html>
