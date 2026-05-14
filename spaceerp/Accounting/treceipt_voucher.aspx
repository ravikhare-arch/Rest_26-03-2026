<%@ Page Title="Receipt Voucher" Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="treceipt_voucher.aspx.cs" Inherits="Transcation_receipt_voucher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="vmsg" runat="Server">

    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <asp:Label ID="lblmsg" runat="server"></asp:Label>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="vtitle" runat="Server">
    Receipt Voucher
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   

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

                    <h4 class="panel-title text-center">RECEIPT VOUCHER </h4>
                </div>
                <!-- end panel-heading -->
                <!-- begin panel-body -->
                <div class="panel-body">
                    <asp:Panel CssClass="tbl" ID="tblmain" runat="server">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <div style="border: 1px solid #e0e0d9; padding: 5px; margin-top: 10px;">

                                    <div class="form-group row m-b-5">

                                        <div class="col-md-2 col-sm-3">
                                            <asp:UpdatePanel ID="up1" runat="server">
                                                <ContentTemplate>


                                                    <label class="col-form-label" for="email">Voucher No * :</label>
                                                    <asp:TextBox ID="txtReceiptVoucherNo" runat="server" Width="100%" Enabled="false"></asp:TextBox>

                                                    <asp:RequiredFieldValidator ID="RFV1" runat="server" ControlToValidate="txtReceiptVoucherNo" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                        
                                        <div class="col-md-2 col-sm-2" style="z-index:99">
                                            <label class="col-form-label" for="email">Voucher Date * :</label>
                                            <asp:TextBox ID="txttReceiptVoucher" runat="server" Width="100%" OnTextChanged="txttReceiptVoucher_TextChanged" AutoPostBack="true"></asp:TextBox>


                                            <AjaxToolKit:MaskedEditExtender ID="MEE3" runat="server"
                                                TargetControlID="txttReceiptVoucher" Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                            <asp:RegularExpressionValidator ID="REV3" ControlToValidate="txttReceiptVoucher"
                                                ValidationGroup="A" Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                                ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                            </asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator ID="RFV3" runat="server" ControlToValidate="txttReceiptVoucher" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                                            <AjaxToolKit:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd/MM/yyyy"
                                                PopupButtonID="txttReceiptVoucher" TargetControlID="txttReceiptVoucher" PopupPosition="BottomLeft" />
                                        </div>
                                         
                                        <div class="col-md-2 col-sm-3">
                                            <label class="col-form-label" for="email">Voucher Type * :</label>
                                            <asp:DropDownList ID="ddlVoucherTypeID" runat="server" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="ddlVoucherTypeID_SelectedIndexChanged">
                                                <asp:ListItem Text="Select Voucher Type" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="Cash Receipt" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Bank Receipt" Value="2"></asp:ListItem>

                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RFV2" runat="server" ControlToValidate="ddlVoucherTypeID" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                                        </div>
                                       
                                        <div class="col-md-2 col-sm-3">
                                            <label class="col-form-label" for="email">Account Type:</label>
                                            <asp:DropDownList ID="ddlAccountTypeID" runat="server" Width="100%">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlAccountTypeID" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                                        </div>

                                    

                                   <%-- <div class="form-group row m-b-15">
                                        <div class="col-md-3 col-sm-3">
                                            <label class="col-form-label" for="email">Status :</label>
                                            <asp:DropDownList ID="ddlStatusID" runat="server" Width="100%">

                                                <asp:ListItem Text="Select Voucher Type" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="New Voucher" Value="1"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>--%>
                                        <div class="col-md-2 col-sm-3">
                                            <label class="col-form-label" for="email">Posted by * :</label>
                                            <asp:TextBox ID="txtPostedby" runat="server" Width="100%" Enabled="false"></asp:TextBox>
                                        </div>
                                       <%-- <div class="col-md-3 col-sm-3">
                                            <label class="col-form-label" for="email">Amended by * :</label>
                                            <asp:TextBox ID="txtAmendedby" runat="server" Width="100%" Enabled="false"></asp:TextBox>
                                        </div>--%>
                                        <div class="col-md-2 col-sm-3">
                                            <label class="col-form-label" for="email">Location :</label>
                                            <asp:DropDownList ID="ddlLocation" runat="server" CssClass="form-control js-example-placeholder-single" Width="100%"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlLocation" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                </div>

                                <div style="border: 1px solid #e0e0d9; padding: 5px; margin-top:10px;">
                                    <div class="form-group row m-b-5">
                                        <div class="col-md-4 col-sm-6">
                                            <label class="col-form-label">Accounts Title * :</label>
                                            <asp:DropDownList ID="ddlAccountCodeID" runat="server" CssClass="form-control js-example-placeholder-single" AutoPostBack="True" OnSelectedIndexChanged="ddlAccountCodeID_SelectedIndexChanged"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlAccountCodeID" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                                            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Account Type not same as Account Title" Display="Dynamic" ControlToValidate="ddlAccountCodeID" ValidationGroup="A" ControlToCompare="ddlAccountTypeID" Operator="NotEqual" ForeColor="Red"></asp:CompareValidator>
                                        </div>
                                        <%--<div class="col-md-4 col-sm-4">
                                    <label class="col-form-label">Account Title * :</label>
                                    <asp:TextBox ID="txtAccountTitle" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtAccountTitle" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                                </div>--%>

                                        <div class="col-md-2 col-sm-2">
                                            <label class="col-form-label">Balance  * :</label>
                                            <asp:TextBox ID="txtBalance" runat="server" Width="100%" Enabled="False"></asp:TextBox>
                                        </div>
                                        <div class="col-md-2 col-sm-2">
                                            <label class="col-form-label">Job No.</label>
                                            <asp:DropDownList ID="ddlJobID" runat="server" Width="100%"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RFV10" runat="server" ControlToValidate="ddlJobID" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-md-2 col-sm-2">
                                            <label class="col-form-label">Currency</label>
                                            <asp:DropDownList ID="ddlCurrencyID" runat="server" Width="100%" OnSelectedIndexChanged="ddlCurrencyID_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RFV6" runat="server" ControlToValidate="ddlCurrencyID" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                                        </div>
                                         <div class="col-md-2 col-sm-3">
                                            <label class="col-form-label">Rate</label>
                                            <asp:TextBox ID="txtRate" runat="server"  Width="100%" AutoPostBack="True" OnTextChanged="txtRate_TextChanged"></asp:TextBox><asp:RegularExpressionValidator ID="REV7" runat="server" ControlToValidate="txtRate"
                                                SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                ValidationGroup="A"></asp:RegularExpressionValidator>
                                            <AjaxToolKit:FilteredTextBoxExtender ID="FTBE7" runat="server"
                                                Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtRate"
                                                ValidChars=".-">
                                            </AjaxToolKit:FilteredTextBoxExtender>
                                            <asp:RequiredFieldValidator ID="RFV7" runat="server" ControlToValidate="txtRate" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                                        </div>

                                    </div>
                                    <div class="form-group row m-b-5">

                                       
                                        <div class="col-md-2 col-sm-2">
                                            <label class="col-form-label">Amount</label>
                                            <asp:TextBox ID="txtAmount" runat="server" Width="100%" AutoPostBack="True" OnTextChanged="txtAmount_TextChanged"></asp:TextBox><asp:RegularExpressionValidator ID="REV8" runat="server" ControlToValidate="txtAmount"
                                                SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                ValidationGroup="A"></asp:RegularExpressionValidator>
                                            <AjaxToolKit:FilteredTextBoxExtender ID="FTBE8" runat="server"
                                                Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtAmount"
                                                ValidChars=".-">
                                            </AjaxToolKit:FilteredTextBoxExtender>
                                            <asp:RequiredFieldValidator ID="RFV8" runat="server" ControlToValidate="txtAmount" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-md-2 col-sm-2">
                                            <label class="col-form-label">Local Amount </label>
                                            <asp:TextBox ID="txtLocalAmount" runat="server" Width="100%" Enabled="False"></asp:TextBox><asp:RegularExpressionValidator ID="REV9" runat="server" ControlToValidate="txtLocalAmount"
                                                SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                ValidationGroup="A"></asp:RegularExpressionValidator>
                                            <AjaxToolKit:FilteredTextBoxExtender ID="FTBE9" runat="server"
                                                Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtLocalAmount"
                                                ValidChars=".-">
                                            </AjaxToolKit:FilteredTextBoxExtender>
                                            <asp:RequiredFieldValidator ID="RFV9" runat="server" ControlToValidate="txtLocalAmount" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-md-2 col-sm-2">
                                            <label class="col-form-label">Cheque No. </label>
                                            <asp:TextBox ID="txtcheque" runat="server" Width="100%" Enabled="False"></asp:TextBox>
                                        </div>
                                        <div class="col-md-2 col-sm-2">
                                            <label class="col-form-label">Cheque Date </label>
                                            <asp:TextBox ID="txtdtCheque" runat="server" Width="100%" Enabled="False" placeholder="DD/MM/YYYY"></asp:TextBox>
                                            <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender1" runat="server"
                                                TargetControlID="txtdtCheque" Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtdtCheque"
                                                ValidationGroup="A" Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                                ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                            </asp:RegularExpressionValidator>
                                            <AjaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy"
                                                PopupButtonID="txtdtCheque" TargetControlID="txtdtCheque" PopupPosition="TopLeft" />
                                        </div>
                                        <div class="col-md-2 col-sm-6">
                                            <label class="col-form-label">Description  * :</label>
                                            <asp:TextBox ID="txtDescription" runat="server" Width="100%"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RFV5" runat="server" ControlToValidate="txtDescription" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-md-2 col-sm-6">
                                            <label class="col-form-label">Remarks.</label>
                                            <asp:TextBox ID="txtRemarks" runat="server" Width="100%"></asp:TextBox>
                                        </div>

                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                        <div class="form-group row m-b-15">
                            <div class="col-md-12 col-sm-12" style="text-align: center; padding: 10px;">
                                <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary" Text="Add" ValidationGroup="A" OnClick="btnAdd_Click" ToolTip="Add" />

                                <asp:Button ID="btnAddDet" runat="server" CssClass="btn btn-primary" Text="Add" ValidationGroup="A" OnClick="btnAddDet_Click" ToolTip="Add" />
                                <asp:Button ID="btnUpdateDet" runat="server" CssClass="btn btn-primary" Text="Update" ValidationGroup="B" OnClick="btnUpdateDet_Click" ToolTip="Update" />
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
                                DataKeyNames="nReceiptVoucherDetID" Width="100%" AllowPaging="false" AllowSorting="True" EmptyDataText="No Records to display"
                                OnPageIndexChanging="GridView2_PageIndexChanging">
                                <Columns>
                                    <asp:TemplateField HeaderText="nReceiptVoucherDetID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDetID" runat="server" Text='<%# Eval("nReceiptVoucherDetID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="sAccountTitle" HeaderText="Account Title" />
                                    <asp:BoundField DataField="sDescription" HeaderText="Description" />
                                    <asp:BoundField DataField="sCurrenccy" HeaderText="Currency" />
                                    <asp:BoundField DataField="nLocalAmount" HeaderText="Local Amount" />
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

                                        <div class="form-group row m-b-15">

                                            <div class="col-md-3 col-sm-3">

                                                <label class="col-form-label" for="email">Voucher No * :</label>

                                                <asp:DropDownList ID="ddlVoucherNoS" runat="server" CssClass="form-control js-example-placeholder-single">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-md-3 col-sm-3 ">
                                                <label class="col-form-label" for="email">Voucher Type * :</label>
                                                <asp:DropDownList ID="ddlVTypeS" runat="server" CssClass="form-control js-example-placeholder-single">
                                                    <asp:ListItem Text="Select Voucher Type" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="Cash Payment" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="Bank Payment" Value="2"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-md-2 col-sm-2" style="z-index: 999;">
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

                                            <div class="col-md-2 col-sm-2" style="z-index: 999999;">
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
                                            <div class="col-md-2 col-sm-2">
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
                                                    DataKeyNames="nReceiptVoucerID" Width="100%" AllowPaging="true" AllowSorting="True" PageSize="25" EmptyDataText="No Records to display"
                                                    OnPageIndexChanging="GridView1_PageIndexChanging">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="nReceiptVoucerID" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblID" runat="server" Text='<%# Eval("nReceiptVoucerID") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Voucher Date">
                                                            <ItemTemplate>
                                                                <%#validation.TextToDate(Eval("dtReceiptVoucher").ToString())%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="sReceiptVoucherNo" HeaderText="Voucher No" />
                                                        <asp:BoundField DataField="sVoucherType" HeaderText="Voucher Type" />
                                                        <asp:BoundField DataField="sPostedby" HeaderText="Postedby" />
                                                        <asp:BoundField DataField="sAmendedby" HeaderText="Amendedby" />
                                                        <asp:BoundField DataField="TotAmount" HeaderText="Total Amount" />
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
                </div>
                <!-- end panel-body -->

            </div>
            <!-- end panel -->
        </div>
        <!-- end col-6 -->

    </div>
    <!-- end row -->



</asp:Content>
