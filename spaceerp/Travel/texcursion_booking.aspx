<%@ Page Title="Excursion Booking" Language="C#" MasterPageFile="~/Pagecontent.master" AutoEventWireup="true" CodeFile="texcursion_booking.aspx.cs" Inherits="Transcation_excursion_booking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link type="text/css" rel="stylesheet" href="../assets/css/default/mystyle.css" />
    <link href="../assets/css/default/style.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
    <link type="text/css" rel="stylesheet" href="../assets/css/default/mystyle.css" />
    <link href="../assets/css/default/style.min.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.3/umd/popper.min.js" integrity="sha384-vFJXuSJphROIrBnz7yo7oB41mKfc8JzQZiCq4NCceLEaO4IHwicKwpJf9c9IpFgh" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta.2/js/bootstrap.min.js" integrity="sha384-alpBpkh1PFOepccYVYDB4do5UnbKysX5WZXm3XxPqe5iKTfUKjNkCk9SaVuEZflJ" crossorigin="anonymous"></script>

</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="up11" runat="server">
        <ContentTemplate>
            <asp:Label ID="lblmsg" runat="server"></asp:Label>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div class="container-fluid nopad">
        <!-- begin col-6 -->
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
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

                            <h4 class="panel-title text-center">Excursion Booking </h4>




                        </div>
                        <!-- end panel-heading -->
                        <!-- begin panel-body -->
                        <div class="panel-body">

                            <asp:Panel class="tbl" ID="tblmain" runat="server">
                                <div>

                                    <div class="form-group row ">
                                        <div class="col-md-2 col-sm-3">
                                            <label class="col-form-label" for="fullname">
                                                Booking Type :</label>
                                            <asp:DropDownList CssClass="form-control" ID="ddlbookType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlbookType_SelectedIndexChanged">
                                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="Booking" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Refund" Value="2"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlbookType" ErrorMessage="Please fill out this field." Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-md-2 col-sm-3">
                                            <label class="col-form-label" for="fullname">
                                                Excursion Booking No. :</label>
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                                    <asp:TextBox ID="txtExcursionBookingNo" runat="server" CssClass="form-control" AutoPostBack="true" Enabled="true" OnTextChanged="txtExcursionBookingNo_TextChanged"> </asp:TextBox>
                                                </ContentTemplate>

                                            </asp:UpdatePanel>
                                        </div>
                                        <div class="col-md-2 col-sm-3">
                                            <label class="col-form-label" for="fullname">
                                                Excursion Date :</label>
                                            <asp:TextBox ID="txtdtExcursionBooking" runat="server" CssClass="form-control datepicker" Width="100%" AutoPostBack="true" OnTextChanged="txtdtExcursionBooking_TextChanged"></asp:TextBox>
                                            <%--<AjaxToolKit:CalendarExtender ID="CalendarExtender4" runat="server" Format="dd/MM/yyyy"
                                                PopupButtonID="txtdtExcursionBooking" TargetControlID="txtdtExcursionBooking" PopupPosition="TopLeft" />--%>

                                            <AjaxToolKit:MaskedEditExtender ID="MEE4" runat="server" TargetControlID="txtdtExcursionBooking"
                                                Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                            <asp:RegularExpressionValidator ID="REV4" ControlToValidate="txtdtExcursionBooking" ValidationGroup="A"
                                                Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                                ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                            </asp:RegularExpressionValidator>
                                        </div>
                                        <div class="col-md-2 col-sm-3">
                                            <label class="col-form-label" for="fullname">
                                                Supplier Name :</label>
                                            <asp:DropDownList CssClass="form-control js-example-placeholder-single" ID="ddlSupplier" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSupplier_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlSupplier" ErrorMessage="Please fill out this field." Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-md-2 col-sm-3">
                                            <label class="col-form-label" for="fullname">
                                                Client Name :</label>
                                            <asp:DropDownList CssClass="form-control js-example-placeholder-single" ID="ddlAgentID" runat="server">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RFV3" runat="server" ControlToValidate="ddlAgentID" ErrorMessage="Please fill out this field." Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                                        </div>

                                        <div class="col-md-2 col-sm-3">
                                            <label class="col-form-label" for="fullname">
                                                Location  :</label>
                                            <asp:DropDownList ID="ddlLocationID" runat="server" CssClass="form-control js-example-placeholder-single" required>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RFV4" runat="server" ControlToValidate="ddlAgentID" ErrorMessage="Please fill out this field." Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                                        </div>

                                    </div>

                                </div>

                                <asp:Panel class="tbl" ID="tblDet" runat="server">

                                    <div>

                                        <div class="row">
                                            <div class="col-md-2 col-sm-3">
                                                <label class="col-form-label" for="fullname">
                                                    Ref. No. :</label>
                                                <asp:TextBox ID="txtExcursionReferenceNo" CssClass="form-control" runat="server" Width="100%" required ValidationGroup="B">
                                                </asp:TextBox>
                                            </div>
                                            <div class="col-md-2 col-sm-3">
                                                <label class="col-form-label" for="fullname">
                                                    Guest Name :</label>
                                                <asp:TextBox ID="txtGuestName" CssClass="form-control" runat="server" ValidationGroup="B" Width="100%">
                                                </asp:TextBox>
                                            </div>

                                            <div class="col-md-2 col-sm-3">
                                                <label class="col-form-label" for="fullname">Excursion Type </label>
                                                <asp:DropDownList ID="ddlExcursionTypeID" CssClass="form-control" runat="server" Width="100%"></asp:DropDownList>
                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlExcursionTypeID" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>--%>
                                            </div>
                                            <div class="col-md-2 col-sm-3">
                                                <label class="col-form-label" for="fullname">
                                                    Diver Name :</label>
                                                <asp:DropDownList ID="ddlDiverNameID" CssClass="form-control" runat="server" Width="100%"></asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlDiverNameID" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="B"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="col-md-2 col-sm-3">
                                                <label class="col-form-label" for="fullname">
                                                    Pickup Place :</label>
                                                <asp:TextBox ID="txtPickupPlace" CssClass="form-control" runat="server" Width="100%"></asp:TextBox>
                                            </div>

                                            <div class="col-md-2 col-sm-3">
                                                <label class="col-form-label" for="fullname">
                                                    Telephone :</label>
                                                <asp:TextBox ID="txtTelephone" CssClass="form-control" runat="server" Width="100%"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-2 col-sm-3">
                                                <label class="col-form-label" for="fullname">
                                                    Job No. :</label>
                                                <asp:TextBox ID="txtJobNo" CssClass="form-control" runat="server" ValidationGroup="B" Width="100%">
                                                </asp:TextBox>

                                            </div>
                                            <div class="col-md-2 col-sm-3">
                                                <label class="col-form-label" for="fullname">
                                                    Pickup Date :</label>
                                                <asp:TextBox ID="txttPickupDate" runat="server" CssClass="form-control datepicker" Width="100%" placeholder="DD/MM/YYYY"></asp:TextBox>
                                                <%--<AjaxToolKit:CalendarExtender ID="CalendarExtender9" runat="server" Format="dd/MM/yyyy"
                                                    PopupButtonID="txttPickupDate" TargetControlID="txttPickupDate" PopupPosition="TopLeft" />--%>
                                                <AjaxToolKit:MaskedEditExtender ID="MEE9" runat="server"
                                                    TargetControlID="txttPickupDate" Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                                <asp:RegularExpressionValidator ID="REV9" ControlToValidate="txttPickupDate"
                                                    ValidationGroup="A" Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                                    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                                </asp:RegularExpressionValidator>
                                            </div>
                                            <div class="col-md-2 col-sm-3">
                                                <label class="col-form-label" for="fullname">
                                                    Pick Time :</label>
                                                <asp:TextBox ID="txtPickupTime" CssClass="form-control" runat="server" Text="12:00" ValidationGroup="B" Width="100%"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="rev" runat="server" ErrorMessage="InvalidTime"
                                                    ControlToValidate="txtPickupTime" ValidationExpression="^((0?[1-9])|(1[0-2]))(:|\s)([0-5][0-9])$">
                                                </asp:RegularExpressionValidator>
                                                <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender2" runat="server"
                                                    TargetControlID="txtPickupTime" Mask="99:99" MaskType="Time" AcceptNegative="None" />
                                            </div>
                                            <div class="col-md-2 col-sm-3" style="padding-top: 32px; padding-left: 0px">
                                                <asp:DropDownList ID="ddlPickTimeFormatID" runat="server" CssClass="form-control" Width="100%">

                                                    <asp:ListItem Value="1" Text="AM"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="PM"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-md-2 col-sm-4">
                                                <label class="col-form-label" for="fullname">
                                                    Drop Time
                                                </label>
                                                <asp:TextBox ID="txtDropTime" CssClass="form-control" runat="server" Text="12:00" ValidationGroup="B" Width="100%"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="InvalidTime"
                                                    ControlToValidate="txtDropTime" ValidationExpression="^((0?[1-9])|(1[0-2]))(:|\s)([0-5][0-9])$">
                                                </asp:RegularExpressionValidator>
                                                <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender1" runat="server"
                                                    TargetControlID="txtDropTime" Mask="99:99" MaskType="Time" AcceptNegative="None" />
                                            </div>
                                            <div class="col-md-2 col-sm-3" style="padding-top: 32px; padding-left: 0px">
                                                <asp:DropDownList ID="ddlDropTimeFormatID" CssClass="form-control" runat="server" Width="100%">

                                                    <asp:ListItem Value="1" Text="AM"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="PM"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>

                                        </div>


                                    </div>
                                    <div class="row">

                                        <div class="col-md-6 col-sm-12">

                                            <div>




                                                <div class="form-group row m-b-5">
                                                    <div class="col-md-3 col-sm-3">
                                                        <label class="col-form-label" for="fullname">
                                                            Client SC Type
                                                        </label>
                                                        <asp:DropDownList ID="ddlProfitType" CssClass="form-control" runat="server" Width="90%">
                                                            <asp:ListItem Value="0" Text="Value"></asp:ListItem>
                                                            <asp:ListItem Value="1" Text="% "></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="col-md-2 col-sm-3">
                                                        <label class="col-form-label" for="fullname">
                                                            Clnt SC
                                                        </label>
                                                        <asp:TextBox ID="txtProfitAmt" CssClass="form-control" runat="server" placeholder="" Width="90%" AutoPostBack="True" OnTextChanged="txtProfitAmt_TextChanged"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtProfitAmt"
                                                            SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                            ValidationGroup="A"></asp:RegularExpressionValidator>
                                                        <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                                            Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtProfitAmt"
                                                            ValidChars=".-">
                                                        </AjaxToolKit:FilteredTextBoxExtender>
                                                    </div>
                                                    <div class="col-md-2 col-sm-3">
                                                        <label class="col-form-label" for="fullname">
                                                            Clnt SC2
                                                        </label>
                                                        <asp:TextBox ID="txtProfitAmt2" CssClass="form-control" runat="server" placeholder="" Width="90%" AutoPostBack="True" OnTextChanged="txtProfitAmt2_TextChanged"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtProfitAmt2"
                                                            SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                            ValidationGroup="A"></asp:RegularExpressionValidator>
                                                        <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server"
                                                            Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtProfitAmt2"
                                                            ValidChars=".-">
                                                        </AjaxToolKit:FilteredTextBoxExtender>
                                                    </div>
                                                    <div class="col-md-3 col-sm-3">
                                                        <label class="col-form-label" for="fullname">
                                                            TDS Type
                                                        </label>
                                                        <asp:DropDownList ID="ddlClntTds" CssClass="form-control" runat="server" Width="90%">
                                                            <asp:ListItem Value="0" Text="Value"></asp:ListItem>
                                                            <asp:ListItem Value="1" Text="%"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="col-md-2 col-sm-3">
                                                        <label class="col-form-label" for="fullname">
                                                            Clnt TDS
                                                        </label>
                                                        <asp:TextBox ID="txtClntTds" CssClass="form-control" runat="server" placeholder="" Width="90%" AutoPostBack="True" OnTextChanged="txtClntTds_TextChanged"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" ControlToValidate="txtClntTds"
                                                            SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                            ValidationGroup="A"></asp:RegularExpressionValidator>
                                                        <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server"
                                                            Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtClntTds"
                                                            ValidChars=".-">
                                                        </AjaxToolKit:FilteredTextBoxExtender>
                                                    </div>
                                                </div>
                                                <div class="form-group row m-b-5">


                                                    <div class="col-md-4 col-sm-3">
                                                        <label class="col-form-label" for="fullname">
                                                            Discount
                                                        </label>
                                                        <asp:TextBox ID="txtDiscount" runat="server" CssClass="form-control" Width="95%" Placeholder="Discount   :" OnTextChanged="txtDiscount_TextChanged" AutoPostBack="true" ></asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server" ControlToValidate="txtDiscount"
                                                            SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                            ValidationGroup="A"></asp:RegularExpressionValidator>
                                                        <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" runat="server"
                                                            Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtDiscount"
                                                            ValidChars=".-">
                                                        </AjaxToolKit:FilteredTextBoxExtender>
                                                    </div>
                                                    <div class="col-md-4 col-sm-3">
                                                        <label class="col-form-label" for="fullname">
                                                            Other Chrgs
                                                        </label>
                                                        <asp:TextBox ID="txtOtherchrg" runat="server" CssClass="form-control" Width="95%" Placeholder="" OnTextChanged="txtOtherchrg_TextChanged" AutoPostBack="true" ></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server" ControlToValidate="txtOtherchrg"
                                                            SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                            ValidationGroup="A"></asp:RegularExpressionValidator>
                                                        <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender12" runat="server"
                                                            Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtOtherchrg"
                                                            ValidChars=".-">
                                                        </AjaxToolKit:FilteredTextBoxExtender>
                                                    </div>

                                                    <div class="col-md-4 col-sm-2">
                                                        <label class="col-form-label" for="fullname">
                                                            Remarks :</label>
                                                        <asp:TextBox ID="txtRemarks" CssClass="form-control" runat="server" Width="90%"></asp:TextBox>
                                                    </div>

                                                </div>

                                                <fieldset class="the-fieldset">
                                                    <div class="form-group row">

                                                        <div class="col-md-1 col-sm-1">
                                                            <label class="col-form-label" for="fullname">
                                                                Tax
                                                            </label>
                                                            <asp:CheckBox ID="chkClntTax" runat="server" Width="90%" Checked="true" AutoPostBack="True" OnCheckedChanged="chkClntTax_CheckedChanged"></asp:CheckBox>

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
                                                            <asp:TextBox ID="txtClntIgst" CssClass="form-control" runat="server" Width="90%" Enabled="false"></asp:TextBox>

                                                        </div>
                                                    </div>
                                                </fieldset>

                                            </div>

                                        </div>
                                        <div class="col-md-6 col-sm-12">
                                            <div>



                                                <div class="form-group row m-b-10">
                                                    <div class="col-md-2 col-sm-3">
                                                        <label class="col-form-label" for="fullname">
                                                            Adl. :</label>
                                                        <asp:TextBox ID="txtAdultPax" CssClass="form-control" Width="90%" runat="server" ValidationGroup="B" AutoPostBack="true" OnTextChanged="txtAdultPax_TextChanged"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="REV14" runat="server" ControlToValidate="txtAdultPax"
                                                            SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                            ValidationGroup="B"></asp:RegularExpressionValidator>
                                                        <AjaxToolKit:FilteredTextBoxExtender ID="FTBE14" runat="server"
                                                            Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtAdultPax"
                                                            ValidChars=".-">
                                                        </AjaxToolKit:FilteredTextBoxExtender>
                                                    </div>
                                                    <div class="col-md-2 col-sm-3">
                                                        <label class="col-form-label" for="fullname">
                                                            Adl.  Rate :</label>
                                                        <asp:TextBox ID="txtAdultPaxRate" CssClass="form-control" Width="90%" runat="server" ValidationGroup="B" AutoPostBack="true" OnTextChanged="txtAdultPaxRate_TextChanged"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtAdultPaxRate"
                                                            SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                            ValidationGroup="B"></asp:RegularExpressionValidator>
                                                        <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                                            Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtAdultPaxRate"
                                                            ValidChars=".-">
                                                        </AjaxToolKit:FilteredTextBoxExtender>
                                                    </div>
                                                    <div class="col-md-2 col-sm-3">
                                                        <label class="col-form-label" for="fullname">
                                                            Chd. :</label>
                                                        <asp:TextBox ID="txtChildPax" CssClass="form-control" runat="server" Width="90%" AutoPostBack="true" OnTextChanged="txtChildPax_TextChanged"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="REV16" runat="server" ControlToValidate="txtChildPax"
                                                            SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                            ValidationGroup="A"></asp:RegularExpressionValidator>
                                                        <AjaxToolKit:FilteredTextBoxExtender ID="FTBE16" runat="server"
                                                            Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtChildPax"
                                                            ValidChars=".-">
                                                        </AjaxToolKit:FilteredTextBoxExtender>
                                                    </div>
                                                    <div class="col-md-2 col-sm-3">
                                                        <label class="col-form-label" for="fullname">
                                                            Chd. Rate :</label>
                                                        <asp:TextBox ID="txtChildPaxRate" CssClass="form-control" runat="server" Width="90%" AutoPostBack="true" OnTextChanged="txtChildPax_TextChanged"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="REV17" runat="server" ControlToValidate="txtChildPaxRate"
                                                            SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                            ValidationGroup="A"></asp:RegularExpressionValidator>
                                                        <AjaxToolKit:FilteredTextBoxExtender ID="FTBE17" runat="server"
                                                            Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtChildPaxRate"
                                                            ValidChars=".-">
                                                        </AjaxToolKit:FilteredTextBoxExtender>
                                                    </div>
                                                    <div class="col-md-2 col-sm-3" style="display:none;">
                                                        <label class="col-form-label" for="fullname">
                                                            Inf. :</label>
                                                        <asp:TextBox ID="txtInfPax" CssClass="form-control" runat="server" Width="90%" AutoPostBack="true" OnTextChanged="txtInfPax_TextChanged"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtInfPax"
                                                            SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                            ValidationGroup="A"></asp:RegularExpressionValidator>
                                                        <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server"
                                                            Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtInfPax"
                                                            ValidChars=".-">
                                                        </AjaxToolKit:FilteredTextBoxExtender>
                                                    </div>
                                                    <div class="col-md-2 col-sm-3" style="display:none;">
                                                        <label class="col-form-label" for="fullname">
                                                            Inf. Rate :</label>
                                                        <asp:TextBox ID="txtInfRate" runat="server" CssClass="form-control" Width="90%" AutoPostBack="true" OnTextChanged="txtInfRate_TextChanged"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="txtInfRate"
                                                            SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                            ValidationGroup="A"></asp:RegularExpressionValidator>
                                                        <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server"
                                                            Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtInfRate"
                                                            ValidChars=".-">
                                                        </AjaxToolKit:FilteredTextBoxExtender>
                                                    </div>

                                                </div>
                                                <div class="form-group row m-b-5">
                                                    <div class="col-md-3 col-sm-4">
                                                        <label class="col-form-label" for="fullname">
                                                            SC Type
                                                        </label>
                                                        <asp:DropDownList ID="ddlSupScType" CssClass="form-control" runat="server" Width="90%">
                                                            <asp:ListItem Value="0" Text="Value"></asp:ListItem>
                                                            <asp:ListItem Value="1" Text="% "></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="col-md-2 col-sm-3">
                                                        <label class="col-form-label" for="fullname">
                                                            Sup. SC :</label>
                                                        <asp:TextBox ID="txtSupSc" runat="server" CssClass="form-control" Width="90%" Enabled="true" AutoPostBack="True" OnTextChanged="txtSupSc_TextChanged"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="txtTotal"
                                                            SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                            ValidationGroup="B"></asp:RegularExpressionValidator>
                                                        <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server"
                                                            Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtTotal"
                                                            ValidChars=".-">
                                                        </AjaxToolKit:FilteredTextBoxExtender>
                                                    </div>
                                                    <div class="col-md-3 col-sm-4">
                                                        <label class="col-form-label" for="fullname">
                                                            TDS Type
                                                        </label>
                                                        <asp:DropDownList ID="ddlSupTds" CssClass="form-control" runat="server" Width="90%">
                                                            <asp:ListItem Value="0" Text="Value"></asp:ListItem>
                                                            <asp:ListItem Value="1" Text="% "></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="col-md-2 col-sm-3">
                                                        <label class="col-form-label" for="fullname">
                                                            Sup. TDS :</label>
                                                        <asp:TextBox ID="txtSupTds" runat="server" CssClass="form-control" Width="90%" Enabled="true" AutoPostBack="True" OnTextChanged="txtSupTds_TextChanged"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtSupTds"
                                                            SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                            ValidationGroup="B"></asp:RegularExpressionValidator>
                                                        <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                                            Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtSupTds"
                                                            ValidChars=".-">
                                                        </AjaxToolKit:FilteredTextBoxExtender>
                                                    </div>
                                                    <div class="col-md-2 col-sm-3">
                                                        <label class="col-form-label" for="fullname">
                                                            Discount :</label>
                                                        <asp:TextBox ID="txtSupDiscount" runat="server" CssClass="form-control" Width="90%" Enabled="true" AutoPostBack="True" OnTextChanged="txtSupDiscount_TextChanged"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator17" runat="server" ControlToValidate="txtSupDiscount"
                                                            SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                            ValidationGroup="B"></asp:RegularExpressionValidator>
                                                        <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender13" runat="server"
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
                                                            <asp:CheckBox ID="chkSupTax" runat="server" Width="90%" Checked="true" AutoPostBack="True" OnCheckedChanged="chkSupTax_CheckedChanged"></asp:CheckBox>

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
                                                            <asp:TextBox ID="txtsupigst" CssClass="form-control" runat="server" Width="90%" Enabled="false"></asp:TextBox>

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
                                                            <asp:TextBox ID="txtdtRfnDate" runat="server" CssClass="datepicker " Width="100%" Enabled="true"></asp:TextBox>
                                                            <AjaxToolKit:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd/MM/yyyy"
                                                                PopupButtonID="txtdtRfnDate" TargetControlID="txtdtRfnDate" PopupPosition="TopLeft" />
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
                                                            <asp:TextBox ID="txtrfnSC" runat="server" CssClass="form-control" Width="95%" Enabled="true" AutoPostBack="True" OnTextChanged="txtrfnSC_TextChanged"></asp:TextBox>

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

                                                                    <div class="col-md-1 col-sm-1">
                                                                        <label class="col-form-label" for="fullname">
                                                                            Tax
                                                                        </label>
                                                                        <asp:CheckBox ID="chkRfnTax" runat="server" Width="100%" Checked="true" AutoPostBack="True" OnCheckedChanged="chkRfnTax_CheckedChanged"></asp:CheckBox>

                                                                    </div>

                                                                    <div class="col-md-4 col-sm-4">
                                                                        <label class="col-form-label" for="fullname">
                                                                            CGST
                                                                        </label>
                                                                        <asp:TextBox ID="txtRfnCGst" runat="server" Width="95%" Enabled="false"></asp:TextBox>

                                                                    </div>

                                                                    <div class="col-md-4 col-sm-4">
                                                                        <label class="col-form-label" for="fullname">
                                                                            SGST
                                                                        </label>
                                                                        <asp:TextBox ID="txtRfnSGst" runat="server" Width="95%" Enabled="false"></asp:TextBox>

                                                                    </div>
                                                                    <div class="col-md-3 col-sm-3">
                                                                        <label class="col-form-label" for="fullname">
                                                                            IGST
                                                                        </label>
                                                                        <asp:TextBox ID="txtRfnIGst" runat="server" Width="95%" Enabled="false"></asp:TextBox>

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
                                            <asp:Label ID="lblSelleing" runat="server" Visible="false"></asp:Label>
                                            <asp:TextBox ID="txtsellingCost" runat="server" Width="40%" ForeColor="Black" CssClass="btn bg-blue-darker" Enabled="false" Placeholder="Selling Rate   :" required></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtTotal"
                                                SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                ValidationGroup="A"></asp:RegularExpressionValidator>
                                            <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                                Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtTotal"
                                                ValidChars=".-">
                                            </AjaxToolKit:FilteredTextBoxExtender>

                                        </div>
                                        <div class="col-md-6 col-sm-6 text-center">

                                            <label class="col-form-label text-center" for="fullname">
                                                Supplier Cost
                                            </label>
                                            <asp:Label ID="lblBuyCost" runat="server" Visible="false"></asp:Label>
                                            <asp:TextBox ID="txtTotal" runat="server" Width="40%" ForeColor="Black" CssClass="btn bg-blue-darker" required Enabled="false"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server" ControlToValidate="txtTotal"
                                                SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                ValidationGroup="A"></asp:RegularExpressionValidator>
                                            <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server"
                                                Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtTotal"
                                                ValidChars=".-">
                                            </AjaxToolKit:FilteredTextBoxExtender>

                                        </div>

                                    </div>

                                    <div class="form-group row m-b-0" style="margin: 20px; text-align: center;">

                                        <div class="col-md-12 col-sm-12">
                                            <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary btnspl" Text="Add" ValidationGroup="A"
                                                OnClick="btnAdd_Click" ToolTip="Add" />
                                            <asp:Button ID="btnAddDet" runat="server" CssClass="btn btn-primary" Text="Add" ValidationGroup="A" OnClick="btnAddDet_Click" ToolTip="Add" />
                                            <asp:Button ID="btnUpdateDet" runat="server" CssClass="btn btn-primary" Text="Update" ValidationGroup="A" OnClick="btnUpdateDet_Click" ToolTip="Update" />
                                            <asp:LinkButton ID="btnPrint" runat="server" Text="Print New" OnClick="btnPrint_Click" CssClass="btn btn-primary"></asp:LinkButton>
                                           <%--<asp:Button ID="btnPrint" runat="server" CssClass="btn btn-primary" Text="Print" OnClick="btnPrint_Click" ToolTip="Print" Visible="false" CausesValidation="false"/>--%>
                                            <asp:Button ID="btnPaymentHistory" runat="server" CssClass="btn btn-primary" Text="Payment History" OnClick="btnPaymentHistory_Click" ToolTip="Payment History" Visible="false" />
                                            <%-- <asp:Button ID="btnDeleteDet" runat="server" CssClass="btn btn-primary" Text="Delete" ValidationGroup="A" OnClick="btnDeleteDet_Click" ToolTip="Delete" />

                            <AjaxToolKit:ConfirmButtonExtender ID="btnDeleteDet_ConfirmButtonExtender" runat="server"
                                DisplayModalPopupID="btnDeleteDet_modalpopupextender" TargetControlID="btnDeleteDet" />
                            <AjaxToolKit:ModalPopupExtender ID="btnDeleteDet_modalpopupextender" runat="server"
                                BackgroundCssClass="modalBackground" CancelControlID="ButtonCancelDet" OkControlID="ButtonOkD"
                                PopupControlID="PNL1" TargetControlID="btnDeleteDet" />
                            <br />
                            <asp:Panel ID="PNL1" runat="server" Style="display: none; width: 200px; background-color: #348fe2; border-width: 1px; border-color: Black; border-style: solid; padding: 20px;">
                                Are you sure you want to delete?
