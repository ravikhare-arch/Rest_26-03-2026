<%@ Page Title="General Ledger" Language="C#" MasterPageFile="~/PrintMaster.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="rptGeneralLedger.aspx.cs" Inherits="Accounting_rptGeneralLedger" %>

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
    <!-- begin breadcrumb -->
    <ol class="breadcrumb hidden-print pull-right" id="tplink">
        <li class="breadcrumb-item"><a href="tgeneral_ledger.aspx">Home</a></li>
        <li class="breadcrumb-item active">General Ledger</li>
    </ol>
    <!-- end breadcrumb -->
    <!-- begin page-header -->
    <h1 class="page-header hidden-print">General Ledger </h1>
    <!-- end page-header -->

    <!-- begin invoice -->
    <div class="invoice" id="invoice" runat="server">
        <!-- begin invoice-company -->
        <div class="invoice-company text-inverse f-w-600">
            <div class="pull-right hidden-print" id="hidePrint" runat="server">
                <a href="javascript:;" onclick="printpage()" class="btn btn-sm btn-white m-b-10 p-l-5" id="btnpdf"><i class="fa fa-file-pdf t-plus-1 text-danger fa-fw fa-lg"></i>Export as PDF</a>
                <a href="javascript:;" onclick="printpage()" class="btn btn-sm btn-warning m-b-10 p-l-5" id="btnprint"><i class="fa fa-print t-plus-1 fa-fw fa-lg"></i>Print</a>

              
                <asp:Button ID="btnExcel" runat="server" Text="Excel" CssClass="btn btn-sm btn-success m-b-10 p-l-5 " OnClick="btnExcel_Click" />
                <asp:Button ID="btnSendMail" runat="server" Text="Email" CssClass="btn btn-sm btn-primary m-b-10 p-l-5"  OnClick="btnSendMail_Click" />
               

                
            </div>
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
                <asp:GridView ID="GridView1" CssClass="text-black" runat="server" HeaderStyle-BackColor="#1c3967" BorderColor="Black" BorderStyle="Solid" BorderWidth="1" HeaderStyle-CssClass="text-white" HeaderStyle-Height="40px" RowStyle-Height="40px"
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
                            <small><b>TOTAL DEBIT :</b></small>
                            <span class="text-inverse">
                                <asp:Label ID="lblTotDebit" runat="server"></asp:Label></span>
                        </div>

                        <div class="sub-price">
                            <i class="fa fa-minus text-muted"></i>
                        </div>
                        <div class="sub-price">
                            <small><b>TOTAL CREDIT :</b></small>
                            <span class="text-inverse">
                                <asp:Label ID="lblTotCredit" runat="server"></asp:Label>
                            </span>
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
                    <small><b>TOTAL BALANCE :</b></small> <span class="f-w-600">
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

    <asp:Panel ID="PNL0" runat="server" Style=" background-color: white; width: 500px; border-width: 2px; border-color: Black; border-style: solid; padding: 20px;margin:0 auto" >
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
                            <asp:LinkButton ID="lnkAttachment" runat="server" Style="font-size: 11px;color:black"></asp:LinkButton>
                        </div>
                    </div>
                    <div style="text-align: right;">
                        <asp:Button ID="btnSend" runat="server" CssClass="btn btn-primary" Text="Send" Style="color: black;" OnClick="btnSend_Click"  />
                        <asp:Button ID="btnClose" runat="server" CssClass="btn btn-default" Text="Close" Style="color: black;" OnClick="btnClose_Click" />
                    </div>
                </asp:Panel>
</asp:Content>

