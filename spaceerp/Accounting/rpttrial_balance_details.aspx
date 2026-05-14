<%@ Page Title="Trail Balance" Language="C#" MasterPageFile="~/PrintMaster.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="rpttrial_balance_details.aspx.cs" Inherits="Accounting_rpttrial_balance_details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <!-- Bootstrap -->
    
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
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
    <style>
        #invoicebg{
    padding: 30px;
}

.invoice {
    position: relative;
    background-color: #FFF;
    min-height: 680px;
    padding: 15px
}

.invoice header {
    padding: 10px 0;
    margin-bottom: 20px;
    border-bottom: 1px solid #3989c6
}

.invoice .company-details {
    text-align: right
}

.invoice .company-details .name {
    margin-top: 0;
    margin-bottom: 0
}

.invoice .contacts {
    margin-bottom: 20px
}

.invoice .invoice-to {
    text-align: left
}

.invoice .invoice-to .to {
    margin-top: 0;
    margin-bottom: 0
}

.invoice .invoice-details {
    text-align: right
}

.invoice .invoice-details .invoice-id {
    margin-top: 0;
    color: #3989c6
}

.invoice main {
    padding-bottom: 50px
}

.invoice main .thanks {
    margin-top: -100px;
    font-size: 2em;
    margin-bottom: 50px
}

.invoice main .notices {
    padding-left: 6px;
    border-left: 6px solid #3989c6
}

.invoice main .notices .notice {
    font-size: 1.2em
}

.invoice table {
    width: 100%;
    border-collapse: collapse;
    border-spacing: 0;
    margin-bottom: 20px
}

.invoice table td,.invoice table th {
    padding: 15px;
    background: #eee;
    border-bottom: 1px solid #fff
}

.invoice table th {
    white-space: nowrap;
    font-weight: 400;
    color: #3989c6;
    font-size: 1.4em;
    border-top: 1px solid #3989c6;
}

.invoice table td h3 {
    margin: 0;
    font-weight: 400;
    color: #3989c6;
    font-size: 1.2em
}

.invoice table .qty,.invoice table .total,.invoice table .unit {
    text-align: right;
    font-size: 1.2em
}

.invoice table .no {
    color: #fff;
    font-size: 1.6em;
    background: #3989c6
}

.invoice table .unit {
    background: #ddd
}

.invoice table .total {
    background: #3989c6;
    color: #fff
}

.invoice table tbody tr:last-child td {
    border: none
}

.invoice table tfoot td {
    background: 0 0;
    border-bottom: none;
    white-space: nowrap;
    text-align: right;
    padding: 10px 20px;
    font-size: 1.2em;
    border-top: 1px solid #aaa
}

.invoice table tfoot tr:first-child td {
    border-top: none
}

.invoice table tfoot tr:last-child td {
    color: #3989c6;
    font-size: 1.4em;
    border-top: 1px solid #3989c6
}

.invoice table tfoot tr td:first-child {
    border: none
}

.invoice footer {
    width: 100%;
    text-align: center;
    color: #777;
    border-top: 1px solid #aaa;
    padding: 8px 0
}
.invoice-id {
    margin-top: 0px !important;
}
        .btn-sm {
            padding: 5px 15px;
            font-size: 14px;
        }
