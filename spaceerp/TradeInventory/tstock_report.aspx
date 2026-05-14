<%@ Page Title="" Language="C#" MasterPageFile="~/Pagecontent.master" AutoEventWireup="true" CodeFile="tstock_report.aspx.cs" Inherits="trading_Stock_item" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />
    <link href="../assets/css/default/style.min.css" rel="stylesheet" />
    <link href="https://cdn.datatables.net/1.10.22/css/dataTables.bootstrap4.min.css" rel="stylesheet" />
    
    <style>
        .form-control {
            border: 1px solid #00bcd4;
            width: 90%;
        }

    </style>


    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    
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
                        <h4 class="panel-title"> Stock Report Details</h4>
                    </div>
                    <!-- end panel-heading -->
                    <!-- begin panel-body -->
                    <div class="panel-body">

                        <div class="form-group row m-b-15">
                            <div class="col-md-6 col-sm-6">
                                <label class="col-form-label" for="email">Report Type  :</label>
                                <asp:DropDownList ID="ddlReportType" runat="server" CssClass="form-control js-example-placeholder-single">
                                    <asp:ListItem Text="Select Report" Value="0"></asp:ListItem>
                                    <asp:ListItem Text=" Stock Report Detail " Value="1"></asp:ListItem>
                                    <asp:ListItem Text=" Stock Report Vendor Wise " Value="2"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RFV2" runat="server" ControlToValidate="ddlReportType" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-2 col-sm-2">
                                <br /><br />
                                <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-primary" Text="Search" ValidationGroup="A"  ToolTip="Search" OnClick="btnSearch_Click" />
                            </div>
                            
                        </div>


                        <div class="form-group row m-b-0 text-center">
                            
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

