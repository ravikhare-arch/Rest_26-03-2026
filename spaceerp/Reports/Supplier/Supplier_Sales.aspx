<%@ Page Title="Supplier Sales Reports" Language="C#" MasterPageFile="~/pagecontent.master" AutoEventWireup="true" CodeFile="Supplier_Sales.aspx.cs" Inherits="Reports_Customers_Customer_Sales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link type="text/css" rel="stylesheet" href="../assets/css/default/mystyle.css" />
    <style>
        input[type="radio"] {
            margin-left: 10px;
            padding-left: 30px;
        }
    </style>
    <link href="../../assets/css/default/style.min.css" rel="stylesheet" />
    <link type="text/css" rel="stylesheet" href="../../assets/css/default/mystyle.css" />
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
                        <div class="panel-heading-btn pull-left">
                            <asp:RadioButtonList ID="optReport" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" >
                                            <asp:ListItem Text="Sales Reports" Value="1" Selected="True"></asp:ListItem>
                                            <%--<asp:ListItem Text="Statement" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="Outstanding Reports" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="Cash Book" Value="4"></asp:ListItem>--%>
                                        </asp:RadioButtonList>
                        </div>
                        <div class="panel-heading-btn">
                            <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                            <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                        </div>
                        <h4 class="panel-title text-center">Supplier Sales Reports</h4>
                    </div>
                    <!-- end panel-heading -->
                    <!-- begin panel-body -->
                    <div class="panel-body">
                        <asp:UpdatePanel ID="up1" runat="server">
                            <ContentTemplate>
                                <asp:Panel ID="pnlGenLedger" runat="server">
                                    <fieldset class="the-fieldset">
                                        <div class="form-group row m-b-15">
                                            <div class="col-md-3 col-sm-3">
                                                <label class="col-form-label" for="email">Report For :</label>
                                                <asp:DropDownList ID="ddlReportFor" runat="server" CssClass="form-control js-example-placeholder-single" AutoPostBack="true" OnSelectedIndexChanged="ddlReportFor_SelectedIndexChanged">
                                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="All Supplier" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="Supplier" Value="2"></asp:ListItem>
                                                  
                                                </asp:DropDownList>
                                                   <asp:RequiredFieldValidator ID="RFV2" runat="server" ControlToValidate="ddlReportFor" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="col-md-3 col-sm-3">
                                                <label class="col-form-label" for="email">Account Title  :</label>
                                                <asp:DropDownList ID="ddlAccountTitle" runat="server" CssClass="form-control js-example-placeholder-single">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RFV5" runat="server" ControlToValidate="ddlAccountTitle" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="B"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="col-md-3 col-sm-3">
                                                <label class="col-form-label" for="email">Type  :</label>
                                                <asp:DropDownList ID="ddlAccType" runat="server" CssClass="form-control js-example-placeholder-single">
                                                     <asp:ListItem Text="Select Type" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="Visa Sales" Value="Visa"></asp:ListItem>
                                                     <asp:ListItem Text="Air Ticket Sales" Value="AirTicket"></asp:ListItem>
                                                    <asp:ListItem Text="Group Air Ticket Sales" Value="GroupAirTicket"></asp:ListItem>
                                                     <asp:ListItem Text="Hotel Sales" Value="Hotel"></asp:ListItem>
                                                     <asp:ListItem Text="Excursion Sales" Value="Excursion"></asp:ListItem>
                                                     <asp:ListItem Text="Mofa Sales" Value="Visa"></asp:ListItem>
                                                     <asp:ListItem Text="Group Mofa Sales" Value="GroupMofa"></asp:ListItem>
                                                     <asp:ListItem Text="Insurance Sales" Value="Insurance"></asp:ListItem>
                                                     <asp:ListItem Text="Recruitement Sales" Value="Recruitement"></asp:ListItem>
                                                     <asp:ListItem Text="Train Ticket Sales" Value="Train"></asp:ListItem>
                                                     <asp:ListItem Text="Bus Ticket Sales" Value="Visa"></asp:ListItem>
                                                     <asp:ListItem Text="Car Sales" Value="Visa"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                             <div class="col-md-3 col-sm-3">
                                                <label class="col-form-label" for="email">Branch  :</label>
                                                <asp:DropDownList ID="ddlBranches" runat="server" CssClass="form-control js-example-placeholder-single">
                                                </asp:DropDownList>
                                               <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlAccountTitle" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>--%>
                                            </div>
                                            <div class="col-md-3 col-sm-3" style="z-index: 9999;">


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
                                            <%--    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtdtFrom" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>--%>

                                            </div>

                                            <div class="col-md-3 col-sm-3">
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

