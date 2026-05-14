<%@ Page Title="Journal Voucher" Language="C#" MasterPageFile="~/PrintMaster.master" AutoEventWireup="true" CodeFile="rptJournalVoucher.aspx.cs" Inherits="Accounting_rptJournalVoucher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../assets/css/default/invoice-print.min.css" rel="stylesheet" />
    <link href="../assets/css/default/mystyle.css" rel="stylesheet" />

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
    <div class="row">
        <div class="col-md-6">
            <h1 class="page-header hidden-print">Journal Voucher  </h1>
        </div>
        <div class="col-md-6">
            <ol class="breadcrumb hidden-print pull-right" id="tplink">
                <li class="breadcrumb-item"><a href="tacc_journal_voucher.aspx">Home</a></li>
                <li class="breadcrumb-item active">Payment Voucher</li>
            </ol>
        </div>
    </div>

    <!-- end breadcrumb -->
    <!-- begin page-header -->
    <h1 class="page-header hidden-print"></h1>
    <!-- end page-header -->

    <!-- begin invoice -->
    <div class="invoice" id="invoice" runat="server">
        <!-- begin invoice-company -->
        <table style="width: 100%">
            <tr>
                <td class="text-center float-left" style="width: 50%; text-decoration: underline; margin-bottom: 25px;" colspan="3">
                    <%-- <asp:Label ID="lblCompanyName" runat="server"></asp:Label>--%>
                    <div class="text-right">
                        <h3 style="text-decoration: underline">
                            <asp:Label ID="lblVoucherType" runat="server"></asp:Label>
                        </h3>
                    </div>
                </td>
                <td class="float-right" style="width: 50%" colspan="4">
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
            <div class="invoice-from">
                <small>from</small>
                <address class="m-t-5 m-b-5">
                    <strong class="text-inverse">
                        <asp:Label ID="lblCompanyName1" runat="server"></asp:Label></strong><br />
                    <asp:Label ID="lblcompanyAdd" runat="server"></asp:Label><br />
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
                <small>Journal Voucher Details</small>
                <div class="date text-inverse m-t-5">
                    Date
                    <br />
                    <small>
                        <asp:Label ID="lblDate" runat="server"></asp:Label></small>
                </div>
                <div class="invoice-detail">
                    <div class="date text-inverse m-t-5">
                        Journal Voucher No.
                        <br />
                        <small>
                            <asp:Label ID="lblVoucherNo" runat="server"></asp:Label>
                        </small>
                    </div>


                    <%--<div class="date text-inverse m-t-5">
                        Reference No.:<br />
                        <small>
                            <asp:Label ID="lblrefNo" runat="server"></asp:Label></small>
                    </div>--%>
                </div>
            </div>
        </div>
        <!-- end invoice-header -->
        <!-- begin invoice-content -->
        <div class="invoice-content">
            <!-- begin table-responsive -->
            <div class="table-responsive">
                <asp:GridView ID="GridView1" HeaderStyle-BackColor="#1c3967" BorderColor="Black" BorderStyle="Solid" BorderWidth="1" HeaderStyle-CssClass="text-white" HeaderStyle-Height="40px" RowStyle-Height="40px" runat="server"
                    AutoGenerateColumns="False" EmptyDataText="No Records to display" DataKeyNames="nJournalVoucherID"
                    Width="100%" AllowPaging="true" AllowSorting="True" PageSize="25">
                    <Columns>
                        <asp:TemplateField HeaderText="nJournalVoucherID" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblID" runat="server" Text='<%# Eval("nJournalVoucherID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="sCode" HeaderText="Mark" />
                        <asp:BoundField DataField="sAccountTitle" HeaderText="Account Title" />
                        <asp:BoundField DataField="sDescription" HeaderText="Description" />
                        <asp:BoundField DataField="nDebit" HeaderText="Debit" />
                        <asp:BoundField DataField="nCredit" HeaderText="Credit" />


                    </Columns>
                </asp:GridView>

            </div>
            <!-- end table-responsive -->
            <table style="border: 1px; width: 99%; margin-bottom: 30px; color: black;">
                <tr style="background-color: #f2f2f2; height: 80px">
                    <td style="padding-left: 10px; width: 80%" colspan="10">
                        <small>SUB TOT.</small><br />
                        <span class="text-inverse">
                            <asp:Label ID="lblSubTot" runat="server"></asp:Label></span>
                    </td>


                    <td style="background-color: #293036; color: white; text-align: center; width: 20%" colspan="2">
                        <b>GRAND TOTAL</b>
                        <br />
                        <span class="f-w-600">
                            <asp:Label ID="lblGrandtotal" runat="server"></asp:Label></span>
                    </td>
                </tr>
            </table>
            <!-- begin invoice-price -->

            <!-- end invoice-price -->
        </div>
        <!-- end invoice-content -->
        <table style="margin-top: 100px; color: black">
            <tr>
                <td></td>
                <td style="border-top: 1px solid black; width: 25%"></td>
                <td></td>
                <td style="border-top: 1px solid black; width: 25%"></td>
                <td></td>
                <td style="border-top: 1px solid black; width: 25%"></td>
                <td style="width: 10%"></td>
            </tr>
            <tr>
                <td style="width: 10%"></td>
                <td style="text-align: center">Cashier</td>
                <td style="width: 10%"></td>
                <td style="text-align: center">Checked by</td>
                <td style="width: 10%"></td>
                <td style="text-align: center">Approved by
                </td>
                <td></td>

            </tr>
        </table>
        <!-- begin Cashier -->

        <!-- end Cashier -->
        <!-- begin invoice-note -->
        <%-- <div class="invoice-note">
            * Make all cheques payable to [<asp:Label ID="lblCompanyName2" runat="server"></asp:Label>]<br />
            * PDC/PDCR is due within 30 days<br />
            * If you have any questions concerning this invoice, contact  [<asp:Label ID="lblcperson" runat="server"></asp:Label>,
            <asp:Label ID="lblphone2" runat="server"></asp:Label>,
            <asp:Label ID="lblemail2" runat="server"></asp:Label>]
               
        </div>--%>
        <!-- end invoice-note -->
        <!-- begin invoice-footer -->
        <hr />
        <table style="color: black">
            <tr>
                <td colspan="12" style="text-align: center;">THANK YOU FOR YOUR BUSINESS
                   
                </td>

            </tr>
        </table>

        <!-- end invoice-footer -->
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

