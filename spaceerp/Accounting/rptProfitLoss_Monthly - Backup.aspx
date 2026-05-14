<%@ Page Title="" Language="C#" MasterPageFile="~/PrintMaster.master" AutoEventWireup="true" CodeFile="rptProfitLoss_Monthly - Backup.aspx.cs" Inherits="Accounting_rptProfitLoss_Details" %>

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

    <ol class="breadcrumb hidden-print pull-right" id="tplink">
        <li class="breadcrumb-item"><a href="tprofit_loss.aspx">Home</a></li>
        <li class="breadcrumb-item active">Profit And Loss</li>
    </ol>
    <h1 class="page-header hidden-print">Profit And Loss </h1>
    <div class="invoice bg-grey-lighter" id="invoice" runat="server">
        <!-- begin invoice-company -->
        <div class="invoice-company text-inverse f-w-600">
            <div class="pull-right hidden-print" id="hidePrint" runat="server">
                 <a href="javascript:;" onclick="printpage()" class="btn btn-sm btn-white m-b-10 p-l-5" id="btnpdf"><i class="fa fa-file-pdf t-plus-1 text-danger fa-fw fa-lg"></i>Export as PDF</a>
                <a href="javascript:;" onclick="printpage()" class="btn btn-sm btn-warning m-b-10 p-l-5" id="btnprint"><i class="fa fa-print t-plus-1 fa-fw fa-lg"></i>Print</a>

                <asp:Button ID="btnExcel" runat="server" Text="Excel" CssClass="btn btn-sm btn-success m-b-10 p-l-5 " OnClick="btnExcel_Click" />
                <asp:Button ID="btnSendMail" runat="server" Text="Email" CssClass="btn btn-sm btn-primary m-b-10 p-l-5" OnClick="btnSendMail_Click" />
            </div>
            <asp:Label ID="lblCompanyName" runat="server"></asp:Label>
            <div class="text-center">
                <h3>Profit And Loss (Monthly) </h3>
            </div>
        </div>

        <asp:Label ID="lblDate" runat="server" ForeColor="Black"></asp:Label>



        <div class="container-fluid bg-white">
            <h4 class="p-10">Profit/ Loss</h4>
            <table class="table table-hover text-black">
                <thead>
                    <th>Month -Year
                    </th>
                    <th>Income / Revenue
                    </th>
                    <th>Expenses
                    </th>
                    <th>Total
                    </th>
                </thead>
                <tbody>
                    <asp:Repeater ID="rptPl" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("sMonthName") %> -<%#Eval("sYear") %></td>
                                <td><%#Eval("sIncome") %></td>
                                <td><%#Eval("sExpense") %></td>
                                <td class="font-weight-bold"><%#Eval("nTotal") %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr class="text-black bg-grey font-weight-bold">
                        <td>Grand Total</td>
                        <td>
                            <asp:Label ID="lblIncome" runat="server"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblExp" runat="server"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblProfitLoss" runat="server"></asp:Label></td>

                    </tr>
                </tbody>
            </table>
            <h4 class="p-10">Income/ Revenue</h4>
            <asp:GridView ID="GridView1" runat="server" Width="100%" CssClass="table table-hover text-black" HeaderStyle-BackColor="#0f2540" HeaderStyle-ForeColor="White" CellPadding="15">
            </asp:GridView>
            <asp:GridView ID="GridView2" runat="server" Width="100%" CssClass="table table-hover text-black" HeaderStyle-BackColor="#0f2540" HeaderStyle-ForeColor="White">
            </asp:GridView>
            <hr />

            <h4 class="p-10">Expenses</h4>
            <asp:GridView ID="GridView3" runat="server" Width="100%" CssClass="table table-hover text-black" HeaderStyle-BackColor="#0f2540" HeaderStyle-ForeColor="White">
            </asp:GridView>
            <asp:GridView ID="GridView4" runat="server" Width="100%" CssClass="table table-hover text-black" HeaderStyle-BackColor="#0f2540" HeaderStyle-ForeColor="White">
            </asp:GridView>
            <br />
            <br />
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

