<%@ Page Title="visa" Language="C#" MasterPageFile="~/Pagecontent.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="tvisa.aspx.cs" Inherits="Transcation_visa" Culture="en-GB" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">

    <link type="text/css" rel="stylesheet" href="../assets/css/default/mystyle.css" />
    <link href="../assets/css/default/style.min.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.3/umd/popper.min.js" integrity="sha384-vFJXuSJphROIrBnz7yo7oB41mKfc8JzQZiCq4NCceLEaO4IHwicKwpJf9c9IpFgh" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta.2/js/bootstrap.min.js" integrity="sha384-alpBpkh1PFOepccYVYDB4do5UnbKysX5WZXm3XxPqe5iKTfUKjNkCk9SaVuEZflJ" crossorigin="anonymous"></script>
    <link href="https://cdn.datatables.net/1.10.22/css/dataTables.bootstrap4.min.css" rel="stylesheet" />

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <style>
        .modal-header {
            padding: 15px;
            border-bottom: 1px solid #e5e5e5;
            background: #1b82ec;
            color: #fff;
            padding-top: 0px;
            padding-bottom: 0px;
        }

        .modal-footer {
            padding: 15px;
            text-align: right;
            border-top: 1px solid #e5e5e5;
            background: #1b82ec;
            padding-bottom: 5px;
            padding-top: 5px;
        }

        .modal-xl {
            width: 80% !important;
            max-width: 1200px;
        }

        .modal-body {
            max-height: 80vh;
            overflow-x: hidden;
            overflow-y: scroll;
        }

        .btn {
            padding: 0px 12px;
        }
        /*.modal-body {
    position: relative;
    padding: 0px;
}*/
        .close {
            float: right;
            font-size: 21px;
            font-weight: 700;
            line-height: 1;
            color: #fff;
            text-shadow: 0 1px 0 #fff;
            filter: alpha(opacity=20);
            opacity: 2;
        }

        .btnspl {
            min-width: 217px;
            padding: 10px 50px;
        }

        .row {
            margin-right: 0px;
            margin-left: 0px;
        }
    </style>
    <%--<style>
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
<asp:UpdatePanel ID="uplbl" runat="server">
        <ContentTemplate>

            <asp:Label ID="lblmsg" runat="server"></asp:Label>
        </ContentTemplate>
    </asp:UpdatePanel>

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
                        <%--<asp:LinkButton ID="btnLedger" runat="server" OnClick="btnLedger_Click" CssClass="btn btn-info btn-xs">General Ledger</asp:LinkButton>
                        <AjaxToolKit:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server"
                            DisplayModalPopupID="btnLedger_modalpopupextender" TargetControlID="btnLedger" />
                        <AjaxToolKit:ModalPopupExtender ID="btnLedger_modalpopupextender" runat="server"
                            BackgroundCssClass="modalBackground" CancelControlID="btnLClose" OkControlID="btnLOk"
                            PopupControlID="PnlPayment" TargetControlID="btnLedger" />
                        <br />--%>
                    </div>
                    <div class="panel-heading-btn">
                        <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                        <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                    </div>

                    <h4 class="panel-title text-center">Visa Booking Details</h4>




                </div>
                <!-- end panel-heading -->
                <!-- begin panel-body -->
                <div class="panel-body">
                    <asp:UpdatePanel ID="UP1" runat="server">
                        <ContentTemplate>
                            <asp:Panel class="tbl" ID="tblmain" runat="server">

                                <div style=" padding: 10px;">

                                    <div class="form-group row">

                                        <div class="col-md-2 col-sm-3">
                                            <label class="col-form-label" for="fullname">
                                                Visa Booking No   * :
                                            </label>

                                            <asp:TextBox ID="txtVisaBookingNo" runat="server" CssClass="form-control" ValidationGroup="A" Enabled="true" AutoPostBack="True" OnTextChanged="txtVisaBookingNo_TextChanged"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtVisaBookingNo" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-md-2 col-sm-3">
                                            <label class="col-form-label" for="fullname">
                                                Booking Date  * :
                                            </label>

                                            <asp:TextBox ID="txttBooking" runat="server" CssClass="form-control datepicker" AutoPostBack="true" OnTextChanged="txttBooking_TextChanged"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txttBooking" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="REV2" ControlToValidate="txttBooking"
                                                ValidationGroup="A" Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                                ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                            </asp:RegularExpressionValidator>
                                            <%-- <AjaxToolKit:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy"
                                                PopupButtonID="txttBooking" TargetControlID="txttBooking" PopupPosition="TopLeft" />--%>
                                            <AjaxToolKit:MaskedEditExtender ID="MEE2" runat="server"
                                                TargetControlID="txttBooking" Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                        </div>
                                        <div class="col-md-3 col-sm-3">
                                            <label class="col-form-label" for="fullname">
                                                Supplier
                                            </label>
                                            <asp:DropDownList ID="ddlSupplier" runat="server" Width="100%" CssClass="form-control js-example-placeholder-single" AutoPostBack="true" OnSelectedIndexChanged="ddlSupplier_SelectedIndexChanged"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RFV17" runat="server" ControlToValidate="ddlSupplier" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-md-3 col-sm-3">
                                            <label class="col-form-label" for="fullname">
                                                Client Name  * :
                                            </label>

                                            <asp:DropDownList ID="ddlAgentID" runat="server" CssClass="form-control js-example-placeholder-single"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RFV3" runat="server" ControlToValidate="ddlAgentID" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-md-2 col-sm-3">
                                            <label class="col-form-label" for="fullname">
                                                Branch   * :
                                            </label>

                                            <asp:DropDownList ID="ddlLocationID" runat="server" CssClass="form-control js-example-placeholder-single"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RFV4" runat="server" ControlToValidate="ddlLocationID" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>

                                        </div>

                                    </div>

                                    <asp:Panel class="tbl" ID="tblDet" runat="server">
                                        <div style=" padding: 0px; margin-top: 0px;">
                                            <div class="row">
                                                <div class="col-md-2 col-sm-3">
                                                    <label class="col-form-label" for="fullname">
                                                        Type :</label>
                                                    <asp:DropDownList CssClass="form-control" ID="ddlbookType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlbookType_SelectedIndexChanged">
                                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="Booking" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="Refund" Value="2"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlbookType" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-md-2 col-sm-3">
                                                    <label class="col-form-label" for="fullname">
                                                        Ref. No.   
                                                    </label>
                                                    <asp:TextBox ID="txtReferenceNo" CssClass="form-control" runat="server" Width="90%" ValidationGroup="A"></asp:TextBox>
                                                </div>
                                                <div class="col-md-2 col-sm-3">
                                                    <label class="col-form-label" for="fullname">
                                                        Customer Name   * 
                                                    </label>
                                                    <asp:TextBox ID="txtCustomerName" CssClass="form-control" runat="server" Width="100%" ValidationGroup="A"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtCustomerName" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-md-2 col-sm-3">
                                                    <label class="col-form-label" for="fullname">
                                                        Nationality :
                                                    </label>
                                                    <asp:TextBox ID="txtNationality" CssClass="form-control" runat="server" Width="100%"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtNationality" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-md-2 col-sm-3">
                                                    <label class="col-form-label" for="fullname">
                                                        Country
                                                    </label>
                                                    <asp:DropDownList ID="ddlCountry" runat="server" CssClass="form-control js-example-placeholder-single"></asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlCountry" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>

                                                </div>

                                                <div class="col-md-2 col-sm-3">
                                                    <label class="col-form-label" for="fullname">
                                                        Gender    :
                                                    </label>
                                                    <br />

                                                    <asp:DropDownList ID="ddlGender" CssClass="form-control" runat="server" Width="100%">
                                                        <asp:ListItem Value="1" Text="Male"></asp:ListItem>
                                                        <asp:ListItem Value="2" Text="Female"></asp:ListItem>
                                                        <asp:ListItem Value="3" Text="Other"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>


                                            </div>
                                            <div class="row">

                                                <div class="col-md-2 col-sm-3" style="z-index: 99">
                                                    <label class="col-form-label" for="fullname">
                                                        DOB  * :
                                                    </label>
                                                    <asp:TextBox ID="txttDOB" runat="server" ValidationGroup="A" CssClass="form-control datepicker" Width="100%" placeholder="DD/MM/YYYY"></asp:TextBox>
                                                   <%-- <AjaxToolKit:CalendarExtender ID="CalendarExtender9" runat="server" Format="dd/MM/yyyy"
                                                        PopupButtonID="txttDOB" TargetControlID="txttDOB" PopupPosition="TopLeft" />--%>
                                                    <AjaxToolKit:MaskedEditExtender ID="MEE9" runat="server"
                                                        TargetControlID="txttDOB" Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                                    <asp:RegularExpressionValidator ID="REV9" ControlToValidate="txttDOB"
                                                        ValidationGroup="A" Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                                        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                                    </asp:RegularExpressionValidator>
                                                </div>
                                                <div class="col-md-2 col-sm-3">
                                                    <label class="col-form-label" for="fullname">
                                                        Ex Durtion
                                                    </label>

                                                    <asp:TextBox ID="txtExpectedDuration" CssClass="form-control" runat="server" Width="100%" ToolTip="Expected Duration"></asp:TextBox><asp:RegularExpressionValidator ID="REV16" runat="server" ControlToValidate="txtExpectedDuration"
                                                        SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                        ValidationGroup="A"></asp:RegularExpressionValidator>
                                                    <AjaxToolKit:FilteredTextBoxExtender ID="FTBE16" runat="server"
                                                        Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtExpectedDuration"
                                                        ValidChars=".-">
                                                    </AjaxToolKit:FilteredTextBoxExtender>
                                                </div>
                                                <div class="col-md-2 col-sm-3">
                                                    <label class="col-form-label" for="fullname">
                                                        Passport No  :
                                                    </label>
                                                    <asp:TextBox ID="txtPassportNo" CssClass="form-control" runat="server" Width="100%"></asp:TextBox>
                                                </div>
                                                <div class="col-md-2 col-sm-3" style="z-index: 99">
                                                    <label class="col-form-label" for="fullname">
                                                        Inbound 
                                                    </label>

                                                    <asp:TextBox ID="txttExpectedArrival" runat="server" Width="100%" CssClass="form-control datepicker"  placeholder="DD/MM/YYYY"></asp:TextBox>
                                                    <%--<AjaxToolKit:CalendarExtender ID="CalendarExtender14" runat="server" Format="dd/MM/yyyy"
                                                        PopupButtonID="txttExpectedArrival" TargetControlID="txttExpectedArrival" PopupPosition="TopLeft" />--%>
                                                    <AjaxToolKit:MaskedEditExtender ID="MEE14" runat="server"
                                                        TargetControlID="txttExpectedArrival" Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                                    <asp:RegularExpressionValidator ID="REV14" ControlToValidate="txttExpectedArrival"
                                                        ValidationGroup="A" Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                                        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                                    </asp:RegularExpressionValidator>
                                                </div>

                                                <div class="col-md-2 col-sm-3" style="z-index: 99">
                                                    <label class="col-form-label" for="fullname">
                                                        Outbound
                                                    </label>
                                                    <asp:TextBox ID="txttExpectedDeparture" runat="server" Width="100%" CssClass="form-control datepicker" placeholder="DD/MM/YYYY"></asp:TextBox>
                                                    <asp:CompareValidator ID="CompareValidator2" ValidationGroup="A" ForeColor="Red" runat="server" ControlToValidate="txttExpectedDeparture" ControlToCompare="txttExpectedArrival" Operator="GreaterThanEqual" Type="Date" ErrorMessage="Invalid Date."></asp:CompareValidator>
                                                   <%-- <AjaxToolKit:CalendarExtender ID="CalendarExtender15" runat="server" Format="dd/MM/yyyy"
                                                   PopupButtonID="txttExpectedDeparture" TargetControlID="txttExpectedDeparture" PopupPosition="TopLeft" />--%>
                                                         <AjaxToolKit:MaskedEditExtender ID="MEE15" runat="server"
                                                        TargetControlID="txttExpectedDeparture" Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                                    <asp:RegularExpressionValidator ID="REV15" ControlToValidate="txttExpectedDeparture"
                                                        ValidationGroup="A" Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                                        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                                    </asp:RegularExpressionValidator>
                                                </div>
                                                <div class="col-md-2 col-sm-3" style="z-index: 99">
                                                    <label class="col-form-label" for="fullname">
                                                        Visa Validity
                                                    </label>
                                                    <asp:TextBox ID="txtdtVisaExpiry" runat="server" Width="100%" CssClass="form-control datepicker" placeholder="DD/MM/YYYY"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtdtVisaExpiry" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                    <%--<AjaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy"
                                                        PopupButtonID="txtdtVisaExpiry" TargetControlID="txtdtVisaExpiry" PopupPosition="TopLeft" />--%>
                                                    <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender1" runat="server"
                                                        TargetControlID="txtdtVisaExpiry" Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator9" ControlToValidate="txtdtVisaExpiry"
                                                        ValidationGroup="A" Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                                        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                                    </asp:RegularExpressionValidator>
                                                </div>

                                            </div>

                                        </div>
                                        <div class="row">
                                            <!-- begin col-6 -->
                                            <div class="col-lg-6">

                                                <div style=" margin-top: 0px;padding-top: 0px;">

                                                    <div class="form-group row m-b-15">
                                                        <div class="col-md-2 col-sm-3">
                                                            <label class="col-form-label" for="fullname">
                                                                Clnt Cost
                                                            </label>
                                                            <asp:TextBox ID="txtClntCost" CssClass="form-control" runat="server" Placeholder="Clnt Cost" OnTextChanged="txtClntCost_TextChanged" AutoPostBack="true" Width="100%"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtClntCost" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" ControlToValidate="txtClntCost"
                                                                SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                                ValidationGroup="A"></asp:RegularExpressionValidator>
                                                            <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server"
                                                                Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtClntCost"
                                                                ValidChars=".-">
                                                            </AjaxToolKit:FilteredTextBoxExtender>
                                                        </div>
                                                        <div class="col-md-2 col-sm-3">
                                                            <label class="col-form-label" for="fullname">
                                                                SC Type
                                                            </label>
                                                            <asp:DropDownList ID="ddlProfitType" CssClass="form-control" runat="server" Width="100%">
                                                                <asp:ListItem Value="0" Text="Value"></asp:ListItem>
                                                                <asp:ListItem Value="1" Text="% "></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="col-md-2 col-sm-3">
                                                            <label class="col-form-label" for="fullname">
                                                                Clnt SC1
                                                            </label>
                                                            <asp:TextBox ID="txtProfitAmt" runat="server" CssClass="form-control" placeholder="Client SC" Width="100%" AutoPostBack="True" OnTextChanged="txtProfitAmt_TextChanged"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtProfitAmt"
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
                                                            <asp:TextBox ID="txtProfitAmt2" CssClass="form-control" runat="server" Placeholder="Client SC 2  :" OnTextChanged="txtProfitAmt2_TextChanged" AutoPostBack="true" Width="100%"></asp:TextBox><asp:RegularExpressionValidator ID="REV33" runat="server" ControlToValidate="txtProfitAmt2"
                                                                SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                                ValidationGroup="A"></asp:RegularExpressionValidator>
                                                            <AjaxToolKit:FilteredTextBoxExtender ID="FTBE33" runat="server"
                                                                Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtProfitAmt2"
                                                                ValidChars=".-">
                                                            </AjaxToolKit:FilteredTextBoxExtender>
                                                        </div>
                                                        <div class="col-md-2 col-sm-3">
                                                            <label class="col-form-label" for="fullname">
                                                                TDS Type
                                                            </label>
                                                            <asp:DropDownList ID="ddlClntTds" CssClass="form-control" runat="server" Width="100%">
                                                                <asp:ListItem Value="0" Text="Value"></asp:ListItem>
                                                                <asp:ListItem Value="1" Text="%"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="col-md-2 col-sm-3">
                                                            <label class="col-form-label" for="fullname">
                                                                Clnt TDS
                                                            </label>
                                                            <asp:TextBox ID="txtClntTdsAmount" CssClass="form-control" runat="server" placeholder="Clnt TDS" Width="100%" AutoPostBack="True" OnTextChanged="txtClntTdsAmount_TextChanged"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtClntTdsAmount"
                                                                SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                                ValidationGroup="A"></asp:RegularExpressionValidator>
                                                            <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                                                Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtClntTdsAmount"
                                                                ValidChars=".-">
                                                            </AjaxToolKit:FilteredTextBoxExtender>
                                                        </div>


                                                    </div>
                                                    <div class="form-group row m-b-15">
                                                        <div class="col-md-2 col-sm-3">
                                                            <label class="col-form-label" for="fullname">
                                                                Discount
                                                            </label>
                                                            <asp:TextBox ID="txtDiscount" CssClass="form-control" runat="server" Width="95%" Text="0" Placeholder="" OnTextChanged="txtDiscount_TextChanged" AutoPostBack="true" placeolder="Discount"></asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtDiscount"
                                                                SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                                ValidationGroup="A"></asp:RegularExpressionValidator>
                                                            <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                                                Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtDiscount"
                                                                ValidChars=".-">
                                                            </AjaxToolKit:FilteredTextBoxExtender>
                                                        </div>
                                                        <div class="col-md-3 col-sm-3">
                                                            <label class="col-form-label" for="fullname">
                                                                Courier Chrg
                                                            </label>
                                                            <asp:TextBox ID="txtCourierCharge" CssClass="form-control" runat="server" placeholder="" Width="100%" OnTextChanged="txtCourierCharge_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtCourierCharge"
                                                                SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                                ValidationGroup="A"></asp:RegularExpressionValidator>
                                                            <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server"
                                                                Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtCourierCharge"
                                                                ValidChars=".-">
                                                            </AjaxToolKit:FilteredTextBoxExtender>
                                                        </div>

                                                        <div class="col-md-3 col-sm-3">
                                                            <label class="col-form-label" for="fullname">
                                                                Other Chrg
                                                            </label>
                                                            <asp:TextBox ID="txtOtherCharge" CssClass="form-control" runat="server" placeholder="" Width="100%" OnTextChanged="txtOtherCharge_TextChanged" AutoPostBack="true">></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="REV26" runat="server" ControlToValidate="txtOtherCharge"
                                                                SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                                ValidationGroup="A"></asp:RegularExpressionValidator>
                                                            <AjaxToolKit:FilteredTextBoxExtender ID="FTBE26" runat="server"
                                                                Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtOtherCharge"
                                                                ValidChars=".-">
                                                            </AjaxToolKit:FilteredTextBoxExtender>
                                                        </div>


                                                        <div class="col-md-4 col-sm-3">
                                                            <label class="col-form-label" for="fullname">
                                                                Remarks
                                                            </label>
                                                            <br />
                                                            <asp:TextBox ID="txtRemarks" CssClass="form-control" runat="server" Width="100%" placeholder="Remarks :"></asp:TextBox>
                                                        </div>

                                                    </div>

                                                    <div class="form-group row m-b-10">
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
                                                                    <asp:TextBox ID="txtClntIgst" CssClass="form-control" runat="server" Width="100%" Enabled="false"></asp:TextBox>

                                                                </div>
                                                            </div>
                                                        </fieldset>
                                                    </div>
                                                    <div class="form-group row m-b-5">
                                                        <div class="col-md-12 col-sm-12 text-center text-black font-weight-bold">
                                                            <asp:Label ID="lblSelleingTitle" runat="server" Text="SELLING COST : " Visible="false"></asp:Label>
                                                            <asp:Label ID="lblSelleing" runat="server" Visible="false"></asp:Label>
                                                        </div>
                                                    </div>

                                                </div>

                                            </div>
                                            <div class="col-lg-6">

                                                <div style=" margin-top: 0px;padding-top: 0px;">

                                                    <div class="form-group row m-b-15">
                                                         <div class="col-md-2 col-sm-3">
                                                            <label class="col-form-label" for="fullname">
                                                                Cost
                                                            </label>

                                                            <asp:TextBox ID="txtCost" CssClass="form-control" runat="server" Enabled="true" placeholder="Buy Cost" ToolTip="Cost" Width="100%" AutoPostBack="True" OnTextChanged="txtCost_TextChanged"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="REV28" runat="server" ControlToValidate="txtCost"
                                                                SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                                ValidationGroup="A"></asp:RegularExpressionValidator>
                                                            <AjaxToolKit:FilteredTextBoxExtender ID="FTBE28" runat="server"
                                                                Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtCost"
                                                                ValidChars=".-">
                                                            </AjaxToolKit:FilteredTextBoxExtender>
                                                        </div>
                                                        <div class="col-md-3 col-sm-3">
                                                            <label class="col-form-label" for="fullname">
                                                                Visa Type
                                                            </label>
                                                            <asp:DropDownList ID="ddlVisaTypeID" CssClass="form-control" runat="server" Width="100%" OnTextChanged="ddlVisaTypeID_TextChanged" AutoPostBack="true"></asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RFV18" runat="server" ControlToValidate="ddlVisaTypeID" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                        </div>

                                                        <div class="col-md-2 col-sm-3">
                                                            <label class="col-form-label" for="fullname">
                                                                Duration
                                                            </label>
                                                            <asp:TextBox ID="txtDuration" CssClass="form-control" runat="server" Enabled="true" placeholder="Duration :" Width="95%"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="REV29" runat="server" ControlToValidate="txtDuration"
                                                                SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                                ValidationGroup="A"></asp:RegularExpressionValidator>
                                                            <AjaxToolKit:FilteredTextBoxExtender ID="FTBE29" runat="server"
                                                                Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtDuration"
                                                                ValidChars=".-">
                                                            </AjaxToolKit:FilteredTextBoxExtender>
                                                        </div>
                                                        <div class="col-md-3 col-sm-3">
                                                            <label class="col-form-label" for="fullname">
                                                                Status
                                                            </label>
                                                            <asp:DropDownList ID="ddlVisaStatusID" CssClass="form-control" runat="server" Width="100%">
                                                                <asp:ListItem Value="0" Text="Select Visa Status"></asp:ListItem>
                                                                <asp:ListItem Value="1" Text="Approved"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="Rejected"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="Cancelled"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="col-md-2 col-sm-3">
                                                            <label class="col-form-label" for="fullname">
                                                                Extsn
                                                            </label>
                                                            <asp:TextBox ID="txtExtension" CssClass="form-control" runat="server" placeholder="Extension  :" Width="100%"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="REV20" runat="server" ControlToValidate="txtExtension"
                                                                SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                                ValidationGroup="A"></asp:RegularExpressionValidator>
                                                            <AjaxToolKit:FilteredTextBoxExtender ID="FTBE20" runat="server"
                                                                Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtExtension"
                                                                ValidChars=".-">
                                                            </AjaxToolKit:FilteredTextBoxExtender>
                                                        </div>
                                                    </div>


                                                    <div class="form-group row m-b-15">

                                                        <div class="col-md-2 col-sm-3">
                                                            <label class="col-form-label" for="fullname">
                                                                SC Type
                                                            </label>
                                                            <asp:DropDownList ID="ddlSupScType" CssClass="form-control" runat="server" Width="100%">
                                                                <asp:ListItem Value="0" Text="Value"></asp:ListItem>
                                                                <asp:ListItem Value="1" Text="%"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="col-md-2 col-sm-3">
                                                            <label class="col-form-label" for="fullname">
                                                                Sup. Sc
                                                            </label>
                                                            <asp:TextBox ID="txtSupSc" CssClass="form-control" runat="server" placeholder="Sup. SC" Width="100%" AutoPostBack="True" OnTextChanged="txtSupSc_TextChanged"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtSupSc"
                                                                SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                                ValidationGroup="A"></asp:RegularExpressionValidator>
                                                            <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                                                Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtSupSc"
                                                                ValidChars=".-">
                                                            </AjaxToolKit:FilteredTextBoxExtender>
                                                        </div>
                                                        <div class="col-md-3 col-sm-3">
                                                            <label class="col-form-label" for="fullname">
                                                                TDS Type
                                                            </label>
                                                            <asp:DropDownList ID="ddlSupTds" CssClass="form-control" runat="server" Width="100%">
                                                                <asp:ListItem Value="0" Text="Value"></asp:ListItem>
                                                                <asp:ListItem Value="1" Text="%"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="col-md-2 col-sm-3">
                                                            <label class="col-form-label" for="fullname">
                                                                Sup TDS
                                                            </label>
                                                            <asp:TextBox ID="txtSupTds" CssClass="form-control" runat="server" placeholder="Sup. Tds :" Width="100%" AutoPostBack="True" OnTextChanged="txtSupTds_TextChanged"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtSupTds"
                                                                SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                                ValidationGroup="A"></asp:RegularExpressionValidator>
                                                            <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server"
                                                                Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtSupTds"
                                                                ValidChars=".-">
                                                            </AjaxToolKit:FilteredTextBoxExtender>
                                                        </div>
                                                        <div class="col-md-3 col-sm-3">
                                                            <label class="col-form-label" for="fullname">
                                                                Discount
                                                            </label>
                                                            <asp:TextBox ID="txtSupDisc" CssClass="form-control" runat="server" placeholder="Sup. Disc :" Width="100%" Text="0" AutoPostBack="True" OnTextChanged="txtSupDisc_TextChanged"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server" ControlToValidate="txtSupDisc"
                                                                SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                                ValidationGroup="A"></asp:RegularExpressionValidator>
                                                            <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server"
                                                                Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtSupDisc"
                                                                ValidChars=".-">
                                                            </AjaxToolKit:FilteredTextBoxExtender>
                                                        </div>

                                                    </div>

                                                    <div class="form-group row m-b-10">
                                                        <div class="col-md-12 col-sm-12">
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
                                                                        <asp:TextBox ID="txtsupigst" CssClass="form-control" runat="server" Width="100%" Enabled="false"></asp:TextBox>

                                                                    </div>
                                                                </div>
                                                            </fieldset>
                                                        </div>
                                                    </div>
                                                    <div class="form-group row m-b-5">
                                                        <div class="col-md-12 col-sm-12 text-center text-black font-weight-bold">
                                                            <asp:Label ID="lblBuyCostTitle" runat="server" Text="BUYING COST  : " Font-Bold="true" Visible="false"></asp:Label>
                                                            <asp:Label ID="lblBuyCost" runat="server" Visible="false"></asp:Label>
                                                        </div>
                                                    </div>

                                                </div>

                                            </div>

                                            <!-- begin col-6 -->



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
                                                                <asp:TextBox ID="txtdtRfnDate" runat="server" Width="95%" Enabled="true"></asp:TextBox>
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
                                                                <asp:TextBox ID="txtRefundAmt" runat="server" Width="95%" Enabled="true" AutoPostBack="True" OnTextChanged="txtRefundAmt_TextChanged"></asp:TextBox>
                                                            </div>
                                                            <div class="col-md-4 col-sm-4">
                                                                <label class="col-form-label" for="fullname">
                                                                    Rfn. SC
                                                                </label>
                                                                <asp:TextBox ID="txtrfnSC" runat="server" Width="95%" Text="0" Enabled="true" AutoPostBack="True" OnTextChanged="txtrfnSC_TextChanged"></asp:TextBox>

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
                                                                        <asp:TextBox ID="txtRfnRemarks" runat="server" Width="100%" Enabled="true"></asp:TextBox>

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
                                                                            <asp:TextBox ID="txtRfnCGst" runat="server" Width="95%" Text="0" Enabled="false"></asp:TextBox>

                                                                        </div>

                                                                        <div class="col-md-4 col-sm-4">
                                                                            <label class="col-form-label" for="fullname">
                                                                                SGST
                                                                            </label>
                                                                            <asp:TextBox ID="txtRfnSGst" runat="server" Width="95%" Text="0" Enabled="false"></asp:TextBox>

                                                                        </div>
                                                                        <div class="col-md-3 col-sm-4">
                                                                            <label class="col-form-label" for="fullname">
                                                                                IGST
                                                                            </label>
                                                                            <asp:TextBox ID="txtRfnIGst" runat="server" Text="0" Width="95%" Enabled="false"></asp:TextBox>

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

                                                <asp:TextBox ID="txtVisaRate" runat="server" Width="40%" ForeColor="Black" CssClass="btn bg-blue-darker" Enabled="false" Text="0" Placeholder="Selling Rate   :"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="txtVisaRate"
                                                    SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                    ValidationGroup="A"></asp:RegularExpressionValidator>
                                                <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server"
                                                    Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtVisaRate"
                                                    ValidChars=".-">
                                                </AjaxToolKit:FilteredTextBoxExtender>

                                            </div>
                                            <div class="col-md-6 col-sm-6 text-center">

                                                <label class="col-form-label text-center" for="fullname">
                                                    Supplier Cost
                                                </label>

                                                <asp:TextBox ID="txtBuyCost" runat="server" Width="40%" Text="0" ForeColor="Black" CssClass="btn bg-blue-darker" Enabled="false"></asp:TextBox>

                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtBuyCost"
                                                    SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                    ValidationGroup="A"></asp:RegularExpressionValidator>
                                                <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server"
                                                    Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtBuyCost"
                                                    ValidChars=".-">
                                                </AjaxToolKit:FilteredTextBoxExtender>

                                            </div>


                                        </div>

                                        <div class="form-group row m-b-0" style="margin: 20px; text-align: center;">
                                            <div class="col-md-12 col-sm-12">
                                                <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary btnspl" Text="Add" ValidationGroup="A" OnClick="btnAdd_Click" ToolTip="Add" />
                                                <asp:Button ID="btnAddDet" runat="server" CssClass="btn btn-primary" Text="Add" ValidationGroup="A" OnClick="btnAddDet_Click" ToolTip="Add" />
                                                <asp:Button ID="btnUpdateDet" runat="server" CssClass="btn btn-primary" Text="Update" ValidationGroup="A" OnClick="btnUpdateDet_Click" ToolTip="Update" />
                                                <asp:Button ID="btnPrint" runat="server" CssClass="btn btn-primary" Text="Print" OnClick="btnPrint_Click" ToolTip="Print" Visible="false" />
                                                <asp:Button ID="btnPaymentHistory" runat="server" CssClass="btn btn-primary" Text="Payment History" OnClick="btnPaymentHistory_Click" ToolTip="Payment History" Visible="false" />

                                            </div>
                                        </div>
                                    </asp:Panel>
                                </div>

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:UpdatePanel ID="Up2" runat="server">
                        <ContentTemplate>
                            <asp:Panel class="tbl table-responsive" ID="tblGridDet" runat="server" Style="margin-top: 20px;">
                                <asp:Label ID="lblpgsDet" runat="server" Text="Page Size :"></asp:Label>
                                <asp:DropDownList ID="ddlPageSizeDet" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPageSizeDet_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:GridView ID="GridView2" CssClass="table table-striped table-bordered" runat="server" AutoGenerateColumns="False"
                                    DataKeyNames="nVisaDetID" Width="100%" AllowPaging="false" AllowSorting="True" EmptyDataText="No Records to display"
                                    OnPageIndexChanging="GridView2_PageIndexChanging">
                                    <Columns>
                                        <asp:TemplateField HeaderText="nVisaDetID" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblIDDet" runat="server" Text='<%# Eval("nVisaDetID") %>'></asp:Label>
                                                <asp:Label ID="lblBookType" runat="server" Text='<%# Eval("sVoucherType") %>'></asp:Label>
                                                <asp:Label ID="lblvisaID" runat="server" Text='<%# Eval("nVisaID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="sVoucherType" HeaderText="Type" />
                                        <asp:BoundField DataField="sReferenceNo" HeaderText="Ref. No." />
                                        <asp:BoundField DataField="sCustomerName" HeaderText="PAX Name" />
                                        <asp:BoundField DataField="sPassportNo" HeaderText="Gender" />
                                        <asp:TemplateField HeaderText="Inbound">
                                            <ItemTemplate>
                                                <%#validation.TextToDate(Eval("dtExpectedArrival").ToString())%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Outbound">
                                            <ItemTemplate>
                                                <%#validation.TextToDate(Eval("dtExpectedDeparture").ToString())%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Validity">
                                            <ItemTemplate>
                                                <%#validation.TextToDate(Eval("dtVisaExpiryDate").ToString())%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="nBuyingRate" HeaderText="Supplier Cost" />
                                        <asp:BoundField DataField="nSellingRate" HeaderText="Client Cost" />


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
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <asp:UpdatePanel ID="UP3" runat="server">
                        <ContentTemplate>
                            <asp:Panel class="tbl table-responsive" ID="tblGrd" runat="server">
                                <div style=" padding: 10px; margin-top: 20px;">
                                    <div class="form-group row m-b-15">
                                        <div class="col-md-2 col-sm-3">
                                            <label class="col-form-label" for="fullname">
                                                Invoice No. :</label>
                                            <asp:DropDownList CssClass="form-control js-example-placeholder-single" ID="ddlInvoiceNo" runat="server">
                                            </asp:DropDownList>

                                        </div>
                                        <div class="col-md-2 col-sm-2" style="z-index: 99">
                                            <label class="col-form-label" for="fullname">
                                                Invoice Date :</label>
                                            <asp:TextBox ID="txtSdtBooking" runat="server" CssClass="form-control datepicker" placeholder="dd/MM/yyyy" ></asp:TextBox>
                                            <%--<AjaxToolKit:CalendarExtender ID="CalendarExtender4" runat="server" Format="dd/MM/yyyy"
                                                PopupButtonID="txtSdtBooking" TargetControlID="txtSdtBooking" PopupPosition="BottomLeft" />--%>

                                            <AjaxToolKit:MaskedEditExtender ID="MEE4" runat="server" TargetControlID="txtSdtBooking"
                                                Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                            <asp:RegularExpressionValidator ID="REV4" ControlToValidate="txtSdtBooking" ValidationGroup="A"
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
                                                Expiry  :</label>
                                            <asp:DropDownList ID="ddlExpiry" runat="server" CssClass="js-example-placeholder-single form-control">
                                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="10 Days" Value="-10"></asp:ListItem>
                                                <asp:ListItem Text="20 Days" Value="-20"></asp:ListItem>
                                                <asp:ListItem Text="30 Days" Value="-30"></asp:ListItem>
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
                                <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:GridView ID="GridView1" CssClass="table table-striped table-bordered" runat="server" AutoGenerateColumns="False"
                                    DataKeyNames="nVisaId" Width="100%" AllowPaging="true" AllowSorting="True" PageSize="25" EmptyDataText="No Records to display"
                                    OnPageIndexChanging="GridView1_PageIndexChanging">
                                    <Columns>
                                        <asp:TemplateField HeaderText="nVisaId" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblID" runat="server" Text='<%# Eval("nVisaId") %>'></asp:Label>
                                                <asp:Label ID="lblAgentID" runat="server" Text='<%# Eval("nAgentID") %>'></asp:Label>
                                                <asp:Label ID="lblBalance" runat="server" Text='<%# Eval("nBalance") %>'></asp:Label>
                                                <asp:Label ID="lblInvoiceNo" runat="server" Text='<%# Eval("sVisaBookingNo") %>'></asp:Label>
                                                <asp:Label ID="lblInvoiceDate" runat="server" Text='<%# Eval("dtBooking") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:BoundField DataField="sVisaBookingNo" HeaderText="Invoice No." />
                                        <asp:TemplateField HeaderText="Invoice Date">
                                            <ItemTemplate>
                                                <%#validation.TextToDate(Eval("dtBooking").ToString())%>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:BoundField DataField="sVisaSellCompany" HeaderText="Agent Name" />
                                        <asp:BoundField DataField="sVisaBuyCompany" HeaderText="Supplier Name" />
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
                    <i class="fas fa-lg fa-fw m-r-10 fa-print fa-grid-edit"></i> <span class="text-inverse">Print</span></asp:LinkButton><br />
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
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:Panel ID="PnlPayment" runat="server">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h4 class="modal-title">Visa Payment</h4>
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
                                            <asp:TextBox ID="txtdtpayment" runat="server" Width="100%" CssClass="form-control datepicker" placeholder="DD/MM/YYYY" OnTextChanged="txtdtpayment_TextChanged" AutoPostBack="true"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtdtpayment" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                                            <%--<AjaxToolKit:CalendarExtender ID="CalendarExtender5" runat="server" Format="dd/MM/yyyy"
                                                PopupButtonID="txtdtpayment" TargetControlID="txtdtpayment" PopupPosition="BottomLeft" />--%>
                                            <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender2" runat="server"
                                                TargetControlID="txtdtpayment" Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator11" ControlToValidate="txtdtpayment"
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

                                        <div class="col-md-2 col-sm-3">
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
                                                            <asp:Label ID="lblVisaID" runat="server" Text='<%# Eval("nInvoiceID") %>'></asp:Label>
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


</asp:Content>
