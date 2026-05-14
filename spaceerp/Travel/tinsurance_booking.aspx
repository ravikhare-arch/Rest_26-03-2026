<%@ Page Title="Insurance Booking" Language="C#" MasterPageFile="~/Pagecontent.master" AutoEventWireup="true" CodeFile="tinsurance_booking.aspx.cs" Inherits="Transcation_insurance_booking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link type="text/css" rel="stylesheet" href="../assets/css/default/mystyle.css" />
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
                        <a href="../Accounting/tgeneral_ledger.aspx" target="_blank" class="btn btn-info btn-xs">Statements</a>
                        <%-- <a href="Statements/tinsurance_statement.aspx?AccType=0&AccTitle=&Loc=0&DtStFrom=&DtStTo=" target="_blank" class="btn btn-info btn-xs">Statement</a>--%>
                    </div>
                    <div class="panel-heading-btn">
                        <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                        <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                    </div>

                    <h4 class="panel-title text-center">Insurance Booking </h4>




                </div>
                <!-- end panel-heading -->
                <!-- begin panel-body -->
                <div class="panel-body">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:Panel class="tbl" ID="tblmain" runat="server">
                                <div style=" padding: 5px; margin-top: 5px;padding-top: 0px;">

                                    <div class="form-group row">

                                        <div class="col-md-2 col-sm-2">
                                            <label class="col-form-label" for="fullname">
                                                Invoice No. :</label>

                                            <asp:TextBox ID="txtInsuranceBookingNo" runat="server" CssClass="form-control" AutoPostBack="true" Enabled="true" OnTextChanged="txtBusBookingNo_TextChanged"> </asp:TextBox>

                                        </div>
                                        <div class="col-md-2 col-sm-2" style="z-index: 99">
                                            <label class="col-form-label" for="fullname">
                                                Invoice Date :</label>
                                            <asp:TextBox ID="txtdtBookingDate" runat="server" CssClass="form-control datepicker" Width="90%" AutoPostBack="true" OnTextChanged="txtdtBookingDate_TextChanged"></asp:TextBox>
                                            <AjaxToolKit:CalendarExtender ID="CalendarExtender4" runat="server" Format="dd/MM/yyyy"
                                                PopupButtonID="txtdtBookingDate" TargetControlID="txtdtBookingDate" PopupPosition="TopLeft" />

                                            <AjaxToolKit:MaskedEditExtender ID="MEE4" runat="server" TargetControlID="txtdtBookingDate"
                                                Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                            <asp:RegularExpressionValidator ID="REV4" ControlToValidate="txtdtBookingDate" ValidationGroup="A"
                                                Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                                ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                            </asp:RegularExpressionValidator>
                                        </div>
                                        <div class="col-md-3 col-sm-3">
                                            <label class="col-form-label" for="fullname">
                                                Supplier Name :</label>
                                            <asp:DropDownList CssClass="form-control js-example-placeholder-single" ID="ddlSupplier" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSupplier_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlSupplier" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
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
                                            <asp:DropDownList ID="ddlLocationID" runat="server" CssClass="form-control js-example-placeholder-single">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RFV4" runat="server" ControlToValidate="ddlLocationID" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                                        </div>

                                    </div>

                                </div>

                                <asp:Panel class="tbl" ID="tblDet" runat="server">

                                    <div style=" padding: 5px; margin-top: 0px;padding-top: 0px;">

                                        <div class="row">
                                            <div class="col-md-6 col-sm-12">
                                                <div class="row">
                                                    <div class="col-md-3 col-sm-3">
                                                        <label class="col-form-label" for="fullname">
                                                            Booking Type :</label>
                                                        <asp:DropDownList Width="90%" ID="ddlbookType" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlbookType_SelectedIndexChanged">
                                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Booking" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Refund" Value="2"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlbookType" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-md-2 col-sm-3">
                                                        <label class="col-form-label" for="fullname">
                                                            Policy No. :</label>
                                                        <asp:TextBox ID="txtPolicyNo" CssClass="form-control" runat="server" Width="90%" ValidationGroup="B">
                                                        </asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPolicyNo" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-md-4 col-sm-3">
                                                        <label class="col-form-label" for="fullname">
                                                            Name :</label>
                                                        <asp:TextBox ID="txtPaxName" CssClass="form-control" runat="server" ValidationGroup="B" Width="90%">
                                                        </asp:TextBox>
                                                    </div>
                                                    <div class="col-md-3 col-sm-3">
                                                        <label class="col-form-label" for="fullname">
                                                            Country :</label>
                                                        <asp:DropDownList Width="90%" ID="ddlCountry" runat="server" CssClass="form-control js-example-placeholder-single">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlCountry" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6 col-sm-12">
                                                <div class="row">
                                                    <div class="col-md-3 col-sm-3">
                                                        <label class="col-form-label" for="fullname">Gender </label>
                                                        <asp:DropDownList ID="ddlGender" CssClass="form-control" runat="server" Width="90%">
                                                            <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                                                            <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                                                            <asp:ListItem Text="Other" Value="Other"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlBusTypeID" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>--%>
                                                    </div>
                                                    <div class="col-md-3 col-sm-3">
                                                        <label class="col-form-label" for="fullname">
                                                            Age :</label>
                                                        <asp:TextBox ID="txtAge" runat="server" CssClass="form-control" Width="90%"></asp:TextBox>
                                                    </div>
                                                    <div class="col-md-3 col-sm-3">
                                                        <label class="col-form-label" for="fullname">
                                                            Plan No :</label>
                                                        <asp:TextBox ID="txtPlanNo" CssClass="form-control" runat="server" Width="90%"></asp:TextBox>
                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPlanNo" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="B"></asp:RequiredFieldValidator>--%>
                                                    </div>
                                                    <div class="col-md-3 col-sm-3">
                                                        <label class="col-form-label" for="fullname">
                                                            Proposer :</label>
                                                        <asp:TextBox ID="txtProposal" CssClass="form-control" runat="server" Width="90%"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>


                                        </div>
                                        <div class="row">
                                            <div class="col-md-6 col-sm-12">
                                                <div class="row">
                                                    <div class="col-md-2 col-sm-3">
                                                        <label class="col-form-label" for="fullname">
                                                            Status :</label>
                                                        <asp:DropDownList ID="ddlStatus" CssClass="form-control" runat="server" Width="90%">
                                                            <asp:ListItem Text="Select Staus" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Booked" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Cancelled" Value="2"></asp:ListItem>
                                                        </asp:DropDownList>

                                                    </div>
                                                    <div class="col-md-2 col-sm-3">
                                                        <label class="col-form-label" for="fullname">
                                                            Inv Type:</label>
                                                        <asp:DropDownList ID="ddlInvType" CssClass="form-control" runat="server" Width="90%">
                                                            <asp:ListItem Text="Select INV Type" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Air Insurance" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Train Insurance" Value="2"></asp:ListItem>
                                                        </asp:DropDownList>

                                                    </div>
                                                    <div class="col-md-3 col-sm-3">
                                                        <label class="col-form-label" for="fullname">
                                                            Assignee :</label>
                                                        <asp:TextBox ID="txtAssignee" CssClass="form-control" runat="server" ValidationGroup="B" Width="90%">
                                                        </asp:TextBox>

                                                    </div>
                                                    <div class="col-md-3 col-sm-3">
                                                        <label class="col-form-label" for="fullname">
                                                            Passport No.:</label>
                                                        <asp:TextBox ID="txtPassport" CssClass="form-control" runat="server" ValidationGroup="B" Width="90%">
                                                        </asp:TextBox>

                                                    </div>
                                                    <div class="col-md-2 col-sm-3">
                                                        <label class="col-form-label" for="fullname">
                                                            C. Area :</label>
                                                        <asp:TextBox ID="txtCArea" CssClass="form-control" runat="server" Width="80%"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6 col-sm-12">
                                                <div class="row">
                                                    <div class="col-md-3 col-sm-3">
                                                        <label class="col-form-label" for="fullname">
                                                            Issue Date :</label>
                                                        <asp:TextBox ID="txtdtInvIssue" runat="server" ValidationGroup="B" CssClass="datepicker form-control" Width="90%" placeholder="dd/MM/yyyy">
                                                        </asp:TextBox>
                                                        <%--<AjaxToolKit:CalendarExtender ID="CalendarExtender9" runat="server" Format="dd/MM/yyyy"
                                                            PopupButtonID="txtdtInvIssue" TargetControlID="txtdtInvIssue" PopupPosition="TopLeft" />--%>
                                                        <AjaxToolKit:MaskedEditExtender ID="MEE9" runat="server"
                                                            TargetControlID="txtdtInvIssue" Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                                        <asp:RegularExpressionValidator ID="REV9" ControlToValidate="txtdtInvIssue"
                                                            ValidationGroup="A" Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                                            ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                                        </asp:RegularExpressionValidator>
                                                    </div>
                                                    <div class="col-md-3 col-sm-3">
                                                        <label class="col-form-label" for="fullname">
                                                            Expiry Date :</label>
                                                        <asp:TextBox ID="txtdtInvExpiry" runat="server" ValidationGroup="B" CssClass="datepicker form-control" Width="90%" placeholder="dd/MM/yyyy">
                                                        </asp:TextBox>
                                                       <%-- <AjaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy"
                                                            PopupButtonID="txtdtInvExpiry" TargetControlID="txtdtInvExpiry" PopupPosition="TopLeft" />--%>
                                                        <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender1" runat="server"
                                                            TargetControlID="txtdtInvExpiry" Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtdtInvExpiry"
                                                            ValidationGroup="A" Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                                            ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                                        </asp:RegularExpressionValidator>
                                                    </div>
                                                    <div class="col-md-3 col-sm-3">
                                                        <label class="col-form-label" for="fullname">
                                                            No. of Days :</label>
                                                        <asp:TextBox ID="txtDays" CssClass="form-control" runat="server" ValidationGroup="B" Width="90%">
                                                        </asp:TextBox>

                                                    </div>
                                                    <div class="col-md-3 col-sm-3">
                                                        <label class="col-form-label" for="fullname">
                                                            Address :</label>
                                                        <asp:TextBox ID="txtAddress" CssClass="form-control" runat="server" ValidationGroup="B" Width="90%">
                                                        </asp:TextBox>

                                                    </div>

                                                </div>
                                            </div>
                                        </div>


                                    </div>
                                    <div class="row">

                                        <div class="col-md-6 col-sm-12">
                                            <div style=" padding: 5px; margin-top: 10px;">
                                                <div class="form-group row m-b-5">
                                                    <div class="col-md-2 col-sm-3">
                                                        <label class="col-form-label" for="fullname">
                                                            Cost
                                                        </label>
                                                        <asp:TextBox ID="txtClntCost" CssClass="form-control" runat="server" placeholder="" Width="90%" AutoPostBack="True" OnTextChanged="txtClntCost_TextChanged"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server" ControlToValidate="txtClntCost"
                                                            SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                            ValidationGroup="A"></asp:RegularExpressionValidator>
                                                        <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" runat="server"
                                                            Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtClntCost"
                                                            ValidChars=".-">
                                                        </AjaxToolKit:FilteredTextBoxExtender>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtClntCost" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-md-2 col-sm-3">
                                                        <label class="col-form-label" for="fullname">
                                                            SC Type
                                                        </label>
                                                        <asp:DropDownList ID="ddlProfitType" CssClass="form-control" runat="server" Width="90%">
                                                            <asp:ListItem Value="0" Text="Value"></asp:ListItem>
                                                            <asp:ListItem Value="1" Text="% "></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="col-md-2 col-sm-3">
                                                        <label class="col-form-label" for="fullname">
                                                            SC 1
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
                                                            SC 2
                                                        </label>
                                                        <asp:TextBox ID="txtProfitAmt2" CssClass="form-control" runat="server" placeholder="" Width="90%" AutoPostBack="True" OnTextChanged="txtProfitAmt2_TextChanged"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtProfitAmt2"
                                                            SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                            ValidationGroup="A"></asp:RegularExpressionValidator>
                                                        <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server"
                                                            Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtProfitAmt2"
                                                            ValidChars=".-">
                                                        </AjaxToolKit:FilteredTextBoxExtender>
                                                    </div>
                                                    <div class="col-md-2 col-sm-3">
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
                                                        <asp:TextBox ID="txtDiscount" runat="server" CssClass="form-control" Width="95%" Text="0" Placeholder="Discount   :" OnTextChanged="txtDiscount_TextChanged" AutoPostBack="true" placeolder="Discount"></asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtDiscount"
                                                            SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                            ValidationGroup="A"></asp:RegularExpressionValidator>
                                                        <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server"
                                                            Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtDiscount"
                                                            ValidChars=".-">
                                                        </AjaxToolKit:FilteredTextBoxExtender>

                                                    </div>
                                                    <div class="col-md-4 col-sm-3">
                                                        <label class="col-form-label" for="fullname">
                                                            Other Chrgs
                                                        </label>
                                                        <asp:TextBox ID="txtOtherchrg" CssClass="form-control" runat="server" Width="95%" Text="0" Placeholder="Discount   :" OnTextChanged="txtOtherchrg_TextChanged" AutoPostBack="true" placeolder="Ohter Charges"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="txtOtherchrg"
                                                            SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                            ValidationGroup="A"></asp:RegularExpressionValidator>
                                                        <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server"
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
                                                            <asp:TextBox ID="txtClntCgst" CssClass="form-control" runat="server" Width="95%" Text="0" Enabled="false"></asp:TextBox>

                                                        </div>

                                                        <div class="col-md-4 col-sm-4">
                                                            <label class="col-form-label" for="fullname">
                                                                SGST
                                                            </label>
                                                            <asp:TextBox ID="txtClntSgst" CssClass="form-control" runat="server" Width="95%" Text="0" Enabled="false"></asp:TextBox>

                                                        </div>
                                                        <div class="col-md-3 col-sm-3">
                                                            <label class="col-form-label" for="fullname">
                                                                IGST
                                                            </label>
                                                            <asp:TextBox ID="txtClntIgst" runat="server" CssClass="form-control" Width="90%" Enabled="false"></asp:TextBox>

                                                        </div>
                                                    </div>
                                                </fieldset>

                                            </div>

                                        </div>
                                        <div class="col-md-6 col-sm-12">
                                            <div style=" padding: 5px; margin-top: 10px;">



                                                <div class="form-group row m-b-10">
                                                    <div class="col-md-2 col-sm-3">
                                                        <label class="col-form-label" for="fullname">
                                                            Cost :</label>
                                                        <asp:TextBox ID="txtBasicFare" CssClass="form-control" Text="0" Width="90%" runat="server" ValidationGroup="B" AutoPostBack="true" OnTextChanged="txtBasicFare_TextChanged"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="REV11" runat="server" ControlToValidate="txtBasicFare"
                                                            SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                            ValidationGroup="A"></asp:RegularExpressionValidator>
                                                        <AjaxToolKit:FilteredTextBoxExtender ID="FTBE11" runat="server"
                                                            Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtBasicFare"
                                                            ValidChars=".-">
                                                        </AjaxToolKit:FilteredTextBoxExtender>
                                                        <asp:RequiredFieldValidator ID="RFV11" runat="server" ControlToValidate="txtBasicFare" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-md-3 col-sm-4">
                                                        <label class="col-form-label" for="fullname">
                                                            SC Type
                                                        </label>
                                                        <asp:DropDownList ID="ddlSupScType" CssClass="form-control" runat="server" Width="90%">
                                                            <asp:ListItem Value="0" Text="Value"></asp:ListItem>
                                                            <asp:ListItem Value="1" Text="% "></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="col-md-3 col-sm-2">
                                                        <label class="col-form-label" for="fullname">
                                                            Sup. SC :</label>
                                                        <asp:TextBox ID="txtSupSc" CssClass="form-control" runat="server" Text="0" Width="90%" Enabled="true" AutoPostBack="True" OnTextChanged="txtSupSc_TextChanged"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="txtSupSc"
                                                            SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                            ValidationGroup="B"></asp:RegularExpressionValidator>
                                                        <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server"
                                                            Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtSupSc"
                                                            ValidChars=".-">
                                                        </AjaxToolKit:FilteredTextBoxExtender>
                                                    </div>
                                                    <div class="col-md-2 col-sm-3">
                                                        <label class="col-form-label" for="fullname">
                                                            Otr Tax :</label>
                                                        <asp:TextBox ID="txtOtherTax" CssClass="form-control" Text="0" Width="90%" runat="server" ValidationGroup="B" AutoPostBack="true" OnTextChanged="txtOtherTax_TextChanged"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtOtherTax"
                                                            SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                            ValidationGroup="B"></asp:RegularExpressionValidator>
                                                        <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                                            Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtOtherTax"
                                                            ValidChars=".-">
                                                        </AjaxToolKit:FilteredTextBoxExtender>
                                                    </div>





                                                </div>
                                                <div class="form-group row m-b-5">

                                                    <div class="col-md-3 col-sm-4">
                                                        <label class="col-form-label" for="fullname">
                                                            TDS Type
                                                        </label>
                                                        <asp:DropDownList ID="ddlSupTds" CssClass="form-control" runat="server" Width="90%">
                                                            <asp:ListItem Value="0" Text="Value"></asp:ListItem>
                                                            <asp:ListItem Value="1" Text="% "></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="col-md-3 col-sm-2">
                                                        <label class="col-form-label" for="fullname">
                                                            Sup. TDS :</label>
                                                        <asp:TextBox ID="txtSupTds" CssClass="form-control" runat="server" Text="0" Width="90%" Enabled="true" AutoPostBack="True" OnTextChanged="txtSupTds_TextChanged"></asp:TextBox>
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
                                                            Comm Rcvd. :</label>
                                                        <asp:TextBox ID="txtSupComm" CssClass="form-control" runat="server" Width="90%" AutoPostBack="true" Text="0" OnTextChanged="txtSupComm_TextChanged"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="REV16" runat="server" ControlToValidate="txtSupComm"
                                                            SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                            ValidationGroup="A"></asp:RegularExpressionValidator>
                                                        <AjaxToolKit:FilteredTextBoxExtender ID="FTBE16" runat="server"
                                                            Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtSupComm"
                                                            ValidChars=".-">
                                                        </AjaxToolKit:FilteredTextBoxExtender>
                                                    </div>

                                                    <div class="col-md-2 col-sm-3">
                                                        <label class="col-form-label" for="fullname">
                                                            Discount :</label>
                                                        <asp:TextBox ID="txtSupDiscount" CssClass="form-control" runat="server" Width="90%" AutoPostBack="true" Text="0" OnTextChanged="txtSupDiscount_TextChanged"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server" ControlToValidate="txtSupDiscount"
                                                            SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                            ValidationGroup="A"></asp:RegularExpressionValidator>
                                                        <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender12" runat="server"
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
                                                            <asp:TextBox ID="txtsupcgst" CssClass="form-control" runat="server" Width="95%" Text="0" Enabled="false"></asp:TextBox>

                                                        </div>

                                                        <div class="col-md-4 col-sm-4">
                                                            <label class="col-form-label" for="fullname">
                                                                SGST
                                                            </label>
                                                            <asp:TextBox ID="txtsupsgst" CssClass="form-control" runat="server" Width="95%" Text="0" Enabled="false"></asp:TextBox>

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
                                                            <asp:TextBox ID="txtdtRfnDate" runat="server" CssClass="datepicker form-control" Width="90%" Enabled="true"></asp:TextBox>
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
                                                            <asp:TextBox ID="txtrfnSC" CssClass="form-control" runat="server" Width="95%" Text="0" Enabled="true" AutoPostBack="True" OnTextChanged="txtrfnSC_TextChanged"></asp:TextBox>

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
                                                                    <asp:TextBox ID="txtRfnRemarks" CssClass="form-control" runat="server" Width="90%" Enabled="true"></asp:TextBox>

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
                                                                        <asp:CheckBox ID="chkRfnTax" runat="server" Width="90%" Checked="true" AutoPostBack="True" OnCheckedChanged="chkRfnTax_CheckedChanged"></asp:CheckBox>

                                                                    </div>

                                                                    <div class="col-md-4 col-sm-4">
                                                                        <label class="col-form-label" for="fullname">
                                                                            CGST
                                                                        </label>
                                                                        <asp:TextBox ID="txtRfnCGst" CssClass="form-control" runat="server" Width="95%" Text="0" Enabled="false"></asp:TextBox>

                                                                    </div>

                                                                    <div class="col-md-4 col-sm-4">
                                                                        <label class="col-form-label" for="fullname">
                                                                            SGST
                                                                        </label>
                                                                        <asp:TextBox ID="txtRfnSGst" CssClass="form-control" runat="server" Width="95%" Text="0" Enabled="false"></asp:TextBox>

                                                                    </div>
                                                                    <div class="col-md-3 col-sm-3">
                                                                        <label class="col-form-label" for="fullname">
                                                                            IGST
                                                                        </label>
                                                                        <asp:TextBox ID="txtRfnIGst" CssClass="form-control" runat="server" Text="0" Width="95%" Enabled="false"></asp:TextBox>

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
                                            <asp:TextBox ID="txtClientCost" runat="server" Width="40%" ForeColor="Black" CssClass="btn bg-blue-darker" Enabled="false" Text="0"></asp:TextBox>
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
                                            <asp:TextBox ID="txtSupplierCost" runat="server" Width="40%" Text="0" ForeColor="Black" CssClass="btn bg-blue-darker" Enabled="false"></asp:TextBox>
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

                                </asp:Panel>

                                <asp:Panel class="tbl table-responsive" ID="tblGridDet" runat="server" Style="margin-top: 20px;">

                                    <asp:Label ID="lblpgsDet" runat="server" Text="Page Size :"></asp:Label>
                                    <asp:DropDownList ID="ddlPageSizeDet" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPageSizeDet_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:GridView ID="GridView2" CssClass="table table-striped table-bordered" runat="server" AutoGenerateColumns="False"
                                        DataKeyNames="nInsuranceBookingDetID" Width="90%" AllowPaging="false" AllowSorting="True" EmptyDataText="No Records to display"
                                        OnPageIndexChanging="GridView2_PageIndexChanging">
                                        <Columns>
                                            <asp:TemplateField HeaderText="nInsuranceBookingDetID" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDetID" runat="server" Text='<%# Eval("nInsuranceBookingDetID") %>'></asp:Label>
                                                    <asp:Label ID="lblBookType" runat="server" Text='<%# Eval("nBookTypeID") %>'></asp:Label>
                                                    <asp:Label ID="lblInsuranceBookingID" runat="server" Text='<%# Eval("nInsuranceBookingID") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="sVoucherType" HeaderText="Type" />--%>
                                            <asp:BoundField DataField="sPaxName" HeaderText="Pax Name" />
                                            <asp:BoundField DataField="sPolicyNo" HeaderText="Policy No" />
                                            <asp:TemplateField HeaderText="From Date">
                                                <ItemTemplate>
                                                    <%#validation.TextToDate(Eval("dtTravelFromDate").ToString())%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="To Date">
                                                <ItemTemplate>
                                                    <%#validation.TextToDate(Eval("dtTravelToDate").ToString())%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="sPassport" HeaderText="Passport No." />
                                            <asp:BoundField DataField="nSupplierCost" HeaderText="Supplier Cost" />
                                            <asp:BoundField DataField="nClientCost" HeaderText="Client Cost" />
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

                                <div style=" padding: 10px; margin-top: 20px;padding-bottom:0px;">
                                    <div class="form-group row">
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
                                            <asp:TextBox ID="txtSdtBooking" runat="server" CssClass="form-control datepicker" Width="90%" placeholder="dd/MM/yyyy"></asp:TextBox>
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
                                            <asp:DropDownList ID="ddlSLoc" runat="server" CssClass="js-example-placeholder-single form-control">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group row m-b-15 text-center">
                                        <div>&nbsp;</div>
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
                                    DataKeyNames="nInsuranceBookingID" Width="90%" AllowPaging="true" AllowSorting="True" PageSize="25"
                                    OnPageIndexChanging="GridView1_PageIndexChanging">
                                    <Columns>
                                        <asp:TemplateField HeaderText="nInsuranceBookingID" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblID" runat="server" Text='<%# Eval("nInsuranceBookingID") %>'></asp:Label>
                                                <asp:Label ID="lblBookType" runat="server" Text='<%# Eval("sVoucherType") %>'></asp:Label>
                                                <asp:Label ID="lblAgentID" runat="server" Text='<%# Eval("nClientID") %>'></asp:Label>
                                                <asp:Label ID="lblBalance" runat="server" Text='<%# Eval("nBalance") %>'></asp:Label>
                                                <asp:Label ID="lblInvoiceNo" runat="server" Text='<%# Eval("sInsuranceBookingNo") %>'></asp:Label>
                                                <asp:Label ID="lblInvoiceDate" runat="server" Text='<%# Eval("dtBookingDate") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="sVoucherType" HeaderText="Book Type" />
                                        <asp:BoundField DataField="sInsuranceBookingNo" HeaderText="Invoice No." />
                                        <asp:TemplateField HeaderText="Invoice Date">
                                            <ItemTemplate>
                                                <%#validation.TextToDate(Eval("dtBookingDate").ToString())%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="sAgent" HeaderText="Client Name" />
                                        <asp:BoundField DataField="sBranchName" HeaderText="Branch Name" />
                                        <asp:BoundField DataField="sPaxName" HeaderText="Name" />
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
                                                </asp:LinkButton><br />
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
                                        <h4 class="modal-title">Insurance Payment</h4>
                                    </div>
                                    <div class="row m-5">

                                        <div class="col-md-3 col-sm-3">
                                            <h5>Payment For</h5>
                                            <asp:TextBox ID="txtPayInv" runat="server" Enabled="false" Width="90%"></asp:TextBox>
                                            <asp:Label ID="lblInvoiceDate" runat="server" Visible="false" Width="90%"></asp:Label>
                                        </div>
                                        <div class="col-md-3 col-sm-3">
                                            <h5>Balance Amount</h5>
                                            <asp:TextBox ID="txtPayBalance" runat="server" Width="90%" Enabled="false"></asp:TextBox>
                                            <asp:Label ID="lblAgent" runat="server" Visible="false"></asp:Label>
                                        </div>
                                        <div class="col-md-3 col-sm-3">
                                            <h5>Voucher No</h5>
                                            <asp:TextBox ID="txtPayVoucherNo" runat="server" Width="90%" Enabled="false"></asp:TextBox>
                                        </div>
                                        <div class="col-md-3 col-sm-3" style="z-index: 99">
                                            <h5>Payment Date</h5>
                                            <asp:TextBox ID="txtdtpayment" runat="server" CssClass="datepicker" Width="90%" placeholder="DD/MM/YYYY" OnTextChanged="txtdtpayment_TextChanged" AutoPostBack="true"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtdtpayment" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                                           <%-- <AjaxToolKit:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy"
                                                PopupButtonID="txtdtpayment" TargetControlID="txtdtpayment" PopupPosition="BottomLeft" />--%>
                                            <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender2" runat="server"
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
                                            <asp:DropDownList ID="ddlPayVoucherType" runat="server" Width="90%" OnSelectedIndexChanged="ddlPayVoucherType_SelectedIndexChanged" AutoPostBack="true">
                                                <asp:ListItem Value="0" Text="Select Payment Type"></asp:ListItem>
                                                <asp:ListItem Value="1" Text="Cash Payment"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="Bank Payment"></asp:ListItem>

                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddlPayVoucherType" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="P"></asp:RequiredFieldValidator>
                                        </div>

                                        <div class="col-md-2 col-sm-3">
                                            <h5>Payment Account</h5>
                                            <asp:DropDownList ID="ddlPaymentAccount" runat="server" Width="90%">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlPaymentAccount" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="P"></asp:RequiredFieldValidator>
                                        </div>

                                        <div class="col-md-3 col-sm-3">
                                            <h5>Amount</h5>
                                            <asp:TextBox ID="txtPayAmount" runat="server" Width="90%"></asp:TextBox>
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
                                            <asp:TextBox ID="txtPayRemarks" runat="server" Width="90%" TextMode="SingleLine"></asp:TextBox>
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
                                                DataKeyNames="nPaymentReceiveID" Width="90%" AllowPaging="true" AllowSorting="True" PageSize="25" EmptyDataText="No Records to display"
                                                OnPageIndexChanging="GridPay_PageIndexChanging">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="nPaymentReceiveID" Visible="false">
                                                        <ItemTemplate>
                                                             <asp:Label ID="lblPayID" runat="server" Text='<%# Eval("nPaymentReceiveID") %>'></asp:Label>
                                                            <asp:Label ID="lblPaydETID" runat="server" Text='<%# Eval("nPaymentReceiveDetID") %>'></asp:Label>
                                                            <asp:Label ID="lblInsuranceID" runat="server" Text='<%# Eval("nInvoiceID") %>'></asp:Label>
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
                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <!-- end panel-body -->
                <!-- end panel -->
            </div>
            <!-- end col-6 -->
        </div>
        <!-- end row -->
    </div>




</asp:Content>
