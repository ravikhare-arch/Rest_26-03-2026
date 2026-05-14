<%@ Page Title="Reports" Language="C#" MasterPageFile="~/Pagecontent.master" AutoEventWireup="true" CodeFile="tgeneral_Outstanding.aspx.cs" Inherits="Accounting_tgeneral_Outstanding" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link type="text/css" rel="stylesheet" href="../assets/css/default/mystyle.css" />
    <style>
        input[type="radio"] {
            margin-left: 10px;
            padding-left: 30px;
        }
        .mt-30{
            margin-top: 30px;
        }
    </style>
    <link type="text/css" rel="stylesheet" href="../assets/css/default/mystyle.css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
    <link type="text/css" rel="stylesheet" href="../assets/css/default/mystyle.css" />
    <link href="../assets/css/default/style.min.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.3/umd/popper.min.js" integrity="sha384-vFJXuSJphROIrBnz7yo7oB41mKfc8JzQZiCq4NCceLEaO4IHwicKwpJf9c9IpFgh" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta.2/js/bootstrap.min.js" integrity="sha384-alpBpkh1PFOepccYVYDB4do5UnbKysX5WZXm3XxPqe5iKTfUKjNkCk9SaVuEZflJ" crossorigin="anonymous"></script>
    <%-- <style>
        .content-page .content {
            margin-left: auto;
            margin-right: auto;
            display: block;
            margin-top:0px;
            margin-bottom:0px;
        padding:0px;
        }
        .enlarged #wrapper .content-page {
            margin-left: 0px;
        }
        .topbar {
            display: none;
        }

        .footer {
            display: none;
        }
        .side-menu {
            display: none;
        }
    </style>--%>
    <style>
        .panel-heading-btn label {
            color: #fff;
            margin-right: 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:Label ID="lblmsg" runat="server"></asp:Label>
    <asp:Panel CssClass="tbl" ID="tblmain" runat="server">
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
                        <h4 class="panel-title">General Ledger Reports</h4>
                    </div>
                    <!-- end panel-heading -->
                    <!-- begin panel-body -->
                    <div class="panel-body">
                        <asp:UpdatePanel ID="up1" runat="server">
                            <ContentTemplate>
                                
                               
                                <asp:Panel ID="pnlOutstanding" runat="server">
                                    <fieldset class="the-fieldset m-b-10">
                                        <legend class="the-legend text-black font-weight-bold p-15">Outstanding Reports Agent /Supplier</legend>


                                        <div class="form-group row m-b-15">
                                            <div class="col-md-2 col-sm-4">
                                                <label class="col-form-label" for="email">Report For :</label>
                                                <asp:DropDownList ID="ddlOSReportFor" runat="server" CssClass="form-control js-example-placeholder-single" AutoPostBack="true" OnSelectedIndexChanged="ddlOSReportFor_SelectedIndexChanged">
                                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="SUPPLIER" Value="7"></asp:ListItem>
                                                    <asp:ListItem Text="CLIENT" Value="3"></asp:ListItem>
                                                    <asp:ListItem Text="AIRLINE" Value="12"></asp:ListItem>
                                                    <asp:ListItem Text="ALL AGENT" Value="20"></asp:ListItem>
                                                    <asp:ListItem Text="ALL SUPPLIER" Value="21"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlOSReportFor" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="C"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="col-md-2 col-sm-4">
                                                <label class="col-form-label" for="email">Account Title  :</label>
                                                <asp:DropDownList ID="ddlOSAccount" runat="server" CssClass="form-control js-example-placeholder-single">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="ddlOSAccount" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="C"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="col-md-2 col-sm-4">
                                                <label class="col-form-label" for="email">Account Type  :</label>
                                                <asp:DropDownList ID="ddlOSAccountType" runat="server" CssClass="form-control js-example-placeholder-single">
                                                    <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                    <asp:ListItem Value="Visa" Text="Visa"></asp:ListItem>
                                                    <asp:ListItem Value="AirTicket" Text="Air Ticket"></asp:ListItem>
                                                    <asp:ListItem Value="GroupAirTicket" Text="Group Air Ticket"></asp:ListItem>
                                                    <asp:ListItem Value="Hotels" Text="Hotels"></asp:ListItem>
                                                    <asp:ListItem Value="Excursion" Text="Excursion"></asp:ListItem>
                                                    <asp:ListItem Value="Mofa" Text="Mofa"></asp:ListItem>
                                                    <asp:ListItem Value="GroupMofa" Text="Group Mofa"></asp:ListItem>
                                                    <asp:ListItem Value="Recruitement" Text="Recruitement"></asp:ListItem>
                                                    <asp:ListItem Value="Insurance" Text="Insurance"></asp:ListItem>
                                                    <asp:ListItem Value="Train" Text="Train Tickets"></asp:ListItem>
                                                    <asp:ListItem Value="Bus" Text="Bus Tickets"></asp:ListItem>
                                                    <asp:ListItem Value="Car" Text="Car Booking"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlOSAccountType" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="C"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="col-md-2 col-sm-4">
                                                <label class="col-form-label" for="email">Location  :</label>
                                                <asp:DropDownList ID="ddlOSLocation" runat="server" CssClass="form-control js-example-placeholder-single">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-md-2 col-sm-2">


                                                <label class="col-form-label" for="email">From Date :</label>
                                                <asp:TextBox ID="txtdtOsFrom" runat="server" CssClass="form-control datepicker" Width="100%" placeholder="dd/MM/yyyy" AutoComplete="off"></asp:TextBox>

                                                <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender4" runat="server"
                                                    TargetControlID="txtdtOsFrom" Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ControlToValidate="txtdtOsFrom"
                                                    ValidationGroup="C" Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                                    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                                </asp:RegularExpressionValidator>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtdtOsFrom" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="C"></asp:RequiredFieldValidator>
                                            </div>

                                            <div class="col-md-2  col-sm-2">
                                                <label class="col-form-label" for="email">To Date :</label>
                                                <asp:TextBox ID="txtdtOsTo" runat="server" CssClass="form-control datepicker" Width="100%" placeholder="dd/MM/yyyy" AutoComplete="off"></asp:TextBox>


                                                <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender5" runat="server"
                                                    TargetControlID="txtdtOsTo" Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ControlToValidate="txtdtOsTo"
                                                    ValidationGroup="C" Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                                    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                                </asp:RegularExpressionValidator>
                                               <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtdtOsTo" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="C"></asp:RequiredFieldValidator>
                                            </div>

                                        </div>
                                        <div class="form-group row m-b-0 text-center">
                                            <div class="col-md-12 col-sm-12">
                                                <label>&nbsp;</label>
                                                <asp:Button ID="btnOSSearch" runat="server" CssClass="btn btn-primary" Text="Search" ValidationGroup="C" ToolTip="Search" OnClick="btnOSSearch_Click" />
                                            </div>
                                        </div>
                                    </fieldset>

                                    <fieldset class="the-fieldset">
                                        <legend class="the-legend text-black font-weight-bold p-15">All Agents / Suppliers Outstanding Reports</legend>


                                        <div class="form-group row m-b-15">
                                            <div class="col-md-4 col-sm-4">
                                                <label class="col-form-label" for="email">Report For :</label>
                                                <asp:DropDownList ID="ddlOSRPTTYPE" runat="server" CssClass="form-control js-example-placeholder-single">
                                                    <asp:ListItem Text="SELECT" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="ALL AGENT" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="ALL SUPPLIER" Value="2"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>


                                            <div class="col-md-3 col-sm-2">


                                                <label class="col-form-label" for="email">From Date :</label>
                                                <asp:TextBox ID="txtdtAllOsFrom" runat="server" CssClass="form-control datepicker" Width="100%" placeholder="dd/MM/yyyy" AutoComplete="off"></asp:TextBox>

                                                <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender6" runat="server"
                                                    TargetControlID="txtdtAllOsFrom" Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" ControlToValidate="txtdtAllOsFrom"
                                                    ValidationGroup="D" Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                                    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                                </asp:RegularExpressionValidator>
                                                <%-- <AjaxToolKit:CalendarExtender ID="CalendarExtender5" runat="server" Format="dd/MM/yyyy"
                                                    PopupButtonID="txtdtOsFrom" TargetControlID="txtdtOsFrom" PopupPosition="BottomRight" />--%>
                                            </div>

                                            <div class="col-md-3  col-sm-2">
                                                <label class="col-form-label" for="email">To Date :</label>
                                                <asp:TextBox ID="txtdtAllOsTo" runat="server" CssClass="form-control datepicker" Width="100%" placeholder="dd/MM/yyyy" AutoComplete="off"></asp:TextBox>


                                                <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender7" runat="server"
                                                    TargetControlID="txtdtAllOsTo" Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" ControlToValidate="txtdtAllOsTo"
                                                    ValidationGroup="C" Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                                    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                                </asp:RegularExpressionValidator>
                                                <%--<AjaxToolKit:CalendarExtender ID="CalendarExtender6" runat="server" Format="dd/MM/yyyy"
                                                    PopupButtonID="txtdtOsTo" TargetControlID="txtdtOsTo" PopupPosition="BottomRight" />--%>
                                            </div>
                                            <div class="col-md-2 col-sm-12 mt-30">
                                                <asp:Button ID="btnOSSearchAll" runat="server" CssClass="btn btn-primary" Text="Search" ValidationGroup="D" ToolTip="Search" OnClick="btnOSSearchAll_Click" />
                                            </div>

                                        </div>
                                        <div class="form-group row m-b-0 text-center">
                                        </div>
                                    </fieldset>
                                </asp:Panel>
                                
                            </ContentTemplate>
                        </asp:UpdatePanel>




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

