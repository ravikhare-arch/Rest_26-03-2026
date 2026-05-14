<%@ Page Title="Payable & Receivables" Language="C#" MasterPageFile="~/PrintMaster.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="rptpay_receivables.aspx.cs" Inherits="Accounting_rpttrialbalance_subaccount  " %>

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
    <div class="row">
        <div class="col-md-6">
            Payables and Receivables
        </div>
        <div class="col-md-6">
            <ol class="breadcrumb hidden-print pull-right" id="tplink">
                <li class="breadcrumb-item"><a href="tpay_receivables.aspx">Home</a></li>
                <li class="breadcrumb-item active">Payables and Receivables</li>
            </ol>
        </div>
    </div>
   
    <!-- end breadcrumb -->
    <!-- begin page-header -->
   
    <!-- end page-header -->

    <!-- begin invoice -->
     <div class="invoice" id="invoice" runat="server">
        <!-- begin invoice-company -->
         <table style="width: 100%">
            <tr>
                <td class="text-center float-left" style="width: 50%; text-decoration: underline; margin-bottom: 25px;" colspan="6">
                    <div class="text-right">
                        <h3 style="text-decoration: underline"><asp:Label ID="lblrpttype" runat="server"></asp:Label> </h3>
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
        <%--  <div class="invoice-header">
            <div class="invoice-from">

                <address class="m-t-5 m-b-5">
                    <strong class="text-inverse">Date From :
                        <asp:Label ID="lblrptDates" runat="server"></asp:Label>
                    </strong>
                    <br />

                </address>
            </div>
            <div class="invoice-to">
                <%--<address class="m-t-5 m-b-5">
                    <strong class="text-inverse">Voucher Type: All</strong><br />

                </address>--%>
        <%--  </div>
            <div class="invoice-date">
                <%-- <div class="date text-inverse m-t-5">
                    User :All
                   
                </div>--%>
        <%-- </div>
        </div>--%>

        <!-- end invoice-header -->
        <table style="width: 100%; color: black; border: 1px solid black">

            <tr style="height: 40px; text-align: left; padding: 10px; border: 1px solid Gray; color: black; background-color: yellow; font-weight: bold">
                <th>Account Code</th>
                <th>Account Title</th>
                <th>Pay Amount</th>
            </tr>
            <asp:Repeater ID="treetableSub" OnItemDataBound="treetable_ItemDataBound" runat="server">
                <ItemTemplate>
                    <tr style="height: 40px; text-align: left; padding: 10px; border: 1px solid Gray; color: black; background-color: lightgray; font-weight: bold">
                        <td data-column="name" class="p-l-10" colspan="2">
                            <span class="fa fa-arrow-right"></span>
                            <asp:HiddenField ID="hdnMain" runat="server" Value='<%#Eval("sSubAccount") %>' />
                            <%#Eval("[sSubAccount]") %></td>
                        <td><%#Eval("BalAmount") %></td>
                    </tr>
                    <asp:Repeater ID="treetableAcc" runat="server">
                        <ItemTemplate>
                            <tr style="height: 40px; text-align: left; padding: 10px; border: 1px solid Gray; color: black; background-color: #ffffff;">
                                <td data-column="name" class="p-l-15">

                                    <%#Eval("[Account Code]") %></td>
                                <td><%#Eval("[Account Title]") %></td>
                                <td><%#Eval("[BalAmount]") %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </ItemTemplate>
            </asp:Repeater>
            <tr style="height: 40px; text-align: left; padding: 10px; border: 1px solid Gray; color: black; background-color: yellow; font-weight: bold">
                <td data-column="name" class="p-l-10 text-left" colspan="2">Total</td>

                <td>
                    <asp:Label ID="lbltotBalance" runat="server"> </asp:Label></td>
            </tr>

        </table>
        <asp:Label ID="lblrecord" runat="server" Visible="false" ForeColor="Red"> </asp:Label>
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

