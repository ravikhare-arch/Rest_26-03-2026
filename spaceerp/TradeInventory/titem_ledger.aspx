<%@ Page Title="" Language="C#" MasterPageFile="~/Pagecontent.master" AutoEventWireup="true" CodeFile="titem_ledger.aspx.cs" Inherits="Trading_titemledger" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />
    <link href="../assets/css/default/style.min.css" rel="stylesheet" />
    <link href="https://cdn.datatables.net/1.10.22/css/dataTables.bootstrap4.min.css" rel="stylesheet" />
    <style>
        /*.modal-xl{ 
                 max-width :75%;
                 max-height:60vh;
             }*/
        .modal-body {
            max-height: 80vh;
            overflow-x: hidden;
            overflow-y: scroll;
        }

        .form-group {
            margin-bottom: 0px;
        }
    </style>
    <style>
        .form-control {
            border: 1px solid #00bcd4;
            width: 90%;
        }

        .nopad {
            padding: 0;
        }

        .full-wdth {
            width: 100% !important;
        }
    </style>


    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <style>
        .row {
            margin-right: 0px;
            margin-left: 0px;
        }
    </style>
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
                        <h4 class="panel-title">Item Ledger</h4>
                    </div>
                    <!-- end panel-heading -->
                    <!-- begin panel-body -->
                    <div class="panel-body">

                        <div class="form-group row m-b-15">
                            <div class="col-md-4 col-sm-4">
                                <label class="col-form-label" for="email">Item Name  :</label>
                                <asp:DropDownList ID="ddlItemName" runat="server" CssClass="form-control js-example-placeholder-single">
                                   
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RFV2" runat="server" ControlToValidate="ddlItemName" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-3 col-sm-3" style="z-index:9999;">


                                <label class="col-form-label" for="email">From Date :</label>
                                <asp:TextBox ID="txtdtFrom" runat="server" CssClass="form-control"></asp:TextBox>

                                <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender1" runat="server"
                                    TargetControlID="txtdtFrom" Mask="99/99/9999" MaskType="Date" AcceptNegative="None"  />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtdtFrom"
                                    ValidationGroup="A" Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                </asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtdtFrom" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>

                            </div>
                            <div class="col-md-1 col-sm-1" style="padding-top: 23px; padding-left: 0px">
                                <AjaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy"
                                    PopupButtonID="Img4" TargetControlID="txtdtFrom" PopupPosition="BottomRight" />
                                <asp:ImageButton ID="Img4" runat="server" ImageUrl="~/assets/img/Calendar-icon.png"
                                    Width="32" Height="32" />
                            </div>
                            <div class="col-md-3  col-sm-3">
                                <label class="col-form-label" for="email">To Date :</label>
                                <asp:TextBox ID="txtdtToDate" runat="server" CssClass="form-control"></asp:TextBox>


                                <AjaxToolKit:MaskedEditExtender ID="MEE3" runat="server"
                                    TargetControlID="txtdtToDate" Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                <asp:RegularExpressionValidator ID="REV3" ControlToValidate="txtdtToDate"
                                    ValidationGroup="A" Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                </asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="RFV3" runat="server" ControlToValidate="txtdtToDate" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-1 col-sm-1" style="padding-top: 23px; padding-left: 0px">
                                <AjaxToolKit:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd/MM/yyyy"
                                    PopupButtonID="Img3" TargetControlID="txtdtToDate" PopupPosition="BottomRight" />
                                <asp:ImageButton ID="Img3" runat="server" ImageUrl="~/assets/img/Calendar-icon.png"
                                    Width="32" Height="32" />
                            </div>
                            
                        </div>


                        <div class="form-group row m-b-0 text-center">
                            <div class="col-md-12 col-sm-12">
                                <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-primary" Text="Search" ValidationGroup="A"  ToolTip="Search" OnClick="btnSearch_Click" />
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

