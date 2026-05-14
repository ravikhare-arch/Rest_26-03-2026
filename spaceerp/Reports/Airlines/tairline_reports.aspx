<%@ Page Title="Reports" Language="C#" MasterPageFile="~/Pagecontent.master" AutoEventWireup="true" CodeFile="tairline_reports.aspx.cs" Inherits="Accounting_tgeneralledger" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link type="text/css" rel="stylesheet" href="../assets/css/default/mystyle.css" />
    <style >
        input[type="radio"] {
            margin-left: 10px;
            padding-left: 30px;
        }
    </style>
    <link href="../../assets/css/default/style.min.css" rel="stylesheet" />
 <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
    <link type="text/css" rel="stylesheet" href="../assets/css/default/mystyle.css" />
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.3/umd/popper.min.js" integrity="sha384-vFJXuSJphROIrBnz7yo7oB41mKfc8JzQZiCq4NCceLEaO4IHwicKwpJf9c9IpFgh" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta.2/js/bootstrap.min.js" integrity="sha384-alpBpkh1PFOepccYVYDB4do5UnbKysX5WZXm3XxPqe5iKTfUKjNkCk9SaVuEZflJ" crossorigin="anonymous"></script>
    
     <%--  <style>
        .content-page .content {
            margin-left: auto;
            margin-right: auto;
            display: block;
          margin-top: 0px;
          margin-bottom: 0;
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
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

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
                        <h4 class="panel-title">Airline Wise Sales Reports</h4>
                    </div>
                    <!-- end panel-heading -->
                    <!-- begin panel-body -->
                    <div class="panel-body">
                        <asp:UpdatePanel ID="up1" runat="server">
                            <ContentTemplate>
                                <div class="form-group row m-b-15">
                                    <div>&nbsp;</div>
                                    <div class="col-md-12 col-sm-12">
                                        <asp:RadioButtonList ID="optReport" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="text-center form-control" style="border: none;" AutoPostBack="true" OnSelectedIndexChanged="optReport_SelectedIndexChanged">
                                            <asp:ListItem Text="Airline Sales" Value="1" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="Airline Refund" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="Airline Taxes" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="Airline Sales Summary" Value="4"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                </div>
                                <asp:Panel ID="pnlAirlineSales" runat="server">
                                    <fieldset class="the-fieldset">
                                        <div class="form-group row m-b-15">
                                            <div class="col-md-2 col-sm-3">
                                                <label class="col-form-label" for="email">Report For :</label>
                                                <asp:DropDownList ID="ddlReportFor" runat="server" CssClass="form-control js-example-placeholder-single" AutoPostBack="true" OnSelectedIndexChanged="ddlReportFor_SelectedIndexChanged">
                                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="ALL AIRLINE" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="AIRLINE WISE" Value="2"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlReportFor" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="col-md-2 col-sm-3">
                                                <label class="col-form-label" for="email">Airline (Optional)  :</label>
                                                <asp:DropDownList ID="ddlAirline" runat="server" CssClass="form-control js-example-placeholder-single">
                                                </asp:DropDownList>

                                            </div>
                                            <div class="col-md-2 col-sm-3">
                                                <label class="col-form-label" for="email">Account Type :</label>
                                                <asp:DropDownList ID="ddlAccountType" runat="server" CssClass="form-control js-example-placeholder-single" AutoPostBack="true" OnSelectedIndexChanged="ddlAccountType_SelectedIndexChanged">
                                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="SUPPLIER" Value="7"></asp:ListItem>
                                                    <asp:ListItem Text="CLIENT" Value="3"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlAccountType" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                                            </div>

                                            <div class="col-md-2 col-sm-3">
                                                <label class="col-form-label" for="email">Account Title  :</label>
                                                <asp:DropDownList ID="ddlAccountTitle" runat="server" CssClass="form-control js-example-placeholder-single">
                                                </asp:DropDownList>
                                                <%--<asp:RequiredFieldValidator ID="RFV2" runat="server" ControlToValidate="ddlAccountTitle" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>--%>
                                            </div>
                                            <div class="col-md-3 col-sm-4">
                                                <label class="col-form-label" for="email">Branch  :</label>
                                                <asp:DropDownList ID="ddlBranches" runat="server" CssClass="form-control js-example-placeholder-single">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-md-2 col-sm-3">


                                                <label class="col-form-label" for="email">From Date :</label>
                                                <asp:TextBox ID="txtdtFrom" runat="server" CssClass="form-control datepicker" Width="100%" Style="z-index: 9999;" placeholder="dd/MM/yyyy" AutoComplete="off"></asp:TextBox>

                                                <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender1" runat="server"
                                                    TargetControlID="txtdtFrom" Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtdtFrom"
                                                    ValidationGroup="A" Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                                    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                                </asp:RegularExpressionValidator>
                                                <%--<AjaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy"
                                                    PopupButtonID="txtdtFrom" TargetControlID="txtdtFrom" PopupPosition="BottomRight" />--%>
                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtdtFrom" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>--%>
                                            </div>

                                            <div class="col-md-2  col-sm-2">
                                                <label class="col-form-label" for="email">To Date :</label>
                                                <asp:TextBox ID="txtdtToDate" runat="server" CssClass="form-control datepicker" Width="100%" placeholder="dd/MM/yyyy" AutoComplete="off"></asp:TextBox>


                                                <AjaxToolKit:MaskedEditExtender ID="MEE3" runat="server"
                                                    TargetControlID="txtdtToDate" Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                                <asp:RegularExpressionValidator ID="REV3" ControlToValidate="txtdtToDate"
                                                    ValidationGroup="A" Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                                    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                                </asp:RegularExpressionValidator>
                                                <%--<AjaxToolKit:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd/MM/yyyy"
                                                    PopupButtonID="txtdtToDate" TargetControlID="txtdtToDate" PopupPosition="BottomRight" />--%>
                                                <%--<asp:RequiredFieldValidator ID="RFV3" runat="server" ControlToValidate="txtdtToDate" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>--%>
                                            </div>

                                        </div>
                                        <div class="form-group row m-b-0 text-center">
                                            <div class="col-md-12 col-sm-12">
                                                <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-primary btnspl" Text="Search" ValidationGroup="A" ToolTip="Search" OnClick="btnSearch_Click" />
                                            </div>
                                        </div>
                                    </fieldset>
                                </asp:Panel>
                                <asp:Panel ID="pnlAirlineRefund" runat="server">
                                    <fieldset class="the-fieldset">
                                        <%--<legend class="the-legend text-black">Airline Refund Reports</legend>--%>
                                        <div class="form-group row m-b-15">
                                            <div class="col-md-2 col-sm-3">
                                                <label class="col-form-label" for="email">Report For :</label>
                                                <asp:DropDownList ID="ddlRefundReportFor" runat="server" CssClass="form-control js-example-placeholder-single" AutoPostBack="true" OnSelectedIndexChanged="ddlRefundReportFor_SelectedIndexChanged">
                                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="ALL AIRLINE" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="AIRLINE WISE" Value="2"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlRefundReportFor" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="B"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="col-md-2 col-sm-3">
                                                <label class="col-form-label" for="email">Airline (Optional)  :</label>
                                                <asp:DropDownList ID="ddlRefundAirline" runat="server" CssClass="form-control js-example-placeholder-single">
                                                </asp:DropDownList>

                                            </div>
                                            <div class="col-md-2 col-sm-3">
                                                <label class="col-form-label" for="email">Account Type :</label>
                                                <asp:DropDownList ID="ddlAccountTypeRefund" runat="server" CssClass="form-control js-example-placeholder-single" AutoPostBack="true" OnSelectedIndexChanged="ddlAccountTypeRefund_SelectedIndexChanged">
                                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="SUPPLIER" Value="7"></asp:ListItem>
                                                    <asp:ListItem Text="CLIENT" Value="3"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlAccountTypeRefund" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="B"></asp:RequiredFieldValidator>
                                            </div>

                                            <div class="col-md-2 col-sm-3">
                                                <label class="col-form-label" for="email">Account Title  :</label>
                                                <asp:DropDownList ID="ddlRefundAccountTitle" runat="server" CssClass="form-control js-example-placeholder-single">
                                                </asp:DropDownList>
                                                <%--<asp:RequiredFieldValidator ID="RFV2" runat="server" ControlToValidate="ddlAccountTitle" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>--%>
                                            </div>
                                            <div class="col-md-3 col-sm-4">
                                                <label class="col-form-label" for="email">Branch  :</label>
                                                <asp:DropDownList ID="ddlRefundBranch" runat="server" CssClass="form-control js-example-placeholder-single">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-md-2 col-sm-3">


                                                <label class="col-form-label" for="email">From Date :</label>
                                                <asp:TextBox ID="txtdtFromRefund" runat="server" CssClass="form-control datepicker" Width="100%" Style="z-index: 9999;" placeholder="dd/MM/yyyy" AutoComplete="off"></asp:TextBox>

                                                <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender10" runat="server"
                                                    TargetControlID="txtdtFromRefund" Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator10" ControlToValidate="txtdtFromRefund"
                                                    ValidationGroup="B" Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                                    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                                </asp:RegularExpressionValidator>
                                                <%--<AjaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy"
                                                    PopupButtonID="txtdtFrom" TargetControlID="txtdtFrom" PopupPosition="BottomRight" />--%>
                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtdtFrom" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>--%>
                                            </div>

                                            <div class="col-md-2  col-sm-2">
                                                <label class="col-form-label" for="email">To Date :</label>
                                                <asp:TextBox ID="txtdtToDateRefund" runat="server" CssClass="form-control datepicker" Width="100%" placeholder="dd/MM/yyyy" AutoComplete="off"></asp:TextBox>


                                                <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender11" runat="server"
                                                    TargetControlID="txtdtToDateRefund" Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator11" ControlToValidate="txtdtToDateRefund"
                                                    ValidationGroup="B" Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                                    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                                </asp:RegularExpressionValidator>

                                            </div>

                                        </div>
                                        <div class="form-group row m-b-0 text-center">
                                            <div class="col-md-12 col-sm-12">
                                                <asp:Button ID="btnSearchRefund" runat="server" CssClass="btn btn-primary btnspl" Text="Search" ValidationGroup="B" ToolTip="Search" OnClick="btnSearchRefund_Click" />
                                            </div>
                                        </div>
                                    </fieldset>
                                </asp:Panel>
                                <asp:Panel ID="pnlAirlineTaxes" runat="server">
                                    <fieldset class="the-fieldset">
                                        <%--<legend class="the-legend text-black">Airline Taxes</legend>--%>
                                        <div class="form-group row m-b-15">
                                            <div class="col-md-2 col-sm-3">
                                                <label class="col-form-label" for="email">Report For :</label>
                                                <asp:DropDownList ID="ddlTaxReportFor" runat="server" CssClass="form-control js-example-placeholder-single" AutoPostBack="true" OnSelectedIndexChanged="ddlTaxReportFor_SelectedIndexChanged">
                                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="ALL AIRLINE" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="AIRLINE WISE" Value="2"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlTaxReportFor" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="C"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="col-md-2 col-sm-3">
                                                <label class="col-form-label" for="email">Account Title (Optional)  :</label>
                                                <asp:DropDownList ID="ddlTaxesAirline" runat="server" CssClass="form-control js-example-placeholder-single">
                                                </asp:DropDownList>

                                            </div>
                                            <div class="col-md-2 col-sm-3">
                                                <label class="col-form-label" for="email">Account Type :</label>
                                                <asp:DropDownList ID="ddlTaxesAccountType" runat="server" CssClass="form-control js-example-placeholder-single" AutoPostBack="true" OnSelectedIndexChanged="ddlTaxesAccountType_SelectedIndexChanged">
                                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="SUPPLIER" Value="7"></asp:ListItem>
                                                    <asp:ListItem Text="CLIENT" Value="3"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlTaxesAccountType" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="C"></asp:RequiredFieldValidator>
                                            </div>

                                            <div class="col-md-2 col-sm-3">
                                                <label class="col-form-label" for="email">Account Title  :</label>
                                                <asp:DropDownList ID="ddlTaxesAccountTitle" runat="server" CssClass="form-control js-example-placeholder-single">
                                                </asp:DropDownList>
                                                <%--<asp:RequiredFieldValidator ID="RFV2" runat="server" ControlToValidate="ddlAccountTitle" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>--%>
                                            </div>
                                            <div class="col-md-3 col-sm-4">
                                                <label class="col-form-label" for="email">Branch  :</label>
                                                <asp:DropDownList ID="ddlTaxesBranch" runat="server" CssClass="form-control js-example-placeholder-single">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-md-2 col-sm-3">


                                                <label class="col-form-label" for="email">From Date :</label>
                                                <asp:TextBox ID="txtDtTaxesFrom" runat="server" CssClass="form-control datepicker" Width="100%" Style="z-index: 9999;" placeholder="dd/MM/yyyy" AutoComplete="off"></asp:TextBox>

                                                <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender2" runat="server"
                                                    TargetControlID="txtDtTaxesFrom" Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtDtTaxesFrom"
                                                    ValidationGroup="C" Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                                    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                                </asp:RegularExpressionValidator>
                                                <%--<AjaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy"
                                                    PopupButtonID="txtdtFrom" TargetControlID="txtdtFrom" PopupPosition="BottomRight" />--%>
                                                <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtDtSummaryFrom" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="D"></asp:RequiredFieldValidator>--%>
                                            </div>

                                            <div class="col-md-2  col-sm-2">
                                                <label class="col-form-label" for="email">To Date :</label>
                                                <asp:TextBox ID="txtDtTaxesTO" runat="server" CssClass="form-control datepicker" Width="100%" placeholder="dd/MM/yyyy" AutoComplete="off"></asp:TextBox>


                                                <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender3" runat="server"
                                                    TargetControlID="txtDtTaxesTO" Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="txtDtTaxesTO"
                                                    ValidationGroup="C" Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                                    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                                </asp:RegularExpressionValidator>
                                                <%--<AjaxToolKit:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd/MM/yyyy"
                                                    PopupButtonID="txtdtToDate" TargetControlID="txtdtToDate" PopupPosition="BottomRight" />--%>
                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtDtSummaryTO" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="D"></asp:RequiredFieldValidator>--%>
                                            </div>

                                        </div>
                                        <div class="form-group row m-b-0 text-center">
                                            <div class="col-md-12 col-sm-12">
                                                <asp:Button ID="btnSearchTaxes" runat="server" CssClass="btn btn-primary btnspl" Text="Search" ValidationGroup="C" ToolTip="Search" OnClick="btnSearchTaxes_Click" />
                                            </div>
                                        </div>
                                    </fieldset>
                                </asp:Panel>
                                
                                <asp:Panel ID="pnlAirlineSummary" runat="server">
                                    <fieldset class="the-fieldset">
                                        <%--<legend class="the-legend text-black">Airline Sales Summary</legend>--%>
                                        <div class="form-group row m-b-15">
                                            <div class="col-md-2 col-sm-3">
                                                <label class="col-form-label" for="email">Report For :</label>
                                                <asp:DropDownList ID="ddlSummaryReportFor" runat="server" CssClass="form-control js-example-placeholder-single" AutoPostBack="true" OnSelectedIndexChanged="ddlSummaryReportFor_SelectedIndexChanged">
                                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="ALL AIRLINE" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="AIRLINE WISE" Value="2"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlSummaryReportFor" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="D"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="col-md-2 col-sm-3">
                                                <label class="col-form-label" for="email">Account Title (Optional)  :</label>
                                                <asp:DropDownList ID="ddlSummaryAirline" runat="server" CssClass="form-control js-example-placeholder-single">
                                                </asp:DropDownList>

                                            </div>
                                            <div class="col-md-2 col-sm-3">
                                                <label class="col-form-label" for="email">Account Type :</label>
                                                <asp:DropDownList ID="ddlSummaryAccountType" runat="server" CssClass="form-control js-example-placeholder-single" AutoPostBack="true" OnSelectedIndexChanged="ddlSummaryAccountType_SelectedIndexChanged">
                                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="SUPPLIER" Value="7"></asp:ListItem>
                                                    <asp:ListItem Text="CLIENT" Value="3"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlSummaryAccountType" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="D"></asp:RequiredFieldValidator>
                                            </div>

                                            <div class="col-md-2 col-sm-3">
                                                <label class="col-form-label" for="email">Account Title  :</label>
                                                <asp:DropDownList ID="ddlSummaryAcountTitle" runat="server" CssClass="form-control js-example-placeholder-single">
                                                </asp:DropDownList>
                                                <%--<asp:RequiredFieldValidator ID="RFV2" runat="server" ControlToValidate="ddlAccountTitle" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>--%>
                                            </div>
                                            <div class="col-md-3 col-sm-4">
                                                <label class="col-form-label" for="email">Branch  :</label>
                                                <asp:DropDownList ID="ddlSummaryBranch" runat="server" CssClass="form-control js-example-placeholder-single">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-md-2 col-sm-3">


                                                <label class="col-form-label" for="email">From Date :</label>
                                                <asp:TextBox ID="txtDtSummaryFrom" runat="server" CssClass="form-control datepicker" Width="100%" Style="z-index: 9999;" placeholder="dd/MM/yyyy" AutoComplete="off"></asp:TextBox>

                                                <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender8" runat="server"
                                                    TargetControlID="txtDtSummaryFrom" Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator8" ControlToValidate="txtDtSummaryFrom"
                                                    ValidationGroup="D" Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                                    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                                </asp:RegularExpressionValidator>
                                                <%--<AjaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy"
                                                    PopupButtonID="txtdtFrom" TargetControlID="txtdtFrom" PopupPosition="BottomRight" />--%>
                                                <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtDtSummaryFrom" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="D"></asp:RequiredFieldValidator>--%>
                                            </div>

                                            <div class="col-md-2  col-sm-2">
                                                <label class="col-form-label" for="email">To Date :</label>
                                                <asp:TextBox ID="txtDtSummaryTO" runat="server" CssClass="form-control datepicker" Width="100%" placeholder="dd/MM/yyyy" AutoComplete="off"></asp:TextBox>


                                                <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender9" runat="server"
                                                    TargetControlID="txtDtSummaryTO" Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator9" ControlToValidate="txtDtSummaryTO"
                                                    ValidationGroup="D" Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                                    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                                </asp:RegularExpressionValidator>
                                                <%--<AjaxToolKit:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd/MM/yyyy"
                                                    PopupButtonID="txtdtToDate" TargetControlID="txtdtToDate" PopupPosition="BottomRight" />--%>
                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtDtSummaryTO" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="D"></asp:RequiredFieldValidator>--%>
                                            </div>

                                        </div>
                                        <div class="form-group row m-b-0 text-center">
                                            <div class="col-md-12 col-sm-12">
                                                <asp:Button ID="btnSummarySearch" runat="server" CssClass="btn btn-primary btnspl" Text="Search" ValidationGroup="D" ToolTip="Search" OnClick="btnSummarySearch_Click" />
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

