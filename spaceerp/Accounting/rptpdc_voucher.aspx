<%@ Page Title="" Language="C#" MasterPageFile="~/PrintMaster.master" AutoEventWireup="true" CodeFile="rptpdc_voucher.aspx.cs" Inherits="Accounting_rptpdc_voucher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
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
    
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    <link href="../../css/StatementSheet.css" rel="stylesheet" />
    <style>
        .widget-box{
            width: 100%;
        }
        .label-lg{
          line-height: 2;
        }
        .btborder{
            border-top: 1px solid black;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">    
    <div class="container-fluid" id="invoice" runat="server">
         <div class="row">                
                <div class="widget-box">
                    <div class="widget-header widget-header-large">
                        <%--<img src="logo.png" />--%>
                        <asp:Image ID="imgComp" runat="server" AlternateText="" Height="100px" Style="display: none" />
                        <div class="widget-toolbar no-border invoice-info center-block">
                            <span class="invoice-info-label">
                                <asp:Label ID="lblVType" runat="server"></asp:Label></span>
                            <span class="red h3">PDC/PDCR Voucher</span> <span class="invoice-info-label"></span>                           
                              <span class="text-right pull-right" id="hidePrint" runat="server">
                        <a href="tpdc_voucher.aspx" class="btn btn-sm btn btn-info m-b-10 p-l-5" id="btnhome"><i class="fa fa-home t-plus-1 text-white fa-fw fa-lg"></i>Home</a>
                        <a href="javascript:;" onclick="printpage()" class="btn btn-sm btn-white m-b-10 p-l-5" id="btnpdf"><i class="fa fa-file-pdf t-plus-1 text-danger fa-fw fa-lg"></i>Export as PDF</a>
                        <a href="javascript:;" onclick="printpage()" class="btn btn-sm btn-warning m-b-10 p-l-5" id="btnprint"><i class="fa fa-print t-plus-1 fa-fw fa-lg"></i>Print</a>
                        <asp:Button ID="btnExcel" runat="server" Text="Excel" CssClass="btn btn-sm btn-success m-b-10 p-l-5 " OnClick="btnExcel_Click" />
                        <asp:Button ID="btnSendMail" runat="server" Text="Email" CssClass="btn btn-sm btn-primary m-b-10 p-l-5" OnClick="btnSendMail_Click" />
                    </span>
                        </div>
                         <div class="widget-toolbar no-border invoice-info">
                             <span class="invoice-info-label">Date:</span>
                             <span class="blue"><asp:Label ID="lblDate" runat="server"></asp:Label></span>
                             <span class="pull-right">
                             <span class="invoice-info-label">PDC/PDCR Voucher No.:</span>
                             <span class="red"><asp:Label ID="lblVoucherNo" runat="server"></asp:Label></span></span>
                         </div>
                    </div>                    
                    <div class="widget-body">
                        <div class="widget-main padding-24">
                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="row">
                                        <div class="col-xs-11 label label-lg label-info arrowed-in arrowed-right">
                                            <b>Company Info</b>
                                        </div>
                                    </div>
                                    <div>
                                        <ul class="list-unstyled spaced">
                                            <li><i class="ace-icon fa fa-caret-right blue"></i>
                                                <%--<asp:Label ID="lblCompanyName" runat="server"></asp:Label>--%><asp:Label ID="lblVoucherType" runat="server"></asp:Label></li>
                                            <li><i class="ace-icon fa fa-caret-right blue"></i>
                                                <asp:Label ID="lblAddress" runat="server"></asp:Label></li>
                                            <li style="display: none;"><i class="ace-icon fa fa-caret-right blue"></i>
                                                <asp:Label ID="lblCity" runat="server"></asp:Label>,
                                                <asp:Label ID="lblCountry" runat="server"></asp:Label></li>
                                            <li><i class="ace-icon fa fa-caret-right blue"></i>Phone: <b class="red">
                                                <asp:Label ID="lblPhoneNo" runat="server"></asp:Label></b></li>
                                            <li style="display: none;"><i class="ace-icon fa fa-caret-right blue"></i>Fax: <b class="red">
                                                <asp:Label ID="lblFax" runat="server"></asp:Label></b></li>

                                            <li><i class="ace-icon fa fa-caret-right blue"></i>Email: <b class="red">
                                                <asp:Label ID="lblEmail" runat="server"></asp:Label></b> Website: <b class="red">
                                                    <asp:Label ID="lblWebsite" runat="server"></asp:Label></b></li>
                                            <li><i class="ace-icon fa fa-caret-right blue"></i>GST <b class="red">
                                                <asp:Label ID="lblCompGstNo" runat="server"></asp:Label></b></li>
                                            <li class="divider"></li>
                                            <%--<li> <i class="ace-icon fa fa-caret-right blue"></i> Paymant Info</li>--%>
                                        </ul>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="row">
                                        <div class="col-xs-11 label label-lg label-success arrowed-in arrowed-right"><b>Customer Info</b></div>
                                    </div>
                                    <div>
                                        <ul class="list-unstyled  spaced">
                                            <li>
                                                <i class="ace-icon fa fa-caret-right green"></i>
                                                <asp:Label ID="lblCompanyName1" runat="server"></asp:Label></li>
                                            <li><i class="ace-icon fa fa-caret-right green"></i>
                                                <asp:Label ID="lblcompanyAdd" runat="server"></asp:Label></li>
                                            <li style="display: none;"><i class="ace-icon fa fa-caret-right green"></i>
                                                <asp:Label ID="lblAgntCity" runat="server"></asp:Label>,
                                                <asp:Label ID="lblAgentCountry" runat="server"></asp:Label></li>
                                            <li><i class="ace-icon fa fa-caret-right blue"></i>Phone: <b class="red">
                                                                        <asp:Label ID="lblPhone" runat="server"></asp:Label></b></li>
                                            <li style="display: none;"><i class="ace-icon fa fa-caret-right blue"></i>Fax: <b class="red">
                                                <asp:Label ID="Label1" runat="server"></asp:Label></b></li>
                                            <li><i class="ace-icon fa fa-caret-right blue"></i>Bank Name: <asp:Label ID="lblBank" runat="server"></asp:Label></li>

                                            <li><i class="ace-icon fa fa-caret-right blue"></i>GST <b class="red">
                                                27BMXPA6006N1ZL</b></li>

                                            <%--<li class="divider"></li><li> <i class="ace-icon fa fa-caret-right green"></i> Contact Info</li>--%>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                            <div class="space"></div>

                        </div>
                        <div class="invoice-detail">
        <div class="invoice-content">
            <!-- begin table-responsive -->
            <div class="table-responsive">
                <asp:GridView ID="GridView1" CssClass="table table-striped table-bordered" runat="server"
                    AutoGenerateColumns="False" EmptyDataText="No Records to display" DataKeyNames="nPdcVoucherDetID"
                    Width="100%" AllowPaging="true" AllowSorting="True" PageSize="25">
                    <Columns>
                        <asp:TemplateField HeaderText="nPdcVoucherDetID" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblID" runat="server" Text='<%# Eval("nPdcVoucherDetID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="sCode" HeaderText="Mark" />
                        <asp:BoundField DataField="sAccountTitle" HeaderText="Account Title" />
                        <asp:BoundField DataField="sDescription" HeaderText="Description" />
                        <asp:BoundField DataField="sChequeNo" HeaderText="Cheque No." />
                        <asp:TemplateField HeaderText="Cheque Date">
                            <ItemTemplate>
                                <%#validation.TextToDate(Eval("dtCheque").ToString())%>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="sCurrency" HeaderText="Currency" />
                        <asp:BoundField DataField="nLocalAmount" HeaderText="Amount" />
                    </Columns>
                </asp:GridView>
                <div class="hr hr8 hr-double hr-dotted"></div>
                <div class="row">
                     <div class="col-sm-7 pull-left"><h4 class="pull-left"> SUB TOT. <span class="red"><asp:Label ID="lblSubTot" runat="server"></asp:Label></span></h4></div>              
                    <div class="col-sm-5 text-right pull-right">
                        <h4 class="pull-right"> GRAND TOTAL : <span class="red"><asp:Label ID="lblGrandtotal" runat="server"></asp:Label></span></h4></div>
                   </div> 
                <div class="hr hr8 hr-double hr-dotted"></div>
            </div>
            <!-- end table-responsive -->
            <div class="well text-center">
                                    Thank you for Your business.
                                    We believe you will be satisfied by our services.
                                </div>
                    <div class="row">
                    <div class="col-sm-4 text-center btborder">Cashier</div>
                    <div class="col-sm-4 text-center btborder">Checked by</div>
                    <div class="col-sm-4 text-center btborder">Approved by
                        </div>
                    </div>
            <!-- end invoice-price -->
        </div>
        <!-- end invoice-content -->
        <%--<div class="invoice-footer">
            <p class="text-center m-b-5 f-w-600">
                THANK YOU FOR YOUR BUSINESS
                   
            </p>

        </div>--%>
        <!-- end invoice-footer -->
    </div>
                    </div>
             </div>
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

