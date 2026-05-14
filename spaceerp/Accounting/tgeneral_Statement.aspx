<%@ Page Title="Reports" Language="C#" MasterPageFile="~/Pagecontent.master" AutoEventWireup="true" CodeFile="tgeneral_Statement.aspx.cs" Inherits="Accounting_tgeneral_Statement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link type="text/css" rel="stylesheet" href="../assets/css/default/mystyle.css" />
    <style>
        input[type="radio"] {
            margin-left: 10px;
            padding-left: 30px;
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
                               
                                <asp:Panel ID="pnlStatement" runat="server">
                                    <fieldset class="the-fieldset">
                                        <legend class="the-legend text-black">Statements</legend>
                                        <div class="form-group row m-b-15">
                                            <div class="col-md-2 col-sm-4">
                                                <label class="col-form-label" for="email">Report For :</label>
                                                <asp:DropDownList ID="ddlStReportFor" runat="server" CssClass="form-control js-example-placeholder-single" AutoPostBack="true" OnSelectedIndexChanged="ddlStReportFor_SelectedIndexChanged">
                                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="SUPPLIER" Value="7"></asp:ListItem>
                                                    <asp:ListItem Text="CLIENT" Value="3"></asp:ListItem>
                                                    <asp:ListItem Text="AIRLINE" Value="12"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="ddlStAccountTitle" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="col-md-2 col-sm-4">
                                                <label class="col-form-label" for="email">Account Title  :</label>
                                                <asp:DropDownList ID="ddlStAccountTitle" runat="server" CssClass="form-control js-example-placeholder-single">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="ddlStAccountTitle" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="col-md-2 col-sm-4">
                                                <label class="col-form-label" for="email">Account Type  :</label>
                                                <asp:DropDownList ID="ddlStAccountType" runat="server" CssClass="form-control js-example-placeholder-single">
                                                    <asp:ListItem Text="SELECT TYPE" Value="-1"></asp:ListItem>
                                                     <asp:ListItem Text="All" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="VISA" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="TICKETING (AIR)" Value="2"></asp:ListItem>
                                                    <asp:ListItem Text="HOTEL BOOKING" Value="3"></asp:ListItem>
                                                    <asp:ListItem Text="EXCURSION BOOKING" Value="4"></asp:ListItem>
                                                    <asp:ListItem Text="TRAIN TICKET BOOKING" Value="5"></asp:ListItem>
                                                    <asp:ListItem Text="BUS TICKET BOOKING" Value="6"></asp:ListItem>
                                                    <asp:ListItem Text="CAR BOOKING" Value="7"></asp:ListItem>
                                                    <asp:ListItem Text="UMRAH MOFA BOOKING" Value="8"></asp:ListItem>
                                                    <asp:ListItem Text="INSURANCE BOOKING" Value="9"></asp:ListItem>
                                                    <asp:ListItem Text="MOFA RECRUITEMENT" Value="10"></asp:ListItem>
                                                    <asp:ListItem Text="GROUP UMRAH MOFA" Value="11"></asp:ListItem>
                                                    <asp:ListItem Text="GROUP AIR TICKET" Value="12"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlStAccountType" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="-1" ValidationGroup="B"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="col-md-2 col-sm-4">
                                                <label class="col-form-label" for="email">Location  :</label>
                                                <asp:DropDownList ID="ddlLocation" runat="server" CssClass="form-control js-example-placeholder-single">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-md-2 col-sm-2" style="z-index: 9999;">


                                                <label class="col-form-label" for="email">From Date :</label>
                                                <asp:TextBox ID="txtStdtFrom" runat="server" CssClass="form-control datepicker" Width="100%" placeholder="dd/MM/yyyy" AutoComplete="off"></asp:TextBox>

                                                <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender2" runat="server"
                                                    TargetControlID="txtStdtFrom" Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtStdtFrom"
                                                    ValidationGroup="A" Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                                    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                                </asp:RegularExpressionValidator>
                                                <%-- <AjaxToolKit:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy"
                                                    PopupButtonID="txtStdtFrom" TargetControlID="txtStdtFrom" PopupPosition="BottomRight" />--%>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ControlToValidate="txtStdtFrom" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                                            </div>

                                            <div class="col-md-2  col-sm-2">
                                                <label class="col-form-label" for="email">To Date :</label>
                                                <asp:TextBox ID="txtStdtToDate" runat="server" CssClass="form-control datepicker" Width="100%" placeholder="dd/MM/yyyy" AutoComplete="off"></asp:TextBox>


                                                <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender3" runat="server"
                                                    TargetControlID="txtStdtToDate" Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="txtStdtToDate"
                                                    ValidationGroup="A" Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                                    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                                </asp:RegularExpressionValidator>
                                                <%-- <AjaxToolKit:CalendarExtender ID="CalendarExtender4" runat="server" Format="dd/MM/yyyy"
                                                    PopupButtonID="txtStdtToDate" TargetControlID="txtStdtToDate" PopupPosition="BottomRight" />--%>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ControlToValidate="txtStdtToDate" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                                            </div>

                                        </div>
                                        <div class="form-group row m-b-0 text-center">
                                            <div class="col-md-12 col-sm-12">
                                                <asp:Button ID="btnSearchSt" runat="server" CssClass="btn btn-primary" Text="Search" ValidationGroup="B" ToolTip="Search" OnClick="btnSearchSt_Click" />
                                            </div>
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

