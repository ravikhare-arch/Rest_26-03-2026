<%@ Page Title="" Language="C#" MasterPageFile="~/PrintMaster.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="rptPostedVoucher.aspx.cs" Inherits="Accounting_rptPostedVoucher" %>

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
                            <span class="red h3">List Posted Vouchers</span> <span class="invoice-info-label"></span>                           
                              <span class="text-right pull-right" id="hidePrint" runat="server">
                        <a href="tpostedvoucher.aspx" class="btn btn-sm btn btn-info m-b-10 p-l-5" id="btnhome"><i class="fa fa-home t-plus-1 text-white fa-fw fa-lg"></i>Home</a>
                        <a href="javascript:;" onclick="printpage()" class="btn btn-sm btn-info m-b-10 p-l-5" id="btnpdf"><i class="fa fa-file-pdf t-plus-1 text-danger fa-fw fa-lg"></i>Export as PDF</a>
                <a href="javascript:;" onclick="printpage()" class="btn btn-sm btn-warning m-b-10 p-l-5" id="btnprint"><i class="fa fa-print t-plus-1 fa-fw fa-lg"></i>Print</a>
                <asp:Button ID="btnExcel" runat="server" Text="Excel" CssClass="btn btn-sm btn-success m-b-10 p-l-5 " OnClick="btnExcel_Click" />
                <asp:Button ID="btnSendMail" runat="server" Text="Email" CssClass="btn btn-sm btn-primary m-b-10 p-l-5" OnClick="btnSendMail_Click" />
                    </span>
                        </div>
                         <div class="widget-toolbar no-border invoice-info">
                             <span class="invoice-info-label">Date From:</span>
                             <span class="blue"><asp:Label ID="lblDates" runat="server"></asp:Label></span>
                             <span class="pull-right">
                                 <span>User :<span class="red">All,</span></span>
                             <span class="invoice-info-label">Voucher Type.:</span>
                             <span class="red"><asp:Label ID="lblVoucherType" runat="server"></asp:Label></span></span>
                         </div>
                    </div>                    
                    <div class="widget-body">
    <!-- end page-header -->
    <!-- begin invoice -->
    <div class="invoice text-black" id="invoice" runat="server" >
        <!-- begin invoice-company -->
        <div class="invoice-content">
            <!-- begin table-responsive -->
            <div class="table-responsive">

                <asp:DataList CssClass="table table-bordered m-b-0 text-black bg-white" RepeatDirection="Vertical" ID="DataList1" OnItemDataBound="DataList1_ItemDataBound"
                    runat="server">
                    <ItemTemplate>
                        <thead>
                            <tr style="background-color: #1c3967; color: white; height: 40px; text-align: center;">
                                <th>MARK</th>
                                <th>ACCOUNT TITLE</th>
                                <th>DESCRIPTION</th>
                                <th>Debit</th>
                                <th>Credit</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td colspan="5">
                                    <table class="table no-border">
                                       <tr style="height: 40px; text-align: center; padding: 10px; border: 1px solid black;color:black">
                                            <td>
                                                <asp:HiddenField ID="hdn" runat="server" Value='<%#Eval("VoucherNo") %>' />
                                                Date: <%# validation.TextToDate(Eval("[VoucherDate]").ToString()) %></td>
                                            <td>Voucher No.: <%#Eval("[VoucherNo]") %></td>
                                            <td>Voucher Type: <%#Eval("[sVoucherType]") %></td>
                                            <td colspan="2">Posted By: <%#Eval("[sPostedby]") %></td>

                                        </tr>
                                    </table>

                                </td>

                            </tr>
                            <asp:Repeater ID="Gridview1" runat="server">
                                <ItemTemplate>
                                   <tr style="height: 40px; text-align: center; padding: 10px; border: 1px solid black">
                                        <td><%#Eval("[Account Code]") %></td>
                                        <td><%#Eval("[Account Title]") %></td>
                                        <td><%#Eval("[Description]") %></td>
                                        <td><%#Eval("[Debit Amount]") %></td>
                                        <td><%#Eval("[Credit Amount]") %></td>
                                    </tr>

                                </ItemTemplate>
                            </asp:Repeater>

                           <tr style="height: 40px; text-align: center; padding: 10px; border: 1px solid black">
                                <td colspan="3"></td>
                                <td>
                                    <h3><%#Eval("TotDebit") %></h3>
                                </td>
                                <td>
                                    <h3><%#Eval("TotCredit") %></h3>
                                </td>
                            </tr>
                        </tbody>
                    </ItemTemplate>
                </asp:DataList>



            </div>
            <div class="invoice-footer">
                <p class="text-center m-b-5 f-w-600 text-black">
                    THANK YOU FOR YOUR BUSINESS
                   
                </p>

            </div>
            <!-- end invoice-footer -->
            <!-- end invoice -->
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

