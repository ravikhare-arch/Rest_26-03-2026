<%@ Page Title="" Language="C#" MasterPageFile="~/PrintMaster.master" AutoEventWireup="true" CodeFile="rptGeneralLedger.aspx.cs" Inherits="Accounting_rptGeneralLedger" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../assets/css/default/invoice-print.min.css" rel="stylesheet" />
    <link href="../assets/css/default/mystyle.css" rel="stylesheet" />
    <style>
        .highlighted td {
            color: Red !important;
            background-color: blue !important;
        }
    </style>
    <script type="text/javascript">
        function printpage() {
            //Get the print button and put it into a variable
            var printButton = document.getElementById("btnprint");
            var topLink = document.getElementById("tplink");
            var pdfButton = document.getElementById("btnpdf");
            //Set the print button visibility to 'hidden' 
            printButton.style.visibility = 'hidden';
            topLink.style.visibility = 'hidden';
            pdfButton.style.visibility = 'hidden';
            //Print the page content
            window.print()
            //Set the print button to 'visible' again 
            //[Delete this line if you want it to stay hidden after printing]
            printButton.style.visibility = 'visible';
            topLink.style.visibility = 'visible';
            pdfButton.style.visibility = 'visible';
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- begin breadcrumb -->
    <ol class="breadcrumb hidden-print pull-right" id="tplink">
        <li class="breadcrumb-item"><a href="../Dashboard.aspx">Home</a></li>
        <li class="breadcrumb-item active">General Ledger</li>
    </ol>
    <!-- end breadcrumb -->
    <!-- begin page-header -->
    <h1 class="page-header hidden-print">General Ledger </h1>
    <!-- end page-header -->

    <!-- begin invoice -->
    <div class="invoice">
        <!-- begin invoice-company -->
        <div class="invoice-company text-inverse f-w-600">
            <span class="pull-right hidden-print">
                <a href="javascript:;" class="btn btn-sm btn-white m-b-10 p-l-5" id="btnpdf"><i class="fa fa-file-pdf t-plus-1 text-danger fa-fw fa-lg"></i>Export as PDF</a>
                <a href="javascript:;" onclick="printpage()" class="btn btn-sm btn-white m-b-10 p-l-5" id="btnprint"><i class="fa fa-print t-plus-1 fa-fw fa-lg"></i>Print</a>

            </span>
            <asp:Label ID="lblCompanyName" runat="server"></asp:Label>
            <div class="text-center">
                <h4>Statement of Account </h4>
            </div>
        </div>
        <!-- end invoice-company -->
        <!-- begin invoice-header -->
        <div class="invoice-header">
            <div class="invoice-from">
                <small>Account Information</small>
                <address class="m-t-5 m-b-5">
                    <strong class="text-inverse">
                        <asp:Label ID="lblAccountTitle" runat="server"></asp:Label></strong><br />
                    <asp:Label ID="lblAdd" runat="server"></asp:Label><br />
                    <asp:Label ID="lblCity" runat="server"></asp:Label><br />
                    <asp:Label ID="lblCountry" runat="server"></asp:Label><br />
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

            <div class="invoice-date">

                <div class="date text-inverse m-t-5">
                    Statement Period : 
                   
                    <small>
                        <asp:Label ID="lblDate" runat="server"></asp:Label></small>
                </div>
                <div class="invoice-detail">
                    <div class="date text-inverse m-t-5">
                        Member Since :
                        
                        <small>
                            <asp:Label ID="lblCreatedDate" runat="server"></asp:Label>
                        </small>
                    </div>

                    <%--<div class="date text-inverse m-t-5">
                        Currency:<br />
                        <small>
                            <asp:Label ID="lblCurrency" runat="server"></asp:Label></small>
                    </div>--%>
                </div>
            </div>
        </div>
        <!-- end invoice-header -->
        <!-- begin invoice-content -->
        <div class="invoice-content">
            <!-- begin table-responsive -->
            <div class="table-responsive">
                <asp:GridView ID="GridView1" CssClass="table table-invoice" runat="server"
                    AutoGenerateColumns="False" EmptyDataText="No Records to display" DataKeyNames="Account Code" 
                    Width="100%" AllowSorting="True">
                    <Columns>
                        <asp:TemplateField HeaderText="Account Code" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblID" runat="server" Text='<%# Eval("Account Code") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Voucher Date">
                            <ItemTemplate>
                                <%#validation.TextToDate(Eval("Voucher Date").ToString())%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Voucher No" HeaderText="Voucher No" />
                        <asp:BoundField DataField="sVoucherType" HeaderText="Voucher Type" />
                        <asp:BoundField DataField="Description" HeaderText="Description" />
                        <asp:BoundField DataField="Debit Amount" HeaderText="Debit Amount" />
                        <asp:BoundField DataField="Credit Amount" HeaderText="Credit Amount" />
                        <asp:BoundField DataField="Balance" HeaderText="Balance" />
                      

                    </Columns>
                </asp:GridView>

            </div>
            <!-- end table-responsive -->
            <!-- begin invoice-price -->
            <div class="invoice-price">
                <div class="invoice-price-left">
                    <div class="invoice-price-row">
                        <div class="sub-price">
                            <small>Total Credit</small>
                            <span class="text-inverse">
                                <asp:Label ID="lblTotCredit" runat="server"></asp:Label>
                            </span>
                        </div>
                        <div class="sub-price">
                            <i class="fa fa-minus text-muted"></i>
                        </div>
                        <div class="sub-price">
                            <small>Total Debit</small>
                            <span class="text-inverse">
                                <asp:Label ID="lblTotDebit" runat="server"></asp:Label></span>
                        </div>


                        <div class="sub-price">
                            <%--<i class="fa fa-minus text-muted"></i>--%>
                        </div>
                        <%--<div class="sub-price">
                             <small>Discount</small>
                            <span class="text-inverse">
                                </span>
                        </div>--%>
                    </div>

                </div>
                <div class="invoice-price-right">
                    <small>TOTAL BALANCE</small> <span class="f-w-600">
                        <asp:Label ID="lblTotBalance" runat="server"></asp:Label></span>
                </div>
            </div>
            <!-- end invoice-price -->
        </div>
        <!-- end invoice-content -->
        <!-- begin invoice-note -->
        <%-- <div class="invoice-note">
            * Make all cheques payable to [<asp:Label ID="lblCompanyName2" runat="server"></asp:Label>]<br />
            * Journal is due within 30 days<br />
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