<br />
                                <br />
                                <div style="text-align: right;">
                                    <asp:Button ID="ButtonOkD" runat="server" Text="OK" />
                                    <asp:Button ID="ButtonCancelDet" runat="server" Text="Cancel" />
                                </div>
                            </asp:Panel>--%>
                                        </div>
                                    </div>

                                </asp:Panel>

                                <asp:Panel class="tbl table-responsive" ID="tblGridDet" runat="server" Style="margin-top: 20px;">

                                    <asp:Label ID="lblpgsDet" runat="server" Text="Page Size :"></asp:Label>
                                    <asp:DropDownList ID="ddlPageSizeDet" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPageSizeDet_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:GridView ID="GridView2" CssClass="table table-striped table-bordered" runat="server" AutoGenerateColumns="False"
                                        DataKeyNames="nExcursionBookingDetID" Width="100%" AllowPaging="false" AllowSorting="True" EmptyDataText="No Records to display"
                                        OnPageIndexChanging="GridView2_PageIndexChanging">
                                        <Columns>
                                            <asp:TemplateField HeaderText="nExcursionBookingDetID" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDetID" runat="server" Text='<%# Eval("nExcursionBookingDetID") %>'></asp:Label>
                                                    <asp:Label ID="lblExcurID" runat="server" Text='<%# Eval("nExcursionBookingID") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="sExcursionReferenceNo" HeaderText="ExcursionReferenceNo" />
                                            <asp:BoundField DataField="sGuestName" HeaderText="GuestName" />
                                            <asp:BoundField DataField="sExcursionType" HeaderText="ExcursionTypeID" />
                                            <asp:BoundField DataField="sDriverName" HeaderText="DiverNameID" />
                                            <asp:BoundField DataField="sPickupPlace" HeaderText="PickupPlace" />
                                            <asp:BoundField DataField="sTelephone" HeaderText="Telephone" />
                                            <asp:BoundField DataField="sJobNo" HeaderText="JobNo" />
                                            <asp:TemplateField HeaderText="tPickupDate">
                                                <ItemTemplate>
                                                    <%#validation.TextToDate(Eval("dtPickupDate").ToString())%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="nTotal" HeaderText="Total" />
                                            <asp:BoundField DataField="sRemarks" HeaderText="Remarks" />
                                            <asp:TemplateField HeaderText="Edit/Delete">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btngdEditDet" runat="server" OnClick="btngdEditDet_Click" ToolTip="Edit">
                    <i class="far fa-lg fa-fw m-r-10 fa-edit fa-grid-edit"></i> <span class="text-inverse">Edit</span>
                                                    </asp:LinkButton>
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
                                <div>
                                    <div class="form-group row m-b-15">
                                        <div class="col-md-3 col-sm-3">
                                            <label class="col-form-label" for="fullname">
                                                Invoice No. :</label>
                                            <asp:DropDownList CssClass="form-control js-example-placeholder-single" ID="ddlInvoiceNo" runat="server">
                                            </asp:DropDownList>

                                        </div>
                                        <div class="col-md-3 col-sm-3">
                                            <label class="col-form-label" for="fullname">
                                                Booking Type  :</label>
                                            <asp:DropDownList ID="ddlSBookType" runat="server" CssClass="js-example-placeholder-single form-control">
                                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="Booking" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Refund" Value="2"></asp:ListItem>

                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-md-3 col-sm-3" style="z-index: 99">
                                            <label class="col-form-label" for="fullname">
                                                Invoice Date :</label>
                                            <asp:TextBox ID="txtSdtBooking" runat="server" CssClass="form-control datepicker" Width="100%" placeholder="dd/MM/yyyy"></asp:TextBox>
                                            <%--<AjaxToolKit:CalendarExtender ID="CalendarExtender5" runat="server" Format="dd/MM/yyyy"
                                                PopupButtonID="txtSdtBooking" TargetControlID="txtSdtBooking" PopupPosition="BottomLeft" />--%>

                                            <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender4" runat="server" TargetControlID="txtSdtBooking"
                                                Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator16" ControlToValidate="txtSdtBooking" ValidationGroup="A"
                                                Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                                ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                            </asp:RegularExpressionValidator>
                                        </div>

                                        <div class="col-md-3 col-sm-3">
                                            <label class="col-form-label" for="fullname">
                                                Client Name :</label>
                                            <asp:DropDownList CssClass="form-control js-example-placeholder-single" ID="ddlSClient" runat="server">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-md-3 col-sm-3">
                                            <label class="col-form-label" for="fullname">
                                                Supplier Name :</label>
                                            <asp:DropDownList CssClass="form-control js-example-placeholder-single" ID="ddlSSup" runat="server">
                                            </asp:DropDownList>
                                        </div>

                                        <div class="col-md-3 col-sm-3">
                                            <label class="col-form-label" for="fullname">
                                                Location  :</label>
                                            <asp:DropDownList ID="ddlSLoc" runat="server" CssClass="js-example-placeholder-single form-control">
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
                                    AutoGenerateColumns="False" EmptyDataText="No Records to display"
                                    DataKeyNames="nExcursionBookingID" Width="100%" AllowPaging="true" AllowSorting="True" PageSize="25"
                                    OnPageIndexChanging="GridView1_PageIndexChanging">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Invoice Date" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblID" runat="server" Text='<%# Eval("nExcursionBookingID") %>'></asp:Label>
                                                <asp:Label ID="lblAgentID" runat="server" Text='<%# Eval("nAgentID") %>'></asp:Label>
                                                <asp:Label ID="lblBalance" runat="server" Text='<%# Eval("nBalance") %>'></asp:Label>
                                                <asp:Label ID="lblInvoiceNo" runat="server" Text='<%# Eval("sExcursionBookingNo") %>'></asp:Label>
                                                <asp:Label ID="lblBookType" runat="server" Text='<%# Eval("sBookType") %>'></asp:Label>
                                                <asp:Label ID="lblInvoiceDate" runat="server" Text='<%# Eval("dtExcursionBooking") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="sBookType" HeaderText="Book Type" />
                                        <asp:BoundField DataField="sExcursionBookingNo" HeaderText="Invoice No" />
                                        <asp:TemplateField HeaderText="Invoice Date">
                                            <ItemTemplate>
                                                <%#validation.TextToDate(Eval("dtExcursionBooking").ToString())%>
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
                                        <h4 class="modal-title">Excursion Payment</h4>
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
                                            <asp:TextBox ID="txtdtpayment" runat="server" CssClass="datepicker" Width="100%" TextMode="SingleLine" placeholder="DD/MM/YYYY" OnTextChanged="txtdtpayment_TextChanged" AutoPostBack="true"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtdtpayment" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                                            <%-- <AjaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy"
                                                PopupButtonID="txtdtpayment" TargetControlID="txtdtpayment" PopupPosition="BottomLeft" />--%>
                                            <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender5" runat="server"
                                                TargetControlID="txtdtpayment" Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator15" ControlToValidate="txtdtpayment"
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
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddlPayVoucherType" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="P"></asp:RequiredFieldValidator>
                                        </div>

                                        <div class="col-md-3 col-sm-3">
                                            <h5>Payment Account</h5>
                                            <asp:DropDownList ID="ddlPaymentAccount" runat="server" Width="100%">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="ddlPaymentAccount" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="P"></asp:RequiredFieldValidator>
                                        </div>

                                        <div class="col-md-3 col-sm-3">
                                            <h5>Amount</h5>
                                            <asp:TextBox ID="txtPayAmount" runat="server" Width="100%"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator19" runat="server" ControlToValidate="txtPayAmount"
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
                                                            <asp:Label ID="lblExcursionID" runat="server" Text='<%# Eval("nInvoiceID") %>'></asp:Label>
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
                        <!-- end panel-body -->
                        <!-- end panel -->
                    </div>
                    <!-- end col-6 -->
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <!-- end row -->
    </div>
</asp:Content>
