<%@ Page Title="Air Ticketing" Language="C#" MasterPageFile="~/Pagecontent.master" AutoEventWireup="true" Culture="en-GB"
    CodeFile="tticketing.aspx.cs" Inherits="Transcation_ticketing" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />
    <link href="../assets/css/default/style.min.css" rel="stylesheet" />
    <link href="https://cdn.datatables.net/1.10.22/css/dataTables.bootstrap4.min.css" rel="stylesheet" />
    <style>
        /*.modal-xl{ 
                 max-width :75%;
                 max-height:60vh;
             }*/
        .modal-body {
            max-height: 80vh;
            overflow-x: hidden;
            overflow-y: scroll;
        }

        .form-group {
            margin-bottom: 0px;
        }
    </style>
    <style>
        .form-control {
            border: 1px solid #00bcd4;
            width: 90%;
        }

        .nopad {
            padding: 0;
        }

        .full-wdth {
            width: 100% !important;
        }
    </style>


    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <style>
        .row {
            margin-right: 0px;
            margin-left: 0px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
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
                                <%--<asp:LinkButton ID="btnStatement" runat="server" OnClick="btnStatement_Click" CssClass="btn btn-info btn-xs">Statement</asp:LinkButton>--%>
                                <%--  <a href="tticketing_statement.aspx?AccType=0&AccTitle=&Loc=0&DtStFrom=&DtStTo=" target="_blank" class="btn btn-info btn-xs">Statement</a>--%>
                            </div>
                            <div class="panel-heading-btn">
                                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                            </div>

                            <h4 class="panel-title text-center">Ticket Booking Details</h4>

                        </div>
                        <!-- end panel-heading -->
                        <!-- begin panel-body -->
                        <div class="panel-body">

                            <asp:Panel class="tbl" ID="tblmain" runat="server">
                                <div style="border: 1px solid #e0e0d9; padding: 5px;">

                                    <div class="form-group row m-b-5">
                                        <div class="col-md-6 col-sm-12">
                                            <div class="form-group row">
                                                <div class="col-md-3 col-sm-2">
                                                    <label class="col-form-label" for="fullname">
                                                        Journey Type :</label>
                                                    <asp:DropDownList CssClass="js-example-placeholder-single" ID="ddlTicketType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTicketType_SelectedIndexChanged">
                                                        <asp:ListItem Text="Select Journey Type" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="DOM" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="INT" Value="2"></asp:ListItem>
                                                        <asp:ListItem Text="BSP" Value="3"></asp:ListItem>
                                                        <asp:ListItem Text="Void" Value="5"></asp:ListItem>

                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlTicketType" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-md-3 col-sm-2">
                                                    <label class="col-form-label" for="fullname">
                                                        Tax Invoice :</label>

                                                    <asp:TextBox ID="txtTicketBookingNo" runat="server" CssClass="form-control" Width="100%"> </asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtTicketBookingNo" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-md-3 col-sm-2" style="z-index: 100">
                                                    <label class="col-form-label" for="fullname">
                                                        DOC Date :</label>
                                                    <asp:TextBox ID="txtdtBooking" runat="server" CssClass="form-control datepicker" AutoCompleteType="None" AutoPostBack="true" OnTextChanged="txtdtBooking_TextChanged" Width="100%"></asp:TextBox>
                                                    <%-- <AjaxToolKit:CalendarExtender ID="CalendarExtender4" runat="server" Format="dd/MM/yyyy"
                                                        PopupButtonID="txtdtBooking" TargetControlID="txtdtBooking" PopupPosition="BottomLeft" />--%>
                                                    <AjaxToolKit:MaskedEditExtender ID="MEE4" runat="server" TargetControlID="txtdtBooking"
                                                        Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                                    <asp:RegularExpressionValidator ID="REV4" ControlToValidate="txtdtBooking" ValidationGroup="A"
                                                        Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                                        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                                    </asp:RegularExpressionValidator>
                                                </div>
                                                <div class="col-md-3 col-sm-2">
                                                    <label class="col-form-label" for="fullname">
                                                        Supplier Type :</label>
                                                    <asp:DropDownList Width="100%" ID="ddlTktCompany" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlTktCompany_SelectedIndexChanged">
                                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="Supplier" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="Airline" Value="2"></asp:ListItem>
                                                        <asp:ListItem Text="Self" Value="3"></asp:ListItem>
                                                        <asp:ListItem Text="IATA BSP" Value="4"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlTktCompany" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                </div>

                                            </div>
                                        </div>
                                        <div class="col-md-6 col-sm-12">
                                            <div class="form-group row">
                                                <div class="col-md-4 col-sm-2">
                                                    <label class="col-form-label" for="fullname">
                                                        Supplier Name * :</label>
                                                    <asp:DropDownList ID="ddlsupplier" runat="server" CssClass="form-control js-example-placeholder-single" AutoPostBack="true" OnSelectedIndexChanged="ddlsupplier_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlsupplier" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-md-4 col-sm-2">
                                                    <label class="col-form-label" for="fullname">
                                                        Client Name :</label>
                                                    <asp:DropDownList CssClass="form-control js-example-placeholder-single" ID="ddlAgentID" runat="server">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RFV3" runat="server" ControlToValidate="ddlAgentID" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                </div>

                                                <div class="col-md-4 col-sm-2">
                                                    <label class="col-form-label" for="fullname">
                                                        Location  :</label>
                                                    <asp:DropDownList ID="ddlLocationID" runat="server" CssClass="js-example-placeholder-single" Width="100%" AutoPostBack="true" OnTextChanged="ddlLocationID_TextChanged">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RFV4" runat="server" ControlToValidate="ddlLocationID" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                </div>


                                <asp:Panel class="tbl" ID="tblDet" runat="server">

                                    <div style="border: 1px solid #e0e0d9; padding: 15px; padding-top: 0px;">
                                        <div class="form-group row">
                                            <div class="col-md-2 col-sm-6">
                                                <label class="col-form-label" for="fullname">
                                                    Book Type</label>
                                                <asp:DropDownList CssClass="form-control" Width="100%" ID="ddlBookType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBookType_SelectedIndexChanged">
                                                    <asp:ListItem Text="Booking" Value="1" Selected="True"></asp:ListItem>
                                                    <asp:ListItem Text="Refund" Value="2"></asp:ListItem>
                                                    <asp:ListItem Text="Re-Issue" Value="3"></asp:ListItem>
                                                    <asp:ListItem Text="Sales" Value="4"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-md-2 col-sm-6">
                                                <label class="col-form-label" for="fullname">
                                                    Select Air</label>
                                                <asp:DropDownList CssClass="js-example-placeholder-single form-control" Width="100%" ID="ddlCarrierID" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCarrierID_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-md-2 col-sm-6">
                                                <label class="col-form-label" for="fullname">
                                                    2-Latter</label>
                                                <asp:TextBox ID="txtlatter" CssClass="form-control" runat="server" Width="100%" Enabled="false" />
                                            </div>
                                            <div class="col-md-2 col-sm-6">
                                                <label class="col-form-label" for="fullname">
                                                    Designator</label>
                                                <asp:TextBox ID="txtdesignator" CssClass="form-control" runat="server" Width="100%" Enabled="false" />

                                            </div>
                                            <div class="col-md-2 col-sm-6">
                                                <label class="col-form-label" for="fullname">
                                                    Ticket No. :</label>
                                                <asp:TextBox ID="txtPNR" CssClass="form-control" runat="server" Width="100%" AutoPostBack="true" MaxLength="14" OnTextChanged="txtPNR_TextChanged">
                                                </asp:TextBox>
                                            </div>
                                            <div class="col-md-2 col-sm-6">
                                                <label class="col-form-label" for="fullname">
                                                    Pax Type</label>
                                                <asp:DropDownList Width="100%" CssClass="form-control" ID="ddlPaxType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBookType_SelectedIndexChanged">
                                                    <asp:ListItem Text="Adult" Value="ADT" Selected="True"></asp:ListItem>
                                                    <asp:ListItem Text="Child" Value="CHD"></asp:ListItem>
                                                    <asp:ListItem Text="Infant" Value="INF"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>


                                        </div>

                                        <div class="form-group row">
                                            <div class="col-md-2 col-sm-6">
                                                <label class="col-form-label" for="fullname">
                                                    Pax Name :</label>
                                                <asp:TextBox ID="txtCustomerName" CssClass="form-control" runat="server" ValidationGroup="A" Width="100%">
                                                </asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtCustomerName" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                                            </div>
                                            <%--<div class="col-md-2 col-sm-6">
                                                <label class="col-form-label" for="fullname">
                                                    PAX Mobile No :</label>
                                                <asp:TextBox ID="txtpaxmobileno" runat="server" ValidationGroup="A" Width="100%">
                                                </asp:TextBox>
                                            </div>--%>
                                            <%--<div class="col-md-2 col-sm-6">
                                                <label class="col-form-label" for="fullname">
                                                    PAX Email :</label>
                                                <asp:TextBox ID="txtpaxemail" runat="server" ValidationGroup="A" Width="100%">
                                                </asp:TextBox>
                                            </div>--%>
                                            <div class="col-md-2 col-sm-6">
                                                <label class="col-form-label" for="fullname">
                                                    B Sign :</label>
                                                <asp:TextBox CssClass="form-control" ID="txtbookingsign" runat="server" ValidationGroup="A" Width="100%">
                                                </asp:TextBox>
                                            </div>
                                            <div class="col-md-2 col-sm-6">
                                                <label class="col-form-label" for="fullname">
                                                    Staff Sign :</label>
                                                <asp:TextBox ID="txtstaffsign" CssClass="form-control" runat="server" ValidationGroup="A" Width="100%">
                                                </asp:TextBox>
                                            </div>
                                            <div class="col-md-2 col-sm-6">
                                                <label class="col-form-label" for="fullname">
                                                    Tour Code:</label>
                                                <asp:TextBox ID="txttourcode" CssClass="form-control" runat="server" ValidationGroup="A" Width="100%">
                                                </asp:TextBox>
                                            </div>
                                            <div class="col-md-2 col-sm-6">
                                                <label class="col-form-label" for="fullname">
                                                    Fare Basis :</label>
                                                <asp:TextBox ID="txtfabasis" CssClass="form-control" runat="server" ValidationGroup="A" Width="100%">
                                                </asp:TextBox>
                                            </div>
                                            <div class="col-md-2 col-sm-6">
                                                <label class="col-form-label" for="fullname">
                                                    Trip :</label>
                                                <asp:TextBox ID="txttriplength" CssClass="form-control" runat="server" ValidationGroup="A" Width="100%">
                                                </asp:TextBox>
                                            </div>

                                            <div class="col-md-2 col-sm-6">
                                                <label class="col-form-label" for="fullname">
                                                    Flight Class</label>
                                                <asp:DropDownList ID="ddlFlightClassID" runat="server" CssClass="form-control js-example-placeholder-single">
                                                </asp:DropDownList>
                                            </div>

                                            <%--<div class="col-md-2 col-sm-6">
                                                <label class="col-form-label" for="fullname">
                                                    Pro Time :</label>
                                                <asp:TextBox ID="txtprocesstime" runat="server" ValidationGroup="A" Width="100%"></asp:TextBox>
                                            </div>--%>
                                        </div>

                                        <div class="form-group row">
                                            <%--<div class="col-md-2 col-sm-6">
                                                <label class="col-form-label" for="fullname">
                                                    Cancellation :</label>
                                                <asp:TextBox CssClass="form-control" ID="txtcancellation" runat="server" ValidationGroup="A" Width="100%">
                                                </asp:TextBox>
                                            </div>--%>
                                            <div class="col-md-2 col-sm-6">
                                                <label class="col-form-label" for="fullname">
                                                    Re-Issue:</label>

                                                <asp:DropDownList CssClass="form-control" ID="rdbbtnreissue" runat="server" Width="100%">
                                                    <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                                    <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-md-2 col-sm-6">
                                                <label class="col-form-label" for="fullname">
                                                    Amex :</label>

                                                <asp:DropDownList ID="rdbbtnamex" CssClass="form-control" runat="server" Width="100%">
                                                    <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                                    <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-md-2 col-sm-6">
                                                <label class="col-form-label" for="fullname">
                                                    Emp No :</label>
                                                <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" ValidationGroup="A" Width="100%">
                                                </asp:TextBox>
                                            </div>
                                            <div class="col-md-2 col-sm-2">
                                                <label class="col-form-label" for="fullname">
                                                    Travel Date :</label>
                                                <asp:TextBox CssClass="form-control" ID="txtTravelDate" runat="server" Width="100%"> </asp:TextBox>

                                            </div>
                                            <div class="col-md-2 col-sm-2">
                                                <label class="col-form-label" for="fullname">
                                                    Return Date :</label>
                                                <asp:TextBox CssClass="form-control" ID="txtreturndate" runat="server" Width="100%"></asp:TextBox>




                                            </div>

                                            <%--<div class="col-md-2 col-sm-6">
                                                <label class="col-form-label" for="fullname">
                                                    Ref No. :</label>
                                                <asp:TextBox CssClass="form-control" ID="txtReferenceNo" runat="server" ValidationGroup="A" Width="100%">
                                                </asp:TextBox>
                                            </div>--%>
                                            <div class="col-md-2 col-sm-6">
                                                <label class="col-form-label" for="fullname">
                                                    Air PNR:</label>
                                                <asp:TextBox CssClass="form-control" ID="txtAirPnr" runat="server" ValidationGroup="A" Width="100%"></asp:TextBox>
                                            </div>

                                        </div>

                                        <div class="form-group row">
                                            <div class="col-md-2 col-sm-6">
                                                <label class="col-form-label" for="fullname">
                                                    Flight No:</label>
                                                <asp:TextBox CssClass="form-control" ID="txtFlightNo" runat="server" ValidationGroup="A" Width="100%"></asp:TextBox>
                                            </div>
                                            <div class="col-md-2 col-sm-6">
                                                <label class="col-form-label" for="fullname">
                                                    CRS :</label>
                                                <asp:DropDownList ID="ddlTktBookFrom" CssClass="form-control" runat="server" Width="100%">
                                                    <asp:ListItem Text="AMDEUS" Value="1A"></asp:ListItem>
                                                    <asp:ListItem Text="Galileo" Value="1G"></asp:ListItem>
                                                    <asp:ListItem Text="SABRE" Value="1S"></asp:ListItem>
                                                    <asp:ListItem Text="ABACUS" Value="1B"></asp:ListItem>
                                                    <asp:ListItem Text="WEB" Value="WEB"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-md-2 col-sm-6">
                                                <label class="col-form-label" for="fullname">
                                                    Sector :</label>
                                                <asp:TextBox CssClass="form-control" ID="txtSector" runat="server" placeholder="BOM/DEL/BOM" ValidationGroup="A" MaxLength="19" Width="100%"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtSector" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>

                                            </div>
                                            <div class="col-md-2 col-sm-12">
                                                <label class="col-form-label" for="fullname">
                                                    Remarks :</label>
                                                <asp:TextBox CssClass="form-control" ID="txtRemarks" runat="server" Width="100%">
                                                </asp:TextBox>
                                            </div>
                                            <div class="col-md-2 col-sm-12">
                                                <label class="col-form-label" for="fullname">
                                                    Tax Details :</label>
                                                <asp:TextBox CssClass="form-control" ID="txttaxdetails" runat="server" Width="100%">
                                                </asp:TextBox>
                                            </div>

                                            <div class="col-md-2 col-sm-6">
                                                <label class="col-form-label" for="fullname">
                                                    File Name :</label>
                                                <asp:TextBox CssClass="form-control" ID="txtfilename" runat="server" ValidationGroup="A" Width="100%">
                                                </asp:TextBox>
                                            </div>

                                            <%--<div class="col-md-2 col-sm-2" style="z-index: 100">
                                                    <label class="col-form-label" for="fullname">
                                                        Proc Date :</label>
                                                    <asp:TextBox CssClass="form-control" ID="txtprocdate" runat="server" CssClass="form-control datepicker" AutoCompleteType="None" Width="100%"></asp:TextBox>
                                                   
                                                    <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender6" runat="server" TargetControlID="txtprocdate"
                                                        Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator30" ControlToValidate="txtprocdate" ValidationGroup="A"
                                                        Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                                        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                                    </asp:RegularExpressionValidator>
                                                </div>--%>
                                        </div>

                                        <div class="form-group row">
                                            <div class="col-md-2 col-sm-6">
                                                <label class="col-form-label" for="fullname">
                                                    Auto INV :</label>
                                                <asp:DropDownList ID="ddlinvoicetype" CssClass="form-control" runat="server" Width="100%">
                                                    <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                                    <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-md-2 col-sm-6">
                                                <label class="col-form-label" for="fullname">
                                                    LPO No:</label>
                                                <asp:TextBox CssClass="form-control" ID="txtlpono" runat="server" ValidationGroup="A" Width="100%"></asp:TextBox>
                                            </div>
                                            <div class="col-md-2 col-sm-6">
                                                <label class="col-form-label" for="fullname">
                                                    PCC :</label>
                                                <asp:TextBox CssClass="form-control" ID="txtpcc" runat="server" ValidationGroup="A" Width="100%"></asp:TextBox>
                                            </div>
                                            <div class="col-md-2 col-sm-6">
                                                <label class="col-form-label" for="fullname">
                                                    G PNR No :</label>
                                                <asp:TextBox CssClass="form-control" ID="txtgalpnrno" runat="server" ValidationGroup="A" Width="100%"></asp:TextBox>
                                            </div>
                                            <div class="col-md-2 col-sm-6">
                                                <label class="col-form-label" for="fullname">
                                                    IATA No :</label>
                                                <asp:TextBox CssClass="form-control" ID="txtiatano" runat="server" MaxLength="19" Width="100%"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtiatano" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>

                                            </div>
                                            <div class="col-md-2 col-sm-12">
                                                <label class="col-form-label" for="fullname">
                                                    No of Segmnt :</label>
                                                <asp:TextBox CssClass="form-control" ID="txtnoofsegment" runat="server" Width="100%">
                                                </asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                        </div>
                                        <div class="form-group row">
                                        </div>
                                        <div class="form-group row m-t-10">
                                            <asp:Repeater ID="rptSector" runat="server" Visible="false">
                                                <ItemTemplate>
                                                    <div class="col-md-3 col-sm-12  p-10 text-center border">
                                                        <div class="row">
                                                            <div class="col-md-4 col-sm-12 text-black">
                                                                <asp:HiddenField ID="hdnRow" runat="server" Value='<%# Eval("nTickerSectorID") %>' />
                                                                <asp:Label ID="lblsector" Text='<%# Eval("sSector") %>' runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-3 col-sm-12">
                                                                <asp:TextBox ID="txtSecAirR" runat="server" Text='<%# Eval("sAirline") %>' Width="100%"></asp:TextBox>
                                                            </div>
                                                            <div class="col-md-5 col-sm-12" style="z-index: 999">
                                                                <asp:TextBox ID="txtdtTravelR" runat="server" Text='<%# validation.TextToDate(Eval("dtTDate").ToString()) %>' Width="100%" CssClass="form-control datepicker"></asp:TextBox>
                                                                <%-- <AjaxToolKit:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy"
                                                                    PopupButtonID="txtdtTravelR" TargetControlID="txtdtTravelR" PopupPosition="TopLeft" />--%>

                                                                <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtdtTravelR"
                                                                    Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtdtTravelR"
                                                                    ValidationGroup="A" Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                                                    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                                                </asp:RegularExpressionValidator>
                                                            </div>
                                                        </div>
                                                    </div>

                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </div>

                                    </div>




                                    <div class="form-group row m-b-5">

                                        <div class="col-md-6 col-sm-12">
                                            <div style="border: 1px solid #e0e0d9; padding: 5px;">

                                                <div class="form-group row">
                                                    <div class="col-md-6 col-sm-12">
                                                        <div class="form-group row">
                                                            <div class="col-md-3 col-sm-6">
                                                                <label class="col-form-label" for="fullname">
                                                                    B FARE</label>
                                                                <asp:TextBox CssClass="form-control" ID="txtClntBasicFare" runat="server" Width="100%" AutoPostBack="True" OnTextChanged="txtClntBasicFare_TextChanged" TabIndex="1"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator17" runat="server" ControlToValidate="txtClntBasicFare"
                                                                    SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                                    ValidationGroup="A"></asp:RegularExpressionValidator>
                                                                <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender13" runat="server"
                                                                    Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtClntBasicFare"
                                                                    ValidChars=".-">
                                                                </AjaxToolKit:FilteredTextBoxExtender>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtClntBasicFare" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                            </div>
                                                            <div class="col-md-3 col-sm-6">
                                                                <label class="col-form-label" for="fullname">
                                                                    'YQ' 
                                                                </label>
                                                                <asp:TextBox CssClass="form-control" ID="txtClntYQTax" runat="server" Width="100%" AutoPostBack="True" OnTextChanged="txtClntYQTax_TextChanged" TabIndex="2"></asp:TextBox>
                                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtClntYQTax" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>--%>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtClntYQTax"
                                                                    SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                                    ValidationGroup="A"></asp:RegularExpressionValidator>
                                                                <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender17" runat="server"
                                                                    Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtClntYQTax"
                                                                    ValidChars=".-">
                                                                </AjaxToolKit:FilteredTextBoxExtender>
                                                            </div>
                                                            <div class="col-md-3 col-sm-6">
                                                                <label class="col-form-label" for="fullname">
                                                                    'YR' 
                                                                </label>
                                                                <asp:TextBox CssClass="form-control" ID="txtClntYRTax" runat="server" Width="100%" AutoPostBack="True" OnTextChanged="txtClntYRTax_TextChanged"></asp:TextBox>
                                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtClntYRTax" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>--%>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator21" runat="server" ControlToValidate="txtClntYRTax"
                                                                    SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                                    ValidationGroup="A"></asp:RegularExpressionValidator>
                                                                <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender18" runat="server"
                                                                    Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtClntYRTax"
                                                                    ValidChars=".-">
                                                                </AjaxToolKit:FilteredTextBoxExtender>
                                                            </div>
                                                            <div class="col-md-3 col-sm-4">
                                                                <label class="col-form-label" for="fullname">
                                                                    'K3' 
                                                                </label>
                                                                <asp:TextBox CssClass="form-control" ID="txtClntK3Tax" runat="server" Width="100%" OnTextChanged="txtClntK3Tax_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtClntYRTax" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>--%>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator18" runat="server" ControlToValidate="txtClntK3Tax"
                                                                    SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                                    ValidationGroup="A"></asp:RegularExpressionValidator>
                                                                <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender14" runat="server"
                                                                    Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtClntK3Tax"
                                                                    ValidChars=".-">
                                                                </AjaxToolKit:FilteredTextBoxExtender>
                                                            </div>

                                                        </div>
                                                    </div>
                                                    <div class="col-md-6 col-sm-12">
                                                        <div class="form-group row">
                                                            <div class="col-md-4 col-sm-4">
                                                                <label class="col-form-label" for="fullname">
                                                                    OTR TAX
                                                                </label>
                                                                <asp:TextBox CssClass="form-control" ID="txtClntOtherTax" runat="server" OnTextChanged="txtClntOtherTax_TextChanged" AutoPostBack="true" Width="100%"></asp:TextBox>
                                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtClntOtherTax" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>--%>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator20" runat="server" ControlToValidate="txtClntOtherTax"
                                                                    SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                                    ValidationGroup="A"></asp:RegularExpressionValidator>
                                                                <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender16" runat="server"
                                                                    Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtClntOtherTax"
                                                                    ValidChars=".-">
                                                                </AjaxToolKit:FilteredTextBoxExtender>
                                                            </div>
                                                            <div class="col-md-4 col-sm-6">

                                                                <label class="col-form-label" for="fullname">
                                                                    IATA COM
                                                                </label>
                                                                <asp:TextBox CssClass="form-control" ID="txtClntAirCom" runat="server" Enabled="true" Width="100%" OnTextChanged="txtClntAirCom_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator23" runat="server" ControlToValidate="txtClntAirCom"
                                                                    SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                                    ValidationGroup="A"></asp:RegularExpressionValidator>
                                                                <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender20" runat="server"
                                                                    Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtClntAirCom"
                                                                    ValidChars=".-">
                                                                </AjaxToolKit:FilteredTextBoxExtender>
                                                            </div>
                                                            <div class="col-md-4 col-sm-6">
                                                                <label class="col-form-label" for="fullname">
                                                                    PLB COM
                                                                </label>
                                                                <asp:TextBox CssClass="form-control" ID="txtClntAirPlb" runat="server" Enabled="true" Width="100%" OnTextChanged="txtClntAirPlb_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator24" runat="server" ControlToValidate="txtClntAirPlb"
                                                                    SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                                    ValidationGroup="A"></asp:RegularExpressionValidator>
                                                                <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender21" runat="server"
                                                                    Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtClntAirPlb"
                                                                    ValidChars=".-">
                                                                </AjaxToolKit:FilteredTextBoxExtender>
                                                            </div>
                                                            <%-- <div class="col-md-3 col-sm-4">
                                                                <label class="col-form-label" for="fullname">
                                                                    OC Tax
                                                                </label>
                                                                <asp:TextBox CssClass="form-control" ID="txtClntOCTax" runat="server"  OnTextChanged="txtClntOCTax_TextChanged" AutoPostBack="true" Width="100%"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator19" runat="server" ControlToValidate="txtClntOCTax"
                                                                    SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                                    ValidationGroup="A"></asp:RegularExpressionValidator>
                                                                <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender15" runat="server"
                                                                    Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtClntOCTax"
                                                                    ValidChars=".-">
                                                                </AjaxToolKit:FilteredTextBoxExtender>
                                                            </div>--%>
                                                            <%--<div class="col-md-4 col-sm-6">

                                                                <label class="col-form-label" for="fullname">
                                                                    Air INC
                                                                </label>
                                                                <asp:TextBox CssClass="form-control" ID="txtClntAirInc" runat="server" Width="100%" Enabled="true" AutoPostBack="True" OnTextChanged="txtClntAirInc_TextChanged"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator22" runat="server" ControlToValidate="txtClntAirInc"
                                                                    SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                                    ValidationGroup="A"></asp:RegularExpressionValidator>
                                                                <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender19" runat="server"
                                                                    Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtClntAirInc"
                                                                    ValidChars=".-">
                                                                </AjaxToolKit:FilteredTextBoxExtender>
                                                            </div>--%>
                                                        </div>
                                                    </div>

                                                </div>
                                                <div class="form-group row">
                                                    <div class="col-md-2 col-sm-4">
                                                        <label class="col-form-label" for="fullname">
                                                            TKT COST</label>
                                                        <asp:TextBox CssClass="form-control" ID="txtClntTicketFare" runat="server" Width="100%" OnTextChanged="txtProfitAmount_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator25" runat="server" ControlToValidate="txtClntTicketFare"
                                                            SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                            ValidationGroup="A"></asp:RegularExpressionValidator>
                                                        <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender22" runat="server"
                                                            Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtClntTicketFare"
                                                            ValidChars=".-">
                                                        </AjaxToolKit:FilteredTextBoxExtender>
                                                    </div>
                                                    <div class="col-md-2 col-sm-4">
                                                        <label class="col-form-label" for="fullname">SC Type </label>
                                                        <asp:DropDownList ID="ddlProfit" CssClass="form-control" runat="server" Width="100%">
                                                            <asp:ListItem Text="Value" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="%" Value="1"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>

                                                    <div class="col-md-2 col-sm-4">
                                                        <label class="col-form-label" for="fullname">
                                                            SC 1:</label>
                                                        <asp:TextBox CssClass="form-control" ID="txtProfitAmount" runat="server" Width="100%" OnTextChanged="txtProfitAmount_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtProfitAmount" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>--%>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtProfitAmount"
                                                            SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                            ValidationGroup="A"></asp:RegularExpressionValidator>
                                                        <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                                            Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtProfitAmount"
                                                            ValidChars=".-">
                                                        </AjaxToolKit:FilteredTextBoxExtender>
                                                    </div>
                                                    <div class="col-md-2 col-sm-4">
                                                        <label class="col-form-label" for="fullname">
                                                            SC 2 :</label>
                                                        <asp:TextBox CssClass="form-control" ID="txtClntSc2" runat="server" Width="100%" OnTextChanged="txtClntSc2_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server" ControlToValidate="txtClntSc2"
                                                            SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                            ValidationGroup="A"></asp:RegularExpressionValidator>
                                                        <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" runat="server"
                                                            Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtClntSc2"
                                                            ValidChars=".-">
                                                        </AjaxToolKit:FilteredTextBoxExtender>
                                                    </div>

                                                    <div class="col-md-2 col-sm-4">
                                                        <label class="col-form-label" for="fullname">TDS Type :</label>
                                                        <asp:DropDownList ID="ddlclntTds" CssClass="form-control" runat="server" Width="100%">
                                                            <asp:ListItem Text="Value" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="%" Value="1"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="col-md-2 col-sm-4">
                                                        <label class="col-form-label" for="fullname">
                                                            CLNT TDS</label>
                                                        <asp:TextBox CssClass="form-control" ID="txtClntTds" Width="100%" runat="server" OnTextChanged="txtClntTds_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" ControlToValidate="txtClntTds"
                                                            SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                            ValidationGroup="A"></asp:RegularExpressionValidator>
                                                        <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server"
                                                            Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtClntTds"
                                                            ValidChars=".-">
                                                        </AjaxToolKit:FilteredTextBoxExtender>
                                                    </div>

                                                </div>

                                                <div class="form-group row ">
                                                    <div class="col-md-12 col-sm-12">
                                                        <div class="form-group row">
                                                            <div class="col-md-6">
                                                                <div class="col-md-6 col-sm-4">
                                                                    <label class="col-form-label" for="fullname">
                                                                        DISCOUNT :</label>
                                                                    <asp:TextBox CssClass="form-control" ID="txtDiscount" runat="server" Width="100%" OnTextChanged="txtDiscount_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtDiscount"
                                                                        SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                                        ValidationGroup="A"></asp:RegularExpressionValidator>
                                                                    <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                                                        Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtDiscount"
                                                                        ValidChars=".-">
                                                                    </AjaxToolKit:FilteredTextBoxExtender>
                                                                </div>
                                                                <div class="col-md-6 col-sm-3">
                                                                    <label class="col-form-label" for="fullname">
                                                                        OTR CHRG
                                                                    </label>
                                                                    <asp:TextBox CssClass="form-control" ID="txtOtherchrg" runat="server" Width="95%" Placeholder="" OnTextChanged="txtOtherchrg_TextChanged" AutoPostBack="true" placeolder=""></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator15" runat="server" ControlToValidate="txtOtherchrg"
                                                                        SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                                        ValidationGroup="A"></asp:RegularExpressionValidator>
                                                                    <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender12" runat="server"
                                                                        Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtOtherchrg"
                                                                        ValidChars=".-">
                                                                    </AjaxToolKit:FilteredTextBoxExtender>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-6">
                                                                <div class="form-group row">

                                                                    <div class="col-md-4 col-sm-4">
                                                                        <label class="col-form-label" for="fullname">
                                                                            CGST
                                                                        </label>
                                                                        <asp:TextBox CssClass="form-control" ID="txtClntCgst" runat="server" Width="95%" Enabled="false"></asp:TextBox>

                                                                    </div>

                                                                    <div class="col-md-4 col-sm-4">
                                                                        <label class="col-form-label" for="fullname">
                                                                            SGST
                                                                        </label>
                                                                        <asp:TextBox CssClass="form-control" ID="txtClntSgst" runat="server" Width="95%" Enabled="false"></asp:TextBox>

                                                                    </div>
                                                                    <div class="col-md-4 col-sm-4">
                                                                        <label class="col-form-label" for="fullname">
                                                                            IGST
                                                                        </label>
                                                                        <asp:TextBox CssClass="form-control" ID="txtClntIgst" runat="server" Width="100%" Enabled="false"></asp:TextBox>

                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>

                                                    </div>
                                                    <div class="col-md-12 col-sm-12" style="display: none">
                                                        <div class="form-group row">
                                                            <fieldset class="the-fieldset">
                                                                <legend class="the-legend text-black">CLIENT GST</legend>
                                                                <div class="form-group row">

                                                                    <div class="col-md-1 col-sm-4">
                                                                        <label class="col-form-label" for="fullname">
                                                                            TAX
                                                                        </label>
                                                                        <asp:CheckBox ID="chkClntTax" runat="server" Width="100%" Checked="true" AutoPostBack="True" OnCheckedChanged="chkClntTax_CheckedChanged"></asp:CheckBox>

                                                                    </div>

                                                                </div>
                                                            </fieldset>
                                                        </div>
                                                    </div>

                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6 col-sm-12" style="border: 1px solid #e0e0d9;">
                                            <div style="padding: 5px;">
                                                <div class="form-group row">

                                                    <div class="col-md-6 col-sm-4">
                                                        <div class="form-group row">
                                                            <div class="col-md-3 col-sm-6">
                                                                <label class="col-form-label" for="fullname">
                                                                    B FARE</label>
                                                                <asp:TextBox CssClass="form-control" ID="txtFareBasis" runat="server" Width="100%" AutoPostBack="True" OnTextChanged="txtFareBasis_TextChanged"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtFareBasis"
                                                                    SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                                    ValidationGroup="A"></asp:RegularExpressionValidator>
                                                                <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server"
                                                                    Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtFareBasis"
                                                                    ValidChars=".-">
                                                                </AjaxToolKit:FilteredTextBoxExtender>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtFareBasis" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                            </div>
                                                            <div class="col-md-3 col-sm-6">
                                                                <label class="col-form-label" for="fullname">
                                                                    'YQ' 
                                                                </label>
                                                                <asp:TextBox CssClass="form-control" ID="txtYQtax" runat="server" Width="100%" AutoPostBack="True" OnTextChanged="txtYQtax_TextChanged"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server" ControlToValidate="txtYQtax"
                                                                    SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                                    ValidationGroup="A"></asp:RegularExpressionValidator>
                                                                <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server"
                                                                    Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtYQtax"
                                                                    ValidChars=".-">
                                                                </AjaxToolKit:FilteredTextBoxExtender>
                                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtYQtax" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>--%>
                                                            </div>
                                                            <div class="col-md-3 col-sm-6">
                                                                <label class="col-form-label" for="fullname">
                                                                    'YR' 
                                                                </label>
                                                                <asp:TextBox CssClass="form-control" ID="txtYRtax" runat="server" Width="100%" AutoPostBack="True" OnTextChanged="txtYRtax_TextChanged"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator19" runat="server" ControlToValidate="txtYRtax"
                                                                    SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                                    ValidationGroup="A"></asp:RegularExpressionValidator>
                                                                <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender15" runat="server"
                                                                    Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtYRtax"
                                                                    ValidChars=".-">
                                                                </AjaxToolKit:FilteredTextBoxExtender>
                                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtYRtax" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>--%>
                                                            </div>
                                                            <div class="col-md-3 col-sm-4">
                                                                <label class="col-form-label" for="fullname">
                                                                    'K3' 
                                                                </label>
                                                                <asp:TextBox CssClass="form-control" ID="txtK3Tax" runat="server" Width="100%" OnTextChanged="txtK3Tax_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server" ControlToValidate="txtK3Tax"
                                                                    SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                                    ValidationGroup="A"></asp:RegularExpressionValidator>
                                                                <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server"
                                                                    Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtK3Tax"
                                                                    ValidChars=".-">
                                                                </AjaxToolKit:FilteredTextBoxExtender>
                                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtK3Tax" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>--%>
                                                            </div>

                                                        </div>
                                                    </div>
                                                    <div class="col-md-6 col-sm-4">
                                                        <div class="form-group row">
                                                            <div class="col-md-4 col-sm-4">
                                                                <label class="col-form-label" for="fullname">
                                                                    OTR TAX
                                                                </label>
                                                                <asp:TextBox CssClass="form-control" ID="txtOtherTax" runat="server" OnTextChanged="txtOtherTax_TextChanged" AutoPostBack="true" Width="100%"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtOtherTax"
                                                                    SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                                    ValidationGroup="A"></asp:RegularExpressionValidator>
                                                                <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                                                    Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtOtherTax"
                                                                    ValidChars=".-">
                                                                </AjaxToolKit:FilteredTextBoxExtender>
                                                                <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtOtherTax" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>--%>
                                                            </div>
                                                            <div class="col-md-4 col-sm-6">
                                                                <label class="col-form-label" for="fullname">
                                                                    IATA COM
                                                                </label>
                                                                <asp:TextBox CssClass="form-control" ID="txtAirComm" runat="server" Enabled="true" Width="100%" OnTextChanged="txtAirComm_TextChanged"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator28" runat="server" ControlToValidate="txtAirComm"
                                                                    SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                                    ValidationGroup="A"></asp:RegularExpressionValidator>
                                                                <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender25" runat="server"
                                                                    Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtAirComm"
                                                                    ValidChars=".-">
                                                                </AjaxToolKit:FilteredTextBoxExtender>
                                                            </div>
                                                            <div class="col-md-4 col-sm-6">
                                                                <label class="col-form-label" for="fullname">
                                                                    PLB COM
                                                                </label>
                                                                <asp:TextBox CssClass="form-control" ID="txtAirplb" runat="server" Enabled="true" Width="100%" OnTextChanged="txtAirplb_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator29" runat="server" ControlToValidate="txtAirplb"
                                                                    SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                                    ValidationGroup="A"></asp:RegularExpressionValidator>
                                                                <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender26" runat="server"
                                                                    Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtAirplb"
                                                                    ValidChars=".-">
                                                                </AjaxToolKit:FilteredTextBoxExtender>
                                                            </div>
                                                            <%--  <div class="col-md-3 col-sm-4">
                                                                <label class="col-form-label" for="fullname">
                                                                    OC Tax
                                                                </label>
                                                                <asp:TextBox CssClass="form-control" ID="txtOcTax" runat="server"  OnTextChanged="txtOcTax_TextChanged" AutoPostBack="true" Width="100%"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server" ControlToValidate="txtOtherTax"
                                                                    SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                                    ValidationGroup="A"></asp:RegularExpressionValidator>
                                                                <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server"
                                                                    Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtOtherTax"
                                                                    ValidChars=".-">
                                                                </AjaxToolKit:FilteredTextBoxExtender>
                                                            </div>--%>
                                                            <%-- <div class="col-md-4 col-sm-6">

                                                                <label class="col-form-label" for="fullname">
                                                                    Air INC
                                                                </label>
                                                                <asp:TextBox CssClass="form-control" ID="txtAirInc" runat="server" Width="100%" Enabled="true" AutoPostBack="True" OnTextChanged="txtAirInc_TextChanged1"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator30" runat="server" ControlToValidate="txtAirInc"
                                                                    SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                                    ValidationGroup="A"></asp:RegularExpressionValidator>
                                                                <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender27" runat="server"
                                                                    Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtAirInc"
                                                                    ValidChars=".-">
                                                                </AjaxToolKit:FilteredTextBoxExtender>
                                                            </div>--%>
                                                        </div>
                                                    </div>


                                                </div>
                                                <div class="form-group row">
                                                    <div class="col-md-2 col-sm-4">
                                                        <label class="col-form-label" for="fullname">
                                                            TKT COST</label>
                                                        <asp:TextBox CssClass="form-control" ID="txtSupTicketFare" runat="server" Width="100%" OnTextChanged="txtProfitAmount_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator26" runat="server" ControlToValidate="txtSupTicketFare"
                                                            SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                            ValidationGroup="A"></asp:RegularExpressionValidator>
                                                        <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender23" runat="server"
                                                            Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtSupTicketFare"
                                                            ValidChars=".-">
                                                        </AjaxToolKit:FilteredTextBoxExtender>
                                                    </div>
                                                    <div class="col-md-2 col-sm-6">
                                                        <label class="col-form-label" for="fullname">
                                                            SC TYP
                                                        </label>
                                                        <asp:DropDownList ID="ddlSupScType" CssClass="form-control" runat="server" Width="100%">
                                                            <asp:ListItem Value="0" Text="Value"></asp:ListItem>
                                                            <asp:ListItem Value="1" Text="% "></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="col-md-2 col-sm-4">
                                                        <label class="col-form-label" for="fullname">
                                                            SUP SC :</label>
                                                        <asp:TextBox CssClass="form-control" ID="txtSupSc" runat="server" Width="100%" Enabled="true" AutoPostBack="True" OnTextChanged="txtSupSc_TextChanged"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="txtSupSc"
                                                            SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                            ValidationGroup="B"></asp:RegularExpressionValidator>
                                                        <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server"
                                                            Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtSupSc"
                                                            ValidChars=".-">
                                                        </AjaxToolKit:FilteredTextBoxExtender>
                                                    </div>
                                                    <div class="col-md-2 col-sm-6">
                                                        <label class="col-form-label" for="fullname">
                                                            TDS TYP
                                                        </label>
                                                        <asp:DropDownList ID="ddlSupTds" CssClass="form-control" runat="server" Width="100%">
                                                            <asp:ListItem Value="0" Text="Value"></asp:ListItem>
                                                            <asp:ListItem Value="1" Text="% "></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="col-md-2 col-sm-4">
                                                        <label class="col-form-label" for="fullname">
                                                            Sup. TDS</label>
                                                        <asp:TextBox CssClass="form-control" ID="txtSupTds" runat="server" Width="100%" Enabled="true" AutoPostBack="True" OnTextChanged="txtSupSc_TextChanged"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="txtSupTds"
                                                            SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                            ValidationGroup="B"></asp:RegularExpressionValidator>
                                                        <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server"
                                                            Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtSupTds"
                                                            ValidChars=".-">
                                                        </AjaxToolKit:FilteredTextBoxExtender>
                                                    </div>
                                                    <div class="col-md-2 col-sm-4">
                                                        <label class="col-form-label" for="fullname">
                                                            DISCOUNT</label>
                                                        <asp:TextBox CssClass="form-control" ID="txtSupDiscount" runat="server" Width="100%" Enabled="true" AutoPostBack="True" OnTextChanged="txtSupDiscount_TextChanged"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator27" runat="server" ControlToValidate="txtSupDiscount"
                                                            SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                            ValidationGroup="B"></asp:RegularExpressionValidator>
                                                        <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender24" runat="server"
                                                            Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtSupDiscount"
                                                            ValidChars=".-">
                                                        </AjaxToolKit:FilteredTextBoxExtender>
                                                    </div>



                                                </div>
                                                <div class="form-group row">
                                                    <div class="col-md-12">

                                                        <div class="col-md-4 col-sm-4">
                                                            <label class="col-form-label" for="fullname">
                                                                CGST
                                                            </label>
                                                            <asp:TextBox CssClass="form-control" ID="txtsupcgst" runat="server" Width="95%" Enabled="false"></asp:TextBox>

                                                        </div>

                                                        <div class="col-md-4 col-sm-4">
                                                            <label class="col-form-label" for="fullname">
                                                                SGST
                                                            </label>
                                                            <asp:TextBox CssClass="form-control" ID="txtsupsgst" runat="server" Width="95%" Enabled="false"></asp:TextBox>

                                                        </div>
                                                        <div class="col-md-3 col-sm-4">
                                                            <label class="col-form-label" for="fullname">
                                                                IGST
                                                            </label>
                                                            <asp:TextBox CssClass="form-control" ID="txtsupigst" runat="server" Width="95%" Enabled="false"></asp:TextBox>

                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-group row" style="display: none;">
                                                    <div class="col-md-12 col-sm-6">
                                                        <fieldset class="the-fieldset">
                                                            <legend class="the-legend text-black">SUP GST</legend>
                                                            <div class="form-group row m-b-5">

                                                                <div class="col-md-1 col-sm-4">
                                                                    <label class="col-form-label" for="fullname">
                                                                        TAX
                                                                    </label>
                                                                    <asp:CheckBox ID="chkSupTax" runat="server" Width="100%" Checked="true" AutoPostBack="True" OnCheckedChanged="chkSupTax_CheckedChanged"></asp:CheckBox>

                                                                </div>

                                                            </div>
                                                        </fieldset>
                                                    </div>
                                                    <%--<div class="col-md-6 col-sm-6">
                                                        <fieldset class="the-fieldset">
                                                            <legend class="the-legend text-black">Air GST</legend>
                                                            <div class="form-group row m-b-5">

                                                                <div class="col-md-1 col-sm-4">
                                                                    <label class="col-form-label" for="fullname">
                                                                        Tax
                                                                    </label>
                                                                    <asp:CheckBox ID="chkAirTax" runat="server" Width="100%" Checked="true" AutoPostBack="True" OnCheckedChanged="chkSupTax_CheckedChanged"></asp:CheckBox>

                                                                </div>

                                                                <div class="col-md-4 col-sm-4">
                                                                    <label class="col-form-label" for="fullname">
                                                                        CGST
                                                                    </label>
                                                                    <asp:TextBox CssClass="form-control" ID="txtAircgst" runat="server" Width="95%"  Enabled="false"></asp:TextBox>

                                                                </div>

                                                                <div class="col-md-4 col-sm-4">
                                                                    <label class="col-form-label" for="fullname">
                                                                        SGST
                                                                    </label>
                                                                    <asp:TextBox CssClass="form-control" ID="txtAirsgst" runat="server" Width="95%"  Enabled="false"></asp:TextBox>

                                                                </div>
                                                                <div class="col-md-3 col-sm-4">
                                                                    <label class="col-form-label" for="fullname">
                                                                        IGST
                                                                    </label>
                                                                    <asp:TextBox CssClass="form-control" ID="txtAirIgst" runat="server"  Width="95%" Enabled="false"></asp:TextBox>

                                                                </div>
                                                            </div>
                                                        </fieldset>
                                                    </div>--%>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-4 col-sm-4">
                                                    </div>
                                                    <div class="col-md-4 col-sm-4 text-center">
                                                    </div>
                                                    <div class="col-md-4 col-sm-4">
                                                    </div>

                                                </div>
                                            </div>
                                        </div>


                                    </div>
                                    <div class="form-group row m-b-0" style="padding: 10px;" id="tblrefund" runat="server" visible="false">
                                        <fieldset class="the-fieldset">
                                            <legend class="the-legend text-black text-center font-weight-bold">REFUND</legend>
                                            <div class="row">
                                                <div class="col-md-6 col-sm-6">

                                                    <div class="form-group row m-b-5">
                                                        <div class="col-md-4 col-sm-4">
                                                            <label class="col-form-label" for="fullname">
                                                                Refund Date
                                                            </label>
                                                            <asp:TextBox ID="txtdtRfnDate" runat="server" Width="95%" Enabled="true" CssClass="datepicker form-control"></asp:TextBox>
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
                                                            <asp:TextBox CssClass="form-control" ID="txtRefundAmt" runat="server" Width="95%" Enabled="true" AutoPostBack="True" OnTextChanged="txtRefundAmt_TextChanged"></asp:TextBox>
                                                        </div>
                                                        <div class="col-md-4 col-sm-4">
                                                            <label class="col-form-label" for="fullname">
                                                                Rfn. SC
                                                            </label>
                                                            <asp:TextBox CssClass="form-control" ID="txtrfnSC" runat="server" Width="95%" Enabled="true" AutoPostBack="True" OnTextChanged="txtrfnSC_TextChanged"></asp:TextBox>

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
                                                                        <asp:TextBox CssClass="form-control" ID="txtRfnCGst" runat="server" Width="95%" Enabled="false"></asp:TextBox>

                                                                    </div>

                                                                    <div class="col-md-4 col-sm-4">
                                                                        <label class="col-form-label" for="fullname">
                                                                            SGST
                                                                        </label>
                                                                        <asp:TextBox CssClass="form-control" ID="txtRfnSGst" runat="server" Width="95%" Enabled="false"></asp:TextBox>

                                                                    </div>
                                                                    <div class="col-md-3 col-sm-4">
                                                                        <label class="col-form-label" for="fullname">
                                                                            IGST
                                                                        </label>
                                                                        <asp:TextBox CssClass="form-control" ID="txtRfnIGst" runat="server" Width="95%" Enabled="false"></asp:TextBox>

                                                                    </div>
                                                                </div>
                                                            </fieldset>
                                                        </div>
                                                    </div>

                                                </div>
                                            </div>
                                        </fieldset>
                                    </div>

                                    <div class="form-group row m-b-0" style="text-align: center; padding: 10px;">
                                        <div class="col-md-6 col-sm-12 text-center">

                                            <label class="col-form-label text-center" for="fullname">
                                                Client Cost 
                                            </label>
                                            <asp:Label ID="lblClientCost" runat="server" Visible="false"></asp:Label>
                                            <asp:TextBox ID="txtTotal" runat="server" Enabled="false" Width="40%" CssClass="btn" BackColor="#003366" ForeColor="White"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtTotal"
                                                SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                ValidationGroup="A"></asp:RegularExpressionValidator>
                                            <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                                Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtTotal"
                                                ValidChars=".-">
                                            </AjaxToolKit:FilteredTextBoxExtender>
                                        </div>
                                        <div class="col-md-6 col-sm-12 text-center">
                                            <label class="col-form-label text-center" for="fullname">
                                                Supplier Cost</label>
                                            <asp:Label ID="lblSupCost" runat="server" Visible="false"></asp:Label>
                                            <asp:TextBox ID="txtCost" runat="server" Width="40%" Enabled="false" CssClass="btn" BackColor="#003366" ForeColor="White"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="REV34" runat="server" ControlToValidate="txtCost"
                                                SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                ValidationGroup="A"></asp:RegularExpressionValidator>
                                            <AjaxToolKit:FilteredTextBoxExtender ID="FTBE34" runat="server"
                                                Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtCost"
                                                ValidChars=".-">
                                            </AjaxToolKit:FilteredTextBoxExtender>

                                        </div>

                                    </div>

                                    <!-- not need -->
                                    <div class="form-group row m-b-0" style="text-align: center; padding-top: 0px;">



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

                                    <!-- not need -->
                                    <asp:Panel class="tbl table-responsive" ID="tblGridDet" runat="server" Style="margin-top: 20px; margin-bottom: 20px;">


                                        <asp:GridView ID="GridView2" CssClass="table table-striped table-bordered" runat="server" AutoGenerateColumns="False"
                                            DataKeyNames="nTicketingDetID" Width="100%" AllowPaging="false" AllowSorting="True" EmptyDataText="No Records to display"
                                            OnPageIndexChanging="GridView2_PageIndexChanging">
                                            <Columns>
                                                <asp:TemplateField HeaderText="nTicketingDetID" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblIDDet" runat="server" Text='<%# Eval("nTicketingDetID") %>'></asp:Label>
                                                        <asp:Label ID="lblBookType" runat="server" Text='<%# Eval("sTicketTypeDet") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="sTicketTypeDet" HeaderText="Book Type" />
                                                <asp:BoundField DataField="sPaxType" HeaderText="Pax Type" />
                                                <asp:BoundField DataField="sCustomerName" HeaderText="Pax Name" />
                                                <asp:BoundField DataField="sSector" HeaderText="Sector" />
                                                <asp:BoundField DataField="nBuyRate" HeaderText="Buy Cost" />

                                                <asp:BoundField DataField="nSellingCost" HeaderText="Selling Cost" />

                                                <asp:BoundField DataField="sRemarks" HeaderText="Remarks" />
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

                            </asp:Panel>
                            <!-- not need -->
                            <asp:Panel class="tbl table-responsive" ID="tblGrd" runat="server">
                                <div style="border: 1px solid #e0e0d9; padding: 10px; margin-top: 20px;">
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
                                                <asp:ListItem Text="Select Ticket Type" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="DOM" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="INT" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="BSP" Value="3"></asp:ListItem>

                                                <asp:ListItem Text="Void" Value="5"></asp:ListItem>

                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-md-2 col-sm-2" style="z-index: 99">
                                            <label class="col-form-label" for="fullname">
                                                Invoice Date :</label>
                                            <asp:TextBox ID="txtSdtBooking" runat="server" CssClass="form-control datepicker" placeholder="dd/MM/yyyy" Width="100%"></asp:TextBox>
                                            <AjaxToolKit:CalendarExtender ID="CalendarExtender5" runat="server" Format="dd/MM/yyyy"
                                                PopupButtonID="txtSdtBooking" TargetControlID="txtSdtBooking" PopupPosition="BottomLeft" />

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
                                            <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-primary" Text="Search" ValidationGroup="A"
                                                ToolTip="Search" OnClick="btnSearch_Click" />
                                        </div>
                                    </div>
                                </div>
                                <asp:Label ID="lblpgs" runat="server" Text="Page Size :"></asp:Label>
                                <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:GridView ID="GridView1" CssClass="table table-striped table-bordered" runat="server"
                                    AutoGenerateColumns="False" EmptyDataText="No Records to display" DataKeyNames="nTicketingID"
                                    Width="100%" AllowPaging="true" AllowSorting="True" PageSize="25">
                                    <Columns>
                                        <asp:TemplateField HeaderText="nTicketingID" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblID" runat="server" Text='<%# Eval("nTicketingID") %>'></asp:Label>
                                                <asp:Label ID="lblBookType" runat="server" Text='<%# Eval("sTicketType") %>'></asp:Label>
                                                <asp:Label ID="lblAgentID" runat="server" Text='<%# Eval("nAgentID") %>'></asp:Label>
                                                <asp:Label ID="lblBalance" runat="server" Text='<%# Eval("nBalance") %>'></asp:Label>
                                                <asp:Label ID="lblInvoiceNo" runat="server" Text='<%# Eval("sTicketBookingNo") %>'></asp:Label>
                                                <asp:Label ID="lblInvoiceDate" runat="server" Text='<%# Eval("dtBooking") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="sTicketType" HeaderText="Ticket Type" />
                                        <asp:BoundField DataField="sTicketBookingNo" HeaderText="Invoice No." />
                                        <asp:TemplateField HeaderText="Invoice Date">
                                            <ItemTemplate>
                                                <%#validation.TextToDate(Eval("dtBooking").ToString())%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="sAgentName" HeaderText="Agent Name" />
                                        <asp:BoundField DataField="sTicCompanyBuy" HeaderText="Supplier" />
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
                                                <br />
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
                            <!-- not need -->
                            <asp:Panel ID="PnlPayment" runat="server">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h4 class="modal-title">Air Tickets Payment</h4>
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
                                            <asp:TextBox ID="txtdtpayment" runat="server" Width="100%" TextMode="SingleLine" CssClass="form-control datepicker" placeholder="DD/MM/YYYY" OnTextChanged="txtdtpayment_TextChanged" AutoPostBack="true"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtdtpayment" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                                            <%--<AjaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy"
                                                PopupButtonID="txtdtpayment" TargetControlID="txtdtpayment" PopupPosition="BottomLeft" />--%>
                                            <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender1" runat="server"
                                                TargetControlID="txtdtpayment" Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator31" ControlToValidate="txtdtpayment"
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
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="ddlPayVoucherType" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="P"></asp:RequiredFieldValidator>
                                        </div>

                                        <div class="col-md-2 col-sm-3">
                                            <h5>Payment Account</h5>
                                            <asp:DropDownList ID="ddlPaymentAccount" runat="server" Width="100%">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="ddlPaymentAccount" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="P"></asp:RequiredFieldValidator>
                                        </div>

                                        <div class="col-md-3 col-sm-3">
                                            <h5>Amount</h5>
                                            <asp:TextBox ID="txtPayAmount" runat="server" Width="100%"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator32" runat="server" ControlToValidate="txtPayAmount"
                                                SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"></asp:RegularExpressionValidator>
                                            <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender28" runat="server"
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
                                                            <asp:Label ID="lblTicketID" runat="server" Text='<%# Eval("nInvoiceID") %>'></asp:Label>
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
                <!-- end row -->
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:HiddenField runat="server" ID="hfPosition" Value="" />
<script type="text/javascript">
    $(function () {
        var f = $("#<%=hfPosition.ClientID%>");
        window.onload = function () {
            var position = parseInt(f.val());
            if (!isNaN(position)) {
                $(window).scrollTop(position);
            }
        };
        window.onscroll = function () {
            var position = $(window).scrollTop();
            f.val(position);
        };
    });
</script>

</asp:Content>