@media print {
    .invoice {
        font-size: 11px!important;
        overflow: hidden!important
    }

    .invoice footer {
        position: absolute;
        bottom: 10px;
        page-break-after: always
    }

    .invoice>div:last-child {
        page-break-before: always
    }
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- begin breadcrumb -->
    <div id="invoicebg">        
        <div class="invoice overflow-auto">
            <div style="min-width: 600px">
                <header>
                    <div class="row">
                        <div class="col">
                            <h1 class="invoice-id">
                                <a target="_blank" href="javascript:;">
                                    Trial Balance
                                </a>
                            </h1>
                        </div>
                        <div class="col company-details">
                           <div class="text-right" id="hidePrint" runat="server">
                <a href="ttrailbalance.aspx" class="btn btn-sm btn btn-info m-b-10 p-l-5" id="btnhome"><i class="fa fa-home t-plus-1 text-white fa-fw fa-lg"></i>Home</a>
                        <a href="javascript:;" onclick="printpage()" class="btn btn-sm btn-info m-b-10 p-l-5" id="btnpdf"><i class="fa fa-file-pdf t-plus-1 text-danger fa-fw fa-lg"></i>Export as PDF</a>
                        <a href="javascript:;" onclick="printpage()" class="btn btn-sm btn-warning m-b-10 p-l-5" id="btnprint"><i class="fa fa-print t-plus-1 fa-fw fa-lg"></i>Print</a>
                        <asp:Button ID="btnExcel" runat="server" Text="Excel" CssClass="btn btn-sm btn-success m-b-10 p-l-5 " OnClick="btnExcel_Click" />
                        <asp:Button ID="btnSendMail" runat="server" Text="Email" CssClass="btn btn-sm btn-primary m-b-10 p-l-5" OnClick="btnSendMail_Click" />                 
            </div>
                        </div>
                    </div>
                </header>
                <main>                           
                 <div class="row contacts">
                        <div class="col invoice-to">
                             <h2 class="name">
                                <a target="_blank" href="javascript:;">
                                    <asp:Label ID="lblCompanyName" runat="server"></asp:Label>
                                </a>
                            </h2>
                            <div class="address"><asp:Label ID="lblAddress" runat="server"></asp:Label>,
                                 <asp:Label ID="lblCity" runat="server"></asp:Label>, <asp:Label ID="lblCountry" runat="server"></asp:Label></div>
                            <div class="text-gray-light">Phone: <asp:Label ID="lblPhoneNo" runat="server"></asp:Label></div>
                            <div class="email">Email: <asp:Label ID="lblEmail" runat="server"></asp:Label></div>                            
                        </div>
                        <div class="col invoice-details">
                            
                            <div class="date">Date From: <asp:Label ID="lblrptDates" runat="server"></asp:Label></div>
                        </div>
                    </div>
                 <!-- begin invoice -->
              <div class="invoice" id="invoice" runat="server">      

        <asp:DataList ID="treetable" Width="100%" OnItemDataBound="treetable_ItemDataBound" runat="server">
            <ItemTemplate>
                <tr>
                    <th>Account Title</th>
                    <th>Current Debit</th>
                    <th>Current Credit</th>
                    <th>Balance</th>
                </tr>
                <tr>
                    <td data-column="name" class="no">
                        <span class="fa fa-arrow-right"></span>
                        <asp:HiddenField ID="hdnMain" runat="server" Value='<%#Eval("sMainAccountTitle") %>' />
                        <%#Eval("[sMainAccountTitle]") %></td>
                    <td class="qty"><%#Eval("[DebitAmount]") %></td>
                    <td class="unit"><%#Eval("[CreditAmount]") %></td>
                    <td class="total"><%#Eval("BalAmount") %></td>
                </tr>
                <asp:Repeater ID="treetableSub" runat="server" OnItemDataBound="treetableSub_ItemDataBound">
                    <ItemTemplate>
                        <tr>
                            <td data-column="name" class="no">
                                <span class="fa fa-arrow-right"></span>
                                <asp:HiddenField ID="hdnSub" runat="server" Value='<%#Eval("sSubAccount") %>' />
                                <%#Eval("[sSubAccount]") %></td>
                            <td class="qty"><%#Eval("[DebitAmount]") %></td>
                            <td class="unit"><%#Eval("[CreditAmount]") %></td>
                            <td class="total"><%#Eval("BalAmount") %> </td>
                        </tr>

                        <asp:Repeater ID="treeAcc" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td data-column="name" class="text-left">

                                        <%#Eval("[Account Title]") %></td>
                                    <td class="qty"><%#Eval("[DebitAmount]") %></td>
                                    <td class="unit"><%#Eval("[CreditAmount]") %></td>
                                    <td class="total"><%#Eval("BalAmount") %></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ItemTemplate>
                </asp:Repeater>

            </ItemTemplate>
        </asp:DataList>
        <asp:Label ID="lblrecord" runat="server" Visible="false" ForeColor="Red"> </asp:Label>

    </div>
                    </main>
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
   
</asp:Content>

