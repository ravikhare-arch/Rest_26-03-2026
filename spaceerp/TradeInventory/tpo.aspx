<%@ Page Title="Purchase Order" Language="C#" MasterPageFile="~/Pagecontent.master" AutoEventWireup="true" CodeFile="tpo.aspx.cs" Inherits="Transcation_po" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />
    <link type="text/css" rel="stylesheet" href="../assets/css/default/mystyle.css" />
    <link href="../assets/css/default/style.min.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.3/umd/popper.min.js" integrity="sha384-vFJXuSJphROIrBnz7yo7oB41mKfc8JzQZiCq4NCceLEaO4IHwicKwpJf9c9IpFgh" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta.2/js/bootstrap.min.js" integrity="sha384-alpBpkh1PFOepccYVYDB4do5UnbKysX5WZXm3XxPqe5iKTfUKjNkCk9SaVuEZflJ" crossorigin="anonymous"></script>
    
    <link href="../css/customize-model.css" rel="stylesheet" />
    <link href="../css/CustomModal.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <asp:UpdatePanel ID="UpdatePanel3" runat="server">
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
                    </div>
                    <div class="panel-heading-btn">
                        <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                        <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                    </div>

                    <h4 class="panel-title text-center">Purchase Order Details</h4>
                </div>
                <!-- end panel-heading -->
                <!-- begin panel-body -->
                <div class="panel-body">
                    <asp:Panel class="tbl" ID="tblmain" runat="server">
                        <asp:UpdatePanel ID="UP1" runat="server">
                            <ContentTemplate>
                                <div>
                                    <div class="form-group row">
                                        <div class="col-md-6 col-sm-2">
                                            <div class="form-group row">
                                                <div class="col-md-3 col-sm-2">
                                                    <label class="col-form-label" for="fullname">PO No. * :</label>

                                                    <asp:TextBox CssClass="form-control" ID="txtPoNo" runat="server" Width="100%" required Enabled="false"> </asp:TextBox>


                                                </div>

                                                <div class="col-md-3 col-sm-2" style="z-index: 99">
                                                    <label class="col-form-label" for="fullname">Order Date :</label>
                                                    <asp:TextBox CssClass="form-control" ID="txttOrder" runat="server" Width="100%" required placeholder="dd/mm/yyyy" AutoPostBack="true" OnTextChanged="txttOrder_TextChanged"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="REV4" ControlToValidate="txttOrder"
                                                        ValidationGroup="A" Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                                        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                                    </asp:RegularExpressionValidator>

                                                    <AjaxToolKit:CalendarExtender ID="CalendarExtender4" runat="server" Format="dd/MM/yyyy"
                                                        PopupButtonID="txttOrder" TargetControlID="txttOrder" PopupPosition="TopLeft" />

                                                    <AjaxToolKit:MaskedEditExtender ID="MEE4" runat="server"
                                                        TargetControlID="txttOrder" Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />

                                                </div>
                                                <div class="col-md-3 col-sm-2" style="z-index: 99">
                                                    <label class="col-form-label" for="fullname">Delivery Date :</label>
                                                    <asp:TextBox CssClass="form-control" ID="txttDelivery" runat="server" Width="100%" placeholder="dd/mm/yyyy" required></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="REV5" ControlToValidate="txttDelivery"
                                                        ValidationGroup="A" Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                                        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                                    </asp:RegularExpressionValidator>

                                                    <AjaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy"
                                                        PopupButtonID="txttDelivery" TargetControlID="txttDelivery" PopupPosition="TopLeft" />
                                                    <AjaxToolKit:MaskedEditExtender ID="MEE5" runat="server"
                                                        TargetControlID="txttDelivery" Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />

                                                </div>
                                                <div class="col-md-3 col-sm-2">
                                                    <label class="col-form-label" for="fullname">Location  :</label>
                                                    <asp:DropDownList CssClass="js-example-placeholder-single js-states form-control" ID="ddlLocation" runat="server"></asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RFV4" runat="server" ControlToValidate="ddlLocation" ErrorMessage="Please fill out this field." Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>
                                        <%-- <div class="col-md-2 col-sm-2">
                                    <label class="col-form-label" for="fullname">Status  :</label>
                                    <asp:TextBox CssClass="form-control" ID="txtStatus" runat="server" CssClass="form-control" required></asp:TextBox>
                                </div>--%>
                                        <div class="col-md-6 col-sm-2">
                                            <div class="form-group row">

                                                <div class="col-md-4 col-sm-3">
                                                    <label class="col-form-label" for="fullname">Vendor Name  :</label>
                                                    <asp:DropDownList ID="ddlVenderName" runat="server" CssClass="js-example-placeholder-single js-states form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlVenderName_SelectedIndexChanged"></asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlVenderName" ErrorMessage="Please fill out this field." Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-md-2 col-sm-3">
                                                    <label class="col-form-label" for="fullname">Balance :</label>
                                                    <asp:TextBox CssClass="form-control" ID="txtBalance" runat="server" Width="100%" Enabled="false"></asp:TextBox>

                                                </div>

                                                <div class="col-md-1 col-sm-1">
                                                    <div class="p-t-10">&nbsp;</div>
                                                    <asp:CheckBox ID="chkAttantion" runat="server" OnCheckedChanged="chkAttantion_CheckedChanged" AutoPostBack="true" />

                                                </div>
                                                <div class="col-md-2 col-sm-2">
                                                    <label class="col-form-label" for="fullname">Attn.</label>
                                                    <asp:TextBox CssClass="form-control" ID="txtAttention" runat="server" Width="100%" Enabled="false"></asp:TextBox>



                                                </div>
                                                <div class="col-md-1 col-sm-1 ">
                                                    <div class="p-t-10">&nbsp;</div>
                                                    <label class="col-form-label hide" for="fullname">Note</label>
                                                    <asp:CheckBox ID="chkNote" runat="server" OnCheckedChanged="chkNote_CheckedChanged" AutoPostBack="true" />


                                                </div>
                                                <div class="col-md-2 col-sm-2">
                                                    <label class="col-form-label" for="fullname">Note :</label>
                                                    <asp:TextBox CssClass="form-control" ID="txtNote" runat="server" Width="100%" Enabled="false"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>




                                    <div class="form-group row m-b-0" runat="server" visible="false">
                                        <label class="col-md-4 col-sm-4 col-form-label">&nbsp;</label>
                                        <div class="col-md-8 col-sm-8">


                                            <asp:Button ID="btnDelete" Visible="false" runat="server" CssClass="btn btn-primary" Text="Delete" OnClick="btnDelete_Click" ToolTip="Delete" />
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
                                    </div>

                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                        <asp:Panel class="tbl" ID="tblDet" runat="server">
                            <!-- begin row -->

                            <div style=" padding: 10px;">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <div class="form-group row m-b-15">

                                            <div class="col-md-2 col-sm-2">
                                                <label class="col-form-label" for="fullname">Item Mark * :</label>
                                                <asp:DropDownList ID="ddlItem" runat="server" CssClass="form-control js-example-placeholder-single" OnSelectedIndexChanged="ddlItem_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlItem" ErrorMessage="Please fill out this field." Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>

                                            </div>

                                            <div class="col-md-2 col-sm-2">
                                                <label class="col-form-label" for="fullname">Unit   :</label>
                                                <asp:DropDownList Width="100%" ID="ddlUnit" CssClass="form-control" Enabled="false" runat="server"></asp:DropDownList>
                                            </div>
                                            <div class="col-md-2 col-sm-2">
                                                <label class="col-form-label" for="fullname">Current  Stock :</label>
                                                <asp:TextBox CssClass="form-control" ID="txtStock" runat="server" Width="100%" Enabled="false" onkeypress="return fun_AllowOnlyAmountAndDot(this.id);"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtStock"
                                                    SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                    ValidationGroup="A"></asp:RegularExpressionValidator>
                                                <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                                    Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtStock"
                                                    ValidChars=".-">
                                                </AjaxToolKit:FilteredTextBoxExtender>
                                            </div>
                                            <div class="col-md-2 col-sm-2">
                                                <label class="col-form-label" for="fullname">Quantity :</label>
                                                <asp:TextBox CssClass="form-control" ID="txtQty" runat="server" Width="100%" OnTextChanged="txtQty_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtQty"
                                                    SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                    ValidationGroup="A"></asp:RegularExpressionValidator>
                                                <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                                    Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtQty"
                                                    ValidChars=".-">
                                                </AjaxToolKit:FilteredTextBoxExtender>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtQty" ErrorMessage="Please fill out this field." Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                <%--<asp:CompareValidator ID="RangeValidator1" runat="server" Display="Dynamic"
                                                    ErrorMessage="Stock Not Available" ValidationGroup="A" ControlToValidate="txtQty" Type="Integer" ControlToCompare="txtStock"
                                                    Operator="LessThanEqual"></asp:CompareValidator>--%>
                                            </div>
                                            <div class="col-md-2 col-sm-2">
                                                <label class="col-form-label" for="fullname">Unit Price :</label>
                                                <asp:TextBox CssClass="form-control" ID="txtUnitPrice" runat="server" Width="100%" OnTextChanged="txtUnitPrice_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtUnitPrice"
                                                    SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                    ValidationGroup="A"></asp:RegularExpressionValidator>
                                                <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                                    Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtUnitPrice"
                                                    ValidChars=".-">
                                                </AjaxToolKit:FilteredTextBoxExtender>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtUnitPrice" ErrorMessage="Please fill out this field." Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="col-md-2 col-sm-2">
                                                <label class="col-form-label" for="fullname">Total Price :</label>
                                                <asp:TextBox CssClass="form-control" ID="txtTotalPrice" runat="server" Width="100%" Enabled="false"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtTotalPrice"
                                                    SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                    ValidationGroup="A"></asp:RegularExpressionValidator>
                                                <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                                    Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtTotalPrice"
                                                    ValidChars=".-">
                                                </AjaxToolKit:FilteredTextBoxExtender>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <div class="form-group row m-b-15">

                                            <div class="col-md-3 col-sm-3">
                                                <label class="col-form-label" for="fullname">Tax Name * :</label>
                                                <asp:DropDownList ID="ddlTaxName" CssClass="form-control" runat="server" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="ddlTaxName_SelectedIndexChanged"></asp:DropDownList>
                                            </div>

                                            <div class="col-md-3 col-sm-3">
                                                <label class="col-form-label" for="fullname">Tax Type   :</label>
                                                <asp:DropDownList CssClass="form-control" Width="100%" ID="ddlTaxType" Enabled="false" runat="server">
                                                    <asp:ListItem Value="0" Text="Select Type"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="Amount"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="% Percentage"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-md-3 col-sm-3">
                                                <label class="col-form-label" for="fullname">Tax Value :</label>
                                                <asp:TextBox CssClass="form-control" ID="txtTaxValue" runat="server" Width="100%" Text="0" Enabled="true"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtTaxValue"
                                                    SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                    ValidationGroup="A"></asp:RegularExpressionValidator>
                                                <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server"
                                                    Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtTaxValue"
                                                    ValidChars=".-">
                                                </AjaxToolKit:FilteredTextBoxExtender>
                                            </div>
                                            <div class="col-md-3 col-sm-3">
                                                <label class="col-form-label" for="fullname">Taxable Amount :</label>
                                                <asp:TextBox CssClass="form-control" ID="txtTaxableAmount" runat="server" Width="100%" Text="0" Enabled="true"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="txtTaxableAmount"
                                                    SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                    ValidationGroup="A"></asp:RegularExpressionValidator>
                                                <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server"
                                                    Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtTaxableAmount"
                                                    ValidChars=".-">
                                                </AjaxToolKit:FilteredTextBoxExtender>
                                            </div>

                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <div class="form-group row m-b-0">
                                    <div class="col-md-12 col-sm-12" style="text-align: center;">
                                        <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary btnspl" Text="Add" ValidationGroup="A" OnClick="btnAdd_Click" ToolTip="Add" />
                                        <asp:Button ID="btnAddDet" runat="server" CssClass="btn btn-primary" Text="Add" ValidationGroup="A" OnClick="btnAddDet_Click" ToolTip="Add" />
                                        <asp:Button ID="btnUpdateDet" runat="server" CssClass="btn btn-primary" Text="Update" ValidationGroup="A" OnClick="btnUpdateDet_Click" ToolTip="Update" />
                                        <asp:Button ID="btnDeleteDet" runat="server" CssClass="btn btn-primary" Text="Delete" ValidationGroup="A" OnClick="btnDeleteDet_Click" ToolTip="Delete" />
                                         <asp:Button ID="btnPrint" runat="server" CssClass="btn btn-primary" Text="Print" OnClick="btnPrint_Click" ToolTip="Print" Visible="false" />
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
                                        </asp:Panel>

                                    </div>
                                </div>

                            </div>

                            <div class="form-group row m-b-15">
                                <div class="col-md-12 col-sm-12">
                                    <br />
                                    <asp:Panel class="tbl table-responsive" ID="tblGridDet" runat="server">

                                        <asp:Label ID="lblpgsDet" runat="server" Text="Page Size :"></asp:Label>
                                        <asp:DropDownList ID="ddlPageSizeDet" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPageSizeDet_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:GridView ID="GridView2" CssClass="table table-striped table-bordered" runat="server" AutoGenerateColumns="False"
                                            DataKeyNames="nPoDetID" Width="100%" AllowPaging="false" AllowSorting="True" EmptyDataText="No Records to display"
                                            OnPageIndexChanging="GridView2_PageIndexChanging">
                                            <Columns>
                                                <asp:TemplateField HeaderText="nPoDetID" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblIDDet" runat="server" Text='<%# Eval("nPoDetID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="sItemName" HeaderText="Item Name" />
                                                <asp:BoundField DataField="sItemUnit" HeaderText="Unit" />
                                                <asp:BoundField DataField="nQuantity" HeaderText="Quantity" />
                                                <asp:BoundField DataField="nUnitPrice" HeaderText="Unit Price" />
                                                <asp:BoundField DataField="sTaxName" HeaderText="Tax Name" />
                                                <asp:BoundField DataField="nTaxableAmount" HeaderText="Tax Amount" />
                                                <asp:BoundField DataField="nTotalPrice" HeaderText="Total Price" />
                                                <asp:TemplateField HeaderText="Edit/Delete">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btngdEditDet" runat="server" OnClick="btngdEditDet_Click" ToolTip="Edit">
                                                       
                           <i class="far fa-lg fa-fw m-r-10 fa-edit fa-grid-edit"></i> &nbsp;&nbsp;<span class="text-inverse">Edit</span>
                                                        </asp:LinkButton>
                                                        <asp:LinkButton ID="btngdDeleteDet" runat="server" OnClick="btngdDeleteDet_Click" ToolTip="Delete">
                           <i class="far fa-lg fa-fw m-r-10 fa-trash-alt fa-grid-del"></i> &nbsp;&nbsp;<span class="text-inverse">Delete</span>
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
                                        <asp:Panel class="tbl table-responsive" Visible="false" ID="tblGridTax" runat="server">


                                            <asp:GridView ID="gridTax" CssClass="table table-striped table-bordered" runat="server" AutoGenerateColumns="False"
                                                DataKeyNames="nTaxTemplateDetID" Width="100%" AllowSorting="True">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="nTaxTemplateDetID" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblIDDet" runat="server" Text='<%# Eval("nTaxTemplateDetID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="">
                                                        <ItemTemplate>

                                                            <asp:Label ID="lblTaxName" runat="server" Text='<%# Eval("sTaxName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="">
                                                        <ItemTemplate>
                                                            <% if (Eval("nTaxTypeID").ToString() == "2")
                                                               { %>
                                                            <asp:TextBox CssClass="form-control" ID="txtTaxPer" runat="server" Text='<%# Eval("nTaxValue") %>'></asp:TextBox>
                                                            <%
                                                               }
                                                            %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="">
                                                        <ItemTemplate>

                                                            <asp:TextBox CssClass="form-control" ID="txtAmount" runat="server" Text='<%# Eval("nAmount") %>'></asp:TextBox>

                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                </Columns>
                                            </asp:GridView>

                                        </asp:Panel>
                                    </asp:Panel>
                                </div>
                            </div>



                        </asp:Panel>

                        <asp:Panel ID="tblbootomPage" runat="server">
                            <div style=" padding: 10px;">
                                <asp:UpdatePanel ID="up10" runat="server">
                                    <ContentTemplate>

                                        <div class="form-group row m-b-15">
                                            <div class="col-md-2 col-sm-2">
                                                <label class="col-form-label" for="fullname">Sub Total :</label>
                                                <asp:TextBox CssClass="form-control" ID="txtSubTot" runat="server" Width="100%" Text="0" Enabled="false"></asp:TextBox>
                                            </div>
                                            <div class="col-md-2 col-sm-2">
                                                <label class="col-form-label" for="fullname">Shipping & Pack Cost :</label>
                                                <asp:TextBox ID="txtShippimngCost" runat="server" Text="0" CssClass="form-control" Enabled="true" AutoPostBack="True" OnTextChanged="txtShippimngCost_TextChanged"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server" ControlToValidate="txtShippimngCost"
                                                    SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                    ValidationGroup="A"></asp:RegularExpressionValidator>
                                                <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" runat="server"
                                                    Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtShippimngCost"
                                                    ValidChars=".-">
                                                </AjaxToolKit:FilteredTextBoxExtender>


                                            </div>


                                            <div class="col-md-2 col-sm-2">
                                                <label class="col-form-label" for="fullname">Other Charges :</label>
                                                <asp:TextBox CssClass="form-control" ID="txtOtherCharges" runat="server" Width="100%" Text="0" Enabled="true" AutoPostBack="True" OnTextChanged="txtOtherCharges_TextChanged"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="txtOtherCharges"
                                                    SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                    ValidationGroup="A"></asp:RegularExpressionValidator>
                                                <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server"
                                                    Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtOtherCharges"
                                                    ValidChars=".-">
                                                </AjaxToolKit:FilteredTextBoxExtender>
                                            </div>
                                            <div class="col-md-1 col-sm-1">
                                                <label class="col-form-label" for="fullname">Discount :</label>
                                                <asp:TextBox CssClass="form-control" ID="txtDiscount" runat="server" Width="100%" Text="0" AutoPostBack="True" OnTextChanged="txtDiscount_TextChanged"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" ControlToValidate="txtDiscount"
                                                    SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                    ValidationGroup="A"></asp:RegularExpressionValidator>
                                                <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server"
                                                    Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtDiscount"
                                                    ValidChars=".-">
                                                </AjaxToolKit:FilteredTextBoxExtender>
                                            </div>
                                            <div class="col-md-2 col-sm-2">
                                                <label class="col-form-label" for="fullname">Tax :</label>
                                                <asp:TextBox CssClass="form-control" ID="txtTaxTotal" runat="server" Width="100%" Enabled="false" Text="0"></asp:TextBox>

                                            </div>
                                            <div class="col-md-2 col-sm-2">
                                                <label class="col-form-label" for="fullname">Grand Total</label>
                                                <asp:TextBox CssClass="form-control" ID="txtGrandTot" runat="server" Width="100%" Enabled="false" Text="0"></asp:TextBox>

                                            </div>
                                            <div class="col-md-1 col-sm-1 text-center m-t-30">

                                                <asp:Button ID="btnUpdate" Visible="true" runat="server" CssClass="btn btn-primary" Text="Save" ValidationGroup="B" OnClick="btnUpdate_Click" ToolTip="Update" />

                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <div class="form-group row m-b-15">
                                </div>

                            </div>
                        </asp:Panel>
                    </asp:Panel>

                    <asp:Panel class="tbl table-responsive" ID="tblGrd" runat="server">
                        <div class="form-group row m-b-20">
                            <div class="col-md-3 col-sm-3">
                                <label class="col-form-label" for="fullname">Vendor Name  :</label>
                                <asp:DropDownList CssClass="form-control js-example-placeholder-single" ID="ddlVendSearch" runat="server">
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-3 col-sm-3">
                                <label class="col-form-label" for="fullname">Sales Order No.  :</label>
                                <asp:DropDownList CssClass="form-control js-example-placeholder-single" ID="ddlPoSearch" runat="server">
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-2 col-sm-2" style="z-index: 9999;">
                                <label class="col-form-label" for="fullname">From Date :</label>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        <asp:ImageButton ID="img7" runat="server" ImageUrl="~/assets/img/Calendar-icon.png" Width="16" Height="16" />
                                    </div>
                                    <asp:TextBox ID="txtdtFroms" runat="server" CssClass="form-control"></asp:TextBox>

                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ControlToValidate="txtdtFroms"
                                        ValidationGroup="A" Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                    </asp:RegularExpressionValidator>
                                    <AjaxToolKit:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy"
                                        PopupButtonID="img7" TargetControlID="txtdtFroms" PopupPosition="BottomLeft" />
                                    <AjaxToolKit:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd/MM/yyyy"
                                        PopupButtonID="txtdtFroms" TargetControlID="txtdtFroms" PopupPosition="BottomLeft" />

                                    <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender1" runat="server"
                                        TargetControlID="txtdtFroms" Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                </div>
                            </div>
                            <div class="col-md-2 col-sm-2" style="z-index: 9999;">
                                <label class="col-form-label" for="fullname">To Date :</label>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        <asp:ImageButton ID="img6" runat="server" ImageUrl="~/assets/img/Calendar-icon.png" Width="16" Height="16" />
                                    </div>
                                    <asp:TextBox ID="txtdtTo" runat="server" CssClass="form-control"></asp:TextBox>

                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" ControlToValidate="txtdtTo"
                                        ValidationGroup="A" Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                    </asp:RegularExpressionValidator>
                                    <AjaxToolKit:CalendarExtender ID="CalendarExtender5" runat="server" Format="dd/MM/yyyy"
                                        PopupButtonID="img6" TargetControlID="txtdtTo" PopupPosition="BottomLeft" />
                                    <AjaxToolKit:CalendarExtender ID="CalendarExtender6" runat="server" Format="dd/MM/yyyy"
                                        PopupButtonID="txtdtTo" TargetControlID="txtdtTo" PopupPosition="BottomLeft" />
                                    <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender2" runat="server"
                                        TargetControlID="txtdtTo" Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                </div>
                            </div>
                            <div class="col-md-2 col-sm-2">
                                <label class="col-form-label" for="fullname">Search</label><br />
                                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btnspl btn-primary" ToolTip="Search" OnClick="btnSearch_Click" />
                            </div>
                        </div>
                        <asp:Label ID="lblpgs" runat="server" Text="Page Size :"></asp:Label>
                        <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
                        </asp:DropDownList>
                        <div>&nbsp;</div>
                        <asp:GridView ID="GridView1" CssClass="table table-striped table-bordered" runat="server" AutoGenerateColumns="False"
                            DataKeyNames="nPoID" Width="100%" AllowPaging="true" AllowSorting="True" PageSize="25" EmptyDataText="No Records to display"
                            OnPageIndexChanging="GridView1_PageIndexChanging">
                            <Columns>
                                <asp:TemplateField HeaderText="nPoID" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblID" runat="server" Text='<%# Eval("nPoID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="sPoNo" HeaderText="PO No." />
                                <asp:TemplateField HeaderText="Order Date">
                                    <ItemTemplate>
                                        <%#validation.TextToDate(Eval("dtOrder").ToString())%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delivery Date">
                                    <ItemTemplate>
                                        <%#validation.TextToDate(Eval("dtDelivery").ToString())%>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:BoundField DataField="sVendorName" HeaderText="Vendor Name" />
                                <asp:TemplateField HeaderText="Edit/Delete">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btngdEdit" runat="server" OnClick="btngdEdit_Click" ToolTip="Edit">
                           <i class="far fa-lg fa-fw m-r-10 fa-edit fa-grid-edit"></i> <span class="text-inverse">Edit</span>
                                        </asp:LinkButton>
                                        <asp:LinkButton ID="btngdPrint" runat="server" OnClick="btngdPrint_Click" ToolTip="Print">
                           <i class="fas fa-lg fa-fw m-r-10 fa-print fa-grid-edit"></i> <span class="text-inverse">Print</span> </asp:LinkButton>
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
                </div>
                <!-- end panel-body -->

            </div>
            <!-- end panel -->
        </div>
        <!-- end col-6 -->

    </div>
    <!-- end row -->



</asp:Content>
