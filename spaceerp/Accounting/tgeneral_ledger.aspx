<%@ Page Title="Reports" Language="C#" MasterPageFile="~/Pagecontent.master" AutoEventWireup="true" CodeFile="tgeneral_ledger.aspx.cs" Inherits="Accounting_tgeneralledger" %>

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
                                <div class="form-group row m-b-15">
                                    <div>&nbsp;</div>
                                    <div class="col-md-12 col-sm-12">
                                        <asp:RadioButtonList ID="optReport" cssstyle="color:#fff" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="text-center form-control" AutoPostBack="true" OnSelectedIndexChanged="optReport_SelectedIndexChanged">
                                            <asp:ListItem Text="General Ledger" Value="1" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="Statement" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="Outstanding Reports" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="Cash Book" Value="4"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                </div>
                                <asp:Panel ID="pnlGenLedger" runat="server">
                                    <fieldset class="the-fieldset">
                                        <div class="form-group row m-b-15">
                                            <div class="col-md-2 col-sm-4">
                                                <label class="col-form-label" for="email">Report For :</label>
                                                <asp:DropDownList ID="ddlReportFor" runat="server" CssClass="form-control js-example-placeholder-single" AutoPostBack="true" OnSelectedIndexChanged="ddlReportFor_SelectedIndexChanged">
                                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="SUPPLIER" Value="7"></asp:ListItem>
                                                    <asp:ListItem Text="CLIENT" Value="3"></asp:ListItem>
                                                    <asp:ListItem Text="AIRLINE" Value="12"></asp:ListItem>

                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-md-3 col-sm-4">
                                                <label class="col-form-label" for="email">Account Title  :</label>
                                                <asp:DropDownList ID="ddlAccountTitle" runat="server" CssClass="form-control js-example-placeholder-single">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RFV2" runat="server" ControlToValidate="ddlAccountTitle" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="col-md-3 col-sm-4">
                                                <label class="col-form-label" for="email">Account Type  :</label>
                                                <asp:DropDownList ID="ddlAccType" runat="server" CssClass="form-control js-example-placeholder-single">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-md-2 col-sm-2" style="z-index: 9999;">


                                                <label class="col-form-label" for="email">From Date :</label>
                                                <asp:TextBox ID="txtdtFrom" runat="server" CssClass="form-control datepicker" Width="100%" placeholder="dd/MM/yyyy" AutoComplete="off"></asp:TextBox>

                                                <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender1" runat="server"
                                                    TargetControlID="txtdtFrom" Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtdtFrom"
                                                    ValidationGroup="A" Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                                    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                                </asp:RegularExpressionValidator>
                                                <%--<AjaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy"
                                                    PopupButtonID="txtdtFrom" TargetControlID="txtdtFrom" PopupPosition="BottomRight" />--%>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtdtFrom" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>

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
                                                <asp:RequiredFieldValidator ID="RFV3" runat="server" ControlToValidate="txtdtToDate" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                                            </div>

                                        </div>
                                        <div class="form-group row m-b-0 text-center">
                                            <div class="col-md-12 col-sm-12">
                                                <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-primary btnspl" Text="Search" ValidationGroup="A" ToolTip="Search" OnClick="btnSearch_Click" />
                                            </div>
                                        </div>
                                    </fieldset>
                                </asp:Panel>
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
                                            </div>
                                            <div class="col-md-2 col-sm-4">
                                                <label class="col-form-label" for="email">Account Title  :</label>
                                                <asp:DropDownList ID="ddlStAccountTitle" runat="server" CssClass="form-control js-example-placeholder-single">
                                                </asp:DropDownList>
                                                <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlStAccountTitle" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>--%>
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
                                                <asp:TextBox ID="txtStdtFrom" runat="server" CssClass="datepicker" Width="100%" placeholder="dd/MM/yyyy" AutoComplete="off"></asp:TextBox>

                                                <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender2" runat="server"
                                                    TargetControlID="txtStdtFrom" Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtStdtFrom"
                                                    ValidationGroup="A" Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                                    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                                </asp:RegularExpressionValidator>
                                                <%-- <AjaxToolKit:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy"
                                                    PopupButtonID="txtStdtFrom" TargetControlID="txtStdtFrom" PopupPosition="BottomRight" />--%>
                                            </div>

                                            <div class="col-md-2  col-sm-2">
                                                <label class="col-form-label" for="email">To Date :</label>
                                                <asp:TextBox ID="txtStdtToDate" runat="server" CssClass="datepicker" Width="100%" placeholder="dd/MM/yyyy" AutoComplete="off"></asp:TextBox>


                                                <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender3" runat="server"
                                                    TargetControlID="txtStdtToDate" Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="txtStdtToDate"
                                                    ValidationGroup="A" Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                                    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                                </asp:RegularExpressionValidator>
                                                <%-- <AjaxToolKit:CalendarExtender ID="CalendarExtender4" runat="server" Format="dd/MM/yyyy"
                                                    PopupButtonID="txtStdtToDate" TargetControlID="txtStdtToDate" PopupPosition="BottomRight" />--%>
                                            </div>

                                        </div>
                                        <div class="form-group row m-b-0 text-center">
                                            <div class="col-md-12 col-sm-12">
                                                <asp:Button ID="btnSearchSt" runat="server" CssClass="btn btn-primary" Text="Search" ValidationGroup="B" ToolTip="Search" OnClick="btnSearchSt_Click" />
                                            </div>
                                        </div>
                                    </fieldset>
                                </asp:Panel>
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
                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlOSAccountType" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="C"></asp:RequiredFieldValidator>--%>
                                            </div>
                                            <div class="col-md-2 col-sm-4">
                                                <label class="col-form-label" for="email">Location  :</label>
                                                <asp:DropDownList ID="ddlOSLocation" runat="server" CssClass="form-control js-example-placeholder-single">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-md-2 col-sm-2" style="z-index: 9999;">


                                                <label class="col-form-label" for="email">From Date :</label>
                                                <asp:TextBox ID="txtdtOsFrom" runat="server" CssClass="form-control datepicker" Width="100%" placeholder="dd/MM/yyyy" AutoComplete="off"></asp:TextBox>

                                                <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender4" runat="server"
                                                    TargetControlID="txtdtOsFrom" Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ControlToValidate="txtdtOsFrom"
                                                    ValidationGroup="C" Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                                    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                                </asp:RegularExpressionValidator>
                                                <%-- <AjaxToolKit:CalendarExtender ID="CalendarExtender5" runat="server" Format="dd/MM/yyyy"
                                                    PopupButtonID="txtdtOsFrom" TargetControlID="txtdtOsFrom" PopupPosition="BottomRight" />--%>
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
                                                <%--<AjaxToolKit:CalendarExtender ID="CalendarExtender6" runat="server" Format="dd/MM/yyyy"
                                                    PopupButtonID="txtdtOsTo" TargetControlID="txtdtOsTo" PopupPosition="BottomRight" />--%>
                                            </div>

                                        </div>
                                        <div class="form-group row m-b-0 text-center">
                                            <div class="col-md-12 col-sm-12">
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


                                            <div class="col-md-3 col-sm-2" style="z-index: 9999;">


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
                                            <div class="col-md-2 col-sm-12 p-30">
                                                <asp:Button ID="btnOSSearchAll" runat="server" CssClass="btn btn-primary" Text="Search" ValidationGroup="D" ToolTip="Search" OnClick="btnOSSearchAll_Click" />
                                            </div>

                                        </div>
                                        <div class="form-group row m-b-0 text-center">
                                        </div>
                                    </fieldset>
                                </asp:Panel>
                                <asp:Panel ID="pnlCashBook" runat="server">
                                    <fieldset class="the-fieldset">
                                        <legend class="the-legend text-black">Cash Book</legend>
                                        <div class="form-group row m-b-15">

                                            <div class="col-md-6 col-sm-4">
                                                <label class="col-form-label" for="email">Account Title  :</label>
                                                <asp:DropDownList ID="ddlAccountCashBook" runat="server" CssClass="form-control js-example-placeholder-single">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlAccountCashBook" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="F"></asp:RequiredFieldValidator>
                                            </div>

                                            <div class="col-md-3 col-sm-2" style="z-index: 9999;">


                                                <label class="col-form-label" for="email">From Date :</label>
                                                <asp:TextBox ID="txtdtCashBFrom" runat="server" CssClass="datepicker" Width="100%" placeholder="dd/MM/yyyy" AutoComplete="off"></asp:TextBox>

                                                <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender8" runat="server"
                                                    TargetControlID="txtdtCashBFrom" Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator8" ControlToValidate="txtdtCashBFrom"
                                                    ValidationGroup="A" Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                                    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                                </asp:RegularExpressionValidator>
                                                <%--<AjaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy"
                                                    PopupButtonID="txtdtFrom" TargetControlID="txtdtFrom" PopupPosition="BottomRight" />--%>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtdtCashBFrom" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="F"></asp:RequiredFieldValidator>

                                            </div>

                                            <div class="col-md-3  col-sm-2">
                                                <label class="col-form-label" for="email">To Date :</label>
                                                <asp:TextBox ID="txtdtCashBTo" runat="server" CssClass="datepicker" Width="100%" placeholder="dd/MM/yyyy" AutoComplete="off"></asp:TextBox>


                                                <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender9" runat="server"
                                                    TargetControlID="txtdtCashBTo" Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator9" ControlToValidate="txtdtCashBTo"
                                                    ValidationGroup="A" Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                                    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                                </asp:RegularExpressionValidator>
                                                <%--<AjaxToolKit:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd/MM/yyyy"
                                                    PopupButtonID="txtdtToDate" TargetControlID="txtdtToDate" PopupPosition="BottomRight" />--%>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtdtCashBTo" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="F"></asp:RequiredFieldValidator>
                                            </div>

                                        </div>
                                        <div class="form-group row m-b-0 text-center">
                                            <div class="col-md-12 col-sm-12">
                                                <asp:Button ID="btnSearchCashBook" runat="server" CssClass="btn btn-primary" Text="Search" ValidationGroup="F" ToolTip="Search" OnClick="btnSearchCashBook_Click" />
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

