<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="tpay_receivables.aspx.cs" Inherits="Accounting_ttrailbalance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="vmsg" runat="Server">
    <asp:Label ID="lblmsg" runat="server"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="vtitle" runat="Server">
    Payables And Receivables
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:Panel class="tbl" ID="tblmain" runat="server">
        <!-- begin row -->
        <div class="row">
            <!-- begin col-6 -->
            <div class="col-lg-12">
                <!-- begin panel -->
                <div class="panel panel-inverse">
                    <!-- begin panel-heading -->
                    <div class="panel-heading">
                        <div class="panel-heading-btn">
                            <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                            <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                        </div>
                        <h4 class="panel-title">Payables And Receivables Details</h4>
                    </div>
                    <!-- end panel-heading -->
                    <!-- begin panel-body -->
                    <div class="panel-body">

                        <div class="form-group row m-b-15">
                            <div class="col-md-6">
                                <asp:DropDownList ID="optReportType" runat="server" CssClass="form-control">
                                    <asp:ListItem Text="Payables" Value="1" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="Receivables" Value="2"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-3 col-sm-3" style="z-index: 9999;">
                                <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-primary" Text="Search" ValidationGroup="A" ToolTip="Search" OnClick="btnSearch_Click" />
                            </div>

                        </div>
                       
                    </div>
                <!-- end panel-body -->

            </div>
            <!-- end panel -->
        </div>
        <!-- end col-6 -->

        </div>
        <!-- end row -->
    </asp:Panel>
</asp:Content>

