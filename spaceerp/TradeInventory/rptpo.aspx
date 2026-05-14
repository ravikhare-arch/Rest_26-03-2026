<%@ Page Title="Purchase Order" Language="C#" MasterPageFile="~/PrintMaster.master" AutoEventWireup="true" CodeFile="rptpo.aspx.cs" Inherits="Tradding_rptpo" %>

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
            font-size:28px;
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
        <div class="row nopad">
            <div class="col-md-6">
                <img src="../assetss/images/logo.png" class="quoteimg" />

                <!-- begin invoice-company -->
                <div class="invoice-company text-inverse f-w-600">
                    <span class="pull-left hidden-print" id="hidePrint" runat="server">
                        <a href="javascript:;" onclick="printpage()" class="btn btn-sm btn-white m-b-10 p-l-5" id="btnpdf"><i class="fa fa-file-pdf t-plus-1 text-danger fa-fw fa-lg"></i>Export as PDF</a>
                        <a href="javascript:;" onclick="printpage()" class="btn btn-sm btn-warning m-b-10 p-l-5" id="btnprint"><i class="fa fa-print t-plus-1 fa-fw fa-lg"></i>Print</a>


                        <asp:Button ID="btnExcel" runat="server" Text="Excel" CssClass="btn btn-sm btn-success m-b-10 p-l-5 " OnClick="btnExcel_Click" />
                        <asp:Button ID="btnSendMail" runat="server" Text="Email" CssClass="btn btn-sm btn-primary m-b-10 p-l-5" OnClick="btnSendMail_Click" /> </span>


                </div>
                <!-- end invoice-company -->
            </div>
            <div class="col-md-6">
                <div class="quotebg">
                    <img src="../assetss/images/Quotebg.png" />
                    <h1 class="centered">
                        <span>PURCHASE ORDER </span></h1>
                </div>
                <div class="date quotbg text-inverse m-t-5">
                    Quotation No.
                        <small>
                            <asp:Label ID="lblPONo" runat="server"></asp:Label>/ <asp:Label ID="lblDate" runat="server"></asp:Label>
                        </small>
                </div>
            </div>
        </div>
 <div class="invoice-content">
            <!-- begin table-responsive -->
            <div class="table-responsive bg-white">
                <div id="invoice" runat="server">
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
                <div>
                    <table class="table table-invoice" cellspacing="0" rules="all" border="1" style="width: 100%; border-collapse: collapse;">
                        <thead>
                            <tr>
                                <th scope="col">Delievery Date</th>
                                <th scope="col">Payment Terms</th>
                                <th scope="col">Reference No.:</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>
                                    <asp:Label ID="lblDelivertDate" runat="server"></asp:Label></td>
                                <td>30 Days</td>
                                <td>
                                    <asp:Label ID="lblrefNo" runat="server"></asp:Label></td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>


        <!-- end invoice-header -->

        <!-- begin invoice-content -->
        <div class="invoice-content">
            <!-- begin table-responsive -->
            <div class="table-responsive bg-white" style="width:100%">
                <asp:GridView ID="GridView1" width="100%" HeaderStyle-BackColor="#1c3967" BorderColor="Black" BorderStyle="Solid" BorderWidth="1" HeaderStyle-CssClass="text-white" HeaderStyle-Height="40px" RowStyle-Height="40px" runat="server" CellPadding="10"
                    AutoGenerateColumns="False" EmptyDataText="No Records to display" DataKeyNames="nPoDetID"
                    AllowPaging="true" AllowSorting="True" PageSize="25">
                    <Columns>
                        <asp:TemplateField HeaderText="nPoDetID" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblID" runat="server" Text='<%# Eval("nPoDetID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="sItemName" HeaderText="Item Name" />
                        <asp:BoundField DataField="sItemUnit" HeaderText="Item Unit" />
                        <asp:BoundField DataField="nQuantity" HeaderText="Quantity" />
                        <asp:BoundField DataField="nUnitPrice" HeaderText="Unit Price" />
                        <asp:BoundField DataField="sTaxName" HeaderText="Tax Name" />
                        <asp:BoundField DataField="nTaxableAmount" HeaderText="Tax Amount" />
                        <asp:BoundField DataField="nTotalPrice" HeaderText="Total Price" />
                    </Columns>
                </asp:GridView>

            </div>
            <!-- end table-responsive -->
         
            <!-- begin Cashier -->
            <div class="row">
                <div class="col-6">
                </div>
                <div class="col-6">
                    <table style="border: 1px; width: 100%; margin-bottom: 30px; color: black;">

                        <tr style="background-color: #1c3967; color: white; height: 40px; text-align: center;">

                            <th>Details</th>
                            <th>Amount</th>
                        </tr>

                        <tr style="height: 40px; text-align: center; padding: 10px; border: 1px solid black">
                            <td>SUB TOTAL BEFORE TAX</td>
                            <td>
                                <asp:Label ID="lblSubTot" runat="server"></asp:Label></td>
                        </tr>
                        <tr style="height: 40px; text-align: center; padding: 10px; border: 1px solid black">
                            <td>DISCOUNT (-)</td>
                            <td>
                                <asp:Label ID="lblDiscount" runat="server"></asp:Label></td>
                        </tr>
                        <tr style="height: 40px; text-align: center; padding: 10px; border: 1px solid black">
                            <td>SHIPPING & PACKAGING COST</td>
                            <td>
                                <asp:Label ID="lblShippingCost" runat="server"></asp:Label></td>
                        </tr>
                        <tr style="height: 40px; text-align: center; padding: 10px; border: 1px solid black">
                            <td>OTHER COST</td>
                            <td>
                                <asp:Label ID="lblOtherCost" runat="server"></asp:Label></td>
                        </tr>
                        <tr style="height: 40px; text-align: center; padding: 10px; border: 1px solid black">
                            <td>TOTAL TAX AMOUNT</td>
                            <td>
                                <asp:Label ID="lblTotalTax" runat="server"></asp:Label></td>
                        </tr>
                        <tr style="height: 40px; text-align: center; padding: 10px; border: 1px solid black; font-weight: bold; background-color: grey">
                            <td>GRAND TOTAL</td>
                            <td>
                                <asp:Label ID="lblGrandtotal" runat="server"></asp:Label></td>
                        </tr>
                        <%--<tr>
                                <td>TOTAL PAID(-)</td>  
                                <td>7500</td>
                            </tr>
                            <tr class="bg-grey-lighter">
                                <td>TOTAL BALANCE</td>
                                <td>20000</td>
                            </tr>--%>
                    </table>


                </div>

            </div>
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
    </div>
    <!-- end invoice -->
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

