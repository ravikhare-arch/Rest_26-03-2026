<%@ Page Title="Hotel Booking" Language="C#" MasterPageFile="~/Pagecontent.master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" Culture="en-GB"
    CodeFile="thotel.aspx.cs" Inherits="Transcation_hotel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link type="text/css" rel="stylesheet" href="../assets/css/default/mystyle.css" />
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
    <link type="text/css" rel="stylesheet" href="../assets/css/default/mystyle.css" />
    <link href="../assets/css/default/style.min.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.3/umd/popper.min.js" integrity="sha384-vFJXuSJphROIrBnz7yo7oB41mKfc8JzQZiCq4NCceLEaO4IHwicKwpJf9c9IpFgh" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta.2/js/bootstrap.min.js" integrity="sha384-alpBpkh1PFOepccYVYDB4do5UnbKysX5WZXm3XxPqe5iKTfUKjNkCk9SaVuEZflJ" crossorigin="anonymous"></script>
    <%--<style>
        .content-page .content {
            margin-left: auto;
            margin-right: auto;
            display: block;
            margin-top: 0px;
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
        .row{
            margin:0px 0px;
        }
    </style>--%>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<asp:UpdatePanel ID="up2" runat="server">
        <ContentTemplate>
            <asp:Label ID="lblmsg" runat="server"></asp:Label>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <!-- begin row -->
            <div class="row">
                <!-- begin col-6 -->
                <div class="col-lg-12">
                    <!-- begin panel -->
                    <div class="panel panel-inverse">
                        <!-- begin panel-heading -->
                        <div class="panel-heading">
                            <div class="panel-heading-btn pull-left">
                                <asp:LinkButton ID="lnkAdd" runat="server" OnClick="lnkAdd_Click" CssClass="btn btn-info btn-xs">ADD</asp:LinkButton>
                                <asp:LinkButton ID="lnkList" runat="server" OnClick="lnkList_Click" CssClass="btn btn-info btn-xs">LIST</asp:LinkButton>
                                <a href="../Accounting/tgeneral_ledger.aspx" target="_blank" class="btn btn-info btn-xs">Statements</a>
                            </div>
                            <div class="panel-heading-btn">
                                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                            </div>

                            <h4 class="panel-title text-center">Hotel Booking </h4>




                        </div>
                        <!-- end panel-heading -->
                        <!-- begin panel-body -->
                        <div class="panel-body">
                            <asp:Panel class="tbl" ID="tblmain" runat="server">
                                <div style=" padding: 10px;">

                                    <div class="form-group row">

                                        <div class="col-md-2 col-sm-3">
                                            <label class="col-form-label" for="fullname">
                                                Invoice No. :</label>

                                            <asp:TextBox ID="txtHotelBookingNo" CssClass="form-control" runat="server" Enabled="true" AutoPostBack="True" OnTextChanged="txtHotelBookingNo_TextChanged"></asp:TextBox>

                                        </div>
                                        <div class="col-md-2 col-sm-2">
                                            <label class="col-form-label" for="fullname">
                                                Invoice Date :</label>
                                            <asp:TextBox ID="txtdtBooking" runat="server" CssClass="form-control datepicker" Width="100%" AutoPostBack="true" OnTextChanged="txtdtBooking_TextChanged"></asp:TextBox>
                                           <%-- <AjaxToolKit:CalendarExtender ID="CalendarExtender4" runat="server" Format="dd/MM/yyyy"
                                                PopupButtonID="txtdtBooking" TargetControlID="txtdtBooking" PopupPosition="TopLeft" />--%>

                                            <AjaxToolKit:MaskedEditExtender ID="MEE4" runat="server" TargetControlID="txtdtBooking"
                                                Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                            <asp:RegularExpressionValidator ID="REV4" ControlToValidate="txtdtBooking" ValidationGroup="A"
                                                Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                                ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                            </asp:RegularExpressionValidator>
                                        </div>
                                        <div class="col-md-3 col-sm-3">
                                            <label class="col-form-label" for="fullname">
                                                Supplier Name :</label>
                                            <asp:DropDownList CssClass="form-control js-example-placeholder-single" ID="ddlSupplier" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSupplier_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlSupplier" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-md-3 col-sm-3">
                                            <label class="col-form-label" for="fullname">
                                                Client Name :</label>
                                            <asp:DropDownList CssClass="form-control js-example-placeholder-single" ID="ddlAgentID" runat="server">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RFV3" runat="server" ControlToValidate="ddlAgentID" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                                        </div>

                                        <div class="col-md-2 col-sm-2">
                                            <label class="col-form-label" for="fullname">
                                                Location  :</label>
                                            <asp:DropDownList ID="ddlLocationID" runat="server" CssClass="form-control js-example-placeholder-single form-control">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RFV4" runat="server" ControlToValidate="ddlLocationID" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                                        </div>



                                    </div>

                                    <asp:Panel class="tbl" ID="tblDet" runat="server">

                                        <div class="row">
                                            <div class="col-md-12 col-sm-12">

                                                <div style=" padding: 0px; margin:0px;">
                                                    <div class="form-group row m-b-0">
                                                        <div class="col-md-6 col-sm-12">
                                                            <div class="form-group row m-b-0">
                                                                <div class="col-md-3 col-sm-3">
                                                                    <label class="col-form-label" for="fullname">
                                                                        Type :</label>
                                                                    <asp:DropDownList Width="100%" ID="ddlbookType" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlbookType_SelectedIndexChanged">
                                                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                        <asp:ListItem Text="Booking" Value="1"></asp:ListItem>
                                                                        <asp:ListItem Text="Refund" Value="2"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlbookType" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                                </div>
                                                                <div class="col-md-3  col-sm-3">
                                                                    <label class="col-form-label" for="fullname">
                                                                     No. of Pax</label>
                                                                    <asp:TextBox ID="txtPaxNos" CssClass="form-control" Width="100%" runat="server" AutoPostBack="true" OnTextChanged="txtPaxNos_TextChanged"></asp:TextBox>
                                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtPaxNos" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator18" runat="server" ControlToValidate="txtPaxNos"
                                                                        SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                                        ValidationGroup="A"></asp:RegularExpressionValidator>
                                                                    <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender13" runat="server"
                                                                        Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtPaxNos"
                                                                        ValidChars=".-">
                                                                    </AjaxToolKit:FilteredTextBoxExtender>
                                                                </div>
                                                                <div class="col-md-3 col-sm-3">
                                                                    <label class="col-form-label" for="fullname">
                                                                        Ref No :</label>
                                                                    <asp:TextBox ID="txtReferenceNo" CssClass="form-control" Width="100%" runat="server" ValidationGroup="A">
                                                                    </asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="form-control" runat="server" ControlToValidate="txtReferenceNo" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                                </div>
                                                                <div class="col-md-3 col-sm-3">
                                                                    <label class="col-form-label" for="fullname">
                                                                        Hotel Name :</label>
                                                                    <asp:DropDownList Width="100%" CssClass="form-control" ID="ddlHotelName" runat="server">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlHotelName" InitialValue="0" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                                </div>
                                                               
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6 col-sm-12">
                                                            <div class="form-group row m-b-0">
                                                                 <div class="col-md-3 col-sm-3">
                                                                    <label class="col-form-label" for="fullname">
                                                                        Nationality :</label>
                                                                    <asp:TextBox ID="txtNationality" CssClass="form-control" runat="server" ValidationGroup="A" Width="100%"></asp:TextBox>
                                                                </div>
                                                                <div class="col-md-3 col-sm-3">
                                                                    <label class="col-form-label" for="fullname">
                                                                        City :</label>
                                                                    <asp:DropDownList ID="ddlCity" CssClass="form-control" runat="server" Width="100%">
                                                                    </asp:DropDownList>
                                                                </div>
                                                                <div class="col-md-3 col-sm-3">
                                                                    <label class="col-form-label" for="fullname">
                                                                        Room Type :</label>
                                                                    <asp:DropDownList ID="ddlRoomType" CssClass="form-control" runat="server" Width="100%">
                                                                    </asp:DropDownList>
                                                                </div>
                                                                <div class="col-md-3 col-sm-3">
                                                                    <label class="col-form-label" for="fullname">
                                                                        Status :</label>
                                                                    <asp:DropDownList ID="ddlStatus" CssClass="form-control" runat="server" Width="100%">
                                                                        <asp:ListItem Value="0" Text="Select Status"></asp:ListItem>
                                                                        <asp:ListItem Value="1" Text="Booked"></asp:ListItem>
                                                                        <asp:ListItem Value="2" Text="Check In"></asp:ListItem>
                                                                        <asp:ListItem Value="3" Text="Check Out"></asp:ListItem>
                                                                        <asp:ListItem Value="4" Text="Cancelled"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </div>
                                                                
                                                            </div>
                                                        </div>
                                                        </div>
                                                        <div class="form-group row m-b-0">
                                                            <div class="col-md-2  col-sm-3">
                                                                <label class="col-form-label" for="fullname">
                                                                    Food Chrg :</label>
                                                                <asp:TextBox ID="txtMeal" CssClass="form-control" Width="100%" runat="server" AutoPostBack="true" OnTextChanged="txtMeal_TextChanged"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server" ControlToValidate="txtMeal"
                                                                    SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                                    ValidationGroup="A"></asp:RegularExpressionValidator>
                                                                <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" runat="server"
                                                                    Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtMeal"
                                                                    ValidChars=".-">
                                                                </AjaxToolKit:FilteredTextBoxExtender>
                                                            </div>

                                                            <div class="col-md-2 col-sm-3">
                                                                <label class="col-form-label" for="fullname">
                                                                    Check in :</label>
                                                                <asp:TextBox ID="txtdtCheckIn" runat="server" CssClass="form-control datepicker" Width="100%" AutoPostBack="true" placeholder="DD/MM/YYYY" ValidationGroup="A" OnTextChanged="txtdtCheckIn_TextChanged">
                                                                </asp:TextBox>
                                                               <%-- <AjaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy"
                                                                    PopupButtonID="txtdtCheckIn" TargetControlID="txtdtCheckIn" PopupPosition="TopLeft" />--%>

                                                                <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtdtCheckIn"
                                                                    Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtdtCheckIn"
                                                                    ValidationGroup="A" Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                                                    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                                                </asp:RegularExpressionValidator>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtdtCheckIn" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                            </div>
                                                            <div class="col-md-2 col-sm-3">
                                                                <label class="col-form-label" for="fullname">
                                                                    Check Out :</label>
                                                                <asp:TextBox ID="txtdtCheckOut" runat="server" AutoPostBack="true" CssClass="form-control datepicker" Width="100%" placeholder="DD/MM/YYYY" ValidationGroup="A" OnTextChanged="txtdtCheckOut_TextChanged">
                                                                </asp:TextBox>
                                                                <asp:CompareValidator ID="cmpVal1" ControlToCompare="txtdtCheckIn"
                                                                    ControlToValidate="txtdtCheckOut" Type="Date" Operator="GreaterThanEqual"
                                                                    ErrorMessage="Invalid Date" Display="Dynamic" runat="server"></asp:CompareValidator>

                                                                <%--<AjaxToolKit:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy"
                                                                    PopupButtonID="txtdtCheckOut" TargetControlID="txtdtCheckOut" PopupPosition="TopLeft" />--%>

                                                                <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtdtCheckOut"
                                                                    Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtdtCheckOut"
                                                                    ValidationGroup="A" Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                                                    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                                                </asp:RegularExpressionValidator>

                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtdtCheckOut" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>

                                                            </div>
                                                            <div class="col-md-6 col-sm-12">
                                                                <div class="row">

                                                                    <div class="col-md-3 col-sm-3">
                                                                        <label class="col-form-label" for="fullname">
                                                                            No of Nights
                                                                        </label>

                                                                        <asp:TextBox ID="txtTotNight" CssClass="form-control" runat="server" ValidationGroup="A" Width="100%" AutoPostBack="true" OnTextChanged="txtTotNight_TextChanged"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtTotNight"
                                                                            SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                                            ValidationGroup="A"></asp:RegularExpressionValidator>
                                                                        <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                                                            Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtTotNight"
                                                                            ValidChars=".-">
                                                                        </AjaxToolKit:FilteredTextBoxExtender>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtTotNight" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                    
                                                                    <div class="col-md-3 col-sm-3">
                                                                        <label class="col-form-label" for="fullname">
                                                                            No. of Rooms :</label>
                                                                        <asp:TextBox ID="txtNoRoom" CssClass="form-control" runat="server" Width="100%" ValidationGroup="A" AutoPostBack="true" OnTextChanged="txtNoRoom_TextChanged">
                                                                        </asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="REV34" runat="server" ControlToValidate="txtNoRoom"
                                                                            SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                                            ValidationGroup="A"></asp:RegularExpressionValidator>
                                                                        <AjaxToolKit:FilteredTextBoxExtender ID="FTBE34" runat="server"
                                                                            Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtNoRoom"
                                                                            ValidChars=".-">
                                                                        </AjaxToolKit:FilteredTextBoxExtender>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtNoRoom" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                    <div class="col-md-3 col-sm-3">
                                                                        <label class="col-form-label" for="fullname">
                                                                            Per(night)</label>
                                                                        <asp:TextBox ID="txtRate" CssClass="form-control" runat="server" ValidationGroup="A" Width="100%" AutoPostBack="true" OnTextChanged="txtRate_TextChanged"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtRate"
                                                                            SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                                            ValidationGroup="A"></asp:RegularExpressionValidator>
                                                                        <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                                                            Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtRate"
                                                                            ValidChars=".-">
                                                                        </AjaxToolKit:FilteredTextBoxExtender>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtRate" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                    <div class="col-md-3 col-sm-3">
                                                                        <label class="col-form-label" for="fullname">
                                                                            Extra Bed :</label>
                                                                        <asp:TextBox ID="txtExtrabed" CssClass="form-control" runat="server" Width="100%" ValidationGroup="A" AutoPostBack="True" OnTextChanged="txtExtrabed_TextChanged"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtExtrabed"
                                                                            SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                                            ValidationGroup="A"></asp:RegularExpressionValidator>
                                                                        <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                                                            Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtExtrabed"
                                                                            ValidChars=".-">
                                                                        </AjaxToolKit:FilteredTextBoxExtender>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        
                                                    <div class="form-group row m-b-0">
                                            <asp:Repeater ID="rptPaxList" runat="server">
                                                <ItemTemplate>
                                                    <div class="col-md-4 col-sm-4">
                                                        <div style=" padding: 5px; margin-top: 3px;">
                                                            <div class="row m-b-5">

                                                                <div class="col-md-6 col-sm-4">
                                                                    <label class="col-form-label" for="fullname">
                                                                        Pax Name 
                                                                    </label>
                                                                    <asp:HiddenField ID="hdnGuestID" runat="server" Value='<%# Eval("nHotelGustID") %>' />
                                                                    <asp:HiddenField ID="hdnHotelBookingDet" runat="server" Value='<%# Eval("nHotelBookingDetID") %>' />
                                                                    <asp:HiddenField ID="hdnLead" runat="server" Value='<%# Eval("bLead") %>' />
                                                                    <asp:TextBox ID="txtPaxtName1" runat="server" CssClass="form-control" Width="100%" Text='<%# Eval("sPaxName") %>'></asp:TextBox>
                                                                </div>
                                                                <div class="col-md-3 col-sm-4">
                                                                    <label class="col-form-label" for="fullname">
                                                                        Gender
                                                                    </label>
                                                                    <asp:DropDownList ID="ddlGender1" CssClass="form-control" runat="server" Width="100%">
                                                                        <asp:ListItem Value="Male" Text="Male"></asp:ListItem>
                                                                        <asp:ListItem Value="Female" Text="Female"></asp:ListItem>
                                                                        <asp:ListItem Value="Other" Text="Other "></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </div>
                                                                <div class="col-md-3 col-sm-4">
                                                                    <label class="col-form-label" for="fullname">
                                                                        Age 
                                                                    </label>
                                                                    <asp:TextBox ID="txtAge1" CssClass="form-control" runat="server" Width="100%" Text='<%# Eval("sAge") %>'></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <%--  <div class="row m-b-5">

                                                                <div class="col-md-6 col-sm-4">

                                                                    <asp:TextBox ID="txtPaxtName2" runat="server" Width="100%"></asp:TextBox>
                                                                </div>
                                                                <div class="col-md-3 col-sm-4">

                                                                    <asp:DropDownList ID="ddlGender2" runat="server" Width="100%">
                                                                        <asp:ListItem Value="Male" Text="Male"></asp:ListItem>
                                                                        <asp:ListItem Value="Female" Text="Female"></asp:ListItem>
                                                                        <asp:ListItem Value="Other" Text="Other "></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </div>
                                                                <div class="col-md-3 col-sm-4">

                                                                    <asp:TextBox ID="txtAge2" runat="server" Width="100%"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="row m-b-5">

                                                                <div class="col-md-6 col-sm-4">

                                                                    <asp:TextBox ID="txtPaxtName3" runat="server" Width="100%"></asp:TextBox>
                                                                </div>
                                                                <div class="col-md-3 col-sm-4">

                                                                    <asp:DropDownList ID="ddlGender3" runat="server" Width="100%">
                                                                        <asp:ListItem Value="Male" Text="Male"></asp:ListItem>
                                                                        <asp:ListItem Value="Female" Text="Female"></asp:ListItem>
                                                                        <asp:ListItem Value="Other" Text="Other "></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </div>
                                                                <div class="col-md-3 col-sm-4">

                                                                    <asp:TextBox ID="txtAge3" runat="server" Width="100%"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="row m-b-5">

                                                                <div class="col-md-6 col-sm-4">

                                                                    <asp:TextBox ID="txtPaxtName4" runat="server" Width="100%"></asp:TextBox>
                                                                </div>
                                                                <div class="col-md-3 col-sm-4">

                                                                    <asp:DropDownList ID="ddlGender4" runat="server" Width="100%">
                                                                        <asp:ListItem Value="Male" Text="Male"></asp:ListItem>
                                                                        <asp:ListItem Value="Female" Text="Female"></asp:ListItem>
                                                                        <asp:ListItem Value="Other" Text="Other "></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </div>
                                                                <div class="col-md-3 col-sm-4">

                                                                    <asp:TextBox ID="txtAge4" runat="server" Width="100%"></asp:TextBox>
                                                                </div>
                                                            </div>--%>
                                                        </div>
                                                    </div>
                                                   </ItemTemplate>
                                            </asp:Repeater>
                                        </div>
                                        </div>
                                        <div class="row">

                                            <div class="col-md-6 col-sm-12">
                                                <div style=" padding: 5px; margin-top: 0px;">
                                                    <div class="form-group row m-b-5">
                                                        <div class="col-md-2 col-sm-2">
                                                            <label class="col-form-label" for="fullname">
                                                                Cost
                                                            </label>
                                                            <asp:TextBox ID="txtclntCost" CssClass="form-control" runat="server" placeholder="Cost" Width="100%" AutoPostBack="True" Enabled="false"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator15" runat="server" ControlToValidate="txtclntCost"
                                                                SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                                ValidationGroup="A"></asp:RegularExpressionValidator>
                                                            <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender12" runat="server"
                                                                Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtclntCost"
                                                                ValidChars=".-">
                                                            </AjaxToolKit:FilteredTextBoxExtender>
                                                        </div>
                                                        <div class="col-md-2 col-sm-2">
                                                            <label class="col-form-label" for="fullname">
                                                                Clnt SC 
                                                            </label>
                                                            <asp:DropDownList ID="ddlProfitType" CssClass="form-control" runat="server" Width="100%">
                                                                <asp:ListItem Value="0" Text="Value"></asp:ListItem>
                                                                <asp:ListItem Value="1" Text="%"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="col-md-2 col-sm-2">
                                                            <label class="col-form-label" for="fullname">
                                                                Client SC
                                                            </label>
                                                            <asp:TextBox ID="txtProfitAmt" CssClass="form-control" runat="server" placeholder="Clnt SC" Width="100%" AutoPostBack="True" OnTextChanged="txtProfitAmt_TextChanged"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtProfitAmt"
                                                                SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                                ValidationGroup="A"></asp:RegularExpressionValidator>
                                                            <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server"
                                                                Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtProfitAmt"
                                                                ValidChars=".-">
                                                            </AjaxToolKit:FilteredTextBoxExtender>
                                                        </div>
                                                        <div class="col-md-2 col-sm-3">
                                                            <label class="col-form-label" for="fullname">
                                                                Clnt SC2
                                                            </label>
                                                            <asp:TextBox ID="txtProfitAmt2" CssClass="form-control" runat="server" placeholder="" Width="100%" AutoPostBack="True" OnTextChanged="txtProfitAmt2_TextChanged"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator17" runat="server" ControlToValidate="txtProfitAmt2"
                                                                SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                                ValidationGroup="A"></asp:RegularExpressionValidator>
                                                            <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender14" runat="server"
                                                                Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtProfitAmt2"
                                                                ValidChars=".-">
                                                            </AjaxToolKit:FilteredTextBoxExtender>
                                                        </div>
                                                        <div class="col-md-2 col-sm-2">
                                                            <label class="col-form-label" for="fullname">
                                                                Clnt TDS 
                                                            </label>
                                                            <asp:DropDownList ID="ddlClntTds" CssClass="form-control" runat="server" Width="100%">
                                                                <asp:ListItem Value="0" Text="Value"></asp:ListItem>
                                                                <asp:ListItem Value="1" Text="%"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="col-md-2 col-sm-2">
                                                            <label class="col-form-label" for="fullname">
                                                                Clnt TDS
                                                            </label>
                                                            <asp:TextBox ID="txtClntTds" CssClass="form-control" runat="server" placeholder="Clnt Tds  :" Width="100%" AutoPostBack="True" OnTextChanged="txtProfitAmt_TextChanged"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" ControlToValidate="txtProfitAmt"
                                                                SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                                ValidationGroup="A"></asp:RegularExpressionValidator>
                                                            <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server"
                                                                Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtProfitAmt"
                                                                ValidChars=".-">
                                                            </AjaxToolKit:FilteredTextBoxExtender>
                                                        </div>
                                                    
                                                        <div class="col-md-3 col-sm-3">
                                                            <label class="col-form-label" for="fullname">
                                                                Discount
                                                            </label>
                                                            <asp:TextBox ID="txtDiscount" CssClass="form-control" runat="server" Width="95%" Placeholder="Discount   :" OnTextChanged="txtDiscount_TextChanged" AutoPostBack="true" placeolder="Discount"></asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="txtDiscount"
                                                                SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                                ValidationGroup="A"></asp:RegularExpressionValidator>
                                                            <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server"
                                                                Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtDiscount"
                                                                ValidChars=".-">
                                                            </AjaxToolKit:FilteredTextBoxExtender>
                                                        </div>
                                                        <div class="col-md-3 col-sm-3">
                                                            <label class="col-form-label" for="fullname">
                                                                Other Chrgs
                                                            </label>
                                                            <asp:TextBox ID="txtOtherchrg" CssClass="form-control" runat="server" Width="100%" AutoPostBack="true" OnTextChanged="txtOtherchrg_TextChanged"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator20" runat="server" ControlToValidate="txtOtherchrg"
                                                                SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                                ValidationGroup="A"></asp:RegularExpressionValidator>
                                                            <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender17" runat="server"
                                                                Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtOtherchrg"
                                                                ValidChars=".-">
                                                            </AjaxToolKit:FilteredTextBoxExtender>
                                                        </div>

                                                        <div class="col-md-3 col-sm-3">
                                                            <label class="col-form-label" for="fullname">
                                                                Remarks :</label>
                                                            <asp:TextBox ID="txtRemarks" CssClass="form-control" runat="server" Width="100%"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                    <fieldset class="the-fieldset">
                                                        <div class="form-group row">

                                                            <div class="col-md-1 col-sm-1">
                                                                <label class="col-form-label" for="fullname">
                                                                    Tax
                                                                </label>
                                                                <asp:CheckBox ID="chkClntTax" runat="server" Width="100%" Checked="true" AutoPostBack="True" OnCheckedChanged="chkClntTax_CheckedChanged"></asp:CheckBox>

                                                            </div>

                                                            <div class="col-md-4 col-sm-4">
                                                                <label class="col-form-label" for="fullname">
                                                                    CGST
                                                                </label>
                                                                <asp:TextBox ID="txtClntCgst" CssClass="form-control" runat="server" Width="95%" Enabled="false"></asp:TextBox>

                                                            </div>

                                                            <div class="col-md-4 col-sm-4">
                                                                <label class="col-form-label" for="fullname">
                                                                    SGST
                                                                </label>
                                                                <asp:TextBox ID="txtClntSgst" CssClass="form-control" runat="server" Width="95%" Enabled="false"></asp:TextBox>

                                                            </div>
                                                            <div class="col-md-3 col-sm-3">
                                                                <label class="col-form-label" for="fullname">
                                                                    IGST
                                                                </label>
                                                                <asp:TextBox ID="txtClntIgst" CssClass="form-control" runat="server" Width="100%" Enabled="false"></asp:TextBox>

                                                            </div>
                                                        </div>
                                                    </fieldset>

                                                </div>

                                            </div>
                                            <div class="col-md-6 col-sm-12">
                                                <div style=" padding: 5px; margin-top: 0px;">
                                                    <div class="form-group row m-b-10">
                                                        <div class="col-md-3 col-sm-3">
                                                            <label class="col-form-label" for="fullname">
                                                                Cost :</label>
                                                            <asp:TextBox ID="txtBasicFare" CssClass="form-control" Width="100%" runat="server" Enabled="false" ValidationGroup="B"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="REV11" runat="server" ControlToValidate="txtBasicFare"
                                                                SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                                ValidationGroup="A"></asp:RegularExpressionValidator>
                                                            <AjaxToolKit:FilteredTextBoxExtender ID="FTBE11" runat="server"
                                                                Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtBasicFare"
                                                                ValidChars=".-">
                                                            </AjaxToolKit:FilteredTextBoxExtender>
                                                            <asp:RequiredFieldValidator ID="RFV11" runat="server" ControlToValidate="txtBasicFare" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                        </div>

                                                        <div class="col-md-3 col-sm-3">
                                                            <label class="col-form-label" for="fullname">
                                                                Sup. SC Type
                                                            </label>
                                                            <asp:DropDownList ID="ddlSupScType" CssClass="form-control" runat="server" Width="100%" AutoPostBack="True">
                                                                <asp:ListItem Value="0" Text="Value"></asp:ListItem>
                                                                <asp:ListItem Value="1" Text="% "></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="col-md-3 col-sm-3">
                                                            <label class="col-form-label" for="fullname">
                                                                Sup. SC
                                                            </label>
                                                            <asp:TextBox ID="txtSupSc" CssClass="form-control" runat="server" Width="100%" Enabled="true" AutoPostBack="True" OnTextChanged="txtSupSc_TextChanged"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="txtTotal"
                                                                SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                                ValidationGroup="B"></asp:RegularExpressionValidator>
                                                            <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server"
                                                                Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtTotal"
                                                                ValidChars=".-">
                                                            </AjaxToolKit:FilteredTextBoxExtender>
                                                        </div>

                                                        <div class="col-md-3 col-sm-3">
                                                            <label class="col-form-label" for="fullname">
                                                                Otr Tax :</label>
                                                            <asp:TextBox ID="txtOtherTax" CssClass="form-control" Width="100%" runat="server" ValidationGroup="B" AutoPostBack="true" OnTextChanged="txtOtherTax_TextChanged"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server" ControlToValidate="txtOtherTax"
                                                                SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                                ValidationGroup="B"></asp:RegularExpressionValidator>
                                                            <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server"
                                                                Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtOtherTax"
                                                                ValidChars=".-">
                                                            </AjaxToolKit:FilteredTextBoxExtender>
                                                        </div>



                                                    </div>
                                                    <div class="form-group row m-b-5">


                                                        <div class="col-md-3 col-sm-2">
                                                            <label class="col-form-label" for="fullname">
                                                                Sup Tds 
                                                            </label>
                                                            <asp:DropDownList ID="ddlSupTds" CssClass="form-control" runat="server" Width="100%">
                                                                <asp:ListItem Value="0" Text="Value"></asp:ListItem>
                                                                <asp:ListItem Value="1" Text="%"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="col-md-3 col-sm-2">
                                                            <label class="col-form-label" for="fullname">
                                                                Sup Tds
                                                            </label>
                                                            <asp:TextBox ID="txtSupTds" CssClass="form-control" runat="server" placeholder="Clnt SC" Width="100%" AutoPostBack="True" OnTextChanged="txtSupTds_TextChanged"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server" ControlToValidate="txtSupTds"
                                                                SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                                ValidationGroup="A"></asp:RegularExpressionValidator>
                                                            <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server"
                                                                Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtProfitAmt"
                                                                ValidChars=".-">
                                                            </AjaxToolKit:FilteredTextBoxExtender>
                                                        </div>


                                                        <div class="col-md-3 col-sm-3">
                                                            <label class="col-form-label" for="fullname">
                                                                Comm Rcvd. :</label>
                                                            <asp:TextBox ID="txtSupComm" CssClass="form-control" runat="server" Width="100%" AutoPostBack="true" OnTextChanged="txtSupComm_TextChanged"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="REV16" runat="server" ControlToValidate="txtSupComm"
                                                                SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                                ValidationGroup="A"></asp:RegularExpressionValidator>
                                                            <AjaxToolKit:FilteredTextBoxExtender ID="FTBE16" runat="server"
                                                                Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtSupComm"
                                                                ValidChars=".-">
                                                            </AjaxToolKit:FilteredTextBoxExtender>
                                                        </div>
                                                        <div class="col-md-3 col-sm-3">
                                                            <label class="col-form-label" for="fullname">
                                                                Sup Discount :</label>
                                                            <asp:TextBox ID="txtSupDiscount" CssClass="form-control" runat="server" Width="100%" AutoPostBack="true" OnTextChanged="txtSupDiscount_TextChanged"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator22" runat="server" ControlToValidate="txtSupDiscount"
                                                                SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                                ValidationGroup="A"></asp:RegularExpressionValidator>
                                                            <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender15" runat="server"
                                                                Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtSupDiscount"
                                                                ValidChars=".-">
                                                            </AjaxToolKit:FilteredTextBoxExtender>
                                                        </div>
                                                    </div>
                                                    <fieldset class="the-fieldset">
                                                        <div class="form-group row m-b-5">

                                                            <div class="col-md-1 col-sm-1">
                                                                <label class="col-form-label" for="fullname">
                                                                    Tax
                                                                </label>
                                                                <asp:CheckBox ID="chkSupTax" runat="server" Width="100%" Checked="true" AutoPostBack="True" OnCheckedChanged="chkSupTax_CheckedChanged"></asp:CheckBox>

                                                            </div>

                                                            <div class="col-md-4 col-sm-4">
                                                                <label class="col-form-label" for="fullname">
                                                                    CGST
                                                                </label>
                                                                <asp:TextBox ID="txtsupcgst" CssClass="form-control" runat="server" Width="95%" Enabled="false"></asp:TextBox>

                                                            </div>

                                                            <div class="col-md-4 col-sm-4">
                                                                <label class="col-form-label" for="fullname">
                                                                    SGST
                                                                </label>
                                                                <asp:TextBox ID="txtsupsgst" CssClass="form-control" runat="server" Width="95%" Enabled="false"></asp:TextBox>

                                                            </div>
                                                            <div class="col-md-3 col-sm-3">
                                                                <label class="col-form-label" for="fullname">
                                                                    IGST
                                                                </label>
                                                                <asp:TextBox ID="txtsupigst" CssClass="form-control" runat="server" Width="100%" Enabled="false"></asp:TextBox>

                                                            </div>
                                                        </div>
                                                    </fieldset>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="form-group row m-b-10" style="padding: 10px;" id="tblrefund" runat="server" visible="false">
                                            <fieldset class="the-fieldset">
                                                <legend class="the-legend text-black text-center font-weight-bold">REFUND</legend>
                                                <div class="row">
                                                    <div class="col-md-6 col-sm-6">

                                                        <div class="form-group row m-b-5">
                                                            <div class="col-md-4 col-sm-4">
                                                                <label class="col-form-label" for="fullname">
                                                                    Refund Date
                                                                </label>
                                                                <asp:TextBox ID="txtdtRfnDate" runat="server" CssClass="form-control datepicker" Width="100%" Enabled="true"></asp:TextBox>
                                                                <%--<AjaxToolKit:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd/MM/yyyy"
                                                                    PopupButtonID="txtdtRfnDate" TargetControlID="txtdtRfnDate" PopupPosition="TopLeft" />--%>
                                                                <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txtdtRfnDate"
                                                                    Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator14" ControlToValidate="txtdtRfnDate" ValidationGroup="A"
                                                                    Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                                                    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                                                </asp:RegularExpressionValidator>
                                                            </div>

                                                            <div class="col-md-4 col-sm-4">
                                                                <label class="col-form-label" for="fullname">
                                                                    Rfn.Amount
                                                                </label>
                                                                <asp:TextBox ID="txtRefundAmt" CssClass="form-control" runat="server" Width="95%" Enabled="true" AutoPostBack="True" OnTextChanged="txtRefundAmt_TextChanged"></asp:TextBox>
                                                            </div>
                                                            <div class="col-md-4 col-sm-4">
                                                                <label class="col-form-label" for="fullname">
                                                                    Rfn. SC
                                                                </label>
                                                                <asp:TextBox ID="txtrfnSC" CssClass="form-control" runat="server" Width="95%" Enabled="true" AutoPostBack="True" OnTextChanged="txtrfnSC_TextChanged"></asp:TextBox>

                                                            </div>




                                                        </div>

                                                    </div>
                                                    <div class="col-md-6 col-sm-6 border-left-1">
                                                        <div class="row">
                                                            <div class="col-md-4 col-sm-6">
                                                                <div class="row">
                                                                    <div class="col-md-12 col-sm-4">
                                                                        <label class="col-form-label" for="fullname">
                                                                            Remarks
                                                                        </label>
                                                                        <asp:TextBox ID="txtRfnRemarks" CssClass="form-control" runat="server" Width="100%" Enabled="true"></asp:TextBox>

                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-8 col-sm-6">
                                                                <fieldset class="the-fieldset">
                                                                    <legend class="the-legend text-black">Refund GST</legend>
                                                                    <div class="form-group row m-b-5">

                                                                        <div class="col-md-1 col-sm-4">
                                                                            <label class="col-form-label" for="fullname">
                                                                                Tax
                                                                            </label>
                                                                            <asp:CheckBox ID="chkRfnTax" runat="server" Width="100%" Checked="true" AutoPostBack="True" OnCheckedChanged="chkRfnTax_CheckedChanged"></asp:CheckBox>

                                                                        </div>

                                                                        <div class="col-md-4 col-sm-4">
                                                                            <label class="col-form-label" for="fullname">
                                                                                CGST
                                                                            </label>
                                                                            <asp:TextBox ID="txtRfnCGst" CssClass="form-control" runat="server" Width="95%" Enabled="false"></asp:TextBox>

                                                                        </div>

                                                                        <div class="col-md-4 col-sm-4">
                                                                            <label class="col-form-label" for="fullname">
                                                                                SGST
                                                                            </label>
                                                                            <asp:TextBox ID="txtRfnSGst" CssClass="form-control" runat="server" Width="95%" Enabled="false"></asp:TextBox>

                                                                        </div>
                                                                        <div class="col-md-3 col-sm-4">
                                                                            <label class="col-form-label" for="fullname">
                                                                                IGST
                                                                            </label>
                                                                            <asp:TextBox ID="txtRfnIGst" CssClass="form-control" runat="server" Width="95%" Enabled="false"></asp:TextBox>

                                                                        </div>
                                                                    </div>
                                                                </fieldset>
                                                            </div>
                                                        </div>

                                                    </div>
                                                </div>
                                            </fieldset>
                                        </div>

                                        <div class="row">

                                            <div class="col-md-6 col-sm-6 text-center">

                                                <label class="col-form-label" for="fullname">
                                                    Client Cost
                                                </label>
                                                <asp:Label ID="lblSelleing" CssClass="form-control" runat="server" Visible="false"></asp:Label>
                                                <asp:TextBox ID="txtSelleing" runat="server" Width="40%" ForeColor="Black" CssClass="btn bg-blue-darker" Enabled="false" Placeholder="Selling Rate   :"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="REV32" runat="server" ControlToValidate="txtSelleing"
                                                    SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                    ValidationGroup="A"></asp:RegularExpressionValidator>
                                                <AjaxToolKit:FilteredTextBoxExtender ID="FTBE32" runat="server"
                                                    Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtSelleing"
                                                    ValidChars=".-">
                                                </AjaxToolKit:FilteredTextBoxExtender>

                                            </div>
                                            <div class="col-md-6 col-sm-6 text-center">

                                                <label class="col-form-label text-center" for="fullname">
                                                    Supplier Cost
                                                </label>
                                                <asp:Label ID="lblBuyCost" CssClass="form-control" runat="server" Visible="false"></asp:Label>
                                                <asp:TextBox ID="txtTotal" runat="server" Width="40%" ForeColor="Black" CssClass="btn bg-blue-darker" Enabled="false"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtTotal"
                                                    SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                    ValidationGroup="A"></asp:RegularExpressionValidator>
                                                <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                                    Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtTotal"
                                                    ValidChars=".-">
                                                </AjaxToolKit:FilteredTextBoxExtender>

                                            </div>
                                        </div>


                                        <div class="row">
                                            <div class="col-md-12 col-sm-12 text-center">
                                                <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary btnspl" Text="Add" ValidationGroup="A"
                                                    OnClick="btnAdd_Click" ToolTip="Add" />
                                                <asp:Button ID="btnAddDet" runat="server" CssClass="btn btn-primary btnspl" Text="Add" ValidationGroup="A" OnClick="btnAddDet_Click" ToolTip="Add" />
                                                <asp:Button ID="btnUpdateDet" runat="server" CssClass="btn btn-primary btnspl" Text="Update" ValidationGroup="A" OnClick="btnUpdateDet_Click" ToolTip="Update" />
                                                <asp:Button ID="btnPrint" runat="server" CssClass="btn btn-primary btnspl" Text="Print" OnClick="btnPrint_Click" ToolTip="Print" Visible="false" />
                                                <asp:Button ID="btnPaymentHistory" runat="server" CssClass="btn btn-primary btnspl" Text="Payment History" OnClick="btnPaymentHistory_Click" ToolTip="Payment History" Visible="false" />

                                            </div>
                                        </div>

                                        <%--<div class="form-group row m-b-0" style="margin-top: 20px;">
                                <label class="col-md-5 col-sm-5 col-form-label">
                                    &nbsp;</label>
                                <div class="col-md-5 col-sm-5">

                                    <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-primary" Text="Update"
                                        ValidationGroup="A" OnClick="btnUpdate_Click" ToolTip="Update" />
                                    <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-primary" Text="Delete"
                                        OnClick="btnDelete_Click" ToolTip="Delete" />
                                    <AjaxToolKit:ConfirmButtonExtender ID="btnDelete_confirmbuttonextender" runat="server"
                                        DisplayModalPopupID="btnDelete_modalpopupextender" TargetControlID="btnDelete" />
                                    <AjaxToolKit:ModalPopupExtender ID="btnDelete_modalpopupextender" runat="server"
                                        BackgroundCssClass="modalBackground" CancelControlID="ButtonCancel" OkControlID="ButtonOk"
                                        PopupControlID="PNL" TargetControlID="btnDelete" />
                                    <br />
                                    <asp:Panel ID="PNL" runat="server" Style="display: none; width: 200px; background-color: #348fe2; border-width: 1px; border-color: Black; border-style: solid; padding: 20px;">
                                        Are you sure you want to delete?
                                    <br />
                                        <br />
                                        <div style="text-align: right;">
                                            <asp:Button ID="ButtonOk" runat="server" Text="OK" />
                                            <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" />
                                        </div>
                                    </asp:Panel>
                                </div>
                            </div>--%>
                                    </asp:Panel>

                                </div>

                                <asp:Panel class="tbl table-responsive" ID="tblGridDet" runat="server" Style="margin-top: 20px;">

                                    <asp:Label ID="lblpgsDet" runat="server" Text="Page Size :"></asp:Label>
                                    <asp:DropDownList ID="ddlPageSizeDet" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPageSizeDet_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:GridView ID="GridView2" CssClass="table table-striped table-bordered" runat="server" AutoGenerateColumns="False"
                                        DataKeyNames="nHotelBookingDetID" Width="100%" AllowPaging="false" AllowSorting="True" EmptyDataText="No Records to display"
                                        OnPageIndexChanging="GridView2_PageIndexChanging">
                                        <Columns>
                                            <asp:TemplateField HeaderText="nHotelBookingDetID" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDetID" runat="server" Text='<%# Eval("nHotelBookingDetID") %>'></asp:Label>
                                                    <asp:Label ID="lblBookType" runat="server" Text='<%# Eval("sVoucherType") %>'></asp:Label>
                                                    <asp:Label ID="lblhotelbookid" runat="server" Text='<%# Eval("nHotelBookingID") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="sVoucherType" HeaderText="Book Type" />
                                            <asp:BoundField DataField="sReferenceNo" HeaderText="Ref. No." />
                                            <asp:BoundField DataField="sGuestName" HeaderText="Pax Name" />
                                            <asp:BoundField DataField="sHotelName" HeaderText="Hotel Name" />
                                            <asp:BoundField DataField="sTotDay" HeaderText="No. Of Days" />
                                            <asp:BoundField DataField="nNoOfRooms" HeaderText="No. Of Rooms" />
                                            <asp:TemplateField HeaderText="Check In">
                                                <ItemTemplate>
                                                    <%#validation.TextToDate(Eval("dtCheckIn").ToString())%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Check Out">
                                                <ItemTemplate>
                                                    <%#validation.TextToDate(Eval("dtCheckOut").ToString())%>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:BoundField DataField="nBuyCost" HeaderText="Supplier Cost" />
                                            <asp:BoundField DataField="nSellingCost" HeaderText="Cleint Cost" />
                                            <asp:TemplateField HeaderText="Edit/Delete">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btngdEditDet" runat="server" OnClick="btngdEditDet_Click" ToolTip="Edit">
                        <i class="far fa-lg fa-fw m-r-10 fa-edit fa-grid-edit"></i> <span class="text-inverse">Edit</span>
                                                    </asp:LinkButton>
                                                    <asp:LinkButton ID="btngdPrintdet" runat="server" OnClick="btngdPrintdet_Click" ToolTip="Print">
                    <i class="fas fa-lg fa-fw m-r-10 fa-print fa-grid-edit"></i> <span class="text-inverse">Print</span></asp:LinkButton>
                                                    <asp:LinkButton ID="btngdDeleteDet" runat="server" OnClick="btngdDeleteDet_Click" ToolTip="Delete">
                        <i class="far fa-lg fa-fw m-r-10 fa-trash-alt fa-grid-del"></i> <span class="text-inverse">Delete</span>
                                                    </asp:LinkButton>
                                                    <AjaxToolKit:ConfirmButtonExtender ID="btngdDeleteDet_confirmbuttonextender" runat="server"
                                                        DisplayModalPopupID="btngdDeleteDet_modalpopupextender" TargetControlID="btngdDeleteDet" />
                                                    <AjaxToolKit:ModalPopupExtender ID="btngdDeleteDet_modalpopupextender" runat="server"
                                                        BackgroundCssClass="modalBackground" CancelControlID="ButtonCancelDet" OkControlID="ButtonOkDet"
                                                        PopupControlID="PNL0" TargetControlID="btngdDeleteDet" />
                                                    <br />
                                                    <asp:Panel ID="PNL0" runat="server" Style="display: none; width: 200px; background-color: #348fe2; border-width: 1px; border-color: Black; border-style: solid; padding: 20px;">
                                                        Are you sure you want to delete?
                                                <br />
                                                        <br />
                                                        <div style="text-align: right;">
                                                            <asp:Button ID="ButtonOkDet" runat="server" Text="OK" />
                                                            <asp:Button ID="ButtonCancelDet" runat="server" Text="Cancel" />
                                                        </div>
                                                    </asp:Panel>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>

                                </asp:Panel>
                            </asp:Panel>
                            <asp:Panel class="tbl table-responsive" ID="tblGrd" runat="server">
                                <div style=" padding: 10px; margin-top: 20px;">
                                    <div class="form-group row m-b-15">
                                        <div class="col-md-2 col-sm-3">
                                            <label class="col-form-label" for="fullname">
                                                Invoice No. :</label>
                                            <asp:DropDownList CssClass="form-control js-example-placeholder-single" ID="ddlInvoiceNo" runat="server">
                                            </asp:DropDownList>

                                        </div>
                                        <div class="col-md-2 col-sm-3">
                                            <label class="col-form-label" for="fullname">
                                                Booking Type  :</label>
                                            <asp:DropDownList ID="ddlSBookType" runat="server" CssClass="js-example-placeholder-single form-control">
                                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="Booking" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Refund" Value="2"></asp:ListItem>

                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-md-2 col-sm-2" style="z-index: 99">
                                            <label class="col-form-label" for="fullname">
                                                Invoice Date :</label>
                                            <asp:TextBox ID="txtSdtBooking" runat="server" CssClass="datepicker form-control" Width="100%" placeholder="dd/MM/yyyy"></asp:TextBox>
                                            <%--<AjaxToolKit:CalendarExtender ID="CalendarExtender5" runat="server" Format="dd/MM/yyyy"
                                                PopupButtonID="txtSdtBooking" TargetControlID="txtSdtBooking" PopupPosition="BottomLeft" />--%>

                                            <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender4" runat="server" TargetControlID="txtSdtBooking"
                                                Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator16" ControlToValidate="txtSdtBooking" ValidationGroup="A"
                                                Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                                ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                            </asp:RegularExpressionValidator>
                                        </div>

                                        <div class="col-md-2 col-sm-3">
                                            <label class="col-form-label" for="fullname">
                                                Client Name :</label>
                                            <asp:DropDownList CssClass="form-control js-example-placeholder-single" ID="ddlSClient" runat="server">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-md-2 col-sm-3">
                                            <label class="col-form-label" for="fullname">
                                                Supplier Name :</label>
                                            <asp:DropDownList CssClass="form-control js-example-placeholder-single" ID="ddlSSup" runat="server">
                                            </asp:DropDownList>
                                        </div>

                                        <div class="col-md-2 col-sm-3">
                                            <label class="col-form-label" for="fullname">
                                                Location  :</label>
                                            <asp:DropDownList ID="ddlSLoc" runat="server" CssClass="form-control js-example-placeholder-single form-control">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group row m-b-15 text-center">
                                        <div class="col-md-12 col-sm-12">
                                            <asp:Button ID="btnSearch" runat="server" CssClass="btn btnspl btn-primary" Text="Search" ValidationGroup="A"
                                                ToolTip="Search" OnClick="btnSearch_Click" />
                                        </div>
                                    </div>
                                </div>

                                <asp:Label ID="lblpgs" runat="server" Text="Page Size :"></asp:Label>
                                <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:GridView ID="GridView1" CssClass="table table-striped table-bordered" runat="server"
                                    AutoGenerateColumns="False" EmptyDataText="No Records to display" DataKeyNames="nHotelBookingID "
                                    Width="100%" AllowPaging="true" AllowSorting="True" PageSize="25" OnPageIndexChanging="GridView1_PageIndexChanging">
                                    <Columns>
                                        <asp:TemplateField HeaderText="nHotelBookingID" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblID" runat="server" Text='<%# Eval("nHotelBookingID") %>'></asp:Label>
                                                <asp:Label ID="lblAgentID" runat="server" Text='<%# Eval("nAgentID") %>'></asp:Label>
                                                <asp:Label ID="lblBalance" runat="server" Text='<%# Eval("nBalance") %>'></asp:Label>
                                                <asp:Label ID="lblInvoiceNo" runat="server" Text='<%# Eval("sHotelBookingNo") %>'></asp:Label>
                                                <asp:Label ID="lblInvoiceDate" runat="server" Text='<%# Eval("dtBooking") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:BoundField DataField="sHotelBookingNo" HeaderText="Invoice No" />
                                        <asp:TemplateField HeaderText="Invoice Date">
                                            <ItemTemplate>
                                                <%#validation.TextToDate(Eval("dtBooking").ToString())%>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:BoundField DataField="sAgent" HeaderText="Agent Name" />
                                        <asp:BoundField DataField="sSupplier" HeaderText="Supplier Name" />
                                        <asp:BoundField DataField="sBranchName" HeaderText="Branch Name" />
                                        <asp:BoundField DataField="nBuyingRate" HeaderText="Buying Cost" />
                                        <asp:BoundField DataField="nSellingRate" HeaderText="Selling Cost" />
                                        <asp:BoundField DataField="nPaidAmount" HeaderText="Paid Amount" />
                                        <asp:BoundField DataField="nBalance" HeaderText="Balance" />
                                        <asp:BoundField DataField="sPaid" HeaderText="Paid Status" />
                                        <asp:TemplateField HeaderText="Edit/Delete">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btngdEdit" runat="server" OnClick="btngdEdit_Click" ToolTip="Edit">
                        <i class="far fa-lg fa-fw m-r-10 fa-edit fa-grid-edit"></i> <span class="text-inverse">Edit</span>
                                                </asp:LinkButton><br />
                                                <asp:LinkButton ID="btngdPrint" runat="server" OnClick="btngdPrint_Click" ToolTip="Print">
                                               <i class="fas fa-lg fa-fw m-r-10 fa-print fa-grid-edit"></i> <span class="text-inverse">Print</span>
                                                </asp:LinkButton><br />
                                                <asp:LinkButton ID="btngdPay" runat="server" OnClick="btngdPay_Click" ToolTip="payment">
                    <i class="far fa-lg fa-fw m-r-10 fa-money-bill-alt fa-grid-edit"></i> <span class="text-inverse">Payment</span></asp:LinkButton><br />
                                                <asp:LinkButton ID="btngdDelete" runat="server" OnClick="btngdDelete_Click" ToolTip="Delete">
                        <i class="far fa-lg fa-fw m-r-10 fa-trash-alt fa-grid-del"></i> <span class="text-inverse">Delete</span>
                                                </asp:LinkButton>
                                                <AjaxToolKit:ConfirmButtonExtender ID="btngdDelete_confirmbuttonextender" runat="server"
                                                    DisplayModalPopupID="btngdDelete_modalpopupextender" TargetControlID="btngdDelete" />
                                                <AjaxToolKit:ModalPopupExtender ID="btngdDelete_modalpopupextender" runat="server"
                                                    BackgroundCssClass="modalBackground" CancelControlID="ButtonCancel0" OkControlID="ButtonOk0"
                                                    PopupControlID="PNL0" TargetControlID="btngdDelete" />
                                                <br />
                                                <asp:Panel ID="PNL0" runat="server" Style="display: none; width: 200px; background-color: #348fe2; border-width: 1px; border-color: Black; border-style: solid; padding: 20px;">
                                                    Are you sure you want to delete?
                        <br />
                                                    <br />
                                                    <div style="text-align: right;">
                                                        <asp:Button ID="ButtonOk0" runat="server" Text="OK" />
                                                        <asp:Button ID="ButtonCancel0" runat="server" Text="Cancel" />
                                                    </div>
                                                </asp:Panel>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>

                            <asp:Panel ID="PnlPayment" runat="server">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h4 class="modal-title">Hotel Payment</h4>
                                    </div>
                                    <div class="row m-5">

                                        <div class="col-md-3 col-sm-3">
                                            <h5>Payment For</h5>
                                            <asp:TextBox ID="txtPayInv" runat="server" Enabled="false" Width="100%"></asp:TextBox>
                                            <asp:Label ID="lblInvoiceDate" runat="server" Visible="false" Width="100%"></asp:Label>
                                        </div>
                                        <div class="col-md-3 col-sm-3">
                                            <h5>Balance Amount</h5>
                                            <asp:TextBox ID="txtPayBalance" runat="server" Width="100%" Enabled="false"></asp:TextBox>
                                            <asp:Label ID="lblAgent" runat="server" Visible="false"></asp:Label>
                                        </div>
                                        <div class="col-md-3 col-sm-3">
                                            <h5>Voucher No</h5>
                                            <asp:TextBox ID="txtPayVoucherNo" runat="server" Width="100%" Enabled="false"></asp:TextBox>
                                        </div>
                                        <div class="col-md-3 col-sm-3" style="z-index: 99">
                                            <h5>Payment Date</h5>
                                            <asp:TextBox ID="txtdtpayment" runat="server" CssClass="form-control datepicker" Width="100%" placeholder="DD/MM/YYYY" OnTextChanged="txtdtpayment_TextChanged" AutoPostBack="true"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtdtpayment" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                                            <%--<AjaxToolKit:CalendarExtender ID="CalendarExtender6" runat="server" Format="dd/MM/yyyy"
                                                PopupButtonID="txtdtpayment" TargetControlID="txtdtpayment" PopupPosition="BottomLeft" />--%>
                                            <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender5" runat="server"
                                                TargetControlID="txtdtpayment" Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator19" ControlToValidate="txtdtpayment"
                                                ValidationGroup="A" Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                                ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                            </asp:RegularExpressionValidator>
                                        </div>

                                    </div>
                                    <div class="row m-15">


                                        <div class="col-md-3 col-sm-3">
                                            <h5>Payment Type</h5>
                                            <asp:DropDownList ID="ddlPayVoucherType" runat="server" Width="100%" OnSelectedIndexChanged="ddlPayVoucherType_SelectedIndexChanged" AutoPostBack="true">
                                                <asp:ListItem Value="0" Text="Select Payment Type"></asp:ListItem>
                                                <asp:ListItem Value="1" Text="Cash Payment"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="Bank Payment"></asp:ListItem>

                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="ddlPayVoucherType" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="P"></asp:RequiredFieldValidator>
                                        </div>

                                        <div class="col-md-2 col-sm-3">
                                            <h5>Payment Account</h5>
                                            <asp:DropDownList ID="ddlPaymentAccount" runat="server" Width="100%">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="ddlPaymentAccount" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="P"></asp:RequiredFieldValidator>
                                        </div>

                                        <div class="col-md-3 col-sm-3">
                                            <h5>Amount</h5>
                                            <asp:TextBox ID="txtPayAmount" runat="server" Width="100%"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator21" runat="server" ControlToValidate="txtPayAmount"
                                                SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"></asp:RegularExpressionValidator>
                                            <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender19" runat="server"
                                                Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtPayAmount"
                                                ValidChars=".-">
                                            </AjaxToolKit:FilteredTextBoxExtender>
                                            <asp:RequiredFieldValidator ID="RFV1" runat="server" ControlToValidate="txtPayAmount" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="P"></asp:RequiredFieldValidator>

                                            <asp:CompareValidator ID="CompareValidator19" runat="server" ErrorMessage="Invalid Amount" Display="Dynamic" ControlToValidate="txtPayAmount" ValidationGroup="P" ControlToCompare="txtPayBalance" Type="Double" Operator="LessThanEqual" ForeColor="Red"></asp:CompareValidator>
                                        </div>

                                        <div class="col-md-4 col-sm-3">
                                            <h5>Remarks</h5>
                                            <asp:TextBox ID="txtPayRemarks" runat="server" Width="100%" TextMode="SingleLine"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row m-b-15">
                                        <div class="col-md-12 col-sm-3 text-center m-b-30">
                                            <asp:Button ID="btnPayment" CssClass="btn btn-primary" runat="server" Text="Save" ToolTip="Save" OnClick="btnPayment_Click" ValidationGroup="P" />
                                            <asp:Button ID="btnPaymentReceipt" CssClass="btn btn-primary" runat="server" Text="Payment Receipt" ToolTip="Payment Receipt" OnClick="btnPaymentReceipt_Click" />
                                        </div>
                                    </div>
                                    <div class="row m-b-30">
                                        <div class="col-md-12 col-sm-3 text-center m-b-30">
                                            <asp:GridView ID="GridPay" CssClass="table table-striped table-bordered" runat="server" AutoGenerateColumns="False"
                                                DataKeyNames="nPaymentReceiveID" Width="100%" AllowPaging="true" AllowSorting="True" PageSize="25" EmptyDataText="No Records to display"
                                                OnPageIndexChanging="GridPay_PageIndexChanging">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="nPaymentReceiveID" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblPayID" runat="server" Text='<%# Eval("nPaymentReceiveID") %>'></asp:Label>
                                                            <asp:Label ID="lblPaydETID" runat="server" Text='<%# Eval("nPaymentReceiveDetID") %>'></asp:Label>
                                                            <asp:Label ID="lblHotelID" runat="server" Text='<%# Eval("nInvoiceID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="sVoucherNo" HeaderText="Voucher No." />
                                                    <asp:TemplateField HeaderText="Payment Date">
                                                        <ItemTemplate>
                                                            <%#validation.TextToDate(Eval("dtPayment").ToString())%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="sInvoiceNo" HeaderText="Invoice No" />
                                                    <asp:BoundField DataField="sPayMode" HeaderText="Payment Mode" />
                                                    <asp:BoundField DataField="sCashAcc" HeaderText="Payment Account" />
                                                    <asp:BoundField DataField="sAgent" HeaderText="Agent Name" />
                                                    <asp:BoundField DataField="nAmount" HeaderText="Amount" />
                                                    <asp:BoundField DataField="sRemarks" HeaderText="Remarks" />
                                                    <asp:TemplateField HeaderText="Edit/Delete">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btngdPayEdit" runat="server" OnClick="btngdPayEdit_Click1" ToolTip="Edit">
                           <i class="far fa-lg fa-fw m-r-10 fa-edit fa-grid-edit"></i> <span class="text-inverse">Edit</span>
                                                            </asp:LinkButton>
                                                            <asp:LinkButton ID="btngdPayPrintDet" runat="server" OnClick="btngdPayPrintDet_Click" ToolTip="Print">
                    <i class="fas fa-lg fa-fw m-r-10 fa-print fa-grid-edit"></i> <span class="text-inverse">Print</span></asp:LinkButton>
                                                            <asp:LinkButton ID="btngdPayDelete" runat="server" OnClick="btngdPayDelete_Click" ToolTip="Delete">
                           <i class="far fa-lg fa-fw m-r-10 fa-trash-alt fa-grid-del"></i> <span class="text-inverse">Delete</span>
                                                            </asp:LinkButton>
                                                            <AjaxToolKit:ConfirmButtonExtender ID="btngdPayDelete_confirmbuttonextender" runat="server"
                                                                DisplayModalPopupID="btngdPayDelete_modalpopupextender" TargetControlID="btngdPayDelete" />
                                                            <AjaxToolKit:ModalPopupExtender ID="btngdPayDelete_modalpopupextender" runat="server"
                                                                BackgroundCssClass="modalBackground" CancelControlID="ButtonCancel0" OkControlID="ButtonOk0"
                                                                PopupControlID="PNL0" TargetControlID="btngdPayDelete" />
                                                            <br />
                                                            <asp:Panel ID="PNL0" runat="server" Style="display: none; width: 200px; background-color: #348fe2; border-width: 1px; border-color: Black; border-style: solid; padding: 20px;">
                                                                Are you sure you want to delete?
 <br />
                                                                <br />
                                                                <div style="text-align: right;">
                                                                    <asp:Button ID="ButtonOk0" runat="server" Text="OK" />
                                                                    <asp:Button ID="ButtonCancel0" runat="server" Text="Cancel" />
                                                                </div>
                                                            </asp:Panel>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                            </asp:Panel>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>


    <!-- end row -->

</asp:Content>
