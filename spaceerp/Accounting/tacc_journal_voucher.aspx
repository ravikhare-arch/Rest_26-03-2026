<%@ Page Title="Account Journal" Language="C#" MasterPageFile="~/Pagecontent.master" AutoEventWireup="true" CodeFile="tacc_journal_voucher.aspx.cs" Inherits="Transcation_acc_journal_voucher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
   <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
    <link type="text/css" rel="stylesheet" href="../assets/css/default/mystyle.css" />
    <link href="../assets/css/default/style.min.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.3/umd/popper.min.js" integrity="sha384-vFJXuSJphROIrBnz7yo7oB41mKfc8JzQZiCq4NCceLEaO4IHwicKwpJf9c9IpFgh" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta.2/js/bootstrap.min.js" integrity="sha384-alpBpkh1PFOepccYVYDB4do5UnbKysX5WZXm3XxPqe5iKTfUKjNkCk9SaVuEZflJ" crossorigin="anonymous"></script>
     
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 <asp:Label ID="lblmsg" runat="server" style="display:none"></asp:Label>
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
                            <asp:LinkButton ID="lnkAdd" runat="server" OnClick="lnkAdd_Click" CssClass="btn btn-info btn-xs">ADD</asp:LinkButton>
                            <asp:LinkButton ID="lnkList" runat="server" OnClick="lnkList_Click" CssClass="btn btn-info btn-xs">LIST</asp:LinkButton>
                        </div>
                        <div class="panel-heading-btn">
                            <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                            <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                        </div>
                        <h4 class="panel-title text-center">JOURNAL VOUCHER</h4>
                    </div>
                    <!-- end panel-heading -->
                    <!-- begin panel-body -->
                    <div class="panel-body">
                        <div>

                            <div class="form-group row m-b-5">

                                <div class="col-md-2 col-sm-3">
                                    <asp:UpdatePanel ID="up1" runat="server">
                                        <ContentTemplate>


                                            <label class="col-form-label" for="email">Journal Voucher No * :</label>
                                            <asp:TextBox ID="txtJournalVoucherNo" CssClass="form-control" runat="server" Width="100%" Enabled="false"></asp:TextBox>

                                            <asp:RequiredFieldValidator ID="RFV1" runat="server" ControlToValidate="txtJournalVoucherNo" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="col-md-2 col-sm-3">
                                    <label class="col-form-label" for="email">Voucher Type * :</label>
                                    <asp:DropDownList ID="ddlVoucherTypeID" CssClass="form-control" runat="server" Width="100%">
                                        <asp:ListItem Text="Select Voucher Type" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Journal Voucher" Value="1"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RFV2" runat="server" ControlToValidate="ddlVoucherTypeID" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-2 col-sm-3">
                                    <label class="col-form-label" for="email">Voucher Date * :</label>
                                    <asp:TextBox ID="txttJournalVoucher" CssClass="form-control" runat="server" Width="100%" OnTextChanged="txttJournalVoucher_TextChanged" AutoPostBack="true"></asp:TextBox>


                                    <AjaxToolKit:MaskedEditExtender ID="MEE3" runat="server"
                                        TargetControlID="txttJournalVoucher" Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                    <asp:RegularExpressionValidator ID="REV3" ControlToValidate="txttJournalVoucher"
                                        ValidationGroup="A" Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                    </asp:RegularExpressionValidator>
                                    <AjaxToolKit:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd/MM/yyyy"
                                        PopupButtonID="txttJournalVoucher" TargetControlID="txttJournalVoucher" PopupPosition="TopLeft" />
                                    <asp:RequiredFieldValidator ID="RFV3" runat="server" ControlToValidate="txttJournalVoucher" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-2 col-sm-3">
                                    <label class="col-form-label" for="email">Account Type (Debtor)* :</label>
                                    <asp:DropDownList ID="ddlAccountType" runat="server" CssClass="form-control js-example-placeholder-single">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlAccountType" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-2 col-sm-3">
                                    <label class="col-form-label" for="email">Posted by * :</label>
                                    <asp:TextBox ID="txtPostedby" CssClass="form-control" runat="server" Width="100%" Enabled="false"></asp:TextBox>
                                </div>
                                <%--<div class="col-md-3 col-sm-3">
                                    <label class="col-form-label" for="email">Amended by * :</label>
                                    <asp:TextBox ID="txtAmendedby" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>--%>
                                <div class="col-md-2 col-sm-3">
                                    <label class="col-form-label" for="email">Location :</label>
                                    <asp:DropDownList ID="ddlLocation" CssClass="form-control" runat="server" Width="100%"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlLocation" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <%--<div class="form-group row m-b-0">
                            <div class="col-md-12 col-sm-12" style="text-align:center;">
                                
                                <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-primary" Text="Update" ValidationGroup="A" OnClick="btnUpdate_Click" ToolTip="Update" />
                                <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-primary" Text="Delete" OnClick="btnDelete_Click" ToolTip="Delete" />
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
                        </div>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <div>

                                    <div class="form-group row m-b-15">
                                        <div class="col-md-3 col-sm-3">
                                            <label class="col-form-label">Account Title(Creditor) * :</label>
                                            <asp:DropDownList ID="ddlAccountCodeID" runat="server" CssClass="form-control js-example-placeholder-single" AutoPostBack="true" OnSelectedIndexChanged="ddlAccountCodeID_SelectedIndexChanged"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlAccountCodeID" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                                            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Account Type not same as Account Title" Display="Dynamic" ControlToValidate="ddlAccountCodeID" ValidationGroup="A" ControlToCompare="ddlAccountType" Operator="NotEqual" ForeColor="Red"></asp:CompareValidator>

                                        </div>
                                        <%--<div class="col-md-3 col-sm-3">
                                    <label class="col-form-label">Account Title * :</label>
                                    <asp:TextBox ID="txtAccountTitle" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtAccountTitle" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                                </div>--%>
                                        <div class="col-md-2 col-sm-3">
                                            <label class="col-form-label">Balance  * :</label>
                                            <asp:TextBox ID="txtBalance" CssClass="form-control" runat="server" Width="100%" Enabled="False"></asp:TextBox>
                                        </div>
                                        <div class="col-md-2 col-sm-3">
                                            <label class="col-form-label">Job No.</label>
                                            <asp:DropDownList ID="ddlJobID" CssClass="form-control" runat="server" Width="100%"></asp:DropDownList>
                                        </div>
                                        <div class="col-md-3 col-sm-3">
                                            <label class="col-form-label">Currency</label>
                                            <asp:DropDownList ID="ddlCurrencyID" CssClass="form-control" runat="server" Width="100%" OnSelectedIndexChanged="ddlCurrencyID_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RFV6" runat="server" ControlToValidate="ddlCurrencyID" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-md-2 col-sm-3">
                                            <label class="col-form-label">Rate</label>
                                            <asp:TextBox ID="txtRate" CssClass="form-control" runat="server" Width="100%" AutoPostBack="True" OnTextChanged="txtRate_TextChanged"></asp:TextBox><asp:RegularExpressionValidator ID="REV7" runat="server" ControlToValidate="txtRate"
                                                SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                ValidationGroup="A"></asp:RegularExpressionValidator>
                                            <AjaxToolKit:FilteredTextBoxExtender ID="FTBE7" runat="server"
                                                Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtRate"
                                                ValidChars=".-">
                                            </AjaxToolKit:FilteredTextBoxExtender>
                                            <asp:RequiredFieldValidator ID="RFV7" runat="server" ControlToValidate="txtRate" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                    <div class="form-group row m-b-15">
                                        <div class="col-md-3 col-sm-3">
                                            <label class="col-form-label">Amount</label>
                                            <asp:TextBox ID="txtAmount" CssClass="form-control" runat="server" Width="100%" AutoPostBack="true" OnTextChanged="txtAmount_TextChanged"></asp:TextBox><asp:RegularExpressionValidator ID="REV8" runat="server" ControlToValidate="txtAmount"
                                                SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                ValidationGroup="A"></asp:RegularExpressionValidator>
                                            <AjaxToolKit:FilteredTextBoxExtender ID="FTBE8" runat="server"
                                                Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtAmount"
                                                ValidChars=".-">
                                            </AjaxToolKit:FilteredTextBoxExtender>
                                            <asp:RequiredFieldValidator ID="RFV8" runat="server" ControlToValidate="txtAmount" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-md-3 col-sm-3">
                                            <label class="col-form-label">Local Amount</label>
                                            <asp:TextBox ID="txtLocalAmount" CssClass="form-control" runat="server" Width="100%" Enabled="false"></asp:TextBox><asp:RegularExpressionValidator ID="REV9" runat="server" ControlToValidate="txtLocalAmount"
                                                SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                ValidationGroup="A"></asp:RegularExpressionValidator>
                                            <AjaxToolKit:FilteredTextBoxExtender ID="FTBE9" runat="server"
                                                Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtLocalAmount"
                                                ValidChars=".-">
                                            </AjaxToolKit:FilteredTextBoxExtender>
                                            <asp:RequiredFieldValidator ID="RFV9" runat="server" ControlToValidate="txtLocalAmount" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                                        </div>

                                        <div class="col-md-3 col-sm-3">
                                            <label class="col-form-label">Description  * :</label>
                                            <asp:TextBox ID="txtDescription" CssClass="form-control" runat="server" Width="100%"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RFV5" runat="server" ControlToValidate="txtDescription" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-md-3 col-sm-3">
                                            <label class="col-form-label">Remarks.</label>
                                            <asp:TextBox ID="txtRemarks" CssClass="form-control" runat="server" Width="100%"></asp:TextBox>
                                        </div>

                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <div class="form-group row m-b-15">
                            <div class="col-md-12 col-sm-12" style="text-align: center; padding: 10px;">
                                <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary btnspl" Text="Add" ValidationGroup="A" OnClick="btnAdd_Click" ToolTip="Add" />

                                <asp:Button ID="btnAddDet" runat="server" CssClass="btn btn-primary" Text="Add" ValidationGroup="A" OnClick="btnAddDet_Click" ToolTip="Add" />
                                <asp:Button ID="btnUpdateDet" runat="server" CssClass="btn btn-primary" Text="Update" ValidationGroup="A" OnClick="btnUpdateDet_Click" ToolTip="Update" />
                                <asp:Button ID="btnPrint" runat="server" CssClass="btn btn-primary" Text="Print" OnClick="btnPrint_Click" ToolTip="Print" Visible="false" />
                                <%-- <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-primary" Text="Delete"
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
                                </asp:Panel>--%>
                            </div>
                        </div>

                        <asp:Panel class="tbl table-responsive" ID="tblGridDet" runat="server" Style="margin-top: 20px;">

                            <asp:Label ID="lblpgsDet" runat="server" Text="Page Size :"></asp:Label>
                            <asp:DropDownList ID="ddlPageSizeDet" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPageSizeDet_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:GridView ID="GridView2" CssClass="table table-hover m-b-0 text-inverse" runat="server" AutoGenerateColumns="False"
                                DataKeyNames="nJournalVoucherDetID" Width="100%" AllowPaging="false" AllowSorting="True" EmptyDataText="No Records to display"
                                OnPageIndexChanging="GridView2_PageIndexChanging">
                                <Columns>
                                    <asp:TemplateField HeaderText="nJournalVoucherDetID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDetID" runat="server" Text='<%# Eval("nJournalVoucherDetID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="sAccountTitle" HeaderText="Account Title" />
                                    <asp:BoundField DataField="sDescription" HeaderText="Description" />
                                    <asp:BoundField DataField="sCurrency" HeaderText="Currency" />
                                    <asp:BoundField DataField="nLocalAmount" HeaderText="Amount" />
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
                    </div>
                    <!-- end panel-body -->

                </div>
                <!-- end panel -->
            </div>
            <!-- end col-6 -->

        </div>
        <!-- end row -->
    </asp:Panel>

    <asp:Panel CssClass="tbl table-responsive" ID="tblGrd" runat="server">
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
                        <h4 class="panel-title">Payment Voucher Details</h4>
                    </div>
                    <!-- end panel-heading -->
                    <!-- begin panel-body -->
                    <div class="panel-body">
                        
            <div class="col-md-12 ml-auto mr-auto" >
                                        <div class="clearfix form-group">  
                                            <div class="col-md-3">
                                    <label>Agency Name</label>
                                    <asp:TextBox ID="txtAName" placeHolder="Agency Name" AutoComplete="off" CssClass="form-control" runat="server" ></asp:TextBox>

                                </div>                                                                                 
                                            <div class="col-md-3">
                                                <label for="form-1-3" class="control-label">Agent ID</label>
                                                     <asp:TextBox ID="txtagentname" placeholder="Agent Name" runat="server" CssClass="search_filter form-control" autocomplete="off"></asp:TextBox>
                               
                                            </div>
                                            <div class="col-md-2">
                                                <label for="form-1-3" class="control-label">From Date</label>
                                                <div class="timepicker-input" >
                                                     <asp:TextBox ID="txttLastPurchase" CssClass="form-control" runat="server" Width="100%" placeholder="dd/mm/yyyy"></asp:TextBox>
                                                <AjaxToolKit:CalendarExtender ID="CalendarExtender18" runat="server" Format="dd/MM/yyyy"
                                                    PopupButtonID="txttLastPurchase" TargetControlID="txttLastPurchase" PopupPosition="TopLeft" />
                                                <AjaxToolKit:MaskedEditExtender ID="MEE18" runat="server" TargetControlID="txttLastPurchase"
                                                    Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                                <asp:RegularExpressionValidator ID="REV18" ControlToValidate="txttLastPurchase" ValidationGroup="A"
                                                    Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                                    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                                </asp:RegularExpressionValidator>
                                                </div>
                                            </div>
                                             <div class="col-md-2">
                                                <label for="form-1-3" class="control-label">To Date</label>                                  
                                    <div class="timepicker-input">
                                        <asp:TextBox ID="txttLastOrder" CssClass="form-control" runat="server" Width="100%" placeholder="dd/mm/yyyy"></asp:TextBox>
                                                <AjaxToolKit:CalendarExtender ID="CalendarExtender19" runat="server" Format="dd/MM/yyyy"
                                                    PopupButtonID="txttLastOrder" TargetControlID="txttLastOrder" PopupPosition="TopLeft" />
                                                <AjaxToolKit:MaskedEditExtender ID="MEE19" runat="server" TargetControlID="txttLastOrder"
                                                    Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                                <asp:RegularExpressionValidator ID="REV19" ControlToValidate="txttLastOrder" ValidationGroup="A"
                                                    Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                                    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                                </asp:RegularExpressionValidator>
                                    </div>
                                            </div>
                                            <div class="col-md-2">
                                                <label>&nbsp;</label>
                                                 <input type="button" name="BtnHotelSearch" value="Search" id="BtnSearch" class="btn btn-primary form-control no-mrg-btm"  />
                                                 
                                            </div>
                                        </div>
                                        
                                    </div>
            <div class=" col-md-12 text-center pb-10">
                    <br />
                  
              <%--<asp:UpdatePanel runat="server" ID="upl">
                  <ContentTemplate>--%>
                       <asp:Button ID="Button1" CssClass="btn btn-primary" runat="server" Text="Export To Excel" />
               <asp:Button ID="Button2" CssClass="btn btn-primary" runat="server" Text="Export To PDF"  />
               <asp:Button ID="Button3" CssClass="btn btn-primary" runat="server" Text="Print" Visible="false"/>
                   <asp:Button ID="Button4" CssClass="btn btn-primary" runat="server" Text="Send Mail" />            
             
                                          </div>
                        <div class="form-group row m-b-15" style="display:none">
                            <div class="col-md-3 col-sm-3">

                                <label class="col-form-label" for="email">Voucher No * :</label>

                                <asp:DropDownList ID="ddlVoucherNoS" runat="server" CssClass="form-control js-example-placeholder-single">
                                </asp:DropDownList>
                            </div>

                            <div class="col-md-3 col-sm-3" style="z-index: 999;">
                                <label class="col-form-label" for="email">From Date * :</label>
                                <div class="input-group">

                                    <div class="input-group-addon">
                                        <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/assets/img/Calendar-icon.png" Width="16" Height="16" />
                                    </div>
                                    <asp:TextBox ID="txtdtFrom" runat="server" CssClass="form-control"></asp:TextBox>

                                    <asp:RegularExpressionValidator ID="REV4" ControlToValidate="txtdtFrom"
                                        ValidationGroup="A" Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                    </asp:RegularExpressionValidator>
                                    <AjaxToolKit:CalendarExtender ID="CalendarExtender5" runat="server" Format="dd/MM/yyyy"
                                        PopupButtonID="ImageButton3" TargetControlID="txtdtFrom" PopupPosition="BottomRight" />

                                    <AjaxToolKit:MaskedEditExtender ID="MEE4" runat="server"
                                        TargetControlID="txtdtFrom" Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                </div>
                            </div>

                            <div class="col-md-3 col-sm-3" style="z-index: 999999;">
                                <label class="col-form-label" for="email">To Date * :</label>
                                <div class="input-group">

                                    <div class="input-group-addon">
                                        <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/assets/img/Calendar-icon.png" Width="16" Height="16" />
                                    </div>
                                    <asp:TextBox ID="txtdtTo" runat="server" CssClass="form-control"></asp:TextBox>

                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtdtTo"
                                        ValidationGroup="A" Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                    </asp:RegularExpressionValidator>
                                    <AjaxToolKit:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy"
                                        PopupButtonID="ImageButton4" TargetControlID="txtdtTo" PopupPosition="BottomRight" />

                                    <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender2" runat="server"
                                        TargetControlID="txtdtTo" Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                </div>
                            </div>
                            <div class="col-md-3 col-sm-3">
                                <label class="col-form-label" for="email">Search :</label><br />
                                <asp:Button ID="btnSearch" Text="Search" runat="server" OnClick="btnSearch_Click" CssClass="btn btn-primary" ToolTip="Search" ValidationGroup="B" />
                            </div>
                        </div>
                        <div class="form-group row m-b-15">
                            <div class="col-md-12 col-sm-12">
                                <asp:Label ID="lblpgs" runat="server" Text="Page Size :"></asp:Label>
                                <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:GridView ID="GridView1" CssClass="table table-hover m-b-0 text-inverse" runat="server" AutoGenerateColumns="False"
                                    DataKeyNames="nJournalVoucerID" Width="100%" AllowPaging="true" AllowSorting="True" PageSize="25" EmptyDataText="No Records to display"
                                    OnPageIndexChanging="GridView1_PageIndexChanging">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Voucher date" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblID" runat="server" Text='<%# Eval("nJournalVoucerID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Voucher Date">
                                            <ItemTemplate>
                                                <%#validation.TextToDate(Eval("dtJournalVoucher").ToString())%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="sJournalVoucherNo" HeaderText="Voucher No" />
                                        <asp:BoundField DataField="sVoucherType" HeaderText="Voucher Type" />
                                        <asp:BoundField DataField="sPostedby" HeaderText="Postedby" />
                                        <asp:BoundField DataField="sAmendedby" HeaderText="Amendedby" />
                                        <asp:BoundField DataField="TotAmount" HeaderText="Voucher Amount" />
                                        <asp:TemplateField HeaderText="Edit/Delete">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btngdEdit" runat="server" OnClick="btngdEdit_Click" ToolTip="Edit">
                           <i class="far fa-lg fa-fw m-r-10 fa-edit fa-grid-edit"></i> <span class="text-inverse">Edit</span>
                                                </asp:LinkButton>
                                                <asp:LinkButton ID="btngdPrint" runat="server" OnClick="btngdPrint_Click" ToolTip="Print">
                           <i class="fas fa-lg fa-fw m-r-10 fa-print fa-grid-edit"></i> <span class="text-inverse">Print</span>
                                                </asp:LinkButton>
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
                            </div>
                        </div>
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
