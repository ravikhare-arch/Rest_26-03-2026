<%@ Page Title="Profit & Loss" Language="C#" MasterPageFile="~/PrintMaster.master" AutoEventWireup="true" CodeFile="rptProfitLoss_Quaterly.aspx.cs" Inherits="Accounting_rptProfitLoss_Details" %>

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
                            <span class="red h3">Profit And Loss (Quaterly)</span> <span class="invoice-info-label"></span>                           
                              <span class="text-right pull-right" id="hidePrint" runat="server">
                        <a href="tprofit_loss.aspx" class="btn btn-sm btn btn-info m-b-10 p-l-5" id="btnhome"><i class="fa fa-home t-plus-1 text-white fa-fw fa-lg"></i>Home</a>
                            <a href="javascript:;" onclick="printpage()" class="btn btn-sm btn-white m-b-10 p-l-5" id="btnpdf"><i class="fa fa-file-pdf t-plus-1 text-danger fa-fw fa-lg"></i>Export as PDF</a>
                            <a href="javascript:;" onclick="printpage()" class="btn btn-sm btn-warning m-b-10 p-l-5" id="btnprint"><i class="fa fa-print t-plus-1 fa-fw fa-lg"></i>Print</a>
                            <asp:Button ID="btnExcel" runat="server" Text="Excel" CssClass="btn btn-sm btn-success m-b-10 p-l-5 " OnClick="btnExcel_Click" />
                            <asp:Button ID="btnSendMail" runat="server" Text="Email" CssClass="btn btn-sm btn-primary m-b-10 p-l-5" OnClick="btnSendMail_Click" />
                        </span>
                        </div>
                         <div class="widget-toolbar no-border invoice-info">
                             <span class="invoice-info-label">PERIOD :</span>
                             <span class="blue">        <asp:Label ID="lblDate" runat="server" ForeColor="Black"></asp:Label></span>
                             <span class="pull-right">
                                 <span>User :<span class="red">All,</span></span>
                             <span class="invoice-info-label">Voucher Type.:</span>
                             <span class="red"><asp:Label ID="lblVoucherType" runat="server"></asp:Label></span></span>
                         </div>
                    </div>                    
      <div class="widget-body"> 
    <div class="invoice bg-grey-lighter" id="invoice" runat="server">
        <div class="container-fluid bg-white">
            
            <h4 class="text-center">Income/ Revenue</h4>
            <asp:GridView ID="GridView1" runat="server" Width="100%" BorderStyle="Solid" BorderWidth="1" RowStyle-ForeColor="Black" HeaderStyle-Height="40px" RowStyle-Height="40px" CellPadding="15" HeaderStyle-BackColor="#0f2540" HeaderStyle-ForeColor="White">
            </asp:GridView>
            <br />
            <br />
            <%--<asp:GridView ID="GridView2" runat="server" Width="100%" BorderStyle="Solid" BorderWidth="1" RowStyle-ForeColor="Black" HeaderStyle-Height="40px" CellPadding="15" RowStyle-Height="40px" HeaderStyle-BackColor="#0f2540" HeaderStyle-ForeColor="White">
            </asp:GridView>--%>
            <hr />

            <h4 class="text-center">Expenses</h4>
            <asp:GridView ID="GridView3" runat="server" Width="100%" BorderStyle="Solid" BorderWidth="1" RowStyle-ForeColor="Black" HeaderStyle-Height="40px" CellPadding="15" RowStyle-Height="40px" HeaderStyle-BackColor="#0f2540" HeaderStyle-ForeColor="White">
            </asp:GridView>
            <br />
            <br />
           <%-- <asp:GridView ID="GridView4" runat="server" Width="100%" BorderStyle="Solid" BorderWidth="1" RowStyle-ForeColor="Black" HeaderStyle-Height="40px" RowStyle-Height="40px" HeaderStyle-BackColor="#0f2540" HeaderStyle-ForeColor="White">
            </asp:GridView>--%>
            

            <h4 class="text-center">Profit/ Loss</h4>
            <table style="border: 1px; width: 99%; margin-bottom: 30px; color: black;">
                <tr style="background-color: #1c3967; color: white; height: 40px; text-align: center;">
                    <th>Month - Year
                    </th>
                    <th>Income / Revenue
                    </th>
                    <th>Expenses
                    </th>
                    <th>Gross Profit / Loss
                    </th>
                    <th>Tax
                    </th>
                    <th>Net profit / Loss
                    </th>
                </tr>
                <asp:Repeater ID="rptPl" runat="server">
                    <ItemTemplate>
                        <tr style="color: black; height: 40px; text-align: center; border: 1px solid black">
                            <td><%#Eval("Category") %></td>
                            <td><%#Eval("Income") %></td>
                            <td><%#Eval("Expenses") %></td>
                            <td><%#Eval("GrossPl") %></td>
                            <td><%#Eval("Tax") %></td>
                            <td class="font-weight-bold"><%#Eval("NetPl") %></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr style="background-color: #888888; color: white; height: 40px; text-align: center; font-weight: bold; border: 1px solid black">
                    <td>Grand Total</td>
                    <td>
                        <asp:Label ID="lblIncome" runat="server"></asp:Label></td>
                    <td>
                        <asp:Label ID="lblExp" runat="server"></asp:Label></td>
                    <td>
                        <asp:Label ID="lblGrossPl" runat="server"></asp:Label></td>
                    <td>
                        <asp:Label ID="lblTax" runat="server"></asp:Label></td>
                    <td>
                        <asp:Label ID="lblNetPL" runat="server"></asp:Label></td>

                </tr>
            </table>

            <br />
            <br />
        </div>
    </div>
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

