<%@ Page Title="Car Booking" Language="C#" MasterPageFile="~/Pagecontent.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="tcar_booking.aspx.cs" Inherits="Transcation_car_booking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
                        <a href="Statements/tcar_statement.aspx?AccType=0&AccTitle=&Loc=0&DtStFrom=&DtStTo=" target="_blank" class="btn btn-info btn-xs">Statement</a>
                    </div>
                    <div class="panel-heading-btn">
                        <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                        <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                    </div>

                    <h4 class="panel-title text-center">Car Booking </h4>




                </div>
                <!-- end panel-heading -->
                <!-- begin panel-body -->
                <div class="panel-body">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:Panel class="tbl" ID="tblmain" runat="server">
                                <div style="padding: 5px; margin-top: 5px;">

                                    <div class="form-group row">
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
                                        <div class="col-md-2 col-sm-2">
                                            <label class="col-form-label" for="fullname">
                                                Invoice No. :</label>
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                                    <asp:TextBox ID="txtBookingNo" runat="server" CssClass="form-control" AutoPostBack="true" Enabled="true" OnTextChanged="txtBookingNo_TextChanged"> </asp:TextBox>
                                                </ContentTemplate>

                                            </asp:UpdatePanel>
                                        </div>
                                        <div class="col-md-2 col-sm-2" style="z-index: 99">
                                            <label class="col-form-label" for="fullname">
                                                Invoice Date :</label>
                                            <asp:TextBox ID="txtdtBookingDate" runat="server" CssClass="datepicker form-control" Width="100%" required AutoPostBack="true" OnTextChanged="txtdtBookingDate_TextChanged"></asp:TextBox>
                                            <AjaxToolKit:CalendarExtender ID="CalendarExtender4" runat="server" Format="dd/MM/yyyy"
                                                PopupButtonID="txtdtBookingDate" TargetControlID="txtdtBookingDate" PopupPosition="BottomLeft" />

                                            <AjaxToolKit:MaskedEditExtender ID="MEE4" runat="server" TargetControlID="txtdtBookingDate"
                                                Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                            <asp:RegularExpressionValidator ID="REV4" ControlToValidate="txtdtBookingDate" ValidationGroup="A"
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

                                        <div class="col-md-2 col-sm-2">
                                            <label class="col-form-label" for="fullname">
                                                Location  :</label>
                                            <asp:DropDownList ID="ddlLocationID" runat="server" CssClass="form-control js-example-placeholder-single">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RFV4" runat="server" ControlToValidate="ddlAgentID" ErrorMessage="Please fill out this field." Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                                        </div>

                                    </div>

                                </div>

                                <asp:Panel class="tbl" ID="tblDet" runat="server">
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                        <ContentTemplate>
                                            <div style="padding: 5px; padding-top: 0px; margin-top: 0px;">

                                                <div class="row">
                                                    <div class="col-md-2 col-sm-3">
                                                        <label class="col-form-label" for="fullname">
                                                            Ref. No. :</label>
                                                        <asp:TextBox CssClass="form-control" ID="txtReferenceNo" runat="server" Width="100%" required ValidationGroup="B">
                                                        </asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtReferenceNo" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="B"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-md-2 col-sm-3">
                                                        <label class="col-form-label" for="fullname">
                                                            Pax Name :</label>
                                                        <asp:TextBox CssClass="form-control" ID="txtPaxtName" runat="server" ValidationGroup="B" Width="100%">
                                                        </asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPaxtName" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="B"></asp:RequiredFieldValidator>
                                                    </div>

                                                    <div class="col-md-2 col-sm-3">
                                                        <label class="col-form-label" for="fullname">Adult </label>
                                                        <asp:TextBox CssClass="form-control" ID="txtAdult" runat="server" ValidationGroup="B" Width="100%"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtAdult" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="B"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-md-2 col-sm-3">
                                                        <label class="col-form-label" for="fullname">Child </label>
                                                        <asp:TextBox CssClass="form-control" ID="txtChild" runat="server" ValidationGroup="B" Width="100%"></asp:TextBox>
                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlExcursionTypeID" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>--%>
                                                    </div>
                                                    <div class="col-md-2 col-sm-3">
                                                        <label class="col-form-label" for="fullname">Infant </label>
                                                        <asp:TextBox CssClass="form-control" ID="txtInfant" runat="server" ValidationGroup="B" Width="100%"></asp:TextBox>
                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlExcursionTypeID" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>--%>
                                                    </div>




                                                    <div class="col-md-2 col-sm-3">
                                                        <label class="col-form-label" for="fullname">
                                                            Telephone :</label>
                                                        <asp:TextBox CssClass="form-control" ID="txtTelephone" runat="server" Width="100%"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-2 col-sm-3">
                                                        <label class="col-form-label" for="fullname">
                                                            Diver Name :</label>
                                                        <asp:DropDownList CssClass="form-control" ID="ddlDriverID" runat="server" Width="100%"></asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlDriverID" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="B"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-md-2 col-sm-3">
                                                        <label class="col-form-label" for="fullname">
                                                            Vehicle No. :</label>
                                                        <asp:DropDownList CssClass="form-control" ID="ddlVehicleID" runat="server" Width="100%"></asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlVehicleID" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="B"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-md-2 col-sm-3">
                                                        <label class="col-form-label" for="fullname">
                                                            Trip Date :</label>
                                                        <asp:TextBox ID="txttTripDate" runat="server" CssClass="datepicker form-control" Width="100%" placeholder="DD/MM/YYYY"></asp:TextBox>
                                                        <%-- <AjaxToolKit:CalendarExtender ID="CalendarExtender9" runat="server" Format="dd/MM/yyyy"
                                                    PopupButtonID="txttTripDate" TargetControlID="txttTripDate" PopupPosition="TopLeft" />--%>
                                                        <AjaxToolKit:MaskedEditExtender ID="MEE9" runat="server"
                                                            TargetControlID="txttTripDate" Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                                        <asp:RegularExpressionValidator ID="REV9" ControlToValidate="txttTripDate"
                                                            ValidationGroup="A" Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                                            ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                                        </asp:RegularExpressionValidator>
                                                    </div>
                                                    <div class="col-md-2 col-sm-3">
                                                        <label class="col-form-label" for="fullname">
                                                            Pickup Place :</label>
                                                        <asp:TextBox CssClass="form-control" ID="txtPickupPlace" runat="server" Width="100%"></asp:TextBox>
                                                    </div>
                                                    <div class="col-md-2 col-sm-3">
                                                        <label class="col-form-label" for="fullname">XO/CR No. </label>
                                                        <asp:TextBox CssClass="form-control" ID="txtCrNo" runat="server" ValidationGroup="B" Width="100%"></asp:TextBox>
                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlExcursionTypeID" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>--%>
                                                    </div>


                                                    <div class="col-md-2 col-sm-3">
                                                        <label class="col-form-label" for="fullname">
                                                            pay Type</label>
                                                        <asp:DropDownList CssClass="form-control" ID="ddlPayType" runat="server" Width="100%">
                                                            <asp:ListItem Text="Cash" Value="Cash"></asp:ListItem>
                                                            <asp:ListItem Text="Bank" Value="Bank"></asp:ListItem>
                                                        </asp:DropDownList>

                                                    </div>

                                                </div>


                                            </div>
                                            <div class="row">

                                                <div class="col-md-6 col-sm-12">

                                                    <div style="padding: 5px; margin-top: 0px;">
                                                        <div class="form-group row m-b-5">
                                                            <div class="col-md-3 col-sm-3">
                                                                <label class="col-form-label" for="fullname">
                                                                    Client SC Type
                                                                </label>
                                                                <asp:DropDownList CssClass="form-control" ID="ddlProfitType" runat="server" Width="100%">
                                                                    <asp:ListItem Value="0" Text="Value"></asp:ListItem>
                                                                    <asp:ListItem Value="1" Text="% "></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                            <div class="col-md-2 col-sm-3">
                                                                <label class="col-form-label" for="fullname">
                                                                    Clnt SC
                                                                </label>
                                                                <asp:TextBox CssClass="form-control" ID="txtProfitAmt" runat="server" placeholder="" Width="100%" AutoPostBack="True" OnTextChanged="txtProfitAmt_TextChanged"></asp:TextBox>
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
                                                                <asp:TextBox CssClass="form-control" ID="txtProfitAmt2" runat="server" placeholder="" Width="100%" AutoPostBack="True" OnTextChanged="txtProfitAmt2_TextChanged"></asp:TextBox>
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
                                                                <asp:DropDownList CssClass="form-control" ID="ddlClntTds" runat="server" Width="100%">
                                                                    <asp:ListItem Value="0" Text="Value"></asp:ListItem>
                                                                    <asp:ListItem Value="1" Text="%"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                            <div class="col-md-2 col-sm-3">
                                                                <label class="col-form-label" for="fullname">
                                                                    Clnt TDS
                                                                </label>
                                                                <asp:TextBox CssClass="form-control" ID="txtClntTds" runat="server" placeholder="" Width="100%" AutoPostBack="True" OnTextChanged="txtClntTds_TextChanged"></asp:TextBox>
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
                                                                <asp:TextBox CssClass="form-control" ID="txtDiscount" runat="server" Width="95%" Text="0" Placeholder="Discount   :" OnTextChanged="txtDiscount_TextChanged" AutoPostBack="true" placeolder="Discount"></asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtDiscount"
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
                                                                <asp:TextBox CssClass="form-control" ID="txtOtherchrg" runat="server" Width="95%" Text="0" Placeholder="Discount   :" OnTextChanged="txtOtherchrg_TextChanged" AutoPostBack="true" placeolder="Discount"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server" ControlToValidate="txtOtherchrg"
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
                                                                <asp:TextBox CssClass="form-control" ID="txtRemarks" runat="server" Width="100%"></asp:TextBox>
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
                                                                    <asp:TextBox CssClass="form-control" ID="txtClntCgst" runat="server" Width="95%" Text="0" Enabled="false"></asp:TextBox>

                                                                </div>

                                                                <div class="col-md-4 col-sm-4">
                                                                    <label class="col-form-label" for="fullname">
                                                                        SGST
                                                                    </label>
                                                                    <asp:TextBox CssClass="form-control" ID="txtClntSgst" runat="server" Width="95%" Text="0" Enabled="false"></asp:TextBox>

                                                                </div>
                                                                <div class="col-md-3 col-sm-3">
                                                                    <label class="col-form-label" for="fullname">
                                                                        IGST
                                                                    </label>
                                                                    <asp:TextBox CssClass="form-control" ID="txtClntIgst" runat="server" Width="100%" Enabled="false"></asp:TextBox>

                                                                </div>
                                                            </div>
                                                        </fieldset>

                                                    </div>

                                                </div>
                                                <div class="col-md-6 col-sm-12">
                                                    <div style="padding: 5px; margin-top: 0px;">



                                                        <div class="form-group row m-b-10">
                                                            <div class="col-md-2 col-sm-3">
                                                                <label class="col-form-label" for="fullname">
                                                                    Basic Fare</label>
                                                                <asp:TextBox CssClass="form-control" ID="txtBasicFare" Text="0" Width="100%" runat="server" ValidationGroup="B" AutoPostBack="true" OnTextChanged="txtBasicFare_TextChanged"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="REV14" runat="server" ControlToValidate="txtBasicFare"
                                                                    SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                                    ValidationGroup="B"></asp:RegularExpressionValidator>
                                                                <AjaxToolKit:FilteredTextBoxExtender ID="FTBE14" runat="server"
                                                                    Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtBasicFare"
                                                                    ValidChars=".-">
                                                                </AjaxToolKit:FilteredTextBoxExtender>
                                                            </div>
                                                            <div class="col-md-2 col-sm-3">
                                                                <label class="col-form-label" for="fullname">
                                                                    Ext. KM :</label>
                                                                <asp:TextBox CssClass="form-control" ID="txtExtraKM" Text="0" Width="100%" runat="server" ValidationGroup="B" AutoPostBack="true" OnTextChanged="txtExtraKM_TextChanged"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtExtraKM"
                                                                    SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                                    ValidationGroup="B"></asp:RegularExpressionValidator>
                                                                <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                                                    Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtExtraKM"
                                                                    ValidChars=".-">
                                                                </AjaxToolKit:FilteredTextBoxExtender>
                                                            </div>



                                                            <div class="col-md-2 col-sm-3">
                                                                <label class="col-form-label" for="fullname">
                                                                    Ext. HRS :</label>
                                                                <asp:TextBox CssClass="form-control" ID="txtExtraHrs" runat="server" Width="100%" AutoPostBack="true" Text="0" OnTextChanged="txtExtraHrs_TextChanged"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="REV16" runat="server" ControlToValidate="txtExtraHrs"
                                                                    SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                                    ValidationGroup="A"></asp:RegularExpressionValidator>
                                                                <AjaxToolKit:FilteredTextBoxExtender ID="FTBE16" runat="server"
                                                                    Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtExtraHrs"
                                                                    ValidChars=".-">
                                                                </AjaxToolKit:FilteredTextBoxExtender>
                                                            </div>
                                                            <div class="col-md-2 col-sm-3">
                                                                <label class="col-form-label" for="fullname">
                                                                    Drivr Crgs
                                                                </label>
                                                                <asp:TextBox CssClass="form-control" ID="txtDriverCharges" runat="server" Text="0" Width="100%" AutoPostBack="true" OnTextChanged="txtDriverCharges_TextChanged"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="REV17" runat="server" ControlToValidate="txtDriverCharges"
                                                                    SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                                    ValidationGroup="A"></asp:RegularExpressionValidator>
                                                                <AjaxToolKit:FilteredTextBoxExtender ID="FTBE17" runat="server"
                                                                    Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtDriverCharges"
                                                                    ValidChars=".-">
                                                                </AjaxToolKit:FilteredTextBoxExtender>
                                                            </div>
                                                            <div class="col-md-2 col-sm-3">
                                                                <label class="col-form-label" for="fullname">
                                                                    Prk/Toll :</label>
                                                                <asp:TextBox CssClass="form-control" ID="txtTollPark" runat="server" Width="100%" AutoPostBack="true" Text="0" OnTextChanged="txtTollPark_TextChanged"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtTollPark"
                                                                    SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                                    ValidationGroup="A"></asp:RegularExpressionValidator>
                                                                <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server"
                                                                    Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtTollPark"
                                                                    ValidChars=".-">
                                                                </AjaxToolKit:FilteredTextBoxExtender>
                                                            </div>
                                                            <div class="col-md-2 col-sm-3">
                                                                <label class="col-form-label" for="fullname">
                                                                    Fuel/Othr :</label>
                                                                <asp:TextBox CssClass="form-control" ID="txtFuel" runat="server" Text="0" Width="100%" AutoPostBack="true" OnTextChanged="txtFuel_TextChanged"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="txtFuel"
                                                                    SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                                    ValidationGroup="A"></asp:RegularExpressionValidator>
                                                                <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server"
                                                                    Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtFuel"
                                                                    ValidChars=".-">
                                                                </AjaxToolKit:FilteredTextBoxExtender>
                                                            </div>

                                                        </div>
                                                        <div class="form-group row m-b-5">
                                                            <div class="col-md-3 col-sm-4">
                                                                <label class="col-form-label" for="fullname">
                                                                    SC Type
                                                                </label>
                                                                <asp:DropDownList CssClass="form-control" ID="ddlSupScType" runat="server" Width="100%">
                                                                    <asp:ListItem Value="0" Text="Value"></asp:ListItem>
                                                                    <asp:ListItem Value="1" Text="% "></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                            <div class="col-md-2 col-sm-2">
                                                                <label class="col-form-label" for="fullname">
                                                                    Sup. SC :</label>
                                                                <asp:TextBox CssClass="form-control" ID="txtSupSc" runat="server" Text="0" Width="100%" Enabled="true" AutoPostBack="True" OnTextChanged="txtSupSc_TextChanged"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="txtSupSc"
                                                                    SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                                    ValidationGroup="B"></asp:RegularExpressionValidator>
                                                                <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server"
                                                                    Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtSupSc"
                                                                    ValidChars=".-">
                                                                </AjaxToolKit:FilteredTextBoxExtender>
                                                            </div>
                                                            <div class="col-md-3 col-sm-4">
                                                                <label class="col-form-label" for="fullname">
                                                                    TDS Type
                                                                </label>
                                                                <asp:DropDownList CssClass="form-control" ID="ddlSupTds" runat="server" Width="100%">
                                                                    <asp:ListItem Value="0" Text="Value"></asp:ListItem>
                                                                    <asp:ListItem Value="1" Text="% "></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                            <div class="col-md-2 col-sm-2">
                                                                <label class="col-form-label" for="fullname">
                                                                    Sup. TDS :</label>
                                                                <asp:TextBox CssClass="form-control" ID="txtSupTds" runat="server" Text="0" Width="100%" Enabled="true" AutoPostBack="True" OnTextChanged="txtSupTds_TextChanged"></asp:TextBox>
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
                                                                    Discount</label>
                                                                <asp:TextBox CssClass="form-control" ID="txtSupDiscount" runat="server" Width="100%" AutoPostBack="true" Text="0" OnTextChanged="txtSupDiscount_TextChanged"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server" ControlToValidate="txtSupDiscount"
                                                                    SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                                    ValidationGroup="A"></asp:RegularExpressionValidator>
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
                                                                    <asp:CheckBox ID="chkSupTax" runat="server" Width="100%" Checked="true" AutoPostBack="True" OnCheckedChanged="chkSupTax_CheckedChanged"></asp:CheckBox>

                                                                </div>

                                                                <div class="col-md-4 col-sm-4">
                                                                    <label class="col-form-label" for="fullname">
                                                                        CGST
                                                                    </label>
                                                                    <asp:TextBox CssClass="form-control" ID="txtsupcgst" runat="server" Width="95%" Text="0" Enabled="false"></asp:TextBox>

                                                                </div>

                                                                <div class="col-md-4 col-sm-4">
                                                                    <label class="col-form-label" for="fullname">
                                                                        SGST
                                                                    </label>
                                                                    <asp:TextBox CssClass="form-control" ID="txtsupsgst" runat="server" Width="95%" Text="0" Enabled="false"></asp:TextBox>

                                                                </div>
                                                                <div class="col-md-3 col-sm-3">
                                                                    <label class="col-form-label" for="fullname">
                                                                        IGST
                                                                    </label>
                                                                    <asp:TextBox CssClass="form-control" ID="txtsupigst" runat="server" Width="100%" Enabled="false"></asp:TextBox>

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
                                                                    <asp:TextBox ID="txtdtRfnDate" runat="server" CssClass="datepicker form-control" Width="100%" Enabled="true"></asp:TextBox>
                                                                    <%-- <AjaxToolKit:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd/MM/yyyy"
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
                                                                    <asp:TextBox CssClass="form-control" ID="txtRefundAmt" runat="server" Width="95%" Enabled="true" AutoPostBack="True" OnTextChanged="txtRefundAmt_TextChanged"></asp:TextBox>
                                                                </div>
                                                                <div class="col-md-4 col-sm-4">
                                                                    <label class="col-form-label" for="fullname">
                                                                        Rfn. SC
                                                                    </label>
                                                                    <asp:TextBox CssClass="form-control" ID="txtrfnSC" runat="server" Width="95%" Text="0" Enabled="true" AutoPostBack="True" OnTextChanged="txtrfnSC_TextChanged"></asp:TextBox>

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
                                                                            <asp:TextBox CssClass="form-control" ID="txtRfnRemarks" runat="server" Width="100%" Enabled="true"></asp:TextBox>

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
                                                                                <asp:TextBox CssClass="form-control" ID="txtRfnCGst" runat="server" Width="95%" Text="0" Enabled="false"></asp:TextBox>

                                                                            </div>

                                                                            <div class="col-md-4 col-sm-4">
                                                                                <label class="col-form-label" for="fullname">
                                                                                    SGST
                                                                                </label>
                                                                                <asp:TextBox CssClass="form-control" ID="txtRfnSGst" runat="server" Width="95%" Text="0" Enabled="false"></asp:TextBox>

                                                                            </div>
                                                                            <div class="col-md-3 col-sm-3">
                                                                                <label class="col-form-label" for="fullname">
                                                                                    IGST
                                                                                </label>
                                                                                <asp:TextBox CssClass="form-control" ID="txtRfnIGst" runat="server" Text="0" Width="95%" Enabled="false"></asp:TextBox>

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
                                                    <asp:TextBox ID="txtClientCost" runat="server" Width="40%" ForeColor="Black" CssClass="btn bg-blue-darker" Enabled="false" Text="0" required></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtClientCost"
                                                        SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                        ValidationGroup="A"></asp:RegularExpressionValidator>
                                                    <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                                        Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtClientCost"
                                                        ValidChars=".-">
                                                    </AjaxToolKit:FilteredTextBoxExtender>

                                                </div>
                                                <div class="col-md-6 col-sm-6 text-center">

                                                    <label class="col-form-label text-center" for="fullname">
                                                        Supplier Cost
                                                    </label>
                                                    <asp:Label ID="lblBuyCost" runat="server" Visible="false"></asp:Label>
                                                    <asp:TextBox ID="txtSupplierCost" runat="server" Width="40%" Text="0" ForeColor="Black" CssClass="btn bg-blue-darker" required Enabled="false"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server" ControlToValidate="txtSupplierCost"
                                                        SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                        ValidationGroup="A"></asp:RegularExpressionValidator>
                                                    <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server"
                                                        Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtSupplierCost"
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
                                                    <asp:Button ID="btnPrint" runat="server" CssClass="btn btn-primary" Text="Print" OnClick="btnPrint_Click" ToolTip="Print" Visible="false" />
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
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </asp:Panel>
                                <asp:Panel class="tbl table-responsive" ID="tblGridDet" runat="server" Style="margin-top: 20px;">

                                    <asp:Label ID="lblpgsDet" runat="server" Text="Page Size :"></asp:Label>
                                    <asp:DropDownList ID="ddlPageSizeDet" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPageSizeDet_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:GridView ID="GridView2" CssClass="table table-striped table-bordered" runat="server" AutoGenerateColumns="False"
                                        DataKeyNames="nCarBookingDetID" Width="100%" AllowPaging="false" AllowSorting="True" EmptyDataText="No Records to display"
                                        OnPageIndexChanging="GridView2_PageIndexChanging">
                                        <Columns>
                                            <asp:TemplateField HeaderText="nCarBookingDetID" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDetID" runat="server" Text='<%# Eval("nCarBookingDetID") %>'></asp:Label>
                                                    <asp:Label ID="lblcarbookingID" runat="server" Text='<%# Eval("nCarBookingID") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:BoundField DataField="sReferenceNo" HeaderText="Reference No" />
                                            <asp:TemplateField HeaderText="Trip Date">
                                                <ItemTemplate>
                                                    <%#validation.TextToDate(Eval("dtTripDate").ToString())%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="sPickupPlace" HeaderText="Pickup Place" />
                                            <asp:BoundField DataField="sPaxtName" HeaderText="Passenger Name" />
                                            <asp:BoundField DataField="nClientCost" HeaderText="Buying Cost" />
                                            <asp:BoundField DataField="nSupplierCost" HeaderText="Supplier Cost" />

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
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:Panel class="tbl table-responsive" ID="tblGrd" runat="server">
                        <div style="padding: 10px; margin-top: 20px;">
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
                                    <%-- <AjaxToolKit:CalendarExtender ID="CalendarExtender5" runat="server" Format="dd/MM/yyyy"
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
                        <asp:DropDownList CssClass="form-control" ID="ddlPageSize" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:GridView ID="GridView1" CssClass="table table-striped table-bordered" runat="server"
                            AutoGenerateColumns="False" EmptyDataText="No Records to display"
                            DataKeyNames="nCarBookingID" Width="100%" AllowPaging="true" AllowSorting="True" PageSize="25"
                            OnPageIndexChanging="GridView1_PageIndexChanging">
                            <Columns>
                                <asp:TemplateField HeaderText="nCarBookingID" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblID" runat="server" Text='<%# Eval("nCarBookingID") %>'></asp:Label>
                                        <asp:Label ID="lblAgentID" runat="server" Text='<%# Eval("nClientID") %>'></asp:Label>
                                        <asp:Label ID="lblBalance" runat="server" Text='<%# Eval("nBalance") %>'></asp:Label>
                                        <asp:Label ID="lblInvoiceNo" runat="server" Text='<%# Eval("sCarBookingNo") %>'></asp:Label>
                                        <asp:Label ID="lblbookType" runat="server" Text='<%# Eval("sBookType") %>'></asp:Label>
                                        <asp:Label ID="lblInvoiceDate" runat="server" Text='<%# Eval("dtCarBooking") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="sBookType" HeaderText="Book Type" />
                                <asp:BoundField DataField="sCarBookingNo" HeaderText="Invoice No." />
                                <asp:TemplateField HeaderText="Invoice Date">
                                    <ItemTemplate>
                                        <%#validation.TextToDate(Eval("dtCarBooking").ToString())%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="sAgent" HeaderText="Client Name" />


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
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <ContentTemplate>
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h4 class="modal-title">Car Booking Payment</h4>
                                    </div>
                                    <div class="row m-5">

                                        <div class="col-md-3 col-sm-3">
                                            <h5>Payment For</h5>
                                            <asp:TextBox CssClass="form-control" ID="txtPayInv" runat="server" Enabled="false" Width="100%"></asp:TextBox>
                                            <asp:Label ID="lblInvoiceDate" runat="server" Visible="false" Width="100%"></asp:Label>
                                        </div>
                                        <div class="col-md-3 col-sm-3">
                                            <h5>Balance Amount</h5>
                                            <asp:TextBox CssClass="form-control" ID="txtPayBalance" runat="server" Width="100%" Enabled="false"></asp:TextBox>
                                            <asp:Label ID="lblAgent" runat="server" Visible="false"></asp:Label>
                                        </div>
                                        <div class="col-md-3 col-sm-3">
                                            <h5>Voucher No</h5>
                                            <asp:TextBox CssClass="form-control" ID="txtPayVoucherNo" runat="server" Width="100%" Enabled="false"></asp:TextBox>
                                        </div>
                                        <div class="col-md-3 col-sm-3" style="z-index: 99">
                                            <h5>Payment Date</h5>
                                            <asp:TextBox ID="txtdtpayment" runat="server" CssClass="datepicker form-control" Width="100%" TextMode="SingleLine" placeholder="DD/MM/YYYY" OnTextChanged="txtdtpayment_TextChanged" AutoPostBack="true"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtdtpayment" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                                            <%-- <AjaxToolKit:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy"
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
                                            <asp:DropDownList CssClass="form-control" ID="ddlPayVoucherType" runat="server" Width="100%" OnSelectedIndexChanged="ddlPayVoucherType_SelectedIndexChanged" AutoPostBack="true">
                                                <asp:ListItem Value="0" Text="Select Payment Type"></asp:ListItem>
                                                <asp:ListItem Value="1" Text="Cash Payment"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="Bank Payment"></asp:ListItem>

                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddlPayVoucherType" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="P"></asp:RequiredFieldValidator>
                                        </div>

                                        <div class="col-md-2 col-sm-3">
                                            <h5>Payment Account</h5>
                                            <asp:DropDownList CssClass="form-control" ID="ddlPaymentAccount" runat="server" Width="100%">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlPaymentAccount" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="P"></asp:RequiredFieldValidator>
                                        </div>

                                        <div class="col-md-3 col-sm-3">
                                            <h5>Amount</h5>
                                            <asp:TextBox CssClass="form-control" ID="txtPayAmount" runat="server" Width="100%"></asp:TextBox>
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
                                            <asp:TextBox CssClass="form-control" ID="txtPayRemarks" runat="server" Width="100%" TextMode="SingleLine"></asp:TextBox>
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
                                                            <asp:Label ID="lblCarID" runat="server" Text='<%# Eval("nInvoiceID") %>'></asp:Label>
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

                                                    <asp:BoundField DataField="sAgent" HeaderText="Agent Name" />
                                                    <asp:BoundField DataField="sCashAcc" HeaderText="Payment Account" />
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
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </asp:Panel>
                </div>
                <!-- end panel-body -->
                <!-- end panel -->
            </div>
            <!-- end col-6 -->
        </div>
        <!-- end row -->
    </div>




</asp:Content>
