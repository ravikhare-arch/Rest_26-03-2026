<%@ Page Title="Profit & Loss" Language="C#" MasterPageFile="~/PrintMaster.master" AutoEventWireup="true" CodeFile="rptProfitLoss_Details.aspx.cs" Inherits="Accounting_rptProfitLoss_Details" %>

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
    <link href="../../css/StatementSheet.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
         <div class="widget-box">
                    <div class="widget-header widget-header-large">
                        <%--<img src="logo.png" />--%>
                        <asp:Image ID="imgComp" runat="server" AlternateText="" Height="100px" Style="display: none" />
                        <div class="widget-toolbar no-border invoice-info center-block">
                            <span class="invoice-info-label">
                                <asp:Label ID="lblVType" runat="server"></asp:Label></span>
                            <span class="red h3">Profit And Loss</span> <span class="invoice-info-label"></span>                           
                              <span class="text-right pull-right"  id="hidePrint" runat="server">
                        <a href="tprofit_loss.aspx" class="btn btn-sm btn btn-info m-b-10 p-l-5" id="btnhome"><i class="fa fa-home t-plus-1 text-white fa-fw fa-lg"></i>Home</a>
                                        <a href="javascript:;" onclick="printpage()" class="btn btn-sm btn-white m-b-10 p-l-5" id="btnpdf"><i class="fa fa-file-pdf t-plus-1 text-danger fa-fw fa-lg"></i>Export as PDF</a>
                <a href="javascript:;" onclick="printpage()" class="btn btn-sm btn-warning m-b-10 p-l-5" id="btnprint"><i class="fa fa-print t-plus-1 fa-fw fa-lg"></i>Print</a>
                <asp:Button ID="btnExcel" runat="server" Text="Excel" CssClass="btn btn-sm btn-success m-b-10 p-l-5 " OnClick="btnExcel_Click" />
                <asp:Button ID="btnSendMail" runat="server" Text="Email" CssClass="btn btn-sm btn-primary m-b-10 p-l-5" OnClick="btnSendMail_Click" />
                    </span>
                        </div>
                         <div class="widget-toolbar no-border invoice-info">
                             <span class="invoice-info-label">PERIOD :</span>
                             <span class="blue"><asp:Label ID="lblDate" runat="server" ForeColor="Black"></asp:Label></span>
                             <span class="pull-right">
                                 <span>User :<span class="red">All,</span></span>
                             <span class="invoice-info-label">Voucher Type.:</span>
                             <span class="red"><asp:Label ID="lblVoucherType" runat="server"></asp:Label></span></span>
                         </div>
                    </div>                    
      <div class="widget-body">     
    <div class="invoice" id="invoice" runat="server">
        <!-- begin invoice-company -->
        <div class="invoice-company text-inverse f-w-600">
            
            <asp:Label ID="lblCompanyName" runat="server"></asp:Label>            
        </div>

        <div class="container-fluid bg-white">
            

            <h4 class="text-center">Income/ Revnue</h4>
            <div class="container p-b-40">
                <table class="table table-hover text-black m-b-20 p-15">
                    <asp:Repeater ID="rptSales" runat="server">
                        <ItemTemplate>
                           <tr style="height: 40px; text-align: left; padding: 10px; border: 1px solid black;color:black">
                                <td style="width: 80%"><%#Eval("[Account Title]") %> 
                                </td>
                                <td><%#Eval("Amount") %>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr class="font-weight-bold" style="height: 40px; text-align: left; padding: 10px; border: 1px solid black;color:black;background-color:#f1f1f1">
                        <td style="width: 80%">Total Income/ Revenue
                        </td>
                        <td>
                            <asp:Label ID="lblTotIncome" runat="server"></asp:Label>
                        </td>
                    </tr>

                </table>

            </div>
            <h4 class="text-center">Expenses</h4>
            <div class="container p-b-40">
                <table class="table table-hover text-black m-b-20 p-15">
                    <asp:Repeater ID="rptExpense" runat="server">
                        <ItemTemplate>
                             <tr style="height: 40px; text-align:left; padding: 10px; border: 1px solid black;color:black">
                                <td style="width: 80%"><%#Eval("[Account Title]") %>
                                </td>
                                <td><%#Eval("Amount") %>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr class="font-weight-bold" style="height: 40px; text-align:left; padding: 10px; border: 1px solid black;color:black;background-color:#f1f1f1">
                        <td style="width: 80%">Total Expenses
                        </td>
                        <td>
                            <asp:Label ID="lblTotExp" runat="server"></asp:Label>
                        </td>
                    </tr>

                </table>
                <table class="table table-hover text-black p-15" >
                    <tr class="font-weight-bold" runat="server" id="trProfitloss" >
                        <td style="width: 80%">
                            <asp:Label ID="lblPlTitle" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblprofitLoss" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr class="font-weight-bold" >
                        <td style="width: 80%">
                           TAX
                        </td>
                        <td>
                            <asp:Label ID="lblTax" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr class="font-weight-bold" runat="server" id="trWithTax" >
                        <td style="width: 80%">
                           <asp:Label ID="lblPlwithTAXTtile" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblPlwithTAX" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>

            <%-- <h4 class="p-10">Income/ Revnue</h4>--%>
        </div>
    </div>
          </div>
             </div>
        </div>
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

